using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class LevNavWarship : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform TargetTrace;
    public Transform TargetLead;
    public Transform TargetLead2;
    public SphereCollider TLCol;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public Transform ResetAimpoint;
    public Transform AIAnchor;
    public bool useOrbitStrategy;
    public int orbitDist;
    public bool HasRequested;
    public int SMCooldown;
    public int CMCooldown;
    public GameObject MissileAmmo;
    public GameObject Missile2Ammo;
    public GameObject Missile3Ammo;
    public Transform Missile1;
    public Transform Missile2;
    public Transform Missile3;
    public Transform Missile4;
    public Transform Missile5;
    public Transform Missile6;
    public Transform Missile7;
    public Transform Missile8;
    public GameObject Missile5GO;
    public GameObject Missile6GO;
    public Transform topPoint;
    public Transform frontPoint;
    public GameObject Turret1;
    public GameObject Turret2;
    public NPCGun Gun1;
    public NPCGun Gun2;
    public SphereCollider Trig;
    public GameObject Presence;
    public GameObject SpotSound;
    public GameObject AttackSound;
    public GameObject RejectSound;
    public float Dist;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public bool SkipTiny;
    public bool FoundSmall;
    public bool FoundMedium;
    public bool FoundBig;
    public bool isInFront;
    public bool Attacking;
    public bool Obstacle;
    public bool Stuck;
    public bool Emergency;
    public float DirStrength;
    public float TAimStrength;
    public float TurnStrength;
    public int TurnForce;
    public bool TurnRight;
    public bool TurnLeft;
    public float RightDist;
    public float LeftDist;
    public float AngleTH;
    public int forwardPoint;
    public float sidePoint;
    public float sidePointStat;
    public int RPAbs;
    public int RPClamp;
    public int RPMod;
    public float RUP;
    public float RRUP;
    public float LRUP;
    public bool Wall;
    public bool RWall;
    public bool LWall;
    public Vector3 Point1u;
    public Vector3 Point1d;
    public Vector3 RPoint1u;
    public Vector3 RPoint1d;
    public Vector3 LPoint1u;
    public Vector3 LPoint1d;
    public Vector3 localV;
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    public int DangerSense;
    public bool DangerTick;
    public int StoredMissileBatches;
    public int StoredMissile2Batches;
    public int StoredMissile3Batches;
    public int Dist3;
    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 1, 1);
        this.InvokeRepeating("LeaveMarker", 1, 10);
        this.InvokeRepeating("Targety", 15, 15);
        this.InvokeRepeating("Shooty", Random.Range(2, 3), 0.3f);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
        this.sidePointStat = this.sidePoint;
    }

    public virtual void FixedUpdate()
    {
        Vector3 newRot2 = default(Vector3);
        RaycastHit hit = default(RaycastHit);
        RaycastHit hit1 = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        if (!this.DangerTick)
        {
            this.thisTransform.rotation = this.AIAnchor.transform.rotation;
        }
        this.thisTransform.position = this.AIAnchor.transform.position;
        if (this.target)
        {
            Vector3 RelativeTarget = this.thisTransform.InverseTransformPoint(this.target.position);
            float RPModX = RelativeTarget.x * 10;
            this.RPAbs = (int) Mathf.Abs(RPModX);
            this.Dist = Vector3.Distance(this.thisTransform.position, this.target.position);

            if (this.Attacking)
            {
                if (this.target == this.ResetAimpoint)
                {
                    this.target = this.ResetAimpoint;
                    this.Attacking = false;
                    this.FoundSmall = false;
                }
                if (this.target == null)
                {
                    this.target = this.ResetAimpoint;
                    this.Attacking = false;
                    this.FoundSmall = false;
                }
                else
                {
                    if (this.target.name.Contains("broken"))
                    {
                        this.target = this.ResetAimpoint;
                        this.Attacking = false;
                    }
                }
            }
            if (this.TurnLeft)
            {
                this.TurnForce = -500;
            }
            if (this.TurnRight)
            {
                this.TurnForce = 500;
            }
            if ((this.TurnRight && this.TurnLeft) && this.Obstacle)
            {
                this.TurnForce = -500;
            }
            if (this.target)
            {
                if (!this.TurnRight && !this.TurnLeft)
                {
                    if (this.Dist < this.orbitDist)
                    {
                        if (!this.isInFront)
                        {
                            this.RPMod = (int) (RelativeTarget.z * 5);
                        }
                        else
                        {
                            this.RPMod = (int) (RelativeTarget.x * 5);
                        }
                        this.RPClamp = Mathf.Clamp(this.RPMod, -400, 400);
                        this.TurnForce = this.RPClamp;
                    }
                    else
                    {
                        if (this.useOrbitStrategy)
                        {
                            this.RPMod = (int) (RelativeTarget.x * 0.5f);
                            this.RPClamp = Mathf.Clamp(this.RPMod, -400, 400);
                            this.TurnForce = this.RPClamp;
                        }
                        else
                        {
                            this.RPMod = (int) (RelativeTarget.x * 5);
                            this.RPClamp = Mathf.Clamp(this.RPMod, -400, 400);
                            this.TurnForce = this.RPClamp;
                        }
                    }
                }
            }
        }
        this.localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        if (-this.localV.y > 10)
        {
            newRot2 = this.vRigidbody.velocity;
        }
        else
        {
            newRot2 = this.thisTransform.forward;
        }
        float VelClamp = Mathf.Clamp(this.vRigidbody.velocity.magnitude * 2, 40, 200);
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.RUP), newRot2 * VelClamp, Color.white);
        if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.RUP), newRot2, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.Point1u = hit1.point;
        }
        else
        {
            this.Point1u = new Vector3(2, 2, 2);
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.RUP), newRot2 * VelClamp, Color.white);
        if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.RUP), newRot2, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.Point1d = hit2.point;
        }
        else
        {
            this.Point1d = new Vector3(8, 8, 8);
        }
        if (Vector3.Distance(this.Point1u, this.Point1d) < this.AngleTH)
        {
            this.Wall = true;
        }
        this.Obstacle = false;
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint), newRot2 * VelClamp, Color.green);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint), newRot2, out hit, VelClamp, (int) this.targetLayers))
        {
            if (this.Wall)
            {
                this.Obstacle = true;
            }
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (this.thisTransform.right * 4), newRot2 * VelClamp, Color.green);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (this.thisTransform.right * 4), newRot2, out hit, VelClamp, (int) this.targetLayers))
        {
            if (this.Wall)
            {
                this.Obstacle = true;
            }
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.right * 4), newRot2 * VelClamp, Color.green);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.right * 4), newRot2, out hit, VelClamp, (int) this.targetLayers))
        {
            if (this.Wall)
            {
                this.Obstacle = true;
            }
        }
        Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (this.thisTransform.right * this.sidePoint)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.RRUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (this.thisTransform.right * this.sidePoint)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.RRUP), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.RPoint1u = hit1.point;
        }
        else
        {
            this.RPoint1u = new Vector3(2, 2, 2);
        }
        Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (this.thisTransform.right * this.sidePoint)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.RRUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (this.thisTransform.right * this.sidePoint)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.RRUP), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.RPoint1d = hit2.point;
            this.RightDist = hit2.distance;
        }
        else
        {
            this.RPoint1d = new Vector3(8, 8, 8);
            this.RightDist = 512;
        }
        if (Vector3.Distance(this.RPoint1u, this.RPoint1d) < this.AngleTH)
        {
            this.RWall = true;
        }
        Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.right * this.sidePoint)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.LRUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.right * this.sidePoint)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.LRUP), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.LPoint1u = hit1.point;
        }
        else
        {
            this.LPoint1u = new Vector3(2, 2, 2);
        }
        Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.right * this.sidePoint)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.LRUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.right * this.sidePoint)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.LRUP), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.LPoint1d = hit2.point;
            this.LeftDist = hit2.distance;
        }
        else
        {
            this.LPoint1d = new Vector3(8, 8, 8);
            this.LeftDist = 512;
        }
        if (Vector3.Distance(this.LPoint1u, this.LPoint1d) < this.AngleTH)
        {
            this.LWall = true;
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (this.thisTransform.up * 10)) + (this.thisTransform.forward * VelClamp), this.thisTransform.up * -30f, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (this.thisTransform.up * 10)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, 30))
        {
            this.Obstacle = true;
        }
        //---------------------------------------------------------------------------------------------
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 10)) + (this.thisTransform.right * 20)) + (this.thisTransform.forward * VelClamp), this.thisTransform.up * -30f, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 10)) + (this.thisTransform.right * 20)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, 30))
        {
            this.TurnLeft = true;
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 10)) + (-this.thisTransform.right * 20)) + (this.thisTransform.forward * VelClamp), this.thisTransform.up * -30f, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 10)) + (-this.thisTransform.right * 20)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, 30))
        {
            this.TurnRight = true;
        }
        //---------------------------------------------------------------------------------------------
        if ((this.RightDist > this.LeftDist) && this.LWall)
        {
            this.TurnRight = true;
        }
        if ((this.LeftDist > this.RightDist) && this.RWall)
        {
            this.TurnLeft = true;
        }
        if ((this.LeftDist < 20) && this.LWall)
        {
            this.Obstacle = true;
        }
        if ((this.RightDist < 20) && this.RWall)
        {
            this.Obstacle = true;
        }
        if (this.Stuck)
        {
            this.TurnRight = true;
            this.TurnLeft = false;
        }
        if (this.isInFront)
        {
            this.TurnRight = false;
            this.TurnLeft = false;
            this.Obstacle = true;
        }
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        if (this.RUP < 8)
        {
            this.RUP = this.RUP + 1;
        }
        else
        {
            this.RUP = 0;
        }
        if (this.RRUP < 4)
        {
            this.RRUP = this.RRUP + 0.5f;
        }
        else
        {
            this.RRUP = 0;
        }
        if (this.LRUP < 4)
        {
            this.LRUP = this.LRUP + 0.5f;
        }
        else
        {
            this.LRUP = 0;
        }
        if (this.sidePoint < this.sidePointStat)
        {
            this.sidePoint = this.sidePoint + 0.5f;
        }
        else
        {
            this.sidePoint = 2;
        }
        if (this.Obstacle)
        {
            if (-localV.y > 0)
            {
                this.vRigidbody.AddForce((-this.thisVTransform.up * -50) * this.DirStrength);
            }
        }
        if (this.Stuck)
        {
            if (-localV.y < 4)
            {
                this.vRigidbody.AddForce((this.thisVTransform.up * 17) * this.DirStrength);
            }
        }
        if ((this.Attacking && !this.Obstacle) && !this.Stuck)
        {
            if (-localV.y < 70)
            {
                this.vRigidbody.AddForce((-this.thisVTransform.up * 50) * this.DirStrength);
            }
        }
        if ((((!this.Attacking && !this.Obstacle) && !this.Stuck) && !this.TurnLeft) && !this.TurnRight)
        {
            if (-localV.y < 70)
            {
                this.vRigidbody.AddForce((-this.thisVTransform.up * 25) * this.DirStrength);
            }
        }
        this.vRigidbody.AddTorque((this.thisVTransform.forward * this.TurnForce) * this.TurnStrength);
        if (this.target)
        {
            if (this.Turret1)
            {
                this.Turret1.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.transform.position - this.Turret1.transform.position).normalized * 10, -this.Turret1.transform.up * this.TAimStrength);
                this.Turret1.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.transform.position - this.Turret1.transform.position).normalized * -10, this.Turret1.transform.up * this.TAimStrength);
            }
            if (this.Turret2)
            {
                this.Turret2.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.transform.position - this.Turret2.transform.position).normalized * 10, -this.Turret2.transform.up * this.TAimStrength);
                this.Turret2.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.transform.position - this.Turret2.transform.position).normalized * -10, this.Turret2.transform.up * this.TAimStrength);
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (ON.Contains("TFC"))
        {
            if (!ON.Contains("TFC3"))
            {
                if (TerrahyptianNetwork.instance.EnemyTarget1)
                {
                    if (ON.Contains("TFC0a"))
                    {
                        if (TerrahyptianNetwork.instance.EnemyTarget1.name.Contains("TFC0"))
                        {
                            this.PissedAtTC0a = 2;
                        }
                    }
                    if (ON.Contains("TFC1"))
                    {
                        if (TerrahyptianNetwork.instance.EnemyTarget1.name.Contains("TFC1"))
                        {
                            this.PissedAtTC1 = 2;
                        }
                    }
                    if (ON.Contains("TFC4"))
                    {
                        if (TerrahyptianNetwork.instance.EnemyTarget1.name.Contains("TFC4"))
                        {
                            this.PissedAtTC4 = 2;
                        }
                    }
                    if (ON.Contains("TFC5"))
                    {
                        if (TerrahyptianNetwork.instance.EnemyTarget1.name.Contains("TFC5"))
                        {
                            this.PissedAtTC5 = 2;
                        }
                    }
                    if (ON.Contains("TFC6"))
                    {
                        if (TerrahyptianNetwork.instance.EnemyTarget1.name.Contains("TFC6"))
                        {
                            this.PissedAtTC6 = 2;
                        }
                    }
                    if (ON.Contains("TFC7"))
                    {
                        if (TerrahyptianNetwork.instance.EnemyTarget1.name.Contains("TFC7"))
                        {
                            this.PissedAtTC7 = 2;
                        }
                    }
                    if (ON.Contains("TFC8"))
                    {
                        if (TerrahyptianNetwork.instance.EnemyTarget1.name.Contains("TFC8"))
                        {
                            this.PissedAtTC8 = 2;
                        }
                    }
                    if (ON.Contains("TFC9"))
                    {
                        if (TerrahyptianNetwork.instance.EnemyTarget1.name.Contains("TFC9"))
                        {
                            this.PissedAtTC9 = 2;
                        }
                    }
                }
                else
                {
                    if (ON.Contains("TFC0a"))
                    {
                        this.PissedAtTC0a = 2;
                    }
                    if (ON.Contains("TFC1"))
                    {
                        this.PissedAtTC1 = 2;
                    }
                    if (ON.Contains("TFC4"))
                    {
                        this.PissedAtTC4 = 2;
                    }
                    if (ON.Contains("TFC5"))
                    {
                        this.PissedAtTC5 = 2;
                    }
                    if (ON.Contains("TFC6"))
                    {
                        this.PissedAtTC6 = 2;
                    }
                    if (ON.Contains("TFC7"))
                    {
                        this.PissedAtTC7 = 2;
                    }
                    if (ON.Contains("TFC8"))
                    {
                        this.PissedAtTC8 = 2;
                    }
                    if (ON.Contains("TFC9"))
                    {
                        this.PissedAtTC9 = 2;
                    }
                }
                if (!this.Attacking)
                {
                    this.DangerSense = 10;
                    this.target = this.Waypoint;
                    if (other.GetComponent<Rigidbody>())
                    {
                        this.Waypoint.position = OT.position;
                    }
                }
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (ON.Contains("TC"))
        {
            if (!ON.Contains("TC3"))
            {
                if (this.SkipTiny)
                {
                    if (ON.Contains("tT"))
                    {
                        return;
                    }
                }
                if (ON.Contains("xb"))
                {
                    if (ON.Contains("C1"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC1 = OT;
                    }
                    if (ON.Contains("C4"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC4 = OT;
                    }
                    if (ON.Contains("C5"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC5 = OT;
                    }
                    if (ON.Contains("C6"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC6 = OT;
                    }
                    if (ON.Contains("C7"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC7 = OT;
                    }
                    if (ON.Contains("C8"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC8 = OT;
                    }
                    if (ON.Contains("C9"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC9 = OT;
                    }
                }
                if (this.FoundBig)
                {
                    return;
                }
                if (this.PissedAtTC0a > 1)
                {
                    if (ON.Contains("TC0a"))
                    {
                        if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                        {
                            this.target = OT;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            this.PissedAtTC0a = this.PissedAtTC0a - 1;
                        }
                    }
                }
                if (this.PissedAtTC1 > 1)
                {
                    if (ON.Contains("TC1"))
                    {
                        if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                        {
                            this.target = OT;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            this.PissedAtTC1 = this.PissedAtTC1 - 1;
                        }
                    }
                }
                if (this.PissedAtTC4 > 1)
                {
                    if (ON.Contains("TC4"))
                    {
                        if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                        {
                            this.target = OT;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            this.PissedAtTC4 = this.PissedAtTC4 - 1;
                        }
                    }
                }
                if (this.PissedAtTC5 > 1)
                {
                    if (ON.Contains("TC5"))
                    {
                        if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                        {
                            this.target = OT;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            this.PissedAtTC5 = this.PissedAtTC5 - 1;
                        }
                    }
                }
                if (this.PissedAtTC6 > 1)
                {
                    if (ON.Contains("TC6"))
                    {
                        if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                        {
                            this.target = OT;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            this.PissedAtTC6 = this.PissedAtTC6 - 1;
                        }
                    }
                }
                if (this.PissedAtTC7 > 1)
                {
                    if (ON.Contains("TC7"))
                    {
                        if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                        {
                            this.target = OT;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            this.PissedAtTC7 = this.PissedAtTC7 - 1;
                        }
                    }
                }
                if (this.PissedAtTC8 > 1)
                {
                    if (ON.Contains("TC8"))
                    {
                        if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                        {
                            this.target = OT;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            this.PissedAtTC8 = this.PissedAtTC8 - 1;
                        }
                    }
                }
                if (this.PissedAtTC9 > 1)
                {
                    if (ON.Contains("TC9"))
                    {
                        if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                        {
                            this.target = OT;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            this.PissedAtTC9 = this.PissedAtTC9 - 1;
                        }
                    }
                }
                if (ON.Contains("sT"))
                {
                    this.FoundSmall = true;
                }
                if (ON.Contains("mT"))
                {
                    this.FoundMedium = true;
                }
                if (ON.Contains("bT"))
                {
                    this.FoundBig = true;
                }
            }
        }
    }

    public virtual void AttackNoise()
    {
        GameObject TheThing = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
        TheThing.transform.parent = this.thisTransform;
    }

    public virtual void Shooty()
    {
        this.isInFront = false;
        if (this.Attacking)
        {
            this.StartCoroutine(this.Shoot());
            if (this.SMCooldown < 1)
            {
                this.StartCoroutine(this.LaunchSM());
            }
            if (this.FoundBig)
            {
                if (this.target)
                {
                    if (this.frontPoint)
                    {
                        if ((this.StoredMissile3Batches > 0) && (this.Dist < 1000))
                        {
                            if (!Physics.Linecast(this.frontPoint.position, this.target.position, (int) this.MtargetLayers))
                            {
                                this.isInFront = true;
                            }
                        }
                    }
                }
                if (this.CMCooldown < 1)
                {
                    this.StartCoroutine(this.LaunchCM());
                }
            }
        }
    }

    public virtual IEnumerator Shoot()
    {
        if (this.Attacking)
        {
            if (this.Turret1)
            {
                this.Gun1.Fire();
            }
            yield return new WaitForSeconds(0.4f);
            if (this.Turret2)
            {
                this.Gun2.Fire();
            }
        }
    }

    public virtual IEnumerator LaunchSM()
    {
        if (!this.MissileAmmo)
        {
            yield break;
        }
        if (this.target)
        {
            if (Physics.Linecast(this.topPoint.position, this.target.position, (int) this.MtargetLayers))
            {
                yield break;
            }
        }
        if (this.target)
        {
            if ((this.Attacking && (this.StoredMissileBatches > 0)) && (this.Dist < 1000))
            {
                this.SMCooldown = 3;
                if (this.Missile5GO)
                {
                    if (!this.Missile5GO.name.Contains("rok"))
                    {
                        yield break;
                    }
                }
                if (this.Missile6GO)
                {
                    if (!this.Missile6GO.name.Contains("rok"))
                    {
                        yield break;
                    }
                }
                this.Dist3 = 3;
                this.StoredMissileBatches = this.StoredMissileBatches - 1;
                GameObject _SpawnedObject1 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile1.position, this.Missile1.rotation);
                _SpawnedObject1.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) _SpawnedObject1.transform.GetComponent(typeof(MissileScript))).target = this.target;
                yield return new WaitForSeconds(0.3f);
                GameObject _SpawnedObject2 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile2.position, this.Missile2.rotation);
                _SpawnedObject2.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) _SpawnedObject2.transform.GetComponent(typeof(MissileScript))).target = this.target;
                yield return new WaitForSeconds(0.3f);
                GameObject _SpawnedObject3 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile3.position, this.Missile3.rotation);
                _SpawnedObject3.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) _SpawnedObject3.transform.GetComponent(typeof(MissileScript))).target = this.target;
                yield return new WaitForSeconds(0.3f);
                GameObject _SpawnedObject4 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile4.position, this.Missile4.rotation);
                _SpawnedObject4.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) _SpawnedObject4.transform.GetComponent(typeof(MissileScript))).target = this.target;
                if (this.FoundBig)
                {
                    yield return new WaitForSeconds(0.3f);
                    GameObject _SpawnedObject10 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile1.position, this.Missile1.rotation);
                    _SpawnedObject10.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject10.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    yield return new WaitForSeconds(0.3f);
                    GameObject _SpawnedObject20 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile2.position, this.Missile2.rotation);
                    _SpawnedObject20.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject20.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    yield return new WaitForSeconds(0.3f);
                    GameObject _SpawnedObject30 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile3.position, this.Missile3.rotation);
                    _SpawnedObject30.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject30.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    yield return new WaitForSeconds(0.3f);
                    GameObject _SpawnedObject40 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile4.position, this.Missile4.rotation);
                    _SpawnedObject40.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject40.transform.GetComponent(typeof(MissileScript))).target = this.target;
                }
            }
        }
        if (!this.Missile2Ammo)
        {
            yield break;
        }
        if (this.target)
        {
            if ((this.Attacking && (this.StoredMissile2Batches > 0)) && (this.Dist < 512))
            {
                this.SMCooldown = 3;
                if (this.Missile5GO)
                {
                    if (!this.Missile5GO.name.Contains("rok"))
                    {
                        yield break;
                    }
                }
                if (this.Missile6GO)
                {
                    if (!this.Missile6GO.name.Contains("rok"))
                    {
                        yield break;
                    }
                }
                this.Dist3 = 3;
                this.StoredMissile2Batches = this.StoredMissile2Batches - 1;
                this.Missile5GO = UnityEngine.Object.Instantiate(this.Missile2Ammo, this.Missile5.position, this.Missile5.rotation);
                this.Missile5GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) this.Missile5GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                yield return new WaitForSeconds(0.3f);
                this.Missile6GO = UnityEngine.Object.Instantiate(this.Missile2Ammo, this.Missile6.position, this.Missile6.rotation);
                this.Missile6GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) this.Missile6GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
            }
        }
    }

    public virtual IEnumerator LaunchCM()
    {
        if (!this.Missile3Ammo)
        {
            yield break;
        }
        if ((!this.isInFront || (this.RPAbs > 64)) || (this.RPClamp < 0))
        {
            yield break;
        }
        if (this.target != null)
        {
            if (((this.Attacking && (this.StoredMissile3Batches > 0)) && (this.Dist > 128)) && (this.Dist < 2000))
            {
                this.CMCooldown = 4;
                this.StoredMissile3Batches = this.StoredMissile3Batches - 1;
                GameObject _SpawnedObject7 = UnityEngine.Object.Instantiate(this.Missile3Ammo, this.Missile7.position, this.Missile7.rotation);
                _SpawnedObject7.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) _SpawnedObject7.transform.GetComponent(typeof(MissileScript))).target = this.target;
                yield return new WaitForSeconds(0.3f);
                GameObject _SpawnedObject8 = UnityEngine.Object.Instantiate(this.Missile3Ammo, this.Missile8.position, this.Missile8.rotation);
                _SpawnedObject8.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) _SpawnedObject8.transform.GetComponent(typeof(MissileScript))).target = this.target;
            }
        }
    }

    public virtual void Targety()
    {
        if (!this.Attacking)
        {
            this.StartCoroutine(this.TargetArea());
        }
    }

    public virtual IEnumerator TargetArea()
    {
        if ((TerrahyptianNetwork.AlertTime > 0) && !this.Attacking)
        {
            this.Waypoint.transform.position = TerrahyptianNetwork.instance.PriorityWaypoint.position;
            this.target = this.Waypoint;
        }
        yield return new WaitForSeconds(10);
        if (!this.Attacking)
        {
            this.target = this.ResetAimpoint;
        }
    }

    public virtual void LeaveMarker()
    {
        Vector3 lastPos = this.thisTransform.position;
        this.StartCoroutine(this.IsEscaping(lastPos));
    }

    public virtual IEnumerator IsEscaping(Vector3 lastPos)
    {
        this.Stuck = false;
        yield return new WaitForSeconds(2);
        if ((Vector3.Distance(this.thisTransform.position, lastPos) < 3) && !this.isInFront)
        {
            this.Stuck = true;
            yield return new WaitForSeconds(3);
            this.Stuck = false;
        }
    }

    public virtual void CalcLead()
    {
        this.StartCoroutine(this.Lead());
    }

    public virtual IEnumerator Lead()
    {
        if (this.target)
        {
            this.TargetTrace.position = this.target.position;
        }
        yield return new WaitForSeconds(0.1f);
        if (this.target)
        {
            float Dist1 = Vector3.Distance(this.thisTransform.position, this.target.position);
            float Dist2 = Vector3.Distance(this.TargetTrace.position, this.target.position);
            this.TargetTrace.LookAt(this.target);
            this.TargetLead.position = this.TargetTrace.position;
            this.TargetLead.rotation = this.TargetTrace.rotation;
            this.TargetLead2.position = this.TargetTrace.position;
            this.TargetLead2.rotation = this.TargetTrace.rotation;
            this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * Dist1) * Dist2) * 0.02f);
            this.TargetLead2.position = this.TargetLead2.position + ((this.TargetLead.forward * Dist2) * this.Dist3);
            if (this.Attacking)
            {
                this.TLCol.radius = this.Dist * 0.05f;
            }
            else
            {
                this.TLCol.radius = 0.1f;
            }
        }
    }

    public virtual void Regenerator()
    {
        this.PissedAtTC1 = TerrahyptianNetwork.TC1CriminalLevel;
        this.PissedAtTC4 = TerrahyptianNetwork.TC4CriminalLevel;
        this.PissedAtTC5 = TerrahyptianNetwork.TC5CriminalLevel;
        this.PissedAtTC6 = TerrahyptianNetwork.TC6CriminalLevel;
        this.PissedAtTC7 = TerrahyptianNetwork.TC7CriminalLevel;
        this.PissedAtTC8 = TerrahyptianNetwork.TC8CriminalLevel;
        this.PissedAtTC9 = TerrahyptianNetwork.TC9CriminalLevel;
        if (this.target)
        {
            if (this.target.name.Contains("bT"))
            {
                this.FoundBig = true;
            }
            else
            {
                this.FoundBig = false;
            }
            if (!this.target.name.Contains("mTC"))
            {
                this.FoundMedium = false;
            }
            if (!this.target.name.Contains("sTC"))
            {
                this.FoundSmall = false;
            }
            if (!this.Attacking)
            {
                if (TerrahyptianNetwork.TC1CriminalLevel > 480)
                {
                    if (this.target.name.Contains("C1"))
                    {
                        TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                        TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                    }
                    else
                    {
                        if (TerrahyptianNetwork.instance.EnemyTarget2)
                        {
                            if (Vector3.Distance(this.thisTransform.position, TerrahyptianNetwork.instance.EnemyTarget2.position) < 1500)
                            {
                                this.target = TerrahyptianNetwork.instance.EnemyTarget2;
                                if (!this.Attacking)
                                {
                                    this.AttackNoise();
                                }
                                this.Attacking = true;
                            }
                        }
                    }
                }
                if (TerrahyptianNetwork.TC1CriminalLevel > 480)
                {
                    if (TerrahyptianNetwork.AnExtraBigTC1)
                    {
                        this.target = TerrahyptianNetwork.AnExtraBigTC1;
                        TerrahyptianNetwork.AlertTime = 240;
                        //FoundExtraBig = true;
                        this.Attacking = true;
                    }
                    if (this.target.name.Contains("C1"))
                    {
                        TerrahyptianNetwork.AlertLVL2 = 1;
                    }
                }
                if (TerrahyptianNetwork.TC4CriminalLevel > 480)
                {
                    if (TerrahyptianNetwork.AnExtraBigTC4)
                    {
                        this.target = TerrahyptianNetwork.AnExtraBigTC4;
                        TerrahyptianNetwork.AlertTime = 240;
                        //FoundExtraBig = true;
                        this.Attacking = true;
                    }
                    if (this.target.name.Contains("C4"))
                    {
                        TerrahyptianNetwork.AlertLVL2 = 4;
                    }
                }
                if (TerrahyptianNetwork.TC5CriminalLevel > 480)
                {
                    if (TerrahyptianNetwork.AnExtraBigTC5)
                    {
                        this.target = TerrahyptianNetwork.AnExtraBigTC5;
                        TerrahyptianNetwork.AlertTime = 240;
                        //FoundExtraBig = true;
                        this.Attacking = true;
                    }
                    if (this.target.name.Contains("C5"))
                    {
                        TerrahyptianNetwork.AlertLVL2 = 5;
                    }
                }
                if (TerrahyptianNetwork.TC6CriminalLevel > 480)
                {
                    if (TerrahyptianNetwork.AnExtraBigTC6)
                    {
                        this.target = TerrahyptianNetwork.AnExtraBigTC6;
                        TerrahyptianNetwork.AlertTime = 240;
                        //FoundExtraBig = true;
                        this.Attacking = true;
                    }
                    if (this.target.name.Contains("C6"))
                    {
                        TerrahyptianNetwork.AlertLVL2 = 6;
                    }
                }
                if (TerrahyptianNetwork.TC7CriminalLevel > 480)
                {
                    if (TerrahyptianNetwork.AnExtraBigTC7)
                    {
                        this.target = TerrahyptianNetwork.AnExtraBigTC7;
                        TerrahyptianNetwork.AlertTime = 240;
                        //FoundExtraBig = true;
                        this.Attacking = true;
                    }
                    if (this.target.name.Contains("C7"))
                    {
                        TerrahyptianNetwork.AlertLVL2 = 7;
                    }
                }
                if (TerrahyptianNetwork.TC8CriminalLevel > 480)
                {
                    if (TerrahyptianNetwork.AnExtraBigTC8)
                    {
                        this.target = TerrahyptianNetwork.AnExtraBigTC8;
                        TerrahyptianNetwork.AlertTime = 240;
                        //FoundExtraBig = true;
                        this.Attacking = true;
                    }
                    if (this.target.name.Contains("C8"))
                    {
                        TerrahyptianNetwork.AlertLVL2 = 8;
                    }
                }
                if (TerrahyptianNetwork.TC9CriminalLevel > 480)
                {
                    if (TerrahyptianNetwork.AnExtraBigTC9)
                    {
                        this.target = TerrahyptianNetwork.AnExtraBigTC9;
                        TerrahyptianNetwork.AlertTime = 240;
                        //FoundExtraBig = true;
                        this.Attacking = true;
                    }
                    if (this.target.name.Contains("C9"))
                    {
                        TerrahyptianNetwork.AlertLVL2 = 9;
                    }
                }
            }
        }
        if (this.Attacking)
        {
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.radius = 64;
        }
        else
        {
            this.StartCoroutine(this.TrigSweep());
        }
        if (this.DangerSense > 0)
        {
            if ((this.DangerSense < 2) && !this.Attacking)
            {
                this.target = this.ResetAimpoint;
            }
            this.DangerSense = this.DangerSense - 1;
        }
        if (this.SMCooldown > 0)
        {
            this.SMCooldown = this.SMCooldown - 1;
        }
        if (this.CMCooldown > 0)
        {
            this.CMCooldown = this.CMCooldown - 1;
        }
        this.TurnForce = 0;
        this.Wall = false;
        this.RWall = false;
        this.LWall = false;
        this.TurnRight = false;
        this.TurnLeft = false;
        this.StartCoroutine(this.Notice());
    }

    public virtual IEnumerator TrigSweep()
    {
        this.Trig.center = new Vector3(0, 0, 256);
        this.Trig.radius = 256;
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(185, 0, 185);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(256, 0, 0);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(185, 0, -185);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(0, 0, -256);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(-185, 0, -185);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(-256, 0, 0);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(-185, 0, 185);
    }

    public virtual IEnumerator Notice()
    {
        if (this.Attacking)
        {
            if (this.target)
            {
                if (this.Emergency)
                {
                    TerrahyptianNetwork.instance.EnemyTarget1 = this.target;
                }
            }
        }
        if (this.DangerSense > 0)
        {
            this.DangerTick = true;
            this.thisTransform.LookAt(this.Waypoint);
            yield return new WaitForSeconds(0.1f);
            this.DangerTick = false;
        }
    }

    public LevNavWarship()
    {
        this.orbitDist = 300;
        this.Dist = 1;
        this.DirStrength = 2;
        this.TAimStrength = 2;
        this.TurnStrength = 2;
        this.RightDist = 200;
        this.LeftDist = 200;
        this.AngleTH = 2;
        this.forwardPoint = 2;
        this.sidePoint = 10;
        this.sidePointStat = 10;
        this.RPAbs = 1;
        this.RPClamp = 1;
        this.StoredMissileBatches = 32;
        this.StoredMissile2Batches = 64;
        this.StoredMissile3Batches = 8;
        this.Dist3 = 6;
    }

}