using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PolyclinicApplication.Data.Models;

namespace PolyclinicApp.Data.DataAccess;
public class AppDbContext : DbContext
{

    public DbSet<Address>? Addresses { get; set; }
    public DbSet<Doctor>? Doctors { get; set; }
    public DbSet<MedicalInsurance>? MedicalInsurances { get; set; }
    public DbSet<MedicineCard>? MedicineCards { get; set; }
    public DbSet<Passport>? Passports { get; set; }
    public DbSet<Patient>? Patients { get; set; }
    public DbSet<Reception>? Receptions { get; set; }
    public DbSet<Schedule>? Schedules { get; set; }
    public DbSet<Specialization>? Specializations { get; set; }
    public DbSet<User>? Users { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}