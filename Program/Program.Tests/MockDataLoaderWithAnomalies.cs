using AnomalyDetection;
using System;
using System.Collections.Generic;

namespace Program.Tests
{
    public class MockDataLoaderWithAnomalies : IDataLoader
    {
        public IEnumerable<Input> LoadData()
        {
            return new List<Input>
            {
                new Input
                {
                    Date = DateTime.Now.AddMinutes(1),
                    Value = 1500 // --> Spike
                },
                new Input
                {
                    Date = DateTime.Now.AddMinutes(2),
                    Value = 881
                },
                new Input
                {
                    Date = DateTime.Now.AddMinutes(3),
                    Value = 881
                },
                new Input
                {
                    Date = DateTime.Now.AddMinutes(4),
                    Value = 881
                },
                new Input
                {
                    Date = DateTime.Now.AddMinutes(5),
                    Value = 881
                }
            };
        }
    }
}