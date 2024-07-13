using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
namespace SMTV_VSaveEditor
{
    public partial class PLData : UserControl
    {
        public Form1 formstuff = new Form1();
        public string path = "";
        public int offset;
        public int reset;
        Offsets ploffs = new Offsets();
        public PLData()
        {
            InitializeComponent();
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            reset = offset;
            //write name
            //byte[] fnameb = new byte[18];
            //char[] fnamec = textBox1.Text.ToCharArray();
            //string fname = string.Join(new char[] {(char)0x00}.ToString(), fnamec);
            //fnameb = Encoding.ASCII.GetBytes(fname);
            //
            //byte[] lnameb = new byte[18];
            //char[] lnamec = textBox2.Text.ToCharArray();
            //string lname = string.Join("0", lnamec);
            //lnameb = Encoding.ASCII.GetBytes(lname);
            
           

            byte[]fnameb = Encoding.Unicode.GetBytes(textBox1.Text);
            byte[]lnameb = Encoding.Unicode.GetBytes(textBox2.Text);

            Array.Resize(ref fnameb, 12);
            Array.Resize(ref lnameb, 10);

            byte[] data = File.ReadAllBytes(path);
            MemoryStream ms = new MemoryStream(formstuff.svdata);
            BinaryWriter bw = new BinaryWriter(ms);


            
           


            bw.BaseStream.Position = ploffs.FN1;
            bw.Write(fnameb);
            bw.BaseStream.Position = ploffs.LN1;
            
            bw.Write(lnameb);
            //fname only
            bw.BaseStream.Position = ploffs.FN2;
            bw.Write(fnameb);
            //name combined
            bw.BaseStream.Position = ploffs.FN3;
            bw.Write(fnameb, 0, fnameb.Length);
            bw.BaseStream.Position = ploffs.LN2;
            bw.Write(lnameb, 0, lnameb.Length);
            
            
            //stats
            offset = reset;
            int[] plstatpos = new int[21];
            plstatpos[0] = ploffs.HPB;
            plstatpos[1] = ploffs.MPB;
            plstatpos[2] = ploffs.STB;
            plstatpos[3] = ploffs.VIB;
            plstatpos[4] = ploffs.MAB;
            plstatpos[5] = ploffs.AGB;
            plstatpos[6] = ploffs.LUB;

            plstatpos[7] = ploffs.HPA;
            plstatpos[8] = ploffs.MPA;
            plstatpos[9] = ploffs.STA;
            plstatpos[10] = ploffs.VIA;
            plstatpos[11] = ploffs.MAA;
            plstatpos[12] = ploffs.AGA;
            plstatpos[13] = ploffs.LUA;

            plstatpos[14] = ploffs.HPC;
            plstatpos[15] = ploffs.MPC;
            plstatpos[16] = ploffs.STC;
            plstatpos[17] = ploffs.VIC;
            plstatpos[18] = ploffs.MAC;
            plstatpos[19] = ploffs.AGC;
            plstatpos[20] = ploffs.LUC;



            


            
            for(int i = 0; i < 7; i++)
            {
                bw.BaseStream.Position = plstatpos[i];


                byte[] sbase = BitConverter.GetBytes(Convert.ToInt32(statview.Rows[i].Cells[1].Value));
                byte[] sadd = BitConverter.GetBytes(Convert.ToInt32(statview.Rows[i].Cells[2].Value));
                byte[] sc = BitConverter.GetBytes(Convert.ToInt32(statview.Rows[i].Cells[3].Value));
                
                
                bw.Write(sbase,0,2);
                bw.BaseStream.Position = plstatpos[i + 7];
                
                

                bw.Write(sadd,0,2);
                bw.BaseStream.Position = plstatpos[i+14];
                
                
                bw.Write(sc,0,2);
                
                
                
            }
            //skills
            offset = reset;
            int skilloff = offset + 108;
            int skilloffa = 8;

            int[] plskilloffs = new int[8];
            plskilloffs[0] = ploffs.SKILL1F;
            plskilloffs[1] = ploffs.SKILL2F;
            plskilloffs[2] = ploffs.SKILL3F;
            plskilloffs[3] = ploffs.SKILL4F;
            plskilloffs[4] = ploffs.SKILL5F;
            plskilloffs[5] = ploffs.SKILL6F;
            plskilloffs[6] = ploffs.SKILL7F;
            plskilloffs[7] = ploffs.SKILL8F;


            
            
            for (int i = 0; i < 8; i++)
            {
                bw.BaseStream.Position = plskilloffs[i];
                
                
                ComboBox cbb = SPanel.Controls[i] as ComboBox;
                byte[] skbyte = BitConverter.GetBytes(cbb.SelectedIndex);
                bw.Write(skbyte, 0, 2);
                
                
            }

            //resistance

            //int[] resistoff = new int[14];
            //resistoff[0] = ploffs.ResPHY;
            //resistoff[1] = ploffs.ResFIR;
            //resistoff[2] = ploffs.ResICE;
            //resistoff[3] = ploffs.ResELE;
            //resistoff[4] = ploffs.ResFOR;
            //resistoff[5] = ploffs.ResLIG;
            //resistoff[6] = ploffs.ResDAR;
            //
            //resistoff[7] = ploffs.ResPHYC;
            //resistoff[8] = ploffs.ResFIRC;
            //resistoff[9] = ploffs.ResICEC;
            //resistoff[10] = ploffs.ResELEC;
            //resistoff[11] = ploffs.ResFORC;
            //resistoff[12] = ploffs.ResLIGC;
            //resistoff[13] = ploffs.ResDARC;
            //
            //for (int i = 0; i < 7; i++)
            //{
            //    int resistval = 100;
            //    ComboBox cbb = PLResistS.Controls[i] as ComboBox;
            //    switch(cbb.SelectedIndex)
            //    {
            //        case 0:
            //            resistval = 0;
            //            break;
            //        case 1:
            //            resistval = 50;
            //            break;
            //        case 2:
            //            resistval = 100;
            //            break;
            //        case 3:
            //            resistval = 125;
            //            break;
            //    }
            //    bw.BaseStream.Position = resistoff[i];
            //    bw.Write(BitConverter.GetBytes(resistval),0,2);
            //    bw.BaseStream.Position = resistoff[i+7];
            //    bw.Write(BitConverter.GetBytes(resistval), 0, 2);
            //
            //}
            //
            ////potentials
            //
            //int[]potoffs = new int[11];
            //potoffs[0] = ploffs.POTPHY;
            //potoffs[1] = ploffs.POTFIR;
            //potoffs[2] = ploffs.POTICE;
            //potoffs[3] = ploffs.POTELE;
            //potoffs[4] = ploffs.POTFOR;
            //potoffs[5] = ploffs.POTLIG;
            //potoffs[6] = ploffs.POTDAR;
            //potoffs[7] = ploffs.POTALM;
            //potoffs[8] = ploffs.POTAIL;
            //potoffs[9] = ploffs.POTHEA;
            //potoffs[10] = ploffs.POTSUP;
            //
            //for (int i = 0; i < 11; i++)
            //{
            //    bw.BaseStream.Position = potoffs[i];
            //    NumericUpDown nm = Potential.Controls[i]as NumericUpDown;
            //    byte[] nmbyte = BitConverter.GetBytes(Convert.ToInt32(nm.Value));
            //    if (nm.Value > -1)
            //    {
            //        bw.Write(nmbyte,0,2);
            //    }else if (nm.Value < -1)
            //    {
            //        nmbyte = BitConverter.GetBytes(Convert.ToInt32(65535 - nm.Value));
            //        bw.Write(nm.Value);
            //    }
            //}


            //macca
            bw.BaseStream.Position = 0x3d32;
            bw.Write(BitConverter.GetBytes((int)maccactl.Value),0,4);
            //glory
            bw.Write(BitConverter.GetBytes((int)Gloryctl.Value), 0, 3);

            //write all data
            File.WriteAllBytes(path, ms.ToArray());
            bw.Close();
            MessageBox.Show("Saved to "+path);
            Form1 fm1 = new Form1();
            fm1.panel1.Controls.Clear();



        }

        private void PLData_Load(object sender, EventArgs e)
        {
            

        }
    }
}
