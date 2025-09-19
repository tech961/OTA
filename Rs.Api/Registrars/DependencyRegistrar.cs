using FluentValidation;
using Rs.Api.Services;
using Rs.Domain.Common.Interfaces;
using Rs.Domain.Repositories;
using Rs.Infrastructure.Services;
using Rs.Persistence;
using Rs.Persistence.DbPersistence;
using Rs.Persistence.Repositories;
using IUser = Rs.Domain.Common.Interfaces.IUser;

namespace Rs.Api.Registrars;

public class DependencyRegistrar: IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(Program), typeof(BaseModel));
        builder.Services.AddValidatorsFromAssembly(typeof(BaseModel).Assembly);
        builder.Services.AddScoped<IDataContext>(provider => provider.GetRequiredService<DataContext>());
        builder.Services.AddScoped<ITokenProviderService, TokenProviderService>();
        builder.Services.AddScoped<IIdentityService, IdentityService>();
        builder.Services.AddScoped<IUser, CurrentUser>();
        builder.Services.AddScoped<IFileManagerRepository, FileManagerRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddHttpContextAccessor();
        
        builder.Services.AddTransient<IEmailService, EmailService>();
        builder.Services.AddTransient<IExcelService, ExcelService>();
        builder.Services.AddTransient<IFileService, FileService>();
    }
}