namespace Alpha.Endpoint;

public static class LoginEndpoints
{
    public static void Map(IEndpointRouteBuilder endpoints)
    {
        endpoints
            .MapPost("/Login", async ([FromHeader(Name = "Authorization")] BasicCredentials credentials, IAuthenticationService authService) => {
                var result = await authService.LoginAsync(credentials.UserName, credentials.Password);
                if (result.Succeeded)
                    return Results.Ok(result.Token);

                return Results.BadRequest(result.Errors);
            })
            .AllowAnonymous();
    }
}
