# Sistema de Inventario de Ferretería

Aplicación web ASP.NET Core MVC para administrar productos, categorías, marcas,
proveedores, sucursales e inventario de una ferretería. Utiliza Microsoft SQL
Server y Entity Framework Core.

## Funciones implementadas

- CRUD de inventario y entradas de inventario.
- CRUD de ventas con actualización automática de existencias.
- CRUD de variantes de producto y validación de SKU único.
- Inicio de sesión con perfiles Administrador y Operador.
- Asistente de inventario de solo lectura, utilizable localmente y preparado para OpenAI.

Para que el código sea fácil de estudiar, el formulario de ventas registra un producto por venta. El Administrador mantiene los catálogos; el Operador registra entradas y ventas y consulta el inventario.

## Acceso de demostración

| Perfil | Usuario | Contraseña |
| --- | --- | --- |
| Administrador | `admin` | `Admin123*` |
| Operador | `operador` | `Operador123*` |

Estas cuentas son académicas. Deben cambiarse en `appsettings.json` o mediante variables de entorno antes de publicar la aplicación.

## Requisitos

- Windows 10 u 11.
- Acceso a Internet y `winget` para instalar automáticamente el SDK de .NET 10
  si todavía no está disponible.
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

3. Si falta el SDK de .NET 10, el script instala automáticamente el paquete
   oficial `Microsoft.DotNet.SDK.10` mediante `winget`; Windows puede solicitar
   permiso de administrador.
4. El script comprueba SQL Server, crea `InventarioFerreteriaDB` desde
   `BaseDatos.txt` si aún no existe, restaura las dependencias, compila el
   proyecto y abre `http://localhost:5118`. La aplicación se ejecuta como DLL
   mediante `dotnet.exe`, sin depender de un ejecutable local sin firmar.
5. Para detener la aplicación, presiona `Ctrl+C` en la ventana de ejecución.

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
$env:ConnectionStrings__ConexionSQL = "Server=.\NOMBRE_INSTANCIA;Database=InventarioFerreteriaDB;Integrated Security=True;Encrypt=False;MultipleActiveResultSets=True;"
$env:ASPNETCORE_ENVIRONMENT = "Development"
$env:ASPNETCORE_URLS = "http://localhost:5118"
dotnet .\bin\Debug\net10.0\SistemaInventarioFerreteria.dll
```

## Asistente IA

El asistente funciona sin servicios externos: consulta disponibilidad, explica reposiciones y resume alertas con datos verificables de SQL Server. Para habilitar también una explicación redactada por OpenAI, configura:

```powershell
$env:OpenAI__ApiKey = "TU-CLAVE"
$env:OpenAI__Modelo = "gpt-5-nano"
.\INICIAR.cmd
```

No guardes la clave en Git. La IA no modifica datos y no inventa cantidades: OpenAI solo explica el cálculo hecho por el sistema. `gpt-5-nano` es el modelo predeterminado para mantener bajo el costo.

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

- La conexión usa autenticación integrada de Windows; no contiene usuarios ni
  contraseñas de SQL Server.
- Las contraseñas de inicio de sesión incluidas son únicamente de demostración.
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
- **No se pudo instalar el SDK:** comprueba la conexión a Internet, que `winget`
  esté disponible y acepta la solicitud de administrador de Windows.
- **La instancia tiene otro nombre:** pásala como argumento a `INICIAR.cmd`.
- **La estructura está incompleta:** respalda o renombra la base existente antes
  de volver a ejecutar el inicio.
