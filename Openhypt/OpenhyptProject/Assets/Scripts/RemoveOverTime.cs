using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RemoveOverTime : MonoBehaviour
{
    public GameObject TheParent;
    public GameObject Relier;
    public RemoveOverTime CoWorker;
    public bool UseRelier;
    public bool UseCoWorker;
    public bool Active;
    public bool SkipStillDespawn;
    public bool UseDistanceDespawn;
    public bool UseCustomDespawn;
    public GameObject UCDAIgo;
    public string UCDAIname;
    public bool UseNPCDenum;
    public GameObject UNDAIgo;
    public string UNDAIname;
    public GameObject thisGO;
    public string SavedName;
    public int AppearanceEnsurement;
    public int Points;
    public int RemovalPoints;
    public int RemovalTime;
    public int DespawnDist;
    public int DespawnX;
    public int DespawnY;
    public int DespawnZ;
    public bool isVesselCarrier;
    public virtual void Start()
    {
        this.InvokeRepeating("Ticker", 5, 1);
        this.thisGO = this.gameObject;
        this.SavedName = this.thisGO.name;
        if (this.AppearanceEnsurement < 8)
        {
            this.AppearanceEnsurement = 8;
        }
        if (WorldInformation.instance.AreaCode == 64)
        {
            this.UseDistanceDespawn = false;
        }
    }

    public virtual void Update()
    {
        if (!this.SkipStillDespawn)
        {
            if ((this.transform.parent == null) && !this.Active)
            {
                this.Active = true;
                this.GetComponent<Rigidbody>().isKinematic = false;
            }
            if (this.Active)
            {
                if (this.Points > this.RemovalPoints)
                {
                    this.transform.parent = null;
                    this.GetComponent<Rigidbody>().isKinematic = true;
                    this.transform.Translate((Vector3.down * 0.15f) * Time.deltaTime, Space.World);
                }
                if (this.Points > this.RemovalTime)
                {
                    this.StartCoroutine(this.Removal());
                }
            }
        }
    }

    public virtual void Ticker()
    {
        if (!this.thisGO.activeSelf)
        {
            this.StopAllCoroutines();
            //var Blip = Resources.Load("Prefabs/RadarBlip", GameObject) as GameObject;
            //Instantiate(Blip, transform.position, transform.rotation);
            //Debug.Log(SavedName);
            //Time.timeScale = 0;
            return;
        }
        if (this.transform.position.x > this.DespawnX)
        {
            this.StartCoroutine(this.Removal());
        }
        if (this.transform.position.y > this.DespawnY)
        {
            this.StartCoroutine(this.Removal());
        }
        if (this.transform.position.z > this.DespawnZ)
        {
            this.StartCoroutine(this.Removal());
        }
        if (-this.transform.position.x > this.DespawnX)
        {
            this.StartCoroutine(this.Removal());
        }
        if (-this.transform.position.y > this.DespawnY)
        {
            this.StartCoroutine(this.Removal());
        }
        if (-this.transform.position.z > this.DespawnZ)
        {
            this.StartCoroutine(this.Removal());
        }
        if (this.UseDistanceDespawn)
        {
            if (Vector3.Distance(this.transform.position, PlayerInformation.instance.PiriPresence.position) > this.DespawnDist)
            {
                if (this.AppearanceEnsurement < 1)
                {
                    this.StartCoroutine(this.Removal());
                }
                else
                {
                    this.AppearanceEnsurement = this.AppearanceEnsurement - 1;
                }
            }
            else
            {
                this.AppearanceEnsurement = 0;
            }
        }
        if (!this.SkipStillDespawn)
        {
            if ((this.Relier != null) && this.UseRelier)
            {
                this.Points = 0;
            }
            if (this.UseCoWorker)
            {
                if (this.CoWorker == null)
                {
                    this.StartCoroutine(this.Removal());
                }
                if (this.CoWorker.Points > this.RemovalPoints)
                {
                    if (this.Points < this.RemovalPoints)
                    {
                        this.transform.parent = null;
                        this.Points = this.RemovalPoints + 1;
                    }
                    this.Points = this.Points + 1;
                }
            }
            if (!this.gameObject.activeSelf)
            {
                return;
            }
            if (this.TheParent != null)
            {
                if (!this.TheParent.activeSelf)
                {
                    return;
                }
            }
            if (!this.UseCoWorker)
            {
                Vector3 lastPos = this.transform.position;
                this.StartCoroutine(this.IsStill(lastPos));
            }
        }
    }

    public virtual IEnumerator Removal()
    {
        if (this.UseNPCDenum)
        {
            if (this.UNDAIgo)
            {
                //this.UNDAIgo.GetComponent(this.UNDAIname).Damage();
                ReflectionUtils.InvokeVoid0(UNDAIgo.GetComponent(UNDAIname), UNDAIname, "Damage");
                yield return new WaitForSeconds(0.3f);
            }
        }
        if (this.isVesselCarrier)
        {
            VesselList.instance.StaticStringOut = null;
        }
        if (!this.UseCustomDespawn)
        {
            if (this.TheParent != null)
            {
                UnityEngine.Object.Destroy(this.TheParent);
            }
            UnityEngine.Object.Destroy(this.gameObject);
        }
        else
        {
            if (this.UCDAIgo)
            {
                //this.UCDAIgo.GetComponent(this.UCDAIname).Despawn();
                ReflectionUtils.InvokeVoid0(UCDAIgo.GetComponent(UCDAIname), UCDAIname, "Despawn");
            }
        }
    }

    public virtual IEnumerator IsStill(Vector3 lastPos)
    {
        yield return new WaitForSeconds(1);
        if ((Vector3.Distance(this.transform.position, lastPos) > 0.2f) && (this.Points < this.RemovalPoints))
        {
            this.Points = 0;
        }
        if (this.Points < this.RemovalPoints)
        {
            if (Vector3.Distance(this.transform.position, lastPos) < 0.2f)
            {
                this.Points = this.Points + 1;
            }
        }
        else
        {
            this.Points = this.Points + 1;
        }
    }

    public virtual void OnJointBreak(float breakForce)
    {
        if (!this.SkipStillDespawn)
        {
            this.Active = true;
            this.transform.parent = null;
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    public RemoveOverTime()
    {
        this.UCDAIname = "PersonMcPersonface";
        this.UNDAIname = "PersonMcPersonface";
        this.RemovalPoints = 20;
        this.RemovalTime = 80;
        this.DespawnDist = 100;
        this.DespawnX = 35000;
        this.DespawnY = 35000;
        this.DespawnZ = 35000;
    }

}