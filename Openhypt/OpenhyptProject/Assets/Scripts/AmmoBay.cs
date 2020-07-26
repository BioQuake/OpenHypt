using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AmmoBay : MonoBehaviour
{
    public GameObject GunController;
    public GameObject Ammometer;
    public GameObject AmmoPoint;
    public bool AmmoBaySec;
    public bool AmmoBay2;
    public bool AmmoBay3;
    public bool AmmoLP;
    public bool AmmoHP;
    public bool AmmoM;
    public virtual void Start()
    {
        this.InvokeRepeating("Count", 1, 0.1f);
        if (this.AmmoLP)
        {
            this.Ammometer = AmmoIndicators.instance.LP;
        }
        if (this.AmmoHP)
        {
            this.Ammometer = AmmoIndicators.instance.HP;
        }
        if (this.AmmoM)
        {
            this.Ammometer = AmmoIndicators.instance.M;
        }
    }

    public bool IsUsingLauncher;
    public bool IsUsingGun;
    public bool CanRegenerate;
    public bool IsRegenerating;
    public int RegeneratedAmount;
    public int RegenerateTime;
    public int PrimaryAmmunition;
    public int MaxPrimaryAmmunition;
    public ItemEnum AmmoType;
    public bool broken;
    private int AmmoNum;
    private TextMesh AN;
    public virtual void Count()
    {
        if (this.broken)
        {
            return;
        }
        if (this.AmmoPoint)
        {
            if (this.PrimaryAmmunition == this.MaxPrimaryAmmunition)
            {
                this.AmmoPoint.name = "AmmoPointF" + this.AmmoType;
            }
            else
            {
                this.AmmoPoint.name = "AmmoPointE" + this.AmmoType;
            }
        }
        if (WorldInformation.playerCar == "null")
        {
            this.AmmoNum = 0;
            this.AN = (TextMesh) this.Ammometer.gameObject.GetComponent(typeof(TextMesh));
            this.AN.text = this.AmmoNum.ToString();
        }
        else
        {
            if (WorldInformation.playerCar == this.transform.parent.name)
            {
                this.AmmoNum = this.PrimaryAmmunition;
                this.AN = (TextMesh) this.Ammometer.gameObject.GetComponent(typeof(TextMesh));
                this.AN.text = this.AmmoNum.ToString();
            }
        }
        if (this.GunController.name == "broken")
        {
            if (!this.broken)
            {
                this.AmmoNum = 0;
                this.AN = (TextMesh) this.Ammometer.gameObject.GetComponent(typeof(TextMesh));
                this.AN.text = this.AmmoNum.ToString();
                this.broken = true;
            }
        }
    }

    public virtual void Update()
    {
        if (this.CanRegenerate)
        {
            if (!this.IsRegenerating)
            {
                if (this.PrimaryAmmunition == 0)
                {
                    this.StartCoroutine(this.Regenerate());
                }
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("drop"))
        {
            Item _item = ((DataContainer) other.gameObject.GetComponent(typeof(DataContainer))).item;
            if ((this.AmmoType == _item.ID) && (this.PrimaryAmmunition < this.MaxPrimaryAmmunition))
            {
                this.PrimaryAmmunition = this.PrimaryAmmunition + 1;
                if (this.IsUsingGun == true)
                {
                    ((NewgunController) this.GunController.GetComponent(typeof(NewgunController))).CanFire = true;
                }
                if (this.IsUsingLauncher == true)
                {
                    if (!this.AmmoBay2 && !this.AmmoBay3)
                    {
                        ((LauncherScript) this.GunController.GetComponent(typeof(LauncherScript))).CanFire = true;
                    }
                    if (this.AmmoBay2)
                    {
                        ((LauncherScript) this.GunController.GetComponent(typeof(LauncherScript))).CanFire2 = true;
                    }
                    if (this.AmmoBay3)
                    {
                        ((LauncherScript) this.GunController.GetComponent(typeof(LauncherScript))).CanFire3 = true;
                    }
                }
                UnityEngine.Object.Destroy(other.gameObject);
            }
        }
    }

    public virtual void ExpendedRound(int Num)
    {
        if (this.PrimaryAmmunition >= Num)
        {
            this.PrimaryAmmunition = this.PrimaryAmmunition - Num;
        }
        if (this.PrimaryAmmunition < Num)
        {
            if (this.IsUsingGun == true)
            {
                if (!this.AmmoBaySec)
                {
                    ((NewgunController) this.GunController.GetComponent(typeof(NewgunController))).CanFire = false;
                }
                else
                {
                    ((NewgunController) this.GunController.GetComponent(typeof(NewgunController))).CanFireSec = false;
                }
            }
            if (this.IsUsingLauncher == true)
            {
                if (!this.AmmoBay2 && !this.AmmoBay3)
                {
                    ((LauncherScript) this.GunController.GetComponent(typeof(LauncherScript))).CanFire = false;
                }
                if (this.AmmoBay2)
                {
                    ((LauncherScript) this.GunController.GetComponent(typeof(LauncherScript))).CanFire2 = false;
                }
                if (this.AmmoBay3)
                {
                    ((LauncherScript) this.GunController.GetComponent(typeof(LauncherScript))).CanFire3 = false;
                }
            }
        }
    }

    public virtual IEnumerator Regenerate()
    {
        this.IsRegenerating = true;
        yield return new WaitForSeconds(this.RegenerateTime);
        this.PrimaryAmmunition = this.RegeneratedAmount;
        this.IsRegenerating = false;
        if (this.IsUsingGun == true)
        {
            if (!this.AmmoBaySec)
            {
                ((NewgunController) this.GunController.GetComponent(typeof(NewgunController))).CanFire = true;
            }
            else
            {
                ((NewgunController) this.GunController.GetComponent(typeof(NewgunController))).CanFireSec = true;
            }
        }
        if (this.IsUsingLauncher == true)
        {
            if (!this.AmmoBay2 && !this.AmmoBay3)
            {
                ((LauncherScript) this.GunController.GetComponent(typeof(LauncherScript))).CanFire = true;
            }
            if (this.AmmoBay2)
            {
                ((LauncherScript) this.GunController.GetComponent(typeof(LauncherScript))).CanFire2 = true;
            }
            if (this.AmmoBay3)
            {
                ((LauncherScript) this.GunController.GetComponent(typeof(LauncherScript))).CanFire3 = true;
            }
        }
    }

    public AmmoBay()
    {
        this.RegeneratedAmount = 10;
        this.RegenerateTime = 10;
        this.PrimaryAmmunition = 10;
        this.MaxPrimaryAmmunition = 10;
    }

}