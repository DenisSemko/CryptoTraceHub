namespace ConfigAgent.API.Services;

public static class CipherLocator
{
    private static IServiceProvider _serviceProvider;

    public static void Initialize(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static TService GetService<TService>()
    {
        return _serviceProvider.GetRequiredService<TService>();
    }
}