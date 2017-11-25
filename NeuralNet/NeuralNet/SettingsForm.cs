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

        public SettingsForm()
        {
            InitializeComponent();
            functions = new List<ActivationFunction>();
            functions.Add(new BooleanFunction());
            functions.Add(new ReLUFunction());
            functions.Add(new IdentityFunction());
            functions.Add(new SigmoidFunction());
            functions.Add(new HyperbolicTanget());

            cb_HiddenLayerAF.DataSource = new BindingList<ActivationFunction>(functions);
            cb_HiddenLayerAF.DisplayMember = "Name";

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
            for(int i = 0; i < functions.Count; ++i)
            {
                if (settings.Layer1Function.Name == functions.ElementAt(i).Name)
                    cb_HiddenLayerAF.SelectedIndex = i;
            }
            for (int i = 0; i < functions.Count; ++i)
            {
                if (settings.OutputLayerFunction.Name == functions.ElementAt(i).Name)
                    cb_OutputLayerAF.SelectedIndex = i;
            }
            cb_HiddenLayerBias.Checked = settings.Layer1Bias;
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
                settings.Layer1Function = (ActivationFunction)cb_HiddenLayerAF.SelectedItem;
                settings.OutputLayerFunction = (ActivationFunction)cb_OutputLayerAF.SelectedItem;
                settings.Layer1Bias = cb_HiddenLayerBias.Checked;
                settings.OutputLayerBias = cb_OutputLayerBias.Checked;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
