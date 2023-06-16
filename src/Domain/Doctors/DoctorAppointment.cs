using Flunt.Validations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Medicar.Domain.Doctors;

public class DoctorAppointment : Entity
{
    [ForeignKey("Schedule")]
    public Guid ScheduleId { get; set; }
    [IgnoreDataMember]
    public Schedule Schedule { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string AppointmentTime { get; set; }

    public DoctorAppointment(Schedule schedule, DateTime appointimentDate, string appointmentTime)
    {
        var contract = new Contract<Schedule>()
            .IsNotNull(schedule, "Schedule", "Informações sobre a agenda são obrigatórias.")
            .IsNotNull(appointimentDate, "AppointmentDate", "Data da agenda é obrigatória.")
            .IsGreaterOrEqualsThan(appointimentDate, DateTime.Now, "AppointmentDate", "Data informada inválida, por favor tente novamente.")
            .IsNotNull(appointmentTime, "AppointmentTime", "O horário de atendimento é obrigatório.");
        AddNotifications(contract);

        Schedule = schedule;
        AppointmentDate = appointimentDate;
        AppointmentTime = appointmentTime;
        CreatedDate = DateTime.Now;
        UpdateDate = DateTime.Now;
    }
}
