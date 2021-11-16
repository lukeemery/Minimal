namespace Alpha.Configuration
{
    public static class RegisterConfiguration
    {
        public static IServiceCollection AddConfig(
             this IServiceCollection services, IConfiguration config)
        {
            services.Configure<Options.Jwt>(
                config.GetSection(nameof(Options.Jwt)));

            return services;
        }
    }
}
