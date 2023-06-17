using Medicar.Domain.Doctors;
using Medicar.Endpoints.Doctors;
using Medicar.Endpoints.Schedules;
using Medicar.Infra.Data;
using Microsoft.AspNetCore.Authorization;

namespace Medicar.Endpoints.DoctorAppointments;

public class DoctorAppointmentPost
{
    public static string Template => "/consultas";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    [Authorize]
    public static IResult Action(DoctorAppointmentRequest doctorAppointmentRequest, ApplicationDbContext context)
    {
        var existingDoctorAppointment = context.DoctorAppointments.Where(c => c.AppointmentTime == doctorAppointmentRequest.AppointmentTime);
        if (existingDoctorAppointment != null)
            return Results.BadRequest("Já existe um paciente com consulta marcada no horário informado. Por favor, tente novamente!");

        Schedule schedule = context.Schedules.Where(c => c.Id == doctorAppointmentRequest.ScheduleId).Last();
        if (schedule == null)
            return Results.BadRequest("Não existe agenda cadastrada com Id informado. Tente novamente!");


        ////remover horario cadastrado da lista de horarios disponiveis -- somente na criação da agenda
        //List<string> appointmentTimes = new List<string>();
        //appointmentTimes.RemoveAll(x => x == doctorRequest.)

        var doctorAppointment = new DoctorAppointment(schedule, schedule.AppointmentDate, doctorAppointmentRequest.AppointmentTime);

        if (!doctorAppointment.IsValid)
            return Results.BadRequest(doctorAppointment.Notifications);

        context.DoctorAppointments.Add(doctorAppointment);
        context.SaveChanges();

        return Results.Created($"/doctors/{doctorAppointment.Id}", doctorAppointment.Id);
    }
}
