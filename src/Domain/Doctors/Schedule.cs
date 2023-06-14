using System.ComponentModel.DataAnnotations.Schema;

namespace Medicar.Domain.Doctors;

public class Schedule : Entity
{
    [Column("DoctorId")]
    public Doctor Doctor { get; set; }
    public DateOnly AppointmentDate { get; set; }
    public TimeSpan AppointmentTimes { get; set; }
}
