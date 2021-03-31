using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HangFire.Services
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddHangfire(configuration => { configuration.UseInMemoryStorage(); });
		}

		public void Configure(IApplicationBuilder application, IWebHostEnvironment environment)
		{
			if (environment.IsDevelopment())
			{
				application.UseDeveloperExceptionPage();
			}

			application.UseRouting();
			application.UseEndpoints(endpoints =>
			{
				endpoints.MapGet("/", async context =>
				{
					await context.Response.WriteAsync("Test Hangfire WebApp! Access /hangfire url");
				});
			});

			application.UseHangfireDashboard();
			application.UseHangfireServer();

			Process.Start();
		}
	}
}
