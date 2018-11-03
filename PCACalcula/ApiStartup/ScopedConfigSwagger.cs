using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using PCACalcula.Filter;

namespace PCACalcula.ApiStartup
{
    public static class ScopedConfigSwagger
    {
        public static void AddServicesSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Api para calcular juros compostos", Version = "v1" });
                c.DocumentFilter<SwaggerSecurityRequirementsDocumentFilter>();
            });
        }

        public static void Configure(IApplicationBuilder app, IHostingEnvironment env, string basePath, string endpoint)
        {
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    swaggerDoc.BasePath = basePath;
                });
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(endpoint, "Api para calcular juros compostos");
            });


        }
    }
}
