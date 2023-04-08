using AutoMapper;
using BirdApi.Data;
using BirdApi.Service;
using BirdApi.Service.Abstract;
using BirdApi.Service.Concrete;

namespace BirdApi.Web.Extension;

public static class StartUpExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        //UnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();


        //services.AddScoped<ScopedService>();
        //services.AddTransient<TransientService>();
        //services.AddSingleton<SingletonService>();
    }

    public static void AddMapperService(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        });
        services.AddSingleton(mapperConfig.CreateMapper());
    }

    public static void AddBusinessService(this IServiceCollection services)
    {
        //repository
        services.AddScoped<IGenericRepository<Account>, GenericRepository<Account>>();
        services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();

        //services
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IAccountService, AccountService>();

        //jwt
        services.AddScoped<ITokenManagementService, TokenManagementService>();
    }
}
