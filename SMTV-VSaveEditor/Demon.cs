using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMTV_VSaveEditor
{
    public partial class Demon : UserControl
    {
        public string svpath = "";
        public int off = 0xb60;
        public Demon()
        {
            InitializeComponent();
        }

        private void Demon_Load(object sender, EventArgs e)
        {
            
            DemonIDbox.DataSource = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\demon.txt");
            DemonIDbox.SelectedIndex = 0;
            if(svpath != "")
            {
                int[]dmndata = Demoninfo.Demondata(off +(DemonIDbox.SelectedIndex*424),svpath);
                DemonIDbox.SelectedIndex = dmndata[0];
                //skills
                int y = 1;
                int cbr = 0;
                for (int i = 0;i<8;i++)
                {
                    
                    string[]db = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\skills.txt");
                    ComboBox comboBox = new ComboBox();
                    comboBox.BindingContext = new BindingContext();
                    comboBox.DataSource = db;
                    comboBox.SelectedIndex = y;
                    if(i < 4)
                    {
                        comboBox.Location = new Point(0, i*25+5);
                    }
                    else
                    {
                        comboBox.Location = new Point(200, cbr * 25 + 5);
                        cbr++;
                    }
                    
                    DSpanel.Controls.Add(comboBox);
                    
                    y++;
                }
            }
            
        }

        private void DemonIDbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            DemonIDbox.DataSource = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\demon.txt");
            int[] dmndata = Demoninfo.Demondata(off + (Convert.ToInt32(numericUpDown1.Value) * 424), svpath);
            try
            {
                DemonIDbox.SelectedIndex = dmndata[0];
                DSpanel.Controls.Clear();
                int cbr = 0; int y = 0;
                for (int i = 0; i < 8; i++)
                {

                    string[] db = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\skills.txt");
                    ComboBox comboBox = new ComboBox();
                    comboBox.BindingContext = new BindingContext();
                    comboBox.DataSource = db;
                    comboBox.SelectedIndex = y;
                    if (i < 4)
                    {
                        comboBox.Location = new Point(0, i * 25 + 5);
                    }
                    else
                    {
                        comboBox.Location = new Point(200, cbr * 25 + 5);
                        cbr++;
                    }

                    DSpanel.Controls.Add(comboBox);

                    y++;
                }


            }
            catch
            {

            }
            
        }
    }
}
