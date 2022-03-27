using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OxygenLab.Data.Models;

namespace OxygenLab.Data.DataAccess;
public class AppDbContext : DbContext
{

    public DbSet<Client> Clients { get; set; }
    public DbSet<Experiment> Experiments { get; set; }
    public DbSet<Reagent> Reagents { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}