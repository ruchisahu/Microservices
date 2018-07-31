using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProductCatalog.Data;
using Microsoft.AspNetCore.Owin;
using Swashbuckle.AspNetCore.Swagger;


namespace ProductCatalog
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
            services.Configure<CatalogSetting>(Configuration);
            services.AddMvc();
            services.AddDbContext<CatalogContext>(

                 options => options.UseSqlServer(Configuration["ConnectionString"]));

            services.AddSwaggerGen(options =>
            {
            options.DescribeAllEnumsAsStrings();
            options.SwaggerDoc("v1" , new Swashbuckle.AspNetCore.Swagger.Info
            {
                Title = "eshoes",
                Version = "v1",
                Description = "Catalog",
                TermsOfService = "Terms Of Services"
            });
        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

               app .UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "ProductCatalog");
            });
                
            app.UseMvc();
        }
    }
}
