using BookStore_01.Data;
using BookStore_01.Data.Repositories;
using BookStore_01.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BookStore_01
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
            //Context
            services.AddDbContext<BookStoreContext>();

            //AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddControllers();

            //NewtonsoftJson
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            //IoC
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //repositories
            services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
            //services
            services.AddScoped<IBookSevice, BookSevice>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IOrderService, OrderService>();

            //loging
            //services.AddLogging();
            services.AddSingleton(typeof(ILogger), typeof(Logger<Startup>));

            //init swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore_01", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore_01 v1"));
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
