using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Spacecrafts.Website.Models;
using Spacecrafts.Website.Services;

namespace Spacecrafts.Website
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
            services.AddRazorPages();
            services.AddControllers();
            services.AddTransient<SpaceCraftJsonService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
                ///This code below shows the basic way of making a WebAPI using low level coding within .Net ASP.Net Core!
                /// 
                //endpoints.MapGet("/spacecrafts",
                //    (context) =>
                //    {
                //        var spacecrafts = app.ApplicationServices.GetService<SpaceCraftJsonService>().GetSpaceCrafts();
                //        var jsonSpaceCrafts = JsonSerializer.Serialize<IEnumerable<SpaceCraft>>(spacecrafts);
                //        return context.Response.WriteAsync(jsonSpaceCrafts);
                //    }
                //                 );
                // });
        }
    }
}
