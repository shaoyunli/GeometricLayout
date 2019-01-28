using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using GeometricLayout.Services;
using GeometricLayout.Interfaces;
using GeometricLayout.Builders;
using GeometricLayout.Validators;

namespace GeometricLayout
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<ILayoutService, LayoutService>();
            services.AddTransient<ILayoutServiceValidator, LayoutServiceValidator>();
            services.AddTransient<ITriangleConverter, RightTriangleConverter>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Geometric Layout API",
                    Version = "v1",
                    Description = "Geometric Layout Web API.",
                    Contact = new Contact
                    {
                        Name = "Shaoyun Li",
                        Email = "shaoyun.li@gmail.com",
                        Url = "https://www.linkedin.com/in/shaoyunli/"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Geometric Layout API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles(new DefaultFilesOptions
            {
                DefaultFileNames = new List<string> { "index.html" }
            });
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
