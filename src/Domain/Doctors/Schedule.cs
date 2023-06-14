namespace Medicar.Domain.Doctors;

public class Schedule :Entity
{
    public Doctor Doctor { get; set; }
    public DateOnly AppointmentDate { get; set; }
    public List<TimeSpan> AppointmentTimes { get; set; }
}
