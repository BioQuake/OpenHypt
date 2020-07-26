using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BigHumanoidAI : MonoBehaviour
{
    public Transform ThisTF;
    public Rigidbody ThisRB;
    public float DirForce;
    public float AngForce;
    public static float StaticAngForce;
    public float MaxVel;
    public int MoodAtTC1;
    public int MoodAtTC2;
    public int MoodAtTC3;
    public int MoodAtTC4;
    public int MoodAtTC5;
    public int MoodAtTC6;
    public int MoodAtTC7;
    public int Interest;
    public int AngerLevel;
    public int Jitter;
    public bool Stay;
    public bool Walking;
    public bool Obstacle;
    public bool Right;
    public bool Left;
    public bool TurnRight;
    public bool TurnLeft;
    public AnimationCurve TurnForceCurve;
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
    public CyraHeadController HeadController;
    public Rigidbody RGhostHandRB;
    public float RHandMaxDist;
    public Transform RArmPivotTF;
    public Rigidbody RArmPivotRB;
    public ConfigurableJoint RCJoint;
    public ConfigurableJoint RHandCJoint;
    public GameObject RHandGO;
    public Rigidbody LGhostHandRB;
    public float LHandMaxDist;
    public Transform LArmPivotTF;
    public Rigidbody LArmPivotRB;
    public ConfigurableJoint LCJoint;
    public ConfigurableJoint LHandCJoint;
    public GameObject LHandGO;
    public Transform RReachPoint;
    public Transform LReachPoint;
    public float ArmAimForce;
    public float ArmPivotSpeed;
    public Transform ReachPointRF;
    public Transform ReachPointR;
    public Transform ReachPointLF;
    public Transform ReachPointL;
    public AnimationCurve ArmSwingCurveZ;
    public AnimationCurve ArmSwingCurveZ2;
    public AnimationCurve ArmSwingCurveY;
    public AnimationCurve ArmSwingCurveY2;
    public LegScript2 LLegScript;
    public LegScript2 RLegScript;
    public bool RAscend;
    public bool LAscend;
    public int StepTime;
    public int RStepNum;
    public int LStepNum;
    public float RAngle;
    public float LAngle;
    public float RNum;
    public float LNum;
    public float LAndR;
    public float FAndB;
    public LayerMask MtargetLayers;
    public virtual void Start()
    {
        this.InvokeRepeating("Ticker", 1, 0.5f);
        BigHumanoidAI.StaticAngForce = this.AngForce;
        GameObject RgO = new GameObject("RGhostHand");
        GameObject LgO = new GameObject("LGhostHand");
        RgO.transform.position = this.RArmPivotTF.position;
        RgO.transform.rotation = this.RArmPivotTF.rotation;
        RgO.transform.Translate(Vector3.down * 5);
        RgO.layer = 23;
        LgO.transform.position = this.LArmPivotTF.position;
        LgO.transform.rotation = this.LArmPivotTF.rotation;
        LgO.transform.Translate(Vector3.down * 5);
        LgO.layer = 23;
        this.RGhostHandRB = RgO.AddComponent<Rigidbody>();
        this.RGhostHandRB.mass = 0.01f;
        this.LGhostHandRB = LgO.AddComponent<Rigidbody>();
        this.LGhostHandRB.mass = 0.01f;
        this.RCJoint = RgO.AddComponent<ConfigurableJoint>();
        this.RCJoint.autoConfigureConnectedAnchor = false;
        this.RCJoint.connectedBody = this.RArmPivotRB;
        this.RCJoint.anchor = new Vector3(0, 0, 0);
        this.RCJoint.connectedAnchor = new Vector3(0, 0, -5.5f);
        this.RCJoint.axis = new Vector3(0, 0, 0);
        this.LCJoint = LgO.AddComponent<ConfigurableJoint>();
        this.LCJoint.autoConfigureConnectedAnchor = false;
        this.LCJoint.connectedBody = this.LArmPivotRB;
        this.LCJoint.anchor = new Vector3(0, 0, 0);
        this.LCJoint.connectedAnchor = new Vector3(0, 0, -5.5f);
        this.LCJoint.axis = new Vector3(0, 0, 0);

        {
            JointDriveMode _878 = JointDriveMode.Position;
            JointDrive _879 = this.RCJoint.xDrive;
            _879.mode = _878;
            this.RCJoint.xDrive = _879;
        }

        {
            JointDriveMode _880 = JointDriveMode.Position;
            JointDrive _881 = this.RCJoint.yDrive;
            _881.mode = _880;
            this.RCJoint.yDrive = _881;
        }

        {
            JointDriveMode _882 = JointDriveMode.Position;
            JointDrive _883 = this.RCJoint.zDrive;
            _883.mode = _882;
            this.RCJoint.zDrive = _883;
        }

        {
            JointDriveMode _884 = JointDriveMode.Position;
            JointDrive _885 = this.RCJoint.angularXDrive;
            _885.mode = _884;
            this.RCJoint.angularXDrive = _885;
        }

        {
            JointDriveMode _886 = JointDriveMode.Position;
            JointDrive _887 = this.RCJoint.angularYZDrive;
            _887.mode = _886;
            this.RCJoint.angularYZDrive = _887;
        }

        {
            JointDriveMode _888 = JointDriveMode.Position;
            JointDrive _889 = this.LCJoint.xDrive;
            _889.mode = _888;
            this.LCJoint.xDrive = _889;
        }

        {
            JointDriveMode _890 = JointDriveMode.Position;
            JointDrive _891 = this.LCJoint.yDrive;
            _891.mode = _890;
            this.LCJoint.yDrive = _891;
        }

        {
            JointDriveMode _892 = JointDriveMode.Position;
            JointDrive _893 = this.LCJoint.zDrive;
            _893.mode = _892;
            this.LCJoint.zDrive = _893;
        }

        {
            JointDriveMode _894 = JointDriveMode.Position;
            JointDrive _895 = this.LCJoint.angularXDrive;
            _895.mode = _894;
            this.LCJoint.angularXDrive = _895;
        }

        {
            JointDriveMode _896 = JointDriveMode.Position;
            JointDrive _897 = this.LCJoint.angularYZDrive;
            _897.mode = _896;
            this.LCJoint.angularYZDrive = _897;
        }

        {
            int _898 = 1000;
            JointDrive _899 = this.RCJoint.xDrive;
            _899.positionSpring = _898;
            this.RCJoint.xDrive = _899;
        }

        {
            int _900 = 1000;
            JointDrive _901 = this.RCJoint.yDrive;
            _901.positionSpring = _900;
            this.RCJoint.yDrive = _901;
        }

        {
            int _902 = 1;
            JointDrive _903 = this.RCJoint.zDrive;
            _903.positionSpring = _902;
            this.RCJoint.zDrive = _903;
        }

        {
            int _904 = 1000;
            JointDrive _905 = this.RCJoint.angularXDrive;
            _905.positionSpring = _904;
            this.RCJoint.angularXDrive = _905;
        }

        {
            int _906 = 1000;
            JointDrive _907 = this.RCJoint.angularYZDrive;
            _907.positionSpring = _906;
            this.RCJoint.angularYZDrive = _907;
        }

        {
            int _908 = 1000;
            JointDrive _909 = this.LCJoint.xDrive;
            _909.positionSpring = _908;
            this.LCJoint.xDrive = _909;
        }

        {
            int _910 = 1000;
            JointDrive _911 = this.LCJoint.yDrive;
            _911.positionSpring = _910;
            this.LCJoint.yDrive = _911;
        }

        {
            int _912 = 1;
            JointDrive _913 = this.LCJoint.zDrive;
            _913.positionSpring = _912;
            this.LCJoint.zDrive = _913;
        }

        {
            int _914 = 1000;
            JointDrive _915 = this.LCJoint.angularXDrive;
            _915.positionSpring = _914;
            this.LCJoint.angularXDrive = _915;
        }

        {
            int _916 = 1000;
            JointDrive _917 = this.LCJoint.angularYZDrive;
            _917.positionSpring = _916;
            this.LCJoint.angularYZDrive = _917;
        }
        this.RHandCJoint = this.RHandGO.AddComponent<ConfigurableJoint>();
        this.RHandCJoint.autoConfigureConnectedAnchor = false;
        this.RHandCJoint.connectedBody = this.RGhostHandRB;
        this.RHandCJoint.anchor = new Vector3(0, 0, 0);
        this.RHandCJoint.connectedAnchor = new Vector3(0, 0, 0);
        this.RHandCJoint.axis = new Vector3(0, 0, 0);
        this.LHandCJoint = this.LHandGO.AddComponent<ConfigurableJoint>();
        this.LHandCJoint.autoConfigureConnectedAnchor = false;
        this.LHandCJoint.connectedBody = this.LGhostHandRB;
        this.LHandCJoint.anchor = new Vector3(0, 0, 0);
        this.LHandCJoint.connectedAnchor = new Vector3(0, 0, 0);
        this.LHandCJoint.axis = new Vector3(0, 0, 0);

        {
            JointDriveMode _918 = JointDriveMode.Position;
            JointDrive _919 = this.RHandCJoint.xDrive;
            _919.mode = _918;
            this.RHandCJoint.xDrive = _919;
        }

        {
            JointDriveMode _920 = JointDriveMode.Position;
            JointDrive _921 = this.RHandCJoint.yDrive;
            _921.mode = _920;
            this.RHandCJoint.yDrive = _921;
        }

        {
            JointDriveMode _922 = JointDriveMode.Position;
            JointDrive _923 = this.RHandCJoint.zDrive;
            _923.mode = _922;
            this.RHandCJoint.zDrive = _923;
        }

        {
            float _924 = 0.1f;
            JointDrive _925 = this.RHandCJoint.xDrive;
            _925.positionSpring = _924;
            this.RHandCJoint.xDrive = _925;
        }

        {
            float _926 = 0.1f;
            JointDrive _927 = this.RHandCJoint.yDrive;
            _927.positionSpring = _926;
            this.RHandCJoint.yDrive = _927;
        }

        {
            float _928 = 0.1f;
            JointDrive _929 = this.RHandCJoint.zDrive;
            _929.positionSpring = _928;
            this.RHandCJoint.zDrive = _929;
        }

        {
            float _930 = 0.05f;
            JointDrive _931 = this.RHandCJoint.xDrive;
            _931.positionDamper = _930;
            this.RHandCJoint.xDrive = _931;
        }

        {
            float _932 = 0.05f;
            JointDrive _933 = this.RHandCJoint.yDrive;
            _933.positionDamper = _932;
            this.RHandCJoint.yDrive = _933;
        }

        {
            float _934 = 0.05f;
            JointDrive _935 = this.RHandCJoint.zDrive;
            _935.positionDamper = _934;
            this.RHandCJoint.zDrive = _935;
        }

        {
            JointDriveMode _936 = JointDriveMode.Position;
            JointDrive _937 = this.LHandCJoint.xDrive;
            _937.mode = _936;
            this.LHandCJoint.xDrive = _937;
        }

        {
            JointDriveMode _938 = JointDriveMode.Position;
            JointDrive _939 = this.LHandCJoint.yDrive;
            _939.mode = _938;
            this.LHandCJoint.yDrive = _939;
        }

        {
            JointDriveMode _940 = JointDriveMode.Position;
            JointDrive _941 = this.LHandCJoint.zDrive;
            _941.mode = _940;
            this.LHandCJoint.zDrive = _941;
        }

        {
            float _942 = 0.1f;
            JointDrive _943 = this.LHandCJoint.xDrive;
            _943.positionSpring = _942;
            this.LHandCJoint.xDrive = _943;
        }

        {
            float _944 = 0.1f;
            JointDrive _945 = this.LHandCJoint.yDrive;
            _945.positionSpring = _944;
            this.LHandCJoint.yDrive = _945;
        }

        {
            float _946 = 0.1f;
            JointDrive _947 = this.LHandCJoint.zDrive;
            _947.positionSpring = _946;
            this.LHandCJoint.zDrive = _947;
        }

        {
            float _948 = 0.05f;
            JointDrive _949 = this.LHandCJoint.xDrive;
            _949.positionDamper = _948;
            this.LHandCJoint.xDrive = _949;
        }

        {
            float _950 = 0.05f;
            JointDrive _951 = this.LHandCJoint.yDrive;
            _951.positionDamper = _950;
            this.LHandCJoint.yDrive = _951;
        }

        {
            float _952 = 0.05f;
            JointDrive _953 = this.LHandCJoint.zDrive;
            _953.positionDamper = _952;
            this.LHandCJoint.zDrive = _953;
        }

        {
            JointDriveMode _954 = JointDriveMode.Position;
            JointDrive _955 = this.RHandCJoint.angularXDrive;
            _955.mode = _954;
            this.RHandCJoint.angularXDrive = _955;
        }

        {
            JointDriveMode _956 = JointDriveMode.Position;
            JointDrive _957 = this.RHandCJoint.angularYZDrive;
            _957.mode = _956;
            this.RHandCJoint.angularYZDrive = _957;
        }

        {
            JointDriveMode _958 = JointDriveMode.Position;
            JointDrive _959 = this.LHandCJoint.angularXDrive;
            _959.mode = _958;
            this.LHandCJoint.angularXDrive = _959;
        }

        {
            JointDriveMode _960 = JointDriveMode.Position;
            JointDrive _961 = this.LHandCJoint.angularYZDrive;
            _961.mode = _960;
            this.LHandCJoint.angularYZDrive = _961;
        }

        {
            float _962 = 0.1f;
            JointDrive _963 = this.RHandCJoint.angularXDrive;
            _963.positionSpring = _962;
            this.RHandCJoint.angularXDrive = _963;
        }

        {
            float _964 = 0.1f;
            JointDrive _965 = this.RHandCJoint.angularYZDrive;
            _965.positionSpring = _964;
            this.RHandCJoint.angularYZDrive = _965;
        }

        {
            float _966 = 0.05f;
            JointDrive _967 = this.RHandCJoint.angularXDrive;
            _967.positionDamper = _966;
            this.RHandCJoint.angularXDrive = _967;
        }

        {
            float _968 = 0.05f;
            JointDrive _969 = this.RHandCJoint.angularYZDrive;
            _969.positionDamper = _968;
            this.RHandCJoint.angularYZDrive = _969;
        }

        {
            float _970 = 0.1f;
            JointDrive _971 = this.LHandCJoint.angularXDrive;
            _971.positionSpring = _970;
            this.LHandCJoint.angularXDrive = _971;
        }

        {
            float _972 = 0.1f;
            JointDrive _973 = this.LHandCJoint.angularYZDrive;
            _973.positionSpring = _972;
            this.LHandCJoint.angularYZDrive = _973;
        }

        {
            float _974 = 0.05f;
            JointDrive _975 = this.LHandCJoint.angularXDrive;
            _975.positionDamper = _974;
            this.LHandCJoint.angularXDrive = _975;
        }

        {
            float _976 = 0.05f;
            JointDrive _977 = this.LHandCJoint.angularYZDrive;
            _977.positionDamper = _976;
            this.LHandCJoint.angularYZDrive = _977;
        }
        this.RReachPoint.parent = null;
        this.LReachPoint.parent = null;
        if (this.RAscend)
        {
            this.RStepNum = 0;
            this.LStepNum = this.StepTime;
        }
        else
        {
            this.LStepNum = 0;
            this.RStepNum = this.StepTime;
        }
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        RaycastHit rHit1 = default(RaycastHit);
        RaycastHit rHit2 = default(RaycastHit);
        RaycastHit lHit1 = default(RaycastHit);
        RaycastHit lHit2 = default(RaycastHit);
        this.RAngle = Mathf.Abs(this.RUpDist - this.RDownDist);
        this.LAngle = Mathf.Abs(this.LUpDist - this.LDownDist);
        Vector3 newRot = -this.ThisTF.up.normalized;
        float VelClamp = Mathf.Clamp(this.ThisRB.velocity.magnitude * 10, this.SenseDist, 500);
        if (this.HeadController.LookTarget)
        {
            Vector3 relativePoint = this.ThisTF.InverseTransformPoint(this.HeadController.LookTarget.position);
        this.LAndR = relativePoint.x;
        this.FAndB = relativePoint.y;
        }
        Debug.DrawRay(((this.ThisTF.position + (this.ThisTF.right * this.TurnEndSide)) + (this.ThisTF.forward * this.TurnEndVert)) + (this.ThisTF.up * 4), newRot * VelClamp, Color.black);
        if (Physics.Raycast(((this.ThisTF.position + (this.ThisTF.right * this.TurnEndSide)) + (this.ThisTF.forward * this.TurnEndVert)) + (this.ThisTF.up * 4), newRot, out hit, VelClamp, (int) this.MtargetLayers))
        {
            this.RightDist = hit.distance;
        }
        else
        {
            this.RightDist = VelClamp;
        }
        Debug.DrawRay(((this.ThisTF.position + (-this.ThisTF.right * this.TurnEndSide)) + (this.ThisTF.forward * this.TurnEndVert)) + (this.ThisTF.up * 4), newRot * VelClamp, Color.black);
        if (Physics.Raycast(((this.ThisTF.position + (-this.ThisTF.right * this.TurnEndSide)) + (this.ThisTF.forward * this.TurnEndVert)) + (this.ThisTF.up * 4), newRot, out hit, VelClamp, (int) this.MtargetLayers))
        {
            this.LeftDist = hit.distance;
        }
        else
        {
            this.LeftDist = VelClamp;
        }
        Debug.DrawRay(((this.ThisTF.position + (this.ThisTF.right * this.TurnEndSide)) + (this.ThisTF.forward * 0.2f)) + (this.ThisTF.forward * this.TurnEndVert), (newRot * VelClamp) * 1.2f, Color.green);
        if (Physics.Raycast(((this.ThisTF.position + (this.ThisTF.right * this.TurnEndSide)) + (this.ThisTF.forward * 0.2f)) + (this.ThisTF.forward * this.TurnEndVert), -this.ThisTF.up, out rHit1, VelClamp, (int) this.MtargetLayers))
        {
            this.RUpDist = rHit1.distance;
        }
        else
        {
            this.RUpDist = 8;
        }
        Debug.DrawRay(((this.ThisTF.position + (this.ThisTF.right * this.TurnEndSide)) + (this.ThisTF.forward * -0.2f)) + (this.ThisTF.forward * this.TurnEndVert), (newRot * VelClamp) * 1.2f, Color.green);
        if (Physics.Raycast(((this.ThisTF.position + (this.ThisTF.right * this.TurnEndSide)) + (this.ThisTF.forward * -0.2f)) + (this.ThisTF.forward * this.TurnEndVert), -this.ThisTF.up, out rHit2, VelClamp, (int) this.MtargetLayers))
        {
            this.RDownDist = rHit2.distance;
        }
        else
        {
            this.RDownDist = 16;
        }
        Debug.DrawRay(((this.ThisTF.position + (-this.ThisTF.right * this.TurnEndSide)) + (this.ThisTF.forward * 0.2f)) + (this.ThisTF.forward * this.TurnEndVert), (newRot * VelClamp) * 1.2f, Color.green);
        if (Physics.Raycast(((this.ThisTF.position + (-this.ThisTF.right * this.TurnEndSide)) + (this.ThisTF.forward * 0.2f)) + (this.ThisTF.forward * this.TurnEndVert), -this.ThisTF.up, out lHit1, VelClamp, (int) this.MtargetLayers))
        {
            this.LUpDist = lHit1.distance;
        }
        else
        {
            this.LUpDist = 8;
        }
        Debug.DrawRay(((this.ThisTF.position + (-this.ThisTF.right * this.TurnEndSide)) + (this.ThisTF.forward * -0.2f)) + (this.ThisTF.forward * this.TurnEndVert), (newRot * VelClamp) * 1.2f, Color.green);
        if (Physics.Raycast(((this.ThisTF.position + (-this.ThisTF.right * this.TurnEndSide)) + (this.ThisTF.forward * -0.2f)) + (this.ThisTF.forward * this.TurnEndVert), -this.ThisTF.up, out lHit2, VelClamp, (int) this.MtargetLayers))
        {
            this.LDownDist = lHit2.distance;
        }
        else
        {
            this.LDownDist = 16;
        }
        if (this.RAngle < this.IncThreshold)
        {
            this.rSteepInc = true;
        }
        else
        {
            this.rSteepInc = false;
        }
        if (this.LAngle < this.IncThreshold)
        {
            this.lSteepInc = true;
        }
        else
        {
            this.lSteepInc = false;
        }
        this.TurnRight = false;
        this.TurnLeft = false;
        Debug.DrawRay(((this.ThisTF.position + (this.ThisTF.forward * 20)) + (this.ThisTF.right * this.TurnEndSide)) + (-this.ThisTF.up * 25), -this.ThisTF.forward * 35, Color.white);
        if (!Physics.Raycast(((this.ThisTF.position + (this.ThisTF.forward * 20)) + (this.ThisTF.right * this.TurnEndSide)) + (-this.ThisTF.up * 25), -this.ThisTF.forward, 35))
        {
            this.TurnLeft = true;
        }
        Debug.DrawRay(((this.ThisTF.position + (this.ThisTF.forward * 20)) + (-this.ThisTF.right * this.TurnEndSide)) + (-this.ThisTF.up * 25), -this.ThisTF.forward * 35, Color.white);
        if (!Physics.Raycast(((this.ThisTF.position + (this.ThisTF.forward * 20)) + (-this.ThisTF.right * this.TurnEndSide)) + (-this.ThisTF.up * 25), -this.ThisTF.forward, 35))
        {
            this.TurnRight = true;
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
        if (!this.Stay)
        {
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
                if (this.LAndR > 0)
                {
                    this.TurnRight = true;
                    this.TurnLeft = false;
                }
                else
                {
                    this.TurnRight = false;
                    this.TurnLeft = true;
                }
                if (this.FAndB > -11)
                {
                    this.Walking = false;
                }
                else
                {
                    this.Walking = true;
                }
            }
        }
        if (this.Obstacle)
        {
            this.TurnRight = false;
            this.TurnLeft = true;
        }
        if (this.Walking)
        {
            this.LReachPoint.position = this.ReachPointL.position;
            this.RReachPoint.position = this.ReachPointR.position;
            if (this.RAscend)
            {

                {
                    float _978 = this.ArmSwingCurveZ.Evaluate(this.RStepNum);
                    Vector3 _979 = this.ReachPointR.localPosition;
                    _979.y = _978;
                    this.ReachPointR.localPosition = _979;
                }
                this.RNum = this.ArmSwingCurveY.Evaluate(this.RStepNum);
            }
            else
            {

                {
                    float _980 = this.ArmSwingCurveZ2.Evaluate(this.RStepNum);
                    Vector3 _981 = this.ReachPointR.localPosition;
                    _981.y = _980;
                    this.ReachPointR.localPosition = _981;
                }
                this.RNum = this.ArmSwingCurveY2.Evaluate(this.RStepNum);
            }
            if (this.LAscend)
            {

                {
                    float _982 = this.ArmSwingCurveZ.Evaluate(this.LStepNum);
                    Vector3 _983 = this.ReachPointL.localPosition;
                    _983.y = _982;
                    this.ReachPointL.localPosition = _983;
                }
                this.LNum = this.ArmSwingCurveY.Evaluate(this.LStepNum);
            }
            else
            {

                {
                    float _984 = this.ArmSwingCurveZ2.Evaluate(this.LStepNum);
                    Vector3 _985 = this.ReachPointL.localPosition;
                    _985.y = _984;
                    this.ReachPointL.localPosition = _985;
                }
                this.LNum = this.ArmSwingCurveY2.Evaluate(this.LStepNum);
            }
        }
        else
        {
            this.LReachPoint.position = this.ReachPointLF.position;
            this.RReachPoint.position = this.ReachPointRF.position;
            this.RNum = 2;
            this.LNum = 2;
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.Walking)
        {
            if (this.ThisRB.velocity.magnitude < this.MaxVel)
            {
                this.ThisRB.AddForce(this.ThisTF.up * -this.DirForce);
            }
        }
        if (this.AngerLevel > 100)
        {
            this.AngForce = this.TurnForceCurve.Evaluate(this.LAndR);
        }
        else
        {
            this.AngForce = BigHumanoidAI.StaticAngForce;
        }
        if (this.TurnLeft && !this.TurnRight)
        {
            this.ThisRB.AddTorque(this.ThisTF.forward * -this.AngForce);
        }
        if (this.TurnRight && !this.TurnLeft)
        {
            this.ThisRB.AddTorque(this.ThisTF.forward * this.AngForce);
        }
        if (this.RArmPivotRB.angularVelocity.magnitude < this.ArmPivotSpeed)
        {
            this.RArmPivotRB.AddForceAtPosition((this.RReachPoint.position - this.RArmPivotTF.position).normalized * this.ArmAimForce, -this.RArmPivotTF.forward * 2);
            this.RArmPivotRB.AddForceAtPosition((this.RReachPoint.position - this.RArmPivotTF.position).normalized * -this.ArmAimForce, this.RArmPivotTF.forward * 2);
        }
        if (this.LArmPivotRB.angularVelocity.magnitude < this.ArmPivotSpeed)
        {
            this.LArmPivotRB.AddForceAtPosition((this.LReachPoint.position - this.LArmPivotTF.position).normalized * this.ArmAimForce, -this.LArmPivotTF.forward * 2);
            this.LArmPivotRB.AddForceAtPosition((this.LReachPoint.position - this.LArmPivotTF.position).normalized * -this.ArmAimForce, this.LArmPivotTF.forward * 2);
        }
        this.RCJoint.targetPosition = new Vector3(0, 0, this.RNum);
        this.LCJoint.targetPosition = new Vector3(0, 0, this.LNum);
        if (this.RAscend)
        {
            this.RStepNum = this.RStepNum + 1;
        }
        else
        {
            this.RStepNum = this.RStepNum - 1;
        }
        if (this.LAscend)
        {
            this.LStepNum = this.LStepNum + 1;
        }
        else
        {
            this.LStepNum = this.LStepNum - 1;
        }
        if (this.RStepNum > this.StepTime)
        {
            this.RAscend = false;
        }
        if (this.LStepNum > this.StepTime)
        {
            this.LAscend = false;
        }
        if (this.RStepNum < 1)
        {
            this.RAscend = true;
            this.LLegScript.StepNum = this.StepTime;
        }
        if (this.RStepNum > (this.StepTime - 1))
        {
            this.RAscend = false;
            this.LLegScript.StepNum = this.StepTime;
        }
        if (this.LStepNum < 1)
        {
            this.LAscend = true;
            this.RLegScript.StepNum = this.StepTime;
        }
        if (this.LStepNum > (this.StepTime - 1))
        {
            this.LAscend = false;
            this.RLegScript.StepNum = this.StepTime;
        }
        this.RLegScript.Ascend = this.RAscend;
        this.LLegScript.Ascend = this.LAscend;
        this.RLegScript.StepNum = this.RStepNum;
        this.LLegScript.StepNum = this.LStepNum;
    }

    public virtual void Ticker()
    {
        if (this.HeadController.LookTarget)
        {
            if (Vector3.Distance(this.transform.position, this.HeadController.LookTarget.position) < 100)
            {
                if (this.HeadController.LookTarget.name.Contains("TC1"))
                {
                    if (this.MoodAtTC1 < 200)
                    {
                        this.MoodAtTC1 = this.MoodAtTC1 + 100;
                        this.Walking = false;
                        this.Interest = 40;
                    }
                }
                if (this.HeadController.LookTarget.name.Contains("TC3"))
                {
                    if (this.MoodAtTC3 < 200)
                    {
                        this.MoodAtTC3 = this.MoodAtTC3 + 100;
                        this.Walking = false;
                        this.Interest = 40;
                    }
                }
                if (this.HeadController.LookTarget.name.Contains("TC4"))
                {
                    if (this.MoodAtTC4 < 200)
                    {
                        this.MoodAtTC4 = this.MoodAtTC4 + 100;
                        this.Walking = false;
                        this.Interest = 40;
                    }
                }
                if (this.HeadController.LookTarget.name.Contains("TC5"))
                {
                    if (this.MoodAtTC5 < 200)
                    {
                        this.MoodAtTC5 = this.MoodAtTC5 + 100;
                        this.Walking = false;
                        this.Interest = 40;
                    }
                }
                if (this.HeadController.LookTarget.name.Contains("TC6"))
                {
                    if (this.MoodAtTC6 < 200)
                    {
                        this.MoodAtTC6 = this.MoodAtTC6 + 100;
                        this.Walking = false;
                        this.Interest = 40;
                    }
                }
                if (this.HeadController.LookTarget.name.Contains("TC7"))
                {
                    if (this.MoodAtTC7 < 200)
                    {
                        this.MoodAtTC7 = this.MoodAtTC7 + 100;
                        this.Walking = false;
                        this.Interest = 40;
                    }
                }
            }
            if (this.AngerLevel < 100)
            {
                if (this.Interest < 1)
                {
                    this.HeadController.Notice();
                    if (!this.Walking && !this.Stay)
                    {
                        this.Walking = true;
                        this.RStepNum = 0;
                        this.LStepNum = this.StepTime;
                    }
                }
            }
            else
            {
                if (this.HeadController.LookTarget.name.Contains("TC1"))
                {
                    if (this.MoodAtTC1 > 200)
                    {
                        this.HeadController.Reset();
                    }
                }
                if (this.HeadController.LookTarget.name.Contains("TC3"))
                {
                    if (this.MoodAtTC3 > 200)
                    {
                        this.HeadController.Reset();
                    }
                }
                if (this.HeadController.LookTarget.name.Contains("TC4"))
                {
                    if (this.MoodAtTC4 > 200)
                    {
                        this.HeadController.Reset();
                    }
                }
                if (this.HeadController.LookTarget.name.Contains("TC5"))
                {
                    if (this.MoodAtTC5 > 200)
                    {
                        this.HeadController.Reset();
                    }
                }
                if (this.HeadController.LookTarget.name.Contains("TC6"))
                {
                    if (this.MoodAtTC6 > 200)
                    {
                        this.HeadController.Reset();
                    }
                }
                if (this.HeadController.LookTarget.name.Contains("TC7"))
                {
                    if (this.MoodAtTC7 > 200)
                    {
                        this.HeadController.Reset();
                    }
                }
            }
        }
        else
        {
            this.HeadController.Notice();
        }
        if (this.Jitter > 0)
        {
            this.Jitter = this.Jitter - 1;
        }
        if (this.Jitter > 10)
        {
            this.StartCoroutine(this.Obsy());
            this.Jitter = 0;
        }
        if (this.Interest > 0)
        {
            this.Interest = this.Interest - 2;
        }
        if (this.AngerLevel > 4)
        {
            this.AngerLevel = this.AngerLevel - 5;
        }
        if (this.MoodAtTC1 > 0)
        {
            this.MoodAtTC1 = this.MoodAtTC1 - 1;
        }
        if (this.MoodAtTC3 > 0)
        {
            this.MoodAtTC3 = this.MoodAtTC3 - 1;
        }
        if (this.MoodAtTC4 > 0)
        {
            this.MoodAtTC4 = this.MoodAtTC4 - 1;
        }
        if (this.MoodAtTC5 > 0)
        {
            this.MoodAtTC5 = this.MoodAtTC5 - 1;
        }
        if (this.MoodAtTC6 > 0)
        {
            this.MoodAtTC6 = this.MoodAtTC6 - 1;
        }
        if (this.MoodAtTC7 > 0)
        {
            this.MoodAtTC7 = this.MoodAtTC7 - 1;
        }
    }

    public virtual IEnumerator Obsy()
    {
        this.Obstacle = true;
        yield return new WaitForSeconds(1);
        this.Obstacle = false;
    }

    public BigHumanoidAI()
    {
        this.DirForce = 50;
        this.AngForce = 50;
        this.MaxVel = 7;
        this.TurnForceCurve = new AnimationCurve();
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
        this.RHandMaxDist = 5;
        this.LHandMaxDist = 5;
        this.ArmAimForce = 8;
        this.ArmPivotSpeed = 2;
        this.ArmSwingCurveZ = new AnimationCurve();
        this.ArmSwingCurveZ2 = new AnimationCurve();
        this.ArmSwingCurveY = new AnimationCurve();
        this.ArmSwingCurveY2 = new AnimationCurve();
        this.StepTime = 90;
    }

    static BigHumanoidAI()
    {
        BigHumanoidAI.StaticAngForce = 50;
    }

}