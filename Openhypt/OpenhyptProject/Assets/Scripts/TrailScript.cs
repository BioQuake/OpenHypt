using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TrailScript : MonoBehaviour
{
    public LayerMask targetLayers;
    public Rigidbody VelSource;
    public bool isBig;
    public GameObject Trail1;
    public GameObject Trail2;
    public GameObject TrailW1;
    public GameObject TrailW2;
    public Transform Trail1TF;
    public Transform Trail2TF;
    public Transform TrailW1TF;
    public Transform TrailW2TF;
    public ParticleSystem Trail1PS;
    public ParticleSystem Trail2PS;
    public ParticleSystem TrailW1PS;
    public ParticleSystem TrailW2PS;
    public bool OverWater;
    public float ContactDist;
    public float TrailBaseX;
    public float TrailBaseY;
    public float speed;
    public bool Stop;
    public virtual void Start()
    {
        if (WorldInformation.instance.AreaSpace == true)
        {
            UnityEngine.Object.Destroy(this);
        }
        if (WorldInformation.instance.AreaDark == false)
        {
            if (WorldInformation.instance.AreaBeige == true)
            {
                if (!this.isBig)
                {
                    GameObject Prefabionaise1 = ((GameObject) Resources.Load("Trails/TrailStreakBeige", typeof(GameObject))) as GameObject;
                    this.Trail1 = UnityEngine.Object.Instantiate(Prefabionaise1, this.transform.position, this.transform.rotation);
                    this.Trail1TF = this.Trail1.transform;
                    this.Trail1TF.parent = this.gameObject.transform;
                    this.Trail1TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                }
                else
                {
                    GameObject Prefabionaise1B = ((GameObject) Resources.Load("Trails/TrailStreakBeigeB", typeof(GameObject))) as GameObject;
                    this.Trail1 = UnityEngine.Object.Instantiate(Prefabionaise1B, this.transform.position, this.transform.rotation);
                    this.Trail1TF = this.Trail1.transform;
                    this.Trail1TF.parent = this.gameObject.transform;
                    this.Trail1TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                }
                if (!this.isBig)
                {
                    GameObject Prefabionaise2 = ((GameObject) Resources.Load("Trails/TrailCloudBeige", typeof(GameObject))) as GameObject;
                    this.Trail2 = UnityEngine.Object.Instantiate(Prefabionaise2, this.transform.position, this.transform.rotation);
                    this.Trail2TF = this.Trail2.transform;
                    this.Trail2TF.parent = this.gameObject.transform;
                    this.Trail2TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                }
                else
                {
                    GameObject Prefabionaise2B = ((GameObject) Resources.Load("Trails/TrailCloudBeigeB", typeof(GameObject))) as GameObject;
                    this.Trail2 = UnityEngine.Object.Instantiate(Prefabionaise2B, this.transform.position, this.transform.rotation);
                    this.Trail2TF = this.Trail2.transform;
                    this.Trail2TF.parent = this.gameObject.transform;
                    this.Trail2TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                }
                GameObject Prefabionaise3 = ((GameObject) Resources.Load("Trails/TrailStreakWater", typeof(GameObject))) as GameObject;
                this.TrailW1 = UnityEngine.Object.Instantiate(Prefabionaise3, this.transform.position, this.transform.rotation);
                this.TrailW1TF = this.TrailW1.transform;
                this.TrailW1TF.parent = this.gameObject.transform;
                this.TrailW1TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                GameObject Prefabionaise4 = ((GameObject) Resources.Load("Trails/TrailCloudWater", typeof(GameObject))) as GameObject;
                this.TrailW2 = UnityEngine.Object.Instantiate(Prefabionaise4, this.transform.position, this.transform.rotation);
                this.TrailW2TF = this.TrailW2.transform;
                this.TrailW2TF.parent = this.gameObject.transform;
                this.TrailW2TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                this.Trail1PS = (ParticleSystem) this.Trail1.GetComponent(typeof(ParticleSystem));
                this.Trail2PS = (ParticleSystem) this.Trail2.GetComponent(typeof(ParticleSystem));
                this.TrailW1PS = (ParticleSystem) this.TrailW1.GetComponent(typeof(ParticleSystem));
                this.TrailW2PS = (ParticleSystem) this.TrailW2.GetComponent(typeof(ParticleSystem));
            }
            if (WorldInformation.instance.AreaGray == true)
            {
                if (!this.isBig)
                {
                    GameObject Prefabionaise5 = ((GameObject) Resources.Load("Trails/TrailStreakPale", typeof(GameObject))) as GameObject;
                    this.Trail1 = UnityEngine.Object.Instantiate(Prefabionaise5, this.transform.position, this.transform.rotation);
                    this.Trail1TF = this.Trail1.transform;
                    this.Trail1TF.parent = this.gameObject.transform;
                    this.Trail1TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                }
                else
                {
                    GameObject Prefabionaise5B = ((GameObject) Resources.Load("Trails/TrailStreakPaleB", typeof(GameObject))) as GameObject;
                    this.Trail1 = UnityEngine.Object.Instantiate(Prefabionaise5B, this.transform.position, this.transform.rotation);
                    this.Trail1TF = this.Trail1.transform;
                    this.Trail1TF.parent = this.gameObject.transform;
                    this.Trail1TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                }
                if (!this.isBig)
                {
                    GameObject Prefabionaise6 = ((GameObject) Resources.Load("Trails/TrailCloudPale", typeof(GameObject))) as GameObject;
                    this.Trail2 = UnityEngine.Object.Instantiate(Prefabionaise6, this.transform.position, this.transform.rotation);
                    this.Trail2TF = this.Trail2.transform;
                    this.Trail2TF.parent = this.gameObject.transform;
                    this.Trail2TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                }
                else
                {
                    GameObject Prefabionaise6B = ((GameObject) Resources.Load("Trails/TrailCloudPaleB", typeof(GameObject))) as GameObject;
                    this.Trail2 = UnityEngine.Object.Instantiate(Prefabionaise6B, this.transform.position, this.transform.rotation);
                    this.Trail2TF = this.Trail2.transform;
                    this.Trail2TF.parent = this.gameObject.transform;
                    this.Trail2TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                }
                GameObject Prefabionaise7 = ((GameObject) Resources.Load("Trails/TrailStreakWater", typeof(GameObject))) as GameObject;
                this.TrailW1 = UnityEngine.Object.Instantiate(Prefabionaise7, this.transform.position, this.transform.rotation);
                this.TrailW1TF = this.TrailW1.transform;
                this.TrailW1TF.parent = this.gameObject.transform;
                this.TrailW1TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                GameObject Prefabionaise8 = ((GameObject) Resources.Load("Trails/TrailCloudWater", typeof(GameObject))) as GameObject;
                this.TrailW2 = UnityEngine.Object.Instantiate(Prefabionaise8, this.transform.position, this.transform.rotation);
                this.TrailW2TF = this.TrailW2.transform;
                this.TrailW2TF.parent = this.gameObject.transform;
                this.TrailW2TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                this.Trail1PS = (ParticleSystem) this.Trail1.GetComponent(typeof(ParticleSystem));
                this.Trail2PS = (ParticleSystem) this.Trail2.GetComponent(typeof(ParticleSystem));
                this.TrailW1PS = (ParticleSystem) this.TrailW1.GetComponent(typeof(ParticleSystem));
                this.TrailW2PS = (ParticleSystem) this.TrailW2.GetComponent(typeof(ParticleSystem));
            }
        }
        else
        {
            if (WorldInformation.instance.AreaDut == false)
            {
                if (!this.isBig)
                {
                    GameObject Prefabionaise9 = ((GameObject) Resources.Load("Trails/TrailStreakDark", typeof(GameObject))) as GameObject;
                    this.Trail1 = UnityEngine.Object.Instantiate(Prefabionaise9, this.transform.position, this.transform.rotation);
                    this.Trail1TF = this.Trail1.transform;
                    this.Trail1TF.parent = this.gameObject.transform;
                    this.Trail1TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                }
                else
                {
                    GameObject Prefabionaise9B = ((GameObject) Resources.Load("Trails/TrailStreakDarkB", typeof(GameObject))) as GameObject;
                    this.Trail1 = UnityEngine.Object.Instantiate(Prefabionaise9B, this.transform.position, this.transform.rotation);
                    this.Trail1TF = this.Trail1.transform;
                    this.Trail1TF.parent = this.gameObject.transform;
                    this.Trail1TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                }
                if (!this.isBig)
                {
                    GameObject Prefabionaise10 = ((GameObject) Resources.Load("Trails/TrailCloudDark", typeof(GameObject))) as GameObject;
                    this.Trail2 = UnityEngine.Object.Instantiate(Prefabionaise10, this.transform.position, this.transform.rotation);
                    this.Trail2TF = this.Trail2.transform;
                    this.Trail2TF.parent = this.gameObject.transform;
                    this.Trail2TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                }
                else
                {
                    GameObject Prefabionaise10B = ((GameObject) Resources.Load("Trails/TrailCloudDarkB", typeof(GameObject))) as GameObject;
                    this.Trail2 = UnityEngine.Object.Instantiate(Prefabionaise10B, this.transform.position, this.transform.rotation);
                    this.Trail2TF = this.Trail2.transform;
                    this.Trail2TF.parent = this.gameObject.transform;
                    this.Trail2TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                }
            }
            else
            {
                if (!this.isBig)
                {
                    GameObject Prefabionaise13 = ((GameObject) Resources.Load("Trails/TrailStreakDut", typeof(GameObject))) as GameObject;
                    this.Trail1 = UnityEngine.Object.Instantiate(Prefabionaise13, this.transform.position, this.transform.rotation);
                    this.Trail1TF = this.Trail1.transform;
                    this.Trail1TF.parent = this.gameObject.transform;
                    this.Trail1TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                }
                else
                {
                    GameObject Prefabionaise13B = ((GameObject) Resources.Load("Trails/TrailStreakDutB", typeof(GameObject))) as GameObject;
                    this.Trail1 = UnityEngine.Object.Instantiate(Prefabionaise13B, this.transform.position, this.transform.rotation);
                    this.Trail1TF = this.Trail1.transform;
                    this.Trail1TF.parent = this.gameObject.transform;
                    this.Trail1TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                }
                if (!this.isBig)
                {
                    GameObject Prefabionaise14 = ((GameObject) Resources.Load("Trails/TrailCloudDut", typeof(GameObject))) as GameObject;
                    this.Trail2 = UnityEngine.Object.Instantiate(Prefabionaise14, this.transform.position, this.transform.rotation);
                    this.Trail2TF = this.Trail2.transform;
                    this.Trail2TF.parent = this.gameObject.transform;
                    this.Trail2TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                }
                else
                {
                    GameObject Prefabionaise14B = ((GameObject) Resources.Load("Trails/TrailCloudDutB", typeof(GameObject))) as GameObject;
                    this.Trail2 = UnityEngine.Object.Instantiate(Prefabionaise14B, this.transform.position, this.transform.rotation);
                    this.Trail2TF = this.Trail2.transform;
                    this.Trail2TF.parent = this.gameObject.transform;
                    this.Trail2TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
                }
            }
            GameObject Prefabionaise11 = ((GameObject) Resources.Load("Trails/TrailStreakWater", typeof(GameObject))) as GameObject;
            this.TrailW1 = UnityEngine.Object.Instantiate(Prefabionaise11, this.transform.position, this.transform.rotation);
            this.TrailW1TF = this.TrailW1.transform;
            this.TrailW1TF.parent = this.gameObject.transform;
            this.TrailW1TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
            GameObject Prefabionaise12 = ((GameObject) Resources.Load("Trails/TrailCloudWater", typeof(GameObject))) as GameObject;
            this.TrailW2 = UnityEngine.Object.Instantiate(Prefabionaise12, this.transform.position, this.transform.rotation);
            this.TrailW2TF = this.TrailW2.transform;
            this.TrailW2TF.parent = this.gameObject.transform;
            this.TrailW2TF.localScale = new Vector3(this.TrailBaseX, this.TrailBaseY, 0.2f);
            this.Trail1PS = (ParticleSystem) this.Trail1.GetComponent(typeof(ParticleSystem));
            this.Trail2PS = (ParticleSystem) this.Trail2.GetComponent(typeof(ParticleSystem));
            this.TrailW1PS = (ParticleSystem) this.TrailW1.GetComponent(typeof(ParticleSystem));
            this.TrailW2PS = (ParticleSystem) this.TrailW2.GetComponent(typeof(ParticleSystem));
        }
        this.Trail1PS.emissionRate = 1;
        this.Trail2PS.emissionRate = 1;
        this.TrailW1PS.emissionRate = 1;
        this.TrailW2PS.emissionRate = 1;
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (WorldInformation.instance.AreaSpace == true)
        {
            return;
        }
        if (!this.Stop)
        {
            this.speed = this.VelSource.velocity.magnitude;
            if (Physics.Raycast(this.transform.position, Vector3.down, out hit, this.ContactDist, (int) this.targetLayers))
            {
                if (!hit.collider.tag.Contains("tru"))
                {
                    float speedC1 = this.speed * 0.2f;
                    if (this.speed > 10)
                    {
                        if (this.OverWater)
                        {
                            this.TrailW1PS.emissionRate = speedC1 * 6;
                        }
                        else
                        {
                            this.Trail1PS.emissionRate = speedC1 * 6;
                        }
                    }
                    else
                    {
                        if (this.TrailW1PS.emissionRate > 0)
                        {
                            this.TrailW1PS.emissionRate = this.TrailW1PS.emissionRate - 1;
                        }
                        if (this.Trail1PS.emissionRate > 0)
                        {
                            this.Trail1PS.emissionRate = this.Trail1PS.emissionRate - 1;
                        }
                    }
                    if (this.speed > 5)
                    {
                        if (this.OverWater)
                        {
                            this.TrailW2PS.emissionRate = speedC1;
                        }
                        else
                        {
                            if (!this.isBig)
                            {
                                this.Trail2PS.emissionRate = speedC1;
                            }
                            else
                            {
                                this.Trail2PS.emissionRate = speedC1 * 2;
                            }
                        }
                    }
                    else
                    {
                        if (this.TrailW2PS.emissionRate > 0)
                        {
                            this.Trail2PS.emissionRate = this.Trail2PS.emissionRate - 1;
                        }
                        if (this.Trail2PS.emissionRate > 0)
                        {
                            this.Trail2PS.emissionRate = this.Trail2PS.emissionRate - 1;
                        }
                    }
                    if (hit.collider.name == "Wa")
                    {
                        this.OverWater = true;
                        this.Trail1PS.emissionRate = 0;
                        this.Trail2PS.emissionRate = 0;
                    }
                    else
                    {
                        this.OverWater = false;
                        this.TrailW1PS.emissionRate = 0;
                        this.TrailW2PS.emissionRate = 0;
                    }
                    this.Trail1TF.position = hit.point;
                    this.Trail2TF.position = hit.point;
                    this.TrailW1TF.position = hit.point;
                    this.TrailW2TF.position = hit.point;
                }
                else
                {
                    float speedC2 = this.speed * 0.05f;
                    if (this.Trail1PS.emissionRate > 0)
                    {
                        this.Trail1PS.emissionRate = this.Trail1PS.emissionRate - (1 + speedC2);
                    }
                    if (this.Trail2PS.emissionRate > 0)
                    {
                        this.Trail2PS.emissionRate = this.Trail2PS.emissionRate - (1 + speedC2);
                    }
                    if (this.TrailW1PS.emissionRate > 0)
                    {
                        this.TrailW1PS.emissionRate = this.TrailW1PS.emissionRate - (1 + speedC2);
                    }
                    if (this.TrailW2PS.emissionRate > 0)
                    {
                        this.TrailW2PS.emissionRate = this.TrailW2PS.emissionRate - (1 + speedC2);
                    }
                }
            }
            else
            {
                float speedC3 = this.speed * 0.05f;
                if (this.Trail1PS.emissionRate > 0)
                {
                    this.Trail1PS.emissionRate = this.Trail1PS.emissionRate - (1 + speedC3);
                }
                if (this.Trail2PS.emissionRate > 0)
                {
                    this.Trail2PS.emissionRate = this.Trail2PS.emissionRate - (1 + speedC3);
                }
                if (this.TrailW1PS.emissionRate > 0)
                {
                    this.TrailW1PS.emissionRate = this.TrailW1PS.emissionRate - (1 + speedC3);
                }
                if (this.TrailW2PS.emissionRate > 0)
                {
                    this.TrailW2PS.emissionRate = this.TrailW2PS.emissionRate - (1 + speedC3);
                }
            }
        }
        else
        {
            this.Trail1PS.emissionRate = 0;
            this.Trail2PS.emissionRate = 0;
            this.TrailW1PS.emissionRate = 0;
            this.TrailW2PS.emissionRate = 0;
        }
    }

    public TrailScript()
    {
        this.ContactDist = 2;
        this.TrailBaseX = 4;
        this.TrailBaseY = 4;
    }

}