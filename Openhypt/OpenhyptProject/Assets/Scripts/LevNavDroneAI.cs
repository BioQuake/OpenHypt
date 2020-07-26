using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class LevNavDroneAI : MonoBehaviour
{
    public Transform target;
    public Transform ResetView;
    public SphereCollider Trig;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public Transform vPoint;
    public Transform Muzzle;
    public GameObject Shot;
    public NPCGun Gun;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public float ObsStartY;
    public float ObsStartZ;
    public float RightDist;
    public float LeftDist;
    public float UpDist;
    public float DownDist;
    public float Dist;
    public float StabForce;
    public float Diff;
    public float RD;
    public float Vel;
    public bool TurnRight;
    public bool TurnLeft;
    public bool TurnUp;
    public bool TurnDown;
    public bool TurnAway;
    public int Obstacle;
    public bool Hunting;
    public bool Attacking;
    public LayerMask targetLayers;
    public float UniqueShootTime;
    public virtual void Start()
    {
        this.InvokeRepeating("Updater", 1, 1);
        this.InvokeRepeating("Shooty", this.UniqueShootTime, 0.1f);
        this.UniqueShootTime = Random.Range(1, 2);
        this.Vel = 4;
        this.Hunting = true;
    }

    public virtual void Update()
    {
        Vector3 newRot2 = default(Vector3);
        RaycastHit hit0 = default(RaycastHit);
        RaycastHit hit1 = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        float VelClamp = Mathf.Clamp(this.Vel, 20, 80);
        newRot2 = -this.thisVTransform.up;
        this.vPoint.rotation = Quaternion.LookRotation(newRot2);
        Vector3 newRot = -this.thisVTransform.up.normalized;
        newRot = ((-this.thisVTransform.up * 1f) + (-this.thisVTransform.forward * 1f)).normalized;
        Debug.DrawRay(this.thisVTransform.position, (newRot * this.Vel) * 2, Color.white);
        if (Physics.Raycast(this.thisVTransform.position, newRot, out hit0, this.Vel * 2, (int) this.targetLayers))
        {
            if (hit0.distance < 128)
            {
                this.Obstacle = 4;
            }
            else
            {
                this.Obstacle = 2;
            }
        }
        else
        {
            this.Obstacle = 0;
        }
        Debug.DrawRay(this.thisTransform.position, (this.vPoint.forward * VelClamp) * 0.5f, Color.green);
        if (Physics.Raycast(this.thisTransform.position, this.vPoint.forward, out hit0, VelClamp * 0.5f, (int) this.targetLayers))
        {
            this.TurnAway = true;
        }
        else
        {
            this.TurnAway = false;
        }
        newRot = ((this.thisTransform.forward * 0.8f) + (this.thisTransform.up * 0.1f)).normalized;
        Debug.DrawRay(this.thisVTransform.position + (this.thisVTransform.forward * 1), newRot * VelClamp, Color.blue);
        if (Physics.Raycast(this.thisVTransform.position + (this.thisVTransform.forward * 1), newRot, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.UpDist = hit2.distance;
        }
        else
        {
            this.UpDist = 60;
        }
        newRot = ((this.thisTransform.forward * 0.8f) + (this.thisTransform.up * -0.1f)).normalized;
        Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.forward * 1), newRot * VelClamp, Color.red);
        if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.forward * 1), newRot, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.DownDist = hit2.distance;
        }
        else
        {
            this.DownDist = 60;
        }
        Debug.DrawRay(this.thisVTransform.position + (this.thisTransform.right * 2), this.vPoint.forward * VelClamp, Color.black);
        if (Physics.Raycast(this.thisVTransform.position + (this.thisTransform.right * 2), this.vPoint.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.RightDist = hit1.distance;
        }
        else
        {
            this.RightDist = 60;
        }
        Debug.DrawRay(this.thisVTransform.position + (-this.thisTransform.right * 2), this.vPoint.forward * VelClamp, Color.black);
        if (Physics.Raycast(this.thisVTransform.position + (-this.thisTransform.right * 2), this.vPoint.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.LeftDist = hit1.distance;
        }
        else
        {
            this.LeftDist = 60;
        }
        if (this.RightDist != this.LeftDist)
        {
            if (this.TurnAway)
            {
                this.LeftDist = 1;
            }
        }
        this.Diff = Mathf.Abs(this.UpDist - this.DownDist);
        if (this.DownDist > this.UpDist)
        {
            this.TurnDown = true;
            this.TurnUp = false;
        }
        if (this.UpDist > this.DownDist)
        {
            this.TurnUp = true;
            this.TurnDown = false;
        }
        if (this.Diff > 20)
        {
            this.TurnDown = false;
            this.TurnUp = false;
        }
        if (this.RightDist > this.LeftDist)
        {
            this.TurnRight = true;
            this.TurnLeft = false;
            this.Obstacle = 8;
        }
        if (this.LeftDist > this.RightDist)
        {
            this.TurnLeft = true;
            this.TurnRight = false;
            this.Obstacle = 8;
        }
        if (this.DownDist == this.UpDist)
        {
            this.TurnDown = false;
            this.TurnUp = false;
        }
        if (this.RightDist == this.LeftDist)
        {
            this.TurnRight = false;
            this.TurnLeft = false;
        }
    }

    public virtual void FixedUpdate()
    {
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        Vector3 localAV = this.vPoint.InverseTransformDirection(this.vRigidbody.angularVelocity);
        float AVModX = localAV.x;
        float AVClampX = Mathf.Clamp(AVModX, -1, 1);
        float AVModY = localAV.y;
        float AVClampY = Mathf.Clamp(AVModY, -1, 1);
        this.Vel = Mathf.Clamp(-localV.y * 2.24f, 4, 256);
        this.vRigidbody.AddTorque(this.vPoint.right * -AVClampX);
        this.vRigidbody.AddTorque(this.vPoint.up * -AVClampY);
        float AVModZ = localAV.z;
        float AVClampZ = Mathf.Clamp(AVModZ, -1, 1);
        this.vRigidbody.AddTorque(this.vPoint.forward * -AVClampZ);
        if (this.Vel < 230)
        {
            this.vRigidbody.AddForce(this.thisVTransform.up * -2);
        }
        if (this.TurnUp)
        {
            this.vRigidbody.AddTorque(-this.thisVTransform.right * 4);
        }
        if (this.TurnDown)
        {
            this.vRigidbody.AddTorque(this.thisVTransform.right * 4);
        }
        if (!this.TurnUp && !this.TurnDown)
        {
            if (this.Obstacle > 1)
            {
                if (this.Obstacle > 3)
                {
                    this.vRigidbody.AddTorque(-this.thisVTransform.right * 4);
                }
                else
                {
                    this.vRigidbody.AddTorque(-this.thisVTransform.right * 2);
                }
            }
        }
        if (this.TurnLeft && !this.TurnRight)
        {
            this.vRigidbody.AddTorque(this.thisVTransform.forward * -3);
        }
        if (this.TurnRight && !this.TurnLeft)
        {
            this.vRigidbody.AddTorque(this.thisVTransform.forward * 3);
        }
        this.vRigidbody.AddForceAtPosition(Vector3.up * this.StabForce, this.thisTransform.up * 2);
        this.vRigidbody.AddForceAtPosition(-Vector3.up * this.StabForce, -this.thisTransform.up * 2);
        this.vRigidbody.angularDrag = 4;
        if (this.target)
        {
            if (((!this.TurnLeft && !this.TurnRight) && !this.TurnUp) && !this.TurnDown)
            {
                if (this.Dist > 1024)
                {
                    this.vRigidbody.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * -0.5f, this.thisVTransform.up * 2);
                    this.vRigidbody.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * 0.5f, -this.thisVTransform.up * 2);
                }
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            string ON = other.name;
            if (ON.Contains("TFC0a"))
            {
                this.PissedAtTC0a = this.PissedAtTC0a + 1;
            }
            if (ON.Contains("TFC1"))
            {
                this.PissedAtTC1 = this.PissedAtTC1 + 1;
            }
            if (ON.Contains("TFC4"))
            {
                this.PissedAtTC4 = this.PissedAtTC4 + 1;
            }
            if (ON.Contains("TFC7"))
            {
                this.PissedAtTC7 = this.PissedAtTC7 + 1;
            }
            if (ON.Contains("TFC8"))
            {
                this.PissedAtTC8 = this.PissedAtTC8 + 1;
            }
            if (ON.Contains("TFC9"))
            {
                this.PissedAtTC9 = this.PissedAtTC9 + 1;
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (other)
        {
            if (this.PissedAtTC0a > 1)
            {
                if (ON.Contains("TC0a"))
                {
                    this.Attacking = true;
                    this.Hunting = false;
                    this.target = OT;
                }
            }
            if (this.PissedAtTC1 > 1)
            {
                if (ON.Contains("TC1"))
                {
                    this.Attacking = true;
                    this.Hunting = false;
                    this.target = OT;
                }
            }
            if (this.PissedAtTC4 > 1)
            {
                if (ON.Contains("TC4"))
                {
                    this.Attacking = true;
                    this.Hunting = false;
                    this.target = OT;
                }
            }
            if (this.PissedAtTC5 > 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC5"))
                    {
                        this.Attacking = true;
                        this.Hunting = false;
                        this.target = OT;
                    }
                }
            }
            if (this.PissedAtTC6 > 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC6"))
                    {
                        this.Attacking = true;
                        this.Hunting = false;
                        this.target = OT;
                    }
                }
            }
            if (this.PissedAtTC7 > 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC7"))
                    {
                        this.Attacking = true;
                        this.Hunting = false;
                        this.target = OT;
                    }
                }
            }
            if (this.PissedAtTC8 > 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC8"))
                    {
                        this.Attacking = true;
                        this.Hunting = false;
                        this.target = OT;
                    }
                }
            }
            if (this.PissedAtTC9 > 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC9"))
                    {
                        this.Attacking = true;
                        this.Hunting = false;
                        this.target = OT;
                    }
                }
            }
        }
    }

    public virtual void Shooty()
    {
        if (this.Attacking)
        {
            if (this.Gun)
            {
                this.StartCoroutine(this.Shoot());
            }
        }
    }

    public virtual IEnumerator Shoot()
    {
        yield return new WaitForSeconds(this.UniqueShootTime);
        this.Gun.Fire();
    }

    public virtual void Updater()
    {
        if (TerrahyptianNetwork.TC1CriminalLevel > 480)
        {
            this.PissedAtTC1 = 60;
        }
        if (TerrahyptianNetwork.TC5CriminalLevel > 480)
        {
            this.PissedAtTC5 = 60;
        }
        if (TerrahyptianNetwork.TC6CriminalLevel > 480)
        {
            this.PissedAtTC6 = 60;
        }
        if (TerrahyptianNetwork.TC7CriminalLevel > 480)
        {
            this.PissedAtTC7 = 60;
        }
        if (TerrahyptianNetwork.TC8CriminalLevel > 480)
        {
            this.PissedAtTC8 = 60;
        }
        if (TerrahyptianNetwork.TC9CriminalLevel > 480)
        {
            this.PissedAtTC9 = 60;
        }
        if (this.PissedAtTC0a > 1)
        {
            this.PissedAtTC0a = this.PissedAtTC0a - 1;
        }
        if (this.PissedAtTC1 > 1)
        {
            this.PissedAtTC1 = this.PissedAtTC1 - 1;
        }
        if (this.PissedAtTC4 > 1)
        {
            this.PissedAtTC4 = this.PissedAtTC4 - 1;
        }
        if (this.PissedAtTC5 > 1)
        {
            this.PissedAtTC5 = this.PissedAtTC5 - 1;
        }
        if (this.PissedAtTC6 > 1)
        {
            this.PissedAtTC6 = this.PissedAtTC6 - 1;
        }
        if (this.PissedAtTC7 > 1)
        {
            this.PissedAtTC7 = this.PissedAtTC7 - 1;
        }
        if (this.PissedAtTC8 > 1)
        {
            this.PissedAtTC8 = this.PissedAtTC8 - 1;
        }
        if (this.PissedAtTC9 > 1)
        {
            this.PissedAtTC9 = this.PissedAtTC9 - 1;
        }
        this.TurnRight = false;
        this.TurnLeft = false;
        if (this.target)
        {
            this.Dist = Vector3.Distance(this.thisTransform.position, this.target.position);
        }
        if (this.target)
        {
            if (this.Attacking)
            {
                if (TerrahyptianNetwork.TC1CriminalLevel > 480)
                {
                    if (this.target.name.Contains("C1"))
                    {
                        TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                        TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                        TerrahyptianNetwork.AlertTime = 240;
                    }
                    if (this.target.name.Contains("C3"))
                    {
                        TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                        TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                        WorldInformation.PiriExposed = 10;
                    }
                    if (this.target.name.Contains("C5"))
                    {
                        if (TerrahyptianNetwork.TC5CriminalLevel < 20)
                        {
                            TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                            TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                            if (TerrahyptianNetwork.UnitsPresent)
                            {
                                TerrahyptianNetwork.TC5CriminalLevel = 15;
                            }
                        }
                        else
                        {
                            TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                            TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                        }
                    }
                    if (this.target.name.Contains("C6"))
                    {
                        if (TerrahyptianNetwork.TC6CriminalLevel < 20)
                        {
                            TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                            TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                            if (TerrahyptianNetwork.UnitsPresent)
                            {
                                TerrahyptianNetwork.TC6CriminalLevel = 15;
                            }
                        }
                        else
                        {
                            TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                            TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                        }
                    }
                    if (this.target.name.Contains("C7"))
                    {
                        if (TerrahyptianNetwork.TC7CriminalLevel < 20)
                        {
                            TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                            TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                            if (TerrahyptianNetwork.UnitsPresent)
                            {
                                TerrahyptianNetwork.TC7CriminalLevel = 15;
                            }
                        }
                        else
                        {
                            TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                            TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                        }
                    }
                    if (this.target.name.Contains("C8"))
                    {
                        if (TerrahyptianNetwork.TC8CriminalLevel < 20)
                        {
                            TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                            TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                            if (TerrahyptianNetwork.UnitsPresent)
                            {
                                TerrahyptianNetwork.TC8CriminalLevel = 15;
                            }
                        }
                        else
                        {
                            TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                            TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                        }
                    }
                    if (this.target.name.Contains("C9"))
                    {
                        if (TerrahyptianNetwork.TC9CriminalLevel < 20)
                        {
                            TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                            TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                            if (TerrahyptianNetwork.UnitsPresent)
                            {
                                TerrahyptianNetwork.TC9CriminalLevel = 15;
                            }
                        }
                        else
                        {
                            TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                            TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
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
                    }
                    if (this.target.name.Contains("C9"))
                    {
                        TerrahyptianNetwork.AlertLVL2 = 9;
                    }
                }
                if (this.target == this.ResetView)
                {
                    this.Attacking = false;
                    this.target = this.ResetView;
                    //FoundExtraBig = false;
                }
                if (this.target.name.Contains("rok"))
                {
                    this.Attacking = false;
                    this.target = this.ResetView;
                    //FoundExtraBig = false;
                }
                this.Trig.center = new Vector3(0, 0, 0);
                this.Trig.radius = 128;
            }
            else
            {
                this.StartCoroutine(this.TrigSweep());
            }
        }
        else
        {
            this.Attacking = false;
            this.target = this.ResetView;
            //FoundExtraBig = false;
        }
    }

    public virtual IEnumerator TrigSweep()
    {
        this.Trig.center = new Vector3(0, -700, 1000);
        this.Trig.radius = 1000;
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(700, -700, 700);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(1000, -700, 0);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(700, -700, -700);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(0, -700, -1000);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(-700, -700, -700);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(-1000, -700, 0);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(-700, -700, 700);
    }

    public LevNavDroneAI()
    {
        this.ObsStartY = 4;
        this.ObsStartZ = 0.1f;
        this.RightDist = 200;
        this.LeftDist = 200;
        this.UpDist = 200;
        this.DownDist = 200;
        this.Dist = 1000;
        this.StabForce = 2;
        this.Diff = 2;
        this.RD = 1;
        this.UniqueShootTime = 0.1f;
    }

}