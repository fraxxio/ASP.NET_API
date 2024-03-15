namespace CineRadarAI.Api.Data;

public static class DataExtensions
{
    public static void InitializeDb(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbcontext = scope.ServiceProvider.GetRequiredService<DataContext>();
        dbcontext.Database.Migrate();
    }

    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connString = configuration.GetConnectionString("DefaultConnection");
        services.AddSqlServer<DataContext>(connString)
        .AddScoped<IUserService, UserService>();

        return services;
    }
}