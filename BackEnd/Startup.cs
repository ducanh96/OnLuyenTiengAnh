﻿using PracticeEnglish.Middlewares;
using PracticeEnglish.Models;
using aspnetcoregraphql.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using PracticeEnglish.Business.Interface;
using PracticeEnglish.Data.Interface;
using PracticeEnglish.Data.Implement;
using PracticeEnglish.Business.Implement;

namespace PracticeEnglish
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            // Add framework services.
            services.AddMvc();

            // Add application services.
            services.AddTransient<IProductBusiness, ProductBusiness>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryBusiness, CategoryBusiness>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IChuDeRepository, ChuDeRepository>();
            services.AddTransient<IDeThiRepository, DeThiRepository>();
            services.AddTransient<ICauHoiRepository, CauHoiRepository>();
            services.AddTransient<IDeThiBusiness, DeThiBussiness>();
            services.AddTransient<IChuDeBusiness, ChuDeBusiness>();
            services.AddTransient<ICauHoiBusiness, CauHoiBusiness>();
            services.AddTransient<INgheBusiness, NgheBusiness>();
            services.AddTransient<INgheRepository, NgheRepository>();
            services.AddTransient<IDocRepository, DocRepository>();
            services.AddTransient<IDocBusiness, DocBusiness>();

            services.AddScoped<EasyStoreQuery>();
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddTransient<CategoryType>();
            services.AddTransient<ProductType>();
            var sp = services.BuildServiceProvider();
            services.AddScoped<ISchema>(_ => new EasyStoreSchema(type => (GraphType)sp.GetService(type)) { Query = sp.GetService<EasyStoreQuery>() });
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "ASP.NET Core RESTful API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors( options => options.WithOrigins("http://localhost:57912").AllowAnyMethod() );
            loggerFactory.AddFile("C:/@Logs/aspnetcore-rest-api-with-dapper-{Date}.txt");

            app.UseMiddleware(typeof(GlobalExceptionMiddleware));
            app.UseMvc();
            
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASP.NET Core RESTful API v1");
            });
        }
    }
}