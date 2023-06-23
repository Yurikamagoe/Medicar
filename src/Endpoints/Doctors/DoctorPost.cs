using Medicar.Domain.Doctors;
using Medicar.Endpoints.DoctorAppointments;
using Medicar.Infra.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace Medicar.Endpoints.Doctors;

public class DoctorPost
{
    public static string Template => "/medico";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    [Authorize]
    public static IResult Action(DoctorRequest doctorRequest, ApplicationDbContext context)
    {
        var existingDoctor = context.Doctors.Where(c => c.CRM == doctorRequest.CRM).FirstOrDefault();
        if (existingDoctor != null)
            return Results.BadRequest("Já existe um médico com o CRM cadastrado.");

        var doctor = new Doctor(doctorRequest.Name, doctorRequest.CRM, doctorRequest.Email);

        if (!doctor.IsValid)
            return Results.BadRequest(doctor.Notifications);

        context.Doctors.Add(doctor);
        context.SaveChanges();

        return Results.Created($"/doctors/{doctor.Id}", doctor.Id);
    }

}
