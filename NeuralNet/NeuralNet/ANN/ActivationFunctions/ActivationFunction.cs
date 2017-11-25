using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN.ActivationFunctions
{
    public abstract class ActivationFunction
    {
        public abstract double Activate(double x);
        public string Name { get; protected set; }
    }
}
