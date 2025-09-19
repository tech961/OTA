using Rs.Api.ConfigureOptions;

namespace Rs.Api.Registrars;

public class MvcRegistrar: IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()   
                    .AllowAnyHeader()  
                    .AllowAnyMethod(); 
            });
        });
    }
}