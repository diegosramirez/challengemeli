using Microsoft.ML;
using AnomalyDetection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Program
{
    public class SpikeDetectionStrategy : IAnomalyDetectionStrategy
    {        
        private readonly string _applicationName;
        private readonly string _algorithmName;
        private readonly IDataLoader _dataLoader;

        public SpikeDetectionStrategy(string appName, string algorithmName, IDataLoader dataLoader)
        {
            _applicationName = appName;
            _algorithmName = algorithmName;
            _dataLoader = dataLoader;
        }

        public Report DetectAnomalies()
        {
            var mlContext = new MLContext();

            var data = _dataLoader.LoadData();
            IDataView dataView = mlContext.Data.LoadFromEnumerable<Input>(data);

            return DetectSpikes(mlContext, data.Count(), dataView);
        }

        private Report DetectSpikes(MLContext mlContext, int docSize, IDataView data)
        {
            var anomalies = new List<Anomaly>();

            var iidSpikeEstimator = mlContext.Transforms.DetectIidSpike(outputColumnName: nameof(Output.Prediction), inputColumnName: nameof(Input.Value), confidence: (double)99, pvalueHistoryLength: docSize / 4);

            var iidSpikeTransform = iidSpikeEstimator.Fit(CreateEmptyDataView(mlContext));

            var transformedData = iidSpikeTransform.Transform(data);

            var predictions = mlContext.Data.CreateEnumerable<Output>(transformedData, reuseRowObject: false);

            foreach (var p in predictions)
            {
                if (p.Prediction[0] == 1)
                {
                    anomalies.Add(new Anomaly
                    {
                        Date = DateTime.Now,
                        Value = (long)p.Prediction[1],
                    });
                }
            }

            return new Report { Application = _applicationName, Anomalies = anomalies, Algorithm = _algorithmName };
        }

        private IDataView CreateEmptyDataView(MLContext mlContext)
        {
            IEnumerable<Input> enumerableData = new List<Input>();
            return mlContext.Data.LoadFromEnumerable(enumerableData);
        }
    }
}
