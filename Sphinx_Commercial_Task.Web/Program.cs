using Microsoft.EntityFrameworkCore;
using Sphinx_Commercial_Task.Data.Context;
using Sphinx_Commercial_Task.Repository;
using System.Reflection;

namespace Sphinx_Commercial_Task.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();

			builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
			builder.Services.AddDbContext<ApplicationDatabaseContext>(options =>
			{

				options.UseLazyLoadingProxies().

				UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


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

			app.UseAuthorization();

			app.MapRazorPages();
			app.MapControllers();
			app.Run();
		}
	}
}
