USE InventarioFerreteriaDB;
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

IF OBJECT_ID(N'dbo.CargasDatosDemostracion', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.CargasDatosDemostracion
    (
        VersionCarga INT NOT NULL PRIMARY KEY,
        FechaCarga DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
        Descripcion NVARCHAR(250) NOT NULL
    );
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.CargasDatosDemostracion
    WHERE VersionCarga = 1
)
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        /* Catalogos */
        INSERT INTO Categorias (Nombre, Descripcion)
        SELECT datos.Nombre, datos.Descripcion
        FROM (VALUES
            (N'Seguridad industrial', N'Equipo de proteccion personal para obra y taller'),
            (N'Tornilleria y fijaciones', N'Tornillos, clavos, anclajes y elementos de fijacion'),
            (N'Jardineria', N'Herramientas y accesorios para jardin y exteriores'),
            (N'Adhesivos y selladores', N'Pegamentos, siliconas y selladores para construccion'),
            (N'Cerrajeria', N'Candados, cerraduras y accesorios de seguridad')
        ) AS datos(Nombre, Descripcion)
        WHERE NOT EXISTS
        (
            SELECT 1 FROM Categorias c WHERE c.Nombre = datos.Nombre
        );

        INSERT INTO Marcas (Nombre)
        SELECT datos.Nombre
        FROM (VALUES
            (N'Pretul'),
            (N'Makita'),
            (N'Milwaukee'),
            (N'Black+Decker'),
            (N'Corona'),
            (N'Sika'),
            (N'CEMEX'),
            (N'Yale'),
            (N'3M'),
            (N'Schneider Electric'),
            (N'Philips'),
            (N'Surtek')
        ) AS datos(Nombre)
        WHERE NOT EXISTS
        (
            SELECT 1 FROM Marcas m WHERE m.Nombre = datos.Nombre
        );

        DECLARE @Productos TABLE
        (
            Nombre NVARCHAR(150) NOT NULL,
            Descripcion NVARCHAR(300) NULL,
            Categoria NVARCHAR(100) NOT NULL
        );

        INSERT INTO @Productos (Nombre, Descripcion, Categoria)
        VALUES
            (N'Cemento gris', N'Cemento de uso general para concreto y mortero', N'Construccion'),
            (N'Varilla corrugada', N'Acero de refuerzo para estructuras de concreto', N'Construccion'),
            (N'Bloque de concreto', N'Bloque para paredes y divisiones', N'Construccion'),
            (N'Tornillo para lamina', N'Tornillo galvanizado con punta autoperforante', N'Tornilleria y fijaciones'),
            (N'Clavo corriente', N'Clavo de acero para trabajos de carpinteria y construccion', N'Tornilleria y fijaciones'),
            (N'Destornillador plano', N'Destornillador manual con mango antideslizante', N'Herramientas'),
            (N'Alicate universal', N'Alicate para sujetar, doblar y cortar alambre', N'Herramientas'),
            (N'Sierra circular', N'Sierra electrica para cortes en madera', N'Herramientas'),
            (N'Disco de corte', N'Disco abrasivo para corte de metal', N'Herramientas'),
            (N'Interruptor sencillo', N'Interruptor residencial de una via', N'Electricidad'),
            (N'Tomacorriente doble', N'Tomacorriente polarizado para instalacion residencial', N'Electricidad'),
            (N'Bombillo LED', N'Bombillo LED de luz blanca y bajo consumo', N'Electricidad'),
            (N'Codo PVC', N'Accesorio de 90 grados para tuberia de agua potable', N'Plomeria'),
            (N'Grifo para lavamanos', N'Grifo cromado para lavamanos', N'Plomeria'),
            (N'Pegamento para PVC', N'Adhesivo de secado rapido para tuberia PVC', N'Adhesivos y selladores'),
            (N'Guantes de trabajo', N'Guantes reutilizables para manejo de materiales', N'Seguridad industrial'),
            (N'Casco de seguridad', N'Casco con ajuste para proteccion en obra', N'Seguridad industrial'),
            (N'Lentes de seguridad', N'Lentes transparentes con proteccion lateral', N'Seguridad industrial'),
            (N'Candado laminado', N'Candado de acero con tres llaves', N'Cerrajeria'),
            (N'Cerradura de pomo', N'Cerradura para puerta interior o exterior', N'Cerrajeria'),
            (N'Manguera para jardin', N'Manguera flexible reforzada para riego', N'Jardineria'),
            (N'Pala cuadrada', N'Pala con mango de madera para construccion y jardin', N'Jardineria'),
            (N'Silicon transparente', N'Sellador multiuso resistente a la humedad', N'Adhesivos y selladores'),
            (N'Adhesivo para ceramica', N'Mezcla para instalacion de piso y azulejo', N'Adhesivos y selladores'),
            (N'Brocha', N'Brocha de cerdas sinteticas para pintura', N'Pinturas'),
            (N'Cinta metrica', N'Cinta retractil para medicion en obra y taller', N'Herramientas');

        INSERT INTO Productos (Nombre, Descripcion, IdCategoria, Activo)
        SELECT p.Nombre, p.Descripcion, c.IdCategoria, 1
        FROM @Productos p
        INNER JOIN Categorias c ON c.Nombre = p.Categoria
        WHERE NOT EXISTS
        (
            SELECT 1
            FROM Productos existente
            WHERE existente.Nombre = p.Nombre
              AND existente.IdCategoria = c.IdCategoria
        );

        DECLARE @Variantes TABLE
        (
            Producto NVARCHAR(150) NOT NULL,
            Marca NVARCHAR(100) NULL,
            SKU NVARCHAR(50) NOT NULL,
            Color NVARCHAR(50) NULL,
            Tamano NVARCHAR(50) NULL,
            Material NVARCHAR(80) NULL,
            Medida NVARCHAR(80) NULL,
            Presentacion NVARCHAR(100) NULL,
            PrecioCompra DECIMAL(10,2) NOT NULL,
            PrecioVenta DECIMAL(10,2) NOT NULL,
            StockMinimo INT NOT NULL,
            StockBase INT NOT NULL
        );

        INSERT INTO @Variantes
        (Producto, Marca, SKU, Color, Tamano, Material, Medida, Presentacion,
         PrecioCompra, PrecioVenta, StockMinimo, StockBase)
        VALUES
            (N'Pintura Latex', N'Protecto', N'PIN-PRO-GRI-1G-002', N'Gris', N'1 galon', NULL, NULL, N'Galon', 18.50, 26.50, 5, 24),
            (N'Pintura Latex', N'Protecto', N'PIN-PRO-BLA-5G-003', N'Blanco', N'5 galones', NULL, NULL, N'Cubeta', 78.00, 105.00, 3, 10),
            (N'Taladro Electrico', N'DeWalt', N'TAL-DEW-20V-002', NULL, N'20 V', NULL, N'1/2 pulgada', N'Unidad con bateria', 112.00, 149.95, 2, 8),
            (N'Martillo', N'Stanley', N'MAR-STA-20OZ-002', N'Negro/amarillo', N'20 oz', N'Acero', NULL, N'Unidad', 13.25, 19.50, 5, 22),
            (N'Cable Electrico', N'Stanley', N'CAB-STA-12AWG-R-002', N'Rojo', NULL, N'Cobre', N'12 AWG', N'Rollo de 100 metros', 62.00, 84.00, 3, 12),
            (N'Tubo PVC', N'Corona', N'PVC-COR-050-002', N'Blanco', NULL, N'PVC', N'1/2 pulgada x 6 metros', N'Unidad', 2.10, 3.50, 15, 60),
            (N'Tubo PVC', N'Corona', N'PVC-COR-200-003', N'Blanco', NULL, N'PVC', N'2 pulgadas x 6 metros', N'Unidad', 8.75, 12.50, 8, 30),
            (N'Cemento gris', N'CEMEX', N'CEM-CEM-42K-001', N'Gris', N'42.5 kg', N'Cemento Portland', NULL, N'Saco', 8.25, 10.50, 20, 85),
            (N'Varilla corrugada', NULL, N'VAR-GEN-038-001', NULL, NULL, N'Acero', N'3/8 pulgada x 6 metros', N'Unidad', 3.65, 4.75, 30, 150),
            (N'Bloque de concreto', NULL, N'BLO-GEN-15C-001', N'Gris', NULL, N'Concreto', N'15 x 20 x 40 cm', N'Unidad', 0.58, 0.78, 100, 500),
            (N'Tornillo para lamina', N'Surtek', N'TOR-SUR-1IN-001', N'Galvanizado', NULL, N'Acero', N'1 pulgada', N'Caja de 100', 3.10, 4.75, 10, 45),
            (N'Clavo corriente', N'Pretul', N'CLA-PRE-250-001', NULL, NULL, N'Acero', N'2 1/2 pulgadas', N'Libra', 0.82, 1.25, 25, 120),
            (N'Destornillador plano', N'Truper', N'DES-TRU-316-001', N'Naranja/negro', NULL, N'Acero cromo vanadio', N'3/16 x 4 pulgadas', N'Unidad', 2.20, 3.75, 6, 30),
            (N'Alicate universal', N'Stanley', N'ALI-STA-8IN-001', N'Amarillo/negro', N'8 pulgadas', N'Acero', NULL, N'Unidad', 7.80, 11.95, 5, 22),
            (N'Sierra circular', N'Makita', N'SIE-MAK-725-001', N'Verde/negro', N'1,800 W', NULL, N'Disco de 7 1/4 pulgadas', N'Unidad', 118.00, 154.95, 2, 7),
            (N'Disco de corte', N'Milwaukee', N'DIS-MIL-450-001', N'Negro', NULL, N'Abrasivo', N'4 1/2 pulgadas', N'Unidad', 1.15, 1.85, 20, 90),
            (N'Interruptor sencillo', N'Schneider Electric', N'INT-SCH-SEN-001', N'Blanco', NULL, N'Policarbonato', N'15 A / 120 V', N'Unidad', 1.45, 2.35, 15, 70),
            (N'Tomacorriente doble', N'Schneider Electric', N'TOM-SCH-DOB-001', N'Blanco', NULL, N'Policarbonato', N'15 A / 125 V', N'Unidad', 1.85, 2.95, 15, 65),
            (N'Bombillo LED', N'Philips', N'BOM-PHI-9W-001', N'Luz blanca', N'9 W', NULL, N'Base E27', N'Caja individual', 1.60, 2.75, 20, 110),
            (N'Codo PVC', N'Corona', N'COD-COR-050-001', N'Blanco', NULL, N'PVC', N'1/2 pulgada, 90 grados', N'Unidad', 0.18, 0.35, 30, 180),
            (N'Grifo para lavamanos', N'Corona', N'GRI-COR-CRO-001', N'Cromado', NULL, N'Zamak', N'1/2 pulgada', N'Unidad', 12.50, 18.95, 4, 18),
            (N'Pegamento para PVC', N'Sika', N'PEG-SIK-PVC-001', N'Azul', N'1/4 galon', NULL, NULL, N'Lata', 7.25, 10.95, 6, 28),
            (N'Guantes de trabajo', N'3M', N'GUA-3M-MED-001', N'Gris/negro', N'Mediano', N'Nylon y nitrilo', NULL, N'Par', 3.40, 5.50, 12, 55),
            (N'Guantes de trabajo', N'3M', N'GUA-3M-GRA-002', N'Gris/negro', N'Grande', N'Nylon y nitrilo', NULL, N'Par', 3.40, 5.50, 12, 60),
            (N'Casco de seguridad', N'3M', N'CAS-3M-AM-001', N'Amarillo', N'Ajustable', N'Polietileno', NULL, N'Unidad', 8.75, 13.95, 5, 20),
            (N'Lentes de seguridad', N'3M', N'LEN-3M-TRA-001', N'Transparente', N'Universal', N'Policarbonato', NULL, N'Unidad', 2.85, 4.75, 10, 45),
            (N'Candado laminado', N'Yale', N'CAN-YAL-50M-001', N'Plateado', N'50 mm', N'Acero laminado', NULL, N'Unidad', 8.95, 13.50, 5, 20),
            (N'Cerradura de pomo', N'Yale', N'CER-YAL-POM-001', N'Acero satinado', NULL, N'Acero', N'Backset ajustable', N'Juego', 16.25, 24.95, 3, 14),
            (N'Manguera para jardin', N'Truper', N'MAN-TRU-15M-001', N'Verde', NULL, N'PVC reforzado', N'1/2 pulgada x 15 metros', N'Rollo', 11.50, 17.95, 5, 24),
            (N'Pala cuadrada', N'Truper', N'PAL-TRU-CUA-001', N'Negro', NULL, N'Acero y madera', N'Mango de 48 pulgadas', N'Unidad', 10.25, 15.95, 5, 22),
            (N'Silicon transparente', N'Sika', N'SIL-SIK-300-001', N'Transparente', N'300 ml', N'Silicona', NULL, N'Cartucho', 3.15, 5.25, 10, 48),
            (N'Adhesivo para ceramica', N'Sika', N'ADH-SIK-20K-001', N'Gris', N'20 kg', NULL, NULL, N'Saco', 5.90, 8.25, 10, 44),
            (N'Brocha', N'Truper', N'BRO-TRU-3IN-001', N'Negro/naranja', N'3 pulgadas', N'Cerdas sinteticas', NULL, N'Unidad', 1.75, 2.95, 10, 50),
            (N'Cinta metrica', N'Stanley', N'CIN-STA-5M-001', N'Amarillo/negro', N'5 metros', N'Acero', NULL, N'Unidad', 5.25, 8.50, 6, 30);

        INSERT INTO VariantesProducto
        (IdProducto, IdMarca, SKU, Color, Tamano, Material, Medida,
         Presentacion, PrecioCompra, PrecioVenta, StockMinimo, Activo)
        SELECT p.IdProducto, m.IdMarca, v.SKU, v.Color, v.Tamano, v.Material,
               v.Medida, v.Presentacion, v.PrecioCompra, v.PrecioVenta,
               v.StockMinimo, 1
        FROM @Variantes v
        INNER JOIN Productos p ON p.Nombre = v.Producto
        LEFT JOIN Marcas m ON m.Nombre = v.Marca
        WHERE NOT EXISTS
        (
            SELECT 1 FROM VariantesProducto existente WHERE existente.SKU = v.SKU
        );

        /* Puntos de venta y proveedores. Todos los contactos son ficticios. */
        INSERT INTO Sucursales (Nombre, Direccion, Telefono, Activo)
        SELECT datos.Nombre, datos.Direccion, datos.Telefono, 1
        FROM (VALUES
            (N'Sucursal Soyapango', N'Boulevard del Ejercito, Soyapango, San Salvador', N'2500-1103'),
            (N'Sucursal Santa Ana', N'Avenida Independencia Sur, Santa Ana', N'2500-1104'),
            (N'Sucursal San Miguel', N'Avenida Roosevelt Sur, San Miguel', N'2500-1105')
        ) AS datos(Nombre, Direccion, Telefono)
        WHERE NOT EXISTS
        (
            SELECT 1 FROM Sucursales s WHERE s.Nombre = datos.Nombre
        );

        UPDATE Sucursales
        SET Direccion = N'25 Avenida Norte, San Salvador', Telefono = N'2500-1101'
        WHERE Nombre = N'Sucursal Central' AND Direccion = N'San Salvador';

        UPDATE Sucursales
        SET Direccion = N'Carretera Panamericana, Santa Tecla, La Libertad', Telefono = N'2500-1102'
        WHERE Nombre = N'Sucursal Santa Tecla' AND Direccion = N'Santa Tecla';

        INSERT INTO Proveedores
        (Nombre, Telefono, Correo, Direccion, TiempoEntregaDias, Activo)
        SELECT datos.Nombre, datos.Telefono, datos.Correo, datos.Direccion,
               datos.TiempoEntregaDias, 1
        FROM (VALUES
            (N'Distribuidora Cuscatlan', N'2500-2101', N'ventas@cuscatlan.example', N'Colonia Escalon, San Salvador', 2),
            (N'Suministros La Ceiba', N'2500-2102', N'pedidos@laceiba.example', N'Antiguo Cuscatlan, La Libertad', 3),
            (N'Materiales de Occidente', N'2500-2103', N'ventas@occidente.example', N'Zona industrial, Santa Ana', 4),
            (N'Importadora El Torogoz', N'2500-2104', N'compras@eltorogoz.example', N'Soyapango, San Salvador', 5),
            (N'Acabados Lempa', N'2500-2105', N'pedidos@acabadoslempa.example', N'San Marcos, San Salvador', 3),
            (N'Ferresuministros de Oriente', N'2500-2106', N'ventas@ferreoriente.example', N'San Miguel, San Miguel', 4)
        ) AS datos(Nombre, Telefono, Correo, Direccion, TiempoEntregaDias)
        WHERE NOT EXISTS
        (
            SELECT 1 FROM Proveedores p WHERE p.Nombre = datos.Nombre
        );

        /* Existencias actuales para cada variante y sucursal. */
        DECLARE @Stock TABLE (SKU NVARCHAR(50) PRIMARY KEY, StockBase INT NOT NULL);

        INSERT INTO @Stock (SKU, StockBase)
        SELECT SKU, StockBase FROM @Variantes;

        INSERT INTO @Stock (SKU, StockBase)
        SELECT datos.SKU, datos.StockBase
        FROM (VALUES
            (N'PIN-PRO-BLA-1G-001', 26),
            (N'TAL-BOS-500W-001', 10),
            (N'MAR-TRU-16OZ-001', 24),
            (N'CAB-STA-12AWG-001', 120),
            (N'PVC-TRU-1IN-001', 45)
        ) AS datos(SKU, StockBase)
        WHERE NOT EXISTS (SELECT 1 FROM @Stock s WHERE s.SKU = datos.SKU);

        INSERT INTO Inventarios (IdVariante, IdSucursal, Cantidad)
        SELECT variante.IdVariante,
               sucursal.IdSucursal,
               CASE
                   WHEN stock.SKU = N'SIE-MAK-725-001' AND sucursal.Nombre = N'Sucursal San Miguel' THEN 1
                   WHEN stock.SKU = N'CAS-3M-AM-001' AND sucursal.Nombre = N'Sucursal Soyapango' THEN 2
                   WHEN stock.SKU = N'CER-YAL-POM-001' AND sucursal.Nombre = N'Sucursal Santa Ana' THEN 1
                   WHEN stock.SKU = N'INT-SCH-SEN-001' AND sucursal.Nombre = N'Sucursal Central' THEN 5
                   WHEN stock.SKU = N'CEM-CEM-42K-001' AND sucursal.Nombre = N'Sucursal Santa Tecla' THEN 8
                   WHEN stock.SKU = N'ADH-SIK-20K-001' AND sucursal.Nombre = N'Sucursal San Miguel' THEN 4
                   WHEN sucursal.Nombre = N'Sucursal Central' THEN stock.StockBase
                   WHEN sucursal.Nombre = N'Sucursal Santa Tecla' THEN CEILING(stock.StockBase * 0.75)
                   WHEN sucursal.Nombre = N'Sucursal Soyapango' THEN CEILING(stock.StockBase * 0.85)
                   WHEN sucursal.Nombre = N'Sucursal Santa Ana' THEN CEILING(stock.StockBase * 0.65)
                   ELSE CEILING(stock.StockBase * 0.60)
               END
        FROM @Stock stock
        INNER JOIN VariantesProducto variante ON variante.SKU = stock.SKU
        CROSS JOIN Sucursales sucursal
        WHERE sucursal.Nombre IN
        (
            N'Sucursal Central', N'Sucursal Santa Tecla', N'Sucursal Soyapango',
            N'Sucursal Santa Ana', N'Sucursal San Miguel'
        )
        AND NOT EXISTS
        (
            SELECT 1
            FROM Inventarios inventario
            WHERE inventario.IdVariante = variante.IdVariante
              AND inventario.IdSucursal = sucursal.IdSucursal
        );

        /* Entradas de mercaderia de los ultimos 45 dias. */
        DECLARE @Entradas TABLE
        (
            SKU NVARCHAR(50),
            Sucursal NVARCHAR(120),
            Proveedor NVARCHAR(150),
            Cantidad INT,
            Costo DECIMAL(10,2),
            DiasAtras INT
        );

        INSERT INTO @Entradas VALUES
            (N'CEM-CEM-42K-001', N'Sucursal Central', N'Distribuidora Cuscatlan', 120, 8.25, 42),
            (N'VAR-GEN-038-001', N'Sucursal Central', N'Distribuidora Cuscatlan', 250, 3.65, 40),
            (N'BLO-GEN-15C-001', N'Sucursal Soyapango', N'Suministros La Ceiba', 800, 0.58, 38),
            (N'PIN-PRO-GRI-1G-002', N'Sucursal Santa Tecla', N'Acabados Lempa', 36, 18.50, 35),
            (N'TAL-DEW-20V-002', N'Sucursal Central', N'Importadora El Torogoz', 12, 112.00, 33),
            (N'CAB-STA-12AWG-R-002', N'Sucursal Santa Ana', N'Materiales de Occidente', 20, 62.00, 30),
            (N'PVC-COR-050-002', N'Sucursal San Miguel', N'Ferresuministros de Oriente', 90, 2.10, 28),
            (N'TOR-SUR-1IN-001', N'Sucursal Soyapango', N'Importadora El Torogoz', 60, 3.10, 25),
            (N'BOM-PHI-9W-001', N'Sucursal Central', N'Importadora El Torogoz', 150, 1.60, 23),
            (N'COD-COR-050-001', N'Sucursal Santa Tecla', N'Suministros La Ceiba', 220, 0.18, 21),
            (N'GUA-3M-GRA-002', N'Sucursal Soyapango', N'Importadora El Torogoz', 72, 3.40, 19),
            (N'CAS-3M-AM-001', N'Sucursal Santa Ana', N'Materiales de Occidente', 24, 8.75, 17),
            (N'CAN-YAL-50M-001', N'Sucursal San Miguel', N'Ferresuministros de Oriente', 30, 8.95, 15),
            (N'MAN-TRU-15M-001', N'Sucursal Central', N'Distribuidora Cuscatlan', 36, 11.50, 13),
            (N'SIL-SIK-300-001', N'Sucursal Santa Tecla', N'Acabados Lempa', 60, 3.15, 11),
            (N'ADH-SIK-20K-001', N'Sucursal San Miguel', N'Ferresuministros de Oriente', 55, 5.90, 9),
            (N'BRO-TRU-3IN-001', N'Sucursal Soyapango', N'Distribuidora Cuscatlan', 70, 1.75, 7),
            (N'CIN-STA-5M-001', N'Sucursal Santa Ana', N'Materiales de Occidente', 40, 5.25, 5),
            (N'DIS-MIL-450-001', N'Sucursal Central', N'Importadora El Torogoz', 120, 1.15, 3),
            (N'TOM-SCH-DOB-001', N'Sucursal San Miguel', N'Ferresuministros de Oriente', 80, 1.85, 2);

        INSERT INTO EntradasInventario
        (IdVariante, IdSucursal, IdProveedor, Cantidad, CostoUnitario, Fecha)
        SELECT variante.IdVariante, sucursal.IdSucursal, proveedor.IdProveedor,
               entrada.Cantidad, entrada.Costo,
               DATEADD(HOUR, 9, DATEADD(DAY, -entrada.DiasAtras,
                   CAST(CAST(GETDATE() AS DATE) AS DATETIME)))
        FROM @Entradas entrada
        INNER JOIN VariantesProducto variante ON variante.SKU = entrada.SKU
        INNER JOIN Sucursales sucursal ON sucursal.Nombre = entrada.Sucursal
        INNER JOIN Proveedores proveedor ON proveedor.Nombre = entrada.Proveedor;

        /* Ventas recientes de una sola linea, compatibles con el formulario sencillo. */
        DECLARE @VentasSemilla TABLE
        (
            SKU NVARCHAR(50),
            Sucursal NVARCHAR(120),
            Cantidad INT,
            DiasAtras INT,
            Hora INT
        );

        INSERT INTO @VentasSemilla VALUES
            (N'CEM-CEM-42K-001', N'Sucursal Central', 8, 29, 10),
            (N'BLO-GEN-15C-001', N'Sucursal Soyapango', 80, 28, 14),
            (N'MAR-TRU-16OZ-001', N'Sucursal Santa Tecla', 2, 27, 11),
            (N'BOM-PHI-9W-001', N'Sucursal Central', 12, 26, 16),
            (N'PVC-COR-050-002', N'Sucursal San Miguel', 15, 25, 9),
            (N'CLA-PRE-250-001', N'Sucursal Santa Ana', 10, 24, 15),
            (N'PIN-PRO-BLA-1G-001', N'Sucursal Central', 3, 23, 13),
            (N'TOR-SUR-1IN-001', N'Sucursal Soyapango', 6, 22, 10),
            (N'COD-COR-050-001', N'Sucursal Santa Tecla', 25, 21, 12),
            (N'DIS-MIL-450-001', N'Sucursal Central', 15, 20, 17),
            (N'GUA-3M-GRA-002', N'Sucursal San Miguel', 5, 19, 11),
            (N'ADH-SIK-20K-001', N'Sucursal Santa Ana', 7, 18, 14),
            (N'INT-SCH-SEN-001', N'Sucursal Central', 10, 17, 10),
            (N'TOM-SCH-DOB-001', N'Sucursal Soyapango', 8, 16, 15),
            (N'VAR-GEN-038-001', N'Sucursal Santa Tecla', 35, 15, 9),
            (N'SIL-SIK-300-001', N'Sucursal San Miguel', 9, 14, 16),
            (N'BRO-TRU-3IN-001', N'Sucursal Central', 7, 13, 12),
            (N'CIN-STA-5M-001', N'Sucursal Santa Ana', 4, 12, 14),
            (N'CAS-3M-AM-001', N'Sucursal Soyapango', 6, 11, 10),
            (N'CAN-YAL-50M-001', N'Sucursal Santa Tecla', 3, 10, 15),
            (N'MAN-TRU-15M-001', N'Sucursal Central', 4, 9, 11),
            (N'PEG-SIK-PVC-001', N'Sucursal San Miguel', 6, 8, 13),
            (N'CEM-CEM-42K-001', N'Sucursal Santa Tecla', 15, 7, 9),
            (N'LEN-3M-TRA-001', N'Sucursal Soyapango', 8, 6, 16),
            (N'PIN-PRO-GRI-1G-002', N'Sucursal Central', 2, 5, 12),
            (N'PAL-TRU-CUA-001', N'Sucursal Santa Ana', 3, 4, 14),
            (N'BOM-PHI-9W-001', N'Sucursal San Miguel', 18, 3, 10),
            (N'CER-YAL-POM-001', N'Sucursal Santa Ana', 3, 2, 15),
            (N'DES-TRU-316-001', N'Sucursal Central', 5, 1, 11),
            (N'DIS-MIL-450-001', N'Sucursal Soyapango', 20, 0, 14);

        DECLARE @VentasPreparadas TABLE
        (
            IdSucursal INT,
            IdVariante INT,
            Cantidad INT,
            PrecioUnitario DECIMAL(10,2),
            Fecha DATETIME,
            Total DECIMAL(10,2)
        );

        INSERT INTO @VentasPreparadas
        SELECT sucursal.IdSucursal, variante.IdVariante, semilla.Cantidad,
               variante.PrecioVenta,
               DATEADD(HOUR, semilla.Hora, DATEADD(DAY, -semilla.DiasAtras,
                   CAST(CAST(GETDATE() AS DATE) AS DATETIME))),
               semilla.Cantidad * variante.PrecioVenta
        FROM @VentasSemilla semilla
        INNER JOIN VariantesProducto variante ON variante.SKU = semilla.SKU
        INNER JOIN Sucursales sucursal ON sucursal.Nombre = semilla.Sucursal;

        INSERT INTO Ventas (IdSucursal, Fecha, Total)
        SELECT IdSucursal, Fecha, Total FROM @VentasPreparadas;

        INSERT INTO DetalleVentas
        (IdVenta, IdVariante, Cantidad, PrecioUnitario, Subtotal)
        SELECT venta.IdVenta, preparada.IdVariante, preparada.Cantidad,
               preparada.PrecioUnitario, preparada.Total
        FROM @VentasPreparadas preparada
        INNER JOIN Ventas venta
            ON venta.IdSucursal = preparada.IdSucursal
           AND venta.Fecha = preparada.Fecha
           AND venta.Total = preparada.Total
        WHERE NOT EXISTS
        (
            SELECT 1
            FROM DetalleVentas detalle
            WHERE detalle.IdVenta = venta.IdVenta
        );

        INSERT INTO MovimientosInventario
        (IdVariante, IdSucursal, TipoMovimiento, Cantidad, Fecha, Descripcion)
        SELECT variante.IdVariante, sucursal.IdSucursal, N'Entrada', entrada.Cantidad,
               DATEADD(HOUR, 9, DATEADD(DAY, -entrada.DiasAtras,
                   CAST(CAST(GETDATE() AS DATE) AS DATETIME))),
               N'Compra a proveedor - carga demostrativa v1'
        FROM @Entradas entrada
        INNER JOIN VariantesProducto variante ON variante.SKU = entrada.SKU
        INNER JOIN Sucursales sucursal ON sucursal.Nombre = entrada.Sucursal;

        INSERT INTO MovimientosInventario
        (IdVariante, IdSucursal, TipoMovimiento, Cantidad, Fecha, Descripcion)
        SELECT IdVariante, IdSucursal, N'Salida', Cantidad, Fecha,
               N'Venta de mostrador - carga demostrativa v1'
        FROM @VentasPreparadas;

        /* Alertas y recomendaciones calculadas a partir de existencias bajas. */
        DECLARE @BajoStock TABLE (SKU NVARCHAR(50), Sucursal NVARCHAR(120));
        INSERT INTO @BajoStock VALUES
            (N'SIE-MAK-725-001', N'Sucursal San Miguel'),
            (N'CAS-3M-AM-001', N'Sucursal Soyapango'),
            (N'CER-YAL-POM-001', N'Sucursal Santa Ana'),
            (N'INT-SCH-SEN-001', N'Sucursal Central'),
            (N'CEM-CEM-42K-001', N'Sucursal Santa Tecla'),
            (N'ADH-SIK-20K-001', N'Sucursal San Miguel');

        INSERT INTO Alertas
        (IdVariante, IdSucursal, TipoAlerta, Mensaje, Fecha, Estado)
        SELECT variante.IdVariante, sucursal.IdSucursal, N'Stock bajo',
               N'Existencia actual de ' + CAST(inventario.Cantidad AS NVARCHAR(12)) +
               N' unidades; minimo configurado: ' +
               CAST(variante.StockMinimo AS NVARCHAR(12)) + N'.',
               SYSDATETIME(), N'Pendiente'
        FROM @BajoStock bajo
        INNER JOIN VariantesProducto variante ON variante.SKU = bajo.SKU
        INNER JOIN Sucursales sucursal ON sucursal.Nombre = bajo.Sucursal
        INNER JOIN Inventarios inventario
            ON inventario.IdVariante = variante.IdVariante
           AND inventario.IdSucursal = sucursal.IdSucursal;

        INSERT INTO Recomendaciones
        (IdVariante, IdSucursal, StockActual, PromedioVentaDiaria,
         DiasRestantes, CantidadRecomendada, Fecha)
        SELECT variante.IdVariante, sucursal.IdSucursal, inventario.Cantidad,
               CAST(ventas.Unidades / 30.0 AS DECIMAL(10,2)),
               CAST(CASE WHEN ventas.Unidades = 0 THEN 999
                         ELSE inventario.Cantidad / (ventas.Unidades / 30.0) END
                    AS DECIMAL(10,2)),
               CASE
                   WHEN CEILING((ventas.Unidades / 30.0) * 14) + variante.StockMinimo - inventario.Cantidad > 0
                   THEN CAST(CEILING((ventas.Unidades / 30.0) * 14) + variante.StockMinimo - inventario.Cantidad AS INT)
                   ELSE variante.StockMinimo * 2
               END,
               SYSDATETIME()
        FROM @BajoStock bajo
        INNER JOIN VariantesProducto variante ON variante.SKU = bajo.SKU
        INNER JOIN Sucursales sucursal ON sucursal.Nombre = bajo.Sucursal
        INNER JOIN Inventarios inventario
            ON inventario.IdVariante = variante.IdVariante
           AND inventario.IdSucursal = sucursal.IdSucursal
        CROSS APPLY
        (
            SELECT COALESCE(SUM(preparada.Cantidad), 0) AS Unidades
            FROM @VentasPreparadas preparada
            WHERE preparada.IdVariante = variante.IdVariante
              AND preparada.IdSucursal = sucursal.IdSucursal
        ) ventas;

        INSERT INTO dbo.CargasDatosDemostracion
        (VersionCarga, Descripcion)
        VALUES
        (1, N'Catalogo e historial simulado de una ferreteria en El Salvador');

        COMMIT TRANSACTION;
        PRINT N'Datos demostrativos version 1 cargados correctamente.';
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END
ELSE
BEGIN
    PRINT N'Los datos demostrativos version 1 ya estaban cargados; no se duplicaron registros.';
END;
GO
