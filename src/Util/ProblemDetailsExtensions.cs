using Microsoft.AspNetCore.Identity;

namespace Medicar.Util;

public static class ProblemDetailsExtensions
{
    public static Dictionary<string, string[]> ConvertProblemDetails(this IEnumerable<IdentityError> error)
    {
        return error
            .GroupBy(g => g.Code)
            .ToDictionary(g => g.Key, g => g.Select(x => x.Description).ToArray());
    }
}
