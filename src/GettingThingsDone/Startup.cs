﻿using GettingThingsDone.ApplicationCore.Services;
using GettingThingsDone.Contract.Interface;
using GettingThingsDone.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GettingThingsDone
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
            var inMemoryDatabaseRoot = new InMemoryDatabaseRoot();
            services.AddDbContext<GettingThingsDoneDbContext>(options => options.UseInMemoryDatabase("GettingThingsDoneDatabase", inMemoryDatabaseRoot));

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IActionService, ActionService>();
            services.AddScoped<IActionRepository, ActionRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}