using Microsoft.EntityFrameworkCore;
using MKW.API.Dependencies;
using MKW.Data.Infra;

var builder = WebApplication.CreateBuilder(args);

#region Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.StartRegisterServices();
builder.Services.AddHttpContextAccessor();

var connString = builder.Configuration.GetConnectionString("DefaultConnString");
builder.Services.AddDbContext<MKWContext>(options =>
    options.UseSqlServer(connString)
);
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
