using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ReactiveObject : MonoBehaviour
{
    public int Health;
    public bool Missile;
    public bool Radio;
    public bool CanDropItem;
    public GameObject Item;
    public GameObject Item2;
    public Transform ItemSpawnTF;
    public bool unsetOther;
    public ReactiveObject otherScript;
    public bool DropChance;
    public bool RandomDrop;
    public bool skipForce;
    public GameObject Reaction;
    public GameObject MissilePrefab;
    public bool Entered;
    public bool IsOn;
    public float lastVelocity;
    public float lastTVelocity;
    public float Gs;
    public float TGs;
    public float Threshold;
    public bool C;
    public virtual IEnumerator Start()
    {
        this.C = true;
        this.Threshold = 300 / Mathf.Pow(this.GetComponent<Rigidbody>().mass, 0.33f);
        yield return new WaitForSeconds(0.2f);
        this.C = false;
    }

    public virtual void Update()
    {
        if (this.Entered)
        {
            if (Input.GetKeyDown("e") && this.Missile)
            {
                GameObject _SpawnedObject = UnityEngine.Object.Instantiate(this.MissilePrefab, this.transform.position, this.transform.rotation);
                //_SpawnedObject.transform.GetComponent<MissileScript>().MeshEnableTime = 0;
                this.gameObject.GetComponent<NotifyDoorScript>().target.gameObject.SetActive(false);
                UnityEngine.Object.Destroy(this.gameObject);
            }
            if (Input.GetKeyDown("e") && this.Radio)
            {
                if (!this.IsOn)
                {
                    this.GetComponent<AudioSource>().Play();
                    this.IsOn = true;
                }
                else
                {
                    this.GetComponent<AudioSource>().Stop();
                    this.IsOn = false;
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.skipForce)
        {
            return;
        }
        float acceleration = (this.GetComponent<Rigidbody>().velocity.magnitude - this.lastVelocity) / Time.deltaTime;
        this.lastVelocity = this.GetComponent<Rigidbody>().velocity.magnitude;
        this.Gs = Mathf.Abs(acceleration);
        float Tacceleration = (this.GetComponent<Rigidbody>().angularVelocity.magnitude - this.lastTVelocity) / Time.deltaTime;
        this.lastTVelocity = this.GetComponent<Rigidbody>().angularVelocity.magnitude;
        this.TGs = Mathf.Abs(Tacceleration);
        if ((this.TGs > this.Threshold) && !this.C)
        {
            this.C = true;
            this.Break();
        }
        if ((this.Gs > this.Threshold) && !this.C)
        {
            this.C = true;
            this.Break();
        }
    }

    public virtual void DamageIn(float Damage, int DamageCode)
    {
        this.Health = (int) (this.Health - Damage);
        if (this.Health < 1)
        {
            if (this.C)
            {
                return;
            }
            this.C = true;
            this.Break();
        }
    }

    public virtual void Break()
    {
        if (this.unsetOther)
        {
            this.otherScript.CanDropItem = false;
        }
        if (this.CanDropItem)
        {
            if (!this.ItemSpawnTF)
            {
                UnityEngine.Object.Instantiate(this.Item, this.transform.position, this.transform.rotation);
            }
            else
            {
                if (!this.DropChance)
                {
                    UnityEngine.Object.Instantiate(this.Item, this.ItemSpawnTF.position, this.ItemSpawnTF.rotation);
                }
                else
                {
                    if (this.RandomDrop)
                    {
                        int R1 = Random.Range(0, 3);
                        switch (R1)
                        {
                            case 1:
                                UnityEngine.Object.Instantiate(this.Item, this.ItemSpawnTF.position, this.ItemSpawnTF.rotation);
                                break;
                            case 2:
                                UnityEngine.Object.Instantiate(this.Item2, this.ItemSpawnTF.position, this.ItemSpawnTF.rotation);
                                break;
                        }
                    }
                    else
                    {
                        int R2 = Random.Range(0, 2);
                        switch (R2)
                        {
                            case 1:
                                UnityEngine.Object.Instantiate(this.Item, this.ItemSpawnTF.position, this.ItemSpawnTF.rotation);
                                break;
                        }
                    }
                }
            }
        }
        this.Entered = false;
        UnityEngine.Object.Instantiate(this.Reaction, this.transform.position, this.transform.rotation);
        UnityEngine.Object.Destroy(this.gameObject);
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.name == "Pirizuka")
        {
            this.Entered = true;
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.name == "Pirizuka")
        {
            this.Entered = false;
        }
    }

    public ReactiveObject()
    {
        this.Health = 2;
    }

}