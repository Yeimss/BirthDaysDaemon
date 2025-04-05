namespace BirthDayDaemon
{
    public class HBDHost : BackgroundService
    {
        private readonly ILogger<HBDHost> _logger;

        public HBDHost(ILogger<HBDHost> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Host para los cumpleaños corriendo a las: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
