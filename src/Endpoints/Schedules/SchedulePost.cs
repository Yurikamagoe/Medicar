using Medicar.Domain.Doctors;
using Medicar.Infra.Data;
using Microsoft.IdentityModel.Tokens;

namespace Medicar.Endpoints.Schedules;

public class SchedulePost
{
    public static string Template => "/schedule";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(ScheduleRequest scheduleRequest, ApplicationDbContext context)
    {
        //get na agenda pela data
        var schedule = new Schedule(scheduleRequest.Doctor, scheduleRequest.AppointmentDate, scheduleRequest.AppointmentTimes)
        {
            CreatedDate = DateTime.Now,
            UpdateDate = DateTime.Now,
        };

        if(!schedule.IsValid)
            return Results.BadRequest(schedule.Notifications);

        //if (schedule != null)
        //    return Results.BadRequest("Já existe uma agenda cadastrada para o médico e dia informados.");

        ////remover horario cadastrado da lista de horarios disponiveis -- somente na criação da agenda
        //List<string> appointmentTimes = new List<string>();
        //appointmentTimes.RemoveAll(x => x == doctorRequest.)

        context.Schedules.Add(schedule);
        context.SaveChanges();

        return Results.Created($"/doctors/{schedule.Id}", schedule.Id);
    }

}


