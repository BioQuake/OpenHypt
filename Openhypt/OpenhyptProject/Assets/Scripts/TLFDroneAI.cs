using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TLFDroneAI : MonoBehaviour
{
    public Transform target;
    public GameObject Waypoint;
    public Transform Home;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public Transform AIAnchor;
    public GameObject Vessel;
    public CapsuleCollider Trig;
    public GameObject Presence;
    public Transform thisTC;
    public GameObject ShotTC1;
    public Transform Muzzle1;
    public Transform Muzzle2;
    public GameObject Wing;
    public AudioSource Sounds;
    public GameObject AlarmSound;
    public bool Obscurity;
    public bool Damaged;
    public bool IsActive;
    public bool Obstacle;
    public bool TurnRight;
    public bool TurnLeft;
    public int PissedAtTC0a;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public bool Attacking;
    public bool LineOfFire;
    public bool HomeIsMoving;
    public LayerMask targetLayers;
    public float GyroForce;
    public float TurnForce;
    public float Force;
    public float ManeuvForce;
    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 0.7f, 1);
        this.InvokeRepeating("Shooty", Random.Range(0.1f, 1.1f), Random.Range(0.49f, 0.51f));
        this.Force = 0.1f;
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.Vessel == null)
        {
            UnityEngine.Object.Destroy(this.Waypoint);
            UnityEngine.Object.Destroy(this.gameObject);
        }
        if (this.Damaged)
        {
            this.Sounds.volume = 0;
            this.vRigidbody.drag = 0.1f;
            this.vRigidbody.angularDrag = 0.1f;
            UnityEngine.Object.Destroy(this.Presence);
            UnityEngine.Object.Destroy(this.Waypoint);
            UnityEngine.Object.Destroy(this.gameObject);
        }
        if (this.Damaged)
        {
            return;
        }
        if (!this.IsActive || (this.Vessel == null))
        {
            return;
        }
        this.thisTransform.rotation = this.AIAnchor.transform.rotation;
        this.thisTransform.position = this.AIAnchor.transform.position;
        if (this.target == null)
        {
            this.Trig.center = new Vector3(0, 0, 20);
            this.Trig.radius = 30;
            this.Trig.height = 100;
        }
        if (this.target)
        {
            Debug.DrawRay(this.thisTransform.position, this.thisTransform.forward * 100f, Color.red);
            if (Physics.Raycast(this.thisTransform.position, this.thisTransform.forward, out hit, 100, (int) this.targetLayers))
            {
                if (hit.collider.name.Contains(this.target.name))
                {
                    this.LineOfFire = true;
                }
                else
                {
                    this.LineOfFire = false;
                }
            }
        }
        if (this.TurnLeft)
        {
            this.TurnForce = -0.005f;
        }
        if (this.TurnRight)
        {
            this.TurnForce = 0.005f;
        }
        if (!this.TurnRight && !this.TurnLeft)
        {
            this.TurnForce = 0;
        }
        if (this.TurnRight && this.TurnLeft)
        {
            this.TurnForce = 0;
        }
        Vector3 newRot = (this.thisTransform.forward * 0.6f).normalized;
        newRot = ((this.thisTransform.forward * 0.6f) + (this.thisTransform.right * 0.4f)).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), newRot * 10f, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), newRot, 10, (int) this.targetLayers))
        {
            this.TurnLeft = true;
        }
        else
        {
            this.TurnLeft = false;
        }
        newRot = ((this.thisTransform.forward * 0.6f) + (this.thisTransform.right * -0.4f)).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), newRot * 10f, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), newRot, 10, (int) this.targetLayers))
        {
            this.TurnRight = true;
        }
        else
        {
            this.TurnRight = false;
        }
        if (this.vRigidbody.velocity.magnitude > 10)
        {
            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward * 20f, Color.black);
            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward, 20, (int) this.targetLayers))
            {
                this.Obstacle = true;
            }
            else
            {
                this.Obstacle = false;
            }
        }
        else
        {
            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward * 10f, Color.black);
            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward, 10, (int) this.targetLayers))
            {
                this.Obstacle = true;
            }
            else
            {
                this.Obstacle = false;
            }
        }
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward, out hit, 12) && hit.collider.tag.Contains("Te"))
        {
            this.Obscurity = true;
            this.target = null;
        }
        else
        {
            this.Obscurity = false;
        }
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.Vessel)
        {
            if (!this.IsActive)
            {
                if (this.Sounds.volume > 0)
                {
                    this.Sounds.volume = this.Sounds.volume - 0.05f;
                }
            }
            if (this.IsActive)
            {
                if (this.Sounds.volume < 0.5f)
                {
                    this.Sounds.volume = this.Sounds.volume + 0.05f;
                }
            }
        }
        if (!this.IsActive || (this.Vessel == null))
        {
            return;
        }
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        if (-localV.y > 2)
        {
            this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
            if (Physics.Raycast(this.thisTransform.position, Vector3.down, 2, (int) this.targetLayers))
            {
                this.vRigidbody.AddForce(Vector3.up * 0.1f);
            }
        }
        else
        {
            if (Physics.Raycast(this.thisTransform.position, Vector3.down, 2, (int) this.targetLayers))
            {
                this.vRigidbody.AddForce(Vector3.up * 0.07f);
            }
        }
        if (this.ManeuvForce != 0)
        {
            this.vRigidbody.AddForce(this.thisTransform.up * this.ManeuvForce);
        }
        if (this.target)
        {
            this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * 0.04f, this.thisTransform.forward * 0.8f);
            this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -0.04f, -this.thisTransform.forward * 0.8f);
        }
        if (this.Attacking)
        {
            this.vRigidbody.AddForceAtPosition(Vector3.up * this.GyroForce, this.thisTransform.up * 0.1f);
            this.vRigidbody.AddForceAtPosition(-Vector3.up * this.GyroForce, -this.thisTransform.up * 0.1f);
        }
        else
        {
            this.vRigidbody.AddForceAtPosition(Vector3.up * this.GyroForce, this.thisTransform.up * 0.2f);
            this.vRigidbody.AddForceAtPosition(-Vector3.up * this.GyroForce, -this.thisTransform.up * 0.2f);
        }
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward, out hit, 5))
        {
            if (hit.collider.tag.Contains("Te"))
            {
                this.vRigidbody.AddForce(this.thisVTransform.forward * 0.1f);
            }
            if (hit.collider.tag.Contains("Str"))
            {
                this.vRigidbody.AddForce(this.thisVTransform.forward * 0.1f);
            }
        }
        if (this.Obstacle && (-localV.y > 1))
        {
            if (-localV.y > 10)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * -0.8f);
            }
            else
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * -0.2f);
            }
        }
        if (!this.Obstacle)
        {
            this.vRigidbody.AddForce(-this.thisVTransform.up * this.Force);
        }
        if (this.Obscurity)
        {
            this.vRigidbody.AddForce(this.thisVTransform.forward * 0.1f);
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name.Contains("TFC4"))
        {
            this.PissedAtTC4 = 1;
        }
        if (other.GetComponent<Collider>().name.Contains("TFC5"))
        {
            this.PissedAtTC5 = 1;
        }
        if (other.GetComponent<Collider>().name.Contains("TFC6"))
        {
            this.PissedAtTC6 = 1;
        }
        if (other.GetComponent<Collider>().name.Contains("TFC7"))
        {
            this.PissedAtTC7 = 1;
        }
        if (other.GetComponent<Collider>().name.Contains("TFC8"))
        {
            this.PissedAtTC8 = 1;
        }
        if (other.GetComponent<Collider>().name.Contains("TFC9"))
        {
            this.PissedAtTC9 = 1;
        }
        if (other.GetComponent<Collider>().name.Contains("TC1"))
        {
            if (!other.GetComponent<Collider>().name.Contains("TC1d"))
            {
                this.GetComponent<Rigidbody>().isKinematic = true;
                this.Home = other.gameObject.transform;
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (!this.IsActive)
        {
            return;
        }
        if (other.GetComponent<Collider>().name.Contains("TC0a") && (this.PissedAtTC0a > 0))
        {
            if (!this.Attacking)
            {
                this.Warning();
            }
            this.Attacking = true;
            this.target = other.gameObject.transform;
        }
        if (other.GetComponent<Collider>().name.Contains("TC4") && (this.PissedAtTC4 > 0))
        {
            if (!this.Attacking)
            {
                this.Warning();
            }
            this.Attacking = true;
            this.target = other.gameObject.transform;
        }
        if (other.GetComponent<Collider>().name.Contains("TC5") && (this.PissedAtTC5 > 0))
        {
            if (!this.Attacking)
            {
                this.Warning();
            }
            this.Attacking = true;
            this.target = other.gameObject.transform;
        }
        if (other.GetComponent<Collider>().name.Contains("TC6") && (this.PissedAtTC6 > 0))
        {
            if (!this.Attacking)
            {
                this.Warning();
            }
            this.Attacking = true;
            this.target = other.gameObject.transform;
        }
        if (other.GetComponent<Collider>().name.Contains("TC7") && (this.PissedAtTC7 > 0))
        {
            if (!this.Attacking)
            {
                this.Warning();
            }
            this.Attacking = true;
            this.target = other.gameObject.transform;
        }
        if (other.GetComponent<Collider>().name.Contains("TC8") && (this.PissedAtTC8 > 0))
        {
            if (!this.Attacking)
            {
                this.Warning();
            }
            this.Attacking = true;
            this.target = other.gameObject.transform;
        }
        if (other.GetComponent<Collider>().name.Contains("TC9") && (this.PissedAtTC9 > 0))
        {
            if (!this.Attacking)
            {
                this.Warning();
            }
            this.Attacking = true;
            this.target = other.gameObject.transform;
        }
        this.Trig.center = new Vector3(0, 0, 20);
        this.Trig.radius = 30;
        this.Trig.height = 100;
    }

    public virtual IEnumerator Unstick()
    {
        this.ManeuvForce = -0.2f;
        yield return new WaitForSeconds(0.5f);
        this.ManeuvForce = 0.2f;
        yield return new WaitForSeconds(0.5f);
        this.ManeuvForce = 0;
    }

    public virtual void Warning()
    {
        GameObject TheThing3 = UnityEngine.Object.Instantiate(this.AlarmSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
        TheThing3.transform.parent = this.gameObject.transform;
    }

    public virtual IEnumerator Shoot()
    {
        if (this.LineOfFire)
        {
            GameObject TheThing1 = UnityEngine.Object.Instantiate(this.ShotTC1, this.Muzzle1.position, this.Muzzle1.rotation);
            TheThing1.transform.parent = this.Muzzle1;
            this.thisTC.name = "TC0a";
        }
        yield return new WaitForSeconds(0.25f);
        if (this.LineOfFire)
        {
            GameObject TheThing3 = UnityEngine.Object.Instantiate(this.ShotTC1, this.Muzzle2.position, this.Muzzle2.rotation);
            TheThing3.transform.parent = this.Muzzle1;
            this.thisTC.name = "TC0a";
        }
        this.LineOfFire = false;
        yield return new WaitForSeconds(10);
        this.thisTC.name = "TC0";
    }

    public virtual void Shooty()
    {
        if (this.IsActive)
        {
            if (this.Attacking)
            {
                this.StartCoroutine(this.Shoot());
            }
        }
    }

    public virtual void Regenerator()
    {
        if (this.Damaged)
        {
            return;
        }
        if (this.Home)
        {
            this.IsActive = true;
            this.vRigidbody.drag = 0.4f;
            this.vRigidbody.angularDrag = 15;
            this.Wing.gameObject.SetActive(true);
            if (!this.Attacking)
            {
                if (Vector3.Distance(this.thisTransform.position, this.Home.position) > 15)
                {
                    this.target = this.Home;
                }
                else
                {
                    this.target = null;
                }
            }
            if (!this.Attacking)
            {
                if (Vector3.Distance(this.thisTransform.position, this.Home.position) > 15)
                {
                    this.Force = 0.1f;
                }
                else
                {
                    this.Force = 0;
                }
            }
            else
            {
                this.Force = 0.1f;
            }
        }
        Vector3 lastPos = this.thisTransform.position;
        this.StartCoroutine(this.HomeMoving(lastPos));
        if (this.target == null)
        {
            this.Attacking = false;
        }
        this.LineOfFire = false;
    }

    public virtual IEnumerator HomeMoving(Vector3 lastPos)
    {
        yield return new WaitForSeconds(0.5f);
        if (Vector3.Distance(this.thisTransform.position, lastPos) > 1)
        {
            this.HomeIsMoving = true;
        }
        else
        {
            this.HomeIsMoving = false;
        }
    }

    public TLFDroneAI()
    {
        this.GyroForce = 10f;
        this.Force = 0.2f;
    }

}