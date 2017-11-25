using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN.ActivationFunctions
{
    class HyperbolicTanget : ActivationFunction
    {
        public HyperbolicTanget()
        {
            Name = "Hyperbolic Tanget";
        }

        override public double Activate(double x)
        {
            double epx = (double)Math.Pow(Math.E, x);
            double enx = (double)Math.Pow(Math.E, -x);

            return (epx - enx) / (epx + enx);

        }
    }
}
