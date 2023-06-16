using Medicar.Domain.Doctors;
using Medicar.Infra.Data;
using Microsoft.IdentityModel.Tokens;

namespace Medicar.Endpoints.Doctors;

public class DoctorPost
{
    public static string Template => "/doctors";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(DoctorRequest doctorRequest, ApplicationDbContext context)
    {
        //get no médico pelo CRM
        if (!doctorRequest.CRM.IsNullOrEmpty())
            throw new Exception("Já existe um médico com o CRM cadastrado.");

        var doctor = new Doctor(doctorRequest.Name, doctorRequest.CRM, doctorRequest.Email)
        {
            CreatedDate = DateTime.Now,
            UpdateDate = DateTime.Now,
        };

        context.Doctors.Add(doctor);
        context.SaveChanges();

        return Results.Created($"/doctors/{doctor.Id}", doctor.Id);
    }

}
