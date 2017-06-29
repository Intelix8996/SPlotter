using System;
using System.Collections.Generic;
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

        public GearedValues<double> Values { get; set; }
        public double Count { get; set; }

        public void Clear()
        {
            Values.Clear();
        }
    }
}
