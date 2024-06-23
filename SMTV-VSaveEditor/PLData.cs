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
            byte[] fnameb = Encoding.Unicode.GetBytes(textBox1.Text);
            byte[] lnameb = Encoding.Unicode.GetBytes(textBox2.Text);

            byte[] data = File.ReadAllBytes(path);
            MemoryStream ms = new MemoryStream(data);
            BinaryWriter bw = new BinaryWriter(ms);
            bw.BaseStream.Position = offset;
            bw.Write(fnameb);
            bw.BaseStream.Position = offset + 24;
            bw.Write(lnameb, 0, lnameb.Length);
            //fname only
            bw.BaseStream.Position = offset + 44;
            bw.Write(fnameb, 0, fnameb.Length);
            //name combined
            bw.BaseStream.Position = offset + 64;
            bw.Write(fnameb, 0, fnameb.Length);
            bw.BaseStream.Position = offset + 78;
            bw.Write(lnameb, 0, lnameb.Length);
            
            
            //stats
            offset = reset;
            int statoff = offset - 72;
            string testoff = statoff.ToString("X2");
            int stataoff = statoff + 16;
            testoff = stataoff.ToString("X2");
            int statcoff = stataoff + 16;
            testoff = statcoff.ToString("X2");
            bw.BaseStream.Position = statoff;
            for(int i = 0; i < 7; i++)
            {
                byte[] sbase = BitConverter.GetBytes(Convert.ToInt32(statview.Rows[i].Cells[1].Value));
                byte[] sadd = BitConverter.GetBytes(Convert.ToInt32(statview.Rows[i].Cells[2].Value));
                byte[] sc = BitConverter.GetBytes(Convert.ToInt32(statview.Rows[i].Cells[3].Value));
                testoff = bw.BaseStream.Position.ToString("X2");
                if (testoff == "A2A")
                {
                    MessageBox.Show("t");
                }
                bw.Write(sbase,0,2);
                bw.BaseStream.Position = stataoff;
                if (testoff == "9D6")
                {
                    MessageBox.Show("t");
                }
                testoff = bw.BaseStream.Position.ToString("X2");

                bw.Write(sadd,0,2);
                bw.BaseStream.Position = statcoff;
                if (testoff == "9D6")
                {
                    MessageBox.Show("t");
                }
                testoff = bw.BaseStream.Position.ToString("X2");
                bw.Write(sc,0,2);
                statoff += 2;
                stataoff =statoff+ 16;
                statcoff =stataoff+ 16;
                bw.BaseStream.Position = statoff;
                testoff = bw.BaseStream.Position.ToString("X2");
                if (testoff == "9D6")
                {
                    MessageBox.Show("t");
                }
            }
            //skills
            offset = reset;
            int skilloff = offset + 108;
            int skilloffa = 8;
            bw.BaseStream.Position = skilloff;
            
            for (int i = 0; i < 8; i++)
            {
                skilloff = skilloff + (skilloffa * i);
                bw.BaseStream.Position = skilloff;
                ComboBox cbb = SPanel.Controls[i] as ComboBox;
                byte[] skbyte = BitConverter.GetBytes(cbb.SelectedIndex);
                bw.Write(skbyte, 0, 2);
                skilloff = offset + 108;
                
            }

            //int skilloff = offset = 108;
            //int skillcount = 0;
            //for(int i = 0; i< skillview.Rows.Count;i++)
            //{
            //    if (skillview.Rows[i].Cells[1].Value != "" || skillview.Rows[i].Cells[1].Value != null)
            //    {
            //        skillcount++;
            //    }
            //}
            
            


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
