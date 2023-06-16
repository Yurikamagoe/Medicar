using Medicar.Domain.Doctors;
using Medicar.Infra.Data;

namespace Medicar.Endpoints.Doctors;

public class DoctorPost
{
    public static string Template => "/doctors";
    public static string[] Methods => new string[] {HttpMethod.Post.ToString()};
    public static Delegate Handle => Action;

    public static IResult Action(DoctorRequest doctorRequest, ApplicationDbContext context)
    {
        var doctor = new Doctor
        {
            Name = doctorRequest.Name,
            CRM = doctorRequest.CRM,
            Email = doctorRequest.Email
        };

        context.Doctors.Add(doctor);
        context.SaveChanges();

        return Results.Created($"/doctors/{doctor.Id}", doctor.Id);
    }

}
