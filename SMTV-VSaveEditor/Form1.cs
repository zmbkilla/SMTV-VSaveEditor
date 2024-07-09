using System;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.InteropServices;

namespace SMTV_VSaveEditor
{
    public partial class Form1 : Form
    {

        public string default_file = Directory.GetCurrentDirectory()+"\\default";
        public int filecheck = 0x40;
        public string savepath;
        public int ploff=0x9d0;

        //allow moving windows

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }



        Offsets GSOffsets = new Offsets();
        public Form1()
        {
            InitializeComponent();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
            if(!File.Exists(default_file))
            {
                var setfile = File.CreateText(default_file);
                setfile.WriteLine("keep");
                setfile.WriteLine("path:");
                MessageBox.Show("created settings file");
            }


            

            
                string[] lines = File.ReadAllLines(default_file);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains("path:"))
                    {
                        savepath = lines[i].Replace("path:", "");
                    if(savepath != "")
                    {
                        MessageBox.Show("Loaded save from: " + savepath);
                    }
                    
                    }
                }
            
            
        }

        

        private void PLDatabtn_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            var pld = new PLData();
            


            
            string fname = "",lname="";
            if (File.Exists(savepath))
            {
                MemoryStream ms = new MemoryStream(File.ReadAllBytes(savepath));
                BinaryReader reader = new BinaryReader(ms);
                pld.path = savepath;
                pld.offset = ploff;
                
                ms.Position = GSOffsets.FN3;

                
                fname = Encoding.Unicode.GetString(reader.ReadBytes(18));
                pld.Controls["textBox1"].Text = fname;
                ms.Position = GSOffsets.LN2;
                lname = Encoding.Unicode.GetString(reader.ReadBytes(18));
                pld.Controls["textBox2"].Text= lname;
                
                
                var stattable = pld.Controls.Find("statview",true);
                DataGridView dgv = stattable[0] as DataGridView;
               
                string[] statnames = new string[7];
                statnames[0] = "HP";
                statnames[1] = "MP";
                statnames[2] = "STR";
                statnames[3] = "VIT";
                statnames[4] = "MAG";
                statnames[5] = "AGI";
                statnames[6] = "LU";
                int[] plstatoffsets = new int[21];
                
                plstatoffsets[0] = GSOffsets.HPB;
                plstatoffsets[1] = GSOffsets.MPB;
                plstatoffsets[2] = GSOffsets.STB;
                plstatoffsets[3] = GSOffsets.VIB;
                plstatoffsets[4] = GSOffsets.MAB;
                plstatoffsets[5] = GSOffsets.AGB;
                plstatoffsets[6] = GSOffsets.LUB;
                plstatoffsets[7] = GSOffsets.HPA;
                plstatoffsets[8] = GSOffsets.MPA;
                plstatoffsets[9] = GSOffsets.STA;
                plstatoffsets[10] = GSOffsets.VIA;
                plstatoffsets[11] = GSOffsets.MAA;
                plstatoffsets[12] = GSOffsets.AGA;
                plstatoffsets[13] = GSOffsets.LUA;
                plstatoffsets[14] = GSOffsets.HPC;
                plstatoffsets[15] = GSOffsets.MPC;
                plstatoffsets[16] = GSOffsets.STC;
                plstatoffsets[17] = GSOffsets.VIC;
                plstatoffsets[18] = GSOffsets.MAC;
                plstatoffsets[19] = GSOffsets.AGC;
                plstatoffsets[20] = GSOffsets.LUC;


                for (int i = 0; i < statnames.Length; i++)
                {
                    string stat = "";
                    string stata = "";
                    string statc = "";
                    string reverse = "";

                    ms.Position = plstatoffsets[i];
                    stat = BitConverter.ToString(reader.ReadBytes(2)).Replace("-", "");
                    reverse = stat;
                    stat = stat.Replace(stat.Substring(0, 2), stat.Substring(2, 2));
                    stat = stat.Insert(2,reverse.Substring(0,2));
                    stat = stat.Remove(4, 2);
                    stat = Int32.Parse(stat,System.Globalization.NumberStyles.HexNumber).ToString();
                    ms.Position = plstatoffsets[i + 7];
                    stata = BitConverter.ToString(reader.ReadBytes(2)).Replace("-", "");
                    reverse = stata;
                    stata = stata.Replace(stata.Substring(0, 2), stata.Substring(2, 2));
                    stata = stata.Insert(2, reverse.Substring(0, 2));
                    stata = stata.Remove(4, 2);
                    stata = Int32.Parse(stata, System.Globalization.NumberStyles.HexNumber).ToString();
                    ms.Position = plstatoffsets[i + 14];
                    statc = BitConverter.ToString(reader.ReadBytes(2)).Replace("-", "");
                    reverse = statc;
                    statc = statc.Replace(statc.Substring(0, 2), statc.Substring(2, 2));
                    statc = statc.Insert(2, reverse.Substring(0, 2));
                    statc = statc.Remove(4, 2);
                    statc = Int32.Parse(statc, System.Globalization.NumberStyles.HexNumber).ToString();


                    dgv.Rows.Add(statnames[i], stat,stata,statc);
                    
                }

                //skills
                var skilltab = pld.Controls.Find("SPanel", true);
                //DataGridView dgvskill = skilltab[0] as DataGridView;
                
                string[] skills = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\skills.txt");
                int[] PLskilloffs = new int[8];

                PLskilloffs[0] = GSOffsets.SKILL1F; PLskilloffs[1] = GSOffsets.SKILL2F; PLskilloffs[2] = GSOffsets.SKILL3F; PLskilloffs[3] = GSOffsets.SKILL4F; PLskilloffs[4] = GSOffsets.SKILL5F; PLskilloffs[5] = GSOffsets.SKILL6F; PLskilloffs[6] = GSOffsets.SKILL7F; PLskilloffs[7] = GSOffsets.SKILL8F;

                
                
                
                
                //load excel as db
                
                Panel skp = pld.SPanel;
                int z = 0;
                for (int i = 0;i < 8; i++)
                {
                    ComboBox cb = new ComboBox();
                    cb.BindingContext = new BindingContext();
                    
                    cb.DataSource = skills;
                    if(i < 4)
                    {
                        cb.Location = new Point(0, i * 25 + 5);
                    }
                    else
                    {
                        cb.Location = new Point(150, z * 25 + 5);
                        z++;
                    }
                    
                    skp.Controls.Add(cb);

                }
                

                
                


                
                
               
                DataSet ds = new DataSet();
                string[] sload = new string[445];
                sload[0] = "none";
                for (int i = 0; i < sload.Length; i++)
                {
                    sload[i] = skills[i];
                }
                int[] skillid = new int[8];
                int x = 1;
                for (int i = 0; i < 8; i++)
                {
                    ms.Position = PLskilloffs[i];
                    
                    int skillint = BitConverter.ToInt32(reader.ReadBytes(4), 0);
                    skillid[i] = skillint;
                    ComboBox pcb = skp.Controls[i] as ComboBox;
                    pcb.SelectedIndex = skillint;

                    
                    
                    
                }

                //Resist

                int[] resistoff = new int[14];
                resistoff[0] = GSOffsets.ResPHY;
                resistoff[1] = GSOffsets.ResFIR;
                resistoff[2] = GSOffsets.ResICE;
                resistoff[3] = GSOffsets.ResELE;
                resistoff[4] = GSOffsets.ResFOR;
                resistoff[5] = GSOffsets.ResLIG;
                resistoff[6] = GSOffsets.ResDAR;

                resistoff[7] = GSOffsets.ResPHYC;
                resistoff[8] = GSOffsets.ResFIRC;
                resistoff[9] = GSOffsets.ResICEC;
                resistoff[10] = GSOffsets.ResELEC;
                resistoff[11] = GSOffsets.ResFORC;
                resistoff[12] = GSOffsets.ResLIGC;
                resistoff[13] = GSOffsets.ResDARC;

                string[] resisttext = new string[4];
                resisttext[0] = "Null";
                resisttext[1] = "Resist";
                resisttext[2] = "Normal";
                resisttext[3] = "Weak";
                string[] stats = new string[7];
                stats[0] = "PHYSICAL";
                stats[1] = "FIRE";
                stats[2] = "ICE";
                stats[3] = "ELECTRIC";
                stats[4] = "FORCE";
                stats[5] = "LIGHT";
                stats[6] = "DARK";
                Panel resistP = pld.PLResistS;
                for(int i = 0; i < 7; i++)
                {
                    ComboBox cbb = new ComboBox();
                    
                    cbb.BindingContext = new BindingContext();
                    cbb.DataSource = resisttext;
                    cbb.Size = new Size(50, 20);
                    
                        
                       cbb.Location = new Point(75, 5 + (i * 25));
                    
                    
                    
                    resistP.Controls.Add(cbb);

                }


                for(int i = 0; i < 7; i++)
                {
                    ms.Position = resistoff[i+7];
                    ComboBox cbb = pld.PLResistS.Controls[i] as ComboBox;
                    var val = BitConverter.ToString(reader.ReadBytes(1)).Replace("-", "");
                    if (val == "00")
                    {
                        cbb.SelectedIndex = 0;
                    } else if (val == "32")
                    {
                        cbb.SelectedIndex = 1;
                    } else if(val == "64")
                    {
                        cbb.SelectedIndex= 2;
                    } else if (val == "7D")
                    {
                        cbb.SelectedIndex = 3;
                    }
                }

                for (int i = 0; i < 7; i++)
                {
                    Label lbl = new Label();
                    lbl.Location = new Point(5,10+(i*25));
                    lbl.Text = stats[i];
                    pld.PLResistS.Controls.Add(lbl);
                }


                //Potentials

                int[] potoffs = new int[11];
                potoffs[0] = GSOffsets.POTPHY;
                potoffs[1] = GSOffsets.POTFIR;
                potoffs[2] = GSOffsets.POTICE;
                potoffs[3] = GSOffsets.POTELE;
                potoffs[4] = GSOffsets.POTFOR;
                potoffs[5] = GSOffsets.POTLIG;
                potoffs[6] = GSOffsets.POTDAR;
                potoffs[7] = GSOffsets.POTALM;
                potoffs[8] = GSOffsets.POTAIL;
                potoffs[9] = GSOffsets.POTHEA;
                potoffs[10] = GSOffsets.POTSUP;

                string[]pottext = new string[11];
                pottext[0] = "PHYSICAL";
                pottext[1] = "FIRE";
                pottext[2] = "ICE";
                pottext[3] = "ELECTRIC";
                pottext[4] = "FORCE";
                pottext[5] = "LIGHT";
                pottext[6] = "DARK";
                pottext[7] = "ALMIGHTY";
                pottext[8] = "AILMENT";
                pottext[9] = "HEALING";
                pottext[10] = "SUPPORT";

                for (int i = 0;i < 11; i++)
                {
                    Panel pn = pld.Potential as Panel;
                    NumericUpDown nm = new NumericUpDown();
                    nm.BindingContext = new BindingContext();
                    nm.Maximum = 9;
                    nm.Minimum = -9;
                    nm.Size = new Size(50, 20);
                    nm.Location = new Point(75, 5 + (i * 25));
                    pn.Controls.Add(nm);
                }
                for (int i = 0; i < 11; i++)
                {
                    Panel pn = pld.Potential as Panel;
                    Label lbl = new Label();
                    lbl.BindingContext = new BindingContext();
                    lbl.Text = pottext[i];
                    lbl.Location = new Point(5, 10 + (i * 25));
                    pn.Controls.Add(lbl);
                }

                for (int i=0; i < 11; i++)
                {
                    ms.Position = potoffs[i];
                    Panel pn = pld.Potential as Panel;
                    NumericUpDown nm = pn.Controls[i] as NumericUpDown;
                    string readval = BitConverter.ToString(reader.ReadBytes(2)).Replace("-", "");
                    string g2 = readval.Substring(0, 2);
                    readval = readval.Replace(readval.Substring(0, 2), readval.Substring(2, 2));
                    readval = readval.Insert(2, g2);
                    readval = readval.Remove(4, 2);
                    int val = Int32.Parse(readval,System.Globalization.NumberStyles.HexNumber);
                    if(val <= 9)
                    {
                        nm.Value = val;
                    }else if (val > 9)
                    {
                        nm.Value = 65535 - val;
                    }
                }

                //for (int i = 0; i < maxskill; i++)
                //{
                //    string skillhex = BitConverter.ToString(reader.ReadBytes(2)).Replace("-", "");
                //    string skillstr = "";
                //    for (int y = 0; y < skills.Length; y++)
                //    {
                //        if (skills[y].Contains(skillhex))
                //        {
                //            skillstr = skills[y].Replace(skillhex, "");
                //        }
                //    }
                //
                //    dgvskill.Rows.Add(i,skillstr);
                //    ms.Position += 6;
                //}

                panel1.Controls.Add(pld);
            }
           
        }


        public static DataTable ReadDemonDB()
        {
            var fileName = string.Format("{0}\\DemonDB.xls", Directory.GetCurrentDirectory());
            var filetest = Encoding.ASCII.GetString(
    Encoding.Convert(
        Encoding.UTF8,
        Encoding.GetEncoding(
            Encoding.ASCII.EncodingName,
            new EncoderReplacementFallback(string.Empty),
            new DecoderExceptionFallback()
            ),
        Encoding.UTF8.GetBytes(fileName)
    ));
            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; data source={0};User Id =admin;Password=;Extended Properties=Excel 8.0;", fileName);

            var adapter = new OleDbDataAdapter("SELECT * FROM [DemonList$]", connectionString);
            var ds = new DataSet();
            var data = new DataTable();
            adapter.Fill(data);




            adapter.Dispose();
            ds.Dispose();

            return data;
        }






        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Demonbtn_Click(object sender, EventArgs e)
        {
            var dmn = new Demon();
            dmn.svpath = savepath;
            panel1.Controls.Clear();
            panel1.Controls.Add(dmn);
        }

        private void openDecryptedSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if path exist in setting file
            string[] settings = File.ReadAllLines(default_file);
            string pathloc = "";
            for (int i = 0; i < settings.Length; i++)
            {
                if (settings[i].Contains("path:"))
                {
                    pathloc = settings[i].Replace("path:", "");
                }
            }
            byte[] savedata;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            while (openFileDialog.FileName == "")
            {
                openFileDialog.ShowDialog(this);
            }

            savedata = File.ReadAllBytes(openFileDialog.FileName);
            //save location
            for (int i = 0; i < settings.Length; i++)
            {
                if (settings[i].Contains("path:"))
                {
                    settings[i] = "path:" + openFileDialog.FileName;
                }

            }
            File.WriteAllLines(default_file, settings);
            pathloc = openFileDialog.FileName;


            savedata = File.ReadAllBytes(pathloc);




            MemoryStream ms = new MemoryStream(savedata);

            BinaryReader reader = new BinaryReader(ms);
            ms.Position = 0x40;
            byte[] readb = reader.ReadBytes(4);
            string checks = "";

            checks = Encoding.ASCII.GetString(readb);

            if (checks != "GVAS")
            {
                MessageBox.Show("Error: invalid Save file", "Error");
            }

            savepath = pathloc;
            MessageBox.Show("Loaded save from: " + savepath);
        }
    }
}
