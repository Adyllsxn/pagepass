namespace PagePass.Api.Infrastructure.Extensions
{
    public static class AppExtensions
    {
        public static void UseAppExtensions(this WebApplication app)
        {
            app.UseInfrastructureSwagger();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseApps();
        }
    }
}