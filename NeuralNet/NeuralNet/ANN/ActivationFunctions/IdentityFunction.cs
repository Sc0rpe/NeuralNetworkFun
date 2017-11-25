using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN.ActivationFunctions
{
    class IdentityFunction : ActivationFunction
    {
        public IdentityFunction()
        {
            Name = "Identity Function";
        }

        override public double Activate(double x)
        {
            return x;
        }
    }
}
