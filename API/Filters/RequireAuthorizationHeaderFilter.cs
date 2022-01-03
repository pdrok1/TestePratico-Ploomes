using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace API.Filters
{
    public class RequireAuthorizationHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Security ??= new List<OpenApiSecurityRequirement>();

            var scheme = new OpenApiSecurityScheme { 
                Reference = new OpenApiReference { 
                    Type = ReferenceType.SecurityScheme, 
                    Id = "bearer" 
                } 
            };

            operation.Security.Add(new OpenApiSecurityRequirement
            {
                [scheme] = new List<string>()
            });

            /*
            operation.Parameters.Add(new OpenApiParameter
            {
                UnresolvedReference = false,
                Name = "Authorization",
                In = ParameterLocation.Header,
                Description = "access token",
                Required = true,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("Bearer ")
                }
            });
            */
        }
    }
}
