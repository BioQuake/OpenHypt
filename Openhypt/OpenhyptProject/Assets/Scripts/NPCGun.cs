using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class NPCGun : MonoBehaviour
{
    public GameObject turretGO;
    public Rigidbody turretRB;
    public TurretAI turretAI;
    public Transform gunTarget;
    public GameObject Fire1;
    public GameObject stageFire;
    public Transform Muzzle;
    public Transform Muzzle1;
    public Transform Muzzle2;
    public Transform Muzzle3;
    public Transform Muzzle4;
    public bool isLauncher;
    public bool launchesSeeking;
    public bool use2StageFiring;
    public float stageInterval;
    public bool pauseGiveAI;
    public MevNavWarCruiserAI pGAIC7;
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
    public bool ThisTurretDebug;
    public bool ParentTheShot;
    public AudioSource gunFireSound;
    public bool fireSound;
    public int GFSN;
    public Animation RecoilAni;
    public bool LineOfFire;
    public bool SkipLOF;
    public bool UseLOFNum;
    public int LOFNum;
    public bool SkipTLOF;
    public bool reAssess;
    public Transform MuzzleP;
    public string ConfirmedName;
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    public float RayStart;
    public int TargetRange;
    public float TargetMinRange;
    public int TargetCode;
    public bool UseShotRegenSpeed;
    public bool UseSequence;
    public float SequenceDelay;
    public int PauseTime;
    public int StatPauseTime;
    public int RegenTimer;
    public int StatRegenTimer;
    public int Shots;
    public int MaxShots;
    public float Spread;
    public bool DegAlt;
    public virtual void Start()
    {
        this.targetLayers = WorldInformation.instance.NPCGunTL;
        this.StatRegenTimer = this.RegenTimer;
        this.StatPauseTime = this.PauseTime;
        if (this.UseLOFNum)
        {
            GameObject gO1 = new GameObject("MuzzlePoint");
            this.MuzzleP = gO1.transform;
            this.MuzzleP.position = this.Muzzle.position;
            this.MuzzleP.rotation = this.Muzzle.rotation;
            this.MuzzleP.parent = this.Muzzle;
        }
    }

    public virtual void OnJointBreak(float breakForce)
    {
        this.transform.parent = null;
        this.StopAllCoroutines();
        if (this.turretGO)
        {
            UnityEngine.Object.Destroy(this.turretGO);
        }
        UnityEngine.Object.Destroy(this);
    }

    public virtual void Fire()
    {
        RaycastHit hit1 = default(RaycastHit);
        if (!this.Muzzle)
        {
            return;
        }
        if (this.UseLOFNum)
        {
            if (this.gunTarget)
            {
                this.MuzzleP.LookAt(this.gunTarget);
            }
        }
        if (this.Spread > 0)
        {
            if (!this.DegAlt)
            {
                this.Muzzle.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                this.Muzzle.transform.localRotation = Quaternion.Euler(90, 0, 0);
            }
            this.Muzzle.transform.Rotate(Vector3.right * Random.Range(0, this.Spread));
            this.Muzzle.transform.Rotate(Vector3.left * Random.Range(0, this.Spread));
            this.Muzzle.transform.Rotate(Vector3.up * Random.Range(0, this.Spread));
            this.Muzzle.transform.Rotate(Vector3.down * Random.Range(0, this.Spread));
        }
        if (this.SkipTLOF)
        {
            this.LineOfFire = true;
        }
        else
        {
            this.LineOfFire = false;
        }
        if (this.SkipLOF)
        {
            if (!this.use2StageFiring)
            {
                this.StartCoroutine(this.Firing1());
            }
            else
            {
                this.StartCoroutine(this.Firing2());
            }
        }
        else
        {
            if (Physics.Raycast((this.Muzzle.position + (this.Muzzle.forward * this.RayStart)) + (this.Muzzle.up * 0.25f), this.Muzzle.forward, out hit1, this.TargetRange, (int) this.targetLayers))
            {
                if (!this.SkipTLOF)
                {
                    if (!hit1.collider.name.Contains("TC" + this.TargetCode))
                    {
                        if (hit1.collider.name.Contains(this.ConfirmedName) || hit1.collider.name.Contains("TL" + this.TargetCode))
                        {
                            this.LineOfFire = true;
                        }
                        else
                        {
                            if (hit1.collider.name.Contains("TL"))
                            {
                                if (!hit1.collider.name.Contains("TL" + this.TargetCode))
                                {
                                    if ((SphereCollider) hit1.collider.gameObject.GetComponent(typeof(SphereCollider)))
                                    {
                                        ((SphereCollider) hit1.collider.gameObject.GetComponent(typeof(SphereCollider))).radius = 0.1f;
                                    }
                                    this.reAssess = true;
                                }
                            }
                            else
                            {
                                if (hit1.collider.name.Contains(this.ConfirmedName))
                                {
                                    this.LineOfFire = true;
                                }
                            }
                            if (this.gunTarget)
                            {
                                if (Physics.Raycast((this.MuzzleP.position + (this.MuzzleP.forward * this.RayStart)) + (this.Muzzle.up * 0.25f), this.MuzzleP.forward, out hit1, this.TargetRange, (int) this.targetLayers))
                                {
                                    if (!hit1.collider.name.Contains("DV"))
                                    {
                                        this.LineOfFire = false;
                                    }
                                }
                            }
                        }
                    }
                    //Debug.Log(hit1.collider.name);
                    if (hit1.distance < this.TargetMinRange)
                    {
                        this.LineOfFire = false;
                    }
                }
                else
                {
                    if (Physics.Raycast((this.Muzzle.position + (this.Muzzle.forward * this.RayStart)) + (this.Muzzle.up * 0.25f), this.Muzzle.forward, out hit1, this.TargetRange, (int) this.targetLayers))
                    {
                        if (hit1.collider.name.Contains("TC" + this.TargetCode))
                        {
                            this.LineOfFire = false;
                        }
                        else
                        {
                            if (hit1.collider.name.Contains("rok"))
                            {
                                this.LineOfFire = false;
                            }
                            else
                            {
                                this.LineOfFire = true;
                            }
                            if (this.ThisTurretDebug)
                            {
                                Debug.Log("IsLOF " + hit1.collider.name);
                            }
                        }
                    }
                }
            }
        }
        //[TryAgain]=============================================================================================================================
        if (this.reAssess)
        {
            if (Physics.Raycast((this.Muzzle.position + (this.Muzzle.forward * this.RayStart)) + (this.Muzzle.up * 0.25f), this.Muzzle.forward, out hit1, this.TargetRange, (int) this.targetLayers))
            {
                if (!hit1.collider.name.Contains("TC" + this.TargetCode))
                {
                    if (hit1.collider.name.Contains(this.ConfirmedName) || hit1.collider.name.Contains("TL" + this.TargetCode))
                    {
                        this.LineOfFire = true;
                    }
                    else
                    {
                        if (hit1.collider.name.Contains("TL"))
                        {
                            if (!hit1.collider.name.Contains("TL" + this.TargetCode))
                            {
                                if ((SphereCollider) hit1.collider.gameObject.GetComponent(typeof(SphereCollider)))
                                {
                                    ((SphereCollider) hit1.collider.gameObject.GetComponent(typeof(SphereCollider))).radius = 0.1f;
                                }
                                this.reAssess = true;
                            }
                        }
                        else
                        {
                            if (hit1.collider.name.Contains(this.ConfirmedName))
                            {
                                this.LineOfFire = true;
                            }
                        }
                        if (this.gunTarget)
                        {
                            if (Physics.Raycast((this.MuzzleP.position + (this.MuzzleP.forward * this.RayStart)) + (this.Muzzle.up * 0.25f), this.MuzzleP.forward, out hit1, this.TargetRange, (int) this.targetLayers))
                            {
                                if (!hit1.collider.name.Contains("DV"))
                                {
                                    this.LineOfFire = false;
                                }
                            }
                        }
                    }
                }
                //Debug.Log(hit1.collider.name);
                if (hit1.distance < this.TargetMinRange)
                {
                    this.LineOfFire = false;
                }
            }
        }
        if (this.LineOfFire)
        {
            this.reAssess = false;
        }
        if (this.UseLOFNum)
        {
            if (this.LineOfFire)
            {
                if (this.LOFNum < 10)
                {
                    this.LOFNum = this.LOFNum + 1;
                }
            }
            else
            {
                if (this.LOFNum > 0)
                {
                    this.LOFNum = this.LOFNum - 1;
                }
            }
            if (this.LOFNum > 9)
            {
                this.LineOfFire = true;
            }
            else
            {
                this.LineOfFire = false;
            }
        }
        if (this.LineOfFire && (this.Shots > 0))
        {
            if (this.pauseGiveAI)
            {
                this.pGAIC7.MainGunsCooldown = 10;
                this.pGAIC7.FiringMainGuns = true;
            }
            if (!this.use2StageFiring)
            {
                this.StartCoroutine(this.Firing1());
            }
            else
            {
                this.StartCoroutine(this.Firing2());
            }
        }
        if (!this.UseShotRegenSpeed)
        {
            if (this.Shots == 0)
            {
                this.Shots = -1;
                this.PauseTime = 0;
            }
        }
    }

    public virtual IEnumerator Firing1()
    {
        if (this.gunFireSound)
        {
            if (this.GFSN < 1)
            {
                this.GFSN = 12;
                this.gunFireSound.Play();
                this.gunFireSound.loop = true;
            }
        }
        this.Shots = this.Shots - 1;
        if (this.UseShotRegenSpeed)
        {
            if (this.Shots == 0)
            {
                this.RegenTimer = this.StatRegenTimer;
            }
        }
        if (!this.isLauncher)
        {
            if (!this.ParentTheShot)
            {
                UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle.position, this.Muzzle.rotation);
            }
            else
            {
                GameObject TheThing = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle.position, this.Muzzle.rotation);
                TheThing.transform.parent = this.Muzzle.transform;
            }
        }
        else
        {
            if (!this.launchesSeeking)
            {
                UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle1.position, this.Muzzle1.rotation);
                if (this.UseSequence)
                {
                    yield return new WaitForSeconds(this.SequenceDelay);
                    UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle2.position, this.Muzzle2.rotation);
                    yield return new WaitForSeconds(this.SequenceDelay);
                    UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle3.position, this.Muzzle3.rotation);
                    yield return new WaitForSeconds(this.SequenceDelay);
                    UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle4.position, this.Muzzle4.rotation);
                }
            }
            else
            {
                GameObject _theProjectile1 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle1.position, this.Muzzle1.rotation);
                ((MissileScript) _theProjectile1.transform.GetComponent(typeof(MissileScript))).target = this.turretAI.target;
                if (this.UseSequence)
                {
                    yield return new WaitForSeconds(this.SequenceDelay);
                    GameObject _theProjectile2 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle2.position, this.Muzzle2.rotation);
                    ((MissileScript) _theProjectile2.transform.GetComponent(typeof(MissileScript))).target = this.turretAI.target;
                    yield return new WaitForSeconds(this.SequenceDelay);
                    GameObject _theProjectile3 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle3.position, this.Muzzle3.rotation);
                    ((MissileScript) _theProjectile3.transform.GetComponent(typeof(MissileScript))).target = this.turretAI.target;
                    yield return new WaitForSeconds(this.SequenceDelay);
                    GameObject _theProjectile4 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle4.position, this.Muzzle4.rotation);
                    ((MissileScript) _theProjectile4.transform.GetComponent(typeof(MissileScript))).target = this.turretAI.target;
                }
            }
        }
        if (this.DischargedBit1)
        {
            this.StartCoroutine(this.DischargeBits());
        }
        if (this.RecoilAni != null)
        {
            this.RecoilAni.Stop();
            this.RecoilAni.Play();
        }
    }

    public virtual IEnumerator Firing2()
    {
        GameObject TheThing2 = UnityEngine.Object.Instantiate(this.stageFire, this.Muzzle.position, this.Muzzle.rotation);
        TheThing2.transform.parent = this.Muzzle.transform;
        this.Shots = this.Shots - 1;
        if (this.UseShotRegenSpeed)
        {
            if (this.Shots == 0)
            {
                this.RegenTimer = this.StatRegenTimer;
            }
        }
        yield return new WaitForSeconds(this.stageInterval);
        if (this.gunFireSound)
        {
            if (this.GFSN < 1)
            {
                this.GFSN = 12;
                this.gunFireSound.Play();
                this.gunFireSound.loop = true;
            }
        }
        if (!this.isLauncher)
        {
            if (!this.ParentTheShot)
            {
                UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle.position, this.Muzzle.rotation);
            }
            else
            {
                GameObject TheThing = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle.position, this.Muzzle.rotation);
                TheThing.transform.parent = this.Muzzle.transform;
            }
        }
        else
        {
            if (!this.launchesSeeking)
            {
                UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle1.position, this.Muzzle1.rotation);
                if (this.UseSequence)
                {
                    yield return new WaitForSeconds(this.SequenceDelay);
                    UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle2.position, this.Muzzle2.rotation);
                    yield return new WaitForSeconds(this.SequenceDelay);
                    UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle3.position, this.Muzzle3.rotation);
                    yield return new WaitForSeconds(this.SequenceDelay);
                    UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle4.position, this.Muzzle4.rotation);
                }
            }
            else
            {
                GameObject _theProjectile1 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle1.position, this.Muzzle1.rotation);
                ((MissileScript) _theProjectile1.transform.GetComponent(typeof(MissileScript))).target = this.turretAI.target;
                if (this.UseSequence)
                {
                    yield return new WaitForSeconds(this.SequenceDelay);
                    GameObject _theProjectile2 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle2.position, this.Muzzle2.rotation);
                    ((MissileScript) _theProjectile2.transform.GetComponent(typeof(MissileScript))).target = this.turretAI.target;
                    yield return new WaitForSeconds(this.SequenceDelay);
                    GameObject _theProjectile3 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle3.position, this.Muzzle3.rotation);
                    ((MissileScript) _theProjectile3.transform.GetComponent(typeof(MissileScript))).target = this.turretAI.target;
                    yield return new WaitForSeconds(this.SequenceDelay);
                    GameObject _theProjectile4 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle4.position, this.Muzzle4.rotation);
                    ((MissileScript) _theProjectile4.transform.GetComponent(typeof(MissileScript))).target = this.turretAI.target;
                }
            }
        }
        if (this.DischargedBit1)
        {
            this.StartCoroutine(this.DischargeBits());
        }
        if (this.RecoilAni != null)
        {
            this.RecoilAni.Stop();
            this.RecoilAni.Play();
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.gunFireSound)
        {
            if (this.GFSN > 0)
            {
                this.GFSN = this.GFSN - 1;
            }
            else
            {
                this.gunFireSound.loop = false;
            }
        }
        if (!this.UseShotRegenSpeed)
        {
            if (this.Shots == -1)
            {
                if (this.PauseTime < this.StatPauseTime)
                {
                    this.PauseTime = this.PauseTime + 1;
                }
                if (this.PauseTime == this.StatPauseTime)
                {
                    this.Shots = this.MaxShots;
                }
            }
        }
        else
        {
            if (this.Shots < this.MaxShots)
            {
                if (this.RegenTimer > 0)
                {
                    this.RegenTimer = this.RegenTimer - 1;
                }
                if (this.RegenTimer == 0)
                {
                    this.RegenTimer = this.StatRegenTimer;
                    this.Shots = this.Shots + 1;
                }
            }
        }
        if (this.HasMovingBits)
        {
            if (this.Shots > 0)
            {
                if (this.MovingBit1.localPosition.y < 0)
                {

                    {
                        float _2500 = this.MovingBit1.localPosition.y + this.MB1Speed;
                        Vector3 _2501 = this.MovingBit1.localPosition;
                        _2501.y = _2500;
                        this.MovingBit1.localPosition = _2501;
                    }
                }
            }
            else
            {
                if (this.MovingBit1.localPosition.y > -this.MB1EndValue)
                {

                    {
                        float _2502 = this.MovingBit1.localPosition.y - this.MB1Speed;
                        Vector3 _2503 = this.MovingBit1.localPosition;
                        _2503.y = _2502;
                        this.MovingBit1.localPosition = _2503;
                    }
                }
            }
        }
    }

    public virtual IEnumerator DischargeBits()
    {
        this.DischargedBit1Model.SetActive(true);
        yield return new WaitForSeconds(this.DischargedBitDelay);
        this.DischargedBit1Model.SetActive(false);
        GameObject _SpawnedObject0 = UnityEngine.Object.Instantiate(this.DischargedBit1P, this.DischargedBit1.position, this.DischargedBit1.rotation);
        _SpawnedObject0.GetComponent<Rigidbody>().velocity = ((this.DischargedBit1.forward * this.DischargedBitVelocity) * 0.45f) + (this.turretRB.velocity * 1);
        _SpawnedObject0.GetComponent<Rigidbody>().AddTorque(this.DischargedBit1.right * this.DischargedBitTorque);
    }

    public NPCGun()
    {
        this.stageInterval = 0.6f;
        this.DischargedBitDelay = 0.3f;
        this.DischargedBitVelocity = 70;
        this.DischargedBitTorque = 3;
        this.MB1Speed = 0.01f;
        this.MB1EndValue = 0.5f;
        this.ConfirmedName = "TC";
        this.RayStart = 0.5f;
        this.TargetRange = 400;
        this.TargetMinRange = 0.5f;
        this.SequenceDelay = 0.5f;
        this.PauseTime = 2;
        this.RegenTimer = 60;
        this.StatRegenTimer = 60;
        this.MaxShots = 3;
    }

}