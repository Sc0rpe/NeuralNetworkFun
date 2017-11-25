using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN
{
    class MyRandom
    {
        Random r;
        double Min;
        double Max;

        public MyRandom()
        {
            r = new Random();
            Min = 0.0;
            Max = 1.0;
        }

        public MyRandom(double min, double max)
        {
            r = new Random();
            Min = min;
            Max = max;
        }

        public double NextDouble()
        {
            return Min + r.NextDouble() * (Max - Min);
        }

        public double NextDouble(double min, double max)
        {
            return min + r.NextDouble() * (max - min);
        }

        public int NextInt()
        {
            double val = Min + r.NextDouble() * (Max - Min);
            return (int)System.Math.Round(val, 0);
        }

        public int NextInt(double min, double max)
        {
            double val = min + r.NextDouble() * (max - min);
            int ret = (int)System.Math.Round(val, 0);
            return ret;
        }

    }
}
