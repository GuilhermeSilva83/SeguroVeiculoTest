using Microsoft.EntityFrameworkCore;

using SeguroVeiculo.Domain.Aggs.SeguradoAgg;
using SeguroVeiculo.Domain.Aggs.SeguroAgg;
using SeguroVeiculo.Domain.Aggs.VeiculoAgg;
using SeguroVeiculo.Domain.Services;
using SeguroVeiculo.Infra.Repository;
using SeguroVeiculo.Seedwork.Domain;
using SeguroVeiculo.WebApi.Map;

using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(_ =>
{
    _.AddProfile(new EntityToDtoProfile());
    _.AddProfile(new DtoToEntityProfile());
});

var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

ConfigServices(builder.Services, configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



void ConfigServices(IServiceCollection services, IConfigurationRoot configuration)
{
    services.AddScoped<ISeguroRepository, SeguroRepository>();
    services.AddScoped<ISeguradoRepository, SeguradoRepository>();
    services.AddScoped<IVeiculoRepository, VeiculoRepository>();

    services.AddSingleton<ICalculoValorSeguroService, CalculoValorSeguroService>();


    services.AddDbContext<IUnitOfWork, MainContextUnitOfWork>(o =>
    {
        var opt = o.UseSqlServer(configuration.GetConnectionString("Default"), opt =>
        {
            opt.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
        });
    });
}


public partial class Program {



}