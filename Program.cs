using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SigMonografiasIfma.Data;
using SigMonografiasIfma.Models;

var builder = WebApplication.CreateBuilder(args);


//Conexão com Banco de dados
var connectionString = builder.Configuration.GetConnectionString("VisualStudioConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


//AspNetIdentity
builder.Services.AddIdentity<Funcionario, IdentityRole>(options =>
    {
        
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();
//Configurando propriedades do esquema de autenticação baseado em cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "SigMonografias.Cookies"; //Nome do Cookie
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5); //Tempo de expiração
        options.SlidingExpiration = true;  //Será emitido um novo cookie sempre que um request for precessado e mais da metade da janela de expiração tiver sido transcorrido
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

//métodos do AspnetIdentity 
app.UseAuthentication();
app.UseAuthorization();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
