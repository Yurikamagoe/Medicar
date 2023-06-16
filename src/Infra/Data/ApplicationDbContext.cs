using Flunt.Notifications;
using Medicar.Domain;
using Medicar.Domain.Doctors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Medicar.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Schedule> Schedules { get; set; }

    public DbSet<DoctorAppointment> DoctorAppointments { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Ignore<Notification>();
        builder.Entity<Doctor>(entity =>
        {
            entity.Property(p => p.Name).IsRequired();
            entity.Property(p => p.CRM).IsRequired();
            entity.Property(p => p.Email).HasMaxLength(50);
        });

        builder.Entity<Schedule>(entity =>
        {
            entity.Property(e => e.AppointmentDate).IsRequired();
            entity.Property(p => p.AppointmentTimes).IsRequired();
            entity.Property(e => e.AppointmentTimes)
               .HasConversion(
                   times => string.Join(",", times),
                   times => times.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList()
               );
            entity.HasOne(e => e.Doctor)
                .WithMany()
                .HasForeignKey(e => e.DoctorId)
                .IsRequired();
        });

        builder.Entity<DoctorAppointment>(entity =>
        {
            entity.Property(e => e.AppointmentDate).IsRequired();
            entity.Property(p => p.AppointmentTime).IsRequired();
            entity.HasOne(e => e.Schedule)
                .WithMany()
                .HasForeignKey(e => e.ScheduleId)
                .IsRequired();
        });
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>()
            .HaveMaxLength(100);

        configuration.Properties<DateOnly>()
           .HaveConversion<DateOnlyConverter>()
           .HaveColumnType("date");
    }

}
