using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioFerreteria.Data;
using SistemaInventarioFerreteria.Services;

var builder = WebApplication.CreateBuilder(args);

// La consola es suficiente para este proyecto y funciona sin permisos de administrador.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Todas las pantallas requieren iniciar sesión, excepto las marcadas con AllowAnonymous.
builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    options.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Cuenta/Login";
        options.AccessDeniedPath = "/Cuenta/AccesoDenegado";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
    });

// En desarrollo las sesiones se reinician con la aplicación y no dependen
// de claves antiguas guardadas por otro usuario de Windows.
if (builder.Environment.IsDevelopment())
{
    var keysDirectory = new DirectoryInfo(
        Path.Combine(builder.Environment.ContentRootPath, "App_Data", "Keys"));

    builder.Services.AddDataProtection()
        .PersistKeysToFileSystem(keysDirectory)
        .SetApplicationName("SistemaInventarioFerreteria");
}

builder.Services.AddHttpClient<IaService>(client =>
    client.Timeout = TimeSpan.FromSeconds(15));

var connectionString = builder.Configuration.GetConnectionString("ConexionSQL")
    ?? throw new InvalidOperationException(
        "No se encontro la cadena de conexion 'ConexionSQL'.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
