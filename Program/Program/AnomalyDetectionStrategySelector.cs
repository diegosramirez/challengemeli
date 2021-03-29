namespace Program
{
    public static class AnomalyDetectionStrategySelector
    {
        public static IAnomalyDetectionStrategy GetAnomalyDetectionStrategy(Application app)
        {
            if (app.Configuration.Algorithm.Name == Constants.SPIKE_DETECTION)
            {
                return new SpikeDetectionStrategy(app.Name, app.Configuration.Algorithm.Name, new DataDogDataLoader());
            }
            else if (app.Configuration.Algorithm.Name == Constants.CHANGE_POINT)
            {
                return new ChangePointDetectionStrategy(app.Name, app.Configuration.Algorithm.Name);
            }

            return new DefaultAnomalyDetectionStrategy();
        }
    }
}
