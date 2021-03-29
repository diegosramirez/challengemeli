using Microsoft.ML.Data;

namespace Program
{
    public class Output
    {
        [VectorType(3)]
        public double[] Prediction { get; set; }
    }
}
