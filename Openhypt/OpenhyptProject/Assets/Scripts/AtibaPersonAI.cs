using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AtibaPersonAI : MonoBehaviour
{
    public Transform target;
    public Transform eventualTarget;
    public Transform lookTarget;
    public Transform ResetView;
    public Transform LocalView;
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
    public int PissedAtTC2;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC5;
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
    public int Bebs;
    public AudioClip Beb1;
    public AudioClip Bib1;
    public AudioClip Bub1;
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
            if (!hitG.collider.name.Contains("T6B"))
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
    }

    private Quaternion NewRotation;
    private Quaternion NewRotation2;
    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        Vector3 WAV = this.BodyTF.InverseTransformDirection(this.WheelRB.angularVelocity);
        this.AngVelMod = WAV.x * 0.5f;
        float VelClamp = Mathf.Clamp(this.AngVelMod, 0.5f, 8);
        //var localV = BodyTF.InverseTransformDirection(BodyRB.velocity);
        //var LVClamp = Mathf.Clamp(localV.z,0.5,4);
        //var LVClamp2 = Mathf.Clamp(localV.z,2,4);
        Vector3 localAV = this.BodyTF.InverseTransformDirection(this.BodyRB.angularVelocity);
        float RayLV = VelClamp * this.RayDist;
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
                        int _650 = 340;
                        Vector3 _651 = this.HeadTF.localEulerAngles;
                        _651.x = _650;
                        this.HeadTF.localEulerAngles = _651;
                    }
                }
            }
            if (this.HeadTF.localEulerAngles.x < 90)
            {
                if (this.HeadTF.localEulerAngles.x > 40)
                {

                    {
                        int _652 = 40;
                        Vector3 _653 = this.HeadTF.localEulerAngles;
                        _653.x = _652;
                        this.HeadTF.localEulerAngles = _653;
                    }
                }
            }
            if (this.HeadTF.localEulerAngles.z > 30)
            {
                if (this.HeadTF.localEulerAngles.z < 180)
                {

                    {
                        int _654 = 30;
                        Vector3 _655 = this.HeadTF.localEulerAngles;
                        _655.z = _654;
                        this.HeadTF.localEulerAngles = _655;
                    }
                }
            }
            if (this.HeadTF.localEulerAngles.z < 330)
            {
                if (this.HeadTF.localEulerAngles.z > 180)
                {

                    {
                        int _656 = 330;
                        Vector3 _657 = this.HeadTF.localEulerAngles;
                        _657.z = _656;
                        this.HeadTF.localEulerAngles = _657;
                    }
                }
            }
            if ((this.HeadTF.localEulerAngles.y < 300) && (this.HeadTF.localEulerAngles.y > 180))
            {

                {
                    int _658 = 300;
                    Vector3 _659 = this.HeadTF.localEulerAngles;
                    _659.y = _658;
                    this.HeadTF.localEulerAngles = _659;
                }
            }
            if ((this.HeadTF.localEulerAngles.y > 60) && (this.HeadTF.localEulerAngles.y < 180))
            {

                {
                    int _660 = 60;
                    Vector3 _661 = this.HeadTF.localEulerAngles;
                    _661.y = _660;
                    this.HeadTF.localEulerAngles = _661;
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
                            float _662 = this.MoveSpeed;
                            JointMotor _663 = this.WheelJoint.motor;
                            _663.targetVelocity = _662;
                            this.WheelJoint.motor = _663;
                        }

                        {
                            float _664 = this.MoveForce;
                            JointMotor _665 = this.WheelJoint.motor;
                            _665.force = _664;
                            this.WheelJoint.motor = _665;
                        }
                    }
                    else
                    {

                        {
                            float _666 = this.MoveSpeed;
                            JointMotor _667 = this.WheelJoint.motor;
                            _667.targetVelocity = _666;
                            this.WheelJoint.motor = _667;
                        }

                        {
                            int _668 = 0;
                            JointMotor _669 = this.WheelJoint.motor;
                            _669.force = _668;
                            this.WheelJoint.motor = _669;
                        }
                    }
                }
                else
                {

                    {
                        float _670 = this.MoveSpeed;
                        JointMotor _671 = this.WheelJoint.motor;
                        _671.targetVelocity = _670;
                        this.WheelJoint.motor = _671;
                    }

                    {
                        int _672 = 0;
                        JointMotor _673 = this.WheelJoint.motor;
                        _673.force = _672;
                        this.WheelJoint.motor = _673;
                    }
                }
            }
            else
            {
                this.BodyRB.angularDrag = 1;
                this.StabForce = 0.1f;
                this.TurnForce = 0;

                {
                    float _674 = this.MoveSpeed;
                    JointMotor _675 = this.WheelJoint.motor;
                    _675.targetVelocity = _674;
                    this.WheelJoint.motor = _675;
                }

                {
                    int _676 = 0;
                    JointMotor _677 = this.WheelJoint.motor;
                    _677.force = _676;
                    this.WheelJoint.motor = _677;
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
                    float _678 = this.MoveSpeed;
                    JointMotor _679 = this.WheelJoint.motor;
                    _679.targetVelocity = _678;
                    this.WheelJoint.motor = _679;
                }

                {
                    int _680 = 0;
                    JointMotor _681 = this.WheelJoint.motor;
                    _681.force = _680;
                    this.WheelJoint.motor = _681;
                }
            }
            else
            {
                this.BodyRB.angularDrag = 0.1f;
                this.StabForce = 0.1f;
                this.TurnForce = 0;

                {
                    float _682 = this.MoveSpeed;
                    JointMotor _683 = this.WheelJoint.motor;
                    _683.targetVelocity = _682;
                    this.WheelJoint.motor = _683;
                }

                {
                    int _684 = 0;
                    JointMotor _685 = this.WheelJoint.motor;
                    _685.force = _684;
                    this.WheelJoint.motor = _685;
                }
            }
        }
        //[Sitting]=================================================================================================================
        if (this.Pathfind > 0)
        {
            this.LocalView.position = this.HeadTF.position;

            {
                float _686 = this.LocalView.position.y - 2;
                Vector3 _687 = this.LocalView.position;
                _687.y = _686;
                this.LocalView.position = _687;
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
            Debug.DrawRay((this.LocalView.position + (this.LocalView.forward * RayLV)) + (this.LocalView.right * this.RaySideDist), -this.LocalView.up * 0.5f, Color.black);
            if (!Physics.Raycast((this.LocalView.position + (this.LocalView.forward * RayLV)) + (this.LocalView.right * this.RaySideDist), -this.LocalView.up, out hit, 0.5f, (int) this.targetLayers))
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
            Debug.DrawRay((this.LocalView.position + (this.LocalView.forward * RayLV)) + (-this.LocalView.right * this.RaySideDist), -this.LocalView.up * 0.5f, Color.black);
            if (!Physics.Raycast((this.LocalView.position + (this.LocalView.forward * RayLV)) + (-this.LocalView.right * this.RaySideDist), -this.LocalView.up, out hit, 0.5f, (int) this.targetLayers))
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
                    float _688 = this.LocalView.localEulerAngles.y + 1.5f;
                    Vector3 _689 = this.LocalView.localEulerAngles;
                    _689.y = _688;
                    this.LocalView.localEulerAngles = _689;
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
                    float _690 = this.LocalView.localEulerAngles.y - 1.5f;
                    Vector3 _691 = this.LocalView.localEulerAngles;
                    _691.y = _690;
                    this.LocalView.localEulerAngles = _691;
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
                    if (VelClamp == 0.5f)
                    {
                        this.RightDist = 0.1f;
                        this.LeftDist = 0.1f;
                    }
                }
                if ((this.RightDist == 0.1f) && (this.LeftDist == 0.1f))
                {

                    {
                        float _692 = this.LocalView.localEulerAngles.y + 1.5f;
                        Vector3 _693 = this.LocalView.localEulerAngles;
                        _693.y = _692;
                        this.LocalView.localEulerAngles = _693;
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
                                int _694 = 0;
                                Vector3 _695 = this.LocalView.localEulerAngles;
                                _695.x = _694;
                                this.LocalView.localEulerAngles = _695;
                            }

                            {
                                int _696 = 0;
                                Vector3 _697 = this.LocalView.localEulerAngles;
                                _697.z = _696;
                                this.LocalView.localEulerAngles = _697;
                            }
                        }
                        if (this.eventualTarget)
                        {
                            if (this.Anger > 5)
                            {
                                this.NewRotation2 = Quaternion.LookRotation(this.eventualTarget.position - this.LocalView.position);
                                this.LocalView.rotation = Quaternion.RotateTowards(this.LocalView.rotation, this.NewRotation2, 1);

                                {
                                    int _698 = 0;
                                    Vector3 _699 = this.LocalView.localEulerAngles;
                                    _699.x = _698;
                                    this.LocalView.localEulerAngles = _699;
                                }

                                {
                                    int _700 = 0;
                                    Vector3 _701 = this.LocalView.localEulerAngles;
                                    _701.z = _700;
                                    this.LocalView.localEulerAngles = _701;
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
                                    int _702 = 0;
                                    Vector3 _703 = this.LocalView.localEulerAngles;
                                    _703.x = _702;
                                    this.LocalView.localEulerAngles = _703;
                                }

                                {
                                    int _704 = 0;
                                    Vector3 _705 = this.LocalView.localEulerAngles;
                                    _705.z = _704;
                                    this.LocalView.localEulerAngles = _705;
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
                                    int _706 = 0;
                                    Vector3 _707 = this.LocalView.localEulerAngles;
                                    _707.x = _706;
                                    this.LocalView.localEulerAngles = _707;
                                }

                                {
                                    int _708 = 0;
                                    Vector3 _709 = this.LocalView.localEulerAngles;
                                    _709.z = _708;
                                    this.LocalView.localEulerAngles = _709;
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
                    if (VelClamp < 0.6f)
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
                this.LocoSpeed = VelClamp * 0.45f;

                {
                    float _710 = this.torsoCurve.Evaluate(this.movementClock1);
                    Vector3 _711 = this.GTorso.localEulerAngles;
                    _711.y = _710;
                    this.GTorso.localEulerAngles = _711;
                }

                {
                    float _712 = this.femurCurve.Evaluate(this.movementClock1);
                    Vector3 _713 = this.GRFemur.localEulerAngles;
                    _713.x = _712;
                    this.GRFemur.localEulerAngles = _713;
                }

                {
                    float _714 = this.femurCurve.Evaluate(this.movementClock2);
                    Vector3 _715 = this.GLFemur.localEulerAngles;
                    _715.x = _714;
                    this.GLFemur.localEulerAngles = _715;
                }

                {
                    float _716 = this.tibiaCurve.Evaluate(this.movementClock1);
                    Vector3 _717 = this.GRTibia.localEulerAngles;
                    _717.x = _716;
                    this.GRTibia.localEulerAngles = _717;
                }

                {
                    float _718 = this.tibiaCurve.Evaluate(this.movementClock2);
                    Vector3 _719 = this.GLTibia.localEulerAngles;
                    _719.x = _718;
                    this.GLTibia.localEulerAngles = _719;
                }
            }
            else
            {

                {
                    float _720 = this.torsoCurveR.Evaluate(this.movementClock1);
                    Vector3 _721 = this.GTorso.localEulerAngles;
                    _721.y = _720;
                    this.GTorso.localEulerAngles = _721;
                }
                if (VelClamp < 3)
                {
                    this.LocoSpeed = VelClamp * 0.45f;

                    {
                        float _722 = this.femurCurve.Evaluate(this.movementClock1);
                        Vector3 _723 = this.GRFemur.localEulerAngles;
                        _723.x = _722;
                        this.GRFemur.localEulerAngles = _723;
                    }

                    {
                        float _724 = this.femurCurve.Evaluate(this.movementClock2);
                        Vector3 _725 = this.GLFemur.localEulerAngles;
                        _725.x = _724;
                        this.GLFemur.localEulerAngles = _725;
                    }

                    {
                        float _726 = this.tibiaCurve.Evaluate(this.movementClock1);
                        Vector3 _727 = this.GRTibia.localEulerAngles;
                        _727.x = _726;
                        this.GRTibia.localEulerAngles = _727;
                    }

                    {
                        float _728 = this.tibiaCurve.Evaluate(this.movementClock2);
                        Vector3 _729 = this.GLTibia.localEulerAngles;
                        _729.x = _728;
                        this.GLTibia.localEulerAngles = _729;
                    }
                }
                else
                {
                    this.LocoSpeed = VelClamp * 0.3f;

                    {
                        float _730 = this.femurCurveR.Evaluate(this.movementClock1);
                        Vector3 _731 = this.GRFemur.localEulerAngles;
                        _731.x = _730;
                        this.GRFemur.localEulerAngles = _731;
                    }

                    {
                        float _732 = this.femurCurveR.Evaluate(this.movementClock2);
                        Vector3 _733 = this.GLFemur.localEulerAngles;
                        _733.x = _732;
                        this.GLFemur.localEulerAngles = _733;
                    }

                    {
                        float _734 = this.tibiaCurveR.Evaluate(this.movementClock1);
                        Vector3 _735 = this.GRTibia.localEulerAngles;
                        _735.x = _734;
                        this.GRTibia.localEulerAngles = _735;
                    }

                    {
                        float _736 = this.tibiaCurveR.Evaluate(this.movementClock2);
                        Vector3 _737 = this.GLTibia.localEulerAngles;
                        _737.x = _736;
                        this.GLTibia.localEulerAngles = _737;
                    }
                }
            }
            if (!this.Holding)
            {
                if (!this.Running)
                {
                    this.LocoSpeed = VelClamp * 0.45f;

                    {
                        float _738 = this.humerusCurve.Evaluate(this.movementClock1);
                        Vector3 _739 = this.GRHumerus.localEulerAngles;
                        _739.z = _738;
                        this.GRHumerus.localEulerAngles = _739;
                    }

                    {
                        float _740 = -this.humerusCurve.Evaluate(this.movementClock2);
                        Vector3 _741 = this.GLHumerus.localEulerAngles;
                        _741.z = _740;
                        this.GLHumerus.localEulerAngles = _741;
                    }

                    {
                        float _742 = this.radiusCurve.Evaluate(this.movementClock1);
                        Vector3 _743 = this.GRRadius.localEulerAngles;
                        _743.z = _742;
                        this.GRRadius.localEulerAngles = _743;
                    }

                    {
                        float _744 = -this.radiusCurve.Evaluate(this.movementClock2);
                        Vector3 _745 = this.GLRadius.localEulerAngles;
                        _745.z = _744;
                        this.GLRadius.localEulerAngles = _745;
                    }
                }
                else
                {
                    this.LocoSpeed = VelClamp * 0.3f;

                    {
                        float _746 = this.humerusCurveR.Evaluate(this.movementClock1);
                        Vector3 _747 = this.GRHumerus.localEulerAngles;
                        _747.z = _746;
                        this.GRHumerus.localEulerAngles = _747;
                    }

                    {
                        float _748 = -this.humerusCurveR.Evaluate(this.movementClock2);
                        Vector3 _749 = this.GLHumerus.localEulerAngles;
                        _749.z = _748;
                        this.GLHumerus.localEulerAngles = _749;
                    }

                    {
                        float _750 = this.radiusCurveR.Evaluate(this.movementClock1);
                        Vector3 _751 = this.GRRadius.localEulerAngles;
                        _751.z = _750;
                        this.GRRadius.localEulerAngles = _751;
                    }

                    {
                        float _752 = -this.radiusCurveR.Evaluate(this.movementClock2);
                        Vector3 _753 = this.GLRadius.localEulerAngles;
                        _753.z = _752;
                        this.GLRadius.localEulerAngles = _753;
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
            if (!ON.Contains("TFC6"))
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
                if (ON.Contains("TFC2"))
                {
                    this.PissedAtTC2 = this.PissedAtTC2 + 4;
                }
                if (ON.Contains("TFC3"))
                {
                    this.PissedAtTC3 = this.PissedAtTC3 + 4;
                }
                if (ON.Contains("TFC4"))
                {
                    this.PissedAtTC4 = this.PissedAtTC4 + 4;
                }
                if (ON.Contains("TFC5"))
                {
                    this.PissedAtTC5 = this.PissedAtTC5 + 4;
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
            if (!ON.Contains("TC6"))
            {
                if ((this.Ogle > 0) && (this.Anger < 1))
                {
                    this.lookTarget = OT;
                    this.eventualTarget = OT;
                    if (this.Bebs > 0)
                    {
                        this.StartCoroutine(this.Beb());
                        this.Bebs = 0;
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
                if (this.PissedAtTC2 > 1)
                {
                    if (ON.Contains("TC2"))
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
                        if (this.PissedAtTC2 > 4)
                        {
                            this.Anger = 60;
                        }
                    }
                }
                if (this.PissedAtTC3 > 1)
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
                if (ON.Contains("TC5"))
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
                if (this.PissedAtTC7 > 1)
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
                if (this.PissedAtTC8 > 1)
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
                if (this.PissedAtTC9 > 1)
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
        if (ON.Contains("TC6"))
        {
            if (Vector3.Distance(this.thisTransform.position, OT.position) > 1)
            {
                if (this.FreeRoam)
                {
                    if (this.TCCol.name.Contains("sTC6b"))
                    {
                        this.LLotteryNum = 128;
                        this.TCCol.name = "sTC6";
                    }
                    if (!this.Leader)
                    {
                        if (ON.Contains("sTC6l"))
                        {
                            if (this.TCCol.name.Contains("5l"))
                            {
                                OT.name = "sTC6b";
                            }
                            else
                            {
                                this.Leader = OT;
                            }
                        }
                        else
                        {
                            if (!this.TCCol.name.Contains("6l"))
                            {
                                if (this.LLotteryNum == 0)
                                {
                                    if (ON.Contains("sTC6"))
                                    {
                                        OT.name = "sTC6l";
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
                    if (this.Bebs > 0)
                    {
                        this.StartCoroutine(this.Bob());
                        this.Bebs = 0;
                    }
                    this.Trig.center = new Vector3(0, 0, 0);
                    this.Trig.radius = 25;
                }
            }
        }
        if (this.Favourite1 == null)
        {
            if (ON.Contains("Shoosh"))
            {
                if (Vector3.Distance(this.thisTransform.position, OT.position) < 6)
                {
                    this.Favourite1 = OT;
                    this.ResetView.position = OT.position;
                    this.lookTarget = OT;
                    this.Ogle = 0;
                }
            }
        }
        if (this.Possession1 == null)
        {
            if (ON.Contains("Shakar"))
            {
                if (Vector3.Distance(this.thisTransform.position, OT.position) < 6)
                {
                    this.Possession1 = OT;
                    this.ResetView.position = OT.position;
                    this.lookTarget = OT;
                    this.Ogle = 0;
                }
            }
        }
        if (this.Possession2 == null)
        {
            if (ON.Contains("Atiba_Radio"))
            {
                if (Vector3.Distance(this.thisTransform.position, OT.position) < 6)
                {
                    this.Possession2 = OT;
                    this.ResetView.position = OT.position;
                    this.lookTarget = OT;
                    this.Ogle = 0;
                }
            }
        }
    }

    public virtual IEnumerator Beb()
    {
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<AudioSource>().PlayOneShot(this.Beb1);
    }

    public virtual IEnumerator Bob()
    {
        yield return new WaitForSeconds(1);
        this.Fidgeting = true;
        this.Force = 1;
    }

    public virtual IEnumerator Bub()
    {
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<AudioSource>().PlayOneShot(this.Bub1);
    }

    public virtual IEnumerator Bib()
    {
        yield return new WaitForSeconds(2);
        this.Fidgeting = true;
        this.Force = 8;
        this.GetComponent<AudioSource>().PlayOneShot(this.Bib1);
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
                this.UpperBodyAni.CrossFade("Plast2Stand", 0.3f);
            }
        }
        //(TorsoMovement)===============================================================
        if ((this.GTorso.localEulerAngles.y < 360) && (this.GTorso.localEulerAngles.y > 180))
        {

            {
                float _754 = this.GTorso.localEulerAngles.y + 1;
                Vector3 _755 = this.GTorso.localEulerAngles;
                _755.y = _754;
                this.GTorso.localEulerAngles = _755;
            }
        }
        if ((this.GTorso.localEulerAngles.y > 0) && (this.GTorso.localEulerAngles.y < 180))
        {

            {
                float _756 = this.GTorso.localEulerAngles.y - 1;
                Vector3 _757 = this.GTorso.localEulerAngles;
                _757.y = _756;
                this.GTorso.localEulerAngles = _757;
            }
        }
        if ((this.GTorso.localEulerAngles.x < 360) && (this.GTorso.localEulerAngles.x > 180))
        {

            {
                float _758 = this.GTorso.localEulerAngles.x + 1;
                Vector3 _759 = this.GTorso.localEulerAngles;
                _759.x = _758;
                this.GTorso.localEulerAngles = _759;
            }
        }
        if ((this.GTorso.localEulerAngles.x > 0) && (this.GTorso.localEulerAngles.x < 180))
        {

            {
                float _760 = this.GTorso.localEulerAngles.x - 1;
                Vector3 _761 = this.GTorso.localEulerAngles;
                _761.x = _760;
                this.GTorso.localEulerAngles = _761;
            }
        }
        //(LegMovement)===============================================================
        if ((this.GRFemur.localEulerAngles.x < 357) && (this.GRFemur.localEulerAngles.x > 180))
        {

            {
                float _762 = this.GRFemur.localEulerAngles.x + (1 * this.LocoSpeed);
                Vector3 _763 = this.GRFemur.localEulerAngles;
                _763.x = _762;
                this.GRFemur.localEulerAngles = _763;
            }
        }
        if ((this.GRFemur.localEulerAngles.x > 3) && (this.GRFemur.localEulerAngles.x < 180))
        {

            {
                float _764 = this.GRFemur.localEulerAngles.x - (1 * this.LocoSpeed);
                Vector3 _765 = this.GRFemur.localEulerAngles;
                _765.x = _764;
                this.GRFemur.localEulerAngles = _765;
            }
        }
        if ((this.GLFemur.localEulerAngles.x < 357) && (this.GLFemur.localEulerAngles.x > 180))
        {

            {
                float _766 = this.GLFemur.localEulerAngles.x + (1 * this.LocoSpeed);
                Vector3 _767 = this.GLFemur.localEulerAngles;
                _767.x = _766;
                this.GLFemur.localEulerAngles = _767;
            }
        }
        if ((this.GLFemur.localEulerAngles.x > 3) && (this.GLFemur.localEulerAngles.x < 180))
        {

            {
                float _768 = this.GLFemur.localEulerAngles.x - (1 * this.LocoSpeed);
                Vector3 _769 = this.GLFemur.localEulerAngles;
                _769.x = _768;
                this.GLFemur.localEulerAngles = _769;
            }
        }
        if ((this.GRTibia.localEulerAngles.x < 360) && (this.GRTibia.localEulerAngles.x > 180))
        {

            {
                float _770 = this.GRTibia.localEulerAngles.x + (1 * this.LocoSpeed);
                Vector3 _771 = this.GRTibia.localEulerAngles;
                _771.x = _770;
                this.GRTibia.localEulerAngles = _771;
            }
        }
        if ((this.GRTibia.localEulerAngles.x > 0) && (this.GRTibia.localEulerAngles.x < 180))
        {

            {
                float _772 = this.GRTibia.localEulerAngles.x - (1 * this.LocoSpeed);
                Vector3 _773 = this.GRTibia.localEulerAngles;
                _773.x = _772;
                this.GRTibia.localEulerAngles = _773;
            }
        }
        if ((this.GLTibia.localEulerAngles.x < 360) && (this.GLTibia.localEulerAngles.x > 180))
        {

            {
                float _774 = this.GLTibia.localEulerAngles.x + (1 * this.LocoSpeed);
                Vector3 _775 = this.GLTibia.localEulerAngles;
                _775.x = _774;
                this.GLTibia.localEulerAngles = _775;
            }
        }
        if ((this.GLTibia.localEulerAngles.x > 0) && (this.GLTibia.localEulerAngles.x < 180))
        {

            {
                float _776 = this.GLTibia.localEulerAngles.x - (1 * this.LocoSpeed);
                Vector3 _777 = this.GLTibia.localEulerAngles;
                _777.x = _776;
                this.GLTibia.localEulerAngles = _777;
            }
        }
        if ((this.GRFemur.localEulerAngles.y < 15) || (this.GRFemur.localEulerAngles.y > 270))
        {

            {
                float _778 = this.GRFemur.localEulerAngles.y + (1 * this.LocoSpeed);
                Vector3 _779 = this.GRFemur.localEulerAngles;
                _779.y = _778;
                this.GRFemur.localEulerAngles = _779;
            }
        }
        if ((this.GLFemur.localEulerAngles.y > 345) || (this.GLFemur.localEulerAngles.y < 90))
        {

            {
                float _780 = this.GLFemur.localEulerAngles.y - (1 * this.LocoSpeed);
                Vector3 _781 = this.GLFemur.localEulerAngles;
                _781.y = _780;
                this.GLFemur.localEulerAngles = _781;
            }
        }
        if ((this.GRFemur.localEulerAngles.z < 5) || (this.GRFemur.localEulerAngles.z > 270))
        {

            {
                float _782 = this.GRFemur.localEulerAngles.z + (1 * this.LocoSpeed);
                Vector3 _783 = this.GRFemur.localEulerAngles;
                _783.z = _782;
                this.GRFemur.localEulerAngles = _783;
            }
        }
        if ((this.GLFemur.localEulerAngles.z > 355) || (this.GLFemur.localEulerAngles.z < 90))
        {

            {
                float _784 = this.GLFemur.localEulerAngles.z - (1 * this.LocoSpeed);
                Vector3 _785 = this.GLFemur.localEulerAngles;
                _785.z = _784;
                this.GLFemur.localEulerAngles = _785;
            }
        }
        //(ArmMovement)===============================================================
        if ((this.GRHumerus.localEulerAngles.z < 357) && (this.GRHumerus.localEulerAngles.z > 180))
        {

            {
                float _786 = this.GRHumerus.localEulerAngles.z + (1 * this.LocoSpeed);
                Vector3 _787 = this.GRHumerus.localEulerAngles;
                _787.z = _786;
                this.GRHumerus.localEulerAngles = _787;
            }
        }
        if ((this.GRHumerus.localEulerAngles.z > 3) && (this.GRHumerus.localEulerAngles.z < 180))
        {

            {
                float _788 = this.GRHumerus.localEulerAngles.z - (1 * this.LocoSpeed);
                Vector3 _789 = this.GRHumerus.localEulerAngles;
                _789.z = _788;
                this.GRHumerus.localEulerAngles = _789;
            }
        }
        if ((this.GLHumerus.localEulerAngles.z < 357) && (this.GLHumerus.localEulerAngles.z > 180))
        {

            {
                float _790 = this.GLHumerus.localEulerAngles.z + (1 * this.LocoSpeed);
                Vector3 _791 = this.GLHumerus.localEulerAngles;
                _791.z = _790;
                this.GLHumerus.localEulerAngles = _791;
            }
        }
        if ((this.GLHumerus.localEulerAngles.z > 3) && (this.GLHumerus.localEulerAngles.z < 180))
        {

            {
                float _792 = this.GLHumerus.localEulerAngles.z - (1 * this.LocoSpeed);
                Vector3 _793 = this.GLHumerus.localEulerAngles;
                _793.z = _792;
                this.GLHumerus.localEulerAngles = _793;
            }
        }
        if ((this.GRRadius.localEulerAngles.z < 360) && (this.GRRadius.localEulerAngles.z > 180))
        {

            {
                float _794 = this.GRRadius.localEulerAngles.z + (1 * this.LocoSpeed);
                Vector3 _795 = this.GRRadius.localEulerAngles;
                _795.z = _794;
                this.GRRadius.localEulerAngles = _795;
            }
        }
        if ((this.GRRadius.localEulerAngles.z > 0) && (this.GRRadius.localEulerAngles.z < 180))
        {

            {
                float _796 = this.GRRadius.localEulerAngles.z - (1 * this.LocoSpeed);
                Vector3 _797 = this.GRRadius.localEulerAngles;
                _797.z = _796;
                this.GRRadius.localEulerAngles = _797;
            }
        }
        if ((this.GLRadius.localEulerAngles.z < 360) && (this.GLRadius.localEulerAngles.z > 180))
        {

            {
                float _798 = this.GLRadius.localEulerAngles.z + (1 * this.LocoSpeed);
                Vector3 _799 = this.GLRadius.localEulerAngles;
                _799.z = _798;
                this.GLRadius.localEulerAngles = _799;
            }
        }
        if ((this.GLRadius.localEulerAngles.z > 0) && (this.GLRadius.localEulerAngles.z < 180))
        {

            {
                float _800 = this.GLRadius.localEulerAngles.z - (1 * this.LocoSpeed);
                Vector3 _801 = this.GLRadius.localEulerAngles;
                _801.z = _800;
                this.GLRadius.localEulerAngles = _801;
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
                    if (!this.UpperBodyAni.IsPlaying("Plast2AimGun"))
                    {
                        this.UpperBodyAni.CrossFade("Plast2AimGun", 0.3f);
                        this.AimSpeed = 0.1f;
                    }
                }
                else
                {
                    if (!this.UpperBodyAni.IsPlaying("Plast2IdleGun"))
                    {
                        this.UpperBodyAni.CrossFade("Plast2IdleGun", 0.3f);
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
                if (!this.UpperBodyAni.IsPlaying("Plast2IdleGun"))
                {
                    this.UpperBodyAni.CrossFade("Plast2IdleGun", 0.3f);
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
                    float _802 = this.GTorso.localEulerAngles.x + this.VNClamp;
                    Vector3 _803 = this.GTorso.localEulerAngles;
                    _803.x = _802;
                    this.GTorso.localEulerAngles = _803;
                }
            }
            else
            {

                {
                    float _804 = this.GTorso.localEulerAngles.x - this.VNClamp;
                    Vector3 _805 = this.GTorso.localEulerAngles;
                    _805.x = _804;
                    this.GTorso.localEulerAngles = _805;
                }
            }
            if (this.Hori < 0)
            {

                {
                    float _806 = this.GTorso.localEulerAngles.y - this.HNClamp;
                    Vector3 _807 = this.GTorso.localEulerAngles;
                    _807.y = _806;
                    this.GTorso.localEulerAngles = _807;
                }
            }
            else
            {

                {
                    float _808 = this.GTorso.localEulerAngles.y + this.HNClamp;
                    Vector3 _809 = this.GTorso.localEulerAngles;
                    _809.y = _808;
                    this.GTorso.localEulerAngles = _809;
                }
            }
        }
        else
        {
            if ((this.GTorso.localEulerAngles.y < 360) && (this.GTorso.localEulerAngles.y > 180))
            {

                {
                    float _810 = this.GTorso.localEulerAngles.y + 1;
                    Vector3 _811 = this.GTorso.localEulerAngles;
                    _811.y = _810;
                    this.GTorso.localEulerAngles = _811;
                }
            }
            if ((this.GTorso.localEulerAngles.y > 0) && (this.GTorso.localEulerAngles.y < 180))
            {

                {
                    float _812 = this.GTorso.localEulerAngles.y - 1;
                    Vector3 _813 = this.GTorso.localEulerAngles;
                    _813.y = _812;
                    this.GTorso.localEulerAngles = _813;
                }
            }
            if ((this.GTorso.localEulerAngles.x < 360) && (this.GTorso.localEulerAngles.x > 180))
            {

                {
                    float _814 = this.GTorso.localEulerAngles.x + 1;
                    Vector3 _815 = this.GTorso.localEulerAngles;
                    _815.x = _814;
                    this.GTorso.localEulerAngles = _815;
                }
            }
            if ((this.GTorso.localEulerAngles.x > 0) && (this.GTorso.localEulerAngles.x < 180))
            {

                {
                    float _816 = this.GTorso.localEulerAngles.x - 1;
                    Vector3 _817 = this.GTorso.localEulerAngles;
                    _817.x = _816;
                    this.GTorso.localEulerAngles = _817;
                }
            }
        }
        if ((this.GTorso.localEulerAngles.x > 45) && (this.GTorso.localEulerAngles.x < 180))
        {

            {
                int _818 = 45;
                Vector3 _819 = this.GTorso.localEulerAngles;
                _819.x = _818;
                this.GTorso.localEulerAngles = _819;
            }
        }
        if ((this.GTorso.localEulerAngles.x < 315) && (this.GTorso.localEulerAngles.x > 180))
        {

            {
                int _820 = 315;
                Vector3 _821 = this.GTorso.localEulerAngles;
                _821.x = _820;
                this.GTorso.localEulerAngles = _821;
            }
        }
        if ((this.GTorso.localEulerAngles.y > 30) && (this.GTorso.localEulerAngles.y < 180))
        {

            {
                int _822 = 30;
                Vector3 _823 = this.GTorso.localEulerAngles;
                _823.y = _822;
                this.GTorso.localEulerAngles = _823;
            }
        }
        if ((this.GTorso.localEulerAngles.y < 330) && (this.GTorso.localEulerAngles.y > 180))
        {

            {
                int _824 = 330;
                Vector3 _825 = this.GTorso.localEulerAngles;
                _825.y = _824;
                this.GTorso.localEulerAngles = _825;
            }
        }
        //(LegMovement)===============================================================
        if ((this.GRFemur.localEulerAngles.x < 10) || (this.GRFemur.localEulerAngles.x > 180))
        {

            {
                float _826 = this.GRFemur.localEulerAngles.x + 1;
                Vector3 _827 = this.GRFemur.localEulerAngles;
                _827.x = _826;
                this.GRFemur.localEulerAngles = _827;
            }
        }
        if ((this.GRFemur.localEulerAngles.x > 10) && (this.GRFemur.localEulerAngles.x < 180))
        {

            {
                float _828 = this.GRFemur.localEulerAngles.x - 1;
                Vector3 _829 = this.GRFemur.localEulerAngles;
                _829.x = _828;
                this.GRFemur.localEulerAngles = _829;
            }
        }
        if ((this.GLFemur.localEulerAngles.x > 350) || (this.GLFemur.localEulerAngles.x < 180))
        {

            {
                float _830 = this.GLFemur.localEulerAngles.x - 1;
                Vector3 _831 = this.GLFemur.localEulerAngles;
                _831.x = _830;
                this.GLFemur.localEulerAngles = _831;
            }
        }
        if ((this.GLFemur.localEulerAngles.x < 350) && (this.GLFemur.localEulerAngles.x > 180))
        {

            {
                float _832 = this.GLFemur.localEulerAngles.x + 1;
                Vector3 _833 = this.GLFemur.localEulerAngles;
                _833.x = _832;
                this.GLFemur.localEulerAngles = _833;
            }
        }
        if ((this.GRTibia.localEulerAngles.x < 360) && (this.GRTibia.localEulerAngles.x > 180))
        {

            {
                float _834 = this.GRTibia.localEulerAngles.x + 1;
                Vector3 _835 = this.GRTibia.localEulerAngles;
                _835.x = _834;
                this.GRTibia.localEulerAngles = _835;
            }
        }
        if ((this.GRTibia.localEulerAngles.x > 0) && (this.GRTibia.localEulerAngles.x < 180))
        {

            {
                float _836 = this.GRTibia.localEulerAngles.x - 1;
                Vector3 _837 = this.GRTibia.localEulerAngles;
                _837.x = _836;
                this.GRTibia.localEulerAngles = _837;
            }
        }
        if ((this.GLTibia.localEulerAngles.x < 360) && (this.GLTibia.localEulerAngles.x > 180))
        {

            {
                float _838 = this.GLTibia.localEulerAngles.x + 1;
                Vector3 _839 = this.GLTibia.localEulerAngles;
                _839.x = _838;
                this.GLTibia.localEulerAngles = _839;
            }
        }
        if ((this.GLTibia.localEulerAngles.x > 0) && (this.GLTibia.localEulerAngles.x < 180))
        {

            {
                float _840 = this.GLTibia.localEulerAngles.x - 1;
                Vector3 _841 = this.GLTibia.localEulerAngles;
                _841.x = _840;
                this.GLTibia.localEulerAngles = _841;
            }
        }
        if ((this.GRFemur.localEulerAngles.y < 45) || (this.GRFemur.localEulerAngles.y > 270))
        {

            {
                float _842 = this.GRFemur.localEulerAngles.y + 1;
                Vector3 _843 = this.GRFemur.localEulerAngles;
                _843.y = _842;
                this.GRFemur.localEulerAngles = _843;
            }
        }
        if ((this.GLFemur.localEulerAngles.y > 360) || (this.GLFemur.localEulerAngles.y < 90))
        {

            {
                float _844 = this.GLFemur.localEulerAngles.y - 1;
                Vector3 _845 = this.GLFemur.localEulerAngles;
                _845.y = _844;
                this.GLFemur.localEulerAngles = _845;
            }
        }
        if ((this.GLFemur.localEulerAngles.y < 360) && (this.GLFemur.localEulerAngles.y > 180))
        {

            {
                float _846 = this.GLFemur.localEulerAngles.y + 1;
                Vector3 _847 = this.GLFemur.localEulerAngles;
                _847.y = _846;
                this.GLFemur.localEulerAngles = _847;
            }
        }
        if ((this.GRFemur.localEulerAngles.z < 5) || (this.GRFemur.localEulerAngles.z > 270))
        {

            {
                float _848 = this.GRFemur.localEulerAngles.z + 1;
                Vector3 _849 = this.GRFemur.localEulerAngles;
                _849.z = _848;
                this.GRFemur.localEulerAngles = _849;
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
            if (!this.UpperBodyAni.IsPlaying("Plast2IdleGun"))
            {
                this.UpperBodyAni.CrossFade("Plast2IdleGun", 0.3f);
            }
        }
        if (this.Running)
        {
            if ((this.GTorso.localEulerAngles.x < 14) || (this.GTorso.localEulerAngles.x > 180))
            {

                {
                    float _850 = this.GTorso.localEulerAngles.x + 1;
                    Vector3 _851 = this.GTorso.localEulerAngles;
                    _851.x = _850;
                    this.GTorso.localEulerAngles = _851;
                }
            }
            if ((this.GTorso.localEulerAngles.x > 16) && (this.GTorso.localEulerAngles.x < 180))
            {

                {
                    float _852 = this.GTorso.localEulerAngles.x - 1;
                    Vector3 _853 = this.GTorso.localEulerAngles;
                    _853.x = _852;
                    this.GTorso.localEulerAngles = _853;
                }
            }
        }
        else
        {
            if ((this.GTorso.localEulerAngles.x < 360) && (this.GTorso.localEulerAngles.x > 180))
            {

                {
                    float _854 = this.GTorso.localEulerAngles.x + 1;
                    Vector3 _855 = this.GTorso.localEulerAngles;
                    _855.x = _854;
                    this.GTorso.localEulerAngles = _855;
                }
            }
            if ((this.GTorso.localEulerAngles.x > 0) && (this.GTorso.localEulerAngles.x < 180))
            {

                {
                    float _856 = this.GTorso.localEulerAngles.x - 1;
                    Vector3 _857 = this.GTorso.localEulerAngles;
                    _857.x = _856;
                    this.GTorso.localEulerAngles = _857;
                }
            }
        }
        if ((this.GRFemur.localEulerAngles.y < 0) || (this.GRFemur.localEulerAngles.y < 180))
        {

            {
                float _858 = this.GRFemur.localEulerAngles.y - (1 * this.LocoSpeed);
                Vector3 _859 = this.GRFemur.localEulerAngles;
                _859.y = _858;
                this.GRFemur.localEulerAngles = _859;
            }
        }
        if ((this.GLFemur.localEulerAngles.y > 360) || (this.GLFemur.localEulerAngles.y > 180))
        {

            {
                float _860 = this.GLFemur.localEulerAngles.y + (1 * this.LocoSpeed);
                Vector3 _861 = this.GLFemur.localEulerAngles;
                _861.y = _860;
                this.GLFemur.localEulerAngles = _861;
            }
        }
        if ((this.GRFemur.localEulerAngles.z < 0) || (this.GRFemur.localEulerAngles.z < 180))
        {

            {
                float _862 = this.GRFemur.localEulerAngles.z - (1 * this.LocoSpeed);
                Vector3 _863 = this.GRFemur.localEulerAngles;
                _863.z = _862;
                this.GRFemur.localEulerAngles = _863;
            }
        }
        if ((this.GLFemur.localEulerAngles.z > 360) || (this.GLFemur.localEulerAngles.z > 180))
        {

            {
                float _864 = this.GLFemur.localEulerAngles.z + (1 * this.LocoSpeed);
                Vector3 _865 = this.GLFemur.localEulerAngles;
                _865.z = _864;
                this.GLFemur.localEulerAngles = _865;
            }
        }
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
                this.Bebs = 0;
            }
        }
        if (this.Possession2)
        {
            this.Pos2Area = this.Possession2.transform.position;
            if (!this.IHappy)
            {
                this.IHappy = true;
                this.Bebs = 0;
                this.StartCoroutine(this.Bub());
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
                this.Bebs = 0;
                this.StartCoroutine(this.Beb());
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
            this.Bebs = 1;
        }
        if ((this.Possession2 == null) && this.IHappy)
        {
            this.ResetView.position = this.Pos2Area;
            this.lookTarget = this.ResetView;
            this.IHappy = false;
            this.LookingAtLostItem = true;
            this.Fidgeting = false;
            this.Ogle = 10;
            this.Bebs = 1;
        }
        if ((this.Favourite1 == null) && this.IEcstatic)
        {
            this.ResetView.position = this.Fav1Area;
            this.lookTarget = this.ResetView;
            this.IEcstatic = false;
            this.LookingAtLostItem = true;
            this.Fidgeting = false;
            this.Ogle = 10;
            this.Bebs = 1;
        }
        if (((this.IHas && this.IHappy) && !this.Fidgeting) && !this.IEcstatic)
        {
            this.StartCoroutine(this.Bub());
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
        if (this.PissedAtTC2 > 0)
        {
            this.PissedAtTC2 = this.PissedAtTC2 - 1;
        }
        if (this.PissedAtTC3 > 0)
        {
            this.PissedAtTC3 = this.PissedAtTC3 - 1;
        }
        if (this.PissedAtTC4 > 0)
        {
            this.PissedAtTC4 = this.PissedAtTC4 - 1;
        }
        if (this.PissedAtTC5 > 0)
        {
            this.PissedAtTC5 = this.PissedAtTC5 - 1;
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
        if (AbiaSyndicateNetwork.TC0aCriminalLevel > 0)
        {
            this.PissedAtTC0a = 8;
        }
        if (AbiaSyndicateNetwork.TC1CriminalLevel > 0)
        {
            this.PissedAtTC1 = 8;
        }
        if (AbiaSyndicateNetwork.TC2CriminalLevel > 0)
        {
            this.PissedAtTC2 = 8;
        }
        if (AbiaSyndicateNetwork.TC3CriminalLevel > 0)
        {
            this.PissedAtTC3 = 8;
        }
        if (AbiaSyndicateNetwork.TC4CriminalLevel > 0)
        {
            this.PissedAtTC4 = 8;
        }
        if (AbiaSyndicateNetwork.TC5CriminalLevel > 0)
        {
            this.PissedAtTC5 = 8;
        }
        if (AbiaSyndicateNetwork.TC7CriminalLevel > 0)
        {
            this.PissedAtTC7 = 8;
        }
        if (AbiaSyndicateNetwork.TC8CriminalLevel > 0)
        {
            this.PissedAtTC8 = 8;
        }
        if (AbiaSyndicateNetwork.TC9CriminalLevel > 0)
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
                    float _866 = this.LocalView.localEulerAngles.y + 180;
                    Vector3 _867 = this.LocalView.localEulerAngles;
                    _867.y = _866;
                    this.LocalView.localEulerAngles = _867;
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
            if (this.TCCol.name.Contains("C6l"))
            {
                this.Leader = null;
            }
            if (this.Leader)
            {
                if (!this.Leader.name.Contains("6l"))
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
        if (Vector3.Distance(this.thisTransform.position, this.Waypoint.position) > 16)
        {
            this.Running = true;
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
        if (this.convNum < 2)
        {
            if (speech.Contains("albel"))
            {
                yield return new WaitForSeconds(1);
                this.GetComponent<AudioSource>().PlayOneShot(this.Beb1);
                yield break;
            }
            if (speech.Contains("abia") && speech.Contains("infidel"))
            {
                this.convNum = 3;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Atiba Albel!");
                this.PissedAtTC1 = this.PissedAtTC1 + 8;
                this.GetComponent<AudioSource>().PlayOneShot(this.Bib1);
                yield break;
            }
        }
        if (this.convNum == 0)
        {
            //===============================================================================
            if (speech.Contains("hi") || speech.Contains("hey"))
            {
                this.convNum = 1;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Hello friend! \n You've come to trade?");
                yield break;
            }
            if (speech.Contains("yo"))
            {
                this.convNum = 1;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Umm. You've come to trade?");
                yield break;
            }
            if (speech.Contains("hello") || speech.Contains("greet"))
            {
                this.convNum = 1;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Greetings, buyer!");
                yield break;
            }
            if (speech.Contains("abia"))
            {
                this.convNum = 1;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Excuse me, infidel. \n But that is not to be spoken of!");
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 1)
        {
            //===============================================================================
            if ((speech.Contains("ye") || speech.Contains("sure")) || speech.Contains("course"))
            {
                this.convNum = 2;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("That's great! But I am not a vendor. \n You need to find one, wherever they are.");
                yield break;
            }
            if ((speech.Contains("no") || speech.Contains("nah")) || speech.Contains("nvm"))
            {
                this.convNum = 2;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech(". . . Ok then.");
                yield break;
            }
            if ((speech.Contains("fuck") || speech.Contains("shit")) || speech.Contains("ass"))
            {
                this.convNum = 3;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Excuse me?");
                yield break;
            }
            if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
            {
                this.convNum = 2;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("What do you want?");
                yield break;
            }
            if (speech.Contains("hello") || speech.Contains("greet"))
            {
                this.convNum = 2;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Yes, I am here.");
                yield break;
            }
            if (speech.Contains("abia"))
            {
                this.convNum = 2;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("I warn you, one more time!");
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
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Whatever, I'm busy.");
                yield break;
            }
            if ((speech.Contains("no") || speech.Contains("nah")) || speech.Contains("nvm"))
            {
                this.convNum = 2;
                yield return new WaitForSeconds(2);
                yield break;
            }
            if ((speech.Contains("fuck") || speech.Contains("shit")) || speech.Contains("ass"))
            {
                this.convNum = 3;
                this.boredom = 4;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("You know what. \n Stay away!");
                yield break;
            }
            if (speech.Contains("hello") || speech.Contains("greet"))
            {
                this.convNum = 3;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("What is this?");
                yield break;
            }
            if (speech.Contains("abia"))
            {
                this.convNum = 3;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Atiba Albel!");
                this.PissedAtTC1 = this.PissedAtTC1 + 8;
                this.GetComponent<AudioSource>().PlayOneShot(this.Bib1);
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
                    this.ReturnSpeech("It's not my job to help \n with your personal issues.");
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
                this.PissedAtTC1 = this.PissedAtTC1 + 8;
                this.GetComponent<AudioSource>().PlayOneShot(this.Bib1);
                yield break;
            }
            if (speech.Contains("fuck off"))
            {
                this.convNum = 99;
                this.Ogle = 2;
                yield return new WaitForSeconds(2);
                this.PissedAtTC1 = this.PissedAtTC1 + 8;
                this.GetComponent<AudioSource>().PlayOneShot(this.Bib1);
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
        if (this.convNum == 3)
        {
            //===============================================================================
            yield return new WaitForSeconds(4);
            this.ReturnSpeech("Perish, infidel!");
            this.Ogle = 2;
            this.boredom = 4;
            this.convNum = 4;
            yield break;
        }
        //===============================================================================
        yield return new WaitForSeconds(2);
        if (this.boredom == 0)
        {
            this.ReturnSpeech("What?");
        }
        if (this.boredom == 1)
        {
            this.ReturnSpeech("Please elaborate.");
            this.convNum = 1;
        }
        if (this.boredom == 2)
        {
            this.ReturnSpeech("Well, see you later.");
            this.convNum = 4;
            this.Ogle = 4;
        }
        if (this.boredom == 3)
        {
            this.ReturnSpeech("Goodbye!");
            this.convNum = 4;
            this.Ogle = 2;
        }
        if (this.boredom == 4)
        {
            this.ReturnSpeech("Go away, \n you irritating donkey!");
            this.convNum = 4;
            this.Ogle = 2;
        }
        if (this.boredom == 5)
        {
            this.ReturnSpeech("Leave me alone! \n I swear to god!");
            this.convNum = 4;
            this.Ogle = 2;
        }
        if (this.boredom == 6)
        {
            this.ReturnSpeech("One more time, \n I'll shoot your head off!");
            this.convNum = 4;
            this.Ogle = 2;
        }
        if (this.boredom == 7)
        {
            this.ReturnSpeech("Ko ro udma!");
            this.convNum = 5;
            this.PissedAtTC1 = this.PissedAtTC1 + 8;
            this.Ogle = 2;
        }
        this.boredom = this.boredom + 1;
    }

    public virtual void ReturnSpeech(string yourText)
    {
        GameObject Load = ((GameObject) Resources.Load("Prefabs/TalkBubble", typeof(GameObject))) as GameObject;
        GameObject TGO = UnityEngine.Object.Instantiate(Load, this.thisTransform.position, Load.transform.rotation);
        TGO.name = "CFC6";
        TalkBubbleScript.myText = yourText;
        ((TalkBubbleScript) TGO.GetComponent(typeof(TalkBubbleScript))).source = this.thisTransform;
    }

    public AtibaPersonAI()
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