using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using ANN.ActivationFunctions;

namespace ANN
{

    public abstract class Neuron : IXmlSerializable
    {
	    public double value;
        public string name;
        public NeuralNetwork parentNetwork;

        protected ActivationFunction activationfunction;

	    public Neuron()
        {
            value = 0;
            name = "";
            parentNetwork = null;
            activationfunction = new SigmoidFunction();
        }

        public Neuron(NeuralNetwork parent)
        {
            value = 0;
            name = "";
            parentNetwork = parent;
            activationfunction = new SigmoidFunction();
        }

        public Neuron(Neuron n)
        {
            value = n.value;
            name = n.name;
            activationfunction = n.activationfunction;
            parentNetwork = n.parentNetwork;
        }

        public abstract double GetValue();

        public void SetActivationFunction(ActivationFunction af)
        {
            activationfunction = af;
        }

        public abstract Neuron Copy();

        public abstract XmlSchema GetSchema();

        public abstract void ReadXml(XmlReader reader);

        public abstract void WriteXml(XmlWriter writer);


        /// <summary>
        /// DEPRECATED
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        //public static double Sigmoid(double x)
        //   {
        //       double et = System.Math.Pow(System.Math.E, x);
        //       return 1.0 / (1.0f + et);
        //   }

    };
}
