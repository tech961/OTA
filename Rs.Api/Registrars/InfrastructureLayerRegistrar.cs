using Rs.Domain.Common.Interfaces;
using Rs.Persistence.DbPersistence;

namespace Rs.Api.Registrars;

public class InfrastructureLayerRegistrar: IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();
    }
}