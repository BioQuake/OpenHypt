using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ArchocapacitorScript : MonoBehaviour
{
    public Transform target;
    public float AimForce;
    public float Force;
    public bool Aiming;
    public Transform thisTransform;
    public Rigidbody thisRigidbody;
    public int ProximityRange;
    public bool IsDoomstar;
    public bool PylonMigrate;
    public bool DoomclawMigrate;
    public bool LinearCourse;
    public bool CanCol;
    public bool Discharge;
    public bool Charged;
    public bool Boosting;
    public bool Boosted;
    public GameObject BoostSound;
    public Vector3 localV;
    public bool Obstacle;
    public SphereCollider Sphere1;
    public SphereCollider Sphere2;
    public SphereCollider Trigger;
    public AudioSource Noise1;
    public AudioSource Noise2;
    public GameObject BowShockEffects;
    public GameObject AllEffects;
    public GameObject AuraEffects;
    public GameObject explosion;
    public GameObject DischargeEffect;
    public GameObject GlowOffEffect;
    public ParticleSystem GlowEffect;
    public Light LightEffect;
    public KillOverTime Remover;
    public static Transform newTarget;
    public Transform CivArea;
    public int CivCount;
    public float VelClamp;
    public LayerMask targetLayers;
    public virtual void Start()
    {
        this.InvokeRepeating("Counter", 0.1f, 0.33f);
        if (this.IsDoomstar)
        {
            AgrianNetwork.DoomstarActive = true;
            AgrianNetwork.theDoomstar = this.thisTransform;
            this.Charged = true;
            this.Aiming = true;
            this.Noise2.volume = 1;
            this.Noise1.volume = 0;
            this.AuraEffects.gameObject.SetActive(true);
            this.BowShockEffects.gameObject.SetActive(true);
            this.GlowEffect.emissionRate = 64;
            this.LightEffect.intensity = 1;
            this.Sphere1.enabled = true;
            this.Sphere2.enabled = true;
            this.Force = 16;
            this.thisRigidbody.mass = 0.1f;
            this.thisRigidbody.drag = 0.7f;
            this.thisRigidbody.angularDrag = 4;
            this.Trigger.radius = 500;
        }
        else
        {
            AgrianNetwork.DoomstarActive = false;
            this.Charged = false;
            this.Aiming = false;
            this.Noise2.volume = 0;
            this.Noise1.volume = 0;
            this.AuraEffects.gameObject.SetActive(false);
            this.BowShockEffects.gameObject.SetActive(false);
            this.GlowEffect.emissionRate = 0;
            this.LightEffect.intensity = 0;
            this.Sphere1.enabled = false;
            this.Sphere2.enabled = false;
            this.Force = 16;
            this.thisRigidbody.mass = 0.02f;
            this.thisRigidbody.drag = 0.1f;
            this.thisRigidbody.angularDrag = 0.1f;
            this.Trigger.radius = 1;
        }
        if (this.LinearCourse)
        {
            this.Trigger.radius = 1;
            this.thisRigidbody.drag = 0;
            this.thisRigidbody.velocity = this.thisTransform.forward * 250;
        }
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        this.VelClamp = Mathf.Clamp(this.thisRigidbody.velocity.magnitude, 10, 500);
        if (Physics.Raycast(this.thisTransform.position, this.thisTransform.forward, out hit, this.VelClamp, (int) this.targetLayers))
        {
            this.Obstacle = true;
        }
        else
        {
            this.Obstacle = false;
        }
    }

    public virtual void FixedUpdate()
    {
        if ((!this.Discharge && this.IsDoomstar) && !this.LinearCourse)
        {
            if (this.thisRigidbody.velocity != Vector3.zero)
            {
                this.BowShockEffects.transform.rotation = Quaternion.LookRotation(this.thisRigidbody.velocity);
            }
            if (this.target)
            {
                if (this.Obstacle)
                {
                    this.thisRigidbody.AddForce(Vector3.up * 8);
                }
                else
                {
                    if (!this.Boosting)
                    {
                        this.thisRigidbody.AddForce(this.thisTransform.forward * this.Force);
                        this.AimForce = 1;
                    }
                    else
                    {
                        this.thisRigidbody.AddForce(this.thisTransform.forward * this.Force);
                        this.AimForce = 2;
                    }
                }
            }
            else
            {
                this.thisRigidbody.AddForce(this.thisTransform.forward * 8);
            }
            if (this.target)
            {
                this.thisRigidbody.AddForceAtPosition((this.target.transform.position - this.thisTransform.position).normalized * this.AimForce, this.thisTransform.forward * 1);
                this.thisRigidbody.AddForceAtPosition((this.target.transform.position - this.thisTransform.position).normalized * -this.AimForce, -this.thisTransform.forward * 1);
            }
            if (this.target)
            {
                if (((Vector3.Distance(this.thisTransform.position, this.target.position) < this.ProximityRange) && this.Aiming) && (this.CivCount < 1))
                {
                    UnityEngine.Object.Instantiate(this.explosion, this.thisTransform.position, this.explosion.transform.rotation);
                    this.Noise2.volume = 0;
                    this.gameObject.GetComponent<Collider>().enabled = false;
                    this.AllEffects.gameObject.SetActive(false);
                    this.Remover.IsRemoving = true;
                    AgrianNetwork.DoomstarActive = false;
                    UnityEngine.Object.Destroy(this);
                }
            }
        }
        if (this.Discharge)
        {
            if (this.target)
            {
                this.thisRigidbody.AddForce(this.thisTransform.forward * 4);
                this.thisRigidbody.AddForceAtPosition((this.target.transform.position - this.thisTransform.position).normalized * this.AimForce, this.thisTransform.forward * 1);
                this.thisRigidbody.AddForceAtPosition((this.target.transform.position - this.thisTransform.position).normalized * -this.AimForce, -this.thisTransform.forward * 1);
            }
            if (this.Noise2.volume > 0)
            {
                this.Noise2.volume = this.Noise2.volume - 0.001f;
            }
            if (this.Noise1.volume < 1)
            {
                this.Noise1.volume = this.Noise1.volume + 0.001f;
            }
            if (this.Noise2.volume == 0.999f)
            {
                GameObject SpawnedObject = UnityEngine.Object.Instantiate(this.DischargeEffect, this.thisTransform.position, this.thisTransform.rotation);
                SpawnedObject.transform.parent = this.thisTransform;
                this.AuraEffects.gameObject.SetActive(false);
                this.BowShockEffects.gameObject.SetActive(false);
                AgrianNetwork.DoomstarActive = false;
            }
            if (this.Noise2.volume == 0)
            {
                this.thisRigidbody.mass = 0.02f;
                this.thisRigidbody.drag = 0.1f;
                this.thisRigidbody.angularDrag = 0.1f;
                this.target = null;
                this.Discharge = false;
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if ((!this.Discharge && this.IsDoomstar) && !this.LinearCourse)
        {
            if (other.GetComponent<Collider>().name.Contains("C2"))
            {
                if (!other.GetComponent<Collider>().name.Contains("tTC"))
                {
                    this.CivArea = other.gameObject.transform;
                    this.Trigger.radius = 1;
                    this.CivCount = 4;
                    this.Aiming = false;
                }
            }
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (this.LinearCourse && this.CanCol)
        {
            UnityEngine.Object.Instantiate(this.explosion, this.thisTransform.position, this.explosion.transform.rotation);
            this.Noise2.volume = 0;
            this.gameObject.GetComponent<Collider>().enabled = false;
            this.AllEffects.gameObject.SetActive(false);
            this.Remover.IsRemoving = true;
            AgrianNetwork.DoomstarActive = false;
            UnityEngine.Object.Destroy(this);
        }
        if (((this.Charged && !this.IsDoomstar) && !this.LinearCourse) && (this.Noise2.volume == 0))
        {
            if (((((collision.gameObject.tag == "SoftTerrain") || (collision.gameObject.tag == "Terrain")) || (collision.gameObject.tag == "Structure")) || (collision.gameObject.tag == "MetalStructure")) || (collision.gameObject.tag == "Vehicle"))
            {
                this.Charged = false;
                this.GlowEffect.emissionRate = 0;
                this.Noise1.volume = 0;
                this.LightEffect.intensity = 0;
                UnityEngine.Object.Instantiate(this.GlowOffEffect, this.thisTransform.position, this.thisTransform.rotation);
            }
        }
        if (collision.gameObject.name.Contains("Z#") && !this.Charged)
        {
            if (this.GlowEffect.emissionRate < 64)
            {
                this.GlowEffect.emissionRate = this.GlowEffect.emissionRate + 8;
            }
            if (this.Noise1.volume < 1)
            {
                this.Noise1.volume = this.Noise1.volume + 0.125f;
                this.LightEffect.intensity = this.LightEffect.intensity + 0.125f;
            }
            if (this.GlowEffect.emissionRate == 64)
            {
                this.Charged = true;
            }
        }
    }

    public virtual void Counter()
    {
        if (ArchocapacitorScript.newTarget)
        {
            this.target = ArchocapacitorScript.newTarget;
        }
        if (AgrianNetwork.DoomclawActive)
        {
            this.target = AgrianNetwork.theDoomclaw;
            this.DoomclawMigrate = true;
            this.thisRigidbody.drag = 4;
        }
        if (this.DoomclawMigrate)
        {
            return;
        }
        if (this.target)
        {
            AgrianNetwork.doomstarTarget = this.target;
            if (this.target.name.Contains("EnergyBall"))
            {
                if (Vector3.Distance(this.thisTransform.position, this.target.position) < 30)
                {
                    this.Sphere2.enabled = false;
                    if (Vector3.Distance(this.thisTransform.position, this.target.position) < 15)
                    {
                        this.IsDoomstar = false;
                        this.Trigger.radius = 1;
                        this.Discharge = true;
                        this.Sphere1.enabled = false;
                        this.Sphere2.enabled = false;
                    }
                }
            }
        }
        if ((!this.Discharge && this.IsDoomstar) && !this.LinearCourse)
        {
            if (this.PylonMigrate)
            {
                this.Force = 16;
                if (Vector3.Distance(this.thisTransform.position, this.target.position) < 1000)
                {
                    this.thisRigidbody.drag = 4;
                }
                else
                {
                    this.thisRigidbody.drag = 0.7f;
                }
            }
            else
            {
                if (this.target == null)
                {
                    this.target = EnergyPylonScript.EnergyBallArea;
                }
                else
                {
                    if (WorldInformation.instance.AreaCode == 9)
                    {
                        this.target = EnergyPylonScript.EnergyBallArea;
                    }
                    if (!this.target.name.Contains("TC"))
                    {
                        this.target = EnergyPylonScript.EnergyBallArea;
                        this.PylonMigrate = true;
                    }
                    else
                    {
                        this.localV = this.thisTransform.InverseTransformDirection(this.thisRigidbody.velocity);
                        if ((this.localV.x < 10) && (this.localV.y < 10))
                        {
                            if (!this.Boosted && !this.CivArea)
                            {
                                this.StartCoroutine(this.Boost());
                            }
                        }
                    }
                }
                if (this.target)
                {
                    if (!this.Boosting)
                    {
                        if (this.thisRigidbody.drag < 2)
                        {
                            this.thisRigidbody.drag = this.thisRigidbody.drag + 0.005f;
                        }
                        if (this.Force < 50)
                        {
                            this.Force = this.Force + 0.125f;
                        }
                    }
                    else
                    {
                        this.thisRigidbody.drag = 2;
                    }
                    if (this.CivArea)
                    {
                        if (Vector3.Distance(this.CivArea.position, this.target.position) < 1000)
                        {
                            this.thisRigidbody.drag = 4;
                        }
                        else
                        {
                            if (this.thisRigidbody.drag > 2)
                            {
                                this.thisRigidbody.drag = 0.7f;
                            }
                        }
                    }
                }
                this.Trigger.radius = 1000;
                if (this.CivArea)
                {
                    if (Vector3.Distance(this.CivArea.transform.position, this.thisTransform.position) > 1000)
                    {
                        this.CivArea = null;
                        this.Aiming = true;
                    }
                }
                else
                {
                    this.Aiming = true;
                }
                if (this.CivCount > 0)
                {
                    this.CivCount = this.CivCount - 1;
                }
                if (AgrianNetwork.DismissDoomstar)
                {
                    this.target = EnergyPylonScript.EnergyBallArea;
                }
            }
        }
        this.CanCol = true;
    }

    public virtual IEnumerator Boost()
    {
        this.Boosting = true;
        this.Boosted = true;
        this.thisRigidbody.drag = 2;
        this.Force = 180;
        GameObject TheThing = UnityEngine.Object.Instantiate(this.BoostSound, this.thisTransform.position, this.thisTransform.rotation);
        TheThing.transform.parent = this.thisTransform;
        yield return new WaitForSeconds(1.5f);
        this.Boosting = false;
        this.thisRigidbody.drag = 0.7f;
        this.Force = 16;
        yield return new WaitForSeconds(6);
        this.Boosted = false;
    }

    public ArchocapacitorScript()
    {
        this.AimForce = 1;
        this.ProximityRange = 5;
    }

}