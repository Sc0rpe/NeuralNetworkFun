using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ANN;


namespace NeuralNet
{
    public partial class Form1 : Form
    {
        NeuralNetwork myNeuralNetwork1;
        Settings settings;
        bool isTraining;


        public Form1()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            init();
        }

        private void init()
        {
            settings = new Settings();
            isTraining = false;
            NeuralNetwork.AppendText += new ANN.UI.StringArgReturningVoidDelegate(this.SendText);
            NeuralNetwork.SetProgress += new ANN.UI.ProgressReturningVoidDelegate(this.SetProgress);
            myNeuralNetwork1 = new NeuralNetwork(1);
        }

        private Settings checkSettings()
        {
            try
            {

                //check neuron numbers
                settings.InputNeurons = Convert.ToInt32(textboxInputNeurons.Text);
                settings.HiddenNeurons = Convert.ToInt32(textboxHidenNeurons.Text);
                settings.OutputNeurons = Convert.ToInt32(textboxOutputNeurons.Text);

                if (System.IO.File.Exists(textboxFilePath.Text))
                    settings.TrainingDataFilePath = textboxFilePath.Text;
                else
                    throw new System.IO.FileNotFoundException();

                settings.containsErrors = false;
            }
            catch(FormatException fe)
            {
                settings.containsErrors = true;
                MessageBox.Show(fe.Message);
            }
            catch(OverflowException oe)
            {
                settings.containsErrors = true;
                MessageBox.Show(oe.Message);
            }
            catch(System.IO.FileNotFoundException fnfe)
            {
                settings.containsErrors = true;
                MessageBox.Show(fnfe.Message);
            }

            return settings;
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            settings = checkSettings();

            System.Threading.Thread t = new System.Threading.Thread(() =>
            {
                NeuralNetwork n = null;
                System.Threading.Thread myThread = new System.Threading.Thread(() =>
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    n = NeuralNetwork.Train(settings);
                });
                myThread.Start();
                myThread.Join();
                myNeuralNetwork1 = n;
                isTraining = false;
            });

            if (settings.containsErrors)
            {

            }
            else if(!isTraining)
            {
                this.progressBar1.Maximum = settings.MaxGens+1;
                this.progressBar1.Visible = true;
                t.Name = "NetTrain";
                t.Start();
                isTraining = true;
                btnTrain.Text = "Stop";
                
            }
            else if(isTraining)
            {
                NeuralNetwork.Interrupt();
                btnTrain.Text = "Train!";
            }

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            
            if(DialogResult.OK == ofd.ShowDialog())
            {
                textboxFilePath.Text = ofd.FileName;
            }
        }

        public void SetProgress(int prog)
        {
            if (progressBar1.InvokeRequired)
            {
                ANN.UI.ProgressReturningVoidDelegate d = new ANN.UI.ProgressReturningVoidDelegate(SetProgress);
                this.Invoke(d, new object[] { prog });
            }
            else
                progressBar1.Value = prog;
        }

        public void SendText(string text)
        {
            if (OutputConsole.InvokeRequired)
            {
                ANN.UI.StringArgReturningVoidDelegate d = new ANN.UI.StringArgReturningVoidDelegate(SendText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                OutputConsole.AppendText(text);
            }
        }

        private void queryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryNetwork q = new QueryNetwork(myNeuralNetwork1);

            q.ShowDialog();

        }

        private bool SaveNetwork()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                string path = dlg.FileName;
                ANN.Data.ANNSerializer.SaveNetwork(myNeuralNetwork1, path);
                return true;
            }
            else
                return false;
        }

        private bool LoadNetwork()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (DialogResult.OK == ofd.ShowDialog())
            {
                myNeuralNetwork1 = ANN.Data.ANNSerializer.LoadNetwork(ofd.FileName);
                return true;
            }
            else
                return false;
        }

        private void saveNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveNetwork();
        }

        private void loadNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadNetwork();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();

            if (DialogResult.OK == sf.ShowDialog())
            {
                settings = SettingsForm.settings;
            }
        }
    }
}
