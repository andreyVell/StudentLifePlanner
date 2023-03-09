namespace Slp.WebApi.AppCustomStart
{
    public static class CorsPolicyExtensions
    {
        private const string CorsPolicy = "SlpCorsPolicy";
        public static void AddCustomCorsPolicy(this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsPolicy,
                    builder => builder.WithOrigins(configuration.GetSection("AllowedOrigins").Get<List<string>>().ToArray())
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        public static void UseCustomCorsPolicy(this IApplicationBuilder app)
        {
            app.UseCors(CorsPolicy);
        }
    }
}
