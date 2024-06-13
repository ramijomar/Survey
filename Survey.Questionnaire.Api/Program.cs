using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Survey.Configurations.Shared;
using Survey.Domain.Cqrs.DI;
using Survey.Infrastructure.Persistence.DbContexts;
using Survey.Infrastructure.Persistence.DI;
using Survey.Questionnaire.Api.Common;
using Survey.Web.Shared.Middleware;

var builder = WebApplication.CreateBuilder(args);


var config = builder.Configuration;
var services = builder.Services;

config.LoadConfigurationFiles(builder.Environment);

ConfigureServices();

ConfigureAutofacContainer();

ConfigureSwagger();

var app = builder.Build();

ConfigureWebApp();

app.Run();


void ConfigureServices()
{
    services.AddControllers();

    services.AddMvc();

    services.AddEndpointsApiExplorer();

    services.AddDbContext<SurveyDbContext>(options =>
    {
        options.UseSqlite(GetConnectionString());
    });
}

void ConfigureAutofacContainer()
{
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder
        .RegisterDomainCqrsModule()
        .RegisterPersistenceModule();
    });
}

void ConfigureSwagger()
{
    services.AddSwaggerGen();
}

void ConfigureWebApp()
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.UseMiddleware<ExceptionMiddleware>();
}

string GetConnectionString()
{
    var connectionStringsConfig = new ConnectionsStringConfiguration();
    config.GetSection(ConnectionsStringConfiguration.SectionName).Bind(connectionStringsConfig);

    return connectionStringsConfig.ConnectionString;
}