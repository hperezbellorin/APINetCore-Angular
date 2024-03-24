using NetCoreAngular.Server.Servicios;
    using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using NetCoreAngular.Server.Models;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

string cors = "ConfigurarCors";

// Add services to the container.

builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: cors, builder =>
        {
            builder.WithMethods("*");
            builder.WithHeaders("*"); // permitir peticiones post
            builder.WithOrigins("*"); // permitir peticiones get
        });
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioAPI, UsuarioApiServicio>();
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddNLog("nlog.config");
});
builder.Services.AddScoped<IProductos, ProductosServicio>();
builder.Services.AddScoped<IClientes, ClientesServicio>();


//JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:ClaveSecreta"]))
    };
});






var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(cors);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
