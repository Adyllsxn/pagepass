namespace PagePass.Ioc
{
    public static class DependecyInjectionUserApp
    {
        public static void UseApps (this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}