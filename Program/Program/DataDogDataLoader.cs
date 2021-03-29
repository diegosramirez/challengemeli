using AnomalyDetection;
using System;
using System.Collections.Generic;

namespace Program
{
    public class DataDogDataLoader : IDataLoader
    {
        public IEnumerable<Input> LoadData()
        {
            return new List<Input>
            {
                new Input
                {
                    Date = DateTime.Now.AddMinutes(1),
                    Value = 881
                },
                new Input
                {
                    Date = DateTime.Now.AddMinutes(2),
                    Value = 883
                },
                new Input
                {
                    Date = DateTime.Now.AddMinutes(3),
                    Value = 860
                },
                new Input
                {
                    Date = DateTime.Now.AddMinutes(4),
                    Value = 851
                },
                new Input
                {
                    Date = DateTime.Now.AddMinutes(5),
                    Value = 898
                },
                new Input
                {
                    Date = DateTime.Now.AddMinutes(6),
                    Value = 1641
                },
                new Input
                {
                    Date = DateTime.Now.AddMinutes(7),
                    Value = 881
                },
                new Input
                {
                    Date = DateTime.Now.AddMinutes(8),
                    Value = 880
                },
                new Input
                {
                    Date = DateTime.Now.AddMinutes(9),
                    Value = 872
                },
                new Input
                {
                    Date = DateTime.Now.AddMinutes(10),
                    Value = 886
                },
                new Input
                {
                    Date = DateTime.Now.AddMinutes(11),
                    Value = 869
                },
                new Input
                {
                    Date = DateTime.Now.AddMinutes(12),
                    Value = 1965
                }
            };
        }
    }
}
