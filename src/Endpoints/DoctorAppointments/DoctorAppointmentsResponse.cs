using Medicar.Domain;
using Medicar.Domain.Doctors;

namespace Medicar.Endpoints.DoctorAppointments;

public class DoctorAppointmentsResponse 
{
    public Guid DoctorAppointmentId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public string AppointmentTime { get; set; }
    public Doctor Doctor { get; set; }
}
