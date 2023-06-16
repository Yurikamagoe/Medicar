using Medicar.Domain.Doctors;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Medicar.Endpoints.Schedules;

public class ScheduleRequest
{
    [Required]
    public Doctor Doctor { get; set; }
    [Required]
    public DateTime AppointmentDate { get; set; }
    [Required]
    public List<string> AppointmentTimes { get; set; }
}