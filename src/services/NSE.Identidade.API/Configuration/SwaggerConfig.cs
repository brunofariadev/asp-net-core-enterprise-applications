using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace NSE.Identidade.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "NerdStore Identity API",
                    Version = "v1",
                    Description = "Esta API faz parte realiza as autenticações do sistema NerdStore",
                    Contact = new OpenApiContact() { Name = "Bruno Oliveira de Faria", Email = "brunogyn1@gmail.com" }
                });
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
            return app;
        }
    }
}
