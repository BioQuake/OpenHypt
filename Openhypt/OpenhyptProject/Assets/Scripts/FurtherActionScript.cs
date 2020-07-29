using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class FurtherActionScript : MonoBehaviour
{
    public GameObject TextGO;
    public static bool IsActive;
    public static bool FurtherActionE1;
    public static bool FurtherActionE2;
    public static bool FurtherActionLMB;
    public bool NoTravel;
    public bool NoTravelCM;
    public bool NoHitchTravel;
    public bool VesselBroken;
    public bool NewDocument;
    public bool NoDocument;
    public bool LockedOn;
    public bool Hitching;
    public bool Wanted;
    public bool Travel;
    public bool NoPass;
    public bool NoVessel;
    public bool Backpack;
    public bool HeadStuck;
    public bool UsingPhone;
    public bool VesselTooBig;
    public bool UsingTurret1;
    public bool UsingTurret2;
    public bool UsingTurret3;
    public bool PiriCeptopodOof;
    public bool PersonalDroneOof;
    public bool NoTransportService;
    public bool DocumentationsLimit;
    public bool ZerzekAlreadyPresent;
    public GameObject NoTravelText;
    public GameObject NoTravelCMText;
    public GameObject NoHitchTravelText;
    public GameObject VesselBrokenText;
    public GameObject NewDocumentText;
    public GameObject NoDocumentText;
    public GameObject LockedOnText;
    public GameObject HitchingText;
    public GameObject WantedText;
    public GameObject TravelText;
    public GameObject NoPassText;
    public GameObject BackpackText;
    public GameObject NoVesselText;
    public GameObject HeadStuckText;
    public GameObject UsingPhoneText;
    public GameObject VesselTooBigText;
    public GameObject UsingTurret1Text;
    public GameObject UsingTurret2Text;
    public GameObject UsingTurret3Text;
    public GameObject PiriCeptopodOofText;
    public GameObject PersonalDroneOofText;
    public GameObject NoTransportServiceText;
    public GameObject DocumentationsLimitText;
    public GameObject ZerzekAlreadyPresentText;
    public static FurtherActionScript instance;
    public virtual void Awake()
    {
        FurtherActionScript.instance = this;
    }

    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!CameraScript.InInterface)
            {
                if (FurtherActionScript.IsActive)
                {
                    this.TextGO.SetActive(false);
                    FurtherActionScript.IsActive = false;
                }
                else
                {
                    this.ShowText();
                    this.TextGO.SetActive(true);
                    FurtherActionScript.IsActive = true;
                }
            }
        }
        if (FurtherActionScript.IsActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FurtherActionScript.FurtherActionE1 = true;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                this.StartCoroutine(this.DelayerE());
            }
            if (Input.GetMouseButton(0))
            {
                FurtherActionScript.FurtherActionLMB = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                this.StartCoroutine(this.DelayerLMB());
            }
        }
    }

    public virtual void ShowText()
    {
        if (this.NoTravel)
        {
            this.TextGO.SetActive(false);
            this.NoTravelText.SetActive(true);
            this.NoTravelText.GetComponent<Animation>().Play();
        }
        else
        {
            this.NoTravelText.SetActive(false);
        }
        if (this.NoTravelCM)
        {
            this.TextGO.SetActive(false);
            this.NoTravelCMText.SetActive(true);
            this.NoTravelCMText.GetComponent<Animation>().Play();
        }
        else
        {
            this.NoTravelCMText.SetActive(false);
        }
        if (this.NoHitchTravel)
        {
            this.TextGO.SetActive(false);
            this.NoHitchTravelText.SetActive(true);
            this.NoHitchTravelText.GetComponent<Animation>().Play();
        }
        else
        {
            this.NoHitchTravelText.SetActive(false);
        }
        if (this.VesselBroken)
        {
            this.TextGO.SetActive(false);
            this.VesselBrokenText.SetActive(true);
            this.VesselBrokenText.GetComponent<Animation>().Play();
        }
        else
        {
            this.VesselBrokenText.SetActive(false);
        }
        if (this.NewDocument)
        {
            this.TextGO.SetActive(false);
            this.NewDocumentText.SetActive(true);
            this.NewDocumentText.GetComponent<Animation>().Play();
        }
        else
        {
            this.NewDocumentText.SetActive(false);
        }
        if (this.NoDocument)
        {
            this.TextGO.SetActive(false);
            this.NoDocumentText.SetActive(true);
            this.NoDocumentText.GetComponent<Animation>().Play();
        }
        else
        {
            this.NoDocumentText.SetActive(false);
        }
        if (this.Wanted)
        {
            this.TextGO.SetActive(false);
            this.WantedText.SetActive(true);
            this.WantedText.GetComponent<Animation>().Play();
        }
        else
        {
            this.WantedText.SetActive(false);
        }
        if (this.LockedOn)
        {
            this.TextGO.SetActive(false);
            this.LockedOnText.SetActive(true);
            this.LockedOnText.GetComponent<Animation>().Play();
        }
        else
        {
            this.LockedOnText.SetActive(false);
        }
        if (this.Hitching)
        {
            this.TextGO.SetActive(false);
            this.HitchingText.SetActive(true);
            this.HitchingText.GetComponent<Animation>().Play();
        }
        else
        {
            this.HitchingText.SetActive(false);
        }
        if (this.Travel)
        {
            this.TextGO.SetActive(false);
            this.TravelText.SetActive(true);
            this.TravelText.GetComponent<Animation>().Play();
        }
        else
        {
            this.TravelText.SetActive(false);
        }
        if (this.NoVessel)
        {
            this.TextGO.SetActive(false);
            this.NoVesselText.SetActive(true);
            this.NoVesselText.GetComponent<Animation>().Play();
        }
        else
        {
            this.NoVesselText.SetActive(false);
        }
        if (this.Backpack)
        {
            this.TextGO.SetActive(false);
            this.BackpackText.SetActive(true);
            this.BackpackText.GetComponent<Animation>().Play();
        }
        else
        {
            this.BackpackText.SetActive(false);
        }
        if (this.NoPass)
        {
            this.TextGO.SetActive(false);
            this.NoPassText.SetActive(true);
            this.NoPassText.GetComponent<Animation>().Play();
        }
        else
        {
            this.NoPassText.SetActive(false);
        }
        if (this.HeadStuck)
        {
            this.TextGO.SetActive(false);
            this.HeadStuckText.SetActive(true);
            this.HeadStuckText.GetComponent<Animation>().Play();
        }
        else
        {
            this.HeadStuckText.SetActive(false);
        }
        if (this.UsingPhone)
        {
            this.TextGO.SetActive(false);
            this.UsingPhoneText.SetActive(true);
            this.UsingPhoneText.GetComponent<Animation>().Play();
        }
        else
        {
            this.UsingPhoneText.SetActive(false);
        }
        if (this.VesselTooBig)
        {
            this.TextGO.SetActive(false);
            this.VesselTooBigText.SetActive(true);
            this.VesselTooBigText.GetComponent<Animation>().Play();
        }
        else
        {
            this.VesselTooBigText.SetActive(false);
        }
        if (this.UsingTurret1)
        {
            this.TextGO.SetActive(false);
            this.UsingTurret1Text.SetActive(true);
            this.UsingTurret1Text.GetComponent<Animation>().Play();
        }
        else
        {
            this.UsingTurret1Text.SetActive(false);
        }
        if (this.UsingTurret2)
        {
            this.TextGO.SetActive(false);
            this.UsingTurret2Text.SetActive(true);
            this.UsingTurret2Text.GetComponent<Animation>().Play();
        }
        else
        {
            this.UsingTurret2Text.SetActive(false);
        }
        if (this.UsingTurret3)
        {
            this.TextGO.SetActive(false);
            this.UsingTurret3Text.SetActive(true);
            this.UsingTurret3Text.GetComponent<Animation>().Play();
        }
        else
        {
            this.UsingTurret3Text.SetActive(false);
        }
        if (this.PiriCeptopodOof)
        {
            this.TextGO.SetActive(false);
            this.PiriCeptopodOofText.SetActive(true);
            this.PiriCeptopodOofText.GetComponent<Animation>().Play();
        }
        else
        {
            this.PiriCeptopodOofText.SetActive(false);
        }
        if (this.PersonalDroneOof)
        {
            this.TextGO.SetActive(false);
            this.PersonalDroneOofText.SetActive(true);
            this.PersonalDroneOofText.GetComponent<Animation>().Play();
        }
        else
        {
            this.PersonalDroneOofText.SetActive(false);
        }
        if (this.NoTransportService)
        {
            this.TextGO.SetActive(false);
            this.NoTransportServiceText.SetActive(true);
            this.NoTransportServiceText.GetComponent<Animation>().Play();
        }
        else
        {
            this.NoTransportServiceText.SetActive(false);
        }
        if (this.DocumentationsLimit)
        {
            this.TextGO.SetActive(false);
            this.DocumentationsLimitText.SetActive(true);
            this.DocumentationsLimitText.GetComponent<Animation>().Play();
        }
        else
        {
            this.DocumentationsLimitText.SetActive(false);
        }
        if (this.ZerzekAlreadyPresent)
        {
            this.TextGO.SetActive(false);
            this.ZerzekAlreadyPresentText.SetActive(true);
            this.ZerzekAlreadyPresentText.GetComponent<Animation>().Play();
        }
        else
        {
            this.ZerzekAlreadyPresentText.SetActive(false);
        }
        this.NoTravel = false;
        this.NoTravelCM = false;
        this.NoHitchTravel = false;
        this.VesselBroken = false;
        this.NewDocument = false;
        this.NoDocument = false;
        this.LockedOn = false;
        this.Hitching = false;
        this.Wanted = false;
        this.Travel = false;
        this.NoPass = false;
        this.NoVessel = false;
        this.Backpack = false;
        this.HeadStuck = false;
        this.UsingPhone = false;
        this.VesselTooBig = false;
        this.UsingTurret1 = false;
        this.UsingTurret2 = false;
        this.UsingTurret3 = false;
        this.PiriCeptopodOof = false;
        this.PersonalDroneOof = false;
        this.NoTransportService = false;
        this.DocumentationsLimit = false;
        this.ZerzekAlreadyPresent = false;
    }

    public virtual IEnumerator DelayerE()
    {
        yield return new WaitForSeconds(0.1f);
        FurtherActionScript.FurtherActionE1 = false;
        this.TextGO.SetActive(false);
        FurtherActionScript.IsActive = false;
    }

    public virtual IEnumerator DelayerLMB()
    {
        yield return new WaitForSeconds(0.1f);
        FurtherActionScript.FurtherActionLMB = false;
        this.TextGO.SetActive(false);
        FurtherActionScript.IsActive = false;
    }

}