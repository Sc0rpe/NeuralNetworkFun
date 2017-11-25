using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN.ActivationFunctions
{
    class SigmoidFunction : ActivationFunction
    {
        public SigmoidFunction()
        {
            Name = "Sigmoid Function";
        }

        override public double Activate(double x)
        {
            double et = System.Math.Pow(System.Math.E, -x);
            return 1.0 / (1.0 + et);
        }
    }
}
