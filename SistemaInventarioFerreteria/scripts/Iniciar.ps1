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
$demoDataScript = Join-Path (Split-Path -Parent $projectDirectory) "DatosDemostracion.sql"
$applicationDll = Join-Path $projectDirectory "bin\Debug\net10.0\SistemaInventarioFerreteria.dll"
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

function Find-DotNet10Sdk {
    $candidatePaths = @()
    $pathCommand = Get-Command "dotnet.exe" -ErrorAction SilentlyContinue

    if ($null -ne $pathCommand) {
        $candidatePaths += $pathCommand.Source
    }

    $programFiles = [Environment]::GetFolderPath([Environment+SpecialFolder]::ProgramFiles)
    if (-not [string]::IsNullOrWhiteSpace($programFiles)) {
        $candidatePaths += (Join-Path $programFiles "dotnet\dotnet.exe")
    }

    if (-not [string]::IsNullOrWhiteSpace($env:LOCALAPPDATA)) {
        $candidatePaths += (Join-Path $env:LOCALAPPDATA "Microsoft\dotnet\dotnet.exe")
    }

    foreach ($candidatePath in ($candidatePaths | Select-Object -Unique)) {
        if (-not (Test-Path -LiteralPath $candidatePath -PathType Leaf)) {
            continue
        }

        $installedSdks = & $candidatePath --list-sdks 2>$null
        $sdkCommandExitCode = $LASTEXITCODE
        $hasDotNet10Sdk = $installedSdks | Where-Object { $_ -match '^\s*10\.0\.\d+' } | Select-Object -First 1

        if ($sdkCommandExitCode -eq 0 -and $null -ne $hasDotNet10Sdk) {
            return $candidatePath
        }
    }

    return $null
}

function Install-DotNet10Sdk {
    $wingetCommand = Get-Command "winget.exe" -ErrorAction SilentlyContinue
    if ($null -eq $wingetCommand) {
        throw "No se encontro el SDK de .NET 10 ni el instalador winget. Instalalo desde https://dotnet.microsoft.com/download/dotnet/10.0"
    }

    Write-Step "Instalando el SDK oficial de .NET 10"
    Write-Host "Windows puede solicitar permiso de administrador para completar la instalacion." -ForegroundColor Yellow

    & $wingetCommand.Source install `
        --id "Microsoft.DotNet.SDK.10" `
        --exact `
        --source "winget" `
        --accept-source-agreements `
        --accept-package-agreements

    if ($LASTEXITCODE -ne 0) {
        throw "No fue posible instalar el SDK de .NET 10 mediante winget (codigo $LASTEXITCODE)."
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

    $dotnetPath = Find-DotNet10Sdk
    if ($null -eq $dotnetPath) {
        Install-DotNet10Sdk
        $dotnetPath = Find-DotNet10Sdk

        if ($null -eq $dotnetPath) {
            throw "La instalacion termino, pero el SDK de .NET 10 aun no esta disponible. Cierra esta ventana, vuelve a abrir INICIAR.cmd y, si el problema continua, repara la instalacion de .NET 10."
        }
    }

    $sqlcmdCommand = Get-Command "sqlcmd.exe" -ErrorAction SilentlyContinue
    if ($null -eq $sqlcmdCommand) {
        throw "No se encontro sqlcmd. Instala SQL Server Express con las herramientas de linea de comandos."
    }
    $script:sqlcmdPath = $sqlcmdCommand.Source

    if (-not (Test-Path -LiteralPath $databaseScript)) {
        throw "No se encontro el archivo de base de datos: $databaseScript"
    }

    if (-not (Test-Path -LiteralPath $demoDataScript)) {
        throw "No se encontro el archivo de datos demostrativos: $demoDataScript"
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
        Write-Step "La base InventarioFerreteriaDB ya existe; se conservaran sus datos"
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

    Write-Step "Comprobando los datos demostrativos"
    Invoke-SqlCommand -Arguments @(
        "-d", "InventarioFerreteriaDB",
        "-i", $demoDataScript
    ) | ForEach-Object { Write-Host $_ }

    $connectionString = "Server=$SqlServer;Database=InventarioFerreteriaDB;Integrated Security=True;Encrypt=False;MultipleActiveResultSets=True;"
    $env:ConnectionStrings__ConexionSQL = $connectionString

    Write-Step "Restaurando las dependencias del proyecto"
    Invoke-CheckedCommand -Command $dotnetPath -Arguments @(
        "restore", $projectFile,
        "--configfile", $nugetConfig,
        "--nologo"
    )

    Write-Step "Compilando el sistema"
    Invoke-CheckedCommand -Command $dotnetPath -Arguments @(
        "build", $projectFile,
        "--no-restore",
        "--configuration", "Debug",
        "-p:UseAppHost=false",
        "--nologo"
    )

    if (-not (Test-Path -LiteralPath $applicationDll -PathType Leaf)) {
        throw "La compilacion termino, pero no se encontro la aplicacion: $applicationDll"
    }

    Write-Step "Iniciando el sistema en $applicationUrl"
    Write-Host "Modo compatible con Application Control: dotnet.exe ejecutara la DLL; no se usara un archivo EXE local." -ForegroundColor DarkGray
    Write-Host "Para detenerlo, presiona Ctrl+C." -ForegroundColor DarkGray

    $env:ASPNETCORE_ENVIRONMENT = "Development"
    $env:ASPNETCORE_URLS = $applicationUrl

    if (-not $NoAbrirNavegador) {
        $browserCommand = "Start-Sleep -Seconds 3; Start-Process '$applicationUrl'"
        Start-Process -FilePath "powershell.exe" -WindowStyle Hidden -ArgumentList @(
            "-NoLogo",
            "-NoProfile",
            "-WindowStyle", "Hidden",
            "-Command", $browserCommand
        ) | Out-Null
    }

    Push-Location $projectDirectory
    try {
        & $dotnetPath exec $applicationDll
        if ($LASTEXITCODE -ne 0) {
            throw "La aplicacion termino con el codigo $LASTEXITCODE."
        }
    }
    finally {
        Pop-Location
    }
}
catch {
    Write-Host ""
    Write-Host "ERROR: $($_.Exception.Message)" -ForegroundColor Red
    exit 1
}
