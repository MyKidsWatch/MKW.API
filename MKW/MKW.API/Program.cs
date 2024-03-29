﻿#region Using
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MKW.API.Dependencies;
using MKW.Data.Context;
using MKW.Middleware;
using Serilog;
using Stripe;
using System.Reflection;
#endregion

#region Builder
var builder = WebApplication.CreateBuilder(args);
#endregion

#region secrets
builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true);
#endregion

#region Controllers & Endpoints
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
#endregion

#region Swagger
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "MyKidsWatch", Version = "v1" });
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
                "JWT Authorization Header\r\n\r\n" +
                "Informe seu token segundo o formato: 'Bearer [Token]'.\r\n\r\n" +
                "Exemplo: 'Bearer ABC123DFG456'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
     });
});
#endregion

#region DbContext
var connString = builder.Configuration.GetConnectionString("DefaultConnString");
builder.Services.AddDbContext<MKWContext>(options =>
{
    options.UseSqlServer(connString);
    options.UseLazyLoadingProxies();
}
);
#endregion

#region IoC
builder.Services.StartRegisterServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region Stripe
StripeConfiguration.ApiKey = builder.Configuration["API:Stripe:Key"];
#endregion

#region Serilog
Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .WriteTo.File("logs/MKW.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();
#endregion

#region Build & Run App
var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseCors(options =>
    options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<RequestMiddleware>();

Log.Debug("{Data}", "App started");

app.Run();
#endregion
