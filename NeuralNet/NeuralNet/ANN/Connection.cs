using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ANN
{
    public class Connection : IXmlSerializable
    {
        NeuralNetwork parentNetwork;
	    public Neuron sourceNeuron { get; set; }
        public string sourceNeuronName { get; set; }

        double weight;

	    public Connection()
        {
            sourceNeuron = null;
            parentNetwork = null;
            sourceNeuronName = "";
            weight = 1.0;
        }

        public Connection(Neuron n, double _weight)
        {
            sourceNeuron = n;
            parentNetwork = n.parentNetwork;
            weight = _weight;
        }

        public double GetValue()
        {
            return sourceNeuron.GetValue() * weight;
        }

        public void SetWeight(double w)
        {
            weight = w;
        }

        public double GetWeight()
        {
            return weight;
        }

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            this.weight = reader.ReadElementContentAsDouble("weight", "");
            sourceNeuronName = reader.ReadElementContentAsString("source_neuron_name", "");
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("weight", this.weight.ToString());
            writer.WriteElementString("source_neuron_name", sourceNeuron.name);
        }
    };
}
