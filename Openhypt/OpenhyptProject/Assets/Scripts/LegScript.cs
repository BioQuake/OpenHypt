using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class LegScript : MonoBehaviour
{
    public Transform VesselTF;
    public Transform FootTF;
    public GameObject FootGO;
    public Rigidbody FootRB;
    public Transform PivotTF;
    public Rigidbody PivotRB;
    public Transform theParent;
    public Transform GroundPoint;
    public LayerMask targetLayers;
    public Rigidbody VesselRB;
    public Rigidbody GhostLegRB;
    public Rigidbody GyroPointRB;
    public LegScript OtherLegScript;
    public ConfigurableJoint CJoint;
    public ConfigurableJoint FootCJoint;
    public ConfigurableJoint FootAngCJoint;
    public bool breaksOn;
    public bool OnNPC;
    public float FootMaxForce;
    public float FootMaxDist;
    public float CounterForce;
    public AnimationCurve CounterForceCurve;
    public float DirForce;
    public float AngForce;
    public float MaxFVel;
    public float MaxRVel;
    public bool Ascend;
    public GameObject AscendSound;
    public GameObject DescendSound;
    public float GroundFeelDist;
    public bool Stepped;
    public bool KeyW;
    public bool KeyA;
    public bool KeyS;
    public bool KeyD;
    public bool RightSideLeg;
    public bool UseFootAim;
    public float FootAimForce;
    public Transform FootAngler;
    public float FullStride;
    public float GroundClearance;
    public float LegLiftSpeed;
    public AnimationCurve LiftSpeedModCurve;
    public AnimationCurve DropSpeedModCurve;
    public float LegPivotSpeed;
    public float MinStride;
    public float MaxStride;
    public float StrideDistMod;
    public float RevStrideDistMod;
    public float StepAimForce;
    public AnimationCurve StepAimForceCurve;
    public int StepTime;
    public int StepNum;
    public float AngMod;
    public float Num;
    public AnimationCurve curve;
    private int PStepTime;
    private float PStrideDistMod;
    private float PGroundClearance;
    private float PFootMaxForce;
    public virtual void Start()
    {
        GameObject gO = new GameObject("GhostLeg");
        gO.transform.parent = this.theParent;
        gO.transform.position = this.transform.position;
        gO.transform.rotation = this.transform.rotation;
        gO.transform.Translate(Vector3.back * 5);
        gO.layer = 23;
        this.GhostLegRB = gO.AddComponent<Rigidbody>();
        this.GhostLegRB.mass = 0.1f;
        //var SCol = gO.AddComponent ("SphereCollider");
        //SCol.radius = 1;
        this.CJoint = gO.AddComponent<ConfigurableJoint>();
        this.CJoint.autoConfigureConnectedAnchor = false;
        this.CJoint.connectedBody = this.PivotRB;
        this.CJoint.anchor = new Vector3(0, 0, 0);
        this.CJoint.connectedAnchor = new Vector3(0, 0, -this.FootMaxDist);
        this.CJoint.axis = new Vector3(0, 0, 0);

        {
            JointDriveMode _2144 = JointDriveMode.Position;
            JointDrive _2145 = this.CJoint.xDrive;
            _2145.mode = _2144;
            this.CJoint.xDrive = _2145;
        }

        {
            JointDriveMode _2146 = JointDriveMode.Position;
            JointDrive _2147 = this.CJoint.yDrive;
            _2147.mode = _2146;
            this.CJoint.yDrive = _2147;
        }

        {
            JointDriveMode _2148 = JointDriveMode.Position;
            JointDrive _2149 = this.CJoint.zDrive;
            _2149.mode = _2148;
            this.CJoint.zDrive = _2149;
        }

        {
            JointDriveMode _2150 = JointDriveMode.Position;
            JointDrive _2151 = this.CJoint.angularXDrive;
            _2151.mode = _2150;
            this.CJoint.angularXDrive = _2151;
        }

        {
            JointDriveMode _2152 = JointDriveMode.Position;
            JointDrive _2153 = this.CJoint.angularYZDrive;
            _2153.mode = _2152;
            this.CJoint.angularYZDrive = _2153;
        }

        {
            int _2154 = 1000;
            JointDrive _2155 = this.CJoint.xDrive;
            _2155.positionSpring = _2154;
            this.CJoint.xDrive = _2155;
        }

        {
            int _2156 = 1000;
            JointDrive _2157 = this.CJoint.yDrive;
            _2157.positionSpring = _2156;
            this.CJoint.yDrive = _2157;
        }

        {
            int _2158 = 1000;
            JointDrive _2159 = this.CJoint.zDrive;
            _2159.positionSpring = _2158;
            this.CJoint.zDrive = _2159;
        }

        {
            int _2160 = 1000;
            JointDrive _2161 = this.CJoint.angularXDrive;
            _2161.positionSpring = _2160;
            this.CJoint.angularXDrive = _2161;
        }

        {
            int _2162 = 1000;
            JointDrive _2163 = this.CJoint.angularYZDrive;
            _2163.positionSpring = _2162;
            this.CJoint.angularYZDrive = _2163;
        }
        this.FootCJoint = this.FootGO.AddComponent<ConfigurableJoint>();
        this.FootCJoint.autoConfigureConnectedAnchor = false;
        this.FootCJoint.connectedBody = this.GhostLegRB;
        this.FootCJoint.anchor = new Vector3(0, 0, 0);
        this.FootCJoint.connectedAnchor = new Vector3(0, 0, 0);
        this.FootCJoint.axis = new Vector3(0, 0, 0);

        {
            JointDriveMode _2164 = JointDriveMode.Position;
            JointDrive _2165 = this.FootCJoint.xDrive;
            _2165.mode = _2164;
            this.FootCJoint.xDrive = _2165;
        }

        {
            JointDriveMode _2166 = JointDriveMode.Position;
            JointDrive _2167 = this.FootCJoint.yDrive;
            _2167.mode = _2166;
            this.FootCJoint.yDrive = _2167;
        }

        {
            JointDriveMode _2168 = JointDriveMode.Position;
            JointDrive _2169 = this.FootCJoint.zDrive;
            _2169.mode = _2168;
            this.FootCJoint.zDrive = _2169;
        }

        {
            int _2170 = 1000;
            JointDrive _2171 = this.FootCJoint.xDrive;
            _2171.positionSpring = _2170;
            this.FootCJoint.xDrive = _2171;
        }

        {
            int _2172 = 1000;
            JointDrive _2173 = this.FootCJoint.yDrive;
            _2173.positionSpring = _2172;
            this.FootCJoint.yDrive = _2173;
        }

        {
            int _2174 = 1000;
            JointDrive _2175 = this.FootCJoint.zDrive;
            _2175.positionSpring = _2174;
            this.FootCJoint.zDrive = _2175;
        }

        {
            int _2176 = 100;
            JointDrive _2177 = this.FootCJoint.xDrive;
            _2177.positionDamper = _2176;
            this.FootCJoint.xDrive = _2177;
        }

        {
            int _2178 = 100;
            JointDrive _2179 = this.FootCJoint.yDrive;
            _2179.positionDamper = _2178;
            this.FootCJoint.yDrive = _2179;
        }

        {
            int _2180 = 100;
            JointDrive _2181 = this.FootCJoint.zDrive;
            _2181.positionDamper = _2180;
            this.FootCJoint.zDrive = _2181;
        }

        {
            JointDriveMode _2182 = JointDriveMode.Position;
            JointDrive _2183 = this.FootCJoint.angularXDrive;
            _2183.mode = _2182;
            this.FootCJoint.angularXDrive = _2183;
        }

        {
            JointDriveMode _2184 = JointDriveMode.Position;
            JointDrive _2185 = this.FootCJoint.angularYZDrive;
            _2185.mode = _2184;
            this.FootCJoint.angularYZDrive = _2185;
        }

        {
            float _2186 = 0.1f;
            JointDrive _2187 = this.FootCJoint.angularXDrive;
            _2187.positionSpring = _2186;
            this.FootCJoint.angularXDrive = _2187;
        }

        {
            float _2188 = 0.1f;
            JointDrive _2189 = this.FootCJoint.angularYZDrive;
            _2189.positionSpring = _2188;
            this.FootCJoint.angularYZDrive = _2189;
        }

        {
            float _2190 = 0.05f;
            JointDrive _2191 = this.FootCJoint.angularXDrive;
            _2191.positionDamper = _2190;
            this.FootCJoint.angularXDrive = _2191;
        }

        {
            float _2192 = 0.05f;
            JointDrive _2193 = this.FootCJoint.angularYZDrive;
            _2193.positionDamper = _2192;
            this.FootCJoint.angularYZDrive = _2193;
        }
        if (this.Ascend)
        {
            this.StepNum = 0;
        }
        else
        {
            this.StepNum = this.StepTime + 1;
        }
        this.Stepped = true;
        this.PStepTime = this.StepTime;
        this.PStrideDistMod = this.StrideDistMod;
        this.PGroundClearance = this.GroundClearance;
        this.PFootMaxForce = this.FootMaxForce;
        this.GroundPoint.parent = this.theParent;
        if (this.OnNPC)
        {
            this.breaksOn = false;
        }
    }

    public virtual void Update()
    {
        if (this.OnNPC)
        {
            this.breaksOn = false;
        }
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            if (CameraScript.InInterface == false)
            {
                if (Input.GetKeyDown("w") && !this.breaksOn)
                {
                    this.KeyW = true;
                }
                if (Input.GetKeyUp("w"))
                {
                    this.KeyW = false;
                }
                if (Input.GetKeyDown("a") && !this.breaksOn)
                {
                    this.KeyA = true;
                }
                if (Input.GetKeyUp("a"))
                {
                    this.KeyA = false;
                }
                if (Input.GetKeyDown("s") && !this.breaksOn)
                {
                    this.KeyS = true;
                }
                if (Input.GetKeyUp("s"))
                {
                    this.KeyS = false;
                }
                if (Input.GetKeyDown("d") && !this.breaksOn)
                {
                    this.KeyD = true;
                }
                if (Input.GetKeyUp("d"))
                {
                    this.KeyD = false;
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        Vector3 localV = this.VesselTF.InverseTransformDirection(this.VesselRB.velocity);
        float Vel = -localV.z;
        float VelClamp = this.LiftSpeedModCurve.Evaluate(this.GyroPointRB.velocity.magnitude);
        float VelClamp2 = this.DropSpeedModCurve.Evaluate(this.GyroPointRB.velocity.magnitude);
        float LVelClamp = Mathf.Clamp(Vel, 0.5f, this.FootMaxForce);
        this.AngMod = this.VesselRB.angularVelocity.magnitude * 2;
        float AngClamp = Mathf.Clamp(this.AngMod, 1, 4);
        if (this.GyroPointRB.velocity != Vector3.zero)
        {
            this.GroundPoint.rotation = Quaternion.LookRotation(this.GyroPointRB.velocity);
        }
        Debug.DrawRay(this.PivotTF.position, Vector3.down * 32f, Color.green);
        if (Physics.Raycast(this.PivotTF.position, Vector3.down, out hit, 32, (int) this.targetLayers))
        {
            this.FootMaxForce = this.curve.Evaluate(hit.distance);
            this.GroundPoint.position = hit.point;
        }
        this.StepAimForce = this.StepAimForceCurve.Evaluate(this.GyroPointRB.velocity.magnitude);
        float Y = this.GroundPoint.eulerAngles.y;
        float Z = this.GroundPoint.eulerAngles.z;
        if (!this.breaksOn)
        {
            if (this.Ascend)
            {
                this.StepNum = this.StepNum + 1;
                if (this.Stepped)
                {
                    if (!Physics.Raycast(this.FootTF.position, -this.FootTF.forward, this.GroundFeelDist, (int) this.targetLayers))
                    {
                        if (this.AscendSound)
                        {
                            GameObject TheSound1 = UnityEngine.Object.Instantiate(this.AscendSound, this.transform.position, this.transform.rotation);
                            TheSound1.transform.parent = this.PivotTF;
                        }
                        this.Stepped = false;
                    }
                }
                if (this.UseFootAim)
                {
                    this.FootAngCJoint.angularXMotion = ConfigurableJointMotion.Free;
                }

                {
                    JointDriveMode _2194 = JointDriveMode.None;
                    JointDrive _2195 = this.FootCJoint.angularXDrive;
                    _2195.mode = _2194;
                    this.FootCJoint.angularXDrive = _2195;
                }

                {
                    JointDriveMode _2196 = JointDriveMode.None;
                    JointDrive _2197 = this.FootCJoint.angularYZDrive;
                    _2197.mode = _2196;
                    this.FootCJoint.angularYZDrive = _2197;
                }
                this.GroundPoint.rotation = Quaternion.Euler(0, Y, Z);
                this.GroundPoint.position = this.GroundPoint.position + ((this.GroundPoint.forward * this.GyroPointRB.velocity.magnitude) * this.StrideDistMod);
                if (this.Num > this.FullStride)
                {
                    Debug.DrawRay(this.FootTF.position + (-this.VesselTF.up * 1.5f), Vector3.down * this.GroundClearance, Color.green);
                    if (Physics.Raycast(this.FootTF.position + (-this.VesselTF.up * 1.5f), Vector3.down, out hit, this.GroundClearance, (int) this.targetLayers) || Physics.Raycast(this.FootTF.position, Vector3.down, out hit, this.GroundClearance, (int) this.targetLayers))
                    {
                        this.Num = this.Num - (VelClamp * this.LegLiftSpeed);
                    }
                }
            }
            else
            {
                this.StepNum = this.StepNum - 1;
                if (!this.Stepped)
                {
                    if (Physics.Raycast(this.FootTF.position, -this.FootTF.forward, this.GroundFeelDist, (int) this.targetLayers))
                    {
                        if (this.DescendSound)
                        {
                            GameObject TheSound2 = UnityEngine.Object.Instantiate(this.DescendSound, this.FootTF.position, this.FootTF.rotation);
                            TheSound2.transform.parent = this.FootTF;
                        }
                        this.Stepped = true;
                    }
                }
                if (this.UseFootAim)
                {
                    this.FootAngCJoint.angularXMotion = ConfigurableJointMotion.Locked;
                }

                {
                    JointDriveMode _2198 = JointDriveMode.Position;
                    JointDrive _2199 = this.FootCJoint.angularXDrive;
                    _2199.mode = _2198;
                    this.FootCJoint.angularXDrive = _2199;
                }

                {
                    JointDriveMode _2200 = JointDriveMode.Position;
                    JointDrive _2201 = this.FootCJoint.angularYZDrive;
                    _2201.mode = _2200;
                    this.FootCJoint.angularYZDrive = _2201;
                }
                this.GroundPoint.rotation = Quaternion.Euler(0, Y, Z);
                this.GroundPoint.position = this.GroundPoint.position + ((this.GroundPoint.forward * this.GyroPointRB.velocity.magnitude) * this.StrideDistMod);
                if (this.Num < 0)
                {
                    this.Num = this.Num + (VelClamp2 * this.LegLiftSpeed);
                }
            }
        }
        if (this.PivotRB.angularVelocity.magnitude < this.LegPivotSpeed)
        {
            this.PivotRB.AddForceAtPosition(((this.GroundPoint.position - this.PivotTF.position).normalized * this.StepAimForce) * AngClamp, -this.PivotTF.forward * 2);
            this.PivotRB.AddForceAtPosition(((this.GroundPoint.position - this.PivotTF.position).normalized * -this.StepAimForce) * AngClamp, this.PivotTF.forward * 2);
        }
        if (this.UseFootAim)
        {
            Debug.DrawRay(this.FootTF.position, Vector3.down * this.GroundClearance, Color.green);
            if (Physics.Raycast(this.FootTF.position, Vector3.down, out hit, this.GroundClearance, (int) this.targetLayers))
            {
                this.FootAngler.rotation = Quaternion.LookRotation(hit.normal);
            }
        }
        if (this.StepNum > this.StepTime)
        {
            this.Ascend = false;
        }
        if (this.StepNum < 1)
        {
            this.Ascend = true;
            if (this.OtherLegScript)
            {
                this.OtherLegScript.StepNum = this.StepTime;
            }
        }
        if (this.KeyW && !this.KeyS)
        {
            this.GroundClearance = this.PGroundClearance;
            if (this.GyroPointRB.velocity.magnitude < this.MaxFVel)
            {
                this.VesselRB.GetComponent<Rigidbody>().AddForce(this.VesselRB.transform.up * -this.DirForce);
            }
            if (this.Ascend)
            {
                this.CounterForce = this.CounterForceCurve.Evaluate(this.StepNum);
                if (!this.RightSideLeg)
                {
                    this.VesselRB.GetComponent<Rigidbody>().AddTorque(this.VesselRB.transform.forward * this.CounterForce);
                }
                else
                {
                    this.VesselRB.GetComponent<Rigidbody>().AddTorque(this.VesselRB.transform.forward * -this.CounterForce);
                }
                this.StrideDistMod = this.PStrideDistMod;
            }
            else
            {
                this.StrideDistMod = this.PStrideDistMod;
            }
        }
        if (this.KeyS && !this.KeyW)
        {
            this.GroundClearance = this.PGroundClearance;
            if (this.GyroPointRB.velocity.magnitude < this.MaxRVel)
            {
                this.VesselRB.GetComponent<Rigidbody>().AddForce(this.VesselRB.transform.up * this.DirForce);
            }
            if (this.Ascend)
            {
                this.StrideDistMod = this.RevStrideDistMod;
            }
            else
            {
                this.StrideDistMod = this.PStrideDistMod;
            }
        }
        if (this.KeyA)
        {
            this.VesselRB.GetComponent<Rigidbody>().AddTorque(this.VesselRB.transform.forward * -this.AngForce);
            this.GroundClearance = this.PGroundClearance;
        }
        if (this.KeyD)
        {
            this.VesselRB.GetComponent<Rigidbody>().AddTorque(this.VesselRB.transform.forward * this.AngForce);
            this.GroundClearance = this.PGroundClearance;
        }
        if (((!this.KeyW && !this.KeyA) && !this.KeyS) && !this.KeyD)
        {
            this.StrideDistMod = this.PStrideDistMod;
            float GCClamp = Mathf.Clamp(Vector3.Distance(this.FootTF.position, this.GroundPoint.position), 0.01f, this.PGroundClearance);
            this.GroundClearance = GCClamp;
        }

        {
            float _2202 = this.FootMaxForce * LVelClamp;
            JointDrive _2203 = this.FootCJoint.xDrive;
            _2203.maximumForce = _2202;
            this.FootCJoint.xDrive = _2203;
        }

        {
            float _2204 = this.FootMaxForce * LVelClamp;
            JointDrive _2205 = this.FootCJoint.yDrive;
            _2205.maximumForce = _2204;
            this.FootCJoint.yDrive = _2205;
        }

        {
            float _2206 = this.FootMaxForce * LVelClamp;
            JointDrive _2207 = this.FootCJoint.zDrive;
            _2207.maximumForce = _2206;
            this.FootCJoint.zDrive = _2207;
        }
        this.CJoint.targetPosition = new Vector3(0, 0, this.Num);
    }

    public LegScript()
    {
        this.FootMaxForce = 0.5f;
        this.FootMaxDist = 5;
        this.CounterForce = 1;
        this.CounterForceCurve = new AnimationCurve();
        this.DirForce = 2;
        this.AngForce = 2;
        this.MaxFVel = 7;
        this.MaxRVel = 7;
        this.GroundFeelDist = 1;
        this.FootAimForce = 1;
        this.FullStride = -2.5f;
        this.GroundClearance = 1;
        this.LegLiftSpeed = 1;
        this.LiftSpeedModCurve = new AnimationCurve();
        this.DropSpeedModCurve = new AnimationCurve();
        this.LegPivotSpeed = 0.2f;
        this.MaxStride = 1;
        this.StrideDistMod = 0.5f;
        this.RevStrideDistMod = 2;
        this.StepAimForce = 1;
        this.StepAimForceCurve = new AnimationCurve();
        this.StepTime = 100;
        this.curve = new AnimationCurve();
    }

}