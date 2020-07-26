using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class WaterScript : MonoBehaviour
{
    public float Proddy;
    public Transform Orientator;
    public GameObject StrikePrefabPar;
    public GameObject StrikePrefabPer;
    public GameObject PerturbPrefab;
    public int PerCount;
    public int ParCount;
    public GameObject Object1;
    public int ParCount1;
    public GameObject Object2;
    public int ParCount2;
    public virtual void FixedUpdate()
    {
        if (this.PerCount < 64)
        {
            this.PerCount = this.PerCount + 1;
        }
        if (this.ParCount < 64)
        {
            this.ParCount = this.ParCount + 1;
        }
        if (this.Object1)
        {
            if (this.ParCount1 < 64)
            {
                this.ParCount1 = this.ParCount1 + 1;
            }
        }
        if (this.Object2)
        {
            if (this.ParCount2 < 64)
            {
                this.ParCount2 = this.ParCount2 + 1;
            }
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            if (other.GetComponent<Rigidbody>().angularDrag < 16)
            {
                other.GetComponent<Rigidbody>().angularDrag = 0.1f;
            }
            if (other.gameObject == this.Object1)
            {
                this.Object1 = null;
            }
            if (other.gameObject == this.Object2)
            {
                this.Object2 = null;
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Rigidbody ORB = other.GetComponent<Rigidbody>();
            Transform OTF = other.transform;
            Vector3 localV = this.transform.InverseTransformDirection(ORB.velocity);
            if (this.PerCount > 8)
            {
                if (-localV.y > 5)
                {
                    if (ORB.mass > 0.045f)
                    {
                        this.PerCount = 0;
                        if (ORB.mass < 0.15f)
                        {
                            if (-localV.y > 10)
                            {
                                GameObject Thing1 = UnityEngine.Object.Instantiate(this.StrikePrefabPer, other.transform.position, this.transform.rotation);
                                Thing1.transform.position = new Vector3(OTF.position.x, this.transform.position.y, OTF.position.z);
                            }
                        }
                        else
                        {
                            GameObject Thing0 = UnityEngine.Object.Instantiate(this.StrikePrefabPer, other.transform.position, this.transform.rotation);
                            Thing0.transform.position = new Vector3(OTF.position.x, this.transform.position.y, OTF.position.z);
                        }
                    }
                }
            }
            if (Vector3.Distance(OTF.position, PlayerInformation.instance.PiriPresence.position) < 512)
            {
                if (!this.Object1)
                {
                    this.Object1 = other.gameObject;
                }
                if (!this.Object2)
                {
                    this.Object2 = other.gameObject;
                }
            }
            if (this.Object1 == this.Object2)
            {
                this.Object2 = null;
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Rigidbody ORB = other.GetComponent<Rigidbody>();
            Transform OTF = other.transform;
            Vector3 relativePoint = this.transform.InverseTransformPoint(OTF.position);
            float ContactDist = relativePoint.y;
            if (ContactDist > 0)
            {
                float ORBvel = ORB.velocity.magnitude;
                if (Vector3.Distance(OTF.position, PlayerInformation.instance.PiriPresence.position) < 2)
                {
                    if (this.ParCount > 6)
                    {
                        if (ORB.velocity.magnitude > 10)
                        {
                            GameObject Thing1 = UnityEngine.Object.Instantiate(this.StrikePrefabPar, OTF.position, this.transform.rotation);
                            Thing1.GetComponent<Rigidbody>().velocity = ORB.velocity * 1;
                            Thing1.transform.position = new Vector3(OTF.position.x, this.transform.position.y, OTF.position.z);
                            this.ParCount = 0;
                        }
                        else
                        {
                            if (this.ParCount > 8)
                            {
                                GameObject Thing2 = UnityEngine.Object.Instantiate(this.PerturbPrefab, OTF.position, this.transform.rotation);
                                Thing2.transform.position = new Vector3(OTF.position.x, this.transform.position.y, OTF.position.z);
                                this.ParCount = 0;
                            }
                        }
                    }
                }
                else
                {
                    if (this.ParCount1 > 6)
                    {
                        if (ORB.velocity.magnitude > 10)
                        {
                            GameObject Thing3 = UnityEngine.Object.Instantiate(this.StrikePrefabPar, OTF.position, this.transform.rotation);
                            Thing3.GetComponent<Rigidbody>().velocity = ORB.velocity * 1;
                            Thing3.transform.position = new Vector3(OTF.position.x, this.transform.position.y, OTF.position.z);
                            this.ParCount1 = 0;
                        }
                        else
                        {
                            if (this.ParCount1 > 8)
                            {
                                GameObject Thing4 = UnityEngine.Object.Instantiate(this.PerturbPrefab, OTF.position, this.transform.rotation);
                                Thing4.transform.position = new Vector3(OTF.position.x, this.transform.position.y, OTF.position.z);
                                this.ParCount1 = 0;
                            }
                        }
                    }
                    if (this.ParCount2 > 6)
                    {
                        if (ORB.velocity.magnitude > 10)
                        {
                            GameObject Thing5 = UnityEngine.Object.Instantiate(this.StrikePrefabPar, OTF.position, this.transform.rotation);
                            Thing5.GetComponent<Rigidbody>().velocity = ORB.velocity * 1;
                            Thing5.transform.position = new Vector3(OTF.position.x, this.transform.position.y, OTF.position.z);
                            this.ParCount2 = 0;
                        }
                        else
                        {
                            if (this.ParCount2 > 8)
                            {
                                GameObject Thing6 = UnityEngine.Object.Instantiate(this.PerturbPrefab, OTF.position, this.transform.rotation);
                                Thing6.transform.position = new Vector3(OTF.position.x, this.transform.position.y, OTF.position.z);
                                this.ParCount2 = 0;
                            }
                        }
                    }
                }
                if (ORB.velocity != Vector3.zero)
                {
                    this.Orientator.rotation = Quaternion.LookRotation(ORB.velocity);
                }
                ORB.AddTorque(((this.Orientator.right * ORBvel) * ORB.mass) * ContactDist);
                ORB.AddForce((ORB.velocity * ORB.mass) * -1);
            }
            else
            {
                float Clamp = Mathf.Clamp(ContactDist, -1, 0);
                if (Vector3.Distance(OTF.position, PlayerInformation.instance.PiriPresence.position) < 2)
                {
                    if (this.ParCount > 8)
                    {
                        GameObject Thing7 = UnityEngine.Object.Instantiate(this.PerturbPrefab, OTF.position, this.transform.rotation);
                        Thing7.transform.position = new Vector3(OTF.position.x, this.transform.position.y, OTF.position.z);
                        this.ParCount = 0;
                    }
                }
                else
                {
                    if (this.ParCount1 > 8)
                    {
                        GameObject Thing8 = UnityEngine.Object.Instantiate(this.PerturbPrefab, OTF.position, this.transform.rotation);
                        Thing8.transform.position = new Vector3(OTF.position.x, this.transform.position.y, OTF.position.z);
                        this.ParCount1 = 0;
                    }
                    if (this.ParCount2 > 8)
                    {
                        GameObject Thing9 = UnityEngine.Object.Instantiate(this.PerturbPrefab, OTF.position, this.transform.rotation);
                        Thing9.transform.position = new Vector3(OTF.position.x, this.transform.position.y, OTF.position.z);
                        this.ParCount2 = 0;
                    }
                }
                if (ORB.angularDrag < 16)
                {
                    ORB.angularDrag = 8;
                }
                ORB.AddForce((ORB.velocity * ORB.mass) * -4);
                ORB.AddForce(((Vector3.up * ORB.mass) * 21) * -Clamp);
            }
        }
    }

    public WaterScript()
    {
        this.Proddy = 1;
    }

}