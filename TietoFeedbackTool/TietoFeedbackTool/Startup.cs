using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Infrastructure.Services;
using TietoFeedbackTool.Persistence;

namespace TietoFeedbackTool
{
	public class Startup
	{
		public string ConnetionString { get; set; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			ConnetionString = Configuration.GetConnectionString("TietoFeedbackToolDB");
		}
		readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
		public IConfiguration Configuration { get; }
		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy(MyAllowSpecificOrigins,
					builder =>
					{
						builder.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader();
					}
				);
			});
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/dist";
			});
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddDbContext<ITietoFeedbackToolContext, TietoFeedbackToolContext>(options =>
			{
				options.UseSqlServer(ConnetionString, b => b.MigrationsAssembly("TietoFeedbackTool"));
			});
			// Register the Swagger generator
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info
				{
					Title = "TietoFeedbackTool API",
					Version = "pre-alpha version",
					Description = "API for Feedback Tool",
					License = new License
					{
						Name = "APACHE LICENSE, VERSION 2.0",
						Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0").ToString(),
					}
				});
				// Set the comments path for the Swagger JSON and UI.;
				var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
				var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
				var commentsFile = Path.Combine(baseDirectory, commentsFileName);

				c.IncludeXmlComments(commentsFile);
			});
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
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "~Pre-alpha~ TietoFeedbackTool API");
			});
			app.UseCors(MyAllowSpecificOrigins);
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseSpaStaticFiles();
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				// To learn more about options for serving an Angular SPA from ASP.NET Core,
				// see https://go.microsoft.com/fwlink/?linkid=864501
				spa.Options.SourcePath = "ClientApp";
				if (env.IsDevelopment())
				{
					spa.UseAngularCliServer(npmScript: "start");
				}
			});
		}
	}
}
