namespace WebApi.Modules.Common.Swagger
{
    using System;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this._provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in this._provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "Desafio Técnico",
                Version = description.ApiVersion.ToString(),
                Description = "Desenvolvimento em Clean Architecture e dotnet core 3.1",
                Contact = new OpenApiContact
                {
                    Name = "Osvaldo Bay Machado", Email = "osvaldo.bay@gmail.com"
                },
                TermsOfService = new Uri("https://github.com/osvaldo-github/desafio-tecnico"),
                License = new OpenApiLicense
                {
                    Name = "Apache License",
                    Url = new Uri("https://github.com/osvaldo-github/desafio-tecnico/LICENSE")
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}
