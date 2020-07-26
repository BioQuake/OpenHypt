using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CallAssistance : MonoBehaviour
{
    public static bool CallingAssistance;
    public static bool DismissAssistance;
    public static bool CallingAmmo;
    public static bool DismissAmmo;
    public static bool CallingKatovari;
    public static bool CallingCargo;
    public static bool CallingCargoAgrian;
    public static bool CallingCepto;
    public static bool DismissCepto;
    public static bool CallingPiriDrone;
    public static bool DismissPiriDrone;
    public static bool IsAssisting;
    public static bool IsSnynsing;
    public static bool IsAmmoing;
    public static bool IsKatovariying;
    public static bool IsCargoing;
    public bool CargoAgrianDisabled;
    public bool CargoDisabled;
    public int CargoTimer;
    public virtual void Start()
    {
        this.InvokeRepeating("Counter", 0.73f, 1);
        if (((((((WorldInformation.instance.AreaCode == 0) || (WorldInformation.instance.AreaCode == 5)) || (WorldInformation.instance.AreaCode == 6)) || (WorldInformation.instance.AreaCode == 7)) || (WorldInformation.instance.AreaCode == 8)) || (WorldInformation.instance.AreaCode == 9)) || (WorldInformation.instance.AreaCode == 10))
        {
            this.CargoAgrianDisabled = true;
        }
        if ((((((WorldInformation.instance.AreaCode == 0) || (WorldInformation.instance.AreaCode == 6)) || (WorldInformation.instance.AreaCode == 7)) || (WorldInformation.instance.AreaCode == 8)) || (WorldInformation.instance.AreaCode == 9)) || (WorldInformation.instance.AreaCode == 10))
        {
            this.CargoDisabled = true;
        }
        CallAssistance.CallingAssistance = false;
        CallAssistance.DismissAssistance = false;
        CallAssistance.CallingAmmo = false;
        CallAssistance.DismissAmmo = false;
        CallAssistance.CallingCepto = false;
        CallAssistance.DismissCepto = false;
        CallAssistance.CallingKatovari = false;
        PiripodAI.IsActive = false;
        CallAssistance.IsAssisting = false;
    }

    public virtual void Update()
    {
        if (CallAssistance.CallingAssistance || CallAssistance.DismissAssistance)
        {
            this.Assisting();
        }
        if (CallAssistance.CallingAmmo || CallAssistance.DismissAmmo)
        {
            this.Ammoing();
        }
        if (CallAssistance.CallingKatovari)
        {
            this.Katovariying();
        }
        if (CallAssistance.CallingCargo)
        {
            this.Cargoing();
        }
        if (CallAssistance.CallingCargoAgrian)
        {
            this.StartCoroutine(this.CargoingAgrian());
        }
        if (CallAssistance.CallingCepto || CallAssistance.DismissCepto)
        {
            this.AssistingCepto();
        }
        if (CallAssistance.CallingPiriDrone || CallAssistance.DismissPiriDrone)
        {
            this.AssistingPiriDrone();
        }
    }

    public virtual void Assisting()
    {
        if (CallAssistance.CallingAssistance)
        {
            CallAssistance.CallingAssistance = false;
            CallButton.CallingOther = true;
            CallAssistance.IsAssisting = true;
        }
        if (CallAssistance.DismissAssistance)
        {
            CallAssistance.DismissAssistance = false;
            CallButton.CallingOther2 = true;
            CallAssistance.IsAssisting = false;
        }
    }

    public virtual void Ammoing()
    {
        if (CallAssistance.CallingAmmo)
        {
            CallAssistance.CallingAmmo = false;
            CallButton.CallingOther = true;
            CallAssistance.IsAmmoing = true;
        }
        if (CallAssistance.DismissAmmo)
        {
            CallAssistance.DismissAmmo = false;
            CallButton.CallingOther2 = true;
            CallAssistance.IsAmmoing = false;
        }
    }

    public virtual void Katovariying()
    {
        if (CallAssistance.CallingKatovari)
        {
            CallButton.CallingOther = true;
            CallAssistance.CallingKatovari = false;
            CallAssistance.IsKatovariying = true;
        }
    }

    public virtual void Cargoing()
    {
        if (!this.CargoDisabled)
        {
            if (CallAssistance.CallingCargo)
            {
                GameObject Prefabionaise1 = ((GameObject) Resources.Load("VesselPrefabs/" + VesselList.instance.StringOut(), typeof(GameObject))) as GameObject;
                if (Prefabionaise1.GetComponent<VehicleSensor>().LargeVessel == false)
                {
                    CallAssistance.CallingCargo = false;
                    CallButton.CallingOther = true;
                    if (VesselList.instance.StaticStringOut == null)
                    {
                        VesselList.instance.StaticStringOut = VesselList.instance.StringOut();
                        if (this.CargoTimer < 1)
                        {
                            this.CargoTimer = 60;
                        }
                    }
                    VesselList.instance.VLTF.Translate(Vector3.right * 3, Space.World);
                }
                else
                {
                    CallAssistance.CallingCargo = false;
                    CallButton.CallingOther0 = true;
                    FurtherActionScript.instance.VesselTooBig = true;
                    FurtherActionScript.instance.ShowText();
                }
            }
        }
        else
        {
            FurtherActionScript.instance.NoTransportService = true;
            FurtherActionScript.instance.ShowText();
            CallAssistance.CallingCargo = false;
            CallButton.CallingOther0 = true;
        }
    }

    public virtual IEnumerator CargoingAgrian()
    {
        if (!this.CargoAgrianDisabled)
        {
            CallAssistance.CallingCargoAgrian = false;
            CallButton.CallingOther = true;
            VesselList.instance.VLTF.Translate(Vector3.right * 3, Space.World);
            //entered = false;
            yield return new WaitForSeconds(8);
            WorldInformation.instance.Ceptobarge.SetActive(true);
            this.CargoAgrianDisabled = true;
        }
        else
        {
            FurtherActionScript.instance.NoTransportService = true;
            FurtherActionScript.instance.ShowText();
            CallAssistance.CallingCargoAgrian = false;
            CallButton.CallingOther0 = true;
            //entered = false;
        }
    }

    public virtual void AssistingCepto()
    {
        if (PiripodAI.IsActive)
        {
            CallAssistance.CallingCepto = false;
            CallAssistance.DismissCepto = true;
        }
        else
        {
            CallAssistance.CallingCepto = true;
            CallAssistance.DismissCepto = false;
        }
        if (CallAssistance.CallingCepto)
        {
            CallAssistance.CallingCepto = false;
            CallButton.CallingOther = true;
            PiripodAI.IsActive = true;
            CallAssistance.IsSnynsing = true;
        }
        if (CallAssistance.DismissCepto)
        {
            CallAssistance.DismissCepto = false;
            CallButton.CallingOther2 = true;
            PiripodAI.IsActive = false;
            CallAssistance.IsSnynsing = false;
        }
    }

    public virtual void AssistingPiriDrone()
    {
        if (CallAssistance.CallingPiriDrone)
        {
            CallAssistance.CallingPiriDrone = false;
            CallButton.CallingOther = true;
            PiriDefenseDroneAI.Assisting = true;
        }
        if (CallAssistance.DismissPiriDrone)
        {
            CallAssistance.DismissPiriDrone = false;
            CallButton.CallingOther2 = true;
            PiriDefenseDroneAI.Assisting = false;
        }
    }

    public virtual void Counter()
    {
        if (this.CargoTimer > 1)
        {
            this.CargoTimer = this.CargoTimer - 1;
        }
        if (this.CargoTimer == 1)
        {
            this.CargoTimer = 0;
            CallAssistance.IsCargoing = true;
        }
    }

}