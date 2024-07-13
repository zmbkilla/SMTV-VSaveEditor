﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTV_VSaveEditor
{
    internal class DemonList
    {

        public IDictionary<int, Tuple<string, int>> test = new Dictionary<int, Tuple<string, int>>()
        {
            {1,new Tuple<string,int>("test",1) }
        };

        public Dictionary<int, int> IDtoPic = new Dictionary<int, int>()
        {
            {1,1 },
            {2,2 },
        };
        


        public Dictionary<int, string> DemonIDs = new Dictionary<int, string>()
        {
            {1,"Satan"},
            {2,"Lucifer"},

            {4,"Dagda"},


            {7,"Khonsu"},
            {8,"Zeus"},
            {9,"Odin"},

            {11,"Mitra"},
            {12,"Atavaka"},
            {13,"Horus"},
{14,"Thoth"},
{15,"Khonsu Ra"},
{16,"Vishnu"},
{17,"Baal"},

{19,"Demeter"},
{20,"Anahita"},
{21,"Lakshmi"},
{22,"Norn"},
{23,"Idun"},
{24,"Sarasvati"},
{25,"Ishtar"},
{26,"Scathach"},
{27,"Parvati"},
{28,"AmeNoUzume"},
{29,"Fortuna"},
{30,"Maria"},
{31,"Artemis"},
{32,"Konohana Sakuya"},

{34,"Hanuman"},
{35,"Fionn Mac Cumhaill"},
{36,"Cu Chulainn"},
{37,"Kurama Tengu"},
{38,"Amanozako"},

{40,"Kresnik"},
{41,"Anansi"},
{42,"Koppa Tengu"},
{43,"Apsaras"},
{44,"Agathion"},
{45,"Mandrake"},
{46,"Dis"},
{47,"Efreet"},



{51,"Titania"},
{52,"Oberon"},
{53,"Silky"},
{54,"Setanta"},
{55,"Kelpie"},
{56,"High Pixie"},
{57,"JackO'Lantern"},
{58,"Jack Frost"},
{59,"Pixie"},
{60,"Nahobeeho"},



{64,"Queen Medb"},
{65,"Succubus"},
{66,"Kaiwan"},
{67,"Lilim"},
{68,"Incubus"},
{69,"Mokoi"},
{70,"Sandman"},

{72,"Black Frost"},


{75,"Nuwa (Normal)"},
{76,"Amon"},
{77,"Mara"},
{78,"Mephisto"},
{79,"Chi You"},
{80,"Surt"},
{81,"Beelzebub"},
{82,"Arioch"},
{83,"Belial"},
{84,"Abaddon"},
{85,"Moloch"},
{86,"Belphegor"},
{87,"King Frost"},
{88,"Mithras"},
{89,"Loki"},




{94,"Huang Long"},
{95,"Quetzalcoatl"},
{96,"Qing Long"},
{97,"Xuanwu"},
{98,"Ananta"},
{99,"Vritra"},
{100,"Nyami Nyami"},


{103,"YamataNoOrochi"},
{104,"Naga Raja"},
{105,"Yurlungur"},
{106,"Naga"},
{107,"Nozuchi"},
{108,"Vouivre"},


{111,"Vasuki"},
{112,"Seth"},
{113,"Basilisk"},
{114,"Aitvaras"},
{115,"Hydra"},
{116,"Fafnir"},
{117,"Zhu Tun She"},
{118,"Samael"},
{119,"Barong"},
{120,"Anubis"},
{121,"Makami"},
{122,"Xiezhai"},



{126,"Baihu"},
{127,"Chimera"},
{128,"Cironnup"},
{129,"Shiisaa"},
{130,"Senri"},
{131,"Unicorn"},


{134,"Cerberus"},
{135,"Orthrus"},
{136,"LoupGarou"},
{137,"Nekomata"},
{138,"Inugami"},
{139,"Orobas"},
{140,"Cait Sith"},
{141,"Dormarth"},
{142,"GlasyaLabolas"},

{144,"Bugs"},
{145,"Nue"},
{146,"Bicorn"},
{147,"Mothman"},
{148,"Fenrir"},
{149,"Peallaidh"},


{152,"Hayataro"},


{155,"Flaemis"},
{156,"Aquans"},
{157,"Aeros"},
{158,"Erthys"},












{171,"Black Ooze"},
{172,"Legion"},
{173,"Slime"},
{174,"Mad Gasser"},
{175,"Turbo Granny"},


{178,"Shiva"},
{179,"Mot"},
{180,"ZaouGongen"},
{181,"Asura"},
{182,"Chernobog"},
{183,"Dionysos"},




{188,"Danu"},
{189,"Inanna"},
{190,"Kali"},
{191,"Cybele"},
{192,"Skadi"},
{193,"Isis"},
{194,"KikuriHime"},
{195,"Hariti"},

{197,"Nuwa (Snake)"},
{198,"Alilat"},

{200,"Thor"},
{201,"Futsunushi"},
{202,"Attis"},
{203,"Bishamonten"},
{204,"Jikokuten"},
{205,"Koumokuten"},
{206,"Zouchouten"},




{211,"Arahabaki"},
{212,"Oyamatsumi"},
{213,"KushinadaHime"},
{214,"SukunaHikona"},
{215,"Okuninushi"},
{216,"TakeMinakata"},




{221,"Ganesha"},
{222,"Siegfried"},
{223,"Valkyrie"},
{224,"Yoshitsune"},
{225,"Neko Shogun"},
{226,"Nezha Taizi"},
{227,"Masakado"},



{231,"Mada"},
{232,"Girimekhala"},
{233,"Pazuzu"},
{234,"Mishaguji"},
{235,"Baphomet"},
{236,"Lahmu"},
{237,"Saturnus"},
{238,"Tzitzimitl"},

{240,"Abdiel"},
{241,"Metatron"},
{242,"Michael"},
{243,"Gabriel"},
{244,"Sraosha"},
{245,"Raphael"},
{246,"Sandalphon"},
{247,"Uriel"},
{248,"Camael"},
{249,"Melchizedek"},
{250,"Mastema"},
{251,"Armaiti"},


{254,"Throne"},
{255,"Dominion"},
{256,"Power"},
{257,"Principality"},
{258,"Archangel"},
{259,"Angel"},
{260,"Cherub"},



{264,"Abdiel"},
{265,"Adramelech"},
{266,"Flauros"},
{267,"Nebiros"},
{268,"Berith"},
{269,"Ose"},
{270,"Eligor"},
{271,"Forneus"},
{272,"Andras"},
{273,"Decarabia"},
{274,"Halphas"},
{275,"Azazel"},


{278,"Garuda"},
{279,"Zhuque"},
{280,"Yatagarasu"},
{281,"Jatayu"},
{282,"Feng Huang"},
{283,"Thunderbird"},



{287,"Anzu"},
{288,"Zhen"},
{289,"Muu Shuwuu"},
{290,"Onmoraki"},
{291,"Gurulu"},



{295,"Cleopatra"},
{296,"Rangda"},
{297,"Dakini"},
{298,"Atropos"},
{299,"Yakshini"},
{300,"Lachesis"},
{301,"Clotho"},
{302,"Manananggal"},
{303,"Lamia"},
{304,"Mermaid"},
{305,"Leanan Sidhe"},




{310,"OngyoKI"},
{311,"ShikiOuji"},
{312,"SuiKi"},
{313,"FuuKI"},
{314,"KinKI"},
{315,"Azumi"},
{316,"IpponDatara"},
{317,"Daemon"},
{318,"Oni"},
{319,"Karasu Tengu"},


{322,"Hecatoncheires"},
{323,"Loa"},
{324,"Rakshasa"},
{325,"Turudak"},
{326,"Macabre"},
{327,"Gremlin"},


{330,"KayaNoHime"},
{331,"Tsuchigumo"},
{332,"Narcissus"},
{333,"Hua Po"},
{334,"Koropokkur"},
{335,"Sudama"},
{336,"Kodama"},
{337,"Gogmagog"},



{341,"Pisaca"},
{342,"Kumbhanda"},
{343,"Poltergeist"},
{344,"Obariyon"},
{345,"Preta"},
{346,"Kudlak"},



{350,"Trumpeter"},
{351,"Mother Harlot"},
{352,"Black Rider"},
{353,"Red Rider"},
{354,"White Rider"},
{355,"Alice"},
{356,"Hell Biker"},
{357,"Daisoujou"},
{358,"Pale Rider"},
{359,"Matador"},





{365,"Tao"},
{366,"Yoko"},



{370,"Shujinkou Nahobino"},










{381,"Hare of Inaba"},



{385,"Kinmamon"},
{386,"Onyankopon"},
{387,"Amabie"},



{391,"Lilith"},
{392,"Agrat bat Mahlat"},
{393,"Naamah"},
{394,"Eisheth Zenunim"},





{400,"Yoko Hiromine"},
{401,"Tao Isonokami"},
{402,"Yuzuru Atsuta"},
{403,"Ichiro Dazai"},
        };
        

        
            


    }
}
