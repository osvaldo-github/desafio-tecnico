namespace WebApi.Modules.Common.Swagger
{
    using System.IO;
    using System.Reflection;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.PlatformAbstractions;
    using Swashbuckle.AspNetCore.SwaggerGen;

    public static class SwaggerExtensions
    {
        private static string XmlCommentsFilePath
        {
            get
            {
                string basePath = PlatformServices.Default.Application.ApplicationBasePath;
                string fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                c =>
                {
                    c.IncludeXmlComments(XmlCommentsFilePath);
                });

            return services;
        }

        public static IApplicationBuilder UseVersionedSwagger(
            this IApplicationBuilder app,
            IApiVersionDescriptionProvider provider,
            IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });

            return app;
        }
    }
}
