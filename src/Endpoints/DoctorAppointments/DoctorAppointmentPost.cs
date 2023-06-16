using Medicar.Domain.Doctors;
using Medicar.Endpoints.Doctors;
using Medicar.Endpoints.Schedules;
using Medicar.Infra.Data;

namespace Medicar.Endpoints.DoctorAppointments;

public class DoctorAppointmentPost
{
    public static string Template => "/consulta";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(DoctorAppointmentRequest doctorAppointmentRequest, ApplicationDbContext context)
    {
        var existingDoctorAppointment = context.DoctorAppointments.Where(c => c.AppointmentTime == doctorAppointmentRequest.AppointmentTime);
        if (existingDoctorAppointment != null)
            return Results.BadRequest("Já existe um paciente com consulta marcada no horário informado. Por favor, tente novamente!");

        Schedule schedule = context.Schedules.Where(c => c.Id == doctorAppointmentRequest.ScheduleId).Last();
        if (schedule == null)
            return Results.BadRequest("Não existe agenda cadastrada com Id informado. Tente novamente!");

        var doctorAppointment = new DoctorAppointment(schedule, schedule.AppointmentDate, doctorAppointmentRequest.AppointmentTime);

        if (!doctorAppointment.IsValid)
            return Results.BadRequest(doctorAppointment.Notifications);

        context.DoctorAppointments.Add(doctorAppointment);
        context.SaveChanges();

        return Results.Created($"/doctors/{doctorAppointment.Id}", doctorAppointment.Id);
    }
}
