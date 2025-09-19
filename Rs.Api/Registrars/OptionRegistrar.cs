using Microsoft.Extensions.Options;

namespace Rs.Api.Registrars;

public class OptionRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services
            .Configure<VerificationSettings>(builder.Configuration.GetSection(nameof(VerificationSettings)));
        builder.Services.AddSingleton(service => service.GetRequiredService<IOptions<VerificationSettings>>().Value);

        builder.Services
            .Configure<EmailSettings>(builder.Configuration.GetSection(nameof(EmailSettings)));
        builder.Services.AddSingleton(service => service.GetRequiredService<IOptions<EmailSettings>>().Value);
        
        builder.Services
            .Configure<FileUploadSettings>(builder.Configuration.GetSection(nameof(FileUploadSettings)));
        builder.Services.AddSingleton(service => service.GetRequiredService<IOptions<FileUploadSettings>>().Value);
    }
}