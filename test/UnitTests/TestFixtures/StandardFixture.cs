namespace UnitTests.TestFixtures
{
    using System;
    using System.Net.Http;
    using Infrastructure.ExternalIntegration.Integration;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.Extensions.Configuration;
    using WebApi;
    using Xunit;

    public sealed class StandardFixture
    {
        public StandardFixture()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5000");

            // Aqui está sendo utilizado o mock para permitir teste na fase do docker
            // Se quiser utilizar o FinanceiroService descomente a linha abaixo e comente a outra
            // Se fizer isso garanta que haja uma instancia dessa aplicacao rodando

            //this.FinanceiroService = new FinanceiroService(httpClient);
            this.FinanceiroService = new FinanceiroServiceMock(httpClient);
        }

        // Aqui está sendo utilizado o mock para permitir teste na fase do docker
        // Se quiser utilizar o FinanceiroService descomente a linha abaixo e comente a outra
        // Se fizer isso garanta que haja uma instancia dessa aplicacao rodando

        //public FinanceiroService FinanceiroService { get; }
        public FinanceiroServiceMock FinanceiroService { get; }
    }
}
