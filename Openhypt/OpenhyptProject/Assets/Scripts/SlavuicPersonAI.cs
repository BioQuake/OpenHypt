using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SlavuicPersonAI : MonoBehaviour
{
    public Transform target;
    public Transform eventualTarget;
    public Transform lookTarget;
    public Transform ResetView;
    public Transform LocalView;
    public Transform LocalSpace;
    public Transform LocalWaypoint;
    public Transform Waypoint;
    public Transform Stranger;
    public Transform Leader;
    public int LLotteryNum;
    public Transform BodyTF;
    public Rigidbody BodyRB;
    public Transform HeadTF;
    public SphereCollider Trig;
    public Transform TCCol;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody WheelRB;
    public HingeJoint WheelJoint;
    public GameObject GunGO;
    public Transform GunTF;
    public Transform GunBarrelTF;
    public PersonGunScript Gun;
    public Animation UpperBodyAni;
    public Transform TorsoTF;
    public Transform TorsoAP;
    public Transform GTorso;
    public Transform RFemurTF;
    public Transform LFemurTF;
    public Transform RTibiaTF;
    public Transform LTibiaTF;
    public Transform RFootTF;
    public Transform LFootTF;
    public Transform RFemurAP;
    public Transform LFemurAP;
    public Transform RTibiaAP;
    public Transform LTibiaAP;
    public Transform RFootAP;
    public Transform LFootAP;
    public Transform GRFemur;
    public Transform GLFemur;
    public Transform GRTibia;
    public Transform GLTibia;
    public Transform GRFoot;
    public Transform GLFoot;
    public Transform GRHumerus;
    public Transform GLHumerus;
    public Transform GRRadius;
    public Transform GLRadius;
    public Transform Possession1;
    public Transform Possession2;
    public Transform Favourite1;
    public Vector3 Pos1Area;
    public Vector3 Pos2Area;
    public Vector3 Fav1Area;
    public float movementClock1;
    public float movementClock2;
    public float VelClamp;
    public float MoveSpeed;
    public float MoveForce;
    public float LocoSpeed;
    public float StabForce;
    public float RotForce;
    public float TurnForce;
    public float Force;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public int Break1;
    public float Vert;
    public float Hori;
    public float VertAbs;
    public float HoriAbs;
    public float VNClamp;
    public float HNClamp;
    public float AimSpeed;
    public float FuckingRead;
    public AnimationCurve torsoCurve;
    public AnimationCurve femurCurve;
    public AnimationCurve tibiaCurve;
    public AnimationCurve torsoCurveR;
    public AnimationCurve femurCurveR;
    public AnimationCurve tibiaCurveR;
    public AnimationCurve humerusCurve;
    public AnimationCurve radiusCurve;
    public AnimationCurve humerusCurveR;
    public AnimationCurve radiusCurveR;
    public bool NoShoot;
    public bool AimStance;
    public bool AimGunOnce;
    public bool IdleGunOnce;
    public bool StandOnce;
    public bool WalkOnce;
    public bool Sitting;
    public bool Walking;
    public bool Running;
    public bool Fidgeting;
    public bool FreeRoam;
    public bool IHas;
    public bool IHappy;
    public bool IEcstatic;
    public bool IBliiiiiin;
    public bool LookingAtLostItem;
    public bool Holding;
    public bool Grounded;
    public bool Obscured;
    public int Obstacle;
    public int Stuckage;
    public int RestlessLegs;
    public int Anger;
    public int Pathfind;
    public int Ogle;
    public int Blyats;
    public AudioClip Blyat1;
    public AudioClip Bliin1;
    public AudioClip Cyka1;
    public float RayDist;
    public float RaySideDist;
    public float RightDist;
    public float LeftDist;
    public int RightNum;
    public int LeftNum;
    public int RStep;
    public int LStep;
    public float AngVelMod;
    public float RPClamp;
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    private int StatTurnForce;
    public virtual IEnumerator Start()
    {
        RaycastHit hitG = default(RaycastHit);
        this.InvokeRepeating("Refresher", 1, 0.5f);
        Debug.DrawRay(this.BodyTF.position + (-this.BodyTF.up * 1.08f), Vector3.down * 8, Color.white);
        if (Physics.Raycast(this.BodyTF.position + (-this.BodyTF.up * 1.08f), Vector3.down, out hitG, 8, (int) this.targetLayers))
        {
            this.Waypoint.parent = hitG.collider.transform;
            if (!hitG.collider.name.Contains("T5B"))
            {
                this.FreeRoam = true;
            }
        }
        this.StatTurnForce = (int) this.TurnForce;
        this.RayDist = 5;
        this.RaySideDist = 1.2f;
        this.RStep = 1;
        this.LStep = 3;
        if (this.Sitting)
        {
            this.TorsoAP.position = this.TorsoTF.position;
            this.TorsoAP.rotation = this.TorsoTF.rotation;
            this.RFemurAP.position = this.RFemurTF.position;
            this.RFemurAP.rotation = this.RFemurTF.rotation;
            this.LFemurAP.position = this.LFemurTF.position;
            this.LFemurAP.rotation = this.LFemurTF.rotation;
            this.RTibiaAP.position = this.RTibiaTF.position;
            this.RTibiaAP.rotation = this.RTibiaTF.rotation;
            this.LTibiaAP.position = this.LTibiaTF.position;
            this.LTibiaAP.rotation = this.LTibiaTF.rotation;
            this.RFootAP.position = this.RFootTF.position;
            this.RFootAP.rotation = this.RFootTF.rotation;
            this.LFootAP.position = this.LFootTF.position;
            this.LFootAP.rotation = this.LFootTF.rotation;
        }
        yield return new WaitForSeconds(1);
        this.Pathfind = 240;
    }

    public virtual void Update()//}
    {
        RaycastHit hit = default(RaycastHit);
        this.LocalSpace.position = this.thisTransform.position;
        if (this.target == null)
        {
            this.target = this.ResetView;
            if (this.Anger > 10)
            {
                this.Anger = 10;
            }
        }
        else
        {
            if (this.AimStance)
            {
                this.NoShoot = false;
                Debug.DrawRay(this.GunBarrelTF.position + (this.GunBarrelTF.forward * 0.3f), this.GunBarrelTF.forward * 250, Color.yellow);
                if (Physics.Raycast(this.GunBarrelTF.position + (this.GunBarrelTF.forward * 0.3f), this.GunBarrelTF.forward, out hit, 250, (int) this.targetLayers))
                {
                    if (hit.collider.tag.Contains("tru") || hit.collider.name.Contains("T5"))
                    {
                        this.NoShoot = true;
                    }
                }
                if (!this.NoShoot)
                {
                    if (this.target.name.Contains("Reset"))
                    {
                        if (this.Anger > 10)
                        {
                            this.Anger = 10;
                        }
                        this.NoShoot = true;
                    }
                    if (this.target.name.Contains("Way"))
                    {
                        this.target = this.ResetView;
                        this.NoShoot = true;
                    }
                }
            }
        }
        if (this.eventualTarget == null)
        {
            this.eventualTarget = this.ResetView;
        }
        else
        {
            if (this.Anger > 0)
            {
                if (!this.Obscured)
                {
                    this.target = this.eventualTarget;
                }
                else
                {
                    this.Waypoint.position = this.eventualTarget.position;
                    this.target = this.LocalWaypoint;
                }
            }
        }
        if (SlavuicNetwork.Attention)
        {
            if (Vector3.Distance(this.thisTransform.position, PlayerInformation.instance.Pirizuka.position) < 500)
            {
                this.lookTarget = PlayerInformation.instance.Pirizuka;
                this.Ogle = 20;
            }
        }
    }

    private Quaternion NewRotation;
    private Quaternion NewRotation2;
    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        Vector3 WAV = this.BodyTF.InverseTransformDirection(this.WheelRB.angularVelocity);
        this.AngVelMod = WAV.x * 0.5f;
        this.VelClamp = Mathf.Clamp(this.AngVelMod, 0.5f, 8);
        //var localV = BodyTF.InverseTransformDirection(BodyRB.velocity);
        //var LVClamp = Mathf.Clamp(localV.z,0.5,4);
        //var LVClamp2 = Mathf.Clamp(localV.z,2,4);
        Vector3 localAV = this.BodyTF.InverseTransformDirection(this.BodyRB.angularVelocity);
        float RayLV = this.VelClamp * this.RayDist;
        float AngComb = localAV.x + localAV.z;
        float AVModX = localAV.x * 4;
        float AVClampX = Mathf.Clamp(AVModX, 0, 1);
        float AVModY = localAV.y * 0.2f;
        //var AVClampY = Mathf.Clamp(AVModY,0,1);
        float AVModZ = localAV.z * 4;
        float AVClampZ = Mathf.Clamp(AVModZ, 0, 1);
        this.BodyRB.AddTorque(this.BodyTF.right * -AVClampX);
        //BodyRB.AddTorque(BodyTF.up * -AVClampY);
        this.BodyRB.AddTorque(this.BodyTF.forward * -AVClampZ);
        this.BodyRB.AddForceAtPosition(Vector3.up * this.StabForce, this.thisVTransform.up * 1);
        this.BodyRB.AddForceAtPosition(-Vector3.up * this.StabForce, -this.thisVTransform.up * 1);
        if (this.LLotteryNum > 0)
        {
            this.LLotteryNum = this.LLotteryNum - 1;
        }
        if (this.target)
        {
            Vector3 RelativeTarget = this.BodyTF.InverseTransformPoint(this.target.position);
            this.RPClamp = Mathf.Clamp(RelativeTarget.x, -this.TurnForce, this.TurnForce);
            float RPMod = this.RPClamp / AVModY;
            Vector3 RelativeG = this.GunTF.InverseTransformPoint(this.target.position);
            this.Vert = RelativeG.z;
            this.Hori = RelativeG.x;
            this.VertAbs = Mathf.Abs(this.Vert);
            this.HoriAbs = Mathf.Abs(this.Hori);
            float DistModV = this.VertAbs / Vector3.Distance(this.thisTransform.position, this.target.position);
            float DistModH = this.HoriAbs / Vector3.Distance(this.thisTransform.position, this.target.position);
            this.VNClamp = Mathf.Clamp(DistModV * this.AimSpeed, 0, 2);
            this.HNClamp = Mathf.Clamp(DistModH * this.AimSpeed, 0, 2);
            if (this.AimSpeed < 2)
            {
                this.AimSpeed = this.AimSpeed + 0.02f;
            }
            this.FuckingRead = this.HoriAbs + this.VertAbs;
            if ((this.Walking || (this.Anger > 5)) || (this.Ogle > 5))
            {
                this.BodyRB.AddTorque(this.BodyTF.up * this.RPClamp);
            }
        }
        if (this.lookTarget)
        {
            this.NewRotation = Quaternion.LookRotation(this.lookTarget.position - this.HeadTF.position);
            this.HeadTF.rotation = Quaternion.RotateTowards(this.HeadTF.rotation, this.NewRotation, 4);
            if (this.HeadTF.localEulerAngles.x > 200)
            {
                if (this.HeadTF.localEulerAngles.x < 340)
                {

                    {
                        int _2994 = 340;
                        Vector3 _2995 = this.HeadTF.localEulerAngles;
                        _2995.x = _2994;
                        this.HeadTF.localEulerAngles = _2995;
                    }
                }
            }
            if (this.HeadTF.localEulerAngles.x < 90)
            {
                if (this.HeadTF.localEulerAngles.x > 40)
                {

                    {
                        int _2996 = 40;
                        Vector3 _2997 = this.HeadTF.localEulerAngles;
                        _2997.x = _2996;
                        this.HeadTF.localEulerAngles = _2997;
                    }
                }
            }
            if (this.HeadTF.localEulerAngles.z > 30)
            {
                if (this.HeadTF.localEulerAngles.z < 180)
                {

                    {
                        int _2998 = 30;
                        Vector3 _2999 = this.HeadTF.localEulerAngles;
                        _2999.z = _2998;
                        this.HeadTF.localEulerAngles = _2999;
                    }
                }
            }
            if (this.HeadTF.localEulerAngles.z < 330)
            {
                if (this.HeadTF.localEulerAngles.z > 180)
                {

                    {
                        int _3000 = 330;
                        Vector3 _3001 = this.HeadTF.localEulerAngles;
                        _3001.z = _3000;
                        this.HeadTF.localEulerAngles = _3001;
                    }
                }
            }
            if ((this.HeadTF.localEulerAngles.y < 300) && (this.HeadTF.localEulerAngles.y > 180))
            {

                {
                    int _3002 = 300;
                    Vector3 _3003 = this.HeadTF.localEulerAngles;
                    _3003.y = _3002;
                    this.HeadTF.localEulerAngles = _3003;
                }
            }
            if ((this.HeadTF.localEulerAngles.y > 60) && (this.HeadTF.localEulerAngles.y < 180))
            {

                {
                    int _3004 = 60;
                    Vector3 _3005 = this.HeadTF.localEulerAngles;
                    _3005.y = _3004;
                    this.HeadTF.localEulerAngles = _3005;
                }
            }
        }
        if (this.Fidgeting)
        {
            if (!this.IBliiiiiin)
            {
                this.BodyRB.AddTorque(this.thisTransform.up * Random.Range(-this.Force, this.Force));
                if ((this.BodyTF.localEulerAngles.x > 345) || (this.BodyTF.localEulerAngles.x < 15))
                {
                    this.BodyRB.AddTorque(this.thisTransform.right * Random.Range(-this.Force, this.Force));
                }
                if ((this.BodyTF.localEulerAngles.z > 345) || (this.BodyTF.localEulerAngles.z < 15))
                {
                    this.BodyRB.AddTorque(this.thisTransform.forward * Random.Range(-this.Force, this.Force));
                }
            }
            else
            {
                this.BodyRB.AddTorque(this.thisTransform.up * Random.Range(-this.Force, this.Force));
                this.BodyRB.AddTorque(this.thisTransform.right * Random.Range(-this.Force, this.Force));
                this.BodyRB.AddTorque(this.thisTransform.forward * Random.Range(-this.Force, this.Force));
            }
        }
        this.TorsoTF.position = this.TorsoAP.position;
        this.TorsoTF.rotation = this.TorsoAP.rotation;
        this.RFemurTF.position = this.RFemurAP.position;
        this.RFemurTF.rotation = this.RFemurAP.rotation;
        this.LFemurTF.position = this.LFemurAP.position;
        this.LFemurTF.rotation = this.LFemurAP.rotation;
        this.RTibiaTF.position = this.RTibiaAP.position;
        this.RTibiaTF.rotation = this.RTibiaAP.rotation;
        this.LTibiaTF.position = this.LTibiaAP.position;
        this.LTibiaTF.rotation = this.LTibiaAP.rotation;
        this.RFootTF.position = this.RFootAP.position;
        this.RFootTF.rotation = this.RFootAP.rotation;
        this.LFootTF.position = this.LFootAP.position;
        this.LFootTF.rotation = this.LFootAP.rotation;
        //[Standing]=================================================================================================================
        if (!this.Sitting)
        {
            Debug.DrawRay(this.BodyTF.position + (-this.BodyTF.up * 1.1f), Vector3.down * 0.6f, Color.white);
            if (Physics.Raycast(this.BodyTF.position + (-this.BodyTF.up * 1.1f), Vector3.down, 0.6f, (int) this.targetLayers))
            {
                this.Grounded = true;
            }
            else
            {
                this.Grounded = false;
            }
            if (this.Grounded)
            {
                this.BodyRB.angularDrag = 32;
                this.TurnForce = this.StatTurnForce;
                if (AngComb < 2)
                {
                    if (this.StabForce < 6)
                    {
                        this.StabForce = this.StabForce + 0.2f;
                    }
                }
                else
                {
                    this.StabForce = 0.1f;
                }
                if (this.Walking)
                {
                    if (this.Obstacle < 20)
                    {

                        {
                            float _3006 = this.MoveSpeed;
                            JointMotor _3007 = this.WheelJoint.motor;
                            _3007.targetVelocity = _3006;
                            this.WheelJoint.motor = _3007;
                        }

                        {
                            float _3008 = this.MoveForce;
                            JointMotor _3009 = this.WheelJoint.motor;
                            _3009.force = _3008;
                            this.WheelJoint.motor = _3009;
                        }
                    }
                    else
                    {

                        {
                            float _3010 = this.MoveSpeed;
                            JointMotor _3011 = this.WheelJoint.motor;
                            _3011.targetVelocity = _3010;
                            this.WheelJoint.motor = _3011;
                        }

                        {
                            int _3012 = 0;
                            JointMotor _3013 = this.WheelJoint.motor;
                            _3013.force = _3012;
                            this.WheelJoint.motor = _3013;
                        }
                    }
                }
                else
                {

                    {
                        float _3014 = this.MoveSpeed;
                        JointMotor _3015 = this.WheelJoint.motor;
                        _3015.targetVelocity = _3014;
                        this.WheelJoint.motor = _3015;
                    }

                    {
                        int _3016 = 0;
                        JointMotor _3017 = this.WheelJoint.motor;
                        _3017.force = _3016;
                        this.WheelJoint.motor = _3017;
                    }
                }
            }
            else
            {
                this.BodyRB.angularDrag = 1;
                this.StabForce = 0.1f;
                this.TurnForce = 0;

                {
                    float _3018 = this.MoveSpeed;
                    JointMotor _3019 = this.WheelJoint.motor;
                    _3019.targetVelocity = _3018;
                    this.WheelJoint.motor = _3019;
                }

                {
                    int _3020 = 0;
                    JointMotor _3021 = this.WheelJoint.motor;
                    _3021.force = _3020;
                    this.WheelJoint.motor = _3021;
                }
            }
        }
        else
        {
            //[Standing]=================================================================================================================
            //[Sitting]=================================================================================================================
            Debug.DrawRay(this.BodyTF.position, Vector3.down * 1.6f, Color.white);
            if (Physics.Raycast(this.BodyTF.position, Vector3.down, 1.6f, (int) this.targetLayers))
            {
                this.Grounded = true;
            }
            else
            {
                this.Grounded = false;
            }
            if (this.Grounded)
            {
                this.BodyRB.angularDrag = 0.1f;
                this.StabForce = 1;
                this.TurnForce = 0;
                this.Force = 2;

                {
                    float _3022 = this.MoveSpeed;
                    JointMotor _3023 = this.WheelJoint.motor;
                    _3023.targetVelocity = _3022;
                    this.WheelJoint.motor = _3023;
                }

                {
                    int _3024 = 0;
                    JointMotor _3025 = this.WheelJoint.motor;
                    _3025.force = _3024;
                    this.WheelJoint.motor = _3025;
                }
            }
            else
            {
                this.BodyRB.angularDrag = 0.1f;
                this.StabForce = 0.1f;
                this.TurnForce = 0;

                {
                    float _3026 = this.MoveSpeed;
                    JointMotor _3027 = this.WheelJoint.motor;
                    _3027.targetVelocity = _3026;
                    this.WheelJoint.motor = _3027;
                }

                {
                    int _3028 = 0;
                    JointMotor _3029 = this.WheelJoint.motor;
                    _3029.force = _3028;
                    this.WheelJoint.motor = _3029;
                }
            }
        }
        //[Sitting]=================================================================================================================
        if (this.Pathfind > 0)
        {
            this.LocalView.position = this.HeadTF.position;

            {
                float _3030 = this.LocalView.position.y - 2;
                Vector3 _3031 = this.LocalView.position;
                _3031.y = _3030;
                this.LocalView.position = _3031;
            }
            Debug.DrawRay(this.LocalView.position + (this.LocalView.right * this.RaySideDist), this.LocalView.forward * RayLV, Color.black);
            if (Physics.Raycast(this.LocalView.position + (this.LocalView.right * this.RaySideDist), this.LocalView.forward, out hit, RayLV, (int) this.targetLayers))
            {
                if (this.LeftNum < 5)
                {
                    if (this.Obstacle < 80)
                    {
                        this.RightDist = hit.distance;
                    }
                }
            }
            else
            {
                if (this.Obstacle < 80)
                {
                    this.RightDist = 64;
                }
                if (this.RightNum > 0)
                {
                    this.RightNum = this.RightNum - 1;
                }
            }
            Debug.DrawRay(this.LocalView.position + (-this.LocalView.right * this.RaySideDist), this.LocalView.forward * RayLV, Color.black);
            if (Physics.Raycast(this.LocalView.position + (-this.LocalView.right * this.RaySideDist), this.LocalView.forward, out hit, RayLV, (int) this.targetLayers))
            {
                if (this.RightNum < 5)
                {
                    if (this.Obstacle < 80)
                    {
                        this.LeftDist = hit.distance;
                    }
                }
            }
            else
            {
                if (this.Obstacle < 80)
                {
                    this.LeftDist = 64;
                }
                if (this.LeftNum > 0)
                {
                    this.LeftNum = this.LeftNum - 1;
                }
            }
            Debug.DrawRay((this.LocalView.position + (this.LocalView.forward * RayLV)) + (this.LocalView.right * this.RaySideDist), -this.LocalView.up * 1, Color.black);
            if (!Physics.Raycast((this.LocalView.position + (this.LocalView.forward * RayLV)) + (this.LocalView.right * this.RaySideDist), -this.LocalView.up, out hit, 1, (int) this.targetLayers))
            {
                this.RightDist = 0.1f;
                if (this.Pathfind > 20)
                {
                    this.Pathfind = this.Pathfind - 20;
                }
                if (this.RayDist > 2)
                {
                    this.RayDist = this.RayDist - 0.5f;
                }
                if (this.RaySideDist > 0.6f)
                {
                    this.RaySideDist = this.RaySideDist - 0.05f;
                }
            }
            else
            {
                if (this.RaySideDist < 1.2f)
                {
                    this.RaySideDist = this.RaySideDist + 0.01f;
                }
                if (this.RayDist < 5)
                {
                    this.RayDist = this.RayDist + 0.01f;
                }
            }
            Debug.DrawRay((this.LocalView.position + (this.LocalView.forward * RayLV)) + (-this.LocalView.right * this.RaySideDist), -this.LocalView.up * 1, Color.black);
            if (!Physics.Raycast((this.LocalView.position + (this.LocalView.forward * RayLV)) + (-this.LocalView.right * this.RaySideDist), -this.LocalView.up, out hit, 1, (int) this.targetLayers))
            {
                this.LeftDist = 0.1f;
                if (this.Pathfind > 20)
                {
                    this.Pathfind = this.Pathfind - 20;
                }
                if (this.RayDist > 2)
                {
                    this.RayDist = this.RayDist - 0.5f;
                }
                if (this.RaySideDist > 0.6f)
                {
                    this.RaySideDist = this.RaySideDist - 0.05f;
                }
            }
            else
            {
                if (this.RaySideDist < 1.2f)
                {
                    this.RaySideDist = this.RaySideDist + 0.01f;
                }
                if (this.RayDist < 5)
                {
                    this.RayDist = this.RayDist + 0.01f;
                }
            }
            if (this.RightDist > this.LeftDist)
            {

                {
                    float _3032 = this.LocalView.localEulerAngles.y + 1.5f;
                    Vector3 _3033 = this.LocalView.localEulerAngles;
                    _3033.y = _3032;
                    this.LocalView.localEulerAngles = _3033;
                }
                if (this.RightNum < 10)
                {
                    this.RightNum = this.RightNum + 1;
                }
                if ((this.Anger > 5) || this.Running)
                {
                    if (this.Pathfind > 30)
                    {
                        this.Pathfind = 30;
                    }
                }
            }
            if (this.LeftDist > this.RightDist)
            {

                {
                    float _3034 = this.LocalView.localEulerAngles.y - 1.5f;
                    Vector3 _3035 = this.LocalView.localEulerAngles;
                    _3035.y = _3034;
                    this.LocalView.localEulerAngles = _3035;
                }
                if (this.LeftNum < 10)
                {
                    this.LeftNum = this.LeftNum + 1;
                }
                if ((this.Anger > 5) || this.Running)
                {
                    if (this.Pathfind > 30)
                    {
                        this.Pathfind = 30;
                    }
                }
            }
            if (this.LeftDist == this.RightDist)
            {
                if (this.LeftNum > 0)
                {
                    this.LeftNum = this.LeftNum - 1;
                }
            }
            Debug.DrawRay(this.LocalView.position, (this.LocalView.forward * RayLV) * 0.75f, Color.white);
            if (this.Pathfind < 4)
            {
                if (this.Grounded && !this.Walking)
                {
                    this.RStep = 1;
                    this.LStep = 3;
                }
                if (!Physics.Raycast(this.LocalView.position, this.LocalView.forward, out hit, RayLV * 0.75f, (int) this.targetLayers))
                {
                    this.LocalWaypoint.position = this.LocalView.position;
                    this.LocalWaypoint.rotation = this.LocalView.rotation;
                    this.LocalWaypoint.Translate(Vector3.forward * 15);
                    this.Break1 = 60;
                    if (!this.IEcstatic && (this.Ogle < 1))
                    {
                        this.target = this.LocalWaypoint;
                        this.Walking = true;
                    }
                }
                else
                {
                    this.Pathfind = 30;
                }
                this.LeftNum = 0;
                this.RightNum = 0;
            }
            else
            {
                if (!Physics.Raycast(this.LocalView.position, this.LocalView.forward, out hit, RayLV * 0.75f, (int) this.targetLayers))
                {
                    if (this.Obstacle > 0)
                    {
                        this.Obstacle = this.Obstacle - 1;
                    }
                }
                else
                {
                    if (this.Obstacle < 80)
                    {
                        this.Obstacle = this.Obstacle + 4;
                    }
                }
                Debug.DrawRay(this.LocalView.position + ((this.LocalView.forward * RayLV) * 0.5f), -this.LocalView.up * 1, Color.white);
                if (!Physics.Raycast(this.LocalView.position + ((this.LocalView.forward * RayLV) * 0.5f), -this.LocalView.up, out hit, 1, (int) this.targetLayers))
                {
                    if (this.Obstacle < 80)
                    {
                        this.Obstacle = this.Obstacle + 8;
                    }
                }
                if (this.Obstacle > 80)
                {
                    this.RightDist = 0.1f;
                    this.LeftDist = 0.1f;
                }
                if (this.Obstacle > 60)
                {
                    if (this.VelClamp == 0.5f)
                    {
                        this.RightDist = 0.1f;
                        this.LeftDist = 0.1f;
                    }
                }
                if ((this.RightDist == 0.1f) && (this.LeftDist == 0.1f))
                {

                    {
                        float _3036 = this.LocalView.localEulerAngles.y + 1.5f;
                        Vector3 _3037 = this.LocalView.localEulerAngles;
                        _3037.y = _3036;
                        this.LocalView.localEulerAngles = _3037;
                    }
                }
                if (!this.FreeRoam)
                {
                    if ((this.LeftDist == this.RightDist) && (this.Obstacle < 1))
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.Waypoint.position) > 50)
                        {
                            this.NewRotation2 = Quaternion.LookRotation(this.Waypoint.position - this.LocalView.position);
                            this.LocalView.rotation = Quaternion.RotateTowards(this.LocalView.rotation, this.NewRotation2, 1);

                            {
                                int _3038 = 0;
                                Vector3 _3039 = this.LocalView.localEulerAngles;
                                _3039.x = _3038;
                                this.LocalView.localEulerAngles = _3039;
                            }

                            {
                                int _3040 = 0;
                                Vector3 _3041 = this.LocalView.localEulerAngles;
                                _3041.z = _3040;
                                this.LocalView.localEulerAngles = _3041;
                            }
                        }
                        if (this.eventualTarget)
                        {
                            if (this.Anger > 5)
                            {
                                this.NewRotation2 = Quaternion.LookRotation(this.eventualTarget.position - this.LocalView.position);
                                this.LocalView.rotation = Quaternion.RotateTowards(this.LocalView.rotation, this.NewRotation2, 1);

                                {
                                    int _3042 = 0;
                                    Vector3 _3043 = this.LocalView.localEulerAngles;
                                    _3043.x = _3042;
                                    this.LocalView.localEulerAngles = _3043;
                                }

                                {
                                    int _3044 = 0;
                                    Vector3 _3045 = this.LocalView.localEulerAngles;
                                    _3045.z = _3044;
                                    this.LocalView.localEulerAngles = _3045;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if ((this.LeftDist == this.RightDist) && (this.Obstacle < 1))
                    {
                        if (this.Leader)
                        {
                            if (Vector3.Distance(this.thisTransform.position, this.Waypoint.position) > 8)
                            {
                                this.NewRotation2 = Quaternion.LookRotation(this.Waypoint.position - this.LocalView.position);
                                this.LocalView.rotation = Quaternion.RotateTowards(this.LocalView.rotation, this.NewRotation2, 1);

                                {
                                    int _3046 = 0;
                                    Vector3 _3047 = this.LocalView.localEulerAngles;
                                    _3047.x = _3046;
                                    this.LocalView.localEulerAngles = _3047;
                                }

                                {
                                    int _3048 = 0;
                                    Vector3 _3049 = this.LocalView.localEulerAngles;
                                    _3049.z = _3048;
                                    this.LocalView.localEulerAngles = _3049;
                                }
                            }
                        }
                        if (this.eventualTarget)
                        {
                            if (this.Anger > 5)
                            {
                                this.NewRotation2 = Quaternion.LookRotation(this.eventualTarget.position - this.LocalView.position);
                                this.LocalView.rotation = Quaternion.RotateTowards(this.LocalView.rotation, this.NewRotation2, 1);

                                {
                                    int _3050 = 0;
                                    Vector3 _3051 = this.LocalView.localEulerAngles;
                                    _3051.x = _3050;
                                    this.LocalView.localEulerAngles = _3051;
                                }

                                {
                                    int _3052 = 0;
                                    Vector3 _3053 = this.LocalView.localEulerAngles;
                                    _3053.z = _3052;
                                    this.LocalView.localEulerAngles = _3053;
                                }
                            }
                        }
                    }
                }
            }
            if (this.Pathfind > 0)
            {
                this.Pathfind = this.Pathfind - 1;
            }
        }
        else
        {
            this.RestlessLegs = this.RestlessLegs + 1;
            if (this.RestlessLegs > 300)
            {
                this.RestlessLegs = 0;
                if (this.Grounded && !this.Walking)
                {
                    this.RStep = 1;
                    this.LStep = 3;
                }
                if (!Physics.Raycast(this.LocalView.position, this.LocalView.forward, out hit, RayLV * 0.75f, (int) this.targetLayers))
                {
                    this.LocalWaypoint.position = this.LocalView.position;
                    this.LocalWaypoint.rotation = this.LocalView.rotation;
                    this.LocalWaypoint.Translate(Vector3.forward * 15);
                    this.Break1 = 60;
                    if (!this.IEcstatic && (this.Ogle < 1))
                    {
                        this.target = this.LocalWaypoint;
                        this.Walking = true;
                    }
                }
                else
                {
                    this.Pathfind = 30;
                }
                this.LeftNum = 0;
                this.RightNum = 0;
            }
        }
        if ((this.Pathfind == 0) && this.Walking)
        {
            this.Pathfind = 240;
        }
        //(StateSetters)===============================================================
        if (!this.Sitting)
        {
            if (this.Walking)
            {
                if (this.Grounded)
                {
                    if (this.VelClamp < 0.6f)
                    {
                        if (this.Break1 < 1)
                        {
                            if (this.Anger > 0)
                            {
                                if (this.Obscured)
                                {
                                    this.Walking = false;
                                }
                            }
                            else
                            {
                                this.Walking = false;
                            }
                        }
                        else
                        {
                            if ((this.Obstacle < 1) && (this.Ogle < 1))
                            {
                                this.Walking = true;
                            }
                        }
                        if (this.Break1 > 0)
                        {
                            this.Break1 = this.Break1 - 1;
                        }
                        if (!this.AimStance)
                        {
                            this.AniStand();
                        }
                        else
                        {
                            this.AniAimStand();
                        }
                    }
                    else
                    {
                        if (this.Break1 > 0)
                        {
                            this.Break1 = this.Break1 - 1;
                        }
                        this.AniWalk();
                    }
                }
            }
            else
            {
                if (!this.AimStance)
                {
                    this.AniStand();
                }
                else
                {
                    this.AniAimStand();
                }
            }
        }
        //(ActionSetters)===============================================================
        if (!this.Sitting)
        {
            if (this.Walking)
            {
                if (this.Anger < 11)
                {
                    if ((this.Anger > 0) && !this.Obscured)
                    {
                        this.Walking = false;
                    }
                    this.Gun.Firing = false;
                }
                else
                {
                    if ((this.FuckingRead < 8) && !this.NoShoot)
                    {
                        this.Gun.Firing = true;
                    }
                    else
                    {
                        this.Gun.Firing = false;
                    }
                }
                if ((this.Anger > 5) && (this.RPClamp < 0.5f))
                {
                    if (!this.Obscured)
                    {
                        this.Walking = false;
                    }
                    this.AimStance = true;
                }
            }
            else
            {
                if (this.Anger < 11)
                {
                    this.Gun.Firing = false;
                }
                else
                {
                    if ((this.FuckingRead < 8) && !this.NoShoot)
                    {
                        this.Gun.Firing = true;
                    }
                    else
                    {
                        this.Gun.Firing = false;
                    }
                }
                if (this.Anger > 1)
                {
                    if ((this.RestlessLegs > 120) && (this.Ogle < 1))
                    {
                        if (this.RPClamp > 0.5f)
                        {
                            this.RestlessLegs = 0;
                            this.Walking = true;
                        }
                        else
                        {
                            if (!this.Obscured)
                            {
                                this.Walking = false;
                                this.AimStance = true;
                            }
                            else
                            {
                                this.RestlessLegs = 0;
                                this.Walking = true;
                            }
                        }
                    }
                }
                if (this.Anger < 1)
                {
                    this.AimStance = false;
                }
            }
        }
        //[MovementMechanism]=================================================================================================================
        if (this.Walking)
        {
            if (this.movementClock1 < 60)
            {
                this.movementClock1 = this.movementClock1 + (1 * this.LocoSpeed);
            }
            else
            {
                this.movementClock1 = 0;
                this.movementClock2 = 30;
            }
            if (this.movementClock2 < 60)
            {
                this.movementClock2 = this.movementClock2 + (1 * this.LocoSpeed);
            }
            else
            {
                this.movementClock2 = 0;
                this.movementClock1 = 30;
            }
            if (!this.Running)
            {
                this.LocoSpeed = this.VelClamp * 0.45f;

                {
                    float _3054 = this.torsoCurve.Evaluate(this.movementClock1);
                    Vector3 _3055 = this.GTorso.localEulerAngles;
                    _3055.y = _3054;
                    this.GTorso.localEulerAngles = _3055;
                }

                {
                    float _3056 = this.femurCurve.Evaluate(this.movementClock1);
                    Vector3 _3057 = this.GRFemur.localEulerAngles;
                    _3057.x = _3056;
                    this.GRFemur.localEulerAngles = _3057;
                }

                {
                    float _3058 = this.femurCurve.Evaluate(this.movementClock2);
                    Vector3 _3059 = this.GLFemur.localEulerAngles;
                    _3059.x = _3058;
                    this.GLFemur.localEulerAngles = _3059;
                }

                {
                    float _3060 = this.tibiaCurve.Evaluate(this.movementClock1);
                    Vector3 _3061 = this.GRTibia.localEulerAngles;
                    _3061.x = _3060;
                    this.GRTibia.localEulerAngles = _3061;
                }

                {
                    float _3062 = this.tibiaCurve.Evaluate(this.movementClock2);
                    Vector3 _3063 = this.GLTibia.localEulerAngles;
                    _3063.x = _3062;
                    this.GLTibia.localEulerAngles = _3063;
                }
            }
            else
            {

                {
                    float _3064 = this.torsoCurveR.Evaluate(this.movementClock1);
                    Vector3 _3065 = this.GTorso.localEulerAngles;
                    _3065.y = _3064;
                    this.GTorso.localEulerAngles = _3065;
                }
                if (this.VelClamp < 3)
                {
                    this.LocoSpeed = this.VelClamp * 0.45f;

                    {
                        float _3066 = this.femurCurve.Evaluate(this.movementClock1);
                        Vector3 _3067 = this.GRFemur.localEulerAngles;
                        _3067.x = _3066;
                        this.GRFemur.localEulerAngles = _3067;
                    }

                    {
                        float _3068 = this.femurCurve.Evaluate(this.movementClock2);
                        Vector3 _3069 = this.GLFemur.localEulerAngles;
                        _3069.x = _3068;
                        this.GLFemur.localEulerAngles = _3069;
                    }

                    {
                        float _3070 = this.tibiaCurve.Evaluate(this.movementClock1);
                        Vector3 _3071 = this.GRTibia.localEulerAngles;
                        _3071.x = _3070;
                        this.GRTibia.localEulerAngles = _3071;
                    }

                    {
                        float _3072 = this.tibiaCurve.Evaluate(this.movementClock2);
                        Vector3 _3073 = this.GLTibia.localEulerAngles;
                        _3073.x = _3072;
                        this.GLTibia.localEulerAngles = _3073;
                    }
                }
                else
                {
                    this.LocoSpeed = this.VelClamp * 0.3f;

                    {
                        float _3074 = this.femurCurveR.Evaluate(this.movementClock1);
                        Vector3 _3075 = this.GRFemur.localEulerAngles;
                        _3075.x = _3074;
                        this.GRFemur.localEulerAngles = _3075;
                    }

                    {
                        float _3076 = this.femurCurveR.Evaluate(this.movementClock2);
                        Vector3 _3077 = this.GLFemur.localEulerAngles;
                        _3077.x = _3076;
                        this.GLFemur.localEulerAngles = _3077;
                    }

                    {
                        float _3078 = this.tibiaCurveR.Evaluate(this.movementClock1);
                        Vector3 _3079 = this.GRTibia.localEulerAngles;
                        _3079.x = _3078;
                        this.GRTibia.localEulerAngles = _3079;
                    }

                    {
                        float _3080 = this.tibiaCurveR.Evaluate(this.movementClock2);
                        Vector3 _3081 = this.GLTibia.localEulerAngles;
                        _3081.x = _3080;
                        this.GLTibia.localEulerAngles = _3081;
                    }
                }
            }
            if (!this.Holding)
            {
                if (!this.Running)
                {
                    this.LocoSpeed = this.VelClamp * 0.45f;

                    {
                        float _3082 = this.humerusCurve.Evaluate(this.movementClock1);
                        Vector3 _3083 = this.GRHumerus.localEulerAngles;
                        _3083.z = _3082;
                        this.GRHumerus.localEulerAngles = _3083;
                    }

                    {
                        float _3084 = -this.humerusCurve.Evaluate(this.movementClock2);
                        Vector3 _3085 = this.GLHumerus.localEulerAngles;
                        _3085.z = _3084;
                        this.GLHumerus.localEulerAngles = _3085;
                    }

                    {
                        float _3086 = this.radiusCurve.Evaluate(this.movementClock1);
                        Vector3 _3087 = this.GRRadius.localEulerAngles;
                        _3087.z = _3086;
                        this.GRRadius.localEulerAngles = _3087;
                    }

                    {
                        float _3088 = -this.radiusCurve.Evaluate(this.movementClock2);
                        Vector3 _3089 = this.GLRadius.localEulerAngles;
                        _3089.z = _3088;
                        this.GLRadius.localEulerAngles = _3089;
                    }
                }
                else
                {
                    this.LocoSpeed = this.VelClamp * 0.3f;

                    {
                        float _3090 = this.humerusCurveR.Evaluate(this.movementClock1);
                        Vector3 _3091 = this.GRHumerus.localEulerAngles;
                        _3091.z = _3090;
                        this.GRHumerus.localEulerAngles = _3091;
                    }

                    {
                        float _3092 = -this.humerusCurveR.Evaluate(this.movementClock2);
                        Vector3 _3093 = this.GLHumerus.localEulerAngles;
                        _3093.z = _3092;
                        this.GLHumerus.localEulerAngles = _3093;
                    }

                    {
                        float _3094 = this.radiusCurveR.Evaluate(this.movementClock1);
                        Vector3 _3095 = this.GRRadius.localEulerAngles;
                        _3095.z = _3094;
                        this.GRRadius.localEulerAngles = _3095;
                    }

                    {
                        float _3096 = -this.radiusCurveR.Evaluate(this.movementClock2);
                        Vector3 _3097 = this.GLRadius.localEulerAngles;
                        _3097.z = _3096;
                        this.GLRadius.localEulerAngles = _3097;
                    }
                }
            }
        }
        else
        {
            this.movementClock1 = 0;
            this.movementClock2 = 30;
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (ON.Contains("TFC"))
        {
            if (!ON.Contains("TFC5"))
            {
                Vector3 relativePoint = OT.InverseTransformPoint(this.thisTransform.position);
                float RPXabs = Mathf.Abs(relativePoint.x);
                float RPYabs = Mathf.Abs(relativePoint.y);
                if (relativePoint.z < 0)
                {
                    return;
                }
                if ((RPXabs > 4) || (RPYabs > 4))
                {
                    return;
                }
                if (ON.Contains("TFC0a"))
                {
                    this.PissedAtTC0a = this.PissedAtTC0a + 4;
                }
                if (ON.Contains("TFC1"))
                {
                    this.PissedAtTC1 = this.PissedAtTC1 + 4;
                }
                if (ON.Contains("TFC4"))
                {
                    this.PissedAtTC4 = this.PissedAtTC4 + 4;
                }
                if (ON.Contains("TFC7"))
                {
                    this.PissedAtTC7 = this.PissedAtTC7 + 4;
                }
                if (ON.Contains("TFC8"))
                {
                    this.PissedAtTC8 = this.PissedAtTC8 + 4;
                }
                if (ON.Contains("TFC9"))
                {
                    this.PissedAtTC9 = this.PissedAtTC9 + 4;
                }
                if (this.Anger < 120)
                {
                    this.Anger = this.Anger + 10;
                }
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (this.LookingAtLostItem || (this.Force == 0))
        {
            return;
        }
        if (this.target)
        {
            if (this.target.name.Contains("TC"))
            {
                return;
            }
        }
        string ON = other.name;
        Transform OT = other.transform;
        if (ON.Contains("TC"))
        {
            if (!ON.Contains("TC5"))
            {
                if ((this.Ogle > 0) && (this.Anger < 1))
                {
                    this.lookTarget = OT;
                    this.Stranger = OT;
                    if (this.Blyats > 0)
                    {
                        this.StartCoroutine(this.IdiNahui());
                        this.Blyats = 0;
                    }
                    this.Trig.center = new Vector3(0, 0, 0);
                    this.Trig.radius = 25;
                }
                if (this.PissedAtTC0a > 1)
                {
                    if (ON.Contains("TC0a"))
                    {
                        this.lookTarget = OT;
                        this.eventualTarget = OT;
                        if (!Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
                        {
                            this.lookTarget = OT;
                            this.target = OT;
                            this.Obscured = false;
                            this.Trig.center = new Vector3(0, 0, 0);
                            this.Trig.radius = Vector3.Distance(this.thisTransform.position, OT.position);
                        }
                        if (this.PissedAtTC0a > 4)
                        {
                            this.Anger = 60;
                        }
                    }
                }
                if (this.PissedAtTC1 > 1)
                {
                    if (ON.Contains("TC1"))
                    {
                        this.lookTarget = OT;
                        this.eventualTarget = OT;
                        if (!Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
                        {
                            this.lookTarget = OT;
                            this.target = OT;
                            this.Obscured = false;
                            this.Trig.center = new Vector3(0, 0, 0);
                            this.Trig.radius = Vector3.Distance(this.thisTransform.position, OT.position);
                        }
                        if (this.PissedAtTC1 > 4)
                        {
                            this.Anger = 60;
                        }
                    }
                }
                if (this.PissedAtTC3 > 1)
                {
                    if (!ON.Contains("cT"))
                    {
                        if (ON.Contains("TC3"))
                        {
                            this.lookTarget = OT;
                            this.eventualTarget = OT;
                            if (!Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
                            {
                                this.lookTarget = OT;
                                this.target = OT;
                                this.Obscured = false;
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = Vector3.Distance(this.thisTransform.position, OT.position);
                            }
                            if (this.PissedAtTC3 > 4)
                            {
                                this.Anger = 60;
                            }
                        }
                    }
                }
                if (this.PissedAtTC4 > 1)
                {
                    if (ON.Contains("TC4"))
                    {
                        this.lookTarget = OT;
                        this.eventualTarget = OT;
                        if (!Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
                        {
                            this.lookTarget = OT;
                            this.target = OT;
                            this.Obscured = false;
                            this.Trig.center = new Vector3(0, 0, 0);
                            this.Trig.radius = Vector3.Distance(this.thisTransform.position, OT.position);
                        }
                        if (this.PissedAtTC4 > 4)
                        {
                            this.Anger = 60;
                        }
                    }
                }
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC6"))
                    {
                        if (!other.name.Contains("csT"))
                        {
                            this.lookTarget = OT;
                            this.eventualTarget = OT;
                            if (!Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
                            {
                                this.lookTarget = OT;
                                this.target = OT;
                                this.Obscured = false;
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = Vector3.Distance(this.thisTransform.position, OT.position);
                            }
                            this.Anger = 60;
                        }
                    }
                }
                if (this.PissedAtTC7 > 1)
                {
                    if (!ON.Contains("cT"))
                    {
                        if (ON.Contains("TC7"))
                        {
                            this.lookTarget = OT;
                            this.eventualTarget = OT;
                            if (!Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
                            {
                                this.lookTarget = OT;
                                this.target = OT;
                                this.Obscured = false;
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = Vector3.Distance(this.thisTransform.position, OT.position);
                            }
                            if (this.PissedAtTC7 > 4)
                            {
                                this.Anger = 60;
                            }
                        }
                    }
                }
                if (this.PissedAtTC8 > 1)
                {
                    if (!ON.Contains("cT"))
                    {
                        if (ON.Contains("TC8"))
                        {
                            this.lookTarget = OT;
                            this.eventualTarget = OT;
                            if (!Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
                            {
                                this.lookTarget = OT;
                                this.target = OT;
                                this.Obscured = false;
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = Vector3.Distance(this.thisTransform.position, OT.position);
                            }
                            if (this.PissedAtTC8 > 4)
                            {
                                this.Anger = 60;
                            }
                        }
                    }
                }
                if (this.PissedAtTC9 > 1)
                {
                    if (!ON.Contains("cT"))
                    {
                        if (ON.Contains("TC9"))
                        {
                            this.lookTarget = OT;
                            this.eventualTarget = OT;
                            if (!Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
                            {
                                this.lookTarget = OT;
                                this.target = OT;
                                this.Obscured = false;
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = Vector3.Distance(this.thisTransform.position, OT.position);
                            }
                            if (this.PissedAtTC9 > 4)
                            {
                                this.Anger = 60;
                            }
                        }
                    }
                }
            }
        }
        if (ON.Contains("TC5"))
        {
            if (Vector3.Distance(this.thisTransform.position, OT.position) > 1)
            {
                if (this.FreeRoam)
                {
                    if (this.TCCol.name.Contains("sTC5b"))
                    {
                        this.LLotteryNum = 128;
                        this.TCCol.name = "sTC5";
                    }
                    if (!this.Leader)
                    {
                        if (ON.Contains("sTC5l"))
                        {
                            if (this.TCCol.name.Contains("5l"))
                            {
                                OT.name = "sTC5b";
                            }
                            else
                            {
                                this.Leader = OT;
                            }
                        }
                        else
                        {
                            if (!this.TCCol.name.Contains("5l"))
                            {
                                if (this.LLotteryNum == 0)
                                {
                                    if (ON.Contains("sTC5"))
                                    {
                                        OT.name = "sTC5l";
                                    }
                                    this.LLotteryNum = Random.Range(48, 64);
                                }
                            }
                        }
                    }
                }
                if ((this.Ogle > 0) && (this.Anger < 1))
                {
                    this.lookTarget = OT;
                    if (this.Blyats > 0)
                    {
                        this.StartCoroutine(this.Privet());
                        this.Blyats = 0;
                    }
                    this.Trig.center = new Vector3(0, 0, 0);
                    this.Trig.radius = 25;
                }
            }
        }
        if (this.Favourite1 == null)
        {
            if (ON.Contains("Vodka"))
            {
                if (Vector3.Distance(this.thisTransform.position, OT.position) < 6)
                {
                    this.Favourite1 = OT;
                    this.ResetView.position = OT.position;
                    this.lookTarget = other.gameObject.transform;
                    this.Ogle = 0;
                }
            }
        }
        if (this.Possession1 == null)
        {
            if (ON.Contains("BK"))
            {
                if (Vector3.Distance(this.thisTransform.position, OT.position) < 6)
                {
                    this.Possession1 = OT;
                    this.ResetView.position = OT.position;
                    this.lookTarget = other.gameObject.transform;
                    this.Ogle = 0;
                }
            }
        }
        if (this.Possession2 == null)
        {
            if (ON.Contains("Slav_Radio"))
            {
                if (Vector3.Distance(this.thisTransform.position, OT.position) < 6)
                {
                    this.Possession2 = OT;
                    this.ResetView.position = OT.position;
                    this.lookTarget = other.gameObject.transform;
                    this.Ogle = 0;
                }
            }
        }
    }

    public virtual void AniStand()
    {
        if (!this.StandOnce)
        {
            this.StandOnce = true;
            this.Holding = false;
            if (this.GunGO.activeSelf)
            {
                this.GunGO.SetActive(false);
                this.UpperBodyAni.CrossFade("PlastStand", 0.3f);
            }
        }
        //(TorsoMovement)===============================================================
        if ((this.GTorso.localEulerAngles.y < 360) && (this.GTorso.localEulerAngles.y > 180))
        {

            {
                float _3098 = this.GTorso.localEulerAngles.y + 1;
                Vector3 _3099 = this.GTorso.localEulerAngles;
                _3099.y = _3098;
                this.GTorso.localEulerAngles = _3099;
            }
        }
        if ((this.GTorso.localEulerAngles.y > 0) && (this.GTorso.localEulerAngles.y < 180))
        {

            {
                float _3100 = this.GTorso.localEulerAngles.y - 1;
                Vector3 _3101 = this.GTorso.localEulerAngles;
                _3101.y = _3100;
                this.GTorso.localEulerAngles = _3101;
            }
        }
        if ((this.GTorso.localEulerAngles.x < 360) && (this.GTorso.localEulerAngles.x > 180))
        {

            {
                float _3102 = this.GTorso.localEulerAngles.x + 1;
                Vector3 _3103 = this.GTorso.localEulerAngles;
                _3103.x = _3102;
                this.GTorso.localEulerAngles = _3103;
            }
        }
        if ((this.GTorso.localEulerAngles.x > 0) && (this.GTorso.localEulerAngles.x < 180))
        {

            {
                float _3104 = this.GTorso.localEulerAngles.x - 1;
                Vector3 _3105 = this.GTorso.localEulerAngles;
                _3105.x = _3104;
                this.GTorso.localEulerAngles = _3105;
            }
        }
        //(LegMovement)===============================================================
        if ((this.GRFemur.localEulerAngles.x < 357) && (this.GRFemur.localEulerAngles.x > 180))
        {

            {
                float _3106 = this.GRFemur.localEulerAngles.x + (1 * this.LocoSpeed);
                Vector3 _3107 = this.GRFemur.localEulerAngles;
                _3107.x = _3106;
                this.GRFemur.localEulerAngles = _3107;
            }
        }
        if ((this.GRFemur.localEulerAngles.x > 3) && (this.GRFemur.localEulerAngles.x < 180))
        {

            {
                float _3108 = this.GRFemur.localEulerAngles.x - (1 * this.LocoSpeed);
                Vector3 _3109 = this.GRFemur.localEulerAngles;
                _3109.x = _3108;
                this.GRFemur.localEulerAngles = _3109;
            }
        }
        if ((this.GLFemur.localEulerAngles.x < 357) && (this.GLFemur.localEulerAngles.x > 180))
        {

            {
                float _3110 = this.GLFemur.localEulerAngles.x + (1 * this.LocoSpeed);
                Vector3 _3111 = this.GLFemur.localEulerAngles;
                _3111.x = _3110;
                this.GLFemur.localEulerAngles = _3111;
            }
        }
        if ((this.GLFemur.localEulerAngles.x > 3) && (this.GLFemur.localEulerAngles.x < 180))
        {

            {
                float _3112 = this.GLFemur.localEulerAngles.x - (1 * this.LocoSpeed);
                Vector3 _3113 = this.GLFemur.localEulerAngles;
                _3113.x = _3112;
                this.GLFemur.localEulerAngles = _3113;
            }
        }
        if ((this.GRTibia.localEulerAngles.x < 360) && (this.GRTibia.localEulerAngles.x > 180))
        {

            {
                float _3114 = this.GRTibia.localEulerAngles.x + (1 * this.LocoSpeed);
                Vector3 _3115 = this.GRTibia.localEulerAngles;
                _3115.x = _3114;
                this.GRTibia.localEulerAngles = _3115;
            }
        }
        if ((this.GRTibia.localEulerAngles.x > 0) && (this.GRTibia.localEulerAngles.x < 180))
        {

            {
                float _3116 = this.GRTibia.localEulerAngles.x - (1 * this.LocoSpeed);
                Vector3 _3117 = this.GRTibia.localEulerAngles;
                _3117.x = _3116;
                this.GRTibia.localEulerAngles = _3117;
            }
        }
        if ((this.GLTibia.localEulerAngles.x < 360) && (this.GLTibia.localEulerAngles.x > 180))
        {

            {
                float _3118 = this.GLTibia.localEulerAngles.x + (1 * this.LocoSpeed);
                Vector3 _3119 = this.GLTibia.localEulerAngles;
                _3119.x = _3118;
                this.GLTibia.localEulerAngles = _3119;
            }
        }
        if ((this.GLTibia.localEulerAngles.x > 0) && (this.GLTibia.localEulerAngles.x < 180))
        {

            {
                float _3120 = this.GLTibia.localEulerAngles.x - (1 * this.LocoSpeed);
                Vector3 _3121 = this.GLTibia.localEulerAngles;
                _3121.x = _3120;
                this.GLTibia.localEulerAngles = _3121;
            }
        }
        if ((this.GRFemur.localEulerAngles.y < 15) || (this.GRFemur.localEulerAngles.y > 270))
        {

            {
                float _3122 = this.GRFemur.localEulerAngles.y + (1 * this.LocoSpeed);
                Vector3 _3123 = this.GRFemur.localEulerAngles;
                _3123.y = _3122;
                this.GRFemur.localEulerAngles = _3123;
            }
        }
        if ((this.GLFemur.localEulerAngles.y > 345) || (this.GLFemur.localEulerAngles.y < 90))
        {

            {
                float _3124 = this.GLFemur.localEulerAngles.y - (1 * this.LocoSpeed);
                Vector3 _3125 = this.GLFemur.localEulerAngles;
                _3125.y = _3124;
                this.GLFemur.localEulerAngles = _3125;
            }
        }
        if ((this.GRFemur.localEulerAngles.z < 5) || (this.GRFemur.localEulerAngles.z > 270))
        {

            {
                float _3126 = this.GRFemur.localEulerAngles.z + (1 * this.LocoSpeed);
                Vector3 _3127 = this.GRFemur.localEulerAngles;
                _3127.z = _3126;
                this.GRFemur.localEulerAngles = _3127;
            }
        }
        if ((this.GLFemur.localEulerAngles.z > 355) || (this.GLFemur.localEulerAngles.z < 90))
        {

            {
                float _3128 = this.GLFemur.localEulerAngles.z - (1 * this.LocoSpeed);
                Vector3 _3129 = this.GLFemur.localEulerAngles;
                _3129.z = _3128;
                this.GLFemur.localEulerAngles = _3129;
            }
        }
        //(ArmMovement)===============================================================
        if ((this.GRHumerus.localEulerAngles.z < 357) && (this.GRHumerus.localEulerAngles.z > 180))
        {

            {
                float _3130 = this.GRHumerus.localEulerAngles.z + (1 * this.LocoSpeed);
                Vector3 _3131 = this.GRHumerus.localEulerAngles;
                _3131.z = _3130;
                this.GRHumerus.localEulerAngles = _3131;
            }
        }
        if ((this.GRHumerus.localEulerAngles.z > 3) && (this.GRHumerus.localEulerAngles.z < 180))
        {

            {
                float _3132 = this.GRHumerus.localEulerAngles.z - (1 * this.LocoSpeed);
                Vector3 _3133 = this.GRHumerus.localEulerAngles;
                _3133.z = _3132;
                this.GRHumerus.localEulerAngles = _3133;
            }
        }
        if ((this.GLHumerus.localEulerAngles.z < 357) && (this.GLHumerus.localEulerAngles.z > 180))
        {

            {
                float _3134 = this.GLHumerus.localEulerAngles.z + (1 * this.LocoSpeed);
                Vector3 _3135 = this.GLHumerus.localEulerAngles;
                _3135.z = _3134;
                this.GLHumerus.localEulerAngles = _3135;
            }
        }
        if ((this.GLHumerus.localEulerAngles.z > 3) && (this.GLHumerus.localEulerAngles.z < 180))
        {

            {
                float _3136 = this.GLHumerus.localEulerAngles.z - (1 * this.LocoSpeed);
                Vector3 _3137 = this.GLHumerus.localEulerAngles;
                _3137.z = _3136;
                this.GLHumerus.localEulerAngles = _3137;
            }
        }
        if ((this.GRRadius.localEulerAngles.z < 360) && (this.GRRadius.localEulerAngles.z > 180))
        {

            {
                float _3138 = this.GRRadius.localEulerAngles.z + (1 * this.LocoSpeed);
                Vector3 _3139 = this.GRRadius.localEulerAngles;
                _3139.z = _3138;
                this.GRRadius.localEulerAngles = _3139;
            }
        }
        if ((this.GRRadius.localEulerAngles.z > 0) && (this.GRRadius.localEulerAngles.z < 180))
        {

            {
                float _3140 = this.GRRadius.localEulerAngles.z - (1 * this.LocoSpeed);
                Vector3 _3141 = this.GRRadius.localEulerAngles;
                _3141.z = _3140;
                this.GRRadius.localEulerAngles = _3141;
            }
        }
        if ((this.GLRadius.localEulerAngles.z < 360) && (this.GLRadius.localEulerAngles.z > 180))
        {

            {
                float _3142 = this.GLRadius.localEulerAngles.z + (1 * this.LocoSpeed);
                Vector3 _3143 = this.GLRadius.localEulerAngles;
                _3143.z = _3142;
                this.GLRadius.localEulerAngles = _3143;
            }
        }
        if ((this.GLRadius.localEulerAngles.z > 0) && (this.GLRadius.localEulerAngles.z < 180))
        {

            {
                float _3144 = this.GLRadius.localEulerAngles.z - (1 * this.LocoSpeed);
                Vector3 _3145 = this.GLRadius.localEulerAngles;
                _3145.z = _3144;
                this.GLRadius.localEulerAngles = _3145;
            }
        }
    }

    public virtual void AniAimStand()
    {
        if (!this.AimGunOnce)
        {
            this.AimGunOnce = true;
            this.Holding = true;
            this.GunGO.SetActive(true);
            if (this.Anger > 5)
            {
                if (!this.Obscured)
                {
                    if (!this.UpperBodyAni.IsPlaying("PlastAimGun"))
                    {
                        this.UpperBodyAni.CrossFade("PlastAimGun", 0.3f);
                        this.AimSpeed = 0.1f;
                    }
                }
                else
                {
                    if (!this.UpperBodyAni.IsPlaying("PlastIdleGun"))
                    {
                        this.UpperBodyAni.CrossFade("PlastIdleGun", 0.3f);
                        this.AimSpeed = 0.1f;
                    }
                }
            }
        }
        else
        {
            if ((this.Anger < 6) && !this.IdleGunOnce)
            {
                this.IdleGunOnce = true;
                if (!this.UpperBodyAni.IsPlaying("PlastIdleGun"))
                {
                    this.UpperBodyAni.CrossFade("PlastIdleGun", 0.3f);
                    this.AimSpeed = 0.1f;
                }
            }
        }
        //(TorsoMovement)===============================================================
        if ((this.Anger > 5) && !this.Obscured)
        {
            if (this.Vert < 0)
            {

                {
                    float _3146 = this.GTorso.localEulerAngles.x + this.VNClamp;
                    Vector3 _3147 = this.GTorso.localEulerAngles;
                    _3147.x = _3146;
                    this.GTorso.localEulerAngles = _3147;
                }
            }
            else
            {

                {
                    float _3148 = this.GTorso.localEulerAngles.x - this.VNClamp;
                    Vector3 _3149 = this.GTorso.localEulerAngles;
                    _3149.x = _3148;
                    this.GTorso.localEulerAngles = _3149;
                }
            }
            if (this.Hori < 0)
            {

                {
                    float _3150 = this.GTorso.localEulerAngles.y - this.HNClamp;
                    Vector3 _3151 = this.GTorso.localEulerAngles;
                    _3151.y = _3150;
                    this.GTorso.localEulerAngles = _3151;
                }
            }
            else
            {

                {
                    float _3152 = this.GTorso.localEulerAngles.y + this.HNClamp;
                    Vector3 _3153 = this.GTorso.localEulerAngles;
                    _3153.y = _3152;
                    this.GTorso.localEulerAngles = _3153;
                }
            }
        }
        else
        {
            if ((this.GTorso.localEulerAngles.y < 360) && (this.GTorso.localEulerAngles.y > 180))
            {

                {
                    float _3154 = this.GTorso.localEulerAngles.y + 1;
                    Vector3 _3155 = this.GTorso.localEulerAngles;
                    _3155.y = _3154;
                    this.GTorso.localEulerAngles = _3155;
                }
            }
            if ((this.GTorso.localEulerAngles.y > 0) && (this.GTorso.localEulerAngles.y < 180))
            {

                {
                    float _3156 = this.GTorso.localEulerAngles.y - 1;
                    Vector3 _3157 = this.GTorso.localEulerAngles;
                    _3157.y = _3156;
                    this.GTorso.localEulerAngles = _3157;
                }
            }
            if ((this.GTorso.localEulerAngles.x < 360) && (this.GTorso.localEulerAngles.x > 180))
            {

                {
                    float _3158 = this.GTorso.localEulerAngles.x + 1;
                    Vector3 _3159 = this.GTorso.localEulerAngles;
                    _3159.x = _3158;
                    this.GTorso.localEulerAngles = _3159;
                }
            }
            if ((this.GTorso.localEulerAngles.x > 0) && (this.GTorso.localEulerAngles.x < 180))
            {

                {
                    float _3160 = this.GTorso.localEulerAngles.x - 1;
                    Vector3 _3161 = this.GTorso.localEulerAngles;
                    _3161.x = _3160;
                    this.GTorso.localEulerAngles = _3161;
                }
            }
        }
        if ((this.GTorso.localEulerAngles.x > 45) && (this.GTorso.localEulerAngles.x < 180))
        {

            {
                int _3162 = 45;
                Vector3 _3163 = this.GTorso.localEulerAngles;
                _3163.x = _3162;
                this.GTorso.localEulerAngles = _3163;
            }
        }
        if ((this.GTorso.localEulerAngles.x < 315) && (this.GTorso.localEulerAngles.x > 180))
        {

            {
                int _3164 = 315;
                Vector3 _3165 = this.GTorso.localEulerAngles;
                _3165.x = _3164;
                this.GTorso.localEulerAngles = _3165;
            }
        }
        if ((this.GTorso.localEulerAngles.y > 30) && (this.GTorso.localEulerAngles.y < 180))
        {

            {
                int _3166 = 30;
                Vector3 _3167 = this.GTorso.localEulerAngles;
                _3167.y = _3166;
                this.GTorso.localEulerAngles = _3167;
            }
        }
        if ((this.GTorso.localEulerAngles.y < 330) && (this.GTorso.localEulerAngles.y > 180))
        {

            {
                int _3168 = 330;
                Vector3 _3169 = this.GTorso.localEulerAngles;
                _3169.y = _3168;
                this.GTorso.localEulerAngles = _3169;
            }
        }
        //(LegMovement)===============================================================
        if ((this.GRFemur.localEulerAngles.x < 10) || (this.GRFemur.localEulerAngles.x > 180))
        {

            {
                float _3170 = this.GRFemur.localEulerAngles.x + 1;
                Vector3 _3171 = this.GRFemur.localEulerAngles;
                _3171.x = _3170;
                this.GRFemur.localEulerAngles = _3171;
            }
        }
        if ((this.GRFemur.localEulerAngles.x > 10) && (this.GRFemur.localEulerAngles.x < 180))
        {

            {
                float _3172 = this.GRFemur.localEulerAngles.x - 1;
                Vector3 _3173 = this.GRFemur.localEulerAngles;
                _3173.x = _3172;
                this.GRFemur.localEulerAngles = _3173;
            }
        }
        if ((this.GLFemur.localEulerAngles.x > 350) || (this.GLFemur.localEulerAngles.x < 180))
        {

            {
                float _3174 = this.GLFemur.localEulerAngles.x - 1;
                Vector3 _3175 = this.GLFemur.localEulerAngles;
                _3175.x = _3174;
                this.GLFemur.localEulerAngles = _3175;
            }
        }
        if ((this.GLFemur.localEulerAngles.x < 350) && (this.GLFemur.localEulerAngles.x > 180))
        {

            {
                float _3176 = this.GLFemur.localEulerAngles.x + 1;
                Vector3 _3177 = this.GLFemur.localEulerAngles;
                _3177.x = _3176;
                this.GLFemur.localEulerAngles = _3177;
            }
        }
        if ((this.GRTibia.localEulerAngles.x < 360) && (this.GRTibia.localEulerAngles.x > 180))
        {

            {
                float _3178 = this.GRTibia.localEulerAngles.x + 1;
                Vector3 _3179 = this.GRTibia.localEulerAngles;
                _3179.x = _3178;
                this.GRTibia.localEulerAngles = _3179;
            }
        }
        if ((this.GRTibia.localEulerAngles.x > 0) && (this.GRTibia.localEulerAngles.x < 180))
        {

            {
                float _3180 = this.GRTibia.localEulerAngles.x - 1;
                Vector3 _3181 = this.GRTibia.localEulerAngles;
                _3181.x = _3180;
                this.GRTibia.localEulerAngles = _3181;
            }
        }
        if ((this.GLTibia.localEulerAngles.x < 360) && (this.GLTibia.localEulerAngles.x > 180))
        {

            {
                float _3182 = this.GLTibia.localEulerAngles.x + 1;
                Vector3 _3183 = this.GLTibia.localEulerAngles;
                _3183.x = _3182;
                this.GLTibia.localEulerAngles = _3183;
            }
        }
        if ((this.GLTibia.localEulerAngles.x > 0) && (this.GLTibia.localEulerAngles.x < 180))
        {

            {
                float _3184 = this.GLTibia.localEulerAngles.x - 1;
                Vector3 _3185 = this.GLTibia.localEulerAngles;
                _3185.x = _3184;
                this.GLTibia.localEulerAngles = _3185;
            }
        }
        if ((this.GRFemur.localEulerAngles.y < 45) || (this.GRFemur.localEulerAngles.y > 270))
        {

            {
                float _3186 = this.GRFemur.localEulerAngles.y + 1;
                Vector3 _3187 = this.GRFemur.localEulerAngles;
                _3187.y = _3186;
                this.GRFemur.localEulerAngles = _3187;
            }
        }
        if ((this.GLFemur.localEulerAngles.y > 360) || (this.GLFemur.localEulerAngles.y < 90))
        {

            {
                float _3188 = this.GLFemur.localEulerAngles.y - 1;
                Vector3 _3189 = this.GLFemur.localEulerAngles;
                _3189.y = _3188;
                this.GLFemur.localEulerAngles = _3189;
            }
        }
        if ((this.GLFemur.localEulerAngles.y < 360) && (this.GLFemur.localEulerAngles.y > 180))
        {

            {
                float _3190 = this.GLFemur.localEulerAngles.y + 1;
                Vector3 _3191 = this.GLFemur.localEulerAngles;
                _3191.y = _3190;
                this.GLFemur.localEulerAngles = _3191;
            }
        }
        if ((this.GRFemur.localEulerAngles.z < 5) || (this.GRFemur.localEulerAngles.z > 270))
        {

            {
                float _3192 = this.GRFemur.localEulerAngles.z + 1;
                Vector3 _3193 = this.GRFemur.localEulerAngles;
                _3193.z = _3192;
                this.GRFemur.localEulerAngles = _3193;
            }
        }
    }

    public virtual void AniWalk()
    {
        if (!this.WalkOnce)
        {
            this.WalkOnce = true;
        }
        if (this.Holding)
        {
            if (!this.UpperBodyAni.IsPlaying("PlastIdleGun"))
            {
                this.UpperBodyAni.CrossFade("PlastIdleGun", 0.3f);
            }
        }
        if (this.Running)
        {
            if ((this.GTorso.localEulerAngles.x < 14) || (this.GTorso.localEulerAngles.x > 180))
            {

                {
                    float _3194 = this.GTorso.localEulerAngles.x + 1;
                    Vector3 _3195 = this.GTorso.localEulerAngles;
                    _3195.x = _3194;
                    this.GTorso.localEulerAngles = _3195;
                }
            }
            if ((this.GTorso.localEulerAngles.x > 16) && (this.GTorso.localEulerAngles.x < 180))
            {

                {
                    float _3196 = this.GTorso.localEulerAngles.x - 1;
                    Vector3 _3197 = this.GTorso.localEulerAngles;
                    _3197.x = _3196;
                    this.GTorso.localEulerAngles = _3197;
                }
            }
        }
        else
        {
            if ((this.GTorso.localEulerAngles.x < 360) && (this.GTorso.localEulerAngles.x > 180))
            {

                {
                    float _3198 = this.GTorso.localEulerAngles.x + 1;
                    Vector3 _3199 = this.GTorso.localEulerAngles;
                    _3199.x = _3198;
                    this.GTorso.localEulerAngles = _3199;
                }
            }
            if ((this.GTorso.localEulerAngles.x > 0) && (this.GTorso.localEulerAngles.x < 180))
            {

                {
                    float _3200 = this.GTorso.localEulerAngles.x - 1;
                    Vector3 _3201 = this.GTorso.localEulerAngles;
                    _3201.x = _3200;
                    this.GTorso.localEulerAngles = _3201;
                }
            }
        }
        if ((this.GRFemur.localEulerAngles.y < 0) || (this.GRFemur.localEulerAngles.y < 180))
        {

            {
                float _3202 = this.GRFemur.localEulerAngles.y - (1 * this.LocoSpeed);
                Vector3 _3203 = this.GRFemur.localEulerAngles;
                _3203.y = _3202;
                this.GRFemur.localEulerAngles = _3203;
            }
        }
        if ((this.GLFemur.localEulerAngles.y > 360) || (this.GLFemur.localEulerAngles.y > 180))
        {

            {
                float _3204 = this.GLFemur.localEulerAngles.y + (1 * this.LocoSpeed);
                Vector3 _3205 = this.GLFemur.localEulerAngles;
                _3205.y = _3204;
                this.GLFemur.localEulerAngles = _3205;
            }
        }
        if ((this.GRFemur.localEulerAngles.z < 0) || (this.GRFemur.localEulerAngles.z < 180))
        {

            {
                float _3206 = this.GRFemur.localEulerAngles.z - (1 * this.LocoSpeed);
                Vector3 _3207 = this.GRFemur.localEulerAngles;
                _3207.z = _3206;
                this.GRFemur.localEulerAngles = _3207;
            }
        }
        if ((this.GLFemur.localEulerAngles.z > 360) || (this.GLFemur.localEulerAngles.z > 180))
        {

            {
                float _3208 = this.GLFemur.localEulerAngles.z + (1 * this.LocoSpeed);
                Vector3 _3209 = this.GLFemur.localEulerAngles;
                _3209.z = _3208;
                this.GLFemur.localEulerAngles = _3209;
            }
        }
    }

    public virtual IEnumerator IdiNahui()
    {
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<AudioSource>().PlayOneShot(this.Blyat1);
    }

    public virtual IEnumerator Ura()
    {
        yield return new WaitForSeconds(1);
        this.Fidgeting = true;
        this.Force = 1;
    }

    public virtual IEnumerator Privet()
    {
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<AudioSource>().PlayOneShot(this.Cyka1);
    }

    public virtual IEnumerator Ebanytii()
    {
        yield return new WaitForSeconds(2);
        this.Fidgeting = true;
        this.Force = 8;
        this.GetComponent<AudioSource>().PlayOneShot(this.Bliin1);
    }

    public virtual void Refresher()
    {
        int Interval = Random.Range(0, 3);
        switch (Interval)
        {
            case 1:
                if (this.Ogle < 10)
                {
                    this.Ogle = this.Ogle + 2;
                }
                break;
        }
        if (this.eventualTarget)
        {
            if (Physics.Linecast(this.thisTransform.position, this.eventualTarget.position, (int) this.MtargetLayers))
            {
                this.Obscured = true;
            }
            else
            {
                this.Obscured = false;
            }
        }
        if ((this.Ogle < 1) && (this.Anger < 1))
        {
            this.lookTarget = this.ResetView;
        }
        if (this.LookingAtLostItem)
        {
            this.LookingAtLostItem = false;
            this.Ogle = 0;
        }
        else
        {
            if (this.Ogle > 0)
            {
                this.Ogle = this.Ogle - 1;
            }
        }
        if (this.Possession1)
        {
            this.Pos1Area = this.Possession1.transform.position;
            if (!this.IHas)
            {
                this.IHas = true;
                this.Blyats = 0;
            }
        }
        if (this.Possession2)
        {
            this.Pos2Area = this.Possession2.transform.position;
            if (!this.IHappy)
            {
                this.IHappy = true;
                this.Blyats = 0;
                this.StartCoroutine(this.Ura());
            }
        }
        if (this.Favourite1)
        {
            this.Fav1Area = this.Favourite1.transform.position;
            if (!this.IEcstatic)
            {
                this.IBliiiiiin = false;
                this.Walking = false;
                this.IEcstatic = true;
                this.Force = 0;
                this.Ogle = 10;
                this.Blyats = 0;
                this.StartCoroutine(this.Ebanytii());
            }
        }
        if ((this.Possession1 == null) && this.IHas)
        {
            this.ResetView.position = this.Pos1Area;
            this.lookTarget = this.ResetView;
            this.IHas = false;
            this.LookingAtLostItem = true;
            this.Fidgeting = false;
            this.Ogle = 10;
            this.Blyats = 1;
        }
        if ((this.Possession2 == null) && this.IHappy)
        {
            this.ResetView.position = this.Pos2Area;
            this.lookTarget = this.ResetView;
            this.IHappy = false;
            this.LookingAtLostItem = true;
            this.Fidgeting = false;
            this.Ogle = 10;
            this.Blyats = 1;
        }
        if ((this.Favourite1 == null) && this.IEcstatic)
        {
            this.ResetView.position = this.Fav1Area;
            this.lookTarget = this.ResetView;
            this.IEcstatic = false;
            this.LookingAtLostItem = true;
            this.Fidgeting = false;
            this.Ogle = 10;
            this.Blyats = 1;
        }
        if (((this.IHas && this.IHappy) && !this.Fidgeting) && !this.IEcstatic)
        {
            this.StartCoroutine(this.Ura());
        }
        if (this.Fidgeting && (this.Force > 0))
        {
            this.ResetView.position = (this.BodyTF.position + (this.BodyTF.up * 1)) + (this.BodyTF.forward * 1);
        }
        if (this.PissedAtTC0a > 0)
        {
            this.PissedAtTC0a = this.PissedAtTC0a - 1;
        }
        if (this.PissedAtTC1 > 0)
        {
            this.PissedAtTC1 = this.PissedAtTC1 - 1;
        }
        if (this.PissedAtTC3 > 0)
        {
            this.PissedAtTC3 = this.PissedAtTC3 - 1;
        }
        if (this.PissedAtTC4 > 0)
        {
            this.PissedAtTC4 = this.PissedAtTC4 - 1;
        }
        if (this.PissedAtTC7 > 0)
        {
            this.PissedAtTC7 = this.PissedAtTC7 - 1;
        }
        if (this.PissedAtTC8 > 0)
        {
            this.PissedAtTC8 = this.PissedAtTC8 - 1;
        }
        if (this.PissedAtTC9 > 0)
        {
            this.PissedAtTC9 = this.PissedAtTC9 - 1;
        }
        if (SlavuicNetwork.TC0aDeathRow > 0)
        {
            this.PissedAtTC0a = 8;
        }
        if (SlavuicNetwork.TC1DeathRow > 0)
        {
            this.PissedAtTC1 = 8;
        }
        if (SlavuicNetwork.TC3DeathRow > 0)
        {
            this.PissedAtTC3 = 8;
        }
        if (SlavuicNetwork.TC4DeathRow > 0)
        {
            this.PissedAtTC4 = 8;
        }
        if (SlavuicNetwork.TC7DeathRow > 0)
        {
            this.PissedAtTC7 = 8;
        }
        if (SlavuicNetwork.TC8DeathRow > 0)
        {
            this.PissedAtTC8 = 8;
        }
        if (SlavuicNetwork.TC9DeathRow > 0)
        {
            this.PissedAtTC9 = 8;
        }
        if (this.Anger > 0)
        {
            this.Anger = this.Anger - 1;
        }
        if (this.Walking)
        {
            if (this.AngVelMod < 0.5f)
            {
                this.Stuckage = this.Stuckage + 1;
            }
            else
            {
                if (this.Stuckage > 0)
                {
                    this.Stuckage = this.Stuckage - 1;
                }
            }
            if (this.Stuckage > 8)
            {

                {
                    float _3210 = this.LocalView.localEulerAngles.y + 180;
                    Vector3 _3211 = this.LocalView.localEulerAngles;
                    _3211.y = _3210;
                    this.LocalView.localEulerAngles = _3211;
                }
                this.Stuckage = 0;
            }
        }
        this.WalkOnce = false;
        if (this.VelClamp < 0.7f)
        {
            this.StandOnce = false;
        }
        this.AimGunOnce = false;
        this.IdleGunOnce = false;
        this.Trig.center = new Vector3(0, 0, 80);
        this.Trig.radius = 100;
        if (NotiScript.PiriNotis)
        {
            if (Vector3.Distance(this.thisTransform.position, PlayerInformation.instance.Pirizuka.position) < 128)
            {
                this.Walking = false;
                this.lookTarget = PlayerInformation.instance.PiriTarget;
                this.target = PlayerInformation.instance.PiriTarget;
                this.Ogle = 10;
                NotiScript.PiriNotis = false;
            }
        }
        if (this.Ogle > 0)
        {
            if (WorldInformation.pSpeech)
            {
                if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < 8)
                {
                    this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText));
                    WorldInformation.pSpeech = null;
                }
            }
        }
        if (this.FreeRoam)
        {
            if (this.TCCol.name.Contains("C5l"))
            {
                this.Leader = null;
            }
            if (this.Leader)
            {
                if (!this.Leader.name.Contains("5l"))
                {
                    this.Leader = null;
                }
            }
            if (this.Leader)
            {
                this.Waypoint.position = this.Leader.position;
            }
            else
            {
                this.Waypoint.position = this.LocalWaypoint.position;
            }
        }
        this.Running = false;
        if (this.FreeRoam)
        {
            if (Vector3.Distance(this.thisTransform.position, this.Waypoint.position) > 16)
            {
                this.Running = true;
            }
        }
        if (this.Running)
        {
            if (Vector3.Distance(this.thisTransform.position, this.Waypoint.position) > 24)
            {
                this.MoveSpeed = 550;
            }
            else
            {
                this.MoveSpeed = 500;
            }
        }
        else
        {
            this.MoveSpeed = 200;
        }
    }

    //========================================================================================================================//
    //////////////////////////////////////////////////////[INTERACTION]/////////////////////////////////////////////////////////
    //========================================================================================================================//
    public int convNum;
    public int boredom;
    public virtual IEnumerator ProcessSpeech(string speech)
    {
        yield return new WaitForSeconds(0.1f);
        if (!!string.IsNullOrEmpty(speech))
        {
            yield break;
        }
        if (this.convNum == 0)
        {
            //===============================================================================
            if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
            {
                this.convNum = 1;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Oh, privet comrade!");
                yield break;
            }
            if (speech.Contains("hello") || speech.Contains("greet"))
            {
                this.convNum = 1;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Yes? And hello.");
                yield break;
            }
            if (speech.Contains("blyat") || speech.Contains("cyka"))
            {
                this.convNum = 1;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Haha! I have never once heard \n a Thilian say that word!");
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 1)
        {
            //===============================================================================
            if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
            {
                this.convNum = 2;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Do you want something?");
                yield break;
            }
            if ((speech.Contains("fuck") || speech.Contains("shit")) || speech.Contains("ass"))
            {
                this.convNum = 2;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("What!?");
                yield break;
            }
            if (speech.Contains("hello") || speech.Contains("greet"))
            {
                this.convNum = 2;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Hello! Now what do you want?");
                yield break;
            }
            if (speech.Contains("blyat") || speech.Contains("cyka"))
            {
                this.convNum = 2;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Yes, yes. Now do you want something?");
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 2)
        {
            //===============================================================================
            if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
            {
                this.convNum = 3;
                this.boredom = 4;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech(". . .");
                yield break;
            }
            if ((speech.Contains("no") || speech.Contains("nah")) || speech.Contains("nvm"))
            {
                this.convNum = 2;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Alright.");
                yield break;
            }
            if ((speech.Contains("fuck") || speech.Contains("shit")) || speech.Contains("ass"))
            {
                this.convNum = 3;
                this.boredom = 4;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Screw you, cyka.");
                yield break;
            }
            if (speech.Contains("hello") || speech.Contains("greet"))
            {
                this.convNum = 3;
                this.boredom = 4;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech(". . .");
                yield break;
            }
            if (speech.Contains("blyat") || speech.Contains("cyka"))
            {
                this.convNum = 3;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Ok, enough games! I'm on patrol duty.");
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum > 0)
        {
            if (this.boredom < 3)
            {
                if (((speech.Contains("bye") || speech.Contains("cya")) || speech.Contains("fare")) || speech.Contains("later"))
                {
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Goodbye.");
                    this.Ogle = 2;
                    yield break;
                }
                if (speech.Contains("help"))
                {
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Well, I don't really have \n time to help you.");
                    this.Ogle = 2;
                    yield break;
                }
            }
            //===============================================================================
            if (speech.Contains("fuck you"))
            {
                this.convNum = 99;
                this.Ogle = 2;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Well fuck you too idi nahui!");
                yield break;
            }
            if (speech.Contains("fuck off"))
            {
                this.convNum = 99;
                this.Ogle = 2;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Ok. Thili nahui");
                yield break;
            }
            if (speech.Contains("go away"))
            {
                this.convNum = 99;
                this.Ogle = 2;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Well then.");
                yield break;
            }
        }
        else
        {
            //===============================================================================
            if (this.boredom < 3)
            {
                if (((speech.Contains("bye") || speech.Contains("cya")) || speech.Contains("fare")) || speech.Contains("later"))
                {
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok.");
                    this.Ogle = 2;
                    yield break;
                }
            }
        }
        yield return new WaitForSeconds(2);
        if (this.boredom == 0)
        {
            this.ReturnSpeech("What?");
        }
        if (this.boredom == 1)
        {
            this.ReturnSpeech("What exactly do you want?");
            this.convNum = 1;
        }
        if (this.boredom == 2)
        {
            this.ReturnSpeech("Just get to the point. \n We can't stay here forever.");
            this.convNum = 1;
        }
        if (this.boredom == 3)
        {
            this.ReturnSpeech("Well, good luck.");
            this.convNum = 4;
            this.Ogle = 4;
        }
        if (this.boredom == 4)
        {
            this.ReturnSpeech("Just go away.");
            this.convNum = 4;
            this.Ogle = 2;
        }
        if (this.boredom == 5)
        {
            this.ReturnSpeech("I told you. Go away!");
            this.convNum = 4;
            this.Ogle = 2;
        }
        if (this.boredom == 6)
        {
            this.ReturnSpeech("If you don't leave now, \n I'll force you to!");
            this.convNum = 4;
            this.Ogle = 2;
        }
        if (this.boredom == 7)
        {
            this.ReturnSpeech("Pizdets!");
            this.convNum = 5;
            this.PissedAtTC1 = 8;
            this.Ogle = 2;
        }
        this.boredom = this.boredom + 1;
    }

    public virtual void ReturnSpeech(string yourText)
    {
        GameObject Load = ((GameObject) Resources.Load("Prefabs/TalkBubble", typeof(GameObject))) as GameObject;
        GameObject TGO = UnityEngine.Object.Instantiate(Load, this.thisTransform.position, Load.transform.rotation);
        TGO.name = "CFC5";
        TalkBubbleScript.myText = yourText;
        ((TalkBubbleScript) TGO.GetComponent(typeof(TalkBubbleScript))).source = this.thisTransform;
    }

    public SlavuicPersonAI()
    {
        this.MoveSpeed = 200;
        this.MoveForce = 1;
        this.LocoSpeed = 1;
        this.StabForce = 1;
        this.RotForce = 1;
        this.TurnForce = 1;
        this.Force = 1;
        this.AimSpeed = 0.1f;
        this.torsoCurve = new AnimationCurve();
        this.femurCurve = new AnimationCurve();
        this.tibiaCurve = new AnimationCurve();
        this.torsoCurveR = new AnimationCurve();
        this.femurCurveR = new AnimationCurve();
        this.tibiaCurveR = new AnimationCurve();
        this.humerusCurve = new AnimationCurve();
        this.radiusCurve = new AnimationCurve();
        this.humerusCurveR = new AnimationCurve();
        this.radiusCurveR = new AnimationCurve();
        this.RayDist = 5;
        this.RaySideDist = 5;
        this.RightDist = 200;
        this.LeftDist = 200;
        this.RStep = 1;
        this.LStep = 1;
        this.StatTurnForce = 1;
    }

}