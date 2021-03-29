using Microsoft.ML.Data;
using System;

namespace AnomalyDetection
{
    public class Input
    {
        [LoadColumn(0)]
        public DateTime Date;

        [LoadColumn(1)]
        public float Value;
    }
}