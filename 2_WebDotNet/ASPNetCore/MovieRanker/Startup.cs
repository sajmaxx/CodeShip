using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Amazon.DynamoDBv2;
using MovieRank.Libs.Mappers;
using MovieRank.Libs.Repositories;
using MovieRanker.Services;

namespace MovieRanker
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            //services.AddMvc();
            services.AddAWSService<IAmazonDynamoDB>();
            AddSingleTons(services);
        }

        private static void AddSingleTons(IServiceCollection services)
        {
            services.AddSingleton<IMovieRankingService, MovieRankingService>();
            services.AddSingleton<IMovieNameRepository, MovieNameRepository>();
            services.AddSingleton<IDBMapper, DBMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
