using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DutOotController : MonoBehaviour
{
    public Transform targetXB;
    public Transform target;
    public DutOotController targetAI;
    public Transform targetPiri;
    public Rigidbody ootRB;
    public Transform ootTF;
    public Transform ootTC;
    public SphereCollider ootTrig;
    public Transform thisTransform;
    public Transform Model;
    public Transform Model2;
    public Transform Model3;
    public Transform topTF;
    public ParticleSystem Blur;
    public ParticleSystem FX1;
    public ParticleSystem FX2;
    public Color newColor;
    public float aimForce;
    public float hoverForce;
    public AnimationCurve hoverCurve;
    public AnimationCurve ootSizeCurve;
    public int lifetime;
    public int ootGrowth;
    public int protoCykinGrowth;
    public bool IsFading;
    public bool IsMerging;
    public bool IsSacrificing;
    public bool IsColonist;
    public bool SpawningCykin;
    public bool SpawningCydaz;
    public bool SpawningCytarg;
    public bool SpawningCytchau;
    public LayerMask targetLayers;
    public virtual void Start()
    {
        this.InvokeRepeating("Ticker", Random.Range(0.1f, 0.9f), 1);
        this.ootTF.parent.transform.parent = null;
        this.lifetime = Random.Range(8, 64);
        this.newColor = this.Model.GetComponent<Renderer>().material.GetColor("_Color");
        this.targetPiri = PlayerInformation.instance.Pirizuka;
        this.ootRB.mass = this.ootGrowth * 0.001f;
        StuffSpawner.TheNPC0805N = StuffSpawner.TheNPC0805N + 1;
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        this.thisTransform.position = this.ootTF.transform.position;
        if (((this.Blur.startColor.a < 0.5f) && !this.IsFading) && !this.IsMerging)
        {

            {
                float _1822 = this.Blur.startColor.a + 0.002f;
                Color _1823 = this.Blur.startColor;
                _1823.a = _1822;
                this.Blur.startColor = _1823;
            }
        }
        if (!this.IsFading && !this.IsMerging)
        {
            if (this.ootGrowth < 4)
            {
                if (this.newColor.a < 0.5f)
                {
                    this.newColor.a = this.newColor.a + 0.002f;
                }
                else
                {
                    this.newColor.a = this.newColor.a - 0.002f;
                }
            }
            else
            {
                if (this.newColor.a < 0.25f)
                {
                    this.newColor.a = this.newColor.a + 0.001f;
                }
                else
                {
                    this.newColor.a = this.newColor.a - 0.001f;
                }
                if (this.topTF.localPosition.z < (this.ootGrowth * 0.15f))
                {

                    {
                        float _1824 = this.topTF.localPosition.z + 0.003f;
                        Vector3 _1825 = this.topTF.localPosition;
                        _1825.z = _1824;
                        this.topTF.localPosition = _1825;
                    }
                }
                else
                {

                    {
                        float _1826 = this.topTF.localPosition.z - 0.003f;
                        Vector3 _1827 = this.topTF.localPosition;
                        _1827.z = _1826;
                        this.topTF.localPosition = _1827;
                    }
                }
            }
        }
        if (this.ootGrowth < 1)
        {
            if (Vector3.Distance(this.thisTransform.position, this.targetPiri.position) < 1.5f)
            {
                this.IsFading = true;

                {
                    float _1828 = this.Blur.startColor.a - 0.002f;
                    Color _1829 = this.Blur.startColor;
                    _1829.a = _1828;
                    this.Blur.startColor = _1829;
                }
                this.newColor.a = this.newColor.a - 0.002f;
            }
        }
        if (this.IsFading)
        {
            this.ootRB.AddForce(this.transform.forward * Random.Range(0.0001f * this.ootGrowth, 0.0003f * this.ootGrowth));
            if (this.target)
            {
                this.ootRB.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * this.aimForce, this.thisTransform.forward * 1);
                this.ootRB.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * -this.aimForce, -this.thisTransform.forward * 1);
                if (this.IsMerging)
                {
                    this.ootRB.AddForce((this.target.position - this.thisTransform.position).normalized * 0.002f);
                }
            }
            this.IsFading = true;

            {
                float _1830 = this.Blur.startColor.a - 0.002f;
                Color _1831 = this.Blur.startColor;
                _1831.a = _1830;
                this.Blur.startColor = _1831;
            }
            this.newColor.a = this.newColor.a - 0.002f;
        }
        else
        {
            if (!this.IsColonist)
            {
                if (this.ootTrig.radius < 64)
                {
                    this.ootTrig.radius = this.ootTrig.radius + 0.1f;
                }
            }
            else
            {
                if (this.ootTrig.radius < 5.5f)
                {
                    this.ootTrig.radius = this.ootTrig.radius + 0.1f;
                }
            }
            if (this.target)
            {
                if (this.ootGrowth < 4)
                {
                    this.ootRB.AddForce(this.transform.forward * Random.Range(0.0001f * this.ootGrowth, 0.0003f * this.ootGrowth));
                    this.ootRB.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * this.aimForce, this.thisTransform.forward * 0.3f);
                    this.ootRB.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * -this.aimForce, -this.thisTransform.forward * 0.3f);
                    this.ootRB.AddTorque(this.ootTF.up * Random.Range(-0.0001f, 0.0001f));
                    this.ootRB.AddTorque(this.ootTF.right * Random.Range(-0.0001f, 0.0001f));
                    this.ootRB.AddTorque(this.ootTF.forward * Random.Range(-0.0001f, 0.0001f));
                }
                else
                {
                    if (Physics.Raycast(this.thisTransform.position, Vector3.down, out hit, 2000, (int) this.targetLayers))
                    {
                        this.hoverForce = this.hoverCurve.Evaluate(hit.distance);
                        this.ootRB.AddForce((Vector3.up * this.hoverForce) * 0.005f);
                    }
                    this.ootRB.AddForceAtPosition(Vector3.up * this.aimForce, this.thisTransform.forward * 1);
                    this.ootRB.AddForceAtPosition(-Vector3.up * this.aimForce, -this.thisTransform.forward * 1);
                    if (!this.IsColonist)
                    {
                        if (!this.IsSacrificing)
                        {
                            if (Vector3.Distance(this.thisTransform.position, this.target.position) > 1.5f)
                            {
                                this.ootRB.AddForce(((this.target.position - this.thisTransform.position).normalized * 0.0003f) * this.ootGrowth);
                            }
                            else
                            {
                                this.ootRB.AddForce(((this.target.position - this.thisTransform.position).normalized * -0.0003f) * this.ootGrowth);
                            }
                        }
                        else
                        {
                            this.ootRB.AddForce(((this.target.position - this.thisTransform.position).normalized * 0.0003f) * this.ootGrowth);
                        }
                    }
                    else
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.target.position) > 1.5f)
                        {
                            this.ootRB.AddForce(((this.target.position - this.thisTransform.position).normalized * 0.0003f) * this.ootGrowth);
                        }
                        else
                        {
                            this.ootRB.AddForce(((this.target.position - this.thisTransform.position).normalized * -0.0003f) * this.ootGrowth);
                        }
                        if (this.targetXB)
                        {
                            if (Vector3.Distance(this.thisTransform.position, this.targetXB.position) > 1.5f)
                            {
                                this.ootRB.AddForce(((this.targetXB.position - this.thisTransform.position).normalized * 0.00015f) * this.ootGrowth);
                            }
                        }
                    }
                    if (this.ootGrowth < 16)
                    {
                        this.ootRB.AddTorque(this.ootTF.up * Random.Range(-3E-05f, 3E-05f));
                        this.ootRB.AddTorque(this.ootTF.right * Random.Range(-3E-05f, 3E-05f));
                        this.ootRB.AddTorque(this.ootTF.forward * Random.Range(-3E-05f, 3E-05f));
                    }
                }
            }
            else
            {
                if (this.ootGrowth < 4)
                {
                    this.ootRB.AddForce(this.transform.forward * Random.Range(0.0001f * this.ootGrowth, 0.0003f * this.ootGrowth));
                    this.ootRB.AddTorque(this.ootTF.up * Random.Range(-0.0001f, 0.0001f));
                    this.ootRB.AddTorque(this.ootTF.right * Random.Range(-0.0001f, 0.0001f));
                    this.ootRB.AddTorque(this.ootTF.forward * Random.Range(-0.0001f, 0.0001f));
                }
                else
                {
                    if (Physics.Raycast(this.thisTransform.position, Vector3.down, out hit, 2000, (int) this.targetLayers))
                    {
                        this.hoverForce = this.hoverCurve.Evaluate(hit.distance);
                        this.ootRB.AddForce((Vector3.up * this.hoverForce) * 0.005f);
                    }
                    this.ootRB.AddForceAtPosition(Vector3.up * this.aimForce, this.thisTransform.forward * 1);
                    this.ootRB.AddForceAtPosition(-Vector3.up * this.aimForce, -this.thisTransform.forward * 1);
                    if (this.IsColonist)
                    {
                        if (this.targetXB)
                        {
                            if (Vector3.Distance(this.thisTransform.position, this.targetXB.position) > 1.5f)
                            {
                                this.ootRB.AddForce(((this.targetXB.position - this.thisTransform.position).normalized * 0.00015f) * this.ootGrowth);
                            }
                            else
                            {
                                this.ootRB.AddForce(((this.targetXB.position - this.thisTransform.position).normalized * -0.0007f) * this.ootGrowth);
                            }
                        }
                        else
                        {
                            this.IsColonist = false;
                        }
                    }
                    if (this.ootGrowth < 16)
                    {
                        this.ootRB.AddTorque(this.ootTF.up * Random.Range(-3E-05f, 3E-05f));
                        this.ootRB.AddTorque(this.ootTF.right * Random.Range(-3E-05f, 3E-05f));
                        this.ootRB.AddTorque(this.ootTF.forward * Random.Range(-3E-05f, 3E-05f));
                    }
                }
            }
        }
        this.Model.GetComponent<Renderer>().material.SetColor("_Color", this.newColor);
        this.Model2.GetComponent<Renderer>().material.SetColor("_Color", this.newColor);
        this.Model3.GetComponent<Renderer>().material.SetColor("_Color", this.newColor);
        if (this.ootGrowth < 7)
        {
            if (this.ootGrowth > 3)
            {
                if (this.Model3.localScale.y > 0)
                {
                    this.Model3.localScale = this.Model3.localScale - new Vector3(0.003f, 0.003f, 0.003f);
                }
                if (this.Model2.localScale.y < 1)
                {
                    this.Model2.localScale = this.Model2.localScale + new Vector3(0.005f, 0.005f, 0.005f);
                }
                if (this.Model.localScale.y > 0)
                {
                    this.Model.localScale = this.Model.localScale - new Vector3(0.002f, 0.002f, 0.002f);
                }
            }
            else
            {
                if (this.Model3.localScale.y > 0)
                {
                    this.Model3.localScale = this.Model3.localScale - new Vector3(0.003f, 0.003f, 0.003f);
                }
                if (this.Model2.localScale.y > 0)
                {
                    this.Model2.localScale = this.Model2.localScale - new Vector3(0.003f, 0.003f, 0.003f);
                }
                if (this.Model.localScale.y < 1)
                {
                    this.Model.localScale = this.Model.localScale + new Vector3(0.005f, 0.005f, 0.005f);
                }
            }
        }
        else
        {
            if (this.Model3.localScale.y < (this.ootGrowth * 0.1f))
            {
                this.Model3.localScale = this.Model3.localScale + new Vector3(0.003f, 0.003f, 0.003f);
            }
            else
            {
                this.Model3.localScale = this.Model3.localScale - new Vector3(0.003f, 0.003f, 0.003f);
            }
            if (this.Model2.localScale.y > 0)
            {
                this.Model2.localScale = this.Model2.localScale - new Vector3(0.001f, 0.001f, 0.001f);
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (this.IsFading || (this.ootGrowth > 15))
        {
            return;
        }
        string ON = other.name;
        Transform OT = other.transform;
        if (!this.IsColonist)
        {
            if (ON.Contains("OotT"))
            {
                if (OT != this.ootTC)
                {
                    if (this.ootGrowth > 3)
                    {
                        if (ON.Contains("mO") || ON.Contains("bO"))
                        {
                            if (((DutOotController) OT.parent.transform.GetChild(0).GetComponent(typeof(DutOotController))).ootGrowth > this.ootGrowth)
                            {
                                this.target = OT;
                            }
                            if (((DutOotController) OT.parent.transform.GetChild(0).GetComponent(typeof(DutOotController))).IsColonist == false)
                            {
                                this.ootTrig.radius = 0.1f;
                            }
                            if (ON.Contains("xbO"))
                            {
                                if (Vector3.Distance(this.thisTransform.position, OT.position) < 3.5f)
                                {
                                    this.targetXB = OT;
                                    this.target = OT;
                                    this.IsColonist = true;
                                }
                                this.ootTrig.radius = 0.1f;
                            }
                        }
                    }
                    else
                    {
                        this.ootTrig.radius = 0.1f;
                        if (this.target)
                        {
                            if (Vector3.Distance(this.thisTransform.position, OT.position) < Vector3.Distance(this.thisTransform.position, this.target.position))
                            {
                                this.target = OT;
                            }
                        }
                        else
                        {
                            this.target = OT;
                        }
                    }
                }
            }
        }
        else
        {
            if (ON.Contains("OotT"))
            {
                if (OT != this.ootTC)
                {
                    if (ON.Contains("mO") || ON.Contains("bO"))
                    {
                        this.ootTrig.radius = 0.1f;
                        this.target = OT;
                    }
                }
            }
        }
    }

    public virtual void Ticker()
    {
        if (this.target)
        {
            if (!this.IsFading)
            {
                if (this.IsColonist)
                {
                    if (this.ootGrowth > 3)
                    {
                        if (this.targetXB)
                        {
                            this.ootGrowth = (int) this.ootSizeCurve.Evaluate(Vector3.Distance(this.thisTransform.position, this.targetXB.position));
                        }
                        if (this.ootGrowth < 4)
                        {
                            this.IsColonist = false;
                            this.target = null;
                        }
                    }
                }
                else
                {
                    if (this.ootGrowth > 3)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.target.position) < 1.5f)
                        {
                            if (((DutOotController) this.target.parent.transform.GetChild(0).GetComponent(typeof(DutOotController))).IsSacrificing)
                            {
                                this.target = null;
                            }
                        }
                    }
                }
                if (this.target)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.target.position) < 0.5f)
                    {
                        if (this.target.name.Contains("OotT"))
                        {
                            this.targetAI = (DutOotController) this.target.parent.transform.GetChild(0).GetComponent(typeof(DutOotController));
                            if (this.ootGrowth >= this.targetAI.ootGrowth)
                            {
                                if (this.targetAI.ootGrowth < 4)
                                {
                                    this.targetAI.IsFading = true;
                                    this.targetAI.IsMerging = true;
                                    this.targetAI.target = this.ootTC;
                                    this.ootGrowth = this.ootGrowth + this.targetAI.ootGrowth;
                                    this.ootRB.mass = this.ootRB.mass + (this.targetAI.ootGrowth * 0.001f);
                                    this.lifetime = this.lifetime + 64;
                                    UnityEngine.Object.Destroy(this.target.gameObject);
                                }
                            }
                            else
                            {
                                //targetAI = null;
                                if (this.targetAI.ootGrowth < 16)
                                {
                                    if (this.targetAI.ootGrowth > 3)
                                    {
                                        this.IsFading = true;
                                        this.IsMerging = true;
                                        this.targetAI.ootGrowth = this.targetAI.ootGrowth + this.ootGrowth;
                                        this.target.parent.GetComponent<Rigidbody>().mass = this.target.parent.GetComponent<Rigidbody>().mass + (this.ootGrowth * 0.001f);
                                        this.targetAI.lifetime = this.targetAI.lifetime + 64;
                                        UnityEngine.Object.Destroy(this.ootTC.gameObject);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        //targetAI = null;
        if (this.IsColonist)
        {
            if (this.ootGrowth > 15)
            {
                this.ootGrowth = 12;
            }
        }
        this.Blur.startSize = 1 + (this.ootGrowth * 0.15f);
        if (!this.IsFading)
        {
            if (this.ootGrowth < 7)
            {
                if (this.ootGrowth > 3)
                {
                    this.ootTC.name = "mOotT";
                    if (this.lifetime < 16)
                    {
                        this.IsSacrificing = true;
                        this.ootTC.name = "Soot";
                    }
                    else
                    {
                        this.IsSacrificing = false;
                    }
                }
                else
                {
                    this.ootTC.name = "sOotT";
                }
            }
            else
            {
                this.ootTC.name = "bOotT";
            }
            if (this.ootGrowth < 16)
            {
                if (!this.IsColonist)
                {
                    if (this.lifetime < 1)
                    {
                        this.IsFading = true;
                    }
                    else
                    {
                        this.lifetime = this.lifetime - 1;
                    }
                }
            }
            else
            {
                this.ootTC.name = "xbOotT";
                if (this.SpawningCykin)
                {
                    if (this.FX1.startColor.a < 0.1f)
                    {

                        {
                            float _1832 = this.FX1.startColor.a + 0.002f;
                            Color _1833 = this.FX1.startColor;
                            _1833.a = _1832;
                            this.FX1.startColor = _1833;
                        }
                    }
                    if (this.FX2.startSize < 1)
                    {
                        this.FX2.startSize = this.FX2.startSize + 0.02f;
                    }
                    else
                    {
                        this.protoCykinGrowth = this.protoCykinGrowth + 1;
                    }
                    if (this.protoCykinGrowth > 15)
                    {
                        GameObject Spawnionaise = ((GameObject) Resources.Load("NPCs/CykinDut", typeof(GameObject))) as GameObject;
                        GameObject _SpawnedObject0 = UnityEngine.Object.Instantiate(Spawnionaise, this.topTF.position, this.topTF.rotation);
                        ((DutCykinAI) _SpawnedObject0.transform.GetChild(0).transform.GetChild(0).transform.GetComponent(typeof(DutCykinAI))).IsNewlyCreated = true;
                        if (this.SpawningCydaz)
                        {
                            ((DutCykinAI) _SpawnedObject0.transform.GetChild(0).transform.GetChild(0).transform.GetComponent(typeof(DutCykinAI))).TypeCydaz = true;
                        }
                        if (this.SpawningCytarg)
                        {
                            ((DutCykinAI) _SpawnedObject0.transform.GetChild(0).transform.GetChild(0).transform.GetComponent(typeof(DutCykinAI))).TypeCytarg = true;
                        }
                        if (this.SpawningCytchau)
                        {
                            ((DutCykinAI) _SpawnedObject0.transform.GetChild(0).transform.GetChild(0).transform.GetComponent(typeof(DutCykinAI))).TypeCytchau = true;
                        }
                        this.SpawningCydaz = false;
                        this.SpawningCytarg = false;
                        this.SpawningCytchau = false;
                        this.SpawningCykin = false;
                        this.protoCykinGrowth = 0;

                        {
                            int _1834 = 0;
                            Color _1835 = this.FX1.startColor;
                            _1835.a = _1834;
                            this.FX1.startColor = _1835;
                        }
                        this.FX2.startSize = 0;
                    }
                }
                else
                {

                    {
                        int _1836 = 0;
                        Color _1837 = this.FX1.startColor;
                        _1837.a = _1836;
                        this.FX1.startColor = _1837;
                    }
                    this.FX2.startSize = 0;
                }
            }
            if (!this.SpawningCykin)
            {
                int randomValueC = Random.Range(0, 32);
                switch (randomValueC)
                {
                    case 0:

                        {
                            float _1838 = 0.5f;
                            Color _1839 = this.FX2.startColor;
                            _1839.r = _1838;
                            this.FX2.startColor = _1839;
                        }

                        {
                            float _1840 = 0.65f;
                            Color _1841 = this.FX2.startColor;
                            _1841.g = _1840;
                            this.FX2.startColor = _1841;
                        }

                        {
                            float _1842 = 0.2f;
                            Color _1843 = this.FX2.startColor;
                            _1843.b = _1842;
                            this.FX2.startColor = _1843;
                        }
                        this.SpawningCydaz = true;
                        this.SpawningCykin = true;
                        break;
                    case 1:

                        {
                            float _1844 = 0.2f;
                            Color _1845 = this.FX2.startColor;
                            _1845.r = _1844;
                            this.FX2.startColor = _1845;
                        }

                        {
                            float _1846 = 0.6f;
                            Color _1847 = this.FX2.startColor;
                            _1847.g = _1846;
                            this.FX2.startColor = _1847;
                        }

                        {
                            float _1848 = 0.2f;
                            Color _1849 = this.FX2.startColor;
                            _1849.b = _1848;
                            this.FX2.startColor = _1849;
                        }
                        this.SpawningCytarg = true;
                        this.SpawningCykin = true;
                        break;
                    case 2:

                        {
                            float _1850 = 0.2f;
                            Color _1851 = this.FX2.startColor;
                            _1851.r = _1850;
                            this.FX2.startColor = _1851;
                        }

                        {
                            float _1852 = 0.65f;
                            Color _1853 = this.FX2.startColor;
                            _1853.g = _1852;
                            this.FX2.startColor = _1853;
                        }

                        {
                            float _1854 = 0.4f;
                            Color _1855 = this.FX2.startColor;
                            _1855.b = _1854;
                            this.FX2.startColor = _1855;
                        }
                        this.SpawningCytchau = true;
                        this.SpawningCykin = true;
                        break;
                }
            }
            this.ootRB.drag = this.ootGrowth * 0.1f;
        }
        else
        {
            if (this.Blur.startColor.a < 0.01f)
            {
                if (this.newColor.a < 0.01f)
                {
                    this.Despawn();
                }
            }
        }
    }

    public virtual void Despawn()
    {
        UnityEngine.Object.Destroy(this.ootTF.parent.gameObject);
        StuffSpawner.TheNPC0805N = StuffSpawner.TheNPC0805N - 1;
    }

    public DutOotController()
    {
        this.aimForce = 0.1f;
        this.hoverForce = 0.0001f;
        this.hoverCurve = new AnimationCurve();
        this.ootSizeCurve = new AnimationCurve();
        this.lifetime = 8;
        this.ootGrowth = 1;
    }

}