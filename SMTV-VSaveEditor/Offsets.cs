using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTV_VSaveEditor
{
    internal class Offsets
    {
        public const int FN1 = 0x4D8;
        public const int FN2 = 0x9d0;
        public const int FN3 = 0x9fc;
        public const int LN1 = 0x9e8;
        public const int LN2 = 0xa1e;


        public const int DLCF = 0x529;
        public const int NGF = 0x528;
        public const int CFlag = 0x502;

        //MC
        public const int HPB = 0x988;
        public const int MPB = 0x98A;
        public const int STRB = 0x98C;
        public const int VITB = 0x98E;
        public const int MAGB = 0x990;
        public const int AGIB = 0x992;
        public const int LUB = 0x994;

        public const int HPA = 0x998;
        public const int MPA = 0x99A;
        public const int STRA = 0x99C;
        public const int VITA = 0x99E;
        public const int MAGA = 0x9A0;
        public const int AGIA = 0x9A2;
        public const int LUA = 0x9A4;

        public const int HPC = 0x9A8;
        public const int MPC = 0x9AA;
        public const int STRC = 0x9AC;
        public const int VITC = 0x9AE;
        public const int MAGC = 0x9B0;
        public const int AGIC = 0x9B2;
        public const int LUC = 0x9B4;

        public const int LVLF = 0x9C0;
        public const int EXPF = 0x9C8;

        public const int SKILL1F = 0xA3C;
        public const int SKILL2F = 0xA44;
        public const int SKILL3F = 0xA4C;
        public const int SKILL4F = 0xA54;
        public const int SKILL5F = 0xA5C;
        public const int SKILL6F = 0xA64;
        public const int SKILL7F = 0xA6C;
        public const int SKILL8F = 0xA74;


        //64 = normal, 7D weak, 00 null, 32 resist
        public const int ResPHY = 0xA98;
        public const int ResFIR = 0xA9A;
        public const int ResICE = 0xA9C;
        public const int ResELE = 0xA9E;
        public const int ResFOR = 0xAA0;
        public const int ResLIG = 0xAA2;
        public const int ResDAR = 0xAA4;

        public const int ResPHYC = 0xAD0;
        public const int ResFIRC = 0xAD2;
        public const int ResICEC = 0xAD4;
        public const int ResELEC = 0xAD6;
        public const int ResFORC = 0xAD8;
        public const int ResLIGC = 0xADA;
        public const int ResDARC = 0xADC;

        public const int POTPHY = 0xB38;
        public const int POTFIR = 0xB3A;
        public const int POTICE = 0xB3C;
        public const int POTELE = 0xB3E;
        public const int POTFOR = 0xB40;
        public const int POTLIG = 0xB42;
        public const int POTDAR = 0xB44;
        public const int POTALM = 0xB46;
        public const int POTAIL = 0xB48;
        public const int POTHEA = 0xB4A;
        public const int POTSUP = 0xB4C;

        public const int INNATEF = 0xB50;

        //Demon

        public const int DEMONHPB = 0xB60;
        public const int DEMONMPB = 0xB62;
        public const int DEMONSTB = 0xB64;
        public const int DEMONVIB = 0xB66;
        public const int DEMONMAB = 0xB68;
        public const int DEMONAGB = 0xB6A;
        public const int DEMONLUB = 0xB6C;

        public const int DEMONHPA = 0xB70;
        public const int DEMONMPA = 0xB72;
        public const int DEMONSTA = 0xB74;
        public const int DEMONVIA = 0xB76;
        public const int DEMONMAA = 0xB78;
        public const int DEMONAGA = 0xB7A;
        public const int DEMONLUA = 0xB7C;

        public const int DEMONHPC = 0xB80;
        public const int DEMONMPC = 0xB82;
        public const int DEMONSTC = 0xB84;
        public const int DEMONVIC = 0xB86;
        public const int DEMONMAC = 0xB88;
        public const int DEMONAGC = 0xB8A;
        public const int DEMONLUC = 0xB8C;

        public const int DEMONEXP = 0xBC8;
        public const int DEMONLVL = 0xBD0;

        public const int DEMONID = 0xBD2;

        public const int DEMONS1 = 0xBDC;
        public const int DEMONS2 = 0xBE4;
        public const int DEMONS3 = 0xBEC;
        public const int DEMONS4 = 0xBF4;
        public const int DEMONS5 = 0xBFC;
        public const int DEMONS6 = 0xC04;
        public const int DEMONS7 = 0xC0C;
        public const int DEMONS8 = 0xC14;

        public const int DEMONRPHY = 0xC38;
        public const int DEMONRFIR = 0xC3A;
        public const int DEMONRICE = 0xC3C;
        public const int DEMONRELE = 0xC3E;
        public const int DEMONRFOR = 0xC40;
        public const int DEMONRLIG = 0xC42;
        public const int DEMONRDAR = 0xC44;

        public const int DEMONRPHYC = 0xC70;
        public const int DEMONRFIRC = 0xC72;
        public const int DEMONRICEC = 0xC74;
        public const int DEMONRELEC = 0xC76;
        public const int DEMONRFORC = 0xC78;
        public const int DEMONRLIGC = 0xC7A;
        public const int DEMONRDARC = 0xC7C;

        public const int DEMONPPHY = 0xCA8;
        public const int DEMONPFIR = 0xCAA;
        public const int DEMONPICE = 0xCAC;
        public const int DEMONPELE = 0xCAE;
        public const int DEMONPFOR = 0xCB0;
        public const int DEMONPLIG = 0xCB2;
        public const int DEMONPDAR = 0xCB4;
        public const int DEMONPALM = 0xCB6;
        public const int DEMONPAIL = 0xCB8;
        public const int DEMONPHEA = 0xCBA;
        public const int DEMONPSUP = 0xCBC;

        public const int DEMONPPHYC = 0xCE0;
        public const int DEMONPFIRC = 0xCE2;
        public const int DEMONPICEC = 0xCE4;
        public const int DEMONPELEC = 0xCE6;
        public const int DEMONPFORC = 0xCE8;
        public const int DEMONPLIGC = 0xCEA;
        public const int DEMONPDARC = 0xCEC;
        public const int DEMONPALMC = 0xCEE;
        public const int DEMONPAILC = 0xCF0;
        public const int DEMONPHEAC = 0xCF2;
        public const int DEMONPSUPC = 0xCF4;

        public const int DEMONINN = 0xCF8;

    }
}
