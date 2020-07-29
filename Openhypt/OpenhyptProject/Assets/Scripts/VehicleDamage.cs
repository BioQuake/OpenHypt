using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class VehicleDamage : MonoBehaviour
{
    public float Health;
    public float StaticHealth;
    public float HealthThreshold;
    public bool HighThreshold;
    public float HurtThreshold;
    public int TargetCode;
    public float ThisDamage;
    public float SendDamage;
    public float lastVelocity;
    public float Gs;
    public float Threshold;
    public AnimationCurve scalarForceCurve;
    private bool once;
    private bool Honce;
    public bool forceOnce;
    private bool hurtOnce;
    private bool DetOnce;
    private bool SpaceOnce;
    private bool HeavyHit;
    private bool ExtraThiccHit;
    public bool PlayerControlled;
    public VehicleDamage OtherDamage;
    public NewgunController PlayerGunScript;
    public bool CanRegenerate;
    public float RegenAmount;
    public bool StartFromOne;
    public bool StartFromRandom;
    public bool RestartingFromOne;
    public bool RegisterTouch;
    public bool RegisterForce;
    public bool useScalarForce;
    public bool SkipTargetForce;
    public bool RegisterHit;
    public bool RegisterHitExtra;
    public bool RegisterHeavyHit;
    public bool RegisterExtraThiccHit;
    public bool SkipThreatCount;
    public bool SkipSpaceDamage;
    public bool IsCivilian;
    public bool IsMachine;
    public bool IsPiriCeptopod;
    public bool IsPersonalDrone;
    public bool IsInside;
    public bool PartiallyDamaged;
    public GameObject TheThingie;
    public bool NoArmor;
    public bool LightArmor;
    public bool MediumArmor;
    public bool HeavyArmor;
    public bool ThiccArmor;
    public bool ExtraThiccArmor;
    public bool UtsargalineArmor;
    public bool AtsargalineArmor;
    public bool UsingRammer;
    public bool CanEmergency;
    public bool SkipSensitivity;
    public bool FrontSensitive;
    public float SenSplitCenter;
    public float DamageReceival;
    public bool OpenVessel;
    public bool ExplosiveVessel;
    public bool ExplodeParent;
    public GameObject Explosion;
    public bool LocalOriExp;
    public bool UseDetonate;
    public bool DeployOnBreakVessel;
    public float DeployDelay;
    public GameObject Gates;
    public FixedJoint GateJoint;
    public GameObject Gates2;
    public ConfigurableJoint GateJoint2;
    public GameObject DeployeeFab1;
    public GameObject Deployee1GO;
    public GameObject Deployee1AIGO;
    public bool Deployee1IsOut;
    public GameObject DeployeeFab2;
    public GameObject DeployeeFab3;
    public GameObject DeployeeFab4;
    public GameObject DeployeeFab5;
    public GameObject DeployeeFab6;
    public GameObject DeployeeFab7;
    public GameObject DeployeeArea1;
    public GameObject DeployeeArea2;
    public GameObject DeployeeArea3;
    public GameObject DeployeeArea4;
    public GameObject DeployeeArea5;
    public GameObject DeployeeArea6;
    public GameObject DeployeeArea7;
    public bool Helirotor;
    public TorqueScript1 TorqueScript;
    public GameObject Rotor;
    public bool Dislodge;
    public bool ResetDrag;
    public bool ResetGravity;
    public bool PiriIsHurt;
    public GameObject AI;
    public string AIName;
    public Rigidbody AIrigidbody;
    public CapsuleCollider AITrig;
    public bool DestroyAI;
    public bool AICallDeathFunction;
    public bool CustomDeath;
    public bool ColSoundBreakUsage;
    public CollisionSound ColSound;
    public bool UsesWMC;
    public GameObject[] WMCs;
    public GameObject Vehicle;
    public GameObject HurtSound;
    public GameObject PartialBrokenSound;
    public GameObject OnboardBrokenSound;
    public GameObject BrokenSound;
    public GameObject SecondBrokenSound;
    public bool UnparentBrokenSound;
    public bool UnparentSecondBrokenSound;
    public bool UnparentOBBrokenSound;
    public GameObject BrokenEffectArea;
    public GameObject BrokenSubPart1;
    public GameObject BrokenSubPart2;
    public float BreakDelay;
    public float SecondBreakDelay;
    public float FinalBreakDelay;
    public Transform[] WhatToUnchild;
    public ConfigurableJoint[] WhatToUnjoint;
    public GameObject[] WhatToDestroy;
    public GameObject[] SecondWhatToDestroy;
    public GameObject[] PartialWhatToDestroy;
    public GameObject Part1Lock;
    public GameObject Part2Lock;
    public GameObject Part3Lock;
    public GameObject Part4Lock;
    public GameObject Part5Lock;
    public GameObject Part6Lock;
    public Rigidbody PartFinal;
    public float PartFinalMass;
    public float LockDist;
    public bool Locking;
    public ParticleSystem[] ParticleFX;
    public GameObject[] EngineEffects;
    public GameObject[] SpinningParts;
    public GameObject[] Props;
    public GameObject[] Wings;
    public GameObject[] PartsResetDrag;
    public GameObject[] PartsResetGrav;
    public GameObject[] LimbSections;
    public HingeJoint[] HingeStop;
    public AudioSource Sound;
    public BigVesselRotator Rotator;
    public RadarScript RadarController;
    public GameObject GunController;
    public ConfigurableJoint ConJoint;
    public SpringJoint SprJoint;
    public LayerMask MtargetLayers;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Tick", 1, 0.2f);
        this.forceOnce = true;
        if (this.Vehicle)
        {
            if (this.Vehicle.GetComponent("MainVehicleController"))
            {
                this.PlayerControlled = true;
            }
        }
        if (!this.RestartingFromOne)
        {
            this.StaticHealth = this.Health;
        }
        this.HurtThreshold = -this.Health;
        if (!this.HighThreshold)
        {
            this.HealthThreshold = this.Health * 0.33f;
        }
        else
        {
            this.HealthThreshold = this.Health * 0.5f;
        }
        if (this.useScalarForce)
        {
            this.Threshold = 1000;
            float RBDiv = this.GetComponent<Rigidbody>().mass * 0.1f;
            this.Threshold = this.Threshold + RBDiv;
        }
        if (this.ColSoundBreakUsage)
        {
            this.ColSound.Broken = true;
            this.ColSound.BrokenC = true;
        }
        if (this.IsCivilian)
        {
            if ((this.TargetCode == 3) && (WorldInformation.instance.AreaCode == 1))
            {
                this.TargetCode = 0;
            }
        }
        if (!this.SkipSpaceDamage)
        {
            if (WorldInformation.instance.AreaSpace == true)
            {
                this.DamageIn(2048, 0, 0, true);
                this.SpaceOnce = true;
            }
        }
        if (!this.RestartingFromOne)
        {
            if (this.StartFromOne)
            {
                this.Health = 1;
            }
            if (this.StartFromRandom)
            {
                this.Health = Random.Range(1, this.StaticHealth);
            }
        }
        yield return new WaitForSeconds(0.3f);
        this.forceOnce = false;
    }

    public virtual void RestartFromOne()
    {
        this.RestartingFromOne = true;
        this.StaticHealth = this.Health;
        this.Health = 1;
    }

    public virtual void FixedUpdate()
    {
        if (this.CanRegenerate)
        {
            if (this.Health >= 1)
            {
                if (this.Health < this.StaticHealth)
                {
                    this.Health = this.Health + this.RegenAmount;
                }
            }
        }
        if (this.RegisterForce)
        {
            float acceleration = (this.GetComponent<Rigidbody>().velocity.magnitude - this.lastVelocity) / Time.deltaTime;
            this.Gs = Mathf.Abs(acceleration);
            this.lastVelocity = this.GetComponent<Rigidbody>().velocity.magnitude;
            if (!this.forceOnce)
            {
                if (!this.useScalarForce)
                {
                    if (this.Gs > 2000)
                    {
                        if (this.GetComponent<Rigidbody>().mass > 0.011f)
                        {
                            this.forceOnce = true;
                            if (!this.SkipTargetForce)
                            {
                                if ((Vector3.Distance(this.transform.position, PlayerInformation.instance.PiriTarget.position) < 20) && (WorldInformation.vehicleSpeed > 90))
                                {
                                    this.DamageIn(100000, 1, 0, true);
                                }
                                else
                                {
                                    this.DamageIn(100000, 0, 0, false);
                                }
                            }
                            else
                            {
                                this.DamageIn(100000, 0, 0, false);
                            }
                        }
                        if ((this.GetComponent<Rigidbody>().mass < 0.011f) && (this.Gs > 4000))
                        {
                            this.forceOnce = true;
                            if (!this.SkipTargetForce)
                            {
                                if ((Vector3.Distance(this.transform.position, PlayerInformation.instance.PiriTarget.position) < 20) && (WorldInformation.vehicleSpeed > 90))
                                {
                                    this.DamageIn(100000, 1, 0, true);
                                }
                                else
                                {
                                    this.DamageIn(100000, 0, 0, false);
                                }
                            }
                            else
                            {
                                this.DamageIn(100000, 0, 0, false);
                            }
                        }
                    }
                }
                else
                {
                    if (this.Gs > this.Threshold)
                    {
                        this.forceOnce = true;
                        if (!this.SkipTargetForce)
                        {
                            if ((Vector3.Distance(this.transform.position, PlayerInformation.instance.PiriTarget.position) < 20) && (WorldInformation.vehicleSpeed > 90))
                            {
                                this.DamageIn(100000, 1, 0, true);
                            }
                            else
                            {
                                this.DamageIn(100000, 0, 0, false);
                            }
                        }
                        else
                        {
                            this.DamageIn(100000, 0, 0, false);
                        }
                    }
                }
            }
        }
        if (this.PiriIsHurt)
        {
            AudioListener.volume = AudioListener.volume - 0.005f;
        }
    }

    public virtual void OnCollisionStay(Collision collision)
    {
        if (this.RegisterTouch)
        {
            if (this.AI)
            {
                if (((collision.gameObject.tag == "Vehicle") || (collision.gameObject.tag == "Body")) || (collision.gameObject.tag == "Metal"))
                {
                    //this.AI.GetComponent(this.AIName).OnHull = true;
                    ReflectionUtils.SetField(AI.GetComponent(AIName), "AIName", "OnHull", true);
                }
            }
        }
    }

    public virtual void DamageIn(float Damage, int DamageCode, float Frontal, bool PShot)
    {
        int i0 = 0;
        if (!this.SkipSensitivity)
        {
            if (!this.FrontSensitive && (Frontal < this.SenSplitCenter))
            {
                Damage = Damage * this.DamageReceival;
            }
            if (this.FrontSensitive && (Frontal > this.SenSplitCenter))
            {
                Damage = Damage * this.DamageReceival;
            }
        }
        if (this.NoArmor == true)
        {
            if (PShot && (this.Health > 0))
            {
                this.ThisDamage = Damage;
                this.SendDamage = Damage;
                if (this.Health < Damage)
                {
                    this.ThisDamage = this.ThisDamage - this.Health;
                    this.SendDamage = this.SendDamage - this.ThisDamage;
                }
                if (this.SendDamage > 0)
                {
                    DamageCounter.instance.ShowDamage(this.SendDamage, this.TargetCode);
                }
            }
            this.Health = this.Health - Damage;
            if (Damage > 24)
            {
                this.HeavyHit = true;
                if (Damage > 96)
                {
                    this.ExtraThiccHit = true;
                }
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
                if (this.SendDamage > 0)
                {
                    DamageCounter.instance.ShowDamage(this.SendDamage, this.TargetCode);
                }
            }
            this.Health = this.Health - (Damage * 0.5f);
            if (Damage > 24)
            {
                this.HeavyHit = true;
                if (Damage > 96)
                {
                    this.ExtraThiccHit = true;
                }
            }
        }
        if (this.MediumArmor == true)
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
                if (this.SendDamage > 0)
                {
                    DamageCounter.instance.ShowDamage(this.SendDamage, this.TargetCode);
                }
            }
            this.Health = this.Health - (Damage * 0.25f);
            if (Damage > 24)
            {
                this.HeavyHit = true;
                if (Damage > 96)
                {
                    this.ExtraThiccHit = true;
                }
            }
        }
        if (this.HeavyArmor == true)
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
                if (this.SendDamage > 0)
                {
                    DamageCounter.instance.ShowDamage(this.SendDamage, this.TargetCode);
                }
            }
            this.Health = this.Health - (Damage * 0.125f);
            if (Damage > 24)
            {
                this.HeavyHit = true;
                if (Damage > 96)
                {
                    this.ExtraThiccHit = true;
                }
            }
        }
        if (this.ThiccArmor == true)
        {
            if (PShot && (this.Health > 0))
            {
                this.ThisDamage = Damage * 0.085f;
                this.SendDamage = Damage * 0.085f;
                if (this.Health < (Damage * 0.085f))
                {
                    this.ThisDamage = this.ThisDamage - this.Health;
                    this.SendDamage = this.SendDamage - this.ThisDamage;
                }
                if (this.SendDamage > 0)
                {
                    DamageCounter.instance.ShowDamage(this.SendDamage, this.TargetCode);
                }
            }
            this.Health = this.Health - (Damage * 0.085f);
            if (Damage > 24)
            {
                this.HeavyHit = true;
                if (Damage > 96)
                {
                    this.ExtraThiccHit = true;
                }
            }
        }
        if (this.ExtraThiccArmor == true)
        {
            if (PShot && (this.Health > 0))
            {
                this.ThisDamage = Damage * 0.0625f;
                this.SendDamage = Damage * 0.0625f;
                if (this.Health < (Damage * 0.0625f))
                {
                    this.ThisDamage = this.ThisDamage - this.Health;
                    this.SendDamage = this.SendDamage - this.ThisDamage;
                }
                if (this.SendDamage > 0)
                {
                    DamageCounter.instance.ShowDamage(this.SendDamage, this.TargetCode);
                }
            }
            this.Health = this.Health - (Damage * 0.0625f);
            if (Damage > 24)
            {
                this.HeavyHit = true;
                if (Damage > 96)
                {
                    this.ExtraThiccHit = true;
                }
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
                if (this.SendDamage > 0)
                {
                    DamageCounter.instance.ShowDamage(this.SendDamage, this.TargetCode);
                }
            }
            this.Health = this.Health - (Damage * 0.01f);
            if (Damage > 24)
            {
                this.HeavyHit = true;
                if (Damage > 96)
                {
                    this.ExtraThiccHit = true;
                }
            }
        }
        if (this.AtsargalineArmor == true)
        {
            if (PShot && (this.Health > 0))
            {
                this.ThisDamage = Damage * 0.003f;
                this.SendDamage = Damage * 0.003f;
                if (this.Health < (Damage * 0.003f))
                {
                    this.ThisDamage = this.ThisDamage - this.Health;
                    this.SendDamage = this.SendDamage - this.ThisDamage;
                }
                if (this.SendDamage > 0)
                {
                    DamageCounter.instance.ShowDamage(this.SendDamage, this.TargetCode);
                }
            }
            this.Health = this.Health - (Damage * 0.003f);
            if (Damage > 24)
            {
                this.HeavyHit = true;
                if (Damage > 96)
                {
                    this.ExtraThiccHit = true;
                }
            }
        }
        if (this.HeavyHit && this.RegisterHeavyHit)
        {
            if (this.AI)
            {
                //this.AI.GetComponent(this.AIName).Emergency = true;
                ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "Emergency", true);
            }
            this.HeavyHit = false;
        }
        if (this.ExtraThiccHit && this.RegisterExtraThiccHit)
        {
            if (this.AI)
            {
                //this.AI.GetComponent(this.AIName).Emergency = true;
                ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "Emergency", true);
            }
            this.ExtraThiccHit = false;
        }
        if (!this.once)
        {
            if (!this.SkipThreatCount)
            {
                //---------------------------------------------------------
                if (this.TargetCode == 2)
                {
                    if (PShot)
                    {
                        if (DamageCode == 1)
                        {
                            if (this.RegisterHit)
                            {
                                if (this.AI)
                                {
                                    //this.AI.GetComponent(this.AIName).PissedAtTC1 = ((float) this.AI.GetComponent(this.AIName).PissedAtTC1) + Damage;
                                    float tmp = ReflectionUtils.GetFieldValue<float>(AI.GetComponent(AIName), AIName, "PissedAtTC1") + Damage;
                                    ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC1", tmp);
                                }
                            }
                            if (Damage < this.StaticHealth)
                            {
                                AgrianNetwork.TC1CriminalLevel = (int) (AgrianNetwork.TC1CriminalLevel + (Damage * 2));
                            }
                            else
                            {
                                AgrianNetwork.TC1CriminalLevel = (int) (AgrianNetwork.TC1CriminalLevel + (this.StaticHealth * 2));
                            }
                        }
                        else
                        {
                            WorldInformation.PiriWanted = (int) (WorldInformation.PiriWanted + Damage);
                            WorldInformation.instance.NaughtyVicinity = this.transform.position;
                        }
                        if (DamageCode == 2)
                        {
                            WorldInformation.PiriExposed = 60;
                            AgrianNetwork.TC1CriminalLevel = (int) (AgrianNetwork.TC1CriminalLevel + (Damage * 2));
                        }
                    }
                    if (DamageCode == 3)
                    {
                        if (this.RegisterHit)
                        {
                            if (this.AI)
                            {
                                //this.AI.GetComponent(this.AIName).PissedAtTC3 = ((float) this.AI.GetComponent(this.AIName).PissedAtTC3) + Damage;
                                float tmp = ReflectionUtils.GetFieldValue<float>(AI.GetComponent(AIName), AIName, "PissedAtTC3") + Damage;
                                ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC3", tmp);
                            }
                        }
                        if (Damage < this.StaticHealth)
                        {
                            AgrianNetwork.TC3CriminalLevel = (int) (AgrianNetwork.TC3CriminalLevel + (Damage * 2));
                        }
                        else
                        {
                            AgrianNetwork.TC3CriminalLevel = (int) (AgrianNetwork.TC3CriminalLevel + this.StaticHealth);
                        }
                    }
                    if (DamageCode == 4)
                    {
                        if (this.RegisterHit)
                        {
                            if (this.AI)
                            {
                                //this.AI.GetComponent(this.AIName).PissedAtTC4 = ((float) this.AI.GetComponent(this.AIName).PissedAtTC4) + Damage;
                                float tmp = ReflectionUtils.GetFieldValue<float>(AI.GetComponent(AIName), AIName, "PissedAtTC4") + Damage;
                                ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC4", tmp);
                            }
                        }
                        if (Damage < this.StaticHealth)
                        {
                            AgrianNetwork.TC4CriminalLevel = (int) (AgrianNetwork.TC4CriminalLevel + (Damage * 2));
                        }
                        else
                        {
                            AgrianNetwork.TC4CriminalLevel = (int) (AgrianNetwork.TC4CriminalLevel + (this.StaticHealth * 2));
                        }
                    }
                    if (DamageCode == 5)
                    {
                        if (this.RegisterHit)
                        {
                            if (this.AI)
                            {
                                //this.AI.GetComponent(this.AIName).PissedAtTC5 = ((float) this.AI.GetComponent(this.AIName).PissedAtTC5) + Damage;
                                float tmp = ReflectionUtils.GetFieldValue<float>(AI.GetComponent(AIName), AIName, "PissedAtTC5") + Damage;
                                ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC5", tmp);
                            }
                        }
                        if (Damage < this.StaticHealth)
                        {
                            AgrianNetwork.TC5CriminalLevel = (int) (AgrianNetwork.TC5CriminalLevel + (Damage * 2));
                        }
                        else
                        {
                            AgrianNetwork.TC5CriminalLevel = (int) (AgrianNetwork.TC5CriminalLevel + (this.StaticHealth * 2));
                        }
                    }
                    if (DamageCode == 6)
                    {
                        if (this.RegisterHit)
                        {
                            if (this.AI)
                            {
                                //this.AI.GetComponent(this.AIName).PissedAtTC6 = ((float) this.AI.GetComponent(this.AIName).PissedAtTC6) + Damage;
                                float tmp = ReflectionUtils.GetFieldValue<float>(AI.GetComponent(AIName), AIName, "PissedAtTC6") + Damage;
                                ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC6", tmp);
                            }
                        }
                        if (Damage < this.StaticHealth)
                        {
                            AgrianNetwork.TC6CriminalLevel = (int) (AgrianNetwork.TC6CriminalLevel + (Damage * 2));
                        }
                        else
                        {
                            AgrianNetwork.TC6CriminalLevel = (int) (AgrianNetwork.TC6CriminalLevel + (this.StaticHealth * 2));
                        }
                    }
                    if (DamageCode == 7)
                    {
                        if (this.RegisterHit)
                        {
                            if (this.AI)
                            {
                                //this.AI.GetComponent(this.AIName).PissedAtTC7 = ((float) this.AI.GetComponent(this.AIName).PissedAtTC7) + Damage;
                                float tmp = ReflectionUtils.GetFieldValue<float>(AI.GetComponent(AIName), AIName, "PissedAtTC7") + Damage;
                                ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC7", tmp);
                            }
                        }
                        if (Damage < this.StaticHealth)
                        {
                            AgrianNetwork.TC7CriminalLevel = (int) (AgrianNetwork.TC7CriminalLevel + (Damage * 2));
                        }
                        else
                        {
                            AgrianNetwork.TC7CriminalLevel = (int) (AgrianNetwork.TC7CriminalLevel + (this.StaticHealth * 2));
                        }
                    }
                    if (DamageCode == 8)
                    {
                        if (this.RegisterHit)
                        {
                            if (this.AI)
                            {
                                //this.AI.GetComponent(this.AIName).PissedAtTC8 = ((float) this.AI.GetComponent(this.AIName).PissedAtTC8) + Damage;
                                float tmp = ReflectionUtils.GetFieldValue<float>(AI.GetComponent(AIName), AIName, "PissedAtTC8") + Damage;
                                ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC8", tmp);
                            }
                        }
                        if (Damage < this.StaticHealth)
                        {
                            AgrianNetwork.TC8CriminalLevel = (int) (AgrianNetwork.TC8CriminalLevel + (Damage * 2));
                        }
                        else
                        {
                            AgrianNetwork.TC8CriminalLevel = (int) (AgrianNetwork.TC8CriminalLevel + (this.StaticHealth * 2));
                        }
                    }
                    if (DamageCode == 9)
                    {
                        if (this.RegisterHit)
                        {
                            if (this.AI)
                            {
                                //this.AI.GetComponent(this.AIName).PissedAtTC9 = ((float) this.AI.GetComponent(this.AIName).PissedAtTC9) + Damage;
                                float tmp = ReflectionUtils.GetFieldValue<float>(AI.GetComponent(AIName), AIName, "PissedAtTC9") + Damage;
                                ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC9", tmp);
                            }
                        }
                        if (Damage < this.StaticHealth)
                        {
                            AgrianNetwork.TC9CriminalLevel = (int) (AgrianNetwork.TC9CriminalLevel + (Damage * 2));
                        }
                        else
                        {
                            AgrianNetwork.TC9CriminalLevel = (int) (AgrianNetwork.TC9CriminalLevel + (this.StaticHealth * 2));
                        }
                    }
                    if ((this.Health < 1) && !this.Honce)
                    {
                        this.Honce = true;
                        AgrianNetwork.instance.PriorityWaypoint.transform.position = this.transform.position;
                        if (this.StaticHealth < 48)
                        {
                            if (AgrianNetwork.instance.AlertTime < 240)
                            {
                                AgrianNetwork.instance.AlertTime = 240;
                            }
                        }
                        else
                        {
                            if (this.StaticHealth < 1000)
                            {
                                AgrianNetwork.instance.FullPriorityWaypoint.transform.position = this.transform.position;
                                if (AgrianNetwork.instance.AlertTime < 300)
                                {
                                    AgrianNetwork.instance.AlertTime = 300;
                                }
                                AgrianNetwork.instance.RedAlertTime = 300;
                            }
                            else
                            {
                                AgrianNetwork.instance.FullPriorityWaypoint.transform.position = this.transform.position;
                                AgrianNetwork.instance.AlertTime = 600;
                                AgrianNetwork.instance.RedAlertTime = 600;
                            }
                        }
                    }
                }
                //---------------------------------------------------------
                if (this.TargetCode == 3)
                {
                    if (DamageCode == 0)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            TerrahyptianNetwork.TC0aCriminalLevel = (int) (TerrahyptianNetwork.TC0aCriminalLevel + (Damage * 3));
                        }
                        else
                        {
                            TerrahyptianNetwork.TC0aCriminalLevel = (int) (TerrahyptianNetwork.TC0aCriminalLevel + (this.StaticHealth * 3));
                        }
                        if ((this.Health < 1) && !this.Honce)
                        {
                            if (!this.IsCivilian)
                            {
                                this.Honce = true;
                                if (this.AI)
                                {
                                    //TerrahyptianNetwork.instance.EnemyTarget2 = this.AI.GetComponent(this.AIName).target;
                                    TerrahyptianNetwork.instance.EnemyTarget2 = ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target");
                                }
                                TerrahyptianNetwork.instance.PriorityWaypoint.position = this.transform.position;
                            }
                        }
                    }
                    if (PShot)
                    {
                        if (DamageCode == 1)
                        {
                            if (Damage < this.StaticHealth)
                            {
                                TerrahyptianNetwork.TC1CriminalLevel = (int) (TerrahyptianNetwork.TC1CriminalLevel + (Damage * 3));
                            }
                            else
                            {
                                TerrahyptianNetwork.TC1CriminalLevel = (int) (TerrahyptianNetwork.TC1CriminalLevel + (this.StaticHealth * 3));
                            }
                            if ((this.Health < 1) && !this.Honce)
                            {
                                TerrahyptianNetwork.TC1Nuisance = TerrahyptianNetwork.TC1Nuisance + 1;
                                WorldInformation.instance.NaughtyVicinity = this.transform.position;
                                if (!this.IsCivilian)
                                {
                                    TerrahyptianNetwork.AlertLVL1 = 1;
                                    this.Honce = true;
                                    if (this.AI)
                                    {
                                        //TerrahyptianNetwork.instance.EnemyTarget2 = this.AI.GetComponent(this.AIName).target;
                                        TerrahyptianNetwork.instance.EnemyTarget2 = ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target");
                                    }
                                    TerrahyptianNetwork.instance.PriorityWaypoint.position = this.transform.position;
                                }
                            }
                        }
                        if (DamageCode == 3)
                        {
                            WorldInformation.PiriExposed = 60;
                            if (Damage < this.StaticHealth)
                            {
                                TerrahyptianNetwork.TC1CriminalLevel = (int) (TerrahyptianNetwork.TC1CriminalLevel + (Damage * 3));
                            }
                            else
                            {
                                TerrahyptianNetwork.TC1CriminalLevel = (int) (TerrahyptianNetwork.TC1CriminalLevel + (this.StaticHealth * 3));
                            }
                        }
                    }
                    if (DamageCode == 4)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            TerrahyptianNetwork.TC4CriminalLevel = (int) (TerrahyptianNetwork.TC4CriminalLevel + (Damage * 3));
                        }
                        else
                        {
                            TerrahyptianNetwork.TC4CriminalLevel = (int) (TerrahyptianNetwork.TC4CriminalLevel + (this.StaticHealth * 3));
                        }
                        if ((this.Health < 1) && !this.Honce)
                        {
                            if (!this.IsCivilian)
                            {
                                TerrahyptianNetwork.AlertLVL1 = 4;
                                this.Honce = true;
                                if (this.AI)
                                {
                                    //TerrahyptianNetwork.instance.EnemyTarget2 = this.AI.GetComponent(this.AIName).target;
                                    TerrahyptianNetwork.instance.EnemyTarget2 = ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target");
                                }
                                TerrahyptianNetwork.instance.PriorityWaypoint.position = this.transform.position;
                            }
                        }
                    }
                    if (DamageCode == 5)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            TerrahyptianNetwork.TC5CriminalLevel = (int) (TerrahyptianNetwork.TC5CriminalLevel + (Damage * 3));
                        }
                        else
                        {
                            TerrahyptianNetwork.TC5CriminalLevel = (int) (TerrahyptianNetwork.TC5CriminalLevel + (this.StaticHealth * 3));
                        }
                        if ((this.Health < 1) && !this.Honce)
                        {
                            if (!this.IsCivilian)
                            {
                                TerrahyptianNetwork.AlertLVL1 = 5;
                                this.Honce = true;
                                if (this.AI)
                                {
                                    //TerrahyptianNetwork.instance.EnemyTarget2 = this.AI.GetComponent(this.AIName).target;
                                    TerrahyptianNetwork.instance.EnemyTarget2 = ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target");
                                }
                                TerrahyptianNetwork.instance.PriorityWaypoint.position = this.transform.position;
                            }
                        }
                    }
                    if (DamageCode == 6)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            TerrahyptianNetwork.TC6CriminalLevel = (int) (TerrahyptianNetwork.TC6CriminalLevel + (Damage * 3));
                        }
                        else
                        {
                            TerrahyptianNetwork.TC6CriminalLevel = (int) (TerrahyptianNetwork.TC6CriminalLevel + (this.StaticHealth * 3));
                        }
                        if ((this.Health < 1) && !this.Honce)
                        {
                            if (!this.IsCivilian)
                            {
                                TerrahyptianNetwork.AlertLVL1 = 6;
                                this.Honce = true;
                                if (this.AI)
                                {
                                    //TerrahyptianNetwork.instance.EnemyTarget2 = this.AI.GetComponent(this.AIName).target;
                                    TerrahyptianNetwork.instance.EnemyTarget2 = ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target");
                                }
                                TerrahyptianNetwork.instance.PriorityWaypoint.position = this.transform.position;
                            }
                        }
                    }
                    if (DamageCode == 7)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            TerrahyptianNetwork.TC7CriminalLevel = (int) (TerrahyptianNetwork.TC7CriminalLevel + (Damage * 3));
                        }
                        else
                        {
                            TerrahyptianNetwork.TC7CriminalLevel = (int) (TerrahyptianNetwork.TC7CriminalLevel + (this.StaticHealth * 3));
                        }
                        if ((this.Health < 1) && !this.Honce)
                        {
                            if (!this.IsCivilian)
                            {
                                TerrahyptianNetwork.AlertLVL1 = 7;
                                this.Honce = true;
                                if (this.AI)
                                {
                                    //TerrahyptianNetwork.instance.EnemyTarget2 = this.AI.GetComponent(this.AIName).target;
                                    TerrahyptianNetwork.instance.EnemyTarget2 = ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target");
                                }
                                TerrahyptianNetwork.instance.PriorityWaypoint.position = this.transform.position;
                            }
                        }
                    }
                    if (DamageCode == 8)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            TerrahyptianNetwork.TC8CriminalLevel = (int) (TerrahyptianNetwork.TC8CriminalLevel + (Damage * 3));
                        }
                        else
                        {
                            TerrahyptianNetwork.TC8CriminalLevel = (int) (TerrahyptianNetwork.TC8CriminalLevel + (this.StaticHealth * 3));
                        }
                        if ((this.Health < 1) && !this.Honce)
                        {
                            if (!this.IsCivilian)
                            {
                                TerrahyptianNetwork.AlertLVL1 = 8;
                                this.Honce = true;
                                if (this.AI)
                                {
                                    //TerrahyptianNetwork.instance.EnemyTarget2 = this.AI.GetComponent(this.AIName).target;
                                    TerrahyptianNetwork.instance.EnemyTarget2 = ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target");
                                }
                                TerrahyptianNetwork.instance.PriorityWaypoint.position = this.transform.position;
                            }
                        }
                    }
                    if (DamageCode == 9)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            TerrahyptianNetwork.TC9CriminalLevel = (int) (TerrahyptianNetwork.TC9CriminalLevel + (Damage * 3));
                        }
                        else
                        {
                            TerrahyptianNetwork.TC9CriminalLevel = (int) (TerrahyptianNetwork.TC9CriminalLevel + (this.StaticHealth * 3));
                        }
                        if ((this.Health < 1) && !this.Honce)
                        {
                            if (!this.IsCivilian)
                            {
                                TerrahyptianNetwork.AlertLVL1 = 9;
                                this.Honce = true;
                                if (this.AI)
                                {
                                    //TerrahyptianNetwork.instance.EnemyTarget2 = this.AI.GetComponent(this.AIName).target;
                                    TerrahyptianNetwork.instance.EnemyTarget2 = ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target");
                                }
                                TerrahyptianNetwork.instance.PriorityWaypoint.position = this.transform.position;
                            }
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
                            float tmp = ReflectionUtils.GetFieldValue<float>(AI.GetComponent(AIName), AIName, "PissedAtTC0a") + 3;
                            ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC0a", tmp);
                            if (Damage > 64)
                            {
                                if (SlavuicNetwork.TC0aDeathRow < 300)
                                {
                                    SlavuicNetwork.TC0aDeathRow = SlavuicNetwork.TC0aDeathRow + 100;
                                }
                            }
                        }
                        if ((DamageCode == 1) && PShot)
                        {
                            SlavuicNetwork.target = PlayerInformation.instance.PiriTarget;
                            WorldInformation.instance.NaughtyVicinity = this.transform.position;
                            //this.AI.GetComponent(this.AIName).PissedAtTC1 = ((int) this.AI.GetComponent(this.AIName).PissedAtTC1) + 3;
                            float tmp = ReflectionUtils.GetFieldValue<float>(AI.GetComponent(AIName), AIName, "PissedAtTC1") + 3;
                            ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC1", tmp);
                        }
                        if (DamageCode == 3)
                        {
                            //this.AI.GetComponent(this.AIName).PissedAtTC3 = ((int) this.AI.GetComponent(this.AIName).PissedAtTC3) + 3;
                            float tmp = ReflectionUtils.GetFieldValue<float>(AI.GetComponent(AIName), AIName, "PissedAtTC3") + 3;
                            ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC3", tmp);
                            if (Damage > 64)
                            {
                                if (SlavuicNetwork.TC3DeathRow < 300)
                                {
                                    SlavuicNetwork.TC3DeathRow = SlavuicNetwork.TC3DeathRow + 100;
                                }
                            }
                        }
                        if (DamageCode == 4)
                        {
                            //this.AI.GetComponent(this.AIName).PissedAtTC4 = ((int) this.AI.GetComponent(this.AIName).PissedAtTC4) + 3;
                            float tmp = ReflectionUtils.GetFieldValue<float>(AI.GetComponent(AIName), AIName, "PissedAtTC3") + 3;
                            ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC3", tmp);
                            if (Damage > 64)
                            {
                                if (SlavuicNetwork.TC4DeathRow < 300)
                                {
                                    SlavuicNetwork.TC4DeathRow = SlavuicNetwork.TC4DeathRow + 100;
                                }
                            }
                        }
                        if (DamageCode == 6)
                        {
                            //this.AI.GetComponent(this.AIName).PissedAtTC6 = ((int) this.AI.GetComponent(this.AIName).PissedAtTC6) + 3;
                            float tmp = ReflectionUtils.GetFieldValue<float>(AI.GetComponent(AIName), AIName, "PissedAtTC6") + 3;
                            ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC6", tmp);
                            if (Damage > 64)
                            {
                                if (SlavuicNetwork.TC6DeathRow < 300)
                                {
                                    SlavuicNetwork.TC6DeathRow = SlavuicNetwork.TC6DeathRow + 100;
                                }
                            }
                        }
                        if (DamageCode == 7)
                        {
                            //this.AI.GetComponent(this.AIName).PissedAtTC7 = ((int) this.AI.GetComponent(this.AIName).PissedAtTC7) + 3;
                            float tmp = ReflectionUtils.GetFieldValue<float>(AI.GetComponent(AIName), AIName, "PissedAtTC7") + 3;
                            ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC7", tmp);
                            if (Damage > 64)
                            {
                                if (SlavuicNetwork.TC7DeathRow < 300)
                                {
                                    SlavuicNetwork.TC7DeathRow = SlavuicNetwork.TC7DeathRow + 100;
                                }
                            }
                        }
                        if (DamageCode == 8)
                        {
                            //this.AI.GetComponent(this.AIName).PissedAtTC8 = ((int) this.AI.GetComponent(this.AIName).PissedAtTC8) + 3;
                            float tmp = ReflectionUtils.GetFieldValue<float>(AI.GetComponent(AIName), AIName, "PissedAtTC8") + 3;
                            ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC8", tmp);
                            if (Damage > 64)
                            {
                                if (SlavuicNetwork.TC8DeathRow < 300)
                                {
                                    SlavuicNetwork.TC8DeathRow = SlavuicNetwork.TC8DeathRow + 100;
                                }
                            }
                        }
                        if (DamageCode == 9)
                        {
                            //this.AI.GetComponent(this.AIName).PissedAtTC9 = ((int) this.AI.GetComponent(this.AIName).PissedAtTC9) + 3;
                            float tmp = ReflectionUtils.GetFieldValue<float>(AI.GetComponent(AIName), AIName, "PissedAtTC9") + 3;
                            ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "PissedAtTC9", tmp);
                            if (Damage > 64)
                            {
                                if (SlavuicNetwork.TC9DeathRow < 300)
                                {
                                    SlavuicNetwork.TC9DeathRow = SlavuicNetwork.TC9DeathRow + 100;
                                }
                            }
                        }
                        if (this.PartiallyDamaged && this.RegisterHitExtra)
                        {
                            this.RegisterHeavyHit = true;
                        }
                    }
                    if (PShot)
                    {
                        if (DamageCode == 5)
                        {
                            WorldInformation.PiriExposed = 60;
                            SlavuicNetwork.TC3DeathRow = SlavuicNetwork.TC3DeathRow + 100;
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
                        if (DamageCode == 8)
                        {
                            SlavuicNetwork.TC8DeathRow = 240;
                        }
                        if (DamageCode == 9)
                        {
                            SlavuicNetwork.TC9DeathRow = 240;
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
                        WorldInformation.instance.NaughtyVicinity = this.transform.position;
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
                    if (DamageCode == 8)
                    {
                        AbiaSyndicateNetwork.TC8CriminalLevel = AbiaSyndicateNetwork.TC8CriminalLevel + 10;
                    }
                    if (DamageCode == 9)
                    {
                        AbiaSyndicateNetwork.TC9CriminalLevel = AbiaSyndicateNetwork.TC9CriminalLevel + 10;
                    }
                    if ((this.Health < 1) && !this.Honce)
                    {
                        AbiaSyndicateNetwork.Alert = true;
                    }
                }
                //---------------------------------------------------------
                if (this.TargetCode == 7)
                {
                    if (this.RegisterHit)
                    {
                        if (this.AI)
                        {
                            //this.AI.GetComponent(this.AIName).GotHit = true;
                            ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "GotHit", true);
                        }
                    }
                    if (DamageCode == 0)
                    {
                        if (MevNavNetwork.TC0aDeathRow < 60)
                        {
                            MevNavNetwork.TC0aDeathRow = 60;
                        }
                    }
                    if ((DamageCode == 1) && PShot)
                    {
                        if (MevNavNetwork.TC1DeathRow < 300)
                        {
                            MevNavNetwork.TC1DeathRow = 120;
                        }
                        WorldInformation.instance.NaughtyVicinity = this.transform.position;
                    }
                    if (DamageCode == 3)
                    {
                        if (MevNavNetwork.TC3DeathRow < 300)
                        {
                            MevNavNetwork.TC3DeathRow = 120;
                        }
                    }
                    if (DamageCode == 4)
                    {
                        if (MevNavNetwork.TC4DeathRow < 60)
                        {
                            MevNavNetwork.TC4DeathRow = 60;
                        }
                    }
                    if (DamageCode == 6)
                    {
                        if (MevNavNetwork.TC6DeathRow < 300)
                        {
                            MevNavNetwork.TC6DeathRow = 120;
                        }
                    }
                    if (DamageCode == 5)
                    {
                        if (MevNavNetwork.TC5DeathRow < 300)
                        {
                            MevNavNetwork.TC5DeathRow = 120;
                        }
                    }
                    if (PShot)
                    {
                        if (DamageCode == 7)
                        {
                            WorldInformation.PiriExposed = 60;
                            if (MevNavNetwork.TC1DeathRow < 300)
                            {
                                MevNavNetwork.TC1DeathRow = 120;
                            }
                        }
                    }
                    if (DamageCode == 8)
                    {
                        if (MevNavNetwork.TC8DeathRow < 300)
                        {
                            MevNavNetwork.TC8DeathRow = 120;
                        }
                    }
                    if (DamageCode == 9)
                    {
                        if (MevNavNetwork.TC9DeathRow < 300)
                        {
                            MevNavNetwork.TC9DeathRow = 120;
                        }
                    }
                    if (this.AI)
                    {
                        if ((this.StaticHealth > 1000) && (this.Health < 320))
                        {
                            //this.AI.GetComponent(this.AIName).Emergency = true;
                            ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "Emergency", true);
                        }
                        if ((this.StaticHealth == 160) && (this.Health < 40))
                        {
                            //this.AI.GetComponent(this.AIName).Emergency = true;
                            ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "Emergency", true);
                        }
                        if ((this.StaticHealth == 80) && (this.Health < 20))
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
                    if ((this.Health < 1) && !this.Honce)
                    {
                        MevNavNetwork.AlertLVL1 = DamageCode;
                        this.Honce = true;
                        MevNavNetwork.AlertTime = 240;
                        if (this.StaticHealth > 100)
                        {
                            if ((DamageCode == 1) && PShot)
                            {
                                if (MevNavNetwork.TC1DeathRow < 1200)
                                {
                                    MevNavNetwork.TC1DeathRow = 1200;
                                }
                            }
                            if (DamageCode == 3)
                            {
                                if (MevNavNetwork.TC3DeathRow < 1200)
                                {
                                    MevNavNetwork.TC3DeathRow = 1200;
                                }
                            }
                            if (DamageCode == 5)
                            {
                                if (MevNavNetwork.TC5DeathRow < 1200)
                                {
                                    MevNavNetwork.TC5DeathRow = 1200;
                                }
                            }
                            if (DamageCode == 6)
                            {
                                if (MevNavNetwork.TC6DeathRow < 1200)
                                {
                                    MevNavNetwork.TC6DeathRow = 1200;
                                }
                            }
                            if (DamageCode == 8)
                            {
                                if (MevNavNetwork.TC8DeathRow < 1200)
                                {
                                    MevNavNetwork.TC8DeathRow = 1200;
                                }
                            }
                            if (DamageCode == 9)
                            {
                                if (MevNavNetwork.TC9DeathRow < 1200)
                                {
                                    MevNavNetwork.TC9DeathRow = 1200;
                                }
                            }
                            MevNavNetwork.instance.PriorityWaypoint.position = this.transform.position;
                            if (this.StaticHealth > 1000)
                            {
                                MevNavNetwork.AlertLVL3 = MevNavNetwork.AlertLVL3 + 1;
                            }
                        }
                        if (this.StaticHealth == 80)
                        {
                            if ((DamageCode == 1) && PShot)
                            {
                                if (MevNavNetwork.TC1DeathRow < 600)
                                {
                                    MevNavNetwork.TC1DeathRow = 600;
                                }
                            }
                            if (DamageCode == 3)
                            {
                                if (MevNavNetwork.TC3DeathRow < 600)
                                {
                                    MevNavNetwork.TC3DeathRow = 600;
                                }
                            }
                            if (DamageCode == 5)
                            {
                                if (MevNavNetwork.TC5DeathRow < 600)
                                {
                                    MevNavNetwork.TC5DeathRow = 600;
                                }
                            }
                            if (DamageCode == 6)
                            {
                                if (MevNavNetwork.TC6DeathRow < 600)
                                {
                                    MevNavNetwork.TC6DeathRow = 600;
                                }
                            }
                            if (DamageCode == 8)
                            {
                                if (MevNavNetwork.TC8DeathRow < 600)
                                {
                                    MevNavNetwork.TC8DeathRow = 600;
                                }
                            }
                            if (DamageCode == 9)
                            {
                                if (MevNavNetwork.TC9DeathRow < 600)
                                {
                                    MevNavNetwork.TC9DeathRow = 600;
                                }
                            }
                            MevNavNetwork.instance.PriorityWaypoint.position = this.transform.position;
                        }
                        if (this.StaticHealth == 24)
                        {
                            if ((DamageCode == 1) && PShot)
                            {
                                if (MevNavNetwork.TC1DeathRow < 300)
                                {
                                    MevNavNetwork.TC1Nuisance = MevNavNetwork.TC1Nuisance + 1;
                                    MevNavNetwork.instance.PriorityWaypoint.position = this.transform.position;
                                }
                            }
                            if (DamageCode == 3)
                            {
                                if (MevNavNetwork.TC3DeathRow < 300)
                                {
                                    MevNavNetwork.TC3Nuisance = MevNavNetwork.TC3Nuisance + 1;
                                    MevNavNetwork.instance.PriorityWaypoint.position = this.transform.position;
                                }
                            }
                            if (DamageCode == 5)
                            {
                                if (MevNavNetwork.TC5DeathRow < 300)
                                {
                                    MevNavNetwork.TC5Nuisance = MevNavNetwork.TC5Nuisance + 1;
                                    MevNavNetwork.instance.PriorityWaypoint.position = this.transform.position;
                                }
                            }
                            if (DamageCode == 6)
                            {
                                if (MevNavNetwork.TC6DeathRow < 300)
                                {
                                    MevNavNetwork.TC6Nuisance = MevNavNetwork.TC6Nuisance + 1;
                                    MevNavNetwork.instance.PriorityWaypoint.position = this.transform.position;
                                }
                            }
                            if (DamageCode == 8)
                            {
                                if (MevNavNetwork.TC8DeathRow < 300)
                                {
                                    MevNavNetwork.TC8Nuisance = MevNavNetwork.TC8Nuisance + 1;
                                    MevNavNetwork.instance.PriorityWaypoint.position = this.transform.position;
                                }
                            }
                            if (DamageCode == 9)
                            {
                                if (MevNavNetwork.TC9DeathRow < 300)
                                {
                                    MevNavNetwork.TC9Nuisance = MevNavNetwork.TC9Nuisance + 1;
                                    MevNavNetwork.instance.PriorityWaypoint.position = this.transform.position;
                                }
                            }
                        }
                    }
                }
                //---------------------------------------------------------
                if (this.TargetCode == 9)
                {
                    if (DamageCode == 0)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            if (DutvutanianNetwork.TC0aCriminalLevel < 240)
                            {
                                DutvutanianNetwork.TC0aCriminalLevel = DutvutanianNetwork.TC0aCriminalLevel + 60;
                            }
                            else
                            {
                                if (Damage < 600)
                                {
                                    DutvutanianNetwork.TC0aCriminalLevel = (int) (DutvutanianNetwork.TC0aCriminalLevel + (Damage * 0.2f));
                                }
                                else
                                {
                                    DutvutanianNetwork.TC0aCriminalLevel = 600;
                                }
                            }
                            if (DutvutanianNetwork.AlertTime < 30)
                            {
                                DutvutanianNetwork.AlertTime = (int) Damage;
                            }
                        }
                        else
                        {
                            if (Damage < 600)
                            {
                                DutvutanianNetwork.TC0aCriminalLevel = (int) (DutvutanianNetwork.TC0aCriminalLevel + (Damage * 0.2f));
                            }
                            else
                            {
                                DutvutanianNetwork.TC0aCriminalLevel = DutvutanianNetwork.TC0aCriminalLevel + 600;
                            }
                            DutvutanianNetwork.AlertTime = 120;
                        }
                        if ((this.Health < 1) && !this.Honce)
                        {
                            if (!this.IsCivilian)
                            {
                                this.Honce = true;
                                if (this.AI)
                                {
                                    //DutvutanianNetwork.instance.EnemyTargetMin = this.AI.GetComponent(this.AIName).target;
                                    DutvutanianNetwork.instance.EnemyTargetMin = ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target");
                                }
                            }
                        }
                    }
                    if (PShot)
                    {
                        if (DamageCode == 1)
                        {
                            if (Damage < this.StaticHealth)
                            {
                                if (DutvutanianNetwork.TC1CriminalLevel < 240)
                                {
                                    DutvutanianNetwork.TC1CriminalLevel = DutvutanianNetwork.TC1CriminalLevel + 60;
                                }
                                else
                                {
                                    if (Damage < 600)
                                    {
                                        DutvutanianNetwork.TC1CriminalLevel = (int) (DutvutanianNetwork.TC1CriminalLevel + (Damage * 0.2f));
                                    }
                                    else
                                    {
                                        DutvutanianNetwork.TC1CriminalLevel = 600;
                                    }
                                }
                                if (DutvutanianNetwork.AlertTime < 30)
                                {
                                    DutvutanianNetwork.AlertTime = (int) Damage;
                                }
                            }
                            else
                            {
                                if (Damage < 600)
                                {
                                    DutvutanianNetwork.TC1CriminalLevel = (int) (DutvutanianNetwork.TC1CriminalLevel + (Damage * 0.2f));
                                }
                                else
                                {
                                    DutvutanianNetwork.TC1CriminalLevel = DutvutanianNetwork.TC1CriminalLevel + 600;
                                }
                                DutvutanianNetwork.AlertTime = 120;
                            }
                            if ((this.Health < 1) && !this.Honce)
                            {
                                TerrahyptianNetwork.TC1Nuisance = TerrahyptianNetwork.TC1Nuisance + 1;
                                WorldInformation.instance.NaughtyVicinity = this.transform.position;
                                if (!this.IsCivilian)
                                {
                                    DutvutanianNetwork.TC1CriminalPoints = DutvutanianNetwork.TC1CriminalPoints + 1;
                                    this.Honce = true;
                                    if (this.AI)
                                    {
                                        if (this.AI.GetComponent(this.AIName))
                                        {
                                            //if (this.AI.GetComponent(this.AIName).target != null)
                                            if (ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target") != null)
                                            {
                                                //DutvutanianNetwork.instance.EnemyTargetMin = this.AI.GetComponent(this.AIName).target;
                                                DutvutanianNetwork.instance.EnemyTargetMin = ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (DamageCode == 9)
                        {
                            WorldInformation.PiriExposed = 60;
                            if (Damage < this.StaticHealth)
                            {
                                if (DutvutanianNetwork.TC1CriminalLevel < 240)
                                {
                                    DutvutanianNetwork.TC1CriminalLevel = DutvutanianNetwork.TC1CriminalLevel + 60;
                                }
                                else
                                {
                                    if (Damage < 600)
                                    {
                                        DutvutanianNetwork.TC1CriminalLevel = (int) (DutvutanianNetwork.TC1CriminalLevel + (Damage * 0.2f));
                                    }
                                    else
                                    {
                                        DutvutanianNetwork.TC1CriminalLevel = 600;
                                    }
                                }
                                if (DutvutanianNetwork.AlertTime < 30)
                                {
                                    DutvutanianNetwork.AlertTime = (int) Damage;
                                }
                            }
                            else
                            {
                                if (Damage < 600)
                                {
                                    DutvutanianNetwork.TC1CriminalLevel = (int) (DutvutanianNetwork.TC1CriminalLevel + (Damage * 0.2f));
                                }
                                else
                                {
                                    DutvutanianNetwork.TC1CriminalLevel = DutvutanianNetwork.TC1CriminalLevel + 600;
                                }
                                DutvutanianNetwork.AlertTime = 120;
                            }
                        }
                    }
                    if (DamageCode == 2)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            if (DutvutanianNetwork.TC2CriminalLevel < 240)
                            {
                                DutvutanianNetwork.TC2CriminalLevel = DutvutanianNetwork.TC2CriminalLevel + 60;
                            }
                            else
                            {
                                if (Damage < 600)
                                {
                                    DutvutanianNetwork.TC2CriminalLevel = (int) (DutvutanianNetwork.TC2CriminalLevel + (Damage * 0.2f));
                                }
                                else
                                {
                                    DutvutanianNetwork.TC2CriminalLevel = 600;
                                }
                            }
                            if (DutvutanianNetwork.AlertTime < 30)
                            {
                                DutvutanianNetwork.AlertTime = (int) Damage;
                            }
                        }
                        else
                        {
                            if (Damage < 600)
                            {
                                DutvutanianNetwork.TC2CriminalLevel = (int) (DutvutanianNetwork.TC2CriminalLevel + (Damage * 0.2f));
                            }
                            else
                            {
                                DutvutanianNetwork.TC2CriminalLevel = DutvutanianNetwork.TC2CriminalLevel + 600;
                            }
                            DutvutanianNetwork.AlertTime = 120;
                        }
                        if ((this.Health < 1) && !this.Honce)
                        {
                            if (!this.IsCivilian)
                            {
                                DutvutanianNetwork.TC2CriminalPoints = DutvutanianNetwork.TC2CriminalPoints + 1;
                                this.Honce = true;
                                if (this.AI)
                                {
                                    if (this.AI.GetComponent(this.AIName))
                                    {
                                        //if (this.AI.GetComponent(this.AIName).target != null)
                                        if (ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target") != null)
                                        {
                                            //DutvutanianNetwork.instance.EnemyTargetMin = this.AI.GetComponent(this.AIName).target;
                                            DutvutanianNetwork.instance.EnemyTargetMin = ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (DamageCode == 3)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            if (DutvutanianNetwork.TC3CriminalLevel < 240)
                            {
                                DutvutanianNetwork.TC3CriminalLevel = DutvutanianNetwork.TC3CriminalLevel + 60;
                            }
                            else
                            {
                                if (Damage < 600)
                                {
                                    DutvutanianNetwork.TC3CriminalLevel = (int) (DutvutanianNetwork.TC3CriminalLevel + (Damage * 0.2f));
                                }
                                else
                                {
                                    DutvutanianNetwork.TC3CriminalLevel = 600;
                                }
                            }
                            if (DutvutanianNetwork.AlertTime < 30)
                            {
                                DutvutanianNetwork.AlertTime = (int) Damage;
                            }
                        }
                        else
                        {
                            if (Damage < 600)
                            {
                                DutvutanianNetwork.TC3CriminalLevel = (int) (DutvutanianNetwork.TC3CriminalLevel + (Damage * 0.2f));
                            }
                            else
                            {
                                DutvutanianNetwork.TC3CriminalLevel = DutvutanianNetwork.TC3CriminalLevel + 600;
                            }
                            DutvutanianNetwork.AlertTime = 120;
                        }
                        if ((this.Health < 1) && !this.Honce)
                        {
                            if (!this.IsCivilian)
                            {
                                DutvutanianNetwork.TC3CriminalPoints = DutvutanianNetwork.TC3CriminalPoints + 1;
                                this.Honce = true;
                                if (this.AI)
                                {
                                    if (this.AI.GetComponent(this.AIName))
                                    {
                                        //if (this.AI.GetComponent(this.AIName).target != null)
                                        if (ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target") != null)
                                        {
                                            //DutvutanianNetwork.instance.EnemyTargetMin = this.AI.GetComponent(this.AIName).target;
                                            DutvutanianNetwork.instance.EnemyTargetMin = ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (DamageCode == 4)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            if (DutvutanianNetwork.TC4CriminalLevel < 240)
                            {
                                DutvutanianNetwork.TC4CriminalLevel = DutvutanianNetwork.TC4CriminalLevel + 60;
                            }
                            else
                            {
                                if (Damage < 600)
                                {
                                    DutvutanianNetwork.TC4CriminalLevel = (int) (DutvutanianNetwork.TC4CriminalLevel + (Damage * 0.2f));
                                }
                                else
                                {
                                    DutvutanianNetwork.TC4CriminalLevel = 600;
                                }
                            }
                            if (DutvutanianNetwork.AlertTime < 30)
                            {
                                DutvutanianNetwork.AlertTime = (int) Damage;
                            }
                        }
                        else
                        {
                            if (Damage < 600)
                            {
                                DutvutanianNetwork.TC4CriminalLevel = (int) (DutvutanianNetwork.TC4CriminalLevel + (Damage * 0.2f));
                            }
                            else
                            {
                                DutvutanianNetwork.TC4CriminalLevel = ((int) DutvutanianNetwork.TC4CriminalLevel) + 600;
                            }
                            DutvutanianNetwork.AlertTime = 120;
                        }
                        if ((this.Health < 1) && !this.Honce)
                        {
                            if (!this.IsCivilian)
                            {
                                DutvutanianNetwork.TC4CriminalPoints = DutvutanianNetwork.TC4CriminalPoints + 1;
                                this.Honce = true;
                                if (this.AI)
                                {
                                    if (this.AI.GetComponent(this.AIName))
                                    {
                                        //if (this.AI.GetComponent(this.AIName).target != null)
                                        if (ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target") != null)
                                        {
                                            //DutvutanianNetwork.instance.EnemyTargetMin = this.AI.GetComponent(this.AIName).target;
                                            DutvutanianNetwork.instance.EnemyTargetMin = ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (DamageCode == 5)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            if (DutvutanianNetwork.TC5CriminalLevel < 240)
                            {
                                DutvutanianNetwork.TC5CriminalLevel = DutvutanianNetwork.TC5CriminalLevel + 60;
                            }
                            else
                            {
                                if (Damage < 600)
                                {
                                    DutvutanianNetwork.TC5CriminalLevel = (int) (DutvutanianNetwork.TC5CriminalLevel + (Damage * 0.2f));
                                }
                                else
                                {
                                    DutvutanianNetwork.TC5CriminalLevel = 600;
                                }
                            }
                            if (DutvutanianNetwork.AlertTime < 30)
                            {
                                DutvutanianNetwork.AlertTime = (int) Damage;
                            }
                        }
                        else
                        {
                            if (Damage < 600)
                            {
                                DutvutanianNetwork.TC5CriminalLevel = (int) (DutvutanianNetwork.TC5CriminalLevel + (Damage * 0.2f));
                            }
                            else
                            {
                                DutvutanianNetwork.TC5CriminalLevel = DutvutanianNetwork.TC5CriminalLevel + 600;
                            }
                            DutvutanianNetwork.AlertTime = 120;
                        }
                        if ((this.Health < 1) && !this.Honce)
                        {
                            if (!this.IsCivilian)
                            {
                                DutvutanianNetwork.TC5CriminalPoints = DutvutanianNetwork.TC5CriminalPoints + 1;
                                this.Honce = true;
                                if (this.AI)
                                {
                                    if (this.AI.GetComponent(this.AIName))
                                    {
                                        //if (this.AI.GetComponent(this.AIName).target != null)
                                        if (ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target") != null)
                                        {
                                            //DutvutanianNetwork.instance.EnemyTargetMin = this.AI.GetComponent(this.AIName).target;
                                            DutvutanianNetwork.instance.EnemyTargetMin = ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (DamageCode == 6)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            if (DutvutanianNetwork.TC6CriminalLevel < 240)
                            {
                                DutvutanianNetwork.TC6CriminalLevel = DutvutanianNetwork.TC6CriminalLevel + 60;
                            }
                            else
                            {
                                if (Damage < 600)
                                {
                                    DutvutanianNetwork.TC6CriminalLevel = (int) (DutvutanianNetwork.TC6CriminalLevel + (Damage * 0.2f));
                                }
                                else
                                {
                                    DutvutanianNetwork.TC6CriminalLevel = 600;
                                }
                            }
                            if (DutvutanianNetwork.AlertTime < 30)
                            {
                                DutvutanianNetwork.AlertTime = (int) Damage;
                            }
                        }
                        else
                        {
                            if (Damage < 600)
                            {
                                DutvutanianNetwork.TC6CriminalLevel = (int) (DutvutanianNetwork.TC6CriminalLevel + (Damage * 0.2f));
                            }
                            else
                            {
                                DutvutanianNetwork.TC6CriminalLevel = DutvutanianNetwork.TC6CriminalLevel + 600;
                            }
                            DutvutanianNetwork.AlertTime = 120;
                        }
                        if ((this.Health < 1) && !this.Honce)
                        {
                            if (!this.IsCivilian)
                            {
                                DutvutanianNetwork.TC6CriminalPoints = DutvutanianNetwork.TC6CriminalPoints + 1;
                                this.Honce = true;
                                if (this.AI)
                                {
                                    if (this.AI.GetComponent(this.AIName))
                                    {
                                        //if (this.AI.GetComponent(this.AIName).target != null)
                                        if (ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target") != null)
                                        {
                                            //DutvutanianNetwork.instance.EnemyTargetMin = this.AI.GetComponent(this.AIName).target;
                                            DutvutanianNetwork.instance.EnemyTargetMin = ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (DamageCode == 7)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            if (DutvutanianNetwork.TC7CriminalLevel < 240)
                            {
                                DutvutanianNetwork.TC7CriminalLevel = DutvutanianNetwork.TC7CriminalLevel + 60;
                            }
                            else
                            {
                                if (Damage < 600)
                                {
                                    DutvutanianNetwork.TC7CriminalLevel = (int) (DutvutanianNetwork.TC7CriminalLevel + (Damage * 0.2f));
                                }
                                else
                                {
                                    DutvutanianNetwork.TC7CriminalLevel = 600;
                                }
                            }
                            if (DutvutanianNetwork.AlertTime < 30)
                            {
                                DutvutanianNetwork.AlertTime = (int) Damage;
                            }
                        }
                        else
                        {
                            if (Damage < 600)
                            {
                                DutvutanianNetwork.TC7CriminalLevel = (int) (DutvutanianNetwork.TC7CriminalLevel + (Damage * 0.2f));
                            }
                            else
                            {
                                DutvutanianNetwork.TC7CriminalLevel = DutvutanianNetwork.TC7CriminalLevel + 600;
                            }
                            DutvutanianNetwork.AlertTime = 120;
                        }
                        if ((this.Health < 1) && !this.Honce)
                        {
                            if (!this.IsCivilian)
                            {
                                DutvutanianNetwork.TC7CriminalPoints = DutvutanianNetwork.TC7CriminalPoints + 1;
                                this.Honce = true;
                                if (this.AI)
                                {
                                    if (this.AI.GetComponent(this.AIName))
                                    {
                                        //if (this.AI.GetComponent(this.AIName).target != null)
                                        if (ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target") != null)
                                        {
                                            //DutvutanianNetwork.instance.EnemyTargetMin = this.AI.GetComponent(this.AIName).target;
                                            DutvutanianNetwork.instance.EnemyTargetMin = ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (DamageCode == 8)
                    {
                        if (Damage < this.StaticHealth)
                        {
                            if (DutvutanianNetwork.TC8CriminalLevel < 240)
                            {
                                DutvutanianNetwork.TC8CriminalLevel = DutvutanianNetwork.TC8CriminalLevel + 60;
                            }
                            else
                            {
                                if (Damage < 600)
                                {
                                    DutvutanianNetwork.TC8CriminalLevel = (int) (DutvutanianNetwork.TC8CriminalLevel + (Damage * 0.2f));
                                }
                                else
                                {
                                    DutvutanianNetwork.TC8CriminalLevel = 600;
                                }
                            }
                            if (DutvutanianNetwork.AlertTime < 30)
                            {
                                DutvutanianNetwork.AlertTime = (int) Damage;
                            }
                        }
                        else
                        {
                            if (Damage < 600)
                            {
                                DutvutanianNetwork.TC8CriminalLevel = (int) (DutvutanianNetwork.TC8CriminalLevel + (Damage * 0.2f));
                            }
                            else
                            {
                                DutvutanianNetwork.TC8CriminalLevel = DutvutanianNetwork.TC8CriminalLevel + 600;
                            }
                            DutvutanianNetwork.AlertTime = 120;
                        }
                        if ((this.Health < 1) && !this.Honce)
                        {
                            if (!this.IsCivilian)
                            {
                                DutvutanianNetwork.TC8CriminalPoints = DutvutanianNetwork.TC8CriminalPoints + 1;
                                this.Honce = true;
                                if (this.AI)
                                {
                                    if (this.AI.GetComponent(this.AIName))
                                    {
                                        //if (this.AI.GetComponent(this.AIName).target != null)
                                        if (ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target") != null)
                                        {
                                            //DutvutanianNetwork.instance.EnemyTargetMin = this.AI.GetComponent(this.AIName).target;
                                            DutvutanianNetwork.instance.EnemyTargetMin = ReflectionUtils.GetFieldValue<Transform>(AI.GetComponent(AIName), AIName, "target");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        //----------------------------------------------------------
        if ((-this.Health > -this.HurtThreshold) && !this.hurtOnce)
        {
            if (((DamageCode != 6) && this.IsInside) && !this.OpenVessel)
            {
                if (!WorldInformation.Godmode)
                {
                    this.hurtOnce = true;
                    WorldInformation.CanLeaveVehicle = false;
                    this.PiriIsHurt = true;
                    WorldInformation.PiriIsHurt = true;
                    this.PiriHurt();
                }
            }
        }
        if (this.Health < this.HealthThreshold)
        {
            if (!this.PartiallyDamaged)
            {
                this.PartiallyDamaged = true;
                if (this.CanEmergency)
                {
                    //this.AI.GetComponent(this.AIName).Emergency = true;
                    ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "Emergency", true);
                }
                if (this.PartialBrokenSound)
                {
                    this.TheThingie = UnityEngine.Object.Instantiate(this.PartialBrokenSound, this.BrokenEffectArea.transform.position, this.BrokenEffectArea.transform.rotation);
                    this.TheThingie.transform.parent = this.gameObject.transform;
                    if (!(this.PartialWhatToDestroy == null))
                    {
                        i0 = 0;
                        while (i0 < this.PartialWhatToDestroy.Length)
                        {
                            UnityEngine.Object.Destroy(this.PartialWhatToDestroy[i0].gameObject);
                            i0++;
                        }
                    }
                }
            }
        }
        if ((this.Health < 1) && !this.once)
        {
            this.once = true;
            if (this.PlayerGunScript)
            {
                this.PlayerGunScript.SecBroken = true;
                this.PlayerGunScript.VolleyBroken = true;
            }
            if (!this.CustomDeath)
            {
                this.DestroySequence();
                if (this.AICallDeathFunction)
                {
                    if (this.AI.GetComponent(this.AIName))
                    {
                        //this.AI.GetComponent(this.AIName).Damage();
                        ReflectionUtils.InvokeVoid0(AI.GetComponent(AIName), AIName, "Damage");
                    }
                }
            }
            else
            {
                //this.AI.GetComponent(this.AIName).Kill();
                ReflectionUtils.InvokeVoid0(AI.GetComponent(AIName), AIName, "Kill");
            }
            if (this.ColSoundBreakUsage)
            {
                this.ColSound.Broken = false;
                this.ColSound.BrokenC = false;
            }
        }
    }

    public virtual void DestroySequence()
    {
        int ie = 0;
        int ij = 0;
        int ii = 0;
        int ip = 0;
        int i3 = 0;
        int i5 = 0;
        int i6 = 0;
        int i7 = 0;
        int i8 = 0;
        int i4 = 0;
        int i2 = 0;
        if (this.IsPiriCeptopod)
        {
            FurtherActionScript.instance.PiriCeptopodOof = true;
            FurtherActionScript.instance.ShowText();
        }
        if (this.IsPersonalDrone)
        {
            FurtherActionScript.instance.PersonalDroneOof = true;
            FurtherActionScript.instance.ShowText();
        }
        if (this.ResetDrag)
        {
            this.Vehicle.GetComponent<Rigidbody>().drag = 0.1f;
            this.Vehicle.GetComponent<Rigidbody>().angularDrag = 0.1f;
        }
        if (this.ResetGravity)
        {
            this.Vehicle.GetComponent<Rigidbody>().useGravity = true;
        }
        if (!this.SpaceOnce)
        {
            if (this.BrokenSound)
            {
                GameObject TheThing = UnityEngine.Object.Instantiate(this.BrokenSound, this.BrokenEffectArea.transform.position, this.BrokenEffectArea.transform.rotation);
                if (!this.UnparentBrokenSound)
                {
                    TheThing.transform.parent = this.gameObject.transform;
                }
                else
                {
                    TheThing.transform.parent = null;
                }
            }
        }
        if (this.OnboardBrokenSound && !this.DeployOnBreakVessel)
        {
            this.OnboardBrokenSound.gameObject.SetActive(true);
        }
        if (this.TheThingie)
        {
            UnityEngine.Object.Destroy(this.TheThingie);
        }
        if (this.Rotator)
        {
            UnityEngine.Object.Destroy(this.Rotator);
        }
        if (this.Sound)
        {
            UnityEngine.Object.Destroy(this.Sound);
        }
        if (this.RadarController)
        {
            UnityEngine.Object.Destroy(this.RadarController);
        }
        if (this.DestroyAI)
        {
            UnityEngine.Object.Destroy(this.AI.GetComponent(this.AIName));
        }
        if (this.AIrigidbody)
        {
            this.AIrigidbody.freezeRotation = false;
        }
        if (this.AITrig)
        {
            this.AITrig.center = new Vector3(0, 0, 0);
            this.AITrig.radius = 0.1f;
            this.AITrig.height = 0.1f;
            this.AITrig.gameObject.layer = 23;
            this.AITrig.isTrigger = false;
        }
        if (this.PlayerControlled)
        {
            this.Vehicle.GetComponent<MainVehicleController>().SetState(true);
            if (this.Vehicle.GetComponent<NewgunController>() != null)
            {
                this.Vehicle.GetComponent<NewgunController>().Broken = true;
            }
            //if (this.Vehicle.GetComponent<NewgunControllerStatic>() != null)
            //{
            //    this.Vehicle.GetComponent<NewgunControllerStatic>().Broken = true;
            //}
            if (this.Vehicle.GetComponent<NewgunControllerTurret>() != null)
            {
                this.Vehicle.GetComponent<NewgunControllerTurret>().Broken = true;
            }
            if (this.Vehicle.GetComponent<LauncherScript>() != null)
            {
                this.Vehicle.GetComponent<LauncherScript>().Broken = true;
            }
        }
        if (!(this.WhatToUnchild == null))
        {
            ie = 0;
            while (ie < this.WhatToUnchild.Length)
            {
                if (this.WhatToUnchild[ie] != null)
                {
                    if (this.WhatToUnchild[ie].GetComponent<TrailScript>() != null)
                    {
                        this.WhatToUnchild[ie].GetComponent<TrailScript>().Stop = true;
                    }
                    this.WhatToUnchild[ie].gameObject.AddComponent<KillOverTime>();
                    this.WhatToUnchild[ie].parent = null;
                }
                ie++;
            }
        }
        if (!(this.WhatToUnjoint == null))
        {
            ij = 0;
            while (ij < this.WhatToUnjoint.Length)
            {
                UnityEngine.Object.Destroy(this.WhatToUnjoint[ij]);
                ij++;
            }
        }
        if (!(this.WhatToDestroy == null))
        {
            ii = 0;
            while (ii < this.WhatToDestroy.Length)
            {
                UnityEngine.Object.Destroy(this.WhatToDestroy[ii].gameObject);
                ii++;
            }
        }
        if (!(this.ParticleFX == null))
        {
            ip = 0;
            while (ip < this.ParticleFX.Length)
            {
                this.ParticleFX[ip].enableEmission = false;
                this.ParticleFX[ip].emissionRate = 0;
                ip++;
            }
        }
        if (!(this.EngineEffects == null))
        {
            i3 = 0;
            while (i3 < this.EngineEffects.Length)
            {
                if (this.EngineEffects[i3].GetComponent<ThrusterLights>() != null)
                {
                    this.EngineEffects[i3].GetComponent<ThrusterLights>().Broken = true;
                }
                if (this.EngineEffects[i3].GetComponent<AircraftThrusterLights>() != null)
                {
                    this.EngineEffects[i3].GetComponent<AircraftThrusterLights>().Broken = true;
                }
                if (this.EngineEffects[i3].GetComponent<ExhaustSmoke>() != null)
                {
                    this.EngineEffects[i3].GetComponent<ExhaustSmoke>().Broken = true;
                }
                i3++;
            }
        }
        if (!(this.Props == null))
        {
            i5 = 0;
            while (i5 < this.Props.Length)
            {
                if (this.Props[i5].GetComponent<PropSpin>() != null)
                {
                    this.Props[i5].GetComponent<PropSpin>().Broken = true;
                }
                i5++;
            }
        }
        if (!(this.Wings == null))
        {
            i6 = 0;
            while (i6 < this.Wings.Length)
            {
                if (this.Wings[i6].GetComponent<WingScript>() != null)
                {
                    this.Wings[i6].GetComponent<WingScript>().Broken = true;
                }
                i6++;
            }
        }
        if (!(this.PartsResetDrag == null))
        {
            i7 = 0;
            while (i7 < this.PartsResetDrag.Length)
            {
                if (this.PartsResetDrag[i7].gameObject != null)
                {
                    this.PartsResetDrag[i7].GetComponent<Rigidbody>().drag = 0.05f;
                }
                i7++;
            }
        }
        if (!(this.PartsResetGrav == null))
        {
            i8 = 0;
            while (i8 < this.PartsResetGrav.Length)
            {
                if (this.PartsResetGrav[i8].gameObject != null)
                {
                    this.PartsResetGrav[i8].GetComponent<Rigidbody>().useGravity = true;
                }
                i8++;
            }
        }
        if (!(this.HingeStop == null))
        {
            i4 = 0;
            while (i4 < this.HingeStop.Length)
            {
                if (this.HingeStop[i4] != null)
                {
                    this.HingeStop[i4].useMotor = false;

                    {
                        float _3708 = 0.02f;
                        JointSpring _3709 = this.HingeStop[i4].spring;
                        _3709.damper = _3708;
                        this.HingeStop[i4].spring = _3709;
                    }

                    {
                        int _3710 = 0;
                        JointMotor _3711 = this.HingeStop[i4].motor;
                        _3711.targetVelocity = _3710;
                        this.HingeStop[i4].motor = _3711;
                    }

                    {
                        int _3712 = 0;
                        JointMotor _3713 = this.HingeStop[i4].motor;
                        _3713.force = _3712;
                        this.HingeStop[i4].motor = _3713;
                    }
                }
                i4++;
            }
        }
        if (this.UsesWMC == true)
        {
            i2 = 0;
            while (i2 < this.WMCs.Length)
            {
                this.WMCs[i2].GetComponent<WheelMotorController>().Broken = true;
                i2++;
            }
        }
        this.transform.name = "broken";
        this.StartCoroutine(this.Break1());
    }

    public virtual IEnumerator Break1()
    {
        int i1 = 0;
        int i9 = 0;
        if (this.DeployOnBreakVessel)
        {
            this.StartCoroutine(this.Deploy());
        }
        if (!this.UseDetonate)
        {
            yield return new WaitForSeconds(this.SecondBreakDelay);
            if (this.SecondBrokenSound)
            {
                GameObject TheThing2 = UnityEngine.Object.Instantiate(this.SecondBrokenSound, this.BrokenEffectArea.transform.position, this.BrokenEffectArea.transform.rotation);
                if (!this.UnparentSecondBrokenSound)
                {
                    TheThing2.transform.parent = this.gameObject.transform;
                }
                else
                {
                    TheThing2.transform.parent = null;
                }
            }
            if (this.OnboardBrokenSound)
            {
                if (this.DeployOnBreakVessel)
                {
                    this.OnboardBrokenSound.gameObject.SetActive(true);
                }
            }
            if (this.Dislodge)
            {
                if (this.ConJoint)
                {
                    UnityEngine.Object.Destroy(this.ConJoint);
                }
                else
                {
                    UnityEngine.Object.Destroy(this.SprJoint);
                }
            }
            if (this.GunController)
            {
                UnityEngine.Object.Destroy(this.GunController);
            }
            if (!(this.SecondWhatToDestroy == null))
            {
                i1 = 0;
                while (i1 < this.SecondWhatToDestroy.Length)
                {
                    UnityEngine.Object.Destroy(this.SecondWhatToDestroy[i1].gameObject);
                    i1++;
                }
            }
            if (this.Part1Lock)
            {
                this.Locking = true;
            }
            if (this.ExplosiveVessel)
            {
                this.Explode();
            }
            yield return new WaitForSeconds(this.FinalBreakDelay);
            if (this.OnboardBrokenSound)
            {
                if (this.UnparentOBBrokenSound)
                {
                    this.OnboardBrokenSound.transform.parent = null;
                }
            }
            if (this.BrokenSubPart1 || this.BrokenSubPart2)
            {
                this.BrokenSubPart1.SetActive(true);
                this.BrokenSubPart2.SetActive(true);
                this.BrokenSubPart1.transform.parent = null;
                this.BrokenSubPart2.transform.parent = null;
                this.BrokenSubPart1.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity * 1;
                this.BrokenSubPart2.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity * 1;
                UnityEngine.Object.Destroy(this.gameObject);
            }
            if (this.Helirotor)
            {
                yield return new WaitForSeconds(1);
                this.TorqueScript.Power = 900;
                yield return new WaitForSeconds(0.5f);
                this.TorqueScript.Power = 800;
                yield return new WaitForSeconds(0.5f);
                this.TorqueScript.Power = 700;
                yield return new WaitForSeconds(0.4f);
                this.TorqueScript.Power = 600;
                yield return new WaitForSeconds(0.4f);
                this.TorqueScript.Power = 500;
                yield return new WaitForSeconds(0.3f);
                this.TorqueScript.Power = 400;
                yield return new WaitForSeconds(0.3f);
                this.TorqueScript.Power = 300;
                yield return new WaitForSeconds(0.2f);
                UnityEngine.Object.Destroy(this.Rotor);

                {
                    int _3714 = 2;
                    JointSpring _3715 = this.GetComponent<HingeJoint>().spring;
                    _3715.damper = _3714;
                    this.GetComponent<HingeJoint>().spring = _3715;
                }
                this.GetComponent<Rigidbody>().angularDrag = 0.05f;
                i9 = 0;
                while (i9 < this.LimbSections.Length)
                {

                    {
                        int _3716 = 5;
                        JointDrive _3717 = ((ConfigurableJoint) this.LimbSections[i9].GetComponent(typeof(ConfigurableJoint))).angularXDrive;
                        _3717.positionSpring = _3716;
                        ((ConfigurableJoint) this.LimbSections[i9].GetComponent(typeof(ConfigurableJoint))).angularXDrive = _3717;
                    }

                    {
                        int _3718 = 5;
                        JointDrive _3719 = ((ConfigurableJoint) this.LimbSections[i9].GetComponent(typeof(ConfigurableJoint))).angularYZDrive;
                        _3719.positionSpring = _3718;
                        ((ConfigurableJoint) this.LimbSections[i9].GetComponent(typeof(ConfigurableJoint))).angularYZDrive = _3719;
                    }
                    this.LimbSections[i9].GetComponent<Rigidbody>().drag = 0.1f;
                    this.LimbSections[i9].GetComponent<Rigidbody>().useGravity = true;
                    i9++;
                }
            }
        }
    }

    public virtual void RemoteDet()
    {
        if (!this.DetOnce)
        {
            this.DetOnce = true;
            this.StartCoroutine(this.Detonate());
        }
    }

    public virtual IEnumerator DetTimer()
    {
        if (!this.DetOnce)
        {
            this.DetOnce = true;
            yield return new WaitForSeconds(5);
            this.StartCoroutine(this.Detonate());
        }
    }

    public virtual void Timer()
    {
        if (!this.CanRegenerate)
        {
            if (this.Health > this.StaticHealth)
            {
                FollowHorizon.LevelRot = 180;
            }
        }
    }

    public virtual IEnumerator Detonate()
    {
        int i1 = 0;
        if (this.SecondBrokenSound)
        {
            GameObject TheThing2 = UnityEngine.Object.Instantiate(this.SecondBrokenSound, this.BrokenEffectArea.transform.position, this.BrokenEffectArea.transform.rotation);
            if (!this.UnparentSecondBrokenSound)
            {
                TheThing2.transform.parent = this.gameObject.transform;
            }
            else
            {
                TheThing2.transform.parent = null;
            }
        }
        if (this.OnboardBrokenSound)
        {
            if (this.DeployOnBreakVessel)
            {
                this.OnboardBrokenSound.gameObject.SetActive(true);
            }
        }
        if (this.GunController)
        {
            UnityEngine.Object.Destroy(this.GunController);
        }
        if (!(this.SecondWhatToDestroy == null))
        {
            i1 = 0;
            while (i1 < this.SecondWhatToDestroy.Length)
            {
                UnityEngine.Object.Destroy(this.SecondWhatToDestroy[i1].gameObject);
                i1++;
            }
        }
        yield return new WaitForSeconds(this.FinalBreakDelay);
        if (this.ExplosiveVessel)
        {
            this.Explode();
        }
    }

    public virtual IEnumerator Deploy()
    {
        yield return new WaitForSeconds(this.DeployDelay);
        this.Gates.GetComponent<AudioSource>().Play();
        if (!this.GateJoint)
        {
            this.Gates.GetComponent<Animation>().Play();
        }
        else
        {
            UnityEngine.Object.Destroy(this.GateJoint);
            if (this.GateJoint2)
            {
                UnityEngine.Object.Destroy(this.GateJoint2);
                this.Gates2.GetComponent<Rigidbody>().velocity = this.Gates2.transform.forward * -24;
                this.Gates2.transform.parent = null;
            }
            this.Gates.GetComponent<Rigidbody>().velocity = this.Gates.transform.forward * -24;
            this.Gates.transform.parent = null;
        }
        if (this.DeployeeArea1)
        {
            this.Deployee1GO = UnityEngine.Object.Instantiate(this.DeployeeFab1, this.DeployeeArea1.transform.position, this.DeployeeArea1.transform.rotation);
            if (this.TargetCode == 7)
            {
                ((MevNavClouterAI) this.Deployee1GO.transform.GetChild(0).GetComponent(typeof(MevNavClouterAI))).DeusDamage = this;
                this.Deployee1AIGO = this.Deployee1GO.transform.GetChild(0).gameObject;
                this.Deployee1IsOut = true;
            }
        }
        if (this.DeployeeArea2)
        {
            GameObject _SpawnedObject2 = UnityEngine.Object.Instantiate(this.DeployeeFab2, this.DeployeeArea2.transform.position, this.DeployeeArea2.transform.rotation);
            if (this.TargetCode == 7)
            {
                ((MevNavShieldAI) _SpawnedObject2.transform.GetChild(0).GetComponent(typeof(MevNavShieldAI))).Home = this.Deployee1GO.transform.GetChild(1).transform;
            }
        }
        if (this.DeployeeArea3)
        {
            GameObject _SpawnedObject3 = UnityEngine.Object.Instantiate(this.DeployeeFab3, this.DeployeeArea3.transform.position, this.DeployeeArea3.transform.rotation);
            if (this.TargetCode == 7)
            {
                ((MevNavShieldAI) _SpawnedObject3.transform.GetChild(0).GetComponent(typeof(MevNavShieldAI))).Home = this.Deployee1GO.transform.GetChild(1).transform;
            }
        }
        if (this.DeployeeArea4)
        {
            GameObject _SpawnedObject4 = UnityEngine.Object.Instantiate(this.DeployeeFab4, this.DeployeeArea4.transform.position, this.DeployeeArea4.transform.rotation);
            if (this.TargetCode == 7)
            {
                ((MevNavShieldAI) _SpawnedObject4.transform.GetChild(0).GetComponent(typeof(MevNavShieldAI))).Home = this.Deployee1GO.transform.GetChild(1).transform;
            }
        }
        if (this.DeployeeArea5)
        {
            GameObject _SpawnedObject5 = UnityEngine.Object.Instantiate(this.DeployeeFab5, this.DeployeeArea5.transform.position, this.DeployeeArea5.transform.rotation);
            if (this.TargetCode == 7)
            {
                ((MevNavShieldAI) _SpawnedObject5.transform.GetChild(0).GetComponent(typeof(MevNavShieldAI))).Home = this.Deployee1GO.transform.GetChild(1).transform;
            }
        }
        if (this.DeployeeArea6)
        {
            GameObject _SpawnedObject6 = UnityEngine.Object.Instantiate(this.DeployeeFab6, this.DeployeeArea6.transform.position, this.DeployeeArea6.transform.rotation);
            if (this.TargetCode == 7)
            {
                ((MevNavShieldAI) _SpawnedObject6.transform.GetChild(0).GetComponent(typeof(MevNavShieldAI))).Home = this.Deployee1GO.transform.GetChild(1).transform;
            }
        }
        if (this.DeployeeArea7)
        {
            GameObject _SpawnedObject7 = UnityEngine.Object.Instantiate(this.DeployeeFab7, this.DeployeeArea7.transform.position, this.DeployeeArea7.transform.rotation);
            if (this.TargetCode == 7)
            {
                ((MevNavShieldAI) _SpawnedObject7.transform.GetChild(0).GetComponent(typeof(MevNavShieldAI))).Home = this.Deployee1GO.transform.GetChild(1).transform;
            }
        }
    }

    public virtual IEnumerator Hit()
    {
        yield return new WaitForSeconds(1.6f);
        this.HeavyHit = false;
    }

    public virtual void Tick()
    {
        if (this.Locking)
        {
            Debug.DrawRay(this.transform.position, Vector3.down * this.LockDist, Color.red);
            if (Physics.Raycast(this.transform.position, Vector3.down, this.LockDist, (int) this.MtargetLayers))
            {
                if (this.Part1Lock)
                {
                    if (((HingeJoint) this.Part1Lock.GetComponent(typeof(HingeJoint))) != null)
                    {
                        UnityEngine.Object.Destroy((HingeJoint) this.Part1Lock.GetComponent(typeof(HingeJoint)));
                    }
                    if (((CharacterJoint) this.Part1Lock.GetComponent(typeof(CharacterJoint))) != null)
                    {
                        UnityEngine.Object.Destroy((CharacterJoint) this.Part1Lock.GetComponent(typeof(CharacterJoint)));
                    }
                    UnityEngine.Object.Destroy(this.Part1Lock.GetComponent<Rigidbody>());
                }
                if (this.Part2Lock)
                {
                    if (((HingeJoint) this.Part2Lock.GetComponent(typeof(HingeJoint))) != null)
                    {
                        UnityEngine.Object.Destroy((HingeJoint) this.Part2Lock.GetComponent(typeof(HingeJoint)));
                    }
                    if (((CharacterJoint) this.Part2Lock.GetComponent(typeof(CharacterJoint))) != null)
                    {
                        UnityEngine.Object.Destroy((CharacterJoint) this.Part2Lock.GetComponent(typeof(CharacterJoint)));
                    }
                    UnityEngine.Object.Destroy(this.Part2Lock.GetComponent<Rigidbody>());
                }
                if (this.Part3Lock)
                {
                    if (((HingeJoint) this.Part3Lock.GetComponent(typeof(HingeJoint))) != null)
                    {
                        UnityEngine.Object.Destroy((HingeJoint) this.Part3Lock.GetComponent(typeof(HingeJoint)));
                    }
                    if (((CharacterJoint) this.Part3Lock.GetComponent(typeof(CharacterJoint))) != null)
                    {
                        UnityEngine.Object.Destroy((CharacterJoint) this.Part3Lock.GetComponent(typeof(CharacterJoint)));
                    }
                    UnityEngine.Object.Destroy(this.Part3Lock.GetComponent<Rigidbody>());
                }
                if (this.Part4Lock)
                {
                    if (((HingeJoint) this.Part4Lock.GetComponent(typeof(HingeJoint))) != null)
                    {
                        UnityEngine.Object.Destroy((HingeJoint) this.Part4Lock.GetComponent(typeof(HingeJoint)));
                    }
                    if (((CharacterJoint) this.Part4Lock.GetComponent(typeof(CharacterJoint))) != null)
                    {
                        UnityEngine.Object.Destroy((CharacterJoint) this.Part4Lock.GetComponent(typeof(CharacterJoint)));
                    }
                    UnityEngine.Object.Destroy(this.Part4Lock.GetComponent<Rigidbody>());
                }
                if (this.Part5Lock)
                {
                    if (((HingeJoint) this.Part5Lock.GetComponent(typeof(HingeJoint))) != null)
                    {
                        UnityEngine.Object.Destroy((HingeJoint) this.Part5Lock.GetComponent(typeof(HingeJoint)));
                    }
                    if (((CharacterJoint) this.Part5Lock.GetComponent(typeof(CharacterJoint))) != null)
                    {
                        UnityEngine.Object.Destroy((CharacterJoint) this.Part5Lock.GetComponent(typeof(CharacterJoint)));
                    }
                    UnityEngine.Object.Destroy(this.Part5Lock.GetComponent<Rigidbody>());
                }
                if (this.Part6Lock)
                {
                    if (((HingeJoint) this.Part6Lock.GetComponent(typeof(HingeJoint))) != null)
                    {
                        UnityEngine.Object.Destroy((HingeJoint) this.Part6Lock.GetComponent(typeof(HingeJoint)));
                    }
                    if (((CharacterJoint) this.Part6Lock.GetComponent(typeof(CharacterJoint))) != null)
                    {
                        UnityEngine.Object.Destroy((CharacterJoint) this.Part6Lock.GetComponent(typeof(CharacterJoint)));
                    }
                    UnityEngine.Object.Destroy(this.Part6Lock.GetComponent<Rigidbody>());
                }
                if (this.PartFinal)
                {
                    this.PartFinal.mass = this.PartFinalMass;
                }
                this.Locking = false;
            }
        }
        if (this.OtherDamage)
        {
            if (this.OtherDamage.Health < 1)
            {
                this.DamageIn(2048, 0, 0, false);
            }
        }
        if (this.Deployee1IsOut)
        {
            if (!this.Deployee1AIGO)
            {
                if (!this.DetOnce)
                {
                    this.StartCoroutine(this.DetTimer());
                }
            }
        }
        this.Timer();
        if (!this.PlayerControlled)
        {
            return;
        }
        if (WorldInformation.playerCar == this.Vehicle.name)
        {
            if (this.Health < this.HealthThreshold)
            {
                IndicatorScript.VehicleIsDamaged = true;
            }
            this.IsInside = true;
        }
        else
        {
            this.IsInside = false;
        }
    }

    public virtual void Explode()
    {
        if (this.ExplodeParent)
        {
            this.transform.parent.gameObject.AddComponent<KillOverTime>();
            this.gameObject.SetActive(false);
        }
        else
        {
            UnityEngine.Object.Destroy(this.gameObject);
        }
        if (!this.LocalOriExp)
        {
            UnityEngine.Object.Instantiate(this.Explosion, this.BrokenEffectArea.transform.position, this.Explosion.transform.rotation);
        }
        else
        {
            UnityEngine.Object.Instantiate(this.Explosion, this.BrokenEffectArea.transform.position, this.BrokenEffectArea.transform.rotation);
        }
    }

    public virtual void PiriHurt()
    {
        if (this.PlayerControlled)
        {
            this.StartCoroutine(WorldInformation.instance.Hurt());
        }
    }

    public VehicleDamage()
    {
        this.Health = 10;
        this.StaticHealth = 10;
        this.HealthThreshold = 10;
        this.HurtThreshold = 10;
        this.scalarForceCurve = new AnimationCurve();
        this.RegenAmount = 0.005f;
        this.DamageReceival = 0.5f;
        this.DeployDelay = 6;
        this.AIName = "PersonMcPersonface";
        this.BreakDelay = 0.05f;
        this.SecondBreakDelay = 0.05f;
        this.PartFinalMass = 1;
        this.LockDist = 6;
    }

}