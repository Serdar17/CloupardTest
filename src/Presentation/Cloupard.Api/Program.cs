using Cloupard.Api;
using Cloupard.Api.Configuration;
using Cloupard.Common.Settings;
using Cloupard.Services.Logger.Logger;
using Cloupard.Services.Settings.Settings;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


var mainSettings = Settings.Load<MainSettings>(MainSettings.SectionName);
var logSettings = Settings.Load<LogSettings>(LogSettings.SectionName);
var swaggerSettings = Settings.Load<SwaggerSettings>(SwaggerSettings.SectionName);

builder.AddAppLogger(mainSettings, logSettings);

services.AddHttpContextAccessor()
    // .AddAppDbContext(builder.Configuration)
    .AddAppCors()
    .AddAppSwagger(mainSettings, swaggerSettings)
    .AddAppValidator()
    .AddAppController();

services.RegisterServices();
var app = builder.Build();

var logger = app.Services.GetRequiredService<IAppLogger>();
app.UseAppCors();

app.UseAppSwagger();

app.UseAppController();

app.UseAppMiddlewares();

logger.Information("The Cloupard.Api has started");

app.Run();

logger.Information("The Cloupard.Api has started");
