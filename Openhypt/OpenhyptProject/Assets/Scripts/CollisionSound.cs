using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CollisionSound : MonoBehaviour
{
    public AudioClip[] Sound1;
    public int Sound1MinForce;
    public AudioClip Sound2;
    public AudioClip Sound3;
    public AudioClip[] SoundT;
    public Rigidbody vRigidbody;
    public Transform forwardTF;
    public bool Complementary;
    public CollisionSound MainCS;
    public bool CanSound;
    public bool CanTSound;
    public bool CanStrike;
    public bool Broken;
    public bool BrokenC;
    public bool OnlySoundOnce;
    public bool Invincible;
    public bool SkidVehicle;
    public bool Sturdy;
    public bool Argaline;
    public bool IgnoreSmallC;
    public bool HasSpinVac;
    public GameObject VacArea;
    public GameObject StrikePrefabMetal;
    public GameObject StrikePrefabMetalCont;
    public GameObject StrikePrefabStructure;
    public GameObject StrikePrefabStructureCont;
    public GameObject StrikePrefabGround;
    public GameObject StrikePrefabGroundCont;
    public float MSGMaxVolume;
    public GameObject MotionSoundGround;
    public int VesselHealth;
    public int Reps;
    public float rAV;
    public float rV;
    public float lastVelocity;
    public float lastTVelocity;
    public float Gs;
    public float TGs;
    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 1, 0.3f);
        this.InvokeRepeating("Tick2", 1, 0.1f);
        if (!this.forwardTF)
        {
            this.forwardTF = this.transform;
        }
        this.vRigidbody = this.gameObject.GetComponent<Rigidbody>();
        if (this.GetComponent("VehicleDamage") != null)
        {
            this.VesselHealth = (int) this.GetComponent<VehicleDamage>().Health;
        }
    }

    public virtual void FixedUpdate()
    {
        this.rV = this.vRigidbody.velocity.magnitude;
        this.rAV = this.vRigidbody.angularVelocity.magnitude;
        float acceleration = (this.rV - this.lastVelocity) / Time.deltaTime;
        this.lastVelocity = this.rV;
        this.Gs = Mathf.Abs(acceleration);
        float Tacceleration = (this.rAV - this.lastTVelocity) / Time.deltaTime;
        this.lastTVelocity = this.rAV;
        this.TGs = Mathf.Abs(Tacceleration);
        if (!this.Complementary)
        {
            if (!this.Broken)
            {
                if (this.Sound3)
                {
                    if (this.CanSound)
                    {
                        if (!this.Sturdy && !this.Argaline)
                        {
                            if (this.Gs > 2500)
                            {
                                this.CanSound = false;
                                if (this.Sound3)
                                {
                                    this.GetComponent<AudioSource>().PlayOneShot(this.Sound3, 1);
                                }
                                if (this.OnlySoundOnce)
                                {
                                    this.Broken = true;
                                    return;
                                }
                                if (!this.Invincible)
                                {
                                    this.GetComponent<VehicleDamage>().Health = ((int) this.GetComponent<VehicleDamage>().Health) - (this.VesselHealth * 4);
                                    this.GetComponent<VehicleDamage>().DamageIn(0, 0, 0, false);
                                }
                            }
                        }
                        if (this.Sturdy)
                        {
                            if (this.Gs > 3000)
                            {
                                this.CanSound = false;
                                this.GetComponent<AudioSource>().PlayOneShot(this.Sound3, 1);
                                if (this.OnlySoundOnce)
                                {
                                    this.Broken = true;
                                    return;
                                }
                                if (!this.Invincible)
                                {
                                    this.GetComponent<VehicleDamage>().Health = ((int) this.GetComponent<VehicleDamage>().Health) - (this.VesselHealth * 4);
                                    this.GetComponent<VehicleDamage>().DamageIn(0, 0, 0, false);
                                }
                            }
                        }
                        if (this.Argaline)
                        {
                            if (this.Gs > 4000)
                            {
                                this.CanSound = false;
                                this.GetComponent<AudioSource>().PlayOneShot(this.Sound3, 1);
                                if (this.OnlySoundOnce)
                                {
                                    this.Broken = true;
                                    return;
                                }
                                if (!this.Invincible)
                                {
                                    this.GetComponent<VehicleDamage>().Health = ((int) this.GetComponent<VehicleDamage>().Health) - (this.VesselHealth * 4);
                                    this.GetComponent<VehicleDamage>().DamageIn(0, 0, 0, false);
                                }
                            }
                        }
                    }
                    if (this.CanSound)
                    {
                        if (this.Gs > 1500)
                        {
                            this.CanSound = false;
                            this.GetComponent<AudioSource>().PlayOneShot(this.Sound3, 1);
                            if (this.OnlySoundOnce)
                            {
                                this.Broken = true;
                                return;
                            }
                            if (!this.Invincible)
                            {
                                if (!this.Sturdy && !this.Argaline)
                                {
                                    this.GetComponent<VehicleDamage>().Health = ((float) this.GetComponent<VehicleDamage>().Health) - (this.VesselHealth * 0.75f);
                                }
                                if (this.Sturdy && !this.Argaline)
                                {
                                    this.GetComponent<VehicleDamage>().Health = ((float) this.GetComponent<VehicleDamage>().Health) - (this.VesselHealth * 0.35f);
                                }
                                if (this.Argaline)
                                {
                                    this.GetComponent<VehicleDamage>().Health = ((float) this.GetComponent<VehicleDamage>().Health) - (this.VesselHealth * 0.2f);
                                }
                                this.GetComponent<VehicleDamage>().DamageIn(0, 0, 0, false);
                            }
                        }
                    }
                }
                if (this.Sound2)
                {
                    if (this.CanSound)
                    {
                        if (this.Gs > 700)
                        {
                            this.CanSound = false;
                            this.GetComponent<AudioSource>().PlayOneShot(this.Sound2, 1);
                            if (this.OnlySoundOnce)
                            {
                                this.Broken = true;
                                return;
                            }
                            if (!this.Invincible)
                            {
                                if (!this.Sturdy && !this.Argaline)
                                {
                                    this.GetComponent<VehicleDamage>().Health = ((float) this.GetComponent<VehicleDamage>().Health) - (this.VesselHealth * 0.25f);
                                }
                                if (this.Sturdy && !this.Argaline)
                                {
                                    this.GetComponent<VehicleDamage>().Health = ((float) this.GetComponent<VehicleDamage>().Health) - (this.VesselHealth * 0.15f);
                                }
                                this.GetComponent<VehicleDamage>().DamageIn(0, 0, 0, false);
                            }
                        }
                    }
                }
                if (this.Sound1.Length > 0)
                {
                    if (this.CanSound && !this.IgnoreSmallC)
                    {
                        if (this.Gs > this.Sound1MinForce)
                        {
                            this.CanSound = false;
                            this.GetComponent<AudioSource>().PlayOneShot(this.Sound1[Random.Range(0, this.Sound1.Length)], 1);
                            if (this.OnlySoundOnce)
                            {
                                this.Broken = true;
                                return;
                            }
                        }
                    }
                }
                if (this.SoundT.Length > 0)
                {
                    if (this.CanTSound)
                    {
                        if (this.TGs > 100)
                        {
                            this.CanTSound = false;
                            this.GetComponent<AudioSource>().PlayOneShot(this.SoundT[Random.Range(0, this.SoundT.Length)], 1);
                            if (this.OnlySoundOnce)
                            {
                                this.Broken = true;
                                return;
                            }
                        }
                    }
                }
            }
            if (this.MotionSoundGround)
            {
                this.MotionSoundGround.GetComponent<AudioSource>().volume = this.MotionSoundGround.GetComponent<AudioSource>().volume - 0.005f;
            }
        }
    }

    public virtual void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ghosts")
        {
            return;
        }
        if (collision.rigidbody)
        {
            if (collision.rigidbody.velocity.magnitude > this.rV)
            {
                this.CanStrike = false;
            }
        }
        if (this.CanStrike)
        {
            if (collision.relativeVelocity.magnitude > 19)
            {
                this.Reps = this.Reps + 1;
            }
        }
        if (this.CanStrike)
        {
            if (!this.OnlySoundOnce)
            {
                if ((((this.TGs > 200) || (this.Gs > 400)) || (collision.relativeVelocity.magnitude > 20)) || (this.rAV > 10))
                {
                    if (collision.contacts.Length > 0)
                    {
                        ContactPoint contact = collision.contacts[0];
                        if ((collision.gameObject.tag == "SoftTerrain") || (collision.gameObject.tag == "Terrain"))
                        {
                            if (!this.Complementary)
                            {
                                if (this.Reps < 2)
                                {
                                    UnityEngine.Object.Instantiate(this.StrikePrefabGround, contact.point, this.transform.rotation);
                                }
                                if ((this.Reps > 1) && !this.SkidVehicle)
                                {
                                    GameObject Thing1 = UnityEngine.Object.Instantiate(this.StrikePrefabGroundCont, contact.point, this.transform.rotation);
                                    Thing1.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                                }
                            }
                            else
                            {
                                if (this.MainCS.Reps < 2)
                                {
                                    UnityEngine.Object.Instantiate(this.StrikePrefabGround, contact.point, this.transform.rotation);
                                }
                                if (this.MainCS.Reps > 1)
                                {
                                    GameObject Thing2 = UnityEngine.Object.Instantiate(this.StrikePrefabGroundCont, contact.point, this.transform.rotation);
                                    Thing2.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                                }
                            }
                            this.CanStrike = false;
                            this.Reps = 4;
                            if (this.Complementary)
                            {
                                this.MainCS.Reps = 4;
                            }
                        }
                        if (((collision.gameObject.tag == "Structure") || (collision.gameObject.tag == "Mineral")) || (collision.gameObject.tag == "Untagged"))
                        {
                            if (!this.Complementary)
                            {
                                if (this.Reps < 2)
                                {
                                    UnityEngine.Object.Instantiate(this.StrikePrefabStructure, contact.point, this.transform.rotation);
                                }
                                if (this.Reps > 1)
                                {
                                    GameObject Thing3 = UnityEngine.Object.Instantiate(this.StrikePrefabStructureCont, contact.point, this.transform.rotation);
                                    Thing3.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                                }
                            }
                            else
                            {
                                if (this.MainCS.Reps < 2)
                                {
                                    UnityEngine.Object.Instantiate(this.StrikePrefabStructure, contact.point, this.transform.rotation);
                                }
                                if (this.MainCS.Reps > 1)
                                {
                                    GameObject Thing4 = UnityEngine.Object.Instantiate(this.StrikePrefabStructureCont, contact.point, this.transform.rotation);
                                    Thing4.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                                }
                            }
                            this.CanStrike = false;
                            this.Reps = 4;
                            if (this.Complementary)
                            {
                                this.MainCS.Reps = 4;
                            }
                        }
                        if ((((collision.gameObject.tag == "Vehicle") || (collision.gameObject.tag == "Metal")) || (collision.gameObject.tag == "MetalStructure")) || (collision.gameObject.tag == "ElementMaterials"))
                        {
                            if (!this.Complementary)
                            {
                                if (this.Reps < 2)
                                {
                                    UnityEngine.Object.Instantiate(this.StrikePrefabMetal, contact.point, this.forwardTF.rotation);
                                }
                                if (this.Reps > 1)
                                {
                                    GameObject Thing5 = UnityEngine.Object.Instantiate(this.StrikePrefabMetalCont, contact.point, this.forwardTF.rotation);
                                    Thing5.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                                }
                            }
                            else
                            {
                                if (this.MainCS.Reps < 2)
                                {
                                    UnityEngine.Object.Instantiate(this.StrikePrefabMetal, contact.point, this.forwardTF.rotation);
                                }
                                if (this.MainCS.Reps > 1)
                                {
                                    GameObject Thing6 = UnityEngine.Object.Instantiate(this.StrikePrefabMetalCont, contact.point, this.forwardTF.rotation);
                                    Thing6.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                                }
                            }
                            this.CanStrike = false;
                            this.Reps = 4;
                            if (this.Complementary)
                            {
                                this.MainCS.Reps = 4;
                            }
                        }
                    }
                }
            }
            else
            {
                if (!this.BrokenC)
                {
                    if ((((this.TGs > 200) || (this.Gs > 100)) || (collision.relativeVelocity.magnitude > 20)) || (this.rAV > 10))
                    {
                        if (collision.contacts.Length > 0)
                        {
                            ContactPoint contact2 = collision.contacts[0];
                            Quaternion NormalAngle = Quaternion.LookRotation(contact2.normal);
                            if ((collision.gameObject.tag == "SoftTerrain") || (collision.gameObject.tag == "Terrain"))
                            {
                                if (!this.Complementary)
                                {
                                    if (this.Reps < 2)
                                    {
                                        UnityEngine.Object.Instantiate(this.StrikePrefabGround, contact2.point, NormalAngle);
                                    }
                                    if ((this.Reps > 1) && !this.SkidVehicle)
                                    {
                                        GameObject Thing1S = UnityEngine.Object.Instantiate(this.StrikePrefabGroundCont, contact2.point, this.transform.rotation);
                                        Thing1S.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                                    }
                                }
                                else
                                {
                                    if (this.MainCS.Reps < 2)
                                    {
                                        UnityEngine.Object.Instantiate(this.StrikePrefabGround, contact2.point, NormalAngle);
                                    }
                                    if (this.MainCS.Reps > 1)
                                    {
                                        GameObject Thing2S = UnityEngine.Object.Instantiate(this.StrikePrefabGroundCont, contact2.point, this.transform.rotation);
                                        Thing2S.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                                    }
                                }
                                this.CanStrike = false;
                                this.Reps = 4;
                                if (this.Complementary)
                                {
                                    this.MainCS.Reps = 4;
                                }
                            }
                            if (((collision.gameObject.tag == "Structure") || (collision.gameObject.tag == "Mineral")) || (collision.gameObject.tag == "Untagged"))
                            {
                                if (!this.Complementary)
                                {
                                    if (this.Reps < 2)
                                    {
                                        UnityEngine.Object.Instantiate(this.StrikePrefabStructure, contact2.point, NormalAngle);
                                    }
                                    if (this.Reps > 1)
                                    {
                                        GameObject Thing3S = UnityEngine.Object.Instantiate(this.StrikePrefabStructureCont, contact2.point, this.transform.rotation);
                                        Thing3S.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                                    }
                                }
                                else
                                {
                                    if (this.MainCS.Reps < 2)
                                    {
                                        UnityEngine.Object.Instantiate(this.StrikePrefabStructure, contact2.point, NormalAngle);
                                    }
                                    if (this.MainCS.Reps > 1)
                                    {
                                        GameObject Thing4S = UnityEngine.Object.Instantiate(this.StrikePrefabStructureCont, contact2.point, this.transform.rotation);
                                        Thing4S.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                                    }
                                }
                                this.CanStrike = false;
                                this.Reps = 4;
                                if (this.Complementary)
                                {
                                    this.MainCS.Reps = 4;
                                }
                            }
                            if ((((collision.gameObject.tag == "Vehicle") || (collision.gameObject.tag == "Metal")) || (collision.gameObject.tag == "MetalStructure")) || (collision.gameObject.tag == "ElementMaterials"))
                            {
                                if (!this.Complementary)
                                {
                                    if (this.Reps < 2)
                                    {
                                        UnityEngine.Object.Instantiate(this.StrikePrefabMetal, contact2.point, NormalAngle);
                                    }
                                    if (this.Reps > 1)
                                    {
                                        GameObject Thing5S = UnityEngine.Object.Instantiate(this.StrikePrefabMetalCont, contact2.point, this.forwardTF.rotation);
                                        Thing5S.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                                    }
                                }
                                else
                                {
                                    if (this.MainCS.Reps < 2)
                                    {
                                        UnityEngine.Object.Instantiate(this.StrikePrefabMetal, contact2.point, NormalAngle);
                                    }
                                    if (this.MainCS.Reps > 1)
                                    {
                                        GameObject Thing6S = UnityEngine.Object.Instantiate(this.StrikePrefabMetalCont, contact2.point, this.forwardTF.rotation);
                                        Thing6S.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                                    }
                                }
                                this.CanStrike = false;
                                this.Reps = 4;
                                if (this.Complementary)
                                {
                                    this.MainCS.Reps = 4;
                                }
                            }
                            this.BrokenC = true;
                        }
                    }
                }
            }
        }
        if (this.MotionSoundGround)
        {
            if (((((((collision.gameObject.tag == "SoftTerrain") || (collision.gameObject.tag == "Terrain")) || (collision.gameObject.tag == "Structure")) || (collision.gameObject.tag == "MetalStructure")) || (collision.gameObject.tag == "Metal")) || (collision.gameObject.tag == "ElementMaterials")) || (collision.gameObject.tag == "Vehicle"))
            {
                if (this.MotionSoundGround.GetComponent<AudioSource>().volume < (collision.relativeVelocity.magnitude * 0.015f))
                {
                    this.MotionSoundGround.GetComponent<AudioSource>().volume = collision.relativeVelocity.magnitude * 0.015f;
                }
            }
            if (this.MotionSoundGround.GetComponent<AudioSource>().volume > this.MSGMaxVolume)
            {
                this.MotionSoundGround.GetComponent<AudioSource>().volume = this.MSGMaxVolume;
            }
        }
    }

    public virtual void Tick()
    {
        this.CanSound = true;
        this.CanTSound = true;
    }

    public virtual void Tick2()
    {
        if (this.HasSpinVac)
        {
            if (this.rAV > 32)
            {
                this.name = "TFC1#2";
                this.VacArea.gameObject.SetActive(true);
            }
            else
            {
                this.VacArea.gameObject.SetActive(false);
                if (this.rAV > 16)
                {
                    this.name = "TFC1#1";
                }
                else
                {
                    this.name = "Hull";
                }
            }
        }
        this.CanStrike = true;
        if (this.Reps > 1)
        {
            this.Reps = this.Reps - 1;
        }
    }

    public CollisionSound()
    {
        this.Sound1MinForce = 200;
        this.MSGMaxVolume = 0.5f;
        this.VesselHealth = 10;
    }

}