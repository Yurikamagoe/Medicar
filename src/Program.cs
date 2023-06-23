using Medicar.Domain.Doctors;
using Medicar.Endpoints.DoctorAppointments;
using Medicar.Endpoints.Doctors;
using Medicar.Endpoints.Schedules;
using Medicar.Endpoints.Security;
using Medicar.Endpoints.Users;
using Medicar.Infra.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDbContext>(
builder.Configuration["ConnectionStrings:DefaultConnection"]);
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

//builder.Services.AddAuthorization();
//builder.Services.AddAuthentication(x =>
//{
//    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateActor = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = builder.Configuration["JwtBearerTokenSettings:Issuer"],
//        ValidAudience = builder.Configuration["JwtBearerTokenSettings:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecretKey"]))
//    };
//});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//app.UseAuthentication();
//app.UseAuthorization();

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
app.MapMethods(UserPost.Template, UserPost.Methods, UserPost.Handle);
app.MapMethods(TokenPost.Template, TokenPost.Methods, TokenPost.Handle);

app.Run();

