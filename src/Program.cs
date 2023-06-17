using Medicar.Domain.Doctors;
using Medicar.Endpoints.DoctorAppointments;
using Medicar.Endpoints.Doctors;
using Medicar.Endpoints.Schedules;
using Medicar.Infra.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionString:MedicarDb"]);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapMethods(DoctorPost.Template, DoctorPost.Methods, DoctorPost.Handle);
app.MapMethods(SchedulePost.Template, SchedulePost.Methods, SchedulePost.Handle);
app.MapMethods(DoctorAppointmentPost.Template, DoctorAppointmentPost.Methods, DoctorAppointmentPost.Handle);
app.MapMethods(DoctorAppointmentsGetAll.Template, DoctorAppointmentsGetAll.Methods, DoctorAppointmentsGetAll.Handle);
app.MapMethods(DoctorAppointmentDelete.Template, DoctorAppointmentDelete.Methods, DoctorAppointmentDelete.Handle);

app.Run();

