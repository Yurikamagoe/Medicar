﻿using Medicar.Domain.Doctors;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Medicar.Domain.Requests;

public class DoctorAppointmentRequest
{
    [Required]
    public Guid ScheduleId { get; set; }
    [Required]
    public string AppointmentTime { get; set; }
}
