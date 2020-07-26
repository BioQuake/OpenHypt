using UnityEngine;
using System.Collections;

//Raw
public enum eMineralType
{
    Feldspar = 0,
    Cohenite = 1,
    Dappernite = 2,
    Gypsum = 3,
    Cassiterite = 4,
    Chalcocite = 5,
    Stolzite = 6,
    Argentite = 7,
    Argalite = 8,
    Sperrylite = 9,
    Augurite = 10
}

//Refined
public enum rMineralType
{
    Silicon = 0,
    Iron = 1,
    Nickel = 2,
    Tin = 3,
    Cobalt = 4,
    Copper = 5,
    Carbon = 6,
    Aluminium = 7,
    Sulfur = 8,
    Potassium = 9,
    Sodium = 10,
    Calcium = 11,
    Magnesium = 12,
    Lead = 13,
    Poshium = 14,
    Tungsten = 15,
    Silver = 16,
    Iridium = 17,
    Osmium = 18,
    Arsenic = 19,
    Platinum = 20,
    Tellurium = 21,
    Gold = 22
}

[System.Serializable]
public partial class MineralSetup : MonoBehaviour
{
    public static MineralSetup instance;
    public virtual void Awake()
    {
        MineralSetup.instance = this;
    }

    public GameObject LoadingBarTarget;
    public static string DeliverLoadAnimation;
    public static float DeliverLoadWaitTime;
    public static string RefineLoadAnimation;
    public static float RefineLoadWaitTime;
    public static string DispenseLoadAnimation;
    public static float DispenseLoadWaitTime;
    //This is to setup the amount of <A> you need to refine.
    public virtual void Start()
    {
         //									RawMineralType	NeedToRefine
        MineralRefinery.RequiredToRefine.Add((int) eMineralType.Feldspar, 2000);
        MineralRefinery.RequiredToRefine.Add((int) eMineralType.Stolzite, 800);
        MineralRefinery.RequiredToRefine.Add((int) eMineralType.Cassiterite, 400);
        MineralRefinery.RequiredToRefine.Add((int) eMineralType.Argentite, 800);
        MineralRefinery.RequiredToRefine.Add((int) eMineralType.Sperrylite, 400);
        MineralRefinery.RequiredToRefine.Add((int) eMineralType.Argalite, 800);
        MineralRefinery.RequiredToRefine.Add((int) eMineralType.Augurite, 800);
        MineralRefinery.RequiredToRefine.Add((int) eMineralType.Chalcocite, 800);
        MineralRefinery.RequiredToRefine.Add((int) eMineralType.Gypsum, 800);
        MineralRefinery.RequiredToRefine.Add((int) eMineralType.Cohenite, 2800);
        MineralRefinery.RequiredToRefine.Add((int) eMineralType.Dappernite, 60);
    }

    //This is to setup the amount of refined <B>'s you'll get from refining <A>
    public virtual void AddRefinedM(eMineralType _mineralType)
    {
        switch (_mineralType)
        {
            case eMineralType.Feldspar:
                MineralRefinery.instance.AddRefined(rMineralType.Silicon, 4);
                MineralRefinery.instance.AddRefined(rMineralType.Aluminium, 2);
                MineralRefinery.instance.AddRefined(rMineralType.Potassium, 1);
                MineralRefinery.instance.AddRefined(rMineralType.Sodium, 1);
                MineralRefinery.instance.AddRefined(rMineralType.Calcium, 1);
                MineralRefinery.instance.AddRefined(rMineralType.Magnesium, 1);
                break;
            case eMineralType.Stolzite:
                MineralRefinery.instance.AddRefined(rMineralType.Lead, 1);
                MineralRefinery.instance.AddRefined(rMineralType.Tungsten, 1);
                break;
            case eMineralType.Cassiterite:
                MineralRefinery.instance.AddRefined(rMineralType.Tin, 1);
                break;
            case eMineralType.Chalcocite:
                MineralRefinery.instance.AddRefined(rMineralType.Copper, 1);
                MineralRefinery.instance.AddRefined(rMineralType.Sulfur, 1);
                break;
            case eMineralType.Sperrylite:
                MineralRefinery.instance.AddRefined(rMineralType.Platinum, 1);
                MineralRefinery.instance.AddRefined(rMineralType.Arsenic, 1);
                break;
            case eMineralType.Argentite:
                MineralRefinery.instance.AddRefined(rMineralType.Silver, 1);
                MineralRefinery.instance.AddRefined(rMineralType.Sulfur, 1);
                break;
            case eMineralType.Argalite:
                MineralRefinery.instance.AddRefined(rMineralType.Osmium, 1);
                MineralRefinery.instance.AddRefined(rMineralType.Iridium, 1);
                break;
            case eMineralType.Augurite:
                MineralRefinery.instance.AddRefined(rMineralType.Gold, 1);
                MineralRefinery.instance.AddRefined(rMineralType.Tellurium, 1);
                break;
            case eMineralType.Gypsum:
                MineralRefinery.instance.AddRefined(rMineralType.Calcium, 1);
                MineralRefinery.instance.AddRefined(rMineralType.Sulfur, 1);
                break;
            case eMineralType.Cohenite:
                MineralRefinery.instance.AddRefined(rMineralType.Iron, 8);
                MineralRefinery.instance.AddRefined(rMineralType.Nickel, 4);
                MineralRefinery.instance.AddRefined(rMineralType.Cobalt, 1);
                MineralRefinery.instance.AddRefined(rMineralType.Carbon, 1);
                break;
            case eMineralType.Dappernite:
                MineralRefinery.instance.AddRefined(rMineralType.Poshium, 1);
                break;
            default:
                Debug.LogError("Couldnt find the configuration for " + _mineralType.ToString(), this);
                return;
                break;
        }
    }

    static MineralSetup()
    {
        MineralSetup.DeliverLoadAnimation = "MRHLoadingBarDeliver";
        MineralSetup.DeliverLoadWaitTime = 2f;
        MineralSetup.RefineLoadAnimation = "MRHLoadingBarRefine";
        MineralSetup.RefineLoadWaitTime = 60f;
        MineralSetup.DispenseLoadAnimation = "MRHLoadingBarDispense";
        MineralSetup.DispenseLoadWaitTime = 2f;
    }

}