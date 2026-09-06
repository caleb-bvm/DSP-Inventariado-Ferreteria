import fs from "node:fs/promises";
import path from "node:path";
import { Presentation, PresentationFile } from "@oai/artifact-tool";

const ROOT = process.cwd();
const OUT = path.join(ROOT, "output", "presentations", "Rentavia_Proyecto_Catedra_Fase1.pptx");
const SOURCE_DOC = path.join(ROOT, "tmp", "pdfs", "final-4_4-4_6-v2", "Documentacion_Proyecto_Catedra_QA.pdf");
const W = 1280;
const H = 720;
const BLACK = "#111111";
const DARK = "#333333";
const MID = "#666666";
const LIGHT = "#D9D9D9";
const PALE = "#F5F5F5";
const WHITE = "#FFFFFF";

const refs = {
  1: "https://www.conamype.gob.sv/blog/2026/06/25/conamype-celebra-35-anos-impulsando-el-desarrollo-de-las-mype-salvadorenas-y-recibe-reconocimientos-por-su-trayectoria/",
  2: "https://www.elsalvador.travel/services/tourist-transportation/es/",
  3: "https://www.conamype.gob.sv/blog/2026/07/07/conamype-koica-y-pnud-fortalecen-la-transformacion-digital-de-200-mype-con-canastas-digitales-mype-360/",
  4: "https://www.asamblea.gob.sv/sites/default/files/documents/decretos/17458CF0-AB9B-482A-85A1-03834D5D89B7.pdf",
  5: "https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-10.0",
  6: "https://learn.microsoft.com/en-us/ef/",
  7: "https://docs.docker.com/get-started/introduction/",
  8: "https://learn.microsoft.com/en-us/azure/container-apps/scale-app",
  9: "https://learn.microsoft.com/en-us/azure/postgresql/flexible-server/service-overview",
  10: "https://azure.microsoft.com/en-us/free/students",
  11: "https://learn.microsoft.com/en-us/azure/ai-foundry/responsible-ai/openai/overview",
};

function textbox(slide, text, x, y, width, height, style = {}) {
  const shape = slide.shapes.add({
    geometry: "textbox",
    position: { left: x, top: y, width, height },
    fill: "none",
    line: { style: "solid", fill: "none", width: 0 },
  });
  shape.text = text;
  shape.text.style = {
    fontFamily: "Arial",
    fontSize: style.fontSize ?? 20,
    color: style.color ?? BLACK,
    bold: style.bold ?? false,
    alignment: style.alignment ?? "left",
    verticalAlignment: style.verticalAlignment ?? "top",
  };
  return shape;
}

function line(slide, x, y, width, color = BLACK, thickness = 1) {
  return slide.shapes.add({
    geometry: "rect",
    position: { left: x, top: y, width, height: thickness },
    fill: color,
    line: { style: "solid", fill: color, width: 0 },
  });
}

function hintFor(title, section) {
  const t = title.toLowerCase();
  if (t.startsWith("diccionario de datos:")) {
    const entity = title.split(":")[1]?.trim() ?? "entidad";
    return `Un diccionario de datos documenta los campos, tipos y restricciones de ${entity}; sirve para implementar y validar la base de datos sin ambigüedades.`;
  }
  if (t.includes("bibliografía")) return "Una fuente técnica permite verificar conceptos, decisiones y tecnologías; su URL y fecha de consulta hacen trazable la investigación.";
  if (t.includes("casos de uso")) return "Un caso de uso representa una función que el sistema ofrece a un actor; sirve para delimitar responsabilidades y requisitos funcionales.";
  if (t.includes("secuencia")) return "Un diagrama de secuencia muestra mensajes en orden temporal; sirve para comprobar cómo colaboran interfaz, lógica, base de datos y servicios externos.";
  if (t.includes("entidad–relación")) return "El modelo entidad–relación representa tablas, claves y cardinalidades; sirve como plano lógico para construir la base de datos relacional.";
  if (t.includes("prototipo: acceso")) return "La autenticación comprueba la identidad; la autorización por roles determina qué acciones puede ejecutar cada usuario.";
  if (t.includes("panel operativo")) return "Un dashboard reúne indicadores y alertas en una vista; sirve para conocer el estado operativo y priorizar acciones.";
  if (t.includes("disponibilidad de flota")) return "La disponibilidad combina fechas, estado y ausencia de reservas superpuestas; sirve para ofrecer solamente vehículos realmente utilizables.";
  if (t.includes("nueva reserva")) return "El recomendador filtra candidatos válidos y usa IA para ordenarlos o explicarlos; la confirmación final permanece bajo control humano.";
  if (t.includes("prototipos ux/ui")) return "UX estudia la experiencia completa del usuario y UI diseña la interfaz visible; ambas permiten validar el flujo antes de programarlo.";
  if (t.includes("uml")) return "UML es un lenguaje visual estandarizado para describir actores, procesos e interacciones antes de implementar el software.";
  if (t.includes("flujo de datos")) return "Un flujo de datos muestra cómo la información atraviesa componentes; sirve para detectar dependencias, validaciones y puntos de integración.";
  if (t.includes("asp.net") || t.includes("presentación")) return "ASP.NET Core es el framework web de .NET; recibe solicitudes HTTP, ejecuta la aplicación y devuelve páginas o respuestas de API.";
  if (t.includes("entity framework") || t.includes("persistencia")) return "Entity Framework Core es un ORM: traduce objetos de C# a tablas y consultas SQL, simplificando persistencia y migraciones.";
  if (t.includes("postgresql") || t.includes("base de datos")) return "PostgreSQL es un gestor relacional; almacena datos estructurados y aplica claves, restricciones y transacciones para conservar su integridad.";
  if (t.includes("docker")) return "Docker empaqueta aplicación y dependencias en contenedores; sirve para ejecutar el mismo entorno en desarrollo, pruebas y despliegue.";
  if (t.includes("azure")) return "Microsoft Azure ofrece servicios administrados de cómputo, registro y base de datos; sirve para desplegar y operar el piloto en la nube.";
  if (t.includes("ia") || t.includes("recomendador")) return "La inteligencia artificial genera o prioriza sugerencias; debe recibir candidatos filtrados, producir una salida validable y contar con una alternativa por reglas.";
  if (t.includes("seguridad") || t.includes("privacidad")) return "La seguridad protege confidencialidad, integridad y disponibilidad mediante autenticación, permisos, cifrado, auditoría y mínimo privilegio.";
  if (t.includes("respaldo") || t.includes("continuidad")) return "Un backup es una copia recuperable; el monitoreo observa métricas y alertas para detectar fallos y sostener la continuidad del servicio.";
  if (t.includes("arquitectura en capas") || t.includes("decisión arquitectónica")) return "La arquitectura en capas separa interfaz, casos de uso, reglas e infraestructura; sirve para reducir acoplamiento y facilitar pruebas y cambios.";
  if (t.includes("dominio")) return "El dominio concentra entidades y reglas del negocio; evita que decisiones críticas dependan de la interfaz o de una tecnología externa.";
  if (t.includes("aplicación")) return "La capa de aplicación coordina casos de uso y transacciones; conecta la intención del usuario con las reglas del dominio y los recursos externos.";
  if (t.includes("infraestructura")) return "La infraestructura implementa acceso a datos, correo, archivos, nube e IA; se desacopla mediante interfaces para poder sustituir proveedores.";
  if (t.includes("api") || t.includes("servicio")) return "Una API expone operaciones mediante endpoints; sirve para intercambiar datos entre clientes y servicios con contratos de entrada y salida definidos.";
  if (t.includes("requisito") || section.toLowerCase() === "requisitos") return "Un requisito define una capacidad o calidad verificable; los criterios de aceptación indican cómo demostrar que se cumple.";
  if (t.includes("riesgo")) return "La gestión de riesgos identifica probabilidad, impacto y mitigación; sirve para reducir fallos antes de que afecten alcance, costo o calidad.";
  if (t.includes("factibilidad")) return "La factibilidad evalúa si la propuesta puede construirse, financiarse y adoptarse con los recursos y restricciones disponibles.";
  if (t.includes("costo") || t.includes("económica")) return "El control de costos compara consumo y presupuesto; alertas, límites y escalado a cero ayudan a evitar cargos inesperados en la nube.";
  if (t.includes("indicador") || t.includes("línea base") || t.includes("resultado")) return "Un indicador es una medida verificable; la línea base registra el estado inicial para comparar posteriormente el efecto real del sistema.";
  if (t.includes("cronograma") || t.includes("avance") || t.includes("entregable")) return "El desarrollo incremental divide el proyecto en entregas verificables; sirve para controlar avance, recibir retroalimentación y reducir riesgos.";
  if (t.includes("glosario")) return "Un glosario fija el significado de siglas y conceptos; sirve para que equipo, docentes y usuarios compartan el mismo vocabulario técnico.";
  if (t.includes("alcance")) return "El alcance define qué incluye y excluye la versión inicial; sirve para controlar expectativas, tiempo, costo y complejidad.";
  if (t.includes("módulo")) return "Un módulo agrupa funciones relacionadas con una responsabilidad del negocio; facilita organización, mantenimiento y pruebas independientes.";
  if (t.includes("objetivo")) return "Un objetivo expresa el resultado que orienta el proyecto; debe conectarse con funciones, entregables e indicadores verificables.";
  if (t.includes("contexto") || t.includes("transformación digital")) return "La transformación digital integra procesos, personas y tecnología para convertir registros dispersos en información útil y trazable.";
  if (t.includes("problema") || t.includes("impacto")) return "Una fuente única de información centraliza el dato oficial; reduce duplicidad, inconsistencias y decisiones basadas en registros desactualizados.";
  if (t.includes("usuario")) return "Un usuario es una persona o rol que interactúa con el sistema; identificar sus tareas permite diseñar permisos y flujos adecuados.";
  if (t.includes("solución") || t.includes("descripción general") || t.includes("ficha")) return "Una aplicación web se ejecuta en un servidor y se usa desde un navegador; centraliza procesos sin instalar un programa distinto en cada equipo.";
  if (t.includes("conclusión") || t.includes("recomendación")) return "La validación contrasta la propuesta con usuarios, datos y pruebas; sirve para convertir supuestos del proyecto en evidencia comprobable.";
  if (t.includes("contenido")) return "La documentación técnica conecta problema, requisitos, diseño, datos, implementación y validación para conservar trazabilidad de extremo a extremo.";
  return "La trazabilidad permite seguir cada decisión y registro desde su origen hasta su resultado; sirve para auditar, explicar y corregir la operación.";
}

function addHint(slide, title, section, number) {
  line(slide, 64, 676, 1152, LIGHT, 1);
  textbox(slide, `CONCEPTO CLAVE · ${hintFor(title, section)}`, 64, 682, 1078, 24, { fontSize: 10, color: DARK });
  textbox(slide, String(number).padStart(2, "0"), 1160, 682, 56, 18, { fontSize: 10, color: MID, alignment: "right" });
}

function base(slide, title, section, number) {
  slide.background.fill = WHITE;
  textbox(slide, section.toUpperCase(), 64, 28, 480, 22, { fontSize: 12, bold: true, color: MID });
  textbox(slide, title, 64, 56, 1140, 54, { fontSize: 36, bold: true });
  line(slide, 64, 116, 1152, LIGHT, 2);
  addHint(slide, title, section, number);
}

function setNotes(slide, extra = "", citations = []) {
  const sources = [SOURCE_DOC, ...citations.map((n) => refs[n])];
  const unique = [...new Set(sources)];
  slide.speakerNotes.textFrame.setText(`${extra}${extra ? "\n\n" : ""}[Sources]\n${unique.map((s) => `- ${s}`).join("\n")}`);
}

function bulletText(bullets) {
  return bullets.map((b) => `• ${b}`).join("\n\n");
}

function addBullets(p, spec, number) {
  const slide = p.slides.add();
  base(slide, spec.title, spec.section, number);
  const totalChars = spec.bullets.reduce((a, b) => a + b.length, 0);
  const twoCols = spec.columns === 2 || (spec.bullets.length >= 7 && totalChars > 520);
  const fs = spec.fontSize ?? (totalChars > 800 ? 16 : totalChars > 560 ? 18 : 21);
  if (twoCols) {
    const split = Math.ceil(spec.bullets.length / 2);
    textbox(slide, bulletText(spec.bullets.slice(0, split)), 76, 142, 540, 500, { fontSize: fs, color: DARK });
    textbox(slide, bulletText(spec.bullets.slice(split)), 664, 142, 540, 500, { fontSize: fs, color: DARK });
    line(slide, 640, 148, 1, LIGHT, 480);
  } else {
    textbox(slide, bulletText(spec.bullets), 84, 146, 1110, 500, { fontSize: fs, color: DARK });
  }
  if (spec.footer) textbox(slide, spec.footer, 76, 650, 1060, 24, { fontSize: 11, color: MID });
  setNotes(slide, spec.notes ?? "", spec.citations ?? []);
  return slide;
}

function addTable(p, spec, number) {
  const slide = p.slides.add();
  base(slide, spec.title, spec.section, number);
  const rows = spec.rows.length + 1;
  const table = slide.tables.add({
    rows,
    columns: spec.headers.length,
    left: 64,
    top: 146,
    width: 1152,
    height: spec.height ?? 470,
    columnWidths: spec.widths,
    values: [spec.headers, ...spec.rows],
  });
  table.borders.assign({ style: "solid", fill: "#888888", width: 1 });
  for (let c = 0; c < spec.headers.length; c++) {
    const cell = table.getCell(0, c);
    cell.fill = BLACK;
    cell.text.style = { fontFamily: "Arial", fontSize: spec.headerSize ?? 16, bold: true, color: WHITE };
  }
  for (let r = 1; r < rows; r++) {
    for (let c = 0; c < spec.headers.length; c++) {
      const cell = table.getCell(r, c);
      cell.fill = r % 2 === 0 ? PALE : WHITE;
      cell.text.style = { fontFamily: "Arial", fontSize: spec.fontSize ?? 15, color: BLACK };
    }
  }
  if (spec.footer) textbox(slide, spec.footer, 70, 642, 1080, 28, { fontSize: 11, color: MID });
  setNotes(slide, spec.notes ?? "", spec.citations ?? []);
  return slide;
}

async function imageBytes(rel) {
  const b = await fs.readFile(path.join(ROOT, rel));
  return b.buffer.slice(b.byteOffset, b.byteOffset + b.byteLength);
}

async function addImage(p, spec, number) {
  const slide = p.slides.add();
  base(slide, spec.title, spec.section, number);
  const blob = await imageBytes(spec.path);
  slide.images.add({
    blob,
    contentType: spec.contentType ?? (spec.path.toLowerCase().endsWith(".png") ? "image/png" : "image/jpeg"),
    alt: spec.alt,
    fit: spec.fit ?? "contain",
    crop: spec.crop,
    position: spec.position ?? { left: 84, top: 136, width: 1112, height: 510 },
  });
  if (spec.caption) textbox(slide, spec.caption, 76, 650, 1080, 22, { fontSize: 11, color: MID, alignment: "center" });
  setNotes(slide, spec.notes ?? "", spec.citations ?? []);
  return slide;
}

function addCover(p) {
  const slide = p.slides.add();
  slide.background.fill = WHITE;
  textbox(slide, "UNIVERSIDAD DON BOSCO", 72, 52, 1136, 26, { fontSize: 14, bold: true, alignment: "center" });
  textbox(slide, "Rentavía", 72, 132, 1136, 72, { fontSize: 54, bold: true, alignment: "center" });
  textbox(slide, "Sistema web inteligente para la gestión de renta de vehículos", 150, 215, 980, 54, { fontSize: 25, alignment: "center" });
  line(slide, 330, 292, 620, BLACK, 2);
  textbox(slide, "Proyecto de Cátedra — Fase 1\nDesarrollo de Aplicaciones con Software Propietario", 170, 320, 940, 64, { fontSize: 18, alignment: "center" });
  textbox(slide, "Josue Gamaliel Flores Figueroa — FF233029\nCristian Josué Torres Reyes — TR240516\nMichael Caleb Ortiz Melendez — OM260275\nNathaly Ivania Martinez Guerrero — MG260121\nJimmy Steeven Peña Saravia — PS260123", 260, 414, 760, 128, { fontSize: 16, alignment: "center" });
  textbox(slide, "Docente: Ing. Rene Mauricio Tejada\n24 de agosto de 2026", 300, 585, 680, 46, { fontSize: 15, alignment: "center" });
  addHint(slide, "Ficha del proyecto", "Introducción", 1);
  setNotes(slide);
}

const bullets = [
  ["Ficha del proyecto", "Introducción", ["Sistema web para pequeñas y medianas agencias salvadoreñas de renta de vehículos.", "Problema de partida: hojas de cálculo, agendas, llamadas y mensajería separadas.", "Centraliza clientes, flota, reservas, contratos, devoluciones, mantenimiento y reportes.", "La IA recomienda únicamente vehículos que existen y están disponibles.", "La propuesta debe validarse durante la Fase II."]],
  ["Contenido", "Introducción", ["Contexto, problema y usuarios.", "Solución, alcance y criterios de éxito.", "Factibilidad, prototipos y UML.", "Arquitectura, seguridad e inteligencia artificial.", "Base de datos y diccionario completo.", "Requisitos, plan de trabajo, resultados y conclusiones.", "Glosario de siglas, conceptos y tecnologías; bibliografía."], 2],
  ["Descripción general", "Descripción del proyecto", ["Aplicación web centralizada para la operación completa de una agencia pequeña.", "Disponibilidad real de flota en un rango de fechas.", "Automatización del ciclo reserva → alquiler → devolución → mantenimiento.", "Reportes básicos para la toma de decisiones.", "Recomendación inteligente orientativa y sujeta a confirmación humana."]],
  ["Objetivo general", "Descripción del proyecto", ["Desarrollar un sistema web seguro, modular y escalable.", "Centralizar la información de la flota y los clientes.", "Automatizar reserva, entrega, devolución y mantenimiento.", "Incorporar un asistente inteligente de recomendación.", "Reducir errores operativos, mejorar la trazabilidad y elevar la calidad del servicio."]],
  ["Objetivos específicos", "Descripción del proyecto", ["Centralizar clientes, vehículos, categorías, tarifas, disponibilidad, reservas, alquileres, devoluciones y mantenimientos en una base relacional.", "Impedir reservas superpuestas y automatizar tarifas, días de alquiler y cargos adicionales.", "Recomendar vehículos por pasajeros, equipaje, viaje, transmisión, presupuesto y preferencias.", "Implementar servicios web, autenticación, autorización por rol y protección de datos.", "Contenerizar con Docker y proponer despliegue en Microsoft Azure.", "Mantener una arquitectura en capas para pruebas, mantenimiento y escalabilidad."]],
  ["Contexto salvadoreño", "Análisis del problema", ["CONAMYPE reportó más de 276,000 servicios empresariales y cerca de 52,000 registros MYPE en siete años [1].", "El directorio oficial de transporte turístico incluye operadores registrados y arrendadoras de vehículos [2].", "La observación inicial sugiere agencias independientes con pocos empleados y flotas reducidas.", "Esa observación se trata como hipótesis y deberá validarse con trabajo de campo."], null, [1,2]],
  ["Transformación digital y pertinencia", "Análisis del problema", ["En 2026, CONAMYPE, MITUR, KOICA y PNUD entregaron herramientas digitales a 200 MYPE del sector turismo [3].", "La propuesta se alinea con la digitalización tecnológica, comercial y administrativa.", "La adopción depende de que la solución sea sencilla, asequible y adaptable.", "Los beneficios todavía no son resultados medidos; son hipótesis de mejora."], null, [3]],
  ["Problema identificado", "Análisis del problema", ["No existe una única fuente confiable de información.", "Pueden producirse reservas duplicadas o asignaciones superpuestas.", "Consultar disponibilidad por fechas consume tiempo.", "El historial de clientes, contratos, pagos, inspecciones, daños y cargos está disperso.", "Faltan alertas de devoluciones, retrasos y mantenimiento.", "Es difícil medir utilización, ingresos y demanda.", "Las recomendaciones dependen de criterios no uniformes."], 2],
  ["Usuarios afectados", "Análisis del problema", ["Propietario o administrador: necesita indicadores y control general.", "Empleado de atención: registra clientes, consulta disponibilidad y crea reservas.", "Encargado de flota: registra entrega, devolución, inspección y mantenimiento.", "Cliente: necesita opciones adecuadas, información clara y confirmaciones oportunas."]],
  ["Impacto y línea base", "Análisis del problema", ["La fragmentación aumenta búsquedas, inconsistencias y coordinación manual.", "Dificulta conocer el estado real de cada vehículo.", "Complica reconstruir una operación ante consultas o reclamos.", "El impacto se medirá con tiempos de proceso, incidencias y percepción de usuarios.", "No deben declararse porcentajes de mejora antes de levantar la línea base."]],
  ["Solución propuesta", "Análisis del problema", ["Aplicación web responsive con autenticación por roles.", "Agenda central de disponibilidad y bloqueo de conflictos de fechas.", "Historial completo por vehículo.", "Conversión de reserva en alquiler y registro de devolución.", "Mantenimiento con bloqueo temporal de disponibilidad.", "Reportes operativos para apoyar decisiones."]],
  ["Cómo funciona el recomendador", "Análisis del problema", ["El servidor consulta primero la disponibilidad real.", "Reglas determinísticas filtran candidatos por restricciones objetivas.", "La IA ordena o explica alternativas según preferencias.", "El backend valida identificadores y salida.", "El usuario revisa y decide.", "La IA no confirma reservas ni toma decisiones legales o financieras."]],
  ["Alcance inicial", "Análisis del problema", ["Una agencia con una o más sucursales configurables.", "Prioridad: operación pequeña y flujo principal completo.", "Identidad, clientes, flota, reservas y alquileres.", "Devoluciones, pagos, cargos, mantenimiento y reportes.", "Recomendación inteligente y auditoría.", "Prototipo académico y piloto controlado."]],
  ["Fuera del alcance inicial", "Análisis del problema", ["Pasarela de pagos.", "Rastreo GPS.", "Integración con aseguradoras o instituciones públicas.", "Aplicación móvil nativa.", "Reconocimiento automático de daños.", "Fijación dinámica de precios.", "Estas funciones quedan como extensiones futuras."], 2],
  ["Criterios de éxito propuestos", "Análisis del problema", ["Cero reservas confirmadas superpuestas para un vehículo.", "Trazabilidad desde la reserva hasta la devolución y cierre.", "Consulta por fechas y filtros desde una sola pantalla.", "Recomendaciones únicamente de vehículos disponibles y con explicación.", "Pruebas de usabilidad con usuarios representativos.", "Metas cuantitativas definitivas después de la línea base."]],
  ["Módulos operativos", "Diseño técnico", ["Identidad y seguridad: acceso, recuperación, usuarios, roles y permisos.", "Clientes: contacto, documentos e historial.", "Flota: vehículos, categorías, tarifas, imágenes, kilometraje y estado.", "Reservas: fechas, disponibilidad, creación, modificación y cancelación.", "Alquileres y devoluciones: contrato, entrega, inspección, combustible, kilometraje y cargos."]],
  ["Módulos de soporte y análisis", "Diseño técnico", ["Mantenimiento preventivo y correctivo con bloqueo de disponibilidad.", "Reportes de utilización, ingresos, reservas, devoluciones y mantenimiento.", "Recomendador con preferencias, candidatos filtrados, explicación y registro.", "Auditoría de operaciones sensibles, errores y eventos críticos.", "Notificaciones por correo condicionadas al alcance del prototipo."]],
  ["Interacción entre componentes", "Diseño técnico", ["La interfaz no accede directamente a la base de datos.", "Los controladores o endpoints reciben solicitudes y validan modelos.", "La capa de aplicación orquesta los casos de uso.", "El dominio aplica las reglas centrales.", "La infraestructura resuelve persistencia, correo, archivos, monitoreo e IA.", "La separación reduce el acoplamiento y facilita las pruebas."]],
  ["Factibilidad técnica: tecnologías", "Factibilidad", ["C# y ASP.NET Core para la aplicación web y servicios [5].", "Entity Framework Core para mapeo, consultas y migraciones [6].", "PostgreSQL como base de datos relacional.", "HTML, CSS y JavaScript para la interfaz responsive.", "Docker y Docker Compose para ambientes reproducibles [7].", "Git y GitHub para control de versiones.", "Microsoft Azure para el piloto [8][9]."], 2, [5,6,7,8,9]],
  ["Capacidades técnicas necesarias", "Factibilidad", ["Programación en C# y ASP.NET Core MVC o Web App.", "Diseño de APIs y endpoints.", "Modelado relacional, SQL, EF Core y migraciones.", "HTML, CSS, JavaScript, accesibilidad y diseño responsive.", "Git, GitHub y revisión de cambios.", "Docker, ambientes, configuración y secretos.", "Azure, registros, alertas y escalado.", "Integración y evaluación de servicios de IA."], 2],
  ["Factibilidad económica", "Factibilidad", [".NET, PostgreSQL, Git, GitHub y editores pueden usarse sin costo académico.", "Docker evita comprar servidores durante la construcción.", "Azure for Students ofrece USD 100 por doce meses a estudiantes elegibles [10].", "El piloto incurre en costos de base de datos, almacenamiento, contenedores e IA.", "El precio depende de región, capacidad, tráfico, retención y solicitudes."], null, [10]],
  ["Control de costos", "Factibilidad", ["Calcular el precio vigente antes de desplegar.", "Azure Container Apps puede escalar a cero en consumo [8].", "La base administrada y otros recursos pueden seguir generando cargos [9].", "Configurar presupuesto, alertas, límites de consumo y retención.", "El crédito estudiantil no es un modelo sostenible de producción.", "Conclusión: viable para prototipo y piloto; producción requiere presupuesto mensual."], null, [8,9]],
  ["Factibilidad operativa", "Factibilidad", ["Interfaz alineada con el flujo cotidiano y baja capacitación.", "Inicio con una sucursal piloto y migración de datos esenciales.", "Período breve de verificación paralela.", "Lenguaje sencillo, validaciones claras y estados visibles.", "Participación de propietarios y empleados en requisitos y pruebas.", "Mitigar resistencia con prototipos, demostraciones, manual y soporte."]],
  ["Conclusión de factibilidad", "Factibilidad", ["El proyecto es viable técnica, económica y operativamente para la Fase II.", "Debe mantenerse el alcance priorizado.", "Las necesidades deben validarse con agencias reales.", "Los costos de nube y consumo de IA requieren control.", "UX significa experiencia de usuario; UI significa interfaz de usuario."]],
  ["Prototipos UX/UI", "Diseño de la aplicación", ["Acceso y autenticación por roles.", "Panel operativo con indicadores y alertas.", "Disponibilidad de flota con filtros y estados.", "Nueva reserva con recomendación explicada.", "Son diseños preliminares que deberán validarse con usuarios."]],
  ["UML: terminología", "Modelado UML", ["UML: Unified Modeling Language o Lenguaje Unificado de Modelado.", "Caso de uso: función observable por un actor.", "Diagrama de secuencia: mensajes ordenados en el tiempo.", "Actor: rol externo que interactúa con el sistema.", "Línea de vida: participante durante una secuencia.", "alt: fragmento de alternativas condicionales.", "include/extend: relaciones de inclusión o extensión."], 2],
  ["Decisión arquitectónica", "Arquitectura", ["Monolito modular dentro de una solución ASP.NET Core.", "Simplifica despliegue y transacciones.", "Conserva separación lógica por capas y módulos.", "No se proponen microservicios en la primera versión.", "Un monolito se despliega como una unidad; un microservicio es un servicio independiente."]],
  ["Arquitectura en capas", "Arquitectura", ["Presentación → Aplicación → Dominio.", "Infraestructura implementa interfaces y conecta recursos externos.", "Presentación captura y muestra; Aplicación orquesta; Dominio decide; Infraestructura persiste e integra.", "Las dependencias apuntan hacia reglas estables, no hacia detalles externos."]],
  ["Capa de presentación", "Arquitectura", ["ASP.NET Core MVC o Web App con diseño responsive.", "Paneles diferentes para administrador y empleado.", "Vistas para consulta y reserva.", "Los controladores reciben solicitudes y validan modelos.", "Las reglas complejas no pertenecen a los controladores."]],
  ["Capa de aplicación", "Arquitectura", ["Orquesta registrar vehículo, disponibilidad, reserva, alquiler, devolución, mantenimiento, reportes e IA.", "Define interfaces para persistencia, correo, archivos e IA.", "Coordina autorización y transacciones.", "Facilita pruebas y sustitución de proveedores.", "Caso de uso: objetivo de negocio ejecutado por la aplicación."]],
  ["Capa de dominio", "Arquitectura", ["Entidades: Usuario, Rol, Cliente, Sucursal, Vehículo, Categoría, Tarifa, Reserva, Alquiler, Inspección, Cargo Adicional, Pago, Mantenimiento y Recomendación.", "Objetos de valor y reglas centrales.", "Impide reservas superpuestas.", "Impide usar vehículos fuera de servicio.", "Impide cerrar devoluciones incompletas.", "Invariante: regla que siempre debe mantenerse."]],
  ["Capa de infraestructura", "Arquitectura", ["Entity Framework Core y PostgreSQL.", "Repositorios cuando aporten valor.", "Almacenamiento de imágenes y documentos.", "Correo, notificaciones, auditoría, registros y monitoreo.", "Adaptador del servicio de IA.", "Credenciales en secretos o configuración segura; nunca en el repositorio."]],
  ["Aplicación web, API y DTO", "Arquitectura", ["ASP.NET Core es la plataforma de frontend y backend [5].", "Los módulos pueden exponer endpoints internos o una API web.", "Los DTO evitan exponer directamente las entidades persistentes.", "API: interfaz de programación; endpoint: punto de acceso; DTO: objeto de transferencia de datos."], null, [5]],
  ["PostgreSQL y Entity Framework Core", "Arquitectura", ["PostgreSQL almacena la información transaccional.", "EF Core administra mapeo, relaciones, consultas y migraciones [6].", "Integridad: placa única, correo normalizado, estados controlados y fechas válidas.", "Restricciones, transacciones e índices protegen concurrencia y rendimiento.", "ORM: mapeo objeto-relacional; migración: cambio versionado del esquema."], null, [6]],
  ["Seguridad de la aplicación", "Arquitectura", ["ASP.NET Core Identity o mecanismo equivalente.", "Contraseñas protegidas y roles.", "Autorización por políticas y rutas privadas.", "HTTPS, protección antifalsificación y validación del servidor.", "Límites de solicitudes, auditoría y manejo centralizado de errores.", "Autenticación verifica identidad; autorización decide permisos."]],
  ["Protección de datos personales", "Arquitectura", ["Aplicar la Ley para la Protección de Datos Personales de El Salvador, Decreto 144 [4].", "Tratamiento legítimo e informado.", "Minimización y finalidad definida.", "Acceso restringido y conservación limitada.", "Corrección o eliminación cuando corresponda.", "No enviar identidad, licencia, dirección ni pago al servicio de IA."], null, [4]],
  ["IA responsable y controles", "Arquitectura", ["Entrada mínima: fechas, pasajeros, equipaje, presupuesto, preferencias y candidatos anonimizados.", "Salida limitada a identificadores permitidos, explicación y alternativas.", "Registrar versión del prompt, candidatos y resultado para pruebas.", "Ciclo responsable: identificar, medir, mitigar y operar [11].", "Revisión humana, límites de alcance, monitoreo y casos de prueba.", "Fallback basado en reglas si la IA falla."], null, [11]],
  ["Contenerización", "Despliegue", ["Imagen Docker con compilación por etapas.", "Docker Compose para aplicación y PostgreSQL en desarrollo.", "Configuración por ambiente.", "La imagen no contiene secretos.", "Ejecución reproducible entre equipos [7].", "Imagen: plantilla; contenedor: instancia; Compose: orquestación local."], null, [7]],
  ["Despliegue propuesto en Azure", "Despliegue", ["Azure Container Registry almacena la imagen.", "Azure Container Apps ejecuta y escala la aplicación [8].", "Azure Database for PostgreSQL Flexible Server aloja los datos [9].", "Almacenamiento separado para imágenes y documentos.", "HTTPS, secretos administrados, registros y alertas.", "Perfil de consumo con escalado automático y a cero."], null, [8,9]],
  ["Respaldo, monitoreo y continuidad", "Despliegue", ["Copias de seguridad de la base de datos.", "Prueba real de restauración antes de producción.", "Registros estructurados y métricas de errores.", "Alertas de consumo y eventos críticos.", "Alta disponibilidad según configuración [9].", "Backup: copia; restauración: recuperación; log: registro; métrica: medición; alerta: aviso."], null, [9]],
  ["Relaciones principales del modelo", "Base de datos", ["Rol 1:N Usuario.", "Sucursal 1:N Usuario y Vehículo.", "Categoría 1:N Vehículo y Tarifa.", "Cliente 1:N Reserva y Recomendación.", "Vehículo 1:N Reserva, Mantenimiento y Recomendación.", "Reserva 1:1 Alquiler.", "Alquiler 1:N Inspección, Pago y Cargo Adicional.", "Los nombres y campos del ERD y el diccionario deben reconciliarse antes de la migración."], 2],
  ["Convenciones del diccionario", "Base de datos", ["Columnas: Campo, Tipo de dato, Descripción, Restricción y Relación.", "INT: número entero.", "VARCHAR(n): texto de hasta n caracteres.", "NUMERIC(10,2): decimal con diez dígitos y dos decimales.", "DATE: fecha.", "PK: clave primaria; FK: clave foránea; NOT NULL: valor obligatorio."]],
  ["Recolección de requisitos", "Requisitos", ["Combina evidencia documental y trabajo de campo.", "Valida las hipótesis del problema.", "Identifica variantes reales del proceso.", "Prioriza funciones que una agencia pequeña pueda adoptar.", "Separa hechos confirmados de supuestos.", "Convierte hallazgos en historias de usuario y criterios de aceptación."]],
  ["Pregunta HMW y tratamiento ético", "Requisitos", ["¿Cómo podríamos ayudar a una pequeña agencia salvadoreña a conocer disponibilidad real, coordinar reservas y mantener trazabilidad sin aumentar la carga administrativa?", "HMW significa How Might We o ¿Cómo podríamos…?", "Solicitar consentimiento, minimizar datos y anonimizar ejemplos.", "Organizar hallazgos por usuario, tarea, problema, frecuencia e impacto.", "Marcar como supuesto toda necesidad no validada."]],
  ["Requisitos funcionales RF-01 a RF-06", "Requisitos", ["RF-01: autenticar y aplicar permisos.", "RF-02: crear, consultar, actualizar y desactivar clientes.", "RF-03: administrar categorías, tarifas, vehículos, fotos y estados.", "RF-04: consultar disponibilidad por fechas, categoría, capacidad y sucursal.", "RF-05: crear, modificar y cancelar reservas sin superposición.", "RF-06: convertir reserva en alquiler y registrar contrato, entrega, kilometraje y combustible.", "RF significa requisito funcional; CRUD significa crear, leer, actualizar y eliminar."], 2],
  ["Requisitos funcionales RF-07 a RF-12", "Requisitos", ["RF-07: devolución, inspección, retrasos, daños y cargos.", "RF-08: mantenimiento y retiro temporal de disponibilidad.", "RF-09: confirmaciones y avisos por correo si el alcance lo permite.", "RF-10: reportes de utilización, ingresos, reservas y mantenimiento.", "RF-11: recomendar con IA y explicar criterios.", "RF-12: auditoría de operaciones sensibles."]],
  ["Requisitos no funcionales RNF-01 a RNF-04", "Requisitos", ["RNF-01: proteger rutas privadas con autenticación y autorización.", "RNF-02: minimizar y restringir datos conforme a la ley [4].", "RNF-03: objetivo inicial de hasta tres segundos para consultas habituales bajo carga piloto.", "RNF-04: respaldos y restauración probada.", "RNF significa requisito no funcional: calidad o restricción del sistema."], null, [4]],
  ["Requisitos no funcionales RNF-05 a RNF-08", "Requisitos", ["RNF-05: interfaz responsive, navegación consistente y errores comprensibles.", "RNF-06: arquitectura en capas, convenciones, documentación y pruebas automatizadas.", "RNF-07: ejecución reproducible con Docker.", "RNF-08: registrar errores, eventos críticos y consumo de IA sin información sensible innecesaria."]],
  ["Priorización MoSCoW", "Requisitos", ["Must: autenticación, flota, clientes, disponibilidad, reservas, alquileres, devoluciones, mantenimiento e IA prototipo.", "Should/Could: notificaciones avanzadas según tiempo y validación.", "Won’t for now: pagos en línea, analítica predictiva y funciones móviles.", "MoSCoW significa Must, Should, Could y Won’t."]],
  ["Plan incremental: incrementos 1 y 2", "Plan del prototipo", ["Primero se validan los flujos UX/UI.", "Cada incremento queda integrado, probado y demostrable.", "Incremento 1: solución, modelo inicial, migraciones, autenticación y contenedores.", "Incremento 2: roles y CRUD de categorías, vehículos, clientes y estados.", "Desarrollo incremental: entregar valor en partes acumulativas."]],
  ["Plan incremental: incrementos 3 a 5", "Plan del prototipo", ["Incremento 3: fechas, superposición, reservas, entrega y contrato.", "Incremento 4: devolución, kilometraje, combustible, cargos y mantenimiento.", "Incremento 5: IA con candidatos filtrados, reportes, pruebas, imagen Docker y piloto Azure."]],
  ["Criterio de terminado", "Plan del prototipo", ["Cumple criterios de aceptación.", "Incluye validaciones y autorización.", "Tiene pruebas proporcionales al riesgo.", "Fue revisado mediante control de versiones.", "Funciona en el ambiente contenedorizado.", "Definition of Done: condición común para considerar terminada una historia."]],
  ["Primer avance: base técnica", "Plan del prototipo", ["Estructura ASP.NET Core y repositorio compartido.", "Arquitectura en capas y dependencias.", "Modelo de datos, ERD y migración inicial.", "EF Core con PostgreSQL.", "Autenticación y roles.", "CRUD de vehículos, categorías y clientes."]],
  ["Primer avance: experiencia y reglas", "Plan del prototipo", ["Navegación entre panel, flota, clientes y reservas.", "Prototipos UX/UI validados.", "Consulta preliminar de disponibilidad.", "Regla contra superposición.", "Contrato de entrada/salida de IA, casos de prueba y fallback.", "Configuración inicial de Docker."]],
  ["Entregables", "Plan del prototipo", ["Documento con problema, factibilidad, arquitectura, plan, resultados y bibliografía.", "Diagramas de bloques, UML y entidad-relación.", "Diccionario de datos y reglas de integridad.", "Modelo Canvas y presupuesto.", "Repositorio, historial e instrucciones.", "Aplicación contenedorizada, pruebas y piloto.", "Manual, documentación técnica y presentación."], 2],
  ["Cronograma: semanas 1 a 4", "Plan del prototipo", ["Semanas 1–2: requisitos, prototipos, datos y arquitectura.", "Semana 3: solución, seguridad, EF Core, PostgreSQL y Docker.", "Semana 4: clientes, categorías, vehículos y estados de flota."]],
  ["Cronograma: semanas 5 a 8", "Plan del prototipo", ["Semana 5: disponibilidad, reservas y alquileres.", "Semana 6: devoluciones, mantenimiento y primera integración de IA.", "Semana 7: reportes, pruebas, correcciones y Azure.", "Semana 8: validación, documentación y exposición.", "El cronograma es relativo y debe ajustarse a fechas oficiales y disponibilidad."]],
  ["Resultados operativos esperados", "Resultados", ["Disponibilidad centralizada y actualizada.", "Trazabilidad completa por vehículo.", "Menor tiempo de búsqueda frente a la línea base.", "Registros uniformes de clientes, contratos, inspecciones y cargos.", "Reportes de utilización y mantenimiento.", "Son metas por comprobar en la Fase II."]],
  ["Resultados técnicos esperados", "Resultados", ["Persistencia relacional con EF Core y PostgreSQL.", "Contenedores reproducibles.", "Autenticación, autorización, validación, auditoría y privacidad.", "IA aislada, evaluable y reemplazable.", "Piloto documentado en Microsoft Azure."]],
  ["Indicadores de validación", "Resultados", ["Cero reservas confirmadas superpuestas.", "100 % de alquileres de prueba con entrega y devolución.", "Al menos 80 % de participantes completan tareas críticas sin ayuda; documentar muestra y umbral.", "100 % de recomendaciones limitadas a vehículos disponibles y existentes.", "Comparar tiempo de consulta y tasa de errores con la línea base."]],
  ["Conclusiones", "Resultados", ["La propuesta combina gestión, automatización, servicios web, seguridad, datos, IA, Docker y Azure.", "El valor principal es una fuente única de información, no un catálogo público.", "El contexto de MYPE y transporte formal respalda la pertinencia [2][3].", "Los retos son reglas reales, concurrencia, privacidad, costos e IA.", "Reglas determinísticas, transacciones, control de acceso, capas y validación mitigan esos riesgos."], null, [2,3]],
  ["Recomendación para la Fase II", "Resultados", ["Iniciar con investigación de campo.", "Construir un flujo vertical pequeño y completo.", "Priorizar reservas, alquileres, devoluciones y mantenimiento.", "Incorporar funciones avanzadas después de estabilizar el núcleo.", "Mantener control explícito del alcance.", "Validar con usuarios y evidencia."]],
  ["Glosario institucional", "Glosario", ["CONAMYPE: Comisión Nacional de la Micro y Pequeña Empresa.", "MYPE: micro y pequeña empresa.", "MITUR: Ministerio de Turismo.", "KOICA: Korea International Cooperation Agency.", "PNUD: Programa de las Naciones Unidas para el Desarrollo.", "UDB: Universidad Don Bosco.", "USD: dólar de los Estados Unidos."], 2],
  ["Glosario de software y web", "Glosario", ["C#: lenguaje de programación de Microsoft.", ".NET: plataforma de desarrollo.", "ASP.NET Core: framework web multiplataforma.", "MVC: Modelo–Vista–Controlador.", "Web App: aplicación accesible mediante navegador.", "API: interfaz de programación de aplicaciones.", "Endpoint: punto de acceso de una API.", "DTO: objeto de transferencia de datos.", "HTML/CSS/JavaScript: estructura, estilo y comportamiento web.", "Responsive: interfaz adaptable."], 2],
  ["Glosario de datos", "Glosario", ["BD/DB: base de datos.", "SQL: lenguaje de consulta estructurado.", "PostgreSQL: gestor relacional.", "EF Core: Entity Framework Core.", "ORM: mapeador objeto-relacional.", "ERD/DER: diagrama entidad-relación.", "PK/FK: clave primaria/foránea.", "INT, VARCHAR, NUMERIC, DATE y NOT NULL: tipos y restricción.", "Índice, restricción, migración y transacción."], 2],
  ["Glosario de arquitectura y nube", "Glosario", ["Monolito modular y microservicio.", "Arquitectura en capas.", "Frontend, backend, dominio, infraestructura y persistencia.", "Docker, imagen, contenedor y Docker Compose.", "Azure Container Registry, Container Apps y PostgreSQL Flexible Server.", "Escalado automático y escalado a cero.", "HTTPS, secreto y variable de entorno."], 2],
  ["Glosario de diseño y requisitos", "Glosario", ["UX/UI: experiencia/interfaz de usuario.", "UML, actor, caso de uso, secuencia y línea de vida.", "RF/RNF: requisito funcional/no funcional.", "CRUD: crear, leer, actualizar y eliminar.", "MoSCoW y HMW.", "Historia de usuario y criterio de aceptación.", "Prototipo, piloto y línea base.", "Desarrollo incremental y Definition of Done."], 2],
  ["Glosario de IA, seguridad y operación", "Glosario", ["IA/AI: inteligencia artificial.", "Prompt y salida estructurada.", "Anonimización, regla determinística y fallback.", "Autenticación, autorización, rol y política.", "Auditoría y log.", "Backup y restauración.", "Monitoreo, métrica y alerta.", "Trazabilidad y concurrencia."], 2],
];

const riskTable = {
  title: "Riesgos técnicos y mitigaciones",
  section: "Factibilidad",
  headers: ["Riesgo", "Efecto", "Mitigación"],
  widths: [260, 330, 562],
  rows: [
    ["Curva Docker/Azure", "Retraso de despliegue", "Prueba temprana y procedimiento documentado"],
    ["Modelo de datos", "Migraciones incompatibles", "Acordar ERD y revisar cada migración"],
    ["Costo o caída de IA", "Recomendador no disponible", "Interfaz desacoplada, límites y fallback por reglas"],
    ["Respuesta incorrecta", "Alternativa inválida", "Filtrar candidatos, salida estructurada y validar IDs"],
    ["Concurrencia", "Reserva duplicada", "Transacciones, restricciones y pruebas"],
  ],
  citations: [],
};

const researchTable = {
  title: "Técnicas de investigación",
  section: "Requisitos",
  headers: ["Técnica", "Muestra mínima", "Propósito"],
  widths: [330, 260, 562],
  rows: [
    ["Entrevistas", "3 propietarios + 2 empleados", "Reglas, variantes y problemas operativos"],
    ["Encuesta", "15 clientes potenciales", "Criterios de elección, canales y confirmación"],
    ["Observación", "1 agencia", "Consulta, reserva, entrega y devolución"],
    ["Revisión documental", "Registros anonimizados", "Formularios, contratos y hojas actuales"],
    ["Taller HMW", "Equipo del proyecto", "Convertir hallazgos en oportunidades"],
  ],
};

const dictSlides = [
  ["Rol", [["IdRol", "INT", "PK, NOT NULL", "Identificador"], ["Nombre", "VARCHAR(50)", "NOT NULL", "Nombre del rol"], ["Descripción", "VARCHAR(150)", "NOT NULL", "Funciones del rol"]]],
  ["Usuario", [["IdUsuario", "INT", "PK, NOT NULL", "Identificador"], ["IdRol", "INT", "FK, NOT NULL", "Rol"], ["IdSucursal", "INT", "FK, NOT NULL", "Sucursal"], ["Nombre / Apellido", "VARCHAR(50)", "NOT NULL", "Identidad"], ["Correo", "VARCHAR(100)", "NOT NULL", "Acceso"], ["Contraseña", "VARCHAR(255)", "NOT NULL", "Hash protegido"], ["Estado", "VARCHAR(20)", "NOT NULL", "Estado de cuenta"]]],
  ["Sucursal", [["IdSucursal", "INT", "PK, NOT NULL", "Identificador"], ["Nombre", "VARCHAR(100)", "NOT NULL", "Nombre"], ["Dirección", "VARCHAR(200)", "NOT NULL", "Ubicación"], ["Teléfono", "VARCHAR(20)", "NOT NULL", "Contacto"], ["Estado", "VARCHAR(20)", "NOT NULL", "Funcionamiento"]]],
  ["Categoría", [["IdCategoria", "INT", "PK, NOT NULL", "Identificador"], ["Nombre", "VARCHAR(50)", "NOT NULL", "Nombre"], ["Descripción", "VARCHAR(150)", "NOT NULL", "Características"]]],
  ["Vehículo", [["IdVehiculo", "INT", "PK, NOT NULL", "Identificador"], ["IdCategoria", "INT", "FK, NOT NULL", "Categoría"], ["IdSucursal", "INT", "FK, NOT NULL", "Sucursal"], ["Placa", "VARCHAR(15)", "NOT NULL", "Placa"], ["Marca / Modelo", "VARCHAR(50)", "NOT NULL", "Fabricante / modelo"], ["Año", "INT", "NOT NULL", "Año"], ["Color", "VARCHAR(30)", "NOT NULL", "Color"], ["Transmisión", "VARCHAR(20)", "NOT NULL", "Tipo"], ["CapacidadPasajeros", "INT", "NOT NULL", "Capacidad"], ["Kilometraje", "NUMERIC(10,2)", "NOT NULL", "Lectura actual"], ["Estado", "VARCHAR(20)", "NOT NULL", "Disponibilidad"]]],
  ["Tarifa", [["IdTarifa", "INT", "PK, NOT NULL", "Identificador"], ["IdCategoria", "INT", "FK, NOT NULL", "Categoría"], ["Nombre", "VARCHAR(50)", "NOT NULL", "Tipo"], ["PrecioDia", "NUMERIC(10,2)", "NOT NULL", "Precio diario"], ["VigenciaDesde", "DATE", "NOT NULL", "Inicio"], ["VigenciaHasta", "DATE", "NOT NULL", "Fin"], ["Estado", "VARCHAR(20)", "NOT NULL", "Vigencia"]]],
  ["Cliente", [["IdCliente", "INT", "PK, NOT NULL", "Identificador"], ["Nombre / Apellido", "VARCHAR(50)", "NOT NULL", "Identidad"], ["Documento / Licencia", "VARCHAR(30)", "NOT NULL", "Identificación"], ["Teléfono", "VARCHAR(20)", "NOT NULL", "Contacto"], ["Correo", "VARCHAR(100)", "NOT NULL", "Contacto"], ["Dirección", "VARCHAR(200)", "NOT NULL", "Domicilio"], ["FechaRegistro", "DATE", "NOT NULL", "Alta"]]],
  ["Reserva", [["IdReserva", "INT", "PK, NOT NULL", "Identificador"], ["IdCliente", "INT", "FK, NOT NULL", "Cliente"], ["IdVehiculo", "INT", "FK, NOT NULL", "Vehículo"], ["FechaReserva", "DATE", "NOT NULL", "Registro"], ["FechaInicio", "DATE", "NOT NULL", "Inicio"], ["FechaFin", "DATE", "NOT NULL", "Fin"], ["TotalEstimado", "NUMERIC(10,2)", "NOT NULL", "Costo estimado"]]],
  ["Alquiler", [["IdAlquiler", "INT", "PK, NOT NULL", "Identificador"], ["IdReserva", "INT", "FK, NOT NULL", "Reserva"], ["FechaInicio", "DATE", "NOT NULL", "Entrega"], ["FechaFin", "DATE", "NOT NULL", "Devolución prevista"], ["KilometrajeInicial", "NUMERIC(10,2)", "NOT NULL", "Lectura inicial"], ["CombustibleInicial", "VARCHAR(20)", "NOT NULL", "Nivel inicial"], ["MontoTotal", "NUMERIC(10,2)", "NOT NULL", "Total"], ["Estado", "VARCHAR(20)", "NOT NULL", "Estado"]]],
  ["Inspección", [["IdInspeccion", "INT", "PK, NOT NULL", "Identificador"], ["IdAlquiler", "INT", "FK, NOT NULL", "Alquiler"], ["Tipo", "VARCHAR(20)", "NOT NULL", "Entrega/devolución"], ["Fecha", "DATE", "NOT NULL", "Fecha"], ["Kilometraje", "NUMERIC(10,2)", "NOT NULL", "Lectura"], ["Combustible", "VARCHAR(20)", "NOT NULL", "Nivel"], ["Observaciones", "VARCHAR(300)", "NOT NULL", "Estado y daños"]]],
  ["Pago", [["IdPago", "INT", "PK, NOT NULL", "Identificador"], ["IdAlquiler", "INT", "FK, NOT NULL", "Alquiler"], ["Fecha", "DATE", "NOT NULL", "Fecha"], ["Monto", "NUMERIC(10,2)", "NOT NULL", "Importe"], ["MetodoPago", "VARCHAR(30)", "NOT NULL", "Método"], ["Referencia", "VARCHAR(100)", "NOT NULL", "Código"], ["Estado", "VARCHAR(20)", "NOT NULL", "Estado"]]],
  ["CargoAdicional", [["IdCargo", "INT", "PK, NOT NULL", "Identificador"], ["IdAlquiler", "INT", "FK, NOT NULL", "Alquiler"], ["Concepto", "VARCHAR(100)", "NOT NULL", "Motivo"], ["Descripción", "VARCHAR(200)", "NOT NULL", "Detalle"], ["Monto", "NUMERIC(10,2)", "NOT NULL", "Valor"], ["Fecha", "DATE", "NOT NULL", "Registro"]]],
  ["Mantenimiento", [["IdMantenimiento", "INT", "PK, NOT NULL", "Identificador"], ["IdVehiculo", "INT", "FK, NOT NULL", "Vehículo"], ["Tipo", "VARCHAR(30)", "NOT NULL", "Preventivo/correctivo"], ["FechaInicio / Fin", "DATE", "NOT NULL", "Período"], ["Costo", "NUMERIC(10,2)", "NOT NULL", "Costo"], ["Descripción", "VARCHAR(300)", "NOT NULL", "Trabajo"], ["Estado", "VARCHAR(20)", "NOT NULL", "Estado"]]],
  ["Recomendación", [["IdRecomendacion", "INT", "PK, NOT NULL", "Identificador"], ["IdCliente", "INT", "FK, NOT NULL", "Cliente"], ["IdVehiculo", "INT", "FK, NOT NULL", "Vehículo"], ["Fecha", "DATE", "NOT NULL", "Generación"], ["Pasajeros", "INT", "NOT NULL", "Cantidad"], ["Presupuesto", "NUMERIC(10,2)", "NOT NULL", "Presupuesto"], ["Criterios", "VARCHAR(300)", "NOT NULL", "Criterios"]]],
];

async function build() {
  const p = Presentation.create({ slideSize: { width: W, height: H } });
  addCover(p);
  let n = 2;
  for (let i = 0; i < bullets.length; i++) {
    if (n === 23) { addTable(p, riskTable, n++); }
    const [title, section, items, columns, citations] = bullets[i];
    addBullets(p, { title, section, bullets: items, columns, citations }, n++);
    if (title === "Módulos de soporte y análisis") {
      await addImage(p, { title: "Flujo de datos", section: "Diseño técnico", path: "assets/diagrama_bloques_arquitectura.png", alt: "Diagrama de bloques de Rentavía", caption: "Figura 1. Flujo principal de la solución propuesta." }, n++);
    }
    if (title === "Prototipos UX/UI") {
      await addImage(p, { title: "Prototipo: acceso", section: "Diseño de la aplicación", path: "tmp/presentation-build/prototype-access.png", alt: "Pantalla de acceso de Rentavía", position: { left: 150, top: 132, width: 980, height: 520 }, caption: "Acceso, recuperación de contraseña y selección de rol." }, n++);
      await addImage(p, { title: "Prototipo: panel operativo", section: "Diseño de la aplicación", path: "tmp/presentation-build/prototype-dashboard.png", alt: "Panel operativo de Rentavía", position: { left: 90, top: 132, width: 1100, height: 520 }, caption: "Indicadores, agenda diaria y alertas de flota." }, n++);
      await addImage(p, { title: "Prototipo: disponibilidad de flota", section: "Diseño de la aplicación", path: "tmp/presentation-build/prototype-flota.png", alt: "Pantalla de disponibilidad", position: { left: 90, top: 132, width: 1100, height: 520 }, caption: "Filtros por fecha, categoría, transmisión y sucursal." }, n++);
      await addImage(p, { title: "Prototipo: nueva reserva e IA", section: "Diseño de la aplicación", path: "tmp/presentation-build/prototype-reserva.png", alt: "Nueva reserva y recomendador", position: { left: 90, top: 132, width: 1100, height: 520 }, caption: "Preferencias, alternativas explicadas y confirmación humana." }, n++);
    }
    if (title === "UML: terminología") {
      await addImage(p, { title: "Diagrama de casos de uso", section: "Modelado UML", path: "diagramas/Diagramas de DSP-Diagrama de caso de uso.jpg.jpeg", alt: "Casos de uso de Rentavía", position: { left: 205, top: 132, width: 870, height: 520 }, caption: "Actores y funciones principales del sistema." }, n++);
      await addImage(p, { title: "Secuencia: reserva, alquiler y pago", section: "Modelado UML", path: "diagramas/Diagramas de DSP-Conversion de reserva en alquiler.jpg.jpeg", alt: "Secuencia de reserva a alquiler", position: { left: 95, top: 132, width: 1090, height: 520 }, caption: "Verificación, creación de alquiler y registro del pago." }, n++);
      await addImage(p, { title: "Secuencia: devolución con cargo", section: "Modelado UML", path: "diagramas/Diagramas de DSP-Devolucion con cargo adicional.jpg.jpeg", alt: "Secuencia de devolución con cargo", position: { left: 95, top: 132, width: 1090, height: 520 }, caption: "Inspección, cargo, pago, cierre y liberación del vehículo." }, n++);
      await addImage(p, { title: "Secuencia: recomendación de IA", section: "Modelado UML", path: "diagramas/Diagramas de DSP-Diagrama de secuencia recomendacion IA.jpg.jpeg", alt: "Secuencia de recomendación", position: { left: 95, top: 132, width: 1090, height: 520 }, caption: "Filtrado determinístico, explicación y conversión opcional en reserva." }, n++);
    }
    if (title === "Respaldo, monitoreo y continuidad") {
      await addImage(p, { title: "Modelo entidad–relación", section: "Base de datos", path: "tmp/presentation-build/modelo-er.png", alt: "Diagrama entidad-relación de Rentavía", position: { left: 185, top: 130, width: 910, height: 525 }, caption: "Catorce entidades y sus cardinalidades principales." }, n++);
    }
    if (title === "Convenciones del diccionario") {
      for (const [name, rows] of dictSlides) {
        addTable(p, { title: `Diccionario de datos: ${name}`, section: "Base de datos", headers: ["Campo", "Tipo", "Restricción", "Significado / relación"], widths: [285, 245, 255, 367], rows, fontSize: rows.length > 9 ? 12 : 15, headerSize: 15, height: 485, footer: name === "Cliente" ? "Los datos personales requieren minimización y acceso restringido." : name === "Reserva" ? "Regla esencial: fechas válidas y ausencia de superposición confirmada." : name === "Mantenimiento" ? "Un mantenimiento activo retira temporalmente el vehículo de disponibilidad." : name === "Recomendación" ? "Registrar trazabilidad sin información sensible innecesaria." : "" }, n++);
      }
    }
    if (title === "Recolección de requisitos") addTable(p, researchTable, n++);
  }

  addBullets(p, { title: "Bibliografía [1]–[6]", section: "Bibliografía", fontSize: 16, bullets: [
    `[1] CONAMYPE. 35 años impulsando el desarrollo de las MYPE. ${refs[1]}`,
    `[2] Ministerio de Turismo. Transporte turístico. ${refs[2]}`,
    `[3] CONAMYPE, KOICA y PNUD. Canastas Digitales MYPE 360. ${refs[3]}`,
    `[4] Asamblea Legislativa. Decreto 144, Ley para la Protección de Datos Personales. ${refs[4]}`,
    `[5] Microsoft Learn. ASP.NET Core. ${refs[5]}`,
    `[6] Microsoft Learn. Entity Framework. ${refs[6]}`,
  ], citations: [1,2,3,4,5,6], footer: "Fecha de consulta: 19 de agosto de 2026." }, n++);
  addBullets(p, { title: "Bibliografía [7]–[11]", section: "Bibliografía", fontSize: 16, bullets: [
    `[7] Docker Docs. Introduction. ${refs[7]}`,
    `[8] Microsoft Learn. Scaling in Azure Container Apps. ${refs[8]}`,
    `[9] Microsoft Learn. Azure Database for PostgreSQL Flexible Server. ${refs[9]}`,
    `[10] Microsoft Azure. Azure for Students. ${refs[10]}`,
    `[11] Microsoft Learn. Responsible AI practices for Azure OpenAI models. ${refs[11]}`,
  ], citations: [7,8,9,10,11], footer: "Fecha de consulta: 19 de agosto de 2026." }, n++);

  const close = p.slides.add();
  close.background.fill = WHITE;
  textbox(close, "Rentavía", 72, 130, 1136, 60, { fontSize: 48, bold: true, alignment: "center" });
  textbox(close, "Una fuente única, trazable y segura para coordinar la operación de una pequeña agencia de renta de vehículos.", 170, 230, 940, 100, { fontSize: 25, alignment: "center" });
  line(close, 380, 370, 520, BLACK, 2);
  textbox(close, "Preguntas", 72, 410, 1136, 50, { fontSize: 34, bold: true, alignment: "center" });
  textbox(close, "Los beneficios e indicadores deberán validarse durante la Fase II.", 210, 535, 860, 34, { fontSize: 17, color: MID, alignment: "center" });
  addHint(close, "Conclusiones", "Resultados", n);
  setNotes(close);

  const pptx = await PresentationFile.exportPptx(p);
  await fs.mkdir(path.dirname(OUT), { recursive: true });
  await pptx.save(OUT);
  console.log(JSON.stringify({ output: OUT, slides: p.slides.items.length }));
}

build().catch((err) => {
  console.error(err);
  process.exitCode = 1;
});
