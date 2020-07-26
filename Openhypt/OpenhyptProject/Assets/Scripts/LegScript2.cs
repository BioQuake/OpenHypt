using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class LegScript2 : MonoBehaviour
{
    public Transform VesselTF;
    public Transform FootTF;
    public GameObject FootGO;
    public Rigidbody FootRB;
    public Transform PivotTF;
    public Rigidbody PivotRB;
    public Transform BodyTF;
    public BigHumanoidAI MainAI;
    public Transform GroundPoint;
    public float GroundPointOffset;
    public LayerMask targetLayers;
    public Rigidbody VesselRB;
    public Rigidbody Vessel2RB;
    public Rigidbody GhostLegRB;
    public Rigidbody GyroPointRB;
    public LegScript OtherLegScript;
    public ConfigurableJoint CJoint;
    public ConfigurableJoint FootCJoint;
    public ConfigurableJoint FootAngCJoint;
    public float FootSensorY;
    public float FootSensorZ;
    public float FootForce;
    public AnimationCurve FootMaxForceCurve;
    public float FootMaxDist;
    public float GroundDistForce;
    public AnimationCurve GroundDistForceCurve;
    public bool UseCounterForce;
    public AnimationCurve CounterForceCurve;
    public AnimationCurve CounterForceCurve2;
    public bool Obstacle;
    public bool Nullstacle;
    public float GroundFeelDist;
    public bool FootPlaced;
    public bool Ascend;
    public GameObject AscendSound;
    public GameObject DescendSound;
    public bool Stepped;
    public bool RightSideLeg;
    public HingeJoint KneeJoint;
    public bool UseLegAim;
    public Transform LegTF;
    public Rigidbody LegRB;
    public bool UseFootAim;
    public Transform FootAngler;
    public AnimationCurve FootTorqueCurve;
    public AnimationCurve FootTorqueCurve2;
    public AnimationCurve GroundClearanceCurve;
    public float FullStride;
    public float GroundClearance;
    public float LiftSpeedMod;
    public AnimationCurve LegLiftCurve;
    public AnimationCurve LegDownCurve;
    public float LegPivotSpeed;
    public AnimationCurve KneeDampCurve;
    public AnimationCurve StrideDistMod;
    public float Vel;
    public AnimationCurve VelCurve;
    public AnimationCurve VelCurve2;
    public AnimationCurve VelCurve3;
    public AnimationCurve VelCurve4;
    public AnimationCurve StraightenCurve;
    public AnimationCurve FootDistForceCurve;
    public float StepAimForce;
    public AnimationCurve StepAimForceCurve;
    public int StepNum;
    public float AngMod;
    public float Num;
    private float PGroundClearance;
    public virtual void Start()
    {
        GameObject gO = new GameObject("GhostLeg");
        //gO.transform.parent = gameObject.transform;
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
            JointDriveMode _2208 = JointDriveMode.Position;
            JointDrive _2209 = this.CJoint.xDrive;
            _2209.mode = _2208;
            this.CJoint.xDrive = _2209;
        }

        {
            JointDriveMode _2210 = JointDriveMode.Position;
            JointDrive _2211 = this.CJoint.yDrive;
            _2211.mode = _2210;
            this.CJoint.yDrive = _2211;
        }

        {
            JointDriveMode _2212 = JointDriveMode.Position;
            JointDrive _2213 = this.CJoint.zDrive;
            _2213.mode = _2212;
            this.CJoint.zDrive = _2213;
        }

        {
            JointDriveMode _2214 = JointDriveMode.Position;
            JointDrive _2215 = this.CJoint.angularXDrive;
            _2215.mode = _2214;
            this.CJoint.angularXDrive = _2215;
        }

        {
            JointDriveMode _2216 = JointDriveMode.Position;
            JointDrive _2217 = this.CJoint.angularYZDrive;
            _2217.mode = _2216;
            this.CJoint.angularYZDrive = _2217;
        }

        {
            int _2218 = 1000;
            JointDrive _2219 = this.CJoint.xDrive;
            _2219.positionSpring = _2218;
            this.CJoint.xDrive = _2219;
        }

        {
            int _2220 = 1000;
            JointDrive _2221 = this.CJoint.yDrive;
            _2221.positionSpring = _2220;
            this.CJoint.yDrive = _2221;
        }

        {
            int _2222 = 1000;
            JointDrive _2223 = this.CJoint.zDrive;
            _2223.positionSpring = _2222;
            this.CJoint.zDrive = _2223;
        }

        {
            int _2224 = 1000;
            JointDrive _2225 = this.CJoint.angularXDrive;
            _2225.positionSpring = _2224;
            this.CJoint.angularXDrive = _2225;
        }

        {
            int _2226 = 1000;
            JointDrive _2227 = this.CJoint.angularYZDrive;
            _2227.positionSpring = _2226;
            this.CJoint.angularYZDrive = _2227;
        }
        this.FootCJoint = this.FootGO.AddComponent<ConfigurableJoint>();
        this.FootCJoint.autoConfigureConnectedAnchor = false;
        this.FootCJoint.connectedBody = this.GhostLegRB;
        this.FootCJoint.anchor = new Vector3(0, 0, 0);
        this.FootCJoint.connectedAnchor = new Vector3(0, 0, 0);
        this.FootCJoint.axis = new Vector3(0, 0, 0);

        {
            JointDriveMode _2228 = JointDriveMode.Position;
            JointDrive _2229 = this.FootCJoint.xDrive;
            _2229.mode = _2228;
            this.FootCJoint.xDrive = _2229;
        }

        {
            JointDriveMode _2230 = JointDriveMode.Position;
            JointDrive _2231 = this.FootCJoint.yDrive;
            _2231.mode = _2230;
            this.FootCJoint.yDrive = _2231;
        }

        {
            JointDriveMode _2232 = JointDriveMode.Position;
            JointDrive _2233 = this.FootCJoint.zDrive;
            _2233.mode = _2232;
            this.FootCJoint.zDrive = _2233;
        }

        {
            int _2234 = 1000;
            JointDrive _2235 = this.FootCJoint.xDrive;
            _2235.positionSpring = _2234;
            this.FootCJoint.xDrive = _2235;
        }

        {
            int _2236 = 1000;
            JointDrive _2237 = this.FootCJoint.yDrive;
            _2237.positionSpring = _2236;
            this.FootCJoint.yDrive = _2237;
        }

        {
            int _2238 = 1000;
            JointDrive _2239 = this.FootCJoint.zDrive;
            _2239.positionSpring = _2238;
            this.FootCJoint.zDrive = _2239;
        }

        {
            int _2240 = 100;
            JointDrive _2241 = this.FootCJoint.xDrive;
            _2241.positionDamper = _2240;
            this.FootCJoint.xDrive = _2241;
        }

        {
            int _2242 = 100;
            JointDrive _2243 = this.FootCJoint.yDrive;
            _2243.positionDamper = _2242;
            this.FootCJoint.yDrive = _2243;
        }

        {
            int _2244 = 100;
            JointDrive _2245 = this.FootCJoint.zDrive;
            _2245.positionDamper = _2244;
            this.FootCJoint.zDrive = _2245;
        }

        {
            JointDriveMode _2246 = JointDriveMode.Position;
            JointDrive _2247 = this.FootCJoint.angularXDrive;
            _2247.mode = _2246;
            this.FootCJoint.angularXDrive = _2247;
        }

        {
            JointDriveMode _2248 = JointDriveMode.Position;
            JointDrive _2249 = this.FootCJoint.angularYZDrive;
            _2249.mode = _2248;
            this.FootCJoint.angularYZDrive = _2249;
        }

        {
            float _2250 = 0.1f;
            JointDrive _2251 = this.FootCJoint.angularXDrive;
            _2251.positionSpring = _2250;
            this.FootCJoint.angularXDrive = _2251;
        }

        {
            float _2252 = 0.1f;
            JointDrive _2253 = this.FootCJoint.angularYZDrive;
            _2253.positionSpring = _2252;
            this.FootCJoint.angularYZDrive = _2253;
        }

        {
            float _2254 = 0.05f;
            JointDrive _2255 = this.FootCJoint.angularXDrive;
            _2255.positionDamper = _2254;
            this.FootCJoint.angularXDrive = _2255;
        }

        {
            float _2256 = 0.05f;
            JointDrive _2257 = this.FootCJoint.angularYZDrive;
            _2257.positionDamper = _2256;
            this.FootCJoint.angularYZDrive = _2257;
        }
        this.Stepped = true;
        this.PGroundClearance = this.GroundClearance;
        this.GroundPoint.parent = null;
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        this.transform.LookAt(this.FootTF);
        Vector3 relativePoint = this.BodyTF.InverseTransformPoint(this.FootTF.position);
        float GCD = Mathf.Clamp(relativePoint.y, 0.01f, this.GroundClearance);
        float FootVelC = Mathf.Clamp(this.FootRB.velocity.magnitude * 0.3f, 1, 8);
        float VelMod = this.GyroPointRB.velocity.magnitude * this.LiftSpeedMod;
        float VelClamp = this.VelCurve.Evaluate(VelMod);
        float VelClamp2 = this.VelCurve2.Evaluate(VelMod);
        float VelClamp3 = this.VelCurve3.Evaluate(VelMod);
        float VelClamp4 = this.VelCurve4.Evaluate(VelMod);
        float Straighten = this.StraightenCurve.Evaluate(VelMod);
        this.AngMod = this.VesselRB.angularVelocity.magnitude * 2;
        float AngClamp = Mathf.Clamp(this.AngMod, 1, 8);
        if (this.GyroPointRB.velocity != Vector3.zero)
        {
            this.GroundPoint.rotation = Quaternion.LookRotation(this.GyroPointRB.velocity);
        }
        Debug.DrawRay(this.PivotTF.position + (this.PivotTF.right * this.GroundPointOffset), this.transform.forward * 32f, Color.green);
        if (Physics.Raycast(this.PivotTF.position + (this.PivotTF.right * this.GroundPointOffset), this.transform.forward, out hit, 32, (int) this.targetLayers))
        {
            if (!this.Nullstacle)
            {
                if (this.Ascend)
                {
                    if (!this.Obstacle)
                    {
                        float v2FootForce = 50 * VelClamp2;
                        this.FootForce = Mathf.Clamp(v2FootForce, this.FootDistForceCurve.Evaluate(relativePoint.y), 8000);
                    }
                    else
                    {
                        this.FootForce = this.FootMaxForceCurve.Evaluate(this.StepNum) * VelClamp2;
                    }
                }
                else
                {
                    if (!this.FootPlaced)
                    {
                        if (!this.Obstacle)
                        {
                            float v4FootForce = 50 * VelClamp2;
                            this.FootForce = Mathf.Clamp(v4FootForce, this.FootDistForceCurve.Evaluate(relativePoint.y), 8000);
                        }
                        else
                        {
                            this.FootForce = this.FootMaxForceCurve.Evaluate(this.StepNum) * VelClamp2;
                        }
                    }
                    else
                    {
                        this.GroundDistForce = this.GroundDistForceCurve.Evaluate(hit.distance);
                        this.FootForce = VelClamp4 * this.GroundDistForce;
                    }
                }
            }
            else
            {
                this.FootForce = this.FootMaxForceCurve.Evaluate(this.StepNum) * VelClamp4;
            }
        }
        Debug.DrawRay(this.PivotTF.position + (this.PivotTF.right * this.GroundPointOffset), Vector3.down * 32f, Color.green);
        if (Physics.Raycast(this.PivotTF.position + (this.PivotTF.right * this.GroundPointOffset), Vector3.down, out hit, 32, (int) this.targetLayers))
        {
            this.GroundPoint.position = hit.point;
        }
        this.StepAimForce = this.StepAimForceCurve.Evaluate(this.GyroPointRB.velocity.magnitude);
        float Y = this.GroundPoint.eulerAngles.y;
        float Z = this.GroundPoint.eulerAngles.z;
        if (this.Ascend)
        {
            //(Ascend)=====================================================================================================================
            if (this.UseCounterForce)
            {
                if (!this.RightSideLeg)
                {
                    this.Vessel2RB.GetComponent<Rigidbody>().AddTorque((this.Vessel2RB.transform.forward * -this.CounterForceCurve.Evaluate(this.StepNum)) * VelClamp3);
                }
                else
                {
                    this.Vessel2RB.GetComponent<Rigidbody>().AddTorque((this.Vessel2RB.transform.forward * this.CounterForceCurve.Evaluate(this.StepNum)) * VelClamp3);
                }
            }
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
                JointDriveMode _2258 = JointDriveMode.Position;
                JointDrive _2259 = this.FootCJoint.angularXDrive;
                _2259.mode = _2258;
                this.FootCJoint.angularXDrive = _2259;
            }

            {
                JointDriveMode _2260 = JointDriveMode.Position;
                JointDrive _2261 = this.FootCJoint.angularYZDrive;
                _2261.mode = _2260;
                this.FootCJoint.angularYZDrive = _2261;
            }
            this.GroundPoint.rotation = Quaternion.Euler(0, Y, Z);
            this.GroundPoint.position = this.GroundPoint.position + ((this.GroundPoint.forward * this.GyroPointRB.velocity.magnitude) * this.StrideDistMod.Evaluate(this.StepNum));
            if (this.UseFootAim)
            {
                this.FootRB.GetComponent<Rigidbody>().AddTorque((this.FootRB.transform.right * this.FootTorqueCurve.Evaluate(this.StepNum)) * VelClamp3);
            }

            {
                float _2262 = this.KneeDampCurve.Evaluate(this.StepNum);
                JointSpring _2263 = this.KneeJoint.spring;
                _2263.damper = _2262;
                this.KneeJoint.spring = _2263;
            }
            if (!this.Nullstacle)
            {
                if (this.Num > this.FullStride)
                {
                    Debug.DrawRay(((this.FootTF.position + (-this.FootTF.up * this.FootSensorZ)) + (-this.FootTF.forward * this.FootSensorY)) + (-this.FootTF.right * 0.5f), Vector3.down * GCD, Color.green);
                    Debug.DrawRay(((this.FootTF.position + (-this.FootTF.up * this.FootSensorZ)) + (-this.FootTF.forward * this.FootSensorY)) + (this.FootTF.right * 0.5f), Vector3.down * GCD, Color.green);
                    if (Physics.Raycast(((this.FootTF.position + (-this.FootTF.up * this.FootSensorZ)) + (-this.FootTF.forward * this.FootSensorY)) + (-this.FootTF.right * 0.5f), Vector3.down, out hit, GCD, (int) this.targetLayers) || Physics.Raycast(((this.FootTF.position + (-this.FootTF.up * this.FootSensorZ)) + (-this.FootTF.forward * this.FootSensorY)) + (this.FootTF.right * 0.5f), Vector3.down, out hit, GCD, (int) this.targetLayers))
                    {
                        float NumAmount1 = this.LegLiftCurve.Evaluate(this.StepNum) * VelClamp;
                        //if(Vector3.Distance(FootTF.position, OtherFootTF.position) < 2)
                        //NumAmount1 = LegLiftCurve.Evaluate(StepNum) * VelClamp;
                        this.Num = this.Num - Mathf.Clamp(NumAmount1, this.FootDistForceCurve.Evaluate(relativePoint.y), 800);
                        this.Obstacle = true;
                    }
                    else
                    {
                        this.Obstacle = false;
                    }
                    Debug.DrawRay((this.FootTF.position + (-this.FootTF.up * this.FootSensorZ)) + (-this.FootTF.forward * 1), this.VesselTF.forward * FootVelC, Color.green);
                    if (Physics.Raycast((this.FootTF.position + (-this.FootTF.up * this.FootSensorZ)) + (-this.FootTF.forward * 1), this.VesselTF.forward, out hit, FootVelC, (int) this.targetLayers))
                    {
                        float NumAmount2 = this.LegLiftCurve.Evaluate(this.StepNum) * VelClamp;
                        this.Num = this.Num - Mathf.Clamp(NumAmount2, this.FootDistForceCurve.Evaluate(relativePoint.y), 800);
                        if (!this.FootPlaced)
                        {
                            this.FootForce = this.FootMaxForceCurve.Evaluate(this.StepNum) * VelClamp2;
                        }
                        this.Obstacle = true;
                    }
                }
                else
                {
                    this.Obstacle = false;
                }
            }
            else
            {
                if (this.Num < 0)
                {
                    this.Num = this.Num + VelClamp;
                }
            }
        }
        else
        {
            //(Descend)=====================================================================================================================
            if (this.UseCounterForce)
            {
                if (!this.RightSideLeg)
                {
                    this.Vessel2RB.GetComponent<Rigidbody>().AddTorque((this.Vessel2RB.transform.forward * this.CounterForceCurve2.Evaluate(this.StepNum)) * VelClamp3);
                }
                else
                {
                    this.Vessel2RB.GetComponent<Rigidbody>().AddTorque((this.Vessel2RB.transform.forward * -this.CounterForceCurve2.Evaluate(this.StepNum)) * VelClamp3);
                }
            }
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
                JointDriveMode _2264 = JointDriveMode.Position;
                JointDrive _2265 = this.FootCJoint.angularXDrive;
                _2265.mode = _2264;
                this.FootCJoint.angularXDrive = _2265;
            }

            {
                JointDriveMode _2266 = JointDriveMode.Position;
                JointDrive _2267 = this.FootCJoint.angularYZDrive;
                _2267.mode = _2266;
                this.FootCJoint.angularYZDrive = _2267;
            }
            this.GroundPoint.rotation = Quaternion.Euler(0, Y, Z);
            this.GroundPoint.position = this.GroundPoint.position + ((this.GroundPoint.forward * this.GyroPointRB.velocity.magnitude) * this.StrideDistMod.Evaluate(this.StepNum));
            if (this.Num < 0)
            {
                this.Num = this.Num + (this.LegDownCurve.Evaluate(this.StepNum) * VelClamp);
            }
        }
        Debug.DrawRay((this.FootTF.position + (-this.FootTF.up * 1.1f)) + (-this.FootTF.forward * 1), Vector3.down * 2, Color.red);
        if (!Physics.Raycast((this.FootTF.position + (-this.FootTF.up * 1.1f)) + (-this.FootTF.forward * 1), Vector3.down, out hit, 2, (int) this.targetLayers))
        {
            this.Nullstacle = true;
        }
        else
        {
            this.Nullstacle = false;
        }
        Debug.DrawRay(this.FootTF.position + (-this.FootTF.up * 0.7f), Vector3.down * this.GroundFeelDist, Color.blue);
        if (Physics.Raycast(this.FootTF.position + (-this.FootTF.up * 0.7f), Vector3.down, out hit, this.GroundFeelDist, (int) this.targetLayers))
        {
            this.FootPlaced = true;
        }
        else
        {
            this.FootPlaced = false;
        }
        if (this.PivotRB.angularVelocity.magnitude < this.LegPivotSpeed)
        {
            this.PivotRB.AddForceAtPosition(((this.GroundPoint.position - this.PivotTF.position).normalized * this.StepAimForce) * AngClamp, -this.PivotTF.forward * 2);
            this.PivotRB.AddForceAtPosition(((this.GroundPoint.position - this.PivotTF.position).normalized * -this.StepAimForce) * AngClamp, this.PivotTF.forward * 2);
        }
        if (this.Num < 0)
        {
            this.Num = this.Num + Straighten;
        }
        if (this.UseFootAim)
        {
            this.FootRB.GetComponent<Rigidbody>().AddTorque((this.FootRB.transform.right * this.FootTorqueCurve2.Evaluate(this.StepNum)) * VelClamp3);
            Debug.DrawRay(this.FootTF.position, Vector3.down * this.GroundClearance, Color.green);
            if (Physics.Raycast(this.FootTF.position, Vector3.down, out hit, this.GroundClearance, (int) this.targetLayers))
            {
                this.FootAngler.rotation = Quaternion.LookRotation(hit.normal);
            }
        }
        float GCClamp = Mathf.Clamp(Vector3.Distance(this.FootTF.position, this.GroundPoint.position), 1, this.PGroundClearance);
        this.GroundClearance = GCClamp;

        {
            float _2268 = this.FootForce;
            JointDrive _2269 = this.FootCJoint.xDrive;
            _2269.maximumForce = _2268;
            this.FootCJoint.xDrive = _2269;
        }

        {
            float _2270 = this.FootForce;
            JointDrive _2271 = this.FootCJoint.yDrive;
            _2271.maximumForce = _2270;
            this.FootCJoint.yDrive = _2271;
        }

        {
            float _2272 = this.FootForce;
            JointDrive _2273 = this.FootCJoint.zDrive;
            _2273.maximumForce = _2272;
            this.FootCJoint.zDrive = _2273;
        }
        this.CJoint.targetPosition = new Vector3(0, 0, this.Num);
    }

    public LegScript2()
    {
        this.FootSensorY = 1;
        this.FootSensorZ = 1.5f;
        this.FootForce = 0.5f;
        this.FootMaxForceCurve = new AnimationCurve();
        this.FootMaxDist = 5;
        this.GroundDistForceCurve = new AnimationCurve();
        this.CounterForceCurve = new AnimationCurve();
        this.CounterForceCurve2 = new AnimationCurve();
        this.GroundFeelDist = 1;
        this.FootTorqueCurve = new AnimationCurve();
        this.FootTorqueCurve2 = new AnimationCurve();
        this.GroundClearanceCurve = new AnimationCurve();
        this.FullStride = -2.5f;
        this.GroundClearance = 1;
        this.LiftSpeedMod = 0.1f;
        this.LegLiftCurve = new AnimationCurve();
        this.LegDownCurve = new AnimationCurve();
        this.LegPivotSpeed = 0.2f;
        this.KneeDampCurve = new AnimationCurve();
        this.StrideDistMod = new AnimationCurve();
        this.VelCurve = new AnimationCurve();
        this.VelCurve2 = new AnimationCurve();
        this.VelCurve3 = new AnimationCurve();
        this.VelCurve4 = new AnimationCurve();
        this.StraightenCurve = new AnimationCurve();
        this.FootDistForceCurve = new AnimationCurve();
        this.StepAimForce = 1;
        this.StepAimForceCurve = new AnimationCurve();
    }

}