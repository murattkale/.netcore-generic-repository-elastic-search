using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using muratkale.Auth.Bearer;
using Swashbuckle.AspNetCore.Swagger;

namespace WebUI
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		private IServiceCollection services;

		public Startup(IConfiguration configuration, IHostingEnvironment env)
		{
			Configuration = new ConfigurationBuilder()
		   .SetBasePath(env.ContentRootPath)
		   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
		   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
		   .AddEnvironmentVariables()
		   .Build();
		}


		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();
			app.UseSession();


			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=User}/{action=Index}/{id?}");
			});
		}





		public void ConfigureServices()
		{
			services.AddMvc();
			services.AddJwt(Configuration);

			services.Configure<CookiePolicyOptions>(options =>
			{
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddMvc();
			services.AddSession(options => {
				options.IdleTimeout = TimeSpan.FromMinutes(20);
			});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);



			#region Connections
			var redisPort = Configuration.GetSection("Logging:ConnectionStrings:redisPort").Value;
			var redisInstanceName = Configuration.GetSection("Logging:ConnectionStrings:redisInstanceName").Value;
			var _EFDataContext = Configuration.GetSection("Logging:ConnectionStrings:EFDataContext").Value;
			var _MySqlContext = Configuration.GetSection("Logging:ConnectionStrings:MySqlContext").Value;
			#endregion

			services.AddDistributedRedisCache(option =>
			{
				option.Configuration = redisPort;
				option.InstanceName = redisInstanceName;
			});

			services.AddDbContext<EFContext>(options =>
			{
				try
				{
					options.UseSqlServer(_EFDataContext);
					options.ConfigureWarnings(wb =>
					{
						//By default, in this application, we don't want to have client evaluations
						wb.Log(RelationalEventId.QueryClientEvaluationWarning);
					});
				}
				catch (Exception)
				{
					throw;
				}
			}
			);
			////services.AddDbContext<MySqlContext>(o => o.UseMySql(_MySqlContext));
			//services.AddDbContext<EFContext>(options => options.UseInMemoryDatabase(_EFDataContext));
			//services.AddTransient<IStickerRepository, StickerRepository>();

			//#region Swagger
			//services.AddSwaggerGen(c =>
			//{
			//	c.SwaggerDoc("v1", new Info
			//	{
			//		Title = "Murat Kale Title",
			//		Version = "v1.0",
			//		Description = "Murat Kale API Description",
			//		Contact = new Contact
			//		{
			//			Name = "Murat Kale Contact",
			//			Email = "murat.kale9339@gmail.com",
			//			Url = "https://muratkaleblog.wordpress.com/"
			//		},
			//		License = new License
			//		{
			//			Name = "Murat Kale License",
			//			Url = "https://muratkaleblog.wordpress.com/"
			//		}
			//	});
			//});
			//#endregion

		}


		//public void Configure(
		//	  IApplicationBuilder app
		//	, IHostingEnvironment env
		//	, ILoggerFactory loggerFactory
		//	)
		//{

		//	app.UseAuthentication();

		//	loggerFactory.AddConsole(Configuration.GetSection("Logging"));
		//	loggerFactory.AddDebug();

		//	if (env.IsDevelopment())
		//	{
		//		app.UseDeveloperExceptionPage();
		//		app.UseBrowserLink();

		//		#region Services Map
		//		app.Map("/allservices", builder => builder.Run(async context =>
		//		{
		//			var sb = new StringBuilder();
		//			sb.Append("<h1>All Services</h1>");
		//			sb.Append("<table><thead>");
		//			sb.Append("<tr><th>Type</th><th>Lifetime</th><th>Instance</th></tr>");
		//			sb.Append("</thead><tbody>");
		//			foreach (var svc in services)
		//			{
		//				sb.Append("<tr>");
		//				sb.Append($"<td>{svc.ServiceType.FullName}</td>");
		//				sb.Append($"<td>{svc.Lifetime}</td>");
		//				sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
		//				sb.Append("</tr>");
		//			}
		//			sb.Append("</tbody></table>");
		//			await context.Response.WriteAsync(sb.ToString());
		//		}));
		//		#endregion
		//	}

		//	app.UseStaticFiles();
		//	app.UseMvc();
		//	app.UseSwagger();

		//	app.UseSwaggerUI(c =>
		//	{
		//		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Murat Kale ASP.NET Core RESTful API v1");
		//	});
		//}







		

	}
}