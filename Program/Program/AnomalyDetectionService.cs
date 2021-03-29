using System.Linq;

namespace Program
{
    public class AnomalyDetectionService
    {
        private readonly IAnomalyDetectionStrategy _anomalyDetectionStrategy;
        private readonly Repository _repository;

        public AnomalyDetectionService(int appId)
        {
            _repository = new Repository(new Context());
            var app = _repository.GetApplicationById(appId);
            _anomalyDetectionStrategy = AnomalyDetectionStrategySelector.GetAnomalyDetectionStrategy(app);
        }

        public Report Run()
        {
            var report = _anomalyDetectionStrategy.DetectAnomalies();

            if (report.Anomalies.Any()) QueueAnomalies();

            return report;
        }

        private void QueueAnomalies()
        {
        }
    }
}
