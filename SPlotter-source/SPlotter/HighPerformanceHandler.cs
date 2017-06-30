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
        public List<double> _trend = new List<double>();
        public List<GearedValues<double>> Values = new List<GearedValues<double>>();

        public void Clear()
        {
           for (int i = 0; i < Values.Count; ++i)
            {
                Values[i].Clear();
            }
        }
    }
}
