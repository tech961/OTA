using FluentValidation;
using Rs.Domain.Common.Interfaces;
using Rs.Domain.Common.Interfaces.Repositories;
using Rs.Domain.ToDos.Services;
using Rs.Persistence;
using Rs.Persistence.DbPersistence;
using Rs.Persistence.Repositories.ToDoItems;

namespace Rs.Api.Registrars;

public class DependencyRegistrar: IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(Program), typeof(BaseModel));
        builder.Services.AddValidatorsFromAssembly(typeof(BaseModel).Assembly);
        builder.Services.AddScoped<IDataContext>(provider => provider.GetRequiredService<DataContext>());
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
        builder.Services.AddScoped<IToDoItemDomainService, ToDoItemDomainService>();
        builder.Services.AddHttpContextAccessor();
    }
}
