using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Webapp.Services;
using Webapp.Utilities;

namespace Webapp
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddDefaultPolicy(policy =>
				{
					policy.WithOrigins("https://www.freecodecamp.org")
						  .WithMethods("GET", "POST")
						  .AllowAnyHeader();
				});
			});

			services.AddControllers();

			services.AddHttpClient<IDomainValidatorService, DomainValidatorService>();
			services.AddSingleton<IShortUrlService, ShortUrlService>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app.UseCors();

			app.UseRouting();

			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
		}
	}
}