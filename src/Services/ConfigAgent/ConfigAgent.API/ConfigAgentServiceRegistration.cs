namespace ConfigAgent.API;

public static class ConfigAgentServiceRegistration
{
    public static IServiceCollection AddAgentServices(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<CipherConfiguration>(configuration.GetSection("AesConfiguration"));
        services.AddSingleton<ICipherConfiguration>(serviceProvider =>
            serviceProvider.GetRequiredService<IOptions<CipherConfiguration>>().Value);
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        services.AddTransient<ExceptionHandlingMiddleware>();
        
        services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ICredentialsRepository, CredentialsRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<ICipherService, CipherService>();
        services.AddScoped<ICredentialsService, CredentialsService>();
        
        ServiceProvider serviceProvider = services.BuildServiceProvider();
        CipherLocator.Initialize(serviceProvider);
        
        return services;
    }
}