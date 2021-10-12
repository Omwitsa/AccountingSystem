using AccountingSystem.IProvider;
using AccountingSystem.Model;
using AccountingSystem.Provider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystem
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
			services.AddDbContext<AccountingDbContext>(options => options.UseSqlServer(Configuration["Data:ConnectionStrings"]));
            services.AddTransient<IAccountingProvider, AccountingProvider>();
            services.AddTransient<ICustomersProvider, CustomersProvider>();
            services.AddTransient<ISystemProvider, SystemProvider>();
            services.AddTransient<IVendersProvider, VendersProvider>();
            services.AddTransient<IProvider.IConfigurationProvider, Provider.ConfigurationProvider>();
            services.AddRazorPages();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
			});

			UpdateDatabase(app);
		}

		private static void UpdateDatabase(IApplicationBuilder app)
		{
			//GlobalDiagnosticsContext.Set("connectionString", Configuration.GetConnectionString("Campus360Entities"));
			using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetRequiredService<AccountingDbContext>();
				context.Database.Migrate();
				//context.EnsureDatabaseSeeded();
				// context.Database.EnsureCreated();
			}
		}
	}
}
