
using AcortadorApi.Configuration;
using AcortadorApi.Middlewares;
using AcortadorApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllersWithViews()
 .AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CORS_AcortadorApi",
    builder =>
    {
        builder.WithOrigins("*")
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
    });
});

builder.Services.AddAutoMapper(typeof(Program));
//CONFIGURACION SWAGGER
builder.Services.AddConfSwagger();
//CONFIGURACION AUTH
builder.Services.AddConfAuthentication(configuration);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//CONFIGURACION DBCONTEX
builder.Services.AddConfDbContextLog(configuration);
builder.Services.AddConfDbContextSAADS(configuration);
//CONFIGURACION HTTP 
builder.Services.AddConfRepositorioHTTP(configuration);
//configurar base de datos
builder.Services.AddDbContext<AcortadorContext>(Context =>
{
    Context.UseSqlServer("Server=172.16.248.33; Database=Acortador; User=Practicante; Password=Pr4ct1c4nt3*");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseLoguearHTTPMiddleware();
app.UseCors("CORS_AcortadorApi");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
