using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PATITAS.Datos;


var builder = WebApplication.CreateBuilder(args);

//Configuraci�n a la base de datos SQLServer
builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(
       builder.Configuration.GetConnectionString("DefaultConnection")));
//Agregar el servicio Identity a la aplicaci�n
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

//Esta l�nea es para la url de retorno al acceder
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/Cuenta/Acceso");
    options.AccessDeniedPath = new PathString("/Cuenta/Bloqueado");
});

//Estas son opciones de configuraci�n del identity
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequireLowercase = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
    options.Lockout.MaxFailedAccessAttempts = 3;
});



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


