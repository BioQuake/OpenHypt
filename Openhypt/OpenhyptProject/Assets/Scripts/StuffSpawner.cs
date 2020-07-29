using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class StuffSpawner : MonoBehaviour
{
    public GameObject Thing1;
    public GameObject Thing2;
    public GameObject Thing3;
    public GameObject Thing5;
    public GameObject Thing6;
    public GameObject TheP0;
    public GameObject AmmoBot;
    public GameObject TheAmmoBot;
    public GameObject Snyns;
    public GameObject TheSnyns;
    public GameObject TheKatovariDropPod;
    public GameObject NPC000;
    public static int TheNPC000N;
    public GameObject NPC001;
    public static int TheNPC001N;
    public GameObject NPC002;
    public static int TheNPC002N;
    public GameObject NPC003;
    public static int TheNPC003N;
    public GameObject NPC004;
    public static int TheNPC004N;
    public GameObject NPC005;
    public static int TheNPC005N;
    public GameObject NPC006;
    public GameObject TheNPC006;
    public GameObject NPC007;
    public GameObject TheNPC007;
    public GameObject NPC008;
    public GameObject TheNPC008;
    public GameObject TheNPC009;
    public static int TheNPC009N;
    public GameObject TheNPC0091;
    public static int TheNPC0091N;
    public GameObject TheNPC0800;
    public GameObject TheNPC0801;
    public GameObject TheNPC0802;
    public GameObject TheNPC0803;
    public GameObject TheNPC0804;
    public GameObject TheNPC0805;
    public static int TheNPC0805N;
    public GameObject NPC080;
    public GameObject TheNPC080;
    public GameObject NPC081;
    public GameObject TheNPC081;
    public GameObject NPC082;
    public GameObject TheNPC082;
    public GameObject NPC00;
    public GameObject TheNPC00;
    public GameObject NPC01;
    public GameObject TheNPC01;
    public GameObject NPC02;
    public GameObject TheNPC02;
    public GameObject NPC03;
    public GameObject TheNPC03;
    public GameObject NPC04;
    public GameObject TheNPC04;
    public GameObject NPC05;
    public GameObject TheNPC05;
    public GameObject NPC10;
    public GameObject TheNPC10;
    public GameObject NPC20;
    public GameObject TheNPC20;
    public GameObject NPC21;
    public GameObject TheNPC21;
    public GameObject TheNPC22;
    public GameObject TheNPC23;
    public GameObject TheNPC24;
    public GameObject TheNPC25;
    public GameObject TheNPC26;
    public GameObject TheNPC27;
    public GameObject NPC300;
    public GameObject TheNPC300;
    public GameObject NPC301;
    public GameObject TheNPC301;
    public GameObject NPC302;
    public GameObject TheNPC302;
    public GameObject NPC303;
    public GameObject TheNPC303;
    public GameObject NPC310;
    public GameObject TheNPC310;
    public GameObject NPC31;
    public GameObject TheNPC31;
    public GameObject NPC32;
    public GameObject TheNPC32;
    public GameObject NPC33;
    public GameObject TheNPC33;
    public GameObject NPC34;
    public GameObject TheNPC34;
    public GameObject NPC35;
    public GameObject TheNPC35;
    public GameObject NPC36;
    public GameObject TheNPC36;
    public GameObject NPC37;
    public GameObject TheNPC37;
    public GameObject NPC39;
    public GameObject TheNPC39;
    public bool NPC39Once;
    public GameObject NPC40;
    public GameObject TheNPC40;
    public GameObject NPC41;
    public GameObject TheNPC41;
    public GameObject NPC42;
    public GameObject TheNPC42;
    public GameObject NPC43;
    public GameObject TheNPC43;
    public GameObject NPC44;
    public GameObject TheNPC44;
    public GameObject NPC45;
    public GameObject TheNPC45;
    public GameObject NPC50;
    public GameObject TheNPC50;
    public GameObject NPC51;
    public GameObject TheNPC51;
    public GameObject NPC52;
    public GameObject TheNPC52;
    public GameObject NPC53;
    public GameObject TheNPC53;
    public GameObject TheNPC54;
    public GameObject TheNPC55;
    public GameObject TheNPC56;
    public GameObject TheNPC57;
    public GameObject NPC60;
    public GameObject TheNPC60;
    public GameObject NPC61;
    public GameObject TheNPC61;
    public GameObject NPC62;
    public GameObject TheNPC62;
    public GameObject NPC63;
    public GameObject TheNPC63;
    public GameObject NPC70;
    public GameObject TheNPC70;
    public GameObject NPC71;
    public GameObject TheNPC71;
    public GameObject NPC72;
    public GameObject TheNPC72;
    public GameObject NPC73;
    public GameObject TheNPC73;
    public GameObject NPC74;
    public GameObject TheNPC74;
    public GameObject NPC75;
    public GameObject TheNPC75;
    public GameObject NPC76;
    public GameObject TheNPC76;
    public GameObject NPC77;
    public GameObject TheNPC77;
    public GameObject NPC78;
    public GameObject TheNPC78;
    public GameObject NPC79;
    public GameObject TheNPC79;
    public GameObject NPC90;
    public GameObject TheNPC90;
    public GameObject NPC91;
    public GameObject TheNPC91;
    public GameObject NPC92;
    public GameObject TheNPC92;
    public GameObject NPC93;
    public GameObject TheNPC93;
    public GameObject NPC94;
    public GameObject TheNPC94;
    public GameObject NPC95;
    public GameObject TheNPC95;
    public int P0SpawnChanceIn;
    public int PH0SpawnChanceIn;
    public int NPC000SpawnChanceIn;
    public int NPC001SpawnChanceIn;
    public int NPC002SpawnChanceIn;
    public int NPC003SpawnChanceIn;
    public int NPC004SpawnChanceIn;
    public int NPC005SpawnChanceIn;
    public int NPC006SpawnChanceIn;
    public int NPC007SpawnChanceIn;
    public int NPC008SpawnChanceIn;
    public int NPC009SpawnChanceIn;
    public int NPC0091SpawnChanceIn;
    public int NPC0800SpawnChanceIn;
    public int NPC0801SpawnChanceIn;
    public int NPC0802SpawnChanceIn;
    public int NPC0803SpawnChanceIn;
    public int NPC0804SpawnChanceIn;
    public int NPC0805SpawnChanceIn;
    public int NPC080SpawnChanceIn;
    public int NPC081SpawnChanceIn;
    public int NPC082SpawnChanceIn;
    public int NPC00SpawnChanceIn;
    public int NPC01SpawnChanceIn;
    public int NPC02SpawnChanceIn;
    public int NPC03SpawnChanceIn;
    public int NPC04SpawnChanceIn;
    public int NPC05SpawnChanceIn;
    public int NPC10SpawnChanceIn;
    public int NPC20SpawnChanceIn;
    public int NPC21SpawnChanceIn;
    public int NPC22SpawnChanceIn;
    public int NPC23SpawnChanceIn;
    public int NPC24SpawnChanceIn;
    public int NPC25SpawnChanceIn;
    public int NPC26SpawnChanceIn;
    public int NPC27SpawnChanceIn;
    public int NPC300SpawnChanceIn;
    public int NPC301SpawnChanceIn;
    public int NPC302SpawnChanceIn;
    public int NPC303SpawnChanceIn;
    public int NPC310SpawnChanceIn;
    public int NPC31SpawnChanceIn;
    public int NPC32SpawnChanceIn;
    public int NPC33SpawnChanceIn;
    public int NPC34SpawnChanceIn;
    public int NPC35SpawnChanceIn;
    public int NPC36SpawnChanceIn;
    public int NPC37SpawnChanceIn;
    public int NPC39SpawnChanceIn;
    public int NPC40SpawnChanceIn;
    public int NPC41SpawnChanceIn;
    public int NPC42SpawnChanceIn;
    public int NPC43SpawnChanceIn;
    public int NPC44SpawnChanceIn;
    public int NPC45SpawnChanceIn;
    public int NPC50SpawnChanceIn;
    public int NPC51SpawnChanceIn;
    public int NPC52SpawnChanceIn;
    public int NPC53SpawnChanceIn;
    public int NPC54SpawnChanceIn;
    public int NPC55SpawnChanceIn;
    public int NPC56SpawnChanceIn;
    public int NPC57SpawnChanceIn;
    public int NPC60SpawnChanceIn;
    public int NPC61SpawnChanceIn;
    public int NPC62SpawnChanceIn;
    public int NPC63SpawnChanceIn;
    public int NPC70SpawnChanceIn;
    public int NPC71SpawnChanceIn;
    public int NPC72SpawnChanceIn;
    public int NPC73SpawnChanceIn;
    public int NPC74SpawnChanceIn;
    public int NPC75SpawnChanceIn;
    public int NPC76SpawnChanceIn;
    public int NPC77SpawnChanceIn;
    public int NPC78SpawnChanceIn;
    public int NPC79SpawnChanceIn;
    public int NPC90SpawnChanceIn;
    public int NPC91SpawnChanceIn;
    public int NPC92SpawnChanceIn;
    public int NPC93SpawnChanceIn;
    public int NPC94SpawnChanceIn;
    public int NPC95SpawnChanceIn;
    //Statics --------------------------------------------------------------
    public int P0StaticSpawnChanceIn;
    public int PH0StaticSpawnChanceIn;
    public int NPC000StaticSpawnChanceIn;
    public int NPC001StaticSpawnChanceIn;
    public int NPC002StaticSpawnChanceIn;
    public int NPC003StaticSpawnChanceIn;
    public int NPC004StaticSpawnChanceIn;
    public int NPC005StaticSpawnChanceIn;
    public int NPC006StaticSpawnChanceIn;
    public int NPC007StaticSpawnChanceIn;
    public int NPC008StaticSpawnChanceIn;
    public int NPC009StaticSpawnChanceIn;
    public int NPC0091StaticSpawnChanceIn;
    public int NPC0800StaticSpawnChanceIn;
    public int NPC0801StaticSpawnChanceIn;
    public int NPC0802StaticSpawnChanceIn;
    public int NPC0803StaticSpawnChanceIn;
    public int NPC0804StaticSpawnChanceIn;
    public int NPC0805StaticSpawnChanceIn;
    public int NPC080StaticSpawnChanceIn;
    public int NPC081StaticSpawnChanceIn;
    public int NPC082StaticSpawnChanceIn;
    public int NPC00StaticSpawnChanceIn;
    public int NPC01StaticSpawnChanceIn;
    public int NPC02StaticSpawnChanceIn;
    public int NPC03StaticSpawnChanceIn;
    public int NPC04StaticSpawnChanceIn;
    public int NPC05StaticSpawnChanceIn;
    public int NPC10StaticSpawnChanceIn;
    public int NPC20StaticSpawnChanceIn;
    public int NPC21StaticSpawnChanceIn;
    public int NPC22StaticSpawnChanceIn;
    public int NPC23StaticSpawnChanceIn;
    public int NPC24StaticSpawnChanceIn;
    public int NPC25StaticSpawnChanceIn;
    public int NPC26StaticSpawnChanceIn;
    public int NPC27StaticSpawnChanceIn;
    public int NPC300StaticSpawnChanceIn;
    public int NPC301StaticSpawnChanceIn;
    public int NPC302StaticSpawnChanceIn;
    public int NPC303StaticSpawnChanceIn;
    public int NPC310StaticSpawnChanceIn;
    public int NPC31StaticSpawnChanceIn;
    public int NPC32StaticSpawnChanceIn;
    public int NPC33StaticSpawnChanceIn;
    public int NPC34StaticSpawnChanceIn;
    public int NPC35StaticSpawnChanceIn;
    public int NPC36StaticSpawnChanceIn;
    public int NPC37StaticSpawnChanceIn;
    public int NPC39StaticSpawnChanceIn;
    public int NPC40StaticSpawnChanceIn;
    public int NPC41StaticSpawnChanceIn;
    public int NPC42StaticSpawnChanceIn;
    public int NPC43StaticSpawnChanceIn;
    public int NPC44StaticSpawnChanceIn;
    public int NPC45StaticSpawnChanceIn;
    public int NPC50StaticSpawnChanceIn;
    public int NPC51StaticSpawnChanceIn;
    public int NPC52StaticSpawnChanceIn;
    public int NPC53StaticSpawnChanceIn;
    public int NPC54StaticSpawnChanceIn;
    public int NPC55StaticSpawnChanceIn;
    public int NPC56StaticSpawnChanceIn;
    public int NPC57StaticSpawnChanceIn;
    public int NPC60StaticSpawnChanceIn;
    public int NPC61StaticSpawnChanceIn;
    public int NPC62StaticSpawnChanceIn;
    public int NPC63StaticSpawnChanceIn;
    public int NPC70StaticSpawnChanceIn;
    public int NPC71StaticSpawnChanceIn;
    public int NPC72StaticSpawnChanceIn;
    public int NPC73StaticSpawnChanceIn;
    public int NPC74StaticSpawnChanceIn;
    public int NPC75StaticSpawnChanceIn;
    public int NPC76StaticSpawnChanceIn;
    public int NPC77StaticSpawnChanceIn;
    public int NPC78StaticSpawnChanceIn;
    public int NPC79StaticSpawnChanceIn;
    public int NPC90StaticSpawnChanceIn;
    public int NPC91StaticSpawnChanceIn;
    public int NPC92StaticSpawnChanceIn;
    public int NPC93StaticSpawnChanceIn;
    public int NPC94StaticSpawnChanceIn;
    public int NPC95StaticSpawnChanceIn;
    public GameObject AberrantAbettor;
    public GameObject AgrianVigil;
    public GameObject TheAgrianVigil;
    public Transform PiriView;
    public Transform PiriPoint;
    public Transform SpawnSource;
    public Transform SpawnSourceS;
    public Transform SpawnPos;
    public Transform AltRot;
    public Transform AltaltRot;
    public Transform TripleAltTF;
    public Transform TripleAltParentTF;
    public Transform HugeSpawnPos1;
    public Transform HugeSpawnPos2;
    public Transform HugeSpawnPos3;
    public Transform HugeSpawnPos4;
    public Transform HugeSpawnPos5;
    public Transform HugeSpawnPos6;
    public Transform HugeSpawnPos7;
    public Transform HugeSpawnPos8;
    public bool SpawningBig;
    public bool Obscured;
    public bool AreaSpace;
    public int AreaNum;
    public int VelClamp;
    public float Vel2;
    public bool MovingFast;
    public bool IsInPerson;
    public int VelBreak;
    public int Count;
    public int LowSpawnDist;
    public int BigSpawnDist;
    public int HeightLimit;
    public float savedRotY;
    public LayerMask targetLayers;
    public LayerMask targetLayers2;
    public virtual void Start()//Spawn();
    {
        this.PiriView = PlayerInformation.instance.PhysCam;
        this.AreaNum = WorldInformation.instance.AreaCode;
        this.AreaSpace = WorldInformation.instance.AreaSpace;
        this.transform.parent = null;
        GameObject SpawnPos = GameObject.Find("HugeSpawn1");
        if (SpawnPos)
        {
            this.HugeSpawnPos1 = GameObject.Find("HugeSpawn1").transform;
            this.HugeSpawnPos2 = GameObject.Find("HugeSpawn2").transform;
            this.HugeSpawnPos3 = GameObject.Find("HugeSpawn3").transform;
            this.HugeSpawnPos4 = GameObject.Find("HugeSpawn4").transform;
            this.HugeSpawnPos5 = GameObject.Find("HugeSpawn5").transform;
            this.HugeSpawnPos6 = GameObject.Find("HugeSpawn6").transform;
            this.HugeSpawnPos7 = GameObject.Find("HugeSpawn7").transform;
            this.HugeSpawnPos8 = GameObject.Find("HugeSpawn8").transform;
        }
        StuffSpawner.TheNPC000N = 0;
        StuffSpawner.TheNPC001N = 0;
        StuffSpawner.TheNPC002N = 0;
        StuffSpawner.TheNPC003N = 0;
        StuffSpawner.TheNPC004N = 0;
        StuffSpawner.TheNPC005N = 0;
        StuffSpawner.TheNPC009N = 0;
        StuffSpawner.TheNPC0091N = 0;
        StuffSpawner.TheNPC0805N = 0;
        //Planet Pirizuka
        if (this.AreaNum == 0)
        {
            this.HeightLimit = 2000;
            //Objects
            this.P0SpawnChanceIn = 0; //PagesGobnard
            //Phenomenons
            this.PH0SpawnChanceIn = 0; //Dust Devil
            //Civilians & Creatures
            this.NPC000SpawnChanceIn = 0; //Peuktato
            this.NPC001SpawnChanceIn = 0; //Peuktorb
            this.NPC002SpawnChanceIn = 0; //Peuktuber
            this.NPC003SpawnChanceIn = 0; //Peuknyth
            this.NPC004SpawnChanceIn = 0; //Peuknyil
            this.NPC005SpawnChanceIn = 0; //Peukopede
            this.NPC006SpawnChanceIn = 0; //Big Peukopede
            this.NPC007SpawnChanceIn = 0; //Svibra Cloud
            this.NPC008SpawnChanceIn = 0; //Big Svibra Cloud
            this.NPC009SpawnChanceIn = 0; //Cykin
            this.NPC0091SpawnChanceIn = 0; //Turgkin
            this.NPC0800SpawnChanceIn = 0; //Oot1
            this.NPC0801SpawnChanceIn = 0; //Oot2
            this.NPC0802SpawnChanceIn = 0; //Oot3
            this.NPC0803SpawnChanceIn = 0; //Oot4
            this.NPC0804SpawnChanceIn = 0; //OotDut1
            this.NPC0805SpawnChanceIn = 0; //OotDut1Group
            this.NPC080SpawnChanceIn = 0; //Shadowfinger Ootkin
            this.NPC081SpawnChanceIn = 0; //Athnian Ootkin 1
            this.NPC082SpawnChanceIn = 0; //Athnian Ootkin 2
            this.NPC00SpawnChanceIn = 0; //Afazis Terracruiser EC-1
            this.NPC01SpawnChanceIn = 0; //TAK B-l4
            this.NPC02SpawnChanceIn = 0; //Ezyfus Bejsirf Apta
            this.NPC03SpawnChanceIn = 0; //Carbondyle Fecuda C.211
            this.NPC04SpawnChanceIn = 0; //Slavoico BImG-500
            this.NPC05SpawnChanceIn = 0; //Carbondyle Fecuda C.115
            //PrincipalCharacters
            this.NPC10SpawnChanceIn = 0; //Someone
            //Agrians
            this.NPC20SpawnChanceIn = 0; //Enforcer
            this.NPC21SpawnChanceIn = 0; //Sentinel
            this.NPC22SpawnChanceIn = 0; //Agent
            this.NPC23SpawnChanceIn = 0; //Executor
            this.NPC24SpawnChanceIn = 0; //SuperExecutor
            this.NPC25SpawnChanceIn = 0; //Helirotor
            this.NPC26SpawnChanceIn = 0; //Annihilator
            this.NPC27SpawnChanceIn = 0; //Distributor
            //Terrahyptians
            this.NPC300SpawnChanceIn = 0; //LevNav Eos
            this.NPC301SpawnChanceIn = 0; //LevNav Ithis
            this.NPC302SpawnChanceIn = 0; //LevNav MAL
            this.NPC303SpawnChanceIn = 0; //LevNav Darion
            this.NPC310SpawnChanceIn = 0; //Bothunter
            this.NPC31SpawnChanceIn = 0; //Valiant
            this.NPC32SpawnChanceIn = 0; //FecarB1
            this.NPC33SpawnChanceIn = 0; //DasNavCruiser
            this.NPC34SpawnChanceIn = 0; //TRN RD-1
            this.NPC35SpawnChanceIn = 0; //TLFAdamant
            this.NPC36SpawnChanceIn = 0; //TLF Fughunter
            this.NPC37SpawnChanceIn = 0; //TLF LRCM Neutralizer
            this.NPC39SpawnChanceIn = 0; //TRN Zerana
            //Aberrants
            this.NPC40SpawnChanceIn = 0; //Abettor
            this.NPC41SpawnChanceIn = 0; //Gunner
            this.NPC42SpawnChanceIn = 0; //Militant
            this.NPC43SpawnChanceIn = 0; //Marauder
            this.NPC44SpawnChanceIn = 0; //Mercenary
            this.NPC45SpawnChanceIn = 0; //Cruiser
            //Slavuics
            this.NPC50SpawnChanceIn = 0; //Civilian
            this.NPC51SpawnChanceIn = 0; //Watchmen
            this.NPC52SpawnChanceIn = 0; //Mistitor
            this.NPC53SpawnChanceIn = 0; //Civilian2
            this.NPC54SpawnChanceIn = 0; //Snositor
            this.NPC55SpawnChanceIn = 0; //Vanguard
            this.NPC56SpawnChanceIn = 0; //Smertnik
            this.NPC57SpawnChanceIn = 0; //Satnik
            //Al-Atiba
            this.NPC60SpawnChanceIn = 0; //Van
            this.NPC61SpawnChanceIn = 0; //Guncarrier
            this.NPC62SpawnChanceIn = 0; //Bejsirf
            this.NPC63SpawnChanceIn = 0; //Microcruiser
            //MevNavs
            this.NPC70SpawnChanceIn = 0; //Scout Drone
            this.NPC71SpawnChanceIn = 0; //Battle Drone
            this.NPC72SpawnChanceIn = 0; //Cannon Drone
            this.NPC73SpawnChanceIn = 0; //Squire
            this.NPC74SpawnChanceIn = 0; //Archer
            this.NPC75SpawnChanceIn = 0; //Scabbard
            this.NPC76SpawnChanceIn = 0; //Warmonger
            this.NPC77SpawnChanceIn = 0; //Knight
            this.NPC78SpawnChanceIn = 0; //Deus
            this.NPC79SpawnChanceIn = 0; //Eschatos
            //Dutvutanians
            this.NPC90SpawnChanceIn = 0; //DutvutanianCivilian1
            this.NPC91SpawnChanceIn = 0; //DutvutanianCivilian2
            this.NPC92SpawnChanceIn = 0; //DutvutanianCivilian3
            this.NPC93SpawnChanceIn = 0; //DutvutanianIntelShip1
            this.NPC94SpawnChanceIn = 0; //DutvutanianPolice1
            this.NPC95SpawnChanceIn = 0; //DutvutanianObmurat1
            this.AgrianVigil = null;
        }
        //Maedracan Desert
        if (this.AreaNum == 1)
        {
            this.HeightLimit = 2000;
            //Objects
            this.P0SpawnChanceIn = 24; //PagesGobnard
            //Phenomenons
            this.PH0SpawnChanceIn = 8; //Dust Devil
            //Civilians & Creatures
            this.NPC000SpawnChanceIn = 0; //Peuktato
            this.NPC001SpawnChanceIn = 0; //Peuktorb
            this.NPC002SpawnChanceIn = 0; //Peuktuber
            this.NPC003SpawnChanceIn = 0; //Peuknyth
            this.NPC004SpawnChanceIn = 0; //Peuknyil
            this.NPC005SpawnChanceIn = 0; //Peukopede
            this.NPC006SpawnChanceIn = 0; //Big Peukopede
            this.NPC007SpawnChanceIn = 0; //Svibra Cloud
            this.NPC008SpawnChanceIn = 0; //Big Svibra Cloud
            this.NPC009SpawnChanceIn = 0; //Cykin
            this.NPC0091SpawnChanceIn = 0; //Turgkin
            this.NPC0800SpawnChanceIn = 0; //Oot1
            this.NPC0801SpawnChanceIn = 0; //Oot2
            this.NPC0802SpawnChanceIn = 0; //Oot3
            this.NPC0803SpawnChanceIn = 0; //Oot4
            this.NPC0804SpawnChanceIn = 0; //OotDut1
            this.NPC0805SpawnChanceIn = 0; //OotDut1Group
            this.NPC080SpawnChanceIn = 0; //Shadowfinger Ootkin
            this.NPC081SpawnChanceIn = 0; //Athnian Ootkin 1
            this.NPC082SpawnChanceIn = 0; //Athnian Ootkin 2
            this.NPC00SpawnChanceIn = 800; //Afazis Terracruiser EC-1
            this.NPC01SpawnChanceIn = 400; //TAK B-l4
            this.NPC02SpawnChanceIn = 250; //Ezyfus Bejsirf Apta
            this.NPC03SpawnChanceIn = 4800; //Carbondyle Fecuda C.211
            this.NPC04SpawnChanceIn = 800; //Slavoico BImG-500
            this.NPC05SpawnChanceIn = 1600; //Carbondyle Fecuda C.115
            //PrincipalCharacters
            this.NPC10SpawnChanceIn = 0; //Someone
            //Agrians
            this.NPC20SpawnChanceIn = 100; //Enforcer
            this.NPC21SpawnChanceIn = 150; //Sentinel
            this.NPC22SpawnChanceIn = 400; //Agent
            this.NPC23SpawnChanceIn = 800; //Executor
            this.NPC24SpawnChanceIn = 9000; //SuperExecutor
            this.NPC25SpawnChanceIn = 700; //Helirotor
            this.NPC26SpawnChanceIn = 1; //Annihilator
            this.NPC27SpawnChanceIn = 1; //Distributor
            //Terrahyptians
            this.NPC300SpawnChanceIn = 0; //LevNav Eos
            this.NPC301SpawnChanceIn = 0; //LevNav Ithis
            this.NPC302SpawnChanceIn = 0; //LevNav MAL
            this.NPC303SpawnChanceIn = 0; //LevNav Darion
            this.NPC310SpawnChanceIn = 200; //Bothunter
            this.NPC31SpawnChanceIn = 4000; //Valiant
            this.NPC32SpawnChanceIn = 3000; //FecarB1
            this.NPC33SpawnChanceIn = 7000; //DasNavCruiser
            this.NPC34SpawnChanceIn = 0; //TRN RD-1
            this.NPC35SpawnChanceIn = 1; //TLFAdamant
            this.NPC36SpawnChanceIn = 4000; //TLF Fughunter
            this.NPC37SpawnChanceIn = 1; //TLF LRCM Neutralizer
            this.NPC39SpawnChanceIn = 256; //TRN Zerana
            //Aberrants
            this.NPC40SpawnChanceIn = 100; //Abettor
            this.NPC41SpawnChanceIn = 100; //Gunner
            this.NPC42SpawnChanceIn = 100; //Militant
            this.NPC43SpawnChanceIn = 400; //Marauder
            this.NPC44SpawnChanceIn = 600; //Mercenary
            this.NPC45SpawnChanceIn = 1000; //Cruiser
            //Slavuics
            this.NPC50SpawnChanceIn = 200; //Civilian
            this.NPC51SpawnChanceIn = 250; //Watchmen
            this.NPC52SpawnChanceIn = 2000; //Mistitor
            this.NPC53SpawnChanceIn = 200; //Civilian2
            this.NPC54SpawnChanceIn = 800; //Snositor
            this.NPC55SpawnChanceIn = 300; //Vanguard
            this.NPC56SpawnChanceIn = 1; //Smertnik
            this.NPC57SpawnChanceIn = 300; //Satnik
            //Al-Atiba
            this.NPC60SpawnChanceIn = 350; //Van
            this.NPC61SpawnChanceIn = 400; //Guncarrier
            this.NPC62SpawnChanceIn = 500; //Bejsirf
            this.NPC63SpawnChanceIn = 800; //Microcruiser
            //MevNavs
            this.NPC70SpawnChanceIn = 300; //Scout Drone
            this.NPC71SpawnChanceIn = 500; //Battle Drone
            this.NPC72SpawnChanceIn = 600; //Cannon Drone
            this.NPC73SpawnChanceIn = 300; //Squire
            this.NPC74SpawnChanceIn = 600; //Archer
            this.NPC75SpawnChanceIn = 800; //Scabbard
            this.NPC76SpawnChanceIn = 400; //Warmonger
            this.NPC77SpawnChanceIn = 1000; //Knight
            this.NPC78SpawnChanceIn = 9000; //Deus
            this.NPC79SpawnChanceIn = 1; //Eschatos
            //Dutvutanians
            this.NPC90SpawnChanceIn = 0; //DutvutanianCivilian1
            this.NPC91SpawnChanceIn = 0; //DutvutanianCivilian2
            this.NPC92SpawnChanceIn = 0; //DutvutanianCivilian3
            this.NPC93SpawnChanceIn = 1; //DutvutanianIntelShip1
            this.NPC94SpawnChanceIn = 0; //DutvutanianPolice1
            this.NPC95SpawnChanceIn = 1; //DutvutanianObmurat1
        }
        //Anod Outpost
        if (this.AreaNum == 2)
        {
            this.HeightLimit = 2000;
            //Objects
            this.P0SpawnChanceIn = 16; //PagesGobnard
            //Phenomenons
            this.PH0SpawnChanceIn = 8; //Dust Devil
            //Civilians & Creatures
            this.NPC000SpawnChanceIn = 0; //Peuktato
            this.NPC001SpawnChanceIn = 0; //Peuktorb
            this.NPC002SpawnChanceIn = 0; //Peuktuber
            this.NPC003SpawnChanceIn = 0; //Peuknyth
            this.NPC004SpawnChanceIn = 0; //Peuknyil
            this.NPC005SpawnChanceIn = 0; //Peukopede
            this.NPC006SpawnChanceIn = 0; //Big Peukopede
            this.NPC007SpawnChanceIn = 0; //Svibra Cloud
            this.NPC008SpawnChanceIn = 0; //Big Svibra Cloud
            this.NPC009SpawnChanceIn = 0; //Cykin
            this.NPC0091SpawnChanceIn = 0; //Turgkin
            this.NPC0800SpawnChanceIn = 0; //Oot1
            this.NPC0801SpawnChanceIn = 0; //Oot2
            this.NPC0802SpawnChanceIn = 0; //Oot3
            this.NPC0803SpawnChanceIn = 0; //Oot4
            this.NPC0804SpawnChanceIn = 0; //OotDut1
            this.NPC0805SpawnChanceIn = 0; //OotDut1Group
            this.NPC080SpawnChanceIn = 0; //Shadowfinger Ootkin
            this.NPC081SpawnChanceIn = 0; //Athnian Ootkin 1
            this.NPC082SpawnChanceIn = 0; //Athnian Ootkin 2
            this.NPC00SpawnChanceIn = 200; //Afazis Terracruiser EC-1
            this.NPC01SpawnChanceIn = 300; //TAK B-l4
            this.NPC02SpawnChanceIn = 200; //Ezyfus Bejsirf Apta
            this.NPC03SpawnChanceIn = 3000; //Carbondyle Fecuda C.211
            this.NPC04SpawnChanceIn = 800; //Slavoico BImG-500
            this.NPC05SpawnChanceIn = 1000; //Carbondyle Fecuda C.115
            //PrincipalCharacters
            this.NPC10SpawnChanceIn = 0; //Someone
            //Agrians
            this.NPC20SpawnChanceIn = 150; //Enforcer
            this.NPC21SpawnChanceIn = 150; //Sentinel
            this.NPC22SpawnChanceIn = 400; //Agent
            this.NPC23SpawnChanceIn = 1000; //Executor
            this.NPC24SpawnChanceIn = 1; //SuperExecutor
            this.NPC25SpawnChanceIn = 1; //Helirotor
            this.NPC26SpawnChanceIn = 1; //Annihilator
            this.NPC27SpawnChanceIn = 1; //Distributor
            //Terrahyptians
            this.NPC300SpawnChanceIn = 0; //LevNav Eos
            this.NPC301SpawnChanceIn = 0; //LevNav Ithis
            this.NPC302SpawnChanceIn = 0; //LevNav MAL
            this.NPC303SpawnChanceIn = 0; //LevNav Darion
            this.NPC310SpawnChanceIn = 200; //Bothunter
            this.NPC31SpawnChanceIn = 400; //Valiant
            this.NPC32SpawnChanceIn = 1000; //FecarB1
            this.NPC33SpawnChanceIn = 8; //DasNavCruiser
            this.NPC34SpawnChanceIn = 0; //TRN RD-1
            this.NPC35SpawnChanceIn = 1; //TLFAdamant
            this.NPC36SpawnChanceIn = 1000; //TLF Fughunter
            this.NPC37SpawnChanceIn = 1; //TLF LRCM Neutralizer
            this.NPC39SpawnChanceIn = 128; //TRN Zerana
            //Aberrants
            this.NPC40SpawnChanceIn = 200; //Abettor
            this.NPC41SpawnChanceIn = 100; //Gunner
            this.NPC42SpawnChanceIn = 400; //Militant
            this.NPC43SpawnChanceIn = 1000; //Marauder
            this.NPC44SpawnChanceIn = 2000; //Mercenary
            this.NPC45SpawnChanceIn = 4000; //Cruiser
            //Slavuics
            this.NPC50SpawnChanceIn = 1000; //Civilian
            this.NPC51SpawnChanceIn = 850; //Watchmen
            this.NPC52SpawnChanceIn = 3500; //Mistitor
            this.NPC53SpawnChanceIn = 1500; //Civilian2
            this.NPC54SpawnChanceIn = 5000; //Snositor
            this.NPC55SpawnChanceIn = 1000; //Vanguard
            this.NPC56SpawnChanceIn = 1; //Smertnik
            this.NPC57SpawnChanceIn = 500; //Satnik
            //Al-Atiba
            this.NPC60SpawnChanceIn = 1000; //Van
            this.NPC61SpawnChanceIn = 1500; //Guncarrier
            this.NPC62SpawnChanceIn = 1000; //Bejsirf
            this.NPC63SpawnChanceIn = 3000; //Microcruiser
            //MevNavs
            this.NPC70SpawnChanceIn = 2000; //Scout Drone
            this.NPC71SpawnChanceIn = 3000; //Battle Drone
            this.NPC72SpawnChanceIn = 3000; //Cannon Drone
            this.NPC73SpawnChanceIn = 3000; //Squire
            this.NPC74SpawnChanceIn = 3000; //Archer
            this.NPC75SpawnChanceIn = 4000; //Scabbard
            this.NPC76SpawnChanceIn = 4000; //Warmonger
            this.NPC77SpawnChanceIn = 8000; //Knight
            this.NPC78SpawnChanceIn = 0; //Deus
            this.NPC79SpawnChanceIn = 1; //Eschatos
            //Dutvutanians
            this.NPC90SpawnChanceIn = 0; //DutvutanianCivilian1
            this.NPC91SpawnChanceIn = 0; //DutvutanianCivilian2
            this.NPC92SpawnChanceIn = 0; //DutvutanianCivilian3
            this.NPC93SpawnChanceIn = 1; //DutvutanianIntelShip1
            this.NPC94SpawnChanceIn = 0; //DutvutanianPolice1
            this.NPC95SpawnChanceIn = 1; //DutvutanianObmurat1
        }
        //Jaéden Agracoast
        if (this.AreaNum == 3)
        {
            this.HeightLimit = 2000;
            //Objects
            this.P0SpawnChanceIn = 16; //PagesGobnard
            //Phenomenons
            this.PH0SpawnChanceIn = 8; //Dust Devil
            //Civilians & Creatures
            this.NPC000SpawnChanceIn = 0; //Peuktato
            this.NPC001SpawnChanceIn = 0; //Peuktorb
            this.NPC002SpawnChanceIn = 0; //Peuktuber
            this.NPC003SpawnChanceIn = 0; //Peuknyth
            this.NPC004SpawnChanceIn = 0; //Peuknyil
            this.NPC005SpawnChanceIn = 0; //Peukopede
            this.NPC006SpawnChanceIn = 0; //Big Peukopede
            this.NPC007SpawnChanceIn = 0; //Svibra Cloud
            this.NPC008SpawnChanceIn = 0; //Big Svibra Cloud
            this.NPC009SpawnChanceIn = 0; //Cykin
            this.NPC0091SpawnChanceIn = 0; //Turgkin
            this.NPC0800SpawnChanceIn = 0; //Oot1
            this.NPC0801SpawnChanceIn = 0; //Oot2
            this.NPC0802SpawnChanceIn = 0; //Oot3
            this.NPC0803SpawnChanceIn = 0; //Oot4
            this.NPC0804SpawnChanceIn = 0; //OotDut1
            this.NPC0805SpawnChanceIn = 0; //OotDut1Group
            this.NPC080SpawnChanceIn = 0; //Shadowfinger Ootkin
            this.NPC081SpawnChanceIn = 0; //Athnian Ootkin 1
            this.NPC082SpawnChanceIn = 0; //Athnian Ootkin 2
            this.NPC00SpawnChanceIn = 300; //Afazis Terracruiser EC-1
            this.NPC01SpawnChanceIn = 250; //TAK B-l4
            this.NPC02SpawnChanceIn = 150; //Ezyfus Bejsirf Apta
            this.NPC03SpawnChanceIn = 2000; //Carbondyle Fecuda C.211
            this.NPC04SpawnChanceIn = 500; //Slavoico BImG-500
            this.NPC05SpawnChanceIn = 700; //Carbondyle Fecuda C.115
            //PrincipalCharacters
            this.NPC10SpawnChanceIn = 0; //Someone
            //Agrians
            this.NPC20SpawnChanceIn = 100; //Enforcer
            this.NPC21SpawnChanceIn = 100; //Sentinel
            this.NPC22SpawnChanceIn = 500; //Agent
            this.NPC23SpawnChanceIn = 1000; //Executor
            this.NPC24SpawnChanceIn = 1; //SuperExecutor
            this.NPC25SpawnChanceIn = 800; //Helirotor
            this.NPC26SpawnChanceIn = 1; //Annihilator
            this.NPC27SpawnChanceIn = 1; //Distributor
            //Terrahyptians
            this.NPC300SpawnChanceIn = 1; //LevNav Eos
            this.NPC301SpawnChanceIn = 200; //LevNav Ithis
            this.NPC302SpawnChanceIn = 1; //LevNav MAL
            this.NPC303SpawnChanceIn = 1; //LevNav Darion
            this.NPC310SpawnChanceIn = 200; //Bothunter
            this.NPC31SpawnChanceIn = 300; //Valiant
            this.NPC32SpawnChanceIn = 500; //FecarB1
            this.NPC33SpawnChanceIn = 0; //DasNavCruiser
            this.NPC34SpawnChanceIn = 0; //TRN RD-1
            this.NPC35SpawnChanceIn = 1; //TLFAdamant
            this.NPC36SpawnChanceIn = 1000; //TLF Fughunter
            this.NPC37SpawnChanceIn = 1; //TLF LRCM Neutralizer
            this.NPC39SpawnChanceIn = 128; //TRN Zerana
            //Aberrants
            this.NPC40SpawnChanceIn = 200; //Abettor
            this.NPC41SpawnChanceIn = 100; //Gunner
            this.NPC42SpawnChanceIn = 150; //Militant
            this.NPC43SpawnChanceIn = 500; //Marauder
            this.NPC44SpawnChanceIn = 800; //Mercenary
            this.NPC45SpawnChanceIn = 1500; //Cruiser
            //Slavuics
            this.NPC50SpawnChanceIn = 1000; //Civilian
            this.NPC51SpawnChanceIn = 850; //Watchmen
            this.NPC52SpawnChanceIn = 3500; //Mistitor
            this.NPC53SpawnChanceIn = 1500; //Civilian2
            this.NPC54SpawnChanceIn = 5000; //Snositor
            this.NPC55SpawnChanceIn = 1000; //Vanguard
            this.NPC56SpawnChanceIn = 1; //Smertnik
            this.NPC57SpawnChanceIn = 500; //Satnik
            //Al-Atiba
            this.NPC60SpawnChanceIn = 500; //Van
            this.NPC61SpawnChanceIn = 800; //Guncarrier
            this.NPC62SpawnChanceIn = 800; //Bejsirf
            this.NPC63SpawnChanceIn = 1500; //Microcruiser
            //MevNavs
            this.NPC70SpawnChanceIn = 600; //Scout Drone
            this.NPC71SpawnChanceIn = 800; //Battle Drone
            this.NPC72SpawnChanceIn = 800; //Cannon Drone
            this.NPC73SpawnChanceIn = 700; //Squire
            this.NPC74SpawnChanceIn = 800; //Archer
            this.NPC75SpawnChanceIn = 1500; //Scabbard
            this.NPC76SpawnChanceIn = 1000; //Warmonger
            this.NPC77SpawnChanceIn = 3000; //Knight
            this.NPC78SpawnChanceIn = 9000; //Deus
            this.NPC79SpawnChanceIn = 1; //Eschatos
            //Dutvutanians
            this.NPC90SpawnChanceIn = 0; //DutvutanianCivilian1
            this.NPC91SpawnChanceIn = 0; //DutvutanianCivilian2
            this.NPC92SpawnChanceIn = 0; //DutvutanianCivilian3
            this.NPC93SpawnChanceIn = 1; //DutvutanianIntelShip1
            this.NPC94SpawnChanceIn = 0; //DutvutanianPolice1
            this.NPC95SpawnChanceIn = 1; //DutvutanianObmurat1
        }
        //Central Athnias
        if (this.AreaNum == 4)
        {
            this.HeightLimit = 2000;
            //Objects
            this.P0SpawnChanceIn = 24; //PagesGobnard
            //Phenomenons
            this.PH0SpawnChanceIn = 0; //Dust Devil
            //Civilians & Creatures
            this.NPC000SpawnChanceIn = 0; //Peuktato
            this.NPC001SpawnChanceIn = 0; //Peuktorb
            this.NPC002SpawnChanceIn = 0; //Peuktuber
            this.NPC003SpawnChanceIn = 0; //Peuknyth
            this.NPC004SpawnChanceIn = 0; //Peuknyil
            this.NPC005SpawnChanceIn = 0; //Peukopede
            this.NPC006SpawnChanceIn = 0; //Big Peukopede
            this.NPC007SpawnChanceIn = 0; //Svibra Cloud
            this.NPC008SpawnChanceIn = 0; //Big Svibra Cloud
            this.NPC009SpawnChanceIn = 0; //Cykin
            this.NPC0091SpawnChanceIn = 0; //Turgkin
            this.NPC0800SpawnChanceIn = 300; //Oot1
            this.NPC0801SpawnChanceIn = 300; //Oot2
            this.NPC0802SpawnChanceIn = 100; //Oot3
            this.NPC0803SpawnChanceIn = 100; //Oot4
            this.NPC0804SpawnChanceIn = 0; //OotDut1
            this.NPC0805SpawnChanceIn = 0; //OotDut1Group
            this.NPC080SpawnChanceIn = 0; //Shadowfinger Ootkin
            this.NPC081SpawnChanceIn = 256; //Athnian Ootkin 1
            this.NPC082SpawnChanceIn = 256; //Athnian Ootkin 2
            this.NPC00SpawnChanceIn = 200; //Afazis Terracruiser EC-1
            this.NPC01SpawnChanceIn = 200; //TAK B-l4
            this.NPC02SpawnChanceIn = 100; //Ezyfus Bejsirf Apta
            this.NPC03SpawnChanceIn = 2000; //Carbondyle Fecuda C.211
            this.NPC04SpawnChanceIn = 800; //Slavoico BImG-500
            this.NPC05SpawnChanceIn = 750; //Carbondyle Fecuda C.115
            //PrincipalCharacters
            this.NPC10SpawnChanceIn = 0; //Someone
            //Agrians
            this.NPC20SpawnChanceIn = 100; //Enforcer
            this.NPC21SpawnChanceIn = 100; //Sentinel
            this.NPC22SpawnChanceIn = 1; //Agent
            this.NPC23SpawnChanceIn = 1; //Executor
            this.NPC24SpawnChanceIn = 1; //SuperExecutor
            this.NPC25SpawnChanceIn = 0; //Helirotor
            this.NPC26SpawnChanceIn = 1; //Annihilator
            this.NPC27SpawnChanceIn = 1; //Distributor
            //Terrahyptians
            this.NPC300SpawnChanceIn = 0; //LevNav Eos
            this.NPC301SpawnChanceIn = 0; //LevNav Ithis
            this.NPC302SpawnChanceIn = 0; //LevNav MAL
            this.NPC303SpawnChanceIn = 0; //LevNav Darion
            this.NPC310SpawnChanceIn = 300; //Bothunter
            this.NPC31SpawnChanceIn = 150; //Valiant
            this.NPC32SpawnChanceIn = 500; //FecarB1
            this.NPC33SpawnChanceIn = 0; //DasNavCruiser
            this.NPC34SpawnChanceIn = 1; //TRN RD-1
            this.NPC35SpawnChanceIn = 1; //TLFAdamant
            this.NPC36SpawnChanceIn = 1000; //TLF Fughunter
            this.NPC37SpawnChanceIn = 1; //TLF LRCM Neutralizer
            this.NPC39SpawnChanceIn = 64; //TRN Zerana
            //Aberrants
            this.NPC40SpawnChanceIn = 4000; //Abettor
            this.NPC41SpawnChanceIn = 6000; //Gunner
            this.NPC42SpawnChanceIn = 8000; //Militant
            this.NPC43SpawnChanceIn = 0; //Marauder
            this.NPC44SpawnChanceIn = 0; //Mercenary
            this.NPC45SpawnChanceIn = 0; //Cruiser
            //Slavuics
            this.NPC50SpawnChanceIn = 700; //Civilian
            this.NPC51SpawnChanceIn = 450; //Watchmen
            this.NPC52SpawnChanceIn = 3500; //Mistitor
            this.NPC53SpawnChanceIn = 850; //Civilian2
            this.NPC54SpawnChanceIn = 5000; //Snositor
            this.NPC55SpawnChanceIn = 2000; //Vanguard
            this.NPC56SpawnChanceIn = 1; //Smertnik
            this.NPC57SpawnChanceIn = 500; //Satnik
            //Al-Atiba
            this.NPC60SpawnChanceIn = 3000; //Van
            this.NPC61SpawnChanceIn = 6000; //Guncarrier
            this.NPC62SpawnChanceIn = 6000; //Bejsirf
            this.NPC63SpawnChanceIn = 0; //Microcruiser
            //MevNavs
            this.NPC70SpawnChanceIn = 2000; //Scout Drone
            this.NPC71SpawnChanceIn = 3000; //Battle Drone
            this.NPC72SpawnChanceIn = 3500; //Cannon Drone
            this.NPC73SpawnChanceIn = 4000; //Squire
            this.NPC74SpawnChanceIn = 5000; //Archer
            this.NPC75SpawnChanceIn = 5000; //Scabbard
            this.NPC76SpawnChanceIn = 5000; //Warmonger
            this.NPC77SpawnChanceIn = 9000; //Knight
            this.NPC78SpawnChanceIn = 0; //Deus
            this.NPC79SpawnChanceIn = 1; //Eschatos
            //Dutvutanians
            this.NPC90SpawnChanceIn = 0; //DutvutanianCivilian1
            this.NPC91SpawnChanceIn = 0; //DutvutanianCivilian2
            this.NPC92SpawnChanceIn = 0; //DutvutanianCivilian3
            this.NPC93SpawnChanceIn = 1; //DutvutanianIntelShip1
            this.NPC94SpawnChanceIn = 0; //DutvutanianPolice1
            this.NPC95SpawnChanceIn = 1; //DutvutanianObmurat1
        }
        //Dark Keigan Sanis
        if (this.AreaNum == 5)
        {
            this.HeightLimit = 2000;
            //Objects
            this.P0SpawnChanceIn = 48; //PagesGobnard
            //Phenomenons
            this.PH0SpawnChanceIn = 0; //Dust Devil
            //Civilians & Creatures
            this.NPC000SpawnChanceIn = 300; //Peuktato
            this.NPC001SpawnChanceIn = 32; //Peuktorb
            this.NPC002SpawnChanceIn = 64; //Peuktuber
            this.NPC003SpawnChanceIn = 200; //Peuknyth
            this.NPC004SpawnChanceIn = 600; //Peuknyil
            this.NPC005SpawnChanceIn = 100; //Peukopede
            this.NPC006SpawnChanceIn = 600; //Big Peukopede
            this.NPC007SpawnChanceIn = 32; //Svibra Cloud
            this.NPC008SpawnChanceIn = 512; //Big Svibra Cloud
            this.NPC009SpawnChanceIn = 0; //Cykin
            this.NPC0091SpawnChanceIn = 0; //Turgkin
            this.NPC0800SpawnChanceIn = 16; //Oot1
            this.NPC0801SpawnChanceIn = 16; //Oot2
            this.NPC0802SpawnChanceIn = 16; //Oot3
            this.NPC0803SpawnChanceIn = 16; //Oot4
            this.NPC0804SpawnChanceIn = 0; //OotDut1
            this.NPC0805SpawnChanceIn = 0; //OotDut1Group
            this.NPC080SpawnChanceIn = 200; //Shadowfinger Ootkin
            this.NPC081SpawnChanceIn = 0; //Athnian Ootkin 1
            this.NPC082SpawnChanceIn = 0; //Athnian Ootkin 2
            this.NPC00SpawnChanceIn = 1000; //Afazis Terracruiser EC-1
            this.NPC01SpawnChanceIn = 0; //TAK B-l4
            this.NPC02SpawnChanceIn = 0; //Ezyfus Bejsirf Apta
            this.NPC03SpawnChanceIn = 4000; //Carbondyle Fecuda C.211
            this.NPC04SpawnChanceIn = 0; //Slavoico BImG-500
            this.NPC05SpawnChanceIn = 2000; //Carbondyle Fecuda C.115
            //PrincipalCharacters
            this.NPC10SpawnChanceIn = 0; //Someone
            //Agrians
            this.NPC20SpawnChanceIn = 500; //Enforcer
            this.NPC21SpawnChanceIn = 400; //Sentinel
            this.NPC22SpawnChanceIn = 1; //Agent
            this.NPC23SpawnChanceIn = 1; //Executor
            this.NPC24SpawnChanceIn = 1; //SuperExecutor
            this.NPC25SpawnChanceIn = 0; //Helirotor
            this.NPC26SpawnChanceIn = 1; //Annihilator
            this.NPC27SpawnChanceIn = 1; //Distributor
            //Terrahyptians
            this.NPC300SpawnChanceIn = 0; //LevNav Eos
            this.NPC301SpawnChanceIn = 0; //LevNav Ithis
            this.NPC302SpawnChanceIn = 0; //LevNav MAL
            this.NPC303SpawnChanceIn = 0; //LevNav Darion
            this.NPC310SpawnChanceIn = 1000; //Bothunter
            this.NPC31SpawnChanceIn = 0; //Valiant
            this.NPC32SpawnChanceIn = 3000; //FecarB1
            this.NPC33SpawnChanceIn = 0; //DasNavCruiser
            this.NPC34SpawnChanceIn = 0; //TRN RD-1
            this.NPC35SpawnChanceIn = 0; //TLFAdamant
            this.NPC36SpawnChanceIn = 1000; //TLF Fughunter
            this.NPC37SpawnChanceIn = 1; //TLF LRCM Neutralizer
            this.NPC39SpawnChanceIn = 0; //TRN Zerana
            //Aberrants
            this.NPC40SpawnChanceIn = 1000; //Abettor
            this.NPC41SpawnChanceIn = 1000; //Gunner
            this.NPC42SpawnChanceIn = 1000; //Militant
            this.NPC43SpawnChanceIn = 0; //Marauder
            this.NPC44SpawnChanceIn = 0; //Mercenary
            this.NPC45SpawnChanceIn = 0; //Cruiser
            //Slavuics
            this.NPC50SpawnChanceIn = 0; //Civilian
            this.NPC51SpawnChanceIn = 0; //Watchmen
            this.NPC52SpawnChanceIn = 0; //Mistitor
            this.NPC53SpawnChanceIn = 0; //Civilian2
            this.NPC54SpawnChanceIn = 0; //Snositor
            this.NPC55SpawnChanceIn = 0; //Vanguard
            this.NPC56SpawnChanceIn = 1; //Smertnik
            this.NPC57SpawnChanceIn = 0; //Satnik
            //Al-Atiba
            this.NPC60SpawnChanceIn = 4000; //Van
            this.NPC61SpawnChanceIn = 8000; //Guncarrier
            this.NPC62SpawnChanceIn = 0; //Bejsirf
            this.NPC63SpawnChanceIn = 0; //Microcruiser
            //MevNavs
            this.NPC70SpawnChanceIn = 0; //Scout Drone
            this.NPC71SpawnChanceIn = 0; //Battle Drone
            this.NPC72SpawnChanceIn = 0; //Cannon Drone
            this.NPC73SpawnChanceIn = 0; //Squire
            this.NPC74SpawnChanceIn = 0; //Archer
            this.NPC75SpawnChanceIn = 0; //Scabbard
            this.NPC76SpawnChanceIn = 0; //Warmonger
            this.NPC77SpawnChanceIn = 0; //Knight
            this.NPC78SpawnChanceIn = 0; //Deus
            this.NPC79SpawnChanceIn = 0; //Eschatos
            //Dutvutanians
            this.NPC90SpawnChanceIn = 0; //DutvutanianCivilian1
            this.NPC91SpawnChanceIn = 0; //DutvutanianCivilian2
            this.NPC92SpawnChanceIn = 0; //DutvutanianCivilian3
            this.NPC93SpawnChanceIn = 1; //DutvutanianIntelShip1
            this.NPC94SpawnChanceIn = 0; //DutvutanianPolice1
            this.NPC95SpawnChanceIn = 1; //DutvutanianObmurat1
        }
        //Acrityrda
        if (this.AreaNum == 6)
        {
            this.HeightLimit = 1100;
            //Objects
            this.P0SpawnChanceIn = 96; //PagesGobnard
            //Phenomenons
            this.PH0SpawnChanceIn = 0; //Dust Devil
            //Civilians & Creatures
            this.NPC000SpawnChanceIn = 32; //Peuktato
            this.NPC001SpawnChanceIn = 32; //Peuktorb
            this.NPC002SpawnChanceIn = 32; //Peuktuber
            this.NPC003SpawnChanceIn = 32; //Peuknyth
            this.NPC004SpawnChanceIn = 32; //Peuknyil
            this.NPC005SpawnChanceIn = 32; //Peukopede
            this.NPC006SpawnChanceIn = 64; //Big Peukopede
            this.NPC007SpawnChanceIn = 64; //Svibra Cloud
            this.NPC008SpawnChanceIn = 0; //Big Svibra Cloud
            this.NPC009SpawnChanceIn = 0; //Cykin
            this.NPC0091SpawnChanceIn = 0; //Turgkin
            this.NPC0800SpawnChanceIn = 8; //Oot1
            this.NPC0801SpawnChanceIn = 8; //Oot2
            this.NPC0802SpawnChanceIn = 8; //Oot3
            this.NPC0803SpawnChanceIn = 8; //Oot4
            this.NPC0804SpawnChanceIn = 0; //OotDut1
            this.NPC0805SpawnChanceIn = 0; //OotDut1Group
            this.NPC080SpawnChanceIn = 64; //Shadowfinger Ootkin
            this.NPC081SpawnChanceIn = 0; //Athnian Ootkin 1
            this.NPC082SpawnChanceIn = 0; //Athnian Ootkin 2
            this.NPC00SpawnChanceIn = 0; //Afazis Terracruiser EC-1
            this.NPC01SpawnChanceIn = 0; //TAK B-l4
            this.NPC02SpawnChanceIn = 0; //Ezyfus Bejsirf Apta
            this.NPC03SpawnChanceIn = 0; //Carbondyle Fecuda C.211
            this.NPC04SpawnChanceIn = 0; //Slavoico BImG-500
            this.NPC05SpawnChanceIn = 0; //Carbondyle Fecuda C.115
            //PrincipalCharacters
            this.NPC10SpawnChanceIn = 0; //Someone
            //Agrians
            this.NPC20SpawnChanceIn = 0; //Enforcer
            this.NPC21SpawnChanceIn = 0; //Sentinel
            this.NPC22SpawnChanceIn = 0; //Agent
            this.NPC23SpawnChanceIn = 0; //Executor
            this.NPC24SpawnChanceIn = 0; //SuperExecutor
            this.NPC25SpawnChanceIn = 0; //Helirotor
            this.NPC26SpawnChanceIn = 0; //Annihilator
            this.NPC27SpawnChanceIn = 0; //Distributor
            //Terrahyptians
            this.NPC300SpawnChanceIn = 0; //LevNav Eos
            this.NPC301SpawnChanceIn = 0; //LevNav Ithis
            this.NPC302SpawnChanceIn = 0; //LevNav MAL
            this.NPC303SpawnChanceIn = 0; //LevNav Darion
            this.NPC310SpawnChanceIn = 0; //Bothunter
            this.NPC31SpawnChanceIn = 0; //Valiant
            this.NPC32SpawnChanceIn = 0; //FecarB1
            this.NPC33SpawnChanceIn = 0; //DasNavCruiser
            this.NPC34SpawnChanceIn = 0; //TRN RD-1
            this.NPC35SpawnChanceIn = 0; //TLFAdamant
            this.NPC36SpawnChanceIn = 0; //TLF Fughunter
            this.NPC37SpawnChanceIn = 0; //TLF LRCM Neutralizer
            this.NPC39SpawnChanceIn = 0; //TRN Zerana
            //Aberrants
            this.NPC40SpawnChanceIn = 0; //Abettor
            this.NPC41SpawnChanceIn = 0; //Gunner
            this.NPC42SpawnChanceIn = 0; //Militant
            this.NPC43SpawnChanceIn = 0; //Marauder
            this.NPC44SpawnChanceIn = 0; //Mercenary
            this.NPC45SpawnChanceIn = 0; //Cruiser
            //Slavuics
            this.NPC50SpawnChanceIn = 0; //Civilian
            this.NPC51SpawnChanceIn = 0; //Watchmen
            this.NPC52SpawnChanceIn = 0; //Mistitor
            this.NPC53SpawnChanceIn = 0; //Civilian2
            this.NPC54SpawnChanceIn = 0; //Snositor
            this.NPC55SpawnChanceIn = 0; //Vanguard
            this.NPC56SpawnChanceIn = 1; //Smertnik
            this.NPC57SpawnChanceIn = 0; //Satnik
            //Al-Atiba
            this.NPC60SpawnChanceIn = 0; //Van
            this.NPC61SpawnChanceIn = 0; //Guncarrier
            this.NPC62SpawnChanceIn = 0; //Bejsirf
            this.NPC63SpawnChanceIn = 0; //Microcruiser
            //MevNavs
            this.NPC70SpawnChanceIn = 0; //Scout Drone
            this.NPC71SpawnChanceIn = 0; //Battle Drone
            this.NPC72SpawnChanceIn = 0; //Cannon Drone
            this.NPC73SpawnChanceIn = 0; //Squire
            this.NPC74SpawnChanceIn = 0; //Archer
            this.NPC75SpawnChanceIn = 0; //Scabbard
            this.NPC76SpawnChanceIn = 0; //Warmonger
            this.NPC77SpawnChanceIn = 0; //Knight
            this.NPC78SpawnChanceIn = 0; //Deus
            this.NPC79SpawnChanceIn = 0; //Eschatos
            //Dutvutanians
            this.NPC90SpawnChanceIn = 0; //DutvutanianCivilian1
            this.NPC91SpawnChanceIn = 0; //DutvutanianCivilian2
            this.NPC92SpawnChanceIn = 0; //DutvutanianCivilian3
            this.NPC93SpawnChanceIn = 0; //DutvutanianIntelShip1
            this.NPC94SpawnChanceIn = 0; //DutvutanianPolice1
            this.NPC95SpawnChanceIn = 0; //DutvutanianObmurat1
            this.AgrianVigil = null;
        }
        //Knug
        if (this.AreaNum == 7)
        {
            this.HeightLimit = 1100;
            //Objects
            this.P0SpawnChanceIn = 0; //PagesGobnard
            //Phenomenons
            this.PH0SpawnChanceIn = 0; //Dust Devil
            //Civilians & Creatures
            this.NPC000SpawnChanceIn = 32; //Peuktato
            this.NPC001SpawnChanceIn = 32; //Peuktorb
            this.NPC002SpawnChanceIn = 32; //Peuktuber
            this.NPC003SpawnChanceIn = 32; //Peuknyth
            this.NPC004SpawnChanceIn = 32; //Peuknyil
            this.NPC005SpawnChanceIn = 32; //Peukopede
            this.NPC006SpawnChanceIn = 64; //Big Peukopede
            this.NPC007SpawnChanceIn = 64; //Svibra Cloud
            this.NPC008SpawnChanceIn = 0; //Big Svibra Cloud
            this.NPC009SpawnChanceIn = 0; //Cykin
            this.NPC0091SpawnChanceIn = 0; //Turgkin
            this.NPC0800SpawnChanceIn = 8; //Oot1
            this.NPC0801SpawnChanceIn = 8; //Oot2
            this.NPC0802SpawnChanceIn = 0; //Oot3
            this.NPC0803SpawnChanceIn = 0; //Oot4
            this.NPC0804SpawnChanceIn = 0; //OotDut1
            this.NPC0805SpawnChanceIn = 0; //OotDut1Group
            this.NPC080SpawnChanceIn = 64; //Shadowfinger Ootkin
            this.NPC081SpawnChanceIn = 0; //Athnian Ootkin 1
            this.NPC082SpawnChanceIn = 0; //Athnian Ootkin 2
            this.NPC00SpawnChanceIn = 0; //Afazis Terracruiser EC-1
            this.NPC01SpawnChanceIn = 0; //TAK B-l4
            this.NPC02SpawnChanceIn = 0; //Ezyfus Bejsirf Apta
            this.NPC03SpawnChanceIn = 0; //Carbondyle Fecuda C.211
            this.NPC04SpawnChanceIn = 0; //Slavoico BImG-500
            this.NPC05SpawnChanceIn = 0; //Carbondyle Fecuda C.115
            //PrincipalCharacters
            this.NPC10SpawnChanceIn = 0; //Someone
            //Agrians
            this.NPC20SpawnChanceIn = 0; //Enforcer
            this.NPC21SpawnChanceIn = 0; //Sentinel
            this.NPC22SpawnChanceIn = 0; //Agent
            this.NPC23SpawnChanceIn = 0; //Executor
            this.NPC24SpawnChanceIn = 0; //SuperExecutor
            this.NPC25SpawnChanceIn = 0; //Helirotor
            this.NPC26SpawnChanceIn = 0; //Annihilator
            this.NPC27SpawnChanceIn = 0; //Distributor
            //Terrahyptians
            this.NPC300SpawnChanceIn = 0; //LevNav Eos
            this.NPC301SpawnChanceIn = 0; //LevNav Ithis
            this.NPC302SpawnChanceIn = 0; //LevNav MAL
            this.NPC303SpawnChanceIn = 0; //LevNav Darion
            this.NPC310SpawnChanceIn = 0; //Bothunter
            this.NPC31SpawnChanceIn = 0; //Valiant
            this.NPC32SpawnChanceIn = 0; //FecarB1
            this.NPC33SpawnChanceIn = 0; //DasNavCruiser
            this.NPC34SpawnChanceIn = 0; //TRN RD-1
            this.NPC35SpawnChanceIn = 0; //TLFAdamant
            this.NPC36SpawnChanceIn = 0; //TLF Fughunter
            this.NPC37SpawnChanceIn = 0; //TLF LRCM Neutralizer
            this.NPC39SpawnChanceIn = 0; //TRN Zerana
            //Aberrants
            this.NPC40SpawnChanceIn = 0; //Abettor
            this.NPC41SpawnChanceIn = 0; //Gunner
            this.NPC42SpawnChanceIn = 0; //Militant
            this.NPC43SpawnChanceIn = 0; //Marauder
            this.NPC44SpawnChanceIn = 0; //Mercenary
            this.NPC45SpawnChanceIn = 0; //Cruiser
            //Slavuics
            this.NPC50SpawnChanceIn = 0; //Civilian
            this.NPC51SpawnChanceIn = 0; //Watchmen
            this.NPC52SpawnChanceIn = 0; //Mistitor
            this.NPC53SpawnChanceIn = 0; //Civilian2
            this.NPC54SpawnChanceIn = 0; //Snositor
            this.NPC55SpawnChanceIn = 0; //Vanguard
            this.NPC56SpawnChanceIn = 1; //Smertnik
            this.NPC57SpawnChanceIn = 0; //Satnik
            //Al-Atiba
            this.NPC60SpawnChanceIn = 0; //Van
            this.NPC61SpawnChanceIn = 0; //Guncarrier
            this.NPC62SpawnChanceIn = 0; //Bejsirf
            this.NPC63SpawnChanceIn = 0; //Microcruiser
            //MevNavs
            this.NPC70SpawnChanceIn = 0; //Scout Drone
            this.NPC71SpawnChanceIn = 0; //Battle Drone
            this.NPC72SpawnChanceIn = 0; //Cannon Drone
            this.NPC73SpawnChanceIn = 0; //Squire
            this.NPC74SpawnChanceIn = 0; //Archer
            this.NPC75SpawnChanceIn = 0; //Scabbard
            this.NPC76SpawnChanceIn = 0; //Warmonger
            this.NPC77SpawnChanceIn = 0; //Knight
            this.NPC78SpawnChanceIn = 0; //Deus
            this.NPC79SpawnChanceIn = 0; //Eschatos
            //Dutvutanians
            this.NPC90SpawnChanceIn = 0; //DutvutanianCivilian1
            this.NPC91SpawnChanceIn = 0; //DutvutanianCivilian2
            this.NPC92SpawnChanceIn = 0; //DutvutanianCivilian3
            this.NPC93SpawnChanceIn = 0; //DutvutanianIntelShip1
            this.NPC94SpawnChanceIn = 0; //DutvutanianPolice1
            this.NPC95SpawnChanceIn = 0; //DutvutanianObmurat1
            this.AgrianVigil = null;
        }
        //Agratyrda
        if (this.AreaNum == 8)
        {
            this.HeightLimit = 2000;
            //Objects
            this.P0SpawnChanceIn = 128; //PagesGobnard
            //Phenomenons
            this.PH0SpawnChanceIn = 0; //Dust Devil
            //Civilians & Creatures
            this.NPC000SpawnChanceIn = 0; //Peuktato
            this.NPC001SpawnChanceIn = 0; //Peuktorb
            this.NPC002SpawnChanceIn = 0; //Peuktuber
            this.NPC003SpawnChanceIn = 0; //Peuknyth
            this.NPC004SpawnChanceIn = 0; //Peuknyil
            this.NPC005SpawnChanceIn = 0; //Peukopede
            this.NPC006SpawnChanceIn = 0; //Big Peukopede
            this.NPC007SpawnChanceIn = 0; //Svibra Cloud
            this.NPC008SpawnChanceIn = 0; //Big Svibra Cloud
            this.NPC009SpawnChanceIn = 0; //Cykin
            this.NPC0091SpawnChanceIn = 0; //Turgkin
            this.NPC0800SpawnChanceIn = 0; //Oot1
            this.NPC0801SpawnChanceIn = 0; //Oot2
            this.NPC0802SpawnChanceIn = 0; //Oot3
            this.NPC0803SpawnChanceIn = 0; //Oot4
            this.NPC0804SpawnChanceIn = 0; //OotDut1
            this.NPC0805SpawnChanceIn = 0; //OotDut1Group
            this.NPC080SpawnChanceIn = 0; //Shadowfinger Ootkin
            this.NPC081SpawnChanceIn = 0; //Athnian Ootkin 1
            this.NPC082SpawnChanceIn = 0; //Athnian Ootkin 2
            this.NPC00SpawnChanceIn = 0; //Afazis Terracruiser EC-1
            this.NPC01SpawnChanceIn = 0; //TAK B-l4
            this.NPC02SpawnChanceIn = 0; //Ezyfus Bejsirf Apta
            this.NPC03SpawnChanceIn = 0; //Carbondyle Fecuda C.211
            this.NPC04SpawnChanceIn = 0; //Slavoico BImG-500
            this.NPC05SpawnChanceIn = 0; //Carbondyle Fecuda C.115
            //PrincipalCharacters
            this.NPC10SpawnChanceIn = 0; //Someone
            //Agrians
            this.NPC20SpawnChanceIn = 2; //Enforcer
            this.NPC21SpawnChanceIn = 2; //Sentinel
            this.NPC22SpawnChanceIn = 2; //Agent
            this.NPC23SpawnChanceIn = 0; //Executor
            this.NPC24SpawnChanceIn = 0; //SuperExecutor
            this.NPC25SpawnChanceIn = 0; //Helirotor
            this.NPC26SpawnChanceIn = 0; //Annihilator
            this.NPC27SpawnChanceIn = 0; //Distributor
            //Terrahyptians
            this.NPC300SpawnChanceIn = 0; //LevNav Eos
            this.NPC301SpawnChanceIn = 0; //LevNav Ithis
            this.NPC302SpawnChanceIn = 0; //LevNav MAL
            this.NPC303SpawnChanceIn = 0; //LevNav Darion
            this.NPC310SpawnChanceIn = 0; //Bothunter
            this.NPC31SpawnChanceIn = 0; //Valiant
            this.NPC32SpawnChanceIn = 0; //FecarB1
            this.NPC33SpawnChanceIn = 0; //DasNavCruiser
            this.NPC34SpawnChanceIn = 0; //TRN RD-1
            this.NPC35SpawnChanceIn = 0; //TLFAdamant
            this.NPC36SpawnChanceIn = 0; //TLF Fughunter
            this.NPC37SpawnChanceIn = 0; //TLF LRCM Neutralizer
            this.NPC39SpawnChanceIn = 0; //TRN Zerana
            //Aberrants
            this.NPC40SpawnChanceIn = 0; //Abettor
            this.NPC41SpawnChanceIn = 0; //Gunner
            this.NPC42SpawnChanceIn = 0; //Militant
            this.NPC43SpawnChanceIn = 0; //Marauder
            this.NPC44SpawnChanceIn = 0; //Mercenary
            this.NPC45SpawnChanceIn = 0; //Cruiser
            //Slavuics
            this.NPC50SpawnChanceIn = 0; //Civilian
            this.NPC51SpawnChanceIn = 0; //Watchmen
            this.NPC52SpawnChanceIn = 0; //Mistitor
            this.NPC53SpawnChanceIn = 0; //Civilian2
            this.NPC54SpawnChanceIn = 0; //Snositor
            this.NPC55SpawnChanceIn = 0; //Vanguard
            this.NPC56SpawnChanceIn = 0; //Smertnik
            this.NPC57SpawnChanceIn = 0; //Satnik
            //Al-Atiba
            this.NPC60SpawnChanceIn = 0; //Van
            this.NPC61SpawnChanceIn = 0; //Guncarrier
            this.NPC62SpawnChanceIn = 0; //Bejsirf
            this.NPC63SpawnChanceIn = 0; //Microcruiser
            //MevNavs
            this.NPC70SpawnChanceIn = 0; //Scout Drone
            this.NPC71SpawnChanceIn = 0; //Battle Drone
            this.NPC72SpawnChanceIn = 0; //Cannon Drone
            this.NPC73SpawnChanceIn = 0; //Squire
            this.NPC74SpawnChanceIn = 0; //Archer
            this.NPC75SpawnChanceIn = 0; //Scabbard
            this.NPC76SpawnChanceIn = 0; //Warmonger
            this.NPC77SpawnChanceIn = 0; //Knight
            this.NPC78SpawnChanceIn = 0; //Deus
            this.NPC79SpawnChanceIn = 0; //Eschatos
            //Dutvutanians
            this.NPC90SpawnChanceIn = 0; //DutvutanianCivilian1
            this.NPC91SpawnChanceIn = 0; //DutvutanianCivilian2
            this.NPC92SpawnChanceIn = 0; //DutvutanianCivilian3
            this.NPC93SpawnChanceIn = 0; //DutvutanianIntelShip1
            this.NPC94SpawnChanceIn = 0; //DutvutanianPolice1
            this.NPC95SpawnChanceIn = 0; //DutvutanianObmurat1
        }
        //Agratyrda Highway
        if (this.AreaNum == 9)
        {
            this.HeightLimit = 2000;
            //Objects
            this.P0SpawnChanceIn = 96; //PagesGobnard
            //Phenomenons
            this.PH0SpawnChanceIn = 0; //Dust Devil
            //Civilians & Creatures
            this.NPC000SpawnChanceIn = 0; //Peuktato
            this.NPC001SpawnChanceIn = 0; //Peuktorb
            this.NPC002SpawnChanceIn = 0; //Peuktuber
            this.NPC003SpawnChanceIn = 0; //Peuknyth
            this.NPC004SpawnChanceIn = 0; //Peuknyil
            this.NPC005SpawnChanceIn = 0; //Peukopede
            this.NPC006SpawnChanceIn = 0; //Big Peukopede
            this.NPC007SpawnChanceIn = 0; //Svibra Cloud
            this.NPC008SpawnChanceIn = 0; //Big Svibra Cloud
            this.NPC009SpawnChanceIn = 0; //Cykin
            this.NPC0091SpawnChanceIn = 0; //Turgkin
            this.NPC0800SpawnChanceIn = 0; //Oot1
            this.NPC0801SpawnChanceIn = 0; //Oot2
            this.NPC0802SpawnChanceIn = 0; //Oot3
            this.NPC0803SpawnChanceIn = 0; //Oot4
            this.NPC0804SpawnChanceIn = 0; //OotDut1
            this.NPC0805SpawnChanceIn = 0; //OotDut1Group
            this.NPC080SpawnChanceIn = 0; //Shadowfinger Ootkin
            this.NPC081SpawnChanceIn = 0; //Athnian Ootkin 1
            this.NPC082SpawnChanceIn = 0; //Athnian Ootkin 2
            this.NPC00SpawnChanceIn = 0; //Afazis Terracruiser EC-1
            this.NPC01SpawnChanceIn = 0; //TAK B-l4
            this.NPC02SpawnChanceIn = 0; //Ezyfus Bejsirf Apta
            this.NPC03SpawnChanceIn = 0; //Carbondyle Fecuda C.211
            this.NPC04SpawnChanceIn = 0; //Slavoico BImG-500
            this.NPC05SpawnChanceIn = 0; //Carbondyle Fecuda C.115
            //PrincipalCharacters
            this.NPC10SpawnChanceIn = 0; //Someone
            //Agrians
            this.NPC20SpawnChanceIn = 2; //Enforcer
            this.NPC21SpawnChanceIn = 2; //Sentinel
            this.NPC22SpawnChanceIn = 2; //Agent
            this.NPC23SpawnChanceIn = 0; //Executor
            this.NPC24SpawnChanceIn = 0; //SuperExecutor
            this.NPC25SpawnChanceIn = 0; //Helirotor
            this.NPC26SpawnChanceIn = 0; //Annihilator
            this.NPC27SpawnChanceIn = 0; //Distributor
            //Terrahyptians
            this.NPC300SpawnChanceIn = 0; //LevNav Eos
            this.NPC301SpawnChanceIn = 0; //LevNav Ithis
            this.NPC302SpawnChanceIn = 0; //LevNav MAL
            this.NPC303SpawnChanceIn = 0; //LevNav Darion
            this.NPC310SpawnChanceIn = 0; //Bothunter
            this.NPC31SpawnChanceIn = 0; //Valiant
            this.NPC32SpawnChanceIn = 0; //FecarB1
            this.NPC33SpawnChanceIn = 0; //DasNavCruiser
            this.NPC34SpawnChanceIn = 0; //TRN RD-1
            this.NPC35SpawnChanceIn = 0; //TLFAdamant
            this.NPC36SpawnChanceIn = 0; //TLF Fughunter
            this.NPC37SpawnChanceIn = 0; //TLF LRCM Neutralizer
            this.NPC39SpawnChanceIn = 0; //TRN Zerana
            //Aberrants
            this.NPC40SpawnChanceIn = 0; //Abettor
            this.NPC41SpawnChanceIn = 0; //Gunner
            this.NPC42SpawnChanceIn = 0; //Militant
            this.NPC43SpawnChanceIn = 0; //Marauder
            this.NPC44SpawnChanceIn = 0; //Mercenary
            this.NPC45SpawnChanceIn = 0; //Cruiser
            //Slavuics
            this.NPC50SpawnChanceIn = 0; //Civilian
            this.NPC51SpawnChanceIn = 0; //Watchmen
            this.NPC52SpawnChanceIn = 0; //Mistitor
            this.NPC53SpawnChanceIn = 0; //Civilian2
            this.NPC54SpawnChanceIn = 0; //Snositor
            this.NPC55SpawnChanceIn = 0; //Vanguard
            this.NPC56SpawnChanceIn = 0; //Smertnik
            this.NPC57SpawnChanceIn = 0; //Satnik
            //Al-Atiba
            this.NPC60SpawnChanceIn = 0; //Van
            this.NPC61SpawnChanceIn = 0; //Guncarrier
            this.NPC62SpawnChanceIn = 0; //Bejsirf
            this.NPC63SpawnChanceIn = 0; //Microcruiser
            //MevNavs
            this.NPC70SpawnChanceIn = 0; //Scout Drone
            this.NPC71SpawnChanceIn = 0; //Battle Drone
            this.NPC72SpawnChanceIn = 0; //Cannon Drone
            this.NPC73SpawnChanceIn = 0; //Squire
            this.NPC74SpawnChanceIn = 0; //Archer
            this.NPC75SpawnChanceIn = 0; //Scabbard
            this.NPC76SpawnChanceIn = 0; //Warmonger
            this.NPC77SpawnChanceIn = 0; //Knight
            this.NPC78SpawnChanceIn = 0; //Deus
            this.NPC79SpawnChanceIn = 0; //Eschatos
            //Dutvutanians
            this.NPC90SpawnChanceIn = 0; //DutvutanianCivilian1
            this.NPC91SpawnChanceIn = 0; //DutvutanianCivilian2
            this.NPC92SpawnChanceIn = 0; //DutvutanianCivilian3
            this.NPC93SpawnChanceIn = 0; //DutvutanianIntelShip1
            this.NPC94SpawnChanceIn = 0; //DutvutanianPolice1
            this.NPC95SpawnChanceIn = 0; //DutvutanianObmurat1
        }
        //Kabrius Estrellite
        if (this.AreaNum == 10)
        {
            this.HeightLimit = 2000;
            //Objects
            this.P0SpawnChanceIn = 0; //PagesGobnard
            //Phenomenons
            this.PH0SpawnChanceIn = 0; //Dust Devil
            //Civilians & Creatures
            this.NPC000SpawnChanceIn = 0; //Peuktato
            this.NPC001SpawnChanceIn = 0; //Peuktorb
            this.NPC002SpawnChanceIn = 0; //Peuktuber
            this.NPC003SpawnChanceIn = 0; //Peuknyth
            this.NPC004SpawnChanceIn = 0; //Peuknyil
            this.NPC005SpawnChanceIn = 0; //Peukopede
            this.NPC006SpawnChanceIn = 0; //Big Peukopede
            this.NPC007SpawnChanceIn = 0; //Svibra Cloud
            this.NPC008SpawnChanceIn = 0; //Big Svibra Cloud
            this.NPC009SpawnChanceIn = 0; //Cykin
            this.NPC0091SpawnChanceIn = 0; //Turgkin
            this.NPC0800SpawnChanceIn = 0; //Oot1
            this.NPC0801SpawnChanceIn = 0; //Oot2
            this.NPC0802SpawnChanceIn = 0; //Oot3
            this.NPC0803SpawnChanceIn = 0; //Oot4
            this.NPC0804SpawnChanceIn = 0; //OotDut1
            this.NPC0805SpawnChanceIn = 0; //OotDut1Group
            this.NPC080SpawnChanceIn = 0; //Shadowfinger Ootkin
            this.NPC081SpawnChanceIn = 0; //Athnian Ootkin 1
            this.NPC082SpawnChanceIn = 0; //Athnian Ootkin 2
            this.NPC00SpawnChanceIn = 0; //Afazis Terracruiser EC-1
            this.NPC01SpawnChanceIn = 0; //TAK B-l4
            this.NPC02SpawnChanceIn = 0; //Ezyfus Bejsirf Apta
            this.NPC03SpawnChanceIn = 0; //Carbondyle Fecuda C.211
            this.NPC04SpawnChanceIn = 0; //Slavoico BImG-500
            this.NPC05SpawnChanceIn = 0; //Carbondyle Fecuda C.115
            //PrincipalCharacters
            this.NPC10SpawnChanceIn = 0; //Someone
            //Agrians
            this.NPC20SpawnChanceIn = 0; //Enforcer
            this.NPC21SpawnChanceIn = 0; //Sentinel
            this.NPC22SpawnChanceIn = 0; //Agent
            this.NPC23SpawnChanceIn = 0; //Executor
            this.NPC24SpawnChanceIn = 0; //SuperExecutor
            this.NPC25SpawnChanceIn = 0; //Helirotor
            this.NPC26SpawnChanceIn = 1; //Annihilator
            this.NPC27SpawnChanceIn = 0; //Distributor
            //Terrahyptians
            this.NPC300SpawnChanceIn = 0; //LevNav Eos
            this.NPC301SpawnChanceIn = 0; //LevNav Ithis
            this.NPC302SpawnChanceIn = 0; //LevNav MAL
            this.NPC303SpawnChanceIn = 0; //LevNav Darion
            this.NPC310SpawnChanceIn = 0; //Bothunter
            this.NPC31SpawnChanceIn = 0; //Valiant
            this.NPC32SpawnChanceIn = 0; //FecarB1
            this.NPC33SpawnChanceIn = 0; //DasNavCruiser
            this.NPC34SpawnChanceIn = 0; //TRN RD-1
            this.NPC35SpawnChanceIn = 0; //TLFAdamant
            this.NPC36SpawnChanceIn = 0; //TLF Fughunter
            this.NPC37SpawnChanceIn = 0; //TLF LRCM Neutralizer
            this.NPC39SpawnChanceIn = 0; //TRN Zerana
            //Aberrants
            this.NPC40SpawnChanceIn = 0; //Abettor
            this.NPC41SpawnChanceIn = 0; //Gunner
            this.NPC42SpawnChanceIn = 0; //Militant
            this.NPC43SpawnChanceIn = 0; //Marauder
            this.NPC44SpawnChanceIn = 0; //Mercenary
            this.NPC45SpawnChanceIn = 0; //Cruiser
            //Slavuics
            this.NPC50SpawnChanceIn = 0; //Civilian
            this.NPC51SpawnChanceIn = 0; //Watchmen
            this.NPC52SpawnChanceIn = 0; //Mistitor
            this.NPC53SpawnChanceIn = 0; //Civilian2
            this.NPC54SpawnChanceIn = 0; //Snositor
            this.NPC55SpawnChanceIn = 0; //Vanguard
            this.NPC56SpawnChanceIn = 0; //Smertnik
            this.NPC57SpawnChanceIn = 0; //Satnik
            //Al-Atiba
            this.NPC60SpawnChanceIn = 0; //Van
            this.NPC61SpawnChanceIn = 0; //Guncarrier
            this.NPC62SpawnChanceIn = 0; //Bejsirf
            this.NPC63SpawnChanceIn = 0; //Microcruiser
            //MevNavs
            this.NPC70SpawnChanceIn = 0; //Scout Drone
            this.NPC71SpawnChanceIn = 0; //Battle Drone
            this.NPC72SpawnChanceIn = 0; //Cannon Drone
            this.NPC73SpawnChanceIn = 0; //Squire
            this.NPC74SpawnChanceIn = 0; //Archer
            this.NPC75SpawnChanceIn = 0; //Scabbard
            this.NPC76SpawnChanceIn = 0; //Warmonger
            this.NPC77SpawnChanceIn = 0; //Knight
            this.NPC78SpawnChanceIn = 0; //Deus
            this.NPC79SpawnChanceIn = 0; //Eschatos
            //Dutvutanians
            this.NPC90SpawnChanceIn = 0; //DutvutanianCivilian1
            this.NPC91SpawnChanceIn = 0; //DutvutanianCivilian2
            this.NPC92SpawnChanceIn = 0; //DutvutanianCivilian3
            this.NPC93SpawnChanceIn = 1; //DutvutanianIntelShip1
            this.NPC94SpawnChanceIn = 0; //DutvutanianPolice1
            this.NPC95SpawnChanceIn = 1; //DutvutanianObmurat1
            this.AgrianVigil = null;
        }
        //Sunfront Peninsula
        if (this.AreaNum == 11)
        {
            this.HeightLimit = 2000;
            //Objects
            this.P0SpawnChanceIn = 12; //PagesGobnard
            //Phenomenons
            this.PH0SpawnChanceIn = 0; //Dust Devil
            //Civilians & Creatures
            this.NPC000SpawnChanceIn = 0; //Peuktato
            this.NPC001SpawnChanceIn = 0; //Peuktorb
            this.NPC002SpawnChanceIn = 0; //Peuktuber
            this.NPC003SpawnChanceIn = 0; //Peuknyth
            this.NPC004SpawnChanceIn = 0; //Peuknyil
            this.NPC005SpawnChanceIn = 0; //Peukopede
            this.NPC006SpawnChanceIn = 0; //Big Peukopede
            this.NPC007SpawnChanceIn = 0; //Svibra Cloud
            this.NPC008SpawnChanceIn = 0; //Big Svibra Cloud
            this.NPC009SpawnChanceIn = 0; //Cykin
            this.NPC0091SpawnChanceIn = 0; //Turgkin
            this.NPC0800SpawnChanceIn = 0; //Oot1
            this.NPC0801SpawnChanceIn = 0; //Oot2
            this.NPC0802SpawnChanceIn = 0; //Oot3
            this.NPC0803SpawnChanceIn = 0; //Oot4
            this.NPC0804SpawnChanceIn = 0; //OotDut1
            this.NPC0805SpawnChanceIn = 0; //OotDut1Group
            this.NPC080SpawnChanceIn = 0; //Shadowfinger Ootkin
            this.NPC081SpawnChanceIn = 0; //Athnian Ootkin 1
            this.NPC082SpawnChanceIn = 0; //Athnian Ootkin 2
            this.NPC00SpawnChanceIn = 100; //Afazis Terracruiser EC-1
            this.NPC01SpawnChanceIn = 100; //TAK B-l4
            this.NPC02SpawnChanceIn = 50; //Ezyfus Bejsirf Apta
            this.NPC03SpawnChanceIn = 1800; //Carbondyle Fecuda C.211
            this.NPC04SpawnChanceIn = 700; //Slavoico BImG-500
            this.NPC05SpawnChanceIn = 700; //Carbondyle Fecuda C.115
            //PrincipalCharacters
            this.NPC10SpawnChanceIn = 0; //Someone
            //Agrians
            this.NPC20SpawnChanceIn = 150; //Enforcer
            this.NPC21SpawnChanceIn = 200; //Sentinel
            this.NPC22SpawnChanceIn = 1; //Agent
            this.NPC23SpawnChanceIn = 1; //Executor
            this.NPC24SpawnChanceIn = 1; //SuperExecutor
            this.NPC25SpawnChanceIn = 0; //Helirotor
            this.NPC26SpawnChanceIn = 1; //Annihilator
            this.NPC27SpawnChanceIn = 1; //Distributor
            //Terrahyptians
            this.NPC300SpawnChanceIn = 500; //LevNav Eos
            this.NPC301SpawnChanceIn = 200; //LevNav Ithis
            this.NPC302SpawnChanceIn = 2000; //LevNav MAL
            this.NPC303SpawnChanceIn = 6000; //LevNav Darion
            this.NPC310SpawnChanceIn = 500; //Bothunter
            this.NPC31SpawnChanceIn = 0; //Valiant
            this.NPC32SpawnChanceIn = 3000; //FecarB1
            this.NPC33SpawnChanceIn = 0; //DasNavCruiser
            this.NPC34SpawnChanceIn = 0; //TRN RD-1
            this.NPC35SpawnChanceIn = 0; //TLFAdamant
            this.NPC36SpawnChanceIn = 0; //TLF Fughunter
            this.NPC37SpawnChanceIn = 0; //TLF LRCM Neutralizer
            this.NPC39SpawnChanceIn = 128; //TRN Zerana
            //Aberrants
            this.NPC40SpawnChanceIn = 8000; //Abettor
            this.NPC41SpawnChanceIn = 8000; //Gunner
            this.NPC42SpawnChanceIn = 8000; //Militant
            this.NPC43SpawnChanceIn = 0; //Marauder
            this.NPC44SpawnChanceIn = 0; //Mercenary
            this.NPC45SpawnChanceIn = 0; //Cruiser
            //Slavuics
            this.NPC50SpawnChanceIn = 1000; //Civilian
            this.NPC51SpawnChanceIn = 2000; //Watchmen
            this.NPC52SpawnChanceIn = 5000; //Mistitor
            this.NPC53SpawnChanceIn = 1500; //Civilian2
            this.NPC54SpawnChanceIn = 5000; //Snositor
            this.NPC55SpawnChanceIn = 2000; //Vanguard
            this.NPC56SpawnChanceIn = 1; //Smertnik
            this.NPC57SpawnChanceIn = 1000; //Satnik
            //Al-Atiba
            this.NPC60SpawnChanceIn = 4000; //Van
            this.NPC61SpawnChanceIn = 8000; //Guncarrier
            this.NPC62SpawnChanceIn = 8000; //Bejsirf
            this.NPC63SpawnChanceIn = 0; //Microcruiser
            //MevNavs
            this.NPC70SpawnChanceIn = 2000; //Scout Drone
            this.NPC71SpawnChanceIn = 4000; //Battle Drone
            this.NPC72SpawnChanceIn = 5000; //Cannon Drone
            this.NPC73SpawnChanceIn = 6000; //Squire
            this.NPC74SpawnChanceIn = 6000; //Archer
            this.NPC75SpawnChanceIn = 6000; //Scabbard
            this.NPC76SpawnChanceIn = 6000; //Warmonger
            this.NPC77SpawnChanceIn = 0; //Knight
            this.NPC78SpawnChanceIn = 0; //Deus
            this.NPC79SpawnChanceIn = 1; //Eschatos
            //Dutvutanians
            this.NPC90SpawnChanceIn = 0; //DutvutanianCivilian1
            this.NPC91SpawnChanceIn = 0; //DutvutanianCivilian2
            this.NPC92SpawnChanceIn = 0; //DutvutanianCivilian3
            this.NPC93SpawnChanceIn = 1; //DutvutanianIntelShip1
            this.NPC94SpawnChanceIn = 0; //DutvutanianPolice1
            this.NPC95SpawnChanceIn = 1; //DutvutanianObmurat1
        }
        //Oyhurat Island
        if (this.AreaNum == 12)
        {
            this.HeightLimit = 2000;
            //Objects
            this.P0SpawnChanceIn = 48; //PagesGobnard
            //Phenomenons
            this.PH0SpawnChanceIn = 8; //Dust Devil
            //Civilians & Creatures
            this.NPC000SpawnChanceIn = 0; //Peuktato
            this.NPC001SpawnChanceIn = 0; //Peuktorb
            this.NPC002SpawnChanceIn = 0; //Peuktuber
            this.NPC003SpawnChanceIn = 0; //Peuknyth
            this.NPC004SpawnChanceIn = 0; //Peuknyil
            this.NPC005SpawnChanceIn = 0; //Peukopede
            this.NPC006SpawnChanceIn = 0; //Big Peukopede
            this.NPC007SpawnChanceIn = 0; //Svibra Cloud
            this.NPC008SpawnChanceIn = 0; //Big Svibra Cloud
            this.NPC009SpawnChanceIn = 0; //Cykin
            this.NPC0091SpawnChanceIn = 0; //Turgkin
            this.NPC0800SpawnChanceIn = 0; //Oot1
            this.NPC0801SpawnChanceIn = 0; //Oot2
            this.NPC0802SpawnChanceIn = 0; //Oot3
            this.NPC0803SpawnChanceIn = 0; //Oot4
            this.NPC0804SpawnChanceIn = 0; //OotDut1
            this.NPC0805SpawnChanceIn = 0; //OotDut1Group
            this.NPC080SpawnChanceIn = 0; //Shadowfinger Ootkin
            this.NPC081SpawnChanceIn = 0; //Athnian Ootkin 1
            this.NPC082SpawnChanceIn = 0; //Athnian Ootkin 2
            this.NPC00SpawnChanceIn = 800; //Afazis Terracruiser EC-1
            this.NPC01SpawnChanceIn = 400; //TAK B-l4
            this.NPC02SpawnChanceIn = 250; //Ezyfus Bejsirf Apta
            this.NPC03SpawnChanceIn = 6000; //Carbondyle Fecuda C.211
            this.NPC04SpawnChanceIn = 800; //Slavoico BImG-500
            this.NPC05SpawnChanceIn = 2000; //Carbondyle Fecuda C.115
            //PrincipalCharacters
            this.NPC10SpawnChanceIn = 0; //Someone
            //Agrians
            this.NPC20SpawnChanceIn = 100; //Enforcer
            this.NPC21SpawnChanceIn = 150; //Sentinel
            this.NPC22SpawnChanceIn = 400; //Agent
            this.NPC23SpawnChanceIn = 800; //Executor
            this.NPC24SpawnChanceIn = 9000; //SuperExecutor
            this.NPC25SpawnChanceIn = 700; //Helirotor
            this.NPC26SpawnChanceIn = 1; //Annihilator
            this.NPC27SpawnChanceIn = 1; //Distributor
            //Terrahyptians
            this.NPC300SpawnChanceIn = 0; //LevNav Eos
            this.NPC301SpawnChanceIn = 0; //LevNav Ithis
            this.NPC302SpawnChanceIn = 0; //LevNav MAL
            this.NPC303SpawnChanceIn = 0; //LevNav Darion
            this.NPC310SpawnChanceIn = 200; //Bothunter
            this.NPC31SpawnChanceIn = 4000; //Valiant
            this.NPC32SpawnChanceIn = 3000; //FecarB1
            this.NPC33SpawnChanceIn = 7000; //DasNavCruiser
            this.NPC34SpawnChanceIn = 1; //TRN RD-1
            this.NPC35SpawnChanceIn = 1; //TLFAdamant
            this.NPC36SpawnChanceIn = 4000; //TLF Fughunter
            this.NPC37SpawnChanceIn = 1; //TLF LRCM Neutralizer
            this.NPC39SpawnChanceIn = 256; //TRN Zerana
            //Aberrants
            this.NPC40SpawnChanceIn = 100; //Abettor
            this.NPC41SpawnChanceIn = 100; //Gunner
            this.NPC42SpawnChanceIn = 100; //Militant
            this.NPC43SpawnChanceIn = 400; //Marauder
            this.NPC44SpawnChanceIn = 600; //Mercenary
            this.NPC45SpawnChanceIn = 1000; //Cruiser
            //Slavuics
            this.NPC50SpawnChanceIn = 300; //Civilian
            this.NPC51SpawnChanceIn = 350; //Watchmen
            this.NPC52SpawnChanceIn = 3000; //Mistitor
            this.NPC53SpawnChanceIn = 300; //Civilian2
            this.NPC54SpawnChanceIn = 1000; //Snositor
            this.NPC55SpawnChanceIn = 400; //Vanguard
            this.NPC56SpawnChanceIn = 1; //Smertnik
            this.NPC57SpawnChanceIn = 400; //Satnik
            //Al-Atiba
            this.NPC60SpawnChanceIn = 350; //Van
            this.NPC61SpawnChanceIn = 400; //Guncarrier
            this.NPC62SpawnChanceIn = 500; //Bejsirf
            this.NPC63SpawnChanceIn = 800; //Microcruiser
            //MevNavs
            this.NPC70SpawnChanceIn = 300; //Scout Drone
            this.NPC71SpawnChanceIn = 500; //Battle Drone
            this.NPC72SpawnChanceIn = 600; //Cannon Drone
            this.NPC73SpawnChanceIn = 300; //Squire
            this.NPC74SpawnChanceIn = 600; //Archer
            this.NPC75SpawnChanceIn = 800; //Scabbard
            this.NPC76SpawnChanceIn = 400; //Warmonger
            this.NPC77SpawnChanceIn = 1000; //Knight
            this.NPC78SpawnChanceIn = 9000; //Deus
            this.NPC79SpawnChanceIn = 1; //Eschatos
            //Dutvutanians
            this.NPC90SpawnChanceIn = 0; //DutvutanianCivilian1
            this.NPC91SpawnChanceIn = 0; //DutvutanianCivilian2
            this.NPC92SpawnChanceIn = 0; //DutvutanianCivilian3
            this.NPC93SpawnChanceIn = 1; //DutvutanianIntelShip1
            this.NPC94SpawnChanceIn = 0; //DutvutanianPolice1
            this.NPC95SpawnChanceIn = 1; //DutvutanianObmurat1
        }
        //Keordis
        if (this.AreaNum == 13)
        {
            this.HeightLimit = 1100;
            //Objects
            this.P0SpawnChanceIn = 0; //PagesGobnard
            //Phenomenons
            this.PH0SpawnChanceIn = 0; //Dust Devil
            //Civilians & Creatures
            this.NPC000SpawnChanceIn = 0; //Peuktato
            this.NPC001SpawnChanceIn = 0; //Peuktorb
            this.NPC002SpawnChanceIn = 32; //Peuktuber
            this.NPC003SpawnChanceIn = 0; //Peuknyth
            this.NPC004SpawnChanceIn = 0; //Peuknyil
            this.NPC005SpawnChanceIn = 0; //Peukopede
            this.NPC006SpawnChanceIn = 0; //Big Peukopede
            this.NPC007SpawnChanceIn = 0; //Svibra Cloud
            this.NPC008SpawnChanceIn = 0; //Big Svibra Cloud
            this.NPC009SpawnChanceIn = 0; //Cykin
            this.NPC0091SpawnChanceIn = 0; //Turgkin
            this.NPC0800SpawnChanceIn = 12; //Oot1
            this.NPC0801SpawnChanceIn = 12; //Oot2
            this.NPC0802SpawnChanceIn = 12; //Oot3
            this.NPC0803SpawnChanceIn = 12; //Oot4
            this.NPC0804SpawnChanceIn = 0; //OotDut1
            this.NPC0805SpawnChanceIn = 0; //OotDut1Group
            this.NPC080SpawnChanceIn = 128; //Shadowfinger Ootkin
            this.NPC081SpawnChanceIn = 0; //Athnian Ootkin 1
            this.NPC082SpawnChanceIn = 0; //Athnian Ootkin 2
            this.NPC00SpawnChanceIn = 0; //Afazis Terracruiser EC-1
            this.NPC01SpawnChanceIn = 0; //TAK B-l4
            this.NPC02SpawnChanceIn = 0; //Ezyfus Bejsirf Apta
            this.NPC03SpawnChanceIn = 0; //Carbondyle Fecuda C.211
            this.NPC04SpawnChanceIn = 0; //Slavoico BImG-500
            this.NPC05SpawnChanceIn = 0; //Carbondyle Fecuda C.115
            //PrincipalCharacters
            this.NPC10SpawnChanceIn = 0; //Someone
            //Agrians
            this.NPC20SpawnChanceIn = 0; //Enforcer
            this.NPC21SpawnChanceIn = 0; //Sentinel
            this.NPC22SpawnChanceIn = 0; //Agent
            this.NPC23SpawnChanceIn = 0; //Executor
            this.NPC24SpawnChanceIn = 0; //SuperExecutor
            this.NPC25SpawnChanceIn = 0; //Helirotor
            this.NPC26SpawnChanceIn = 0; //Annihilator
            this.NPC27SpawnChanceIn = 0; //Distributor
            //Terrahyptians
            this.NPC300SpawnChanceIn = 0; //LevNav Eos
            this.NPC301SpawnChanceIn = 0; //LevNav Ithis
            this.NPC302SpawnChanceIn = 0; //LevNav MAL
            this.NPC303SpawnChanceIn = 0; //LevNav Darion
            this.NPC310SpawnChanceIn = 0; //Bothunter
            this.NPC31SpawnChanceIn = 0; //Valiant
            this.NPC32SpawnChanceIn = 0; //FecarB1
            this.NPC33SpawnChanceIn = 0; //DasNavCruiser
            this.NPC34SpawnChanceIn = 0; //TRN RD-1
            this.NPC35SpawnChanceIn = 0; //TLFAdamant
            this.NPC36SpawnChanceIn = 0; //TLF Fughunter
            this.NPC37SpawnChanceIn = 0; //TLF LRCM Neutralizer
            this.NPC39SpawnChanceIn = 0; //TRN Zerana
            //Aberrants
            this.NPC40SpawnChanceIn = 0; //Abettor
            this.NPC41SpawnChanceIn = 0; //Gunner
            this.NPC42SpawnChanceIn = 0; //Militant
            this.NPC43SpawnChanceIn = 0; //Marauder
            this.NPC44SpawnChanceIn = 0; //Mercenary
            this.NPC45SpawnChanceIn = 0; //Cruiser
            //Slavuics
            this.NPC50SpawnChanceIn = 0; //Civilian
            this.NPC51SpawnChanceIn = 0; //Watchmen
            this.NPC52SpawnChanceIn = 0; //Mistitor
            this.NPC53SpawnChanceIn = 0; //Civilian2
            this.NPC54SpawnChanceIn = 0; //Snositor
            this.NPC55SpawnChanceIn = 0; //Vanguard
            this.NPC56SpawnChanceIn = 1; //Smertnik
            this.NPC57SpawnChanceIn = 0; //Satnik
            //Al-Atiba
            this.NPC60SpawnChanceIn = 0; //Van
            this.NPC61SpawnChanceIn = 0; //Guncarrier
            this.NPC62SpawnChanceIn = 0; //Bejsirf
            this.NPC63SpawnChanceIn = 0; //Microcruiser
            //MevNavs
            this.NPC70SpawnChanceIn = 0; //Scout Drone
            this.NPC71SpawnChanceIn = 0; //Battle Drone
            this.NPC72SpawnChanceIn = 0; //Cannon Drone
            this.NPC73SpawnChanceIn = 0; //Squire
            this.NPC74SpawnChanceIn = 0; //Archer
            this.NPC75SpawnChanceIn = 0; //Scabbard
            this.NPC76SpawnChanceIn = 0; //Warmonger
            this.NPC77SpawnChanceIn = 0; //Knight
            this.NPC78SpawnChanceIn = 0; //Deus
            this.NPC79SpawnChanceIn = 0; //Eschatos
            //Dutvutanians
            this.NPC90SpawnChanceIn = 0; //DutvutanianCivilian1
            this.NPC91SpawnChanceIn = 0; //DutvutanianCivilian2
            this.NPC92SpawnChanceIn = 0; //DutvutanianCivilian3
            this.NPC93SpawnChanceIn = 0; //DutvutanianIntelShip1
            this.NPC94SpawnChanceIn = 0; //DutvutanianPolice1
            this.NPC95SpawnChanceIn = 0; //DutvutanianObmurat1
            this.AgrianVigil = null;
        }
        //Outer Azecreas
        if (this.AreaNum == 14)
        {
            this.HeightLimit = 2000;
            //Objects
            this.P0SpawnChanceIn = 24; //PagesGobnard
            //Phenomenons
            this.PH0SpawnChanceIn = 0; //Dust Devil
            //Civilians & Creatures
            this.NPC000SpawnChanceIn = 0; //Peuktato
            this.NPC001SpawnChanceIn = 0; //Peuktorb
            this.NPC002SpawnChanceIn = 0; //Peuktuber
            this.NPC003SpawnChanceIn = 0; //Peuknyth
            this.NPC004SpawnChanceIn = 0; //Peuknyil
            this.NPC005SpawnChanceIn = 0; //Peukopede
            this.NPC006SpawnChanceIn = 0; //Big Peukopede
            this.NPC007SpawnChanceIn = 0; //Svibra Cloud
            this.NPC008SpawnChanceIn = 0; //Big Svibra Cloud
            this.NPC009SpawnChanceIn = 0; //Cykin
            this.NPC0091SpawnChanceIn = 0; //Turgkin
            this.NPC0800SpawnChanceIn = 6000; //Oot1
            this.NPC0801SpawnChanceIn = 6000; //Oot2
            this.NPC0802SpawnChanceIn = 2000; //Oot3
            this.NPC0803SpawnChanceIn = 2000; //Oot4
            this.NPC0804SpawnChanceIn = 0; //OotDut1
            this.NPC0805SpawnChanceIn = 0; //OotDut1Group
            this.NPC080SpawnChanceIn = 0; //Shadowfinger Ootkin
            this.NPC081SpawnChanceIn = 0; //Athnian Ootkin 1
            this.NPC082SpawnChanceIn = 0; //Athnian Ootkin 2
            this.NPC00SpawnChanceIn = 200; //Afazis Terracruiser EC-1
            this.NPC01SpawnChanceIn = 200; //TAK B-l4
            this.NPC02SpawnChanceIn = 100; //Ezyfus Bejsirf Apta
            this.NPC03SpawnChanceIn = 2000; //Carbondyle Fecuda C.211
            this.NPC04SpawnChanceIn = 800; //Slavoico BImG-500
            this.NPC05SpawnChanceIn = 700; //Carbondyle Fecuda C.115
            //PrincipalCharacters
            this.NPC10SpawnChanceIn = 0; //Someone
            //Agrians
            this.NPC20SpawnChanceIn = 200; //Enforcer
            this.NPC21SpawnChanceIn = 200; //Sentinel
            this.NPC22SpawnChanceIn = 1; //Agent
            this.NPC23SpawnChanceIn = 1; //Executor
            this.NPC24SpawnChanceIn = 1; //SuperExecutor
            this.NPC25SpawnChanceIn = 0; //Helirotor
            this.NPC26SpawnChanceIn = 1; //Annihilator
            this.NPC27SpawnChanceIn = 1; //Distributor
            //Terrahyptians
            this.NPC300SpawnChanceIn = 0; //LevNav Eos
            this.NPC301SpawnChanceIn = 0; //LevNav Ithis
            this.NPC302SpawnChanceIn = 0; //LevNav MAL
            this.NPC303SpawnChanceIn = 0; //LevNav Darion
            this.NPC310SpawnChanceIn = 600; //Bothunter
            this.NPC31SpawnChanceIn = 300; //Valiant
            this.NPC32SpawnChanceIn = 200; //FecarB1
            this.NPC33SpawnChanceIn = 0; //DasNavCruiser
            this.NPC34SpawnChanceIn = 1; //TRN RD-1
            this.NPC35SpawnChanceIn = 1; //TLFAdamant
            this.NPC36SpawnChanceIn = 600; //TLF Fughunter
            this.NPC37SpawnChanceIn = 1; //TLF LRCM Neutralizer
            this.NPC39SpawnChanceIn = 8; //TRN Zerana
            //Aberrants
            this.NPC40SpawnChanceIn = 0; //Abettor
            this.NPC41SpawnChanceIn = 0; //Gunner
            this.NPC42SpawnChanceIn = 0; //Militant
            this.NPC43SpawnChanceIn = 0; //Marauder
            this.NPC44SpawnChanceIn = 0; //Mercenary
            this.NPC45SpawnChanceIn = 0; //Cruiser
            //Slavuics
            this.NPC50SpawnChanceIn = 1500; //Civilian
            this.NPC51SpawnChanceIn = 3000; //Watchmen
            this.NPC52SpawnChanceIn = 7000; //Mistitor
            this.NPC53SpawnChanceIn = 2000; //Civilian2
            this.NPC54SpawnChanceIn = 6000; //Snositor
            this.NPC55SpawnChanceIn = 3000; //Vanguard
            this.NPC56SpawnChanceIn = 0; //Smertnik
            this.NPC57SpawnChanceIn = 1000; //Satnik
            //Al-Atiba
            this.NPC60SpawnChanceIn = 0; //Van
            this.NPC61SpawnChanceIn = 0; //Guncarrier
            this.NPC62SpawnChanceIn = 0; //Bejsirf
            this.NPC63SpawnChanceIn = 0; //Microcruiser
            //MevNavs
            this.NPC70SpawnChanceIn = 4000; //Scout Drone
            this.NPC71SpawnChanceIn = 0; //Battle Drone
            this.NPC72SpawnChanceIn = 0; //Cannon Drone
            this.NPC73SpawnChanceIn = 8000; //Squire
            this.NPC74SpawnChanceIn = 0; //Archer
            this.NPC75SpawnChanceIn = 0; //Scabbard
            this.NPC76SpawnChanceIn = 9000; //Warmonger
            this.NPC77SpawnChanceIn = 0; //Knight
            this.NPC78SpawnChanceIn = 0; //Deus
            this.NPC79SpawnChanceIn = 1; //Eschatos
            //Dutvutanians
            this.NPC90SpawnChanceIn = 0; //DutvutanianCivilian1
            this.NPC91SpawnChanceIn = 0; //DutvutanianCivilian2
            this.NPC92SpawnChanceIn = 0; //DutvutanianCivilian3
            this.NPC93SpawnChanceIn = 1; //DutvutanianIntelShip1
            this.NPC94SpawnChanceIn = 0; //DutvutanianPolice1
            this.NPC95SpawnChanceIn = 1; //DutvutanianObmurat1
        }
        //DutvutanOutpost1
        if (this.AreaNum == 15)
        {
            this.HeightLimit = 2000;
            //Objects
            this.P0SpawnChanceIn = 0; //PagesGobnard
            //Phenomenons
            this.PH0SpawnChanceIn = 0; //Dust Devil
            //Civilians & Creatures
            this.NPC000SpawnChanceIn = 0; //Peuktato
            this.NPC001SpawnChanceIn = 0; //Peuktorb
            this.NPC002SpawnChanceIn = 0; //Peuktuber
            this.NPC003SpawnChanceIn = 0; //Peuknyth
            this.NPC004SpawnChanceIn = 0; //Peuknyil
            this.NPC005SpawnChanceIn = 0; //Peukopede
            this.NPC006SpawnChanceIn = 0; //Big Peukopede
            this.NPC007SpawnChanceIn = 0; //Svibra Cloud
            this.NPC008SpawnChanceIn = 0; //Big Svibra Cloud
            this.NPC009SpawnChanceIn = 64; //Cykin
            this.NPC0091SpawnChanceIn = 128; //Turgkin
            this.NPC0800SpawnChanceIn = 0; //Oot1
            this.NPC0801SpawnChanceIn = 0; //Oot2
            this.NPC0802SpawnChanceIn = 0; //Oot3
            this.NPC0803SpawnChanceIn = 0; //Oot4
            this.NPC0804SpawnChanceIn = 8; //OotDut1
            this.NPC0805SpawnChanceIn = 32; //OotDut1Group
            this.NPC080SpawnChanceIn = 0; //Shadowfinger Ootkin
            this.NPC081SpawnChanceIn = 0; //Athnian Ootkin 1
            this.NPC082SpawnChanceIn = 0; //Athnian Ootkin 2
            this.NPC00SpawnChanceIn = 0; //Afazis Terracruiser EC-1
            this.NPC01SpawnChanceIn = 0; //TAK B-l4
            this.NPC02SpawnChanceIn = 0; //Ezyfus Bejsirf Apta
            this.NPC03SpawnChanceIn = 0; //Carbondyle Fecuda C.211
            this.NPC04SpawnChanceIn = 0; //Slavoico BImG-500
            this.NPC05SpawnChanceIn = 0; //Carbondyle Fecuda C.115
            //PrincipalCharacters
            this.NPC10SpawnChanceIn = 0; //Someone
            //Agrians
            this.NPC20SpawnChanceIn = 0; //Enforcer
            this.NPC21SpawnChanceIn = 0; //Sentinel
            this.NPC22SpawnChanceIn = 0; //Agent
            this.NPC23SpawnChanceIn = 0; //Executor
            this.NPC24SpawnChanceIn = 0; //SuperExecutor
            this.NPC25SpawnChanceIn = 0; //Helirotor
            this.NPC26SpawnChanceIn = 0; //Annihilator
            this.NPC27SpawnChanceIn = 0; //Distributor
            //Terrahyptians
            this.NPC300SpawnChanceIn = 0; //LevNav Eos
            this.NPC301SpawnChanceIn = 0; //LevNav Ithis
            this.NPC302SpawnChanceIn = 0; //LevNav MAL
            this.NPC303SpawnChanceIn = 0; //LevNav Darion
            this.NPC310SpawnChanceIn = 0; //Bothunter
            this.NPC31SpawnChanceIn = 0; //Valiant
            this.NPC32SpawnChanceIn = 0; //FecarB1
            this.NPC33SpawnChanceIn = 0; //DasNavCruiser
            this.NPC34SpawnChanceIn = 0; //TRN RD-1
            this.NPC35SpawnChanceIn = 0; //TLFAdamant
            this.NPC36SpawnChanceIn = 0; //TLF Fughunter
            this.NPC37SpawnChanceIn = 0; //TLF LRCM Neutralizer
            this.NPC39SpawnChanceIn = 0; //TRN Zerana
            //Aberrants
            this.NPC40SpawnChanceIn = 0; //Abettor
            this.NPC41SpawnChanceIn = 0; //Gunner
            this.NPC42SpawnChanceIn = 0; //Militant
            this.NPC43SpawnChanceIn = 0; //Marauder
            this.NPC44SpawnChanceIn = 0; //Mercenary
            this.NPC45SpawnChanceIn = 0; //Cruiser
            //Slavuics
            this.NPC50SpawnChanceIn = 0; //Civilian
            this.NPC51SpawnChanceIn = 0; //Watchmen
            this.NPC52SpawnChanceIn = 0; //Mistitor
            this.NPC53SpawnChanceIn = 0; //Civilian2
            this.NPC54SpawnChanceIn = 0; //Snositor
            this.NPC55SpawnChanceIn = 0; //Vanguard
            this.NPC56SpawnChanceIn = 0; //Smertnik
            this.NPC57SpawnChanceIn = 0; //Satnik
            //Al-Atiba
            this.NPC60SpawnChanceIn = 0; //Van
            this.NPC61SpawnChanceIn = 0; //Guncarrier
            this.NPC62SpawnChanceIn = 0; //Bejsirf
            this.NPC63SpawnChanceIn = 0; //Microcruiser
            //MevNavs
            this.NPC70SpawnChanceIn = 0; //Scout Drone
            this.NPC71SpawnChanceIn = 0; //Battle Drone
            this.NPC72SpawnChanceIn = 0; //Cannon Drone
            this.NPC73SpawnChanceIn = 0; //Squire
            this.NPC74SpawnChanceIn = 0; //Archer
            this.NPC75SpawnChanceIn = 0; //Scabbard
            this.NPC76SpawnChanceIn = 0; //Warmonger
            this.NPC77SpawnChanceIn = 0; //Knight
            this.NPC78SpawnChanceIn = 0; //Deus
            this.NPC79SpawnChanceIn = 0; //Eschatos
            //Dutvutanians
            this.NPC90SpawnChanceIn = 100; //DutvutanianCivilian1
            this.NPC91SpawnChanceIn = 200; //DutvutanianCivilian2
            this.NPC92SpawnChanceIn = 300; //DutvutanianCivilian3
            this.NPC93SpawnChanceIn = 100; //DutvutanianIntelShip1
            this.NPC94SpawnChanceIn = 1000; //DutvutanianPolice1
            this.NPC95SpawnChanceIn = 9000; //DutvutanianObmurat1
            this.AgrianVigil = null;
        }
        //Arena
        if (this.AreaNum == 64)
        {
            this.HeightLimit = 2000;
            //Objects
            this.P0SpawnChanceIn = 0; //PagesGobnard
            //Phenomenons
            this.PH0SpawnChanceIn = 0; //Dust Devil
            //Civilians & Creatures
            this.NPC000SpawnChanceIn = 0; //Peuktato
            this.NPC001SpawnChanceIn = 0; //Peuktorb
            this.NPC002SpawnChanceIn = 0; //Peuktuber
            this.NPC003SpawnChanceIn = 0; //Peuknyth
            this.NPC004SpawnChanceIn = 0; //Peuknyil
            this.NPC005SpawnChanceIn = 0; //Peukopede
            this.NPC006SpawnChanceIn = 0; //Big Peukopede
            this.NPC007SpawnChanceIn = 0; //Svibra Cloud
            this.NPC008SpawnChanceIn = 0; //Big Svibra Cloud
            this.NPC009SpawnChanceIn = 0; //Cykin
            this.NPC0091SpawnChanceIn = 0; //Turgkin
            this.NPC0800SpawnChanceIn = 0; //Oot1
            this.NPC0801SpawnChanceIn = 0; //Oot2
            this.NPC0802SpawnChanceIn = 0; //Oot3
            this.NPC0803SpawnChanceIn = 0; //Oot4
            this.NPC0804SpawnChanceIn = 0; //OotDut1
            this.NPC0805SpawnChanceIn = 0; //OotDut1Group
            this.NPC080SpawnChanceIn = 0; //Shadowfinger Ootkin
            this.NPC081SpawnChanceIn = 0; //Athnian Ootkin 1
            this.NPC082SpawnChanceIn = 0; //Athnian Ootkin 2
            this.NPC00SpawnChanceIn = 0; //Afazis Terracruiser EC-1
            this.NPC01SpawnChanceIn = 0; //TAK B-l4
            this.NPC02SpawnChanceIn = 0; //Ezyfus Bejsirf Apta
            this.NPC03SpawnChanceIn = 0; //Carbondyle Fecuda C.211
            this.NPC04SpawnChanceIn = 0; //Slavoico BImG-500
            this.NPC05SpawnChanceIn = 0; //Carbondyle Fecuda C.115
            //PrincipalCharacters
            this.NPC10SpawnChanceIn = 0; //Someone
            //Agrians
            this.NPC20SpawnChanceIn = 0; //Enforcer
            this.NPC21SpawnChanceIn = 0; //Sentinel
            this.NPC22SpawnChanceIn = 0; //Agent
            this.NPC23SpawnChanceIn = 0; //Executor
            this.NPC24SpawnChanceIn = 0; //SuperExecutor
            this.NPC25SpawnChanceIn = 0; //Helirotor
            this.NPC26SpawnChanceIn = 0; //Annihilator
            this.NPC27SpawnChanceIn = 0; //Distributor
            //Terrahyptians
            this.NPC300SpawnChanceIn = 0; //LevNav Eos
            this.NPC301SpawnChanceIn = 0; //LevNav Ithis
            this.NPC302SpawnChanceIn = 0; //LevNav MAL
            this.NPC303SpawnChanceIn = 0; //LevNav Darion
            this.NPC310SpawnChanceIn = 0; //Bothunter
            this.NPC31SpawnChanceIn = 0; //Valiant
            this.NPC32SpawnChanceIn = 0; //FecarB1
            this.NPC33SpawnChanceIn = 0; //DasNavCruiser
            this.NPC34SpawnChanceIn = 0; //TRN RD-1
            this.NPC35SpawnChanceIn = 0; //TLFAdamant
            this.NPC36SpawnChanceIn = 0; //TLF Fughunter
            this.NPC37SpawnChanceIn = 1; //TLF LRCM Neutralizer
            this.NPC39SpawnChanceIn = 0; //TRN Zerana
            //Aberrants
            this.NPC40SpawnChanceIn = 0; //Abettor
            this.NPC41SpawnChanceIn = 0; //Gunner
            this.NPC42SpawnChanceIn = 0; //Militant
            this.NPC43SpawnChanceIn = 0; //Marauder
            this.NPC44SpawnChanceIn = 0; //Mercenary
            this.NPC45SpawnChanceIn = 0; //Cruiser
            //Slavuics
            this.NPC50SpawnChanceIn = 0; //Civilian
            this.NPC51SpawnChanceIn = 0; //Watchmen
            this.NPC52SpawnChanceIn = 0; //Mistitor
            this.NPC53SpawnChanceIn = 0; //Civilian2
            this.NPC54SpawnChanceIn = 0; //Snositor
            this.NPC55SpawnChanceIn = 0; //Vanguard
            this.NPC56SpawnChanceIn = 0; //Smertnik
            this.NPC57SpawnChanceIn = 0; //Satnik
            //Al-Atiba
            this.NPC60SpawnChanceIn = 0; //Van
            this.NPC61SpawnChanceIn = 0; //Guncarrier
            this.NPC62SpawnChanceIn = 0; //Bejsirf
            this.NPC63SpawnChanceIn = 0; //Microcruiser
            //MevNavs
            this.NPC70SpawnChanceIn = 0; //Scout Drone
            this.NPC71SpawnChanceIn = 0; //Battle Drone
            this.NPC72SpawnChanceIn = 0; //Cannon Drone
            this.NPC73SpawnChanceIn = 0; //Squire
            this.NPC74SpawnChanceIn = 0; //Archer
            this.NPC75SpawnChanceIn = 0; //Scabbard
            this.NPC76SpawnChanceIn = 0; //Warmonger
            this.NPC77SpawnChanceIn = 0; //Knight
            this.NPC78SpawnChanceIn = 0; //Deus
            this.NPC79SpawnChanceIn = 0; //Eschatos
            //Dutvutanians
            this.NPC90SpawnChanceIn = 0; //DutvutanianCivilian1
            this.NPC91SpawnChanceIn = 0; //DutvutanianCivilian2
            this.NPC92SpawnChanceIn = 0; //DutvutanianCivilian3
            this.NPC93SpawnChanceIn = 0; //DutvutanianIntelShip1
            this.NPC94SpawnChanceIn = 0; //DutvutanianPolice1
            this.NPC95SpawnChanceIn = 0; //DutvutanianObmurat1
            this.AgrianVigil = null;
        }
        //Static Settings --------------------------------------------------------------
        //Objects
        this.P0StaticSpawnChanceIn = this.P0SpawnChanceIn; //PagesGobnard
        //Phenomenons
        this.PH0StaticSpawnChanceIn = this.PH0SpawnChanceIn; //Dust Devil
        //Civilians & Creatures
        this.NPC000StaticSpawnChanceIn = this.NPC000SpawnChanceIn; //Peuktato
        this.NPC001StaticSpawnChanceIn = this.NPC001SpawnChanceIn; //Peuktorb
        this.NPC002StaticSpawnChanceIn = this.NPC002SpawnChanceIn; //Peuktuber
        this.NPC003StaticSpawnChanceIn = this.NPC003SpawnChanceIn; //Peuknyth
        this.NPC004StaticSpawnChanceIn = this.NPC004SpawnChanceIn; //Peuknyil
        this.NPC005StaticSpawnChanceIn = this.NPC005SpawnChanceIn; //Peukopede
        this.NPC006StaticSpawnChanceIn = this.NPC006SpawnChanceIn; //Big Peukopede
        this.NPC007StaticSpawnChanceIn = this.NPC007SpawnChanceIn; //Svibra Cloud
        this.NPC008StaticSpawnChanceIn = this.NPC008SpawnChanceIn; //Big Svibra Cloud
        this.NPC009StaticSpawnChanceIn = this.NPC009SpawnChanceIn; //Cykin
        this.NPC0091StaticSpawnChanceIn = this.NPC0091SpawnChanceIn; //Turgkin
        this.NPC0800StaticSpawnChanceIn = this.NPC0800SpawnChanceIn; //Oot1
        this.NPC0801StaticSpawnChanceIn = this.NPC0801SpawnChanceIn; //Oot2
        this.NPC0802StaticSpawnChanceIn = this.NPC0802SpawnChanceIn; //Oot1
        this.NPC0803StaticSpawnChanceIn = this.NPC0803SpawnChanceIn; //Oot2
        this.NPC0804StaticSpawnChanceIn = this.NPC0804SpawnChanceIn; //OotDut1
        this.NPC0805StaticSpawnChanceIn = this.NPC0805SpawnChanceIn; //OotDut1Group
        this.NPC080StaticSpawnChanceIn = this.NPC080SpawnChanceIn; //Shadowfinger Ootkin
        this.NPC081StaticSpawnChanceIn = this.NPC081SpawnChanceIn; //Athnian Ootkin 1
        this.NPC082StaticSpawnChanceIn = this.NPC082SpawnChanceIn; //Athnian Ootkin 2
        this.NPC00StaticSpawnChanceIn = this.NPC00SpawnChanceIn; //Afazis Terracruiser EC-1
        this.NPC01StaticSpawnChanceIn = this.NPC01SpawnChanceIn; //TAK B-l4
        this.NPC02StaticSpawnChanceIn = this.NPC02SpawnChanceIn; //Ezyfus Bejsirf Apta
        this.NPC03StaticSpawnChanceIn = this.NPC03SpawnChanceIn; //Carbondyle Fecuda C.211
        this.NPC04StaticSpawnChanceIn = this.NPC04SpawnChanceIn; //Slavoico BImG-500
        this.NPC05StaticSpawnChanceIn = this.NPC05SpawnChanceIn; //Carbondyle Fecuda C.115
        //PrincipalCharacters
        this.NPC10StaticSpawnChanceIn = this.NPC10SpawnChanceIn; //Someone
        //Agrians
        this.NPC20StaticSpawnChanceIn = this.NPC20SpawnChanceIn; //Enforcer
        this.NPC21StaticSpawnChanceIn = this.NPC21SpawnChanceIn; //Sentinel
        //Terrahyptians
        this.NPC300StaticSpawnChanceIn = this.NPC300SpawnChanceIn; //LevNav Eos
        this.NPC301StaticSpawnChanceIn = this.NPC301SpawnChanceIn; //LevNav Ithis
        this.NPC302StaticSpawnChanceIn = this.NPC302SpawnChanceIn; //LevNav MAL
        this.NPC303StaticSpawnChanceIn = this.NPC303SpawnChanceIn; //LevNav Darion
        this.NPC310StaticSpawnChanceIn = this.NPC310SpawnChanceIn; //Bothunter
        this.NPC31StaticSpawnChanceIn = this.NPC31SpawnChanceIn; //Valiant
        this.NPC32StaticSpawnChanceIn = this.NPC32SpawnChanceIn; //FecarB1
        this.NPC33StaticSpawnChanceIn = this.NPC33SpawnChanceIn; //DasNavCruiser
        this.NPC34StaticSpawnChanceIn = this.NPC34SpawnChanceIn; //TRN RD-1
        this.NPC35StaticSpawnChanceIn = this.NPC35SpawnChanceIn; //TLFAdamant
        this.NPC36StaticSpawnChanceIn = this.NPC36SpawnChanceIn; //TLF Fughunter
        this.NPC37StaticSpawnChanceIn = this.NPC37SpawnChanceIn; //TLF LRCM Neutralizer
        this.NPC39StaticSpawnChanceIn = this.NPC39SpawnChanceIn; //TRN Zerana
        //Aberrants
        this.NPC40StaticSpawnChanceIn = this.NPC40SpawnChanceIn; //Abettor
        this.NPC41StaticSpawnChanceIn = this.NPC41SpawnChanceIn; //Gunner
        this.NPC42StaticSpawnChanceIn = this.NPC42SpawnChanceIn; //Militant
        this.NPC43StaticSpawnChanceIn = this.NPC43SpawnChanceIn; //Marauder
        this.NPC44StaticSpawnChanceIn = this.NPC44SpawnChanceIn; //Mercenary
        this.NPC45StaticSpawnChanceIn = this.NPC45SpawnChanceIn; //Cruiser
        //Slavuics
        this.NPC50StaticSpawnChanceIn = this.NPC50SpawnChanceIn; //Civilian
        this.NPC51StaticSpawnChanceIn = this.NPC51SpawnChanceIn; //Watchmen
        this.NPC52StaticSpawnChanceIn = this.NPC52SpawnChanceIn; //Mistitor
        this.NPC53StaticSpawnChanceIn = this.NPC53SpawnChanceIn; //Civilian2
        this.NPC54StaticSpawnChanceIn = this.NPC54SpawnChanceIn; //Snositor
        this.NPC55StaticSpawnChanceIn = this.NPC55SpawnChanceIn; //Vanguard
        this.NPC56StaticSpawnChanceIn = this.NPC56SpawnChanceIn; //Smertnik
        //Akbars
        this.NPC60StaticSpawnChanceIn = this.NPC60SpawnChanceIn; //Van
        this.NPC61StaticSpawnChanceIn = this.NPC61SpawnChanceIn; //Guncarrier
        this.NPC62StaticSpawnChanceIn = this.NPC62SpawnChanceIn; //Bejsirf
        this.NPC63StaticSpawnChanceIn = this.NPC63SpawnChanceIn; //Microcruiser
        //MevNavs
        this.NPC70StaticSpawnChanceIn = this.NPC70SpawnChanceIn; //Sprite
        this.NPC71StaticSpawnChanceIn = this.NPC71SpawnChanceIn; //Battle Drone
        this.NPC72StaticSpawnChanceIn = this.NPC72SpawnChanceIn; //Cannon Drone
        this.NPC73StaticSpawnChanceIn = this.NPC73SpawnChanceIn; //Squire
        this.NPC74StaticSpawnChanceIn = this.NPC74SpawnChanceIn; //Archer
        this.NPC75StaticSpawnChanceIn = this.NPC75SpawnChanceIn; //Scabbard
        this.NPC76StaticSpawnChanceIn = this.NPC76SpawnChanceIn; //Warmonger
        this.NPC77StaticSpawnChanceIn = this.NPC77SpawnChanceIn; //Knight
        this.NPC78StaticSpawnChanceIn = this.NPC78SpawnChanceIn; //Deus
        //Dutvutanians
        this.NPC90StaticSpawnChanceIn = this.NPC90SpawnChanceIn; //Dutvutanian Civilian 1
        this.NPC91StaticSpawnChanceIn = this.NPC91SpawnChanceIn; //Dutvutanian Civilian 2
        this.NPC92StaticSpawnChanceIn = this.NPC92SpawnChanceIn; //Dutvutanian Civilian 3
        this.NPC93StaticSpawnChanceIn = this.NPC93SpawnChanceIn; //DutvutanianIntelShip1
        this.NPC94StaticSpawnChanceIn = this.NPC94SpawnChanceIn; //DutvutanianPolice1
        this.NPC95StaticSpawnChanceIn = this.NPC95SpawnChanceIn; //DutvutanianObmurat1
    }

    public virtual void FixedUpdate()
    {
        RaycastHit SBhit = default(RaycastHit);
        RaycastHit SBhit2 = default(RaycastHit);
        this.Vel2 = WorldInformation.vehicleSpeed * 0.02f;
        this.VelClamp = (int) Mathf.Clamp(this.Vel2, 1, 6);
        if (this.Count > 0)
        {
            this.Count = this.Count - this.VelClamp;
        }
        if (this.Count < 1)
        {
            this.Spawn();
            this.Count = 60;
        }
        if (this.SpawningBig)
        {
            if (!this.AreaSpace)
            {
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), -this.transform.up, out SBhit, this.HeightLimit, (int) this.targetLayers))
                {
                    this.TripleAltParentTF.position = SBhit.point;

                    {
                        float _3212 = this.TripleAltParentTF.localPosition.y + 1;
                        Vector3 _3213 = this.TripleAltParentTF.localPosition;
                        _3213.y = _3212;
                        this.TripleAltParentTF.localPosition = _3213;
                    }
                    this.AltaltRot.eulerAngles = this.AltaltRot.eulerAngles + new Vector3(0, 2, 0);
                    Debug.DrawRay(SBhit.point + (this.SpawnSource.up * 8), this.AltaltRot.forward * 150, Color.red);
                    if (Physics.Raycast(SBhit.point + (this.SpawnSource.up * 8), this.AltaltRot.forward, 150, (int) this.targetLayers))
                    {
                        this.Obscured = true;
                    }
                    if (this.TripleAltTF.localPosition.z > 1000)
                    {
                        this.TripleAltParentTF.eulerAngles = this.TripleAltParentTF.eulerAngles + new Vector3(0, 60, 0);

                        {
                            int _3214 = 0;
                            Vector3 _3215 = this.TripleAltTF.localPosition;
                            _3215.z = _3214;
                            this.TripleAltTF.localPosition = _3215;
                        }
                    }
                    if (Physics.Raycast(this.TripleAltTF.position + (this.TripleAltTF.up * 1000), -this.TripleAltTF.up, out SBhit2, 2000, (int) this.targetLayers))
                    {

                        {
                            float _3216 = this.TripleAltTF.localPosition.z + 20;
                            Vector3 _3217 = this.TripleAltTF.localPosition;
                            _3217.z = _3216;
                            this.TripleAltTF.localPosition = _3217;
                        }
                        Debug.DrawRay(SBhit2.point + (this.SpawnSource.up * 20), -this.AltaltRot.up * 40, Color.red);
                        if (!Physics.Raycast(SBhit2.point + (this.SpawnSource.up * 20), -this.AltaltRot.up, 40, (int) this.targetLayers))
                        {
                            this.Obscured = true;
                        }
                    }
                }
            }
            else
            {
                this.AltaltRot.eulerAngles = this.AltaltRot.eulerAngles + new Vector3(0, 2, 0);
                Debug.DrawRay(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), this.AltaltRot.forward * 300, Color.red);
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), this.AltaltRot.forward, 300, (int) this.targetLayers))
                {
                    this.Obscured = true;
                }
                Debug.DrawRay((this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist)) + (this.SpawnSource.up * 8), this.AltaltRot.forward * 300, Color.red);
                if (Physics.Raycast((this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist)) + (this.SpawnSource.up * 8), this.AltaltRot.forward, 300, (int) this.targetLayers))
                {
                    this.Obscured = true;
                }
                Debug.DrawRay((this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist)) - (this.SpawnSource.up * 8), this.AltaltRot.forward * 300, Color.red);
                if (Physics.Raycast((this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist)) - (this.SpawnSource.up * 8), this.AltaltRot.forward, 300, (int) this.targetLayers))
                {
                    this.Obscured = true;
                }
                Debug.DrawRay((this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist)) + (this.SpawnSource.up * 16), this.AltaltRot.forward * 300, Color.red);
                if (Physics.Raycast((this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist)) + (this.SpawnSource.up * 16), this.AltaltRot.forward, 300, (int) this.targetLayers))
                {
                    this.Obscured = true;
                }
                Debug.DrawRay((this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist)) - (this.SpawnSource.up * 16), this.AltaltRot.forward * 300, Color.red);
                if (Physics.Raycast((this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist)) - (this.SpawnSource.up * 16), this.AltaltRot.forward, 300, (int) this.targetLayers))
                {
                    this.Obscured = true;
                }
                Debug.DrawRay((this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist)) + (this.SpawnSource.up * 24), this.AltaltRot.forward * 300, Color.red);
                if (Physics.Raycast((this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist)) + (this.SpawnSource.up * 24), this.AltaltRot.forward, 300, (int) this.targetLayers))
                {
                    this.Obscured = true;
                }
                Debug.DrawRay((this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist)) - (this.SpawnSource.up * 24), this.AltaltRot.forward * 300, Color.red);
                if (Physics.Raycast((this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist)) - (this.SpawnSource.up * 24), this.AltaltRot.forward, 300, (int) this.targetLayers))
                {
                    this.Obscured = true;
                }
                Debug.DrawRay((this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist)) + (this.SpawnSource.up * 32), this.AltaltRot.forward * 300, Color.red);
                if (Physics.Raycast((this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist)) + (this.SpawnSource.up * 32), this.AltaltRot.forward, 300, (int) this.targetLayers))
                {
                    this.Obscured = true;
                }
                Debug.DrawRay((this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist)) - (this.SpawnSource.up * 32), this.AltaltRot.forward * 300, Color.red);
                if (Physics.Raycast((this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist)) - (this.SpawnSource.up * 32), this.AltaltRot.forward, 300, (int) this.targetLayers))
                {
                    this.Obscured = true;
                }
            }
        }
    }

    public virtual void Spawn()
    {
        RaycastHit hit = default(RaycastHit);
        Vector3 closest = default(Vector3);
        if (this.Vel2 > 0.5f)
        {
            this.MovingFast = true;
            this.VelBreak = 0;
        }
        else
        {
            this.VelBreak = this.VelBreak + 1;
            if (this.VelBreak > 4)
            {
                this.MovingFast = false;
            }
        }
        if (WorldInformation.playerLevel == 0)
        {
            this.IsInPerson = true;
        }
        else
        {
            this.IsInPerson = false;
        }
        if (AgrianNetwork.Alert)
        {
            if (this.NPC22SpawnChanceIn > 0)
            {
                this.NPC22SpawnChanceIn = 4;
            }
        }
        if (AgrianNetwork.instance.SubdueTarget)
        {
            if (this.NPC27SpawnChanceIn > 0)
            {
                this.NPC27SpawnChanceIn = 4;
            }
        }
        if (TerrahyptianNetwork.AlertLVL1 > 0)
        {
            if (this.NPC31SpawnChanceIn > 0)
            {
                this.NPC31SpawnChanceIn = 16;
            }
            //var Load1 = Resources.Load("Prefabs/Angy", GameObject) as GameObject;
            //var TGO1 = Instantiate(Load1, transform.position, transform.rotation);
            //TGO1.GetComponent(AngyScript).myText = "c3 > c" + TerrahyptianNetwork.AlertLVL1;
            TerrahyptianNetwork.AlertLVL1 = 0;
        }
        if (TerrahyptianNetwork.AlertLVL2 > 0)
        {
            if (this.NPC300SpawnChanceIn > 0)
            {
                this.NPC300SpawnChanceIn = 16;
            }
            if (this.NPC301SpawnChanceIn > 0)
            {
                this.NPC301SpawnChanceIn = 64;
            }
            if (this.NPC302SpawnChanceIn > 0)
            {
                this.NPC302SpawnChanceIn = 64;
            }
            if (this.NPC303SpawnChanceIn > 0)
            {
                this.NPC303SpawnChanceIn = 64;
            }
            if ((this.NPC33SpawnChanceIn > 0) && (this.NPC33SpawnChanceIn < 3000))
            {
                this.NPC33SpawnChanceIn = 16;
            }
            if (this.NPC34SpawnChanceIn > 0)
            {
                this.NPC34SpawnChanceIn = 16;
            }
            if (this.NPC35SpawnChanceIn > 0)
            {
                this.NPC35SpawnChanceIn = 16;
            }
            if (this.NPC36SpawnChanceIn > 0)
            {
                this.NPC36SpawnChanceIn = 16;
            }
            if (this.NPC37SpawnChanceIn > 0)
            {
                this.NPC37SpawnChanceIn = 16;
            }
            //var Load2 = Resources.Load("Prefabs/BigAngy", GameObject) as GameObject;
            //var TGO2 = Instantiate(Load2, transform.position, transform.rotation);
            //TGO2.GetComponent(AngyScript).myText = "c3 > c" + TerrahyptianNetwork.AlertLVL2;
            TerrahyptianNetwork.AlertLVL2 = 0;
        }
        if (CallAssistance.IsCargoing)
        {
            if (this.NPC32SpawnChanceIn > 1)
            {
                this.NPC32SpawnChanceIn = 4;
            }
        }
        if (AgrianNetwork.instance.AlertTime > 120)
        {
            if (this.NPC20SpawnChanceIn > 0)
            {
                this.NPC20SpawnChanceIn = 8;
            }
            if (this.NPC21SpawnChanceIn > 0)
            {
                this.NPC21SpawnChanceIn = 8;
            }
            if (this.NPC22SpawnChanceIn > 0)
            {
                this.NPC22SpawnChanceIn = 8;
            }
            if (AgrianNetwork.instance.AlertTime > 240)
            {
                if (this.NPC23SpawnChanceIn > 0)
                {
                    this.NPC23SpawnChanceIn = 4;
                }
            }
            if (AgrianNetwork.instance.AlertTime > 500)
            {
                if (this.NPC26SpawnChanceIn > 0)
                {
                    this.NPC26SpawnChanceIn = 4;
                }
            }
        }
        if ((SlavuicNetwork.TC1DeathRow > 300) && (SlavuicNetwork.TC1DeathRow < 600))
        {
            if ((this.NPC52SpawnChanceIn > 1) && (this.NPC52SpawnChanceIn < 4000))
            {
                this.NPC52SpawnChanceIn = 4;
            }
        }
        if (SlavuicNetwork.TC1DeathRow > 600)
        {
            if (this.NPC56SpawnChanceIn > 0)
            {
                this.NPC56SpawnChanceIn = 4;
            }
        }
        if (MevNavNetwork.AlertLVL1 > 0)
        {
            if ((this.NPC70SpawnChanceIn > 1) && (this.NPC70SpawnChanceIn < 1000))
            {
                this.NPC70SpawnChanceIn = 32;
            }
            if ((this.NPC77SpawnChanceIn > 1) && (this.NPC77SpawnChanceIn < 5000))
            {
                this.NPC77SpawnChanceIn = 64;
            }
            //var Load3 = Resources.Load("Prefabs/Angy", GameObject) as GameObject;
            //var TGO3 = Instantiate(Load3, transform.position, transform.rotation);
            //TGO3.GetComponent(AngyScript).myText = "c7 > c" + MevNavNetwork.AlertLVL1;
            MevNavNetwork.AlertLVL1 = 0;
        }
        if (MevNavNetwork.AlertLVL2 > 0)
        {
            if (this.NPC78SpawnChanceIn > 1)
            {
                this.NPC78SpawnChanceIn = 128;
            }
            //var Load4 = Resources.Load("Prefabs/BigAngy", GameObject) as GameObject;
            //var TGO4 = Instantiate(Load4, transform.position, transform.rotation);
            //TGO4.GetComponent(AngyScript).myText = "c7 > c" + MevNavNetwork.AlertLVL2;
            MevNavNetwork.AlertLVL2 = 0;
        }
        if (MevNavNetwork.AlertLVL3 > 2)
        {
            if (this.NPC79SpawnChanceIn > 0)
            {
                this.NPC79SpawnChanceIn = 8;
            }
            this.NPC70SpawnChanceIn = 4;
            this.NPC71SpawnChanceIn = 4;
            this.NPC72SpawnChanceIn = 4;
            this.NPC73SpawnChanceIn = 4;
            this.NPC74SpawnChanceIn = 4;
            this.NPC75SpawnChanceIn = 4;
            this.NPC76SpawnChanceIn = 4;
            this.NPC77SpawnChanceIn = 4;
            this.NPC78SpawnChanceIn = 4;
        }
        //var Load4 = Resources.Load("Prefabs/BigAngy", GameObject) as GameObject;
        //var TGO4 = Instantiate(Load4, transform.position, transform.rotation);
        //TGO4.GetComponent(AngyScript).myText = "c7 > c" + MevNavNetwork.AlertLVL2;
        if (DutvutanianNetwork.TC1CriminalLevel > 120)
        {
            if (this.NPC93SpawnChanceIn > 1)
            {
                this.NPC93SpawnChanceIn = 8;
            }
            if (DutvutanianNetwork.TC1CriminalLevel > 480)
            {
                if (this.NPC94SpawnChanceIn > 1)
                {
                    this.NPC94SpawnChanceIn = 32;
                }
            }
            if (DutvutanianNetwork.TC1CriminalLevel > 1400)
            {
                if (this.NPC95SpawnChanceIn > 0)
                {
                    this.NPC95SpawnChanceIn = 32;
                }
            }
        }
        if (DutvutanianNetwork.TC2CriminalLevel > 120)
        {
            if (this.NPC93SpawnChanceIn > 1)
            {
                this.NPC93SpawnChanceIn = 8;
            }
            if (DutvutanianNetwork.TC2CriminalLevel > 480)
            {
                if (this.NPC94SpawnChanceIn > 1)
                {
                    this.NPC94SpawnChanceIn = 32;
                }
            }
            if (DutvutanianNetwork.TC2CriminalLevel > 1400)
            {
                if (this.NPC95SpawnChanceIn > 0)
                {
                    this.NPC95SpawnChanceIn = 32;
                }
            }
        }
        if (!this.SpawningBig)
        {
            this.transform.LookAt(PlayerInformation.instance.PiriPresence);
            this.transform.position = PlayerInformation.instance.PiriPresence.position;

            {
                int _3218 = 0;
                Vector3 _3219 = this.transform.eulerAngles;
                _3219.x = _3218;
                this.transform.eulerAngles = _3219;
            }

            {
                int _3220 = 0;
                Vector3 _3221 = this.transform.eulerAngles;
                _3221.z = _3220;
                this.transform.eulerAngles = _3221;
            }
            this.savedRotY = this.transform.eulerAngles.y;
            //Services
            if ((this.TheAmmoBot == null) && CallAssistance.IsAmmoing)
            {
                if (this.VelClamp > 1)
                {

                    {
                        float _3222 = this.savedRotY;
                        Vector3 _3223 = this.transform.eulerAngles;
                        _3223.y = _3222;
                        this.transform.eulerAngles = _3223;
                    }

                    {
                        float _3224 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3225 = this.transform.eulerAngles;
                        _3225.y = _3224;
                        this.transform.eulerAngles = _3225;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                        this.TheAmmoBot = UnityEngine.Object.Instantiate(this.AmmoBot, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                    }
                }
            }
            if ((this.TheSnyns == null) && CallAssistance.IsSnynsing)
            {
                if (!WorldInformation.PiriPodPresent)
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                    if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 2000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                    {
                        GameObject PrefabionaiseSnyns = ((GameObject) Resources.Load("VesselPrefabs/Vessel1338", typeof(GameObject))) as GameObject;
                        this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                        this.TheSnyns = UnityEngine.Object.Instantiate(PrefabionaiseSnyns, hit.point + (this.SpawnSource.up * 4), this.SpawnPos.rotation);
                    }
                }
            }
            if ((this.TheKatovariDropPod == null) && CallAssistance.IsKatovariying)
            {
                this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 12000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    GameObject PrefabionaiseKatovariDropPod = ((GameObject) Resources.Load("NPCs/KatovariDropPod", typeof(GameObject))) as GameObject;
                    this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                    this.TheKatovariDropPod = UnityEngine.Object.Instantiate(PrefabionaiseKatovariDropPod, hit.point + (this.SpawnSource.up * 128), this.SpawnPos.rotation);
                }
            }
            //[Peuktato]===========================================================================================================================
            if ((StuffSpawner.TheNPC000N < 3) && (this.NPC000SpawnChanceIn > 1))
            {
                int randomValue000 = Random.Range(0, this.NPC000SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3226 = this.savedRotY;
                        Vector3 _3227 = this.transform.eulerAngles;
                        _3227.y = _3226;
                        this.transform.eulerAngles = _3227;
                    }

                    {
                        float _3228 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3229 = this.transform.eulerAngles;
                        _3229.y = _3228;
                        this.transform.eulerAngles = _3229;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(25, 400)), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        Vector3 CHP000 = hit.point + (this.SpawnSource.up * 2);
                        if (Vector3.Distance(CHP000, this.PiriView.position) < 300)
                        {
                            if (!Physics.Linecast(CHP000, this.PiriView.position, (int) this.targetLayers))
                            {
                                this.NPC000SpawnChanceIn = 3;
                                return;
                            }
                        }
                        switch (randomValue000)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                GameObject TheNPC000 = UnityEngine.Object.Instantiate(this.NPC000, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = TheNPC000.transform.position;
                                this.NPC000SpawnChanceIn = this.NPC000StaticSpawnChanceIn;
                                break;
                        }
                    }
                }
                else
                {
                    this.NPC000SpawnChanceIn = 3;
                }
            }
            //[Peuktorb]===========================================================================================================================
            if ((StuffSpawner.TheNPC001N < 3) && (this.NPC001SpawnChanceIn > 1))
            {
                int randomValue001 = Random.Range(0, this.NPC001SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3230 = this.savedRotY;
                        Vector3 _3231 = this.transform.eulerAngles;
                        _3231.y = _3230;
                        this.transform.eulerAngles = _3231;
                    }

                    {
                        float _3232 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3233 = this.transform.eulerAngles;
                        _3233.y = _3232;
                        this.transform.eulerAngles = _3233;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(25, 400)), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        Vector3 CHP001 = hit.point + (this.SpawnSource.up * 2);
                        if (Vector3.Distance(CHP001, this.PiriView.position) < 300)
                        {
                            if (!Physics.Linecast(CHP001, this.PiriView.position, (int) this.targetLayers))
                            {
                                this.NPC001SpawnChanceIn = 3;
                                return;
                            }
                        }
                        switch (randomValue001)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                GameObject TheNPC001 = UnityEngine.Object.Instantiate(this.NPC001, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = TheNPC001.transform.position;
                                this.NPC001SpawnChanceIn = this.NPC001StaticSpawnChanceIn;
                                break;
                        }
                    }
                }
                else
                {
                    this.NPC001SpawnChanceIn = 3;
                }
            }
            //[Peuktuber]===========================================================================================================================
            if ((StuffSpawner.TheNPC002N < 4) && (this.NPC002SpawnChanceIn > 1))
            {
                int randomValue002 = Random.Range(0, this.NPC002SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3234 = this.savedRotY;
                        Vector3 _3235 = this.transform.eulerAngles;
                        _3235.y = _3234;
                        this.transform.eulerAngles = _3235;
                    }

                    {
                        float _3236 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3237 = this.transform.eulerAngles;
                        _3237.y = _3236;
                        this.transform.eulerAngles = _3237;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(25, 200)), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        Vector3 CHP002 = hit.point + (this.SpawnSource.up * 2);
                        if (Vector3.Distance(CHP002, this.PiriView.position) < 100)
                        {
                            if (!Physics.Linecast(CHP002, this.PiriView.position, (int) this.targetLayers))
                            {
                                this.NPC002SpawnChanceIn = 3;
                                return;
                            }
                        }
                        switch (randomValue002)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                GameObject TheNPC002 = UnityEngine.Object.Instantiate(this.NPC002, hit.point + (this.SpawnSource.up * 1), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = TheNPC002.transform.position;
                                this.NPC002SpawnChanceIn = this.NPC002StaticSpawnChanceIn;
                                break;
                        }
                    }
                }
                else
                {
                    this.NPC002SpawnChanceIn = 3;
                }
            }
            //[Peuknyth]===========================================================================================================================
            if ((StuffSpawner.TheNPC003N < 2) && (this.NPC003SpawnChanceIn > 1))
            {
                int randomValue003 = Random.Range(0, this.NPC003SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3238 = this.savedRotY;
                        Vector3 _3239 = this.transform.eulerAngles;
                        _3239.y = _3238;
                        this.transform.eulerAngles = _3239;
                    }

                    {
                        float _3240 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3241 = this.transform.eulerAngles;
                        _3241.y = _3240;
                        this.transform.eulerAngles = _3241;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(25, 200)), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        Vector3 CHP003 = hit.point + (this.SpawnSource.up * 2);
                        if (Vector3.Distance(CHP003, this.PiriView.position) < 100)
                        {
                            if (!Physics.Linecast(CHP003, this.PiriView.position, (int) this.targetLayers))
                            {
                                this.NPC003SpawnChanceIn = 3;
                                return;
                            }
                        }
                        switch (randomValue003)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                GameObject TheNPC003 = UnityEngine.Object.Instantiate(this.NPC003, hit.point + (this.SpawnSource.up * 1), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = TheNPC003.transform.position;
                                this.NPC003SpawnChanceIn = this.NPC003StaticSpawnChanceIn;
                                break;
                        }
                    }
                }
                else
                {
                    this.NPC003SpawnChanceIn = 3;
                }
            }
            //[Peuknyil]===========================================================================================================================
            if ((StuffSpawner.TheNPC004N < 2) && (this.NPC004SpawnChanceIn > 1))
            {
                int randomValue004 = Random.Range(0, this.NPC004SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3242 = this.savedRotY;
                        Vector3 _3243 = this.transform.eulerAngles;
                        _3243.y = _3242;
                        this.transform.eulerAngles = _3243;
                    }

                    {
                        float _3244 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3245 = this.transform.eulerAngles;
                        _3245.y = _3244;
                        this.transform.eulerAngles = _3245;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(25, 1000)), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa") && !hit.collider.name.Contains("Pa"))
                    {
                        Vector3 CHP004 = hit.point + (this.SpawnSource.up * 2);
                        if (Vector3.Distance(CHP004, this.PiriView.position) < 900)
                        {
                            if (!Physics.Linecast(CHP004, this.PiriView.position, (int) this.targetLayers))
                            {
                                this.NPC004SpawnChanceIn = 3;
                                return;
                            }
                        }
                        switch (randomValue004)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                GameObject TheNPC004 = UnityEngine.Object.Instantiate(this.NPC004, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = TheNPC004.transform.position;
                                this.NPC004SpawnChanceIn = this.NPC004StaticSpawnChanceIn;
                                break;
                        }
                    }
                }
                else
                {
                    this.NPC004SpawnChanceIn = 3;
                }
            }
            //[Peukopede]===========================================================================================================================
            if ((StuffSpawner.TheNPC005N < 3) && (this.NPC005SpawnChanceIn > 1))
            {
                int randomValue005 = Random.Range(0, this.NPC005SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3246 = this.savedRotY;
                        Vector3 _3247 = this.transform.eulerAngles;
                        _3247.y = _3246;
                        this.transform.eulerAngles = _3247;
                    }

                    {
                        float _3248 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3249 = this.transform.eulerAngles;
                        _3249.y = _3248;
                        this.transform.eulerAngles = _3249;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(25, 600)), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        Vector3 CHP005 = hit.point + (this.SpawnSource.up * 2);
                        if (Vector3.Distance(CHP005, this.PiriView.position) < 500)
                        {
                            if (!Physics.Linecast(CHP005, this.PiriView.position, (int) this.targetLayers))
                            {
                                this.NPC005SpawnChanceIn = 3;
                                return;
                            }
                        }
                        switch (randomValue005)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                GameObject TheNPC005 = UnityEngine.Object.Instantiate(this.NPC005, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = TheNPC005.transform.position;
                                this.NPC005SpawnChanceIn = this.NPC005StaticSpawnChanceIn;
                                break;
                        }
                    }
                }
                else
                {
                    this.NPC005SpawnChanceIn = 3;
                }
            }
            //[Big Peukopede]===========================================================================================================================
            if ((this.TheNPC006 == null) && (this.NPC006SpawnChanceIn > 1))
            {
                int randomValue006 = Random.Range(0, this.NPC006SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3250 = this.savedRotY;
                        Vector3 _3251 = this.transform.eulerAngles;
                        _3251.y = _3250;
                        this.transform.eulerAngles = _3251;
                    }

                    {
                        float _3252 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3253 = this.transform.eulerAngles;
                        _3253.y = _3252;
                        this.transform.eulerAngles = _3253;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(25, 800)), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa") && !hit.collider.name.Contains("Pa"))
                    {
                        Vector3 CHP006 = hit.point + (this.SpawnSource.up * 2);
                        if (Vector3.Distance(CHP006, this.PiriView.position) < 700)
                        {
                            if (!Physics.Linecast(CHP006, this.PiriView.position, (int) this.targetLayers))
                            {
                                this.NPC006SpawnChanceIn = 3;
                                return;
                            }
                        }
                        switch (randomValue006)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC006 = UnityEngine.Object.Instantiate(this.NPC006, hit.point + (this.SpawnSource.up * 3), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC006.transform.position;
                                this.NPC006SpawnChanceIn = this.NPC006StaticSpawnChanceIn;
                                break;
                        }
                    }
                }
                else
                {
                    this.NPC006SpawnChanceIn = 3;
                }
            }
            //[Svibra Cloud]===========================================================================================================================
            if ((this.TheNPC007 == null) && (this.NPC007SpawnChanceIn > 1))
            {
                int randomValue007 = Random.Range(0, this.NPC007SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3254 = this.savedRotY;
                        Vector3 _3255 = this.transform.eulerAngles;
                        _3255.y = _3254;
                        this.transform.eulerAngles = _3255;
                    }

                    {
                        float _3256 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3257 = this.transform.eulerAngles;
                        _3257.y = _3256;
                        this.transform.eulerAngles = _3257;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(this.LowSpawnDist, 200)), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        Vector3 CHP007 = hit.point + (this.SpawnSource.up * 2);
                        if (Vector3.Distance(CHP007, this.PiriView.position) < 100)
                        {
                            if (!Physics.Linecast(CHP007, this.PiriView.position, (int) this.targetLayers))
                            {
                                this.NPC007SpawnChanceIn = 3;
                                return;
                            }
                        }
                        switch (randomValue007)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC007 = UnityEngine.Object.Instantiate(this.NPC007, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC007.transform.position;
                                this.NPC007SpawnChanceIn = this.NPC007StaticSpawnChanceIn;
                                break;
                        }
                    }
                }
                else
                {
                    this.NPC007SpawnChanceIn = 3;
                }
            }
            //[Big Svibra Cloud]===========================================================================================================================
            if ((this.TheNPC008 == null) && (this.NPC008SpawnChanceIn > 1))
            {
                int randomValue008 = Random.Range(0, this.NPC008SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3258 = this.savedRotY;
                        Vector3 _3259 = this.transform.eulerAngles;
                        _3259.y = _3258;
                        this.transform.eulerAngles = _3259;
                    }

                    {
                        float _3260 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3261 = this.transform.eulerAngles;
                        _3261.y = _3260;
                        this.transform.eulerAngles = _3261;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(this.LowSpawnDist, 600)), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        Vector3 CHP008 = hit.point + (this.SpawnSource.up * 2);
                        if (Vector3.Distance(CHP008, this.PiriView.position) < 500)
                        {
                            if (!Physics.Linecast(CHP008, this.PiriView.position, (int) this.targetLayers))
                            {
                                this.NPC008SpawnChanceIn = 3;
                                return;
                            }
                        }
                        switch (randomValue008)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC008 = UnityEngine.Object.Instantiate(this.NPC008, hit.point + (this.SpawnSource.up * 3), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC008.transform.position;
                                this.NPC008SpawnChanceIn = this.NPC008StaticSpawnChanceIn;
                                break;
                        }
                    }
                }
                else
                {
                    this.NPC008SpawnChanceIn = 3;
                }
            }
            //[Cykin]===========================================================================================================================
            if ((StuffSpawner.TheNPC009N < 3) && (this.NPC009SpawnChanceIn > 1))
            {
                GameObject Spawnionaise009 = ((GameObject) Resources.Load("NPCs/CykinDut", typeof(GameObject))) as GameObject;
                int randomValue009 = Random.Range(0, this.NPC009SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3262 = this.savedRotY;
                        Vector3 _3263 = this.transform.eulerAngles;
                        _3263.y = _3262;
                        this.transform.eulerAngles = _3263;
                    }

                    {
                        float _3264 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3265 = this.transform.eulerAngles;
                        _3265.y = _3264;
                        this.transform.eulerAngles = _3265;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast((this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(128, 256))) + (-this.SpawnSource.up * 997), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue009)
                    {
                        case 2:
                            this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                            this.TheNPC009 = UnityEngine.Object.Instantiate(Spawnionaise009, hit.point + (this.SpawnSource.up * Random.Range(2, 5)), this.SpawnPos.rotation);
                            this.SpawnPos.transform.position = this.TheNPC009.transform.position;
                            this.NPC009SpawnChanceIn = this.NPC009StaticSpawnChanceIn;
                            break;
                    }
                }
            }
            //[Cethin]===========================================================================================================================
            //[Turgkin]===========================================================================================================================
            if ((StuffSpawner.TheNPC0091N < 3) && (this.NPC0091SpawnChanceIn > 1))
            {
                GameObject Spawnionaise0091 = ((GameObject) Resources.Load("NPCs/TurgkinDut", typeof(GameObject))) as GameObject;
                int randomValue0091 = Random.Range(0, this.NPC0091SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3266 = this.savedRotY;
                        Vector3 _3267 = this.transform.eulerAngles;
                        _3267.y = _3266;
                        this.transform.eulerAngles = _3267;
                    }

                    {
                        float _3268 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3269 = this.transform.eulerAngles;
                        _3269.y = _3268;
                        this.transform.eulerAngles = _3269;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast((this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(256, 512))) + (-this.SpawnSource.up * 997), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue0091)
                    {
                        case 2:
                            this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                            this.TheNPC0091 = UnityEngine.Object.Instantiate(Spawnionaise0091, hit.point + (this.SpawnSource.up * Random.Range(0.5f, 3)), this.SpawnPos.rotation);
                            this.SpawnPos.transform.position = this.TheNPC0091.transform.position;
                            this.NPC0091SpawnChanceIn = this.NPC0091StaticSpawnChanceIn;
                            break;
                    }
                }
            }
            //[Ootped]===========================================================================================================================
            if (WorldInformation.IsOotkinSick)
            {
                GameObject SpawnionaiseOotped = ((GameObject) Resources.Load("NPCs/Ootped", typeof(GameObject))) as GameObject;
                int randomValueOotped = Random.Range(0, 8);
                if (this.VelClamp > 1)
                {

                    {
                        float _3270 = this.savedRotY;
                        Vector3 _3271 = this.transform.eulerAngles;
                        _3271.y = _3270;
                        this.transform.eulerAngles = _3271;
                    }

                    {
                        float _3272 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3273 = this.transform.eulerAngles;
                        _3273.y = _3272;
                        this.transform.eulerAngles = _3273;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(25, 50)), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValueOotped)
                    {
                        case 2:
                            this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                            GameObject TheOotped = UnityEngine.Object.Instantiate(SpawnionaiseOotped, hit.point + (this.SpawnSource.up * 0.3f), this.SpawnPos.rotation);
                            this.SpawnPos.transform.position = TheOotped.transform.position;
                            break;
                    }
                }
            }
            //[Oot1]===========================================================================================================================
            if ((this.TheNPC0800 == null) && (this.NPC0800SpawnChanceIn > 1))
            {
                GameObject Spawnionaise0800 = ((GameObject) Resources.Load("NPCs/Oot1", typeof(GameObject))) as GameObject;
                int randomValue0800 = Random.Range(0, this.NPC0800SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3274 = this.savedRotY;
                        Vector3 _3275 = this.transform.eulerAngles;
                        _3275.y = _3274;
                        this.transform.eulerAngles = _3275;
                    }

                    {
                        float _3276 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3277 = this.transform.eulerAngles;
                        _3277.y = _3276;
                        this.transform.eulerAngles = _3277;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast((this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(4, 64))) + (-this.SpawnSource.up * 997), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue0800)
                    {
                        case 2:
                            this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                            this.TheNPC0800 = UnityEngine.Object.Instantiate(Spawnionaise0800, hit.point + (this.SpawnSource.up * Random.Range(0.5f, 3)), this.SpawnPos.rotation);
                            this.SpawnPos.transform.position = this.TheNPC0800.transform.position;
                            this.NPC0800SpawnChanceIn = this.NPC0800StaticSpawnChanceIn;
                            break;
                    }
                }
            }
            //[Oot2]===========================================================================================================================
            if ((this.TheNPC0801 == null) && (this.NPC0801SpawnChanceIn > 1))
            {
                GameObject Spawnionaise0801 = ((GameObject) Resources.Load("NPCs/Oot2", typeof(GameObject))) as GameObject;
                int randomValue0801 = Random.Range(0, this.NPC0801SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3278 = this.savedRotY;
                        Vector3 _3279 = this.transform.eulerAngles;
                        _3279.y = _3278;
                        this.transform.eulerAngles = _3279;
                    }

                    {
                        float _3280 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3281 = this.transform.eulerAngles;
                        _3281.y = _3280;
                        this.transform.eulerAngles = _3281;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast((this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(4, 64))) + (-this.SpawnSource.up * 997), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue0801)
                    {
                        case 2:
                            this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                            this.TheNPC0801 = UnityEngine.Object.Instantiate(Spawnionaise0801, hit.point + (this.SpawnSource.up * Random.Range(0.5f, 3)), this.SpawnPos.rotation);
                            this.SpawnPos.transform.position = this.TheNPC0801.transform.position;
                            this.NPC0801SpawnChanceIn = this.NPC0801StaticSpawnChanceIn;
                            break;
                    }
                }
            }
            //[Oot3]===========================================================================================================================
            if ((this.TheNPC0802 == null) && (this.NPC0802SpawnChanceIn > 1))
            {
                GameObject Spawnionaise0802 = ((GameObject) Resources.Load("NPCs/Oot3", typeof(GameObject))) as GameObject;
                int randomValue0802 = Random.Range(0, this.NPC0802SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3282 = this.savedRotY;
                        Vector3 _3283 = this.transform.eulerAngles;
                        _3283.y = _3282;
                        this.transform.eulerAngles = _3283;
                    }

                    {
                        float _3284 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3285 = this.transform.eulerAngles;
                        _3285.y = _3284;
                        this.transform.eulerAngles = _3285;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast((this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(4, 64))) + (-this.SpawnSource.up * 997), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue0802)
                    {
                        case 2:
                            this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                            this.TheNPC0802 = UnityEngine.Object.Instantiate(Spawnionaise0802, hit.point + (this.SpawnSource.up * Random.Range(0.5f, 3)), this.SpawnPos.rotation);
                            this.SpawnPos.transform.position = this.TheNPC0802.transform.position;
                            this.NPC0802SpawnChanceIn = this.NPC0802StaticSpawnChanceIn;
                            break;
                    }
                }
            }
            //[Oot4]===========================================================================================================================
            if ((this.TheNPC0803 == null) && (this.NPC0803SpawnChanceIn > 1))
            {
                GameObject Spawnionaise0803 = ((GameObject) Resources.Load("NPCs/Oot4", typeof(GameObject))) as GameObject;
                int randomValue0803 = Random.Range(0, this.NPC0803SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3286 = this.savedRotY;
                        Vector3 _3287 = this.transform.eulerAngles;
                        _3287.y = _3286;
                        this.transform.eulerAngles = _3287;
                    }

                    {
                        float _3288 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3289 = this.transform.eulerAngles;
                        _3289.y = _3288;
                        this.transform.eulerAngles = _3289;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast((this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(4, 64))) + (-this.SpawnSource.up * 997), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue0803)
                    {
                        case 2:
                            this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                            this.TheNPC0803 = UnityEngine.Object.Instantiate(Spawnionaise0803, hit.point + (this.SpawnSource.up * Random.Range(0.5f, 3)), this.SpawnPos.rotation);
                            this.SpawnPos.transform.position = this.TheNPC0803.transform.position;
                            this.NPC0803SpawnChanceIn = this.NPC0803StaticSpawnChanceIn;
                            break;
                    }
                }
            }
            //[OotDut1]===========================================================================================================================
            if (this.NPC0804SpawnChanceIn > 1)
            {
                GameObject Spawnionaise0804 = ((GameObject) Resources.Load("NPCs/OotDut1", typeof(GameObject))) as GameObject;
                int randomValue0804 = Random.Range(0, this.NPC0804SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3290 = this.savedRotY;
                        Vector3 _3291 = this.transform.eulerAngles;
                        _3291.y = _3290;
                        this.transform.eulerAngles = _3291;
                    }

                    {
                        float _3292 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3293 = this.transform.eulerAngles;
                        _3293.y = _3292;
                        this.transform.eulerAngles = _3293;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast((this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(4, 64))) + (-this.SpawnSource.up * 997), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue0804)
                    {
                        case 2:
                            // VicinityChecker ==================================================================
                            GameObject[] gos = null;
                            gos = GameObject.FindGameObjectsWithTag("Archoneutralizer");
                            float distance = Mathf.Infinity;
                            Vector3 position = this.transform.position;
                            closest = new Vector3(0, 0, 1000000);
                            foreach (GameObject go in gos)
                            {
                                Vector3 diff = go.transform.position - position;
                                float curDistance = diff.sqrMagnitude;
                                if (curDistance < distance)
                                {
                                    closest = go.transform.position;
                                    distance = curDistance;
                                }
                            }
                            //Debug.Log(closest);
                            // ==================================================================================
                            if (Vector3.Distance(hit.point, closest) > 64)
                            {
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC0804 = UnityEngine.Object.Instantiate(Spawnionaise0804, hit.point + (this.SpawnSource.up * Random.Range(0.5f, 3)), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC0804.transform.position;
                                this.NPC0804SpawnChanceIn = this.NPC0804StaticSpawnChanceIn;
                            }
                            break;
                    }
                }
            }
            //[OotDut1Group]===========================================================================================================================
            if ((StuffSpawner.TheNPC0805N < 24) && (this.NPC0805SpawnChanceIn > 1))
            {
                GameObject Spawnionaise0805 = ((GameObject) Resources.Load("NPCs/OotDut1Group1", typeof(GameObject))) as GameObject;
                int randomValue0805S = Random.Range(0, 3);
                switch (randomValue0805S)
                {
                    case 0:
                        Spawnionaise0805 = ((GameObject) Resources.Load("NPCs/OotDut1Group1", typeof(GameObject))) as GameObject;
                        break;
                    case 1:
                        Spawnionaise0805 = ((GameObject) Resources.Load("NPCs/OotDut1Group2", typeof(GameObject))) as GameObject;
                        break;
                    case 2:
                        Spawnionaise0805 = ((GameObject) Resources.Load("NPCs/OotDut1Group3", typeof(GameObject))) as GameObject;
                        break;
                }
                int randomValue0805 = Random.Range(0, this.NPC0805SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3294 = this.savedRotY;
                        Vector3 _3295 = this.transform.eulerAngles;
                        _3295.y = _3294;
                        this.transform.eulerAngles = _3295;
                    }

                    {
                        float _3296 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3297 = this.transform.eulerAngles;
                        _3297.y = _3296;
                        this.transform.eulerAngles = _3297;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(256, 500)), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue0805)
                    {
                        case 2:
                            this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                            this.TheNPC0805 = UnityEngine.Object.Instantiate(Spawnionaise0805, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                            this.SpawnPos.transform.position = this.TheNPC0805.transform.position;
                            break;
                    }
                }
            }
            //[Shadowfinger Ootkin]===========================================================================================================================
            if ((this.TheNPC080 == null) && (this.NPC080SpawnChanceIn > 1))
            {
                int randomValue080 = Random.Range(0, this.NPC080SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3298 = this.savedRotY;
                        Vector3 _3299 = this.transform.eulerAngles;
                        _3299.y = _3298;
                        this.transform.eulerAngles = _3299;
                    }

                    {
                        float _3300 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3301 = this.transform.eulerAngles;
                        _3301.y = _3300;
                        this.transform.eulerAngles = _3301;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(25, 100)), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue080)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC080 = UnityEngine.Object.Instantiate(this.NPC080, hit.point + (this.SpawnSource.up * 3), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC080.transform.position;
                                this.NPC080SpawnChanceIn = this.NPC080StaticSpawnChanceIn;
                                break;
                        }
                    }
                }
                else
                {
                    this.NPC080SpawnChanceIn = 3;
                }
            }
            //[Athnian Ootkin 1]===========================================================================================================================
            if ((this.TheNPC081 == null) && (this.NPC081SpawnChanceIn > 1))
            {
                int randomValue081 = Random.Range(0, this.NPC081SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3302 = this.savedRotY;
                        Vector3 _3303 = this.transform.eulerAngles;
                        _3303.y = _3302;
                        this.transform.eulerAngles = _3303;
                    }

                    {
                        float _3304 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3305 = this.transform.eulerAngles;
                        _3305.y = _3304;
                        this.transform.eulerAngles = _3305;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(25, 200)), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue081)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC081 = UnityEngine.Object.Instantiate(this.NPC081, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC081.transform.position;
                                this.NPC081SpawnChanceIn = this.NPC081StaticSpawnChanceIn;
                                break;
                        }
                    }
                }
                else
                {
                    this.NPC081SpawnChanceIn = 3;
                }
            }
            //[Athnian Ootkin 2]===========================================================================================================================
            if ((this.TheNPC082 == null) && (this.NPC082SpawnChanceIn > 1))
            {
                int randomValue082 = Random.Range(0, this.NPC082SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3306 = this.savedRotY;
                        Vector3 _3307 = this.transform.eulerAngles;
                        _3307.y = _3306;
                        this.transform.eulerAngles = _3307;
                    }

                    {
                        float _3308 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3309 = this.transform.eulerAngles;
                        _3309.y = _3308;
                        this.transform.eulerAngles = _3309;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(25, 200)), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue082)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC082 = UnityEngine.Object.Instantiate(this.NPC082, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC082.transform.position;
                                this.NPC082SpawnChanceIn = this.NPC082StaticSpawnChanceIn;
                                break;
                        }
                    }
                }
                else
                {
                    this.NPC082SpawnChanceIn = 3;
                }
            }
            //[Afazis Terracruiser EC-1]===========================================================================================================================
            if ((this.TheNPC00 == null) && (this.NPC00SpawnChanceIn > 1))
            {
                int randomValue00 = Random.Range(0, this.NPC00SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3310 = this.savedRotY;
                        Vector3 _3311 = this.transform.eulerAngles;
                        _3311.y = _3310;
                        this.transform.eulerAngles = _3311;
                    }

                    {
                        float _3312 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3313 = this.transform.eulerAngles;
                        _3313.y = _3312;
                        this.transform.eulerAngles = _3313;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue00)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC00 = UnityEngine.Object.Instantiate(this.NPC00, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC00.transform.position;
                                break;
                        }
                    }
                }
            }
            //[TAK B-l4]===========================================================================================================================
            if ((this.TheNPC01 == null) && (this.NPC01SpawnChanceIn > 1))
            {
                int randomValue01 = Random.Range(0, this.NPC01SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3314 = this.savedRotY;
                        Vector3 _3315 = this.transform.eulerAngles;
                        _3315.y = _3314;
                        this.transform.eulerAngles = _3315;
                    }

                    {
                        float _3316 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3317 = this.transform.eulerAngles;
                        _3317.y = _3316;
                        this.transform.eulerAngles = _3317;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue01)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC01 = UnityEngine.Object.Instantiate(this.NPC01, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC01.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Ezyfus Bejsirf Apta]===========================================================================================================================
            if ((this.TheNPC02 == null) && (this.NPC02SpawnChanceIn > 1))
            {
                int randomValue02 = Random.Range(0, this.NPC02SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3318 = this.savedRotY;
                        Vector3 _3319 = this.transform.eulerAngles;
                        _3319.y = _3318;
                        this.transform.eulerAngles = _3319;
                    }

                    {
                        float _3320 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3321 = this.transform.eulerAngles;
                        _3321.y = _3320;
                        this.transform.eulerAngles = _3321;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue02)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC02 = UnityEngine.Object.Instantiate(this.NPC02, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC02.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Carbondyle Fecuda C.211]===========================================================================================================================
            if ((this.TheNPC03 == null) && (this.NPC03SpawnChanceIn > 1))
            {
                int randomValue03 = Random.Range(0, this.NPC03SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3322 = this.savedRotY;
                        Vector3 _3323 = this.transform.eulerAngles;
                        _3323.y = _3322;
                        this.transform.eulerAngles = _3323;
                    }

                    {
                        float _3324 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3325 = this.transform.eulerAngles;
                        _3325.y = _3324;
                        this.transform.eulerAngles = _3325;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue03)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC03 = UnityEngine.Object.Instantiate(this.NPC03, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC03.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Slavoico BImG-500]===========================================================================================================================
            if ((this.TheNPC04 == null) && (this.NPC04SpawnChanceIn > 1))
            {
                int randomValue04 = Random.Range(0, this.NPC04SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3326 = this.savedRotY;
                        Vector3 _3327 = this.transform.eulerAngles;
                        _3327.y = _3326;
                        this.transform.eulerAngles = _3327;
                    }

                    {
                        float _3328 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3329 = this.transform.eulerAngles;
                        _3329.y = _3328;
                        this.transform.eulerAngles = _3329;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 2500), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue04)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC04 = UnityEngine.Object.Instantiate(this.NPC04, hit.point + (this.SpawnSource.up * 4), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC04.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Carbondyle Fecuda C.115]===========================================================================================================================
            if ((this.TheNPC05 == null) && (this.NPC05SpawnChanceIn > 1))
            {
                int randomValue05 = Random.Range(0, this.NPC05SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3330 = this.savedRotY;
                        Vector3 _3331 = this.transform.eulerAngles;
                        _3331.y = _3330;
                        this.transform.eulerAngles = _3331;
                    }

                    {
                        float _3332 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3333 = this.transform.eulerAngles;
                        _3333.y = _3332;
                        this.transform.eulerAngles = _3333;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue05)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC05 = UnityEngine.Object.Instantiate(this.NPC05, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC05.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Someone]===========================================================================================================================
            if ((this.TheNPC10 == null) && (this.NPC10SpawnChanceIn > 1))
            {
                int randomValue10 = Random.Range(0, this.NPC10SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3334 = this.savedRotY;
                        Vector3 _3335 = this.transform.eulerAngles;
                        _3335.y = _3334;
                        this.transform.eulerAngles = _3335;
                    }

                    {
                        float _3336 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3337 = this.transform.eulerAngles;
                        _3337.y = _3336;
                        this.transform.eulerAngles = _3337;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue10)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC10 = UnityEngine.Object.Instantiate(this.NPC10, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC10.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Enforcer]===========================================================================================================================
            if ((this.TheNPC20 == null) && (this.NPC20SpawnChanceIn > 1))
            {
                int randomValue20 = Random.Range(0, this.NPC20SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3338 = this.savedRotY;
                        Vector3 _3339 = this.transform.eulerAngles;
                        _3339.y = _3338;
                        this.transform.eulerAngles = _3339;
                    }

                    {
                        float _3340 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3341 = this.transform.eulerAngles;
                        _3341.y = _3340;
                        this.transform.eulerAngles = _3341;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue20)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC20 = UnityEngine.Object.Instantiate(this.NPC20, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC20.transform.position;
                                break;
                        }
                    }
                }
                else
                {
                    if (Physics.Raycast((this.SpawnSource.position + (-this.SpawnSource.up * 1100)) + (this.SpawnSource.forward * 1800), this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                    {
                        switch (randomValue20)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC20 = UnityEngine.Object.Instantiate(this.NPC20, hit.point + (-this.SpawnSource.up * 4), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC20.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Sentinel]===========================================================================================================================
            if ((this.TheNPC21 == null) && (this.NPC21SpawnChanceIn > 1))
            {
                int randomValue21 = Random.Range(0, this.NPC21SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3342 = this.savedRotY;
                        Vector3 _3343 = this.transform.eulerAngles;
                        _3343.y = _3342;
                        this.transform.eulerAngles = _3343;
                    }

                    {
                        float _3344 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3345 = this.transform.eulerAngles;
                        _3345.y = _3344;
                        this.transform.eulerAngles = _3345;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue21)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC21 = UnityEngine.Object.Instantiate(this.NPC21, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC21.transform.position;
                                break;
                        }
                    }
                }
                else
                {
                    if (Physics.Raycast((this.SpawnSource.position + (-this.SpawnSource.up * 1100)) + (this.SpawnSource.forward * 1800), this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                    {
                        switch (randomValue21)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC21 = UnityEngine.Object.Instantiate(this.NPC21, hit.point + (-this.SpawnSource.up * 4), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC21.transform.position;
                                break;
                        }
                    }
                }
            }
            //if(AreaNum == 14)
            //transform.eulerAngles = Vector3(0, Random.Range (-270, -90), 0);
            //else
            //if(VelClamp > 1)
            //transform.localEulerAngles.y += Random.Range (-60, 60);
            //else
            //transform.eulerAngles = Vector3(0, Random.Range (-180, 180), 0);
            //
            //if(Physics.Raycast(SpawnSource.position + SpawnSource.forward * 100, -transform.up, hit, HeightLimit, targetLayers)){
            //var Load = Resources.Load("Prefabs/ThreatCursor", GameObject) as GameObject;
            //
            //var TGO = Instantiate(Load, hit.point + SpawnSource.up * 2, SpawnPos.rotation);
            //}
            //[Agent]===========================================================================================================================
            if ((this.TheNPC22 == null) && (this.NPC22SpawnChanceIn > 1))
            {
                int randomValue22 = Random.Range(0, this.NPC22SpawnChanceIn);
                if (this.AreaNum == 14)
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-270, -90), 0);
                }
                else
                {
                    if (this.VelClamp > 1)
                    {

                        {
                            float _3346 = this.savedRotY;
                            Vector3 _3347 = this.transform.eulerAngles;
                            _3347.y = _3346;
                            this.transform.eulerAngles = _3347;
                        }

                        {
                            float _3348 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                            Vector3 _3349 = this.transform.eulerAngles;
                            _3349.y = _3348;
                            this.transform.eulerAngles = _3349;
                        }
                    }
                    else
                    {
                        this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                    }
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 6000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue22)
                    {
                        case 2:
                            this.BigSpawnDist = 6000;
                            this.StartCoroutine(this.BigSpawn22());
                            return;
                            break;
                    }
                }
            }
            //[Executor]===========================================================================================================================
            if ((this.TheNPC23 == null) && (this.NPC23SpawnChanceIn > 1))
            {
                int randomValue23 = Random.Range(0, this.NPC23SpawnChanceIn);
                if (this.AreaNum == 14)
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-270, -90), 0);
                }
                else
                {
                    if (this.VelClamp > 1)
                    {

                        {
                            float _3350 = this.savedRotY;
                            Vector3 _3351 = this.transform.eulerAngles;
                            _3351.y = _3350;
                            this.transform.eulerAngles = _3351;
                        }

                        {
                            float _3352 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                            Vector3 _3353 = this.transform.eulerAngles;
                            _3353.y = _3352;
                            this.transform.eulerAngles = _3353;
                        }
                    }
                    else
                    {
                        this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                    }
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 8000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue23)
                    {
                        case 2:
                            this.BigSpawnDist = 8000;
                            this.StartCoroutine(this.BigSpawn23());
                            return;
                            break;
                    }
                }
            }
            //[SuperExecutor]===========================================================================================================================
            if ((this.TheNPC24 == null) && (this.NPC24SpawnChanceIn > 1))
            {
                int randomValue24 = Random.Range(0, this.NPC24SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3354 = this.savedRotY;
                        Vector3 _3355 = this.transform.eulerAngles;
                        _3355.y = _3354;
                        this.transform.eulerAngles = _3355;
                    }

                    {
                        float _3356 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3357 = this.transform.eulerAngles;
                        _3357.y = _3356;
                        this.transform.eulerAngles = _3357;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 12000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue24)
                    {
                        case 2:
                            this.BigSpawnDist = 12000;
                            this.StartCoroutine(this.BigSpawn24());
                            return;
                            break;
                    }
                }
            }
            //[Helirotor]===========================================================================================================================
            if ((this.TheNPC25 == null) && (this.NPC25SpawnChanceIn > 1))
            {
                GameObject Spawnionaise25 = ((GameObject) Resources.Load("NPCs/AgrianHelirotor", typeof(GameObject))) as GameObject;
                int randomValue25 = Random.Range(0, this.NPC25SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3358 = this.savedRotY;
                        Vector3 _3359 = this.transform.eulerAngles;
                        _3359.y = _3358;
                        this.transform.eulerAngles = _3359;
                    }

                    {
                        float _3360 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3361 = this.transform.eulerAngles;
                        _3361.y = _3360;
                        this.transform.eulerAngles = _3361;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 3500), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue25)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC25 = UnityEngine.Object.Instantiate(Spawnionaise25, hit.point + (this.SpawnSource.up * 8), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC25.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Annihilator]===========================================================================================================================
            if ((this.TheNPC26 == null) && (this.NPC26SpawnChanceIn > 1))
            {
                int randomValue26 = Random.Range(0, this.NPC26SpawnChanceIn);
                if (this.AreaNum == 14)
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-270, -90), 0);
                }
                else
                {
                    if (this.VelClamp > 1)
                    {

                        {
                            float _3362 = this.savedRotY;
                            Vector3 _3363 = this.transform.eulerAngles;
                            _3363.y = _3362;
                            this.transform.eulerAngles = _3363;
                        }

                        {
                            float _3364 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                            Vector3 _3365 = this.transform.eulerAngles;
                            _3365.y = _3364;
                            this.transform.eulerAngles = _3365;
                        }
                    }
                    else
                    {
                        this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                    }
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 8000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue26)
                    {
                        case 2:
                            this.BigSpawnDist = 8000;
                            this.StartCoroutine(this.BigSpawn26());
                            return;
                            break;
                    }
                }
            }
            //[Distributor]===========================================================================================================================
            if ((this.TheNPC27 == null) && (this.NPC27SpawnChanceIn > 1))
            {
                int randomValue27 = Random.Range(0, this.NPC27SpawnChanceIn);
                if (this.AreaNum == 14)
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-270, -90), 0);
                }
                else
                {
                    if (this.VelClamp > 1)
                    {

                        {
                            float _3366 = this.savedRotY;
                            Vector3 _3367 = this.transform.eulerAngles;
                            _3367.y = _3366;
                            this.transform.eulerAngles = _3367;
                        }

                        {
                            float _3368 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                            Vector3 _3369 = this.transform.eulerAngles;
                            _3369.y = _3368;
                            this.transform.eulerAngles = _3369;
                        }
                    }
                    else
                    {
                        this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                    }
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 6000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue27)
                    {
                        case 2:
                            this.BigSpawnDist = 6000;
                            this.StartCoroutine(this.BigSpawn27());
                            return;
                            break;
                    }
                }
            }
            //[LevNav Eos]===========================================================================================================================
            if ((this.TheNPC300 == null) && (this.NPC300SpawnChanceIn > 1))
            {
                GameObject Spawnionaise300 = ((GameObject) Resources.Load("NPCs/LevNavClouter0", typeof(GameObject))) as GameObject;
                int randomValue300 = Random.Range(0, this.NPC300SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3370 = this.savedRotY;
                        Vector3 _3371 = this.transform.eulerAngles;
                        _3371.y = _3370;
                        this.transform.eulerAngles = _3371;
                    }

                    {
                        float _3372 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3373 = this.transform.eulerAngles;
                        _3373.y = _3372;
                        this.transform.eulerAngles = _3373;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 3000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue300)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC300 = UnityEngine.Object.Instantiate(Spawnionaise300, hit.point + (this.SpawnSource.up * 4), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC300.transform.position;
                                break;
                        }
                    }
                }
            }
            //[LevNav Ithis]===========================================================================================================================
            if ((this.TheNPC301 == null) && (this.NPC301SpawnChanceIn > 1))
            {
                GameObject Spawnionaise301 = ((GameObject) Resources.Load("NPCs/LevNav_Ithis", typeof(GameObject))) as GameObject;
                int randomValue301 = Random.Range(0, this.NPC301SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3374 = this.savedRotY;
                        Vector3 _3375 = this.transform.eulerAngles;
                        _3375.y = _3374;
                        this.transform.eulerAngles = _3375;
                    }

                    {
                        float _3376 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3377 = this.transform.eulerAngles;
                        _3377.y = _3376;
                        this.transform.eulerAngles = _3377;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 3000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue301)
                    {
                        case 2:
                            this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                            this.TheNPC301 = UnityEngine.Object.Instantiate(Spawnionaise301, hit.point + (this.SpawnSource.up * 256), this.SpawnPos.rotation);
                            this.SpawnPos.transform.position = this.TheNPC301.transform.position;
                            break;
                    }
                }
            }
            //[LevNav MAL]===========================================================================================================================
            if ((this.TheNPC302 == null) && (this.NPC302SpawnChanceIn > 1))
            {
                GameObject Spawnionaise302 = ((GameObject) Resources.Load("NPCs/LevNavLoucurat0", typeof(GameObject))) as GameObject;
                int randomValue302 = Random.Range(0, this.NPC302SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3378 = this.savedRotY;
                        Vector3 _3379 = this.transform.eulerAngles;
                        _3379.y = _3378;
                        this.transform.eulerAngles = _3379;
                    }

                    {
                        float _3380 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3381 = this.transform.eulerAngles;
                        _3381.y = _3380;
                        this.transform.eulerAngles = _3381;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 3000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue302)
                    {
                        case 2:
                            this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                            this.TheNPC302 = UnityEngine.Object.Instantiate(Spawnionaise302, hit.point + (this.SpawnSource.up * 8), this.SpawnPos.rotation);
                            this.SpawnPos.transform.position = this.TheNPC302.transform.position;
                            break;
                    }
                }
            }
            //[LevNav Darion]===========================================================================================================================
            if ((this.TheNPC303 == null) && (this.NPC303SpawnChanceIn > 1))
            {
                int randomValue303 = Random.Range(0, this.NPC303SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3382 = this.savedRotY;
                        Vector3 _3383 = this.transform.eulerAngles;
                        _3383.y = _3382;
                        this.transform.eulerAngles = _3383;
                    }

                    {
                        float _3384 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3385 = this.transform.eulerAngles;
                        _3385.y = _3384;
                        this.transform.eulerAngles = _3385;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 8000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue303)
                    {
                        case 2:
                            this.BigSpawnDist = 8000;
                            this.StartCoroutine(this.BigSpawn303());
                            return;
                            break;
                    }
                }
            }
            //[Bothunter]===========================================================================================================================
            if ((this.TheNPC310 == null) && (this.NPC310SpawnChanceIn > 1))
            {
                GameObject Spawnionaise310 = ((GameObject) Resources.Load("NPCs/TLF_Bothunter", typeof(GameObject))) as GameObject;
                int randomValue310 = Random.Range(0, this.NPC310SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3386 = this.savedRotY;
                        Vector3 _3387 = this.transform.eulerAngles;
                        _3387.y = _3386;
                        this.transform.eulerAngles = _3387;
                    }

                    {
                        float _3388 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3389 = this.transform.eulerAngles;
                        _3389.y = _3388;
                        this.transform.eulerAngles = _3389;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue310)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC310 = UnityEngine.Object.Instantiate(Spawnionaise310, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC310.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Valiant]===========================================================================================================================
            if ((this.TheNPC31 == null) && (this.NPC31SpawnChanceIn > 1))
            {
                int randomValue31 = Random.Range(0, this.NPC31SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3390 = this.savedRotY;
                        Vector3 _3391 = this.transform.eulerAngles;
                        _3391.y = _3390;
                        this.transform.eulerAngles = _3391;
                    }

                    {
                        float _3392 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3393 = this.transform.eulerAngles;
                        _3393.y = _3392;
                        this.transform.eulerAngles = _3393;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 3000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue31)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC31 = UnityEngine.Object.Instantiate(this.NPC31, hit.point + (this.SpawnSource.up * 4), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC31.transform.position;
                                break;
                        }
                    }
                }
            }
            //[FecarB1]===========================================================================================================================
            if ((this.TheNPC32 == null) && (this.NPC32SpawnChanceIn > 1))
            {
                int randomValue32 = Random.Range(0, this.NPC32SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3394 = this.savedRotY;
                        Vector3 _3395 = this.transform.eulerAngles;
                        _3395.y = _3394;
                        this.transform.eulerAngles = _3395;
                    }

                    {
                        float _3396 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3397 = this.transform.eulerAngles;
                        _3397.y = _3396;
                        this.transform.eulerAngles = _3397;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 5000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue32)
                        {
                            case 2:
                                this.BigSpawnDist = 5000;
                                this.StartCoroutine(this.BigSpawn32());
                                return;
                                break;
                        }
                    }
                }
            }
            //[DasNavCruiser]===========================================================================================================================
            if ((this.TheNPC33 == null) && (this.NPC33SpawnChanceIn > 1))
            {
                int randomValue33 = Random.Range(0, this.NPC33SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3398 = this.savedRotY;
                        Vector3 _3399 = this.transform.eulerAngles;
                        _3399.y = _3398;
                        this.transform.eulerAngles = _3399;
                    }

                    {
                        float _3400 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3401 = this.transform.eulerAngles;
                        _3401.y = _3400;
                        this.transform.eulerAngles = _3401;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 6000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue33)
                        {
                            case 2:
                                this.BigSpawnDist = 6000;
                                this.StartCoroutine(this.BigSpawn33());
                                return;
                                break;
                        }
                    }
                }
            }
            //[TRN RD-1]===========================================================================================================================
            if ((this.TheNPC34 == null) && (this.NPC34SpawnChanceIn > 1))
            {
                int randomValue34 = Random.Range(0, this.NPC34SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3402 = this.savedRotY;
                        Vector3 _3403 = this.transform.eulerAngles;
                        _3403.y = _3402;
                        this.transform.eulerAngles = _3403;
                    }

                    {
                        float _3404 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3405 = this.transform.eulerAngles;
                        _3405.y = _3404;
                        this.transform.eulerAngles = _3405;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 3500), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue34)
                        {
                            case 2:
                                this.BigSpawnDist = 3500;
                                this.StartCoroutine(this.BigSpawn34());
                                return;
                                break;
                        }
                    }
                }
            }
            //[TLF Adamant]===========================================================================================================================
            if ((this.TheNPC35 == null) && (this.NPC35SpawnChanceIn > 1))
            {
                int randomValue35 = Random.Range(0, this.NPC35SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3406 = this.savedRotY;
                        Vector3 _3407 = this.transform.eulerAngles;
                        _3407.y = _3406;
                        this.transform.eulerAngles = _3407;
                    }

                    {
                        float _3408 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3409 = this.transform.eulerAngles;
                        _3409.y = _3408;
                        this.transform.eulerAngles = _3409;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 6000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue35)
                        {
                            case 2:
                                this.BigSpawnDist = 6000;
                                this.StartCoroutine(this.BigSpawn35());
                                return;
                                break;
                        }
                    }
                }
            }
            //[Fughunter]===========================================================================================================================
            if ((this.TheNPC36 == null) && (this.NPC36SpawnChanceIn > 1))
            {
                GameObject Spawnionaise36 = ((GameObject) Resources.Load("NPCs/TLF_Fughunter", typeof(GameObject))) as GameObject;
                int randomValue36 = Random.Range(0, this.NPC36SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3410 = this.savedRotY;
                        Vector3 _3411 = this.transform.eulerAngles;
                        _3411.y = _3410;
                        this.transform.eulerAngles = _3411;
                    }

                    {
                        float _3412 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3413 = this.transform.eulerAngles;
                        _3413.y = _3412;
                        this.transform.eulerAngles = _3413;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue36)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC36 = UnityEngine.Object.Instantiate(Spawnionaise36, hit.point + (this.SpawnSource.up * 4), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC36.transform.position;
                                break;
                        }
                    }
                }
            }
            //[TLF LRCM Neutralizer]===========================================================================================================================
            if ((this.TheNPC37 == null) && (this.NPC37SpawnChanceIn > 1))
            {
                if (TerrahyptianNetwork.instance.NukeMarker)
                {
                    GameObject Spawnionaise37 = ((GameObject) Resources.Load("NPCs/TLF_CM1", typeof(GameObject))) as GameObject;
                    int randomValue37 = Random.Range(0, this.NPC37SpawnChanceIn);
                    if (this.VelClamp > 1)
                    {

                        {
                            float _3414 = this.savedRotY;
                            Vector3 _3415 = this.transform.eulerAngles;
                            _3415.y = _3414;
                            this.transform.eulerAngles = _3415;
                        }

                        {
                            float _3416 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                            Vector3 _3417 = this.transform.eulerAngles;
                            _3417.y = _3416;
                            this.transform.eulerAngles = _3417;
                        }
                    }
                    else
                    {
                        this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                    }
                    if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 6000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                    {
                        if (!hit.collider.name.Contains("Wa"))
                        {
                            switch (randomValue37)
                            {
                                case 2:
                                    this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                    this.TheNPC37 = UnityEngine.Object.Instantiate(Spawnionaise37, hit.point + (this.SpawnSource.up * 64), this.SpawnPos.rotation);
                                    this.SpawnPos.transform.position = this.TheNPC37.transform.position;
                                    break;
                            }
                        }
                    }
                }
            }
            //[TRN Zerana]===========================================================================================================================
            if (((this.TheNPC39 == null) && (this.NPC39SpawnChanceIn > 1)) && !this.NPC39Once)
            {
                int randomValue39 = Random.Range(0, this.NPC39SpawnChanceIn);
                int randomPos39 = Random.Range(1, 8);
                switch (randomValue39)
                {
                    case 2:
                        GameObject Spawnionaise39 = ((GameObject) Resources.Load("NPCs/TRNZerana", typeof(GameObject))) as GameObject;
                        switch (randomPos39)
                        {
                            case 1:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                                this.TheNPC39 = UnityEngine.Object.Instantiate(Spawnionaise39, this.HugeSpawnPos1.position, this.SpawnPos.rotation);
                                break;
                        }
                        switch (randomPos39)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                                this.TheNPC39 = UnityEngine.Object.Instantiate(Spawnionaise39, this.HugeSpawnPos2.position, this.SpawnPos.rotation);
                                break;
                        }
                        switch (randomPos39)
                        {
                            case 3:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                                this.TheNPC39 = UnityEngine.Object.Instantiate(Spawnionaise39, this.HugeSpawnPos3.position, this.SpawnPos.rotation);
                                break;
                        }
                        switch (randomPos39)
                        {
                            case 4:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                                this.TheNPC39 = UnityEngine.Object.Instantiate(Spawnionaise39, this.HugeSpawnPos4.position, this.SpawnPos.rotation);
                                break;
                        }
                        switch (randomPos39)
                        {
                            case 5:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                                this.TheNPC39 = UnityEngine.Object.Instantiate(Spawnionaise39, this.HugeSpawnPos5.position, this.SpawnPos.rotation);
                                break;
                        }
                        switch (randomPos39)
                        {
                            case 6:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                                this.TheNPC39 = UnityEngine.Object.Instantiate(Spawnionaise39, this.HugeSpawnPos6.position, this.SpawnPos.rotation);
                                break;
                        }
                        switch (randomPos39)
                        {
                            case 7:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                                this.TheNPC39 = UnityEngine.Object.Instantiate(Spawnionaise39, this.HugeSpawnPos7.position, this.SpawnPos.rotation);
                                break;
                        }
                        switch (randomPos39)
                        {
                            case 8:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                                this.TheNPC39 = UnityEngine.Object.Instantiate(Spawnionaise39, this.HugeSpawnPos8.position, this.SpawnPos.rotation);
                                break;
                        }
                    break;
                }
                this.NPC39Once = true;
            }
            //[Abettor]===========================================================================================================================
            if (this.NPC40SpawnChanceIn > 1)
            {
                int randomValue40 = Random.Range(0, this.NPC40SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3418 = this.savedRotY;
                        Vector3 _3419 = this.transform.eulerAngles;
                        _3419.y = _3418;
                        this.transform.eulerAngles = _3419;
                    }

                    {
                        float _3420 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3421 = this.transform.eulerAngles;
                        _3421.y = _3420;
                        this.transform.eulerAngles = _3421;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 500), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue40)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC40 = UnityEngine.Object.Instantiate(this.NPC40, hit.point + (this.SpawnSource.up * 2), this.AltRot.rotation);
                                this.SpawnPos.transform.position = this.TheNPC40.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Gunner]===========================================================================================================================
            if (this.NPC41SpawnChanceIn > 1)
            {
                int randomValue41 = Random.Range(0, this.NPC41SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3422 = this.savedRotY;
                        Vector3 _3423 = this.transform.eulerAngles;
                        _3423.y = _3422;
                        this.transform.eulerAngles = _3423;
                    }

                    {
                        float _3424 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3425 = this.transform.eulerAngles;
                        _3425.y = _3424;
                        this.transform.eulerAngles = _3425;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue41)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC41 = UnityEngine.Object.Instantiate(this.NPC41, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC41.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Militant]===========================================================================================================================
            if (this.NPC42SpawnChanceIn > 1)
            {
                int randomValue42 = Random.Range(0, this.NPC42SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3426 = this.savedRotY;
                        Vector3 _3427 = this.transform.eulerAngles;
                        _3427.y = _3426;
                        this.transform.eulerAngles = _3427;
                    }

                    {
                        float _3428 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3429 = this.transform.eulerAngles;
                        _3429.y = _3428;
                        this.transform.eulerAngles = _3429;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue42)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC42 = UnityEngine.Object.Instantiate(this.NPC42, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC42.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Marauder]===========================================================================================================================
            if ((this.TheNPC43 == null) && (this.NPC43SpawnChanceIn > 1))
            {
                int randomValue43 = Random.Range(0, this.NPC43SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3430 = this.savedRotY;
                        Vector3 _3431 = this.transform.eulerAngles;
                        _3431.y = _3430;
                        this.transform.eulerAngles = _3431;
                    }

                    {
                        float _3432 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3433 = this.transform.eulerAngles;
                        _3433.y = _3432;
                        this.transform.eulerAngles = _3433;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 4000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue43)
                        {
                            case 2:
                                this.BigSpawnDist = 4000;
                                this.StartCoroutine(this.BigSpawn43());
                                return;
                                break;
                        }
                    }
                }
            }
            //[Mercenary]===========================================================================================================================
            if ((this.TheNPC44 == null) && (this.NPC44SpawnChanceIn > 1))
            {
                int randomValue44 = Random.Range(0, this.NPC44SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3434 = this.savedRotY;
                        Vector3 _3435 = this.transform.eulerAngles;
                        _3435.y = _3434;
                        this.transform.eulerAngles = _3435;
                    }

                    {
                        float _3436 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3437 = this.transform.eulerAngles;
                        _3437.y = _3436;
                        this.transform.eulerAngles = _3437;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 4000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue44)
                        {
                            case 2:
                                this.BigSpawnDist = 4000;
                                this.StartCoroutine(this.BigSpawn44());
                                return;
                                break;
                        }
                    }
                }
            }
            //[Cruiser]===========================================================================================================================
            if ((this.TheNPC45 == null) && (this.NPC45SpawnChanceIn > 1))
            {
                int randomValue45 = Random.Range(0, this.NPC45SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3438 = this.savedRotY;
                        Vector3 _3439 = this.transform.eulerAngles;
                        _3439.y = _3438;
                        this.transform.eulerAngles = _3439;
                    }

                    {
                        float _3440 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3441 = this.transform.eulerAngles;
                        _3441.y = _3440;
                        this.transform.eulerAngles = _3441;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 4000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue45)
                        {
                            case 2:
                                this.BigSpawnDist = 4000;
                                this.StartCoroutine(this.BigSpawn45());
                                return;
                                break;
                        }
                    }
                }
            }
            //[Civilian]===========================================================================================================================
            if ((this.TheNPC50 == null) && (this.NPC50SpawnChanceIn > 1))
            {
                int randomValue50 = Random.Range(0, this.NPC50SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3442 = this.savedRotY;
                        Vector3 _3443 = this.transform.eulerAngles;
                        _3443.y = _3442;
                        this.transform.eulerAngles = _3443;
                    }

                    {
                        float _3444 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3445 = this.transform.eulerAngles;
                        _3445.y = _3444;
                        this.transform.eulerAngles = _3445;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue50)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC50 = UnityEngine.Object.Instantiate(this.NPC50, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC50.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Watchmen]===========================================================================================================================
            if ((this.TheNPC51 == null) && (this.NPC51SpawnChanceIn > 1))
            {
                int randomValue51 = Random.Range(0, this.NPC51SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3446 = this.savedRotY;
                        Vector3 _3447 = this.transform.eulerAngles;
                        _3447.y = _3446;
                        this.transform.eulerAngles = _3447;
                    }

                    {
                        float _3448 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3449 = this.transform.eulerAngles;
                        _3449.y = _3448;
                        this.transform.eulerAngles = _3449;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue51)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC51 = UnityEngine.Object.Instantiate(this.NPC51, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC51.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Mistitor]===========================================================================================================================
            if ((this.TheNPC52 == null) && (this.NPC52SpawnChanceIn > 1))
            {
                int randomValue52 = Random.Range(0, this.NPC52SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3450 = this.savedRotY;
                        Vector3 _3451 = this.transform.eulerAngles;
                        _3451.y = _3450;
                        this.transform.eulerAngles = _3451;
                    }

                    {
                        float _3452 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3453 = this.transform.eulerAngles;
                        _3453.y = _3452;
                        this.transform.eulerAngles = _3453;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 2500), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue52)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC52 = UnityEngine.Object.Instantiate(this.NPC52, hit.point + (this.SpawnSource.up * 3), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC52.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Civilian2]===========================================================================================================================
            if ((this.TheNPC53 == null) && (this.NPC53SpawnChanceIn > 1))
            {
                int randomValue53 = Random.Range(0, this.NPC53SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3454 = this.savedRotY;
                        Vector3 _3455 = this.transform.eulerAngles;
                        _3455.y = _3454;
                        this.transform.eulerAngles = _3455;
                    }

                    {
                        float _3456 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3457 = this.transform.eulerAngles;
                        _3457.y = _3456;
                        this.transform.eulerAngles = _3457;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue53)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC53 = UnityEngine.Object.Instantiate(this.NPC53, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC53.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Snositor]===========================================================================================================================
            if ((this.TheNPC54 == null) && (this.NPC54SpawnChanceIn > 1))
            {
                GameObject Spawnionaise54 = ((GameObject) Resources.Load("NPCs/SlavuicSnositor", typeof(GameObject))) as GameObject;
                int randomValue54 = Random.Range(0, this.NPC54SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3458 = this.savedRotY;
                        Vector3 _3459 = this.transform.eulerAngles;
                        _3459.y = _3458;
                        this.transform.eulerAngles = _3459;
                    }

                    {
                        float _3460 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3461 = this.transform.eulerAngles;
                        _3461.y = _3460;
                        this.transform.eulerAngles = _3461;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 2500), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue54)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC54 = UnityEngine.Object.Instantiate(Spawnionaise54, hit.point + (this.SpawnSource.up * 3), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC54.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Vanguard]===========================================================================================================================
            if ((this.TheNPC55 == null) && (this.NPC55SpawnChanceIn > 1))
            {
                GameObject Spawnionaise55 = ((GameObject) Resources.Load("NPCs/SlavuicVanguard", typeof(GameObject))) as GameObject;
                int randomValue55 = Random.Range(0, this.NPC55SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3462 = this.savedRotY;
                        Vector3 _3463 = this.transform.eulerAngles;
                        _3463.y = _3462;
                        this.transform.eulerAngles = _3463;
                    }

                    {
                        float _3464 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3465 = this.transform.eulerAngles;
                        _3465.y = _3464;
                        this.transform.eulerAngles = _3465;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue55)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC55 = UnityEngine.Object.Instantiate(Spawnionaise55, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC55.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Smertnik]===========================================================================================================================
            if (!this.MovingFast && this.IsInPerson)
            {
                if ((this.TheNPC56 == null) && (this.NPC56SpawnChanceIn > 1))
                {
                    GameObject Spawnionaise56 = ((GameObject) Resources.Load("NPCs/SlavuicSmertnik", typeof(GameObject))) as GameObject;
                    int randomValue56 = Random.Range(0, this.NPC56SpawnChanceIn);
                    if (this.VelClamp > 1)
                    {

                        {
                            float _3466 = this.savedRotY;
                            Vector3 _3467 = this.transform.eulerAngles;
                            _3467.y = _3466;
                            this.transform.eulerAngles = _3467;
                        }

                        {
                            float _3468 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                            Vector3 _3469 = this.transform.eulerAngles;
                            _3469.y = _3468;
                            this.transform.eulerAngles = _3469;
                        }
                    }
                    else
                    {
                        this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                    }
                    //MaxSpawnDist = 330;
                    //MaxSpawnDist = 100;
                    if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(25, 330)), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                    {
                        if (!hit.collider.name.Contains("Wa"))
                        {
                            Vector3 CHP56 = hit.point + (this.SpawnSource.up * 2);
                            if (Vector3.Distance(CHP56, this.PiriView.position) < 300)
                            {
                                if (!Physics.Linecast(CHP56, this.PiriView.position, (int) this.targetLayers))
                                {
                                    this.NPC56SpawnChanceIn = 3;
                                    return;
                                }
                            }
                            switch (randomValue56)
                            {
                                case 2:
                                    this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                    this.TheNPC56 = UnityEngine.Object.Instantiate(Spawnionaise56, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                    this.SpawnPos.transform.position = this.TheNPC56.transform.position;
                                    this.NPC56SpawnChanceIn = this.NPC56StaticSpawnChanceIn;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        this.NPC56SpawnChanceIn = 3;
                    }
                }
            }
            //[Satnik]===========================================================================================================================
            if ((this.TheNPC57 == null) && (this.NPC57SpawnChanceIn > 1))
            {
                GameObject Spawnionaise57 = ((GameObject) Resources.Load("NPCs/SlavuicSatnik", typeof(GameObject))) as GameObject;
                int randomValue57 = Random.Range(0, this.NPC57SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3470 = this.savedRotY;
                        Vector3 _3471 = this.transform.eulerAngles;
                        _3471.y = _3470;
                        this.transform.eulerAngles = _3471;
                    }

                    {
                        float _3472 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3473 = this.transform.eulerAngles;
                        _3473.y = _3472;
                        this.transform.eulerAngles = _3473;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 5000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue57)
                    {
                        case 2:
                            this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                            this.TheNPC57 = UnityEngine.Object.Instantiate(Spawnionaise57, hit.point + (this.SpawnSource.up * 500), this.SpawnPos.rotation);
                            this.SpawnPos.transform.position = this.TheNPC57.transform.position;
                            break;
                    }
                }
            }
            //[Van]===========================================================================================================================
            if ((this.TheNPC60 == null) && (this.NPC60SpawnChanceIn > 1))
            {
                int randomValue60 = Random.Range(0, this.NPC60SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3474 = this.savedRotY;
                        Vector3 _3475 = this.transform.eulerAngles;
                        _3475.y = _3474;
                        this.transform.eulerAngles = _3475;
                    }

                    {
                        float _3476 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3477 = this.transform.eulerAngles;
                        _3477.y = _3476;
                        this.transform.eulerAngles = _3477;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa") && !hit.collider.name.Contains("T5"))
                    {
                        switch (randomValue60)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC60 = UnityEngine.Object.Instantiate(this.NPC60, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC60.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Guncarrier]===========================================================================================================================
            if ((this.TheNPC61 == null) && (this.NPC61SpawnChanceIn > 1))
            {
                int randomValue61 = Random.Range(0, this.NPC61SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3478 = this.savedRotY;
                        Vector3 _3479 = this.transform.eulerAngles;
                        _3479.y = _3478;
                        this.transform.eulerAngles = _3479;
                    }

                    {
                        float _3480 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3481 = this.transform.eulerAngles;
                        _3481.y = _3480;
                        this.transform.eulerAngles = _3481;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa") && !hit.collider.name.Contains("T5"))
                    {
                        switch (randomValue61)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC61 = UnityEngine.Object.Instantiate(this.NPC61, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC61.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Bejsirf]===========================================================================================================================
            if ((this.TheNPC62 == null) && (this.NPC62SpawnChanceIn > 1))
            {
                int randomValue62 = Random.Range(0, this.NPC62SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3482 = this.savedRotY;
                        Vector3 _3483 = this.transform.eulerAngles;
                        _3483.y = _3482;
                        this.transform.eulerAngles = _3483;
                    }

                    {
                        float _3484 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3485 = this.transform.eulerAngles;
                        _3485.y = _3484;
                        this.transform.eulerAngles = _3485;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa") && !hit.collider.name.Contains("T5"))
                    {
                        switch (randomValue62)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC62 = UnityEngine.Object.Instantiate(this.NPC62, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC62.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Microcruiser]===========================================================================================================================
            if ((this.TheNPC63 == null) && (this.NPC63SpawnChanceIn > 1))
            {
                int randomValue63 = Random.Range(0, this.NPC63SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3486 = this.savedRotY;
                        Vector3 _3487 = this.transform.eulerAngles;
                        _3487.y = _3486;
                        this.transform.eulerAngles = _3487;
                    }

                    {
                        float _3488 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3489 = this.transform.eulerAngles;
                        _3489.y = _3488;
                        this.transform.eulerAngles = _3489;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 6000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa") && !hit.collider.name.Contains("T5"))
                    {
                        switch (randomValue63)
                        {
                            case 2:
                                this.BigSpawnDist = 6000;
                                this.StartCoroutine(this.BigSpawn63());
                                return;
                                break;
                        }
                    }
                }
            }
            //[Sprite]===========================================================================================================================
            if ((this.TheNPC70 == null) && (this.NPC70SpawnChanceIn > 1))
            {
                int randomValue70 = Random.Range(0, this.NPC70SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3490 = this.savedRotY;
                        Vector3 _3491 = this.transform.eulerAngles;
                        _3491.y = _3490;
                        this.transform.eulerAngles = _3491;
                    }

                    {
                        float _3492 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3493 = this.transform.eulerAngles;
                        _3493.y = _3492;
                        this.transform.eulerAngles = _3493;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue70)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC70 = UnityEngine.Object.Instantiate(this.NPC70, hit.point + (this.SpawnSource.up * 8), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC70.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Battle Drone]===========================================================================================================================
            if ((this.TheNPC71 == null) && (this.NPC71SpawnChanceIn > 1))
            {
                int randomValue71 = Random.Range(0, this.NPC71SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3494 = this.savedRotY;
                        Vector3 _3495 = this.transform.eulerAngles;
                        _3495.y = _3494;
                        this.transform.eulerAngles = _3495;
                    }

                    {
                        float _3496 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3497 = this.transform.eulerAngles;
                        _3497.y = _3496;
                        this.transform.eulerAngles = _3497;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1300), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa") && !hit.collider.name.Contains("T5"))
                    {
                        switch (randomValue71)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC71 = UnityEngine.Object.Instantiate(this.NPC71, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC71.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Cannon Drone]===========================================================================================================================
            if ((this.TheNPC72 == null) && (this.NPC72SpawnChanceIn > 1))
            {
                int randomValue72 = Random.Range(0, this.NPC72SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3498 = this.savedRotY;
                        Vector3 _3499 = this.transform.eulerAngles;
                        _3499.y = _3498;
                        this.transform.eulerAngles = _3499;
                    }

                    {
                        float _3500 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3501 = this.transform.eulerAngles;
                        _3501.y = _3500;
                        this.transform.eulerAngles = _3501;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1300), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa") && !hit.collider.name.Contains("T5"))
                    {
                        switch (randomValue72)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC72 = UnityEngine.Object.Instantiate(this.NPC72, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC72.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Squire]===========================================================================================================================
            if ((this.TheNPC73 == null) && (this.NPC73SpawnChanceIn > 1))
            {
                int randomValue73 = Random.Range(0, this.NPC73SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3502 = this.savedRotY;
                        Vector3 _3503 = this.transform.eulerAngles;
                        _3503.y = _3502;
                        this.transform.eulerAngles = _3503;
                    }

                    {
                        float _3504 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3505 = this.transform.eulerAngles;
                        _3505.y = _3504;
                        this.transform.eulerAngles = _3505;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa") && !hit.collider.name.Contains("T5"))
                    {
                        switch (randomValue73)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC73 = UnityEngine.Object.Instantiate(this.NPC73, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC73.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Archer]===========================================================================================================================
            if ((this.TheNPC74 == null) && (this.NPC74SpawnChanceIn > 1))
            {
                int randomValue74 = Random.Range(0, this.NPC74SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3506 = this.savedRotY;
                        Vector3 _3507 = this.transform.eulerAngles;
                        _3507.y = _3506;
                        this.transform.eulerAngles = _3507;
                    }

                    {
                        float _3508 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3509 = this.transform.eulerAngles;
                        _3509.y = _3508;
                        this.transform.eulerAngles = _3509;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa") && !hit.collider.name.Contains("T5"))
                    {
                        switch (randomValue74)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC74 = UnityEngine.Object.Instantiate(this.NPC74, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC74.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Scabbard]===========================================================================================================================
            if ((this.TheNPC75 == null) && (this.NPC75SpawnChanceIn > 1))
            {
                int randomValue75 = Random.Range(0, this.NPC75SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3510 = this.savedRotY;
                        Vector3 _3511 = this.transform.eulerAngles;
                        _3511.y = _3510;
                        this.transform.eulerAngles = _3511;
                    }

                    {
                        float _3512 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3513 = this.transform.eulerAngles;
                        _3513.y = _3512;
                        this.transform.eulerAngles = _3513;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1800), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa") && !hit.collider.name.Contains("T5"))
                    {
                        switch (randomValue75)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC75 = UnityEngine.Object.Instantiate(this.NPC75, hit.point + (this.SpawnSource.up * 2), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC75.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Warmonger]===========================================================================================================================
            if ((this.TheNPC76 == null) && (this.NPC76SpawnChanceIn > 1))
            {
                int randomValue76 = Random.Range(0, this.NPC76SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3514 = this.savedRotY;
                        Vector3 _3515 = this.transform.eulerAngles;
                        _3515.y = _3514;
                        this.transform.eulerAngles = _3515;
                    }

                    {
                        float _3516 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3517 = this.transform.eulerAngles;
                        _3517.y = _3516;
                        this.transform.eulerAngles = _3517;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 3200), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa") && !hit.collider.name.Contains("T5"))
                    {
                        switch (randomValue76)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                                this.TheNPC76 = UnityEngine.Object.Instantiate(this.NPC76, hit.point + (this.SpawnSource.up * 4), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheNPC76.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Knight]===========================================================================================================================
            if ((this.TheNPC77 == null) && (this.NPC77SpawnChanceIn > 1))
            {
                int randomValue77 = Random.Range(0, this.NPC77SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3518 = this.savedRotY;
                        Vector3 _3519 = this.transform.eulerAngles;
                        _3519.y = _3518;
                        this.transform.eulerAngles = _3519;
                    }

                    {
                        float _3520 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3521 = this.transform.eulerAngles;
                        _3521.y = _3520;
                        this.transform.eulerAngles = _3521;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 4000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa") && !hit.collider.name.Contains("T5"))
                    {
                        switch (randomValue77)
                        {
                            case 2:
                                this.BigSpawnDist = 4000;
                                this.StartCoroutine(this.BigSpawn77());
                                return;
                                break;
                        }
                    }
                }
            }
            //[Deus]===========================================================================================================================
            if ((this.TheNPC78 == null) && (this.NPC78SpawnChanceIn > 1))
            {
                int randomValue78 = Random.Range(0, this.NPC78SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3522 = this.savedRotY;
                        Vector3 _3523 = this.transform.eulerAngles;
                        _3523.y = _3522;
                        this.transform.eulerAngles = _3523;
                    }

                    {
                        float _3524 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3525 = this.transform.eulerAngles;
                        _3525.y = _3524;
                        this.transform.eulerAngles = _3525;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 8000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa") && !hit.collider.name.Contains("T5"))
                    {
                        switch (randomValue78)
                        {
                            case 2:
                                this.BigSpawnDist = 8000;
                                this.StartCoroutine(this.BigSpawn78());
                                return;
                                break;
                        }
                    }
                }
            }
            //[Eschatos]===========================================================================================================================
            if ((this.TheNPC79 == null) && (this.NPC79SpawnChanceIn > 1))
            {
                int randomValue79 = Random.Range(0, this.NPC79SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3526 = this.savedRotY;
                        Vector3 _3527 = this.transform.eulerAngles;
                        _3527.y = _3526;
                        this.transform.eulerAngles = _3527;
                    }

                    {
                        float _3528 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3529 = this.transform.eulerAngles;
                        _3529.y = _3528;
                        this.transform.eulerAngles = _3529;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 16000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa") && !hit.collider.name.Contains("T5"))
                    {
                        switch (randomValue79)
                        {
                            case 2:
                                this.BigSpawnDist = 16000;
                                this.StartCoroutine(this.BigSpawn79());
                                return;
                                break;
                        }
                    }
                }
            }
            //[Dutvutanian Civilian 1]===========================================================================================================================
            if ((this.TheNPC90 == null) && (this.NPC90SpawnChanceIn > 1))
            {
                GameObject Spawnionaise90 = ((GameObject) Resources.Load("NPCs/DutvutanianCivilian1", typeof(GameObject))) as GameObject;
                int randomValue90 = Random.Range(0, this.NPC90SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3530 = this.savedRotY;
                        Vector3 _3531 = this.transform.eulerAngles;
                        _3531.y = _3530;
                        this.transform.eulerAngles = _3531;
                    }

                    {
                        float _3532 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3533 = this.transform.eulerAngles;
                        _3533.y = _3532;
                        this.transform.eulerAngles = _3533;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 4500), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue90)
                    {
                        case 2:
                            this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                            this.TheNPC90 = UnityEngine.Object.Instantiate(Spawnionaise90, hit.point + (this.SpawnSource.up * Random.Range(100, 400)), this.SpawnPos.rotation);
                            this.SpawnPos.transform.position = this.TheNPC90.transform.position;
                            break;
                    }
                }
            }
            //[Dutvutanian Civilian 2]===========================================================================================================================
            if ((this.TheNPC91 == null) && (this.NPC91SpawnChanceIn > 1))
            {
                GameObject Spawnionaise91 = ((GameObject) Resources.Load("NPCs/DutvutanianCivilian2", typeof(GameObject))) as GameObject;
                int randomValue91 = Random.Range(0, this.NPC91SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3534 = this.savedRotY;
                        Vector3 _3535 = this.transform.eulerAngles;
                        _3535.y = _3534;
                        this.transform.eulerAngles = _3535;
                    }

                    {
                        float _3536 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3537 = this.transform.eulerAngles;
                        _3537.y = _3536;
                        this.transform.eulerAngles = _3537;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 4500), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue91)
                    {
                        case 2:
                            this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                            this.TheNPC91 = UnityEngine.Object.Instantiate(Spawnionaise91, hit.point + (this.SpawnSource.up * Random.Range(100, 400)), this.SpawnPos.rotation);
                            this.SpawnPos.transform.position = this.TheNPC91.transform.position;
                            break;
                    }
                }
            }
            //[Dutvutanian Civilian 3]===========================================================================================================================
            if ((this.TheNPC92 == null) && (this.NPC92SpawnChanceIn > 1))
            {
                GameObject Spawnionaise92 = ((GameObject) Resources.Load("NPCs/DutvutanianCivilian3", typeof(GameObject))) as GameObject;
                int randomValue92 = Random.Range(0, this.NPC92SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3538 = this.savedRotY;
                        Vector3 _3539 = this.transform.eulerAngles;
                        _3539.y = _3538;
                        this.transform.eulerAngles = _3539;
                    }

                    {
                        float _3540 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3541 = this.transform.eulerAngles;
                        _3541.y = _3540;
                        this.transform.eulerAngles = _3541;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 4500), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue92)
                    {
                        case 2:
                            this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                            this.TheNPC92 = UnityEngine.Object.Instantiate(Spawnionaise92, hit.point + (this.SpawnSource.up * Random.Range(100, 400)), this.SpawnPos.rotation);
                            this.SpawnPos.transform.position = this.TheNPC92.transform.position;
                            break;
                    }
                }
            }
            //[Dutvutanian Intel Ship 1]===========================================================================================================================
            if ((this.TheNPC93 == null) && (this.NPC93SpawnChanceIn > 1))
            {
                GameObject Spawnionaise93 = ((GameObject) Resources.Load("NPCs/DutvutanianIntelShip1", typeof(GameObject))) as GameObject;
                int randomValue93 = Random.Range(0, this.NPC93SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3542 = this.savedRotY;
                        Vector3 _3543 = this.transform.eulerAngles;
                        _3543.y = _3542;
                        this.transform.eulerAngles = _3543;
                    }

                    {
                        float _3544 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3545 = this.transform.eulerAngles;
                        _3545.y = _3544;
                        this.transform.eulerAngles = _3545;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 1500), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue93)
                    {
                        case 2:
                            this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                            this.TheNPC93 = UnityEngine.Object.Instantiate(Spawnionaise93, hit.point + (this.SpawnSource.up * 4), this.SpawnPos.rotation);
                            this.SpawnPos.transform.position = this.TheNPC93.transform.position;
                            break;
                    }
                }
            }
            //[Dutvutanian Police 1]===========================================================================================================================
            if ((this.TheNPC94 == null) && (this.NPC94SpawnChanceIn > 1))
            {
                GameObject Spawnionaise94 = ((GameObject) Resources.Load("NPCs/DutvutanianPolice1", typeof(GameObject))) as GameObject;
                int randomValue94 = Random.Range(0, this.NPC94SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3546 = this.savedRotY;
                        Vector3 _3547 = this.transform.eulerAngles;
                        _3547.y = _3546;
                        this.transform.eulerAngles = _3547;
                    }

                    {
                        float _3548 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3549 = this.transform.eulerAngles;
                        _3549.y = _3548;
                        this.transform.eulerAngles = _3549;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 4000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue94)
                    {
                        case 2:
                            this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                            this.TheNPC94 = UnityEngine.Object.Instantiate(Spawnionaise94, hit.point + (this.SpawnSource.up * 4), this.SpawnPos.rotation);
                            this.SpawnPos.transform.position = this.TheNPC94.transform.position;
                            break;
                    }
                }
            }
            //[Dutvutanian Obmurat 1]===========================================================================================================================
            if ((this.TheNPC95 == null) && (this.NPC95SpawnChanceIn > 1))
            {
                int randomValue95 = Random.Range(0, this.NPC95SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3550 = this.savedRotY;
                        Vector3 _3551 = this.transform.eulerAngles;
                        _3551.y = _3550;
                        this.transform.eulerAngles = _3551;
                    }

                    {
                        float _3552 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3553 = this.transform.eulerAngles;
                        _3553.y = _3552;
                        this.transform.eulerAngles = _3553;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 16000), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    switch (randomValue95)
                    {
                        case 2:
                            this.BigSpawnDist = 16000;
                            this.StartCoroutine(this.BigSpawn95());
                            return;
                            break;
                    }
                }
                else
                {
                    switch (randomValue95)
                    {
                        case 2:
                            this.BigSpawnDist = 16000;
                            this.StartCoroutine(this.BigSpawn95());
                            return;
                            break;
                    }
                }
            }
            //[Dust Devils]===========================================================================================================================
            if (this.PH0SpawnChanceIn > 1)
            {
                if (this.Thing5)
                {
                    int randomValue5 = Random.Range(0, 512);
                    if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * Random.Range(-100, 3000)), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                    {
                        if (!hit.collider.tag.Contains("tru") && !hit.collider.name.Contains("Wa"))
                        {
                            switch (randomValue5)
                            {
                                case 2:
                                    UnityEngine.Object.Instantiate(this.Thing5, hit.point + (this.SpawnSource.up * 2), this.SpawnSource.rotation);
                                    break;
                                case 3:
                                    UnityEngine.Object.Instantiate(this.Thing6, hit.point + (this.SpawnSource.up * 2), this.SpawnSource.rotation);
                                    break;
                            }
                        }
                    }
                }
            }
            //[Agrian Vigil]===========================================================================================================================
            if ((this.TheAgrianVigil == null) && this.AgrianVigil)
            {
                int randomValue3 = Random.Range(0, 64);
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * -250), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValue3)
                        {
                            case 2:
                                this.TheAgrianVigil = UnityEngine.Object.Instantiate(this.AgrianVigil, hit.point + (this.SpawnSource.up * 5), this.transform.rotation);
                                break;
                        }
                    }
                }
            }
            //[Pages Gobnard]===========================================================================================================================
            if (this.P0SpawnChanceIn > 1)
            {
                GameObject SpawnionaiseP0 = ((GameObject) Resources.Load("Objects/PageGobnard", typeof(GameObject))) as GameObject;
                int randomValueP0 = Random.Range(0, this.P0SpawnChanceIn);
                if (this.VelClamp > 1)
                {

                    {
                        float _3554 = this.savedRotY;
                        Vector3 _3555 = this.transform.eulerAngles;
                        _3555.y = _3554;
                        this.transform.eulerAngles = _3555;
                    }

                    {
                        float _3556 = this.transform.eulerAngles.y + Random.Range(-60, 60);
                        Vector3 _3557 = this.transform.eulerAngles;
                        _3557.y = _3556;
                        this.transform.eulerAngles = _3557;
                    }
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, Random.Range(-180, 180), 0);
                }
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * 200), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
                {
                    if (!hit.collider.name.Contains("Wa"))
                    {
                        switch (randomValueP0)
                        {
                            case 2:
                                this.SpawnPos.transform.localEulerAngles = new Vector3(-90, 0, 0);
                                this.TheP0 = UnityEngine.Object.Instantiate(SpawnionaiseP0, hit.point + (this.SpawnSource.up * Random.Range(0.2f, 8)), this.SpawnPos.rotation);
                                this.SpawnPos.transform.position = this.TheP0.transform.position;
                                break;
                        }
                    }
                }
            }
            //[Swirls]===========================================================================================================================
            int randomValue1 = Random.Range(0, 128);
            if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * -100), -this.transform.up, out hit, this.HeightLimit, (int) this.targetLayers))
            {
                if (!hit.collider.name.Contains("Wa"))
                {
                    switch (randomValue1)
                    {
                        case 2:
                            UnityEngine.Object.Instantiate(this.Thing1, hit.point, this.Thing1.transform.rotation);
                            break;
                        case 3:
                            UnityEngine.Object.Instantiate(this.Thing2, hit.point, this.Thing2.transform.rotation);
                            break;
                        case 4:
                            UnityEngine.Object.Instantiate(this.Thing3, hit.point, this.Thing3.transform.rotation);
                            break;
                    }
                }
            }
        }
    }

    public virtual IEnumerator BigSpawn22()
    {
        RaycastHit hit2 = default(RaycastHit);
        this.SpawningBig = true;
        this.Obscured = false;
        yield return new WaitForSeconds(6);
        GameObject Spawnionaise22 = ((GameObject) Resources.Load("NPCs/AgrianAgent", typeof(GameObject))) as GameObject;
        if (!this.Obscured)
        {
            if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), -this.transform.up, out hit2, this.HeightLimit, (int) this.targetLayers))
            {
                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                this.TheNPC22 = UnityEngine.Object.Instantiate(Spawnionaise22, hit2.point + (this.SpawnSource.up * 64), this.SpawnPos.rotation);
                this.SpawnPos.transform.position = this.TheNPC22.transform.position;
                this.SpawningBig = false;
                this.Obscured = false;
            }
        }
        else
        {
            this.SpawningBig = false;
            this.Obscured = false;
        }
    }

    public virtual IEnumerator BigSpawn23()
    {
        RaycastHit hit2 = default(RaycastHit);
        this.SpawningBig = true;
        this.Obscured = false;
        yield return new WaitForSeconds(6);
        GameObject Spawnionaise23 = ((GameObject) Resources.Load("NPCs/AgrianExecutor", typeof(GameObject))) as GameObject;
        if (!this.Obscured)
        {
            if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), -this.transform.up, out hit2, this.HeightLimit, (int) this.targetLayers))
            {
                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                this.TheNPC23 = UnityEngine.Object.Instantiate(Spawnionaise23, hit2.point + (this.SpawnSource.up * 64), this.SpawnPos.rotation);
                this.SpawnPos.transform.position = this.TheNPC23.transform.position;
                this.SpawningBig = false;
                this.Obscured = false;
            }
        }
        else
        {
            this.SpawningBig = false;
            this.Obscured = false;
        }
    }

    public virtual IEnumerator BigSpawn24()
    {
        RaycastHit hit2 = default(RaycastHit);
        this.SpawningBig = true;
        this.Obscured = false;
        yield return new WaitForSeconds(6);
        GameObject Spawnionaise24 = ((GameObject) Resources.Load("NPCs/AgrianSuperExecutor", typeof(GameObject))) as GameObject;
        if (!this.Obscured)
        {
            if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), -this.transform.up, out hit2, this.HeightLimit, (int) this.targetLayers))
            {
                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                this.TheNPC24 = UnityEngine.Object.Instantiate(Spawnionaise24, hit2.point + (this.SpawnSource.up * 128), this.SpawnPos.rotation);
                this.SpawnPos.transform.position = this.TheNPC24.transform.position;
                this.SpawningBig = false;
                this.Obscured = false;
            }
        }
        else
        {
            this.SpawningBig = false;
            this.Obscured = false;
        }
    }

    public virtual IEnumerator BigSpawn26()
    {
        RaycastHit hit2 = default(RaycastHit);
        this.SpawningBig = true;
        this.Obscured = false;
        yield return new WaitForSeconds(6);
        GameObject Spawnionaise26 = ((GameObject) Resources.Load("NPCs/AgrianAnnihilator", typeof(GameObject))) as GameObject;
        if (!this.Obscured)
        {
            if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), -this.transform.up, out hit2, this.HeightLimit, (int) this.targetLayers))
            {
                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                this.TheNPC26 = UnityEngine.Object.Instantiate(Spawnionaise26, hit2.point + (this.SpawnSource.up * 80), this.SpawnPos.rotation);
                this.SpawnPos.transform.position = this.TheNPC26.transform.position;
                this.SpawningBig = false;
                this.Obscured = false;
            }
        }
        else
        {
            this.SpawningBig = false;
            this.Obscured = false;
        }
    }

    public virtual IEnumerator BigSpawn27()
    {
        RaycastHit hit2 = default(RaycastHit);
        this.SpawningBig = true;
        this.Obscured = false;
        yield return new WaitForSeconds(6);
        GameObject Spawnionaise27 = ((GameObject) Resources.Load("NPCs/AgrianDistributor", typeof(GameObject))) as GameObject;
        if (!this.Obscured)
        {
            if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), -this.transform.up, out hit2, this.HeightLimit, (int) this.targetLayers))
            {
                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                this.TheNPC27 = UnityEngine.Object.Instantiate(Spawnionaise27, hit2.point + (this.SpawnSource.up * 64), this.SpawnPos.rotation);
                this.SpawnPos.transform.position = this.TheNPC27.transform.position;
                this.SpawningBig = false;
                this.Obscured = false;
            }
        }
        else
        {
            this.SpawningBig = false;
            this.Obscured = false;
        }
    }

    public virtual IEnumerator BigSpawn303()
    {
        RaycastHit hit2 = default(RaycastHit);
        this.SpawningBig = true;
        this.Obscured = false;
        yield return new WaitForSeconds(6);
        GameObject Spawnionaise303 = ((GameObject) Resources.Load("NPCs/LevNavCruiser1", typeof(GameObject))) as GameObject;
        if (!this.Obscured)
        {
            if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), -this.transform.up, out hit2, this.HeightLimit, (int) this.targetLayers))
            {
                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                this.TheNPC303 = UnityEngine.Object.Instantiate(Spawnionaise303, hit2.point + (this.SpawnSource.up * 24), this.SpawnPos.rotation);
                this.SpawnPos.transform.position = this.TheNPC303.transform.position;
                this.SpawningBig = false;
                this.Obscured = false;
            }
        }
        else
        {
            this.SpawningBig = false;
            this.Obscured = false;
        }
    }

    public virtual IEnumerator BigSpawn32()
    {
        RaycastHit hit2 = default(RaycastHit);
        this.SpawningBig = true;
        this.Obscured = false;
        yield return new WaitForSeconds(6);
        if (!this.Obscured)
        {
            if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), -this.transform.up, out hit2, this.HeightLimit, (int) this.targetLayers))
            {
                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                this.TheNPC32 = UnityEngine.Object.Instantiate(this.NPC32, hit2.point + (this.SpawnSource.up * 5), this.SpawnPos.rotation);
                this.SpawnPos.transform.position = this.TheNPC32.transform.position;
                this.SpawningBig = false;
                this.Obscured = false;
            }
        }
        else
        {
            this.SpawningBig = false;
            this.Obscured = false;
        }
    }

    public virtual IEnumerator BigSpawn33()
    {
        RaycastHit hit2 = default(RaycastHit);
        this.SpawningBig = true;
        this.Obscured = false;
        yield return new WaitForSeconds(6);
        GameObject Spawnionaise33 = ((GameObject) Resources.Load("NPCs/DasNavCruiser", typeof(GameObject))) as GameObject;
        if (!this.Obscured)
        {
            if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), -this.transform.up, out hit2, this.HeightLimit, (int) this.targetLayers))
            {
                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                this.TheNPC33 = UnityEngine.Object.Instantiate(Spawnionaise33, hit2.point + (this.SpawnSource.up * 12), this.SpawnPos.rotation);
                this.SpawnPos.transform.position = this.TheNPC33.transform.position;
                this.SpawningBig = false;
                this.Obscured = false;
            }
        }
        else
        {
            this.SpawningBig = false;
            this.Obscured = false;
        }
    }

    public virtual IEnumerator BigSpawn34()
    {
        RaycastHit hit2 = default(RaycastHit);
        this.SpawningBig = true;
        this.Obscured = false;
        yield return new WaitForSeconds(6);
        GameObject Spawnionaise34 = ((GameObject) Resources.Load("NPCs/TRNTank1", typeof(GameObject))) as GameObject;
        if (!this.Obscured)
        {
            if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), -this.transform.up, out hit2, this.HeightLimit, (int) this.targetLayers))
            {
                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                this.TheNPC34 = UnityEngine.Object.Instantiate(Spawnionaise34, hit2.point + (this.SpawnSource.up * 4), this.SpawnPos.rotation);
                this.SpawnPos.transform.position = this.TheNPC34.transform.position;
                this.SpawningBig = false;
                this.Obscured = false;
            }
        }
        else
        {
            this.SpawningBig = false;
            this.Obscured = false;
        }
    }

    public virtual IEnumerator BigSpawn35()
    {
        RaycastHit hit2 = default(RaycastHit);
        this.SpawningBig = true;
        this.Obscured = false;
        yield return new WaitForSeconds(6);
        GameObject Spawnionaise35 = ((GameObject) Resources.Load("NPCs/TLFAdamant", typeof(GameObject))) as GameObject;
        if (!this.Obscured)
        {
            if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), -this.transform.up, out hit2, this.HeightLimit, (int) this.targetLayers))
            {
                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                this.TheNPC35 = UnityEngine.Object.Instantiate(Spawnionaise35, hit2.point + (this.SpawnSource.up * 16), this.SpawnPos.rotation);
                this.SpawnPos.transform.position = this.TheNPC35.transform.position;
                this.SpawningBig = false;
                this.Obscured = false;
            }
        }
        else
        {
            this.SpawningBig = false;
            this.Obscured = false;
        }
    }

    public virtual IEnumerator BigSpawn43()
    {
        RaycastHit hit2 = default(RaycastHit);
        this.SpawningBig = true;
        this.Obscured = false;
        yield return new WaitForSeconds(6);
        if (!this.Obscured)
        {
            if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), -this.transform.up, out hit2, this.HeightLimit, (int) this.targetLayers))
            {
                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                this.TheNPC43 = UnityEngine.Object.Instantiate(this.NPC43, hit2.point + (this.SpawnSource.up * 8), this.SpawnPos.rotation);
                this.SpawnPos.transform.position = this.TheNPC43.transform.position;
                this.SpawningBig = false;
                this.Obscured = false;
            }
        }
        else
        {
            this.SpawningBig = false;
            this.Obscured = false;
        }
    }

    public virtual IEnumerator BigSpawn44()
    {
        RaycastHit hit2 = default(RaycastHit);
        this.SpawningBig = true;
        this.Obscured = false;
        yield return new WaitForSeconds(6);
        if (!this.Obscured)
        {
            if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), -this.transform.up, out hit2, this.HeightLimit, (int) this.targetLayers))
            {
                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                this.TheNPC44 = UnityEngine.Object.Instantiate(this.NPC44, hit2.point + (this.SpawnSource.up * 8), this.SpawnPos.rotation);
                this.SpawnPos.transform.position = this.TheNPC44.transform.position;
                this.SpawningBig = false;
                this.Obscured = false;
            }
        }
        else
        {
            this.SpawningBig = false;
            this.Obscured = false;
        }
    }

    public virtual IEnumerator BigSpawn45()
    {
        RaycastHit hit2 = default(RaycastHit);
        this.SpawningBig = true;
        this.Obscured = false;
        yield return new WaitForSeconds(6);
        if (!this.Obscured)
        {
            if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), -this.transform.up, out hit2, this.HeightLimit, (int) this.targetLayers))
            {
                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                this.TheNPC45 = UnityEngine.Object.Instantiate(this.NPC45, hit2.point + (this.SpawnSource.up * 8), this.SpawnPos.rotation);
                this.SpawnPos.transform.position = this.TheNPC45.transform.position;
                this.SpawningBig = false;
                this.Obscured = false;
            }
        }
        else
        {
            this.SpawningBig = false;
            this.Obscured = false;
        }
    }

    public virtual IEnumerator BigSpawn63()
    {
        RaycastHit hit2 = default(RaycastHit);
        this.SpawningBig = true;
        this.Obscured = false;
        yield return new WaitForSeconds(6);
        if (!this.Obscured)
        {
            if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), -this.transform.up, out hit2, this.HeightLimit, (int) this.targetLayers))
            {
                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                this.TheNPC63 = UnityEngine.Object.Instantiate(this.NPC63, hit2.point + (this.SpawnSource.up * 8), this.SpawnPos.rotation);
                this.SpawnPos.transform.position = this.TheNPC63.transform.position;
                this.SpawningBig = false;
                this.Obscured = false;
            }
        }
        else
        {
            this.SpawningBig = false;
            this.Obscured = false;
        }
    }

    public virtual IEnumerator BigSpawn77()
    {
        RaycastHit hit2 = default(RaycastHit);
        this.SpawningBig = true;
        this.Obscured = false;
        yield return new WaitForSeconds(6);
        if (!this.Obscured)
        {
            if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), -this.transform.up, out hit2, this.HeightLimit, (int) this.targetLayers))
            {
                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                this.TheNPC77 = UnityEngine.Object.Instantiate(this.NPC77, hit2.point + (this.SpawnSource.up * 8), this.SpawnPos.rotation);
                this.SpawnPos.transform.position = this.TheNPC77.transform.position;
                this.SpawningBig = false;
                this.Obscured = false;
            }
        }
        else
        {
            this.SpawningBig = false;
            this.Obscured = false;
        }
    }

    public virtual IEnumerator BigSpawn78()
    {
        RaycastHit hit2 = default(RaycastHit);
        this.SpawningBig = true;
        this.Obscured = false;
        yield return new WaitForSeconds(6);
        if (!this.Obscured)
        {
            if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), -this.transform.up, out hit2, this.HeightLimit, (int) this.targetLayers))
            {
                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                this.TheNPC78 = UnityEngine.Object.Instantiate(this.NPC78, hit2.point + (this.SpawnSource.up * 16), this.SpawnPos.rotation);
                this.SpawnPos.transform.position = this.TheNPC78.transform.position;
                this.SpawningBig = false;
                this.Obscured = false;
            }
        }
        else
        {
            this.SpawningBig = false;
            this.Obscured = false;
        }
    }

    public virtual IEnumerator BigSpawn79()
    {
        RaycastHit hit2 = default(RaycastHit);
        this.SpawningBig = true;
        this.Obscured = false;
        yield return new WaitForSeconds(6);
        GameObject Spawnionaise79 = ((GameObject) Resources.Load("NPCs/MevNavWarcruiser", typeof(GameObject))) as GameObject;
        if (!this.Obscured)
        {
            if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), -this.transform.up, out hit2, this.HeightLimit, (int) this.targetLayers))
            {
                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                this.TheNPC79 = UnityEngine.Object.Instantiate(Spawnionaise79, hit2.point + (this.SpawnSource.up * 48), this.SpawnPos.rotation);
                this.SpawnPos.transform.position = this.TheNPC79.transform.position;
                this.SpawningBig = false;
                this.Obscured = false;
            }
        }
        else
        {
            this.SpawningBig = false;
            this.Obscured = false;
        }
    }

    public virtual IEnumerator BigSpawn95()
    {
        RaycastHit hit2 = default(RaycastHit);
        this.SpawningBig = true;
        this.Obscured = false;
        yield return new WaitForSeconds(6);
        GameObject Spawnionaise95 = ((GameObject) Resources.Load("NPCs/DN_Obmurat_MVA1", typeof(GameObject))) as GameObject;
        if (!this.Obscured)
        {
            if (!this.AreaSpace)
            {
                if (Physics.Raycast(this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), -this.transform.up, out hit2, this.HeightLimit, (int) this.targetLayers))
                {
                    this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                    this.TheNPC95 = UnityEngine.Object.Instantiate(Spawnionaise95, hit2.point + (this.SpawnSource.up * 64), this.SpawnPos.rotation);
                    this.SpawnPos.transform.position = this.TheNPC95.transform.position;
                    this.SpawningBig = false;
                    this.Obscured = false;
                }
            }
            else
            {
                this.SpawnPos.transform.localEulerAngles = new Vector3(0, Random.Range(70, 110), 0);
                this.TheNPC95 = UnityEngine.Object.Instantiate(Spawnionaise95, this.SpawnSource.position + (this.SpawnSource.forward * this.BigSpawnDist), this.SpawnPos.rotation);
                this.SpawnPos.transform.position = this.TheNPC95.transform.position;
                this.SpawningBig = false;
                this.Obscured = false;
            }
        }
        else
        {
            this.SpawningBig = false;
            this.Obscured = false;
        }
    }

    public StuffSpawner()
    {
        this.P0SpawnChanceIn = 8;
        this.PH0SpawnChanceIn = 8;
        this.NPC000SpawnChanceIn = 8;
        this.NPC001SpawnChanceIn = 8;
        this.NPC002SpawnChanceIn = 8;
        this.NPC003SpawnChanceIn = 8;
        this.NPC004SpawnChanceIn = 8;
        this.NPC005SpawnChanceIn = 8;
        this.NPC006SpawnChanceIn = 8;
        this.NPC007SpawnChanceIn = 8;
        this.NPC008SpawnChanceIn = 8;
        this.NPC009SpawnChanceIn = 8;
        this.NPC0091SpawnChanceIn = 8;
        this.NPC0800SpawnChanceIn = 8;
        this.NPC0801SpawnChanceIn = 8;
        this.NPC0802SpawnChanceIn = 8;
        this.NPC0803SpawnChanceIn = 8;
        this.NPC0804SpawnChanceIn = 8;
        this.NPC0805SpawnChanceIn = 8;
        this.NPC080SpawnChanceIn = 8;
        this.NPC081SpawnChanceIn = 8;
        this.NPC082SpawnChanceIn = 8;
        this.NPC00SpawnChanceIn = 8;
        this.NPC01SpawnChanceIn = 8;
        this.NPC02SpawnChanceIn = 8;
        this.NPC03SpawnChanceIn = 8;
        this.NPC04SpawnChanceIn = 8;
        this.NPC05SpawnChanceIn = 8;
        this.NPC10SpawnChanceIn = 8;
        this.NPC20SpawnChanceIn = 8;
        this.NPC21SpawnChanceIn = 8;
        this.NPC22SpawnChanceIn = 8;
        this.NPC23SpawnChanceIn = 8;
        this.NPC24SpawnChanceIn = 8;
        this.NPC25SpawnChanceIn = 8;
        this.NPC26SpawnChanceIn = 8;
        this.NPC27SpawnChanceIn = 8;
        this.NPC300SpawnChanceIn = 8;
        this.NPC301SpawnChanceIn = 8;
        this.NPC302SpawnChanceIn = 8;
        this.NPC303SpawnChanceIn = 8;
        this.NPC310SpawnChanceIn = 8;
        this.NPC31SpawnChanceIn = 8;
        this.NPC32SpawnChanceIn = 8;
        this.NPC33SpawnChanceIn = 8;
        this.NPC34SpawnChanceIn = 8;
        this.NPC35SpawnChanceIn = 8;
        this.NPC36SpawnChanceIn = 8;
        this.NPC37SpawnChanceIn = 8;
        this.NPC39SpawnChanceIn = 8;
        this.NPC40SpawnChanceIn = 8;
        this.NPC41SpawnChanceIn = 8;
        this.NPC42SpawnChanceIn = 8;
        this.NPC43SpawnChanceIn = 8;
        this.NPC44SpawnChanceIn = 8;
        this.NPC45SpawnChanceIn = 8;
        this.NPC50SpawnChanceIn = 8;
        this.NPC51SpawnChanceIn = 8;
        this.NPC52SpawnChanceIn = 8;
        this.NPC53SpawnChanceIn = 8;
        this.NPC54SpawnChanceIn = 8;
        this.NPC55SpawnChanceIn = 8;
        this.NPC56SpawnChanceIn = 8;
        this.NPC57SpawnChanceIn = 8;
        this.NPC60SpawnChanceIn = 8;
        this.NPC61SpawnChanceIn = 8;
        this.NPC62SpawnChanceIn = 8;
        this.NPC63SpawnChanceIn = 8;
        this.NPC70SpawnChanceIn = 8;
        this.NPC71SpawnChanceIn = 8;
        this.NPC72SpawnChanceIn = 8;
        this.NPC73SpawnChanceIn = 8;
        this.NPC74SpawnChanceIn = 8;
        this.NPC75SpawnChanceIn = 8;
        this.NPC76SpawnChanceIn = 8;
        this.NPC77SpawnChanceIn = 8;
        this.NPC78SpawnChanceIn = 8;
        this.NPC79SpawnChanceIn = 8;
        this.NPC90SpawnChanceIn = 8;
        this.NPC91SpawnChanceIn = 8;
        this.NPC92SpawnChanceIn = 8;
        this.NPC93SpawnChanceIn = 8;
        this.NPC94SpawnChanceIn = 8;
        this.NPC95SpawnChanceIn = 8;
        this.P0StaticSpawnChanceIn = 8;
        this.PH0StaticSpawnChanceIn = 8;
        this.NPC000StaticSpawnChanceIn = 8;
        this.NPC001StaticSpawnChanceIn = 8;
        this.NPC002StaticSpawnChanceIn = 8;
        this.NPC003StaticSpawnChanceIn = 8;
        this.NPC004StaticSpawnChanceIn = 8;
        this.NPC005StaticSpawnChanceIn = 8;
        this.NPC006StaticSpawnChanceIn = 8;
        this.NPC007StaticSpawnChanceIn = 8;
        this.NPC008StaticSpawnChanceIn = 8;
        this.NPC009StaticSpawnChanceIn = 8;
        this.NPC0091StaticSpawnChanceIn = 8;
        this.NPC0800StaticSpawnChanceIn = 8;
        this.NPC0801StaticSpawnChanceIn = 8;
        this.NPC0802StaticSpawnChanceIn = 8;
        this.NPC0803StaticSpawnChanceIn = 8;
        this.NPC0804StaticSpawnChanceIn = 8;
        this.NPC0805StaticSpawnChanceIn = 8;
        this.NPC080StaticSpawnChanceIn = 8;
        this.NPC081StaticSpawnChanceIn = 8;
        this.NPC082StaticSpawnChanceIn = 8;
        this.NPC00StaticSpawnChanceIn = 8;
        this.NPC01StaticSpawnChanceIn = 8;
        this.NPC02StaticSpawnChanceIn = 8;
        this.NPC03StaticSpawnChanceIn = 8;
        this.NPC04StaticSpawnChanceIn = 8;
        this.NPC05StaticSpawnChanceIn = 8;
        this.NPC10StaticSpawnChanceIn = 8;
        this.NPC20StaticSpawnChanceIn = 8;
        this.NPC21StaticSpawnChanceIn = 8;
        this.NPC22StaticSpawnChanceIn = 8;
        this.NPC23StaticSpawnChanceIn = 8;
        this.NPC24StaticSpawnChanceIn = 8;
        this.NPC25StaticSpawnChanceIn = 8;
        this.NPC26StaticSpawnChanceIn = 8;
        this.NPC27StaticSpawnChanceIn = 8;
        this.NPC300StaticSpawnChanceIn = 8;
        this.NPC301StaticSpawnChanceIn = 8;
        this.NPC302StaticSpawnChanceIn = 8;
        this.NPC303StaticSpawnChanceIn = 8;
        this.NPC310StaticSpawnChanceIn = 8;
        this.NPC31StaticSpawnChanceIn = 8;
        this.NPC32StaticSpawnChanceIn = 8;
        this.NPC33StaticSpawnChanceIn = 8;
        this.NPC34StaticSpawnChanceIn = 8;
        this.NPC35StaticSpawnChanceIn = 8;
        this.NPC36StaticSpawnChanceIn = 8;
        this.NPC37StaticSpawnChanceIn = 8;
        this.NPC39StaticSpawnChanceIn = 8;
        this.NPC40StaticSpawnChanceIn = 8;
        this.NPC41StaticSpawnChanceIn = 8;
        this.NPC42StaticSpawnChanceIn = 8;
        this.NPC43StaticSpawnChanceIn = 8;
        this.NPC44StaticSpawnChanceIn = 8;
        this.NPC45StaticSpawnChanceIn = 8;
        this.NPC50StaticSpawnChanceIn = 8;
        this.NPC51StaticSpawnChanceIn = 8;
        this.NPC52StaticSpawnChanceIn = 8;
        this.NPC53StaticSpawnChanceIn = 8;
        this.NPC54StaticSpawnChanceIn = 8;
        this.NPC55StaticSpawnChanceIn = 8;
        this.NPC56StaticSpawnChanceIn = 8;
        this.NPC57StaticSpawnChanceIn = 8;
        this.NPC60StaticSpawnChanceIn = 8;
        this.NPC61StaticSpawnChanceIn = 8;
        this.NPC62StaticSpawnChanceIn = 8;
        this.NPC63StaticSpawnChanceIn = 8;
        this.NPC70StaticSpawnChanceIn = 8;
        this.NPC71StaticSpawnChanceIn = 8;
        this.NPC72StaticSpawnChanceIn = 8;
        this.NPC73StaticSpawnChanceIn = 8;
        this.NPC74StaticSpawnChanceIn = 8;
        this.NPC75StaticSpawnChanceIn = 8;
        this.NPC76StaticSpawnChanceIn = 8;
        this.NPC77StaticSpawnChanceIn = 8;
        this.NPC78StaticSpawnChanceIn = 8;
        this.NPC79StaticSpawnChanceIn = 8;
        this.NPC90StaticSpawnChanceIn = 8;
        this.NPC91StaticSpawnChanceIn = 8;
        this.NPC92StaticSpawnChanceIn = 8;
        this.NPC93StaticSpawnChanceIn = 8;
        this.NPC94StaticSpawnChanceIn = 8;
        this.NPC95StaticSpawnChanceIn = 8;
        this.VelClamp = 1;
        this.Vel2 = 1;
        this.Count = 60;
        this.LowSpawnDist = 50;
        this.BigSpawnDist = 4000;
        this.HeightLimit = 2000;
    }

}