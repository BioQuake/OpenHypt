using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AkbarEzymusAI : MonoBehaviour
{
    public Transform target;
    public Transform Forward;
    public GameObject StartTerror;
    public GameObject MusicSound;
    public SphereCollider Trig;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public TurretAI Turret;
    public bool IsBus;
    public bool IsBejsirf;
    public GameObject Terrorist1;
    public GameObject Terrorist2;
    public Transform TerroristSpawn1;
    public Transform TerroristSpawn2;
    public Transform TerroristSpawn3;
    public GameObject TerroristDoor;
    public AudioSource TerroristAudio;
    public bool PissedAtTC1;
    public bool PissedAtTC2;
    public bool PissedAtTC4;
    public bool PissedAtTC5;
    public bool PissedAtTC7;
    public bool PissedAtTC8;
    public bool PissedAtTC9;
    public Transform Ally;
    public bool CloseToBase;
    public bool Bored;
    public bool IsExploding;
    public bool Following;
    public bool Attacking;
    public bool Obstacle;
    public bool CloseObstacle;
    public bool Stuck;
    public bool IsCloseEnough;
    public bool IsTerrorizing;
    public bool TurnRight;
    public bool TurnLeft;
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    public int Suspicion;
    public int JustNoticed;
    public float Force;
    public float TurnForce;
    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.IsExploding || this.IsTerrorizing)
        {
            return;
        }
        if (this.target != null)
        {
            if (this.target.name.Contains("TC6"))
            {
                this.target.name = "TC1";
            }
        }
        if (this.target == null)
        {
            this.StopAllCoroutines();
            this.Attacking = false;
            this.target = this.Forward;
        }
        if (this.target == this.Forward)
        {
            this.StopAllCoroutines();
            this.Attacking = false;
        }
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        Vector3 newRot = ((this.thisTransform.forward * 0.6f) + (this.thisTransform.up * 0.1f)).normalized;
        //-------------------------------------------------------------------------------------------------------------
        if (localV.y > 0.1f)
        {
            this.Obstacle = false;
        }
        if (!this.IsBejsirf)
        {
            if (-localV.y > 20)
            {
                Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 2), this.thisTransform.forward * 40f, Color.green);
                if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 2), this.thisTransform.forward, 40))
                {
                    this.Obstacle = true;
                }
                else
                {
                    this.Obstacle = false;
                }
                newRot = ((-this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * 0.4f)).normalized;
                Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 3), newRot * 40f, Color.black);
                if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 3), newRot, 40))
                {
                    this.TurnLeft = true;
                }
                else
                {
                    this.TurnLeft = false;
                }
                newRot = ((-this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * -0.4f)).normalized;
                Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 3), newRot * 40f, Color.black);
                if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 3), newRot, 40))
                {
                    this.TurnRight = true;
                }
                else
                {
                    this.TurnRight = false;
                }
            }
            else
            {
                if (-localV.y < 20)
                {
                    if (-localV.y > 10)
                    {
                        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 2), this.thisTransform.forward * 30f, Color.green);
                        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 2), this.thisTransform.forward, 30))
                        {
                            this.Obstacle = true;
                        }
                        else
                        {
                            this.Obstacle = false;
                        }
                        newRot = ((-this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * 0.4f)).normalized;
                        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 3), newRot * 30f, Color.black);
                        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 3), newRot, 30))
                        {
                            this.TurnLeft = true;
                        }
                        else
                        {
                            this.TurnLeft = false;
                        }
                        newRot = ((-this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * -0.4f)).normalized;
                        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 3), newRot * 30f, Color.black);
                        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 3), newRot, 30))
                        {
                            this.TurnRight = true;
                        }
                        else
                        {
                            this.TurnRight = false;
                        }
                    }
                    else
                    {
                        if (-localV.y < 10)
                        {
                            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 2), this.thisTransform.forward * 15f, Color.green);
                            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 2), this.thisTransform.forward, 15))
                            {
                                this.Obstacle = true;
                            }
                            else
                            {
                                this.Obstacle = false;
                            }
                            newRot = ((-this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * 0.4f)).normalized;
                            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 3), newRot * 15f, Color.black);
                            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 3), newRot, 15))
                            {
                                this.TurnLeft = true;
                            }
                            else
                            {
                                this.TurnLeft = false;
                            }
                            newRot = ((-this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * -0.4f)).normalized;
                            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 3), newRot * 15f, Color.black);
                            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 3), newRot, 15))
                            {
                                this.TurnRight = true;
                            }
                            else
                            {
                                this.TurnRight = false;
                            }
                        }
                    }
                }
            }
        }
        else
        {
            if (-localV.y > 20)
            {
                if (-localV.y < 40)
                {
                    Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 2), -this.thisVTransform.up * 40f, Color.green);
                    if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 2), -this.thisVTransform.up, 40))
                    {
                        this.Obstacle = true;
                        this.Turret.target = null;
                    }
                    else
                    {
                        this.Obstacle = false;
                    }
                }
                else
                {
                    Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 2), -this.thisVTransform.up * 80f, Color.green);
                    if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 2), -this.thisVTransform.up, 80))
                    {
                        this.Obstacle = true;
                        this.Turret.target = null;
                    }
                    else
                    {
                        this.Obstacle = false;
                    }
                }
                newRot = ((-this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * 0.4f)).normalized;
                Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 3), newRot * 40f, Color.black);
                if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 3), newRot, 40))
                {
                    if (this.JustNoticed < 1)
                    {
                        this.TurnLeft = true;
                        this.Turret.target = null;
                    }
                }
                else
                {
                    this.TurnLeft = false;
                }
                newRot = ((-this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * -0.4f)).normalized;
                Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 3), newRot * 40f, Color.black);
                if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 3), newRot, 40))
                {
                    if (this.JustNoticed < 1)
                    {
                        this.TurnRight = true;
                        this.Turret.target = null;
                    }
                }
                else
                {
                    this.TurnRight = false;
                }
            }
            else
            {
                if (-localV.y < 20)
                {
                    if (-localV.y > 10)
                    {
                        Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 2), -this.thisVTransform.up * 30f, Color.green);
                        if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 2), -this.thisVTransform.up, 30))
                        {
                            this.Obstacle = true;
                            this.Turret.target = null;
                        }
                        else
                        {
                            this.Obstacle = false;
                        }
                        newRot = ((-this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * 0.4f)).normalized;
                        Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 3), newRot * 30f, Color.black);
                        if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 3), newRot, 30))
                        {
                            if (this.JustNoticed < 1)
                            {
                                this.TurnLeft = true;
                                this.Turret.target = null;
                            }
                        }
                        else
                        {
                            this.TurnLeft = false;
                        }
                        newRot = ((-this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * -0.4f)).normalized;
                        Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 3), newRot * 30f, Color.black);
                        if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 3), newRot, 30))
                        {
                            if (this.JustNoticed < 1)
                            {
                                this.TurnRight = true;
                                this.Turret.target = null;
                            }
                        }
                        else
                        {
                            this.TurnRight = false;
                        }
                    }
                    else
                    {
                        if (-localV.y < 10)
                        {
                            Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 2), -this.thisVTransform.up * 15f, Color.green);
                            if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 2), -this.thisVTransform.up, 15))
                            {
                                this.Obstacle = true;
                                this.Turret.target = null;
                            }
                            else
                            {
                                this.Obstacle = false;
                            }
                            newRot = ((-this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * 0.4f)).normalized;
                            Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 3), newRot * 15f, Color.black);
                            if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 3), newRot, 15))
                            {
                                if (this.JustNoticed < 1)
                                {
                                    this.TurnLeft = true;
                                    this.Turret.target = null;
                                }
                            }
                            else
                            {
                                this.TurnLeft = false;
                            }
                            newRot = ((-this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * -0.4f)).normalized;
                            Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 3), newRot * 15f, Color.black);
                            if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 3), newRot, 15))
                            {
                                if (this.JustNoticed < 1)
                                {
                                    this.TurnRight = true;
                                    this.Turret.target = null;
                                }
                            }
                            else
                            {
                                this.TurnRight = false;
                            }
                        }
                    }
                }
            }
        }
        if (this.TurnLeft)
        {
            if (!this.IsBejsirf)
            {
                this.TurnForce = -100;
            }
            else
            {
                this.TurnForce = -30;
            }
        }
        if (this.TurnRight)
        {
            if (!this.IsBejsirf)
            {
                this.TurnForce = 100;
            }
            else
            {
                this.TurnForce = 30;
            }
        }
        if (!this.TurnLeft && !this.TurnRight)
        {
            this.TurnForce = 0;
            Debug.DrawRay(this.thisTransform.position, this.thisTransform.right * 5f, Color.black);
            if (Physics.Raycast(this.thisTransform.position, this.thisTransform.right, 5))
            {
                if (!this.IsBejsirf)
                {
                    this.TurnForce = -30;
                }
                else
                {
                    this.TurnForce = -10;
                }
            }
            Debug.DrawRay(this.thisTransform.position, -this.thisTransform.right * 5f, Color.black);
            if (Physics.Raycast(this.thisTransform.position, -this.thisTransform.right, 5))
            {
                if (!this.IsBejsirf)
                {
                    this.TurnForce = 30;
                }
                else
                {
                    this.TurnForce = 10;
                }
            }
        }
        if (this.Obstacle)
        {
            if (!this.IsBejsirf)
            {
                this.Force = -35;
            }
            if (!this.TurnLeft && !this.TurnRight)
            {
                if (!this.IsBejsirf)
                {
                    if (-localV.y < 10)
                    {
                        this.TurnForce = -100;
                    }
                }
                else
                {
                    this.TurnForce = -30;
                }
            }
        }
        if (this.Stuck && !this.Attacking)
        {
            if (!this.IsBejsirf)
            {
                this.Force = -20;
                this.TurnForce = 6;
            }
        }
    }

    private Quaternion NewRotation;
    public virtual void FixedUpdate()
    {
        if (this.IsExploding)
        {
            return;
        }
        if (!this.IsBejsirf)
        {
            if (this.Following && (this.MusicSound.GetComponent<AudioSource>().volume > 0))
            {
                this.MusicSound.GetComponent<AudioSource>().volume = this.MusicSound.GetComponent<AudioSource>().volume - 0.05f;
            }
            else
            {
                if ((!this.Following && !this.IsTerrorizing) && (this.MusicSound.GetComponent<AudioSource>().volume < 0.8f))
                {
                    this.MusicSound.GetComponent<AudioSource>().volume = this.MusicSound.GetComponent<AudioSource>().volume + 0.05f;
                }
            }
            if (this.IsTerrorizing && (this.MusicSound.GetComponent<AudioSource>().volume > 0))
            {
                this.MusicSound.GetComponent<AudioSource>().volume = this.MusicSound.GetComponent<AudioSource>().volume - 0.05f;
            }
        }
        if (this.IsTerrorizing == true)
        {
            return;
        }
        if (this.target)
        {
            if (this.TurnLeft || this.TurnRight)
            {
                this.GetComponent<Rigidbody>().freezeRotation = false;
            }
            if (!this.TurnLeft && !this.TurnRight)
            {
                this.GetComponent<Rigidbody>().freezeRotation = true;
            }
            if (this.Ally == null)
            {
                this.NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
                if (!this.IsBejsirf)
                {
                    this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 30);
                }
                else
                {
                    this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 100);
                }
                if (this.Attacking)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.target.position) < 30)
                    {
                        if (!this.IsBejsirf && !this.IsBus)
                        {
                            this.TurnForce = 100;
                        }
                    }
                }
            }
            if (this.Ally != null)
            {
                if (Vector3.Distance(this.thisTransform.position, this.Ally.position) > 20)
                {
                    this.NewRotation = Quaternion.LookRotation(this.Ally.position - this.thisTransform.position);
                    if (Vector3.Distance(this.thisTransform.position, this.Ally.position) > 40)
                    {
                        if (!this.IsBejsirf)
                        {
                            this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 30);
                        }
                        else
                        {
                            this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 100);
                        }
                    }
                }
                else
                {
                    if (!this.IsBejsirf)
                    {
                        this.TurnForce = 100;
                    }
                    else
                    {
                        this.TurnForce = 30;
                    }
                }
            }
        }
        if (!this.IsBejsirf)
        {
            this.vRigidbody.AddForce(this.thisVTransform.up * -this.Force);
        }
        else
        {
            if (!this.Obstacle)
            {
                this.vRigidbody.AddForce(this.thisVTransform.up * -this.Force);
            }
        }
        this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
    }

    public virtual void OnTriggerStay(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
        {
            return;
        }
        if (this.IsExploding || this.IsTerrorizing)
        {
            return;
        }
        if (!this.IsBus && (this.Suspicion < 20))
        {
            if (ON.Contains("AkbarLeader"))
            {
                this.Ally = OT;
            }
        }
        if (this.IsBus && (this.Suspicion < 20))
        {
            if (ON.Contains("AkbarGuncarrier") || ON.Contains("AkbarLeader"))
            {
                this.Ally = OT;
            }
        }
        if (ON.Contains("TFC1") && !this.PissedAtTC1)
        {
            this.PissedAtTC1 = true;
        }
        if (ON.Contains("TFC2") && !this.PissedAtTC2)
        {
            this.PissedAtTC2 = true;
        }
        if (ON.Contains("TFC4") && !this.PissedAtTC4)
        {
            this.PissedAtTC4 = true;
        }
        if (ON.Contains("TFC7") && !this.PissedAtTC7)
        {
            this.PissedAtTC7 = true;
        }
        if (ON.Contains("TFC8") && !this.PissedAtTC8)
        {
            this.PissedAtTC8 = true;
        }
        if (ON.Contains("TFC9") && !this.PissedAtTC9)
        {
            this.PissedAtTC9 = true;
        }
        if (this.CloseToBase || this.Bored)
        {
            return;
        }
        if (ON.Contains("TC1"))
        {
            if (!ON.Contains("C1f"))
            {
                if (!ON.Contains("csT"))
                {
                    //Spot = false;
                    //Hunting = false;
                    this.Ally = null;
                    this.target = OT;
                    if (!this.Attacking)
                    {
                        this.Attacking = true;
                        this.StopAllCoroutines();
                    }
                }
            }
            else
            {
                if (this.PissedAtTC1)
                {
                    //Spot = false;
                    //Hunting = false;
                    this.Ally = null;
                    this.target = OT;
                    if (!this.Attacking)
                    {
                        this.Attacking = true;
                        this.StopAllCoroutines();
                    }
                }
            }
        }
        if (this.PissedAtTC2)
        {
            if (ON.Contains("TC2"))
            {
                //Spot = false;
                //Hunting = false;
                this.Ally = null;
                this.target = OT;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
        }
        if (ON.Contains("TC3"))
        {
            if (!ON.Contains("csT"))
            {
                //Spot = false;
                //Hunting = false;
                this.Ally = null;
                this.target = OT;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
        }
        if (this.PissedAtTC4)
        {
            if (ON.Contains("TC4"))
            {
                //Spot = false;
                //Hunting = false;
                this.Ally = null;
                this.target = OT;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
        }
        if (ON.Contains("TC5"))
        {
            //Spot = false;
            //Hunting = false;
            this.Ally = null;
            this.target = OT;
            if (!this.Attacking)
            {
                this.Attacking = true;
                this.StopAllCoroutines();
            }
        }
        if (ON.Contains("TC7"))
        {
            if (!ON.Contains("csT"))
            {
                //Spot = false;
                //Hunting = false;
                this.Ally = null;
                this.target = OT;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
        }
        if (ON.Contains("TC8"))
        {
            if (!ON.Contains("csT"))
            {
                //Spot = false;
                //Hunting = false;
                this.Ally = null;
                this.target = OT;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
        }
        if (ON.Contains("TC9"))
        {
            if (!ON.Contains("csT"))
            {
                //Spot = false;
                //Hunting = false;
                this.Ally = null;
                this.target = OT;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
        }
    }

    public virtual void IsPissed()
    {
        this.Ally = null;
        this.Attacking = true;
        if (this.IsBus)
        {
            this.StartCoroutine(this.StopForTerror());
        }
    }

    public virtual IEnumerator Breaking()
    {
        this.Attacking = false;
        this.Obstacle = true;
        yield return new WaitForSeconds(2);
        this.Attacking = true;
        this.Obstacle = false;
    }

    public virtual void Counter()
    {
        if (this.IsExploding)
        {
            return;
        }
        if (this.Attacking)
        {
            this.Trig.radius = 50;
        }
        else
        {
            this.Trig.radius = 150;
        }
        if (AbiaSyndicateNetwork.instance.AbiaBaseHomePoint)
        {
            if (Vector3.Distance(this.thisTransform.position, AbiaSyndicateNetwork.instance.AbiaBaseHomePoint.position) < 1500)
            {
                this.CloseToBase = true;
            }
            else
            {
                this.CloseToBase = false;
            }
        }
        if (AbiaSyndicateNetwork.TC1CriminalLevel > 0)
        {
            this.PissedAtTC1 = true;
        }
        if (AbiaSyndicateNetwork.TC2CriminalLevel > 0)
        {
            this.PissedAtTC2 = true;
        }
        if (AbiaSyndicateNetwork.TC4CriminalLevel > 0)
        {
            this.PissedAtTC4 = true;
        }
        if (AbiaSyndicateNetwork.TC5CriminalLevel > 0)
        {
            this.PissedAtTC5 = true;
        }
        if (AbiaSyndicateNetwork.TC7CriminalLevel > 0)
        {
            this.PissedAtTC7 = true;
        }
        if (AbiaSyndicateNetwork.TC8CriminalLevel > 0)
        {
            this.PissedAtTC8 = true;
        }
        if (AbiaSyndicateNetwork.TC9CriminalLevel > 0)
        {
            this.PissedAtTC9 = true;
        }
        if (this.target)
        {
            if (!this.Obstacle)
            {
                if (Vector3.Distance(this.thisTransform.position, this.target.position) > 100)
                {
                    if (!this.IsBejsirf)
                    {
                        this.Force = 35;
                    }
                    else
                    {
                        this.Force = 7;
                    }
                    this.TurnForce = 0;
                }
                else
                {
                    if (Vector3.Distance(this.thisTransform.position, this.target.position) < 100)
                    {
                        if (!this.IsBejsirf)
                        {
                            this.Force = 30;
                        }
                        else
                        {
                            this.Force = 5;
                        }
                    }
                }
                if (this.Ally)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.Ally.position) > 40)
                    {
                        if (!this.IsBejsirf)
                        {
                            this.Force = 35;
                        }
                        else
                        {
                            this.Force = 7;
                        }
                        this.TurnForce = 0;
                    }
                    else
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.Ally.position) < 40)
                        {
                            if (!this.IsBejsirf)
                            {
                                this.Force = 30;
                            }
                            else
                            {
                                this.Force = 5;
                            }
                        }
                    }
                }
            }
        }
        if (this.Ally)
        {
            this.Following = true;
        }
        else
        {
            this.Following = false;
        }
        if (this.Suspicion > 60)
        {
            this.IsPissed();
        }
        if (!this.IsBus)
        {
            this.Turret.target = this.target;
            if (this.Attacking)
            {
                this.Turret.Attacking = true;
            }
            else
            {
                this.Turret.Attacking = false;
            }
            if (this.target != null)
            {
                if (this.Attacking)
                {
                    if (!Physics.Linecast(this.thisTransform.position, this.target.position, (int) this.targetLayers))
                    {
                        this.TurnRight = false;
                        this.TurnLeft = false;
                        this.JustNoticed = 2;
                    }
                }
            }
        }
        if (this.JustNoticed > 0)
        {
            this.JustNoticed = this.JustNoticed - 1;
        }
        this.TurnRight = false;
        this.TurnLeft = false;
        if (this.IsBus)
        {
            if (this.target)
            {
                Vector3 TargPos = this.target.position;
                if (Vector3.Distance(this.thisTransform.position, TargPos) < 20)
                {
                    this.IsCloseEnough = true;
                    if (!this.IsExploding)
                    {
                        this.StartCoroutine(this.StopForTerror());
                    }
                }
                else
                {
                    this.IsCloseEnough = false;
                }
            }
        }
    }

    public virtual IEnumerator StopForTerror()
    {
        yield return new WaitForSeconds(1);
        if ((this.Attacking && this.IsCloseEnough) && !this.IsTerrorizing)
        {
            this.IsTerrorizing = true;
            yield return new WaitForSeconds(2);
            if (this.IsBus)
            {
                this.TerroristAudio.Play();
                UnityEngine.Object.Destroy((FixedJoint) this.TerroristDoor.GetComponent(typeof(FixedJoint)));
                this.TerroristDoor.transform.parent = null;
                UnityEngine.Object.Instantiate(this.Terrorist1, this.TerroristSpawn1.position, this.TerroristSpawn1.rotation);
                UnityEngine.Object.Instantiate(this.Terrorist2, this.TerroristSpawn2.position, this.TerroristSpawn2.rotation);
                UnityEngine.Object.Instantiate(this.Terrorist2, this.TerroristSpawn3.position, this.TerroristSpawn3.rotation);
            }
        }
    }

    public virtual void LeaveMarker()
    {
        if (this.IsExploding)
        {
            return;
        }
        if (this.Bored)
        {
            this.Bored = false;
        }
        else
        {
            this.Bored = true;
            this.Attacking = false;
            this.target = this.Forward;
        }
        Vector3 lastPos = this.thisTransform.position;
        this.StartCoroutine(this.IsEscaping(lastPos));
    }

    public virtual IEnumerator IsEscaping(Vector3 lastPos)
    {
        this.Stuck = false;
        yield return new WaitForSeconds(2);
        if (Vector3.Distance(this.thisTransform.position, lastPos) < 5)
        {
            this.Stuck = true;
            yield return new WaitForSeconds(3);
            this.Stuck = false;
        }
    }

    public virtual void Exploding()
    {
        this.IsExploding = true;
        this.StopAllCoroutines();
    }

    public virtual void Start()
    {
        this.InvokeRepeating("LeaveMarker", 10, 10);
        this.InvokeRepeating("Counter", 0.5f, 0.5f);
    }

}