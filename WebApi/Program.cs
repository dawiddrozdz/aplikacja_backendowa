using AppCore.Interfaces;
using AppCore.Modules;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Memory;

namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();
        builder.Services.AddContactsEfModule(builder.Configuration);
        builder.Services.AddContactsModule(builder.Configuration);
        
        builder.Services.AddControllers()
            .AddFluentValidation();
        
        builder.Services.AddExceptionHandler<ProblemDetailsExceptionHandler>();
        builder.Services.AddProblemDetails();

        // builder.Services.AddSingleton<ICustomerService, MemoryCustomerService>();
        // builder.Services.AddSingleton<IPersonRepository, MemoryPersonRepository>();
        // builder.Services.AddSingleton<ICompanyRepository, MemoryCompanyRepository>();
        // builder.Services.AddSingleton<IOrganizationRepository, MemoryOrganizationRepository>();
        // builder.Services.AddSingleton<IContactUnitOfWork, MemoryContactUnitOfWork>();
        // builder.Services.AddSingleton<IPersonService, MemoryPersonService>();

        builder.Services.AddValidatorsFromAssemblyContaining<AppCore.Validators.CreatePersonDtoValidator>();

        builder.Services.AddOpenApi();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseExceptionHandler();
        app.MapControllers();

        app.MapGet("/api/organizations", (IOrganizationRepository repository) =>
            {
                return repository.GetAllAsync();
            })
            .WithName("GetOrganizations");

        app.Run();
    }
}
