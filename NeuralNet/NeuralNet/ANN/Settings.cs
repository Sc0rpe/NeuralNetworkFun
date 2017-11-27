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
    [Serializable]
    public class Settings : IXmlSerializable
    {
        public int InputNeurons { get; set; }
        public int HiddenNeurons { get; set; }
        public int OutputNeurons { get; set; }
        public int HiddenLayers { get; set; }
        public int MaxGens { get; set; }
        public int PopulationSize { get; set; } 
        public int Mutations { get; set; } //amount of mutations done for one individual
        public int TrainingThreads { get; set; } //Number of threads used for training the network
        public char SplitChar { get; set; } //character at wich to split the vector values
        public double PopulationRelease { get; set; }
        public bool HiddenLayerBias { get; set; }
        public bool OutputLayerBias { get; set; }

        public string TrainingDataFilePath { get; set; }

        public ActivationFunctions.ActivationFunction Layer1Function { get; set; }
        public ActivationFunctions.ActivationFunction Layer2Function { get; set; }
        public ActivationFunctions.ActivationFunction OutputLayerFunction { get; set; }

        public List<ActivationFunction> ActivationFunctions { get; set; }

        public Boolean containsErrors { get; set; }

        public Settings()
        {
            HiddenLayers = 1;
            InputNeurons = 4;
            HiddenNeurons = 8;
            OutputNeurons = 4;
            TrainingThreads = 4;
            MaxGens = 1000;
            PopulationSize = 1000;
            PopulationRelease = 0.6;
            Mutations = 40;
            SplitChar = ',';
            HiddenLayerBias = true;
            OutputLayerBias = true;
            ActivationFunctions = new List<ActivationFunction>();

            //add a fucntion for each hidden layer
            for (int i = 0; i < HiddenLayers; ++i)
                ActivationFunctions.Add(new ANN.ActivationFunctions.ReLUFunction());
            //add the fucntion for the outputlayer
            ActivationFunctions.Add(new ANN.ActivationFunctions.IdentityFunction());

            containsErrors = false;
        }

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            
            reader.ReadStartElement("Settings");
            this.InputNeurons = reader.ReadElementContentAsInt("InputNeuronsCount", "");
            this.HiddenNeurons = reader.ReadElementContentAsInt("HiddenNeuronsCount", "");
            this.OutputNeurons = reader.ReadElementContentAsInt("OutputNeuronsCount", "");
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("InputNeuronsCount", this.InputNeurons.ToString());
            writer.WriteElementString("HiddenNeuronsCount", this.HiddenNeurons.ToString());
            writer.WriteElementString("OutputNeuronsCount", this.OutputNeurons.ToString());
        }
    }
}
