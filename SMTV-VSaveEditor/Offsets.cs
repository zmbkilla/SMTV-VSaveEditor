using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTV_VSaveEditor
{
    public class Offsets
    {
        
        public  int FN1 = 0x4D8;
        public  int FN2 = 0x9d0;
        public  int FN3 = 0x9fc;
        public  int LN1 = 0x9e8;
        public  int LN2 = 0xa1e;


        public  int DLCF = 0x529;
        public  int NGF = 0x528;
        public  int CFlag = 0x502;

        //MC
        public  int HPB = 0x988;
        public  int MPB = 0x98A;
        public  int STB = 0x98C;
        public  int VIB = 0x98E;
        public  int MAB = 0x990;
        public  int AGB = 0x992;
        public  int LUB = 0x994;

        


        public  int HPA = 0x998;
        public  int MPA = 0x99A;
        public  int STA = 0x99C;
        public  int VIA = 0x99E;
        public  int MAA = 0x9A0;
        public  int AGA = 0x9A2;
        public  int LUA = 0x9A4;

        public  int HPC = 0x9A8;
        public  int MPC = 0x9AA;
        public  int STC = 0x9AC;
        public  int VIC = 0x9AE;
        public  int MAC = 0x9B0;
        public  int AGC = 0x9B2;
        public  int LUC = 0x9B4;

        public  int LVLF = 0x9C0;
        public  int EXPF = 0x9C8;

        public  int SKILL1F = 0xA3C;
        public  int SKILL2F = 0xA44;
        public  int SKILL3F = 0xA4C;
        public  int SKILL4F = 0xA54;
        public  int SKILL5F = 0xA5C;
        public  int SKILL6F = 0xA64;
        public  int SKILL7F = 0xA6C;
        public  int SKILL8F = 0xA74;


        //64 = normal, 7D weak, 00 null, 32 resist
        public  int ResPHY = 0xA98;
        public  int ResFIR = 0xA9A;
        public  int ResICE = 0xA9C;
        public  int ResELE = 0xA9E;
        public  int ResFOR = 0xAA0;
        public  int ResLIG = 0xAA2;
        public  int ResDAR = 0xAA4;

        public  int ResPHYC = 0xAD0;
        public  int ResFIRC = 0xAD2;
        public  int ResICEC = 0xAD4;
        public  int ResELEC = 0xAD6;
        public  int ResFORC = 0xAD8;
        public  int ResLIGC = 0xADA;
        public  int ResDARC = 0xADC;

        public  int POTPHY = 0xB38;
        public  int POTFIR = 0xB3A;
        public  int POTICE = 0xB3C;
        public  int POTELE = 0xB3E;
        public  int POTFOR = 0xB40;
        public  int POTLIG = 0xB42;
        public  int POTDAR = 0xB44;
        public  int POTALM = 0xB46;
        public  int POTAIL = 0xB48;
        public  int POTHEA = 0xB4A;
        public  int POTSUP = 0xB4C;

        public  int INNATEF = 0xB50;

        //Demon

        public  int DEMONHPB = 0xB60;
        public  int DEMONMPB = 0xB62;
        public  int DEMONSTB = 0xB64;
        public  int DEMONVIB = 0xB66;
        public  int DEMONMAB = 0xB68;
        public  int DEMONAGB = 0xB6A;
        public  int DEMONLUB = 0xB6C;

        public  int DEMONHPA = 0xB70;
        public  int DEMONMPA = 0xB72;
        public  int DEMONSTA = 0xB74;
        public  int DEMONVIA = 0xB76;
        public  int DEMONMAA = 0xB78;
        public  int DEMONAGA = 0xB7A;
        public  int DEMONLUA = 0xB7C;

        public  int DEMONHPC = 0xB80;
        public  int DEMONMPC = 0xB82;
        public  int DEMONSTC = 0xB84;
        public  int DEMONVIC = 0xB86;
        public  int DEMONMAC = 0xB88;
        public  int DEMONAGC = 0xB8A;
        public  int DEMONLUC = 0xB8C;

        public  int DEMONEXP = 0xBC8;
        public  int DEMONLVL = 0xBD0;

        public  int DEMONID = 0xBD2;

        public  int DEMONS1 = 0xBDC;
        public  int DEMONS2 = 0xBE4;
        public  int DEMONS3 = 0xBEC;
        public  int DEMONS4 = 0xBF4;
        public  int DEMONS5 = 0xBFC;
        public  int DEMONS6 = 0xC04;
        public  int DEMONS7 = 0xC0C;
        public  int DEMONS8 = 0xC14;

        public  int DEMONRPHY = 0xC38;
        public  int DEMONRFIR = 0xC3A;
        public  int DEMONRICE = 0xC3C;
        public  int DEMONRELE = 0xC3E;
        public  int DEMONRFOR = 0xC40;
        public  int DEMONRLIG = 0xC42;
        public  int DEMONRDAR = 0xC44;

        public  int DEMONRPHYC = 0xC70;
        public  int DEMONRFIRC = 0xC72;
        public  int DEMONRICEC = 0xC74;
        public  int DEMONRELEC = 0xC76;
        public  int DEMONRFORC = 0xC78;
        public  int DEMONRLIGC = 0xC7A;
        public  int DEMONRDARC = 0xC7C;

        public  int DEMONPPHY = 0xCA8;
        public  int DEMONPFIR = 0xCAA;
        public  int DEMONPICE = 0xCAC;
        public  int DEMONPELE = 0xCAE;
        public  int DEMONPFOR = 0xCB0;
        public  int DEMONPLIG = 0xCB2;
        public  int DEMONPDAR = 0xCB4;
        public  int DEMONPALM = 0xCB6;
        public  int DEMONPAIL = 0xCB8;
        public  int DEMONPHEA = 0xCBA;
        public  int DEMONPSUP = 0xCBC;

        public  int DEMONPPHYC = 0xCE0;
        public  int DEMONPFIRC = 0xCE2;
        public  int DEMONPICEC = 0xCE4;
        public  int DEMONPELEC = 0xCE6;
        public  int DEMONPFORC = 0xCE8;
        public  int DEMONPLIGC = 0xCEA;
        public  int DEMONPDARC = 0xCEC;
        public  int DEMONPALMC = 0xCEE;
        public  int DEMONPAILC = 0xCF0;
        public  int DEMONPHEAC = 0xCF2;
        public  int DEMONPSUPC = 0xCF4;

        public  int DEMONINN = 0xCF8;

    }
}
