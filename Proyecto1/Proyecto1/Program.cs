using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Proyecto1.Auth;
using Proyecto1.Configuration;
using Proyecto1.Data;
using Proyecto1.Helpers;
using Proyecto1.Repositorios;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped<IMostrarMensajes, MostrarMensajes>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:63629/api/") });
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<ProveedorAutenticacionJWT>();
builder.Services.AddScoped<AuthenticationStateProvider, ProveedorAutenticacionJWT>(
    provider => provider.GetRequiredService<ProveedorAutenticacionJWT>());
builder.Services.AddScoped<ILoginService, ProveedorAutenticacionJWT>(
   provider => provider.GetRequiredService<ProveedorAutenticacionJWT>());
builder.Services.AddScoped<RenovadorToken>();

builder.Services.AddScoped<IRepositorio, Repositorio>();




//CONFIGURACION HTTP 
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddConfRepositorioHTTP(configuration);




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
