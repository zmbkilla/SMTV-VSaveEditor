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

namespace SMTV_VSaveEditor
{
    public partial class Form1 : Form
    {

        public string default_file = Directory.GetCurrentDirectory()+"\\default";
        public int filecheck = 0x40;
        public string savepath;
        public int ploff=0x9d0;
        
        
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
                    MessageBox.Show("Loaded save from: " + savepath);
                    }
                }
            
            
        }

        private void Opensavebtn_Click(object sender, EventArgs e)
        {
            //check if path exist in setting file
            string[] settings = File.ReadAllLines(default_file);
            string pathloc = "";
            for(int i = 0;i<settings.Length;i++)
            {
                if (settings[i].Contains("path:"))
                {
                    pathloc = settings[i].Replace("path:", "");
                }
            }
            byte[] savedata;
            if(!File.Exists(pathloc))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                while (openFileDialog.FileName == "")
                {
                    openFileDialog.ShowDialog(this);
                }

                savedata = File.ReadAllBytes(openFileDialog.FileName);
                //save location
                for (int i = 0;i<settings.Length;i++)
                {
                    if (settings[i].Contains("path:"))
                    {
                        settings[i] += openFileDialog.FileName;
                    }

                }
                File.WriteAllLines(default_file,settings);
                pathloc = openFileDialog.FileName;
            }
            
            savedata = File.ReadAllBytes(pathloc);
            

            

            MemoryStream ms = new MemoryStream(savedata);

            BinaryReader reader = new BinaryReader(ms);
            ms.Position = 0x40;
            byte[] readb = reader.ReadBytes(4);
            string checks = "";
            
            checks = Encoding.ASCII.GetString(readb);
            
            if(checks != "GVAS")
            {
                MessageBox.Show("Error: invalid Save file", "Error");
            }

            savepath = pathloc;

        }

        private void PLDatabtn_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            var pld = new PLData
            {
                Dock = DockStyle.Fill,
                
            };


            panel1.Controls.Add(pld);
            string fname = "",lname="";
            if (File.Exists(savepath))
            {
                MemoryStream ms = new MemoryStream(File.ReadAllBytes(savepath));
                BinaryReader reader = new BinaryReader(ms);
                pld.path = savepath;
                pld.offset = ploff;
                
                ms.Position = ploff;

                
                fname = Encoding.Unicode.GetString(reader.ReadBytes(18));
                pld.Controls["textBox1"].Text = fname;
                ms.Position = ploff + 24;
                lname = Encoding.Unicode.GetString(reader.ReadBytes(18));
                pld.Controls["textBox2"].Text= lname;
                int plstats = ploff - 72;
                int plstata = plstats + 16;
                int plstatc = plstata + 16;
                ms.Position = plstats;
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
                
                for (int i = 0; i < statnames.Length; i++)
                {
                    string stat = BitConverter.ToString(reader.ReadBytes(1)).Replace("-","");
                    ms.Position = plstata;
                    string stata = BitConverter.ToString(reader.ReadBytes(1)).Replace("-", "");
                    ms.Position = plstatc;
                    string statc = BitConverter.ToString(reader.ReadBytes(1)).Replace("-", "");
                    stat = Int32.Parse(stat,System.Globalization.NumberStyles.HexNumber).ToString();
                    stata = Int32.Parse(stata, System.Globalization.NumberStyles.HexNumber).ToString();
                    statc = Int32.Parse(statc, System.Globalization.NumberStyles.HexNumber).ToString();
                    dgv.Rows.Add(statnames[i], stat,stata,statc);
                    plstats +=2;
                    plstata = plstats + 16;
                    plstatc = plstata + 16;
                    ms.Position=plstats;
                }

                //skills
                var skilltab = pld.Controls.Find("skillview", true);
                DataGridView dgvskill = skilltab[0] as DataGridView;
                string[] skills = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\skills.txt");
                int skilloff = ploff + 108;
                int maxskill = 8;
                ms.Position = skilloff;
                //load excel as db
                //DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = "Skill Name";
                //col.DataSource = ReadDemonDB();
                dgvskill.Columns.Add(col);


                for (int i = 0; i < maxskill; i++)
                {
                    string skillhex = BitConverter.ToString(reader.ReadBytes(2)).Replace("-", "");
                    string skillstr = "";
                    for (int y = 0; y < skills.Length; y++)
                    {
                        if (skills[y].Contains(skillhex))
                        {
                            skillstr = skills[y].Replace(skillhex, "");
                        }
                    }

                    dgvskill.Rows.Add(i,skillstr);
                    ms.Position += 6;
                }


            }
           
        }




        




        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
