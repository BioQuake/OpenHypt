using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MainVehicleController : MonoBehaviour
{
    public GameObject Pirizuka;
    public int TravelSpeed;
    public float SpawnDist;
    public float COMx;
    public float COMy;
    public float COMz;
    public int vehicleLevel;
    public string ThisVehiclesID;
    public string ThisVehiclesTC;
    public bool hasHorn;
    public AudioSource horn;
    public GameObject EngineFXGO;
    public bool HasGarage;
    public Transform GaragePoint;
    public GameObject GarageLight;
    public Transform CeptoPoint;
    public GameObject Drone;
    public Transform DronePoint1;
    public Transform DronePoint2;
    public Transform DroneRot;
    public GameObject Backpack;
    public Transform BackpackPoint;
    public GameObject Piribun;
    public Transform PiribunPoint;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public Vector3 localV;
    public VehicleSensor ParentVS;
    public GameObject Anchor1;
    public GameObject Anchor2;
    public GameObject VehicleSight;
    public GameObject WheelController1;
    public GameObject WheelController2;
    public GameObject WheelController3;
    public GameObject WheelController4;
    public GameObject WheelController5;
    public GameObject WheelController6;
    public AdvancedHoverScript Hover1;
    public AdvancedHoverScript Hover2;
    public AdvancedHoverScript Hover3;
    public AdvancedHoverScript Hover4;
    public AdvancedHoverScript Hover5;
    public AdvancedHoverScript Hover6;
    public LegScript Leg1;
    public LegScript Leg2;
    public LegScript Leg3;
    public WingScript Wing1;
    public Rigidbody RB1;
    public Rigidbody RB2;
    private float RB1D;
    private float RB2D;
    public bool WeightFix;
    public bool SkipTempLock;
    public bool PiriZerzek;
    public bool WarpVessel;
    public bool SpaceVessel;
    public bool OpenVessel;
    public bool BigVessel;
    public bool BrightVessel;
    public bool Hitcher;
    public ConfigurableJoint HovJoint;
    public ConfigurableJoint Translator;
    public GameObject TranslatorGO;
    public HingeJoint Hook1;
    public Transform Hook1Tip;
    public HingeJoint Hook2;
    public Transform Hook2Tip;
    public GameObject AttachNoise;
    public GameObject DetachNoise;
    public Transform NoiseArea;
    public ConfigurableJoint HitcherJoint;
    public GameObject Thruster;
    public GameObject Hover;
    public GyroStabilizer Gyro;
    public bool Boosting;
    public GameObject BoostSound;
    public bool CanJam;
    public GameObject JamPrefab;
    public Transform JamArea;
    public bool CanDuck;
    public ConfigurableJoint HoverJoint;
    public float HoverJointMax;
    public float HoverVarSpeed;
    public float Num;
    public float NPOffset;
    public float NPForce;
    public bool AffectedBySvibra;
    public bool StartableEngine;
    public bool Starting;
    public bool EngineOn;
    public bool EngineRunning;
    public GameObject EngineAudio;
    public float EngineAudioVol;
    public float EngineVolFadeSpeed;
    public GameObject EngineOffAudio;
    public GameObject EngineLFX;
    public GameObject EngineFX1;
    public GameObject EngineFX2;
    public GameObject EngineFX3;
    public GameObject EngineFX4;
    public GameObject EngineFX5;
    public GameObject EngineFX6;
    public GameObject EngineFX7;
    public GameObject EngineFX8;
    public GameObject EngineFX9;
    public GameObject EngineFX10;
    public GameObject EngineFX11;
    public GameObject EngineFX12;
    public GameObject EngineFX13;
    public GameObject EngineFX14;
    public GameObject EngineFX15;
    public GameObject EngineFX16;
    public GameObject EngineFX17;
    public GameObject EngineFX18;
    public float EngineOnFXDelay;
    public float EngineOffFXDelay;
    public PivotingHingeThrusterScript WingPivScriptR;
    public PivotingHingeThrusterScript WingPivScriptL;
    public int PivAng;
    public int PivAngBoost;
    public GameObject Rotor1;
    public GameObject Rotor2;
    public GameObject Rotor1SpinMesh;
    public GameObject Rotor1IdleMesh;
    public GameObject Rotor2SpinMesh;
    public GameObject Rotor2IdleMesh;
    public float RotorRotSpeed;
    public float RotorSpeed;
    public int EngineCounter;
    public int SvibraEnveloped;
    public GameObject SvibraFX1;
    public GameObject SvibraFX2;
    public bool canCivmode;
    public bool Civmode;
    public bool CanCruise;
    public bool Cruising;
    public bool canVS;
    public bool VSmode;
    public bool CanAscend;
    public bool CanDescend;
    public bool CanChangeGravity;
    public bool CanAntiGravity;
    public bool CanAngularDrag;
    public bool CanDrag;
    public bool IntegratedController;
    public bool AirController;
    public bool canStrafe;
    public bool BreakNoRev;
    public bool CanBoost;
    public ParticleSystem EnergyIndicator;
    public float BoostDemand;
    public float BoostRegen;
    public bool bRegen;
    public bool useForceCurve;
    public AnimationCurve forceCurve;
    public AnimationCurve bForceCurve;
    public ParticleSystem rBoostThrusterFX1;
    public ParticleSystem lBoostThrusterFX1;
    public ParticleSystem rBoostThrusterFX2;
    public ParticleSystem lBoostThrusterFX2;
    public float DirForce;
    public float DirRevForce;
    public float BooostForce;
    public float XCorrectForce;
    public float TiltForce;
    public float AngForce;
    public float PitchForce;
    public float AscendForce;
    public float DescendForce;
    public bool KeyW;
    public bool KeyA;
    public bool KeyS;
    public bool KeyD;
    public bool KeyZ;
    public bool KeyX;
    public bool KeyLM;
    public bool KeyRM;
    public bool KeySpace;
    public bool KeyShift;
    public bool KeyCtrl;
    public Rigidbody AngDragObject;
    public float AngularDragOn;
    public float AngularDragOff;
    public float DragOn;
    public float DragOff;
    public float AtmosphericDrag;
    public bool Breakless;
    public bool breaksOn;
    public bool Inside;
    public bool Broken;
    public bool Once;
    public LayerMask targetLayers;
    public LayerMask HtargetLayers;
    private float AngDrag;
    
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Counter", 0.23f, 1);
        this.InvokeRepeating("BoostTicker", 0.1f, 0.1f);
       
        if (!SkipTempLock)
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
        
        if (!SpaceVessel)
        {
            if (WorldInformation.instance.AreaSpace == true)
            {
                Broken = true;
            }
        }
        
        if (WeightFix)
        {
            GetComponent<Rigidbody>().useGravity = false;
        }
        
        Pirizuka = PlayerInformation.instance.Pirizuka.gameObject;
        
        thisVTransform = gameObject.transform;
        vRigidbody = gameObject.GetComponent<Rigidbody>();
        AngDrag = GetComponent<Rigidbody>().angularDrag;
        AtmosphericDrag = GetComponent<Rigidbody>().drag;

        GetComponent<Rigidbody>().centerOfMass = new Vector3(COMx, COMy, COMz);
        
        if (RB1)
        {
            RB1D = RB1.angularDrag;
        }
        if (RB2)
        {
            RB2D = RB2.angularDrag;
        }
        
        Inside = false;
        
        if (PiriZerzek)
        {
            if (!WorldInformation.PiriPodPresent)
            {
                GameObject Prefabionaise0 = ((GameObject) Resources.Load("VesselPrefabs/Vessel1338", typeof(GameObject))) as GameObject;
                GameObject TheThing0 = Instantiate(Prefabionaise0, CeptoPoint.position, CeptoPoint.rotation);
                ((VehicleSensor) TheThing0.transform.GetComponent(typeof(VehicleSensor))).Vessel.name = "GaragedPod";
            }
        }
        
        ThisVehiclesID = transform.parent.name.Replace("(Clone)", "");

        if (VehicleSight != null)
        {
            VehicleSight.SetActive(false);
            GameObject Prefabionaise = ((GameObject) Resources.Load("Prefabs/CamSight", typeof(GameObject))) as GameObject;
            GameObject TheThing = Instantiate(Prefabionaise, VehicleSight.transform.position, VehicleSight.transform.rotation);
            TheThing.transform.parent = VehicleSight.gameObject.transform;
        }
        
        if (Drone)
        {
            GameObject TheDrone1 = Instantiate(Drone, DronePoint1.transform.position, DroneRot.transform.rotation);
            GameObject TheDrone2 = Instantiate(Drone, DronePoint2.transform.position, DroneRot.transform.rotation);
            ((PiriDefenseDroneAI) TheDrone1.transform.GetChild(0).GetComponent(typeof(PiriDefenseDroneAI))).OnStartup = true;
            ((PiriDefenseDroneAI) TheDrone1.transform.GetChild(0).GetComponent(typeof(PiriDefenseDroneAI))).Settlepoint = DronePoint1;
            ((PiriDefenseDroneAI) TheDrone2.transform.GetChild(0).GetComponent(typeof(PiriDefenseDroneAI))).Settlepoint = DronePoint2;
        }
        
        if (!WheelController1 && !WheelController2 && !WheelController3 && !WheelController4 && !WheelController5 && !WheelController6 
            && !Anchor1 && !Anchor2 
            && !Hover1 && !Hover2 && !Hover3 && !Hover4 && !Hover5 && !Hover6
            && !Leg1 && !Leg2 && !Leg3
            && !Wing1
            && !RB1 && !RB2)
        {
            Breakless = true;
            breaksOn = false;
        }
        
        if (Breakless && StartableEngine)
        {
            if (Hover1 != null)
            {
                Hover1.breaksOn = true;
            }
            if (Hover2 != null)
            {
                Hover2.breaksOn = true;
            }
            if (Hover3 != null)
            {
                Hover3.breaksOn = true;
            }
            if (Hover4 != null)
            {
                Hover4.breaksOn = true;
            }
            if (Hover5 != null)
            {
                Hover5.breaksOn = true;
            }
            if (Hover6 != null)
            {
                Hover6.breaksOn = true;
            }
            breaksOn = false;
        }
        
        if (breaksOn)
        {
            if (WheelController1 != null)
            {
                WheelController1.GetComponent<WheelMotorController>().breaksOn = true;
            }
            if (this.WheelController2 != null)
            {
                WheelController2.GetComponent<WheelMotorController>().breaksOn = true;
            }
            if (this.WheelController3 != null)
            {
                WheelController3.GetComponent<WheelMotorController>().breaksOn = true;
            }
            if (this.WheelController4 != null)
            {
                WheelController4.GetComponent<WheelMotorController>().breaksOn = true;
            }
            if (this.WheelController5 != null)
            {
                WheelController5.GetComponent<WheelMotorController>().breaksOn = true;
            }
            if (this.WheelController6 != null)
            {
                WheelController6.GetComponent<WheelMotorController>().breaksOn = true;
            }
            if (Hover1 != null)
            {
                Hover1.breaksOn = true;
            }
            if (Hover2 != null)
            {
                Hover2.breaksOn = true;
            }
            if (Hover3 != null)
            {
                Hover3.breaksOn = true;
            }
            if (Hover4 != null)
            {
                Hover4.breaksOn = true;
            }
            if (Hover5 != null)
            {
                Hover5.breaksOn = true;
            }
            if (Hover6 != null)
            {
                Hover6.breaksOn = true;
            }
            if (Leg1 != null)
            {
                Leg1.breaksOn = true;
            }
            if (Leg2 != null)
            {
                Leg2.breaksOn = true;
            }
            if (Leg3 != null)
            {
                Leg3.breaksOn = true;
            }
            if (Wing1 != null)
            {
                Wing1.Broken = true;
            }
            if (RB1)
            {
                RB1.angularDrag = 0.1f;
            }
            if (RB2)
            {
                RB2.angularDrag = 0.1f;
            }
        }

        if (WorldInformation.instance.AreaSpace)
        {
            if (CanChangeGravity)
            {
                GetComponent<Rigidbody>().useGravity = false;
            }
            GetComponent<Rigidbody>().drag = 0;
        }
        
        if (!WorldInformation.instance.AreaSpace)
        {
            if (CanChangeGravity)
            {
                GetComponent<Rigidbody>().useGravity = true;
            }
            GetComponent<Rigidbody>().drag = AtmosphericDrag;
        }
        
        if (HasGarage)
        {
            if (PlayerPrefs.HasKey("GaragedID"))
            {
                float Dist = PlayerPrefs.GetFloat("GaragedDist");
                string ID = PlayerPrefs.GetString("GaragedID");
                //var Prefabionaise2 = Resources.Load("VesselPrefabs/" + WorldInformation.GaragedVehicle, GameObject) as GameObject;
                GameObject Prefabionaise2 = ((GameObject) Resources.Load("VesselPrefabs/" + ID, typeof(GameObject))) as GameObject;
                GameObject TheThing1 = Instantiate(Prefabionaise2, GaragePoint.position, GaragePoint.rotation);
                
                float garageYPos = TheThing1.transform.position.y + Dist;
                Vector3 garagedVesselTransform = TheThing1.transform.position;
                garagedVesselTransform.y = garageYPos;
                TheThing1.transform.position = garagedVesselTransform;
                
                if (ID != "Vessel74")
                {
                    ((VehicleSensor) TheThing1.transform.GetComponent(typeof(VehicleSensor))).Vessel.name = "GaragedVessel";
                }
            }
        }

        yield return new WaitForSeconds(0.1f);
        
        GetComponent<Rigidbody>().isKinematic = false;
       
        if (PiriZerzek)
        {
            Instantiate(this.Piribun, this.PiribunPoint.position, this.PiribunPoint.rotation);
        }

        yield return new WaitForSeconds(0.3f);

        Transform horny = transform.Find("Horn");
        if (horny)
        {
            horn = (AudioSource) horny.GetComponent(typeof(AudioSource));
        }
        
        if (horn)
        {
            hasHorn = true;
        }
        else
        {
            hasHorn = false;
        }

        if (PiriZerzek)
        {
            if (!WorldInformation.backpackIsPresent)
            {
                Instantiate(Backpack, BackpackPoint.position, BackpackPoint.rotation);
            }
           
            Instantiate(Piribun, PiribunPoint.position, PiribunPoint.rotation);
        }
        yield return new WaitForSeconds(0.3f);

        Transform Fxy = this.transform.Find("EngineFX");
        if (Fxy)
        {
            EngineFXGO = Fxy.gameObject;
        }
        
        if (PiriZerzek)
        {
            Instantiate(Piribun, PiribunPoint.position, PiribunPoint.rotation);

            yield return new WaitForSeconds(0.3f);

            Instantiate(Piribun, PiribunPoint.position, PiribunPoint.rotation);
        }
    }

    public virtual void OnEnable()
    {
        if (!Breakless && !StartableEngine)
        {
            breaksOn = true;
        }
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        if (WeightFix)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0f, -0.2f, 0f), ForceMode.VelocityChange);
        }
        
        if (CanAscend || useForceCurve)
        {
            localV = thisVTransform.InverseTransformDirection(vRigidbody.velocity);
        }
       
        if (Hitcher)
        {

            {
                int _2282 = 0;
                Vector3 _2283 = this.Translator.transform.localPosition;
                _2283.x = _2282;
                this.Translator.transform.localPosition = _2283;
            }

            {
                int _2284 = 0;
                Vector3 _2285 = this.Translator.transform.localPosition;
                _2285.y = _2284;
                this.Translator.transform.localPosition = _2285;
            }
            Translator.transform.localRotation = Quaternion.Euler(0, 0, 0);
            if (Broken)
            {
                if (HitcherJoint)
                {
                    Destroy(HitcherJoint);
                }
            }
        }
        
        if (!Broken)
        {
            if ((CanDuck && !CameraScript.InInterface) && (WorldInformation.playerCar == transform.name))
            {
                if (!Input.GetKey(KeyCode.LeftControl))
                {
                    if (Num < 0)
                    {
                        Num = Num + HoverVarSpeed;
                    }
                }
                
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    if (Num > HoverJointMax)
                    {
                        Num = Num - HoverVarSpeed;
                    }
                }
                
                HoverJoint.targetPosition = new Vector3(0, 0, Num);
            }
           
            if (Inside)
            {
                if (WorldInformation.IsNopass == true)
                {
                    if (GetComponent<Rigidbody>().mass < 10)
                    {
                        NPOffset = 10;
                    }
                    else
                    {
                        NPOffset = GetComponent<Rigidbody>().mass;
                    }
                    
                    if (GetComponent<Rigidbody>().mass < 2)
                    {
                        NPForce = 2;
                    }
                    else
                    {
                        NPForce = GetComponent<Rigidbody>().mass;
                    }
                    
                    if (GetComponent<Rigidbody>().mass > 1000)
                    {
                        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                        NPOffset = GetComponent<Rigidbody>().mass * 0.1f;
                        float AngVelMod = GetComponent<Rigidbody>().angularVelocity.magnitude * 32;
                        float NPAng = Mathf.Clamp(AngVelMod, 3.33f, 32);
                        AngDragObject.angularDrag = NPAng;
                    }
                    
                    if (GetComponent<Rigidbody>().angularVelocity.magnitude < 0.5f)
                    {
                        GetComponent<Rigidbody>().AddForceAtPosition((WorldInformation.instance.transform.position - transform.position).normalized * NPForce, -transform.up * NPOffset);
                        GetComponent<Rigidbody>().AddForceAtPosition((WorldInformation.instance.transform.position - transform.position).normalized * -NPForce, transform.up * NPOffset);
                    }
                }
            }
            
            if (IntegratedController)
            {
                if (useForceCurve)
                {
                    DirForce = forceCurve.Evaluate(-localV.y);
                    BooostForce = bForceCurve.Evaluate(-localV.y);
                }
                
                if (StartableEngine)
                {
                    if (EngineRunning)
                    {
                        if (Inside)
                        {
                            GetComponent<Rigidbody>().AddTorque(transform.right * XCorrectForce);
                        }
                        
                        if (AirController)
                        {
                            if (KeyLM)
                            {
                                GetComponent<Rigidbody>().AddForce(transform.up * -DirForce);
                            }
                            if (KeySpace)
                            {
                                GetComponent<Rigidbody>().AddForce(transform.up * DirRevForce);
                            }
                            if (KeyZ)
                            {
                                GetComponent<Rigidbody>().AddTorque(transform.forward * -AngForce);
                            }
                            if (KeyX)
                            {
                                GetComponent<Rigidbody>().AddTorque(transform.forward * AngForce);
                            }
                            if (KeyA)
                            {
                                GetComponent<Rigidbody>().AddTorque(transform.up * -AngForce);
                            }
                            if (KeyD)
                            {
                                GetComponent<Rigidbody>().AddTorque(transform.up * AngForce);
                            }
                            if (KeyS)
                            {
                                GetComponent<Rigidbody>().AddTorque(transform.right * -PitchForce);
                            }
                            if (KeyW)
                            {
                                GetComponent<Rigidbody>().AddTorque(transform.right * PitchForce);
                            }
                        }
                        else
                        {
                            if (KeyW)
                            {
                                if (!Civmode)
                                {
                                    if (!Boosting)
                                    {
                                        if (!canStrafe)
                                        {
                                            GetComponent<Rigidbody>().AddForce(transform.up * -DirForce);
                                        }
                                        else
                                        {
                                            if (KeyA || KeyD)
                                            {
                                                GetComponent<Rigidbody>().AddForce((transform.up * -DirForce) * 0.7f);
                                            }
                                            else
                                            {
                                                GetComponent<Rigidbody>().AddForce(transform.up * -DirForce);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        GetComponent<Rigidbody>().AddForce(transform.up * -BooostForce);
                                    }
                                }
                                else
                                {
                                    GetComponent<Rigidbody>().AddForce(transform.up * -DirRevForce);
                                }
                                GetComponent<Rigidbody>().AddTorque(transform.right * TiltForce);
                            }
                            if (KeyS)
                            {
                                if (BreakNoRev)
                                {
                                    if (-localV.y > 0)
                                    {
                                        if (!Boosting)
                                        {
                                            GetComponent<Rigidbody>().AddForce(transform.up * DirRevForce);
                                        }
                                        else
                                        {
                                            GetComponent<Rigidbody>().AddForce(transform.up * BooostForce);
                                        }
                                    }
                                }
                                else
                                {
                                    if (!Boosting)
                                    {
                                        if (!canStrafe)
                                        {
                                            GetComponent<Rigidbody>().AddForce(transform.up * DirRevForce);
                                        }
                                        else
                                        {
                                            if (KeyA || KeyD)
                                            {
                                                GetComponent<Rigidbody>().AddForce((transform.up * DirRevForce) * 0.7f);
                                            }
                                            else
                                            {
                                                GetComponent<Rigidbody>().AddForce(transform.up * DirRevForce);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        GetComponent<Rigidbody>().AddForce(transform.up * BooostForce);
                                    }
                                }
                                GetComponent<Rigidbody>().AddTorque(transform.right * -TiltForce);
                            }
                            if (KeyA)
                            {
                                if (canStrafe)
                                {
                                    if (!KeyRM)
                                    {
                                        GetComponent<Rigidbody>().AddTorque(transform.forward * -AngForce);
                                    }
                                    else
                                    {
                                        if (!KeyW)
                                        {
                                            GetComponent<Rigidbody>().AddForce(transform.right * -DirRevForce);
                                        }
                                        else
                                        {
                                            GetComponent<Rigidbody>().AddForce((transform.right * -DirRevForce) * 0.7f);
                                        }
                                    }
                                }
                                else
                                {
                                    GetComponent<Rigidbody>().AddTorque(transform.forward * -AngForce);
                                }
                            }
                            if (KeyD)
                            {
                                if (canStrafe)
                                {
                                    if (!KeyRM)
                                    {
                                        GetComponent<Rigidbody>().AddTorque(transform.forward * AngForce);
                                    }
                                    else
                                    {
                                        if (!KeyW)
                                        {
                                            GetComponent<Rigidbody>().AddForce(transform.right * DirRevForce);
                                        }
                                        else
                                        {
                                            GetComponent<Rigidbody>().AddForce((transform.right * DirRevForce) * 0.7f);
                                        }
                                    }
                                }
                                else
                                {
                                    GetComponent<Rigidbody>().AddTorque(transform.forward * AngForce);
                                }
                            }
                        }
                        if (CanAscend)
                        {
                            if (KeyShift)
                            {
                                GetComponent<Rigidbody>().AddForce(transform.forward * AscendForce);
                            }
                        }
                        if (CanDescend)
                        {
                            if (KeyCtrl)
                            {
                                GetComponent<Rigidbody>().AddForce(-transform.forward * DescendForce);
                            }
                        }
                    }
                }
                else
                {
                    if (Inside)
                    {
                        GetComponent<Rigidbody>().AddTorque(transform.right * XCorrectForce);
                    }
                    if (AirController)
                    {
                        if (KeyLM)
                        {
                            GetComponent<Rigidbody>().AddForce(transform.up * -DirForce);
                        }
                        if (KeySpace)
                        {
                            GetComponent<Rigidbody>().AddForce(transform.up * DirRevForce);
                        }
                        if (KeyZ)
                        {
                            GetComponent<Rigidbody>().AddTorque(transform.forward * -AngForce);
                        }
                        if (KeyX)
                        {
                            GetComponent<Rigidbody>().AddTorque(transform.forward * AngForce);
                        }
                        if (KeyA)
                        {
                            GetComponent<Rigidbody>().AddTorque(transform.up * -AngForce);
                        }
                        if (KeyD)
                        {
                            GetComponent<Rigidbody>().AddTorque(transform.up * AngForce);
                        }
                        if (KeyS)
                        {
                            GetComponent<Rigidbody>().AddTorque(transform.right * -PitchForce);
                        }
                        if (KeyW)
                        {
                            GetComponent<Rigidbody>().AddTorque(transform.right * PitchForce);
                        }
                    }
                    else
                    {
                        if (KeyW)
                        {
                            if (!Civmode)
                            {
                                if (!Boosting)
                                {
                                    if (!canStrafe)
                                    {
                                        GetComponent<Rigidbody>().AddForce(transform.up * -DirForce);
                                    }
                                    else
                                    {
                                        if (KeyA || KeyD)
                                        {
                                            GetComponent<Rigidbody>().AddForce((transform.up * -DirForce) * 0.7f);
                                        }
                                        else
                                        {
                                            GetComponent<Rigidbody>().AddForce(transform.up * -DirForce);
                                        }
                                    }
                                }
                                else
                                {
                                    GetComponent<Rigidbody>().AddForce(transform.up * -BooostForce);
                                }
                            }
                            else
                            {
                                GetComponent<Rigidbody>().AddForce(transform.up * -DirRevForce);
                            }
                            GetComponent<Rigidbody>().AddTorque(transform.right * TiltForce);
                        }
                        if (KeyS)
                        {
                            if (BreakNoRev)
                            {
                                if (-localV.y > 0)
                                {
                                    if (!Boosting)
                                    {
                                        GetComponent<Rigidbody>().AddForce(transform.up * DirRevForce);
                                    }
                                    else
                                    {
                                        GetComponent<Rigidbody>().AddForce(transform.up * BooostForce);
                                    }
                                }
                            }
                            else
                            {
                                if (!Boosting)
                                {
                                    if (!canStrafe)
                                    {
                                        GetComponent<Rigidbody>().AddForce(transform.up * DirRevForce);
                                    }
                                    else
                                    {
                                        if (KeyA || KeyD)
                                        {
                                            GetComponent<Rigidbody>().AddForce((transform.up * DirRevForce) * 0.7f);
                                        }
                                        else
                                        {
                                            GetComponent<Rigidbody>().AddForce(transform.up * DirRevForce);
                                        }
                                    }
                                }
                                else
                                {
                                    GetComponent<Rigidbody>().AddForce(transform.up * BooostForce);
                                }
                            }
                            GetComponent<Rigidbody>().AddTorque(transform.right * -TiltForce);
                        }
                        if (KeyA)
                        {
                            if (canStrafe)
                            {
                                if (!KeyRM)
                                {
                                    GetComponent<Rigidbody>().AddTorque(transform.forward * -AngForce);
                                }
                                else
                                {
                                    if (!KeyW)
                                    {
                                        GetComponent<Rigidbody>().AddForce(transform.right * -DirRevForce);
                                    }
                                    else
                                    {
                                        GetComponent<Rigidbody>().AddForce((transform.right * -DirRevForce) * 0.7f);
                                    }
                                }
                            }
                            else
                            {
                                GetComponent<Rigidbody>().AddTorque(transform.forward * -AngForce);
                            }
                        }
                        if (KeyD)
                        {
                            if (canStrafe)
                            {
                                if (!KeyRM)
                                {
                                    GetComponent<Rigidbody>().AddTorque(transform.forward * AngForce);
                                }
                                else
                                {
                                    if (!KeyW)
                                    {
                                        GetComponent<Rigidbody>().AddForce(transform.right * DirRevForce);
                                    }
                                    else
                                    {
                                        GetComponent<Rigidbody>().AddForce((transform.right * DirRevForce) * 0.7f);
                                    }
                                }
                            }
                            else
                            {
                                GetComponent<Rigidbody>().AddTorque(transform.forward * AngForce);
                            }
                        }
                    }
                    if (CanAscend)
                    {
                        if (KeyShift)
                        {
                            GetComponent<Rigidbody>().AddForce(transform.forward * AscendForce);
                            if (XCorrectForce != 0)
                            {
                                GetComponent<Rigidbody>().AddTorque((transform.right * XCorrectForce) * 6);
                            }
                        }
                    }
                    if (CanDescend)
                    {
                        if (KeyCtrl)
                        {
                            GetComponent<Rigidbody>().AddForce(-transform.forward * DescendForce);
                        }
                    }
                }
                if (IntegratedController && (WorldInformation.playerCar == transform.name))
                {
                    if (Hitcher && !CameraScript.InInterface)
                    {
                        if (Input.GetKey(KeyCode.PageDown))
                        {
                            if (HovJoint.targetPosition.z > -0.5f)
                            {
                                HovJoint.targetPosition = HovJoint.targetPosition - new Vector3(0, 0, 0.01f);
                            }
                        }
                        if (Input.GetKey(KeyCode.PageUp))
                        {
                            if (HovJoint.targetPosition.z < 0.5f)
                            {
                                HovJoint.targetPosition = HovJoint.targetPosition + new Vector3(0, 0, 0.01f);
                            }
                        }
                        if (Input.GetKey("2"))
                        {
                            if (Translator.targetPosition.z > -2.5f)
                            {
                                Translator.targetPosition = Translator.targetPosition - new Vector3(0, 0, 0.01f);
                            }
                        }
                        if (Input.GetKey("1"))
                        {
                            if (Translator.targetPosition.z < 0)
                            {
                                Translator.targetPosition = Translator.targetPosition + new Vector3(0, 0, 0.01f);
                            }
                        }
                        if (Input.GetKey("4"))
                        {
                            if (Hook1.spring.targetPosition < 90)
                            {

                                {
                                    float _2286 = Hook1.spring.targetPosition + 1;
                                    JointSpring _2287 = Hook1.spring;
                                    _2287.targetPosition = _2286;
                                    Hook1.spring = _2287;
                                }
                            }
                            if (Hook2.spring.targetPosition > -90)
                            {

                                {
                                    float _2288 = Hook2.spring.targetPosition - 1;
                                    JointSpring _2289 = Hook2.spring;
                                    _2289.targetPosition = _2288;
                                    Hook2.spring = _2289;
                                }
                            }
                            if (HitcherJoint)
                            {
                                Destroy(HitcherJoint);
                                GameObject TheThing1 = Instantiate(DetachNoise, NoiseArea.position, NoiseArea.rotation);
                                TheThing1.transform.parent = gameObject.transform;
                            }
                        }
                        if (Input.GetKey("3"))
                        {
                            if (!HitcherJoint)
                            {
                                if (Hook1.spring.targetPosition > 0)
                                {

                                    {
                                        float _2290 = Hook1.spring.targetPosition - 1;
                                        JointSpring _2291 = Hook1.spring;
                                        _2291.targetPosition = _2290;
                                        Hook1.spring = _2291;
                                    }
                                }
                                if (Hook2.spring.targetPosition < 0)
                                {

                                    {
                                        float _2292 = Hook2.spring.targetPosition + 1;
                                        JointSpring _2293 = Hook2.spring;
                                        _2293.targetPosition = _2292;
                                        Hook2.spring = _2293;
                                    }
                                }
                                if (Physics.Raycast(Hook1Tip.position, Hook1Tip.forward, out hit, 0.4f, HtargetLayers)
                                    && Physics.Raycast(Hook2Tip.position, Hook2Tip.forward, out hit, 0.4f, HtargetLayers))
                                {
                                    HitcherJoint = TranslatorGO.AddComponent<ConfigurableJoint>();
                                    HitcherJoint.connectedBody = hit.rigidbody;

                                    {
                                        JointDriveMode _2294 = JointDriveMode.Position;
                                        JointDrive _2295 = HitcherJoint.xDrive;
                                        _2295.mode = _2294;
                                        HitcherJoint.xDrive = _2295;
                                    }

                                    {
                                        JointDriveMode _2296 = JointDriveMode.Position;
                                        JointDrive _2297 = HitcherJoint.yDrive;
                                        _2297.mode = _2296;
                                        HitcherJoint.yDrive = _2297;
                                    }

                                    {
                                        JointDriveMode _2298 = JointDriveMode.Position;
                                        JointDrive _2299 = HitcherJoint.zDrive;
                                        _2299.mode = _2298;
                                        HitcherJoint.zDrive = _2299;
                                    }

                                    {
                                        JointDriveMode _2300 = JointDriveMode.Position;
                                        JointDrive _2301 = HitcherJoint.angularXDrive;
                                        _2301.mode = _2300;
                                        HitcherJoint.angularXDrive = _2301;
                                    }

                                    {
                                        JointDriveMode _2302 = JointDriveMode.Position;
                                        JointDrive _2303 = HitcherJoint.angularYZDrive;
                                        _2303.mode = _2302;
                                        HitcherJoint.angularYZDrive = _2303;
                                    }

                                    {
                                        int _2304 = 10000;
                                        JointDrive _2305 = HitcherJoint.xDrive;
                                        _2305.positionSpring = _2304;
                                        HitcherJoint.xDrive = _2305;
                                    }

                                    {
                                        int _2306 = 10000;
                                        JointDrive _2307 = HitcherJoint.yDrive;
                                        _2307.positionSpring = _2306;
                                        HitcherJoint.yDrive = _2307;
                                    }

                                    {
                                        int _2308 = 10000;
                                        JointDrive _2309 = HitcherJoint.zDrive;
                                        _2309.positionSpring = _2308;
                                        HitcherJoint.zDrive = _2309;
                                    }

                                    {
                                        int _2310 = 10000;
                                        JointDrive _2311 = HitcherJoint.angularXDrive;
                                        _2311.positionSpring = _2310;
                                        HitcherJoint.angularXDrive = _2311;
                                    }

                                    {
                                        int _2312 = 10000;
                                        JointDrive _2313 = HitcherJoint.angularYZDrive;
                                        _2313.positionSpring = _2312;
                                        HitcherJoint.angularYZDrive = _2313;
                                    }

                                    {
                                        int _2314 = 1;
                                        JointDrive _2315 = HitcherJoint.xDrive;
                                        _2315.positionDamper = _2314;
                                        HitcherJoint.xDrive = _2315;
                                    }

                                    {
                                        int _2316 = 1;
                                        JointDrive _2317 = HitcherJoint.yDrive;
                                        _2317.positionDamper = _2316;
                                        HitcherJoint.yDrive = _2317;
                                    }

                                    {
                                        int _2318 = 1;
                                        JointDrive _2319 = HitcherJoint.zDrive;
                                        _2319.positionDamper = _2318;
                                        HitcherJoint.zDrive = _2319;
                                    }

                                    {
                                        int _2320 = 1;
                                        JointDrive _2321 = HitcherJoint.angularXDrive;
                                        _2321.positionDamper = _2320;
                                        HitcherJoint.angularXDrive = _2321;
                                    }

                                    {
                                        int _2322 = 1;
                                        JointDrive _2323 = HitcherJoint.angularYZDrive;
                                        _2323.positionDamper = _2322;
                                        HitcherJoint.angularYZDrive = _2323;
                                    }
                                    GameObject TheThing2 = Instantiate(AttachNoise, NoiseArea.position, NoiseArea.rotation);
                                    TheThing2.transform.parent = gameObject.transform;
                                }
                            }
                        }
                    }
                }
            }
            if (Rotor1)
            {
                Rotor1.transform.Rotate(0, -RotorSpeed, 0 * Time.deltaTime);
                Rotor2.transform.Rotate(0, RotorSpeed, 0 * Time.deltaTime);
                if (EngineRunning)
                {
                    if (RotorSpeed < RotorRotSpeed)
                    {
                        RotorSpeed = RotorSpeed + 1;
                    }
                }
                else
                {
                    if (RotorSpeed > 0)
                    {
                        RotorSpeed = RotorSpeed - 1;
                    }
                }
                if (RotorSpeed > 20)
                {
                    Rotor1IdleMesh.gameObject.SetActive(false);
                    Rotor1SpinMesh.gameObject.SetActive(true);
                    Rotor2IdleMesh.gameObject.SetActive(false);
                    Rotor2SpinMesh.gameObject.SetActive(true);
                }
                else
                {
                    Rotor1IdleMesh.gameObject.SetActive(true);
                    Rotor1SpinMesh.gameObject.SetActive(false);
                    Rotor2IdleMesh.gameObject.SetActive(true);
                    Rotor2SpinMesh.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (Rotor1)
            {
                Rotor1.transform.Rotate(0, -RotorSpeed, 0 * Time.deltaTime);
                Rotor2.transform.Rotate(0, RotorSpeed, 0 * Time.deltaTime);
                if (RotorSpeed > 0)
                {
                    RotorSpeed = RotorSpeed - 1;
                }
                if (RotorSpeed > 20)
                {
                    Rotor1IdleMesh.gameObject.SetActive(false);
                    Rotor1SpinMesh.gameObject.SetActive(true);
                    Rotor2IdleMesh.gameObject.SetActive(false);
                    Rotor2SpinMesh.gameObject.SetActive(true);
                }
                else
                {
                    Rotor1IdleMesh.gameObject.SetActive(true);
                    Rotor1SpinMesh.gameObject.SetActive(false);
                    Rotor2IdleMesh.gameObject.SetActive(true);
                    Rotor2SpinMesh.gameObject.SetActive(false);
                }
            }
        }
        if (AffectedBySvibra)
        {
            if (SvibraEnveloped > 1)
            {
                SvibraEnveloped = SvibraEnveloped - 1;
                if (SvibraEnveloped > 50)
                {
                    if (GetComponent<Rigidbody>().drag < 10)
                    {
                        GetComponent<Rigidbody>().drag = GetComponent<Rigidbody>().drag + 0.02f;
                    }
                    SvibraFX1.GetComponent<ParticleSystem>().enableEmission = true;
                    SvibraFX2.GetComponent<ParticleSystem>().enableEmission = true;
                }
                if (SvibraEnveloped < 2)
                {
                    GetComponent<Rigidbody>().drag = AtmosphericDrag;
                    SvibraFX1.GetComponent<ParticleSystem>().enableEmission = false;
                    SvibraFX2.GetComponent<ParticleSystem>().enableEmission = false;
                }
            }
        }
        if (StartableEngine)
        {
            if (EngineOn && Broken)
            {
                EngineOn = false;
                if (EngineOffAudio)
                {
                    EngineOffAudio.GetComponent<AudioSource>().Play();
                }
                StartCoroutine(EngineEffectsOff());
            }
            if (!EngineOn && !Broken)
            {
                if (EngineAudio.GetComponent<AudioSource>().volume > 0)
                {
                    EngineAudio.GetComponent<AudioSource>().volume = EngineAudio.GetComponent<AudioSource>().volume - EngineVolFadeSpeed;
                }
                if (EngineAudio.GetComponent<AudioSource>().volume == 0)
                {
                    EngineAudio.GetComponent<AudioSource>().Stop();
                }
            }
            if (Starting && !Broken)
            {
                if ((EngineCounter < 100) && !EngineOn)
                {
                    EngineCounter = EngineCounter + 1;
                }
                if ((EngineCounter > 0) && EngineOn)
                {
                    EngineCounter = EngineCounter - 1;
                }
                if ((EngineCounter == 100) && !EngineOn)
                {
                    EngineOn = true;
                    this.EngineAudio.GetComponent<AudioSource>().volume = this.EngineAudioVol;
                    this.EngineAudio.GetComponent<AudioSource>().Play();
                    this.StartCoroutine(this.EngineEffectsOn());
                    if (this.Hover1 != null)
                    {
                        this.Hover1.breaksOn = false;
                    }
                    if (this.Hover2 != null)
                    {
                        this.Hover2.breaksOn = false;
                    }
                    if (this.Hover3 != null)
                    {
                        this.Hover3.breaksOn = false;
                    }
                    if (this.Hover4 != null)
                    {
                        this.Hover4.breaksOn = false;
                    }
                    if (this.Hover5 != null)
                    {
                        this.Hover5.breaksOn = false;
                    }
                    if (this.Hover6 != null)
                    {
                        this.Hover6.breaksOn = false;
                    }
                    this.breaksOn = false;
                }
                if ((this.EngineCounter == 0) && this.EngineOn)
                {
                    this.EngineOn = false;
                    this.EngineOffAudio.GetComponent<AudioSource>().Play();
                    this.StartCoroutine(this.EngineEffectsOff());
                    this.KeySpace = false;
                    this.KeyRM = false;
                    this.KeyLM = false;
                    this.KeyW = false;
                    this.KeyA = false;
                    this.KeyS = false;
                    this.KeyD = false;
                    this.KeyZ = false;
                    this.KeyX = false;
                    if (this.Hover1 != null)
                    {
                        this.Hover1.breaksOn = true;
                    }
                    if (this.Hover2 != null)
                    {
                        this.Hover2.breaksOn = true;
                    }
                    if (this.Hover3 != null)
                    {
                        this.Hover3.breaksOn = true;
                    }
                    if (this.Hover4 != null)
                    {
                        this.Hover4.breaksOn = true;
                    }
                    if (this.Hover5 != null)
                    {
                        this.Hover5.breaksOn = true;
                    }
                    if (this.Hover6 != null)
                    {
                        this.Hover6.breaksOn = true;
                    }
                    if (this.Leg1 != null)
                    {
                        this.Leg1.breaksOn = true;
                    }
                    if (this.Leg2 != null)
                    {
                        this.Leg2.breaksOn = true;
                    }
                    if (this.Leg3 != null)
                    {
                        this.Leg3.breaksOn = true;
                    }
                }
            }
        }
        if (this.VehicleSight != null)
        {
            this.ActivateSight();
        }
    }

    public virtual void ArtificialUpdate()
    {
        if (this.Broken)
        {
            this.Starting = true;
        }
        if (Input.GetKeyDown("q"))
        {
            this.Starting = true;
        }
        if (Input.GetKeyUp("q"))
        {
            this.Starting = false;
        }
        if (this.Broken && !this.Once)
        {
            this.name = "broken";
            WorldInformation.playerCar = this.transform.name;
            if (this.OpenVessel)
            {
                this.StartCoroutine(WorldInformation.vehicleDoorController.Exit());
                UnityEngine.Object.Destroy(WorldInformation.vehicleDoorController);
            }
            if (this.Inside)
            {
                DrivenVesselScript.WhatToSpawn = "null";
            }
            if (this.HitcherJoint)
            {
                UnityEngine.Object.Destroy(this.HitcherJoint);
            }
            this.Once = true;
        }
        if (this.Broken)
        {
            return;
        }
        float verticalInput = Input.GetAxis("Vertical");
        if (this.hasHorn)
        {
            if (Input.GetKeyDown("h"))
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    if (!this.horn.isPlaying)
                    {
                        this.horn.Play();
                        this.horn.loop = true;
                    }
                }
            }
            if (Input.GetKeyUp("h"))
            {
                this.horn.loop = false;
            }
        }
        if (this.CanJam)
        {
            if (Input.GetKeyDown("g"))
            {
                GameObject TheThingJ = UnityEngine.Object.Instantiate(this.JamPrefab, this.JamArea.position, this.JamArea.rotation);
                TheThingJ.transform.parent = this.JamArea;
                this.StartCoroutine(this.JamReset());
                this.CanJam = false;
            }
        }
        if (!this.Breakless && !CameraScript.InInterface)
        {
            if (this.StartableEngine)
            {
                if (Input.GetKeyDown(KeyCode.P) && this.EngineOn)
                {
                    this.CheckWheels();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    this.CheckWheels();
                }
            }
        }
        if (this.canCivmode)
        {
            if (Input.GetKeyDown("c"))
            {
                if (!this.KeyW)
                {
                    if (!this.Civmode)
                    {
                        this.Civmode = true;
                    }
                    else
                    {
                        this.Civmode = false;
                    }
                }
            }
        }
        if (!this.StartableEngine)
        {
            if (!CameraScript.InInterface)
            {
                if (this.canVS)
                {
                    if (Input.GetKeyDown("v"))
                    {
                        if (this.Hover1 != null)
                        {
                            this.Hover1.hBool();
                        }
                        if (this.Hover2 != null)
                        {
                            this.Hover2.hBool();
                        }
                        if (this.Hover3 != null)
                        {
                            this.Hover3.hBool();
                        }
                        if (this.Hover4 != null)
                        {
                            this.Hover4.hBool();
                        }
                        if (this.Hover5 != null)
                        {
                            this.Hover5.hBool();
                        }
                        if (this.Hover6 != null)
                        {
                            this.Hover6.hBool();
                        }
                        if (!this.VSmode)
                        {
                            this.VSmode = true;
                        }
                        else
                        {
                            this.VSmode = false;
                        }
                    }
                }
                if (this.IntegratedController)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        this.KeySpace = true;
                    }
                    if (Input.GetKeyUp(KeyCode.Space))
                    {
                        this.KeySpace = false;
                    }
                    if (Input.GetKeyDown(KeyCode.LeftShift))
                    {
                        this.KeyShift = true;
                    }
                    if (Input.GetKeyUp(KeyCode.LeftShift))
                    {
                        this.KeyShift = false;
                    }
                    if (Input.GetKeyDown(KeyCode.LeftControl))
                    {
                        this.KeyCtrl = true;
                    }
                    if (Input.GetKeyUp(KeyCode.LeftControl))
                    {
                        this.KeyCtrl = false;
                    }
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        this.KeyLM = true;
                    }
                    if (Input.GetKeyUp(KeyCode.Mouse0))
                    {
                        this.KeyLM = false;
                    }
                    if (Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        this.KeyRM = true;
                    }
                    if (Input.GetKeyUp(KeyCode.Mouse1))
                    {
                        this.KeyRM = false;
                    }
                    if (Input.GetKeyDown("w"))
                    {
                        this.KeyW = true;
                    }
                    if (Input.GetKeyUp("w"))
                    {
                        this.KeyW = false;
                    }
                    if (Input.GetKeyDown("a"))
                    {
                        this.KeyA = true;
                    }
                    if (Input.GetKeyUp("a"))
                    {
                        this.KeyA = false;
                    }
                    if (Input.GetKeyDown("s"))
                    {
                        this.KeyS = true;
                    }
                    if (Input.GetKeyUp("s"))
                    {
                        this.KeyS = false;
                    }
                    if (Input.GetKeyDown("d"))
                    {
                        this.KeyD = true;
                    }
                    if (Input.GetKeyUp("d"))
                    {
                        this.KeyD = false;
                    }
                    if (Input.GetKeyDown("z"))
                    {
                        this.KeyZ = true;
                    }
                    if (Input.GetKeyUp("z"))
                    {
                        this.KeyZ = false;
                    }
                    if (Input.GetKeyDown("x"))
                    {
                        this.KeyX = true;
                    }
                    if (Input.GetKeyUp("x"))
                    {
                        this.KeyX = false;
                    }
                }
            }
        }
        else
        {
            if (this.EngineOn)
            {
                if (!CameraScript.InInterface)
                {
                    if (this.canVS)
                    {
                        if (Input.GetKeyDown("v"))
                        {
                            if (this.Hover1 != null)
                            {
                                this.Hover1.hBool();
                            }
                            if (this.Hover2 != null)
                            {
                                this.Hover2.hBool();
                            }
                            if (this.Hover3 != null)
                            {
                                this.Hover3.hBool();
                            }
                            if (this.Hover4 != null)
                            {
                                this.Hover4.hBool();
                            }
                            if (this.Hover5 != null)
                            {
                                this.Hover5.hBool();
                            }
                            if (this.Hover6 != null)
                            {
                                this.Hover6.hBool();
                            }
                            if (!this.VSmode)
                            {
                                this.VSmode = true;
                            }
                            else
                            {
                                this.VSmode = false;
                            }
                        }
                    }
                    if (this.IntegratedController)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            this.KeySpace = true;
                        }
                        if (Input.GetKeyUp(KeyCode.Space))
                        {
                            this.KeySpace = false;
                        }
                        if (Input.GetKeyDown(KeyCode.LeftShift))
                        {
                            this.KeyShift = true;
                        }
                        if (Input.GetKeyUp(KeyCode.LeftShift))
                        {
                            this.KeyShift = false;
                        }
                        if (Input.GetKeyDown(KeyCode.LeftControl))
                        {
                            this.KeyCtrl = true;
                        }
                        if (Input.GetKeyUp(KeyCode.LeftControl))
                        {
                            this.KeyCtrl = false;
                        }
                        if (Input.GetKeyDown(KeyCode.Mouse0))
                        {
                            this.KeyLM = true;
                        }
                        if (Input.GetKeyUp(KeyCode.Mouse0))
                        {
                            this.KeyLM = false;
                        }
                        if (Input.GetKeyDown(KeyCode.Mouse1))
                        {
                            this.KeyRM = true;
                        }
                        if (Input.GetKeyUp(KeyCode.Mouse1))
                        {
                            this.KeyRM = false;
                        }
                        if (Input.GetKeyDown("w"))
                        {
                            this.KeyW = true;
                        }
                        if (Input.GetKeyUp("w"))
                        {
                            this.KeyW = false;
                        }
                        if (Input.GetKeyDown("a"))
                        {
                            this.KeyA = true;
                        }
                        if (Input.GetKeyUp("a"))
                        {
                            this.KeyA = false;
                        }
                        if (Input.GetKeyDown("s"))
                        {
                            this.KeyS = true;
                        }
                        if (Input.GetKeyUp("s"))
                        {
                            this.KeyS = false;
                        }
                        if (Input.GetKeyDown("d"))
                        {
                            this.KeyD = true;
                        }
                        if (Input.GetKeyUp("d"))
                        {
                            this.KeyD = false;
                        }
                        if (Input.GetKeyDown("z"))
                        {
                            this.KeyZ = true;
                        }
                        if (Input.GetKeyUp("z"))
                        {
                            this.KeyZ = false;
                        }
                        if (Input.GetKeyDown("x"))
                        {
                            this.KeyX = true;
                        }
                        if (Input.GetKeyUp("x"))
                        {
                            this.KeyX = false;
                        }
                    }
                }
            }
            else
            {
                IndicatorScript.ParkingBrakeOn = false;
            }
        }
        if (this.CanBoost)
        {
            if (!this.Boosting)
            {
                if (this.BoostSound.GetComponent<AudioSource>().volume > 0)
                {
                    this.BoostSound.GetComponent<AudioSource>().volume = this.BoostSound.GetComponent<AudioSource>().volume - 0.1f;
                }
                if (this.BoostSound.GetComponent<AudioSource>().volume == 0)
                {
                    this.BoostSound.GetComponent<AudioSource>().Stop();
                }
            }
            if (this.EngineOn)
            {
                if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.B)) || (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.B)))
                {
                    if (!this.Boosting && !this.bRegen)
                    {
                        this.Boosting = true;
                        this.BoostSound.GetComponent<AudioSource>().Play();
                        this.BoostSound.GetComponent<AudioSource>().volume = 1;
                        float Force = this.BooostForce;
                        if (this.WingPivScriptR)
                        {
                            this.WingPivScriptR.ForwardPivotAngle = this.PivAngBoost;
                        }
                        if (this.WingPivScriptL)
                        {
                            this.WingPivScriptL.ForwardPivotAngle = -this.PivAngBoost;
                        }
                        if (this.rBoostThrusterFX1)
                        {
                            this.rBoostThrusterFX1.enableEmission = true;
                        }
                        if (this.lBoostThrusterFX1)
                        {
                            this.lBoostThrusterFX1.enableEmission = true;
                        }
                        if (this.rBoostThrusterFX2)
                        {
                            this.rBoostThrusterFX2.enableEmission = true;
                        }
                        if (this.lBoostThrusterFX2)
                        {
                            this.lBoostThrusterFX2.enableEmission = true;
                        }
                    }
                }
                if (((!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.B)) && !Input.GetKey(KeyCode.S)) && !Input.GetKey(KeyCode.B))
                {
                    if (this.Boosting)
                    {
                        this.Boosting = false;
                        float Force = this.DirForce;
                        if (this.WingPivScriptR)
                        {
                            this.WingPivScriptR.ForwardPivotAngle = this.PivAng;
                        }
                        if (this.WingPivScriptL)
                        {
                            this.WingPivScriptL.ForwardPivotAngle = -this.PivAng;
                        }
                        if (this.rBoostThrusterFX1)
                        {
                            this.rBoostThrusterFX1.enableEmission = false;
                        }
                        if (this.lBoostThrusterFX1)
                        {
                            this.lBoostThrusterFX1.enableEmission = false;
                        }
                        if (this.rBoostThrusterFX2)
                        {
                            this.rBoostThrusterFX2.enableEmission = false;
                        }
                        if (this.lBoostThrusterFX2)
                        {
                            this.lBoostThrusterFX2.enableEmission = false;
                        }
                    }
                }
            }
        }
    }

    public virtual IEnumerator EngineEffectsOn()
    {
        yield return new WaitForSeconds(this.EngineOnFXDelay);
        this.EngineRunning = true;
        if (this.Thruster)
        {
            this.Thruster.SetActive(true);
        }
        if (this.Gyro)
        {
            this.Gyro.Deactivated = false;
        }
        if (this.CanAntiGravity)
        {
            this.GetComponent<Rigidbody>().useGravity = false;
            if (this.AngDragObject)
            {
                this.AngDragObject.useGravity = false;
            }
        }
        if (this.CanAngularDrag)
        {
            if (this.AngDragObject)
            {
                this.AngDragObject.angularDrag = this.AngularDragOn;
            }
        }
        if (this.CanDrag)
        {
            this.GetComponent<Rigidbody>().drag = this.DragOn;
        }
        if (this.EngineFX1)
        {
            this.EngineFX1.GetComponent<ParticleSystem>().enableEmission = true;
        }
        if (this.EngineFX2)
        {
            this.EngineFX2.GetComponent<ParticleSystem>().enableEmission = true;
        }
        if (this.EngineFX3)
        {
            this.EngineFX3.GetComponent<ParticleSystem>().enableEmission = true;
        }
        if (this.EngineFX4)
        {
            this.EngineFX4.GetComponent<ParticleSystem>().enableEmission = true;
        }
        if (this.EngineFX5)
        {
            this.EngineFX5.GetComponent<ParticleSystem>().enableEmission = true;
        }
        if (this.EngineFX6)
        {
            this.EngineFX6.GetComponent<ParticleSystem>().enableEmission = true;
        }
        if (this.EngineFX7)
        {
            this.EngineFX7.GetComponent<ParticleSystem>().enableEmission = true;
        }
        if (this.EngineFX8)
        {
            this.EngineFX8.GetComponent<ParticleSystem>().enableEmission = true;
        }
        if (this.EngineFX9)
        {
            this.EngineFX9.GetComponent<ParticleSystem>().enableEmission = true;
        }
        if (this.EngineFX10)
        {
            this.EngineFX10.GetComponent<ParticleSystem>().enableEmission = true;
        }
        if (this.EngineFX11)
        {
            this.EngineFX11.GetComponent<ParticleSystem>().enableEmission = true;
        }
        if (this.EngineFX12)
        {
            this.EngineFX12.GetComponent<ParticleSystem>().enableEmission = true;
        }
        if (this.EngineFX13)
        {
            this.EngineFX13.GetComponent<ParticleSystem>().enableEmission = true;
        }
        if (this.EngineFX14)
        {
            this.EngineFX14.GetComponent<ParticleSystem>().enableEmission = true;
        }
        if (this.EngineFX15)
        {
            this.EngineFX15.GetComponent<ParticleSystem>().enableEmission = true;
        }
        if (this.EngineFX16)
        {
            this.EngineFX16.GetComponent<ParticleSystem>().enableEmission = true;
        }
        if (this.EngineFX17)
        {
            this.EngineFX17.GetComponent<ParticleSystem>().enableEmission = true;
        }
        if (this.EngineFX18)
        {
            this.EngineFX18.GetComponent<ParticleSystem>().enableEmission = true;
        }
        if (this.EngineLFX)
        {
            this.EngineLFX.SetActive(true);
        }
    }

    public virtual IEnumerator EngineEffectsOff()
    {
        yield return new WaitForSeconds(this.EngineOffFXDelay);
        this.EngineRunning = false;
        if (this.Thruster)
        {
            this.Thruster.SetActive(false);
        }
        if (this.Gyro)
        {
            this.Gyro.Deactivated = true;
        }
        if (this.CanAntiGravity)
        {
            this.GetComponent<Rigidbody>().useGravity = true;
            if (this.AngDragObject)
            {
                this.AngDragObject.useGravity = true;
            }
        }
        if (this.CanAngularDrag)
        {
            if (this.AngDragObject)
            {
                this.AngDragObject.angularDrag = this.AngularDragOff;
            }
        }
        if (this.CanDrag)
        {
            this.GetComponent<Rigidbody>().drag = this.DragOff;
        }
        if (this.EngineFX1)
        {
            this.EngineFX1.GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (this.EngineFX2)
        {
            this.EngineFX2.GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (this.EngineFX3)
        {
            this.EngineFX3.GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (this.EngineFX4)
        {
            this.EngineFX4.GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (this.EngineFX5)
        {
            this.EngineFX5.GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (this.EngineFX6)
        {
            this.EngineFX6.GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (this.EngineFX7)
        {
            this.EngineFX7.GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (this.EngineFX8)
        {
            this.EngineFX8.GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (this.EngineFX9)
        {
            this.EngineFX9.GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (this.EngineFX10)
        {
            this.EngineFX10.GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (this.EngineFX11)
        {
            this.EngineFX11.GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (this.EngineFX12)
        {
            this.EngineFX12.GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (this.EngineFX13)
        {
            this.EngineFX13.GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (this.EngineFX14)
        {
            this.EngineFX14.GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (this.EngineFX15)
        {
            this.EngineFX15.GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (this.EngineFX16)
        {
            this.EngineFX16.GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (this.EngineFX17)
        {
            this.EngineFX17.GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (this.EngineFX18)
        {
            this.EngineFX18.GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (this.EngineLFX)
        {
            this.EngineLFX.SetActive(false);
        }
    }

    public virtual IEnumerator RefreshFX()
    {
        if (this.EngineFXGO)
        {
            this.EngineFXGO.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            this.EngineFXGO.SetActive(true);
        }
    }

    public virtual IEnumerator JamReset()
    {
        yield return new WaitForSeconds(0.3f);
        this.CanJam = true;
    }

    public virtual void ActivateSight()
    {
        if ((WorldInformation.playerCar == this.gameObject.name) && Input.GetMouseButton(1))
        {
            this.VehicleSight.SetActive(true);
        }
        else
        {
            this.VehicleSight.SetActive(false);
        }
    }

    public virtual void Update2()
    {
        if (WorldInformation.playerCar == this.gameObject.name)
        {
            IndicatorScript.IsInsideVehicle = true;
        }
        else
        {
            IndicatorScript.IsInsideVehicle = false;
        }
    }

    public virtual void BoostTicker()
    {
        if (this.EnergyIndicator)
        {
            if (this.Boosting)
            {

                {
                    float _2324 = this.EnergyIndicator.startColor.a - this.BoostDemand;
                    Color _2325 = this.EnergyIndicator.startColor;
                    _2325.a = _2324;
                    this.EnergyIndicator.startColor = _2325;
                }
                if (this.EnergyIndicator.startColor.a == 0)
                {
                    this.Boosting = false;
                    this.bRegen = true;
                    float Force = this.DirForce;
                    if (this.WingPivScriptR)
                    {
                        this.WingPivScriptR.ForwardPivotAngle = this.PivAng;
                    }
                    if (this.WingPivScriptL)
                    {
                        this.WingPivScriptL.ForwardPivotAngle = -this.PivAng;
                    }
                    if (this.rBoostThrusterFX1)
                    {
                        this.rBoostThrusterFX1.enableEmission = false;
                    }
                    if (this.lBoostThrusterFX1)
                    {
                        this.lBoostThrusterFX1.enableEmission = false;
                    }
                    if (this.rBoostThrusterFX2)
                    {
                        this.rBoostThrusterFX2.enableEmission = false;
                    }
                    if (this.lBoostThrusterFX2)
                    {
                        this.lBoostThrusterFX2.enableEmission = false;
                    }
                }
            }
            else
            {
                if (!this.Broken)
                {
                    if (this.EnergyIndicator.startColor.a < 1)
                    {

                        {
                            float _2326 = this.EnergyIndicator.startColor.a + this.BoostRegen;
                            Color _2327 = this.EnergyIndicator.startColor;
                            _2327.a = _2326;
                            this.EnergyIndicator.startColor = _2327;
                        }
                        if (this.EnergyIndicator.startColor.a > 0.2f)
                        {
                            this.bRegen = false;
                        }
                    }
                }
                else
                {

                    {
                        float _2328 = this.EnergyIndicator.startColor.a - this.BoostDemand;
                        Color _2329 = this.EnergyIndicator.startColor;
                        _2329.a = _2328;
                        this.EnergyIndicator.startColor = _2329;
                    }
                }
            }
        }
    }

    public virtual void CheckWheels()
    {
        if (this.breaksOn == true)
        {
            this.breaksOn = false;
            if (this.WheelController1 != null)
            {
                ((WheelMotorController) this.WheelController1.GetComponent(typeof(WheelMotorController))).breaksOn = false;
            }
            if (this.WheelController2 != null)
            {
                ((WheelMotorController) this.WheelController2.GetComponent(typeof(WheelMotorController))).breaksOn = false;
            }
            if (this.WheelController3 != null)
            {
                ((WheelMotorController) this.WheelController3.GetComponent(typeof(WheelMotorController))).breaksOn = false;
            }
            if (this.WheelController4 != null)
            {
                ((WheelMotorController) this.WheelController4.GetComponent(typeof(WheelMotorController))).breaksOn = false;
            }
            if (this.WheelController5 != null)
            {
                ((WheelMotorController) this.WheelController5.GetComponent(typeof(WheelMotorController))).breaksOn = false;
            }
            if (this.WheelController6 != null)
            {
                ((WheelMotorController) this.WheelController6.GetComponent(typeof(WheelMotorController))).breaksOn = false;
            }
            if (this.Anchor1 != null)
            {
                ((PistonAnchorBreak) this.Anchor1.GetComponent(typeof(PistonAnchorBreak))).breaksOn = false;
            }
            if (this.Anchor2 != null)
            {
                ((PistonAnchorBreak) this.Anchor2.GetComponent(typeof(PistonAnchorBreak))).breaksOn = false;
            }
            if (this.Hover1 != null)
            {
                this.Hover1.breaksOn = false;
            }
            if (this.Hover2 != null)
            {
                this.Hover2.breaksOn = false;
            }
            if (this.Hover3 != null)
            {
                this.Hover3.breaksOn = false;
            }
            if (this.Hover4 != null)
            {
                this.Hover4.breaksOn = false;
            }
            if (this.Hover5 != null)
            {
                this.Hover5.breaksOn = false;
            }
            if (this.Hover6 != null)
            {
                this.Hover6.breaksOn = false;
            }
            if (this.Leg1 != null)
            {
                this.Leg1.breaksOn = false;
            }
            if (this.Leg2 != null)
            {
                this.Leg2.breaksOn = false;
            }
            if (this.Leg3 != null)
            {
                this.Leg3.breaksOn = false;
            }
            if (this.Wing1 != null)
            {
                this.Wing1.Broken = false;
            }
            if (this.RB1)
            {
                this.RB1.angularDrag = this.RB1D;
            }
            if (this.RB2)
            {
                this.RB2.angularDrag = this.RB2D;
            }
        }
        else
        {
            this.breaksOn = true;
            if (this.WheelController1 != null)
            {
                ((WheelMotorController) this.WheelController1.GetComponent(typeof(WheelMotorController))).breaksOn = true;
            }
            if (this.WheelController2 != null)
            {
                ((WheelMotorController) this.WheelController2.GetComponent(typeof(WheelMotorController))).breaksOn = true;
            }
            if (this.WheelController3 != null)
            {
                ((WheelMotorController) this.WheelController3.GetComponent(typeof(WheelMotorController))).breaksOn = true;
            }
            if (this.WheelController4 != null)
            {
                ((WheelMotorController) this.WheelController4.GetComponent(typeof(WheelMotorController))).breaksOn = true;
            }
            if (this.WheelController5 != null)
            {
                ((WheelMotorController) this.WheelController5.GetComponent(typeof(WheelMotorController))).breaksOn = true;
            }
            if (this.WheelController6 != null)
            {
                ((WheelMotorController) this.WheelController6.GetComponent(typeof(WheelMotorController))).breaksOn = true;
            }
            if (this.Anchor1 != null)
            {
                ((PistonAnchorBreak) this.Anchor1.GetComponent(typeof(PistonAnchorBreak))).breaksOn = true;
            }
            if (this.Anchor2 != null)
            {
                ((PistonAnchorBreak) this.Anchor2.GetComponent(typeof(PistonAnchorBreak))).breaksOn = true;
            }
            if (this.Hover1 != null)
            {
                this.Hover1.breaksOn = true;
            }
            if (this.Hover2 != null)
            {
                this.Hover2.breaksOn = true;
            }
            if (this.Hover3 != null)
            {
                this.Hover3.breaksOn = true;
            }
            if (this.Hover4 != null)
            {
                this.Hover4.breaksOn = true;
            }
            if (this.Hover5 != null)
            {
                this.Hover5.breaksOn = true;
            }
            if (this.Hover6 != null)
            {
                this.Hover6.breaksOn = true;
            }
            if (this.Leg1 != null)
            {
                this.Leg1.breaksOn = true;
            }
            if (this.Leg2 != null)
            {
                this.Leg2.breaksOn = true;
            }
            if (this.Leg3 != null)
            {
                this.Leg3.breaksOn = true;
            }
            if (this.Wing1 != null)
            {
                this.Wing1.Broken = true;
            }
            if (this.RB1)
            {
                this.RB1.angularDrag = 0.1f;
            }
            if (this.RB2)
            {
                this.RB2.angularDrag = 0.1f;
            }
        }
    }

    public virtual void SetState(bool _broken)
    {
        this.Broken = _broken;
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("SvibraCloud"))
        {
            if (this.SvibraEnveloped < 2000)
            {
                this.SvibraEnveloped = this.SvibraEnveloped + 200;
            }
        }
    }

    public virtual void Counter()
    {
        this.GetComponent<Rigidbody>().centerOfMass = new Vector3(this.COMx, this.COMy, this.COMz);
        if (WorldInformation.instance.AreaSpace)
        {
            this.GetComponent<Rigidbody>().drag = 0;
        }
        if (this.HasGarage)
        {
            WorldInformation.Garage = this.GaragePoint;
            if (WorldInformation.InGarage)
            {
                this.GarageLight.SetActive(true);
            }
            if (!WorldInformation.InGarage)
            {
                this.GarageLight.SetActive(false);
            }
        }
        else
        {
            if (WorldInformation.Garage)
            {
                if (WorldInformation.NearGarage)
                {
                    if (Vector3.Distance(this.transform.position, WorldInformation.Garage.position) < 10)
                    {
                        PlayerPrefs.SetString("GaragedID", this.ThisVehiclesID);
                        PlayerPrefs.SetFloat("GaragedDist", this.SpawnDist);
                        PlayerPrefs.Save();
                        WorldInformation.InGarage = true;
                    }
                }
            }
            if (WorldInformation.GarageF1)
            {
                if (WorldInformation.NearGarageF1)
                {
                    if (Vector3.Distance(this.transform.position, WorldInformation.GarageF1.position) < 64)
                    {
                        PlayerPrefs.SetString("GaragedIDF1", this.ThisVehiclesID);
                        PlayerPrefs.SetFloat("GaragedDistF1", this.SpawnDist);
                        PlayerPrefs.Save();
                        WorldInformation.InGarageF1 = true;
                        this.ParentVS.Garaged = true;
                        this.ParentVS.Garage = WorldInformation.GarageF1;
                    }
                }
            }
            if (WorldInformation.GarageF2)
            {
                if (WorldInformation.NearGarageF2)
                {
                    if (Vector3.Distance(this.transform.position, WorldInformation.GarageF2.position) < 64)
                    {
                        PlayerPrefs.SetString("GaragedIDF2", this.ThisVehiclesID);
                        PlayerPrefs.SetFloat("GaragedDistF2", this.SpawnDist);
                        PlayerPrefs.Save();
                        WorldInformation.InGarageF2 = true;
                        this.ParentVS.Garaged = true;
                        this.ParentVS.Garage = WorldInformation.GarageF2;
                    }
                }
            }
        }
        if (!this.Broken)
        {
            if (this.Inside)
            {
                if (this.Civmode)
                {
                    IndicatorScript.CivilmodeOn = true;
                }
                else
                {
                    IndicatorScript.CivilmodeOn = false;
                }
                if (this.VSmode)
                {
                    IndicatorScript.VSmodeOn = true;
                }
                else
                {
                    IndicatorScript.VSmodeOn = false;
                }
                if (this.breaksOn)
                {
                    IndicatorScript.ParkingBrakeOn = true;
                }
                else
                {
                    IndicatorScript.ParkingBrakeOn = false;
                }
                if (this.canVS)
                {
                    if (this.Hover1 != null)
                    {
                        this.Hover1.inside = true;
                    }
                    if (this.Hover2 != null)
                    {
                        this.Hover2.inside = true;
                    }
                    if (this.Hover3 != null)
                    {
                        this.Hover3.inside = true;
                    }
                    if (this.Hover4 != null)
                    {
                        this.Hover4.inside = true;
                    }
                    if (this.Hover5 != null)
                    {
                        this.Hover5.inside = true;
                    }
                    if (this.Hover6 != null)
                    {
                        this.Hover6.inside = true;
                    }
                }
                DrivenVesselScript.WhereToSpawnPos = this.ParentVS.gameObject.transform.position;
                DrivenVesselScript.WhereToSpawnRot = this.ParentVS.gameObject.transform.rotation;
                DrivenVesselScript.LastScene = Application.loadedLevelName;
                DrivenVesselScript.WhatToSpawn = this.ParentVS.prefab_name;
                DrivenVesselScript.VesselTravelSpeed = this.TravelSpeed;
                DrivenVesselScript.VesselSpawnDist = this.SpawnDist;
                DrivenVesselScript.isWarpVessel = this.WarpVessel;
                DrivenVesselScript.isSpaceVessel = this.SpaceVessel;
                WorldInformation.UsingBrightVessel = this.BrightVessel;
                WorldInformation.playerLevel = this.vehicleLevel;
                if (this.ThisVehiclesTC == "null")
                {
                    if (this.vehicleLevel == 1)
                    {
                        TCChanger.TCName = "sTC1p";
                    }
                    if (this.vehicleLevel == 2)
                    {
                        TCChanger.TCName = "mTC1p";
                    }
                    if (this.vehicleLevel == 3)
                    {
                        TCChanger.TCName = "bTC1p";
                    }
                    if (this.vehicleLevel == 4)
                    {
                        TCChanger.TCName = "xbTC1p";
                    }
                }
                else
                {
                    TCChanger.TCName = this.ThisVehiclesTC;
                }
            }
            else
            {
                if (this.canVS)
                {
                    if (this.Hover1 != null)
                    {
                        this.Hover1.inside = false;
                    }
                    if (this.Hover2 != null)
                    {
                        this.Hover2.inside = false;
                    }
                    if (this.Hover3 != null)
                    {
                        this.Hover3.inside = false;
                    }
                    if (this.Hover4 != null)
                    {
                        this.Hover4.inside = false;
                    }
                    if (this.Hover5 != null)
                    {
                        this.Hover5.inside = false;
                    }
                    if (this.Hover6 != null)
                    {
                        this.Hover6.inside = false;
                    }
                }
            }
            if (WorldInformation.IsNopass == false)
            {
                if (this.GetComponent<Rigidbody>().mass > 1000)
                {
                    this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    this.AngDragObject.angularDrag = this.AngDrag;
                }
            }
        }
        else
        {
            if (this.Inside)
            {
                IndicatorScript.CivilmodeOn = false;
                IndicatorScript.VSmodeOn = false;
                IndicatorScript.VehicleIsDamaged = true;
                TCChanger.TCName = "broken";
            }
        }
    }

    public MainVehicleController()
    {
        this.TravelSpeed = 40;
        this.SpawnDist = 1.5f;
        this.ThisVehiclesID = "Null";
        this.ThisVehiclesTC = "null";
        this.RB1D = 1;
        this.RB2D = 1;
        this.HoverJointMax = -1;
        this.HoverVarSpeed = 0.01f;
        this.NPOffset = 2;
        this.NPForce = 2;
        this.EngineAudioVol = 1f;
        this.EngineVolFadeSpeed = 0.05f;
        this.RotorRotSpeed = 60;
        this.BoostDemand = 0.01f;
        this.BoostRegen = 0.01f;
        this.forceCurve = new AnimationCurve();
        this.bForceCurve = new AnimationCurve();
        this.DirForce = 1;
        this.DirRevForce = 1;
        this.TiltForce = 1;
        this.AngForce = 1;
        this.PitchForce = 1;
        this.AscendForce = 5;
        this.DescendForce = 5;
        this.AngularDragOn = 2;
        this.AngularDragOff = 0.2f;
        this.DragOn = 2;
        this.DragOff = 0.05f;
        this.AtmosphericDrag = 0.05f;
        this.AngDrag = 0.05f;
    }

}