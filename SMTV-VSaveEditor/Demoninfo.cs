using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SMTV_VSaveEditor
{
    internal class Demoninfo
    {
        public static int[] Demondata(int offset,string svloc)
        {
            //format demonID,skill1,skill2,skill3,skill4,skill5,skill6,skill7,skill8


            int reset = offset;
            byte[] iddata = new byte[403];
            int[] result = new int[9];
            MemoryStream ms = new MemoryStream(File.ReadAllBytes(svloc));
            BinaryReader br = new BinaryReader(ms);
            //get stat

            //get id


            ms.Position = offset + 114;
            string demoid = BitConverter.ToString(br.ReadBytes(2)).Replace("-", "");
            string reverse = demoid;
            demoid = demoid.Replace(demoid.Substring(0,2),demoid.Substring(2,2));
            demoid = demoid.Insert(2,reverse.Substring(0,2));
            demoid = demoid.Remove(4,2);

            int rint = Int32.Parse(demoid,System.Globalization.NumberStyles.HexNumber);
            result[0] = rint;



            return result;
        }
        
    }
}
