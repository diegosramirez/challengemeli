using System.Collections.Generic;

namespace Program
{
    public interface IAnomalyDetectionStrategy
    {
        Report DetectAnomalies();
    }
}