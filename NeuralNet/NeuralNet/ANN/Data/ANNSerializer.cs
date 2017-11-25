using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using ANN;
namespace ANN.Data { 

    public class ANNSerializer   {

        public static void SaveNetwork(NeuralNetwork net, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(NeuralNetwork));
            TextWriter textWriter = new StreamWriter(path);

            xmlSerializer.Serialize(textWriter, net);
            textWriter.Close();
        }

        public static NeuralNetwork LoadNetwork(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(NeuralNetwork));
            TextReader textReader = new StreamReader(path);

            NeuralNetwork n = (NeuralNetwork)xmlSerializer.Deserialize(textReader);
            textReader.Close();
            return n;
        }

    }
}
