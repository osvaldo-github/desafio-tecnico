namespace WebApi.Modules
{
    using System;
    using System.Net.Http;
    using Polly;
    using Polly.Extensions.Http;

    public static class PolicyHandler
    {
        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(int retryCount = 5)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        public static IAsyncPolicy<HttpResponseMessage> Timeout(int seconds = 30) =>
            Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(seconds));
    }
}
