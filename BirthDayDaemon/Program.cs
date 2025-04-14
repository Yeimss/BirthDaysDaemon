using BirthDayDaemon;
using Core.Repository.Implementation;
using Core.Repository.Interfaces;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<IBirthdayReminder, BirthdayReminder>()
    .AddScoped<IServiceRepository, ServiceRepository>();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddHostedService<HBDHost>();



var host = builder.Build();
host.Run();
