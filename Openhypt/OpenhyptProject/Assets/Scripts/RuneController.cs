using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RuneController : MonoBehaviour
{
    public Transform target;
    public Transform waypoint;
    public Transform home;
    public Transform ally;
    public float ForceY;
    public float ForceX;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody thisRigidbody;
    public SphereCollider Trig;
    public GameObject TC;
    public bool isOotSensor;
    public bool isOotPurger;
    public bool isGasController;
    public bool isCommunityRune;
    public bool foundOot;
    public bool foundOotkin;
    public AudioClip Sound1;
    public AudioClip Sound2;
    public AudioSource RuneNoise;
    public LayerMask targetLayers;
    public int Tick;
    public virtual void Start()
    {
        if (this.isGasController)
        {
        }
    }

    public virtual void Update()
    {
        this.thisTransform.rotation = this.thisVTransform.rotation;
        this.thisTransform.position = this.thisVTransform.position;
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.isGasController)
        {
            this.thisRigidbody.AddTorque(this.thisVTransform.forward * Random.Range(2E-05f, 4E-05f));
            this.thisRigidbody.AddTorque(this.thisVTransform.right * Random.Range(-5E-05f, 5E-05f));
        }
        else
        {
            this.thisRigidbody.AddTorque(this.thisVTransform.up * Random.Range(1E-05f, 2E-05f));
            this.thisRigidbody.AddForceAtPosition(Vector3.up * 2E-05f, this.thisVTransform.up * 1);
            this.thisRigidbody.AddForceAtPosition(-Vector3.up * 2E-05f, -this.thisVTransform.up * 1);
        }
        if (this.target)
        {
            if (this.isGasController)
            {
                this.thisRigidbody.AddForce((this.target.position - this.thisVTransform.position).normalized * Random.Range(1E-05f, 0.0001f));
            }
            else
            {
                this.thisRigidbody.AddForce((this.target.position - this.thisVTransform.position).normalized * 0.0001f);
            }
        }
        else
        {
            this.ForceY = this.ForceY + Random.Range(-1E-05f, 1E-05f);
            this.ForceX = this.ForceX + Random.Range(-1E-05f, 1E-05f);
            if (-this.ForceY > 5E-05f)
            {
                this.ForceY = -5E-05f;
            }
            if (this.ForceY > 5E-05f)
            {
                this.ForceY = 5E-05f;
            }
            if (-this.ForceX > 5E-05f)
            {
                this.ForceX = -5E-05f;
            }
            if (this.ForceX > 5E-05f)
            {
                this.ForceX = 5E-05f;
            }
            this.thisRigidbody.AddForce(this.thisVTransform.up * this.ForceY);
            this.thisRigidbody.AddForce(this.thisVTransform.right * this.ForceX);
        }
        if (Physics.Raycast(this.thisVTransform.position, Vector3.down, out hit, 2, (int) this.targetLayers))
        {
            this.thisRigidbody.AddForce(Vector3.up * 7E-05f);
        }
        if (!Physics.Raycast(this.thisVTransform.position, Vector3.down, out hit, 5, (int) this.targetLayers))
        {
            this.thisRigidbody.AddForce(Vector3.up * -7E-05f);
        }
        this.Tick = this.Tick + Random.Range(1, 3);
        if (this.Tick > 180)
        {
            this.Tick = 0;
            this.Ticker();
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (!this.home)
        {
            if (this.isCommunityRune)
            {
                if (other.name.Contains("CR1"))
                {
                    this.home = other.transform;
                }
            }
            else
            {
                if (other.name.Contains("CR2"))
                {
                    this.home = other.transform;
                }
            }
        }
        if (this.isOotPurger)
        {
            if (!this.ally)
            {
                if (other.name.Contains("RuneNot"))
                {
                    if (!Physics.Linecast(this.thisVTransform.position, other.transform.position, (int) this.targetLayers))
                    {
                        this.ally = other.transform;
                    }
                }
            }
            if (other.name.Contains("Ootkin"))
            {
                if (!Physics.Linecast(this.thisVTransform.position, other.transform.position, (int) this.targetLayers))
                {
                    this.target = other.transform;
                    this.Trig.radius = 1;
                }
            }
        }
        if (this.isOotSensor)
        {
            if (other.name.Contains("Oot"))
            {
                if (other.name.Contains("Ootkin"))
                {
                    if (!Physics.Linecast(this.thisVTransform.position, other.transform.position, (int) this.targetLayers))
                    {
                        this.foundOotkin = true;
                    }
                }
                if (this.Trig.radius > 16)
                {
                    if (!Physics.Linecast(this.thisVTransform.position, other.transform.position, (int) this.targetLayers))
                    {
                        this.foundOot = true;
                    }
                }
            }
        }
    }

    public virtual void Ticker()
    {
        if (this.isCommunityRune)
        {
            if (this.home)
            {
                if (Vector3.Distance(this.thisVTransform.position, this.home.position) > 12)
                {
                    this.target = this.home;
                }
            }
        }
        else
        {
            if (this.isGasController)
            {
                Vector3 newPosition = Random.insideUnitSphere * 16;

                {
                    float _2936 = newPosition.x;
                    Vector3 _2937 = this.waypoint.localPosition;
                    _2937.x = _2936;
                    this.waypoint.localPosition = _2937;
                }

                {
                    float _2938 = newPosition.y;
                    Vector3 _2939 = this.waypoint.localPosition;
                    _2939.y = _2938;
                    this.waypoint.localPosition = _2939;
                }

                {
                    float _2940 = newPosition.z;
                    Vector3 _2941 = this.waypoint.localPosition;
                    _2941.z = _2940;
                    this.waypoint.localPosition = _2941;
                }
                if (this.home)
                {
                    if (Vector3.Distance(this.thisVTransform.position, this.home.position) > 64)
                    {
                        this.target = this.home;
                    }
                    else
                    {
                        this.target = this.waypoint;
                    }
                }
            }
            else
            {
                if (this.home)
                {
                    if (Vector3.Distance(this.thisVTransform.position, this.home.position) > 32)
                    {
                        this.target = this.home;
                    }
                }
            }
        }
        if (this.home)
        {
            if (Vector3.Distance(this.thisVTransform.position, this.home.position) < 8)
            {
                if (this.target == this.home)
                {
                    this.target = null;
                }
            }
        }
        if (this.isOotPurger)
        {
            if (this.target)
            {
                this.TC.name = "Rune";
                if (this.target.name.Contains("Ootkin"))
                {
                    this.foundOotkin = true;
                    if (Vector3.Distance(this.thisVTransform.position, this.target.position) < 4)
                    {
                        //RuneNoise.clip = Sound1;
                        //RuneNoise.Play();
                        this.TC.name = "Oof";
                        this.foundOotkin = false;
                    }
                }
                else
                {
                    this.target = null;
                }
            }
            else
            {
                this.foundOotkin = false;
            }
            if (this.ally)
            {
                if (!this.foundOotkin)
                {
                    if (this.ally.name.Contains("OotNot"))
                    {
                        if (Vector3.Distance(this.thisVTransform.position, this.ally.position) > 6)
                        {
                            this.target = this.ally;
                        }
                    }
                }
            }
        }
        if (this.isOotSensor)
        {
            if (this.foundOot)
            {
                this.foundOot = false;
                this.RuneNoise.clip = this.Sound1;
                this.RuneNoise.Play();
                this.Trig.radius = 0.1f;
                this.TC.name = "Rune";
            }
            if (this.foundOotkin)
            {
                this.foundOotkin = false;
                this.RuneNoise.clip = this.Sound2;
                this.RuneNoise.Play();
                this.Trig.radius = 0.1f;
                this.TC.name = "OotNot";
            }
            if (this.Trig.radius > 8)
            {
                this.TC.name = "RuneNot";
            }
        }
        if (this.isOotSensor)
        {
            if (this.Trig.radius < 48)
            {
                this.Trig.radius = this.Trig.radius + 1;
            }
        }
        else
        {
            if (this.Trig.radius < 18)
            {
                this.Trig.radius = this.Trig.radius + 1;
            }
        }
    }

}