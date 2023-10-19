
using CookBook.Models;
using CookBook.Repositories;
using CookBook.Services;
using Microsoft.EntityFrameworkCore;

namespace CookBook
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<RecipeContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("RecipeContext")));

			//Services
			builder.Services.AddTransient<IRecipeService, RecipeService>();

			//Repositories
			builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

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
		}
	}
}