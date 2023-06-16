using Medicar.Domain.Doctors;
using Medicar.Infra.Data;
using Microsoft.IdentityModel.Tokens;
using System.Numerics;

namespace Medicar.Endpoints.Schedules;

public class SchedulePost
{
    public static string Template => "/agenda";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(ScheduleRequest scheduleRequest, ApplicationDbContext context)
    {
        var existingSchedule = context.Schedules.Where(c => c.AppointmentDate == scheduleRequest.AppointmentDate);
        if (existingSchedule != null)
            return Results.BadRequest("Já existe uma agenda criada para a data informada");

        var schedule = new Schedule(scheduleRequest.Doctor, scheduleRequest.AppointmentDate, scheduleRequest.AppointmentTimes);

        if(!schedule.IsValid)
            return Results.BadRequest(schedule.Notifications);

        
        ////remover horario cadastrado da lista de horarios disponiveis -- somente na criação da agenda
        //List<string> appointmentTimes = new List<string>();
        //appointmentTimes.RemoveAll(x => x == doctorRequest.)

        context.Schedules.Add(schedule);
        context.SaveChanges();

        return Results.Created($"/doctors/{schedule.Id}", schedule.Id);
    }

}


