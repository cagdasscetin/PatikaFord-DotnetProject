using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BirdApi.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}

	//dbset
	public DbSet<Account> Account { get; set; }

    public DbSet<Person> Person { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}
