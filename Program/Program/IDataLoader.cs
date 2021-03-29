using AnomalyDetection;
using System.Collections.Generic;

namespace Program
{
    public interface IDataLoader
    {
        IEnumerable<Input> LoadData();
    }
}
