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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // DemonIDbox
            // 
            this.DemonIDbox.FormattingEnabled = true;
            this.DemonIDbox.Location = new System.Drawing.Point(84, 35);
            this.DemonIDbox.Name = "DemonIDbox";
            this.DemonIDbox.Size = new System.Drawing.Size(233, 21);
            this.DemonIDbox.TabIndex = 0;
            this.DemonIDbox.SelectedIndexChanged += new System.EventHandler(this.DemonIDbox_SelectedIndexChanged);
            // 
            // DSpanel
            // 
            this.DSpanel.Location = new System.Drawing.Point(41, 105);
            this.DSpanel.Name = "DSpanel";
            this.DSpanel.Size = new System.Drawing.Size(377, 134);
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
            // Demon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.DSpanel);
            this.Controls.Add(this.DemonIDbox);
            this.Name = "Demon";
            this.Size = new System.Drawing.Size(693, 429);
            this.Load += new System.EventHandler(this.Demon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox DemonIDbox;
        public System.Windows.Forms.Panel DSpanel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
