using Flunt.Validations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Medicar.Domain.Doctors;

public class Schedule : Entity
{
    [ForeignKey("Doctor")]
    public Guid DoctorId { get; set; }
    [IgnoreDataMember]
    public Doctor Doctor { get; set; }
    public DateTime AppointmentDate { get; set; }
    public List<string> AppointmentTimes { get; set; }

    public Schedule(Doctor doctor, DateTime appointimentDate, List<string> appointimentTimes)
    {
        var contract = new Contract<Schedule>()
            .IsNotNull(doctor, "Doctor", "Informações sobre o médico são obrigatórias.")
            .IsNotNull(appointimentDate, "AppointmentDate", "Data da agenda é obrigatória.")
            .IsGreaterOrEqualsThan(appointimentDate, DateTime.Now, "AppointmentDate", "Data informada inválida, por favor tente novamente.")
            .IsNotNull(appointimentTimes, "AppointmentTimes", "Os horários de atendimento são obrigatórios.");
        AddNotifications(contract);

        Doctor = doctor;
        AppointmentDate = appointimentDate;
        AppointmentTimes = appointimentTimes;
        CreatedDate = DateTime.Now;
        UpdateDate = DateTime.Now;
    }

    public Schedule() { }
}
