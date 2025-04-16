using Core.Repository.Interfaces;

namespace BirthDayDaemon
{
    public class HBDHost : BackgroundService
    {
        private readonly ILogger<HBDHost> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public HBDHost(ILogger<HBDHost> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var birthdayReminder = scope.ServiceProvider.GetRequiredService<IBirthdayReminder>();
                    await birthdayReminder.BirthdayValidator();
                }
                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }
    }
}
