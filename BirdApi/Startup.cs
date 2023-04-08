using BirdApi.Base;
using BirdApi.Web.Extension;
using Microsoft.OpenApi.Models;

namespace BirdApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    public static JwtConfig JwtConfig { get; private set; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // jwt inject
        JwtConfig = Configuration.GetSection("JwtConfig").Get<JwtConfig>();
        services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

        // inject - dependency injection **************
        services.AppDbContextDI(Configuration);
        services.AddServices();
        services.AddMapperService();
        services.AddBusinessService();
        services.AddJwtAuthentication(); //incoming token validation
        // end of dependency injection ****************

        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "BirdApi", Version = "v1" });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BirdApi v1"));
        }

        app.UseHttpsRedirection();

        // jwt
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
