using Paltarumi.Acopio.Apis.Documentation;
using Paltarumi.Acopio.Apis.Endpoints;
using Paltarumi.Acopio.Apis.Exception;
using Paltarumi.Acopio.Apis.Security;
using Paltarumi.Acopio.Application.Extensions;
using Paltarumi.Acopio.Domain.Extensions;
using Paltarumi.Acopio.EmailClient;
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
builder.Services.UseRepositories(configuration);

// Domain Services
builder.Services.UseDomainServices();

// Application Services
builder.Services.UseApplicationServices();

// Security
builder.Services.UseSecurity(configuration);

// EmailClient
builder.Services.UseEmailClient(configuration);

#endregion

#region App

var app = builder.Build();

// CustomExceptionHandler
app.UseCustomExceptionHandler();

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

// Run
app.Run();

#endregion
