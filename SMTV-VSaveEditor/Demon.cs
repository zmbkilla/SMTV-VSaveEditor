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
        public bool writingsave = false;
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
                int[]dmndata = Demoninfo.Demondata(off +(Convert.ToInt32(numericUpDown1.Value)*424),svpath);
                DemonIDbox.SelectedIndex = dmndata[21];

                //stats
                DemonStatdgv.Rows.Clear();
                string[] statnames = new string[7];
                statnames[0] = "HP";
                statnames[1] = "MP";
                statnames[2] = "STR";
                statnames[3] = "VIT";
                statnames[4] = "MAG";
                statnames[5] = "AGI";
                statnames[6] = "LU";
                for (int i = 0; i < 7; i++)
                {
                    DemonStatdgv.Rows.Add(statnames[i], dmndata[i], dmndata[i + 7], dmndata[i+14]);
                }

                //skills
                DSpanel.Controls.Clear();
                int y = 22;
                int cbr = 0;
                for (int i = 0;i<8;i++)
                {
                    
                    string[]db = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\skills.txt");
                    ComboBox comboBox = new ComboBox();
                    comboBox.BindingContext = new BindingContext();
                    comboBox.DataSource = db;
                    //comboBox.SelectedIndex = y;
                    if(i < 4)
                    {
                        comboBox.Location = new Point(0, i*25+5);
                    }
                    else
                    {
                        comboBox.Location = new Point(200, cbr * 25 + 5);
                        cbr++;
                    }

                    comboBox.SelectedIndex = dmndata[y];
                    DSpanel.Controls.Add(comboBox);
                    
                    y++;
                }
            }
            
        }

        private void DemonIDbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = "dev";
            switch (DemonIDbox.SelectedIndex.ToString().Length)
            {
                case 1:
                    id += "00" + Convert.ToString(DemonIDbox.SelectedIndex);
                    break;
                case 2:
                    id += "0" + Convert.ToString(DemonIDbox.SelectedIndex);
                    break;
                case 3:
                    id += Convert.ToString(DemonIDbox.SelectedIndex + 1);
                break;
                case 4:
                    id = "";
                break;
            }
            try
            {
                pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject(id);
            }
            catch
            {

            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (writingsave == false)
            {
                DemonIDbox.DataSource = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\demon.txt");

                if (svpath != "")
                {
                    if (numericUpDown1.Value == 8)
                    {

                    }
                    
                    int[] dmndata = Demoninfo.Demondata(off + (Convert.ToInt32(numericUpDown1.Value) * 424), svpath);
                    bool execute = true;
                    
                    if(dmndata[21] != 65534 && execute != false)
                    {
                        DemonIDbox.SelectedIndex = dmndata[21];
                    }
                    
                    else
                    {
                        DemonIDbox.SelectedIndex = 0;
                        execute = true;
                    }
                    
                    //stats
                    DemonStatdgv.Rows.Clear();
                    string[] statnames = new string[7];
                    statnames[0] = "HP";
                    statnames[1] = "MP";
                    statnames[2] = "STR";
                    statnames[3] = "VIT";
                    statnames[4] = "MAG";
                    statnames[5] = "AGI";
                    statnames[6] = "LU";
                    for (int i = 0; i < 7; i++)
                    {
                        DemonStatdgv.Rows.Add(statnames[i], dmndata[i], dmndata[i + 7], dmndata[i + 14]);
                    }

                    //skills
                    DSpanel.Controls.Clear();
                    int y = 22;
                    int cbr = 0;
                    for (int i = 0; i < 8; i++)
                    {

                        string[] db = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\skills.txt");
                        ComboBox comboBox = new ComboBox();
                        comboBox.BindingContext = new BindingContext();
                        comboBox.DataSource = db;
                        //comboBox.SelectedIndex = y;
                        if (i < 4)
                        {
                            comboBox.Location = new Point(0, i * 25 + 5);
                        }
                        else
                        {
                            comboBox.Location = new Point(200, cbr * 25 + 5);
                            cbr++;
                        }

                        comboBox.SelectedIndex = dmndata[y];
                        DSpanel.Controls.Add(comboBox);

                        y++;
                    }
                }
            }

        }

        private void Demonsavebtn_Click(object sender, EventArgs e)
        {
            MemoryStream stream = new MemoryStream(File.ReadAllBytes(svpath));
            BinaryWriter bw = new BinaryWriter(stream);
            writingsave = true;


            int stat = 0;
                int[] offsets = Demoninfo.demonoverwriteoff(Convert.ToInt32(numericUpDown1.Value));
                
                //stats
                for (int y = 0; y < 7; y++)
                {
                    bw.BaseStream.Position = offsets[0]+(y*2);
                //MessageBox.Show(offsets[0]+(y*2).ToString("X2"));
                    bw.Write(BitConverter.GetBytes(Convert.ToInt32(DemonStatdgv.Rows[y].Cells[1].Value)),0,2);
                    bw.BaseStream.Position = offsets[1]+(y*2);
                    bw.Write(BitConverter.GetBytes(Convert.ToInt32(DemonStatdgv.Rows[y].Cells[2].Value)), 0, 2);
                    bw.BaseStream.Position = offsets[2]+(y*2);
                    bw.Write(BitConverter.GetBytes(Convert.ToInt32(DemonStatdgv.Rows[y].Cells[3].Value)), 0, 2);

                }
                //id
                bw.BaseStream.Position = offsets[3];
                bw.Write(BitConverter.GetBytes(DemonIDbox.SelectedIndex+1), 0, 2);
                byte[] testbyte = BitConverter.GetBytes(DemonIDbox.SelectedIndex);
                string testhex = BitConverter.ToString(testbyte, 0, 2).Replace("-","");
                //MessageBox.Show(BitConverter.GetBytes(DemonIDbox.SelectedIndex + 1).ToString());
                //skills
                for(int z = 0;z < 8; z++)
                {
                    bw.BaseStream.Position = offsets[4+z];
                    ComboBox cbb = DSpanel.Controls[z] as ComboBox;
                    bw.Write(BitConverter.GetBytes(cbb.SelectedIndex), 0, 4);

                }

            bw.Close();
            




            File.WriteAllBytes(svpath, stream.ToArray());
            MessageBox.Show("Saved current demon to " + svpath);
            writingsave = false;
        }
    }
}
