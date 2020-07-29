using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CyraHeadController : MonoBehaviour
{
    public Transform target;
    public SphereCollider Trigger;
    public Transform LookTarget;
    public Transform EyeLookTarget;
    public Transform EyeResetTarget;
    public Transform ResetTarget;
    public Transform KnownTarget;
    public Transform AIAnchor;
    public Transform thisTransform;
    public Transform MainBodyTF;
    public Rigidbody MainBodyRB;
    public Transform TorsoTF;
    public Rigidbody TorsoRB;
    public float ModC;
    public float AbRelDist;
    public Transform BalCenTF;
    public Transform PredictPoint;
    public float PredictPointMod;
    private float PredictPointModStat;
    public Transform GroundPointL;
    public Transform GroundPointR;
    public float GroundPointOffset;
    public Vector3 RRelPoint1;
    public Vector3 RRelPoint2;
    public Vector3 RRelPoint3;
    public Vector3 LRelPoint1;
    public Vector3 LRelPoint2;
    public Vector3 LRelPoint3;
    public float BodyTiltMod;
    public float BodyTiltModStanding;
    public float LegVelMod;
    public Transform RHipTF;
    public HingeJoint RHipJoint;
    public Transform RThighTF;
    public HingeJoint RThighJoint;
    public Transform RKneeTF;
    public HingeJoint RKneeJoint;
    public Transform LHipTF;
    public HingeJoint LHipJoint;
    public Transform LThighTF;
    public HingeJoint LThighJoint;
    public Transform LKneeTF;
    public HingeJoint LKneeJoint;
    public Rigidbody LKneeRB;
    public Rigidbody RKneeRB;
    public HingeJoint RArmJoint;
    public HingeJoint LArmJoint;
    public HingeJoint RForeArmJoint;
    public HingeJoint LForeArmJoint;
    public int FullStepneurysm;
    public float StepneurysmR;
    public float StepneurysmL;
    public float StepneurysmSpeed;
    public GameObject RFootGO;
    public GameObject LFootGO;
    public Transform RFootTF;
    public Transform LFootTF;
    public Rigidbody RFootRB;
    public Rigidbody LFootRB;
    public Collider RFootCol;
    public Collider LFootCol;
    public float FootPlaceTorque;
    public Transform FeetMidTF;
    public ConfigurableJoint RFootCJoint;
    public ConfigurableJoint LFootCJoint;
    public Transform FootSCStartR;
    public Transform FootSCStartL;
    public float FootSCSize1;
    public float FootSCSize2;
    public bool RFootPlaced;
    public bool LFootPlaced;
    public GameObject FootLandSFX;
    public AnimationCurve StepHeightCurve;
    public float StepHeightPlusR;
    public float StepHeightPlusL;
    public AnimationCurve SHPCurve;
    public float Angle;
    public AnimationCurve ArmBendCurve;
    public AnimationCurve ForeArmBendCurve;
    public bool Perform;
    public bool DoOnce;
    private Quaternion NewRotation;
    public string IgnoreSelf;
    public Transform RandAim1;
    public Transform RandAim2;
    public Transform RandAim3;
    public Transform EyeRandAim1;
    public Transform EyeRandAim2;
    public Transform EyeRandAim3;
    public float LookForce;
    public float EyeLookForce;
    public GameObject REye;
    public GameObject LEye;
    public int RBrowMood;
    public int LBrowMood;
    public int RMouthMood;
    public int LMouthMood;
    public int JawMood;
    public int Mood;
    public bool Spot;
    public int TargetCode;
    public int Interest;
    public int AngerLevel;
    public int Jitter;
    public bool Walking;
    public bool Stopping;
    public bool Obstacle;
    public bool Right;
    public bool Left;
    public bool TurnRight;
    public bool TurnLeft;
    public AnimationCurve TurnForceCurve;
    public float TurnForce;
    public float DirForce;
    public int MaxVel;
    public float Vel;
    public float RightDist;
    public float LeftDist;
    public float RUpDist;
    public float RDownDist;
    public float LUpDist;
    public float LDownDist;
    public bool rSteepInc;
    public bool lSteepInc;
    public int SenseDist;
    public float IncThreshold;
    public float TurnEndSide;
    public float TurnEndVert;
    public int PissedAtTC0;
    public int PissedAtTC1;
    public int PissedAtTC2;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public Transform RightBrow;
    public Transform LeftBrow;
    public Transform RightMouth;
    public Transform LeftMouth;
    public Rigidbody HeadRB;
    public LayerMask MtargetLayers;
    public virtual void Start()
    {
        this.InvokeRepeating("Ticker", 1, 0.5f);
        this.StepneurysmR = 0;
        this.StepneurysmL = this.FullStepneurysm / 2;
        this.PredictPointModStat = this.PredictPointMod;
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        RaycastHit rHit1 = default(RaycastHit);
        RaycastHit rHit2 = default(RaycastHit);
        RaycastHit lHit1 = default(RaycastHit);
        RaycastHit lHit2 = default(RaycastHit);
        this.thisTransform.rotation = this.AIAnchor.transform.rotation;
        this.thisTransform.position = this.AIAnchor.transform.position;
        float RAngle = Mathf.Abs(this.RUpDist - this.RDownDist);
        float LAngle = Mathf.Abs(this.LUpDist - this.LDownDist);
        float VelClamp = Mathf.Clamp(this.Vel * 10, this.SenseDist, 500);

        float LAndR = 0.0f;
        float FAndB = 0.0f;
        if (this.LookTarget)
        {
            Vector3 relativePoint = this.MainBodyTF.InverseTransformPoint(this.LookTarget.position);
            LAndR = relativePoint.x;
            FAndB = relativePoint.y;
        }
        this.PredictPoint.position = this.BalCenTF.position;
        if (Physics.Raycast(this.BalCenTF.position, Vector3.down, out hit, 64, (int) this.MtargetLayers))
        {
            this.PredictPoint.position = this.PredictPoint.position - ((Vector3.up * hit.distance) * 0.7f);
        }
        Debug.DrawRay(((this.PredictPoint.position + (this.BalCenTF.right * this.TurnEndSide)) + (-this.BalCenTF.up * 0.2f)) + (-this.BalCenTF.forward * 4), this.BalCenTF.forward * VelClamp, Color.black);
        if (Physics.Raycast(((this.PredictPoint.position + (this.BalCenTF.right * this.TurnEndSide)) + (-this.BalCenTF.up * 0.2f)) + (-this.BalCenTF.forward * 4), this.BalCenTF.forward, out hit, VelClamp, (int) this.MtargetLayers))
        {
            this.RightDist = hit.distance;
        }
        else
        {
            this.RightDist = VelClamp;
        }
        Debug.DrawRay(((this.PredictPoint.position + (-this.BalCenTF.right * this.TurnEndSide)) + (-this.BalCenTF.up * 0.2f)) + (-this.BalCenTF.forward * 4), this.BalCenTF.forward * VelClamp, Color.black);
        if (Physics.Raycast(((this.PredictPoint.position + (-this.BalCenTF.right * this.TurnEndSide)) + (-this.BalCenTF.up * 0.2f)) + (-this.BalCenTF.forward * 4), this.BalCenTF.forward, out hit, VelClamp, (int) this.MtargetLayers))
        {
            this.LeftDist = hit.distance;
        }
        else
        {
            this.LeftDist = VelClamp;
        }
        Debug.DrawRay(((this.PredictPoint.position + (this.BalCenTF.right * this.TurnEndSide)) + (this.BalCenTF.up * 0.2f)) + (this.BalCenTF.forward * this.TurnEndVert), (this.BalCenTF.forward * VelClamp) * 1.2f, Color.green);
        if (Physics.Raycast(((this.PredictPoint.position + (this.BalCenTF.right * this.TurnEndSide)) + (this.BalCenTF.up * 0.2f)) + (this.BalCenTF.forward * this.TurnEndVert), this.BalCenTF.forward, out rHit1, VelClamp, (int) this.MtargetLayers))
        {
            this.RUpDist = rHit1.distance;
        }
        else
        {
            this.RUpDist = 8;
        }
        Debug.DrawRay(((this.PredictPoint.position + (this.BalCenTF.right * this.TurnEndSide)) + (-this.BalCenTF.up * 0.2f)) + (this.BalCenTF.forward * this.TurnEndVert), (this.BalCenTF.forward * VelClamp) * 1.2f, Color.green);
        if (Physics.Raycast(((this.PredictPoint.position + (this.BalCenTF.right * this.TurnEndSide)) + (-this.BalCenTF.up * 0.2f)) + (this.BalCenTF.forward * this.TurnEndVert), this.BalCenTF.forward, out rHit2, VelClamp, (int) this.MtargetLayers))
        {
            this.RDownDist = rHit2.distance;
        }
        else
        {
            this.RDownDist = 16;
        }
        Debug.DrawRay(((this.PredictPoint.position + (-this.BalCenTF.right * this.TurnEndSide)) + (this.BalCenTF.up * 0.2f)) + (this.BalCenTF.forward * this.TurnEndVert), (this.BalCenTF.forward * VelClamp) * 1.2f, Color.green);
        if (Physics.Raycast(((this.PredictPoint.position + (-this.BalCenTF.right * this.TurnEndSide)) + (this.BalCenTF.up * 0.2f)) + (this.BalCenTF.forward * this.TurnEndVert), this.BalCenTF.forward, out lHit1, VelClamp, (int) this.MtargetLayers))
        {
            this.LUpDist = lHit1.distance;
        }
        else
        {
            this.LUpDist = 8;
        }
        Debug.DrawRay(((this.PredictPoint.position + (-this.BalCenTF.right * this.TurnEndSide)) + (-this.BalCenTF.up * 0.2f)) + (this.BalCenTF.forward * this.TurnEndVert), (this.BalCenTF.forward * VelClamp) * 1.2f, Color.green);
        if (Physics.Raycast(((this.PredictPoint.position + (-this.BalCenTF.right * this.TurnEndSide)) + (-this.BalCenTF.up * 0.2f)) + (this.BalCenTF.forward * this.TurnEndVert), this.BalCenTF.forward, out lHit2, VelClamp, (int) this.MtargetLayers))
        {
            this.LDownDist = lHit2.distance;
        }
        else
        {
            this.LDownDist = 16;
        }
        if (RAngle < this.IncThreshold)
        {
            this.rSteepInc = true;
        }
        else
        {
            this.rSteepInc = false;
        }
        if (LAngle < this.IncThreshold)
        {
            this.lSteepInc = true;
        }
        else
        {
            this.lSteepInc = false;
        }
        this.TurnRight = false;
        this.TurnLeft = false;
        if (!this.Obstacle)
        {
            Debug.DrawRay(((this.PredictPoint.position + (this.BalCenTF.up * 20)) + (this.BalCenTF.right * this.TurnEndSide)) + (this.BalCenTF.forward * 25), Vector3.down * 25, Color.white);
            Debug.DrawRay(((this.PredictPoint.position + (this.BalCenTF.up * 20)) + (this.BalCenTF.right * this.TurnEndSide)) + (this.BalCenTF.forward * 30), Vector3.down * 25, Color.white);
            Debug.DrawRay(((this.PredictPoint.position + (this.BalCenTF.up * 20)) + (this.BalCenTF.right * this.TurnEndSide)) + (this.BalCenTF.forward * 35), Vector3.down * 25, Color.white);
            if ((!Physics.Raycast(((this.PredictPoint.position + (this.BalCenTF.up * 20)) + (this.BalCenTF.right * this.TurnEndSide)) + (this.BalCenTF.forward * 25), Vector3.down, 25) || !Physics.Raycast(((this.PredictPoint.position + (this.BalCenTF.up * 20)) + (this.BalCenTF.right * this.TurnEndSide)) + (this.BalCenTF.forward * 30), Vector3.down, 25)) || !Physics.Raycast(((this.PredictPoint.position + (this.BalCenTF.up * 20)) + (this.BalCenTF.right * this.TurnEndSide)) + (this.BalCenTF.forward * 35), Vector3.down, 25))
            {
                this.TurnLeft = true;
            }
            Debug.DrawRay(((this.PredictPoint.position + (this.BalCenTF.up * 20)) + (-this.BalCenTF.right * this.TurnEndSide)) + (this.BalCenTF.forward * 25), Vector3.down * 25, Color.white);
            Debug.DrawRay(((this.PredictPoint.position + (this.BalCenTF.up * 20)) + (-this.BalCenTF.right * this.TurnEndSide)) + (this.BalCenTF.forward * 30), Vector3.down * 25, Color.white);
            Debug.DrawRay(((this.PredictPoint.position + (this.BalCenTF.up * 20)) + (-this.BalCenTF.right * this.TurnEndSide)) + (this.BalCenTF.forward * 35), Vector3.down * 25, Color.white);
            if ((!Physics.Raycast(((this.PredictPoint.position + (this.BalCenTF.up * 20)) + (-this.BalCenTF.right * this.TurnEndSide)) + (this.BalCenTF.forward * 25), Vector3.down, 25) || !Physics.Raycast(((this.PredictPoint.position + (this.BalCenTF.up * 20)) + (-this.BalCenTF.right * this.TurnEndSide)) + (this.BalCenTF.forward * 30), Vector3.down, 25)) || !Physics.Raycast(((this.PredictPoint.position + (this.BalCenTF.up * 20)) + (-this.BalCenTF.right * this.TurnEndSide)) + (this.BalCenTF.forward * 35), Vector3.down, 25))
            {
                this.TurnRight = true;
            }
        }
        if (this.RightDist > this.LeftDist)
        {
            this.TurnRight = true;
        }
        if (this.LeftDist > this.RightDist)
        {
            this.TurnLeft = true;
        }
        if (this.TurnRight && this.TurnLeft)
        {
            this.Jitter = this.Jitter + 1;
        }
        if (this.AngerLevel < 100)
        {
            if (this.TurnRight && !this.Right)
            {
                this.Jitter = this.Jitter + 1;
                this.Right = true;
                this.Left = false;
            }
            if (this.TurnLeft && !this.Left)
            {
                this.Jitter = this.Jitter + 1;
                this.Right = false;
                this.Left = true;
            }
        }
        else
        {
            if (LAndR > 0)
            {
                this.TurnRight = true;
                this.TurnLeft = false;
            }
            else
            {
                this.TurnRight = false;
                this.TurnLeft = true;
            }
        }
        if (this.Obstacle)
        {
            this.TurnRight = false;
            this.TurnLeft = true;
        }
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hitM = default(RaycastHit);
        RaycastHit hitS = default(RaycastHit);
        this.Vel = Mathf.Abs(this.MainBodyTF.InverseTransformDirection(this.MainBodyRB.velocity).z);
        if (this.MainBodyRB.velocity != Vector3.zero)
        {
            this.PredictPoint.rotation = Quaternion.LookRotation(this.MainBodyRB.velocity);
        }
        this.PredictPoint.position = this.MainBodyTF.position;
        float Y = this.PredictPoint.eulerAngles.y;
        float Z = this.PredictPoint.eulerAngles.z;
        this.PredictPoint.rotation = Quaternion.Euler(0, Y, Z);
        this.PredictPoint.position = this.PredictPoint.position + ((this.PredictPoint.forward * this.MainBodyRB.velocity.magnitude) * this.PredictPointMod);
        Debug.DrawRay(this.PredictPoint.position + (this.MainBodyTF.right * this.GroundPointOffset), Vector3.down * 64, Color.yellow);
        if (Physics.Raycast(this.PredictPoint.position + (this.MainBodyTF.right * this.GroundPointOffset), Vector3.down, out hitM, 64, (int) this.MtargetLayers))
        {
            this.GroundPointR.position = hitM.point;
        }
        Debug.DrawRay(this.PredictPoint.position + (this.MainBodyTF.right * -this.GroundPointOffset), Vector3.down * 64, Color.yellow);
        if (Physics.Raycast(this.PredictPoint.position + (this.MainBodyTF.right * -this.GroundPointOffset), Vector3.down, out hitM, 64, (int) this.MtargetLayers))
        {
            this.GroundPointL.position = hitM.point;
        }
        Vector3 relativePointT = this.TorsoTF.InverseTransformPoint(this.MainBodyTF.position);
        float AbRelDistZ = Mathf.Clamp(relativePointT.z, 0, 32);
        float AbRelDistX = relativePointT.x * 0.25f;
        this.MainBodyRB.AddTorque(((this.MainBodyTF.right * this.MainBodyRB.velocity.magnitude) * this.BodyTiltMod) * AbRelDistZ);
        this.MainBodyRB.AddTorque(((this.MainBodyTF.forward * this.MainBodyRB.velocity.magnitude) * this.BodyTiltMod) * -AbRelDistX);
        if (this.RFootPlaced)
        {
            this.RFootRB.AddTorque(this.RFootTF.right * this.FootPlaceTorque);
        }
        if (this.LFootPlaced)
        {
            this.LFootRB.AddTorque(this.LFootTF.right * this.FootPlaceTorque);
        }
        float StepHeightR = this.StepHeightCurve.Evaluate(this.StepneurysmR);
        float StepHeightL = this.StepHeightCurve.Evaluate(this.StepneurysmL);
        float ArmMovementR = this.ArmBendCurve.Evaluate(this.StepneurysmL);
        float ArmMovementL = this.ArmBendCurve.Evaluate(this.StepneurysmR);
        float ForeArmMovementR = this.ForeArmBendCurve.Evaluate(this.StepneurysmL);
        float ForeArmMovementL = this.ForeArmBendCurve.Evaluate(this.StepneurysmR);

        {
            float _1152 = ArmMovementR;
            JointMotor _1153 = this.RArmJoint.motor;
            _1153.targetVelocity = _1152;
            this.RArmJoint.motor = _1153;
        }

        {
            float _1154 = ArmMovementL;
            JointMotor _1155 = this.LArmJoint.motor;
            _1155.targetVelocity = _1154;
            this.LArmJoint.motor = _1155;
        }

        {
            float _1156 = ForeArmMovementR;
            JointMotor _1157 = this.RForeArmJoint.motor;
            _1157.targetVelocity = _1156;
            this.RForeArmJoint.motor = _1157;
        }

        {
            float _1158 = ForeArmMovementL;
            JointMotor _1159 = this.LForeArmJoint.motor;
            _1159.targetVelocity = _1158;
            this.LForeArmJoint.motor = _1159;
        }
        if (this.Walking)
        {
            if (this.StepneurysmR == this.StepneurysmL)
            {
                this.StepneurysmR = 0;
                this.StepneurysmL = 50;
            }
            if (this.StepneurysmR < this.FullStepneurysm)
            {
                this.StepneurysmR = this.StepneurysmR + this.StepneurysmSpeed;
            }
            else
            {
                this.StepneurysmR = 0;
                this.StepneurysmL = 50;
            }
            if (this.StepneurysmL < this.FullStepneurysm)
            {
                this.StepneurysmL = this.StepneurysmL + this.StepneurysmSpeed;
            }
            else
            {
                this.StepneurysmL = 0;
                this.StepneurysmR = 50;
            }
            if (this.TurnLeft)
            {
                this.MainBodyRB.AddTorque(this.MainBodyTF.up * -this.TurnForce);
            }
            if (this.TurnRight)
            {
                this.MainBodyRB.AddTorque(this.MainBodyTF.up * this.TurnForce);
            }
            if (this.Vel < this.MaxVel)
            {
                this.MainBodyRB.AddForce(this.MainBodyTF.forward * this.DirForce);
            }
            if (this.RFootPlaced && this.LFootPlaced)
            {
                this.LFootPlaced = true;
                this.RFootPlaced = false;
                this.PlaceLFoot(false);
            }
        }
        else
        {
            this.FeetMidTF.position = this.FootSCStartL.position;
            this.FeetMidTF.LookAt(this.FootSCStartR);
            this.FeetMidTF.position = this.FeetMidTF.position + ((this.FeetMidTF.forward * Vector3.Distance(this.FeetMidTF.position, this.FootSCStartR.position)) / 2);
            this.PredictPoint.LookAt(this.FeetMidTF);
            this.PredictPoint.position = this.MainBodyTF.position;
            Y = this.PredictPoint.eulerAngles.y;
            Z = this.PredictPoint.eulerAngles.z;
            this.PredictPoint.rotation = Quaternion.Euler(0, Y, Z);
            float ModV = Mathf.Abs(this.PredictPoint.InverseTransformPoint(this.FeetMidTF.position).z);
            float ModV2 = Mathf.Clamp(ModV, -16, 16);
            if (this.RFootPlaced || this.LFootPlaced)
            {
                this.MainBodyRB.AddForce((this.PredictPoint.forward * ModV2) * this.BodyTiltModStanding);
            }
            this.StepneurysmR = 0;
            this.StepneurysmL = 0;
            StepHeightR = StepHeightR - 1;
            StepHeightL = StepHeightL - 1;
            if (Physics.SphereCast(this.FootSCStartR.position, this.FootSCSize2, Vector3.down, out hitS, this.FootSCSize2, (int) this.MtargetLayers))
            {
                if (!this.RFootPlaced)
                {
                    this.RFootPlaced = true;
                    this.PlaceRFoot(true);
                    UnityEngine.Object.Instantiate(this.FootLandSFX, hitS.point, Quaternion.identity);
                }
            }
            if (Physics.SphereCast(this.FootSCStartL.position, this.FootSCSize2, Vector3.down, out hitS, this.FootSCSize2, (int) this.MtargetLayers))
            {
                if (!this.LFootPlaced)
                {
                    this.LFootPlaced = true;
                    this.PlaceLFoot(true);
                    UnityEngine.Object.Instantiate(this.FootLandSFX, hitS.point, Quaternion.identity);
                }
            }
        }
        if (this.Stopping)
        {
            if ((this.StepneurysmR > 24) && (this.StepneurysmR < 26))
            {
                this.Walking = false;
                this.Stopping = false;
            }
            if ((this.StepneurysmL > 24) && (this.StepneurysmL < 26))
            {
                this.Walking = false;
                this.Stopping = false;
            }
        }
        // GetGroundInclination ========================================================================================================
        float UpDist = 2f;
        this.PredictPoint.position = this.BalCenTF.position;
        if (Physics.Raycast(this.BalCenTF.position, Vector3.down, out hitM, 64, (int) this.MtargetLayers))
        {
            this.PredictPoint.position = this.PredictPoint.position - (Vector3.up * hitM.distance);
        }
        Debug.DrawRay(this.PredictPoint.position + (this.BalCenTF.up * 0.1f), this.BalCenTF.forward * 8, Color.yellow);
        if (Physics.Raycast(this.PredictPoint.position + (this.BalCenTF.up * 0.1f), this.BalCenTF.forward, out hitM, 8, (int) this.MtargetLayers))
        {
            UpDist = hitM.distance;
        }
        Debug.DrawRay(this.PredictPoint.position + (this.BalCenTF.up * 0.2f), this.BalCenTF.forward * 8, Color.yellow);
        if (Physics.Raycast(this.PredictPoint.position + (this.BalCenTF.up * 0.2f), this.BalCenTF.forward, out hitM, 8, (int) this.MtargetLayers))
        {
            this.Angle = Mathf.Abs(UpDist - hitM.distance);
            this.StepHeightPlusR = this.SHPCurve.Evaluate(this.Angle);
            this.StepHeightPlusL = this.SHPCurve.Evaluate(this.Angle);
        }
        //===============================================================================================================================
        if (this.StepneurysmR < 50)
        {
            if (Physics.SphereCast(this.FootSCStartR.position, this.FootSCSize1, Vector3.down, out hitS, this.FootSCSize1, (int) this.MtargetLayers))
            {
                if (this.StepneurysmR > 0)
                {
                    StepHeightR = StepHeightR + 1;
                }
            }
        }
        else
        {
            if (Physics.SphereCast(this.FootSCStartR.position, this.FootSCSize2, Vector3.down, out hitS, this.FootSCSize2, (int) this.MtargetLayers))
            {
                StepHeightR = StepHeightR - 2;
                if (!this.RFootPlaced)
                {
                    this.RFootPlaced = true;
                    this.LFootPlaced = false;
                    this.PlaceRFoot(false);
                    UnityEngine.Object.Instantiate(this.FootLandSFX, hitS.point, Quaternion.identity);
                }
            }
            this.StepHeightPlusR = 0;
        }
        if (this.StepneurysmL < 50)
        {
            if (Physics.SphereCast(this.FootSCStartL.position, this.FootSCSize1, Vector3.down, out hitS, this.FootSCSize1, (int) this.MtargetLayers))
            {
                if (this.StepneurysmL > 0)
                {
                    StepHeightL = StepHeightL + 1;
                }
            }
        }
        else
        {
            if (Physics.SphereCast(this.FootSCStartL.position, this.FootSCSize2, Vector3.down, out hitS, this.FootSCSize2, (int) this.MtargetLayers))
            {
                StepHeightL = StepHeightL - 2;
                if (!this.LFootPlaced)
                {
                    this.LFootPlaced = true;
                    this.RFootPlaced = false;
                    this.PlaceLFoot(false);
                    UnityEngine.Object.Instantiate(this.FootLandSFX, hitS.point, Quaternion.identity);
                }
            }
            this.StepHeightPlusL = 0;
        }
        // FootLetGo ======================================================================================================
        //if(StepneurysmR > 120)
        //if(LFootCJoint)
        //Destroy(LFootCJoint);
        //if(StepneurysmL > 120)
        //if(RFootCJoint)
        //Destroy(RFootCJoint);
        if (this.RFootPlaced)
        {
            this.RRelPoint1 = this.RHipTF.InverseTransformPoint(this.ResetTarget.position);
        }
        else
        {
            this.RRelPoint1 = this.RHipTF.InverseTransformPoint(this.GroundPointR.position);
        }
        this.RRelPoint2 = this.RThighTF.InverseTransformPoint(this.GroundPointR.position);
        this.RRelPoint3 = this.RKneeTF.InverseTransformPoint(this.GroundPointR.position);
        float RRelPoint2Z = this.RRelPoint2.z + StepHeightR;
        float RRelPoint3Z = this.RRelPoint3.z - (StepHeightR * 2);

        {
            float _1160 = this.RRelPoint1.x * this.LegVelMod;
            JointMotor _1161 = this.RHipJoint.motor;
            _1161.targetVelocity = _1160;
            this.RHipJoint.motor = _1161;
        }

        {
            float _1162 = (RRelPoint2Z * this.LegVelMod) + this.StepHeightPlusR;
            JointMotor _1163 = this.RThighJoint.motor;
            _1163.targetVelocity = _1162;
            this.RThighJoint.motor = _1163;
        }

        {
            float _1164 = RRelPoint3Z * this.LegVelMod;
            JointMotor _1165 = this.RKneeJoint.motor;
            _1165.targetVelocity = _1164;
            this.RKneeJoint.motor = _1165;
        }
        if (this.LFootPlaced)
        {
            this.LRelPoint1 = this.LHipTF.InverseTransformPoint(this.ResetTarget.position);
        }
        else
        {
            this.LRelPoint1 = this.LHipTF.InverseTransformPoint(this.GroundPointL.position);
        }
        this.LRelPoint2 = this.LThighTF.InverseTransformPoint(this.GroundPointL.position);
        this.LRelPoint3 = this.LKneeTF.InverseTransformPoint(this.GroundPointL.position);
        float LRelPoint2Z = this.LRelPoint2.z + StepHeightL;
        float LRelPoint3Z = this.LRelPoint3.z - (StepHeightL * 2);

        {
            float _1166 = this.LRelPoint1.x * this.LegVelMod;
            JointMotor _1167 = this.LHipJoint.motor;
            _1167.targetVelocity = _1166;
            this.LHipJoint.motor = _1167;
        }

        {
            float _1168 = (LRelPoint2Z * this.LegVelMod) + this.StepHeightPlusL;
            JointMotor _1169 = this.LThighJoint.motor;
            _1169.targetVelocity = _1168;
            this.LThighJoint.motor = _1169;
        }

        {
            float _1170 = LRelPoint3Z * this.LegVelMod;
            JointMotor _1171 = this.LKneeJoint.motor;
            _1171.targetVelocity = _1170;
            this.LKneeJoint.motor = _1171;
        }
        if (this.LookTarget)
        {
            this.HeadRB.AddForceAtPosition((this.LookTarget.transform.position - this.transform.position).normalized * this.LookForce, -this.transform.forward * 1);
            this.HeadRB.AddForceAtPosition((this.LookTarget.transform.position - this.transform.position).normalized * -this.LookForce, this.transform.forward * 1);
        }
        if (this.EyeLookTarget)
        {
            this.REye.GetComponent<Rigidbody>().AddForceAtPosition((this.EyeLookTarget.transform.position - this.REye.transform.position).normalized * this.EyeLookForce, -this.REye.transform.forward * 1);
            this.REye.GetComponent<Rigidbody>().AddForceAtPosition((this.EyeLookTarget.transform.position - this.REye.transform.position).normalized * -this.EyeLookForce, this.REye.transform.forward * 1);
            this.LEye.GetComponent<Rigidbody>().AddForceAtPosition((this.EyeLookTarget.transform.position - this.LEye.transform.position).normalized * this.EyeLookForce, -this.LEye.transform.forward * 1);
            this.LEye.GetComponent<Rigidbody>().AddForceAtPosition((this.EyeLookTarget.transform.position - this.LEye.transform.position).normalized * -this.EyeLookForce, this.LEye.transform.forward * 1);
        }

        {
            float _1172 = -0.08f + (-this.RBrowMood * 0.0002f);
            Vector3 _1173 = this.RightBrow.localPosition;
            _1173.x = _1172;
            this.RightBrow.localPosition = _1173;
        }

        {
            float _1174 = -0.08f + (-this.LBrowMood * 0.0002f);
            Vector3 _1175 = this.LeftBrow.localPosition;
            _1175.x = _1174;
            this.LeftBrow.localPosition = _1175;
        }

        {
            int _1176 = this.RMouthMood;
            Vector3 _1177 = this.RightMouth.localEulerAngles;
            _1177.x = _1176;
            this.RightMouth.localEulerAngles = _1177;
        }

        {
            float _1178 = 270 + (this.RMouthMood * 0.5f);
            Vector3 _1179 = this.RightMouth.localEulerAngles;
            _1179.y = _1178;
            this.RightMouth.localEulerAngles = _1179;
        }

        {
            int _1180 = -this.LMouthMood;
            Vector3 _1181 = this.LeftMouth.localEulerAngles;
            _1181.x = _1180;
            this.LeftMouth.localEulerAngles = _1181;
        }

        {
            float _1182 = 270 + (this.LMouthMood * 0.5f);
            Vector3 _1183 = this.LeftMouth.localEulerAngles;
            _1183.y = _1182;
            this.LeftMouth.localEulerAngles = _1183;
        }
        if (this.Mood == 2)
        {
            if (this.EyeLookTarget != this.EyeRandAim2)
            {
                if (this.RMouthMood < 40)
                {
                    this.RMouthMood = this.RMouthMood + 1;
                }
            }
            else
            {
                if (this.LBrowMood > -100)
                {
                    this.LBrowMood = this.LBrowMood - 1;
                }
            }
            if (this.EyeLookTarget != this.EyeRandAim1)
            {
                if (this.LMouthMood < 40)
                {
                    this.LMouthMood = this.LMouthMood + 1;
                }
            }
            else
            {
                if (this.RBrowMood > -100)
                {
                    this.RBrowMood = this.RBrowMood - 1;
                }
            }
        }
        if (this.Mood == 0)
        {
            if (this.RMouthMood > -14)
            {
                this.RMouthMood = this.RMouthMood - 1;
            }
            if (this.LMouthMood > -14)
            {
                this.LMouthMood = this.LMouthMood - 1;
            }
            if (this.RBrowMood > -200)
            {
                this.RBrowMood = this.RBrowMood - 2;
            }
            if (this.LBrowMood > -200)
            {
                this.LBrowMood = this.LBrowMood - 2;
            }
        }
        if (this.Mood == 1)
        {
            if (this.RBrowMood > 0)
            {
                this.RBrowMood = this.RBrowMood - 1;
            }
            if (this.LBrowMood > 0)
            {
                this.LBrowMood = this.LBrowMood - 1;
            }
            if (this.RBrowMood < 0)
            {
                this.RBrowMood = this.RBrowMood + 1;
            }
            if (this.LBrowMood < 0)
            {
                this.LBrowMood = this.LBrowMood + 1;
            }
            if (this.RMouthMood > 0)
            {
                this.RMouthMood = this.RMouthMood - 2;
            }
            if (this.RMouthMood < 0)
            {
                this.RMouthMood = this.RMouthMood + 2;
            }
            if (this.LMouthMood > 0)
            {
                this.LMouthMood = this.LMouthMood - 2;
            }
            if (this.LMouthMood < 0)
            {
                this.LMouthMood = this.LMouthMood + 2;
            }
        }
        if (this.RMouthMood > 40)
        {
            this.RMouthMood = 40;
        }
        if (this.LMouthMood > 40)
        {
            this.LMouthMood = 40;
        }
        if (this.RMouthMood < -14)
        {
            this.RMouthMood = -14;
        }
        if (this.LMouthMood < -14)
        {
            this.LMouthMood = -14;
        }
        if (this.RBrowMood > 200)
        {
            this.RBrowMood = 200;
        }
        if (this.RBrowMood < -200)
        {
            this.RBrowMood = -200;
        }
        if (this.LBrowMood > 200)
        {
            this.LBrowMood = 200;
        }
        if (this.LBrowMood < -200)
        {
            this.LBrowMood = -200;
        }
        if (this.AngerLevel > 24)
        {
            this.Mood = 0;
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other == null)
        {
            return;
        }
        string ON = other.name;
        Transform OT = other.transform;
        if (ON.Contains(this.IgnoreSelf))
        {
            return;
        }
        if (ON.Contains("TFC"))
        {
            this.Trigger.radius = 128;
            if (this.TargetCode != 0)
            {
                if (ON.Contains("TFC0a"))
                {
                    if (this.PissedAtTC0 < 32)
                    {
                        this.PissedAtTC0 = this.PissedAtTC0 + 8;
                    }
                    if (this.AngerLevel < 64)
                    {
                        this.AngerLevel = this.AngerLevel + 18;
                    }
                    this.Spot = false;
                }
            }
            if (this.TargetCode != 1)
            {
                if (ON.Contains("TFC1"))
                {
                    if (this.PissedAtTC1 < 32)
                    {
                        this.PissedAtTC1 = this.PissedAtTC1 + 8;
                    }
                    if (this.AngerLevel < 64)
                    {
                        this.AngerLevel = this.AngerLevel + 18;
                    }
                    this.Spot = false;
                }
            }
            if ((this.TargetCode != 2) && (this.TargetCode != 3))
            {
                if (ON.Contains("TFC2"))
                {
                    if (this.PissedAtTC2 < 32)
                    {
                        this.PissedAtTC2 = this.PissedAtTC2 + 8;
                    }
                    if (this.AngerLevel < 64)
                    {
                        this.AngerLevel = this.AngerLevel + 18;
                    }
                    this.Spot = false;
                }
            }
            if (this.TargetCode != 3)
            {
                if (ON.Contains("TFC3"))
                {
                    if (this.PissedAtTC3 < 32)
                    {
                        this.PissedAtTC3 = this.PissedAtTC3 + 8;
                    }
                    if (this.AngerLevel < 64)
                    {
                        this.AngerLevel = this.AngerLevel + 18;
                    }
                    this.Spot = false;
                }
            }
            if (this.TargetCode != 4)
            {
                if (ON.Contains("TFC4"))
                {
                    if (this.PissedAtTC4 < 32)
                    {
                        this.PissedAtTC4 = this.PissedAtTC4 + 8;
                    }
                    if (this.AngerLevel < 64)
                    {
                        this.AngerLevel = this.AngerLevel + 18;
                    }
                    this.Spot = false;
                }
            }
            if (this.TargetCode != 5)
            {
                if (ON.Contains("TFC5"))
                {
                    if (this.PissedAtTC5 < 32)
                    {
                        this.PissedAtTC5 = this.PissedAtTC5 + 8;
                    }
                    if (this.AngerLevel < 64)
                    {
                        this.AngerLevel = this.AngerLevel + 18;
                    }
                    this.Spot = false;
                }
            }
            if (this.TargetCode != 6)
            {
                if (ON.Contains("TFC6"))
                {
                    if (this.PissedAtTC6 < 32)
                    {
                        this.PissedAtTC6 = this.PissedAtTC6 + 8;
                    }
                    if (this.AngerLevel < 64)
                    {
                        this.AngerLevel = this.AngerLevel + 18;
                    }
                    this.Spot = false;
                }
            }
            if (this.TargetCode != 7)
            {
                if (ON.Contains("TFC7"))
                {
                    if (this.PissedAtTC7 < 32)
                    {
                        this.PissedAtTC7 = this.PissedAtTC7 + 8;
                    }
                    if (this.AngerLevel < 64)
                    {
                        this.AngerLevel = this.AngerLevel + 18;
                    }
                    this.Spot = false;
                }
            }
            if (this.TargetCode != 8)
            {
                if (ON.Contains("TFC8"))
                {
                    if (this.PissedAtTC8 < 32)
                    {
                        this.PissedAtTC8 = this.PissedAtTC8 + 8;
                    }
                    if (this.AngerLevel < 64)
                    {
                        this.AngerLevel = this.AngerLevel + 18;
                    }
                    this.Spot = false;
                }
            }
            if (this.TargetCode != 9)
            {
                if (ON.Contains("TFC9"))
                {
                    if (this.PissedAtTC9 < 32)
                    {
                        this.PissedAtTC9 = this.PissedAtTC9 + 8;
                    }
                    if (this.AngerLevel < 64)
                    {
                        this.AngerLevel = this.AngerLevel + 18;
                    }
                    this.Spot = false;
                }
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (other == null)
        {
            return;
        }
        string ON = other.name;
        Transform OT = other.transform;
        if (ON.Contains(this.IgnoreSelf))
        {
            return;
        }
        if (ON.Contains("TC"))
        {
            if (this.LookTarget)
            {
                if (this.Interest < 1)
                {
                    if (!this.LookTarget.name.Contains("TC"))
                    {
                        this.LookTarget = OT;
                        this.EyeLookTarget = OT;
                        this.Interest = 32;
                    }
                }
            }
            if (this.TargetCode != 1)
            {
                if (ON.Contains("TC1"))
                {
                    if (this.PissedAtTC1 > 8)
                    {
                        this.LookTarget = OT;
                        this.EyeLookTarget = OT;
                    }
                }
            }
            if (this.TargetCode != 2)
            {
                if (ON.Contains("TC2"))
                {
                    if (this.PissedAtTC3 > 8)
                    {
                        this.LookTarget = OT;
                        this.EyeLookTarget = OT;
                    }
                }
            }
            if (this.TargetCode != 3)
            {
                if (ON.Contains("TC3"))
                {
                    if (this.PissedAtTC3 > 8)
                    {
                        this.LookTarget = OT;
                        this.EyeLookTarget = OT;
                    }
                }
            }
            if (this.TargetCode != 4)
            {
                if (ON.Contains("TC4"))
                {
                    if (this.PissedAtTC4 > 8)
                    {
                        this.LookTarget = OT;
                        this.EyeLookTarget = OT;
                    }
                }
            }
            if (this.TargetCode != 5)
            {
                if (ON.Contains("TC5"))
                {
                    if (this.PissedAtTC5 > 8)
                    {
                        this.LookTarget = OT;
                        this.EyeLookTarget = OT;
                    }
                }
            }
            if (this.TargetCode != 6)
            {
                if (ON.Contains("TC6"))
                {
                    if (this.PissedAtTC6 > 8)
                    {
                        this.LookTarget = OT;
                        this.EyeLookTarget = OT;
                    }
                }
            }
            if (this.TargetCode != 7)
            {
                if (ON.Contains("TC7"))
                {
                    if (this.PissedAtTC7 > 8)
                    {
                        this.LookTarget = OT;
                        this.EyeLookTarget = OT;
                    }
                }
            }
            if (this.TargetCode != 8)
            {
                if (ON.Contains("TC8"))
                {
                    if (this.PissedAtTC8 > 8)
                    {
                        this.LookTarget = OT;
                        this.EyeLookTarget = OT;
                    }
                }
            }
            if (this.TargetCode != 9)
            {
                if (ON.Contains("TC9"))
                {
                    if (this.PissedAtTC9 > 8)
                    {
                        this.LookTarget = OT;
                        this.EyeLookTarget = OT;
                    }
                }
            }
        }
    }

    public virtual void PlaceRFoot(bool RFullPlace)
    {
        if (this.Walking)
        {
            if (this.LFootCJoint)
            {
                UnityEngine.Object.Destroy(this.LFootCJoint);
            }
        }
        if (this.RFootCJoint)
        {
            UnityEngine.Object.Destroy(this.RFootCJoint);
        }
        this.RFootCJoint = this.RFootGO.AddComponent<ConfigurableJoint>();
        this.RFootCJoint.autoConfigureConnectedAnchor = true;

        {
            JointDriveMode _1184 = JointDriveMode.Position;
            JointDrive _1185 = this.RFootCJoint.xDrive;
            _1185.mode = _1184;
            this.RFootCJoint.xDrive = _1185;
        }

        {
            JointDriveMode _1186 = JointDriveMode.Position;
            JointDrive _1187 = this.RFootCJoint.yDrive;
            _1187.mode = _1186;
            this.RFootCJoint.yDrive = _1187;
        }

        {
            JointDriveMode _1188 = JointDriveMode.Position;
            JointDrive _1189 = this.RFootCJoint.zDrive;
            _1189.mode = _1188;
            this.RFootCJoint.zDrive = _1189;
        }

        {
            int _1190 = 1000;
            JointDrive _1191 = this.RFootCJoint.xDrive;
            _1191.positionSpring = _1190;
            this.RFootCJoint.xDrive = _1191;
        }

        {
            int _1192 = 1000;
            JointDrive _1193 = this.RFootCJoint.yDrive;
            _1193.positionSpring = _1192;
            this.RFootCJoint.yDrive = _1193;
        }

        {
            int _1194 = 1000;
            JointDrive _1195 = this.RFootCJoint.zDrive;
            _1195.positionSpring = _1194;
            this.RFootCJoint.zDrive = _1195;
        }

        {
            int _1196 = 10;
            JointDrive _1197 = this.RFootCJoint.xDrive;
            _1197.positionDamper = _1196;
            this.RFootCJoint.xDrive = _1197;
        }

        {
            int _1198 = 10;
            JointDrive _1199 = this.RFootCJoint.yDrive;
            _1199.positionDamper = _1198;
            this.RFootCJoint.yDrive = _1199;
        }

        {
            int _1200 = 10;
            JointDrive _1201 = this.RFootCJoint.zDrive;
            _1201.positionDamper = _1200;
            this.RFootCJoint.zDrive = _1201;
        }

        {
            JointDriveMode _1202 = JointDriveMode.Position;
            JointDrive _1203 = this.RFootCJoint.angularXDrive;
            _1203.mode = _1202;
            this.RFootCJoint.angularXDrive = _1203;
        }

        {
            JointDriveMode _1204 = JointDriveMode.Position;
            JointDrive _1205 = this.RFootCJoint.angularYZDrive;
            _1205.mode = _1204;
            this.RFootCJoint.angularYZDrive = _1205;
        }

        {
            int _1206 = 0;
            JointDrive _1207 = this.RFootCJoint.angularXDrive;
            _1207.positionSpring = _1206;
            this.RFootCJoint.angularXDrive = _1207;
        }

        {
            int _1208 = 0;
            JointDrive _1209 = this.RFootCJoint.angularYZDrive;
            _1209.positionSpring = _1208;
            this.RFootCJoint.angularYZDrive = _1209;
        }

        {
            int _1210 = 0;
            JointDrive _1211 = this.RFootCJoint.angularXDrive;
            _1211.positionDamper = _1210;
            this.RFootCJoint.angularXDrive = _1211;
        }

        {
            int _1212 = 0;
            JointDrive _1213 = this.RFootCJoint.angularYZDrive;
            _1213.positionDamper = _1212;
            this.RFootCJoint.angularYZDrive = _1213;
        }
        this.RFootCol.enabled = true;
        if (!RFullPlace)
        {
            this.LFootCol.enabled = false;
        }
    }

    public virtual void PlaceLFoot(bool LFullPlace)
    {
        if (this.Walking)
        {
            if (this.RFootCJoint)
            {
                UnityEngine.Object.Destroy(this.RFootCJoint);
            }
        }
        if (this.LFootCJoint)
        {
            UnityEngine.Object.Destroy(this.LFootCJoint);
        }
        this.LFootCJoint = this.LFootGO.AddComponent<ConfigurableJoint>();
        this.LFootCJoint.autoConfigureConnectedAnchor = true;

        {
            JointDriveMode _1214 = JointDriveMode.Position;
            JointDrive _1215 = this.LFootCJoint.xDrive;
            _1215.mode = _1214;
            this.LFootCJoint.xDrive = _1215;
        }

        {
            JointDriveMode _1216 = JointDriveMode.Position;
            JointDrive _1217 = this.LFootCJoint.yDrive;
            _1217.mode = _1216;
            this.LFootCJoint.yDrive = _1217;
        }

        {
            JointDriveMode _1218 = JointDriveMode.Position;
            JointDrive _1219 = this.LFootCJoint.zDrive;
            _1219.mode = _1218;
            this.LFootCJoint.zDrive = _1219;
        }

        {
            int _1220 = 1000;
            JointDrive _1221 = this.LFootCJoint.xDrive;
            _1221.positionSpring = _1220;
            this.LFootCJoint.xDrive = _1221;
        }

        {
            int _1222 = 1000;
            JointDrive _1223 = this.LFootCJoint.yDrive;
            _1223.positionSpring = _1222;
            this.LFootCJoint.yDrive = _1223;
        }

        {
            int _1224 = 1000;
            JointDrive _1225 = this.LFootCJoint.zDrive;
            _1225.positionSpring = _1224;
            this.LFootCJoint.zDrive = _1225;
        }

        {
            int _1226 = 10;
            JointDrive _1227 = this.LFootCJoint.xDrive;
            _1227.positionDamper = _1226;
            this.LFootCJoint.xDrive = _1227;
        }

        {
            int _1228 = 10;
            JointDrive _1229 = this.LFootCJoint.yDrive;
            _1229.positionDamper = _1228;
            this.LFootCJoint.yDrive = _1229;
        }

        {
            int _1230 = 10;
            JointDrive _1231 = this.LFootCJoint.zDrive;
            _1231.positionDamper = _1230;
            this.LFootCJoint.zDrive = _1231;
        }

        {
            JointDriveMode _1232 = JointDriveMode.Position;
            JointDrive _1233 = this.LFootCJoint.angularXDrive;
            _1233.mode = _1232;
            this.LFootCJoint.angularXDrive = _1233;
        }

        {
            JointDriveMode _1234 = JointDriveMode.Position;
            JointDrive _1235 = this.LFootCJoint.angularYZDrive;
            _1235.mode = _1234;
            this.LFootCJoint.angularYZDrive = _1235;
        }

        {
            int _1236 = 0;
            JointDrive _1237 = this.LFootCJoint.angularXDrive;
            _1237.positionSpring = _1236;
            this.LFootCJoint.angularXDrive = _1237;
        }

        {
            int _1238 = 0;
            JointDrive _1239 = this.LFootCJoint.angularYZDrive;
            _1239.positionSpring = _1238;
            this.LFootCJoint.angularYZDrive = _1239;
        }

        {
            int _1240 = 0;
            JointDrive _1241 = this.LFootCJoint.angularXDrive;
            _1241.positionDamper = _1240;
            this.LFootCJoint.angularXDrive = _1241;
        }

        {
            int _1242 = 0;
            JointDrive _1243 = this.LFootCJoint.angularYZDrive;
            _1243.positionDamper = _1242;
            this.LFootCJoint.angularYZDrive = _1243;
        }
        this.LFootCol.enabled = true;
        if (!LFullPlace)
        {
            this.RFootCol.enabled = false;
        }
    }

    public virtual void Ticker()
    {
        if (this.LookTarget)
        {
            if (this.AngerLevel < 100)
            {
                if (this.Interest < 16)
                {
                    this.Notice();
                    if (!this.Walking)
                    {
                        this.Walking = true;
                        this.StartCoroutine(this.StartWalking());
                    }
                }
                else
                {
                    if (this.Interest > 24)
                    {
                        if (this.LookTarget.name.Contains("TC"))
                        {
                            if (this.LookTarget == this.KnownTarget)
                            {
                                this.Reset();
                            }
                            else
                            {
                                this.Stopping = true;
                            }
                        }
                    }
                }
            }
            else
            {
                if (this.LookTarget.name.Contains("TC1"))
                {
                    if (this.PissedAtTC1 > 8)
                    {
                        this.Reset();
                    }
                }
                if (this.LookTarget.name.Contains("TC3"))
                {
                    if (this.PissedAtTC3 > 8)
                    {
                        this.Reset();
                    }
                }
                if (this.LookTarget.name.Contains("TC4"))
                {
                    if (this.PissedAtTC4 > 8)
                    {
                        this.Reset();
                    }
                }
                if (this.LookTarget.name.Contains("TC5"))
                {
                    if (this.PissedAtTC5 > 8)
                    {
                        this.Reset();
                    }
                }
                if (this.LookTarget.name.Contains("TC6"))
                {
                    if (this.PissedAtTC6 > 8)
                    {
                        this.Reset();
                    }
                }
                if (this.LookTarget.name.Contains("TC7"))
                {
                    if (this.PissedAtTC7 > 8)
                    {
                        this.Reset();
                    }
                }
                if (this.LookTarget.name.Contains("TC8"))
                {
                    if (this.PissedAtTC8 > 8)
                    {
                        this.Reset();
                    }
                }
                if (this.LookTarget.name.Contains("TC9"))
                {
                    if (this.PissedAtTC9 > 8)
                    {
                        this.Reset();
                    }
                }
            }
        }
        else
        {
            this.Notice();
        }
        if (this.Jitter > 4)
        {
            this.StartCoroutine(this.Obsy());
            this.Jitter = 0;
        }
        if (this.Jitter > 0)
        {
            this.Jitter = this.Jitter - 1;
        }
        if (this.Interest > 0)
        {
            this.Interest = this.Interest - 1;
        }
        if (this.AngerLevel > 4)
        {
            this.AngerLevel = this.AngerLevel - 5;
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
        if (this.PissedAtTC6 > 0)
        {
            this.PissedAtTC6 = this.PissedAtTC6 - 1;
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
        if (this.Trigger.radius < 64)
        {
            this.Trigger.center = this.Trigger.center - new Vector3(0, 0, 2);
            this.Trigger.radius = this.Trigger.radius + 4;
        }
    }

    public virtual void Notice()
    {
        if (this.AngerLevel > 1)
        {
            return;
        }
        //Trigger.center = Vector3(0,0,-32);
        //Trigger.radius = 64;
        if (this.LookTarget)
        {
            if (this.LookTarget.name.Contains("TC"))
            {
                this.KnownTarget = this.LookTarget;
            }
        }
        int Interval = Random.Range(0, 8);
        switch (Interval)
        {
            case 1:
                this.Trigger.center = new Vector3(0, 0, 0);
                this.Trigger.radius = 0.1f;
                this.LookTarget = this.ResetTarget;
                break;
        }
        if (this.LookTarget == this.ResetTarget)
        {
            int Interval1 = Random.Range(0, 16);
            int Interval2 = Random.Range(0, 16);
            switch (Interval1)
            {
                case 1:
                    this.EyeLookTarget = this.EyeResetTarget;
                    break;
                case 2:
                    this.EyeLookTarget = this.EyeRandAim1;
                    break;
                case 3:
                    this.EyeLookTarget = this.EyeRandAim2;
                    break;
                case 4:
                    this.EyeLookTarget = this.EyeRandAim3;
                    break;
            }
            switch (Interval)
            {
                case 1:
                    this.LookTarget = this.RandAim1;
                    break;
                case 2:
                    this.LookTarget = this.RandAim2;
                    break;
                case 3:
                    this.LookTarget = this.RandAim3;
                    break;
            }
        }
        int Interval3 = Random.Range(0, 32);
        switch (Interval3)
        {
            case 1:
                this.Mood = 2;
                break;
            case 2:
                this.Mood = 1;
                break;
            case 3:
                this.Mood = 1;
                break;
        }
    }

    public virtual void Reset()
    {
        this.Trigger.center = new Vector3(0, 0, -32);
        this.Trigger.radius = 64;
        this.EyeLookTarget = this.EyeResetTarget;
        this.LookTarget = this.ResetTarget;
    }

    public virtual IEnumerator StartWalking()
    {
        this.Stopping = false;
        this.PredictPointMod = this.PredictPointModStat * 3;
        yield return new WaitForSeconds(0.5f);
        this.PredictPointMod = this.PredictPointModStat;
    }

    public virtual IEnumerator Obsy()
    {
        this.Obstacle = true;
        yield return new WaitForSeconds(1);
        this.Obstacle = false;
    }

    public CyraHeadController()
    {
        this.PredictPointMod = 1;
        this.PredictPointModStat = 1;
        this.GroundPointOffset = 0.5f;
        this.BodyTiltMod = 2;
        this.BodyTiltModStanding = 2;
        this.LegVelMod = 8;
        this.FullStepneurysm = 80;
        this.StepneurysmR = 1;
        this.StepneurysmL = 1;
        this.StepneurysmSpeed = 1;
        this.FootSCSize1 = 0.4f;
        this.FootSCSize2 = 0.28f;
        this.StepHeightCurve = new AnimationCurve();
        this.SHPCurve = new AnimationCurve();
        this.ArmBendCurve = new AnimationCurve();
        this.ForeArmBendCurve = new AnimationCurve();
        this.LookForce = 0.1f;
        this.EyeLookForce = 0.1f;
        this.RBrowMood = 100;
        this.LBrowMood = 100;
        this.RMouthMood = 10;
        this.LMouthMood = 10;
        this.JawMood = 10;
        this.Mood = 1;
        this.TargetCode = 2;
        this.AngerLevel = 1;
        this.TurnForceCurve = new AnimationCurve();
        this.TurnForce = 1;
        this.DirForce = 1;
        this.MaxVel = 1;
        this.RightDist = 200;
        this.LeftDist = 200;
        this.RUpDist = 200;
        this.RDownDist = 200;
        this.LUpDist = 200;
        this.LDownDist = 200;
        this.SenseDist = 50;
        this.IncThreshold = 1.5f;
        this.TurnEndSide = 10;
        this.TurnEndVert = 10;
        this.PissedAtTC0 = 1;
        this.PissedAtTC1 = 1;
        this.PissedAtTC2 = 1;
        this.PissedAtTC3 = 1;
        this.PissedAtTC4 = 1;
        this.PissedAtTC5 = 1;
        this.PissedAtTC6 = 1;
        this.PissedAtTC7 = 1;
        this.PissedAtTC8 = 1;
        this.PissedAtTC9 = 1;
    }

}