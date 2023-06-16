using Medicar.Domain.Doctors;
using Medicar.Infra.Data;
using Microsoft.IdentityModel.Tokens;

namespace Medicar.Endpoints.Schedules;

public class SchedulePost
{
    public static string Template => "/schedule";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(ScheduleRequest doctorRequest, ApplicationDbContext context)
    {
        //get na agenda pela data
        var schedule = new Schedule();
        if (schedule != null)
            throw new Exception("Já existe uma agenda cadastrada para o médico e dia informados.");

        if(doctorRequest.AppointmentDate < DateTime.Now)
            throw new Exception("Data informada inválida, por favor tente novamente.");

        ////remover horario cadastrado da lista de horarios disponiveis -- somente na criação da agenda
        //List<string> appointmentTimes = new List<string>();
        //appointmentTimes.RemoveAll(x => x == doctorRequest.)

        schedule = new Schedule
        {
            Doctor = doctorRequest.Doctor,
            AppointmentDate = doctorRequest.AppointmentDate,
            AppointmentTimes = doctorRequest.AppointmentTimes,
            CreatedDate = DateTime.Now,
            UpdateDate = DateTime.Now,
        };

        context.Schedules.Add(schedule);
        context.SaveChanges();

        return Results.Created($"/doctors/{schedule.Id}", schedule.Id);
    }

}


