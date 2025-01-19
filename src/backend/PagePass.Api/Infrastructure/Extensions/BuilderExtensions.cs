namespace PagePass.Api.Infrastructure.Extensions
{
    public static class BuilderExtensions
    {
        public static void AddBuilderExtensions(this WebApplicationBuilder builder)
        {
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddInfrastructureSwagger();
        }
    }
}