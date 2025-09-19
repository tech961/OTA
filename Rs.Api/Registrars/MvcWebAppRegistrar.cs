using Rs.Api.Middlewares;

namespace Rs.Api.Registrars;

public class MvcWebAppRegistrar : IWebApplicationRegistrar
{
    public void RegisterPipelineComponents(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseSerilogRequestLogging();
        app.UseStaticFiles();
        app.UseAuthorization();
        app.UseCors("AllowAll");
        app.MapControllers();
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.Run();
    }
}