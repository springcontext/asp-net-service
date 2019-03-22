using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspConsumer.Domains.Context;
using AspConsumer.Jobs;
using AspConsumer.Repositories;
using AspConsumer.Repositories.Impl;
using AspConsumer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AspConsumer
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
            string connectionString = Configuration["database:connectionString"];
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<HeroContext>(options => options.UseMySql(connectionString));
            services.AddScoped<IHeroService, HeroService>();
            services.AddScoped<IHeroRepository, HeroRepository>();
            services.AddHostedService<IHealthCheckTask>().AddLogging();
            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, HeroContext heroContext, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseHealthChecks("/health");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
