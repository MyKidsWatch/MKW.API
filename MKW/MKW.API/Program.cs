using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MKW.API.Dependencies;
using MKW.Data.Context;
using MKW.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
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
builder.Services.StartRegisterServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddHttpClient();
#endregion

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<RequestMiddleware>();

app.Run();
