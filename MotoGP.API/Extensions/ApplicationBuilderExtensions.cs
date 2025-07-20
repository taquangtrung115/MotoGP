namespace MotoGP.API.Extensions;

public static class ApplicationBuilderExtensions
{
    public static WebApplication UseApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            // Chuyển mặc định về Swagger
            app.MapGet("/", context =>
            {
                context.Response.Redirect("/swagger");
                return Task.CompletedTask;
            });
        }

        app.UseHttpsRedirection();
        app.UseCorrelationId();
        app.UseErrorHandling();       // luôn ở đầu
        app.UseRequestLogging();
        app.UseJwtValidation();       // trước Authentication
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}
