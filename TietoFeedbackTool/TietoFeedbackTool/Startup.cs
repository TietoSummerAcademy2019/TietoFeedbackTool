using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;
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

		public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			//services.AddScoped<ISurveyRepository, SurveyRepository>();
			//services.AddScoped<IAccountRepository, AccountRepository>();
			//services.AddScoped<IOpenPuzzleAnswerRepository, OpenPuzzleAnswerRepository>();
			//services.AddScoped<IClosePuzzleAnswerRepository, ClosePuzzleAnswerRepository>();
			//services.AddScoped<IClosePuzzlePossibilityRepository, ClosePuzzlePossibilityRepository>();
			services.AddDbContext<ITietoFeedbackToolContext, TietoFeedbackToolContext>(options =>
			{
				options.UseSqlServer(ConnetionString, b => b.MigrationsAssembly("TietoFeedbackTool"));
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
