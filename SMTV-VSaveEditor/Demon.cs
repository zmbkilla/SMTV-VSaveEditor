using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMTV_VSaveEditor
{
    public partial class Demon : UserControl
    {
        public byte[] svpath;
        public int off = 0xb60;
        public bool writingsave = false;
        Offsets GSoff = new Offsets();
        Form1 fm = new Form1();
        List<int[]> dsinfo = new List<int[]>();
        DemonList dmnlist = new DemonList();
        public Demon()
        {
            InitializeComponent();
        }

        private void Demon_Load(object sender, EventArgs e)
        {
            //dsinfo = Demoninfo.Demonslots(fm.svdata);

            //DemonIDbox.DataSource = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\demon.txt");
            DemonIDbox.DisplayMember = "Value";
            DemonIDbox.ValueMember = "Key";
            DemonIDbox.DataSource = new BindingSource(dmnlist.DemonIDs, null);

            
            if(svpath != null)
            {
                byte[] ttt = svpath;
                int[]dmndata = Demoninfo.Demondata(GSoff.DEMONHPB +(Convert.ToInt32(numericUpDown1.Value)*424),ttt);
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

                //resist

                DResist.Controls.Clear();
                string[] boxval = new string[6];
                boxval[0] = "NULL";
                boxval[1] = "RESIST";
                boxval[2] = "NORMAL";
                boxval[3] = "WEAK";
                boxval[4] = "Drain";
                boxval[5] = "REPEL";
                for (int i = 0; i < 7; i++)
                {
                    ComboBox comboBox = new ComboBox();

                    comboBox.BindingContext = new BindingContext();
                    comboBox.DataSource= boxval;
                    comboBox.Location = new Point(50, i*25+5);
                    switch (dmndata[i + 30])
                    {
                        case 0:
                            comboBox.SelectedIndex = 0; break;
                        case 50:
                            comboBox.SelectedIndex = 1; break;
                        case 100: comboBox.SelectedIndex = 2; break;
                        case 125: comboBox.SelectedIndex = 3; break;
                        case 999: comboBox.SelectedIndex=4; break;
                        case 1000:comboBox.SelectedIndex = 5; break;
                    }

                    DResist.Controls.Add(comboBox);
                }
                string[] res = new string[7];
                res[0] = "Physical";
                res[1] = "Fire";
                res[2] = "Ice";
                res[3] = "Electric";
                res[4] = "Force";
                res[5] = "Dark";
                res[6] = "Light";
                for (int i = 0; i < 7; i++)
                {
                    Label lbl = new Label();
                    lbl.Location = new Point(0, i * 25 + 5);
                    lbl.Text = res[i];
                    DResist.Controls.Add(lbl);

                }

                //potential
                DPots.Controls.Clear();
                string[] pots = new string[11];
                pots[0] = "Physical";
                pots[1] = "Fire";
                pots[2] = "Ice";
                pots[3] = "Electric";
                pots[4] = "Force";
                pots[5] = "Dark";
                pots[6] = "Light";
                pots[7] = "Almighty";
                pots[8] = "Ailment";
                pots[9] = "Healing";
                pots[10] = "Support";
                
                for (int i = 0; i < 11; i++)
                {
                    NumericUpDown nm = new NumericUpDown();
                    nm.BindingContext = new BindingContext();
                    int checkval = dmndata[i + 37];
                    if (checkval > 9)
                    {
                        int compute = 255 - checkval;
                        compute = (compute * -1) - 1;
                        checkval = compute;
                    }

                    nm.Minimum = -9;
                    nm.Maximum = 9;
                    nm.Location = new Point(50, i * 25 + 5);
                    nm.Value = checkval;
                    DPots.Controls.Add(nm);
                }
                for(int i = 0; i < 11; i++)
                {
                    Label lbl = new Label();
                    lbl.BindingContext = new BindingContext();
                    lbl.Location = new Point(0,i * 25 + 5);
                    lbl.Text = pots[i];
                    DPots.Controls.Add(lbl);
                }

                //innate
                SkillsData sd = new SkillsData();

                DIScmb.DisplayMember = "Value";
                DIScmb.ValueMember = "Key";
                DIScmb.DataSource = new BindingSource(sd.ISkillIds, null);
                DIScmb.SelectedValue = dmndata[48];


            }
            
        }

        private void DemonIDbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = "dev";
            var myKey = dmnlist.DemonIDs.FirstOrDefault(x => x.Value == DemonIDbox.SelectedValue.ToString()).Key;
            switch (myKey.ToString().Length)
            {
                case 1:
                    id += "00" + Convert.ToString(DemonIDbox.SelectedIndex);
                    //id += ".png";

                    break;
                case 2:
                    id += "0" + Convert.ToString(DemonIDbox.SelectedIndex);
                    //id += ".png";
                    break;
                case 3:
                    id += Convert.ToString(DemonIDbox.SelectedIndex);
                    //id += ".png";
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

                if (svpath != null)
                {
                    if (numericUpDown1.Value == 8)
                    {

                    }
                    byte[] ttt = svpath;
                    int[] dmndata = Demoninfo.Demondata(GSoff.DEMONHPB + (Convert.ToInt32(numericUpDown1.Value) * 424), ttt);
                    //List<int[]> ds = Demoninfo.Demonslots(svpath);
                    //int[] dmndata = dsinfo.ElementAt(Convert.ToInt32(numericUpDown1.Value));
                    bool execute = true;
                    
                    if(dmndata[21] != 65535 && execute != false)
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


                    //resist

                    DResist.Controls.Clear();
                    string[] boxval = new string[4];
                    boxval[0] = "NULL";
                    boxval[1] = "RESIST";
                    boxval[2] = "NORMAL";
                    boxval[3] = "WEAK";
                    for (int i = 0; i < 7; i++)
                    {
                        ComboBox comboBox = new ComboBox();

                        comboBox.BindingContext = new BindingContext();
                        comboBox.DataSource = boxval;
                        comboBox.Location = new Point(50, i * 25 + 5);
                        switch (dmndata[i + 30])
                        {
                            case 0:
                                comboBox.SelectedIndex = 0; break;
                            case 50:
                                comboBox.SelectedIndex = 1; break;
                            case 100: comboBox.SelectedIndex = 2; break;
                            case 125: comboBox.SelectedIndex = 3; break;
                        }

                        DResist.Controls.Add(comboBox);
                    }
                    string[] res = new string[7];
                    res[0] = "Physical";
                    res[1] = "Fire";
                    res[2] = "Ice";
                    res[3] = "Electric";
                    res[4] = "Force";
                    res[5] = "Dark";
                    res[6] = "Light";
                    for (int i = 0; i < 7; i++)
                    {
                        Label lbl = new Label();
                        lbl.Location = new Point(0, i * 25 + 5);
                        lbl.Text = res[i];
                        DResist.Controls.Add(lbl);

                    }

                    //potential
                    DPots.Controls.Clear();
                    string[] pots = new string[11];
                    pots[0] = "Physical";
                    pots[1] = "Fire";
                    pots[2] = "Ice";
                    pots[3] = "Electric";
                    pots[4] = "Force";
                    pots[5] = "Dark";
                    pots[6] = "Light";
                    pots[7] = "Almighty";
                    pots[8] = "Ailment";
                    pots[9] = "Healing";
                    pots[10] = "Support";

                    for (int i = 0; i < 11; i++)
                    {
                        NumericUpDown nm = new NumericUpDown();
                        nm.BindingContext = new BindingContext();
                        int checkval = dmndata[i + 37];
                        if (checkval > 9)
                        {
                            int compute = 255 - checkval;
                            compute = (compute * -1) - 1;
                            checkval = compute;
                        }
                        nm.Minimum = -9;
                        nm.Maximum = 9;
                        nm.Location = new Point(50, i * 25 + 5);
                        nm.Value = checkval;
                        DPots.Controls.Add(nm);
                    }
                    for (int i = 0; i < 11; i++)
                    {
                        Label lbl = new Label();
                        lbl.BindingContext = new BindingContext();
                        lbl.Location = new Point(0, i * 25 + 5);
                        lbl.Text = pots[i];
                        DPots.Controls.Add(lbl);
                    }
                    //innate
                    DIScmb.SelectedValue = dmndata[48];

                }
            }

        }

        private void Demonsavebtn_Click(object sender, EventArgs e)
        {
            MemoryStream stream = new MemoryStream(fm.svdata);
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
                bw.Write(BitConverter.GetBytes(DemonIDbox.SelectedIndex), 0, 2);
                byte[] testbyte = BitConverter.GetBytes(DemonIDbox.SelectedIndex);
                string testhex = BitConverter.ToString(testbyte, 0, 2).Replace("-","");
                //MessageBox.Show(BitConverter.GetBytes(DemonIDbox.SelectedIndex + 1).ToString());
                //skills
                for(int z = 0;z < 8; z++)
                {
                    bw.BaseStream.Position = offsets[4+z];
                    ComboBox cbb = DSpanel.Controls[z] as ComboBox;
                    bw.Write(BitConverter.GetBytes(cbb.SelectedIndex), 0, 2);

                }
                //resist

                for (int i = 0;i < 7; i++)
                {
                    int pos = offsets[12] + (2*i);
                    bw.BaseStream.Position = pos;
                    ComboBox cbb = DResist.Controls[i] as ComboBox;
                    int val = 0;
                    switch(cbb.SelectedIndex)
                    {
                        case 0: val = 0; break;
                        case 1: val = 50; break;
                        case 2:val = 100; break;
                        case 3:val = 125;break;
                        case 4: val = 999;break;
                        case 5: val = 1000;break;
                    }
                bw.Write(BitConverter.GetBytes(val), 0, 2);
                int pos2 = pos - 56;
                bw.BaseStream.Position = pos2;
                bw.Write(BitConverter.GetBytes(val), 0, 2);
                }
                //pot

                for (int i = 0 ; i < 11 ; i++)
                {
                    int pos = offsets[13] + (2*i);
                    bw.BaseStream.Position = pos;
                    NumericUpDown nm = DPots.Controls[i] as NumericUpDown;
                    int val = 0;
                    val = Convert.ToInt32(nm.Value);
                    if(val < 0)
                    {
                    val = 65535 - ((val * -1) - 1);
                    }
                    bw.Write(BitConverter.GetBytes(val),0,2);
                    int pos2 = pos - 56;
                    bw.BaseStream.Position = pos2;
                    bw.Write(BitConverter.GetBytes(val), 0, 2);
            }


                //innate
                





            bw.Close();
            




            //File.WriteAllBytes(svpath, stream.ToArray());
            MessageBox.Show("Saved current demon to " + svpath);
            writingsave = false;
        }
    }
}
