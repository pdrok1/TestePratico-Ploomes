using API.Filters;
using BusinessLogic.Actions.CreateMessage;
using BusinessLogic.Actions.UpsertClient;
using BusinessLogic.Repositories;
using Infrastructure;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.Threading;

namespace API
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });
                c.OperationFilter<RequireAuthorizationHeaderFilter>();
            });

            var assembly = InjectionHelpers.GetApplicationAssembly();

            services.AddMediatR(assembly);
            //services.Configure<MongoDBSettings>(Configuration.GetSection("MongoDBSettings"));

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<CounterRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"); } );

            app.Use(async (context, next) =>
            {
                if (context.Request.Headers.TryGetValue("Authorization", out var bearer) && bearer.ToString() == "Bearer 908123u9132r187js1a289a8")
                    await next();
                else
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    throw new ApplicationException("You are not allowed to see this.");
                }
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }

    public static class InjectionHelpers
    {
        public static Assembly GetApplicationAssembly()
            => Assembly.Load(AssemblyName.GetAssemblyName(AppDomain.CurrentDomain.BaseDirectory + "BusinessLogic.dll"));
    }
}
