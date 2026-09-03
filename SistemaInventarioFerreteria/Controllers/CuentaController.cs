using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaInventarioFerreteria.Models;

namespace SistemaInventarioFerreteria.Controllers
{
    [AllowAnonymous]
    public class CuentaController : Controller
    {
        private readonly IConfiguration _configuration;

        public CuentaController(IConfiguration configuration)
        {
            _configuration = configuration;
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
