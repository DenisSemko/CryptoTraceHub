namespace CryptoAgent.CoinAPI;

public static class CryptoAgentServiceRegistration
{
    public static IServiceCollection AddAgentServices(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<CoinMarketConfiguration>(configuration.GetSection("Configuration"));
        services.AddSingleton<ICoinMarketConfiguration>(serviceProvider =>
            serviceProvider.GetRequiredService<IOptions<CoinMarketConfiguration>>().Value);

        services.AddScoped<IListingsAgent, ListingsAgent>();
        services.AddScoped<IQuotesAgent, QuotesAgent>();
        services.AddScoped<IPriceConversionAgent, PriceConversionAgent>();

        services.AddTransient<ExceptionHandlingMiddleware>();
        
        return services;
    }
}