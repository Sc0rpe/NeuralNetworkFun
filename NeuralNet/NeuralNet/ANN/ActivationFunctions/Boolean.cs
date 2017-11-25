using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN.ActivationFunctions
{
    class BooleanFunction : ActivationFunction
    {
        public BooleanFunction()
        {
            Name = "Boolean Function";
        }

        override public double Activate(double x)
        {
            if (x <= 0)
                return 0.0;
            else
                return 1.0;
        }
    }
}
