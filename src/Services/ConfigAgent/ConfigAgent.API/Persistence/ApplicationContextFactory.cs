namespace ConfigAgent.API.Persistence;

public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<ApplicationContext>();

        var host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                string basePath = Path.Combine(hostingContext.HostingEnvironment.ContentRootPath, "..", "ConfigAgent.API");
                config.SetBasePath(basePath);
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .Build();

        var configuration = host.Services.GetRequiredService<IConfiguration>();

        string connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.UseNpgsql(connectionString, options => options.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
        
        return new ApplicationContext(builder.Options);
    }
}