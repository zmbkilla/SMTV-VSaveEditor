using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace SMTV_VSaveEditor
{
    internal class Demoninfo
    {
        public static int[] Demondata(int offset,string svloc)
        {
            //format demonID,skill1,skill2,skill3,skill4,skill5,skill6,skill7,skill8


            int reset = offset;
            byte[] iddata = new byte[403];
            int[] result = new int[30];
            MemoryStream ms = new MemoryStream(File.ReadAllBytes(svloc));
            BinaryReader br = new BinaryReader(ms);
            int baseoff = offset;
            int y = 0;
            ms.Position = baseoff;
            //get stat
            for(int i = 0; i < 7; i++)
            {
                
                //br.BaseStream.Position = baseoff;
                string statreverse = "";
                string stat = BitConverter.ToString(br.ReadBytes(2)).Replace("-", "");
                statreverse = stat;
                stat = stat.Replace(stat.Substring(0, 2), stat.Substring(2, 2));
                stat = stat.Insert(2, statreverse.Substring(0, 2));
                stat = stat.Remove(4, 2);
                stat = Int32.Parse(stat,System.Globalization.NumberStyles.HexNumber).ToString();
                

               
                result[i] = Convert.ToInt32(stat);
                

                
            }
            br.BaseStream.Position = baseoff + 16;
            for(int i = 0;i < 7; i++)
            {
                string stata = BitConverter.ToString(br.ReadBytes(2)).Replace("-", "");
                string statreverse = "";
                statreverse = stata;
                stata = stata.Replace(stata.Substring(0, 2), stata.Substring(2, 2));
                stata = stata.Insert(2, statreverse.Substring(0, 2));
                stata = stata.Remove(4, 2);

                stata = Int32.Parse(stata, System.Globalization.NumberStyles.HexNumber).ToString();
                result[i + 7] = Convert.ToInt32(stata);
                
            }
            br.BaseStream.Position = baseoff + 32;
            for (int i = 0;i < 7; i++)
            {
                string statc = BitConverter.ToString(br.ReadBytes(2)).Replace("-", "");
                string statreverse = "";
                statreverse = statc;
                statc = statc.Replace(statc.Substring(0, 2), statc.Substring(2, 2));
                statc = statc.Insert(2, statreverse.Substring(0, 2));
                statc = statc.Remove(4, 2);
                
                statc = Int32.Parse(statc, System.Globalization.NumberStyles.HexNumber).ToString();
                result[i+14] = Convert.ToInt32(statc);
            }
            //get id

            int idoffset = offset + 114;
            ms.Position = offset + 114;
            string demoid = BitConverter.ToString(br.ReadBytes(2)).Replace("-", "");
            string reverse = demoid;
            demoid = demoid.Replace(demoid.Substring(0,2),demoid.Substring(2,2));
            demoid = demoid.Insert(2,reverse.Substring(0,2));
            demoid = demoid.Remove(4,2);

            int rint = Int32.Parse(demoid,System.Globalization.NumberStyles.HexNumber);
            result[21] = rint-1;

            //get skills
            offset = reset;
            int skilloffset = offset + 124;
            ms.Position = skilloffset;
            for(int i = 0; i < 8; i++)
            {
                skilloffset = offset + 124;
                skilloffset = skilloffset + ((i) * 8);
                ms.Position = skilloffset;
                string demosk = BitConverter.ToString(br.ReadBytes(2)).Replace("-", "");
                string sreverse = demosk;
                demosk = demosk.Replace(demosk.Substring(0, 2), demosk.Substring(2, 2));
                demosk = demosk.Insert(2, sreverse.Substring(0, 2));
                demosk = demosk.Remove(4, 2);

                int skint = Int32.Parse(demosk,System.Globalization.NumberStyles.HexNumber);
                result[i+22] = skint;
                offset = reset;
                

            }
            



            return result;
        }

        public static int[] demonoverwriteoff(int slot)
        {
            int[] result = new int[12];
            int offset = 0xb60 + (424*slot);
            result[0] = offset;
            result[1] = offset + 16;
            result[2] = offset +32;
            //id
            result[3] = offset + 114;
            //skill
            result[4] = offset + 124;
            result[5] = result[4] + 8;
            result[6] = result[5] + 8;
            result[7] = result[6] + 8;
            result[8] = result[7] + 8;
            result[9] = result[8] + 8;
            result[10] = result[9] + 8;
            result[11] = result[10] + 8;



            return result;
        }
        
    }
}
