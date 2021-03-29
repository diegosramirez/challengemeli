using NUnit.Framework;

namespace Program.Tests
{
    public class AnomalyDetectionSelectorTest
    {
        [Test]
        public static void SelectStrategy_SpikeDetectionAsInput_SpikeDetectionStrategySelected()
        {
            var app = new Application
            {
                Name = "TestApp",
                Configuration = new Configuration
                {
                    Algorithm = new Algorithm { Name = "Spike Detection" }
                }
            };
            var strategy = AnomalyDetectionStrategySelector.GetAnomalyDetectionStrategy(app);
            Assert.AreEqual(typeof(SpikeDetectionStrategy), strategy.GetType());
        }

        [Test]
        public void SelectStrategy_ChangePointDetectionAsInput_ChangePointDetectionStrategySelected()
        {
            var app = new Application
            {
                Name = "TestApp2",
                Configuration = new Configuration
                {
                    Algorithm = new Algorithm { Name = "Change Point Detection" }
                }
            };
            var strategy = AnomalyDetectionStrategySelector.GetAnomalyDetectionStrategy(app);
            Assert.AreEqual(typeof(ChangePointDetectionStrategy), strategy.GetType());
        }
    }
}
