using ANN.Data;
using ANN.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ANN
{
    [Serializable, XmlRoot("NeuralNetwork")]
    public class NeuralNetwork : IComparable<NeuralNetwork> , IXmlSerializable 
    {
        public string name { get; set; }
        static int NNcount = 0;

        //List<Neuron> inputLayer;
        //List<Neuron> outputLayer;
        //List<Neuron> hiddenLayer;

        List<List<Neuron>> layers;

        public static StringArgReturningVoidDelegate AppendText { get; set; }
        public static ProgressReturningVoidDelegate SetProgress { get; set; }
        public Settings settings { get; set; }

        ANN.ActivationFunctions.ActivationFunction hiddenlayer1AFunction;
        ANN.ActivationFunctions.ActivationFunction hiddenlayer2AFunction;
        ANN.ActivationFunctions.ActivationFunction outputlayerAFunction;

        public double score;
        private static bool isInterrupted = false;

        static List<TrainingData> td;


	    public delegate double errFuncDelegate(List<TrainingData> t);
        public static errFuncDelegate errFuncMethod;

        private void setName()
        {
            name = "NeuralNet[" + NNcount + "]";
            ++NNcount;
        }

        public NeuralNetwork()
        {
            layers = new List<List<Neuron>>();

            for (int i = 0; i < 3; ++i)
            {
                layers.Add(new List<Neuron>());
            }

            setName();

            score = -1.0f;
        }

        public NeuralNetwork(int hiddenlayers)
        {
            layers = new List<List<Neuron>>();

            for(int i=0; i < hiddenlayers+2;++i)
            {
                layers.Add(new List<Neuron>());
            }

            setName();

            score = -1.0f;
        }

        public NeuralNetwork(int inputNeurons, int hiddenNeurons, int outputNeurons, int hiddenlayers) : this(hiddenlayers)
        {

            AddInputNeuron(inputNeurons);
            AddHiddenNeuron(hiddenNeurons);
            AddOutputNeuron(outputNeurons);

            setName();


            score = -1.0f;
        }

        public NeuralNetwork(Settings s) : this(s.InputNeurons, s.HiddenNeurons, s.OutputNeurons, s.HiddenLayers)
        {
            hiddenlayer1AFunction = s.Layer1Function;
            hiddenlayer2AFunction = s.Layer2Function;
            outputlayerAFunction = s.OutputLayerFunction;
            settings = s;
        }

        /// <summary>
        /// (Deep) Copy Constructor for NeuroalNet
        /// </summary>
        /// <param name="net"></param>
        public NeuralNetwork(NeuralNetwork net) : this(net.layers.Count-2)
        {
            settings = net.settings;
            name = "Copy of " + net.name;

            score = -1.0f;

            foreach (Neuron inNeuron in net.layers.ElementAt(0))
            {
                Neuron n;
                if ((n =  inNeuron as InputNeuron) != null)
                    AddInputNeuron(n.Copy());
                else if ((n = inNeuron as BiasNeuron) != null)
                    AddInputNeuron(n.Copy());
            }


            foreach (Neuron outNeuron in net.layers.ElementAt(net.layers.Count-1))
            {
                Neuron n;
                if ((n = outNeuron as WorkingNeuron) != null)
                    AddOutputNeuron(n.Copy());

            }

            for (int l = 1; l <= net.layers.Count - 2; ++l)
            {
                foreach (Neuron hidNeuron in net.layers.ElementAt(l))
                {
                    Neuron n;
                    if ((n = hidNeuron as WorkingNeuron) != null)
                        AddHiddenNeuron(n.Copy(),l);
                    else if ((n = hidNeuron as BiasNeuron) != null)
                        AddHiddenNeuron(n.Copy(),l);
                }
            }

            //generate Full mesh
            this.CreateFullMesh();


            //copy weights
            //hidden layers
            for(int l=1; l < layers.Count-2; ++l)
            {
                for (int i = 0; i < layers.ElementAt(l).Count; ++i)
                {
                    WorkingNeuron n = layers.ElementAt(l).ElementAt(i) as WorkingNeuron;
                    if (n != null)
                    {
                        for (int c = 0; c < ((WorkingNeuron)net.layers.ElementAt(l).ElementAt(i)).connections.Count; ++c)
                        {
                            n.connections.ElementAt(c).SetWeight(((WorkingNeuron)net.layers.ElementAt(l).ElementAt(i)).connections.ElementAt(c).GetWeight());
                        }
                    }
                }
            }


            //output layer
            for (int i = 0; i < layers.ElementAt(layers.Count-1).Count; ++i)
            {
                WorkingNeuron n = layers.ElementAt(layers.Count - 1).ElementAt(i) as WorkingNeuron;
                if (n != null)
                {
                    for (int c = 0; c < ((WorkingNeuron)net.layers.ElementAt(layers.Count - 1).ElementAt(i)).connections.Count; ++c)
                    {
                        n.connections.ElementAt(c).SetWeight(((WorkingNeuron)net.layers.ElementAt(layers.Count - 1).ElementAt(i)).connections.ElementAt(c).GetWeight());
                    }
                }
            }


        }

        public static NeuralNetwork Train(Settings s)
        {
            NeuralNetwork neuralNet;
            isInterrupted = false;

            //Population
            List<NeuralNetwork> pop = new List<NeuralNetwork>();
            List<TrainingData> td = TrainingData.createTrainingData(s.TrainingDataFilePath, s.InputNeurons, s.SplitChar);
            TrainingData.normalizeData(td);
            SetTrainingData(td);
            //generation
            int g = 1;
            SetProgress(g);

            do
            {
                //Create Population
                AppendText("Creating Population" + System.Environment.NewLine);
                while (pop.Count < s.PopulationSize)
                {
                    NeuralNetwork net = new NeuralNetwork(s);

                    //work to do here
                    if(s.Layer1Bias)
                        net.SetBiasNeurons(0, true);
                    if (s.Layer2Bias)
                        net.SetBiasNeurons(1, true);
                    if(s.OutputLayerBias)
                        net.SetBiasNeurons(net.layers.Count-2, true);

                    //set the activation fucntions for all but the input layer
                    for (int i = 0; i < s.ActivationFunctions.Count; ++i)
                        net.SetActivationFunctionForLayer(i + 1, s.ActivationFunctions.ElementAt(i));

                    net.CreateFullMesh();
                    net.RandomizeWeights();
                    net.Invalidate();
                    net.ScoreNetwork();
                    pop.Add(net);
                }
                AppendText("\rGeneration[" + Convert.ToString(g) + "]");

                //sort from lowest to highest score
                pop.Sort();
                //pop.Reverse();

                int lastIndex = (int)((double)pop.Count() * (1.0 - s.PopulationRelease));

                //delete the 40% least accurate networks from population
                for (int x = pop.Count(); x >= lastIndex; --x)
                {
                    NeuralNetwork d = pop.Last();
                    pop.Remove(d);
                }

                //add some mutations from the top 400
                for (int i = 0; i < 300; ++i)
                {
                    NeuralNetwork m = new NeuralNetwork(pop.ElementAt(i));
                    m.MutateWeightsRandom(s.Mutations);
                    m.Invalidate();
                    m.ScoreNetwork();
                    pop.Add(m);
                }
                AppendText("- Score: " + Convert.ToString(pop.ElementAt(0).score) + System.Environment.NewLine);
                ++g;
                SetProgress(g);

            } while (g <= s.MaxGens && !isInterrupted);
            neuralNet = pop.ElementAt(0);

            if (isInterrupted)
                AppendText("Training was interrupted" + System.Environment.NewLine);
            else
                AppendText("Training Finished!" + System.Environment.NewLine);

            return neuralNet;
        }

        public void SetInputVector(List<double> v)
        {
            int index = 0;
            List<Neuron> inpLayer = layers.ElementAt(0);

            foreach (double inp in v)
            {
                ((InputNeuron)inpLayer.ElementAt(index)).SetValue(inp);
                ++index;
            }
            this.Invalidate();
        }

        public List<double> GetOutputVector()
        {
            List<double> result = new List<double>();
            List<Neuron> outpLayer = layers.ElementAt(layers.Count-1);

            foreach (Neuron it in outpLayer)
            {
                result.Add((it).GetValue());
            }

            return result;
        }

        private void SetLayerCount(int layercount)
        {
            layers.Clear();
            for (int i = 0; i < layercount; ++i)
                layers.Add(new List<Neuron>());
        }

        //Setup Functions
        public void AddInputNeuron(Neuron n)
        {
            n.parentNetwork = this;
            n.name = "Input_Neuron" + layers.ElementAt(0).Count.ToString();
            layers.ElementAt(0).Add(n);
        }

        public void AddOutputNeuron(Neuron n)
        {
            n.parentNetwork = this;
            n.name = "Output_Neuron" + layers.ElementAt(layers.Count-1).Count.ToString();
            layers.ElementAt(layers.Count-1).Add(n);
        }

        public void AddHiddenNeuron(Neuron n, int layer)
        {
            n.parentNetwork = this;
            n.name = "Hidden_Neuron_" +layer.ToString() + "_" + layers.ElementAt(layer).Count.ToString();
            layers.ElementAt(layer).Add(n);
        }

        public void AddInputNeuron(int n)
        {
            for (int i = 0; i < n; ++i)
            {
                AddInputNeuron(new InputNeuron(this));
            }
        }

        public void AddOutputNeuron(int n)
        {
            for (int i = 0; i < n; ++i)
            {
                AddOutputNeuron(new WorkingNeuron(this));
            }
        }

        public void AddHiddenNeuron(int n)
        {
            //foreach hidden layer add a neuron
            for (int l = 1; l <= (layers.Count - 2); l++)
            {
                for (int i = 0; i < n; ++i)
                {
                    AddHiddenNeuron(new WorkingNeuron(this), l);
                }
            }
        }

        /// <summary>
        /// De/activate the bias neuron in layers
        /// </summary>
        /// <param name="layerNumber">layer number in wich the bias neuron should be modified</param>
        /// <param name="active">new mode for the bias neuron</param>
        public void SetBiasNeurons(int layerNumber, bool active)
        {
            List<Neuron> l = layers.ElementAt(layerNumber);
            Neuron bn = null;

            foreach (Neuron it in l)
            {
                //search for the BiasNeuron
                if ((bn = it as BiasNeuron) != null)
                {
                    if (!active)
                    {
                        l.Remove(it);
                    }
                }
            }

            if (bn == null && active)
            {
                BiasNeuron biasNeuron = new BiasNeuron(this);
                l.Add(biasNeuron);
            }
        }

        public static void SetErrFunction(errFuncDelegate del)
        {
            errFuncMethod = del;
        }

	    public static void SetTrainingData(List<TrainingData> data)
        {
            td = data;
        }

        public void RemoveInputNeuron(Neuron n)
        {
            layers.ElementAt(0).Remove(n);
        }

        public void RemoveOutpuNeuron(Neuron n)
        {
            layers.ElementAt(layers.Count-1).Remove(n);
        }

        /// <summary>
        /// Removes a neuron from the hidden layer given as absolute layernumber by parameter layer
        /// </summary>
        /// <param name="n"></param>
        /// <param name="layer">Absolute layer number</param>
        public void RemoveHiddenNeuron(Neuron n, int layer)
        {
            layers.ElementAt(layer).Remove(n);
        }

        public Neuron GetNeuronByName(string name)
        {
            Neuron n = null;

            foreach(List<Neuron> l in layers)
            {
                n = l.Find(neuron => neuron.name == name);
                if (n != null)
                    break;
            }

            return n;
        }

        public void MutateWeightsRandom(int mutations)
        {

            MyRandom myrand = new MyRandom(-0.3, 0.3);

            for (int i = 0; i < mutations; ++i)
            {
                int layer = myrand.NextInt(1, 3);

                //select neuron
                Neuron neuron = null;
                while (neuron == null)
                    neuron = layers.ElementAt(layer).ElementAt(myrand.NextInt(0, layers.ElementAt(layer).Count - 1)) as WorkingNeuron;

                //select connection index
                int index = myrand.NextInt(0, ((WorkingNeuron)neuron).connections.Count - 1) ;
                double w = ((WorkingNeuron)neuron).connections.ElementAt(index).GetWeight();
                double change = myrand.NextDouble(-0.3, 0.3);
                change *= w;

                ((WorkingNeuron)neuron).connections[index].SetWeight(w + change);

            }
        }

        public void ScoreNetwork()
        {
            score = CalculateError();
        }

        public double CalculateError()
        {
            //return errFuncMethod(td);
            // return this.CorrectClassified(NeuralNetwork.td);
            return this.MeanSquaredError(NeuralNetwork.td);
        }


        /// <summary>
        /// Function for Network Manipulation
        /// connect each hidden neuron with each input neuron
        /// and each output neuron with each hidden neuron
        /// </summary>
        public void CreateFullMesh()
        {
            //connect each hidden neuron to each input neuron
            for(int l=layers.Count-1; l > 0; --l)
            {
                foreach(Neuron n in layers.ElementAt(l))
                {
                    WorkingNeuron wn = n as WorkingNeuron;

                    if (wn != null)
                    {
                        foreach (Neuron itIn in layers.ElementAt(l-1))
                        {
                            wn.AddConnection(itIn, 1.0);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Creates the mesh of the connection the neurons are maintaining, called after deserialization!
        /// </summary>
        public void CreateMesh()
        {
            for (int l = layers.Count - 1; l > 0; --l)
            { 
                foreach (Neuron n in layers.ElementAt(l))
                {
                    WorkingNeuron wn = n as WorkingNeuron;
                    if (wn != null)
                    {
                        foreach (Connection c in wn.connections)
                            c.sourceNeuron = this.GetNeuronByName(c.sourceNeuronName);
                    }
                }
            }
        }


        /// <summary>
        /// Randomizes the weights of all connections between all neurons in range of -5.0 to 5.0
        /// </summary>
        public void RandomizeWeights()
        {
            MyRandom r = new MyRandom(-0.5, 0.5);

            for (int l = layers.Count - 1; l > 0; --l)
            {
                foreach (Neuron n in layers.ElementAt(l))
                {
                    WorkingNeuron wn = n as WorkingNeuron;

                    if (wn != null)
                    {
                        List<Connection> con = wn.connections;

                        foreach (Connection c in con)
                        {
                            c.SetWeight(r.NextDouble());
                        }
                    }
                }
            }
        }

        public void SetActivationFunctionForLayer(int layernumber, ANN.ActivationFunctions.ActivationFunction af)
        {
            foreach (Neuron n in layers.ElementAt(layernumber))
                n.SetActivationFunction(af);
        }

        public void Invalidate()
        {
            for (int l = layers.Count - 1; l > 0; --l)
            {
                foreach (Neuron n in layers.ElementAt(l))
                {
                    WorkingNeuron wn = n as WorkingNeuron;
                    if (wn != null)
                        wn.Invalidate();
                }
            }
        }


	    public double MeanSquaredError(List<TrainingData> data)
        {
            List<double> outp;
            double dist = 0;
            double err = 0;

            foreach (TrainingData it in data)
            {
                SetInputVector(it.input);
		        outp = GetOutputVector();

                for (int i = 0; i < outp.Count; ++i)
		        {
                    dist += (outp.ElementAt(i) - it.output.ElementAt(i)) *(outp.ElementAt(i) - it.output.ElementAt(i));
                }

                //dist = System.Math.Sqrt(dist);
                err += dist;
            }

            err /= data.Count;
	        //err = System.Math.Sqrt(err);

	        return err;
        }

        public double CorrectClassified(List<TrainingData> data)
        {
            int count = 0;

            foreach (TrainingData t in data)
            {
                bool b = this.evaluateTrainingSet(t);
                if (b)
                    ++count;
            }

            return (double)count;
        }

        ///<summary>
        ///Only for classification, called by Function "CorrectClassified"
        ///</summary>
        public bool evaluateTrainingSet(TrainingData d)
        {
            this.SetInputVector(d.input);
            this.Invalidate();
            List<double> o;
            o = this.GetOutputVector();

            int index = 0;
            int i = 0;

            //searching for the index of the highest value in outputvector
            foreach (double v in o)
            {
                if (o.ElementAt(index) < v)
                    index = i;

                ++i;
            }

            //compare the index to the output vector of the trainings set
            //if the value at this index is 1 the classification was correct
            if (d.output.ElementAt(index) == 1.0)
                return true;
            else
                return false;
        }

        public int CompareTo(NeuralNetwork other)
        {
            if (other == null)
                return 1;
            else
                return this.score.CompareTo(other.score);
        }

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("NeuralNetwork");
            this.name = reader.ReadElementContentAsString("name", "");
            this.score = reader.ReadElementContentAsDouble("score", "");
            int layercount = reader.ReadElementContentAsInt("layers", "");
            SetLayerCount(layercount);

            //Deserialize InputNeurons
            reader.ReadStartElement("InputLayer");
            while(reader.IsStartElement("InputNeuron") || reader.IsStartElement("BiasNeuron"))
            {
                Type type = Type.GetType(reader.GetAttribute("AssemblyQualifiedName"));
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                this.layers.ElementAt(0).Add((Neuron)xmlSerializer.Deserialize(reader));
                reader.ReadEndElement();
            }
            reader.ReadEndElement();

            for (int l = 1; l <= layers.Count - 2; ++l)
            {
                //Deserialize HiddenNeurons
                reader.ReadStartElement("HiddenLayer" + l.ToString());
                while (reader.IsStartElement("WorkingNeuron") || reader.IsStartElement("BiasNeuron"))
                {
                    Type type = Type.GetType(reader.GetAttribute("AssemblyQualifiedName"));
                    XmlSerializer xmlSerializer = new XmlSerializer(type);
                    this.layers.ElementAt(l).Add((Neuron)xmlSerializer.Deserialize(reader));
                    reader.ReadEndElement();
                }
                reader.ReadEndElement();
            }

            //Deserialize OutputNeurons
            reader.ReadStartElement("OutputLayer");
            while (reader.IsStartElement("WorkingNeuron"))
            {
                Type type = Type.GetType(reader.GetAttribute("AssemblyQualifiedName"));
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                this.layers.ElementAt(layers.Count-1).Add((Neuron)xmlSerializer.Deserialize(reader));
                reader.ReadEndElement();
            }
            reader.ReadEndElement();

            //.ReadStartElement("Settings");
            XmlSerializer xmlsettingserializer = new XmlSerializer(typeof(Settings));
            this.settings = (Settings)xmlsettingserializer.Deserialize(reader);
            reader.ReadEndElement();

            //finalize deserialization by creating the mesh of the connections
            CreateMesh();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("name", this.name);
            writer.WriteElementString("score", this.score.ToString());
            writer.WriteElementString("layers", this.layers.Count.ToString());

            //serialize input layer
            writer.WriteStartElement("InputLayer");
            foreach (Neuron n in layers.ElementAt(0))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(n.GetType());
                xmlSerializer.Serialize(writer, n);
            }
            writer.WriteEndElement();

            //serialize hidden layer
            for (int l = 1; l <= layers.Count - 2; ++l)
            {
                writer.WriteStartElement("HiddenLayer" + l.ToString());
                foreach (Neuron n in layers.ElementAt(l))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(n.GetType());
                    xmlSerializer.Serialize(writer, n);
                }
                writer.WriteEndElement();
            }

            //serialize output layer
            writer.WriteStartElement("OutputLayer");
            foreach (Neuron n in layers.ElementAt(layers.Count-1))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(n.GetType());
                xmlSerializer.Serialize(writer, n);
            }
            writer.WriteEndElement();

            XmlSerializer xmlsettingserializer = new XmlSerializer(typeof(Settings));
            xmlsettingserializer.Serialize(writer, this.settings);

        }

        public static void Interrupt()
        {
            isInterrupted = true;
        }
    };
}
