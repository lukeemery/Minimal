using Microsoft.Extensions.Options;

namespace Alpha.Configuration
{
    public class JwtBearerPostConfiguration : IPostConfigureOptions<JwtBearerOptions>
    {
        private readonly IOptions<Options.Jwt> _jwtOptions;

        public JwtBearerPostConfiguration(IOptions<Options.Jwt> jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public void PostConfigure(string name, JwtBearerOptions options)
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtOptions.Value.Issuer,
                ValidAudience = _jwtOptions.Value.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.Key))
            };
        }
    }
}
