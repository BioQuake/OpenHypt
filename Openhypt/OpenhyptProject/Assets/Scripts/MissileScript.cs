using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MissileScript : MonoBehaviour
{
    public float StartVelocity;
    public int EngageVelocity;
    public float Force;
    public bool DirY;
    public Transform target;
    public int TargetCode;
    public Transform TargetTrace;
    public Transform TargetLead;
    public float LeadAmount;
    public bool LeadSpread;
    public float LeadSpreadU;
    public float LeadSpreadL;
    public int Lead1Time;
    public int Lead2Time;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public bool C;
    public bool E;
    public bool Away;
    public bool Armed;
    public bool Aiming;
    public bool Avoiding;
    public bool LPEnabled;
    public bool ThrusterOn;
    public bool IsAttached;
    public ConfigurableJoint CJ;
    public float ColEnableTime;
    public float LPEnableTime;
    public float EngageDelay;
    public float ArmDelay;
    public float ThrusterDelay;
    public float ThrusterTime;
    public float Timer;
    public float EngageDrag;
    public float AimForce;
    public float SpreadAmount;
    public bool SkipLookRot;
    public bool keepAudio;
    public bool TypeMine;
    public bool TypeBomb;
    public bool TypeBallistic;
    public bool TypeBallisticSeeking;
    public bool TypeDirectShot;
    public bool TypeDirectShotSeeking;
    public bool TypeSeeking;
    public bool CanLead;
    public bool useSpleadCurve;
    public AnimationCurve SpleadCurve;
    public bool Sticky;
    public bool ArmLimiter;
    public bool AvoidGround;
    public bool JammingResistant;
    public bool CollisionResistant;
    public bool DirectedExplosion;
    public bool Proximity;
    public bool linProx;
    public int ProximityRange;
    public Transform ProxTrig;
    public bool KillOnDrift;
    public float KOTDist;
    public bool useMevNavNetwork;
    public float HoverForce;
    public float HovDist;
    public LayerMask targetLayers;
    public int ThrusterEffect1Rate;
    public int ThrusterEffect2Rate;
    public int ThrusterEffect3Rate;
    public Transform SmokeEffect1;
    public Transform SmokeEffect2;
    public GameObject ThrusterEffect1;
    public GameObject ThrusterEffect2;
    public GameObject ThrusterEffect3;
    public AudioSource EngageSound;
    public GameObject MeshEffects;
    public GameObject explosion;
    public GameObject dud;
    public KillOverTime Remover;
    public string WeaponOf;
    public float Dist0;
    public float Dist1;
    public float Dist2;
    public float Dist3;
    public float Dist4;
    private Transform LastPoint;
    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 1, 0.93f);
        if (this.vRigidbody.mass > 0.1f)
        {
            if (!WorldInformation.bigMissile1)
            {
                WorldInformation.bigMissile1 = this.thisVTransform;
            }
            else
            {
                WorldInformation.bigMissile2 = this.thisVTransform;
            }
        }
        this.KOTDist = 20000;
        if (this.LeadSpread)
        {
            this.LeadAmount = Random.Range(this.LeadSpreadL, this.LeadSpreadU);
        }
        GameObject gO = new GameObject("LPoint");
        if (this.CanLead)
        {
            GameObject gO1 = new GameObject("TT");
            GameObject gO2 = new GameObject("TL");
            this.TargetTrace = gO1.transform;
            this.TargetLead = gO2.transform;
            this.TargetTrace.position = this.transform.position;
            this.TargetTrace.rotation = this.transform.rotation;
            this.TargetLead.position = this.transform.position;
            this.TargetLead.rotation = this.transform.rotation;
        }
        this.LastPoint = gO.transform;
        this.LastPoint.transform.position = this.transform.position;
        this.LastPoint.transform.rotation = this.transform.rotation;
        this.transform.parent = null;
        if (this.LastPoint)
        {
            this.LastPoint.parent = null;
        }
        this.GetComponent<Rigidbody>().useGravity = false;
        if (!this.DirY)
        {
            this.GetComponent<Rigidbody>().AddForce(this.transform.forward * this.StartVelocity);
        }
        else
        {
            this.GetComponent<Rigidbody>().AddForce(this.transform.up * this.StartVelocity);
        }
        this.GetComponent<Rigidbody>().centerOfMass = new Vector3(0, 0, 0);
        this.StartCoroutine(this.ColEnable());
        this.StartCoroutine(this.LPEnable());
        //[Types]=================================================================================================
        if (this.TypeMine)
        {
            this.StartCoroutine(this.Arm());
            this.StartCoroutine(this.Countdown());
        }
        if (this.TypeBomb)
        {
            this.StartCoroutine(this.Arm());
            this.StartCoroutine(this.Countdown());
        }
        if (this.TypeBallistic)
        {
            this.StartCoroutine(this.Arm2());
            this.StartCoroutine(this.EngageThruster());
            this.StartCoroutine(this.Engage());
            this.StartCoroutine(this.Countdown());
        }
        if (this.TypeBallisticSeeking)
        {
            this.StartCoroutine(this.Arm2());
            this.StartCoroutine(this.EngageThruster());
            this.StartCoroutine(this.Engage());
            this.StartCoroutine(this.Countdown());
        }
        if (this.TypeDirectShot)
        {
            this.StartCoroutine(this.Arm2());
            this.StartCoroutine(this.EngageThruster());
            this.StartCoroutine(this.Engage());
            this.StartCoroutine(this.Countdown());
        }
        if (this.TypeDirectShotSeeking)
        {
            this.StartCoroutine(this.Arm2());
            this.StartCoroutine(this.EngageThruster());
            this.StartCoroutine(this.Engage());
            this.StartCoroutine(this.Countdown());
        }
        if (this.TypeSeeking)
        {
            this.StartCoroutine(this.Arm2());
            this.StartCoroutine(this.EngageThruster());
            this.StartCoroutine(this.Engage());
            this.StartCoroutine(this.Countdown());
        }
    }

    public virtual IEnumerator ColEnable()
    {
        yield return new WaitForSeconds(this.ColEnableTime);
        if (((this.TypeBallistic || this.TypeBallisticSeeking) || this.TypeMine) || this.TypeBomb)
        {
            this.GetComponent<Rigidbody>().useGravity = true;
        }
        this.LastPoint.transform.position = this.transform.position;
        this.LastPoint.transform.rotation = this.transform.rotation;
        if (!this.gameObject.GetComponent<Collider>())
        {
            SphereCollider sc = null;
            sc = this.gameObject.AddComponent<SphereCollider>();
            ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 0.5f;
        }
        this.gameObject.layer = 14;
        this.Away = true;
        this.C = false;
    }

    public virtual IEnumerator LPEnable()
    {
        yield return new WaitForSeconds(this.LPEnableTime);
        this.LPEnabled = true;
    }

    public virtual IEnumerator EngageThruster()
    {
        yield return new WaitForSeconds(this.ThrusterDelay);
        this.ThrusterOn = true;
        this.GetComponent<Rigidbody>().AddForce(this.transform.forward * this.EngageVelocity);
        if (this.SpreadAmount > 0)
        {
            this.GetComponent<Rigidbody>().AddTorque(this.transform.up * Random.Range(-this.SpreadAmount, this.SpreadAmount));
            this.GetComponent<Rigidbody>().AddTorque(this.transform.right * Random.Range(-this.SpreadAmount, this.SpreadAmount));
            this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * Random.Range(-this.SpreadAmount, this.SpreadAmount));
        }
        if (this.GetComponent<AudioSource>() != null)
        {
            this.GetComponent<AudioSource>().Play();
        }
        if (this.MeshEffects != null)
        {
            this.MeshEffects.gameObject.SetActive(true);
        }
        if (this.ThrusterEffect1 != null)
        {
            ((ParticleSystem) this.ThrusterEffect1.GetComponent(typeof(ParticleSystem))).Play();
            ((ParticleSystem) this.ThrusterEffect1.GetComponent(typeof(ParticleSystem))).emissionRate = this.ThrusterEffect1Rate;
        }
        if (this.ThrusterEffect2 != null)
        {
            ((ParticleSystem) this.ThrusterEffect2.GetComponent(typeof(ParticleSystem))).Play();
            ((ParticleSystem) this.ThrusterEffect2.GetComponent(typeof(ParticleSystem))).emissionRate = this.ThrusterEffect2Rate;
        }
        if (this.ThrusterEffect3 != null)
        {
            ((ParticleSystem) this.ThrusterEffect3.GetComponent(typeof(ParticleSystem))).Play();
            ((ParticleSystem) this.ThrusterEffect3.GetComponent(typeof(ParticleSystem))).emissionRate = this.ThrusterEffect3Rate;
        }
        yield return new WaitForSeconds(this.ThrusterTime);
        this.ThrusterOn = false;
    }

    public virtual IEnumerator Engage()
    {
        yield return new WaitForSeconds(this.EngageDelay);
        if (this.EngageDrag > 0)
        {
            this.GetComponent<Rigidbody>().drag = this.EngageDrag;
        }
        this.Aiming = true;
        if (this.EngageSound)
        {
            this.EngageSound.Play();
        }
    }

    public virtual IEnumerator Arm()
    {
        yield return new WaitForSeconds(this.ArmDelay);
        GameObject gO = new GameObject("Trig");
        gO.transform.parent = this.gameObject.transform;
        gO.transform.position = this.transform.position;
        gO.transform.rotation = this.transform.rotation;
        gO.layer = 22;
        Rigidbody gORB = gO.AddComponent<Rigidbody>();
        gORB.isKinematic = true;
        gORB.useGravity = false;
        SphereCollider sc = gO.AddComponent<SphereCollider>();
        sc.isTrigger = true;
        sc.radius = this.ProximityRange;
        ThreatReader TR = gO.gameObject.AddComponent<ThreatReader>();
        TR.IgnoreThis = this.WeaponOf;
        this.ProxTrig = gO.transform;
        this.Armed = true;
    }

    public virtual IEnumerator Arm2()
    {
        yield return new WaitForSeconds(this.ArmDelay);
        this.Armed = true;
    }

    public virtual IEnumerator Countdown()
    {
        yield return new WaitForSeconds(this.Timer);
        if (!this.ArmLimiter)
        {
            this.Explode();
        }
        else
        {
            this.Disable();
        }
    }

    public virtual void Explode()
    {
        if (this.E)
        {
            return;
        }
        this.E = true;
        this.transform.position = this.LastPoint.position;
        if (!this.DirectedExplosion)
        {
            UnityEngine.Object.Instantiate(this.explosion, this.transform.position, this.explosion.transform.rotation);
        }
        else
        {
            UnityEngine.Object.Instantiate(this.explosion, this.transform.position, this.transform.rotation);
        }
        //var Load = Resources.Load("Prefabs/ThreatCursor", GameObject) as GameObject;
        //var TGO = Instantiate(Load, transform.position, transform.rotation);
        if (this.ThrusterEffect1 != null)
        {
            ((ParticleSystem) this.ThrusterEffect1.GetComponent(typeof(ParticleSystem))).emissionRate = 0;
        }
        if (this.ThrusterEffect2 != null)
        {
            ((ParticleSystem) this.ThrusterEffect2.GetComponent(typeof(ParticleSystem))).emissionRate = 0;
        }
        if (this.ThrusterEffect3 != null)
        {
            ((ParticleSystem) this.ThrusterEffect3.GetComponent(typeof(ParticleSystem))).emissionRate = 0;
        }
        if (this.SmokeEffect1 != null)
        {
            this.SmokeEffect1.parent = null;
        }
        if (this.SmokeEffect2 != null)
        {
            this.SmokeEffect2.parent = null;
        }
        if (this.GetComponent<AudioSource>() != null)
        {
            if (!this.keepAudio)
            {
                this.GetComponent<AudioSource>().Stop();
            }
        }
        this.gameObject.GetComponent<Collider>().enabled = false;
        if (this.GetComponent<Renderer>() != null)
        {
            this.GetComponent<Renderer>().enabled = false;
        }
        if (this.MeshEffects != null)
        {
            this.MeshEffects.gameObject.SetActive(false);
        }
        if (this.Remover != null)
        {
            this.Remover.IsRemoving = true;
        }
        this.name = "Broken";
        if (this.LastPoint)
        {
            UnityEngine.Object.Destroy(this.LastPoint.gameObject);
        }
        if (this.TargetLead)
        {
            UnityEngine.Object.Destroy(this.TargetLead.gameObject);
            UnityEngine.Object.Destroy(this.TargetTrace.gameObject);
        }
        UnityEngine.Object.Destroy(this);
    }

    public virtual void Disable()
    {
        if (this.C)
        {
            return;
        }
        GameObject TheDud = UnityEngine.Object.Instantiate(this.dud, this.transform.position, this.transform.rotation);
        TheDud.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
        TheDud.GetComponent<Rigidbody>().angularVelocity = this.vRigidbody.angularVelocity * 1;
        if (this.ThrusterEffect1 != null)
        {
            ((ParticleSystem) this.ThrusterEffect1.GetComponent(typeof(ParticleSystem))).emissionRate = 0;
        }
        if (this.ThrusterEffect2 != null)
        {
            ((ParticleSystem) this.ThrusterEffect2.GetComponent(typeof(ParticleSystem))).emissionRate = 0;
        }
        if (this.ThrusterEffect3 != null)
        {
            ((ParticleSystem) this.ThrusterEffect3.GetComponent(typeof(ParticleSystem))).emissionRate = 0;
        }
        if (this.SmokeEffect1 != null)
        {
            this.SmokeEffect1.parent = null;
        }
        if (this.SmokeEffect2 != null)
        {
            this.SmokeEffect2.parent = null;
        }
        if (this.GetComponent<AudioSource>() != null)
        {
            if (!this.keepAudio)
            {
                this.GetComponent<AudioSource>().Stop();
            }
        }
        this.gameObject.GetComponent<Collider>().enabled = false;
        if (this.GetComponent<Renderer>() != null)
        {
            this.GetComponent<Renderer>().enabled = false;
        }
        if (this.MeshEffects != null)
        {
            this.MeshEffects.gameObject.SetActive(false);
        }
        if (this.Remover != null)
        {
            this.Remover.IsRemoving = true;
        }
        this.name = "Broken";
        if (this.LastPoint)
        {
            UnityEngine.Object.Destroy(this.LastPoint.gameObject);
        }
        if (this.TargetLead)
        {
            UnityEngine.Object.Destroy(this.TargetLead.gameObject);
            UnityEngine.Object.Destroy(this.TargetTrace.gameObject);
        }
        UnityEngine.Object.Destroy(this);
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit0 = default(RaycastHit);
        RaycastHit hitE = default(RaycastHit);
        RaycastHit hit1 = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        RaycastHit hit3 = default(RaycastHit);
        RaycastHit hit4 = default(RaycastHit);
        if (this.ThrusterOn)
        {
            this.GetComponent<Rigidbody>().AddForce(this.transform.forward * this.Force);
        }
        if (this.TypeBallistic)
        {
            if (this.Away)
            {
                if (!this.SkipLookRot)
                {
                    this.thisVTransform.rotation = Quaternion.LookRotation(this.vRigidbody.velocity);
                }
            }
        }
        if (this.Aiming)
        {
            if (this.target)
            {
                this.Dist0 = Vector3.Distance(this.transform.position, this.target.position);
                if (this.TypeDirectShot)
                {
                    if (this.SpreadAmount > 0)
                    {
                        this.GetComponent<Rigidbody>().AddTorque(this.transform.up * Random.Range(-this.SpreadAmount, this.SpreadAmount));
                        this.GetComponent<Rigidbody>().AddTorque(this.transform.right * Random.Range(-this.SpreadAmount, this.SpreadAmount));
                        this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * Random.Range(-this.SpreadAmount, this.SpreadAmount));
                    }
                }
                if (this.CanLead)
                {
                    this.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.position - this.transform.position).normalized * this.AimForce, this.transform.forward * 1);
                    this.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.position - this.transform.position).normalized * -this.AimForce, -this.transform.forward * 1);
                }
                else
                {
                    this.GetComponent<Rigidbody>().AddForceAtPosition((this.target.position - this.transform.position).normalized * this.AimForce, this.transform.forward * 1);
                    this.GetComponent<Rigidbody>().AddForceAtPosition((this.target.position - this.transform.position).normalized * -this.AimForce, -this.transform.forward * 1);
                }
            }
        }
        if (this.KillOnDrift)
        {
            if (this.Armed)
            {
                if (this.Dist0 < 250)
                {
                    if (this.Dist0 > this.KOTDist)
                    {
                        this.Explode();
                    }
                    this.KOTDist = this.Dist0;
                }
            }
        }
        if (this.CanLead)
        {
            if (this.Lead1Time < 1)
            {
                this.Lead1Time = 8;
                this.Lead2Time = 4;
                this.Lead1();
            }
            else
            {
                this.Lead1Time = this.Lead1Time - 1;
            }
            if (this.Lead2Time < 1)
            {
                this.Lead2Time = 8;
                this.Lead2Time = 4;
                this.Lead2();
            }
            else
            {
                this.Lead2Time = this.Lead2Time - 1;
            }
        }
        if (!this.JammingResistant)
        {
            if (this.AimForce == 0)
            {
                this.GetComponent<Rigidbody>().useGravity = true;
                this.GetComponent<Rigidbody>().AddTorque((this.transform.right * 10) * this.GetComponent<Rigidbody>().mass);
                this.GetComponent<Rigidbody>().AddForce(this.transform.right * this.Force);
                this.name = "Broken";
            }
        }
        if (this.Sticky)
        {
            if (this.Away)
            {
                if (!this.IsAttached)
                {
                    Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
                    float VM = localV.z * 0.02f;
                    float VA = Mathf.Abs(VM);
                    Debug.DrawRay(this.transform.position, this.transform.forward * VA, Color.yellow);
                    if (Physics.Raycast(this.transform.position, this.transform.forward, out hit0, VA, (int) this.targetLayers))
                    {
                        if (hit0.collider.GetComponent<Rigidbody>())
                        {
                            this.CJ = this.gameObject.AddComponent<ConfigurableJoint>();
                            this.CJ.connectedBody = hit0.rigidbody;

                            {
                                JointDriveMode _2340 = JointDriveMode.Position;
                                JointDrive _2341 = this.CJ.xDrive;
                                _2341.mode = _2340;
                                this.CJ.xDrive = _2341;
                            }

                            {
                                JointDriveMode _2342 = JointDriveMode.Position;
                                JointDrive _2343 = this.CJ.yDrive;
                                _2343.mode = _2342;
                                this.CJ.yDrive = _2343;
                            }

                            {
                                JointDriveMode _2344 = JointDriveMode.Position;
                                JointDrive _2345 = this.CJ.zDrive;
                                _2345.mode = _2344;
                                this.CJ.zDrive = _2345;
                            }

                            {
                                JointDriveMode _2346 = JointDriveMode.Position;
                                JointDrive _2347 = this.CJ.angularXDrive;
                                _2347.mode = _2346;
                                this.CJ.angularXDrive = _2347;
                            }

                            {
                                JointDriveMode _2348 = JointDriveMode.Position;
                                JointDrive _2349 = this.CJ.angularYZDrive;
                                _2349.mode = _2348;
                                this.CJ.angularYZDrive = _2349;
                            }

                            {
                                int _2350 = 2;
                                JointDrive _2351 = this.CJ.xDrive;
                                _2351.positionSpring = _2350;
                                this.CJ.xDrive = _2351;
                            }

                            {
                                int _2352 = 2;
                                JointDrive _2353 = this.CJ.yDrive;
                                _2353.positionSpring = _2352;
                                this.CJ.yDrive = _2353;
                            }

                            {
                                int _2354 = 2;
                                JointDrive _2355 = this.CJ.zDrive;
                                _2355.positionSpring = _2354;
                                this.CJ.zDrive = _2355;
                            }

                            {
                                int _2356 = 1000;
                                JointDrive _2357 = this.CJ.angularXDrive;
                                _2357.positionSpring = _2356;
                                this.CJ.angularXDrive = _2357;
                            }

                            {
                                int _2358 = 1000;
                                JointDrive _2359 = this.CJ.angularYZDrive;
                                _2359.positionSpring = _2358;
                                this.CJ.angularYZDrive = _2359;
                            }

                            {
                                float _2360 = 0.1f;
                                JointDrive _2361 = this.CJ.xDrive;
                                _2361.positionDamper = _2360;
                                this.CJ.xDrive = _2361;
                            }

                            {
                                float _2362 = 0.1f;
                                JointDrive _2363 = this.CJ.yDrive;
                                _2363.positionDamper = _2362;
                                this.CJ.yDrive = _2363;
                            }

                            {
                                float _2364 = 0.1f;
                                JointDrive _2365 = this.CJ.zDrive;
                                _2365.positionDamper = _2364;
                                this.CJ.zDrive = _2365;
                            }

                            {
                                float _2366 = 0.1f;
                                JointDrive _2367 = this.CJ.angularXDrive;
                                _2367.positionDamper = _2366;
                                this.CJ.angularXDrive = _2367;
                            }

                            {
                                float _2368 = 0.1f;
                                JointDrive _2369 = this.CJ.angularYZDrive;
                                _2369.positionDamper = _2368;
                                this.CJ.angularYZDrive = _2369;
                            }
                            this.CJ.targetPosition = new Vector3(0, 0, -1);
                            this.IsAttached = true;
                        }
                        else
                        {
                            this.CJ = this.gameObject.AddComponent<ConfigurableJoint>();

                            {
                                JointDriveMode _2370 = JointDriveMode.Position;
                                JointDrive _2371 = this.CJ.xDrive;
                                _2371.mode = _2370;
                                this.CJ.xDrive = _2371;
                            }

                            {
                                JointDriveMode _2372 = JointDriveMode.Position;
                                JointDrive _2373 = this.CJ.yDrive;
                                _2373.mode = _2372;
                                this.CJ.yDrive = _2373;
                            }

                            {
                                JointDriveMode _2374 = JointDriveMode.Position;
                                JointDrive _2375 = this.CJ.zDrive;
                                _2375.mode = _2374;
                                this.CJ.zDrive = _2375;
                            }

                            {
                                JointDriveMode _2376 = JointDriveMode.Position;
                                JointDrive _2377 = this.CJ.angularXDrive;
                                _2377.mode = _2376;
                                this.CJ.angularXDrive = _2377;
                            }

                            {
                                JointDriveMode _2378 = JointDriveMode.Position;
                                JointDrive _2379 = this.CJ.angularYZDrive;
                                _2379.mode = _2378;
                                this.CJ.angularYZDrive = _2379;
                            }

                            {
                                int _2380 = 2;
                                JointDrive _2381 = this.CJ.xDrive;
                                _2381.positionSpring = _2380;
                                this.CJ.xDrive = _2381;
                            }

                            {
                                int _2382 = 2;
                                JointDrive _2383 = this.CJ.yDrive;
                                _2383.positionSpring = _2382;
                                this.CJ.yDrive = _2383;
                            }

                            {
                                int _2384 = 2;
                                JointDrive _2385 = this.CJ.zDrive;
                                _2385.positionSpring = _2384;
                                this.CJ.zDrive = _2385;
                            }

                            {
                                int _2386 = 1000;
                                JointDrive _2387 = this.CJ.angularXDrive;
                                _2387.positionSpring = _2386;
                                this.CJ.angularXDrive = _2387;
                            }

                            {
                                int _2388 = 1000;
                                JointDrive _2389 = this.CJ.angularYZDrive;
                                _2389.positionSpring = _2388;
                                this.CJ.angularYZDrive = _2389;
                            }

                            {
                                float _2390 = 0.1f;
                                JointDrive _2391 = this.CJ.xDrive;
                                _2391.positionDamper = _2390;
                                this.CJ.xDrive = _2391;
                            }

                            {
                                float _2392 = 0.1f;
                                JointDrive _2393 = this.CJ.yDrive;
                                _2393.positionDamper = _2392;
                                this.CJ.yDrive = _2393;
                            }

                            {
                                float _2394 = 0.1f;
                                JointDrive _2395 = this.CJ.zDrive;
                                _2395.positionDamper = _2394;
                                this.CJ.zDrive = _2395;
                            }

                            {
                                float _2396 = 0.1f;
                                JointDrive _2397 = this.CJ.angularXDrive;
                                _2397.positionDamper = _2396;
                                this.CJ.angularXDrive = _2397;
                            }

                            {
                                float _2398 = 0.1f;
                                JointDrive _2399 = this.CJ.angularYZDrive;
                                _2399.positionDamper = _2398;
                                this.CJ.angularYZDrive = _2399;
                            }
                            this.CJ.targetPosition = new Vector3(0, 0, -1);
                            this.IsAttached = true;
                        }
                    }
                }
            }
        }
        if (this.C)
        {
            return;
        }
        if (!this.TypeMine && !this.TypeBomb)
        {
            if ((this.target && this.Proximity) && !this.ProxTrig)
            {
                if (!this.linProx)
                {
                    if (Vector3.Distance(this.transform.position, this.target.position) < this.ProximityRange)
                    {
                        this.Explode();
                    }
                }
                else
                {
                    Debug.DrawRay(this.transform.position, this.transform.forward * this.ProximityRange, Color.yellow);
                    if (Physics.Raycast(this.transform.position, this.transform.forward, out hit0, this.ProximityRange, (int) this.targetLayers))
                    {
                        this.Explode();
                    }
                }
            }
            if (this.LastPoint)
            {
                if (Physics.Linecast(this.LastPoint.position, this.transform.position, (int) this.targetLayers) && this.LPEnabled)
                {
                    this.LastPoint.LookAt(this.transform);
                    if (Physics.Raycast(this.LastPoint.position, this.LastPoint.forward, out hitE, 8, (int) this.targetLayers))
                    {
                        this.LastPoint.position = hitE.point;
                        this.transform.position = this.LastPoint.position;
                    }
                    //rigidbody.velocity = Vector3.zero;
                    //Debug.Log("DidBoom");
                    //Time.timeScale = 0;
                    //Debug.Break();
                    this.Explode();
                }
                else
                {
                    this.LastPoint.position = this.transform.position;
                }
            }
        }
        if (this.TypeMine || this.TypeBomb)
        {
            if (this.Armed)
            {
                if (!this.ProxTrig)
                {
                    this.Explode();
                }
            }
        }
        if (this.target)
        {
            if (Vector3.Distance(this.transform.position, this.target.position) > 32)
            {
                if (Physics.Linecast(this.transform.position, this.target.position, (int) this.targetLayers))
                {
                    this.Avoiding = true;
                }
                else
                {
                    this.Avoiding = false;
                }
            }
            else
            {
                this.Avoiding = false;
            }
        }
        if (this.AvoidGround)
        {
            if (this.Avoiding)
            {
                Vector3 newRot = this.GetComponent<Rigidbody>().velocity;
                if (Physics.Raycast(this.transform.position, newRot, out hit1, this.GetComponent<Rigidbody>().velocity.magnitude, (int) this.targetLayers))
                {
                    if (!hit1.collider.name.Contains("TC" + this.TargetCode))
                    {
                        this.GetComponent<Rigidbody>().AddForce((newRot * -this.GetComponent<Rigidbody>().velocity.magnitude) * 0.004f);
                    }
                }
                if (Physics.Raycast(this.transform.position, Vector3.down, this.HovDist, (int) this.targetLayers))
                {
                    this.GetComponent<Rigidbody>().AddForce(Vector3.up * this.AimForce);
                }
                newRot = ((this.transform.forward * 0.6f) + (this.transform.right * -0.4f)).normalized;
                Debug.DrawRay(this.transform.position, newRot * 8, Color.red);
                if (Physics.Raycast(this.transform.position, newRot, out hit1, 8, (int) this.targetLayers))
                {
                    this.Dist1 = hit1.distance;
                }
                else
                {
                    this.Dist1 = 8;
                }
                newRot = ((this.transform.forward * 0.6f) + (this.transform.right * 0.4f)).normalized;
                Debug.DrawRay(this.transform.position, newRot * 8, Color.yellow);
                if (Physics.Raycast(this.transform.position, newRot, out hit2, 8, (int) this.targetLayers))
                {
                    this.Dist2 = hit2.distance;
                }
                else
                {
                    this.Dist2 = 8;
                }
                if ((this.Dist1 < 8) || (this.Dist2 < 8))
                {
                    if (this.Dist1 > this.Dist2)
                    {
                        this.GetComponent<Rigidbody>().AddTorque((this.transform.up * -this.AimForce) * 2);
                    }
                    else
                    {
                        this.GetComponent<Rigidbody>().AddTorque((this.transform.up * this.AimForce) * 2);
                    }
                }
                newRot = ((this.transform.forward * 0.6f) + (this.transform.up * -0.4f)).normalized;
                Debug.DrawRay(this.transform.position, newRot * 8, Color.green);
                if (Physics.Raycast(this.transform.position, newRot, out hit3, 8, (int) this.targetLayers))
                {
                    this.Dist3 = hit3.distance;
                }
                else
                {
                    this.Dist3 = 8;
                }
                newRot = ((this.transform.forward * 0.6f) + (this.transform.up * 0.4f)).normalized;
                Debug.DrawRay(this.transform.position, newRot * 8, Color.cyan);
                if (Physics.Raycast(this.transform.position, newRot, out hit4, 8, (int) this.targetLayers))
                {
                    this.Dist4 = hit4.distance;
                }
                else
                {
                    this.Dist4 = 8;
                }
                if ((this.Dist3 < 8) || (this.Dist4 < 8))
                {
                    if (this.Dist3 > this.Dist4)
                    {
                        this.GetComponent<Rigidbody>().AddTorque((this.transform.right * this.AimForce) * 2);
                    }
                    else
                    {
                        this.GetComponent<Rigidbody>().AddTorque((this.transform.right * -this.AimForce) * 2);
                    }
                }
            }
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.Contains("mTF"))
        {
            return;
        }
        if (!this.Away || this.CollisionResistant)
        {
            return;
        }
        this.Explode();
    }

    public virtual void Tick()
    {
        if (this.target)
        {
            if (this.AvoidGround)
            {
                if (this.target.name.Contains("TC0"))
                {
                    this.TargetCode = 0;
                }
                if (this.target.name.Contains("TC1"))
                {
                    this.TargetCode = 1;
                }
                if (this.target.name.Contains("TC2"))
                {
                    this.TargetCode = 2;
                }
                if (this.target.name.Contains("TC3"))
                {
                    this.TargetCode = 3;
                }
                if (this.target.name.Contains("TC4"))
                {
                    this.TargetCode = 4;
                }
                if (this.target.name.Contains("TC5"))
                {
                    this.TargetCode = 5;
                }
                if (this.target.name.Contains("TC6"))
                {
                    this.TargetCode = 6;
                }
                if (this.target.name.Contains("TC7"))
                {
                    this.TargetCode = 7;
                }
                if (this.target.name.Contains("TC8"))
                {
                    this.TargetCode = 8;
                }
                if (this.target.name.Contains("TC9"))
                {
                    this.TargetCode = 9;
                }
            }
            if (this.target.name == "broken")
            {
                this.target = null;
            }
        }
        if (this.useMevNavNetwork)
        {
            if (this.target == null)
            {
                if (MevNavNetwork.instance.EnemyTarget1 != null)
                {
                    this.target = MevNavNetwork.instance.EnemyTarget1;
                }
                else
                {
                    this.target = MevNavNetwork.instance.EnemyTarget2;
                }
            }
        }
    }

    public virtual void Lead1()
    {
        if (this.target)
        {
            this.TargetTrace.position = this.target.position;
        }
    }

    public virtual void Lead2()
    {
        if (this.target)
        {
            if (this.useSpleadCurve)
            {
                this.LeadAmount = this.SpleadCurve.Evaluate(this.GetComponent<Rigidbody>().velocity.magnitude);
                this.Dist2 = Vector3.Distance(this.TargetTrace.position, this.target.position);
                this.TargetTrace.LookAt(this.target);
                this.TargetLead.position = this.TargetTrace.position;
                this.TargetLead.rotation = this.TargetTrace.rotation;
                this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * this.Dist0) * this.Dist2) * this.LeadAmount);
            }
            else
            {
                this.Dist0 = Vector3.Distance(this.transform.position, this.target.position);
                this.Dist2 = Vector3.Distance(this.TargetTrace.position, this.target.position);
                this.TargetTrace.LookAt(this.target);
                this.TargetLead.position = this.TargetTrace.position;
                this.TargetLead.rotation = this.TargetTrace.rotation;
                this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * this.Dist0) * this.Dist2) * this.LeadAmount);
            }
        }
    }

    public MissileScript()
    {
        this.LeadAmount = 0.08f;
        this.LeadSpreadU = 0.07f;
        this.LeadSpreadL = 0.09f;
        this.LPEnableTime = 0.2f;
        this.EngageDelay = 1;
        this.ArmDelay = 1;
        this.ThrusterDelay = 1;
        this.ThrusterTime = 1;
        this.Timer = 10;
        this.AimForce = 1;
        this.SpleadCurve = new AnimationCurve();
        this.ProximityRange = 5;
        this.HoverForce = 1;
        this.HovDist = 1;
        this.WeaponOf = "PersonMcPersonface";
    }

}