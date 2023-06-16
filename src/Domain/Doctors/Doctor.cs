using Flunt.Validations;

namespace Medicar.Domain.Doctors;

public class Doctor : Entity
{
    public string Name { get; set; }
    public string CRM { get; set; }
    public string Email { get; set; }

    public Doctor(string name, string crm, string email)
    {
        var contract = new Contract<Doctor>()
            .IsNotNull(name, "Name", "Nome do médico é obrigatório.")
            .IsNotNull(crm, "CRM", "CRM do médico é obrigatório.")
            .IsNotNull(email, "Email", "Email do médico é obrigatório.")
            .IsEmail(email,"Email", "Email do médico inválido.");
        AddNotifications(contract);
    }
}
