using Medicar.Domain.Doctors;
using Microsoft.EntityFrameworkCore;

namespace Medicar.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Schedule> Schedules { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Doctor>()
                .Property(p => p.Name).IsRequired();
        builder.Entity<Doctor>()
                .Property(p => p.CRM).IsRequired();
        builder.Entity<Doctor>()
            .Property(p => p.Email).HasMaxLength(50);

        builder.Entity<Schedule>()
                .Property(p => p.Doctor).IsRequired();
        builder.Entity<Schedule>()
                .Property(p => p.AppointmentDate).IsRequired();
        builder.Entity<Schedule>()
                .Property(p => p.AppointmentTimes).IsRequired();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>()
            .HaveMaxLength(100);
    }
}
