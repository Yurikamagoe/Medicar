using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Medicar.Domain.Doctors;

public class Schedule : Entity
{
    [ForeignKey("Doctor")]
    public Guid DoctorId { get; set; }
    [IgnoreDataMember]
    public Doctor Doctor { get; set; }
    public DateTime AppointmentDate { get; set; }
    public List<string> AppointmentTimes { get; set; }
}
