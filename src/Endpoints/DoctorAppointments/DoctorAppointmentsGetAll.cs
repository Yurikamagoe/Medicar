using Medicar.Domain.Responses;
using Medicar.Infra.Data;
using Microsoft.AspNetCore.Authorization;

namespace Medicar.Endpoints.DoctorAppointments;

public class DoctorAppointmentsGetAll
{
    public static string Template => "/consultas";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize]
    public static IResult Action(ApplicationDbContext context)
    {
        var doctorAppointments = context.DoctorAppointments
            .Join(
        context.Schedules,
        doctorAppointment => doctorAppointment.ScheduleId,
        schedule => schedule.Id,
        (doctorAppointment, schedule) => new { DoctorAppointment = doctorAppointment, Schedule = schedule }
        )
            .Join(
        context.Doctors,
        joinedEntities => joinedEntities.Schedule.DoctorId,
        doctor => doctor.Id,
        (joinedEntities, doctor) => new { DoctorAppointment = joinedEntities.DoctorAppointment, Schedule = joinedEntities.Schedule, Doctor = doctor }

        );

        var response = doctorAppointments.Select(c => new DoctorAppointmentsResponse
        {
            DoctorAppointmentId = c.DoctorAppointment.Id,
            AppointmentDate = c.DoctorAppointment.AppointmentDate,
            CreatedDate = c.DoctorAppointment.CreatedDate,
            AppointmentTime = c.DoctorAppointment.AppointmentTime,
            Doctor = c.Doctor
        });
        return Results.Ok(response);
    }
}
