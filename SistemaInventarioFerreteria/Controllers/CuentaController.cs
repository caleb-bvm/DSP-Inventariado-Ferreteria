using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioFerreteria.Data;
using SistemaInventarioFerreteria.Models;

namespace SistemaInventarioFerreteria.Controllers
{
    [AllowAnonymous]
    public class CuentaController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public CuentaController(
            IConfiguration configuration,
            ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public IActionResult Login()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            var rol = ObtenerRol(modelo.Usuario, modelo.Contrasena);
            if (rol == null)
            {
                ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos.");
                return View(modelo);
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, modelo.Usuario),
                new(ClaimTypes.Role, rol)
            };

            if (rol == "Operador")
            {
                var idSucursal = _configuration.GetValue<int?>(
                    "Login:Operador:IdSucursal");
                var sucursal = idSucursal.HasValue
                    ? await _context.Sucursales
                        .AsNoTracking()
                        .FirstOrDefaultAsync(s =>
                            s.IdSucursal == idSucursal.Value && s.Activo)
                    : null;

                if (sucursal == null)
                {
                    ModelState.AddModelError(string.Empty,
                        "El operador no tiene una sucursal activa asignada. " +
                        "Solicite al administrador revisar la configuración.");
                    return View(modelo);
                }

                claims.Add(new Claim("SucursalId",
                    sucursal.IdSucursal.ToString()));
                claims.Add(new Claim("SucursalNombre", sucursal.Nombre));
            }

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                new AuthenticationProperties
                {
                    IsPersistent = modelo.Recordarme,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
                });

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(Login));
        }

        public IActionResult AccesoDenegado()
        {
            return View();
        }

        private string? ObtenerRol(string usuario, string contrasena)
        {
            var administrador = _configuration["Login:Administrador:Usuario"];
            var claveAdministrador = _configuration["Login:Administrador:Contrasena"];
            var operador = _configuration["Login:Operador:Usuario"];
            var claveOperador = _configuration["Login:Operador:Contrasena"];

            if (usuario == administrador && contrasena == claveAdministrador)
            {
                return "Administrador";
            }

            if (usuario == operador && contrasena == claveOperador)
            {
                return "Operador";
            }

            return null;
        }
    }
}
