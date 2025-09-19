namespace Rs.Api.Registrars;

public class MediatrRegistrar: IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(BaseModel).Assembly);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));
        });
    }
}
