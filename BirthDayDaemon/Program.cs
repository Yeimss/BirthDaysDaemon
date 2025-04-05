using BirthDayDaemon;
using Core.Repository.Implementation;
using Core.Repository.Interfaces;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<IBirthdayReminder, BirthdayReminder>();
builder.Services.AddHostedService<HBDHost>();

var host = builder.Build();
host.Run();
