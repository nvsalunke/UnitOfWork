using Microsoft.Extensions.DependencyInjection;

namespace Multi_UnitOfWork.Services
{
	public static class ServiceModule
	{
		public static IServiceCollection AddServiceModule(this IServiceCollection services)
		{
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IFilmService, FilmService>();
			return services;
		}
	}
}