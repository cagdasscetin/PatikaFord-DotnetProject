using BirdApi.Data;

namespace BirdApi.Web.Extension;

public static class StartUpExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        //UnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //repository
        //services.AddScoped<IGenericRepository<Account>, GenericRepository<Account>>();
        //services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();
    }
}
