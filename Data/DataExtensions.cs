namespace CineRadarAI.Api.Data;

public static class DataExtensions
{
    public static void InitializeDb(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbcontext = scope.ServiceProvider.GetRequiredService<DataContext>();
        dbcontext.Database.Migrate();
    }
}