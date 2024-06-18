using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;


namespace SMTVSaveUtil
{
    class SaveCrypt
    {
        private static readonly string sKey = "MDEyMzQ1Njc4OWFiY2RlZj";

        static SaveCrypt()
        {
            sKey = Encoding.UTF8.GetString(Convert.FromBase64String(sKey + "AxMjM0NTY3ODlhYmNkZWY="));
        }
        public static Range indrng = (0..4);
        public static bool IsEncrypted(byte[] buffer, Range index)
            
            => Encoding.ASCII.GetString(buffer[index]) != "GVAS";
        //old value: 0x40..0x44

        public static byte[] Encrypt(byte[] buffer)
            => Crypt(buffer, true);

        public static byte[] Decrypt(byte[] buffer)
            => Crypt(buffer, false);

        public static byte[] Crypt(byte[] buffer, bool encrypt)
        {
            var engine = new AesEngine();
            var cipher = new BufferedBlockCipher(engine);

            var keyBytes = Encoding.ASCII.GetBytes(sKey);
            var keyP = new KeyParameter(keyBytes);

            cipher.Init(encrypt, keyP);

            var res = new byte[cipher.GetOutputSize(buffer.Length)];
            var len = cipher.ProcessBytes(buffer, res, 0);
            len += cipher.DoFinal(res, len);

            return res[..len];
        }

        public static void CryptFile(string path, string pathOut = "")
        {
            var data = File.ReadAllBytes(path);
            using (FileStream fsSourceDDS = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (BinaryReader binaryReader = new BinaryReader(fsSourceDDS))
            {
                //fsSourceDDS.Seek(0x40, SeekOrigin.Begin);
                //byte[] with = binaryReader.ReadBytes(4);
                //string result = System.Text.Encoding.UTF8.GetString(with, 0, with.Length);
                //fsSourceDDS.Seek(0x44, SeekOrigin.Begin);
                //ushort height = binaryReader.ReadUInt16();
                byte[] teststr = new byte[5];
                string dout = "";
                int bsp = 0x40;
                
                
                
            }



            var encBefore = IsEncrypted(data,indrng);

            //double checking if file is really decrypted
            if (encBefore == true)
            {
                indrng = (0x40..0x44);
                encBefore = IsEncrypted(data,indrng);
            }

            Console.WriteLine(encBefore ? "Decrypting..." : "Encrypting...");

            Console.WriteLine("do you want to separate Checksum(Y/N]? [Default:N]");
            string separateinput = "N";
            bool valc = false;
            bool separatebool = false;
            while(valc != true)
            {
                
                separateinput = Console.ReadLine();
                if (string.Equals(separateinput, "N", StringComparison.OrdinalIgnoreCase) || string.Equals(separateinput, "Y", StringComparison.OrdinalIgnoreCase))
                {
                    if(string.Equals(separateinput, "N", StringComparison.OrdinalIgnoreCase))
                    {
                        separatebool = false;
                    }else if (string.Equals(separateinput, "Y", StringComparison.OrdinalIgnoreCase))
                    {
                        separatebool = true;
                    }
                    valc = true;
                }
            }
            
            
            // generate Checksum
            if (encBefore == false)
            {
                byte[] datacopy = new byte[data.Length-0x40];

                Array.Copy(data, 0x40,datacopy, 0,datacopy.Length);


                
            
                byte[] checksumnew = new byte[0x13];

                string test = "";

                using(SHA1 sha1 = SHA1.Create())
                {
                    checksumnew = sha1.ComputeHash(datacopy);
                    


                }


                string byteres = "";
                string testbyte = "";
                for (int i = 0; i < checksumnew.Length; i++)
                {
                    testbyte += checksumnew[i].ToString("X2");
                }
                


                //Console.WriteLine(testbyte);
                Console.WriteLine("done generating checksum: " + testbyte);
                for (int i = 0x0; i < 0x14; i++)
                {
                    MemoryStream ms = new MemoryStream(data);
                    ms.Read(data, 0, data.Length);
                    ms.Position = i;
                    BinaryWriter bw = new BinaryWriter(ms);
                    bw.Write(checksumnew[i]);
                }
                Console.WriteLine("done");
            }


            //separate checksum from save
            

            data = Crypt(data, !encBefore);

            if (encBefore == true && separatebool == true)
            {
                byte[] datacopy = new byte[data.Length - 0x40];

                Array.Copy(data, 0x40, datacopy, 0, datacopy.Length);
                byte[] datachecksum = new byte[0x40];
                Array.Copy(data, 0, datachecksum, 0, datachecksum.Length);
                
                File.WriteAllBytes(path + "_checksum", datachecksum);
                //just to make sure file is empty before replacing data
                data = null;
                data = datacopy;
            }
            Console.WriteLine("Test");

            string teste = Encoding.ASCII.GetString(data[0x40..0x44]);
            if (encBefore && IsEncrypted(data,indrng))
            {
                Console.WriteLine("Decryption failed, the file might not be a valid SMTV save");
                return;
            }

            if (string.IsNullOrWhiteSpace(pathOut))
            {
                pathOut = encBefore ? $"{path}_dec" : $"{path}_enc";
            }
            


            Console.WriteLine($"Writing to {pathOut}...");
            File.WriteAllBytes(pathOut, data);

            Console.WriteLine("Done");
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString().ToLower();
        }


    }
}