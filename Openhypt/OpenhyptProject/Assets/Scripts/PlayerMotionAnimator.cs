using UnityEngine;
using System.Collections;

public enum pState
{
    Idling = 0,
    WalkForward = 1,
    Sprinting = 2
}

public enum eState
{
    Idle = 0,
    Idle2 = 1,
    Idle3 = 2
}

[System.Serializable]
public partial class PlayerMotionAnimator : MonoBehaviour
{
    public GameObject Faceplant;
    public GameObject HurtNoise;
    public Transform FaceplantArea;
    public Transform KickArea;
    public GameObject KickPrefab;
    public GameObject KickSoundPrefab;
    public Transform CarryPointTF;
    public Transform RayPointTF;
    public Transform thisLevelTransform;
    public Transform steppypoint;
    public Transform thisTransform;
    public Rigidbody thisRigidbody;
    public CapsuleCollider PiriCapCol;
    public BoxCollider PiriBoxCol;
    public Transform pivotTF;
    public Rigidbody pivotRB;
    public HingeJoint pivotHinge;
    public HingeJoint PiriWheel;
    public Rigidbody PiriWheelRB;
    public SphereCollider PiriWheelCol;
    public float RotForce;
    public FixedJoint BrakeJoint;
    public ConfigurableJoint CarryJoint;
    public Animation PiriAni;
    public Transform PiriBaseTF;
    public Transform PiriHeadTF;
    public GameObject Pirizuka;
    public GameObject PiriUBC;
    public GameObject RBosom;
    public GameObject LBosom;
    public ConfigurableJoint RBosomCJ;
    public ConfigurableJoint LBosomCJ;
    public float maxAnimationSpeed;
    public float backwardSpeed;
    public float forwardSpeed;
    public float sprintSpeed;
    public string Idling;
    public string Idling2;
    public string Holding;
    public string forward;
    public string HoldingW;
    public string sprint;
    public string falling;
    public string floating;
    public string floatingF;
    public string HoldingOn;
    public string swimming;
    public string jump;
    public string land;
    public string kick;
    public string GunWalk;
    public string GunStrafe;
    public string GunStill;
    public string RidingMotus;
    public string RidingCepstol;
    private GameObject targetRigidbody;
    public static PlayerMotionAnimator instance;
    public bool inInterface;
    public pState state;
    public eState aState;
    public float Count;
    private Vector3 relative;
    public static float lastVelocity;
    public float acceleration;
    public float Gs;
    public bool Performing;
    public static bool CanCollide;
    public bool CanIdle;
    public bool HasJiggled;
    public bool PiriFloating;
    public bool CloseToGround;
    public float GroundClearance;
    public static bool Landing;
    public static bool PiriStill;
    public bool PiriGrounded;
    public bool CanMove;
    public bool CanFPAnimationaise;
    public static bool UsingMotus;
    public static bool Transit;
    public float JumpForce;
    public float StabilizeForce;
    public float TStabilizeForce;
    public int AngDrag;
    public Transform TC;
    public GameObject AimTarget;
    public GameObject AimSideTarget;
    public bool AimingForward;
    public bool AimingLeft;
    public bool AimingRight;
    public bool AimingBack;
    public bool keyW;
    public bool keyA;
    public bool keyS;
    public bool keyD;
    public bool InWater;
    public bool OnGround;
    public bool onMovingGround;
    public Rigidbody groundRigidbody;
    public bool Moving;
    public bool Jumping;
    public bool Carrying;
    public bool HeavyCarry;
    public bool once;
    public LayerMask targetLayers;
    public LayerMask WtargetLayers;
    public LayerMask CtargetLayers;
    public virtual void Awake()
    {
        PlayerMotionAnimator.instance = this;
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 1, 0.2f);
        this.InvokeRepeating("Counter", 0.33f, 0.5f);
        this.AimTarget = GameObject.Find("PiriAimFront").gameObject;
        this.AimSideTarget = GameObject.Find("PiriAimSide").gameObject;
        PlayerMotionAnimator.lastVelocity = 0;
        this.GroundClearance = 2;
        this.targetRigidbody = this.thisTransform.gameObject;
        PlayerMotionAnimator.PiriStill = false;
        PlayerMotionAnimator.Landing = false;
        WorldInformation.UsingVessel = false;
        this.CanMove = true;
        this.CanFPAnimationaise = false;
        if (WorldInformation.isWearingBackpack)
        {
            GameObject Prefabionaise0 = ((GameObject) Resources.Load("Objects/" + WorldInformation.whatBackpack, typeof(GameObject))) as GameObject;
            GameObject TheThing0 = UnityEngine.Object.Instantiate(Prefabionaise0, PlayerInformation.instance.BackpackPoint.position, PlayerInformation.instance.BackpackPoint.rotation);
            TheThing0.name = WorldInformation.whatBackpack;
            ((BackpackScript) TheThing0.transform.GetComponent(typeof(BackpackScript))).GetWorn();
        }
    }

    public virtual IEnumerator Timer()
    {
        this.GroundClearance = 0.5f;
        yield return new WaitForSeconds(1);
        this.Jumping = false;
        this.GroundClearance = 2;
    }

    public virtual IEnumerator Timer2()
    {
        yield return new WaitForSeconds(0.8f);
        PlayerMotionAnimator.Landing = false;
        this.PiriAni.CrossFade(this.Idling, 0.5f);
    }

    public virtual IEnumerator Timer3()
    {

        {
            int _2750 = 2;
            JointSpring _2751 = this.PiriWheel.spring;
            _2751.damper = _2750;
            this.PiriWheel.spring = _2751;
        }
        this.thisRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        yield return new WaitForSeconds(3.3f);
        if (((this.keyW || this.keyA) || this.keyS) || this.keyD)
        {
            this.CanMove = true;
            this.CanFPAnimationaise = false;
            this.thisRigidbody.constraints = RigidbodyConstraints.None;
        }
        yield return new WaitForSeconds(0.5f);
        this.CanMove = true;
        this.CanFPAnimationaise = false;
        this.thisRigidbody.constraints = RigidbodyConstraints.None;
    }

    public virtual IEnumerator Timer4()
    {
        RaycastHit hit = default(RaycastHit);
        GameObject TheThing = UnityEngine.Object.Instantiate(this.KickSoundPrefab, this.thisTransform.position, this.thisTransform.rotation);
        TheThing.transform.parent = this.thisTransform;
        yield return new WaitForSeconds(0.4f);
        if (Physics.Raycast(this.KickArea.transform.position + (-this.KickArea.transform.forward * 0.5f), this.KickArea.transform.forward, out hit, 1.2f, (int) this.targetLayers))
        {
            GameObject TheThing2 = UnityEngine.Object.Instantiate(this.KickPrefab, this.KickArea.transform.position, this.KickArea.transform.rotation);
            TheThing2.transform.parent = this.thisTransform;
            if (hit.rigidbody)
            {
                hit.rigidbody.AddForceAtPosition(this.thisTransform.forward * 4, hit.point);
            }
        }
        yield return new WaitForSeconds(0.5f);
        this.PiriAni.CrossFade(this.Idling);
        yield return new WaitForSeconds(0.3f);
        this.CanMove = true;
    }

    public virtual void Update()
    {
        RaycastHit hitC = default(RaycastHit);
        RaycastHit hitC2 = default(RaycastHit);
        float LastCDist = 0.0f;
        float C2Dist = 0.0f;
        bool DidHit = false;
        bool BotObs = false;
        bool IsOk = false;
        if (WorldInformation.PiriIsHurt)
        {
            return;
        }
        this.inInterface = CameraScript.InInterface;
        this.keyW = false;
        this.keyA = false;
        this.keyS = false;
        this.keyD = false;
        if (!this.inInterface)
        {
            if (Input.GetKey("w"))
            {
                this.keyW = true;
            }
            if (Input.GetKey("a"))
            {
                this.keyA = true;
            }
            if (Input.GetKey("s"))
            {
                this.keyS = true;
            }
            if (Input.GetKey("d"))
            {
                this.keyD = true;
            }
        }
        if (!this.Jumping)
        {
            if (((Physics.Raycast((this.PiriBaseTF.position + (-this.PiriBaseTF.forward * 0.1f)) + (this.PiriBaseTF.up * 1), -this.PiriBaseTF.up, 1.05f, (int) this.targetLayers) || Physics.Raycast((this.PiriBaseTF.position + (this.PiriBaseTF.forward * 0.2f)) + (this.PiriBaseTF.up * 1), -this.PiriBaseTF.up, 1.05f, (int) this.targetLayers)) || Physics.Raycast((this.PiriBaseTF.position + (this.PiriBaseTF.right * 0.15f)) + (this.PiriBaseTF.up * 1), -this.PiriBaseTF.up, 1.05f, (int) this.targetLayers)) || Physics.Raycast((this.PiriBaseTF.position + (-this.PiriBaseTF.right * 0.15f)) + (this.PiriBaseTF.up * 1), -this.PiriBaseTF.up, 1.05f, (int) this.targetLayers))
            {
                this.OnGround = true;
                this.PiriGrounded = true;
            }
            else
            {
                this.OnGround = false;
                this.PiriGrounded = false;
            }
            if (Physics.Raycast(this.PiriBaseTF.position + (this.PiriBaseTF.up * 0.2f), this.PiriBaseTF.forward, 0.6f, (int) this.targetLayers) && !Physics.Raycast(this.PiriBaseTF.position + (this.PiriBaseTF.up * 1), this.PiriBaseTF.forward, 1, (int) this.targetLayers))
            {
                this.OnGround = true;
                this.PiriGrounded = true;
            }
        }
        if (Physics.Raycast(this.PiriHeadTF.position, Vector3.down, 1.5f, (int) this.WtargetLayers))
        {
            this.InWater = true;
        }
        else
        {
            this.InWater = false;
        }
        if (WorldInformation.UsingVessel)
        {
            if (!Input.GetMouseButton(1))
            {
                this.TStabilizeForce = 1;
                this.thisRigidbody.angularDrag = 1;
                if (PlayerMotionAnimator.UsingMotus)
                {
                    this.PiriAni.CrossFade(this.RidingMotus);
                }
                else
                {
                    this.PiriAni.CrossFade(this.RidingCepstol);
                }
            }
            else
            {
                this.TStabilizeForce = 1;
                this.thisRigidbody.angularDrag = 32;
                this.PiriAni.Stop();
            }
        }
        else
        {
            if (PlayerMotionAnimator.Transit)
            {
                PlayerMotionAnimator.Transit = false;
                this.PiriFloating = false;
                this.Jumping = false;
                this.PiriAni.CrossFade(this.Idling);
            }
            if (WorldInformation.FPMode)
            {
                this.AimingForward = true;
                this.thisRigidbody.drag = 0;

                {
                    int _2752 = 0;
                    Vector3 _2753 = this.pivotTF.localEulerAngles;
                    _2753.y = _2752;
                    this.pivotTF.localEulerAngles = _2753;
                }
                //pivotHinge.spring.targetPosition = 0;
                if (this.keyW)
                {
                    if (this.keyA)
                    {

                        {
                            int _2754 = -45;
                            Vector3 _2755 = this.pivotTF.localEulerAngles;
                            _2755.y = _2754;
                            this.pivotTF.localEulerAngles = _2755;
                        }
                    }
                    //pivotHinge.spring.targetPosition = -45;
                    if (this.keyD)
                    {

                        {
                            int _2756 = 45;
                            Vector3 _2757 = this.pivotTF.localEulerAngles;
                            _2757.y = _2756;
                            this.pivotTF.localEulerAngles = _2757;
                        }
                    }
                }
                else
                {
                    //pivotHinge.spring.targetPosition = 45;
                    if (this.keyS)
                    {

                        {
                            int _2758 = 180;
                            Vector3 _2759 = this.pivotTF.localEulerAngles;
                            _2759.y = _2758;
                            this.pivotTF.localEulerAngles = _2759;
                        }
                        //pivotHinge.spring.targetPosition = 180;
                        if (this.keyA)
                        {

                            {
                                int _2760 = -135;
                                Vector3 _2761 = this.pivotTF.localEulerAngles;
                                _2761.y = _2760;
                                this.pivotTF.localEulerAngles = _2761;
                            }
                        }
                        //pivotHinge.spring.targetPosition = -135;
                        if (this.keyD)
                        {

                            {
                                int _2762 = 135;
                                Vector3 _2763 = this.pivotTF.localEulerAngles;
                                _2763.y = _2762;
                                this.pivotTF.localEulerAngles = _2763;
                            }
                        }
                    }
                    else
                    {
                        //pivotHinge.spring.targetPosition = 135;
                        if (this.keyA)
                        {

                            {
                                int _2764 = -90;
                                Vector3 _2765 = this.pivotTF.localEulerAngles;
                                _2765.y = _2764;
                                this.pivotTF.localEulerAngles = _2765;
                            }
                        }
                        //pivotHinge.spring.targetPosition = -90;
                        if (this.keyD)
                        {

                            {
                                int _2766 = 90;
                                Vector3 _2767 = this.pivotTF.localEulerAngles;
                                _2767.y = _2766;
                                this.pivotTF.localEulerAngles = _2767;
                            }
                        }
                    }
                }
            }
            else
            {
                //pivotHinge.spring.targetPosition = 90;
                this.thisRigidbody.drag = 0.1f;

                {
                    int _2768 = 0;
                    Vector3 _2769 = this.pivotTF.localEulerAngles;
                    _2769.y = _2768;
                    this.pivotTF.localEulerAngles = _2769;
                }
                //pivotHinge.spring.targetPosition = 0;
                if (Input.GetMouseButton(1))
                {
                    if (this.keyW)
                    {
                        if (this.keyA)
                        {

                            {
                                int _2770 = -45;
                                Vector3 _2771 = this.pivotTF.localEulerAngles;
                                _2771.y = _2770;
                                this.pivotTF.localEulerAngles = _2771;
                            }
                        }
                        //pivotHinge.spring.targetPosition = -45;
                        if (this.keyD)
                        {

                            {
                                int _2772 = 45;
                                Vector3 _2773 = this.pivotTF.localEulerAngles;
                                _2773.y = _2772;
                                this.pivotTF.localEulerAngles = _2773;
                            }
                        }
                    }
                    else
                    {
                        //pivotHinge.spring.targetPosition = 45;
                        if (this.keyS)
                        {

                            {
                                int _2774 = 180;
                                Vector3 _2775 = this.pivotTF.localEulerAngles;
                                _2775.y = _2774;
                                this.pivotTF.localEulerAngles = _2775;
                            }
                            //pivotHinge.spring.targetPosition = 180;
                            if (this.keyA)
                            {

                                {
                                    int _2776 = -135;
                                    Vector3 _2777 = this.pivotTF.localEulerAngles;
                                    _2777.y = _2776;
                                    this.pivotTF.localEulerAngles = _2777;
                                }
                            }
                            //pivotHinge.spring.targetPosition = -135;
                            if (this.keyD)
                            {

                                {
                                    int _2778 = 135;
                                    Vector3 _2779 = this.pivotTF.localEulerAngles;
                                    _2779.y = _2778;
                                    this.pivotTF.localEulerAngles = _2779;
                                }
                            }
                        }
                        else
                        {
                            //pivotHinge.spring.targetPosition = 135;
                            if (this.keyA)
                            {

                                {
                                    int _2780 = -90;
                                    Vector3 _2781 = this.pivotTF.localEulerAngles;
                                    _2781.y = _2780;
                                    this.pivotTF.localEulerAngles = _2781;
                                }
                            }
                            //pivotHinge.spring.targetPosition = -90;
                            if (this.keyD)
                            {

                                {
                                    int _2782 = 90;
                                    Vector3 _2783 = this.pivotTF.localEulerAngles;
                                    _2783.y = _2782;
                                    this.pivotTF.localEulerAngles = _2783;
                                }
                            }
                        }
                    }
                }
            }
            //pivotHinge.spring.targetPosition = 90;
            if (!this.inInterface)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    this.AimingForward = true;
                    this.AimingBack = false;
                    this.AimingLeft = false;
                    this.AimingRight = false;
                }
                if (Input.GetMouseButtonUp(1))
                {
                    this.AimingForward = false;
                    this.AimingBack = false;
                    this.AimingLeft = false;
                    this.AimingRight = false;
                }
            }
            if ((!this.inInterface && !Input.GetMouseButton(1)) && !WorldInformation.FPMode)
            {
                if (Input.GetKeyDown("w"))
                {
                    this.TStabilizeForce = 0;
                }
                if (Input.GetKeyDown("s"))
                {
                    this.TStabilizeForce = 0;
                }
                if (Input.GetKeyDown("a"))
                {
                    this.TStabilizeForce = 0;
                }
                if (Input.GetKeyDown("d"))
                {
                    this.TStabilizeForce = 0;
                }
                if (this.keyW)
                {
                    this.AimingForward = true;
                }
                if (this.keyS)
                {
                    if (!this.Carrying)
                    {
                        this.AimingBack = true;
                    }
                    else
                    {
                        this.AimingForward = true;
                    }
                }
                if (this.keyA)
                {
                    this.AimingLeft = true;
                }
                if (this.keyD)
                {
                    this.AimingRight = true;
                }
                if (Input.GetKeyUp("w"))
                {
                    this.AimingForward = false;
                    this.TStabilizeForce = 0;
                }
                if (Input.GetKeyUp("s"))
                {
                    this.AimingBack = false;
                    this.TStabilizeForce = 0;
                }
                if (Input.GetKeyUp("a"))
                {
                    this.AimingLeft = false;
                    this.TStabilizeForce = 0;
                }
                if (Input.GetKeyUp("d"))
                {
                    this.AimingRight = false;
                    this.TStabilizeForce = 0;
                }
            }
            if (this.OnGround)
            {
                this.GroundClearance = 2;
            }
            this.thisRigidbody.angularDrag = 48;
            if (!this.CanMove)
            {
                return;
            }
            Vector3 _velocity = this.onMovingGround ? this.targetRigidbody.GetComponent<Rigidbody>().velocity - this.groundRigidbody.velocity : this.targetRigidbody.GetComponent<Rigidbody>().velocity;
            this.relative = this.thisTransform.InverseTransformDirection(_velocity) / 2;
            if (Physics.Raycast(this.PiriBaseTF.position + (this.PiriBaseTF.up * 1.8f), Vector3.down, this.GroundClearance, (int) this.targetLayers))
            {
                this.CloseToGround = true;
            }
            else
            {
                this.CloseToGround = false;
            }
            if (PlayerMotionAnimator.Landing && Input.GetMouseButton(1))
            {
                this.CanFPAnimationaise = false;
            }
            if (WorldInformation.IsNopass)
            {
                this.CanFPAnimationaise = false;
            }
            if (Input.GetKeyDown(KeyCode.Space) && !Input.GetMouseButton(1))
            {
                if (!this.inInterface)
                {
                    if (!this.InWater)
                    {
                        if (((!this.PiriFloating && this.CanMove) && this.PiriGrounded) && this.OnGround)
                        {
                            this.targetRigidbody = this.transform.gameObject;
                            this.thisRigidbody.AddForce(this.thisTransform.up * this.JumpForce);
                            this.PiriAni.Stop();
                            this.PiriAni.Play(this.jump);
                            this.onMovingGround = false;
                            this.Jumping = true;
                            this.OnGround = false;
                            this.PiriGrounded = false;
                            this.CanIdle = false;
                            this.GroundClearance = 2;
                            this.StopAllCoroutines();
                            this.StartCoroutine(this.Pauser());
                            this.StartCoroutine(this.Timer());
                        }
                    }
                    else
                    {
                        this.targetRigidbody = this.transform.gameObject;
                        this.thisRigidbody.AddForce(this.thisTransform.up * this.JumpForce);
                        this.PiriAni.Stop();
                        this.PiriAni.Play(this.jump);
                        this.onMovingGround = false;
                        this.Jumping = true;
                        this.OnGround = false;
                        this.PiriGrounded = false;
                        this.CanIdle = false;
                        this.GroundClearance = 2;
                        this.StopAllCoroutines();
                        this.StartCoroutine(this.Pauser());
                        this.StartCoroutine(this.Timer());
                    }
                    if (this.Carrying)
                    {
                        if (this.CarryJoint)
                        {
                            UnityEngine.Object.Destroy(this.CarryJoint);
                        }
                        this.Carrying = false;
                        WorldInformation.isHolding = false;
                        this.PiriCapCol.enabled = true;
                        this.PiriWheelCol.enabled = true;
                    }
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (!this.inInterface)
                {
                    if (this.Carrying)
                    {
                        if (this.CarryJoint)
                        {
                            UnityEngine.Object.Destroy(this.CarryJoint);
                        }
                        this.Carrying = false;
                        WorldInformation.isHolding = false;
                        this.PiriCapCol.enabled = true;
                        this.PiriWheelCol.enabled = true;
                        this.PiriBoxCol.center = new Vector3(0, -0.2f, 0);
                        this.PiriBoxCol.size = new Vector3(0.4f, 2.1f, 0.4f);
                        this.PiriAni.CrossFade(this.Idling);
                    }
                    else
                    {
                        if (!FurtherActionScript.IsActive)
                        {
                            if (((!Input.GetMouseButton(1) && !this.PiriFloating) && this.CanMove) && this.PiriGrounded)
                            {
                                this.CanMove = false;
                                this.PiriAni.CrossFade(this.kick);
                                this.StartCoroutine(this.Timer4());
                                return;
                            }
                        }
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (!this.Carrying)
                {
                    if (FurtherActionScript.FurtherActionLMB)
                    {
                        Rigidbody CRB = null;

                        {
                            int _2784 = 0;
                            Vector3 _2785 = this.CarryPointTF.localPosition;
                            _2785.y = _2784;
                            this.CarryPointTF.localPosition = _2785;
                        }
                        if (Physics.Raycast(this.CarryPointTF.position + (this.CarryPointTF.forward * -0.3f), this.CarryPointTF.forward, out hitC, 1, (int) this.CtargetLayers))
                        {
                            if (hitC.rigidbody)
                            {
                                if (Physics.Raycast(this.CarryPointTF.position + (this.CarryPointTF.forward * 0.7f), -this.RayPointTF.up, out hitC2, 2, (int) this.CtargetLayers))
                                {
                                    BotObs = true;
                                    CRB = hitC.rigidbody;
                                    IsOk = true;
                                }
                            }
                        }
                        if (!IsOk)
                        {
                            if (((((((((Physics.Raycast(this.RayPointTF.position + (this.RayPointTF.forward * 0.1f), this.RayPointTF.up, out hitC2, 2, (int) this.CtargetLayers) || Physics.Raycast(this.RayPointTF.position + (this.RayPointTF.forward * 0.2f), this.RayPointTF.up, out hitC2, 2, (int) this.CtargetLayers)) || Physics.Raycast(this.RayPointTF.position + (this.RayPointTF.forward * 0.3f), this.RayPointTF.up, out hitC2, 2, (int) this.CtargetLayers)) || Physics.Raycast(this.RayPointTF.position + (this.RayPointTF.forward * 0.4f), this.RayPointTF.up, out hitC2, 2, (int) this.CtargetLayers)) || Physics.Raycast(this.RayPointTF.position + (this.RayPointTF.forward * 0.5f), this.RayPointTF.up, out hitC2, 2, (int) this.CtargetLayers)) || Physics.Raycast(this.RayPointTF.position + (this.RayPointTF.forward * 0.6f), this.RayPointTF.up, out hitC2, 2, (int) this.CtargetLayers)) || Physics.Raycast(this.RayPointTF.position + (this.RayPointTF.forward * 0.7f), this.RayPointTF.up, out hitC2, 2, (int) this.CtargetLayers)) || Physics.Raycast(this.RayPointTF.position + (this.RayPointTF.forward * 0.8f), this.RayPointTF.up, out hitC2, 2, (int) this.CtargetLayers)) || Physics.Raycast(this.RayPointTF.position + (this.RayPointTF.forward * 0.9f), this.RayPointTF.up, out hitC2, 2, (int) this.CtargetLayers)) || Physics.Raycast(this.RayPointTF.position + (this.RayPointTF.forward * 1), this.RayPointTF.up, out hitC2, 2, (int) this.CtargetLayers))
                            {
                                if (hitC2.rigidbody)
                                {
                                    C2Dist = hitC2.distance;

                                    {
                                        float _2786 = this.RayPointTF.localPosition.y;
                                        Vector3 _2787 = this.CarryPointTF.localPosition;
                                        _2787.y = _2786;
                                        this.CarryPointTF.localPosition = _2787;
                                    }

                                    {
                                        float _2788 = this.CarryPointTF.localPosition.y + C2Dist;
                                        Vector3 _2789 = this.CarryPointTF.localPosition;
                                        _2789.y = _2788;
                                        this.CarryPointTF.localPosition = _2789;
                                    }
                                }
                            }
                        }
                        if (!IsOk)
                        {
                            if (Physics.Raycast(this.CarryPointTF.position + (this.CarryPointTF.forward * -0.3f), this.CarryPointTF.forward, out hitC, 1, (int) this.CtargetLayers))
                            {
                                if (hitC.rigidbody)
                                {
                                    LastCDist = hitC.distance;

                                    {
                                        float _2790 = this.CarryPointTF.localPosition.y + 0.1f;
                                        Vector3 _2791 = this.CarryPointTF.localPosition;
                                        _2791.y = _2790;
                                        this.CarryPointTF.localPosition = _2791;
                                    }
                                    CRB = hitC.rigidbody;
                                    DidHit = true;
                                }
                            }
                            if (Physics.Raycast(this.CarryPointTF.position + (this.CarryPointTF.forward * -0.3f), this.CarryPointTF.forward, out hitC, 1, (int) this.CtargetLayers))
                            {
                                if (hitC.rigidbody)
                                {
                                    if (hitC.distance < LastCDist)
                                    {
                                        LastCDist = hitC.distance;
                                    }
                                    else
                                    {
                                        IsOk = true;
                                    }

                                    {
                                        float _2792 = this.CarryPointTF.localPosition.y + 0.1f;
                                        Vector3 _2793 = this.CarryPointTF.localPosition;
                                        _2793.y = _2792;
                                        this.CarryPointTF.localPosition = _2793;
                                    }
                                }
                            }
                            else
                            {
                                if (DidHit)
                                {
                                    IsOk = true;
                                }
                            }
                        }
                        if (!IsOk)
                        {
                            if (Physics.Raycast(this.CarryPointTF.position + (this.CarryPointTF.forward * -0.3f), this.CarryPointTF.forward, out hitC, 1, (int) this.CtargetLayers))
                            {
                                if (hitC.rigidbody)
                                {
                                    if (hitC.distance < LastCDist)
                                    {
                                        LastCDist = hitC.distance;
                                    }
                                    else
                                    {
                                        IsOk = true;
                                    }

                                    {
                                        float _2794 = this.CarryPointTF.localPosition.y + 0.1f;
                                        Vector3 _2795 = this.CarryPointTF.localPosition;
                                        _2795.y = _2794;
                                        this.CarryPointTF.localPosition = _2795;
                                    }
                                }
                            }
                        }
                        if (!IsOk)
                        {
                            if (Physics.Raycast(this.CarryPointTF.position + (this.CarryPointTF.forward * -0.3f), this.CarryPointTF.forward, out hitC, 1, (int) this.CtargetLayers))
                            {
                                if (hitC.rigidbody)
                                {
                                    if (hitC.distance < LastCDist)
                                    {
                                        LastCDist = hitC.distance;
                                    }
                                    else
                                    {
                                        IsOk = true;
                                    }

                                    {
                                        float _2796 = this.CarryPointTF.localPosition.y + 0.1f;
                                        Vector3 _2797 = this.CarryPointTF.localPosition;
                                        _2797.y = _2796;
                                        this.CarryPointTF.localPosition = _2797;
                                    }
                                }
                            }
                        }
                        if (!IsOk)
                        {
                            if (Physics.Raycast(this.CarryPointTF.position + (this.CarryPointTF.forward * -0.3f), this.CarryPointTF.forward, out hitC, 1, (int) this.CtargetLayers))
                            {
                                if (hitC.rigidbody)
                                {
                                    if (hitC.distance < LastCDist)
                                    {
                                        LastCDist = hitC.distance;
                                    }
                                    else
                                    {
                                        IsOk = true;
                                    }

                                    {
                                        float _2798 = this.CarryPointTF.localPosition.y + 0.1f;
                                        Vector3 _2799 = this.CarryPointTF.localPosition;
                                        _2799.y = _2798;
                                        this.CarryPointTF.localPosition = _2799;
                                    }
                                }
                            }
                        }
                        if (!IsOk)
                        {
                            if (Physics.Raycast(this.CarryPointTF.position + (this.CarryPointTF.forward * -0.3f), this.CarryPointTF.forward, out hitC, 1, (int) this.CtargetLayers))
                            {
                                if (hitC.rigidbody)
                                {
                                    if (hitC.distance < LastCDist)
                                    {
                                        LastCDist = hitC.distance;
                                    }
                                    else
                                    {
                                        IsOk = true;
                                    }

                                    {
                                        float _2800 = this.CarryPointTF.localPosition.y + 0.1f;
                                        Vector3 _2801 = this.CarryPointTF.localPosition;
                                        _2801.y = _2800;
                                        this.CarryPointTF.localPosition = _2801;
                                    }
                                }
                            }
                        }
                        if (!IsOk)
                        {
                            if (Physics.Raycast(this.CarryPointTF.position + (this.CarryPointTF.forward * -0.3f), this.CarryPointTF.forward, out hitC, 1, (int) this.CtargetLayers))
                            {
                                if (hitC.rigidbody)
                                {
                                    if (hitC.distance < LastCDist)
                                    {
                                        LastCDist = hitC.distance;
                                    }
                                    else
                                    {
                                        IsOk = true;
                                    }

                                    {
                                        float _2802 = this.CarryPointTF.localPosition.y + 0.1f;
                                        Vector3 _2803 = this.CarryPointTF.localPosition;
                                        _2803.y = _2802;
                                        this.CarryPointTF.localPosition = _2803;
                                    }
                                }
                            }
                        }
                        if (!IsOk)
                        {
                            if (Physics.Raycast(this.CarryPointTF.position + (this.CarryPointTF.forward * -0.3f), this.CarryPointTF.forward, out hitC, 1, (int) this.CtargetLayers))
                            {
                                if (hitC.rigidbody)
                                {
                                    if (hitC.distance < LastCDist)
                                    {
                                        LastCDist = hitC.distance;
                                    }
                                    else
                                    {
                                        IsOk = true;
                                    }

                                    {
                                        float _2804 = this.CarryPointTF.localPosition.y + 0.1f;
                                        Vector3 _2805 = this.CarryPointTF.localPosition;
                                        _2805.y = _2804;
                                        this.CarryPointTF.localPosition = _2805;
                                    }
                                }
                            }
                        }
                        if (CRB)
                        {
                            if ((CRB.mass > 0.1f) && (-this.CarryPointTF.localPosition.y > 0.5f))
                            {
                                IsOk = false;
                            }
                        }
                        if (IsOk)
                        {
                            this.CarryJoint = this.gameObject.AddComponent<ConfigurableJoint>();
                            this.CarryJoint.connectedBody = CRB;

                            {
                                JointDriveMode _2806 = JointDriveMode.Position;
                                JointDrive _2807 = this.CarryJoint.xDrive;
                                _2807.mode = _2806;
                                this.CarryJoint.xDrive = _2807;
                            }

                            {
                                JointDriveMode _2808 = JointDriveMode.Position;
                                JointDrive _2809 = this.CarryJoint.yDrive;
                                _2809.mode = _2808;
                                this.CarryJoint.yDrive = _2809;
                            }

                            {
                                JointDriveMode _2810 = JointDriveMode.Position;
                                JointDrive _2811 = this.CarryJoint.zDrive;
                                _2811.mode = _2810;
                                this.CarryJoint.zDrive = _2811;
                            }

                            {
                                JointDriveMode _2812 = JointDriveMode.Position;
                                JointDrive _2813 = this.CarryJoint.angularXDrive;
                                _2813.mode = _2812;
                                this.CarryJoint.angularXDrive = _2813;
                            }

                            {
                                JointDriveMode _2814 = JointDriveMode.Position;
                                JointDrive _2815 = this.CarryJoint.angularYZDrive;
                                _2815.mode = _2814;
                                this.CarryJoint.angularYZDrive = _2815;
                            }

                            {
                                int _2816 = 1;
                                JointDrive _2817 = this.CarryJoint.xDrive;
                                _2817.positionSpring = _2816;
                                this.CarryJoint.xDrive = _2817;
                            }

                            {
                                int _2818 = 1;
                                JointDrive _2819 = this.CarryJoint.yDrive;
                                _2819.positionSpring = _2818;
                                this.CarryJoint.yDrive = _2819;
                            }

                            {
                                int _2820 = 1;
                                JointDrive _2821 = this.CarryJoint.zDrive;
                                _2821.positionSpring = _2820;
                                this.CarryJoint.zDrive = _2821;
                            }

                            {
                                int _2822 = 1;
                                JointDrive _2823 = this.CarryJoint.angularXDrive;
                                _2823.positionSpring = _2822;
                                this.CarryJoint.angularXDrive = _2823;
                            }

                            {
                                int _2824 = 1;
                                JointDrive _2825 = this.CarryJoint.angularYZDrive;
                                _2825.positionSpring = _2824;
                                this.CarryJoint.angularYZDrive = _2825;
                            }

                            {
                                float _2826 = 0.05f;
                                JointDrive _2827 = this.CarryJoint.xDrive;
                                _2827.positionDamper = _2826;
                                this.CarryJoint.xDrive = _2827;
                            }

                            {
                                float _2828 = 0.1f;
                                JointDrive _2829 = this.CarryJoint.yDrive;
                                _2829.positionDamper = _2828;
                                this.CarryJoint.yDrive = _2829;
                            }

                            {
                                float _2830 = 0.05f;
                                JointDrive _2831 = this.CarryJoint.zDrive;
                                _2831.positionDamper = _2830;
                                this.CarryJoint.zDrive = _2831;
                            }

                            {
                                float _2832 = 0.05f;
                                JointDrive _2833 = this.CarryJoint.angularXDrive;
                                _2833.positionDamper = _2832;
                                this.CarryJoint.angularXDrive = _2833;
                            }

                            {
                                float _2834 = 0.05f;
                                JointDrive _2835 = this.CarryJoint.angularYZDrive;
                                _2835.positionDamper = _2834;
                                this.CarryJoint.angularYZDrive = _2835;
                            }

                            {
                                float _2836 = -hitC.distance + 0.3f;
                                Vector3 _2837 = this.CarryJoint.targetPosition;
                                _2837.z = _2836;
                                this.CarryJoint.targetPosition = _2837;
                            }
                            this.Carrying = true;
                            WorldInformation.isHolding = true;
                            DidHit = false;
                            IsOk = false;
                            if (CRB.mass > 0.1f)
                            {
                                this.HeavyCarry = true;
                                this.PiriCapCol.enabled = false;
                                this.PiriWheelCol.enabled = false;
                                this.PiriAni.CrossFade(this.HoldingOn, 0.5f);

                                {
                                    float _2838 = -this.CarryPointTF.localPosition.y;
                                    Vector3 _2839 = this.CarryJoint.targetPosition;
                                    _2839.y = _2838;
                                    this.CarryJoint.targetPosition = _2839;
                                }
                                this.PiriBoxCol.center = new Vector3(0, 0.3f, 0);
                                this.PiriBoxCol.size = new Vector3(0.4f, 1.1f, 0.4f);
                            }
                            else
                            {
                                this.HeavyCarry = false;
                                this.PiriCapCol.enabled = true;
                                this.PiriWheelCol.enabled = true;
                                this.PiriAni.CrossFade(this.Holding);
                                if (!BotObs)
                                {

                                    {
                                        float _2840 = this.CarryJoint.targetPosition.y + 1.6f;
                                        Vector3 _2841 = this.CarryJoint.targetPosition;
                                        _2841.y = _2840;
                                        this.CarryJoint.targetPosition = _2841;
                                    }
                                }

                                {
                                    float _2842 = this.CarryJoint.targetPosition.y - C2Dist;
                                    Vector3 _2843 = this.CarryJoint.targetPosition;
                                    _2843.y = _2842;
                                    this.CarryJoint.targetPosition = _2843;
                                }
                            }
                            CRB = null;
                            BotObs = false;
                            C2Dist = 0;

                            {
                                int _2844 = 0;
                                Vector3 _2845 = this.CarryPointTF.localPosition;
                                _2845.y = _2844;
                                this.CarryPointTF.localPosition = _2845;
                            }
                        }
                    }
                }
            }
            if (PlayerMotionAnimator.PiriStill && this.CanFPAnimationaise)
            {
                if (this.relative.z > 0.4f)
                {
                    this.PiriAni.CrossFade(this.GunWalk);
                    this.PiriAni[this.GunWalk].speed = Mathf.Clamp(Mathf.Abs(this.relative.z) / this.forwardSpeed, 1, this.maxAnimationSpeed);
                }
                if (-this.relative.z > 0.4f)
                {
                    this.PiriAni.CrossFade(this.GunWalk);
                    this.PiriAni[this.GunWalk].speed = Mathf.Clamp(Mathf.Abs(-this.relative.z) / -this.forwardSpeed, -1, -this.maxAnimationSpeed);
                }
                if ((this.relative.x > 0.4f) || (-this.relative.x > 0.4f))
                {
                    this.PiriAni.CrossFade(this.GunStrafe);
                    this.PiriAni[this.GunStrafe].speed = Mathf.Clamp(Mathf.Abs(this.relative.z) / this.forwardSpeed, 1, this.maxAnimationSpeed);
                }
                if ((((this.relative.z < 0.4f) && (-this.relative.z < 0.4f)) && (this.relative.x < 0.4f)) && (-this.relative.x < 0.4f))
                {
                    this.PiriAni.CrossFade(this.GunStill);
                }
            }
            if (!this.Jumping)
            {
                if (this.PiriFloating)
                {
                    if (!this.CanFPAnimationaise && this.CanMove)
                    {
                        if (this.thisRigidbody.velocity.magnitude < 15)
                        {
                            if (this.relative.z > 0.4f)
                            {
                                if (this.InWater)
                                {
                                    this.PiriAni.CrossFade(this.swimming, 0.8f);
                                }
                                else
                                {
                                    if (!this.Carrying)
                                    {
                                        this.PiriAni.CrossFade(this.floatingF, 1f);
                                    }
                                    else
                                    {
                                        this.PiriAni.CrossFade(this.HoldingOn, 0.5f);
                                    }
                                }
                            }
                            if (this.relative.z < 0.4f)
                            {
                                if (!this.Carrying)
                                {
                                    this.PiriAni.CrossFade(this.floating, 1f);
                                }
                                else
                                {
                                    this.PiriAni.CrossFade(this.HoldingOn, 0.5f);
                                }
                            }
                        }
                        else
                        {
                            if (!this.Carrying)
                            {
                                this.PiriAni.CrossFade(this.falling, 1f);
                            }
                            else
                            {
                                this.PiriAni.CrossFade(this.HoldingOn, 0.5f);
                            }
                        }
                    }
                    if (this.PiriGrounded)
                    {
                        this.PiriFloating = false;
                        PlayerMotionAnimator.Landing = false;
                        if (!Input.GetMouseButton(1))
                        {
                            this.PiriAni.CrossFade(this.Idling);
                        }
                    }
                }
                else
                {
                    if (!this.PiriGrounded)
                    {
                        this.PiriFloating = true;
                    }
                }
            }
            else
            {
                if (this.PiriGrounded)
                {
                    this.PiriAni.CrossFade(this.land, 0.4f);
                    this.StartCoroutine(this.Timer2());
                }
                else
                {
                    this.PiriFloating = true;
                }
            }
            if (!this.inInterface)
            {
                if (Input.GetMouseButtonUp(1))
                {
                    if (!this.PiriFloating)
                    {
                        this.PiriAni.CrossFade(this.Idling);
                        this.CanFPAnimationaise = false;
                    }
                    else
                    {
                        this.PiriAni.CrossFade(this.floating);
                        this.CanFPAnimationaise = false;
                    }
                }
                if (Input.GetMouseButtonDown(1) && !PlayerMotionAnimator.Landing)
                {
                    this.PiriAni.Stop();
                    this.CanFPAnimationaise = true;
                    if (this.Carrying)
                    {
                        if (this.CarryJoint)
                        {
                            UnityEngine.Object.Destroy(this.CarryJoint);
                        }
                        this.Carrying = false;
                        WorldInformation.isHolding = false;
                        this.PiriCapCol.enabled = true;
                        this.PiriWheelCol.enabled = true;
                        this.PiriBoxCol.center = new Vector3(0, -0.2f, 0);
                        this.PiriBoxCol.size = new Vector3(0.4f, 2.1f, 0.4f);
                    }
                }
            }
            if ((Input.GetMouseButton(1) && Input.GetKeyDown(KeyCode.I)) || (Input.GetMouseButton(1) && Input.GetMouseButton(2)))
            {
                if (!this.Carrying)
                {
                    this.PiriAni.Play(this.Idling);
                }
                else
                {
                    if (!this.HeavyCarry)
                    {
                        this.PiriAni.Play(this.Holding);
                    }
                    else
                    {
                        this.PiriAni.Play(this.HoldingOn);
                    }
                }
                this.CanFPAnimationaise = false;
            }
            if (this.CanFPAnimationaise)
            {
                if (!Input.GetMouseButton(1))
                {
                    this.CanFPAnimationaise = false;
                    if (!this.Carrying)
                    {
                        this.PiriAni.Play(this.Idling);
                    }
                    else
                    {
                        if (!this.HeavyCarry)
                        {
                            this.PiriAni.Play(this.Holding);
                        }
                        else
                        {
                            this.PiriAni.Play(this.HoldingOn);
                        }
                    }
                }
            }
            if ((this.PiriGrounded && !this.CanFPAnimationaise) && !this.PiriFloating)
            {
                if (((Input.GetKeyUp("w") && !this.keyA) && !this.keyS) && !this.keyD)
                {
                    if (!this.Carrying)
                    {
                        this.PiriAni.CrossFade(this.Idling);
                    }
                    else
                    {
                        if (!this.HeavyCarry)
                        {
                            this.PiriAni.CrossFade(this.Holding);
                        }
                        else
                        {
                            this.PiriAni.CrossFade(this.HoldingOn);
                        }
                    }
                }
                if (((Input.GetKeyUp("a") && !this.keyW) && !this.keyS) && !this.keyD)
                {
                    if (!this.Carrying)
                    {
                        this.PiriAni.CrossFade(this.Idling);
                    }
                    else
                    {
                        if (!this.HeavyCarry)
                        {
                            this.PiriAni.CrossFade(this.Holding);
                        }
                        else
                        {
                            this.PiriAni.CrossFade(this.HoldingOn);
                        }
                    }
                }
                if (((Input.GetKeyUp("d") && !this.keyW) && !this.keyA) && !this.keyS)
                {
                    if (!this.Carrying)
                    {
                        this.PiriAni.CrossFade(this.Idling);
                    }
                    else
                    {
                        if (!this.HeavyCarry)
                        {
                            this.PiriAni.CrossFade(this.Holding);
                        }
                        else
                        {
                            this.PiriAni.CrossFade(this.HoldingOn);
                        }
                    }
                }
                if (((Input.GetKeyUp("s") && !this.keyW) && !this.keyA) && !this.keyD)
                {
                    if (!this.Carrying)
                    {
                        this.PiriAni.CrossFade(this.Idling);
                    }
                    else
                    {
                        if (!this.HeavyCarry)
                        {
                            this.PiriAni.CrossFade(this.Holding);
                        }
                        else
                        {
                            this.PiriAni.CrossFade(this.HoldingOn);
                        }
                    }
                }
                if (this.inInterface)
                {
                    if (!this.once)
                    {
                        if (!this.Carrying)
                        {
                            this.PiriAni.CrossFade(this.Idling);
                        }
                        else
                        {
                            if (!this.HeavyCarry)
                            {
                                this.PiriAni.CrossFade(this.Holding);
                            }
                            else
                            {
                                this.PiriAni.CrossFade(this.HoldingOn);
                            }
                        }
                        this.keyW = false;
                        this.keyA = false;
                        this.keyS = false;
                        this.keyD = false;
                        this.once = true;
                    }
                }
                else
                {
                    this.once = false;
                }
            }
            if (((!this.keyW && !this.keyA) && !this.keyS) && !this.keyD)
            {
                return;
            }
            if ((this.CanFPAnimationaise || this.PiriFloating) || !this.PiriGrounded)
            {
                return;
            }
            if ((this.relative.z > this.relative.x) && (this.relative.z < 0.4f))
            {
                this.CanIdle = true;
            }
            else
            {
                if ((this.relative.z > this.relative.x) && (this.relative.z > 0.4f))
                {
                    this.CanIdle = false;
                }
            }
            //relative.z > relative.x && 
            if (this.relative.z > 0.4f)
            {
                if (this.relative.z < 2.5f)
                {
                    if (this.state != pState.WalkForward)
                    {
                        if (!this.Carrying)
                        {
                            this.PiriAni.CrossFade(this.forward);
                        }
                        else
                        {
                            if (!this.HeavyCarry)
                            {
                                this.PiriAni.CrossFade(this.HoldingW);
                            }
                        }
                        this.state = pState.WalkForward;
                    }
                    if (!this.Carrying)
                    {
                        if (this.PiriAni.IsPlaying(this.forward))
                        {
                            this.PiriAni[this.forward].speed = Mathf.Clamp(Mathf.Abs(this.relative.z) / this.forwardSpeed, 0, this.maxAnimationSpeed);
                        }
                    }
                    else
                    {
                        if (this.PiriAni.IsPlaying(this.HoldingW))
                        {
                            this.PiriAni[this.HoldingW].speed = Mathf.Clamp(Mathf.Abs(this.relative.z) / this.forwardSpeed, 0, this.maxAnimationSpeed);
                        }
                    }
                }
                else
                {
                    if (this.state != pState.Sprinting)
                    {
                        if (!this.Carrying)
                        {
                            this.PiriAni.CrossFade(this.sprint);
                        }
                        else
                        {
                            if (!this.HeavyCarry)
                            {
                                this.PiriAni.CrossFade(this.HoldingW);
                            }
                        }
                        this.state = pState.Sprinting;
                    }
                    if (!this.Carrying)
                    {
                        if (this.PiriAni.IsPlaying(this.sprint))
                        {
                            this.PiriAni[this.sprint].speed = Mathf.Clamp(Mathf.Abs(this.relative.z) / this.sprintSpeed, 0, this.maxAnimationSpeed);
                        }
                    }
                    else
                    {
                        if (this.PiriAni.IsPlaying(this.HoldingW))
                        {
                            this.PiriAni[this.HoldingW].speed = Mathf.Clamp(Mathf.Abs(this.relative.z) / this.sprintSpeed, 0, this.maxAnimationSpeed);
                        }
                    }
                }
                this.reset();
                this.state = pState.Idling;
            }
            if (this.Carrying)
            {
                if (-this.relative.z > 0.4f)
                {
                    if (!this.HeavyCarry)
                    {
                        this.PiriAni.CrossFade(this.HoldingW);
                    }
                    this.PiriAni[this.HoldingW].speed = -Mathf.Abs(-this.relative.z) / this.forwardSpeed;
                }
            }
        }
    }

    public virtual void reset()
    {
        if ((this.relative.x < 0.8f) && (this.relative.z < 0.8f))
        {
            if (!this.PiriAni.IsPlaying(this.Idling))
            {
                this.state = pState.Idling;
            }
        }
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        Vector3 localAngVel = this.thisTransform.InverseTransformDirection(this.thisRigidbody.angularVelocity);
        this.acceleration = (this.thisRigidbody.velocity.magnitude - PlayerMotionAnimator.lastVelocity) / Time.deltaTime;
        PlayerMotionAnimator.lastVelocity = this.thisRigidbody.velocity.magnitude;
        float RPVelClamp = Mathf.Clamp(PlayerMotionAnimator.lastVelocity * 0.035f, 0, 128);
        float RPVC = 0.75f + RPVelClamp;
        this.Gs = this.acceleration;
        if (!WorldInformation.UsingVessel)
        {
            if (this.OnGround)
            {
                if (((this.AimingForward || this.AimingBack) || this.AimingLeft) || this.AimingRight)
                {
                    if (this.TStabilizeForce < 8)
                    {
                        this.TStabilizeForce = this.TStabilizeForce + 0.5f;
                    }
                }
            }
            else
            {
                this.TStabilizeForce = 2;
            }
            if (!this.onMovingGround)
            {
                float VelClamp1 = Mathf.Clamp(PlayerMotionAnimator.lastVelocity, 0, 8);
                this.thisRigidbody.AddTorque(((this.thisTransform.forward * -localAngVel.y) * VelClamp1) * 0.3f);
            }
            else
            {
                float VelClamp2 = Mathf.Clamp(this.relative.magnitude, 0, 8);
                this.thisRigidbody.AddTorque(((this.thisTransform.forward * -localAngVel.y) * VelClamp2) * 0.3f);
            }
            if (this.Gs < -2500)
            {
                if (!WorldInformation.PiriIsHurt)
                {
                    PlayerMotionAnimator.CanCollide = false;
                    this.StartCoroutine(this.Pauser());
                    this.CanFPAnimationaise = false;
                    PiriUpperBodyController.Resetting = true;
                    this.CanMove = false;
                    this.PiriAni.Stop();
                    this.PiriAni.CrossFade("PiriArmature|Faceplant");
                    GameObject TheThing4 = UnityEngine.Object.Instantiate(this.Faceplant, this.FaceplantArea.transform.position, this.FaceplantArea.transform.rotation);
                    TheThing4.transform.parent = this.thisTransform;
                    this.PiriFloating = false;
                    this.StartCoroutine(this.Timer3());
                    this.Hurt2();
                }
            }
            if (PlayerMotionAnimator.CanCollide)
            {
                if (this.Gs < -500)
                {
                    PlayerMotionAnimator.CanCollide = false;
                    this.StartCoroutine(this.Pauser());
                    this.CanFPAnimationaise = false;
                    PiriUpperBodyController.Resetting = true;
                    this.CanMove = false;
                    this.PiriAni.Stop();
                    this.PiriAni.CrossFade("PiriArmature|Faceplant");
                    GameObject TheThing5 = UnityEngine.Object.Instantiate(this.Faceplant, this.FaceplantArea.transform.position, this.FaceplantArea.transform.rotation);
                    TheThing5.transform.parent = this.thisTransform;
                    this.PiriFloating = false;
                    this.StartCoroutine(this.Timer3());
                }
            }
            if ((PlayerMotionAnimator.CanCollide && this.CanMove) && !Input.GetMouseButton(1))
            {
                if (this.Gs < -200)
                {
                    PlayerMotionAnimator.CanCollide = false;
                    this.StartCoroutine(this.Pauser());
                    this.CanFPAnimationaise = false;
                    PiriUpperBodyController.Resetting = true;
                    this.PiriAni.Stop();
                    if (!Input.GetMouseButton(1))
                    {
                        this.PiriAni.Play(this.land);
                    }
                    PlayerMotionAnimator.Landing = true;
                    this.PiriGrounded = true;
                    this.PiriFloating = false;
                    this.StartCoroutine(this.Timer2());
                }
            }
        }
        if (((Input.GetMouseButton(1) && WorldInformation.UsingVessel) && this.CanMove) && !this.inInterface)
        {
            this.thisRigidbody.AddForceAtPosition((this.AimTarget.transform.position - this.thisTransform.position).normalized * this.TStabilizeForce, this.thisTransform.forward * 1);
            this.thisRigidbody.AddForceAtPosition((this.AimTarget.transform.position - this.thisTransform.position).normalized * -this.TStabilizeForce, -this.thisTransform.forward * 1);
        }
        if (this.CloseToGround)
        {
            if (!WorldInformation.UsingVessel)
            {
                this.thisRigidbody.AddForceAtPosition(Vector3.up * this.StabilizeForce, this.thisTransform.up * 2);
                this.thisRigidbody.AddForceAtPosition(-Vector3.up * this.StabilizeForce, -this.thisTransform.up * 2);
            }
        }
        else
        {
            this.thisRigidbody.AddForceAtPosition(Vector3.up * this.StabilizeForce, this.thisTransform.up * 0.2f);
            this.thisRigidbody.AddForceAtPosition(-Vector3.up * this.StabilizeForce, -this.thisTransform.up * 0.2f);
        }
        if (this.CanMove && !WorldInformation.UsingVessel)
        {
            if (this.AimingForward && (this.thisRigidbody.angularVelocity.magnitude < 5))
            {
                this.thisRigidbody.AddForceAtPosition((this.AimTarget.transform.position - this.thisTransform.position).normalized * this.TStabilizeForce, this.thisTransform.forward * 1);
                this.thisRigidbody.AddForceAtPosition((this.AimTarget.transform.position - this.thisTransform.position).normalized * -this.TStabilizeForce, -this.thisTransform.forward * 1);
            }
            if (this.AimingBack && (this.thisRigidbody.angularVelocity.magnitude < 5))
            {
                this.thisRigidbody.AddForceAtPosition((this.AimTarget.transform.position - this.thisTransform.position).normalized * this.TStabilizeForce, -this.thisTransform.forward * 1);
                this.thisRigidbody.AddForceAtPosition((this.AimTarget.transform.position - this.thisTransform.position).normalized * -this.TStabilizeForce, this.thisTransform.forward * 1);
            }
            if (this.AimingLeft && (this.thisRigidbody.angularVelocity.magnitude < 5))
            {
                this.thisRigidbody.AddForceAtPosition((this.AimSideTarget.transform.position - this.thisTransform.position).normalized * this.TStabilizeForce, -this.thisTransform.forward * 1);
                this.thisRigidbody.AddForceAtPosition((this.AimSideTarget.transform.position - this.thisTransform.position).normalized * -this.TStabilizeForce, this.thisTransform.forward * 1);
            }
            if (this.AimingRight && (this.thisRigidbody.angularVelocity.magnitude < 5))
            {
                this.thisRigidbody.AddForceAtPosition((this.AimSideTarget.transform.position - this.thisTransform.position).normalized * this.TStabilizeForce, this.thisTransform.forward * 1);
                this.thisRigidbody.AddForceAtPosition((this.AimSideTarget.transform.position - this.thisTransform.position).normalized * -this.TStabilizeForce, -this.thisTransform.forward * 1);
            }
            Vector3 newRot = ((-this.thisLevelTransform.up * 2) + (-this.thisLevelTransform.forward * 2)).normalized;
            Debug.DrawRay(this.steppypoint.position + (this.thisLevelTransform.forward * 0.75f), newRot * 0.5f, Color.white);
            if (this.OnGround)
            {
                if (((this.keyW || this.keyA) || this.keyS) || this.keyD)
                {
                    Vector3 _velocity = this.onMovingGround ? this.thisRigidbody.velocity - this.groundRigidbody.velocity : this.thisRigidbody.velocity;
                    if (!this.inInterface)
                    {
                        if (WorldInformation.FPMode)
                        {
                            if (Physics.Raycast(this.steppypoint.position + (this.thisLevelTransform.forward * 0.75f), newRot, 0.5f, (int) this.targetLayers))
                            {
                                this.thisRigidbody.AddForce(this.thisTransform.up * 1.5f);
                                this.thisRigidbody.AddForce(this.thisTransform.forward * 2);
                            }
                        }
                        else
                        {
                            if (_velocity.magnitude < 4)
                            {
                                if (_velocity.magnitude < 2)
                                {
                                    if (Physics.Raycast(this.steppypoint.position + (this.thisLevelTransform.forward * 0.75f), newRot, 0.5f, (int) this.targetLayers))
                                    {
                                        this.thisRigidbody.AddForce(this.thisTransform.up * 1.5f);
                                        this.thisRigidbody.AddForce(this.thisTransform.forward * 1.5f);
                                    }
                                }
                                else
                                {
                                    if (Physics.Raycast(this.steppypoint.position + (this.thisLevelTransform.forward * 0.75f), newRot, 0.5f, (int) this.targetLayers))
                                    {
                                        this.thisRigidbody.AddForce(this.thisTransform.up * 1);
                                        this.thisRigidbody.AddForce(this.thisTransform.forward * 1);
                                    }
                                }
                            }
                        }
                        if (this.PiriWheelRB.angularVelocity.magnitude < 7)
                        {
                            if (this.Carrying)
                            {
                                if (Input.GetKey("s"))
                                {
                                    if (!WorldInformation.FPMode)
                                    {
                                        if (this.RotForce > -0.5f)
                                        {
                                            this.RotForce = this.RotForce - 0.02f;
                                        }
                                    }
                                    else
                                    {
                                        if (this.RotForce < 0.5f)
                                        {
                                            this.RotForce = this.RotForce + 0.02f;
                                        }
                                    }
                                }
                                else
                                {
                                    if (this.RotForce < 0.5f)
                                    {
                                        this.RotForce = this.RotForce + 0.02f;
                                    }
                                }
                            }
                            else
                            {
                                if (this.RotForce < 1)
                                {
                                    this.RotForce = this.RotForce + 0.02f;
                                }
                            }
                        }
                        else
                        {
                            if (this.PiriWheelRB.angularVelocity.magnitude < 19)
                            {
                                if (this.Carrying)
                                {
                                    if (Input.GetKey("s"))
                                    {
                                        if (!WorldInformation.FPMode)
                                        {
                                            if (this.RotForce < 0)
                                            {
                                                this.RotForce = this.RotForce + 0.02f;
                                            }
                                        }
                                        else
                                        {
                                            if (this.RotForce > 0)
                                            {
                                                this.RotForce = this.RotForce - 0.02f;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (this.RotForce > 0)
                                        {
                                            this.RotForce = this.RotForce - 0.02f;
                                        }
                                    }
                                }
                                else
                                {
                                    if (!Input.GetKey(KeyCode.LeftShift))
                                    {
                                        if (this.RotForce > 0)
                                        {
                                            this.RotForce = this.RotForce - 0.02f;
                                        }
                                    }
                                    else
                                    {
                                        if (!Input.GetMouseButton(1))
                                        {
                                            if (this.RotForce < 0.5f)
                                            {
                                                this.RotForce = this.RotForce + 0.02f;
                                            }
                                        }
                                        else
                                        {
                                            if (this.RotForce > 0)
                                            {
                                                this.RotForce = this.RotForce - 0.02f;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (this.RotForce > 0)
                                {
                                    this.RotForce = this.RotForce - 0.02f;
                                }
                            }
                            if (this.PiriWheel.spring.damper < 0.001f)
                            {

                                {
                                    float _2846 = this.PiriWheel.spring.damper + 0.0001f;
                                    JointSpring _2847 = this.PiriWheel.spring;
                                    _2847.damper = _2846;
                                    this.PiriWheel.spring = _2847;
                                }
                            }
                        }
                        if (this.PiriWheel.spring.damper > 0.001f)
                        {

                            {
                                float _2848 = 0.001f;
                                JointSpring _2849 = this.PiriWheel.spring;
                                _2849.damper = _2848;
                                this.PiriWheel.spring = _2849;
                            }
                        }
                        this.PiriWheelRB.AddTorque(this.pivotRB.transform.right * this.RotForce);
                        if (this.BrakeJoint)
                        {
                            UnityEngine.Object.Destroy(this.BrakeJoint);
                        }
                        this.Moving = true;
                    }
                    else
                    {
                        this.Moving = false;
                        if (this.CanMove)
                        {

                            {
                                int _2850 = 8;
                                JointSpring _2851 = this.PiriWheel.spring;
                                _2851.damper = _2850;
                                this.PiriWheel.spring = _2851;
                            }
                        }
                        this.RotForce = 0;
                    }
                }
                else
                {
                    if (((!this.keyW && !this.keyA) && !this.keyS) && !this.keyD)
                    {
                        if (!this.BrakeJoint)
                        {
                            this.BrakeJoint = PlayerInformation.instance.PiriWheel.AddComponent<FixedJoint>();
                            this.BrakeJoint.connectedBody = this.pivotRB;
                        }
                        this.Moving = false;
                        if (this.CanMove)
                        {

                            {
                                int _2852 = 8;
                                JointSpring _2853 = this.PiriWheel.spring;
                                _2853.damper = _2852;
                                this.PiriWheel.spring = _2853;
                            }
                        }
                        this.RotForce = 0;
                    }
                }
            }
            else
            {
                if (WorldInformation.instance.AreaSpace)
                {
                    if (((this.keyW || this.keyS) || this.keyA) || this.keyD)
                    {
                        this.thisRigidbody.AddForce(this.thisTransform.forward * 0.1f);
                    }
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        this.thisRigidbody.AddForce(this.thisTransform.up * -0.1f);
                    }
                    if (Input.GetKey(KeyCode.Space))
                    {
                        this.thisRigidbody.AddForce(this.thisTransform.up * 0.1f);
                    }
                }
                else
                {
                    if (this.InWater)
                    {
                        if (((this.keyW || this.keyS) || this.keyA) || this.keyD)
                        {
                            this.thisRigidbody.AddForce(this.thisTransform.forward * 0.5f);
                        }
                    }
                }
            }
            //-------------------------------------------------------------------------------------------------------------------------|
            if (Physics.Raycast(this.PiriBaseTF.position + (this.PiriBaseTF.up * 1), -this.PiriBaseTF.up, out hit, 5, (int) this.targetLayers) && hit.rigidbody)
            {
                if (hit.rigidbody.velocity.magnitude > 2)
                {
                    this.onMovingGround = true;
                    this.groundRigidbody = hit.rigidbody;
                    if (this.relative.magnitude < 1)
                    {
                        if (this.StabilizeForce < 50)
                        {
                            this.StabilizeForce = this.StabilizeForce + 1;
                        }
                    }
                    else
                    {
                        this.StabilizeForce = 10;
                    }
                }
                else
                {
                    if (this.thisRigidbody.velocity.magnitude < 1)
                    {
                        if (this.StabilizeForce < 50)
                        {
                            this.StabilizeForce = this.StabilizeForce + 1;
                        }
                    }
                    else
                    {
                        this.StabilizeForce = 10;
                    }
                }
            }
            else
            {
                if (this.thisRigidbody.velocity.magnitude < 1)
                {
                    if (this.StabilizeForce < 50)
                    {
                        this.StabilizeForce = this.StabilizeForce + 1;
                    }
                }
                else
                {
                    this.StabilizeForce = 10;
                }
                this.onMovingGround = false;
                this.groundRigidbody = this.thisRigidbody;
            }
            if (this.groundRigidbody == null)
            {
                this.groundRigidbody = this.thisRigidbody;
                this.onMovingGround = false;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------|
        if (!WorldInformation.PiriIsHurt)
        {
            if ((!this.CanIdle || WorldInformation.UsingVessel) || this.Performing)
            {
                return;
            }
            if (((PlayerMotionAnimator.PiriStill || PlayerMotionAnimator.Landing) || this.PiriFloating) || !this.CanMove)
            {
                return;
            }
            if (this.Count < 2.5f)
            {
                return;
            }
            this.Count = 0;
            int randomValue = Random.Range(0, 10);
            switch (randomValue)
            {
                case 1:
                    if (!WorldInformation.FPMode && !this.Carrying)
                    {
                        this.aState = eState.Idle2;
                        this.PiriAni.CrossFade(this.Idling2);
                        this.StopCoroutine("Jiggle");
                        this.StartCoroutine(this.Jiggle());
                    }
                    break;
                case 2:
                    if (!WorldInformation.FPMode && !this.Carrying)
                    {
                        this.aState = eState.Idle3;
                        this.PiriAni.CrossFade(this.Idling2);
                        this.StopCoroutine("Jiggle");
                        this.StartCoroutine(this.Jiggle());
                    }
                    break;
                default:
                     //When randomValue is not 1 or 2
                    if (!this.Carrying)
                    {
                        this.aState = eState.Idle;
                        this.PiriAni.CrossFade(this.Idling);
                    }
                    else
                    {
                        if (!this.HeavyCarry)
                        {
                            this.PiriAni.CrossFade(this.Holding);
                        }
                        else
                        {
                            this.PiriAni.CrossFade(this.HoldingOn);
                        }
                    }
                    break;
            }
        }
    }

    public virtual IEnumerator Jiggle()
    {
        yield return new WaitForSeconds(1.35f);
        if (this.PiriAni.IsPlaying(this.Idling2))
        {
            this.RBosom.GetComponent<Rigidbody>().AddForce(this.thisTransform.up * 0.07f);
        }
        if (this.PiriAni.IsPlaying(this.Idling2))
        {
            this.LBosom.GetComponent<Rigidbody>().AddForce(this.thisTransform.up * 0.07f);
        }
        yield return new WaitForSeconds(0.05f);
        if (this.PiriAni.IsPlaying(this.Idling2))
        {
            this.RBosom.GetComponent<Rigidbody>().AddForce(this.thisTransform.up * 0.07f);
        }
        if (this.PiriAni.IsPlaying(this.Idling2))
        {
            this.LBosom.GetComponent<Rigidbody>().AddForce(this.thisTransform.up * 0.07f);
        }
        yield return new WaitForSeconds(0.05f);
        if (this.PiriAni.IsPlaying(this.Idling2))
        {
            this.RBosom.GetComponent<Rigidbody>().AddForce(this.thisTransform.up * 0.07f);
        }
        if (this.PiriAni.IsPlaying(this.Idling2))
        {
            this.LBosom.GetComponent<Rigidbody>().AddForce(this.thisTransform.up * 0.07f);
        }
        yield return new WaitForSeconds(0.13f);
        if (this.PiriAni.IsPlaying(this.Idling2))
        {
            this.RBosom.GetComponent<Rigidbody>().AddForce(this.thisTransform.up * -0.2f);
        }
        if (this.PiriAni.IsPlaying(this.Idling2))
        {
            this.LBosom.GetComponent<Rigidbody>().AddForce(this.thisTransform.up * -0.2f);
        }
    }

    public virtual void PlayAnimation(string ani)
    {
        if (!this.PiriAni.IsPlaying(ani))
        {
            this.PiriAni.CrossFade(ani);
        }
    }

    public virtual IEnumerator Hurt()
    {
        if (!WorldInformation.Godmode)
        {
            WorldInformation.PiriIsHurt = true;
            this.CanMove = false;
            this.TC.name = "snyf";
            this.PiriAni.Stop();
            UnityEngine.Object.Instantiate(this.HurtNoise, this.thisTransform.position, this.thisTransform.rotation);
            //WheelBrake
            yield return new WaitForSeconds(0.2f);
            this.PiriAni.CrossFade("PiriArmature|Faceplant");
            this.StartCoroutine(WorldInformation.instance.Hurt());
        }
    }

    public virtual void Hurt2()
    {
        if (!WorldInformation.Godmode)
        {
            WorldInformation.PiriIsHurt = true;
            this.CanMove = false;
            this.TC.name = "snyf";
            this.StartCoroutine(WorldInformation.instance.Hurt());
        }
    }

    public virtual void Counter()
    {
        this.Count = this.Count + 0.5f;
    }

    public virtual IEnumerator Pauser()
    {
        yield return new WaitForSeconds(0.3f);
        PlayerMotionAnimator.CanCollide = true;
    }

    public virtual void Tick()
    {
        if (this.Pirizuka.activeSelf)
        {
            this.StartCoroutine(this.Pauser());
        }
        if (this.thisRigidbody.velocity.magnitude < 15)
        {

            {
                int _2854 = 0;
                JointDrive _2855 = this.RBosomCJ.angularXDrive;
                _2855.positionDamper = _2854;
                this.RBosomCJ.angularXDrive = _2855;
            }

            {
                int _2856 = 0;
                JointDrive _2857 = this.RBosomCJ.angularYZDrive;
                _2857.positionDamper = _2856;
                this.RBosomCJ.angularYZDrive = _2857;
            }

            {
                float _2858 = 0.002f;
                JointDrive _2859 = this.RBosomCJ.angularXDrive;
                _2859.positionSpring = _2858;
                this.RBosomCJ.angularXDrive = _2859;
            }

            {
                float _2860 = 0.002f;
                JointDrive _2861 = this.RBosomCJ.angularYZDrive;
                _2861.positionSpring = _2860;
                this.RBosomCJ.angularYZDrive = _2861;
            }

            {
                int _2862 = 0;
                JointDrive _2863 = this.LBosomCJ.angularXDrive;
                _2863.positionDamper = _2862;
                this.LBosomCJ.angularXDrive = _2863;
            }

            {
                int _2864 = 0;
                JointDrive _2865 = this.LBosomCJ.angularYZDrive;
                _2865.positionDamper = _2864;
                this.LBosomCJ.angularYZDrive = _2865;
            }

            {
                float _2866 = 0.002f;
                JointDrive _2867 = this.LBosomCJ.angularXDrive;
                _2867.positionSpring = _2866;
                this.LBosomCJ.angularXDrive = _2867;
            }

            {
                float _2868 = 0.002f;
                JointDrive _2869 = this.LBosomCJ.angularYZDrive;
                _2869.positionSpring = _2868;
                this.LBosomCJ.angularYZDrive = _2869;
            }
        }
        if (this.thisRigidbody.velocity.magnitude > 15)
        {

            {
                float _2870 = 0.0002f;
                JointDrive _2871 = this.RBosomCJ.angularXDrive;
                _2871.positionDamper = _2870;
                this.RBosomCJ.angularXDrive = _2871;
            }

            {
                float _2872 = 0.0002f;
                JointDrive _2873 = this.RBosomCJ.angularYZDrive;
                _2873.positionDamper = _2872;
                this.RBosomCJ.angularYZDrive = _2873;
            }

            {
                float _2874 = 0.006f;
                JointDrive _2875 = this.RBosomCJ.angularXDrive;
                _2875.positionSpring = _2874;
                this.RBosomCJ.angularXDrive = _2875;
            }

            {
                float _2876 = 0.006f;
                JointDrive _2877 = this.RBosomCJ.angularYZDrive;
                _2877.positionSpring = _2876;
                this.RBosomCJ.angularYZDrive = _2877;
            }

            {
                float _2878 = 0.0002f;
                JointDrive _2879 = this.LBosomCJ.angularXDrive;
                _2879.positionDamper = _2878;
                this.LBosomCJ.angularXDrive = _2879;
            }

            {
                float _2880 = 0.0002f;
                JointDrive _2881 = this.LBosomCJ.angularYZDrive;
                _2881.positionDamper = _2880;
                this.LBosomCJ.angularYZDrive = _2881;
            }

            {
                float _2882 = 0.006f;
                JointDrive _2883 = this.LBosomCJ.angularXDrive;
                _2883.positionSpring = _2882;
                this.LBosomCJ.angularXDrive = _2883;
            }

            {
                float _2884 = 0.006f;
                JointDrive _2885 = this.LBosomCJ.angularYZDrive;
                _2885.positionSpring = _2884;
                this.LBosomCJ.angularYZDrive = _2885;
            }
        }
        if (this.thisRigidbody.velocity.magnitude > 50)
        {

            {
                float _2886 = 0.0004f;
                JointDrive _2887 = this.RBosomCJ.angularXDrive;
                _2887.positionDamper = _2886;
                this.RBosomCJ.angularXDrive = _2887;
            }

            {
                float _2888 = 0.0004f;
                JointDrive _2889 = this.RBosomCJ.angularYZDrive;
                _2889.positionDamper = _2888;
                this.RBosomCJ.angularYZDrive = _2889;
            }

            {
                float _2890 = 0.01f;
                JointDrive _2891 = this.RBosomCJ.angularXDrive;
                _2891.positionSpring = _2890;
                this.RBosomCJ.angularXDrive = _2891;
            }

            {
                float _2892 = 0.01f;
                JointDrive _2893 = this.RBosomCJ.angularYZDrive;
                _2893.positionSpring = _2892;
                this.RBosomCJ.angularYZDrive = _2893;
            }

            {
                float _2894 = 0.0004f;
                JointDrive _2895 = this.LBosomCJ.angularXDrive;
                _2895.positionDamper = _2894;
                this.LBosomCJ.angularXDrive = _2895;
            }

            {
                float _2896 = 0.0004f;
                JointDrive _2897 = this.LBosomCJ.angularYZDrive;
                _2897.positionDamper = _2896;
                this.LBosomCJ.angularYZDrive = _2897;
            }

            {
                float _2898 = 0.01f;
                JointDrive _2899 = this.LBosomCJ.angularXDrive;
                _2899.positionSpring = _2898;
                this.LBosomCJ.angularXDrive = _2899;
            }

            {
                float _2900 = 0.01f;
                JointDrive _2901 = this.LBosomCJ.angularYZDrive;
                _2901.positionSpring = _2900;
                this.LBosomCJ.angularYZDrive = _2901;
            }
        }
        if (!Input.GetMouseButton(1) && !WorldInformation.FPMode)
        {
            this.AimingForward = false;
            this.AimingBack = false;
            this.AimingLeft = false;
            this.AimingRight = false;
        }
    }

    public PlayerMotionAnimator()
    {
        this.maxAnimationSpeed = 2f;
        this.backwardSpeed = 1f;
        this.forwardSpeed = 1f;
        this.sprintSpeed = 1f;
        this.aState = eState.Idle;
        this.GroundClearance = 0.5f;
        this.CanMove = true;
        this.JumpForce = 100;
        this.StabilizeForce = 10f;
        this.TStabilizeForce = 10f;
        this.AngDrag = 40;
    }

}