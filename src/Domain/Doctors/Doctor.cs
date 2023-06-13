namespace Medicar.Domain.Doctors;

public class Doctor
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CRM { get; set; }
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
}
