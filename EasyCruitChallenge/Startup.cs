using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCruitChallenge.DatabaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VueCliMiddleware;
using Microsoft.EntityFrameworkCore;
using EasyCruitChallenge.Logic;
using EasyCruitChallenge.DataAccess;

namespace EasyCruitChallenge
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddTransient<ICandidateLogic, CandidateLogic>();
            services.AddSingleton<ICandidateRepository, CandidateRepository>();

            services.AddDbContext<CandidateDatabaseContext>(options =>
                options.UseInMemoryDatabase("EasyCruit"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSpaStaticFiles();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
               spa.Options.SourcePath = "ClientApp";
            });
        }
    }
}
