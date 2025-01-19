namespace PagePass.Ioc
{
    public static class DependecyInjectionSwagger
    {
        public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen( c => {
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme(){
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Put the code token"
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement(){
                        {
                            new OpenApiSecurityScheme(){
                                Reference = new OpenApiReference(){
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[]{}
                        }
                    });
                    c.SwaggerDoc("v1", new OpenApiInfo {Title = "PagePass", Version = "v1", Description = "Api para emprestimo de livros online"});
                }
            );
            return services;
        }

        public static WebApplication UseInfrastructureSwagger(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            return app;
        }
    }
}