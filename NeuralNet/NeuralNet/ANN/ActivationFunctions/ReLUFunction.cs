using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN.ActivationFunctions
{
    class ReLUFunction : ActivationFunction
    {
        public ReLUFunction()
        {
            Name = "ReLU Function";
        }
        override public double Activate(double x)
        {
            if (x < 0.0)
                return 0.0;
            else
                return x;
        }
    }
}
