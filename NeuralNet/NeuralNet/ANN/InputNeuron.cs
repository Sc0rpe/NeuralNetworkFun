using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace ANN
{
    public class InputNeuron : Neuron
    {
        public InputNeuron() : base()
        {
            value = 0;
        }

        public InputNeuron(NeuralNetwork parent) : base(parent)
        {
            value = 0;
        }

        public InputNeuron(InputNeuron n) : base(n)
        {
            //throw new NotImplementedException();
        }

        public override Neuron Copy()
        {
            InputNeuron n = new InputNeuron();

            n.value = this.value;
            n.name = this.name;
            n.activationfunction = this.activationfunction;
            return n;
        }

        public override XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public override double GetValue()
        {
            return value;
        }

        public override void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            this.name = reader.ReadElementContentAsString();
        }

        public virtual void SetValue(double x)
        {
            value = x;
        }

        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("AssemblyQualifiedName", this.GetType().AssemblyQualifiedName);
            writer.WriteElementString("name", this.name.ToString());
        }
    };
}
