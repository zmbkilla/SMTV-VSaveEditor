namespace SMTV_VSaveEditor
{
    partial class PLData
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Savebtn = new System.Windows.Forms.Button();
            this.statview = new System.Windows.Forms.DataGridView();
            this.Stat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Base = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Combined = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPanel = new System.Windows.Forms.Panel();
            this.PLResistS = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.Potential = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.statview)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(194, 30);
            this.textBox1.MaxLength = 12;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(194, 83);
            this.textBox2.MaxLength = 10;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Stats";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Skills";
            // 
            // Savebtn
            // 
            this.Savebtn.Location = new System.Drawing.Point(386, 525);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(75, 23);
            this.Savebtn.TabIndex = 11;
            this.Savebtn.Text = "Save";
            this.Savebtn.UseVisualStyleBackColor = true;
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // statview
            // 
            this.statview.AllowUserToAddRows = false;
            this.statview.AllowUserToDeleteRows = false;
            this.statview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stat,
            this.Base,
            this.Add,
            this.Combined});
            this.statview.Location = new System.Drawing.Point(79, 177);
            this.statview.Name = "statview";
            this.statview.Size = new System.Drawing.Size(443, 112);
            this.statview.TabIndex = 12;
            // 
            // Stat
            // 
            this.Stat.HeaderText = "Stat";
            this.Stat.Name = "Stat";
            // 
            // Base
            // 
            this.Base.HeaderText = "Base";
            this.Base.Name = "Base";
            // 
            // Add
            // 
            this.Add.HeaderText = "Add";
            this.Add.Name = "Add";
            // 
            // Combined
            // 
            this.Combined.HeaderText = "Combined";
            this.Combined.Name = "Combined";
            // 
            // SPanel
            // 
            this.SPanel.AutoScroll = true;
            this.SPanel.AutoScrollMinSize = new System.Drawing.Size(100, 100);
            this.SPanel.Location = new System.Drawing.Point(79, 329);
            this.SPanel.Name = "SPanel";
            this.SPanel.Size = new System.Drawing.Size(311, 190);
            this.SPanel.TabIndex = 13;
            // 
            // PLResistS
            // 
            this.PLResistS.AutoScroll = true;
            this.PLResistS.AutoScrollMargin = new System.Drawing.Size(100, 100);
            this.PLResistS.AutoScrollMinSize = new System.Drawing.Size(100, 50);
            this.PLResistS.Location = new System.Drawing.Point(432, 329);
            this.PLResistS.Name = "PLResistS";
            this.PLResistS.Size = new System.Drawing.Size(188, 190);
            this.PLResistS.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(415, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Resistance";
            // 
            // Potential
            // 
            this.Potential.AutoScroll = true;
            this.Potential.AutoScrollMargin = new System.Drawing.Size(100, 100);
            this.Potential.AutoScrollMinSize = new System.Drawing.Size(100, 50);
            this.Potential.Location = new System.Drawing.Point(636, 329);
            this.Potential.Name = "Potential";
            this.Potential.Size = new System.Drawing.Size(203, 190);
            this.Potential.TabIndex = 15;
            // 
            // PLData
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.Potential);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PLResistS);
            this.Controls.Add(this.SPanel);
            this.Controls.Add(this.statview);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PLData";
            this.Size = new System.Drawing.Size(861, 611);
            this.Load += new System.EventHandler(this.PLData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Savebtn;
        private System.Windows.Forms.DataGridView statview;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Base;
        private System.Windows.Forms.DataGridViewTextBoxColumn Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn Combined;
        public System.Windows.Forms.Panel SPanel;
        public System.Windows.Forms.Panel PLResistS;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Panel Potential;
    }
}
