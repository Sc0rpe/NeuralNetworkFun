using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ANN
{
    public class BiasNeuron : InputNeuron 
    {

        public BiasNeuron()
        {

        }

        public BiasNeuron(NeuralNetwork parent) : base(parent)
        {

        }

        public BiasNeuron(BiasNeuron n)
        {
            value = n.value;
        }

        public override double GetValue()
        {
            return value;
        }

        public override void SetValue(double x)
        {
            System.Console.WriteLine("ERROR: Tried to set Value on BiasNeuron!");
            value = 1.0;
        }

        public override Neuron Copy()
        {
           BiasNeuron n = new BiasNeuron();
           return n;
            
        }

        public override void ReadXml(XmlReader reader)
        {

            reader.ReadStartElement("BiasNeuron");
            this.name = reader.ReadElementContentAsString("name", "");
            this.value = reader.ReadElementContentAsDouble("value", "");
        }

        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("AssemblyQualifiedName", this.GetType().AssemblyQualifiedName);
            writer.WriteElementString("name", this.name.ToString());
            writer.WriteElementString("value", this.value.ToString());
        }
    };
}
