using EmailServices.Services;
using Hangfire;
using Hangfire.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var conn = config.GetConnectionString("emailServicesConnectionString");
builder.Services.AddHangfire(configuration => configuration.UseSqlServerStorage(conn));
builder.Services.AddHangfireServer();

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<EmailWorker>();

var app = builder.Build();
app.UseHangfireServer();
app.UseHangfireDashboard();

app.Run();


var manager = new RecurringJobManager();
manager.AddOrUpdate("SendScheduledEmails", Job.FromExpression<EmailWorker>(x => x.SendScheduledEmails()), "*/1 * * * *");