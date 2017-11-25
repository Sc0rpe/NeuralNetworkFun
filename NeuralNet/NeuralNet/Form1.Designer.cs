namespace NeuralNet
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTrain = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelInputNeurons = new System.Windows.Forms.Label();
            this.labelHiddenNeurons = new System.Windows.Forms.Label();
            this.labelOutputNeurons = new System.Windows.Forms.Label();
            this.textboxInputNeurons = new System.Windows.Forms.TextBox();
            this.textboxHidenNeurons = new System.Windows.Forms.TextBox();
            this.textboxOutputNeurons = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.OutputConsole = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.textboxFilePath = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTrain
            // 
            this.btnTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrain.Location = new System.Drawing.Point(507, 350);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(75, 23);
            this.btnTrain.TabIndex = 1;
            this.btnTrain.Text = "Train!";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelInputNeurons, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelHiddenNeurons, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelOutputNeurons, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textboxInputNeurons, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textboxHidenNeurons, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textboxOutputNeurons, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(570, 100);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // labelInputNeurons
            // 
            this.labelInputNeurons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInputNeurons.AutoSize = true;
            this.labelInputNeurons.Location = new System.Drawing.Point(3, 0);
            this.labelInputNeurons.Name = "labelInputNeurons";
            this.labelInputNeurons.Size = new System.Drawing.Size(184, 50);
            this.labelInputNeurons.TabIndex = 0;
            this.labelInputNeurons.Text = "InputNeurons";
            this.labelInputNeurons.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHiddenNeurons
            // 
            this.labelHiddenNeurons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHiddenNeurons.AutoSize = true;
            this.labelHiddenNeurons.Location = new System.Drawing.Point(193, 0);
            this.labelHiddenNeurons.Name = "labelHiddenNeurons";
            this.labelHiddenNeurons.Size = new System.Drawing.Size(184, 50);
            this.labelHiddenNeurons.TabIndex = 1;
            this.labelHiddenNeurons.Text = "HiddenNeurons";
            this.labelHiddenNeurons.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelOutputNeurons
            // 
            this.labelOutputNeurons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOutputNeurons.AutoSize = true;
            this.labelOutputNeurons.Location = new System.Drawing.Point(383, 0);
            this.labelOutputNeurons.Name = "labelOutputNeurons";
            this.labelOutputNeurons.Size = new System.Drawing.Size(184, 50);
            this.labelOutputNeurons.TabIndex = 2;
            this.labelOutputNeurons.Text = "OutputNeurons";
            this.labelOutputNeurons.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxInputNeurons
            // 
            this.textboxInputNeurons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxInputNeurons.Location = new System.Drawing.Point(3, 53);
            this.textboxInputNeurons.Multiline = true;
            this.textboxInputNeurons.Name = "textboxInputNeurons";
            this.textboxInputNeurons.Size = new System.Drawing.Size(184, 44);
            this.textboxInputNeurons.TabIndex = 3;
            this.textboxInputNeurons.Text = "4";
            // 
            // textboxHidenNeurons
            // 
            this.textboxHidenNeurons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxHidenNeurons.Location = new System.Drawing.Point(193, 53);
            this.textboxHidenNeurons.Multiline = true;
            this.textboxHidenNeurons.Name = "textboxHidenNeurons";
            this.textboxHidenNeurons.Size = new System.Drawing.Size(184, 44);
            this.textboxHidenNeurons.TabIndex = 4;
            this.textboxHidenNeurons.Text = "16";
            // 
            // textboxOutputNeurons
            // 
            this.textboxOutputNeurons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxOutputNeurons.Location = new System.Drawing.Point(383, 53);
            this.textboxOutputNeurons.Multiline = true;
            this.textboxOutputNeurons.Name = "textboxOutputNeurons";
            this.textboxOutputNeurons.Size = new System.Drawing.Size(184, 44);
            this.textboxOutputNeurons.TabIndex = 5;
            this.textboxOutputNeurons.Text = "4";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 347);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(489, 26);
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // OutputConsole
            // 
            this.OutputConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputConsole.Location = new System.Drawing.Point(12, 208);
            this.OutputConsole.Multiline = true;
            this.OutputConsole.Name = "OutputConsole";
            this.OutputConsole.ReadOnly = true;
            this.OutputConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputConsole.Size = new System.Drawing.Size(567, 116);
            this.OutputConsole.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.textboxFilePath);
            this.panel1.Location = new System.Drawing.Point(12, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 40);
            this.panel1.TabIndex = 5;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(482, 8);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // textboxFilePath
            // 
            this.textboxFilePath.Location = new System.Drawing.Point(3, 10);
            this.textboxFilePath.Name = "textboxFilePath";
            this.textboxFilePath.Size = new System.Drawing.Size(473, 20);
            this.textboxFilePath.TabIndex = 0;
            this.textboxFilePath.Text = "...";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.networkToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(594, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveNetworkToolStripMenuItem,
            this.loadNetworkToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveNetworkToolStripMenuItem
            // 
            this.saveNetworkToolStripMenuItem.Name = "saveNetworkToolStripMenuItem";
            this.saveNetworkToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveNetworkToolStripMenuItem.Text = "Save Network";
            this.saveNetworkToolStripMenuItem.Click += new System.EventHandler(this.saveNetworkToolStripMenuItem_Click);
            // 
            // loadNetworkToolStripMenuItem
            // 
            this.loadNetworkToolStripMenuItem.Name = "loadNetworkToolStripMenuItem";
            this.loadNetworkToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.loadNetworkToolStripMenuItem.Text = "Load Network";
            this.loadNetworkToolStripMenuItem.Click += new System.EventHandler(this.loadNetworkToolStripMenuItem_Click);
            // 
            // networkToolStripMenuItem
            // 
            this.networkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.queryToolStripMenuItem});
            this.networkToolStripMenuItem.Name = "networkToolStripMenuItem";
            this.networkToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.networkToolStripMenuItem.Text = "Network";
            // 
            // queryToolStripMenuItem
            // 
            this.queryToolStripMenuItem.Name = "queryToolStripMenuItem";
            this.queryToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.queryToolStripMenuItem.Text = "Query";
            this.queryToolStripMenuItem.Click += new System.EventHandler(this.queryToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 386);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.OutputConsole);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "NeuralNetGUI ";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelInputNeurons;
        private System.Windows.Forms.Label labelHiddenNeurons;
        private System.Windows.Forms.Label labelOutputNeurons;
        private System.Windows.Forms.TextBox textboxInputNeurons;
        private System.Windows.Forms.TextBox textboxHidenNeurons;
        private System.Windows.Forms.TextBox textboxOutputNeurons;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox OutputConsole;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox textboxFilePath;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveNetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadNetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

