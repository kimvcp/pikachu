using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agoda.ApplicationInsights.AspNetCore;
using Agoda.Pikachu.Api.Property;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Agoda.Pikachu.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get;}
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPropertyRepository, PropertyRepository>();
            services.AddSingleton<IHotelPropertyService, HotelPropertyService>();
            services.AddSingleton<IBlackListRepository, BlackListRepository>();
            services.AddSingleton<IDatabaseSettings>(new DatabaseSettings()
            {
                ExampleDbConnectionString = Configuration.GetSection("DbConnectionString").Value
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddApplicationInsightsTelemetry("interns2019");
            var sp = services.BuildServiceProvider();
            var telemetryConfiguration = sp.GetService<TelemetryConfiguration>();
            telemetryConfiguration.UseAgodaInsights("pikachu");

            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Example Website API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // disable libraries
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Example Website API V1");
            });
        }
    }
}
