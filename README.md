# Sistema de Inventario de Ferretería

Aplicación web ASP.NET Core MVC para administrar productos, categorías, marcas,
proveedores, sucursales e inventario de una ferretería. Utiliza Microsoft SQL
Server y Entity Framework Core.

## Requisitos

- Windows 10 u 11.
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
- SQL Server Express con una instancia llamada `SQLEXPRESS`.
- La herramienta `sqlcmd`, incluida con las herramientas de línea de comandos
  de SQL Server.

## Instalación y ejecución rápida

1. Clona el repositorio y entra al proyecto:

   ```powershell
   git clone https://github.com/caleb-bvm/DSP-Inventariado-Ferreteria.git
   cd DSP-Inventariado-Ferreteria\SistemaInventarioFerreteria
   ```

2. Ejecuta `INICIAR.cmd` con doble clic o desde PowerShell:

   ```powershell
   .\INICIAR.cmd
   ```

3. El script comprueba SQL Server, crea `InventarioFerreteriaDB` desde
   `BaseDatos.txt` si aún no existe, restaura las dependencias, compila el
   proyecto y abre `http://localhost:5118`. La aplicación se ejecuta como DLL
   mediante `dotnet.exe`, sin depender de un ejecutable local sin firmar.
4. Para detener la aplicación, presiona `Ctrl+C` en la ventana de ejecución.

El inicio es idempotente: si la base de datos ya existe, el script no vuelve a
importarla ni sobrescribe sus datos.

## Usar otra instancia de SQL Server

Indica la instancia como primer argumento:

```powershell
.\INICIAR.cmd ".\NOMBRE_INSTANCIA"
```

También puedes definir la cadena de conexión únicamente para la sesión actual,
sin modificar archivos del repositorio:

```powershell
$env:ConnectionStrings__ConexionSQL = "Server=.\NOMBRE_INSTANCIA;Database=InventarioFerreteriaDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;"
$env:ASPNETCORE_ENVIRONMENT = "Development"
$env:ASPNETCORE_URLS = "http://localhost:5118"
dotnet .\bin\Debug\net10.0\SistemaInventarioFerreteria.dll
```

## Visual Studio

Ejecuta `INICIAR.cmd` al menos una vez para preparar la base y las dependencias.
Después abre `SistemaInventarioFerreteria.slnx` y selecciona el perfil `http`.

## Comprobación del proyecto

Desde `SistemaInventarioFerreteria`:

```powershell
dotnet restore --configfile .\NuGet.Config
dotnet build --no-restore
```

El proyecto tiene `UseAppHost=false`: la compilación genera la DLL administrada
y no necesita iniciar `SistemaInventarioFerreteria.exe`.

## Compatibilidad con Windows Application Control

Algunas computadoras bloquean los ejecutables locales sin firma generados por
.NET. `INICIAR.cmd` evita ese problema ejecutando la aplicación de esta forma:

```powershell
dotnet exec .\bin\Debug\net10.0\SistemaInventarioFerreteria.dll
```

No es necesario desactivar Smart App Control, AppLocker, WDAC ni el antivirus.
Si una política también bloquea `dotnet.exe`, un administrador deberá autorizar
el SDK oficial de .NET; el proyecto no intenta eludir esa política.

## Seguridad

- La configuración incluida usa autenticación integrada de Windows; no contiene
  usuarios ni contraseñas de SQL Server.
- Para credenciales o configuraciones privadas, usa variables de entorno o
  Secret Manager de .NET. No las escribas en `appsettings.json`.
- Los archivos `.env`, certificados, claves, configuraciones locales, resultados
  de compilación y la carpeta `tmp` están excluidos de Git.
- La configuración predeterminada acepta únicamente `localhost` y `127.0.0.1`.
  En un despliegue real, configura los hosts autorizados y HTTPS para el dominio
  correspondiente.
- Antes de modificar o volver a crear la base, realiza una copia de seguridad. El
  script de inicio nunca elimina automáticamente una base existente.

## Solución de problemas

- **SQL Server está detenido:** ejecuta `INICIAR.cmd` como administrador una vez.
- **No se encontró `sqlcmd`:** instala las herramientas de línea de comandos de
  SQL Server y vuelve a abrir la terminal.
- **La instancia tiene otro nombre:** pásala como argumento a `INICIAR.cmd`.
- **La estructura está incompleta:** respalda o renombra la base existente antes
  de volver a ejecutar el inicio.
