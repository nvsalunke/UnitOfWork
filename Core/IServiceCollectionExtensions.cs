using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Multi_UnitOfWork.Core
{
	public static class IServiceCollectionExtensions
	{
		public static void AddUnitOfWork<T>(this IServiceCollection services) where T : DbContext
		{
			services.AddScoped<IUnitOfWork<T>, UnitOfWork<T>>();
			services.AddScoped<IUnitOfWork>(provider => provider.GetService<IUnitOfWork<T>>());
		}

		public static void AddUnitOfWorkOption(this IServiceCollection services, Action<UnitOfWorkOptionsBuilder> optionAction)
		{
			var optionBuilder = new UnitOfWorkOptionsBuilder();
			optionAction.Invoke(optionBuilder);

			services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
			services.AddSingleton(typeof(UnitOfWorkOptions), optionBuilder.Options);
			services.AddScoped<IUnitOfWorkMultiContext, UnitOfWorkMultiContext>();
		}
	}
}