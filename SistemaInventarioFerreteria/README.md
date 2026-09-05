# Sistema de Inventario de Ferreteria

Aplicacion web ASP.NET Core MVC conectada a **Microsoft SQL Server**. La configuracion local usa autenticacion de Windows, por lo que no guarda usuarios ni contrasenas de SQL Server en el proyecto.

## Modulos disponibles

- Inventario y entradas de inventario.
- Ventas: cada registro descuenta existencias y al editar o eliminar las repone.
- Variantes de producto con SKU unico, precios y stock minimo.
- Inicio de sesion con perfiles Administrador y Operador.
- Asistente de inventario de solo lectura, con respuesta local verificable y conexion opcional a OpenAI.

Para mantener el proyecto sencillo, cada venta registra un producto por formulario. El Administrador puede mantener catalogos e inventario; el Operador puede consultar inventario y registrar entradas o ventas.

## Usuarios de demostracion

| Perfil | Usuario | Contrasena |
| --- | --- | --- |
| Administrador | `admin` | `Admin123*` |
| Operador | `operador` | `Operador123*` |

Estas cuentas son solo para el proyecto academico. Cambia sus valores en `appsettings.json` o mediante variables de entorno antes de publicar el sistema.

## Inicio rapido

1. Verifica que esten instalados **SQL Server Express** (instancia `SQLEXPRESS`) y **sqlcmd**. Si falta el SDK de .NET 10, `INICIAR.cmd` lo instalara automaticamente mediante `winget` y Windows puede solicitar permiso de administrador.
2. Haz doble clic en `INICIAR.cmd`.
3. El sistema comprobara SQL Server, creara `InventarioFerreteriaDB` desde `..\BaseDatos.txt` cuando sea necesario, aplicara una sola vez `..\DatosDemostracion.sql`, restaurara las dependencias y abrira `http://localhost:5118`.
4. Para detener la aplicacion, presiona `Ctrl+C` en la ventana que queda abierta.

El proceso es seguro para ejecuciones posteriores: no vuelve a crear la estructura y cada version de los datos demostrativos se aplica una sola vez, sin duplicar ventas ni entradas.

La aplicacion se compila sin AppHost y se ejecuta como DLL mediante el `dotnet.exe` oficial. Esto evita el error `An Application Control policy has blocked this file` que algunas politicas de Windows producen al intentar abrir un ejecutable local sin firmar.

## Otra instancia de SQL Server

Si la instancia no se llama `SQLEXPRESS`, abre PowerShell en esta carpeta y ejecuta:

```powershell
.\INICIAR.cmd ".\NOMBRE_INSTANCIA"
```

Tambien puedes reemplazar la cadena `ConexionSQL` en `appsettings.json` o definir la variable de entorno `ConnectionStrings__ConexionSQL`.

Se recomienda usar la variable de entorno para no guardar credenciales ni datos privados en el repositorio:

```powershell
$env:ConnectionStrings__ConexionSQL = "Server=.\NOMBRE_INSTANCIA;Database=InventarioFerreteriaDB;Integrated Security=True;Encrypt=False;MultipleActiveResultSets=True;"
.\INICIAR.cmd ".\NOMBRE_INSTANCIA"
```

## Asistente IA

Sin configuracion externa, el asistente ya puede consultar disponibilidad, explicar reposiciones y resumir alertas mediante calculos locales. Para agregar una explicacion generativa con OpenAI, define tu API key antes de iniciar:

```powershell
$env:OpenAI__ApiKey = "TU-CLAVE"
$env:OpenAI__Modelo = "gpt-5-nano"
.\INICIAR.cmd
```

La clave no debe guardarse en el repositorio. OpenAI solo redacta la explicacion; las cantidades y calculos siempre salen de SQL Server. `gpt-5-nano` es el modelo predeterminado para mantener bajo el costo.

## Ejecucion desde Visual Studio

Ejecuta `INICIAR.cmd` al menos una vez para preparar la base y las dependencias. Luego abre `SistemaInventarioFerreteria.slnx` y usa el perfil `http`.

## Ejecucion manual compatible con Application Control

```powershell
dotnet restore --configfile .\NuGet.Config
dotnet build --no-restore
$env:ASPNETCORE_ENVIRONMENT = "Development"
$env:ASPNETCORE_URLS = "http://localhost:5118"
dotnet exec .\bin\Debug\net10.0\SistemaInventarioFerreteria.dll
```

No desactives Smart App Control, AppLocker, WDAC ni el antivirus. Si Windows tambien bloquea el `dotnet.exe` oficial, solicita al administrador que autorice el SDK de .NET.

## Seguridad

- La conexion a SQL Server usa autenticacion integrada de Windows y no contiene contrasenas de base de datos.
- Las contrasenas incluidas para iniciar sesion son unicamente cuentas de demostracion.
- Usa variables de entorno o Secret Manager de .NET para cualquier credencial privada.
- No agregues a Git archivos `.env`, certificados, claves, configuraciones locales ni carpetas generadas.
- La aplicacion local solo acepta `localhost` y `127.0.0.1`; configura hosts autorizados y HTTPS antes de desplegarla.
- Haz una copia de seguridad antes de realizar cambios manuales en la base de datos.

## Solucion de problemas

- **SQL Server esta detenido:** ejecuta `INICIAR.cmd` como administrador una vez.
- **No se encontro sqlcmd:** agrega las herramientas de linea de comandos al instalar SQL Server Express.
- **No se pudo instalar el SDK:** comprueba la conexion a Internet, que `winget` este disponible y acepta la solicitud de administrador de Windows.
- **La estructura esta incompleta:** respalda o renombra la base existente antes de volver a ejecutar el inicio. El script nunca la elimina automaticamente.
