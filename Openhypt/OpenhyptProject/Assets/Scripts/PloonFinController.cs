using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PloonFinController : MonoBehaviour
{
    public GameObject Fin1;
    public GameObject Fin2;
    public GameObject FinR1;
    public GameObject FinR2;
    public bool isBigPloon;
    public GameObject BurnEffect;
    public GameObject Clicker;
    public GameObject Armature;
    public GameObject ArmaMesh;
    public Transform WeightTF;
    public Rigidbody WeightRB;
    public float Strength;
    public float MinHeight;
    public float MaxHeight;
    public float FlapStrength;
    public float RearFlapStrength;
    public float lastVelocity;
    public float lastTVelocity;
    public float Gs;
    public float TGs;
    public bool Burning;
    public bool Tick;
    public bool FlapUp;
    public bool FlapDown;
    public bool Distress;
    public virtual void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("TFC"))
        {
            this.GetComponent<Rigidbody>().angularDrag = 1;
            this.GetComponent<Rigidbody>().drag = 5;
            this.StartCoroutine(this.Burn());
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.Burning && (this.Armature != null))
        {
            if (this.Armature.transform.localScale.x < 0.03f)
            {
                UnityEngine.Object.Destroy(this.Armature);
                UnityEngine.Object.Destroy(this.ArmaMesh);
            }
            if (this.Armature.transform.localScale.x > 0.02f)
            {
                this.Armature.transform.localScale = this.Armature.transform.localScale - new Vector3(0.01f, 0.01f, 0.01f);
            }
        }
        if (this.Burning)
        {
            return;
        }
        float acceleration = (this.GetComponent<Rigidbody>().velocity.magnitude - this.lastVelocity) / Time.deltaTime;
        this.lastVelocity = this.GetComponent<Rigidbody>().velocity.magnitude;
        this.Gs = Mathf.Abs(acceleration);
        float Tacceleration = (this.GetComponent<Rigidbody>().angularVelocity.magnitude - this.lastTVelocity) / Time.deltaTime;
        this.lastTVelocity = this.GetComponent<Rigidbody>().angularVelocity.magnitude;
        this.TGs = Mathf.Abs(Tacceleration);
        if (this.TGs > 400)
        {
            this.StartCoroutine(this.Burn());
        }
        if ((this.Gs > 1000) && (this.TGs < 400))
        {
            this.StartCoroutine(this.Burn());
        }
        if (Physics.Raycast(this.transform.position + new Vector3(0, 0, 0), this.transform.forward, 8))
        {
            this.Distress = true;
        }
        else
        {
            this.Distress = false;
        }
        if (this.Tick == false)
        {
            if (this.isBigPloon)
            {
                this.StartCoroutine(this.FlapBig());
            }
            else
            {
                this.StartCoroutine(this.Flap());
            }
        }
        if (!this.Distress)
        {
            if (this.FlapDown)
            {
                this.Fin1.GetComponent<Rigidbody>().AddTorque(this.Fin1.transform.right * this.FlapStrength);
                this.Fin2.GetComponent<Rigidbody>().AddTorque(this.Fin2.transform.right * this.FlapStrength);
                if (this.isBigPloon)
                {
                    this.FinR1.GetComponent<Rigidbody>().AddTorque(this.FinR1.transform.right * -this.RearFlapStrength);
                    this.FinR2.GetComponent<Rigidbody>().AddTorque(this.FinR2.transform.right * -this.RearFlapStrength);
                }
            }
            if (this.FlapUp)
            {
                this.Fin1.GetComponent<Rigidbody>().AddTorque(this.Fin1.transform.right * -this.FlapStrength);
                this.Fin2.GetComponent<Rigidbody>().AddTorque(this.Fin2.transform.right * -this.FlapStrength);
                if (this.isBigPloon)
                {
                    this.FinR1.GetComponent<Rigidbody>().AddTorque(this.FinR1.transform.right * this.RearFlapStrength);
                    this.FinR2.GetComponent<Rigidbody>().AddTorque(this.FinR2.transform.right * this.RearFlapStrength);
                }
            }
        }
        else
        {
            if (this.FlapDown)
            {
                this.Fin1.GetComponent<Rigidbody>().AddTorque(this.Fin1.transform.right * 0.003f);
                this.Fin2.GetComponent<Rigidbody>().AddTorque(this.Fin2.transform.right * 0.003f);
                if (this.isBigPloon)
                {
                    this.FinR1.GetComponent<Rigidbody>().AddTorque(this.FinR1.transform.right * 0.003f);
                    this.FinR2.GetComponent<Rigidbody>().AddTorque(this.FinR2.transform.right * 0.003f);
                }
            }
            if (this.FlapUp)
            {
                this.Fin1.GetComponent<Rigidbody>().AddTorque(this.Fin1.transform.right * -0.003f);
                this.Fin2.GetComponent<Rigidbody>().AddTorque(this.Fin2.transform.right * 0.003f);
                if (this.isBigPloon)
                {
                    this.FinR1.GetComponent<Rigidbody>().AddTorque(this.FinR1.transform.right * -0.003f);
                    this.FinR2.GetComponent<Rigidbody>().AddTorque(this.FinR2.transform.right * 0.003f);
                }
            }
        }
        if (Physics.Raycast(this.WeightTF.position, this.WeightTF.up, this.MaxHeight))
        {
            this.WeightRB.AddForce(this.WeightTF.up * 0);
        }
        else
        {
            this.WeightRB.AddForce(this.WeightTF.up * this.Strength);
        }
        if (Physics.Raycast(this.WeightTF.position, this.WeightTF.up, this.MinHeight))
        {
            this.WeightRB.AddForce(this.WeightTF.up * -this.Strength);
        }
    }

    public virtual IEnumerator Burn()
    {
        if (!this.Burning)
        {
            this.Burning = true;
            GameObject TheThing = UnityEngine.Object.Instantiate(this.BurnEffect, this.transform.position, this.transform.rotation);
            TheThing.transform.parent = this.gameObject.transform;
            UnityEngine.Object.Destroy(this.Clicker);
            yield return new WaitForSeconds(12);
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }

    public virtual IEnumerator Flap()
    {
        float Interval = Random.Range(0, 2);
        this.Tick = true;
        this.FlapDown = true;
        this.FlapUp = false;
        yield return new WaitForSeconds(1);
        if (this.Clicker)
        {
            this.Clicker.GetComponent<AudioSource>().Play();
        }
        this.FlapDown = false;
        this.FlapUp = true;
        yield return new WaitForSeconds(1);
        this.FlapUp = false;
        yield return new WaitForSeconds(Interval);
        this.Tick = false;
    }

    public virtual IEnumerator FlapBig()
    {
        float Interval = Random.Range(0, 0.5f);
        if (this.Clicker)
        {
            this.Clicker.GetComponent<AudioSource>().Play();
        }
        this.Tick = true;
        this.FlapDown = true;
        this.FlapUp = false;
        yield return new WaitForSeconds(1.5f);
        this.FlapDown = false;
        this.FlapUp = true;
        yield return new WaitForSeconds(1.5f);
        this.FlapUp = false;
        yield return new WaitForSeconds(Interval);
        this.Tick = false;
    }

    public PloonFinController()
    {
        this.Strength = 0.004f;
        this.MinHeight = 2;
        this.MaxHeight = 10;
        this.FlapStrength = 0.1f;
        this.RearFlapStrength = 0.1f;
    }

}