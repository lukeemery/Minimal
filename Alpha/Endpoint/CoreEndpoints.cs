namespace Alpha.Endpoint;

public static class CoreEndpoints
{
    public static void Map(IEndpointRouteBuilder endpoints)
    {
        endpoints
            .MapGet("/", () => "This a demo for JWT Authentication using Minimalist Web API")
            .AllowAnonymous();

        endpoints
            .MapGet("/doaction", () => "Action Succeeded");

        endpoints
            .MapGet("/protected", () => "Sup.");
    }
}
