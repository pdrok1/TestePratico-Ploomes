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
using Microsoft.AspNetCore.Mvc;
using System.IO;
using API.Middlewares;
using System.Threading.Tasks;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public readonly string SWAGGER_ENDPOINT_PATH = "/swagger/v1/swagger.json";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
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

            services
                .AddAuthentication(options => options.DefaultAuthenticateScheme = "DefaultAuthenticationScheme")
                .AddScheme<BasicAuthenticationOptions, BasicAuthenticationHandler>("DefaultAuthenticationScheme", options => { });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint(SWAGGER_ENDPOINT_PATH, "API v1"); } );

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", (context) => {
                    context.Response.Redirect("/swagger");
                    return Task.FromResult(0);
                });
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
