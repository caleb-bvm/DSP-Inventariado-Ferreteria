[CmdletBinding()]
param(
    [Parameter(Position = 0)]
    [string]$SqlServer = ".\SQLEXPRESS",

    [switch]$NoAbrirNavegador
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

$projectDirectory = Split-Path -Parent $PSScriptRoot
$projectFile = Join-Path $projectDirectory "SistemaInventarioFerreteria.csproj"
$nugetConfig = Join-Path $projectDirectory "NuGet.Config"
$databaseScript = Join-Path (Split-Path -Parent $projectDirectory) "BaseDatos.txt"
$applicationUrl = "http://localhost:5118"

function Write-Step {
    param([string]$Message)

    Write-Host ""
    Write-Host "==> $Message" -ForegroundColor Cyan
}

function Invoke-CheckedCommand {
    param(
        [Parameter(Mandatory)]
        [string]$Command,

        [Parameter(Mandatory)]
        [string[]]$Arguments
    )

    & $Command @Arguments
    if ($LASTEXITCODE -ne 0) {
        throw "El comando '$Command' termino con el codigo $LASTEXITCODE."
    }
}

function Invoke-SqlCommand {
    param(
        [Parameter(Mandatory)]
        [string[]]$Arguments
    )

    $baseArguments = @(
        "-S", $SqlServer,
        "-E",
        "-C",
        "-l", "8",
        "-b"
    )

    $output = & $script:sqlcmdPath @baseArguments @Arguments 2>&1
    if ($LASTEXITCODE -ne 0) {
        $output | ForEach-Object { Write-Host $_ -ForegroundColor Red }
        throw "No fue posible ejecutar una instruccion en SQL Server '$SqlServer'."
    }

    return $output
}

try {
    Write-Host "Sistema de Inventario de Ferreteria" -ForegroundColor Green
    Write-Host "Servidor SQL: $SqlServer"

    $dotnetCommand = Get-Command "dotnet.exe" -ErrorAction SilentlyContinue
    if ($null -eq $dotnetCommand) {
        throw "No se encontro .NET 10 SDK. Instalalo desde https://dotnet.microsoft.com/download/dotnet/10.0"
    }

    $sqlcmdCommand = Get-Command "sqlcmd.exe" -ErrorAction SilentlyContinue
    if ($null -eq $sqlcmdCommand) {
        throw "No se encontro sqlcmd. Instala SQL Server Express con las herramientas de linea de comandos."
    }
    $script:sqlcmdPath = $sqlcmdCommand.Source

    if (-not (Test-Path -LiteralPath $databaseScript)) {
        throw "No se encontro el archivo de base de datos: $databaseScript"
    }

    if ($SqlServer.StartsWith(".\", [System.StringComparison]::Ordinal)) {
        $instanceName = $SqlServer.Substring(2)
        $serviceName = "MSSQL`$$instanceName"
        $sqlService = Get-Service -Name $serviceName -ErrorAction SilentlyContinue

        if ($null -eq $sqlService) {
            throw "No se encontro la instancia local '$SqlServer'. Instala SQL Server Express usando el nombre SQLEXPRESS."
        }

        if ($sqlService.Status -ne "Running") {
            Write-Step "Iniciando el servicio de SQL Server"
            try {
                Start-Service -Name $serviceName
                $sqlService.WaitForStatus("Running", [TimeSpan]::FromSeconds(20))
            }
            catch {
                throw "SQL Server esta detenido. Ejecuta INICIAR.cmd como administrador una vez para iniciarlo."
            }
        }
    }

    Write-Step "Comprobando la conexion con SQL Server"
    Invoke-SqlCommand -Arguments @(
        "-Q", "SET NOCOUNT ON; SELECT 1;"
    ) | Out-Null

    $databaseStatus = Invoke-SqlCommand -Arguments @(
        "-d", "master",
        "-h", "-1",
        "-W",
        "-Q", "SET NOCOUNT ON; SELECT CASE WHEN DB_ID(N'InventarioFerreteriaDB') IS NULL THEN 0 ELSE 1 END;"
    )
    $databaseExists = ($databaseStatus -join "`n") -match "(?m)^\s*1\s*$"

    if (-not $databaseExists) {
        Write-Step "Creando InventarioFerreteriaDB y cargando los datos iniciales"
        Invoke-SqlCommand -Arguments @(
            "-i", $databaseScript
        ) | ForEach-Object { Write-Host $_ }
    }
    else {
        Write-Step "La base InventarioFerreteriaDB ya existe; no se modificaran sus datos"
    }

    $schemaStatus = Invoke-SqlCommand -Arguments @(
        "-d", "InventarioFerreteriaDB",
        "-h", "-1",
        "-W",
        "-Q", "SET NOCOUNT ON; SELECT COUNT(*) FROM sys.tables WHERE name IN (N'Categorias', N'Marcas', N'Productos', N'VariantesProducto', N'Sucursales', N'Proveedores', N'Inventarios', N'EntradasInventario', N'Ventas', N'DetalleVentas', N'MovimientosInventario', N'Alertas', N'Recomendaciones');"
    )
    $schemaTableCount = ($schemaStatus | ForEach-Object { "$($_)".Trim() } | Where-Object { $_ -match "^\d+$" } | Select-Object -Last 1)

    if ($schemaTableCount -ne "13") {
        throw "La base existe, pero su estructura esta incompleta ($schemaTableCount de 13 tablas esperadas). No se sobrescribio ningun dato."
    }

    $connectionString = "Server=$SqlServer;Database=InventarioFerreteriaDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;"
    $env:ConnectionStrings__ConexionSQL = $connectionString

    Write-Step "Restaurando las dependencias del proyecto"
    Invoke-CheckedCommand -Command $dotnetCommand.Source -Arguments @(
        "restore", $projectFile,
        "--configfile", $nugetConfig,
        "--nologo"
    )

    Write-Step "Compilando el sistema"
    Invoke-CheckedCommand -Command $dotnetCommand.Source -Arguments @(
        "build", $projectFile,
        "--no-restore",
        "--nologo"
    )

    Write-Step "Iniciando el sistema en $applicationUrl"
    Write-Host "Para detenerlo, presiona Ctrl+C." -ForegroundColor DarkGray

    if (-not $NoAbrirNavegador) {
        $browserCommand = "Start-Sleep -Seconds 3; Start-Process '$applicationUrl'"
        Start-Process -FilePath "powershell.exe" -WindowStyle Hidden -ArgumentList @(
            "-NoLogo",
            "-NoProfile",
            "-WindowStyle", "Hidden",
            "-Command", $browserCommand
        ) | Out-Null
    }

    & $dotnetCommand.Source run `
        --project $projectFile `
        --no-build `
        --launch-profile http
}
catch {
    Write-Host ""
    Write-Host "ERROR: $($_.Exception.Message)" -ForegroundColor Red
    exit 1
}
