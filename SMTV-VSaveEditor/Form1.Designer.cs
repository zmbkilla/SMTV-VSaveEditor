namespace SMTV_VSaveEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Closebtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.Opensavebtn = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.PLDatabtn = new System.Windows.Forms.Button();
            this.Demonbtn = new System.Windows.Forms.Button();
            this.Filebtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.openDecryptedSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Closebtn
            // 
            this.Closebtn.BackColor = System.Drawing.Color.Red;
            this.Closebtn.Location = new System.Drawing.Point(987, 12);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(25, 25);
            this.Closebtn.TabIndex = 0;
            this.Closebtn.Text = "X";
            this.Closebtn.UseVisualStyleBackColor = false;
            this.Closebtn.Click += new System.EventHandler(this.Closebtn_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(0, 100);
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(500, 500);
            this.panel1.Location = new System.Drawing.Point(164, 57);
            this.panel1.MinimumSize = new System.Drawing.Size(620, 353);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 425);
            this.panel1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Filebtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1024, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Opensavebtn,
            this.quitToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // Opensavebtn
            // 
            this.Opensavebtn.Name = "Opensavebtn";
            this.Opensavebtn.Size = new System.Drawing.Size(173, 22);
            this.Opensavebtn.Text = "Open SMTV:V Save";
            
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.PLDatabtn);
            this.flowLayoutPanel1.Controls.Add(this.Demonbtn);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 57);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(127, 425);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // PLDatabtn
            // 
            this.PLDatabtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PLDatabtn.AutoSize = true;
            this.PLDatabtn.Location = new System.Drawing.Point(3, 3);
            this.PLDatabtn.MinimumSize = new System.Drawing.Size(75, 25);
            this.PLDatabtn.Name = "PLDatabtn";
            this.PLDatabtn.Size = new System.Drawing.Size(124, 25);
            this.PLDatabtn.TabIndex = 3;
            this.PLDatabtn.Text = "Player Data";
            this.PLDatabtn.UseVisualStyleBackColor = true;
            this.PLDatabtn.Click += new System.EventHandler(this.PLDatabtn_Click);
            // 
            // Demonbtn
            // 
            this.Demonbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Demonbtn.AutoSize = true;
            this.Demonbtn.Location = new System.Drawing.Point(3, 34);
            this.Demonbtn.MinimumSize = new System.Drawing.Size(75, 25);
            this.Demonbtn.Name = "Demonbtn";
            this.Demonbtn.Size = new System.Drawing.Size(124, 25);
            this.Demonbtn.TabIndex = 4;
            this.Demonbtn.Text = "Demon";
            this.Demonbtn.UseVisualStyleBackColor = true;
            this.Demonbtn.Click += new System.EventHandler(this.Demonbtn_Click);
            // 
            // Filebtn
            // 
            this.Filebtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Filebtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDecryptedSaveToolStripMenuItem});
            this.Filebtn.Image = ((System.Drawing.Image)(resources.GetObject("Filebtn.Image")));
            this.Filebtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Filebtn.Name = "Filebtn";
            this.Filebtn.Size = new System.Drawing.Size(38, 22);
            this.Filebtn.Text = "File";
            // 
            // openDecryptedSaveToolStripMenuItem
            // 
            this.openDecryptedSaveToolStripMenuItem.Name = "openDecryptedSaveToolStripMenuItem";
            this.openDecryptedSaveToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.openDecryptedSaveToolStripMenuItem.Text = "Open Decrypted Save";
            this.openDecryptedSaveToolStripMenuItem.Click += new System.EventHandler(this.openDecryptedSaveToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 516);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.Closebtn);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Closebtn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem Opensavebtn;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button PLDatabtn;
        private System.Windows.Forms.Button Demonbtn;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripDropDownButton Filebtn;
        private System.Windows.Forms.ToolStripMenuItem openDecryptedSaveToolStripMenuItem;
    }
}

