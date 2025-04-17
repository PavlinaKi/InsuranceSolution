namespace InsuranceSolution.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("MailerSendAPI", httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration?.GetSection("MailerSendApiSettings")?.GetValue<string>("BaseUri"));
                httpClient.DefaultRequestHeaders.Add("Authorization", $@"Bearer {configuration.GetSection("MailerSendApiSettings").GetValue<string>("ApiKey")}");
            })
             .AddPolicyHandler(GetRetryPolicy());
             //.AddPolicyHandler(GetResiliencePolicy());

            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }

        //public static IAsyncPolicy<HttpResponseMessage> GetResiliencePolicy()
        //{
        //    var timeout = GetTimeoutPolicy();
        //    var retry = GetRetryPolicy();
        //    var breaker = GetCircuitBreakerPolicy();

        //    return Policy.WrapAsync(retry, breaker, timeout);
        //}

        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        //public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        //{
        //    return Policy
        //        .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
        //        .CircuitBreakerAsync(
        //            handledEventsAllowedBeforeBreaking: 5,
        //            durationOfBreak: TimeSpan.FromSeconds(30)
        //        );
        //}

        //public static IAsyncPolicy<HttpResponseMessage> GetTimeoutPolicy()
        //{
        //    return Policy.TimeoutAsync<HttpResponseMessage>(10);
        //}
    }
}
