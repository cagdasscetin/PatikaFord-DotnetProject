using BirdApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BirdApi.Web.Extension;

public static class StartUpDbContextExtension
{
    public static void AppDbContextDI(this IServiceCollection services, IConfiguration configuration)
    {
        var dbtype = configuration.GetConnectionString("DbType");
        if (dbtype == "SQL")
        {
            var dbconfig = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbconfig));
        }
        else if (dbtype == "PostgreSQL")
        {
            var dbconfig = configuration.GetConnectionString("PostgreSQLConnection");
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(dbconfig));
        }
    }

}
