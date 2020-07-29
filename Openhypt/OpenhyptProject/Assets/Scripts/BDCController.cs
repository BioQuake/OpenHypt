using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BDCController : MonoBehaviour
{
    public Transform VesselSpawn;
    public GameObject Model;
    public GameObject Floor;
    public GameObject Shield;
    public bool Contact;
    public bool GroundContact;
    public bool TempPause;
    public bool OpenShield;
    public bool CloseShield;
    public AudioClip ShieldOpenSound;
    public AudioClip ShieldCloseSound;
    public bool ShieldFree;
    public bool ShieldPush;
    public bool ShieldReturn;
    public bool AimUp;
    public bool Away;
    public Transform ShieldPos;
    public Transform ShieldAim;
    public GameObject AccelSound;
    public GameObject DecelSound;
    public bool DecelOnce;
    public bool AccelOnce;
    public string StringIn;
    public float Force;
    public LayerMask targetLayers;
    private string state;
    public virtual void FixedUpdate()
    {
        Vector3 localV = this.transform.InverseTransformDirection(this.GetComponent<Rigidbody>().velocity);
        if ((-localV.z > 120) && !this.AccelOnce)
        {
            this.DecelOnce = false;
            this.AccelOnce = true;
            GameObject TheThing1 = UnityEngine.Object.Instantiate(this.AccelSound, this.transform.position, this.transform.rotation);
            TheThing1.transform.parent = this.gameObject.transform;
        }
        if ((-localV.z < 120) && !this.DecelOnce)
        {
            this.AccelOnce = false;
            this.DecelOnce = true;
            GameObject TheThing2 = UnityEngine.Object.Instantiate(this.DecelSound, this.transform.position, this.transform.rotation);
            TheThing2.transform.parent = this.gameObject.transform;
        }
        if (Physics.Raycast(this.transform.position, -this.transform.forward, 1000, (int) this.targetLayers) && !this.Contact)
        {
            this.Contact = true;
            this.GetComponent<AudioSource>().Play();
        }
        if (Physics.Raycast(this.transform.position, -this.transform.forward, 12, (int) this.targetLayers) && !this.GroundContact)
        {
            this.GroundContact = true;
            this.Floor.gameObject.GetComponent<AudioSource>().Play();
            this.Floor.transform.parent = null;
            this.StartCoroutine(this.Spawn());
        }
        if (Physics.Raycast(this.transform.position, -this.transform.forward, 45, (int) this.targetLayers) && !this.OpenShield)
        {
            this.TempPause = true;
            this.OpenShield = true;
            this.Shield.GetComponent<Animation>()["BDCShieldScrew"].speed = 1;
            this.Shield.GetComponent<Animation>().Play("BDCShieldScrew");
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.Shield.GetComponent<AudioSource>().PlayOneShot(this.ShieldOpenSound);
            this.StartCoroutine(this.Counter());
        }
        if (((Vector3.Distance(this.ShieldPos.position, this.Shield.transform.position) < 0.005f) && !this.TempPause) && !this.CloseShield)
        {
            this.ShieldFree = false;
            this.CloseShield = true;
            this.Shield.GetComponent<Rigidbody>().isKinematic = true;
            this.Shield.transform.parent = this.gameObject.transform;
            this.Shield.GetComponent<Rigidbody>().drag = 0.1f;
            this.Shield.GetComponent<Animation>()["BDCShieldScrew"].speed = -1;
            this.Shield.GetComponent<Animation>()["BDCShieldScrew"].time = this.Shield.GetComponent<Animation>()["BDCShieldScrew"].length;
            this.Shield.GetComponent<Animation>().Play("BDCShieldScrew");
            this.Shield.GetComponent<AudioSource>().PlayOneShot(this.ShieldCloseSound);
            this.StartCoroutine(this.Counter2());
        }
        if (this.ShieldFree)
        {
            if (this.ShieldPush)
            {
                this.Shield.GetComponent<Rigidbody>().AddForce(this.Shield.transform.right * 1000);
                this.Shield.GetComponent<Rigidbody>().AddForce(this.Shield.transform.forward * -50);
                this.Shield.GetComponent<Rigidbody>().AddTorque(this.Shield.transform.up * -500);
            }
            if (this.ShieldReturn)
            {
                this.Shield.GetComponent<Rigidbody>().AddForce((this.ShieldPos.position - this.Shield.transform.position).normalized * 200);
                if (Vector3.Distance(this.ShieldPos.position, this.Shield.transform.position) < 20)
                {
                    this.Shield.GetComponent<Rigidbody>().AddForceAtPosition((this.ShieldAim.position - this.Shield.transform.position).normalized * 2000, this.Shield.transform.forward * 8);
                    this.Shield.GetComponent<Rigidbody>().AddForceAtPosition((this.ShieldAim.position - this.Shield.transform.position).normalized * -2000, -this.Shield.transform.forward * 8);
                }
            }
        }
        if (this.AimUp)
        {
            this.GetComponent<Rigidbody>().AddTorque(this.transform.up * 50000);
            this.GetComponent<Rigidbody>().AddForceAtPosition((this.Floor.transform.position - this.transform.position).normalized * -8000, -this.transform.forward * 20);
            this.GetComponent<Rigidbody>().AddForceAtPosition((this.Floor.transform.position - this.transform.position).normalized * 8000, this.transform.forward * 20);
            if (this.Away)
            {
                if (-localV.z < 2000)
                {
                    this.GetComponent<Rigidbody>().AddForce(this.transform.forward * -340000);
                }
            }
            if (this.transform.position.y > 35000)
            {
                UnityEngine.Object.Destroy(this.gameObject);
            }
        }
        else
        {
            if (!this.Contact && !this.GroundContact)
            {
                if (-localV.z < 2000)
                {
                    this.GetComponent<Rigidbody>().AddForce(this.transform.forward * -340000);
                }
            }
            if (this.Contact && !this.GroundContact)
            {
                if (-localV.z > 20)
                {
                    this.GetComponent<Rigidbody>().AddForce(this.transform.forward * 580000);
                }
            }
            if (-localV.z > 5)
            {
                this.GetComponent<Rigidbody>().AddForce(this.transform.forward * 10000);
            }
            if (this.GroundContact)
            {
                if (Physics.Raycast(this.transform.position, -this.transform.forward, 40, (int) this.targetLayers) && this.GroundContact)
                {
                    if (localV.z < 8)
                    {
                        this.GetComponent<Rigidbody>().AddForce(this.transform.forward * 5000);
                    }
                }
            }
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * -2500);
        }
    }

    public virtual IEnumerator Counter()
    {
        this.TempPause = true;
        yield return new WaitForSeconds(2);
        this.Shield.GetComponent<Rigidbody>().isKinematic = false;
        this.Shield.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity * 1;
        this.ShieldFree = true;
        this.ShieldPush = true;
        yield return new WaitForSeconds(1);
        this.Shield.transform.parent = null;
        this.Shield.GetComponent<Rigidbody>().drag = 2;
        this.Shield.GetComponent<Rigidbody>().angularDrag = 10;
        this.TempPause = false;
        this.ShieldPush = false;
    }

    public virtual IEnumerator Counter2()
    {
        yield return new WaitForSeconds(2);
        this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * -1000000);
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody>().drag = 0.08f;
        this.GetComponent<Rigidbody>().angularDrag = 6;
        this.AimUp = true;
        yield return new WaitForSeconds(3);
        this.Away = true;
    }

    public virtual IEnumerator Spawn()
    {
        //Muggyonaise--------------------------------------------------------------------------------------------------
        GameObject Prefabionaise = ((GameObject) Resources.Load("VesselPrefabs/" + VesselList.instance.StringOut(), typeof(GameObject))) as GameObject;
        GameObject SpawnedV1 = UnityEngine.Object.Instantiate(Prefabionaise,
            ((this.VesselSpawn.transform.position)
            + ((this.VesselSpawn.transform.up) * Prefabionaise.GetComponent<VehicleSensor>().MidToGroundDist))
            + ((this.VesselSpawn.transform.forward) * Prefabionaise.GetComponent<VehicleSensor>().TailEndDist),
            this.VesselSpawn.transform.rotation);

        {
            string _465 = "DroppedVessel";
            VehicleSensor _466 = SpawnedV1.GetComponent<VehicleSensor>();
            GameObject _467 = _466.Vessel;
            _467.name = _465;
        }
        ((VehicleSensor) SpawnedV1.GetComponent(typeof(VehicleSensor))).Repositioned = true;
        //Muggyonaise--------------------------------------------------------------------------------------------------
        this.Floor.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(0.6f);
        this.GetComponent<Rigidbody>().drag = 4;
        UnityEngine.Object.Destroy((FixedJoint) this.Floor.GetComponent(typeof(FixedJoint)));
        this.Floor.GetComponent<Rigidbody>().velocity = -this.Floor.transform.up * 2;
        yield return new WaitForSeconds(5);
        this.ShieldReturn = true;
    }

    public BDCController()
    {
        this.StringIn = "Vessel1";
        this.Force = 10;
    }

}