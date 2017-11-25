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
    public partial class QueryNetwork : Form
    {
        NeuralNetwork myNet;
        List<TextBox> boxes;

        public QueryNetwork(NeuralNetwork net)
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            myNet = net;
            boxes = new List<TextBox>();
            SetupUI();
        }
        
        private void SetupUI()
        {
            tableLayoutPanel1.ColumnCount = myNet.settings.InputNeurons;

            tableLayoutPanel1.ColumnStyles.Clear();

            for (int i = 0; i < myNet.settings.InputNeurons; ++i)
            {
                tableLayoutPanel1.Controls.Add(new Label { Text = "I" + i, AutoSize = true});
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / (float)Convert.ToDouble(myNet.settings.InputNeurons)));
            }
            for (int i = 0; i < myNet.settings.InputNeurons; ++i)
            {
                TextBox t = new TextBox { Dock = DockStyle.None,Anchor=AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left, Multiline = true, };
                boxes.Add(t);

                tableLayoutPanel1.Controls.Add(t);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            List<double> inputs = new List<double>();

            foreach(TextBox tb in boxes)
            {
                inputs.Add(Convert.ToDouble(tb.Text));

            }
            myNet.SetInputVector(inputs);
            List<double> outputs = myNet.GetOutputVector();
            foreach(double d in outputs)
            {
                textBox1.AppendText(d + System.Environment.NewLine);
            }
        }
    }
}
