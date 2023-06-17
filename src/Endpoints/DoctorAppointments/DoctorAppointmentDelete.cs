using Medicar.Domain.Doctors;
using Medicar.Infra.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medicar.Endpoints.DoctorAppointments;

public class DoctorAppointmentDelete
{
    public static string Template => "/consultas/{id:Guid}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    [Authorize]
    public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
    {
        var doctorAppointment = context.DoctorAppointments.Where(d => d.Id == id).First();
        if (doctorAppointment == null)
            return  Results.BadRequest("Consulta não encontrada.");

        if(doctorAppointment.AppointmentDate < DateTime.Now)
            return Results.BadRequest("Não é posível cancelar uma consulta passada.");

        context.DoctorAppointments.Remove(doctorAppointment);
        context.SaveChanges();

        return Results.Ok();
    }
}
