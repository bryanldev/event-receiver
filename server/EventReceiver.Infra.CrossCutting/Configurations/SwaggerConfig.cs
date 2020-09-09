using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace EventReceiver.Infra.CrossCutting.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "EventReceiver API",
                        Version = "v1",
                        Description = "API Rest created on ASP.NET Core 3.1, " +
                                      "able to receive and save events from sensors."
                    });
                
                // Set the comments path for the Swagger JSON and UI.
                const string xmlFile = "EventReceiver.Application.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
        
        public static void UseSwaggerInj(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventReceiver API");
                c.DocumentTitle = "EventReceiver API";
                c.DocExpansion(DocExpansion.List);
                c.RoutePrefix = "";
            });
        }
    }
}