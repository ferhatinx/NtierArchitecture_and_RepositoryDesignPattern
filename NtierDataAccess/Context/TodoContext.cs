

using Microsoft.EntityFrameworkCore;
using NtierEntities.Domains;
using System.Reflection;
using System.Reflection.PortableExecutable;

namespace NtierDataAccess.Context;

public class TodoContext : DbContext
{
	public DbSet<Work> Works { get; set; }
	public TodoContext(DbContextOptions<TodoContext> options) : base(options)
	{

	}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
