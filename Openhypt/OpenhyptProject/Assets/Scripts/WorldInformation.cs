using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class WorldInformation : MonoBehaviour
{
    public static bool ZerahyptIsRunning;
    public string AreaName;
    public int AreaCode;
    private int currentAmbColor;
    public float changeTime;
    public Color[] ambColors;
    public Color reflColors;
    public static bool AmbOff;
    public static bool AmbOn;
    public bool AreaBeige;
    public bool AreaGray;
    public bool AreaDark;
    public bool AreaDut;
    public bool AreaSpace;
    public bool AreaClosed;
    public bool AreaKabrian;
    public Transform RestrictedArea;
    public Transform TravelLocation;
    public Transform TravelLocationN;
    public Transform TravelLocationE;
    public Transform TravelLocationS;
    public Transform TravelLocationW;
    public Transform SpecialDeliveryArea;
    public bool didDeliver;
    public GameObject FleetWarp;
    public FleetScript PiriFleetScript;
    public GameObject Ceptobarge;
    public bool InvertedNoPass;
    public string TaxiWhereToGo;
    public bool TaxiExit1;
    public bool TaxiExit2;
    public bool TaxiExit3;
    public LayerMask NPCGunTL;
    public bool Once;
    public static bool ZerahyptStarted;
    public static bool cheatsOn;
    public static bool PopUp;
    public static bool Godmode;
    public static bool PiriIsHurt;
    public static int PiriExposed;
    public static int PiriWanted;
    public Vector3 NaughtyVicinity;
    public static bool PiriFree;
    public static bool PiriTopFree;
    public static bool PiriBottomFree;
    public static bool PiriZerzekPresent;
    public static bool PiriPodPresent;
    public static WorldInformation instance;
    public static string VersionID;
    public static AngyScript angyS;
    public static Transform pSpeech;
    public static float pSpeechRange;
    public static Transform bigMissile1;
    public static Transform bigMissile2;
    public static string GaragedVehicle;
    public static float GaragedVehicleSpawnDist;
    public static Transform Garage;
    public static bool NearGarage;
    public static bool InGarage;
    public static string GaragedVehicleF1;
    public static float GaragedVehicleSpawnDistF1;
    public static Transform GarageF1;
    public static bool NearGarageF1;
    public static bool InGarageF1;
    public static string GaragedVehicleF2;
    public static float GaragedVehicleSpawnDistF2;
    public static Transform GarageF2;
    public static bool NearGarageF2;
    public static bool InGarageF2;
    public static string FleetMember2;
    public static string FleetMember3;
    public static string FleetMember4;
    public static int ShippedVehicleNum;
    public static int vehicleSpeed;
    public static int playerLevel;
    public static bool UsingVessel;
    public static bool Hitching;
    public static bool UsingSnyf;
    public static string playerCar;
    public static Transform npcVehicleTF;
    public static MainVehicleController vehicleController;
    public static CarDoorController vehicleDoorController;
    public static bool CanLeaveVehicle;
    public static bool UsingClosedVessel;
    public static bool UsingBrightVessel;
    public static bool UsingBigVessel;
    public static Vector3 TargetAttack;
    public static bool SaveGame;
    public static bool stopCamera;
    public static int AudioTrackNumber;
    public static bool FPMode;
    public static bool IsOotkinSick;
    public static bool NearEntrance;
    public static bool IsNopass;
    public static bool backpackIsPresent;
    public static bool isWearingBackpack;
    public static string whatBackpack;
    public static bool isHolding;
    public static bool isSwitchingScene;
    public static bool isTraveling;
    public static bool DrivingZerzek;
    public static bool FacingNorth;
    public static bool FacingSouth;
    public static bool FacingWest;
    public static bool FacingEast;
    public static bool Unset;
    public static bool DamageCounterOff;
    public static bool MusicOff;
    public static bool TutorialOff;
    public static float AudioVolume;
    public static int Sensitivity;
    public static string DocumentationsStat;
    public static int DocumentationsPurgeNum;
    public static int workSessionNum;
    public static int workInstanceNum;
    public bool objectsScanned;
    public int minClock;
    public int terrahyptTimeSet;
    public static int terrahyptTime;
    public int terrahyptSecond;
    public int terrahyptMinute;
    public int terrahyptHour;
    public static bool minuteBell;
    public static bool halfhourBell;
    public static bool hourBell;
    public static bool halfraonBell;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Ticker", 0.77f, 1);
        this.InvokeRepeating("Ticky", 3, 1.43f);
        WorldInformation.isTraveling = false;
        WorldInformation.isHolding = false;
        WorldInformation.backpackIsPresent = false;
        WorldInformation.DocumentationsStat = PlayerPrefs.GetString("Documentations");
        GameObject Prefabionaise = ((GameObject) Resources.Load("Prefabs/SavedLayerMasks", typeof(GameObject))) as GameObject;
        this.NPCGunTL = ((LayerMaskionaises) Prefabionaise.GetComponent(typeof(LayerMaskionaises))).SavedLayerMask1;
        if (PlayerPrefs.HasKey("FleetMember2"))
        {
            WorldInformation.FleetMember2 = PlayerPrefs.GetString("FleetMember2");
        }
        if (PlayerPrefs.HasKey("FleetMember3"))
        {
            WorldInformation.FleetMember3 = PlayerPrefs.GetString("FleetMember3");
        }
        if (PlayerPrefs.HasKey("FleetMember4"))
        {
            WorldInformation.FleetMember4 = PlayerPrefs.GetString("FleetMember4");
        }
        if (!PlayerPrefs.HasKey("Sensitivity"))
        {
            PlayerPrefs.SetInt("Sensitivity", 60);
        }
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 1);
        }
        if (!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetInt("Music", 1);
        }
        if (!PlayerPrefs.HasKey("Damage"))
        {
            PlayerPrefs.SetInt("Damage", 1);
        }
        if (!PlayerPrefs.HasKey("Tutorial"))
        {
            PlayerPrefs.SetInt("Tutorial", 1);
        }
        WorldInformation.Sensitivity = PlayerPrefs.GetInt("Sensitivity");
        WorldInformation.AudioVolume = PlayerPrefs.GetFloat("Volume");
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            WorldInformation.MusicOff = false;
        }
        else
        {
            WorldInformation.MusicOff = true;
        }
        if (PlayerPrefs.GetInt("Damage") == 1)
        {
            WorldInformation.DamageCounterOff = false;
        }
        else
        {
            WorldInformation.DamageCounterOff = true;
        }
        if (PlayerPrefs.GetInt("Tutorial") == 1)
        {
            WorldInformation.TutorialOff = false;
        }
        else
        {
            WorldInformation.TutorialOff = true;
        }
        AudioListener.volume = WorldInformation.AudioVolume;
        WorldInformation.terrahyptTime = Random.Range(0, 32768);
        //terrahyptTime = terrahyptTimeSet;
        this.setTime();
        WorldInformation.PiriIsHurt = false;
        WorldInformation.Hitching = false;
        WorldInformation.PiriPodPresent = false;
        this.NaughtyVicinity.y = 400000;
        if (this.AreaCode == 63)
        {
            yield break;
        }
        WorldInformation.Unset = false;
        WorldInformation.PiriFree = false;
        WorldInformation.PiriZerzekPresent = false;
        WorldInformation.IsNopass = false;
        WorldInformation.CanLeaveVehicle = true;
        WorldInformation.UsingClosedVessel = false;
        WorldInformation.playerCar = "null";
        if (this.AreaSpace)
        {
            Physics.gravity = new Vector3(0, 0, 0);
        }
        else
        {
            Physics.gravity = new Vector3(0, -13, 0);
        }
        yield return new WaitForSeconds(0.5f);
        if (WorldInformation.DocumentationsStat.Length < 16)
        {
            PlayerPrefs.DeleteKey("WorkSession");
        }
        if (!WorldInformation.ZerahyptIsRunning)
        {
            WorldInformation.ZerahyptIsRunning = true;
            if (!PlayerPrefs.HasKey("WorkSession"))
            {
                WorldInformation.workSessionNum = 1;
                WorldInformation.workInstanceNum = 1;
                PlayerPrefs.SetInt("WorkSession", WorldInformation.workSessionNum);
                Debug.Log("itDid1");
                WorldInformation.DocumentationsStat = WorldInformation.DocumentationsStat + (((((("Work Session " + WorldInformation.workSessionNum) + "\nEntry ") + WorldInformation.workInstanceNum) + " : Instance (") + this.AreaName) + ")\n===============================");
            }
            else
            {
                WorldInformation.workSessionNum = PlayerPrefs.GetInt("WorkSession");
                WorldInformation.workSessionNum = WorldInformation.workSessionNum + 1;
                WorldInformation.workInstanceNum = 1;
                PlayerPrefs.SetInt("WorkSession", WorldInformation.workSessionNum);
                //Debug.Log("itDid2");
                WorldInformation.DocumentationsStat = WorldInformation.DocumentationsStat + (((((("\n \n \n \n \nWork Session " + WorldInformation.workSessionNum) + "\nEntry ") + WorldInformation.workInstanceNum) + " : Instance (") + this.AreaName) + ")\n===============================");
            }
        }
        else
        {
            if (!WorldInformation.isTraveling)
            {
                WorldInformation.workInstanceNum = WorldInformation.workInstanceNum + 1;
                if (WorldInformation.workInstanceNum > 1)
                {
                    WorldInformation.DocumentationsStat = WorldInformation.DocumentationsStat + (((("\n \n \n \n \nEntry " + WorldInformation.workInstanceNum) + " : Instance (") + this.AreaName) + ")\n===============================");
                }
                else
                {
                    WorldInformation.DocumentationsStat = WorldInformation.DocumentationsStat + (((("Entry " + WorldInformation.workInstanceNum) + " : Instance (") + this.AreaName) + ")\n===============================");
                }
            }
        }
        if (!WorldInformation.isTraveling)
        {
            if (WorldInformation.DocumentationsStat.Length > 8000)
            {
                if (WorldInformation.DocumentationsPurgeNum > 3)
                {
                    WorldInformation.DocumentationsPurgeNum = 0;
                    WorldInformation.workInstanceNum = 1;
                    WorldInformation.DocumentationsStat = null;
                    WorldInformation.DocumentationsStat = WorldInformation.DocumentationsStat + (((((("Work Session " + WorldInformation.workSessionNum) + "\nEntry ") + WorldInformation.workInstanceNum) + " : Instance (") + this.AreaName) + ")\n===============================");
                    PlayerPrefs.SetString("Documentations", WorldInformation.DocumentationsStat);
                }
                else
                {
                    //Debug.Log("IsDoingit1 " + DocumentationsStat.Length);
                    WorldInformation.DocumentationsPurgeNum = WorldInformation.DocumentationsPurgeNum + 1;
                    FurtherActionScript.instance.DocumentationsLimit = true;
                    FurtherActionScript.instance.ShowText();
                }
            }
        }
        PlayerPrefs.Save();
        yield return new WaitForSeconds(1.5f);
        if (WorldInformation.PiriZerzekPresent)
        {
            this.StartCoroutine(this.SummonFleet());
        }
    }

    public virtual IEnumerator SummonFleet()
    {
        yield return new WaitForSeconds(20);
        if (this.PiriFleetScript)
        {
            this.StartCoroutine(this.PiriFleetScript.Summon());
        }
    }

    public virtual void Home()
    {
        if (this.FleetWarp)
        {
            this.StartCoroutine(this.SummonFleet());
        }
        else
        {
            FurtherActionScript.instance.NoTransportService = true;
            FurtherActionScript.instance.ShowText();
            CallButton.CallingOther0 = true;
        }
    }

    public virtual void HomeNow()
    {
        if (this.FleetWarp)
        {
            this.StartCoroutine(this.SummonFleet());
        }
    }

    public virtual IEnumerator Hurt()
    {
        if (!this.Once)
        {
            this.Once = true;
            yield return new WaitForSeconds(1);
            ScreenFadeScript.FadeOut = true;
            DrivenVesselScript.WhatToSpawn = "null";
            PlayerPrefs.SetFloat("Injured", 1);
            PlayerPrefs.Save();
            yield return new WaitForSeconds(3);
            AgrianNetwork.TC1CriminalLevel = 0;
            AbiaSyndicateNetwork.TC1CriminalLevel = 0;
            TerrahyptianNetwork.TC1CriminalLevel = 0;
            SlavuicNetwork.TC1DeathRow = 0;
            MevNavNetwork.TC1DeathRow = 0;
            DutvutanianNetwork.TC1CriminalLevel = 0;
            DutvutanianNetwork.TC1CriminalPoints = 2;
            WorldInformation.PiriWanted = 0;
            WorldInformation.FPMode = false;
            if (!this.objectsScanned)
            {
                WorldInformation.DocumentationsStat = WorldInformation.DocumentationsStat + "\n \nNothing to report.";
            }
            PlayerPrefs.SetString("Documentations", WorldInformation.DocumentationsStat);
            Application.LoadLevel("PiriZerzek");
        }
    }

    public virtual IEnumerator EscortHome()
    {
        ScreenFadeScript.FadeOut = true;
        PlayerPrefs.DeleteKey("Injured");
        yield return new WaitForSeconds(1);
        PlayerPrefs.SetFloat("Injured", 1);
        PlayerPrefs.Save();
        yield return new WaitForSeconds(1);
        WorldInformation.FPMode = false;
        PlayerCamFollow.HoldCam = false;
        if (!this.objectsScanned)
        {
            WorldInformation.DocumentationsStat = WorldInformation.DocumentationsStat + "\n \nNothing to report.";
        }
        PlayerPrefs.SetString("Documentations", WorldInformation.DocumentationsStat);
        Application.LoadLevel("PiriZerzek");
    }

    public virtual void Travel()
    {
        if (!this.objectsScanned)
        {
            WorldInformation.DocumentationsStat = WorldInformation.DocumentationsStat + "\n \nNothing to report.";
        }
        PlayerPrefs.SetString("Documentations", WorldInformation.DocumentationsStat);
        Application.LoadLevel("TravelScene");
    }

    public virtual void setTime()
    {
        this.terrahyptSecond = (int) Mathf.Repeat(WorldInformation.terrahyptTime, 64);
        this.terrahyptMinute = (int) Mathf.Repeat(Mathf.Floor(WorldInformation.terrahyptTime / 64), 64);
        this.terrahyptHour = (int) Mathf.Repeat(Mathf.Floor((WorldInformation.terrahyptTime / 64) / 64), 16);
    }

    public virtual void Ticker()
    {
        this.minClock = this.minClock + 1;
        //Debug.Log(PiriExposed);
        //Debug.Log(pSpeech);
        //Debug.Log(PiriWanted);
        if (this.minClock > 120)
        {
            Resources.UnloadUnusedAssets();
            this.minClock = 1;
        }
        if (WorldInformation.bigMissile1)
        {
            if (WorldInformation.bigMissile1.name.Contains("rok"))
            {
                WorldInformation.bigMissile1 = null;
            }
        }
        if (WorldInformation.bigMissile2)
        {
            if (WorldInformation.bigMissile2.name.Contains("rok"))
            {
                WorldInformation.bigMissile2 = null;
            }
        }
        if (!WorldInformation.isTraveling)
        {
            if (WorldInformation.PiriExposed > 0)
            {
                if (Vector3.Distance(PlayerInformation.instance.Pirizuka.position, this.NaughtyVicinity) > 2000)
                {
                    WorldInformation.PiriExposed = WorldInformation.PiriExposed - 1;
                }
                if (this.NaughtyVicinity.y == 88888888)
                {
                    this.NaughtyVicinity = this.transform.position;
                }
            }
            else
            {
                this.NaughtyVicinity.y = 88888888;
            }
        }
    }

    public virtual void Ticky()
    {
        WorldInformation.terrahyptTime = WorldInformation.terrahyptTime + 1;
        this.terrahyptSecond = this.terrahyptSecond + 1;
        if (this.terrahyptSecond > 63)
        {
            WorldInformation.minuteBell = true;
            this.terrahyptSecond = 0;
            this.terrahyptMinute = this.terrahyptMinute + 1;
            this.StartCoroutine(this.BellCease());
        }
        if ((this.terrahyptMinute == 32) && (this.terrahyptSecond < 2))
        {
            WorldInformation.halfhourBell = true;
            this.StartCoroutine(this.BellCease());
        }
        if (this.terrahyptMinute > 63)
        {
            WorldInformation.hourBell = true;
            this.terrahyptMinute = 0;
            this.terrahyptHour = this.terrahyptHour + 1;
            this.StartCoroutine(this.BellCease());
        }
        if ((this.terrahyptHour > 15) && (this.terrahyptHour < 16))
        {
            if (WorldInformation.minuteBell && WorldInformation.hourBell)
            {
                WorldInformation.halfraonBell = true;
            }
            this.terrahyptHour = 0;
            WorldInformation.terrahyptTime = 0;
            this.StartCoroutine(this.BellCease());
        }
        if ((this.terrahyptHour > 12) && (this.terrahyptHour < 14))
        {
            if (WorldInformation.minuteBell && WorldInformation.hourBell)
            {
                WorldInformation.halfraonBell = true;
            }
            this.StartCoroutine(this.BellCease());
        }
        if ((this.terrahyptHour > 7) && (this.terrahyptHour < 9))
        {
            if (WorldInformation.minuteBell && WorldInformation.hourBell)
            {
                WorldInformation.halfraonBell = true;
            }
            this.StartCoroutine(this.BellCease());
        }
        if ((this.terrahyptHour > 3) && (this.terrahyptHour < 5))
        {
            if (WorldInformation.minuteBell && WorldInformation.hourBell)
            {
                WorldInformation.halfraonBell = true;
            }
            this.StartCoroutine(this.BellCease());
        }
    }

    public virtual IEnumerator BellCease()
    {
        yield return new WaitForSeconds(4);
        WorldInformation.minuteBell = false;
        WorldInformation.halfhourBell = false;
        WorldInformation.hourBell = false;
        WorldInformation.halfraonBell = false;
    }

    public virtual void Awake()
    {
        WorldInformation.instance = this;
    }

    public virtual void Update()
    {
        if (this.ambColors != null)
        {
            if (this.ambColors.Length > 0)
            {
                RenderSettings.ambientLight = Color.Lerp(RenderSettings.ambientLight, this.ambColors[this.currentAmbColor], this.changeTime * Time.deltaTime);
            }
        }
        if (WorldInformation.AmbOn)
        {
            WorldInformation.AmbOn = false;
            this.NextAmbColor();
        }
        if (WorldInformation.AmbOff)
        {
            WorldInformation.AmbOff = false;
            this.PrevAmbColor();
        }
        if (WorldInformation.pSpeech)
        {
            WorldInformation.pSpeechRange = WorldInformation.pSpeechRange + (0.1f * WorldInformation.pSpeechRange);
            if (WorldInformation.pSpeechRange > 5000)
            {
                WorldInformation.pSpeechRange = 1;
            }
        }
        else
        {
            //Debug.Log(pSpeechRange);
            WorldInformation.pSpeechRange = 1;
        }
        //BubbleModel.localScale.x = pSpeechRange;
        //BubbleModel.localScale.y = pSpeechRange;
        //BubbleModel.localScale.z = pSpeechRange;
        //BubbleModel.position = PlayerInformation.instance.Pirizuka.position;
        if (WorldInformation.cheatsOn)
        {
            if (Input.GetKey("c"))
            {
                if (Input.GetKey("g"))
                {
                    WorldInformation.Godmode = true;
                    WorldInformation.cheatsOn = false;
                    WorldInformation.PiriWanted = 0;
                    Debug.Log("Godmode");
                }
            }
        }
    }

    public virtual void NextAmbColor()
    {
        if (this.currentAmbColor >= (this.ambColors.Length - 1))
        {
            this.currentAmbColor = 0;
        }
        else
        {
            if (this.currentAmbColor < 1)
            {
                this.currentAmbColor = this.currentAmbColor + 1;
            }
        }
    }

    public virtual void PrevAmbColor()
    {
        if (this.currentAmbColor >= (this.ambColors.Length - 1))
        {
            this.currentAmbColor = 0;
        }
        else
        {
            if (this.currentAmbColor > 0)
            {
                this.currentAmbColor = this.currentAmbColor - 1;
            }
        }
    }

    public virtual void SetChangeTime(float ct)
    {
        this.changeTime = ct;
    }

    public virtual void QuitZerahypt()
    {
        if (!this.objectsScanned)
        {
            WorldInformation.DocumentationsStat = WorldInformation.DocumentationsStat + "\n \nNothing to report.";
        }
        if (WorldInformation.DocumentationsStat.Length > 8000)
        {
            WorldInformation.DocumentationsPurgeNum = 0;
            WorldInformation.workInstanceNum = 1;
            WorldInformation.DocumentationsStat = null;
        }
        PlayerPrefs.SetString("Documentations", WorldInformation.DocumentationsStat);
        Application.Quit();
    }

    public WorldInformation()
    {
        this.TaxiWhereToGo = "Null";
        this.terrahyptTimeSet = 28512;
    }

    static WorldInformation()
    {
        WorldInformation.VersionID = "42.6";
        WorldInformation.GaragedVehicle = "Vessel23";
        WorldInformation.GaragedVehicleSpawnDist = 1.5f;
        WorldInformation.GaragedVehicleF1 = "Vessel23";
        WorldInformation.GaragedVehicleSpawnDistF1 = 1.5f;
        WorldInformation.GaragedVehicleF2 = "Vessel23";
        WorldInformation.GaragedVehicleSpawnDistF2 = 1.5f;
        WorldInformation.playerCar = "null";
        WorldInformation.whatBackpack = "null";
        WorldInformation.AudioVolume = 1;
        WorldInformation.Sensitivity = 60;
    }

}