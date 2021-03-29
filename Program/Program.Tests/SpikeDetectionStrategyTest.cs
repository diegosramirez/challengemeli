using NUnit.Framework;
using System.Linq;

namespace Program.Tests
{
    public class SpikeDetectionStrategyTest
    {
        public IAnomalyDetectionStrategy _anomalyDetectionStrategy { get; set; }

        [Test]
        public void DetectAnomalies_InputWithNoSpikes_ZeroAnomaliesDetected()
        {
            var dataLoader = new MockDataLoaderNoAnomalies();
            _anomalyDetectionStrategy = new SpikeDetectionStrategy("MockAppName", "Spike Detection", dataLoader);

            var anomalies = _anomalyDetectionStrategy.DetectAnomalies();
            Assert.IsTrue(!anomalies.Anomalies.Any());
        }

        [Test]
        public void DetectAnomalies_InputWithSpikes_AnomaliesDetected()
        {
            var dataLoader = new MockDataLoaderWithAnomalies();
            _anomalyDetectionStrategy = new SpikeDetectionStrategy("MockAppName2", "Spike Detection", dataLoader);

            var anomalies = _anomalyDetectionStrategy.DetectAnomalies();
            Assert.IsTrue(anomalies.Anomalies.Any());
        }
    }
}
