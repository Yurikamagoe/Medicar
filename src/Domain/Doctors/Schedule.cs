namespace Medicar.Domain.Doctors;

public class Schedule
{
    public Doctor Doctor { get; set; }
    public DateOnly AppointmentDate { get; set; }
    public List<TimeSpan> AppointmentTimes { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
}
