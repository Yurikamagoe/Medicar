using Medicar.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Medicar.Endpoints.Users;

public class UserPost
{
    public static string Template => "/user";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    [AllowAnonymous]
    public static IResult Action(UserRequest userRequest, UserManager<IdentityUser> userManager)
    {
        var user = new IdentityUser { UserName = userRequest.Name, Email = userRequest.Email };
        var result = userManager.CreateAsync(user).Result;

        if (!result.Succeeded)
            return Results.ValidationProblem(result.Errors.ConvertProblemDetails());

        return Results.Created($"/user/{user.Id}", user.Id);
    }
}
