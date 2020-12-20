using ClientInfoSystem.Core.Entities;
using ClientInfoSystem.Core.RepositoryInterfaces;
using ClientInfoSystem.Core.ServiceInterfaces;
using ClientInfoSystem.Infrastructure.Data;
using ClientInfoSystem.Infrastructure.Repository;
using ClientInfoSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInfoSystem.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClientInfoSystem.API", Version = "v1" });
            });
            // DbContext set up
            services.AddDbContext<ClientInfoSysDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(("ClientInfoSysDbConnection"))));

            // Add Dependency Injection for Repo
            services.AddScoped<IAsyncRepository<Clients>, EfRepository<Clients>>();
            services.AddScoped<IAsyncRepository<Employees>, EfRepository<Employees>>();
            services.AddScoped<IAsyncRepository<Interactions>, EfRepository<Interactions>>();


            // Add Dependency Injection for Service
            services.AddScoped<IClientsService, ClientsService>();
            services.AddScoped<IEmployeesService, EmployeesService>();
            services.AddScoped<IInteractionsService, InteractionsService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClientInfoSystem.API v1"));
            }
            // Resolving CORS for the frontend access to APIs
            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration.GetValue<string>("clientSPAUrl")).AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
