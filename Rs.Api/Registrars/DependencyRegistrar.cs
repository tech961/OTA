using FluentValidation;
using Rs.Domain.Common.Interfaces;
using Rs.Infrastructure.Services;
using Rs.Persistence;
using Rs.Persistence.DbPersistence;

namespace Rs.Api.Registrars;

public class DependencyRegistrar: IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(Program), typeof(BaseModel));
        builder.Services.AddValidatorsFromAssembly(typeof(BaseModel).Assembly);
        builder.Services.AddScoped<IDataContext>(provider => provider.GetRequiredService<DataContext>());
        builder.Services.AddScoped<ITokenProviderService, TokenProviderService>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.AddTransient<IEmailService, EmailService>();
        builder.Services.AddTransient<IExcelService, ExcelService>();
        builder.Services.AddTransient<IFileService, FileService>();
    }
}
