using Hangfire;
using Microsoft.OpenApi.Models;

namespace HangfireForDotNer;

public class Startup
{
    /// <inheritdoc cref="IConfiguration"/>
    private IConfiguration Configuration;

        
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
        
        
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHangfireServer();
            
        services.AddControllers();
            
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Hangfire API",
                Description = "",
                Contact = new OpenApiContact
                {
                    Name = "Denis Petrov",
                    Email = "gofolgof@gmail.com"
                }
            });
                
            //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //c.IncludeXmlComments(xmlPath);
        });

        services.AddHealthChecks();
    }
        
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
            
        app.UseSwagger(c =>
        {
            c.RouteTemplate = "/swagger/{documentname}/swagger.json";
        });
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Key.Schedule v1");
            c.RoutePrefix = "swagger";
        });
            
        app.UseHangfireDashboard("/hangfire");
            
        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/health", _ => Task.CompletedTask);
        });
    }
}