using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Medicar.Infra.Data;

public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
{
    public TimeOnlyConverter() : base(
        d => d.ToTimeSpan(),
        d => TimeOnly.FromTimeSpan(d))
    { }
}