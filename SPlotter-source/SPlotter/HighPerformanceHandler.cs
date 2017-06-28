using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LiveCharts.Geared;

namespace SPlotter
{
    class HighPerformanceHandler
    {
        public int _trend;

        public HighPerformanceHandler()
        {
            Values = new GearedValues<double>().WithQuality(Quality.High);
        }

        public bool IsReading { get; set; }
        public GearedValues<double> Values { get; set; }
        public double Count { get; set; }
        public double CurrentLecture { get; set; }
        public bool IsHot { get; set; }

        public void Stop()
        {
            IsReading = false;
        }

        public void Clear()
        {
            Values.Clear();
        }
    }
}
