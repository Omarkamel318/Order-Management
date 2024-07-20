using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderManagment.APIs.Helpers;
using OrderManagment.BLL.Iservices;
using OrderManagment.BLL.Services;
using OrderManagment.DAL.Data;
using OrderManagment.DAL.IRepository;
using OrderManagment.DAL.Models;
using OrderManagment.DAL.Repository;

namespace OrderManagment.APIs
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();

			#region App service

			builder.Services.AddScoped<IGenericRepository<Order>,GenericRepository<Order>>();
			builder.Services.AddScoped<IGenericRepository<Product>,GenericRepository<Product>>();
			builder.Services.AddScoped<IGenericRepository<OrderItem>,GenericRepository<OrderItem>>();
			builder.Services.AddScoped<IGenericRepository<Invoice>,GenericRepository<Invoice>>();
			builder.Services.AddScoped<IOrderService, OrderService>();
			builder.Services.AddScoped<IOrderRepository, OrderRepository>();
			builder.Services.AddAutoMapper(typeof(MappingProfile));
			#endregion
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();

			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("default"))
				);

			var app = builder.Build();

			#region Migration
			using var scope = app.Services.CreateScope();

			var services = scope.ServiceProvider;

			var _dbcontext = services.GetRequiredService<ApplicationDbContext>();
			var loggerFactory = services.GetRequiredService<ILoggerFactory>();


			//try
			//{
			//	await _dbcontext.Database.MigrateAsync();
			//}
			//catch (Exception ex)
			//{

			//	var logger = loggerFactory.CreateLogger<Program>();
			//	logger.LogError(ex, "error occur during migration");
			//}

			#endregion




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
		}
	}
}
