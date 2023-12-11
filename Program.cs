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
