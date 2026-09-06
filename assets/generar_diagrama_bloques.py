from pathlib import Path
from PIL import Image, ImageDraw, ImageFont


ROOT = Path(__file__).resolve().parent
OUT = ROOT / "diagrama_bloques_arquitectura.png"
W, H = 1600, 940


def font(size: int, bold: bool = False):
    name = "arialbd.ttf" if bold else "arial.ttf"
    return ImageFont.truetype(str(Path("C:/Windows/Fonts") / name), size)


img = Image.new("RGB", (W, H), "#f5f8fb")
d = ImageDraw.Draw(img)


def centered(text, xy, fnt, fill):
    box = d.textbbox((0, 0), text, font=fnt)
    d.text((xy[0] - (box[2] - box[0]) / 2, xy[1]), text, font=fnt, fill=fill)


def box(x0, y0, x1, y1, fill, stroke):
    d.rounded_rectangle((x0 + 8, y0 + 9, x1 + 8, y1 + 9), 22, fill="#d6dee7")
    d.rounded_rectangle((x0, y0, x1, y1), 22, fill=fill, outline=stroke, width=4)


def arrow(points):
    d.line(points, fill="#326b9b", width=5, joint="curve")
    x, y = points[-1]
    px, py = points[-2]
    if abs(x - px) >= abs(y - py):
        tip = [(x, y), (x - 18, y - 10), (x - 18, y + 10)] if x > px else [(x, y), (x + 18, y - 10), (x + 18, y + 10)]
    else:
        tip = [(x, y), (x - 10, y - 18), (x + 10, y - 18)] if y > py else [(x, y), (x - 10, y + 18), (x + 10, y + 18)]
    d.polygon(tip, fill="#326b9b")


centered("Diagrama de bloques de la solución propuesta", (800, 35), font(42, True), "#17365d")
centered("Sistema web inteligente para la gestión de renta de vehículos", (800, 88), font(22), "#425466")

box(65, 225, 325, 410, "#ffffff", "#6ba4cf")
centered("Usuarios", (195, 248), font(25, True), "#17365d")
for y, text in [(302, "Cliente"), (338, "Empleado"), (374, "Administrador")]:
    centered(text, (195, y), font(20), "#253648")

box(430, 170, 810, 465, "#e8f3fb", "#326b9b")
centered("Aplicación web", (620, 196), font(25, True), "#17365d")
centered("ASP.NET Core MVC / API", (620, 237), font(18), "#425466")
d.line((465, 276, 775, 276), fill="#91b7d3", width=2)
for y, text in [(304, "Autenticación y roles"), (340, "Flota y mantenimiento"), (376, "Reservas y alquileres"), (412, "Reportes y auditoría")]:
    centered(text, (620, y), font(20), "#253648")

box(930, 145, 1230, 325, "#ffffff", "#4c9b77")
centered("Capa de datos", (1080, 174), font(25, True), "#17365d")
centered("Entity Framework Core", (1080, 224), font(20), "#253648")
centered("PostgreSQL", (1080, 266), font(20), "#253648")

box(930, 390, 1230, 595, "#fff8e8", "#d19a32")
centered("Servicio de IA", (1080, 416), font(25, True), "#17365d")
centered("Recomendador de vehículos", (1080, 466), font(20), "#253648")
centered("Microsoft Foundry /", (1080, 518), font(18), "#425466")
centered("Azure OpenAI", (1080, 550), font(18), "#425466")

box(1310, 245, 1540, 485, "#f0ecfb", "#7957a8")
centered("Servicios externos", (1425, 274), font(23, True), "#17365d")
for y, text in [(342, "Correo"), (384, "Almacenamiento"), (426, "Monitoreo")]:
    centered(text, (1425, y), font(19), "#253648")

arrow([(325, 317), (430, 317)])
arrow([(810, 260), (930, 260)])
arrow([(810, 375), (870, 375), (870, 492), (930, 492)])
arrow([(1230, 362), (1310, 362)])

d.rounded_rectangle((323, 714, 1293, 859), 22, fill="#cbd5e0")
d.rounded_rectangle((315, 705, 1285, 850), 22, fill="#17365d")
centered("Infraestructura y despliegue", (800, 728), font(27, True), "#ffffff")
centered("Docker · Azure Container Apps · Azure Database for PostgreSQL", (800, 773), font(22), "#e6f1fa")
centered("HTTPS · secretos protegidos · registros · copias de seguridad", (800, 812), font(19), "#bcd7eb")
arrow([(620, 465), (620, 705)])
arrow([(1080, 595), (1080, 705)])

centered("Flujo principal: usuario → aplicación → datos / IA → respuesta y registro de la operación", (800, 888), font(18), "#425466")
img.save(OUT, format="PNG", optimize=True)
print(OUT)
