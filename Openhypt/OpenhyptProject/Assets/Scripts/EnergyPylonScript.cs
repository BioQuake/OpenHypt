using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class EnergyPylonScript : MonoBehaviour
{
    public GameObject DischargePrefab;
    public GameObject DronePrefab;
    public GameObject IssuedDrone1;
    public GameObject IssuedDrone2;
    public Transform DroneArea;
    public AudioSource DroneAreaAudio;
    public GameObject HumArea;
    public Transform DischargeArea;
    public GameObject StartArea;
    public Transform target;
    public bool AimTowards;
    public bool Turning;
    public Rigidbody AdapterRB;
    public static Transform EnergyBallArea;
    public ParticleSystem AuraEffect;
    public AudioClip Hum1;
    public AudioClip Hum2;
    public bool Dist;
    public bool BuoyPatrol;
    public bool Discharging;
    public int DischargeTime;
    public float Lengthrandomizer;
    public float lastTime;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC3;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public virtual void Start()
    {
        this.InvokeRepeating("Respawn", 4, 0.83f);
        this.InvokeRepeating("Counter", 4, 1);
        this.DischargeTime = 0;
        EnergyPylonScript.EnergyBallArea = this.DischargeArea;
        this.Lengthrandomizer = Random.Range(10, 30);
        if (this.BuoyPatrol)
        {
            this.StartArea = new GameObject();
            this.StartArea.transform.position = this.transform.position;
            this.StartArea.transform.rotation = this.transform.rotation;
        }
    }

    public virtual void Update()
    {
        if (!this.Dist)
        {
            if ((Time.time - this.lastTime) > this.Lengthrandomizer)
            {
                this.Lengthrandomizer = Random.Range(30, 60);
                int randomValue = Random.Range(1, 3);
                switch (randomValue)
                {
                    case 1:
                        this.HumArea.GetComponent<AudioSource>().PlayOneShot(this.Hum1);
                        break;
                    case 2:
                        this.HumArea.GetComponent<AudioSource>().PlayOneShot(this.Hum2);
                        break;
                }
                this.lastTime = Time.time;
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (!this.Dist)
        {
            if (this.Discharging)
            {
                if (this.AuraEffect.startSize > 8)
                {
                    this.AuraEffect.startSize = this.AuraEffect.startSize - 0.5f;
                }
                if (this.AuraEffect.startSize < 8.1f)
                {
                    this.Discharging = false;
                }
            }
            if (!this.Discharging)
            {
                if (this.AuraEffect.startSize < 27)
                {
                    this.AuraEffect.startSize = this.AuraEffect.startSize + 0.02f;
                }
            }
            if (this.BuoyPatrol)
            {
                if (this.AimTowards)
                {
                    this.AdapterRB.AddForceAtPosition((this.target.transform.position - this.transform.position).normalized * 20000, -this.transform.up * 16);
                    this.AdapterRB.AddForceAtPosition((this.target.transform.position - this.transform.position).normalized * -20000, this.transform.up * 16);
                }
                else
                {
                    this.AdapterRB.AddForceAtPosition((this.target.transform.position - this.transform.position).normalized * 20000, this.transform.up * 16);
                    this.AdapterRB.AddForceAtPosition((this.target.transform.position - this.transform.position).normalized * -20000, -this.transform.up * 16);
                }
                if (this.Turning)
                {
                    this.GetComponent<Rigidbody>().AddTorque(-this.transform.forward * 200000);
                }
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name.Contains("TFC0a"))
        {
            this.PissedAtTC0a = 10;
        }
        if (other.GetComponent<Collider>().name.Contains("TFC1"))
        {
            this.PissedAtTC1 = 10;
        }
        if (other.GetComponent<Collider>().name.Contains("TFC3"))
        {
            this.PissedAtTC3 = 10;
        }
        if (other.GetComponent<Collider>().name.Contains("TFC5"))
        {
            this.PissedAtTC5 = 10;
        }
        if (other.GetComponent<Collider>().name.Contains("TFC6"))
        {
            this.PissedAtTC6 = 10;
        }
        if (other.GetComponent<Collider>().name.Contains("TFC7"))
        {
            this.PissedAtTC7 = 10;
        }
        if (other.GetComponent<Collider>().name.Contains("TFC"))
        {
            if (!other.GetComponent<Collider>().name.Contains("TFC2"))
            {
                this.StartCoroutine(this.SpawnDrone());
            }
        }
    }

    public virtual IEnumerator SpawnDrone()
    {
        yield return new WaitForSeconds(0.2f);
        if ((this.IssuedDrone2 == null) && this.DronePrefab)
        {
            this.IssuedDrone2 = UnityEngine.Object.Instantiate(this.DronePrefab, this.DroneArea.position, this.DroneArea.rotation);
            this.IssuedDrone2.GetComponent<Rigidbody>().velocity = this.DroneArea.transform.up * -40;
            this.DroneAreaAudio.Play();
            if (this.PissedAtTC0a > 0)
            {
                ((AgrianMiniBotAI) this.IssuedDrone2.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC0a = 8;
            }
            if (this.PissedAtTC1 > 0)
            {
                ((AgrianMiniBotAI) this.IssuedDrone2.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC1 = 8;
            }
            if (this.PissedAtTC3 > 0)
            {
                ((AgrianMiniBotAI) this.IssuedDrone2.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC3 = 8;
            }
            if (this.PissedAtTC5 > 0)
            {
                ((AgrianMiniBotAI) this.IssuedDrone2.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC5 = 8;
            }
            if (this.PissedAtTC6 > 0)
            {
                ((AgrianMiniBotAI) this.IssuedDrone2.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC6 = 8;
            }
            if (this.PissedAtTC7 > 0)
            {
                ((AgrianMiniBotAI) this.IssuedDrone2.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC7 = 8;
            }
        }
    }

    public virtual void Respawn()
    {
        if ((this.IssuedDrone1 == null) && this.DronePrefab)
        {
            this.IssuedDrone1 = UnityEngine.Object.Instantiate(this.DronePrefab, this.DroneArea.position, this.DroneArea.rotation);
            this.IssuedDrone1.GetComponent<Rigidbody>().velocity = this.DroneArea.transform.up * -40;
            this.DroneAreaAudio.Play();
            if (this.PissedAtTC0a > 0)
            {
                ((AgrianMiniBotAI) this.IssuedDrone1.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC0a = 8;
            }
            if (this.PissedAtTC1 > 0)
            {
                ((AgrianMiniBotAI) this.IssuedDrone1.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC1 = 8;
            }
            if (this.PissedAtTC3 > 0)
            {
                ((AgrianMiniBotAI) this.IssuedDrone1.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC3 = 8;
            }
            if (this.PissedAtTC5 > 0)
            {
                ((AgrianMiniBotAI) this.IssuedDrone1.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC5 = 8;
            }
            if (this.PissedAtTC6 > 0)
            {
                ((AgrianMiniBotAI) this.IssuedDrone1.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC6 = 8;
            }
            if (this.PissedAtTC7 > 0)
            {
                ((AgrianMiniBotAI) this.IssuedDrone1.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC7 = 8;
            }
        }
        if (this.BuoyPatrol)
        {
            if ((Vector3.Distance(this.transform.position, this.StartArea.transform.position) > 2000) && !this.AimTowards)
            {
                this.AimTowards = true;
                this.Turning = true;
                this.StartCoroutine(this.Align());
            }
            if ((Vector3.Distance(this.transform.position, this.StartArea.transform.position) < 20) && this.AimTowards)
            {
                this.AimTowards = false;
                this.Turning = true;
                this.StartCoroutine(this.Align());
            }
        }
        if (this.PissedAtTC0a > 0)
        {
            this.PissedAtTC0a = this.PissedAtTC0a - 1;
        }
        if (this.PissedAtTC1 > 0)
        {
            this.PissedAtTC1 = this.PissedAtTC1 - 1;
        }
        if (this.PissedAtTC3 > 0)
        {
            this.PissedAtTC3 = this.PissedAtTC3 - 1;
        }
        if (this.PissedAtTC5 > 0)
        {
            this.PissedAtTC5 = this.PissedAtTC5 - 1;
        }
        if (this.PissedAtTC6 > 0)
        {
            this.PissedAtTC6 = this.PissedAtTC6 - 1;
        }
        if (this.PissedAtTC7 > 0)
        {
            this.PissedAtTC7 = this.PissedAtTC7 - 1;
        }
    }

    public virtual IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.2f);
        GameObject TheThing = UnityEngine.Object.Instantiate(this.DischargePrefab, this.DischargeArea.position, this.DischargeArea.rotation);
        TheThing.transform.parent = this.gameObject.transform;
    }

    public virtual IEnumerator Align()
    {
        yield return new WaitForSeconds(2);
        this.Turning = false;
    }

    public virtual void Discharge()
    {
        this.Discharging = true;
        this.StartCoroutine(this.Spawn());
    }

    public virtual void Counter()
    {
        if (this.DischargeTime < 100)
        {
            int randomValueT = Random.Range(1, 3);
            switch (randomValueT)
            {
                case 1:
                    this.DischargeTime = this.DischargeTime + 1;
                    break;
                case 2:
                    this.DischargeTime = this.DischargeTime + 2;
                    break;
            }
        }
        else
        {
            this.DischargeTime = 0;
            this.Discharge();
        }
    }

    public EnergyPylonScript()
    {
        this.Lengthrandomizer = 10;
    }

}