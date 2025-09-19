using Rs.Persistence.DbPersistence;

namespace Rs.Api.Registrars;

public class DbRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        var cs = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddDbContext<DataContext>((sp, options) =>
        {
            options.UseSqlServer(cs);
        });
    }
}