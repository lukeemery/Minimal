using Microsoft.Extensions.Options;

namespace Alpha.Configuration;

public static class RegisterServices
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<ITokenService, TokenService>();
        services.AddSingleton<IAuthenticationService, AuthenticationService>();
        services.AddSingleton<IApplicationUserStore, ApplicationUserStore>();
    }

    public static void AddApiDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public static void AddEndpointSecurity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IPostConfigureOptions<JwtBearerOptions>, JwtBearerPostConfiguration>();

        services
            .AddAuthorization(o =>
            {
                o.FallbackPolicy = new AuthorizationPolicyBuilder()
                  .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                  .RequireAuthenticatedUser()
                  .Build();
            });

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();
    }
}
