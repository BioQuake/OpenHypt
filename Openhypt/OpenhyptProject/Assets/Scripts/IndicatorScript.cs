using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class IndicatorScript : MonoBehaviour
{
    public bool isDamage;
    public static bool VehicleIsDamaged;
    public bool isGunDamage;
    public static bool GunIsDamaged;
    public bool isParking;
    public static bool ParkingBrakeOn;
    public bool isCivilmode;
    public static bool CivilmodeOn;
    public bool isVSmode;
    public static bool VSmodeOn;
    public bool isCargo;
    public static bool CargoIsFull;
    public static bool IsInsideVehicle;
    public bool Tick;
    public virtual void Start()
    {
        IndicatorScript.VehicleIsDamaged = false;
        IndicatorScript.GunIsDamaged = false;
        IndicatorScript.ParkingBrakeOn = false;
        IndicatorScript.CivilmodeOn = false;
        IndicatorScript.VSmodeOn = false;
        IndicatorScript.IsInsideVehicle = false;
    }

    public virtual void Update()
    {
        if (!IndicatorScript.IsInsideVehicle)
        {
            return;
        }
        if (this.isDamage)
        {
            if (IndicatorScript.VehicleIsDamaged)
            {
                this.StartCoroutine(this.Blinker());
            }
        }
        if (this.isGunDamage)
        {
            if (IndicatorScript.GunIsDamaged)
            {
                this.StartCoroutine(this.Blinker());
            }
        }
        if (this.isParking)
        {
            if (IndicatorScript.ParkingBrakeOn)
            {
                this.StartCoroutine(this.Blinker());
            }
        }
        if (this.isCivilmode)
        {
            if (IndicatorScript.CivilmodeOn)
            {
                this.StartCoroutine(this.Blinker());
            }
        }
        if (this.isVSmode)
        {
            if (IndicatorScript.VSmodeOn)
            {
                this.StartCoroutine(this.Blinker());
            }
        }
        if (this.isCargo)
        {
            if (IndicatorScript.CargoIsFull)
            {
                this.StartCoroutine(this.Blinker());
            }
        }
    }

    public virtual IEnumerator Blinker()
    {
        if (this.Tick)
        {
            yield break;
        }
        this.Tick = true;
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<Renderer>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<Renderer>().enabled = false;
        this.Tick = false;
    }

}