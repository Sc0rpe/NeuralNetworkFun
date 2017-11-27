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
using ANN.ActivationFunctions;

namespace NeuralNet
{
    public partial class SettingsForm : Form
    {
        public static Settings settings { get; set; } = new Settings(); 
        private List<ActivationFunction> functions;
        private List<ComboBox> cb_activationFunctions;
        private List<Label> lbl_activationFunctions;

        public SettingsForm()
        {
            functions = new List<ActivationFunction>();
            cb_activationFunctions = new List<ComboBox>();
            lbl_activationFunctions = new List<Label>();
            functions.Add(new BooleanFunction());
            functions.Add(new ReLUFunction());
            functions.Add(new IdentityFunction());
            functions.Add(new SigmoidFunction());
            functions.Add(new HyperbolicTanget());

            InitializeComponent();

            cb_OutputLayerAF.DataSource = new BindingList<ActivationFunction>(functions);
            cb_OutputLayerAF.DisplayMember = "Name";

            SetupInterface();

        }
        
        private void SetupInterface()
        {
            tb_SplitChar.Text = settings.SplitChar.ToString();
            tb_MaxGenerations.Text = settings.MaxGens.ToString();
            tb_Mutations.Text = settings.Mutations.ToString();
            tb_PopulationSize.Text = settings.PopulationSize.ToString();
            tb_PopulationRelease.Text = settings.PopulationRelease.ToString();
            tb_HiddenLayers.Text = settings.HiddenLayers.ToString();
            tb_TrainingThreads.Text = settings.TrainingThreads.ToString();

            AdjustAFComboBoxes();
            
            for(int i=0; i < functions.Count; ++i)
            {
                if (settings.ActivationFunctions.ElementAt(settings.ActivationFunctions.Count - 1).Name == functions.ElementAt(i).Name)
                    cb_OutputLayerAF.SelectedIndex = i;
            }

            cb_HiddenLayerBias.Checked = settings.HiddenLayerBias;
            cb_OutputLayerBias.Checked = settings.OutputLayerBias;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                settings.SplitChar = tb_SplitChar.Text.ToCharArray().ElementAt(0);
                settings.MaxGens = Convert.ToInt32(tb_MaxGenerations.Text);
                settings.Mutations = Convert.ToInt32(tb_Mutations.Text);
                settings.PopulationSize = Convert.ToInt32(tb_PopulationSize.Text);
                settings.PopulationRelease = Convert.ToDouble(tb_PopulationRelease.Text);
                settings.ActivationFunctions.Clear();
                foreach(ComboBox cb in cb_activationFunctions)
                {
                    settings.ActivationFunctions.Add((ActivationFunction)cb.SelectedItem);
                }
                settings.ActivationFunctions.Add((ActivationFunction)cb_OutputLayerAF.SelectedItem);
                settings.HiddenLayerBias = cb_HiddenLayerBias.Checked;
                settings.OutputLayerBias = cb_OutputLayerBias.Checked;
                settings.HiddenLayers = Convert.ToInt32(tb_HiddenLayers.Text);
                settings.TrainingThreads = Convert.ToInt32(tb_TrainingThreads.Text);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void AdjustAFComboBoxes()
        {
            foreach (ComboBox cb in cb_activationFunctions)
            {
                this.tableLayoutPanel2.Controls.Remove(cb);
            }

            foreach(Label l in lbl_activationFunctions)
            {
                this.tableLayoutPanel2.Controls.Remove(l);
            }
            cb_activationFunctions.Clear();

            for (int i = 0; i < settings.HiddenLayers; ++i)
            {
                Label l = new Label() { Text = "Hidden Layer" + (i + 1) + "Activation Function", AutoSize = true };
                tableLayoutPanel2.Controls.Add(l);
                ComboBox cb = new ComboBox() { Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right};


                lbl_activationFunctions.Add(l);
                cb_activationFunctions.Add(cb);
                tableLayoutPanel2.Controls.Add(cb);

                cb.DataSource = new BindingList<ActivationFunction>(functions);
                cb.DisplayMember = "Name";
            }

            int index = 0;
            foreach(ComboBox cb in cb_activationFunctions)
            {
                for (int j = 0; j < functions.Count; ++j)
                {
                    if (settings.ActivationFunctions.ElementAt(index).Name == functions.ElementAt(j).Name)
                        cb.SelectedIndex = j;
                }
                ++index;
            }

        }

        private void tb_HiddenLayers_TextChanged(object sender, EventArgs e)
        {
            try
            {
                settings.HiddenLayers = Convert.ToInt32(tb_HiddenLayers.Text);
                AdjustAFComboBoxes();
            }
            catch(Exception ex)
            {

            }
        }

        private void tableLayoutPanel2_ControlAdded(object sender, ControlEventArgs e)
        {
            tableLayoutPanel2.RowStyles.Clear();

            float perc = 100f / tableLayoutPanel2.RowCount;
            for (int i = 0; i < tableLayoutPanel2.RowCount; ++i)
                tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, perc));
        }
    }
}
