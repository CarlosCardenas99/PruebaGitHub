using Paltarumi.Acopio.Balanza.Apis.Documentation;
using Paltarumi.Acopio.Balanza.Apis.Endpoints;
using Paltarumi.Acopio.Balanza.Apis.Exception;
using Paltarumi.Acopio.Balanza.Apis.Logging;
using Paltarumi.Acopio.Balanza.Apis.Region;
using Paltarumi.Acopio.Balanza.Apis.Security;
using Paltarumi.Acopio.Balanza.Application.Extensions;
using Paltarumi.Acopio.Balanza.Domain.Extensions;
using Paltarumi.Acopio.Balanza.EmailClient;
using Paltarumi.Acopio.Liquidacion.Update.Extensions;
using Paltarumi.Acopio.Repository.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

#region Services

// Controllers
builder.Services.AddControllers();

// Endpoints
builder.Services.AddEndpointsApiExplorer();

// Documentation
builder.Services.UseSwaggerDocumentation(configuration);

// Repositories
builder.Services.UseRepositories(
     Environment.GetEnvironmentVariable("CN_ACOPIO_BALANZA") ?? configuration.GetConnectionString("DefaultConnection"),
    Environment.GetEnvironmentVariable("URL_SERVICE_AUDIT") ?? configuration.GetValue<string>("AuditOptions:ApiUrl"),
    typeof(Program).Assembly.GetName().Name!
);

// Domain Services
builder.Services.UseDomainServices();
builder.Services.UseDomainServicesUpdate();

// Application Services
builder.Services.UseApplicationServices();

// Security
builder.Services.UseSecurity(configuration);

// EmailClient
builder.Services.UseEmailClient(configuration);

//TODO: UTC
// Region
builder.Services.UseRegion(configuration);

// RequestLogger
builder.Services.UseRequestLogger();

// HttpContextAccessor
builder.Services.AddHttpContextAccessor();

#endregion

#region App

var app = builder.Build();
var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();

// Logging
loggerFactory.AddLog4Net();

// CustomExceptionHandler
app.UseCustomExceptionHandler(loggerFactory);

// RequestLogger
app.UseRequestLogger();

// Documentation
app.UseSwaggerDocumentation(configuration);

// HttpsRedirection
app.UseHttpsRedirection();

// Routing
app.UseRouting();

// Authentication
app.UseAuthentication();

// Authorization
app.UseAuthorization();

// Controllers
app.MapControllers();

// RootApiEndpoint
app.UseRootApiEndpoint(configuration);

//TODO: UTC
app.UseRequestLocalization(options =>
{
    var questStringCultureProvider = options.RequestCultureProviders[0];
    options.RequestCultureProviders.RemoveAt(0);
    options.RequestCultureProviders.Insert(1, questStringCultureProvider);
});

// Run
app.Run();

#endregion
