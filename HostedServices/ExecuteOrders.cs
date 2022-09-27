using AppServices.Interfaces;

namespace HostedServices
{
    public class ExecuteOrders : CronJobService
    {
        private readonly IPortfolioAppServices _portfolioAppServices;
        public ExecuteOrders(IScheduleConfig<ExecuteOrders> config, IPortfolioAppServices portfolioAppServices)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            if (config is null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            _portfolioAppServices = portfolioAppServices ?? throw new ArgumentNullException(nameof(portfolioAppServices));
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override void DoWork(CancellationToken cancellationToken)
        {
            _portfolioAppServices.ExecuteTodaysOrders();
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
