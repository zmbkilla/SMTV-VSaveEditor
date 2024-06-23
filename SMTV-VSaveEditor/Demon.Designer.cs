namespace SMTV_VSaveEditor
{
    partial class Demon
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
            this.DemonIDbox = new System.Windows.Forms.ComboBox();
            this.DSpanel = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Demonsavebtn = new System.Windows.Forms.Button();
            this.DemonStatdgv = new System.Windows.Forms.DataGridView();
            this.DstatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DstatBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DstatAdd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DstatC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DemonStatdgv)).BeginInit();
            this.SuspendLayout();
            // 
            // DemonIDbox
            // 
            this.DemonIDbox.FormattingEnabled = true;
            this.DemonIDbox.Location = new System.Drawing.Point(119, 36);
            this.DemonIDbox.Name = "DemonIDbox";
            this.DemonIDbox.Size = new System.Drawing.Size(233, 21);
            this.DemonIDbox.TabIndex = 0;
            this.DemonIDbox.SelectedIndexChanged += new System.EventHandler(this.DemonIDbox_SelectedIndexChanged);
            // 
            // DSpanel
            // 
            this.DSpanel.Location = new System.Drawing.Point(41, 105);
            this.DSpanel.Name = "DSpanel";
            this.DSpanel.Size = new System.Drawing.Size(441, 134);
            this.DSpanel.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(41, 36);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(37, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Demon Slot";
            // 
            // Demonsavebtn
            // 
            this.Demonsavebtn.Location = new System.Drawing.Point(250, 424);
            this.Demonsavebtn.Name = "Demonsavebtn";
            this.Demonsavebtn.Size = new System.Drawing.Size(136, 23);
            this.Demonsavebtn.TabIndex = 4;
            this.Demonsavebtn.Text = "Apply to current slot";
            this.Demonsavebtn.UseVisualStyleBackColor = true;
            this.Demonsavebtn.Click += new System.EventHandler(this.Demonsavebtn_Click);
            // 
            // DemonStatdgv
            // 
            this.DemonStatdgv.AllowUserToAddRows = false;
            this.DemonStatdgv.AllowUserToDeleteRows = false;
            this.DemonStatdgv.AllowUserToResizeColumns = false;
            this.DemonStatdgv.AllowUserToResizeRows = false;
            this.DemonStatdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DemonStatdgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DstatName,
            this.DstatBase,
            this.DstatAdd,
            this.DstatC});
            this.DemonStatdgv.Location = new System.Drawing.Point(41, 257);
            this.DemonStatdgv.MaximumSize = new System.Drawing.Size(441, 130);
            this.DemonStatdgv.MinimumSize = new System.Drawing.Size(441, 130);
            this.DemonStatdgv.Name = "DemonStatdgv";
            this.DemonStatdgv.Size = new System.Drawing.Size(441, 130);
            this.DemonStatdgv.TabIndex = 5;
            // 
            // DstatName
            // 
            this.DstatName.HeaderText = "Stat Name";
            this.DstatName.Name = "DstatName";
            // 
            // DstatBase
            // 
            this.DstatBase.HeaderText = "Base";
            this.DstatBase.Name = "DstatBase";
            // 
            // DstatAdd
            // 
            this.DstatAdd.HeaderText = "Add";
            this.DstatAdd.Name = "DstatAdd";
            // 
            // DstatC
            // 
            this.DstatC.HeaderText = "Combined";
            this.DstatC.Name = "DstatC";
            // 
            // Demon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DemonStatdgv);
            this.Controls.Add(this.Demonsavebtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.DSpanel);
            this.Controls.Add(this.DemonIDbox);
            this.Name = "Demon";
            this.Size = new System.Drawing.Size(722, 485);
            this.Load += new System.EventHandler(this.Demon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DemonStatdgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox DemonIDbox;
        public System.Windows.Forms.Panel DSpanel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Demonsavebtn;
        private System.Windows.Forms.DataGridView DemonStatdgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn DstatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DstatBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn DstatAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn DstatC;
    }
}
