using AutoMapper;
using Data.Entities;
using Domain.Helpers;
using Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApi.Controllers;

namespace WebApi
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
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddDbContext<WebApiDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DbConnectionString")));

            // AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            // Set up dependency injection for controller's logger
            services.AddScoped<ILogger, Logger<AlbumsController>>();

            // Services / Repositories
            services.AddTransient<IAlbumRepository, AlbumRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            //app.UseAuthentication();
            
            //app.UseHttpsRedirection();

            app.UseMvc();
        }

    }
}
