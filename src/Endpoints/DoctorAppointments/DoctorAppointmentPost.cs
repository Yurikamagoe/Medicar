using Medicar.Domain.Doctors;
using Medicar.Endpoints.Doctors;
using Medicar.Infra.Data;

namespace Medicar.Endpoints.DoctorAppointments;

public class DoctorAppointmentPost
{
    public static string Template => "/consulta";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(DoctorAppointmentRequest doctorAppointmentRequest, ApplicationDbContext context)
    {
        //get na consulta pela data
        if (doctorAppointmentRequest.ScheduleId != null)
            throw new Exception("Já existe uma consulta marcada na data informada.");

        //get na agenda pelo Id
        var schedule = new Schedule(Schedule, DateTime.Now, ["kk","123"].ToList() );

        var doctorAppointment = new DoctorAppointment(schedule, schedule.AppointmentDate, doctorAppointmentRequest.AppointmentTime);

        if (!doctorAppointment.IsValid)
            return Results.BadRequest(doctorAppointment.Notifications);

        context.DoctorAppointments.Add(doctorAppointment);
        context.SaveChanges();

        return Results.Created($"/doctors/{doctorAppointment.Id}", doctorAppointment.Id);
    }
}
