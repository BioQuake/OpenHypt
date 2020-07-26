using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class NewgunController : MonoBehaviour
{
    public Transform AimTarget;
    public Transform thisTransform;
    public Rigidbody thisRB;
    public bool SecondaryGun;
    public Transform SecondaryGunITF;
    public Transform SecondaryGunTF;
    public Transform SecondaryGunTF2;
    public Transform SecondaryGunTF3;
    public Transform SecondaryGunTF4;
    public bool SecondaryGunTFActive;
    public bool SecondaryGunTF2Active;
    public bool SecondaryGunTF3Active;
    public bool SecondaryGunTF4Active;
    public bool alsoHasSecondGun;
    public bool alsoHasThirdGun;
    public bool hasMultipleGuns;
    public int gunUsed;
    public SubDamage gun0HealthScript;
    public SubDamage gun1HealthScript;
    public SubDamage gun2HealthScript;
    public bool IsRetractable;
    public bool SimpleHinge;
    public HingeJoint hinge;
    public HingeJoint hinge2;
    public bool IsBeam;
    public GameObject BeamEffect;
    public GameObject BeamLongEffect;
    public GameObject BeamLongEffect2;
    public GameObject BeamStartEffect;
    public GameObject BeamOffEffect;
    public GameObject BeamAudio;
    public GameObject BeamSection;
    public bool FireUsingMouse;
    public bool SpeedyShooter;
    public bool UsingRecoilSec;
    public bool UsingSoundSec;
    public bool UsingSoundPri;
    public AudioClip PrimarySound;
    public AudioClip SecondarySound;
    public bool CanBeObscured;
    public bool UseAngles;
    public bool UseLayers;
    public Transform Pivot;
    public int PivMax;
    public int PivMin;
    public float ForePauseTime;
    public float ForePauseTimeSec;
    public GameObject ForePauseSound;
    public GameObject ForePauseSoundSec;
    public float SpinAcceleration;
    public float SpinAccelerationSec;
    public float BarrelSpinSpeed;
    public float BarrelSpinSpeedSec;
    public float StaticSpinSpeed;
    public float StaticSpinSpeedSec;
    public GameObject AmmoBay;
    public GameObject AmmoBay2;
    public GameObject AmmoBaySec;
    public AmmoBay AmmoBayScript;
    public AmmoBay AmmoBayScript2;
    public AmmoBay AmmoBaySecScript;
    public GameObject Ammunition;
    public GameObject SecondaryAmmunition;
    public GameObject AmmunitionG2;
    public GameObject AmmunitionG3;
    public GameObject FlarePrefab;
    public GameObject SecondaryFlarePrefab;
    public Transform FlareLocation;
    public Transform SecondaryFlareLocation;
    public Transform BulletLocation;
    public Transform BulletLocationG2;
    public Transform BulletLocationG3;
    public Transform BulletLocationVolley1;
    public SphereCollider BulletLocationCol;
    public SphereCollider BulletLocationColG2;
    public SphereCollider BulletLocationColG3;
    public SphereCollider BulletLocationColVolley1;
    public Transform SecondaryBulletLocation;
    public Transform SecondaryBulletLocation2;
    public Transform SecondaryBulletLocation3;
    public Transform SecondaryBulletLocation4;
    public Transform SecondaryLoopSoundLocation;
    public Transform DischargedBit1;
    public GameObject DischargedBit1P;
    public GameObject DischargedBit1Model;
    public float DischargedBitDelay;
    public int DischargedBitVelocity;
    public float DischargedBitTorque;
    public bool HasMovingBits;
    public Transform MovingBit1;
    public float MB1Speed;
    public float MB1EndValue;
    public Transform ShockwaveLocation;
    public Transform ShockwaveLocationG2;
    public Transform ShockwaveLocationG3;
    public Transform ShockwaveLocationVolley1;
    public GameObject RecoilAnimationObject;
    public string RecoilAnimationName;
    public GameObject RecoilAnimationObjectG2;
    public string RecoilAnimationNameG2;
    public GameObject RecoilAnimationObjectG3;
    public string RecoilAnimationNameG3;
    public GameObject RecoilAnimationObjectVolley1;
    public string RecoilAnimationNameVolley1;
    public bool UseRecoilCurve;
    public AnimationCurve RecoilCurve;
    public Transform Gun1Model;
    public Transform Gun2Model;
    public int G1RN;
    public int G2RN;
    public bool Gun1RecoFire;
    public bool Gun2RecoFire;
    public GameObject HatchAniObject;
    public string Closing;
    public string Opening;
    public string GunForward;
    public string GunBack;
    public GameObject ActivateSound;
    public GameObject DeactivateSound;
    public bool useAudioPri;
    public bool useAudioSec;
    public bool canLoop;
    public bool canLoopSec;
    public AudioSource gSound;
    public AudioSource gSoundSec;
    public bool useAudioPrefabs;
    public GameObject gSoundPref;
    public GameObject gSoundSecPref;
    public GameObject gSoundPrefInst;
    public GameObject gSoundSecPrefInst;
    public TurretAim Aimer;
    public TurretAim Aimer2;
    public GameObject GunBase;
    public GameObject NewGunBase;
    public Transform BarrelTF;
    public Transform BarrelSecTF;
    public bool HullShock;
    public int HullShockForce;
    public float HullShockForceDelay;
    public int HullShockSecForce;
    public float Spread;
    public int ShotNum;
    public bool Volley;
    public float VolleyTime;
    public bool ContinuousBeam;
    public bool Beaming;
    public bool Broken;
    public bool SecBroken;
    public bool VolleyBroken;
    public bool CanFire;
    public bool CanFireSec;
    public bool CanFireG2;
    public bool CanFireG3;
    public bool Obscured;
    public bool IsShooting;
    public bool IsAnimating;
    public bool IsOut;
    public bool isInside;
    public float GunCooldown;
    public float GunCooldownG2;
    public float GunCooldownG3;
    public float SecondaryGunCooldown;
    private float xStartTime;
    private float xStartTimeSec;
    private float xStartTimeG2;
    private float xStartTimeG3;
    private float gunTimer;
    private float gunTimerSec;
    private float gunTimerG2;
    private float gunTimerG3;
    public bool Locked;
    public bool LockedSec;
    public float maxVolume;
    public float incrementValue;
    public float decrementValue;
    private string state;
    public LayerMask targetLayers;
    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 0.17f, 0.17f);
        this.InvokeRepeating("SectionShot", 0.05f, 0.05f);
        this.CanFireSec = true;
        if (this.IsRetractable)
        {
            this.Aimer.Activated = false;
            if (this.Aimer2)
            {
                this.Aimer2.Activated = false;
            }
            if (!this.IsOut)
            {
                this.CanFire = false;
            }
        }
        this.StaticSpinSpeed = this.BarrelSpinSpeed;
        this.StaticSpinSpeedSec = this.BarrelSpinSpeedSec;
        this.BulletLocationCol = this.BulletLocation.GetComponent<SphereCollider>();
        this.BulletLocationCol.enabled = false;
        if (this.BulletLocationColVolley1)
        {
            this.BulletLocationColVolley1 = this.BulletLocation.GetComponent<SphereCollider>();
            this.BulletLocationColVolley1.enabled = false;
        }
        this.AimTarget = GameObject.Find("AimPointTarget").gameObject.transform;
        if (this.AmmoBay)
        {
            this.AmmoBayScript = (AmmoBay) this.AmmoBay.GetComponent("AmmoBay");
        }
        if (this.AmmoBaySec)
        {
            this.AmmoBaySecScript = (AmmoBay) this.AmmoBaySec.GetComponent("AmmoBay");
        }
    }

    private Quaternion NewRotation;
    public virtual void Update()
    {
        if (WorldInformation.playerCar == this.gameObject.name)
        {
            if (this.CanBeObscured)
            {
                this.Obscured = false;
                if (this.UseAngles)
                {
                    if ((this.Pivot.localEulerAngles.z < this.PivMax) || (this.Pivot.localEulerAngles.z > this.PivMin))
                    {
                        this.Obscured = true;
                    }
                }
            }
            if (this.hasMultipleGuns)
            {
                if (Input.GetKeyDown("1"))
                {
                    this.gunUsed = 0;
                    this.gun0HealthScript.Tick();
                    FurtherActionScript.instance.UsingTurret1 = true;
                    FurtherActionScript.instance.ShowText();
                }
                if (Input.GetKeyDown("2"))
                {
                    this.gunUsed = 1;
                    this.gun1HealthScript.Tick();
                    FurtherActionScript.instance.UsingTurret2 = true;
                    FurtherActionScript.instance.ShowText();
                }
                if (Input.GetKeyDown("3"))
                {
                    this.gunUsed = 2;
                    this.gun2HealthScript.Tick();
                    FurtherActionScript.instance.UsingTurret3 = true;
                    FurtherActionScript.instance.ShowText();
                }
            }
            if (this.Broken)
            {
                if (this.canLoop)
                {
                    this.gSound.loop = false;
                }
                if (this.canLoopSec)
                {
                    if (!this.useAudioPrefabs)
                    {
                        this.gSoundSec.loop = false;
                    }
                    else
                    {
                        if (this.gSoundSecPrefInst)
                        {
                            this.gSoundSecPrefInst.GetComponent<AudioSource>().loop = false;
                            this.gSoundSecPrefInst = null;
                        }
                    }
                }
            }
            this.isInside = true;
            if (this.IsBeam)
            {
                if (!this.Broken)
                {
                    if (!CameraScript.InInterface)
                    {
                        if ((Mathf.Abs(this.xStartTime - Time.time) >= this.gunTimer) && this.CanFire)
                        {
                            if ((Input.GetKeyDown("4") && (this.FireUsingMouse == false)) || (Input.GetMouseButtonDown(0) && (this.FireUsingMouse == true)))
                            {
                                this.BeamEffect.SetActive(true);
                                this.BeamLongEffect.GetComponent<ParticleSystem>().enableEmission = true;
                                this.BeamLongEffect2.GetComponent<ParticleSystem>().enableEmission = true;
                                this.BeamShoot();
                                this.Beaming = true;
                            }
                            if ((Input.GetKeyUp("4") && (this.FireUsingMouse == false)) || (Input.GetMouseButtonUp(0) && (this.FireUsingMouse == true)))
                            {
                                this.xStartTime = Time.time;
                                this.gunTimer = 0.5f;
                                this.BeamEffect.SetActive(false);
                                this.BeamLongEffect.GetComponent<ParticleSystem>().enableEmission = false;
                                this.BeamLongEffect2.GetComponent<ParticleSystem>().enableEmission = false;
                                this.Beaming = false;
                                GameObject TheThingie = UnityEngine.Object.Instantiate(this.BeamOffEffect, this.BeamAudio.transform.position, this.BeamAudio.transform.rotation);
                                TheThingie.transform.parent = this.transform;
                            }
                        }
                    }
                    if (this.Beaming == true)
                    {
                        this.state = "increment";
                    }
                    if (this.Beaming == false)
                    {
                        this.state = "decrement";
                    }
                    if (this.state == "increment")
                    {
                        this.increment();
                    }
                    else
                    {
                        if (this.state == "decrement")
                        {
                            this.decrement();
                        }
                    }
                }
            }
            else
            {
                if (!CameraScript.InInterface)
                {
                    if (this.FireUsingMouse)
                    {
                        if (this.useAudioPri)
                        {
                            if (!this.gSound.isPlaying)
                            {
                                if (Input.GetMouseButtonDown(0))
                                {
                                    if (this.CanFire)
                                    {
                                        this.gSound.Stop();
                                    }
                                }
                            }
                        }
                        if (Input.GetMouseButton(0))
                        {
                            if (this.ForePauseTime > 0.1f)
                            {
                                if (Input.GetMouseButtonDown(0))
                                {
                                    this.BarrelSpinSpeed = 0.2f;
                                    this.CanFire = false;
                                    this.StartCoroutine(this.ForePause());
                                }
                            }
                            if (this.BarrelSpinSpeed > 0.1f)
                            {

                                {
                                    float _2404 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                                    Vector3 _2405 = this.BarrelTF.localEulerAngles;
                                    _2405.y = _2404;
                                    this.BarrelTF.localEulerAngles = _2405;
                                }
                            }
                            if (this.gunUsed == 0)
                            {
                                this.StartCoroutine(this.Shoot());
                            }
                            if (this.hasMultipleGuns)
                            {
                                if (this.gunUsed == 1)
                                {
                                    this.ShootG2();
                                }
                                if (this.gunUsed == 2)
                                {
                                    this.ShootG3();
                                }
                            }
                        }
                        else
                        {
                            if (this.useAudioPri)
                            {
                                if (this.canLoop)
                                {
                                    if (this.gSound.isPlaying)
                                    {
                                        this.gSound.loop = false;
                                    }
                                }
                                if (this.canLoopSec)
                                {
                                    this.gSoundSec.loop = false;
                                    if (this.gSoundSecPrefInst)
                                    {
                                        this.gSoundSecPrefInst.GetComponent<AudioSource>().loop = false;
                                        this.gSoundSecPrefInst = null;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.useAudioPri)
                        {
                            if (!this.gSound.isPlaying)
                            {
                                if (Input.GetKeyDown("4"))
                                {
                                    if (this.CanFire)
                                    {
                                        this.gSound.Stop();
                                    }
                                }
                            }
                        }
                        if (Input.GetKey("4"))
                        {
                            if (this.ForePauseTime > 0.1f)
                            {
                                if (Input.GetKeyDown("4"))
                                {
                                    this.BarrelSpinSpeed = 0.2f;
                                    this.CanFire = false;
                                    this.StartCoroutine(this.ForePause());
                                }
                            }
                            if (this.BarrelSpinSpeed > 0.1f)
                            {

                                {
                                    float _2406 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                                    Vector3 _2407 = this.BarrelTF.localEulerAngles;
                                    _2407.y = _2406;
                                    this.BarrelTF.localEulerAngles = _2407;
                                }
                            }
                            if (this.gunUsed == 0)
                            {
                                this.StartCoroutine(this.Shoot());
                            }
                            if (this.hasMultipleGuns)
                            {
                                if (this.gunUsed == 1)
                                {
                                    this.ShootG2();
                                }
                                if (this.gunUsed == 2)
                                {
                                    this.ShootG3();
                                }
                            }
                        }
                        else
                        {
                            if (this.useAudioPri)
                            {
                                if (this.canLoop)
                                {
                                    if (this.gSound.isPlaying)
                                    {
                                        this.gSound.loop = false;
                                    }
                                }
                                if (this.canLoopSec)
                                {
                                    this.gSoundSec.loop = false;
                                    if (this.gSoundSecPrefInst)
                                    {
                                        this.gSoundSecPrefInst.GetComponent<AudioSource>().loop = false;
                                        this.gSoundSecPrefInst = null;
                                    }
                                }
                            }
                        }
                    }
                    if (this.SecondaryGun == true)
                    {
                        if (this.useAudioSec)
                        {
                            if (!this.useAudioPrefabs)
                            {
                                if (!this.gSoundSec.isPlaying)
                                {
                                    if (Input.GetKeyDown("4"))
                                    {
                                        if (this.CanFireSec)
                                        {
                                            this.gSoundSec.Stop();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (Input.GetKeyUp("4"))
                                {
                                    if (this.gSoundSecPrefInst)
                                    {
                                        this.gSoundSecPrefInst.GetComponent<AudioSource>().loop = false;
                                        this.gSoundSecPrefInst = null;
                                    }
                                }
                            }
                        }
                        if (Input.GetKey("4"))
                        {
                            if (this.ForePauseTimeSec > 0.1f)
                            {
                                if (Input.GetKeyDown("4"))
                                {
                                    this.BarrelSpinSpeedSec = 0.2f;
                                    this.CanFire = false;
                                    this.StartCoroutine(this.ForePauseSec());
                                }
                            }
                            if (this.BarrelSpinSpeedSec > 0.1f)
                            {

                                {
                                    float _2408 = this.BarrelSecTF.localEulerAngles.y + this.BarrelSpinSpeedSec;
                                    Vector3 _2409 = this.BarrelSecTF.localEulerAngles;
                                    _2409.y = _2408;
                                    this.BarrelSecTF.localEulerAngles = _2409;
                                }
                            }
                            this.Shoot2();
                        }
                        else
                        {
                            if (this.useAudioSec)
                            {
                                if (this.canLoop)
                                {
                                    if (this.gSound.isPlaying)
                                    {
                                        this.gSound.loop = false;
                                    }
                                }
                                if (this.canLoopSec)
                                {
                                    if (!this.useAudioPrefabs)
                                    {
                                        if (this.gSoundSec.isPlaying)
                                        {
                                            this.gSoundSec.loop = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (this.IsRetractable)
                    {
                        if ((Input.GetKeyDown("0") && !this.IsAnimating) && !this.IsShooting)
                        {
                            this.StartCoroutine(this.GunBoolean());
                        }
                    }
                }
            }
        }
        else
        {
            this.isInside = false;
            if (this.canLoop)
            {
                this.gSound.loop = false;
            }
            if (this.canLoopSec)
            {
                if (!this.useAudioPrefabs)
                {
                    this.gSoundSec.loop = false;
                }
                if (this.gSoundSecPrefInst)
                {
                    this.gSoundSecPrefInst.GetComponent<AudioSource>().loop = false;
                    this.gSoundSecPrefInst = null;
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.SecondaryGunITF)
        {
            this.SecondaryGunTFActive = false;
            this.SecondaryGunTF2Active = false;
            this.SecondaryGunTF3Active = false;
            this.SecondaryGunTF4Active = false;
            this.CanFireSec = false;
            if (Input.GetMouseButton(1))
            {
                if (this.SecondaryGunTF)
                {
                    if ((this.SecondaryGunITF.localEulerAngles.z > 270) && (this.SecondaryGunITF.localEulerAngles.z < 320))
                    {
                        this.NewRotation = Quaternion.LookRotation(this.AimTarget.position - this.SecondaryGunTF.position);
                        this.SecondaryGunTF.rotation = Quaternion.RotateTowards(this.SecondaryGunTF.rotation, this.NewRotation, Time.deltaTime * 100);
                        this.SecondaryGunTFActive = true;
                        if (this.AmmoBaySecScript.PrimaryAmmunition > 0)
                        {
                            this.CanFireSec = true;
                        }
                    }
                }
                if (this.SecondaryGunTF2)
                {
                    if ((this.SecondaryGunITF.localEulerAngles.z > 40) && (this.SecondaryGunITF.localEulerAngles.z < 90))
                    {
                        this.NewRotation = Quaternion.LookRotation(this.AimTarget.position - this.SecondaryGunTF2.position);
                        this.SecondaryGunTF2.rotation = Quaternion.RotateTowards(this.SecondaryGunTF2.rotation, this.NewRotation, Time.deltaTime * 100);
                        this.SecondaryGunTF2Active = true;
                        if (this.AmmoBaySecScript.PrimaryAmmunition > 0)
                        {
                            this.CanFireSec = true;
                        }
                    }
                }
                if (this.SecondaryGunTF3)
                {
                    if ((this.SecondaryGunITF.localEulerAngles.z > 220) && (this.SecondaryGunITF.localEulerAngles.z < 270))
                    {
                        this.NewRotation = Quaternion.LookRotation(this.AimTarget.position - this.SecondaryGunTF3.position);
                        this.SecondaryGunTF3.rotation = Quaternion.RotateTowards(this.SecondaryGunTF3.rotation, this.NewRotation, Time.deltaTime * 100);
                        this.SecondaryGunTF3Active = true;
                        if (this.AmmoBaySecScript.PrimaryAmmunition > 0)
                        {
                            this.CanFireSec = true;
                        }
                    }
                }
                if (this.SecondaryGunTF4)
                {
                    if ((this.SecondaryGunITF.localEulerAngles.z > 90) && (this.SecondaryGunITF.localEulerAngles.z < 140))
                    {
                        this.NewRotation = Quaternion.LookRotation(this.AimTarget.position - this.SecondaryGunTF4.position);
                        this.SecondaryGunTF4.rotation = Quaternion.RotateTowards(this.SecondaryGunTF4.rotation, this.NewRotation, Time.deltaTime * 100);
                        this.SecondaryGunTF4Active = true;
                        if (this.AmmoBaySecScript.PrimaryAmmunition > 0)
                        {
                            this.CanFireSec = true;
                        }
                    }
                }
            }
        }
        if (this.isInside)
        {
            if (this.BarrelSpinSpeed > 0.1f)
            {
                float Proddy1 = 180 - (this.BarrelSpinSpeed * 2);
                float Proddy2 = 360 - (this.BarrelSpinSpeed * 2);
                if ((CameraScript.InInterface == false) && this.CanFire)
                {
                    if (this.FireUsingMouse)
                    {
                        if (Input.GetMouseButton(0))
                        {
                            this.Locked = false;
                            if (this.BarrelSpinSpeed < this.StaticSpinSpeed)
                            {
                                this.BarrelSpinSpeed = this.BarrelSpinSpeed + this.SpinAcceleration;
                            }

                            {
                                float _2410 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                                Vector3 _2411 = this.BarrelTF.localEulerAngles;
                                _2411.y = _2410;
                                this.BarrelTF.localEulerAngles = _2411;
                            }
                        }
                        else
                        {
                            if (this.BarrelSpinSpeed > (this.SpinAcceleration * 10))
                            {
                                this.BarrelSpinSpeed = this.BarrelSpinSpeed - this.SpinAcceleration;
                            }
                            else
                            {
                                this.BarrelSpinSpeed = this.SpinAcceleration * 10;
                            }
                            if (this.BarrelSpinSpeed > (this.SpinAcceleration * 10))
                            {

                                {
                                    float _2412 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                                    Vector3 _2413 = this.BarrelTF.localEulerAngles;
                                    _2413.y = _2412;
                                    this.BarrelTF.localEulerAngles = _2413;
                                }
                            }
                            else
                            {
                                if (!this.Locked)
                                {
                                    if (this.BarrelTF.localEulerAngles.y < 180)
                                    {
                                        if (this.BarrelTF.localEulerAngles.y > Proddy1)
                                        {

                                            {
                                                int _2414 = 180;
                                                Vector3 _2415 = this.BarrelTF.localEulerAngles;
                                                _2415.y = _2414;
                                                this.BarrelTF.localEulerAngles = _2415;
                                            }
                                            this.Locked = true;
                                        }
                                        if (!this.Locked)
                                        {

                                            {
                                                float _2416 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                                                Vector3 _2417 = this.BarrelTF.localEulerAngles;
                                                _2417.y = _2416;
                                                this.BarrelTF.localEulerAngles = _2417;
                                            }
                                        }
                                    }
                                    if (this.BarrelTF.localEulerAngles.y > 180)
                                    {
                                        if (this.BarrelTF.localEulerAngles.y > Proddy2)
                                        {

                                            {
                                                int _2418 = 0;
                                                Vector3 _2419 = this.BarrelTF.localEulerAngles;
                                                _2419.y = _2418;
                                                this.BarrelTF.localEulerAngles = _2419;
                                            }
                                            this.Locked = true;
                                        }
                                        if (!this.Locked)
                                        {

                                            {
                                                float _2420 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                                                Vector3 _2421 = this.BarrelTF.localEulerAngles;
                                                _2421.y = _2420;
                                                this.BarrelTF.localEulerAngles = _2421;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Input.GetKey("4"))
                        {
                            this.Locked = false;
                            if (this.BarrelSpinSpeed < this.StaticSpinSpeed)
                            {
                                this.BarrelSpinSpeed = this.BarrelSpinSpeed + this.SpinAcceleration;
                            }

                            {
                                float _2422 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                                Vector3 _2423 = this.BarrelTF.localEulerAngles;
                                _2423.y = _2422;
                                this.BarrelTF.localEulerAngles = _2423;
                            }
                        }
                        else
                        {
                            if (this.BarrelSpinSpeed > (this.SpinAcceleration * 10))
                            {
                                this.BarrelSpinSpeed = this.BarrelSpinSpeed - this.SpinAcceleration;
                            }
                            else
                            {
                                this.BarrelSpinSpeed = this.SpinAcceleration * 10;
                            }
                            if (this.BarrelSpinSpeed > (this.SpinAcceleration * 10))
                            {

                                {
                                    float _2424 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                                    Vector3 _2425 = this.BarrelTF.localEulerAngles;
                                    _2425.y = _2424;
                                    this.BarrelTF.localEulerAngles = _2425;
                                }
                            }
                            else
                            {
                                if (!this.Locked)
                                {
                                    if (this.BarrelTF.localEulerAngles.y < 180)
                                    {
                                        if (this.BarrelTF.localEulerAngles.y > Proddy1)
                                        {

                                            {
                                                int _2426 = 180;
                                                Vector3 _2427 = this.BarrelTF.localEulerAngles;
                                                _2427.y = _2426;
                                                this.BarrelTF.localEulerAngles = _2427;
                                            }
                                            this.Locked = true;
                                        }
                                        if (!this.Locked)
                                        {

                                            {
                                                float _2428 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                                                Vector3 _2429 = this.BarrelTF.localEulerAngles;
                                                _2429.y = _2428;
                                                this.BarrelTF.localEulerAngles = _2429;
                                            }
                                        }
                                    }
                                    if (this.BarrelTF.localEulerAngles.y > 180)
                                    {
                                        if (this.BarrelTF.localEulerAngles.y > Proddy2)
                                        {

                                            {
                                                int _2430 = 0;
                                                Vector3 _2431 = this.BarrelTF.localEulerAngles;
                                                _2431.y = _2430;
                                                this.BarrelTF.localEulerAngles = _2431;
                                            }
                                            this.Locked = true;
                                        }
                                        if (!this.Locked)
                                        {

                                            {
                                                float _2432 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                                                Vector3 _2433 = this.BarrelTF.localEulerAngles;
                                                _2433.y = _2432;
                                                this.BarrelTF.localEulerAngles = _2433;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (this.BarrelSpinSpeed > (this.SpinAcceleration * 10))
                    {
                        this.BarrelSpinSpeed = this.BarrelSpinSpeed - this.SpinAcceleration;
                    }
                    else
                    {
                        this.BarrelSpinSpeed = this.SpinAcceleration * 10;
                    }
                    if (this.BarrelSpinSpeed > (this.SpinAcceleration * 10))
                    {

                        {
                            float _2434 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                            Vector3 _2435 = this.BarrelTF.localEulerAngles;
                            _2435.y = _2434;
                            this.BarrelTF.localEulerAngles = _2435;
                        }
                    }
                    else
                    {
                        if (!this.Locked)
                        {
                            if (this.BarrelTF.localEulerAngles.y < 180)
                            {
                                if (this.BarrelTF.localEulerAngles.y > Proddy1)
                                {

                                    {
                                        int _2436 = 180;
                                        Vector3 _2437 = this.BarrelTF.localEulerAngles;
                                        _2437.y = _2436;
                                        this.BarrelTF.localEulerAngles = _2437;
                                    }
                                    this.Locked = true;
                                }
                                if (!this.Locked)
                                {

                                    {
                                        float _2438 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                                        Vector3 _2439 = this.BarrelTF.localEulerAngles;
                                        _2439.y = _2438;
                                        this.BarrelTF.localEulerAngles = _2439;
                                    }
                                }
                            }
                            if (this.BarrelTF.localEulerAngles.y > 180)
                            {
                                if (this.BarrelTF.localEulerAngles.y > Proddy2)
                                {

                                    {
                                        int _2440 = 0;
                                        Vector3 _2441 = this.BarrelTF.localEulerAngles;
                                        _2441.y = _2440;
                                        this.BarrelTF.localEulerAngles = _2441;
                                    }
                                    this.Locked = true;
                                }
                                if (!this.Locked)
                                {

                                    {
                                        float _2442 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                                        Vector3 _2443 = this.BarrelTF.localEulerAngles;
                                        _2443.y = _2442;
                                        this.BarrelTF.localEulerAngles = _2443;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (this.BarrelSpinSpeedSec > 0.1f)
            {
                float Proddy1 = 180 - (this.BarrelSpinSpeedSec * 2);
                float Proddy2 = 360 - (this.BarrelSpinSpeedSec * 2);
                if ((CameraScript.InInterface == false) && this.CanFire)
                {
                    if (Input.GetKey("4"))
                    {
                        this.LockedSec = false;
                        if (this.BarrelSpinSpeedSec < this.StaticSpinSpeedSec)
                        {
                            this.BarrelSpinSpeedSec = this.BarrelSpinSpeedSec + this.SpinAccelerationSec;
                        }

                        {
                            float _2444 = this.BarrelSecTF.localEulerAngles.y + this.BarrelSpinSpeedSec;
                            Vector3 _2445 = this.BarrelSecTF.localEulerAngles;
                            _2445.y = _2444;
                            this.BarrelSecTF.localEulerAngles = _2445;
                        }
                    }
                    else
                    {
                        if (this.BarrelSpinSpeedSec > (this.SpinAccelerationSec * 10))
                        {
                            this.BarrelSpinSpeedSec = this.BarrelSpinSpeedSec - this.SpinAccelerationSec;
                        }
                        else
                        {
                            this.BarrelSpinSpeedSec = this.SpinAccelerationSec * 10;
                        }
                        if (this.BarrelSpinSpeedSec > (this.SpinAccelerationSec * 10))
                        {

                            {
                                float _2446 = this.BarrelSecTF.localEulerAngles.y + this.BarrelSpinSpeedSec;
                                Vector3 _2447 = this.BarrelSecTF.localEulerAngles;
                                _2447.y = _2446;
                                this.BarrelSecTF.localEulerAngles = _2447;
                            }
                        }
                        else
                        {
                            if (!this.LockedSec)
                            {
                                if (this.BarrelSecTF.localEulerAngles.y < 180)
                                {
                                    if (this.BarrelSecTF.localEulerAngles.y > Proddy1)
                                    {

                                        {
                                            int _2448 = 180;
                                            Vector3 _2449 = this.BarrelSecTF.localEulerAngles;
                                            _2449.y = _2448;
                                            this.BarrelSecTF.localEulerAngles = _2449;
                                        }
                                        this.LockedSec = true;
                                    }
                                    if (!this.LockedSec)
                                    {

                                        {
                                            float _2450 = this.BarrelSecTF.localEulerAngles.y + this.BarrelSpinSpeedSec;
                                            Vector3 _2451 = this.BarrelSecTF.localEulerAngles;
                                            _2451.y = _2450;
                                            this.BarrelSecTF.localEulerAngles = _2451;
                                        }
                                    }
                                }
                                if (this.BarrelSecTF.localEulerAngles.y > 180)
                                {
                                    if (this.BarrelSecTF.localEulerAngles.y > Proddy2)
                                    {

                                        {
                                            int _2452 = 0;
                                            Vector3 _2453 = this.BarrelSecTF.localEulerAngles;
                                            _2453.y = _2452;
                                            this.BarrelSecTF.localEulerAngles = _2453;
                                        }
                                        this.LockedSec = true;
                                    }
                                    if (!this.LockedSec)
                                    {

                                        {
                                            float _2454 = this.BarrelSecTF.localEulerAngles.y + this.BarrelSpinSpeedSec;
                                            Vector3 _2455 = this.BarrelSecTF.localEulerAngles;
                                            _2455.y = _2454;
                                            this.BarrelSecTF.localEulerAngles = _2455;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (this.BarrelSpinSpeedSec > (this.SpinAccelerationSec * 10))
                    {
                        this.BarrelSpinSpeedSec = this.BarrelSpinSpeedSec - this.SpinAccelerationSec;
                    }
                    else
                    {
                        this.BarrelSpinSpeedSec = this.SpinAccelerationSec * 10;
                    }
                    if (this.BarrelSpinSpeedSec > (this.SpinAccelerationSec * 10))
                    {

                        {
                            float _2456 = this.BarrelSecTF.localEulerAngles.y + this.BarrelSpinSpeedSec;
                            Vector3 _2457 = this.BarrelSecTF.localEulerAngles;
                            _2457.y = _2456;
                            this.BarrelSecTF.localEulerAngles = _2457;
                        }
                    }
                    else
                    {
                        if (!this.LockedSec)
                        {
                            if (this.BarrelSecTF.localEulerAngles.y < 180)
                            {
                                if (this.BarrelSecTF.localEulerAngles.y > Proddy1)
                                {

                                    {
                                        int _2458 = 180;
                                        Vector3 _2459 = this.BarrelSecTF.localEulerAngles;
                                        _2459.y = _2458;
                                        this.BarrelSecTF.localEulerAngles = _2459;
                                    }
                                    this.LockedSec = true;
                                }
                                if (!this.LockedSec)
                                {

                                    {
                                        float _2460 = this.BarrelSecTF.localEulerAngles.y + this.BarrelSpinSpeedSec;
                                        Vector3 _2461 = this.BarrelSecTF.localEulerAngles;
                                        _2461.y = _2460;
                                        this.BarrelSecTF.localEulerAngles = _2461;
                                    }
                                }
                            }
                            if (this.BarrelSecTF.localEulerAngles.y > 180)
                            {
                                if (this.BarrelSecTF.localEulerAngles.y > Proddy2)
                                {

                                    {
                                        int _2462 = 0;
                                        Vector3 _2463 = this.BarrelSecTF.localEulerAngles;
                                        _2463.y = _2462;
                                        this.BarrelSecTF.localEulerAngles = _2463;
                                    }
                                    this.LockedSec = true;
                                }
                                if (!this.LockedSec)
                                {

                                    {
                                        float _2464 = this.BarrelSecTF.localEulerAngles.y + this.BarrelSpinSpeedSec;
                                        Vector3 _2465 = this.BarrelSecTF.localEulerAngles;
                                        _2465.y = _2464;
                                        this.BarrelSecTF.localEulerAngles = _2465;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (this.HasMovingBits)
        {
            if (Mathf.Abs(this.xStartTime - Time.time) >= this.gunTimer)
            {
                if (this.MovingBit1.localPosition.y < 0)
                {

                    {
                        float _2466 = this.MovingBit1.localPosition.y + this.MB1Speed;
                        Vector3 _2467 = this.MovingBit1.localPosition;
                        _2467.y = _2466;
                        this.MovingBit1.localPosition = _2467;
                    }
                }
            }
            else
            {
                if (this.MovingBit1.localPosition.y > -this.MB1EndValue)
                {

                    {
                        float _2468 = this.MovingBit1.localPosition.y - this.MB1Speed;
                        Vector3 _2469 = this.MovingBit1.localPosition;
                        _2469.y = _2468;
                        this.MovingBit1.localPosition = _2469;
                    }
                }
            }
        }
        if (this.UseRecoilCurve)
        {
            if (this.Gun1RecoFire)
            {
                this.G1RN = this.G1RN + 1;
                if (this.G1RN > 40)
                {
                    this.G1RN = 0;
                    this.Gun1RecoFire = false;
                }

                {
                    float _2470 = this.RecoilCurve.Evaluate(this.G1RN);
                    Vector3 _2471 = this.Gun1Model.localPosition;
                    _2471.y = _2470;
                    this.Gun1Model.localPosition = _2471;
                }
            }
            if (this.Gun2RecoFire)
            {
                this.G2RN = this.G2RN + 1;
                if (this.G2RN > 40)
                {
                    this.G2RN = 0;
                    this.Gun2RecoFire = false;
                }

                {
                    float _2472 = this.RecoilCurve.Evaluate(this.G2RN);
                    Vector3 _2473 = this.Gun2Model.localPosition;
                    _2473.y = _2472;
                    this.Gun2Model.localPosition = _2473;
                }
            }
        }
    }

    public virtual IEnumerator ForePause()
    {
        GameObject TheThing0 = UnityEngine.Object.Instantiate(this.ForePauseSound, this.BulletLocation.position, this.BulletLocation.rotation);
        TheThing0.transform.parent = this.BulletLocation;
        yield return new WaitForSeconds(this.ForePauseTime);
        if (this.FireUsingMouse)
        {
            if (Input.GetMouseButton(0))
            {
                if (this.GetComponent<AudioSource>().isPlaying)
                {
                    this.GetComponent<AudioSource>().Stop();
                }
                if (this.AmmoBayScript.PrimaryAmmunition > 0)
                {
                    this.CanFire = true;
                }
            }
        }
        else
        {
            if (Input.GetKey("4"))
            {
                if (this.GetComponent<AudioSource>().isPlaying)
                {
                    this.GetComponent<AudioSource>().Stop();
                }
                if (this.AmmoBayScript.PrimaryAmmunition > 0)
                {
                    this.CanFire = true;
                }
            }
        }
    }

    public virtual IEnumerator ForePauseSec()
    {
        GameObject TheThing01 = UnityEngine.Object.Instantiate(this.ForePauseSoundSec, this.SecondaryBulletLocation.position, this.SecondaryBulletLocation.rotation);
        TheThing01.transform.parent = this.SecondaryBulletLocation;
        yield return new WaitForSeconds(this.ForePauseTimeSec);
        if (Input.GetKey("4"))
        {
            if (this.GetComponent<AudioSource>().isPlaying)
            {
                this.GetComponent<AudioSource>().Stop();
            }
            if (this.AmmoBaySecScript.PrimaryAmmunition > 0)
            {
                this.CanFireSec = true;
            }
        }
    }

    public virtual IEnumerator GunBoolean()
    {
        if (!this.SimpleHinge)
        {
            if (!this.IsAnimating && !this.IsOut)
            {
                this.StartCoroutine(this.Animating());
                this.HatchAniObject.GetComponent<Animation>().Play(this.Opening);
                yield return new WaitForSeconds(0.2f);
                ConfigurableJoint Cjoint = this.NewGunBase.GetComponent<ConfigurableJoint>();
                Cjoint.targetPosition = new Vector3(0, 0, 0);
                yield return new WaitForSeconds(0.6f);
                this.ActivateSound.GetComponent<AudioSource>().Play();

                {
                    int _2474 = 0;
                    JointSpring _2475 = this.hinge.spring;
                    _2475.targetPosition = _2474;
                    this.hinge.spring = _2475;
                }
                yield return new WaitForSeconds(0.6f);
                this.RecoilAnimationObject.GetComponent<Animation>().Play(this.GunForward);

                {
                    int _2476 = 0;
                    JointSpring _2477 = this.hinge.spring;
                    _2477.spring = _2476;
                    this.hinge.spring = _2477;
                }
                this.Aimer.Activated = true;

                {
                    int _2478 = -15;
                    JointLimits _2479 = this.hinge.limits;
                    _2479.max = _2478;
                    this.hinge.limits = _2479;
                }
                yield return new WaitForSeconds(0.05f);

                {
                    int _2480 = -10;
                    JointLimits _2481 = this.hinge.limits;
                    _2481.max = _2480;
                    this.hinge.limits = _2481;
                }
                yield return new WaitForSeconds(0.05f);

                {
                    int _2482 = -5;
                    JointLimits _2483 = this.hinge.limits;
                    _2483.max = _2482;
                    this.hinge.limits = _2483;
                }
                yield return new WaitForSeconds(0.05f);

                {
                    int _2484 = 0;
                    JointLimits _2485 = this.hinge.limits;
                    _2485.max = _2484;
                    this.hinge.limits = _2485;
                }
                yield return new WaitForSeconds(0.05f);
                this.IsOut = true;
                this.CanFire = true;
            }
            if (!this.IsAnimating && this.IsOut)
            {
                this.StartCoroutine(this.Animating());
                this.IsOut = false;
                this.CanFire = false;

                {
                    int _2486 = -90;
                    JointLimits _2487 = this.hinge.limits;
                    _2487.max = _2486;
                    this.hinge.limits = _2487;
                }
                this.Aimer.Activated = false;
                this.RecoilAnimationObject.GetComponent<Animation>().Play(this.GunBack);
                this.DeactivateSound.GetComponent<AudioSource>().Play();
                yield return new WaitForSeconds(0.4f);

                {
                    float _2488 = 0.3f;
                    JointSpring _2489 = this.hinge.spring;
                    _2489.spring = _2488;
                    this.hinge.spring = _2489;
                }

                {
                    int _2490 = -90;
                    JointSpring _2491 = this.hinge.spring;
                    _2491.targetPosition = _2490;
                    this.hinge.spring = _2491;
                }
                yield return new WaitForSeconds(0.8f);
                ConfigurableJoint Cjoint = this.NewGunBase.GetComponent<ConfigurableJoint>();
                Cjoint.targetPosition = new Vector3(0, 0, -3);
                this.HatchAniObject.GetComponent<Animation>().Play(this.Closing);
            }
        }
        else
        {
            if (!this.IsOut)
            {
                this.IsOut = true;

                {
                    int _2492 = -90;
                    JointSpring _2493 = this.hinge.spring;
                    _2493.targetPosition = _2492;
                    this.hinge.spring = _2493;
                }
                if (this.hinge2)
                {

                    {
                        int _2494 = -90;
                        JointSpring _2495 = this.hinge2.spring;
                        _2495.targetPosition = _2494;
                        this.hinge2.spring = _2495;
                    }
                }
                yield return new WaitForSeconds(1);
                this.Aimer.Activated = true;
                if (this.Aimer2)
                {
                    this.Aimer2.Activated = true;
                }
                this.CanFire = true;
            }
            else
            {
                this.IsOut = false;

                {
                    int _2496 = 0;
                    JointSpring _2497 = this.hinge.spring;
                    _2497.targetPosition = _2496;
                    this.hinge.spring = _2497;
                }
                if (this.hinge2)
                {

                    {
                        int _2498 = 0;
                        JointSpring _2499 = this.hinge2.spring;
                        _2499.targetPosition = _2498;
                        this.hinge2.spring = _2499;
                    }
                }
                this.Aimer.Activated = false;
                if (this.Aimer2)
                {
                    this.Aimer2.Activated = false;
                }
                this.CanFire = false;
            }
        }
    }

    public virtual IEnumerator Animating()
    {
        this.IsAnimating = true;
        yield return new WaitForSeconds(3);
        this.IsAnimating = false;
    }

    public virtual IEnumerator Shooting()
    {
        this.IsShooting = true;
        yield return new WaitForSeconds(3);
        this.IsShooting = false;
    }

    public virtual void decrement()
    {
        if (this.BeamAudio.GetComponent<AudioSource>().volume > 0)
        {
            this.BeamAudio.GetComponent<AudioSource>().volume = this.BeamAudio.GetComponent<AudioSource>().volume - this.decrementValue;
        }
        else
        {
            this.BeamAudio.GetComponent<AudioSource>().Stop();
            this.state = "";
        }
    }

    public virtual void increment()
    {
        if (!this.BeamAudio.GetComponent<AudioSource>().isPlaying)
        {
            this.BeamAudio.GetComponent<AudioSource>().Play();
        }
        if (this.BeamAudio.GetComponent<AudioSource>().volume < this.maxVolume)
        {
            this.BeamAudio.GetComponent<AudioSource>().volume = this.BeamAudio.GetComponent<AudioSource>().volume + this.incrementValue;
        }
        else
        {
            this.state = "";
        }
    }

    public virtual void BeamShoot()
    {
        GameObject TheThing = UnityEngine.Object.Instantiate(this.BeamStartEffect, this.BeamAudio.transform.position, this.BeamAudio.transform.rotation);
        TheThing.transform.parent = this.transform;
        if (this.HullShock)
        {
            this.ShockwaveLocation.GetComponent<Rigidbody>().AddForce(this.ShockwaveLocation.transform.up * this.HullShockForce);
        }
        if (this.RecoilAnimationObject != null)
        {
            this.RecoilAnimationObject.GetComponent<Animation>().Play(this.RecoilAnimationName);
        }
    }

    public virtual IEnumerator Shoot()
    {
        RaycastHit hit = default(RaycastHit);
        if ((Mathf.Abs(this.xStartTime - Time.time) >= this.gunTimer) && this.CanFire)
        {
            if (!this.Broken)
            {
                if (this.CanBeObscured && !this.UseAngles)
                {
                    this.Obscured = false;
                    if (Physics.Raycast(this.BulletLocation.position, this.BulletLocation.forward, out hit, Mathf.Infinity, (int) this.targetLayers))
                    {
                        if (hit.collider.name.Contains("DV"))
                        {
                            this.Obscured = true;
                        }
                    }
                }
                //Debug.Log(hit.collider.name);
                if (!this.Obscured)
                {
                    this.StartCoroutine(this.Shooting());
                    this.StartCoroutine(this.gunShot());
                    if (this.useAudioPri)
                    {
                        if (!this.canLoop)
                        {
                            this.gSound.Play();
                        }
                        else
                        {
                            this.gSound.loop = true;
                            if (!this.gSound.isPlaying)
                            {
                                this.gSound.Play();
                            }
                        }
                    }
                }
            }
            this.xStartTime = Time.time;
            this.gunTimer = this.GunCooldown;
            if (this.Volley)
            {
                if (!this.VolleyBroken)
                {
                    this.Obscured = false;
                    if (Physics.Raycast(this.BulletLocationVolley1.position, this.BulletLocationVolley1.forward, out hit, Mathf.Infinity, (int) this.targetLayers))
                    {
                        if (hit.collider.name.Contains("DV"))
                        {
                            this.Obscured = true;
                            yield break;
                        }
                    }
                    yield return new WaitForSeconds(this.VolleyTime);
                    if (this.CanBeObscured && !this.UseAngles)
                    {
                    }
                    if (!this.Obscured)
                    {
                        this.gunShotVolley1();
                    }
                }
            }
        }
        if (!this.CanFire)
        {
            if (this.useAudioPri)
            {
                if (this.canLoop)
                {
                    if (this.gSound.isPlaying)
                    {
                        this.gSound.loop = false;
                    }
                }
            }
        }
    }

    public virtual void ShootG2()
    {
        if (((Mathf.Abs(this.xStartTimeG2 - Time.time) >= this.gunTimerG2) && this.CanFireG2) && !this.Obscured)
        {
            if (!this.Broken)
            {
                this.xStartTimeG2 = Time.time;
                this.StartCoroutine(this.Shooting());
                this.gunTimerG2 = this.GunCooldownG2;
                this.gunShotG2();
                if (this.useAudioPri)
                {
                    if (!this.canLoop)
                    {
                        this.gSound.Play();
                    }
                    else
                    {
                        this.gSound.loop = true;
                        if (!this.gSound.isPlaying)
                        {
                            this.gSound.Play();
                        }
                    }
                }
            }
        }
        if (!this.CanFire)
        {
            if (this.useAudioPri)
            {
                if (this.canLoop)
                {
                    if (this.gSound.isPlaying)
                    {
                        this.gSound.loop = false;
                    }
                }
            }
        }
    }

    public virtual void ShootG3()
    {
        if (((Mathf.Abs(this.xStartTimeG3 - Time.time) >= this.gunTimerG3) && this.CanFireG3) && !this.Obscured)
        {
            if (!this.Broken)
            {
                this.xStartTimeG3 = Time.time;
                this.StartCoroutine(this.Shooting());
                this.gunTimerG3 = this.GunCooldownG3;
                this.gunShotG3();
                if (this.useAudioPri)
                {
                    if (!this.canLoop)
                    {
                        this.gSound.Play();
                    }
                    else
                    {
                        this.gSound.loop = true;
                        if (!this.gSound.isPlaying)
                        {
                            this.gSound.Play();
                        }
                    }
                }
            }
        }
        if (!this.CanFire)
        {
            if (this.useAudioPri)
            {
                if (this.canLoop)
                {
                    if (this.gSound.isPlaying)
                    {
                        this.gSound.loop = false;
                    }
                }
            }
        }
    }

    public virtual void Shoot2()
    {
        if (this.CanFireSec)
        {
            if ((Mathf.Abs(this.xStartTimeSec - Time.time) >= this.gunTimerSec) && !this.Obscured)
            {
                if (!this.SecBroken)
                {
                    this.xStartTimeSec = Time.time;
                    this.gunTimerSec = this.SecondaryGunCooldown;
                    if (this.useAudioSec)
                    {
                        if (!this.canLoopSec)
                        {
                            this.gSoundSec.Play();
                        }
                        else
                        {
                            if (!this.useAudioPrefabs)
                            {
                                this.gSoundSec.loop = true;
                                if (!this.gSoundSec.isPlaying)
                                {
                                    this.gSoundSec.Play();
                                }
                            }
                            else
                            {
                                if (!this.gSoundSecPrefInst)
                                {
                                    this.gSoundSecPrefInst = UnityEngine.Object.Instantiate(this.gSoundSecPref, this.SecondaryLoopSoundLocation.position, this.SecondaryLoopSoundLocation.rotation);
                                    this.gSoundSecPrefInst.transform.parent = this.SecondaryLoopSoundLocation;
                                    this.gSoundSecPrefInst.GetComponent<AudioSource>().loop = true;
                                    if (!this.gSoundSecPrefInst.GetComponent<AudioSource>().isPlaying)
                                    {
                                        this.gSoundSecPrefInst.GetComponent<AudioSource>().Play();
                                    }
                                }
                            }
                        }
                    }
                    this.gunShot2();
                }
            }
        }
        else
        {
            if (this.useAudioSec)
            {
                if (this.canLoopSec)
                {
                    if (!this.useAudioPrefabs)
                    {
                        if (this.gSoundSec.isPlaying)
                        {
                            this.gSoundSec.loop = false;
                        }
                    }
                    else
                    {
                        if (this.gSoundSecPrefInst)
                        {
                            this.gSoundSecPrefInst.GetComponent<AudioSource>().loop = false;
                            this.gSoundSecPrefInst = null;
                        }
                    }
                }
            }
        }
    }

    public virtual IEnumerator gunShot()
    {
        if (this.Spread > 0)
        {
            this.BulletLocation.transform.localRotation = Quaternion.Euler(90, 0, Random.Range(-360, 360));
            this.BulletLocation.transform.Rotate(Vector3.right * Random.Range(0, this.Spread));
            this.BulletLocation.transform.Rotate(Vector3.left * Random.Range(0, this.Spread));
        }
        GameObject TheThang = UnityEngine.Object.Instantiate(this.Ammunition, this.BulletLocation.position, this.BulletLocation.rotation);
        TheThang.transform.parent = this.BulletLocation;
        if (this.FlarePrefab)
        {
            GameObject TheThang2 = UnityEngine.Object.Instantiate(this.FlarePrefab, this.FlareLocation.position, this.FlareLocation.rotation);
            TheThang2.transform.parent = this.BulletLocation;
        }
        if (this.UsingSoundPri)
        {
            this.FlareLocation.gameObject.GetComponent<AudioSource>().PlayOneShot(this.PrimarySound);
        }
        if (this.RecoilAnimationObject != null)
        {
            this.RecoilAnimationObject.GetComponent<Animation>().Stop();
            this.RecoilAnimationObject.GetComponent<Animation>().Play(this.RecoilAnimationName + "");
        }
        if (this.DischargedBit1)
        {
            this.StartCoroutine(this.DischargeBits());
        }
        if (this.AmmoBayScript)
        {
            this.AmmoBayScript.ExpendedRound(this.ShotNum);
        }
        this.Gun1RecoFire = true;
        yield return new WaitForSeconds(this.HullShockForceDelay);
        if (this.HullShock)
        {
            this.ShockwaveLocation.GetComponent<Rigidbody>().AddForce(this.ShockwaveLocation.transform.up * this.HullShockForce);
        }
    }

    public virtual void gunShotG2()
    {
        if (this.Spread > 0)
        {
            this.BulletLocationG2.transform.localRotation = Quaternion.Euler(90, 0, Random.Range(-360, 360));
            this.BulletLocationG2.transform.Rotate(Vector3.right * Random.Range(0, this.Spread));
            this.BulletLocationG2.transform.Rotate(Vector3.left * Random.Range(0, this.Spread));
        }
        if (this.HullShock)
        {
            this.ShockwaveLocationG2.GetComponent<Rigidbody>().AddForce(this.ShockwaveLocationG2.transform.up * this.HullShockForce);
        }
        GameObject TheThangG2 = UnityEngine.Object.Instantiate(this.AmmunitionG2, this.BulletLocationG2.position, this.BulletLocationG2.rotation);
        TheThangG2.transform.parent = this.BulletLocationG2;
        if (this.FlarePrefab)
        {
            GameObject TheThang2G2 = UnityEngine.Object.Instantiate(this.FlarePrefab, this.FlareLocation.position, this.FlareLocation.rotation);
            TheThang2G2.transform.parent = this.BulletLocation;
        }
        if (this.UsingSoundPri)
        {
            this.FlareLocation.gameObject.GetComponent<AudioSource>().PlayOneShot(this.PrimarySound);
        }
        if (this.RecoilAnimationObject != null)
        {
            this.RecoilAnimationObjectG2.GetComponent<Animation>().Stop();
            this.RecoilAnimationObjectG2.GetComponent<Animation>().Play(this.RecoilAnimationNameG2 + "");
        }
        if (this.AmmoBayScript2)
        {
            this.AmmoBayScript2.ExpendedRound(this.ShotNum);
        }
    }

    public virtual void gunShotG3()
    {
        if (this.Spread > 0)
        {
            this.BulletLocationG3.transform.localRotation = Quaternion.Euler(90, 0, Random.Range(-360, 360));
            this.BulletLocationG3.transform.Rotate(Vector3.right * Random.Range(0, this.Spread));
            this.BulletLocationG3.transform.Rotate(Vector3.left * Random.Range(0, this.Spread));
        }
        if (this.HullShock)
        {
            this.ShockwaveLocationG3.GetComponent<Rigidbody>().AddForce(this.ShockwaveLocationG3.transform.up * this.HullShockForce);
        }
        GameObject TheThangG3 = UnityEngine.Object.Instantiate(this.AmmunitionG3, this.BulletLocationG3.position, this.BulletLocationG3.rotation);
        TheThangG3.transform.parent = this.BulletLocationG3;
        if (this.FlarePrefab)
        {
            GameObject TheThang2G2 = UnityEngine.Object.Instantiate(this.FlarePrefab, this.FlareLocation.position, this.FlareLocation.rotation);
            TheThang2G2.transform.parent = this.BulletLocation;
        }
        if (this.UsingSoundPri)
        {
            this.FlareLocation.gameObject.GetComponent<AudioSource>().PlayOneShot(this.PrimarySound);
        }
        if (this.RecoilAnimationObject != null)
        {
            this.RecoilAnimationObjectG3.GetComponent<Animation>().Stop();
            this.RecoilAnimationObjectG3.GetComponent<Animation>().Play(this.RecoilAnimationNameG3 + "");
        }
        if (this.AmmoBayScript2)
        {
            this.AmmoBayScript2.ExpendedRound(this.ShotNum);
        }
    }

    public virtual void gunShotVolley1()
    {
        if (this.Spread > 0)
        {
            this.BulletLocationVolley1.transform.localRotation = Quaternion.Euler(90, 0, Random.Range(-360, 360));
            this.BulletLocationVolley1.transform.Rotate(Vector3.right * Random.Range(0, this.Spread));
            this.BulletLocationVolley1.transform.Rotate(Vector3.left * Random.Range(0, this.Spread));
        }
        if (this.HullShock)
        {
            this.ShockwaveLocationVolley1.GetComponent<Rigidbody>().AddForce(this.ShockwaveLocationVolley1.transform.up * this.HullShockForce);
        }
        GameObject TheThangV1 = UnityEngine.Object.Instantiate(this.Ammunition, this.BulletLocationVolley1.position, this.BulletLocationVolley1.rotation);
        TheThangV1.transform.parent = this.BulletLocationVolley1;
        if (this.FlarePrefab)
        {
        }
        if (this.UsingSoundPri)
        {
            this.BulletLocationVolley1.gameObject.GetComponent<AudioSource>().PlayOneShot(this.PrimarySound);
        }
        if (this.RecoilAnimationObjectVolley1 != null)
        {
            this.RecoilAnimationObjectVolley1.GetComponent<Animation>().Stop();
            this.RecoilAnimationObjectVolley1.GetComponent<Animation>().Play(this.RecoilAnimationNameVolley1 + "");
        }
        if (this.AmmoBayScript)
        {
            this.AmmoBayScript.ExpendedRound(this.ShotNum);
        }
        this.Gun2RecoFire = true;
    }

    public virtual void gunShot2()
    {
        if (!this.SecondaryGunITF)
        {
            if (this.HullShock)
            {
                this.ShockwaveLocation.GetComponent<Rigidbody>().AddForce(this.ShockwaveLocation.transform.up * this.HullShockSecForce);
            }
            GameObject TheThang0 = UnityEngine.Object.Instantiate(this.SecondaryAmmunition, this.SecondaryBulletLocation.position, this.SecondaryBulletLocation.rotation);
            TheThang0.transform.parent = this.SecondaryBulletLocation;
            if (this.SecondaryFlarePrefab)
            {
                GameObject TheThang1 = UnityEngine.Object.Instantiate(this.SecondaryFlarePrefab, this.SecondaryFlareLocation.position, this.SecondaryFlareLocation.rotation);
                TheThang1.transform.parent = this.SecondaryBulletLocation;
            }
            if (this.UsingSoundSec)
            {
                this.SecondaryFlareLocation.gameObject.GetComponent<AudioSource>().PlayOneShot(this.SecondarySound);
            }
            if (this.UsingRecoilSec)
            {
                if (this.RecoilAnimationObject != null)
                {
                    this.RecoilAnimationObject.GetComponent<Animation>().Stop();
                    this.RecoilAnimationObject.GetComponent<Animation>().Play(this.RecoilAnimationName + "");
                }
            }
            this.AmmoBaySecScript.ExpendedRound(this.ShotNum);
        }
        else
        {
            if (this.SecondaryGunTF)
            {
                if (this.SecondaryGunTFActive)
                {
                    if (this.HullShock)
                    {
                        this.ShockwaveLocation.GetComponent<Rigidbody>().AddForce(this.ShockwaveLocation.transform.up * this.HullShockSecForce);
                    }
                    GameObject TheThang2 = UnityEngine.Object.Instantiate(this.SecondaryAmmunition, this.SecondaryBulletLocation.position, this.SecondaryBulletLocation.rotation);
                    TheThang2.transform.parent = this.SecondaryBulletLocation;
                    if (this.SecondaryFlarePrefab)
                    {
                        GameObject TheThang3 = UnityEngine.Object.Instantiate(this.SecondaryFlarePrefab, this.SecondaryFlareLocation.position, this.SecondaryFlareLocation.rotation);
                        TheThang3.transform.parent = this.SecondaryBulletLocation;
                    }
                    if (this.UsingSoundSec)
                    {
                        this.SecondaryFlareLocation.gameObject.GetComponent<AudioSource>().PlayOneShot(this.SecondarySound);
                    }
                    if (this.UsingRecoilSec)
                    {
                        if (this.RecoilAnimationObject != null)
                        {
                            this.RecoilAnimationObject.GetComponent<Animation>().Stop();
                            this.RecoilAnimationObject.GetComponent<Animation>().Play(this.RecoilAnimationName + "");
                        }
                    }
                    this.AmmoBaySecScript.ExpendedRound(this.ShotNum);
                }
            }
            if (this.SecondaryGunTF2)
            {
                if (this.SecondaryGunTF2Active)
                {
                    if (this.HullShock)
                    {
                        this.ShockwaveLocation.GetComponent<Rigidbody>().AddForce(this.ShockwaveLocation.transform.up * this.HullShockSecForce);
                    }
                    GameObject TheThang4 = UnityEngine.Object.Instantiate(this.SecondaryAmmunition, this.SecondaryBulletLocation2.position, this.SecondaryBulletLocation2.rotation);
                    TheThang4.transform.parent = this.SecondaryBulletLocation2;
                    if (this.SecondaryFlarePrefab)
                    {
                        GameObject TheThang5 = UnityEngine.Object.Instantiate(this.SecondaryFlarePrefab, this.SecondaryFlareLocation.position, this.SecondaryFlareLocation.rotation);
                        TheThang5.transform.parent = this.SecondaryBulletLocation2;
                    }
                    if (this.UsingSoundSec)
                    {
                        this.SecondaryFlareLocation.gameObject.GetComponent<AudioSource>().PlayOneShot(this.SecondarySound);
                    }
                    if (this.UsingRecoilSec)
                    {
                        if (this.RecoilAnimationObject != null)
                        {
                            this.RecoilAnimationObject.GetComponent<Animation>().Stop();
                            this.RecoilAnimationObject.GetComponent<Animation>().Play(this.RecoilAnimationName + "");
                        }
                    }
                    this.AmmoBaySecScript.ExpendedRound(this.ShotNum);
                }
            }
            if (this.SecondaryGunTF3)
            {
                if (this.SecondaryGunTF3Active)
                {
                    if (this.HullShock)
                    {
                        this.ShockwaveLocation.GetComponent<Rigidbody>().AddForce(this.ShockwaveLocation.transform.up * this.HullShockSecForce);
                    }
                    GameObject TheThang6 = UnityEngine.Object.Instantiate(this.SecondaryAmmunition, this.SecondaryBulletLocation3.position, this.SecondaryBulletLocation3.rotation);
                    TheThang6.transform.parent = this.SecondaryBulletLocation3;
                    if (this.SecondaryFlarePrefab)
                    {
                        GameObject TheThang7 = UnityEngine.Object.Instantiate(this.SecondaryFlarePrefab, this.SecondaryFlareLocation.position, this.SecondaryFlareLocation.rotation);
                        TheThang7.transform.parent = this.SecondaryBulletLocation3;
                    }
                    if (this.UsingSoundSec)
                    {
                        this.SecondaryFlareLocation.gameObject.GetComponent<AudioSource>().PlayOneShot(this.SecondarySound);
                    }
                    if (this.UsingRecoilSec)
                    {
                        if (this.RecoilAnimationObject != null)
                        {
                            this.RecoilAnimationObject.GetComponent<Animation>().Stop();
                            this.RecoilAnimationObject.GetComponent<Animation>().Play(this.RecoilAnimationName + "");
                        }
                    }
                    this.AmmoBaySecScript.ExpendedRound(this.ShotNum);
                }
            }
            if (this.SecondaryGunTF4)
            {
                if (this.SecondaryGunTF4Active)
                {
                    if (this.HullShock)
                    {
                        this.ShockwaveLocation.GetComponent<Rigidbody>().AddForce(this.ShockwaveLocation.transform.up * this.HullShockSecForce);
                    }
                    GameObject TheThang8 = UnityEngine.Object.Instantiate(this.SecondaryAmmunition, this.SecondaryBulletLocation4.position, this.SecondaryBulletLocation4.rotation);
                    TheThang8.transform.parent = this.SecondaryBulletLocation4;
                    if (this.SecondaryFlarePrefab)
                    {
                        GameObject TheThang9 = UnityEngine.Object.Instantiate(this.SecondaryFlarePrefab, this.SecondaryFlareLocation.position, this.SecondaryFlareLocation.rotation);
                        TheThang9.transform.parent = this.SecondaryBulletLocation;
                    }
                    if (this.UsingSoundSec)
                    {
                        this.SecondaryFlareLocation.gameObject.GetComponent<AudioSource>().PlayOneShot(this.SecondarySound);
                    }
                    if (this.UsingRecoilSec)
                    {
                        if (this.RecoilAnimationObject != null)
                        {
                            this.RecoilAnimationObject.GetComponent<Animation>().Stop();
                            this.RecoilAnimationObject.GetComponent<Animation>().Play(this.RecoilAnimationName + "");
                        }
                    }
                    this.AmmoBaySecScript.ExpendedRound(this.ShotNum);
                }
            }
        }
    }

    public virtual void SectionShot()
    {
        if (this.Broken)
        {
            return;
        }
        if (this.Beaming && !this.CanFire)
        {
            this.BeamEffect.SetActive(false);
            this.BeamLongEffect.GetComponent<ParticleSystem>().enableEmission = false;
            this.BeamLongEffect2.GetComponent<ParticleSystem>().enableEmission = false;
            this.Beaming = false;
            GameObject TheThingie = UnityEngine.Object.Instantiate(this.BeamOffEffect, this.BeamAudio.transform.position, this.BeamAudio.transform.rotation);
            TheThingie.transform.parent = this.transform;
        }
        if (this.Beaming && this.CanFire)
        {
            GameObject Bullet = UnityEngine.Object.Instantiate(this.BeamSection, this.BulletLocation.position, this.BulletLocation.rotation);
            this.AmmoBayScript.ExpendedRound(1);
        }
    }

    public virtual IEnumerator DischargeBits()
    {
        this.DischargedBit1Model.SetActive(true);
        yield return new WaitForSeconds(this.DischargedBitDelay);
        this.DischargedBit1Model.SetActive(false);
        GameObject _SpawnedObject0 = UnityEngine.Object.Instantiate(this.DischargedBit1P, this.DischargedBit1.position, this.DischargedBit1.rotation);
        _SpawnedObject0.GetComponent<Rigidbody>().velocity = ((this.DischargedBit1.forward * this.DischargedBitVelocity) * 0.45f) + (this.thisRB.velocity * 1);
        _SpawnedObject0.GetComponent<Rigidbody>().AddTorque(this.DischargedBit1.right * this.DischargedBitTorque);
    }

    public virtual void Regenerator()
    {
        if (WorldInformation.playerCar == this.gameObject.name)
        {
            this.BulletLocationCol.enabled = true;
            if (this.BulletLocationColG2)
            {
                this.BulletLocationColG2.enabled = true;
            }
            if (this.BulletLocationColG3)
            {
                this.BulletLocationColG3.enabled = true;
            }
        }
        else
        {
            this.BulletLocationCol.enabled = false;
            if (this.BulletLocationColG2)
            {
                this.BulletLocationColG2.enabled = false;
            }
            if (this.BulletLocationColG3)
            {
                this.BulletLocationColG3.enabled = false;
            }
        }
    }

    public NewgunController()
    {
        this.PivMax = 40;
        this.PivMin = 320;
        this.SpinAcceleration = 0.2f;
        this.SpinAccelerationSec = 0.2f;
        this.DischargedBitDelay = 0.3f;
        this.DischargedBitVelocity = 70;
        this.DischargedBitTorque = 3;
        this.MB1Speed = 0.01f;
        this.MB1EndValue = 0.5f;
        this.RecoilAnimationName = "Name";
        this.RecoilAnimationNameG2 = "Name";
        this.RecoilAnimationNameG3 = "Name";
        this.RecoilAnimationNameVolley1 = "Name";
        this.RecoilCurve = new AnimationCurve();
        this.HullShockForce = 1;
        this.HullShockForceDelay = 0.05f;
        this.HullShockSecForce = 1;
        this.ShotNum = 1;
        this.VolleyTime = 0.2f;
        this.CanFire = true;
        this.CanFireSec = true;
        this.CanFireG2 = true;
        this.CanFireG3 = true;
        this.GunCooldown = 3;
        this.GunCooldownG2 = 3;
        this.GunCooldownG3 = 3;
        this.SecondaryGunCooldown = 3;
        this.maxVolume = 0.5f;
        this.incrementValue = 0.05f;
        this.decrementValue = 0.1f;
    }

}