using System.Reflection;
using Microsoft.OpenApi.Models;

namespace MovieApi.Extensions;

public static class SwaggerConfigurationExtension
{
    public static void AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Version = "v1",
                Title = "Movie API",
                Description = "A Web API for Movies",
            });
            
            options.EnableAnnotations();

            var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
        });
    }
    
    public static void UseCustomSwaggerConfig(this IApplicationBuilder app) {
        app.UseSwagger();
        app.UseSwaggerUI();  
    } 
}