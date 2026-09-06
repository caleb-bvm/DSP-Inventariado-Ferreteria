# Documentación de Proyecto de Cátedra

- Document ID: 1JFZqNPp4z2DCGH23P2_rdwhriq9tg7oHRMLRMmlATq4
- Revision ID: AIroW377mFadEWDHVxMvvwizm-yWgmjOORjSr1LnNvUWbVOFc4Ek1YaODWib05TZHLyWxT3JJXzWLiJGp7OrGGSZS1gDvLDNLr_2O_sAtmI
- Selected tab: t.0
- Protected controls: 0
- Opaque controls: 0
- Authoritative dropdowns: 0

Protected-control annotations are preservation instructions. Do not insert their displayed placeholder text to recreate a native control.

## Tab 1 (t.0)

[P00001 | 1:3 | NORMAL_TEXT]
[INLINE_OBJECT kix.f9jk8pn2ncwu]

[P00002 | 3:26 | NORMAL_TEXT]
 Universidad Don Bosco

[P00003 | 26:57 | NORMAL_TEXT]
“Proyecto de Cátedra - Fase 1”

[P00004 | 57:68 | NORMAL_TEXT]
Asignatura

[P00005 | 68:121 | NORMAL_TEXT]
	Desarrollo De Aplicaciones Con Software Propietario

[P00006 | 121:133 | NORMAL_TEXT]
Integrantes

[P00007 | 133:176 | NORMAL_TEXT | LIST id=kix.ezt3bt6se91k level=0]
Flores Figueroa, Josue Gamaliel			FF233029

[P00008 | 176:218 | NORMAL_TEXT | LIST id=kix.ezt3bt6se91k level=0]
Torres Reyes, Cristian Josué 				TR240516

[P00009 | 218:259 | NORMAL_TEXT | LIST id=kix.ezt3bt6se91k level=0]
Ortiz Melendez, Michael Caleb			OM260275

[P00010 | 259:304 | NORMAL_TEXT | LIST id=kix.ezt3bt6se91k level=0]
Martinez Guerrero, Nathaly Ivania			MG260121

[P00011 | 304:344 | NORMAL_TEXT | LIST id=kix.ezt3bt6se91k level=0]
Peña Saravia, Jimmy Steeven				PS260123

[P00012 | 344:352 | NORMAL_TEXT]
Docente

[P00013 | 352:379 | NORMAL_TEXT]
Ing. Rene Mauricio Tejada 

[P00014 | 379:389 | NORMAL_TEXT]
Actividad

[P00015 | 389:418 | NORMAL_TEXT]
Proyecto de Cátedra - Fase 1

[P00016 | 418:419 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00017 | 419:458 | NORMAL_TEXT]
Fecha de entrega: 24 de Agosto de 2026

[P00018 | 458:494 | HEADING_1]
3. Descripción general del proyecto

[P00019 | 494:603 | NORMAL_TEXT]
Sistema web inteligente para la gestión de renta de vehículos en pequeñas y medianas empresas de El Salvador

[P00020 | 603:1147 | NORMAL_TEXT]
La propuesta consiste en desarrollar una aplicación web que centralice la administración de clientes, vehículos, reservas, contratos de alquiler, devoluciones, mantenimiento y reportes. El sistema estará orientado a pequeñas y medianas agencias salvadoreñas que actualmente pueden depender de hojas de cálculo, agendas, llamadas y mensajería para coordinar sus operaciones. La solución incorporará una función de inteligencia artificial que recomendará vehículos según las necesidades del cliente y únicamente dentro del inventario disponible.

[P00021 | 1147:1168 | HEADING_2]
3.1 Objetivo general

[P00022 | 1168:1639 | NORMAL_TEXT]
Desarrollar un sistema web seguro, modular y escalable para pequeñas y medianas empresas de renta de vehículos en El Salvador, que centralice la información de la flota y los clientes, automatice los procesos de reserva, entrega, devolución y mantenimiento, e incorpore un asistente inteligente para recomendar vehículos de acuerdo con las necesidades del usuario, con el propósito de reducir errores operativos, mejorar la trazabilidad y elevar la calidad del servicio.

[P00023 | 1639:1665 | HEADING_2]
3.2 Objetivos específicos

[P00024 | 1665:1838 | NORMAL_TEXT | LIST id=kix.crdm3ueifw9k level=0]
Centralizar la información de clientes, vehículos, categorías, tarifas, disponibilidad, reservas, alquileres, devoluciones y mantenimientos en una base de datos relacional.

[P00025 | 1838:2006 | NORMAL_TEXT | LIST id=kix.crdm3ueifw9k level=0]
Automatizar la consulta de disponibilidad y las reglas que impiden reservas superpuestas, así como el cálculo básico de tarifas, días de alquiler y cargos adicionales.

[P00026 | 2006:2198 | NORMAL_TEXT | LIST id=kix.crdm3ueifw9k level=0]
Integrar un servicio de inteligencia artificial que recomiende vehículos disponibles según cantidad de pasajeros, equipaje, tipo de viaje, transmisión, presupuesto y preferencias del cliente.

[P00027 | 2198:2365 | NORMAL_TEXT | LIST id=kix.crdm3ueifw9k level=0]
Implementar servicios web y controles de seguridad para autenticar usuarios, autorizar acciones por rol, validar datos y proteger la información personal y operativa.

[P00028 | 2365:2549 | NORMAL_TEXT | LIST id=kix.crdm3ueifw9k level=0]
Contenerizar la aplicación con Docker y proponer su despliegue en Microsoft Azure, manteniendo una arquitectura en capas que facilite las pruebas, el mantenimiento y la escalabilidad.

[P00029 | 2549:2582 | HEADING_1]
4. Gestión integral del proyecto

[P00030 | 2582:2639 | HEADING_2]
4.1 Análisis del problema y planteamiento de la solución

[P00031 | 2639:2648 | HEADING_3]
Contexto

[P00032 | 2648:3206 | NORMAL_TEXT]
Las micro y pequeñas empresas constituyen un componente relevante del tejido productivo salvadoreño. CONAMYPE informó que, durante siete años de gestión, brindó más de 276,000 servicios empresariales y alcanzó cerca de 52,000 registros MYPE, lo que evidencia la amplitud del sector atendido por la institución [\[1\]](https://www.conamype.gob.sv/blog/2026/06/25/conamype-celebra-35-anos-impulsando-el-desarrollo-de-las-mype-salvadorenas-y-recibe-reconocimientos-por-su-trayectoria/). En el ámbito turístico, el directorio oficial de transporte de El Salvador incluye operadores registrados y arrendadoras de vehículos, por lo que la renta de automóviles forma parte de la oferta formal vinculada al turismo y la movilidad [\[2\]](https://www.elsalvador.travel/services/tourist-transportation/es/).

[P00033 | 3206:3571 | NORMAL_TEXT]
La observación inicial del equipo identifica además la presencia de agencias independientes que operan con pocos empleados y flotas reducidas. Esta afirmación se manejará como una hipótesis de trabajo y será validada mediante entrevistas, encuestas y observación durante la recolección de requisitos; no se asumirá como resultado definitivo sin evidencia de campo.

[P00034 | 3571:4017 | NORMAL_TEXT]
La necesidad de digitalización también es consistente con iniciativas nacionales recientes. En 2026, CONAMYPE, MITUR, KOICA y PNUD entregaron herramientas digitales a 200 MYPE del sector turismo para fortalecer sus capacidades tecnológicas, comerciales y de gestión [\[3\]](https://www.conamype.gob.sv/blog/2026/07/07/conamype-koica-y-pnud-fortalecen-la-transformacion-digital-de-200-mype-con-canastas-digitales-mype-360/). Por tanto, una solución de gestión interna para pequeñas agencias se alinea con una necesidad real de transformación digital, siempre que sea sencilla, asequible y adaptable.

[P00035 | 4017:4039 | HEADING_3]
Problema identificado

[P00036 | 4039:4410 | NORMAL_TEXT]
Cuando la disponibilidad de los vehículos, las reservas y los contratos se administran en medios separados, la empresa carece de una única fuente confiable de información. Un cambio anotado en una agenda puede no reflejarse en una hoja de cálculo o en la conversación de otro empleado. Esto crea riesgos operativos que el estudio de campo deberá confirmar y dimensionar.

[P00037 | 4410:4480 | NORMAL_TEXT]
Los principales problemas que se pretende atender son los siguientes:

[P00038 | 4480:4571 | NORMAL_TEXT | LIST id=kix.xc7gjo3n9u8l level=0]
Posibles reservas duplicadas o asignaciones de un mismo vehículo en períodos superpuestos.

[P00039 | 4571:4646 | NORMAL_TEXT | LIST id=kix.xc7gjo3n9u8l level=0]
Demora para conocer qué vehículos están disponibles en un rango de fechas.

[P00040 | 4646:4738 | NORMAL_TEXT | LIST id=kix.xc7gjo3n9u8l level=0]
Historial disperso de clientes, contratos, pagos, inspecciones, daños y cargos adicionales.

[P00041 | 4738:4821 | NORMAL_TEXT | LIST id=kix.xc7gjo3n9u8l level=0]
Falta de alertas sobre devoluciones próximas, retrasos y mantenimiento preventivo.

[P00042 | 4821:4918 | NORMAL_TEXT | LIST id=kix.xc7gjo3n9u8l level=0]
Dificultad para medir utilización de la flota, ingresos por período y vehículos más solicitados.

[P00043 | 4918:5064 | NORMAL_TEXT | LIST id=kix.xc7gjo3n9u8l level=0]
Recomendaciones dependientes exclusivamente de la experiencia del empleado, sin criterios uniformes ni verificación automática de disponibilidad.

[P00044 | 5064:5083 | HEADING_3]
Usuarios afectados

[P00045 | 5083:5180 | NORMAL_TEXT | LIST id=kix.h9osoa25qh5s level=0]
Propietarios o administradores, quienes necesitan indicadores y control general de la operación.

[P00046 | 5180:5282 | NORMAL_TEXT | LIST id=kix.h9osoa25qh5s level=0]
Empleados de atención, responsables de registrar clientes, consultar disponibilidad y crear reservas.

[P00047 | 5282:5376 | NORMAL_TEXT | LIST id=kix.h9osoa25qh5s level=0]
Encargados de flota, quienes registran entregas, devoluciones, inspecciones y mantenimientos.

[P00048 | 5376:5470 | NORMAL_TEXT | LIST id=kix.h9osoa25qh5s level=0]
Clientes, quienes requieren información clara, opciones adecuadas y confirmaciones oportunas.

[P00049 | 5470:5500 | HEADING_3]
Impacto esperado del problema

[P00050 | 5500:5907 | NORMAL_TEXT]
Sin un registro centralizado puede aumentar el tiempo dedicado a buscar información, corregir inconsistencias y coordinar al personal. También se dificulta conocer el estado real de cada vehículo y reconstruir el historial de una operación ante una consulta o reclamo. El impacto exacto se medirá durante la investigación mediante tiempos de proceso, frecuencia de incidencias y percepción de los usuarios.

[P00051 | 5907:5926 | HEADING_3]
Solución propuesta

[P00052 | 5926:6304 | NORMAL_TEXT]
Se propone una aplicación web responsive con autenticación por roles. El sistema mantendrá una agenda central de disponibilidad, bloqueará conflictos de fechas, conservará el historial de cada vehículo y permitirá convertir una reserva en alquiler, registrar la devolución y programar mantenimiento. Los reportes ofrecerán indicadores básicos para apoyar decisiones operativas.

[P00053 | 6304:6704 | NORMAL_TEXT]
La función de IA actuará como asistente de recomendación. Primero, la lógica del sistema filtra los vehículos realmente disponibles y compatibles con restricciones objetivas. Después, el servicio de IA ordenará o explicará las alternativas según las preferencias ingresadas. La recomendación será orientativa, mostrará los criterios utilizados y no confirmará una reserva sin aprobación del usuario.

[P00054 | 6704:6722 | HEADING_3]
Alcance y límites

[P00055 | 6722:7145 | NORMAL_TEXT]
El alcance inicial comprende una agencia con una o más sucursales configurables, pero prioriza el funcionamiento de una operación pequeña. No se incluirán en el primer prototipo una pasarela de pagos, rastreo GPS, integración con aseguradoras o instituciones públicas, aplicación móvil nativa, reconocimiento automático de daños ni fijación dinámica de precios. Estas capacidades podrán evaluarse como extensiones futuras.

[P00056 | 7145:7175 | HEADING_3]
Criterios de éxito propuestos

[P00057 | 7175:7247 | NORMAL_TEXT | LIST id=kix.cu0o2mtw1gjh level=0]
Impedir reservas confirmadas que se superpongan para un mismo vehículo.

[P00058 | 7247:7332 | NORMAL_TEXT | LIST id=kix.cu0o2mtw1gjh level=0]
Mantener trazabilidad desde la reserva hasta la devolución y el cierre del alquiler.

[P00059 | 7332:7420 | NORMAL_TEXT | LIST id=kix.cu0o2mtw1gjh level=0]
Permitir consultar la disponibilidad mediante fechas y filtros desde una sola pantalla.

[P00060 | 7420:7516 | NORMAL_TEXT | LIST id=kix.cu0o2mtw1gjh level=0]
Generar recomendaciones únicamente con vehículos disponibles y explicar por qué son apropiados.

[P00061 | 7516:7605 | NORMAL_TEXT | LIST id=kix.cu0o2mtw1gjh level=0]
Obtener resultados satisfactorios en pruebas de usabilidad con usuarios representativos.

[P00062 | 7605:7788 | NORMAL_TEXT]
Los valores base y las metas cuantitativas definitivas se fijarán después de la recolección de datos; de esta manera se evitará declarar mejoras porcentuales sin una medición previa.

[P00063 | 7788:7815 | HEADING_2]
4.2 Diseño técnico inicial

[P00064 | 7815:7835 | HEADING_3]
Módulos principales

[P00065 | 7835:7928 | NORMAL_TEXT | LIST id=kix.t4q9ctla4m5m level=0]
Identidad y seguridad: inicio de sesión, recuperación de acceso, usuarios, roles y permisos.

[P00066 | 7928:8016 | NORMAL_TEXT | LIST id=kix.t4q9ctla4m5m level=0]
Clientes: datos de contacto, documentos requeridos, historial de reservas y alquileres.

[P00067 | 8016:8104 | NORMAL_TEXT | LIST id=kix.t4q9ctla4m5m level=0]
Flota: vehículos, categorías, características, tarifas, imágenes, kilometraje y estado.

[P00068 | 8104:8203 | NORMAL_TEXT | LIST id=kix.t4q9ctla4m5m level=0]
Reservas: consulta por fechas, validación de disponibilidad, creación, modificación y cancelación.

[P00069 | 8203:8296 | NORMAL_TEXT | LIST id=kix.t4q9ctla4m5m level=0]
Alquileres y devoluciones: contrato, entrega, inspección, combustible, kilometraje y cargos.

[P00070 | 8296:8392 | NORMAL_TEXT | LIST id=kix.t4q9ctla4m5m level=0]
Mantenimiento: servicios preventivos y correctivos, fechas, costos y bloqueo de disponibilidad.

[P00071 | 8392:8489 | NORMAL_TEXT | LIST id=kix.t4q9ctla4m5m level=0]
Reportes: utilización de la flota, ingresos, reservas, devoluciones pendientes y mantenimientos.

[P00072 | 8489:8608 | NORMAL_TEXT | LIST id=kix.t4q9ctla4m5m level=0]
Recomendador inteligente: captura de preferencias, filtrado de candidatos, explicación y registro de la recomendación.

[P00073 | 8608:8623 | HEADING_3]
Flujo de datos

[P00074 | 8623:9106 | NORMAL_TEXT]
El usuario interactúa con la interfaz web. La aplicación valida identidad y permisos, ejecuta las reglas de negocio y consulta los datos mediante Entity Framework Core. Para una recomendación, el sistema obtiene primero las opciones disponibles desde PostgreSQL y envía al servicio de IA solamente las características necesarias del viaje y de los vehículos candidatos. La respuesta se valida, se presenta como sugerencia y puede convertirse en una reserva mediante el flujo normal.

[P00075 | 9106:9108 | NORMAL_TEXT]
[INLINE_OBJECT kix.x701itkm53mn]

[P00076 | 9108:9182 | NORMAL_TEXT]
Figura 1. Diagrama de bloques y flujo principal de la solución propuesta.

[P00077 | 9182:9212 | HEADING_3]
Interacción entre componentes

[P00078 | 9212:9605 | NORMAL_TEXT]
La interfaz no accede directamente a la base de datos. Las solicitudes pasarán por controladores o endpoints de ASP.NET Core, servicios de aplicación y reglas de dominio. La infraestructura implementará persistencia, correo, archivos, monitoreo y consumo del servicio de IA. Esta separación reduce el acoplamiento y permite probar la lógica sin depender permanentemente de servicios externos.

[P00079 | 9605:9633 | HEADING_2]
4.3 Estudio de factibilidad

[P00080 | 9633:9654 | HEADING_3]
Factibilidad técnica

[P00081 | 9654:10100 | NORMAL_TEXT]
El proyecto es técnicamente viable para un equipo de cinco integrantes porque utiliza tecnologías contempladas en la asignatura y con documentación oficial. ASP.NET Core permite crear aplicaciones y servicios web multiplataforma y orientados a la nube [\[5\]](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-10.0). Entity Framework Core proporciona acceso relacional, consultas, seguimiento de cambios y migraciones para diferentes motores, incluido PostgreSQL mediante su proveedor correspondiente [\[6\]](https://learn.microsoft.com/en-us/ef/).

[P00082 | 10100:10569 | NORMAL_TEXT]
Docker permitirá ejecutar la aplicación y sus dependencias de manera consistente entre los equipos de desarrollo [\[7\]](https://docs.docker.com/get-started/introduction/). Para producción o demostración, Azure Container Apps admite despliegue de contenedores y escalado automático; en un perfil de consumo puede escalar a cero cuando no hay actividad [\[8\]](https://learn.microsoft.com/en-us/azure/container-apps/scale-app). La base de datos podrá alojarse en Azure Database for PostgreSQL Flexible Server, un servicio administrado con opciones de respaldo, mantenimiento y escalamiento [\[9\]](https://learn.microsoft.com/en-us/azure/postgresql/flexible-server/service-overview).

[P00083 | 10569:10601 | HEADING_3]
Capacidades técnicas necesarias

[P00084 | 10601:10666 | NORMAL_TEXT | LIST id=kix.b7ewyoxm6aiq level=0]
Programación en C#, ASP.NET Core MVC o Web App y diseño de APIs.

[P00085 | 10666:10729 | NORMAL_TEXT | LIST id=kix.b7ewyoxm6aiq level=0]
Modelado relacional, SQL, Entity Framework Core y migraciones.

[P00086 | 10729:10787 | NORMAL_TEXT | LIST id=kix.b7ewyoxm6aiq level=0]
HTML, CSS, JavaScript, accesibilidad y diseño responsive.

[P00087 | 10787:10849 | NORMAL_TEXT | LIST id=kix.b7ewyoxm6aiq level=0]
Git y GitHub para control de versiones y revisión de cambios.

[P00088 | 10849:10908 | NORMAL_TEXT | LIST id=kix.b7ewyoxm6aiq level=0]
Pruebas unitarias, de integración, seguridad y aceptación.

[P00089 | 10908:10995 | NORMAL_TEXT | LIST id=kix.b7ewyoxm6aiq level=0]
Docker, configuración por ambiente, administración de secretos y fundamentos de Azure.

[P00090 | 10995:11068 | NORMAL_TEXT | LIST id=kix.b7ewyoxm6aiq level=0]
Integración segura con un servicio de IA y evaluación de sus respuestas.

[P00091 | 11068:11098 | HEADING_3]
Riesgos técnicos y mitigación

[P00092 | 11098:11228 | NORMAL_TEXT | LIST id=kix.n613wsvqx8xe level=0]
Curva de aprendizaje en Docker y Azure. Mitigación: crear una prueba de despliegue desde el inicio y documentar el procedimiento.

[P00093 | 11228:11355 | NORMAL_TEXT | LIST id=kix.n613wsvqx8xe level=0]
Conflictos en el modelo de datos. Mitigación: acordar el diagrama entidad-relación y revisar migraciones antes de integrarlas.

[P00094 | 11355:11548 | NORMAL_TEXT | LIST id=kix.n613wsvqx8xe level=0]
Indisponibilidad o costo del servicio de IA. Mitigación: aislarlo mediante una interfaz, limitar solicitudes y ofrecer una recomendación básica basada en reglas cuando el servicio no responda.

[P00095 | 11548:11723 | NORMAL_TEXT | LIST id=kix.n613wsvqx8xe level=0]
Respuestas incorrectas de IA. Mitigación: filtrar candidatos en el servidor, exigir salida estructurada, validar identificadores y no permitir que la IA confirme operaciones.

[P00096 | 11723:11746 | HEADING_3]
Factibilidad económica

[P00097 | 11746:12141 | NORMAL_TEXT]
El desarrollo local puede realizarse con herramientas gratuitas o disponibles para uso académico: .NET, PostgreSQL, Git, GitHub y editores de código. La contenerización evita adquirir servidores durante la construcción. Los estudiantes elegibles pueden solicitar Azure for Students, que actualmente ofrece un crédito de USD 100 para doce meses y no exige tarjeta de crédito al registrarse [\[10\]](https://azure.microsoft.com/en-us/free/students).

[P00098 | 12141:12628 | NORMAL_TEXT]
Para un piloto, el gasto se concentrará en base de datos, almacenamiento, ejecución de contenedores y consumo de IA. El costo exacto dependerá de la región, capacidad, tráfico, retención de copias y cantidad de solicitudes; por ello deberá estimarse con la calculadora vigente de Azure antes del despliegue. El escalado a cero de la capa web puede reducir el consumo cuando el sistema está inactivo, aunque la base de datos administrada y otros recursos pueden mantener cargos [\[8\]](https://learn.microsoft.com/en-us/azure/container-apps/scale-app), [\[9\]](https://learn.microsoft.com/en-us/azure/postgresql/flexible-server/service-overview).

[P00099 | 12628:12922 | NORMAL_TEXT]
La conclusión económica es favorable para un prototipo académico y un piloto controlado. Para uso comercial se requerirá un presupuesto mensual, límites de consumo, alertas de costos y un plan de respaldo. No se asumirá que el crédito estudiantil constituye un modelo sostenible de producción.

[P00100 | 12922:12945 | HEADING_3]
Factibilidad operativa

[P00101 | 12945:13329 | NORMAL_TEXT]
La solución es operativamente viable si la interfaz reproduce el flujo cotidiano de la agencia y requiere poca capacitación. Se recomienda iniciar con una sucursal piloto, migrar datos esenciales, capacitar al personal y mantener un período breve de verificación paralela. Los formularios deberán utilizar lenguaje sencillo, validaciones claras y estados visibles para cada vehículo.

[P00102 | 13329:13737 | NORMAL_TEXT]
La adopción dependerá de que propietarios y empleados participen en el levantamiento de requisitos y en las pruebas. Los beneficios esperados son una fuente única de información, menor exposición a conflictos de reserva, mayor trazabilidad y acceso a reportes. El riesgo principal es la resistencia al cambio; se mitigará con prototipos tempranos, demostraciones, manual breve y soporte durante el arranque.

[P00103 | 13737:13764 | HEADING_3]
Conclusión de factibilidad

[P00104 | 13764:13992 | NORMAL_TEXT]
El proyecto se considera factible en los ámbitos técnico, económico y operativo para la Fase II, condicionado a mantener el alcance priorizado, validar las necesidades con agencias reales y controlar los servicios de nube e IA.

[P00105 | 13992:14015 | HEADING_1]
5. Descripción técnica

[P00106 | 14015:14043 | HEADING_2]
5.1 Diseño de la Aplicación

[P00107 | 14043:14060 | NORMAL_TEXT]
Prototipos UX/UI

[P00108 | 14060:14062 | NORMAL_TEXT]
[INLINE_OBJECT kix.goofdh6kqw2u]

[P00109 | 14062:14064 | NORMAL_TEXT]
[INLINE_OBJECT kix.xyj43myrtehz]

[P00110 | 14064:14066 | NORMAL_TEXT]
[INLINE_OBJECT kix.d9h1d3o9e4dv]

[P00111 | 14066:14068 | NORMAL_TEXT]
[INLINE_OBJECT kix.21e77mr44i2t]

[P00112 | 14068:14069 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00113 | 14069:14083 | NORMAL_TEXT]
Diagramas UML

[P00114 | 14083:14084 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00115 | 14084:14113 | HEADING_2]
5.2 Arquitectura del sistema

[P00116 | 14113:14136 | HEADING_3]
Enfoque arquitectónico

[P00117 | 14136:14513 | NORMAL_TEXT]
Se utilizará una arquitectura modular en capas dentro de una solución ASP.NET Core. Para el alcance académico se recomienda un monolito modular, ya que simplifica el despliegue y las transacciones sin impedir la separación lógica. No se propone una arquitectura de microservicios en la primera versión porque agregaría complejidad operativa innecesaria para una flota pequeña.

[P00118 | 14513:14534 | HEADING_3]
Capa de presentación

[P00119 | 14534:14830 | NORMAL_TEXT]
Aplicación ASP.NET Core MVC o Web App con diseño responsive. Presentará paneles diferentes para administrador y empleado, además de vistas para consulta y reserva. Los controladores recibirán solicitudes, validarán modelos y delegaron los casos de uso; no contendrán reglas de negocio complejas.

[P00120 | 14830:14849 | HEADING_3]
Capa de aplicación

[P00121 | 14849:15156 | NORMAL_TEXT]
Orquestará los casos de uso: registrar vehículo, consultar disponibilidad, crear reserva, iniciar alquiler, cerrar devolución, programar mantenimiento, generar reporte y solicitar recomendación. Definirá interfaces para persistencia, correo, archivos e IA, facilitando pruebas y sustitución de proveedores.

[P00122 | 15156:15172 | HEADING_3]
Capa de dominio

[P00123 | 15172:15541 | NORMAL_TEXT]
Contendrá entidades, objetos de valor y reglas centrales. Entre las entidades previstas se encuentran Usuario, Rol, Cliente, Sucursal, Vehículo, Categoría, Tarifa, Reserva, Alquiler, Inspección, Cargo Adicional, Pago, Mantenimiento y Recomendación. Las reglas impedirán superposición de reservas, uso de vehículos fuera de servicio y cierre incompleto de devoluciones.

[P00124 | 15541:15565 | HEADING_3]
Capa de infraestructura

[P00125 | 15565:15870 | NORMAL_TEXT]
Implementará Entity Framework Core, PostgreSQL, repositorios cuando aporten valor, almacenamiento de imágenes, notificaciones, auditoría, registros y el adaptador del servicio de IA. Las credenciales se obtendrán desde configuración segura o secretos del entorno y nunca se almacenarán en el repositorio.

[P00126 | 15870:15897 | HEADING_3]
Aplicación web y servicios

[P00127 | 15897:16197 | NORMAL_TEXT]
ASP.NET Core será la plataforma de frontend y backend solicitada por la asignatura. La aplicación expondrá endpoints internos o una API web para los módulos que lo requieran. Las respuestas utilizarán modelos de transferencia de datos para evitar exponer directamente las entidades persistentes [\[5\]](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-10.0).

[P00128 | 16197:16235 | HEADING_3]
Base de datos y Entity Framework Core

[P00129 | 16235:16580 | NORMAL_TEXT]
PostgreSQL almacenará la información transaccional. Entity Framework Core administrará el mapeo, las relaciones, consultas y migraciones [\[6\]](https://learn.microsoft.com/en-us/ef/). Se aplicarán restricciones e índices para proteger la integridad: matrícula o placa única, correo normalizado cuando corresponda, estados controlados y consultas eficientes por fecha, vehículo y estado.

[P00130 | 16580:16933 | NORMAL_TEXT]
Las operaciones de reserva deberán ejecutarse de forma transaccional. Antes de confirmar, el servidor consultará cruces de fechas y volverá a validar dentro de la operación para reducir condiciones de carrera. Las eliminaciones físicas se limitarán; los registros históricos utilizarán estados o baja lógica cuando sea necesario conservar trazabilidad.

[P00131 | 16933:16943 | HEADING_3]
Seguridad

[P00132 | 16943:17274 | NORMAL_TEXT]
Se propone ASP.NET Core Identity o un mecanismo equivalente para autenticación, contraseñas protegidas y gestión de roles. Se aplicarán autorización por políticas, HTTPS, protección antifalsificación en formularios, validación del lado del servidor, límites de solicitudes, registros de auditoría y manejo centralizado de errores.

[P00133 | 17274:17723 | NORMAL_TEXT]
El sistema tratará datos personales de clientes, por lo que deberá observar la Ley para la Protección de Datos Personales de El Salvador, Decreto Legislativo n.º 144. La ley regula la recolección, uso, procesamiento y almacenamiento legítimo e informado de datos personales [\[4\]](https://www.asamblea.gob.sv/sites/default/files/documents/decretos/17458CF0-AB9B-482A-85A1-03834D5D89B7.pdf). El diseño deberá aplicar minimización, finalidad definida, control de acceso, conservación limitada y mecanismos para corregir o eliminar información cuando corresponda.

[P00134 | 17723:17747 | HEADING_3]
Inteligencia artificial

[P00135 | 17747:18057 | NORMAL_TEXT]
La IA recomendará vehículos, no aprobará clientes ni tomará decisiones legales o financieras. La entrada incluirá fechas, pasajeros, equipaje, presupuesto y preferencias, junto con una lista anonimizada de vehículos disponibles. No se enviarán documentos de identidad, licencias, direcciones ni datos de pago.

[P00136 | 18057:18535 | NORMAL_TEXT]
El backend validará que la respuesta haga referencia a identificadores permitidos y mostrará una explicación breve, alternativas y una advertencia de que la disponibilidad final debe confirmarse. Se registran versión del prompt, candidatos y resultado para pruebas. Microsoft recomienda un ciclo de identificar, medir, mitigar y operar los riesgos de sistemas generativos [\[11\]](https://learn.microsoft.com/en-us/azure/ai-foundry/responsible-ai/openai/overview); este enfoque se aplicará mediante casos de prueba, revisión humana, límites de alcance y monitoreo.

[P00137 | 18535:18564 | HEADING_3]
Contenerización y despliegue

[P00138 | 18564:18797 | NORMAL_TEXT]
La aplicación se ampliará en una imagen Docker con compilación por etapas. En desarrollo se utilizará Docker Compose para la aplicación y PostgreSQL. La imagen no contendrá secretos y se ejecutará con configuración por ambiente [\[7\]](https://docs.docker.com/get-started/introduction/).

[P00139 | 18797:19267 | NORMAL_TEXT]
La estrategia de Azure propuesta comprende Azure Container Registry para la imagen, Azure Container Apps para la aplicación, Azure Database for PostgreSQL Flexible Server para los datos y un servicio de almacenamiento para imágenes o documentos. El despliegue utilizará HTTPS, variables o secretos administrados, registros y alertas. El perfil de consumo de Container Apps es apropiado para un piloto con tráfico variable porque admite escalado automático y a cero [\[8\]](https://learn.microsoft.com/en-us/azure/container-apps/scale-app).

[P00140 | 19267:19301 | HEADING_3]
Respaldo, monitoreo y continuidad

[P00141 | 19301:19679 | NORMAL_TEXT]
Se habilitarán copias de seguridad de la base de datos, registros estructurados, métricas de errores y alertas de consumo. Antes de producción se probará la restauración, no solo la creación de respaldos. El servicio administrador de PostgreSQL reduce tareas de mantenimiento y ofrece capacidades integradas de respaldo y alta disponibilidad según la configuración elegida [\[9\]](https://learn.microsoft.com/en-us/azure/postgresql/flexible-server/service-overview).

[P00142 | 19679:19680 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00143 | 19680:19712 | HEADING_1]
5.3 Gestión de la Base de Datos

[P00144 | 19712:19738 | HEADING_3]
Diagrama Entidad-Relación

[P00145 | 19738:19740 | NORMAL_TEXT]
[INLINE_OBJECT kix.qozee56vgfhk]

[P00146 | 19740:19741 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00147 | 19741:19742 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00148 | 19742:19743 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00149 | 19743:19744 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00150 | 19744:19745 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00151 | 19745:19746 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00152 | 19746:19747 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00153 | 19747:19748 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00154 | 19748:19749 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00155 | 19749:19770 | HEADING_3]
Diccionario de Datos

[P00156 | 19770:19771 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00157 | 19771:19782 | NORMAL_TEXT]
Tabla: Rol

[P00158 | 19785:19791 | NORMAL_TEXT | TABLE row=0 col=0]
Campo

[P00159 | 19792:19805 | NORMAL_TEXT | TABLE row=0 col=1]
Tipo de dato

[P00160 | 19806:19818 | NORMAL_TEXT | TABLE row=0 col=2]
Descripción

[P00161 | 19819:19831 | NORMAL_TEXT | TABLE row=0 col=3]
Restricción

[P00162 | 19832:19841 | NORMAL_TEXT | TABLE row=0 col=4]
Relación

[P00163 | 19843:19849 | NORMAL_TEXT | TABLE row=1 col=0]
IdRol

[P00164 | 19850:19854 | NORMAL_TEXT | TABLE row=1 col=1]
INT

[P00165 | 19855:19878 | NORMAL_TEXT | TABLE row=1 col=2]
Identificador del rol.

[P00166 | 19879:19892 | NORMAL_TEXT | TABLE row=1 col=3]
PK, NOT NULL

[P00167 | 19893:19894 | NORMAL_TEXT | TABLE row=1 col=4]
⟦EMPTY PARAGRAPH⟧

[P00168 | 19896:19903 | NORMAL_TEXT | TABLE row=2 col=0]
Nombre

[P00169 | 19904:19916 | NORMAL_TEXT | TABLE row=2 col=1]
VARCHAR(50)

[P00170 | 19917:19933 | NORMAL_TEXT | TABLE row=2 col=2]
Nombre del rol.

[P00171 | 19934:19943 | NORMAL_TEXT | TABLE row=2 col=3]
NOT NULL

[P00172 | 19944:19945 | NORMAL_TEXT | TABLE row=2 col=4]
⟦EMPTY PARAGRAPH⟧

[P00173 | 19947:19959 | NORMAL_TEXT | TABLE row=3 col=0]
Descripción

[P00174 | 19960:19973 | NORMAL_TEXT | TABLE row=3 col=1]
VARCHAR(150)

[P00175 | 19974:20012 | NORMAL_TEXT | TABLE row=3 col=2]
Descripción de las funciones del rol.

[P00176 | 20013:20022 | NORMAL_TEXT | TABLE row=3 col=3]
NOT NULL

[P00177 | 20023:20024 | NORMAL_TEXT | TABLE row=3 col=4]
⟦EMPTY PARAGRAPH⟧

[P00178 | 20025:20026 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00179 | 20026:20041 | NORMAL_TEXT]
Tabla: Usuario

[P00180 | 20044:20050 | NORMAL_TEXT | TABLE row=0 col=0]
Campo

[P00181 | 20051:20064 | NORMAL_TEXT | TABLE row=0 col=1]
Tipo de dato

[P00182 | 20065:20077 | NORMAL_TEXT | TABLE row=0 col=2]
Descripción

[P00183 | 20078:20090 | NORMAL_TEXT | TABLE row=0 col=3]
Restricción

[P00184 | 20091:20100 | NORMAL_TEXT | TABLE row=0 col=4]
Relación

[P00185 | 20102:20112 | NORMAL_TEXT | TABLE row=1 col=0]
IdUsuario

[P00186 | 20113:20117 | NORMAL_TEXT | TABLE row=1 col=1]
INT

[P00187 | 20118:20145 | NORMAL_TEXT | TABLE row=1 col=2]
Identificador del usuario.

[P00188 | 20146:20159 | NORMAL_TEXT | TABLE row=1 col=3]
PK, NOT NULL

[P00189 | 20160:20161 | NORMAL_TEXT | TABLE row=1 col=4]
⟦EMPTY PARAGRAPH⟧

[P00190 | 20163:20169 | NORMAL_TEXT | TABLE row=2 col=0]
IdRol

[P00191 | 20170:20174 | NORMAL_TEXT | TABLE row=2 col=1]
INT

[P00192 | 20175:20200 | NORMAL_TEXT | TABLE row=2 col=2]
Rol asignado al usuario.

[P00193 | 20201:20214 | NORMAL_TEXT | TABLE row=2 col=3]
FK, NOT NULL

[P00194 | 20215:20219 | NORMAL_TEXT | TABLE row=2 col=4]
Rol

[P00195 | 20221:20232 | NORMAL_TEXT | TABLE row=3 col=0]
IdSucursal

[P00196 | 20233:20237 | NORMAL_TEXT | TABLE row=3 col=1]
INT

[P00197 | 20238:20273 | NORMAL_TEXT | TABLE row=3 col=2]
Sucursal donde trabaja el usuario.

[P00198 | 20274:20287 | NORMAL_TEXT | TABLE row=3 col=3]
FK, NOT NULL

[P00199 | 20288:20297 | NORMAL_TEXT | TABLE row=3 col=4]
Sucursal

[P00200 | 20299:20306 | NORMAL_TEXT | TABLE row=4 col=0]
Nombre

[P00201 | 20307:20319 | NORMAL_TEXT | TABLE row=4 col=1]
VARCHAR(50)

[P00202 | 20320:20340 | NORMAL_TEXT | TABLE row=4 col=2]
Nombre del usuario.

[P00203 | 20341:20350 | NORMAL_TEXT | TABLE row=4 col=3]
NOT NULL

[P00204 | 20351:20352 | NORMAL_TEXT | TABLE row=4 col=4]
⟦EMPTY PARAGRAPH⟧

[P00205 | 20354:20363 | NORMAL_TEXT | TABLE row=5 col=0]
Apellido

[P00206 | 20364:20376 | NORMAL_TEXT | TABLE row=5 col=1]
VARCHAR(50)

[P00207 | 20377:20399 | NORMAL_TEXT | TABLE row=5 col=2]
Apellido del usuario.

[P00208 | 20400:20409 | NORMAL_TEXT | TABLE row=5 col=3]
NOT NULL

[P00209 | 20410:20411 | NORMAL_TEXT | TABLE row=5 col=4]
⟦EMPTY PARAGRAPH⟧

[P00210 | 20413:20420 | NORMAL_TEXT | TABLE row=6 col=0]
Correo

[P00211 | 20421:20434 | NORMAL_TEXT | TABLE row=6 col=1]
VARCHAR(100)

[P00212 | 20435:20477 | NORMAL_TEXT | TABLE row=6 col=2]
Correo utilizado para acceder al sistema.

[P00213 | 20478:20487 | NORMAL_TEXT | TABLE row=6 col=3]
NOT NULL

[P00214 | 20488:20489 | NORMAL_TEXT | TABLE row=6 col=4]
⟦EMPTY PARAGRAPH⟧

[P00215 | 20491:20502 | NORMAL_TEXT | TABLE row=7 col=0]
Contraseña

[P00216 | 20503:20516 | NORMAL_TEXT | TABLE row=7 col=1]
VARCHAR(255)

[P00217 | 20517:20559 | NORMAL_TEXT | TABLE row=7 col=2]
Contraseña almacenada de forma protegida.

[P00218 | 20560:20569 | NORMAL_TEXT | TABLE row=7 col=3]
NOT NULL

[P00219 | 20570:20571 | NORMAL_TEXT | TABLE row=7 col=4]
⟦EMPTY PARAGRAPH⟧

[P00220 | 20573:20580 | NORMAL_TEXT | TABLE row=8 col=0]
Estado

[P00221 | 20581:20593 | NORMAL_TEXT | TABLE row=8 col=1]
VARCHAR(20)

[P00222 | 20594:20627 | NORMAL_TEXT | TABLE row=8 col=2]
Estado de la cuenta del usuario.

[P00223 | 20628:20637 | NORMAL_TEXT | TABLE row=8 col=3]
NOT NULL

[P00224 | 20638:20639 | NORMAL_TEXT | TABLE row=8 col=4]
⟦EMPTY PARAGRAPH⟧

[P00225 | 20640:20641 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00226 | 20641:20657 | NORMAL_TEXT]
Tabla: Sucursal

[P00227 | 20660:20666 | NORMAL_TEXT | TABLE row=0 col=0]
Campo

[P00228 | 20667:20680 | NORMAL_TEXT | TABLE row=0 col=1]
Tipo de dato

[P00229 | 20681:20693 | NORMAL_TEXT | TABLE row=0 col=2]
Descripción

[P00230 | 20694:20706 | NORMAL_TEXT | TABLE row=0 col=3]
Restricción

[P00231 | 20707:20716 | NORMAL_TEXT | TABLE row=0 col=4]
Relación

[P00232 | 20718:20729 | NORMAL_TEXT | TABLE row=1 col=0]
IdSucursal

[P00233 | 20730:20734 | NORMAL_TEXT | TABLE row=1 col=1]
INT

[P00234 | 20735:20765 | NORMAL_TEXT | TABLE row=1 col=2]
Identificador de la sucursal.

[P00235 | 20766:20779 | NORMAL_TEXT | TABLE row=1 col=3]
PK, NOT NULL

[P00236 | 20780:20781 | NORMAL_TEXT | TABLE row=1 col=4]
⟦EMPTY PARAGRAPH⟧

[P00237 | 20783:20790 | NORMAL_TEXT | TABLE row=2 col=0]
Nombre

[P00238 | 20791:20804 | NORMAL_TEXT | TABLE row=2 col=1]
VARCHAR(100)

[P00239 | 20805:20828 | NORMAL_TEXT | TABLE row=2 col=2]
Nombre de la sucursal.

[P00240 | 20829:20838 | NORMAL_TEXT | TABLE row=2 col=3]
NOT NULL

[P00241 | 20839:20840 | NORMAL_TEXT | TABLE row=2 col=4]
⟦EMPTY PARAGRAPH⟧

[P00242 | 20842:20852 | NORMAL_TEXT | TABLE row=3 col=0]
Direccion

[P00243 | 20853:20866 | NORMAL_TEXT | TABLE row=3 col=1]
VARCHAR(200)

[P00244 | 20867:20893 | NORMAL_TEXT | TABLE row=3 col=2]
Dirección de la sucursal.

[P00245 | 20894:20903 | NORMAL_TEXT | TABLE row=3 col=3]
NOT NULL

[P00246 | 20904:20905 | NORMAL_TEXT | TABLE row=3 col=4]
⟦EMPTY PARAGRAPH⟧

[P00247 | 20907:20916 | NORMAL_TEXT | TABLE row=4 col=0]
Telefono

[P00248 | 20917:20929 | NORMAL_TEXT | TABLE row=4 col=1]
VARCHAR(20)

[P00249 | 20930:20952 | NORMAL_TEXT | TABLE row=4 col=2]
Teléfono de contacto.

[P00250 | 20953:20962 | NORMAL_TEXT | TABLE row=4 col=3]
NOT NULL

[P00251 | 20963:20964 | NORMAL_TEXT | TABLE row=4 col=4]
⟦EMPTY PARAGRAPH⟧

[P00252 | 20966:20973 | NORMAL_TEXT | TABLE row=5 col=0]
Estado

[P00253 | 20974:20986 | NORMAL_TEXT | TABLE row=5 col=1]
VARCHAR(20)

[P00254 | 20987:21013 | NORMAL_TEXT | TABLE row=5 col=2]
Estado de funcionamiento.

[P00255 | 21014:21023 | NORMAL_TEXT | TABLE row=5 col=3]
NOT NULL

[P00256 | 21024:21025 | NORMAL_TEXT | TABLE row=5 col=4]
⟦EMPTY PARAGRAPH⟧

[P00257 | 21026:21027 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00258 | 21027:21028 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00259 | 21028:21045 | NORMAL_TEXT]
Tabla: Categoría

[P00260 | 21048:21054 | NORMAL_TEXT | TABLE row=0 col=0]
Campo

[P00261 | 21055:21068 | NORMAL_TEXT | TABLE row=0 col=1]
Tipo de dato

[P00262 | 21069:21081 | NORMAL_TEXT | TABLE row=0 col=2]
Descripción

[P00263 | 21082:21094 | NORMAL_TEXT | TABLE row=0 col=3]
Restricción

[P00264 | 21095:21104 | NORMAL_TEXT | TABLE row=0 col=4]
Relación

[P00265 | 21106:21118 | NORMAL_TEXT | TABLE row=1 col=0]
IdCategoria

[P00266 | 21119:21123 | NORMAL_TEXT | TABLE row=1 col=1]
INT

[P00267 | 21124:21155 | NORMAL_TEXT | TABLE row=1 col=2]
Identificador de la categoría.

[P00268 | 21156:21169 | NORMAL_TEXT | TABLE row=1 col=3]
PK, NOT NULL

[P00269 | 21170:21171 | NORMAL_TEXT | TABLE row=1 col=4]
⟦EMPTY PARAGRAPH⟧

[P00270 | 21173:21180 | NORMAL_TEXT | TABLE row=2 col=0]
Nombre

[P00271 | 21181:21193 | NORMAL_TEXT | TABLE row=2 col=1]
VARCHAR(50)

[P00272 | 21194:21218 | NORMAL_TEXT | TABLE row=2 col=2]
Nombre de la categoría.

[P00273 | 21219:21228 | NORMAL_TEXT | TABLE row=2 col=3]
NOT NULL

[P00274 | 21229:21230 | NORMAL_TEXT | TABLE row=2 col=4]
⟦EMPTY PARAGRAPH⟧

[P00275 | 21232:21244 | NORMAL_TEXT | TABLE row=3 col=0]
Descripcion

[P00276 | 21245:21258 | NORMAL_TEXT | TABLE row=3 col=1]
VARCHAR(150)

[P00277 | 21259:21288 | NORMAL_TEXT | TABLE row=3 col=2]
Descripción de la categoría.

[P00278 | 21289:21298 | NORMAL_TEXT | TABLE row=3 col=3]
NOT NULL

[P00279 | 21299:21300 | NORMAL_TEXT | TABLE row=3 col=4]
⟦EMPTY PARAGRAPH⟧

[P00280 | 21301:21302 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00281 | 21302:21303 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00282 | 21303:21304 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00283 | 21304:21305 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00284 | 21305:21306 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00285 | 21306:21307 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00286 | 21307:21308 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00287 | 21308:21309 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00288 | 21309:21310 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00289 | 21310:21311 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00290 | 21311:21312 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00291 | 21312:21313 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00292 | 21313:21329 | NORMAL_TEXT]
Tabla: Vehiculo

[P00293 | 21332:21338 | NORMAL_TEXT | TABLE row=0 col=0]
Campo

[P00294 | 21339:21352 | NORMAL_TEXT | TABLE row=0 col=1]
Tipo de dato

[P00295 | 21353:21365 | NORMAL_TEXT | TABLE row=0 col=2]
Descripción

[P00296 | 21366:21378 | NORMAL_TEXT | TABLE row=0 col=3]
Restricción

[P00297 | 21379:21388 | NORMAL_TEXT | TABLE row=0 col=4]
Relación

[P00298 | 21390:21401 | NORMAL_TEXT | TABLE row=1 col=0]
IdVehiculo

[P00299 | 21402:21406 | NORMAL_TEXT | TABLE row=1 col=1]
INT

[P00300 | 21407:21435 | NORMAL_TEXT | TABLE row=1 col=2]
Identificador del vehículo.

[P00301 | 21436:21449 | NORMAL_TEXT | TABLE row=1 col=3]
PK, NOT NULL

[P00302 | 21450:21451 | NORMAL_TEXT | TABLE row=1 col=4]
⟦EMPTY PARAGRAPH⟧

[P00303 | 21453:21465 | NORMAL_TEXT | TABLE row=2 col=0]
IdCategoria

[P00304 | 21466:21470 | NORMAL_TEXT | TABLE row=2 col=1]
INT

[P00305 | 21471:21495 | NORMAL_TEXT | TABLE row=2 col=2]
Categoría del vehículo.

[P00306 | 21496:21509 | NORMAL_TEXT | TABLE row=2 col=3]
FK, NOT NULL

[P00307 | 21510:21520 | NORMAL_TEXT | TABLE row=2 col=4]
Categoría

[P00308 | 21522:21533 | NORMAL_TEXT | TABLE row=3 col=0]
IdSucursal

[P00309 | 21534:21538 | NORMAL_TEXT | TABLE row=3 col=1]
INT

[P00310 | 21539:21568 | NORMAL_TEXT | TABLE row=3 col=2]
Sucursal a la que pertenece.

[P00311 | 21569:21582 | NORMAL_TEXT | TABLE row=3 col=3]
FK, NOT NULL

[P00312 | 21583:21592 | NORMAL_TEXT | TABLE row=3 col=4]
Sucursal

[P00313 | 21594:21600 | NORMAL_TEXT | TABLE row=4 col=0]
Placa

[P00314 | 21601:21613 | NORMAL_TEXT | TABLE row=4 col=1]
VARCHAR(15)

[P00315 | 21614:21644 | NORMAL_TEXT | TABLE row=4 col=2]
Número de placa del vehículo.

[P00316 | 21645:21654 | NORMAL_TEXT | TABLE row=4 col=3]
NOT NULL

[P00317 | 21655:21656 | NORMAL_TEXT | TABLE row=4 col=4]
⟦EMPTY PARAGRAPH⟧

[P00318 | 21658:21664 | NORMAL_TEXT | TABLE row=5 col=0]
Marca

[P00319 | 21665:21677 | NORMAL_TEXT | TABLE row=5 col=1]
VARCHAR(50)

[P00320 | 21678:21698 | NORMAL_TEXT | TABLE row=5 col=2]
Marca del vehículo.

[P00321 | 21699:21708 | NORMAL_TEXT | TABLE row=5 col=3]
NOT NULL

[P00322 | 21709:21710 | NORMAL_TEXT | TABLE row=5 col=4]
⟦EMPTY PARAGRAPH⟧

[P00323 | 21712:21719 | NORMAL_TEXT | TABLE row=6 col=0]
Modelo

[P00324 | 21720:21732 | NORMAL_TEXT | TABLE row=6 col=1]
VARCHAR(50)

[P00325 | 21733:21754 | NORMAL_TEXT | TABLE row=6 col=2]
Modelo del vehículo.

[P00326 | 21755:21764 | NORMAL_TEXT | TABLE row=6 col=3]
NOT NULL

[P00327 | 21765:21766 | NORMAL_TEXT | TABLE row=6 col=4]
⟦EMPTY PARAGRAPH⟧

[P00328 | 21768:21772 | NORMAL_TEXT | TABLE row=7 col=0]
Año

[P00329 | 21773:21777 | NORMAL_TEXT | TABLE row=7 col=1]
INT

[P00330 | 21778:21796 | NORMAL_TEXT | TABLE row=7 col=2]
Año del vehículo.

[P00331 | 21797:21806 | NORMAL_TEXT | TABLE row=7 col=3]
NOT NULL

[P00332 | 21807:21808 | NORMAL_TEXT | TABLE row=7 col=4]
⟦EMPTY PARAGRAPH⟧

[P00333 | 21810:21816 | NORMAL_TEXT | TABLE row=8 col=0]
Color

[P00334 | 21817:21829 | NORMAL_TEXT | TABLE row=8 col=1]
VARCHAR(30)

[P00335 | 21830:21850 | NORMAL_TEXT | TABLE row=8 col=2]
Color del vehículo.

[P00336 | 21851:21860 | NORMAL_TEXT | TABLE row=8 col=3]
NOT NULL

[P00337 | 21861:21862 | NORMAL_TEXT | TABLE row=8 col=4]
⟦EMPTY PARAGRAPH⟧

[P00338 | 21864:21876 | NORMAL_TEXT | TABLE row=9 col=0]
Transmisión

[P00339 | 21877:21889 | NORMAL_TEXT | TABLE row=9 col=1]
VARCHAR(20)

[P00340 | 21890:21911 | NORMAL_TEXT | TABLE row=9 col=2]
Tipo de transmisión.

[P00341 | 21912:21921 | NORMAL_TEXT | TABLE row=9 col=3]
NOT NULL

[P00342 | 21922:21923 | NORMAL_TEXT | TABLE row=9 col=4]
⟦EMPTY PARAGRAPH⟧

[P00343 | 21925:21944 | NORMAL_TEXT | TABLE row=10 col=0]
CapacidadPasajeros

[P00344 | 21945:21949 | NORMAL_TEXT | TABLE row=10 col=1]
INT

[P00345 | 21950:21980 | NORMAL_TEXT | TABLE row=10 col=2]
Cantidad máxima de pasajeros.

[P00346 | 21981:21990 | NORMAL_TEXT | TABLE row=10 col=3]
NOT NULL

[P00347 | 21991:21992 | NORMAL_TEXT | TABLE row=10 col=4]
⟦EMPTY PARAGRAPH⟧

[P00348 | 21994:22006 | NORMAL_TEXT | TABLE row=11 col=0]
Kilometraje

[P00349 | 22007:22021 | NORMAL_TEXT | TABLE row=11 col=1]
NUMERIC(10,2)

[P00350 | 22022:22055 | NORMAL_TEXT | TABLE row=11 col=2]
Kilometraje actual del vehículo.

[P00351 | 22056:22065 | NORMAL_TEXT | TABLE row=11 col=3]
NOT NULL

[P00352 | 22066:22067 | NORMAL_TEXT | TABLE row=11 col=4]
⟦EMPTY PARAGRAPH⟧

[P00353 | 22069:22076 | NORMAL_TEXT | TABLE row=12 col=0]
Estado

[P00354 | 22077:22089 | NORMAL_TEXT | TABLE row=12 col=1]
VARCHAR(20)

[P00355 | 22090:22118 | NORMAL_TEXT | TABLE row=12 col=2]
Estado actual del vehículo.

[P00356 | 22119:22128 | NORMAL_TEXT | TABLE row=12 col=3]
NOT NULL

[P00357 | 22129:22130 | NORMAL_TEXT | TABLE row=12 col=4]
⟦EMPTY PARAGRAPH⟧

[P00358 | 22131:22132 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00359 | 22132:22133 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00360 | 22133:22147 | NORMAL_TEXT]
Tabla: Tarifa

[P00361 | 22150:22156 | NORMAL_TEXT | TABLE row=0 col=0]
Campo

[P00362 | 22157:22170 | NORMAL_TEXT | TABLE row=0 col=1]
Tipo de dato

[P00363 | 22171:22183 | NORMAL_TEXT | TABLE row=0 col=2]
Descripción

[P00364 | 22184:22196 | NORMAL_TEXT | TABLE row=0 col=3]
Restricción

[P00365 | 22197:22206 | NORMAL_TEXT | TABLE row=0 col=4]
Relación

[P00366 | 22208:22217 | NORMAL_TEXT | TABLE row=1 col=0]
IdTarifa

[P00367 | 22218:22222 | NORMAL_TEXT | TABLE row=1 col=1]
INT

[P00368 | 22223:22251 | NORMAL_TEXT | TABLE row=1 col=2]
Identificador de la tarifa.

[P00369 | 22252:22265 | NORMAL_TEXT | TABLE row=1 col=3]
PK, NOT NULL

[P00370 | 22266:22267 | NORMAL_TEXT | TABLE row=1 col=4]
⟦EMPTY PARAGRAPH⟧

[P00371 | 22269:22281 | NORMAL_TEXT | TABLE row=2 col=0]
IdCategoria

[P00372 | 22282:22286 | NORMAL_TEXT | TABLE row=2 col=1]
INT

[P00373 | 22287:22317 | NORMAL_TEXT | TABLE row=2 col=2]
Categoría a la que se aplica.

[P00374 | 22318:22331 | NORMAL_TEXT | TABLE row=2 col=3]
FK, NOT NULL

[P00375 | 22332:22342 | NORMAL_TEXT | TABLE row=2 col=4]
Categoría

[P00376 | 22344:22351 | NORMAL_TEXT | TABLE row=3 col=0]
Nombre

[P00377 | 22352:22364 | NORMAL_TEXT | TABLE row=3 col=1]
VARCHAR(50)

[P00378 | 22365:22390 | NORMAL_TEXT | TABLE row=3 col=2]
Nombre o tipo de tarifa.

[P00379 | 22391:22400 | NORMAL_TEXT | TABLE row=3 col=3]
NOT NULL

[P00380 | 22401:22402 | NORMAL_TEXT | TABLE row=3 col=4]
⟦EMPTY PARAGRAPH⟧

[P00381 | 22404:22414 | NORMAL_TEXT | TABLE row=4 col=0]
PrecioDia

[P00382 | 22415:22429 | NORMAL_TEXT | TABLE row=4 col=1]
NUMERIC(10,2)

[P00383 | 22430:22458 | NORMAL_TEXT | TABLE row=4 col=2]
Precio de alquiler por día.

[P00384 | 22459:22468 | NORMAL_TEXT | TABLE row=4 col=3]
NOT NULL

[P00385 | 22469:22470 | NORMAL_TEXT | TABLE row=4 col=4]
⟦EMPTY PARAGRAPH⟧

[P00386 | 22472:22487 | NORMAL_TEXT | TABLE row=5 col=0]
VigenciaDesde 

[P00387 | 22488:22494 | NORMAL_TEXT | TABLE row=5 col=1]
DATE 

[P00388 | 22495:22532 | NORMAL_TEXT | TABLE row=5 col=2]
Fecha desde la que aplica la tarifa 

[P00389 | 22533:22543 | NORMAL_TEXT | TABLE row=5 col=3]
NOT NULL 

[P00390 | 22544:22545 | NORMAL_TEXT | TABLE row=5 col=4]
⟦EMPTY PARAGRAPH⟧

[P00391 | 22547:22562 | NORMAL_TEXT | TABLE row=6 col=0]
VigenciaHasta 

[P00392 | 22563:22569 | NORMAL_TEXT | TABLE row=6 col=1]
DATE 

[P00393 | 22570:22607 | NORMAL_TEXT | TABLE row=6 col=2]
Fecha hasta la que aplica la tarifa 

[P00394 | 22608:22618 | NORMAL_TEXT | TABLE row=6 col=3]
NOT NULL 

[P00395 | 22619:22620 | NORMAL_TEXT | TABLE row=6 col=4]
⟦EMPTY PARAGRAPH⟧

[P00396 | 22622:22629 | NORMAL_TEXT | TABLE row=7 col=0]
Estado

[P00397 | 22630:22642 | NORMAL_TEXT | TABLE row=7 col=1]
VARCHAR(20)

[P00398 | 22643:22676 | NORMAL_TEXT | TABLE row=7 col=2]
Estado de vigencia de la tarifa.

[P00399 | 22677:22686 | NORMAL_TEXT | TABLE row=7 col=3]
NOT NULL

[P00400 | 22687:22688 | NORMAL_TEXT | TABLE row=7 col=4]
⟦EMPTY PARAGRAPH⟧

[P00401 | 22689:22690 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00402 | 22690:22705 | NORMAL_TEXT]
Tabla: Cliente

[P00403 | 22708:22714 | NORMAL_TEXT | TABLE row=0 col=0]
Campo

[P00404 | 22715:22728 | NORMAL_TEXT | TABLE row=0 col=1]
Tipo de dato

[P00405 | 22729:22741 | NORMAL_TEXT | TABLE row=0 col=2]
Descripción

[P00406 | 22742:22754 | NORMAL_TEXT | TABLE row=0 col=3]
Restricción

[P00407 | 22755:22764 | NORMAL_TEXT | TABLE row=0 col=4]
Relación

[P00408 | 22766:22776 | NORMAL_TEXT | TABLE row=1 col=0]
IdCliente

[P00409 | 22777:22781 | NORMAL_TEXT | TABLE row=1 col=1]
INT

[P00410 | 22782:22809 | NORMAL_TEXT | TABLE row=1 col=2]
Identificador del cliente.

[P00411 | 22810:22823 | NORMAL_TEXT | TABLE row=1 col=3]
PK, NOT NULL

[P00412 | 22824:22825 | NORMAL_TEXT | TABLE row=1 col=4]
⟦EMPTY PARAGRAPH⟧

[P00413 | 22827:22834 | NORMAL_TEXT | TABLE row=2 col=0]
Nombre

[P00414 | 22835:22847 | NORMAL_TEXT | TABLE row=2 col=1]
VARCHAR(50)

[P00415 | 22848:22868 | NORMAL_TEXT | TABLE row=2 col=2]
Nombre del cliente.

[P00416 | 22869:22878 | NORMAL_TEXT | TABLE row=2 col=3]
NOT NULL

[P00417 | 22879:22880 | NORMAL_TEXT | TABLE row=2 col=4]
⟦EMPTY PARAGRAPH⟧

[P00418 | 22882:22891 | NORMAL_TEXT | TABLE row=3 col=0]
Apellido

[P00419 | 22892:22904 | NORMAL_TEXT | TABLE row=3 col=1]
VARCHAR(50)

[P00420 | 22905:22927 | NORMAL_TEXT | TABLE row=3 col=2]
Apellido del cliente.

[P00421 | 22928:22937 | NORMAL_TEXT | TABLE row=3 col=3]
NOT NULL

[P00422 | 22938:22939 | NORMAL_TEXT | TABLE row=3 col=4]
⟦EMPTY PARAGRAPH⟧

[P00423 | 22941:22951 | NORMAL_TEXT | TABLE row=4 col=0]
Documento

[P00424 | 22952:22964 | NORMAL_TEXT | TABLE row=4 col=1]
VARCHAR(30)

[P00425 | 22965:22994 | NORMAL_TEXT | TABLE row=4 col=2]
Documento de identificación.

[P00426 | 22995:23004 | NORMAL_TEXT | TABLE row=4 col=3]
NOT NULL

[P00427 | 23005:23006 | NORMAL_TEXT | TABLE row=4 col=4]
⟦EMPTY PARAGRAPH⟧

[P00428 | 23008:23017 | NORMAL_TEXT | TABLE row=5 col=0]
Licencia

[P00429 | 23018:23030 | NORMAL_TEXT | TABLE row=5 col=1]
VARCHAR(30)

[P00430 | 23031:23063 | NORMAL_TEXT | TABLE row=5 col=2]
Número de licencia de conducir.

[P00431 | 23064:23073 | NORMAL_TEXT | TABLE row=5 col=3]
NOT NULL

[P00432 | 23074:23075 | NORMAL_TEXT | TABLE row=5 col=4]
⟦EMPTY PARAGRAPH⟧

[P00433 | 23077:23086 | NORMAL_TEXT | TABLE row=6 col=0]
Telefono

[P00434 | 23087:23099 | NORMAL_TEXT | TABLE row=6 col=1]
VARCHAR(20)

[P00435 | 23100:23119 | NORMAL_TEXT | TABLE row=6 col=2]
Número telefónico.

[P00436 | 23120:23129 | NORMAL_TEXT | TABLE row=6 col=3]
NOT NULL

[P00437 | 23130:23131 | NORMAL_TEXT | TABLE row=6 col=4]
⟦EMPTY PARAGRAPH⟧

[P00438 | 23133:23140 | NORMAL_TEXT | TABLE row=7 col=0]
Correo

[P00439 | 23141:23154 | NORMAL_TEXT | TABLE row=7 col=1]
VARCHAR(100)

[P00440 | 23155:23175 | NORMAL_TEXT | TABLE row=7 col=2]
Correo electrónico.

[P00441 | 23176:23185 | NORMAL_TEXT | TABLE row=7 col=3]
NOT NULL

[P00442 | 23186:23187 | NORMAL_TEXT | TABLE row=7 col=4]
⟦EMPTY PARAGRAPH⟧

[P00443 | 23189:23199 | NORMAL_TEXT | TABLE row=8 col=0]
Direccion

[P00444 | 23200:23213 | NORMAL_TEXT | TABLE row=8 col=1]
VARCHAR(200)

[P00445 | 23214:23237 | NORMAL_TEXT | TABLE row=8 col=2]
Dirección del cliente.

[P00446 | 23238:23247 | NORMAL_TEXT | TABLE row=8 col=3]
NOT NULL

[P00447 | 23248:23249 | NORMAL_TEXT | TABLE row=8 col=4]
⟦EMPTY PARAGRAPH⟧

[P00448 | 23251:23265 | NORMAL_TEXT | TABLE row=9 col=0]
FechaRegistro

[P00449 | 23266:23271 | NORMAL_TEXT | TABLE row=9 col=1]
DATE

[P00450 | 23272:23303 | NORMAL_TEXT | TABLE row=9 col=2]
Fecha de registro del cliente.

[P00451 | 23304:23313 | NORMAL_TEXT | TABLE row=9 col=3]
NOT NULL

[P00452 | 23314:23315 | NORMAL_TEXT | TABLE row=9 col=4]
⟦EMPTY PARAGRAPH⟧

[P00453 | 23316:23317 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00454 | 23317:23332 | NORMAL_TEXT]
Tabla: Reserva

[P00455 | 23335:23341 | NORMAL_TEXT | TABLE row=0 col=0]
Campo

[P00456 | 23342:23355 | NORMAL_TEXT | TABLE row=0 col=1]
Tipo de dato

[P00457 | 23356:23368 | NORMAL_TEXT | TABLE row=0 col=2]
Descripción

[P00458 | 23369:23381 | NORMAL_TEXT | TABLE row=0 col=3]
Restricción

[P00459 | 23382:23391 | NORMAL_TEXT | TABLE row=0 col=4]
Relación

[P00460 | 23393:23403 | NORMAL_TEXT | TABLE row=1 col=0]
IdReserva

[P00461 | 23404:23408 | NORMAL_TEXT | TABLE row=1 col=1]
INT

[P00462 | 23409:23438 | NORMAL_TEXT | TABLE row=1 col=2]
Identificador de la reserva.

[P00463 | 23439:23452 | NORMAL_TEXT | TABLE row=1 col=3]
PK, NOT NULL

[P00464 | 23453:23454 | NORMAL_TEXT | TABLE row=1 col=4]
⟦EMPTY PARAGRAPH⟧

[P00465 | 23456:23466 | NORMAL_TEXT | TABLE row=2 col=0]
IdCliente

[P00466 | 23467:23471 | NORMAL_TEXT | TABLE row=2 col=1]
INT

[P00467 | 23472:23504 | NORMAL_TEXT | TABLE row=2 col=2]
Cliente que realiza la reserva.

[P00468 | 23505:23518 | NORMAL_TEXT | TABLE row=2 col=3]
FK, NOT NULL

[P00469 | 23519:23527 | NORMAL_TEXT | TABLE row=2 col=4]
Cliente

[P00470 | 23529:23540 | NORMAL_TEXT | TABLE row=3 col=0]
IdVehiculo

[P00471 | 23541:23545 | NORMAL_TEXT | TABLE row=3 col=1]
INT

[P00472 | 23546:23566 | NORMAL_TEXT | TABLE row=3 col=2]
Vehículo reservado.

[P00473 | 23567:23580 | NORMAL_TEXT | TABLE row=3 col=3]
FK, NOT NULL

[P00474 | 23581:23590 | NORMAL_TEXT | TABLE row=3 col=4]
Vehículo

[P00475 | 23592:23605 | NORMAL_TEXT | TABLE row=4 col=0]
FechaReserva

[P00476 | 23606:23611 | NORMAL_TEXT | TABLE row=4 col=1]
DATE

[P00477 | 23612:23649 | NORMAL_TEXT | TABLE row=4 col=2]
Fecha en que se registró la reserva.

[P00478 | 23650:23659 | NORMAL_TEXT | TABLE row=4 col=3]
NOT NULL

[P00479 | 23660:23661 | NORMAL_TEXT | TABLE row=4 col=4]
⟦EMPTY PARAGRAPH⟧

[P00480 | 23663:23675 | NORMAL_TEXT | TABLE row=5 col=0]
FechaInicio

[P00481 | 23676:23681 | NORMAL_TEXT | TABLE row=5 col=1]
DATE

[P00482 | 23682:23713 | NORMAL_TEXT | TABLE row=5 col=2]
Fecha de inicio de la reserva.

[P00483 | 23714:23723 | NORMAL_TEXT | TABLE row=5 col=3]
NOT NULL

[P00484 | 23724:23725 | NORMAL_TEXT | TABLE row=5 col=4]
⟦EMPTY PARAGRAPH⟧

[P00485 | 23727:23736 | NORMAL_TEXT | TABLE row=6 col=0]
FechaFin

[P00486 | 23737:23742 | NORMAL_TEXT | TABLE row=6 col=1]
DATE

[P00487 | 23743:23780 | NORMAL_TEXT | TABLE row=6 col=2]
Fecha de finalización de la reserva.

[P00488 | 23781:23790 | NORMAL_TEXT | TABLE row=6 col=3]
NOT NULL

[P00489 | 23791:23792 | NORMAL_TEXT | TABLE row=6 col=4]
⟦EMPTY PARAGRAPH⟧

[P00490 | 23794:23808 | NORMAL_TEXT | TABLE row=7 col=0]
TotalEstimado

[P00491 | 23809:23823 | NORMAL_TEXT | TABLE row=7 col=1]
NUMERIC(10,2)

[P00492 | 23824:23854 | NORMAL_TEXT | TABLE row=7 col=2]
Costo estimado de la reserva.

[P00493 | 23855:23864 | NORMAL_TEXT | TABLE row=7 col=3]
NOT NULL

[P00494 | 23865:23866 | NORMAL_TEXT | TABLE row=7 col=4]
⟦EMPTY PARAGRAPH⟧

[P00495 | 23868:23875 | NORMAL_TEXT | TABLE row=8 col=0]
Estado

[P00496 | 23876:23888 | NORMAL_TEXT | TABLE row=8 col=1]
VARCHAR(20)

[P00497 | 23889:23911 | NORMAL_TEXT | TABLE row=8 col=2]
Estado de la reserva.

[P00498 | 23912:23921 | NORMAL_TEXT | TABLE row=8 col=3]
NOT NULL

[P00499 | 23922:23923 | NORMAL_TEXT | TABLE row=8 col=4]
⟦EMPTY PARAGRAPH⟧

[P00500 | 23925:23940 | NORMAL_TEXT | TABLE row=9 col=0]
Observaciones 

[P00501 | 23941:23955 | NORMAL_TEXT | TABLE row=9 col=1]
VARCHAR(300) 

[P00502 | 23956:24006 | NORMAL_TEXT | TABLE row=9 col=2]
Información adicional relacionada con la reserva 

[P00503 | 24007:24017 | NORMAL_TEXT | TABLE row=9 col=3]
NOT NULL 

[P00504 | 24018:24019 | NORMAL_TEXT | TABLE row=9 col=4]
⟦EMPTY PARAGRAPH⟧

[P00505 | 24020:24021 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00506 | 24021:24022 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00507 | 24022:24038 | NORMAL_TEXT]
Tabla: Alquiler

[P00508 | 24041:24047 | NORMAL_TEXT | TABLE row=0 col=0]
Campo

[P00509 | 24048:24061 | NORMAL_TEXT | TABLE row=0 col=1]
Tipo de dato

[P00510 | 24062:24074 | NORMAL_TEXT | TABLE row=0 col=2]
Descripción

[P00511 | 24075:24087 | NORMAL_TEXT | TABLE row=0 col=3]
Restricción

[P00512 | 24088:24097 | NORMAL_TEXT | TABLE row=0 col=4]
Relación

[P00513 | 24099:24110 | NORMAL_TEXT | TABLE row=1 col=0]
IdAlquiler

[P00514 | 24111:24115 | NORMAL_TEXT | TABLE row=1 col=1]
INT

[P00515 | 24116:24144 | NORMAL_TEXT | TABLE row=1 col=2]
Identificador del alquiler.

[P00516 | 24145:24158 | NORMAL_TEXT | TABLE row=1 col=3]
PK, NOT NULL

[P00517 | 24159:24160 | NORMAL_TEXT | TABLE row=1 col=4]
⟦EMPTY PARAGRAPH⟧

[P00518 | 24162:24172 | NORMAL_TEXT | TABLE row=2 col=0]
IdReserva

[P00519 | 24173:24177 | NORMAL_TEXT | TABLE row=2 col=1]
INT

[P00520 | 24178:24211 | NORMAL_TEXT | TABLE row=2 col=2]
Reserva que originó el alquiler.

[P00521 | 24212:24225 | NORMAL_TEXT | TABLE row=2 col=3]
FK, NOT NULL

[P00522 | 24226:24234 | NORMAL_TEXT | TABLE row=2 col=4]
Reserva

[P00523 | 24236:24248 | NORMAL_TEXT | TABLE row=3 col=0]
FechaInicio

[P00524 | 24249:24254 | NORMAL_TEXT | TABLE row=3 col=1]
DATE

[P00525 | 24255:24293 | NORMAL_TEXT | TABLE row=3 col=2]
Fecha y hora de entrega del vehículo.

[P00526 | 24294:24303 | NORMAL_TEXT | TABLE row=3 col=3]
NOT NULL

[P00527 | 24304:24305 | NORMAL_TEXT | TABLE row=3 col=4]
⟦EMPTY PARAGRAPH⟧

[P00528 | 24307:24316 | NORMAL_TEXT | TABLE row=4 col=0]
FechaFin

[P00529 | 24317:24322 | NORMAL_TEXT | TABLE row=4 col=1]
DATE

[P00530 | 24323:24355 | NORMAL_TEXT | TABLE row=4 col=2]
Fecha programada de devolución.

[P00531 | 24356:24365 | NORMAL_TEXT | TABLE row=4 col=3]
NOT NULL

[P00532 | 24366:24367 | NORMAL_TEXT | TABLE row=4 col=4]
⟦EMPTY PARAGRAPH⟧

[P00533 | 24369:24388 | NORMAL_TEXT | TABLE row=5 col=0]
KilometrajeInicial

[P00534 | 24389:24403 | NORMAL_TEXT | TABLE row=5 col=1]
NUMERIC(10,2)

[P00535 | 24404:24441 | NORMAL_TEXT | TABLE row=5 col=2]
Kilometraje al entregar el vehículo.

[P00536 | 24442:24451 | NORMAL_TEXT | TABLE row=5 col=3]
NOT NULL

[P00537 | 24452:24453 | NORMAL_TEXT | TABLE row=5 col=4]
⟦EMPTY PARAGRAPH⟧

[P00538 | 24455:24474 | NORMAL_TEXT | TABLE row=6 col=0]
CombustibleInicial

[P00539 | 24475:24488 | NORMAL_TEXT | TABLE row=6 col=1]
VARCHAR(20) 

[P00540 | 24489:24535 | NORMAL_TEXT | TABLE row=6 col=2]
Nivel de combustible al entregar el vehículo 

[P00541 | 24536:24545 | NORMAL_TEXT | TABLE row=6 col=3]
NOT NULL

[P00542 | 24546:24547 | NORMAL_TEXT | TABLE row=6 col=4]
⟦EMPTY PARAGRAPH⟧

[P00543 | 24549:24560 | NORMAL_TEXT | TABLE row=7 col=0]
MontoTotal

[P00544 | 24561:24575 | NORMAL_TEXT | TABLE row=7 col=1]
NUMERIC(10,2)

[P00545 | 24576:24602 | NORMAL_TEXT | TABLE row=7 col=2]
Total final del alquiler.

[P00546 | 24603:24612 | NORMAL_TEXT | TABLE row=7 col=3]
NOT NULL

[P00547 | 24613:24614 | NORMAL_TEXT | TABLE row=7 col=4]
⟦EMPTY PARAGRAPH⟧

[P00548 | 24616:24623 | NORMAL_TEXT | TABLE row=8 col=0]
Estado

[P00549 | 24624:24636 | NORMAL_TEXT | TABLE row=8 col=1]
VARCHAR(20)

[P00550 | 24637:24658 | NORMAL_TEXT | TABLE row=8 col=2]
Estado del alquiler.

[P00551 | 24659:24668 | NORMAL_TEXT | TABLE row=8 col=3]
NOT NULL

[P00552 | 24669:24670 | NORMAL_TEXT | TABLE row=8 col=4]
⟦EMPTY PARAGRAPH⟧

[P00553 | 24671:24672 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00554 | 24672:24690 | NORMAL_TEXT]
Tabla: Inspeccion

[P00555 | 24693:24699 | NORMAL_TEXT | TABLE row=0 col=0]
Campo

[P00556 | 24700:24713 | NORMAL_TEXT | TABLE row=0 col=1]
Tipo de dato

[P00557 | 24714:24726 | NORMAL_TEXT | TABLE row=0 col=2]
Descripción

[P00558 | 24727:24739 | NORMAL_TEXT | TABLE row=0 col=3]
Restricción

[P00559 | 24740:24749 | NORMAL_TEXT | TABLE row=0 col=4]
Relación

[P00560 | 24751:24764 | NORMAL_TEXT | TABLE row=1 col=0]
IdInspeccion

[P00561 | 24765:24769 | NORMAL_TEXT | TABLE row=1 col=1]
INT

[P00562 | 24770:24802 | NORMAL_TEXT | TABLE row=1 col=2]
Identificador de la inspección.

[P00563 | 24803:24816 | NORMAL_TEXT | TABLE row=1 col=3]
PK, NOT NULL

[P00564 | 24817:24818 | NORMAL_TEXT | TABLE row=1 col=4]
⟦EMPTY PARAGRAPH⟧

[P00565 | 24820:24831 | NORMAL_TEXT | TABLE row=2 col=0]
IdAlquiler

[P00566 | 24832:24836 | NORMAL_TEXT | TABLE row=2 col=1]
INT

[P00567 | 24837:24861 | NORMAL_TEXT | TABLE row=2 col=2]
Alquiler inspeccionado.

[P00568 | 24862:24875 | NORMAL_TEXT | TABLE row=2 col=3]
FK, NOT NULL

[P00569 | 24876:24885 | NORMAL_TEXT | TABLE row=2 col=4]
Alquiler

[P00570 | 24887:24892 | NORMAL_TEXT | TABLE row=3 col=0]
Tipo

[P00571 | 24893:24905 | NORMAL_TEXT | TABLE row=3 col=1]
VARCHAR(20)

[P00572 | 24906:24948 | NORMAL_TEXT | TABLE row=3 col=2]
Tipo de inspección: entrega o devolución.

[P00573 | 24949:24958 | NORMAL_TEXT | TABLE row=3 col=3]
NOT NULL

[P00574 | 24959:24960 | NORMAL_TEXT | TABLE row=3 col=4]
⟦EMPTY PARAGRAPH⟧

[P00575 | 24962:24968 | NORMAL_TEXT | TABLE row=4 col=0]
Fecha

[P00576 | 24969:24974 | NORMAL_TEXT | TABLE row=4 col=1]
DATE

[P00577 | 24975:24999 | NORMAL_TEXT | TABLE row=4 col=2]
Fecha de la inspección.

[P00578 | 25000:25009 | NORMAL_TEXT | TABLE row=4 col=3]
NOT NULL

[P00579 | 25010:25011 | NORMAL_TEXT | TABLE row=4 col=4]
⟦EMPTY PARAGRAPH⟧

[P00580 | 25013:25025 | NORMAL_TEXT | TABLE row=5 col=0]
Kilometraje

[P00581 | 25026:25040 | NORMAL_TEXT | TABLE row=5 col=1]
NUMERIC(10,2)

[P00582 | 25041:25064 | NORMAL_TEXT | TABLE row=5 col=2]
Kilometraje observado.

[P00583 | 25065:25074 | NORMAL_TEXT | TABLE row=5 col=3]
NOT NULL

[P00584 | 25075:25076 | NORMAL_TEXT | TABLE row=5 col=4]
⟦EMPTY PARAGRAPH⟧

[P00585 | 25078:25090 | NORMAL_TEXT | TABLE row=6 col=0]
Combustible

[P00586 | 25091:25103 | NORMAL_TEXT | TABLE row=6 col=1]
VARCHAR(20)

[P00587 | 25104:25137 | NORMAL_TEXT | TABLE row=6 col=2]
Nivel de combustible registrado.

[P00588 | 25138:25147 | NORMAL_TEXT | TABLE row=6 col=3]
NOT NULL

[P00589 | 25148:25149 | NORMAL_TEXT | TABLE row=6 col=4]
⟦EMPTY PARAGRAPH⟧

[P00590 | 25151:25165 | NORMAL_TEXT | TABLE row=7 col=0]
Observaciones

[P00591 | 25166:25179 | NORMAL_TEXT | TABLE row=7 col=1]
VARCHAR(300)

[P00592 | 25180:25223 | NORMAL_TEXT | TABLE row=7 col=2]
Estado, daños u observaciones encontradas.

[P00593 | 25224:25233 | NORMAL_TEXT | TABLE row=7 col=3]
NOT NULL

[P00594 | 25234:25235 | NORMAL_TEXT | TABLE row=7 col=4]
⟦EMPTY PARAGRAPH⟧

[P00595 | 25236:25237 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00596 | 25237:25249 | NORMAL_TEXT]
Tabla: Pago

[P00597 | 25252:25258 | NORMAL_TEXT | TABLE row=0 col=0]
Campo

[P00598 | 25259:25272 | NORMAL_TEXT | TABLE row=0 col=1]
Tipo de dato

[P00599 | 25273:25285 | NORMAL_TEXT | TABLE row=0 col=2]
Descripción

[P00600 | 25286:25298 | NORMAL_TEXT | TABLE row=0 col=3]
Restricción

[P00601 | 25299:25308 | NORMAL_TEXT | TABLE row=0 col=4]
Relación

[P00602 | 25310:25317 | NORMAL_TEXT | TABLE row=1 col=0]
IdPago

[P00603 | 25318:25322 | NORMAL_TEXT | TABLE row=1 col=1]
INT

[P00604 | 25323:25347 | NORMAL_TEXT | TABLE row=1 col=2]
Identificador del pago.

[P00605 | 25348:25361 | NORMAL_TEXT | TABLE row=1 col=3]
PK, NOT NULL

[P00606 | 25362:25363 | NORMAL_TEXT | TABLE row=1 col=4]
⟦EMPTY PARAGRAPH⟧

[P00607 | 25365:25376 | NORMAL_TEXT | TABLE row=2 col=0]
IdAlquiler

[P00608 | 25377:25381 | NORMAL_TEXT | TABLE row=2 col=1]
INT

[P00609 | 25382:25409 | NORMAL_TEXT | TABLE row=2 col=2]
Alquiler asociado al pago.

[P00610 | 25410:25423 | NORMAL_TEXT | TABLE row=2 col=3]
FK, NOT NULL

[P00611 | 25424:25433 | NORMAL_TEXT | TABLE row=2 col=4]
Alquiler

[P00612 | 25435:25445 | NORMAL_TEXT | TABLE row=3 col=0]
FechaPago

[P00613 | 25446:25451 | NORMAL_TEXT | TABLE row=3 col=1]
DATE

[P00614 | 25452:25468 | NORMAL_TEXT | TABLE row=3 col=2]
Fecha del pago.

[P00615 | 25469:25478 | NORMAL_TEXT | TABLE row=3 col=3]
NOT NULL

[P00616 | 25479:25480 | NORMAL_TEXT | TABLE row=3 col=4]
⟦EMPTY PARAGRAPH⟧

[P00617 | 25482:25488 | NORMAL_TEXT | TABLE row=4 col=0]
Monto

[P00618 | 25489:25503 | NORMAL_TEXT | TABLE row=4 col=1]
NUMERIC(10,2)

[P00619 | 25504:25521 | NORMAL_TEXT | TABLE row=4 col=2]
Cantidad pagada.

[P00620 | 25522:25531 | NORMAL_TEXT | TABLE row=4 col=3]
NOT NULL

[P00621 | 25532:25533 | NORMAL_TEXT | TABLE row=4 col=4]
⟦EMPTY PARAGRAPH⟧

[P00622 | 25535:25546 | NORMAL_TEXT | TABLE row=5 col=0]
MetodoPago

[P00623 | 25547:25559 | NORMAL_TEXT | TABLE row=5 col=1]
VARCHAR(30)

[P00624 | 25560:25600 | NORMAL_TEXT | TABLE row=5 col=2]
Método utilizado para realizar el pago.

[P00625 | 25601:25610 | NORMAL_TEXT | TABLE row=5 col=3]
NOT NULL

[P00626 | 25611:25612 | NORMAL_TEXT | TABLE row=5 col=4]
⟦EMPTY PARAGRAPH⟧

[P00627 | 25614:25626 | NORMAL_TEXT | TABLE row=6 col=0]
Referencia 

[P00628 | 25627:25641 | NORMAL_TEXT | TABLE row=6 col=1]
VARCHAR(100) 

[P00629 | 25642:25671 | NORMAL_TEXT | TABLE row=6 col=2]
Código o referencia de pago 

[P00630 | 25672:25682 | NORMAL_TEXT | TABLE row=6 col=3]
NOT NULL 

[P00631 | 25683:25684 | NORMAL_TEXT | TABLE row=6 col=4]
⟦EMPTY PARAGRAPH⟧

[P00632 | 25686:25693 | NORMAL_TEXT | TABLE row=7 col=0]
Estado

[P00633 | 25694:25706 | NORMAL_TEXT | TABLE row=7 col=1]
VARCHAR(20)

[P00634 | 25707:25724 | NORMAL_TEXT | TABLE row=7 col=2]
Estado del pago.

[P00635 | 25725:25734 | NORMAL_TEXT | TABLE row=7 col=3]
NOT NULL

[P00636 | 25735:25736 | NORMAL_TEXT | TABLE row=7 col=4]
⟦EMPTY PARAGRAPH⟧

[P00637 | 25737:25738 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00638 | 25738:25760 | NORMAL_TEXT]
Tabla: CargoAdicional

[P00639 | 25763:25769 | NORMAL_TEXT | TABLE row=0 col=0]
Campo

[P00640 | 25770:25783 | NORMAL_TEXT | TABLE row=0 col=1]
Tipo de dato

[P00641 | 25784:25796 | NORMAL_TEXT | TABLE row=0 col=2]
Descripción

[P00642 | 25797:25809 | NORMAL_TEXT | TABLE row=0 col=3]
Restricción

[P00643 | 25810:25819 | NORMAL_TEXT | TABLE row=0 col=4]
Relación

[P00644 | 25821:25829 | NORMAL_TEXT | TABLE row=1 col=0]
IdCargo

[P00645 | 25830:25834 | NORMAL_TEXT | TABLE row=1 col=1]
INT

[P00646 | 25835:25870 | NORMAL_TEXT | TABLE row=1 col=2]
Identificador del cargo adicional.

[P00647 | 25871:25884 | NORMAL_TEXT | TABLE row=1 col=3]
PK, NOT NULL

[P00648 | 25885:25886 | NORMAL_TEXT | TABLE row=1 col=4]
⟦EMPTY PARAGRAPH⟧

[P00649 | 25888:25899 | NORMAL_TEXT | TABLE row=2 col=0]
IdAlquiler

[P00650 | 25900:25904 | NORMAL_TEXT | TABLE row=2 col=1]
INT

[P00651 | 25905:25941 | NORMAL_TEXT | TABLE row=2 col=2]
Alquiler al que pertenece el cargo.

[P00652 | 25942:25955 | NORMAL_TEXT | TABLE row=2 col=3]
FK, NOT NULL

[P00653 | 25956:25965 | NORMAL_TEXT | TABLE row=2 col=4]
Alquiler

[P00654 | 25967:25976 | NORMAL_TEXT | TABLE row=3 col=0]
Concepto

[P00655 | 25977:25990 | NORMAL_TEXT | TABLE row=3 col=1]
VARCHAR(100)

[P00656 | 25991:26019 | NORMAL_TEXT | TABLE row=3 col=2]
Motivo del cargo adicional.

[P00657 | 26020:26029 | NORMAL_TEXT | TABLE row=3 col=3]
NOT NULL

[P00658 | 26030:26031 | NORMAL_TEXT | TABLE row=3 col=4]
⟦EMPTY PARAGRAPH⟧

[P00659 | 26033:26045 | NORMAL_TEXT | TABLE row=4 col=0]
Descripcion

[P00660 | 26046:26059 | NORMAL_TEXT | TABLE row=4 col=1]
VARCHAR(200)

[P00661 | 26060:26079 | NORMAL_TEXT | TABLE row=4 col=2]
Detalle del cargo.

[P00662 | 26080:26089 | NORMAL_TEXT | TABLE row=4 col=3]
NOT NULL

[P00663 | 26090:26091 | NORMAL_TEXT | TABLE row=4 col=4]
⟦EMPTY PARAGRAPH⟧

[P00664 | 26093:26099 | NORMAL_TEXT | TABLE row=5 col=0]
Monto

[P00665 | 26100:26114 | NORMAL_TEXT | TABLE row=5 col=1]
NUMERIC(10,2)

[P00666 | 26115:26142 | NORMAL_TEXT | TABLE row=5 col=2]
Valor del cargo adicional.

[P00667 | 26143:26152 | NORMAL_TEXT | TABLE row=5 col=3]
NOT NULL

[P00668 | 26153:26154 | NORMAL_TEXT | TABLE row=5 col=4]
⟦EMPTY PARAGRAPH⟧

[P00669 | 26156:26162 | NORMAL_TEXT | TABLE row=6 col=0]
Fecha

[P00670 | 26163:26168 | NORMAL_TEXT | TABLE row=6 col=1]
DATE

[P00671 | 26169:26198 | NORMAL_TEXT | TABLE row=6 col=2]
Fecha de registro del cargo.

[P00672 | 26199:26208 | NORMAL_TEXT | TABLE row=6 col=3]
NOT NULL

[P00673 | 26209:26210 | NORMAL_TEXT | TABLE row=6 col=4]
⟦EMPTY PARAGRAPH⟧

[P00674 | 26211:26212 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00675 | 26212:26213 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00676 | 26213:26214 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00677 | 26214:26215 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00678 | 26215:26216 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00679 | 26216:26217 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00680 | 26217:26238 | NORMAL_TEXT]
Tabla: Mantenimiento

[P00681 | 26241:26247 | NORMAL_TEXT | TABLE row=0 col=0]
Campo

[P00682 | 26248:26261 | NORMAL_TEXT | TABLE row=0 col=1]
Tipo de dato

[P00683 | 26262:26274 | NORMAL_TEXT | TABLE row=0 col=2]
Descripción

[P00684 | 26275:26287 | NORMAL_TEXT | TABLE row=0 col=3]
Restricción

[P00685 | 26288:26297 | NORMAL_TEXT | TABLE row=0 col=4]
Relación

[P00686 | 26299:26315 | NORMAL_TEXT | TABLE row=1 col=0]
IdMantenimiento

[P00687 | 26316:26320 | NORMAL_TEXT | TABLE row=1 col=1]
INT

[P00688 | 26321:26354 | NORMAL_TEXT | TABLE row=1 col=2]
Identificador del mantenimiento.

[P00689 | 26355:26368 | NORMAL_TEXT | TABLE row=1 col=3]
PK, NOT NULL

[P00690 | 26369:26370 | NORMAL_TEXT | TABLE row=1 col=4]
⟦EMPTY PARAGRAPH⟧

[P00691 | 26372:26383 | NORMAL_TEXT | TABLE row=2 col=0]
IdVehiculo

[P00692 | 26384:26388 | NORMAL_TEXT | TABLE row=2 col=1]
INT

[P00693 | 26389:26424 | NORMAL_TEXT | TABLE row=2 col=2]
Vehículo que recibe mantenimiento.

[P00694 | 26425:26438 | NORMAL_TEXT | TABLE row=2 col=3]
FK, NOT NULL

[P00695 | 26439:26448 | NORMAL_TEXT | TABLE row=2 col=4]
Vehiculo

[P00696 | 26450:26455 | NORMAL_TEXT | TABLE row=3 col=0]
Tipo

[P00697 | 26456:26468 | NORMAL_TEXT | TABLE row=3 col=1]
VARCHAR(30)

[P00698 | 26469:26517 | NORMAL_TEXT | TABLE row=3 col=2]
Tipo de mantenimiento: preventivo o correctivo.

[P00699 | 26518:26527 | NORMAL_TEXT | TABLE row=3 col=3]
NOT NULL

[P00700 | 26528:26529 | NORMAL_TEXT | TABLE row=3 col=4]
⟦EMPTY PARAGRAPH⟧

[P00701 | 26531:26543 | NORMAL_TEXT | TABLE row=4 col=0]
FechaInicio

[P00702 | 26544:26549 | NORMAL_TEXT | TABLE row=4 col=1]
DATE

[P00703 | 26550:26585 | NORMAL_TEXT | TABLE row=4 col=2]
Fecha de inicio del mantenimiento.

[P00704 | 26586:26595 | NORMAL_TEXT | TABLE row=4 col=3]
NOT NULL

[P00705 | 26596:26597 | NORMAL_TEXT | TABLE row=4 col=4]
⟦EMPTY PARAGRAPH⟧

[P00706 | 26599:26608 | NORMAL_TEXT | TABLE row=5 col=0]
FechaFin

[P00707 | 26609:26614 | NORMAL_TEXT | TABLE row=5 col=1]
DATE

[P00708 | 26615:26656 | NORMAL_TEXT | TABLE row=5 col=2]
Fecha de finalización del mantenimiento.

[P00709 | 26657:26666 | NORMAL_TEXT | TABLE row=5 col=3]
NOT NULL

[P00710 | 26667:26668 | NORMAL_TEXT | TABLE row=5 col=4]
⟦EMPTY PARAGRAPH⟧

[P00711 | 26670:26676 | NORMAL_TEXT | TABLE row=6 col=0]
Costo

[P00712 | 26677:26691 | NORMAL_TEXT | TABLE row=6 col=1]
NUMERIC(10,2)

[P00713 | 26692:26717 | NORMAL_TEXT | TABLE row=6 col=2]
Costo del mantenimiento.

[P00714 | 26718:26727 | NORMAL_TEXT | TABLE row=6 col=3]
NOT NULL

[P00715 | 26728:26729 | NORMAL_TEXT | TABLE row=6 col=4]
⟦EMPTY PARAGRAPH⟧

[P00716 | 26731:26743 | NORMAL_TEXT | TABLE row=7 col=0]
Descripcion

[P00717 | 26744:26757 | NORMAL_TEXT | TABLE row=7 col=1]
VARCHAR(300)

[P00718 | 26758:26793 | NORMAL_TEXT | TABLE row=7 col=2]
Descripción del trabajo realizado.

[P00719 | 26794:26803 | NORMAL_TEXT | TABLE row=7 col=3]
NOT NULL

[P00720 | 26804:26805 | NORMAL_TEXT | TABLE row=7 col=4]
⟦EMPTY PARAGRAPH⟧

[P00721 | 26807:26814 | NORMAL_TEXT | TABLE row=8 col=0]
Estado

[P00722 | 26815:26827 | NORMAL_TEXT | TABLE row=8 col=1]
VARCHAR(20)

[P00723 | 26828:26854 | NORMAL_TEXT | TABLE row=8 col=2]
Estado del mantenimiento.

[P00724 | 26855:26864 | NORMAL_TEXT | TABLE row=8 col=3]
NOT NULL

[P00725 | 26865:26866 | NORMAL_TEXT | TABLE row=8 col=4]
⟦EMPTY PARAGRAPH⟧

[P00726 | 26867:26868 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00727 | 26868:26889 | NORMAL_TEXT]
Tabla: Recomendación

[P00728 | 26892:26898 | NORMAL_TEXT | TABLE row=0 col=0]
Campo

[P00729 | 26899:26912 | NORMAL_TEXT | TABLE row=0 col=1]
Tipo de dato

[P00730 | 26913:26925 | NORMAL_TEXT | TABLE row=0 col=2]
Descripción

[P00731 | 26926:26938 | NORMAL_TEXT | TABLE row=0 col=3]
Restricción

[P00732 | 26939:26948 | NORMAL_TEXT | TABLE row=0 col=4]
Relación

[P00733 | 26950:26966 | NORMAL_TEXT | TABLE row=1 col=0]
IdRecomendacion

[P00734 | 26967:26971 | NORMAL_TEXT | TABLE row=1 col=1]
INT

[P00735 | 26972:27007 | NORMAL_TEXT | TABLE row=1 col=2]
Identificador de la recomendación.

[P00736 | 27008:27021 | NORMAL_TEXT | TABLE row=1 col=3]
PK, NOT NULL

[P00737 | 27022:27023 | NORMAL_TEXT | TABLE row=1 col=4]
⟦EMPTY PARAGRAPH⟧

[P00738 | 27025:27035 | NORMAL_TEXT | TABLE row=2 col=0]
IdCliente

[P00739 | 27036:27040 | NORMAL_TEXT | TABLE row=2 col=1]
INT

[P00740 | 27041:27080 | NORMAL_TEXT | TABLE row=2 col=2]
Cliente que solicita la recomendación.

[P00741 | 27081:27094 | NORMAL_TEXT | TABLE row=2 col=3]
FK, NOT NULL

[P00742 | 27095:27103 | NORMAL_TEXT | TABLE row=2 col=4]
Cliente

[P00743 | 27105:27116 | NORMAL_TEXT | TABLE row=3 col=0]
IdVehiculo

[P00744 | 27117:27121 | NORMAL_TEXT | TABLE row=3 col=1]
INT

[P00745 | 27122:27144 | NORMAL_TEXT | TABLE row=3 col=2]
Vehículo recomendado.

[P00746 | 27145:27158 | NORMAL_TEXT | TABLE row=3 col=3]
FK, NOT NULL

[P00747 | 27159:27168 | NORMAL_TEXT | TABLE row=3 col=4]
Vehiculo

[P00748 | 27170:27176 | NORMAL_TEXT | TABLE row=4 col=0]
Fecha

[P00749 | 27177:27182 | NORMAL_TEXT | TABLE row=4 col=1]
DATE

[P00750 | 27183:27224 | NORMAL_TEXT | TABLE row=4 col=2]
Fecha de generación de la recomendación.

[P00751 | 27225:27234 | NORMAL_TEXT | TABLE row=4 col=3]
NOT NULL

[P00752 | 27235:27236 | NORMAL_TEXT | TABLE row=4 col=4]
⟦EMPTY PARAGRAPH⟧

[P00753 | 27238:27248 | NORMAL_TEXT | TABLE row=5 col=0]
Pasajeros

[P00754 | 27249:27253 | NORMAL_TEXT | TABLE row=5 col=1]
INT

[P00755 | 27254:27286 | NORMAL_TEXT | TABLE row=5 col=2]
Cantidad de pasajeros indicada.

[P00756 | 27287:27296 | NORMAL_TEXT | TABLE row=5 col=3]
NOT NULL

[P00757 | 27297:27298 | NORMAL_TEXT | TABLE row=5 col=4]
⟦EMPTY PARAGRAPH⟧

[P00758 | 27300:27312 | NORMAL_TEXT | TABLE row=6 col=0]
Presupuesto

[P00759 | 27313:27327 | NORMAL_TEXT | TABLE row=6 col=1]
NUMERIC(10,2)

[P00760 | 27328:27365 | NORMAL_TEXT | TABLE row=6 col=2]
Presupuesto indicado por el cliente.

[P00761 | 27366:27375 | NORMAL_TEXT | TABLE row=6 col=3]
NOT NULL

[P00762 | 27376:27377 | NORMAL_TEXT | TABLE row=6 col=4]
⟦EMPTY PARAGRAPH⟧

[P00763 | 27379:27389 | NORMAL_TEXT | TABLE row=7 col=0]
Criterios

[P00764 | 27390:27403 | NORMAL_TEXT | TABLE row=7 col=1]
VARCHAR(300)

[P00765 | 27404:27450 | NORMAL_TEXT | TABLE row=7 col=2]
Criterios considerados para la recomendación.

[P00766 | 27451:27460 | NORMAL_TEXT | TABLE row=7 col=3]
NOT NULL

[P00767 | 27461:27462 | NORMAL_TEXT | TABLE row=7 col=4]
⟦EMPTY PARAGRAPH⟧

[P00768 | 27463:27464 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00769 | 27464:27465 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00770 | 27465:27466 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00771 | 27466:27467 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00772 | 27467:27468 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00773 | 27468:27469 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00774 | 27469:27470 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00775 | 27470:27471 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00776 | 27471:27472 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00777 | 27472:27473 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00778 | 27473:27474 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00779 | 27474:27475 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00780 | 27475:27476 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00781 | 27476:27477 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00782 | 27477:27478 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00783 | 27478:27479 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00784 | 27479:27480 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00785 | 27480:27481 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00786 | 27481:27482 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00787 | 27482:27483 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00788 | 27483:27484 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00789 | 27484:27485 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00790 | 27485:27486 | NORMAL_TEXT]
⟦EMPTY PARAGRAPH⟧

[P00791 | 27486:27508 | NORMAL_TEXT]
6. Plan de desarrollo

[P00792 | 27508:27538 | HEADING_2]
6.1 Recolección de requisitos

[P00793 | 27538:27760 | NORMAL_TEXT]
La recolección combinará evidencia documental y trabajo de campo. El objetivo es validar las hipótesis del problema, identificar variantes del proceso y priorizar funciones que una agencia pequeña realmente pueda adoptar.

[P00794 | 27760:27780 | HEADING_3]
Técnicas propuestas

[P00795 | 27780:27914 | NORMAL_TEXT | LIST id=kix.wv8mi6tsnjjw level=0]
Entrevistas semiestructuradas con al menos tres propietarios o administradores de agencias y dos empleados de atención u operaciones.

[P00796 | 27914:28059 | NORMAL_TEXT | LIST id=kix.wv8mi6tsnjjw level=0]
Encuesta breve a por lo menos quince clientes potenciales para conocer criterios de elección, canales utilizados y expectativas de confirmación.

[P00797 | 28059:28170 | NORMAL_TEXT | LIST id=kix.wv8mi6tsnjjw level=0]
Observación, con autorización, del proceso de consulta, reserva, entrega y devolución en al menos una agencia.

[P00798 | 28170:28284 | NORMAL_TEXT | LIST id=kix.wv8mi6tsnjjw level=0]
Revisión de formularios, contratos, hojas de cálculo o registros anonimizados que la empresa utiliza actualmente.

[P00799 | 28284:28386 | NORMAL_TEXT | LIST id=kix.wv8mi6tsnjjw level=0]
Taller How Might We con el equipo para convertir hallazgos en oportunidades de diseño y priorizarlas.

[P00800 | 28386:28413 | HEADING_3]
Pregunta guía How Might We

[P00801 | 28413:28641 | NORMAL_TEXT]
¿Cómo podríamos ayudar a una pequeña agencia salvadoreña de renta de vehículos a conocer su disponibilidad real, coordinar reservas y mantener trazabilidad de cada alquiler sin aumentar innecesariamente la carga administrativa?

[P00802 | 28641:28683 | HEADING_3]
Tratamiento de la información recolectada

[P00803 | 28683:29028 | NORMAL_TEXT]
Se solicitará consentimiento para participar, se evitará recopilar datos personales innecesarios y los ejemplos serán anonimizados. Los hallazgos se organizan por usuario, tarea, problema, frecuencia e impacto. Después se construirán historias de usuario y criterios de aceptación; cualquier necesidad no validada quedará marcada como supuesto.

[P00804 | 29028:29064 | HEADING_3]
Requisitos funcionales preliminares

[P00805 | 29064:29141 | NORMAL_TEXT | LIST id=kix.bxjeqlr1slvr level=0]
RF-01. Autenticar usuarios y aplicar permisos para administrador y empleado.

[P00806 | 29141:29200 | NORMAL_TEXT | LIST id=kix.bxjeqlr1slvr level=0]
RF-02. Crear, consultar, actualizar y desactivar clientes.

[P00807 | 29200:29283 | NORMAL_TEXT | LIST id=kix.bxjeqlr1slvr level=0]
RF-03. Administrar categorías, tarifas, vehículos, fotografías y estados de flota.

[P00808 | 29283:29369 | NORMAL_TEXT | LIST id=kix.bxjeqlr1slvr level=0]
RF-04. Consultar disponibilidad por rango de fechas, categoría, capacidad y sucursal.

[P00809 | 29369:29455 | NORMAL_TEXT | LIST id=kix.bxjeqlr1slvr level=0]
RF-05. Crear, modificar y cancelar reservas sin permitir superposiciones confirmadas.

[P00810 | 29455:29554 | NORMAL_TEXT | LIST id=kix.bxjeqlr1slvr level=0]
RF-06. Convertir una reserva en alquiler y registrar contrato, entrega, kilometraje y combustible.

[P00811 | 29554:29644 | NORMAL_TEXT | LIST id=kix.bxjeqlr1slvr level=0]
RF-07. Registrar devolución, inspección, retrasos, daños informados y cargos adicionales.

[P00812 | 29644:29731 | NORMAL_TEXT | LIST id=kix.bxjeqlr1slvr level=0]
RF-08. Programar mantenimiento y retirar temporalmente vehículos de la disponibilidad.

[P00813 | 29731:29829 | NORMAL_TEXT | LIST id=kix.bxjeqlr1slvr level=0]
RF-09. Emitir confirmaciones y avisos mediante correo cuando el alcance del prototipo lo permita.

[P00814 | 29829:29913 | NORMAL_TEXT | LIST id=kix.bxjeqlr1slvr level=0]
RF-10. Generar reportes básicos de utilización, ingresos, reservas y mantenimiento.

[P00815 | 29913:30004 | NORMAL_TEXT | LIST id=kix.bxjeqlr1slvr level=0]
RF-11. Recomendar vehículos disponibles mediante IA y explicar los criterios de selección.

[P00816 | 30004:30074 | NORMAL_TEXT | LIST id=kix.bxjeqlr1slvr level=0]
RF-12. Conservar un registro de auditoría para operaciones sensibles.

[P00817 | 30074:30113 | HEADING_3]
Requisitos no funcionales preliminares

[P00818 | 30113:30202 | NORMAL_TEXT | LIST id=kix.c0vmu3su3kb5 level=0]
RNF-01. Proteger todas las rutas privadas mediante autenticación y autorización por rol.

[P00819 | 30202:30336 | NORMAL_TEXT | LIST id=kix.c0vmu3su3kb5 level=0]
RNF-02. Aplicar minimización, acceso restringido y tratamiento informado de datos personales conforme a la normativa salvadoreña [\[4\]](https://www.asamblea.gob.sv/sites/default/files/documents/decretos/17458CF0-AB9B-482A-85A1-03834D5D89B7.pdf).

[P00820 | 30336:30492 | NORMAL_TEXT | LIST id=kix.c0vmu3su3kb5 level=0]
RNF-03. Responder las consultas habituales en un objetivo inicial de hasta tres segundos bajo la carga del piloto; el valor será validado mediante pruebas.

[P00821 | 30492:30563 | NORMAL_TEXT | LIST id=kix.c0vmu3su3kb5 level=0]
RNF-04. Mantener respaldos y un procedimiento probado de restauración.

[P00822 | 30563:30658 | NORMAL_TEXT | LIST id=kix.c0vmu3su3kb5 level=0]
RNF-05. Ofrecer interfaz responsive, navegación consistente y mensajes de error comprensibles.

[P00823 | 30658:30761 | NORMAL_TEXT | LIST id=kix.c0vmu3su3kb5 level=0]
RNF-06. Mantener arquitectura en capas, convenciones de código, documentación y pruebas automatizadas.

[P00824 | 30761:30830 | NORMAL_TEXT | LIST id=kix.c0vmu3su3kb5 level=0]
RNF-07. Ejecuta de manera reproducible mediante contenedores Docker.

[P00825 | 30830:30951 | NORMAL_TEXT | LIST id=kix.c0vmu3su3kb5 level=0]
RNF-08. Registrar errores, eventos críticos y consumo del servicio de IA sin almacenar información sensible innecesaria.

[P00826 | 30951:30964 | HEADING_3]
Priorización

[P00827 | 30964:31305 | NORMAL_TEXT]
Los requisitos se priorizará con MoSCoW. Serán imprescindibles la autenticación, flota, clientes, disponibilidad, reservas, alquileres, devoluciones, mantenimiento básico y prototipo de IA. Las notificaciones avanzadas, pagos en línea, analítica predictiva y funciones móviles quedarán condicionadas al tiempo y a la validación del usuario.

[P00828 | 31305:31338 | HEADING_2]
6.2 Plan del prototipo funcional

[P00829 | 31338:31616 | NORMAL_TEXT]
El prototipo de la Fase II seguirá un desarrollo incremental. Primero se valorarán los flujos en prototipos UX/UI; después se implementará una ruta completa desde la consulta de disponibilidad hasta la devolución. Cada incremento deberá quedar integrado, probado y demostrable.

[P00830 | 31616:31644 | HEADING_3]
Incremento 1 - Base técnica

[P00831 | 31644:31810 | NORMAL_TEXT]
Crear la solución ASP.NET Core, repositorio, arquitectura en capas, proyecto de pruebas, configuración de PostgreSQL, migración inicial y contenedores de desarrollo.

[P00832 | 31810:31849 | HEADING_3]
Incremento 2 - Administración de flota

[P00833 | 31849:31945 | NORMAL_TEXT]
Implementar autenticación, roles, CRUD de categorías, vehículos, clientes y estados operativos.

[P00834 | 31945:31982 | HEADING_3]
Incremento 3 - Reservas y alquileres

[P00835 | 31982:32088 | NORMAL_TEXT]
Implementar consulta por fechas, prevención de superposiciones, reservas, entrega y contrato de alquiler.

[P00836 | 32088:32132 | HEADING_3]
Incremento 4 - Devoluciones y mantenimiento

[P00837 | 32132:32248 | NORMAL_TEXT]
Registrar inspección de devolución, kilometraje, combustible, cargos y mantenimiento con bloqueo de disponibilidad.

[P00838 | 32248:32289 | HEADING_3]
Incremento 5 - IA, reportes y despliegue

[P00839 | 32289:32452 | NORMAL_TEXT]
Integrar el recomendador con candidatos previamente filtrados, crear reportes básicos, completar pruebas, generar la imagen Docker y desplegar un piloto en Azure.

[P00840 | 32452:32474 | HEADING_3]
Criterio de terminado

[P00841 | 32474:32719 | NORMAL_TEXT]
Una historia se considerará terminada cuando cumpla sus criterios de aceptación, tenga validaciones y autorización, incluya pruebas proporcionales al riesgo, esté revisada mediante control de versiones y funcione en el ambiente contenedorizado.

[P00842 | 32719:32758 | HEADING_2]
6.3 Alcance esperado del primer avance

[P00843 | 32758:32831 | NORMAL_TEXT | LIST id=kix.nhac3qws8gl level=0]
Estructura inicial de la solución ASP.NET Core y repositorio compartido.

[P00844 | 32831:32907 | NORMAL_TEXT | LIST id=kix.nhac3qws8gl level=0]
Arquitectura en capas definida con dependencias permitidas entre proyectos.

[P00845 | 32907:32979 | NORMAL_TEXT | LIST id=kix.nhac3qws8gl level=0]
Modelo de base de datos, diagrama entidad-relación y migración inicial.

[P00846 | 32979:33029 | NORMAL_TEXT | LIST id=kix.nhac3qws8gl level=0]
Entity Framework Core configurado con PostgreSQL.

[P00847 | 33029:33087 | NORMAL_TEXT | LIST id=kix.nhac3qws8gl level=0]
Autenticación básica y roles de administrador y empleado.

[P00848 | 33087:33139 | NORMAL_TEXT | LIST id=kix.nhac3qws8gl level=0]
CRUD principal de vehículos, categorías y clientes.

[P00849 | 33139:33198 | NORMAL_TEXT | LIST id=kix.nhac3qws8gl level=0]
Navegación básica entre panel, flota, clientes y reservas.

[P00850 | 33198:33254 | NORMAL_TEXT | LIST id=kix.nhac3qws8gl level=0]
Prototipos UX/UI validados para los flujos principales.

[P00851 | 33254:33330 | NORMAL_TEXT | LIST id=kix.nhac3qws8gl level=0]
Consulta preliminar de disponibilidad y regla contra reservas superpuestas.

[P00852 | 33330:33441 | NORMAL_TEXT | LIST id=kix.nhac3qws8gl level=0]
Diseño preliminar de la función de IA, contrato de entrada y salida, casos de prueba y estrategia de respaldo.

[P00853 | 33441:33502 | NORMAL_TEXT | LIST id=kix.nhac3qws8gl level=0]
Configuración inicial de Docker para reproducir el ambiente.

[P00854 | 33502:33518 | HEADING_2]
6.4 Entregables

[P00855 | 33518:33621 | NORMAL_TEXT | LIST id=kix.voukupvgias level=0]
Documento del proyecto con planteamiento, factibilidad, arquitectura, plan, resultados y bibliografía.

[P00856 | 33621:33667 | NORMAL_TEXT | LIST id=kix.voukupvgias level=0]
Diagramas de bloques, UML y entidad-relación.

[P00857 | 33667:33712 | NORMAL_TEXT | LIST id=kix.voukupvgias level=0]
Diccionario de datos y reglas de integridad.

[P00858 | 33712:33756 | NORMAL_TEXT | LIST id=kix.voukupvgias level=0]
Prototipos UX/UI y evidencia de validación.

[P00859 | 33756:33839 | NORMAL_TEXT | LIST id=kix.voukupvgias level=0]
Modelo Canvas y presupuesto, desarrollados por los responsables de esas secciones.

[P00860 | 33839:33921 | NORMAL_TEXT | LIST id=kix.voukupvgias level=0]
Repositorio con código fuente, historial de cambios e instrucciones de ejecución.

[P00861 | 33921:33991 | NORMAL_TEXT | LIST id=kix.voukupvgias level=0]
Aplicación contenedorizada, pruebas y evidencia de despliegue piloto.

[P00862 | 33991:34040 | NORMAL_TEXT | LIST id=kix.voukupvgias level=0]
Manual breve de usuario y documentación técnica.

[P00863 | 34040:34070 | NORMAL_TEXT | LIST id=kix.voukupvgias level=0]
Presentación para exposición.

[P00864 | 34070:34111 | HEADING_3]
Cronograma de referencia para la Fase II

[P00865 | 34111:34190 | NORMAL_TEXT | LIST id=kix.a8cansqqa1rj level=0]
Semanas 1 y 2: validar requisitos, prototipos, modelo de datos y arquitectura.

[P00866 | 34190:34274 | NORMAL_TEXT | LIST id=kix.a8cansqqa1rj level=0]
Semana 3: preparar solución, seguridad, Entity Framework Core, PostgreSQL y Docker.

[P00867 | 34274:34348 | NORMAL_TEXT | LIST id=kix.a8cansqqa1rj level=0]
Semana 4: Implementar clientes, categorías, vehículos y estados de flota.

[P00868 | 34348:34409 | NORMAL_TEXT | LIST id=kix.a8cansqqa1rj level=0]
Semana 5: implementar disponibilidad, reservas y alquileres.

[P00869 | 34409:34488 | NORMAL_TEXT | LIST id=kix.a8cansqqa1rj level=0]
Semana 6: implementar devoluciones, mantenimiento y primera integración de IA.

[P00870 | 34488:34562 | NORMAL_TEXT | LIST id=kix.a8cansqqa1rj level=0]
Semana 7: Integrar reportes, pruebas, correcciones y despliegue en Azure.

[P00871 | 34562:34641 | NORMAL_TEXT | LIST id=kix.a8cansqqa1rj level=0]
Semana 8: validar con usuarios, cerrar documentación y preparar la exposición.

[P00872 | 34641:34776 | NORMAL_TEXT]
Este cronograma es una propuesta relativa y deberá ajustarse a las fechas oficiales de la asignatura y a la disponibilidad del equipo.

[P00873 | 34776:34815 | HEADING_1]
7. Resultados esperados y conclusiones

[P00874 | 34815:34840 | HEADING_2]
7.1 Resultados esperados

[P00875 | 34840:35094 | NORMAL_TEXT]
Se espera obtener una aplicación funcional que permita a una agencia pequeña administrar su operación principal desde un único sistema. Los resultados son metas del proyecto y deberán comprobarse durante la Fase II; no representan beneficios ya medidos.

[P00876 | 35094:35126 | HEADING_3]
Resultados operativos esperados

[P00877 | 35126:35207 | NORMAL_TEXT | LIST id=kix.fchhv6kdrwc6 level=0]
Disponibilidad centralizada y actualizada para reducir conflictos de asignación.

[P00878 | 35207:35294 | NORMAL_TEXT | LIST id=kix.fchhv6kdrwc6 level=0]
Trazabilidad de cada vehículo desde la reserva hasta la devolución y el mantenimiento.

[P00879 | 35294:35382 | NORMAL_TEXT | LIST id=kix.fchhv6kdrwc6 level=0]
Menor tiempo de búsqueda de información respecto de la línea base que se mida en campo.

[P00880 | 35382:35447 | NORMAL_TEXT | LIST id=kix.fchhv6kdrwc6 level=0]
Registro uniforme de clientes, contratos, inspecciones y cargos.

[P00881 | 35447:35534 | NORMAL_TEXT | LIST id=kix.fchhv6kdrwc6 level=0]
Reportes básicos para apoyar decisiones sobre utilización y mantenimiento de la flota.

[P00882 | 35534:35620 | NORMAL_TEXT | LIST id=kix.fchhv6kdrwc6 level=0]
Recomendaciones coherentes con las preferencias y limitadas al inventario disponible.

[P00883 | 35620:35650 | HEADING_3]
Resultados técnicos esperados

[P00884 | 35650:35729 | NORMAL_TEXT | LIST id=kix.y5mbi07g68wm level=0]
Solución ASP.NET Core con arquitectura en capas y responsabilidades separadas.

[P00885 | 35729:35798 | NORMAL_TEXT | LIST id=kix.y5mbi07g68wm level=0]
Persistencia relacional mediante Entity Framework Core y PostgreSQL.

[P00886 | 35798:35855 | NORMAL_TEXT | LIST id=kix.y5mbi07g68wm level=0]
Contenedores reproducibles para desarrollo y despliegue.

[P00887 | 35855:35929 | NORMAL_TEXT | LIST id=kix.y5mbi07g68wm level=0]
Autenticación, autorización, validación, auditoría y protección de datos.

[P00888 | 35929:35982 | NORMAL_TEXT | LIST id=kix.y5mbi07g68wm level=0]
Integración de IA aislada, evaluable y reemplazable.

[P00889 | 35982:36032 | NORMAL_TEXT | LIST id=kix.y5mbi07g68wm level=0]
Despliegue piloto documentado en Microsoft Azure.

[P00890 | 36032:36071 | HEADING_3]
Indicadores propuestos para validación

[P00891 | 36071:36163 | NORMAL_TEXT | LIST id=kix.sxnize4t8g3z level=0]
Cero reservas confirmadas superpuestas para un mismo vehículo en las pruebas de aceptación.

[P00892 | 36163:36246 | NORMAL_TEXT | LIST id=kix.sxnize4t8g3z level=0]
Cien por ciento de los alquileres de prueba con historial de entrega y devolución.

[P00893 | 36246:36406 | NORMAL_TEXT | LIST id=kix.sxnize4t8g3z level=0]
Al menos 80 % de participantes capaces de completar las tareas críticas sin ayuda durante la prueba de usabilidad; la muestra y el umbral deberán documentarse.

[P00894 | 36406:36499 | NORMAL_TEXT | LIST id=kix.sxnize4t8g3z level=0]
Cien por ciento de recomendaciones de prueba limitadas a vehículos disponibles y existentes.

[P00895 | 36499:36609 | NORMAL_TEXT | LIST id=kix.sxnize4t8g3z level=0]
Tiempo de consulta de disponibilidad y tasa de errores comparados con la línea base levantada en una agencia.

[P00896 | 36609:36626 | HEADING_2]
7.2 Conclusiones

[P00897 | 36626:36886 | NORMAL_TEXT]
El sistema de renta de vehículos constituye una propuesta académica realista porque combina gestión de información, automatización de procesos, servicios web, seguridad, base de datos, IA, Docker y despliegue en Azure dentro de un flujo empresarial coherente.

[P00898 | 36886:37246 | NORMAL_TEXT]
El valor principal no reside en crear un catálogo público, sino en ofrecer a pequeñas y medianas agencias una fuente única de información para coordinar la flota. La transformación digital promovida para las MYPE salvadoreñas y el reconocimiento institucional de operadores de transporte y arrendamiento respaldan la pertinencia del contexto elegido [\[2\]](https://www.elsalvador.travel/services/tourist-transportation/es/), [\[3\]](https://www.conamype.gob.sv/blog/2026/07/07/conamype-koica-y-pnud-fortalecen-la-transformacion-digital-de-200-mype-con-canastas-digitales-mype-360/).

[P00899 | 37246:37647 | NORMAL_TEXT]
Los retos más importantes serán validar las reglas reales de operación, mantener consistencia ante reservas concurrentes, proteger datos personales, contener costos de nube y evitar que la IA presente información no autorizada. La arquitectura propuesta mitiga estos riesgos mediante reglas determinísticas, transacciones, control de acceso, separación por capas y validación de las respuestas de IA.

[P00900 | 37647:37994 | NORMAL_TEXT]
Se recomienda iniciar la Fase II con investigación de campo y un flujo vertical pequeño pero completo. Las funciones avanzadas deberán incorporarse solo después de que reservas, alquileres, devoluciones y mantenimiento funcionen de forma confiable. De esta manera, el equipo podrá entregar un prototipo demostrable sin perder control del alcance.

[P00901 | 37994:38010 | HEADING_1]
8. Bibliografía

[P00902 | 38010:38294 | NORMAL_TEXT]
[\[1\]](https://www.conamype.gob.sv/blog/2026/06/25/conamype-celebra-35-anos-impulsando-el-desarrollo-de-las-mype-salvadorenas-y-recibe-reconocimientos-por-su-trayectoria/) Comisión Nacional de la Micro y Pequeña Empresa, “CONAMYPE celebra 35 años impulsando el desarrollo de las MYPE salvadoreñas y recibe reconocimientos por su trayectoria,” 25 de junio de 2026. [En línea]. Disponible en: sitio oficial de CONAMYPE. [Consulta: 19 de agosto de 2026].

[P00903 | 38294:38482 | NORMAL_TEXT]
[\[2\]](https://www.elsalvador.travel/services/tourist-transportation/es/) Ministerio de Turismo de El Salvador, “Transporte turístico,” El Salvador Travel. [En línea]. Disponible: directorio oficial de servicios turísticos. [Consulta: 19 de agosto de 2026].

[P00904 | 38482:38752 | NORMAL_TEXT]
[\[3\]](https://www.conamype.gob.sv/blog/2026/07/07/conamype-koica-y-pnud-fortalecen-la-transformacion-digital-de-200-mype-con-canastas-digitales-mype-360/) Comisión Nacional de la Micro y Pequeña Empresa, “CONAMYPE, KOICA y PNUD fortalecen la transformación digital de 200 MYPE con Canastas Digitales ‘MYPE 360’,” 7 de julio de 2026. [En línea]. Disponible en: sitio oficial de CONAMYPE. [Consulta: 19 de agosto de 2026].

[P00905 | 38752:39029 | NORMAL_TEXT]
[\[4\]](https://www.asamblea.gob.sv/sites/default/files/documents/decretos/17458CF0-AB9B-482A-85A1-03834D5D89B7.pdf) Asamblea Legislativa de la República de El Salvador, Decreto Legislativo n.º 144, “Ley para la Protección de Datos Personales,” Diario Oficial n.º 219, tomo n.º 445, 15 de noviembre de 2024. [En línea]. Disponible: decreto oficial en PDF. [Consulta: 19 de agosto de 2026].

[P00906 | 39029:39183 | NORMAL_TEXT]
[\[5\]](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-10.0) Microsoft, “ASP.NET documentation,” Microsoft Learn. [En línea]. Disponible: documentación oficial de ASP.NET Core. [Consulta: 19 de agosto de 2026].

[P00907 | 39183:39356 | NORMAL_TEXT]
[\[6\]](https://learn.microsoft.com/en-us/ef/) Microsoft, “Entity Framework documentation hub", " Microsoft Learn. [En línea]. Disponible: documentación oficial de Entity Framework. [Consulta: 19 de agosto de 2026].

[P00908 | 39356:39493 | NORMAL_TEXT]
[\[7\]](https://docs.docker.com/get-started/introduction/) Docker Inc., “Introduction,” Docker Docs. [En línea]. Disponible: documentación oficial de Docker. [Consulta: 19 de agosto de 2026].

[P00909 | 39493:39653 | NORMAL_TEXT]
[\[8\]](https://learn.microsoft.com/en-us/azure/container-apps/scale-app) Microsoft, “Scaling in Azure Container Apps,” Microsoft Learn. [En línea]. Disponible: documentación oficial de escalado. [Consulta: 19 de agosto de 2026].

[P00910 | 39653:39837 | NORMAL_TEXT]
[\[9\]](https://learn.microsoft.com/en-us/azure/postgresql/flexible-server/service-overview) Microsoft, “What is Azure Database for PostgreSQL flexible server?,” Microsoft Learn. [En línea]. Disponible: documentación oficial del servicio. [Consulta: 19 de agosto de 2026].

[P00911 | 39837:40005 | NORMAL_TEXT]
[\[10\]](https://azure.microsoft.com/en-us/free/students) Microsoft, “Azure for Students - Free Account Credit,” Microsoft Azure. [En línea]. Disponible: oferta oficial para estudiantes. [Consulta: 19 de agosto de 2026].

[P00912 | 40005:40192 | NORMAL_TEXT]
[\[11\]](https://learn.microsoft.com/en-us/azure/ai-foundry/responsible-ai/openai/overview) Microsoft, “Overview of Responsible AI practices for Azure OpenAI models,” Microsoft Learn. [En línea]. Disponible: guía oficial de IA responsable. [Consulta: 19 de agosto de 2026].

