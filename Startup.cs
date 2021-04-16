using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_pract.Models.NorthwindDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Multi_UnitOfWork.Core;
using Multi_UnitOfWork.Models.Config;
using Multi_UnitOfWork.Models.SakilaDb;
using Multi_UnitOfWork.Services;

namespace Multi_UnitOfWork
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<ApplicationSettings>(Configuration);
			services.AddDbContext<NorthwindContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("NorthwindDbConnection"))
			);

			services.AddDbContext<sakilaContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("SakilaDbConnection"))
			);

			services.AddUnitOfWorkOption(optionBuilder =>
			{
				optionBuilder.AddUnitOfWork<NorthwindContext>("NorthwindDbConnection");
				optionBuilder.AddUnitOfWork<sakilaContext>("SakilaDbConnection");
			});

			services.AddServiceModule();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			//app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
