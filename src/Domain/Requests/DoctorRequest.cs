using System.ComponentModel.DataAnnotations;

namespace Medicar.Domain.Requests;

public class DoctorRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string CRM { get; set; }
    [Required]
    public string Email { get; set; }
}