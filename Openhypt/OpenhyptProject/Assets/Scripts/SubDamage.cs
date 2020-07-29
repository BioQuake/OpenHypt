using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SubDamage : MonoBehaviour
{
    public float Health;
    public float StaticHealth;
    public float HealthThreshold;
    public int TargetCode;
    public float ThisDamage;
    public float SendDamage;
    public int BreakDamageSend;
    private bool once;
    private bool Honce;
    private bool Donce;
    private bool HeavyHit;
    public bool IntegratedPart;
    public bool isGun;
    public bool isSecGun;
    public bool isVolleyGun;
    public bool isLauncher;
    public int gunNumber;
    public bool RegisterHeavyHit;
    public bool SkipThreatCount;
    public bool IsCivilian;
    public bool IsMachine;
    public bool ResetDrag;
    public bool ResetGravity;
    public GameObject AI;
    public string AIName;
    public PlayerMotionAnimator Piri;
    public VehicleDamage ParentDamage;
    public NPCGun GunScript;
    public GameObject otherGunScript;
    public NewgunController PlayerGunScript;
    public LauncherScript PlayerLauncherScript;
    public MissileScript missileScript;
    public bool NoArmor;
    public bool LightArmor;
    public bool HeavyArmor;
    public bool ExtraThiccArmor;
    public bool UtsargalineArmor;
    public GameObject BrokenSound;
    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 1, 0.2f);
        if (((!this.LightArmor && !this.HeavyArmor) && !this.ExtraThiccArmor) && !this.UtsargalineArmor)
        {
            this.NoArmor = true;
        }
        this.StaticHealth = this.Health;
        this.HealthThreshold = this.Health * 0.33f;
        if (this.IsCivilian)
        {
            if ((this.TargetCode == 3) && (WorldInformation.instance.AreaCode == 1))
            {
                this.TargetCode = 0;
            }
        }
    }

    public virtual IEnumerator DamageIn(float Damage, int DamageCode, bool PShot)
    {
        if (this.Donce)
        {
            yield break;
        }
        if (!this.IntegratedPart)
        {
            if (!this.Piri)
            {
                if (this.ParentDamage)
                {
                    if (this.ParentDamage.Health < 1)
                    {
                        yield break;
                    }
                }
            }
            if (this.HeavyHit && this.RegisterHeavyHit)
            {
                //this.AI.GetComponent(this.AIName).Emergency = true;
                ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "Emergency", true);
            }
            if (this.NoArmor == true)
            {
                if ((DamageCode == 1) && (this.Health > 0))
                {
                    this.ThisDamage = Damage;
                    this.SendDamage = Damage;
                    if (this.Health < (Damage + 1))
                    {
                        this.ThisDamage = this.ThisDamage - this.Health;
                        this.SendDamage = this.SendDamage - this.ThisDamage;
                    }
                    DamageCounter.instance.ShowDamage(this.SendDamage, this.TargetCode);
                }
                this.Health = this.Health - Damage;
                if (Damage > 24)
                {
                    this.HeavyHit = true;
                }
            }
            if (this.LightArmor == true)
            {
                if (PShot && (this.Health > 0))
                {
                    this.ThisDamage = Damage * 0.5f;
                    this.SendDamage = Damage * 0.5f;
                    if (this.Health < (Damage * 0.5f))
                    {
                        this.ThisDamage = this.ThisDamage - this.Health;
                        this.SendDamage = this.SendDamage - this.ThisDamage;
                    }
                    DamageCounter.instance.ShowDamage(this.SendDamage, this.TargetCode);
                }
                this.Health = this.Health - (Damage * 0.5f);
                if (Damage > 24)
                {
                    this.HeavyHit = true;
                }
            }
            if (this.HeavyArmor == true)
            {
                if (PShot && (this.Health > 0))
                {
                    this.ThisDamage = Damage * 0.25f;
                    this.SendDamage = Damage * 0.25f;
                    if (this.Health < (Damage * 0.25f))
                    {
                        this.ThisDamage = this.ThisDamage - this.Health;
                        this.SendDamage = this.SendDamage - this.ThisDamage;
                    }
                    DamageCounter.instance.ShowDamage(this.SendDamage, this.TargetCode);
                }
                this.Health = this.Health - (Damage * 0.25f);
                if (Damage > 24)
                {
                    this.HeavyHit = true;
                }
            }
            if (this.ExtraThiccArmor == true)
            {
                if (PShot && (this.Health > 0))
                {
                    this.ThisDamage = Damage * 0.125f;
                    this.SendDamage = Damage * 0.125f;
                    if (this.Health < (Damage * 0.125f))
                    {
                        this.ThisDamage = this.ThisDamage - this.Health;
                        this.SendDamage = this.SendDamage - this.ThisDamage;
                    }
                    DamageCounter.instance.ShowDamage(this.SendDamage, this.TargetCode);
                }
                this.Health = this.Health - (Damage * 0.125f);
                if (Damage > 24)
                {
                    this.HeavyHit = true;
                }
            }
            if (this.UtsargalineArmor == true)
            {
                if (PShot && (this.Health > 0))
                {
                    this.ThisDamage = Damage * 0.01f;
                    this.SendDamage = Damage * 0.01f;
                    if (this.Health < (Damage * 0.01f))
                    {
                        this.ThisDamage = this.ThisDamage - this.Health;
                        this.SendDamage = this.SendDamage - this.ThisDamage;
                    }
                    DamageCounter.instance.ShowDamage(this.SendDamage, this.TargetCode);
                }
                this.Health = this.Health - (Damage * 0.01f);
                if (Damage > 24)
                {
                    this.HeavyHit = true;
                }
            }
            if (!this.SkipThreatCount)
            {
                //---------------------------------------------------------
                if (this.TargetCode == 2)
                {
                    if ((DamageCode == 1) && PShot)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            AgrianNetwork.TC1CriminalLevel = (int) (AgrianNetwork.TC1CriminalLevel + (Damage * 5));
                        }
                        else
                        {
                            AgrianNetwork.TC1CriminalLevel = (int) (AgrianNetwork.TC1CriminalLevel + this.StaticHealth);
                        }
                    }
                    if (DamageCode == 3)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            AgrianNetwork.TC3CriminalLevel = (int) (AgrianNetwork.TC3CriminalLevel + (Damage * 5));
                        }
                        else
                        {
                            AgrianNetwork.TC3CriminalLevel = (int) (AgrianNetwork.TC3CriminalLevel + this.StaticHealth);
                        }
                    }
                    if (DamageCode == 4)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            AgrianNetwork.TC4CriminalLevel = (int) (AgrianNetwork.TC4CriminalLevel + (Damage * 5));
                        }
                        else
                        {
                            AgrianNetwork.TC4CriminalLevel = (int) (AgrianNetwork.TC4CriminalLevel + this.StaticHealth);
                        }
                    }
                    if (DamageCode == 5)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            AgrianNetwork.TC5CriminalLevel = (int) (AgrianNetwork.TC5CriminalLevel + (Damage * 5));
                        }
                        else
                        {
                            AgrianNetwork.TC5CriminalLevel = (int) (AgrianNetwork.TC5CriminalLevel + this.StaticHealth);
                        }
                    }
                    if (DamageCode == 6)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            AgrianNetwork.TC6CriminalLevel = (int) (AgrianNetwork.TC6CriminalLevel + (Damage * 5));
                        }
                        else
                        {
                            AgrianNetwork.TC6CriminalLevel = (int) (AgrianNetwork.TC6CriminalLevel + this.StaticHealth);
                        }
                    }
                    if (DamageCode == 7)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            AgrianNetwork.TC7CriminalLevel = (int) (AgrianNetwork.TC7CriminalLevel + (Damage * 5));
                        }
                        else
                        {
                            AgrianNetwork.TC7CriminalLevel = (int) (AgrianNetwork.TC7CriminalLevel + this.StaticHealth);
                        }
                    }
                    if (DamageCode == 8)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            AgrianNetwork.TC8CriminalLevel = (int) (AgrianNetwork.TC8CriminalLevel + (Damage * 5));
                        }
                        else
                        {
                            AgrianNetwork.TC8CriminalLevel = (int) (AgrianNetwork.TC8CriminalLevel + this.StaticHealth);
                        }
                    }
                    if (DamageCode == 9)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            AgrianNetwork.TC9CriminalLevel = (int) (AgrianNetwork.TC9CriminalLevel + (Damage * 5));
                        }
                        else
                        {
                            AgrianNetwork.TC9CriminalLevel = (int) (AgrianNetwork.TC9CriminalLevel + this.StaticHealth);
                        }
                    }
                }
                //---------------------------------------------------------
                if (this.TargetCode == 3)
                {
                    if (DamageCode == 0)
                    {
                        if (TerrahyptianNetwork.TC0aCriminalLevel < 11)
                        {
                            TerrahyptianNetwork.TC0aCriminalLevel = 90;
                        }
                    }
                    if ((DamageCode == 1) && PShot)
                    {
                        if (TerrahyptianNetwork.TC1CriminalLevel < 11)
                        {
                            TerrahyptianNetwork.TC1CriminalLevel = 90;
                        }
                    }
                    if (DamageCode == 4)
                    {
                        if (TerrahyptianNetwork.TC4CriminalLevel < 11)
                        {
                            TerrahyptianNetwork.TC4CriminalLevel = 90;
                        }
                    }
                    if (DamageCode == 5)
                    {
                        if (TerrahyptianNetwork.TC5CriminalLevel < 11)
                        {
                            TerrahyptianNetwork.TC5CriminalLevel = 90;
                        }
                    }
                    if (DamageCode == 6)
                    {
                        if (TerrahyptianNetwork.TC6CriminalLevel < 11)
                        {
                            TerrahyptianNetwork.TC6CriminalLevel = 90;
                        }
                    }
                    if (DamageCode == 7)
                    {
                        if (TerrahyptianNetwork.TC7CriminalLevel < 11)
                        {
                            TerrahyptianNetwork.TC7CriminalLevel = 90;
                        }
                    }
                }
                //---------------------------------------------------------
                if (this.TargetCode == 5)
                {
                    if (this.AI)
                    {
                        SlavuicNetwork.instance.PriorityWaypoint.position = this.transform.position;
                        if (DamageCode == 0)
                        {
                            //this.AI.GetComponent(this.AIName).PissedAtTC0a = ((int) this.AI.GetComponent(this.AIName).PissedAtTC0a) + 3;
                            int tmp = ReflectionUtils.GetFieldValue<int>(AI.GetComponent(AIName), AIName, "PissedAtTC0a") + 3;
                            ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC0a", tmp);
                        }
                        if ((DamageCode == 1) && PShot)
                        {
                            SlavuicNetwork.target = PlayerInformation.instance.PiriTarget;
                            //this.AI.GetComponent(this.AIName).PissedAtTC1 = ((int) this.AI.GetComponent(this.AIName).PissedAtTC1) + 3;
                            int tmp = ReflectionUtils.GetFieldValue<int>(AI.GetComponent(AIName), AIName, "PissedAtTC1") + 3;
                            ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC1", tmp);
                        }
                        if ((DamageCode == 3) && this.IsMachine)
                        {
                            //this.AI.GetComponent(this.AIName).PissedAtTC3 = ((int) this.AI.GetComponent(this.AIName).PissedAtTC3) + 3;
                            int tmp = ReflectionUtils.GetFieldValue<int>(AI.GetComponent(AIName), AIName, "PissedAtTC3") + 3;
                            ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC3", tmp);
                        }
                        if (DamageCode == 4)
                        {
                            //this.AI.GetComponent(this.AIName).PissedAtTC4 = ((int) this.AI.GetComponent(this.AIName).PissedAtTC4) + 3;
                            int tmp = ReflectionUtils.GetFieldValue<int>(AI.GetComponent(AIName), AIName, "PissedAtTC4") + 3;
                            ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC4", tmp);
                        }
                        if (DamageCode == 7)
                        {
                            //this.AI.GetComponent(this.AIName).PissedAtTC7 = ((int) this.AI.GetComponent(this.AIName).PissedAtTC7) + 3;
                            int tmp = ReflectionUtils.GetFieldValue<int>(AI.GetComponent(AIName), AIName, "PissedAtTC7") + 3;
                            ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC7", tmp);
                        }
                    }
                    if ((this.Health < 1) && !this.Honce)
                    {
                        this.Honce = true;
                        if (DamageCode == 0)
                        {
                            SlavuicNetwork.TC0aDeathRow = 240;
                        }
                        if ((DamageCode == 1) && PShot)
                        {
                            SlavuicNetwork.TC1DeathRow = SlavuicNetwork.TC1DeathRow + 240;
                            if (this.StaticHealth < 200)
                            {
                                SlavuicNetwork.CasualtiesFromTC1 = SlavuicNetwork.CasualtiesFromTC1 + 1;
                            }
                            else
                            {
                                SlavuicNetwork.CasualtiesFromTC1 = 1;
                                SlavuicNetwork.TC1DeathRow = 700;
                            }
                        }
                        if (DamageCode == 3)
                        {
                            SlavuicNetwork.TC3DeathRow = 240;
                        }
                        if (DamageCode == 4)
                        {
                            SlavuicNetwork.TC4DeathRow = 240;
                        }
                        if (DamageCode == 6)
                        {
                            SlavuicNetwork.TC6DeathRow = 240;
                        }
                        if (DamageCode == 7)
                        {
                            SlavuicNetwork.TC7DeathRow = 240;
                        }
                    }
                }
                //---------------------------------------------------------
                if (this.TargetCode == 6)
                {
                    if (DamageCode == 0)
                    {
                        AbiaSyndicateNetwork.TC0aCriminalLevel = AbiaSyndicateNetwork.TC0aCriminalLevel + 10;
                    }
                    if (DamageCode == 1)
                    {
                        AbiaSyndicateNetwork.TC1CriminalLevel = AbiaSyndicateNetwork.TC1CriminalLevel + 10;
                    }
                    if (DamageCode == 2)
                    {
                        AbiaSyndicateNetwork.TC2CriminalLevel = AbiaSyndicateNetwork.TC2CriminalLevel + 10;
                    }
                    if (DamageCode == 3)
                    {
                        AbiaSyndicateNetwork.TC3CriminalLevel = AbiaSyndicateNetwork.TC3CriminalLevel + 10;
                    }
                    if (DamageCode == 4)
                    {
                        AbiaSyndicateNetwork.TC4CriminalLevel = AbiaSyndicateNetwork.TC4CriminalLevel + 10;
                    }
                    if (DamageCode == 5)
                    {
                        AbiaSyndicateNetwork.TC5CriminalLevel = AbiaSyndicateNetwork.TC5CriminalLevel + 10;
                    }
                    if (PShot)
                    {
                        if (DamageCode == 6)
                        {
                            WorldInformation.PiriExposed = 60;
                            AbiaSyndicateNetwork.TC1CriminalLevel = AbiaSyndicateNetwork.TC1CriminalLevel + 10;
                        }
                    }
                    if (DamageCode == 7)
                    {
                        AbiaSyndicateNetwork.TC7CriminalLevel = AbiaSyndicateNetwork.TC7CriminalLevel + 10;
                    }
                    if ((this.Health < 1) && !this.Honce)
                    {
                        AbiaSyndicateNetwork.Alert = true;
                    }
                }
                //---------------------------------------------------------
                if (this.TargetCode == 7)
                {
                    if (DamageCode == 0)
                    {
                        MevNavNetwork.TC0aDeathRow = 60;
                    }
                    if (DamageCode == 2)
                    {
                        MevNavNetwork.TC2DeathRow = 60;
                    }
                    if (DamageCode == 3)
                    {
                        MevNavNetwork.TC3DeathRow = 600;
                    }
                    if (DamageCode == 4)
                    {
                        MevNavNetwork.TC4DeathRow = 60;
                    }
                    if (DamageCode == 5)
                    {
                        MevNavNetwork.TC5DeathRow = 600;
                    }
                    if (this.AI)
                    {
                        if ((this.StaticHealth == 128) && (this.Health < 42))
                        {
                            //this.AI.GetComponent(this.AIName).Emergency = true;
                            ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "Emergency", true);
                        }
                        if ((this.StaticHealth == 64) && (this.Health < 21))
                        {
                            //this.AI.GetComponent(this.AIName).Emergency = true;
                            ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "Emergency", true);
                        }
                        if ((this.StaticHealth == 32) && (this.Health < 12))
                        {
                            //this.AI.GetComponent(this.AIName).Emergency = true;
                            ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "Emergency", true);
                        }
                    }
                    if (this.Health < 1)
                    {
                        if ((DamageCode == 1) && PShot)
                        {
                            if (MevNavNetwork.TC1DeathRow < 240)
                            {
                                MevNavNetwork.TC1DeathRow = 240;
                            }
                        }
                    }
                }
                //---------------------------------------------------------
                if (this.TargetCode == 9)
                {
                    if (DamageCode == 0)
                    {
                        if (DutvutanianNetwork.TC0aCriminalLevel < 240)
                        {
                            DutvutanianNetwork.TC0aCriminalLevel = DutvutanianNetwork.TC0aCriminalLevel + 60;
                        }
                    }
                    if ((DamageCode == 1) && PShot)
                    {
                        if (DutvutanianNetwork.TC1CriminalLevel < 240)
                        {
                            DutvutanianNetwork.TC1CriminalLevel = DutvutanianNetwork.TC1CriminalLevel + 60;
                        }
                    }
                    if (DamageCode == 2)
                    {
                        if (DutvutanianNetwork.TC2CriminalLevel < 240)
                        {
                            DutvutanianNetwork.TC2CriminalLevel = DutvutanianNetwork.TC2CriminalLevel + 60;
                        }
                    }
                    if (DamageCode == 3)
                    {
                        if (DutvutanianNetwork.TC3CriminalLevel < 240)
                        {
                            DutvutanianNetwork.TC3CriminalLevel = DutvutanianNetwork.TC3CriminalLevel + 60;
                        }
                    }
                    if (DamageCode == 4)
                    {
                        if (DutvutanianNetwork.TC4CriminalLevel < 240)
                        {
                            DutvutanianNetwork.TC4CriminalLevel = DutvutanianNetwork.TC4CriminalLevel + 60;
                        }
                    }
                    if (DamageCode == 5)
                    {
                        if (DutvutanianNetwork.TC5CriminalLevel < 240)
                        {
                            DutvutanianNetwork.TC5CriminalLevel = DutvutanianNetwork.TC5CriminalLevel + 60;
                        }
                    }
                    if (DamageCode == 6)
                    {
                        if (DutvutanianNetwork.TC6CriminalLevel < 240)
                        {
                            DutvutanianNetwork.TC6CriminalLevel = DutvutanianNetwork.TC6CriminalLevel + 60;
                        }
                    }
                    if (DamageCode == 7)
                    {
                        if (DutvutanianNetwork.TC7CriminalLevel < 240)
                        {
                            DutvutanianNetwork.TC7CriminalLevel = DutvutanianNetwork.TC7CriminalLevel + 60;
                        }
                    }
                    if (DamageCode == 8)
                    {
                        if (DutvutanianNetwork.TC8CriminalLevel < 240)
                        {
                            DutvutanianNetwork.TC8CriminalLevel = DutvutanianNetwork.TC8CriminalLevel + 60;
                        }
                    }
                }
            }
            //---------------------------------------------------------
            if ((this.Health < 1) && (this.once == false))
            {
                this.once = true;
                if (this.Piri)
                {
                    this.StartCoroutine(this.Piri.Hurt());
                }
                if (this.ParentDamage)
                {
                    this.ParentDamage.DamageIn(this.BreakDamageSend, DamageCode, 0, PShot);
                }
                if (this.GunScript)
                {
                    UnityEngine.Object.Destroy(this.GunScript);
                }
                if (this.otherGunScript)
                {
                    UnityEngine.Object.Destroy(this.otherGunScript);
                }
                if (this.missileScript)
                {
                    this.missileScript.Disable();
                }
                if (this.BrokenSound)
                {
                    GameObject TheThing1 = UnityEngine.Object.Instantiate(this.BrokenSound, this.transform.position, this.transform.rotation);
                    TheThing1.transform.parent = this.gameObject.transform;
                }
                if (this.ResetDrag)
                {
                    this.GetComponent<Rigidbody>().drag = 0.05f;
                    this.GetComponent<Rigidbody>().angularDrag = 0.05f;
                }
                if (this.ResetGravity)
                {
                    this.GetComponent<Rigidbody>().useGravity = true;
                }
                this.transform.name = "broken";
            }
            yield return new WaitForSeconds(1.6f);
            this.HeavyHit = false;
        }
        else
        {
            if (this.isGun || this.isLauncher)
            {
                if (this.NoArmor == true)
                {
                    if (PShot && (this.Health > 0))
                    {
                        this.ThisDamage = Damage;
                        this.SendDamage = Damage;
                        if (this.Health < (Damage + 1))
                        {
                            this.ThisDamage = this.ThisDamage - this.Health;
                            this.SendDamage = this.SendDamage - this.ThisDamage;
                        }
                        DamageCounter.instance.ShowDamage(this.SendDamage, this.TargetCode);
                    }
                    this.Health = this.Health - Damage;
                }
                if (this.LightArmor == true)
                {
                    if (PShot && (this.Health > 0))
                    {
                        this.ThisDamage = Damage * 0.5f;
                        this.SendDamage = Damage * 0.5f;
                        if (this.Health < (Damage * 0.5f))
                        {
                            this.ThisDamage = this.ThisDamage - this.Health;
                            this.SendDamage = this.SendDamage - this.ThisDamage;
                        }
                        DamageCounter.instance.ShowDamage(this.SendDamage, this.TargetCode);
                    }
                    this.Health = this.Health - (Damage * 0.5f);
                }
                if (this.HeavyArmor == true)
                {
                    if (PShot && (this.Health > 0))
                    {
                        this.ThisDamage = Damage * 0.25f;
                        this.SendDamage = Damage * 0.25f;
                        if (this.Health < (Damage * 0.25f))
                        {
                            this.ThisDamage = this.ThisDamage - this.Health;
                            this.SendDamage = this.SendDamage - this.ThisDamage;
                        }
                        DamageCounter.instance.ShowDamage(this.SendDamage, this.TargetCode);
                    }
                    this.Health = this.Health - (Damage * 0.25f);
                }
                if (this.ExtraThiccArmor == true)
                {
                    if (PShot && (this.Health > 0))
                    {
                        this.ThisDamage = Damage * 0.125f;
                        this.SendDamage = Damage * 0.125f;
                        if (this.Health < (Damage * 0.125f))
                        {
                            this.ThisDamage = this.ThisDamage - this.Health;
                            this.SendDamage = this.SendDamage - this.ThisDamage;
                        }
                        DamageCounter.instance.ShowDamage(this.SendDamage, this.TargetCode);
                    }
                    this.Health = this.Health - (Damage * 0.125f);
                }
                if (this.UtsargalineArmor == true)
                {
                    if (PShot && (this.Health > 0))
                    {
                        this.ThisDamage = Damage * 0.01f;
                        this.SendDamage = Damage * 0.01f;
                        if (this.Health < (Damage * 0.01f))
                        {
                            this.ThisDamage = this.ThisDamage - this.Health;
                            this.SendDamage = this.SendDamage - this.ThisDamage;
                        }
                        DamageCounter.instance.ShowDamage(this.SendDamage, this.TargetCode);
                    }
                    this.Health = this.Health - (Damage * 0.01f);
                }
                if ((this.Health < 1) && (this.Donce == false))
                {
                    if (this.isGun)
                    {
                        if (this.PlayerGunScript.gunUsed == this.gunNumber)
                        {
                            if (this.isVolleyGun)
                            {
                                this.PlayerGunScript.VolleyBroken = true;
                            }
                            else
                            {
                                this.PlayerGunScript.Broken = true;
                                if (this.isSecGun)
                                {
                                    this.PlayerGunScript.SecBroken = true;
                                }
                            }
                        }
                    }
                    if (this.isLauncher)
                    {
                        this.PlayerLauncherScript.Broken = true;
                    }
                    this.Donce = true;
                }
            }
            else
            {
                this.ParentDamage.DamageIn(Damage, DamageCode, 0, PShot);
            }
        }
    }

    public virtual void Tick()
    {
        if (this.ParentDamage)
        {
            if (this.ParentDamage.IsInside)
            {
                if (this.ParentDamage.Health < 1)
                {
                    if (this.PlayerGunScript)
                    {
                        this.PlayerGunScript.Broken = true;
                    }
                    return;
                }
                if (this.isGun || this.isLauncher)
                {
                    if (this.Health < 1)
                    {
                        if (this.PlayerGunScript.gunUsed == this.gunNumber)
                        {
                            IndicatorScript.GunIsDamaged = true;
                        }
                        //Debug.Log("IsBroken1");
                        if (this.isGun)
                        {
                            if (this.PlayerGunScript.gunUsed == this.gunNumber)
                            {
                                if (this.isVolleyGun)
                                {
                                    this.PlayerGunScript.VolleyBroken = true;
                                }
                                else
                                {
                                    if (this.isSecGun)
                                    {
                                        this.PlayerGunScript.SecBroken = true;
                                    }
                                    else
                                    {
                                        this.PlayerGunScript.Broken = true;
                                    }
                                }
                            }
                        }
                        if (this.isLauncher)
                        {
                            this.PlayerLauncherScript.Broken = true;
                        }
                    }
                    else
                    {
                        if (this.isGun)
                        {
                            if (this.PlayerGunScript.gunUsed == this.gunNumber)
                            {
                                if (!this.PlayerGunScript.VolleyBroken && !this.PlayerGunScript.SecBroken)
                                {
                                    IndicatorScript.GunIsDamaged = false;
                                }
                                this.PlayerGunScript.Broken = false;
                            }
                        }
                    }
                }
            }
        }
    }

    public virtual void OnJointBreak(float breakForce)
    {
        if (this.ParentDamage)
        {
            this.ParentDamage.DamageIn(this.BreakDamageSend, 0, 0, false);
        }
        if (this.BrokenSound)
        {
            GameObject TheThing0 = UnityEngine.Object.Instantiate(this.BrokenSound, this.transform.position, this.transform.rotation);
            TheThing0.transform.parent = this.gameObject.transform;
        }
        if (this.ResetDrag)
        {
            this.GetComponent<Rigidbody>().drag = 0.05f;
            this.GetComponent<Rigidbody>().angularDrag = 0.05f;
        }
        if (this.ResetGravity)
        {
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    public SubDamage()
    {
        this.Health = 10;
        this.StaticHealth = 10;
        this.HealthThreshold = 10;
        this.BreakDamageSend = 2048;
        this.AIName = "PersonMcPersonface";
    }

}