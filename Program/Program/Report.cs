using System.Collections.Generic;

namespace Program
{
    public class Report
    {
        public string Application { get; set; }
        public string Algorithm { get; set; }
        public IEnumerable<Anomaly> Anomalies { get; set; }
    }
}