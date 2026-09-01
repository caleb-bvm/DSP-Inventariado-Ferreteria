# Sistema de Inventario de Ferreteria

Aplicacion web ASP.NET Core MVC conectada a **Microsoft SQL Server**. La configuracion local usa autenticacion de Windows, por lo que no guarda usuarios ni contrasenas de SQL Server en el proyecto.

## Inicio rapido

1. Verifica que esten instalados **SQL Server Express** (instancia `SQLEXPRESS`), **sqlcmd** y **.NET 10 SDK**.
2. Haz doble clic en `INICIAR.cmd`.
3. El sistema comprobara SQL Server, creara `InventarioFerreteriaDB` desde `..\BaseDatos.txt` cuando sea necesario, restaurara las dependencias y abrira `http://localhost:5118`.
4. Para detener la aplicacion, presiona `Ctrl+C` en la ventana que queda abierta.

El proceso es seguro para ejecuciones posteriores: si la base ya existe, no vuelve a importar el archivo ni sobrescribe los datos.

## Otra instancia de SQL Server

Si la instancia no se llama `SQLEXPRESS`, abre PowerShell en esta carpeta y ejecuta:

```powershell
.\INICIAR.cmd ".\NOMBRE_INSTANCIA"
```

Tambien puedes reemplazar la cadena `ConexionSQL` en `appsettings.json` o definir la variable de entorno `ConnectionStrings__ConexionSQL`.

Se recomienda usar la variable de entorno para no guardar credenciales ni datos privados en el repositorio:

```powershell
$env:ConnectionStrings__ConexionSQL = "Server=.\NOMBRE_INSTANCIA;Database=InventarioFerreteriaDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;"
.\INICIAR.cmd ".\NOMBRE_INSTANCIA"
```

## Ejecucion desde Visual Studio

Ejecuta `INICIAR.cmd` al menos una vez para preparar la base y las dependencias. Luego abre `SistemaInventarioFerreteria.slnx` y usa el perfil `http`.

## Seguridad

- La configuracion incluida usa autenticacion integrada de Windows y no contiene contrasenas.
- Usa variables de entorno o Secret Manager de .NET para cualquier credencial privada.
- No agregues a Git archivos `.env`, certificados, claves, configuraciones locales ni carpetas generadas.
- La aplicacion local solo acepta `localhost` y `127.0.0.1`; configura hosts autorizados y HTTPS antes de desplegarla.
- Haz una copia de seguridad antes de realizar cambios manuales en la base de datos.

## Solucion de problemas

- **SQL Server esta detenido:** ejecuta `INICIAR.cmd` como administrador una vez.
- **No se encontro sqlcmd:** agrega las herramientas de linea de comandos al instalar SQL Server Express.
- **La estructura esta incompleta:** respalda o renombra la base existente antes de volver a ejecutar el inicio. El script nunca la elimina automaticamente.
