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
    public class WorkingNeuron : Neuron
    {
        public List<Connection> connections;

        public bool valid { get; set; }


        public WorkingNeuron() : base()
        {
            connections = new List<Connection>();
            valid = false;
            value = 0;
            parentNetwork = null;
        }

        public WorkingNeuron(NeuralNetwork parent) : base(parent)
        {
            connections = new List<Connection>();
            valid = false;
            value = 0;
        }

        public WorkingNeuron(WorkingNeuron n) : base(n)
        {
            valid = n.valid;
            connections = new List<Connection>();
        }

        public override double GetValue()
        {
            if (!valid)
                Calculate();
            return value;
        }

        public void SetValue(double x)
        {
            value = x;
        }

        public void AddConnection(Neuron n, double w)
        {
            AddConnection(new Connection(n, w));
        }


        public void AddConnection(Connection c)
        {
            connections.Add(c);
        }

        public void Calculate()
        {
            value = 0.0;
            foreach (Connection c in connections)
            {
                value += c.GetValue();
            }
            value = activationfunction.Activate(value);


            valid = true;

        }

        public void Invalidate()
        {
            valid = false;
        }

        public override Neuron Copy()
        {
            WorkingNeuron n = new WorkingNeuron();

            n.name = this.name;
            n.value = this.value;
            n.activationfunction = activationfunction;
            n.parentNetwork = this.parentNetwork;
            return n;
        }

        public override void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("WorkingNeuron");
            this.name = reader.ReadElementContentAsString("name", "");
            this.activationfunction = (ActivationFunctions.ActivationFunction)Activator.CreateInstance(Type.GetType(reader.ReadElementContentAsString()));

            reader.ReadStartElement("Connections");
            while(reader.IsStartElement("Connection"))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Connection));
                this.connections.Add((Connection)xmlSerializer.Deserialize(reader));
                reader.ReadEndElement();
            }
            reader.ReadEndElement();
        }

        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("AssemblyQualifiedName", this.GetType().AssemblyQualifiedName);
            writer.WriteElementString("name", this.name);
            writer.WriteElementString("ActivationFunction", this.activationfunction.GetType().ToString());

            writer.WriteStartElement("Connections");
            foreach(Connection c in this.connections)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(c.GetType());
                xmlSerializer.Serialize(writer, c);
            }
            writer.WriteEndElement();
        }

        public override XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }
    };
}
