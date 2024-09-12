using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Sales_Management.Context;
using Sales_Management.Interface;
using Sales_Management.Models;
using Sales_Management.Repository;
using Sales_Management.Service;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Sales Management API", Version = "v1" });
        });

        // Configure Database Context
        builder.Services.AddDbContext<ApplicationDbContext>(opts =>
        {
            opts.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnectionString"));
        });

        // Register Repositories and Services for Dependency Injection
        builder.Services.AddScoped<IRepository<string, Sale>, SaleRepository>();
        builder.Services.AddScoped<ISaleService, SaleService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();
        app.Run();
    }
}
