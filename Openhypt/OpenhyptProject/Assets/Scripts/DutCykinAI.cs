using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DutCykinAI : MonoBehaviour
{
    public Transform target;
    public Rigidbody CykinRB;
    public Transform CykinTF;
    public Transform CykinPTF;
    public Transform CykinTC;
    public SphereCollider CykinTrig;
    public Transform thisTransform;
    public VehicleDamage DamageScript;
    public WingScript CykinWS;
    public GameObject CykinFXGO;
    public ParticleSystem FX1;
    public ParticleSystem FX2;
    public ParticleSystem FX3;
    public ParticleSystem FX4;
    public float FX2R;
    public float FX2G;
    public float FX2B;
    public float BsC;
    public GameObject OffensePrefab;
    public bool IsNewlyCreated;
    public bool TypeCydaz;
    public bool TypeCytarg;
    public bool TypeCytchau;
    public bool Escaping;
    public bool Transforming;
    public float aimForce;
    public float hoverForce;
    public AnimationCurve hoverCurve;
    public float CykinGrowth;
    public int StrikeNum;
    public LayerMask targetLayers;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Ticker", Random.Range(0.1f, 0.9f), 1);
        this.CykinTF.parent.transform.parent = null;
        if (this.IsNewlyCreated)
        {
            this.DamageScript.RestartFromOne();
        }
        if ((!this.TypeCydaz && !this.TypeCytarg) && !this.TypeCytchau)
        {
            int randomValueC = Random.Range(0, 3);
            switch (randomValueC)
            {
                case 0:

                    {
                        float _1768 = 0.5f;
                        Color _1769 = this.FX2.startColor;
                        _1769.r = _1768;
                        this.FX2.startColor = _1769;
                    }

                    {
                        float _1770 = 0.65f;
                        Color _1771 = this.FX2.startColor;
                        _1771.g = _1770;
                        this.FX2.startColor = _1771;
                    }

                    {
                        float _1772 = 0.2f;
                        Color _1773 = this.FX2.startColor;
                        _1773.b = _1772;
                        this.FX2.startColor = _1773;
                    }
                    this.TypeCydaz = true;
                    this.CykinRB.drag = 0.2f;
                    this.CykinRB.angularDrag = 6;
                    break;
                case 1:

                    {
                        float _1774 = 0.2f;
                        Color _1775 = this.FX2.startColor;
                        _1775.r = _1774;
                        this.FX2.startColor = _1775;
                    }

                    {
                        float _1776 = 0.6f;
                        Color _1777 = this.FX2.startColor;
                        _1777.g = _1776;
                        this.FX2.startColor = _1777;
                    }

                    {
                        float _1778 = 0.2f;
                        Color _1779 = this.FX2.startColor;
                        _1779.b = _1778;
                        this.FX2.startColor = _1779;
                    }
                    this.TypeCytarg = true;
                    this.CykinRB.drag = 0.5f;
                    this.CykinRB.angularDrag = 4;
                    break;
                case 2:

                    {
                        float _1780 = 0.2f;
                        Color _1781 = this.FX2.startColor;
                        _1781.r = _1780;
                        this.FX2.startColor = _1781;
                    }

                    {
                        float _1782 = 0.65f;
                        Color _1783 = this.FX2.startColor;
                        _1783.g = _1782;
                        this.FX2.startColor = _1783;
                    }

                    {
                        float _1784 = 0.4f;
                        Color _1785 = this.FX2.startColor;
                        _1785.b = _1784;
                        this.FX2.startColor = _1785;
                    }
                    this.TypeCytchau = true;
                    this.CykinRB.drag = 0.3f;
                    this.CykinRB.angularDrag = 4;
                    break;
            }
        }
        else
        {
            if (this.TypeCydaz)
            {

                {
                    float _1786 = 0.5f;
                    Color _1787 = this.FX2.startColor;
                    _1787.r = _1786;
                    this.FX2.startColor = _1787;
                }

                {
                    float _1788 = 0.65f;
                    Color _1789 = this.FX2.startColor;
                    _1789.g = _1788;
                    this.FX2.startColor = _1789;
                }

                {
                    float _1790 = 0.2f;
                    Color _1791 = this.FX2.startColor;
                    _1791.b = _1790;
                    this.FX2.startColor = _1791;
                }
                this.CykinRB.drag = 0.2f;
                this.CykinRB.angularDrag = 6;
            }
            if (this.TypeCytarg)
            {

                {
                    float _1792 = 0.2f;
                    Color _1793 = this.FX2.startColor;
                    _1793.r = _1792;
                    this.FX2.startColor = _1793;
                }

                {
                    float _1794 = 0.6f;
                    Color _1795 = this.FX2.startColor;
                    _1795.g = _1794;
                    this.FX2.startColor = _1795;
                }

                {
                    float _1796 = 0.2f;
                    Color _1797 = this.FX2.startColor;
                    _1797.b = _1796;
                    this.FX2.startColor = _1797;
                }
                this.CykinRB.drag = 0.5f;
                this.CykinRB.angularDrag = 4;
            }
            if (this.TypeCytchau)
            {

                {
                    float _1798 = 0.2f;
                    Color _1799 = this.FX2.startColor;
                    _1799.r = _1798;
                    this.FX2.startColor = _1799;
                }

                {
                    float _1800 = 0.65f;
                    Color _1801 = this.FX2.startColor;
                    _1801.g = _1800;
                    this.FX2.startColor = _1801;
                }

                {
                    float _1802 = 0.4f;
                    Color _1803 = this.FX2.startColor;
                    _1803.b = _1802;
                    this.FX2.startColor = _1803;
                }
                this.CykinRB.drag = 0.3f;
                this.CykinRB.angularDrag = 4;
            }
        }
        StuffSpawner.TheNPC009N = StuffSpawner.TheNPC009N + 1;
        yield return new WaitForSeconds(1);
        this.IsNewlyCreated = false;
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        this.thisTransform.position = this.CykinTF.position;
        if (this.IsNewlyCreated)
        {
            return;
        }
        if (this.Transforming)
        {

            {
                float _1804 = this.FX1.startColor.a - 0.005f;
                Color _1805 = this.FX1.startColor;
                _1805.a = _1804;
                this.FX1.startColor = _1805;
            }

            {
                float _1806 = this.FX2.startColor.a - 0.005f;
                Color _1807 = this.FX2.startColor;
                _1807.a = _1806;
                this.FX2.startColor = _1807;
            }

            {
                float _1808 = this.FX3.startColor.a - 0.005f;
                Color _1809 = this.FX3.startColor;
                _1809.a = _1808;
                this.FX3.startColor = _1809;
            }

            {
                float _1810 = this.FX4.startColor.a - 0.005f;
                Color _1811 = this.FX4.startColor;
                _1811.a = _1810;
                this.FX4.startColor = _1811;
            }
            if (this.FX4.startColor.a == 0)
            {
                this.Despawn();
            }
        }
        else
        {
            this.FX1.startSize = 0.03f + (this.CykinGrowth * 0.028f);
            this.FX2.startSize = 1 + (this.CykinGrowth * 0.28f);
            this.FX3.startSize = 1 + (this.CykinGrowth * 0.28f);
            this.FX4.startSize = 0.6f + (this.CykinGrowth * 0.09f);
            this.BsC = this.CykinGrowth * 0.08f;
            if (this.FX3.startColor.a < this.BsC)
            {
                if (this.FX3.startColor.a < 0.25f)
                {

                    {
                        float _1812 = this.FX3.startColor.a + 0.002f;
                        Color _1813 = this.FX3.startColor;
                        _1813.a = _1812;
                        this.FX3.startColor = _1813;
                    }
                }
            }
            else
            {

                {
                    float _1814 = this.FX3.startColor.a - 0.002f;
                    Color _1815 = this.FX3.startColor;
                    _1815.a = _1814;
                    this.FX3.startColor = _1815;
                }
            }
            if (this.CykinGrowth > 2)
            {

                {
                    float _1816 = this.FX4.startColor.a + 0.01f;
                    Color _1817 = this.FX4.startColor;
                    _1817.a = _1816;
                    this.FX4.startColor = _1817;
                }
            }
            else
            {

                {
                    float _1818 = this.FX4.startColor.a - 0.01f;
                    Color _1819 = this.FX4.startColor;
                    _1819.a = _1818;
                    this.FX4.startColor = _1819;
                }
            }
            this.FX4.emissionRate = this.CykinGrowth * 8;
            if (this.CykinTrig.radius < 32)
            {
                this.CykinTrig.radius = this.CykinTrig.radius + 0.1f;
            }
            if (this.target)
            {
                this.CykinRB.AddForce(this.transform.forward * Random.Range(0.0005f, 0.0015f));
                if (!this.Escaping)
                {
                    this.CykinRB.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * this.aimForce, this.thisTransform.forward * 0.3f);
                    this.CykinRB.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * -this.aimForce, -this.thisTransform.forward * 0.3f);
                }
                else
                {
                    this.CykinRB.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * this.aimForce, -this.thisTransform.forward * 0.3f);
                    this.CykinRB.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * -this.aimForce, this.thisTransform.forward * 0.3f);
                }
                this.CykinRB.AddTorque(this.CykinTF.up * Random.Range(-0.0001f, 0.0001f));
                this.CykinRB.AddTorque(this.CykinTF.right * Random.Range(-0.0001f, 0.0001f));
                this.CykinRB.AddTorque(this.CykinTF.forward * Random.Range(-0.0001f, 0.0001f));
            }
            else
            {
                this.CykinRB.AddForce(this.transform.forward * Random.Range(0.0005f, 0.0015f));
                this.CykinRB.AddTorque(this.CykinTF.up * Random.Range(-0.0001f, 0.0001f));
                this.CykinRB.AddTorque(this.CykinTF.right * Random.Range(-0.0001f, 0.0001f));
                this.CykinRB.AddTorque(this.CykinTF.forward * Random.Range(-0.0001f, 0.0001f));
            }
            if (Physics.Raycast(this.thisTransform.position, Vector3.down, out hit, 2000, (int) this.targetLayers))
            {
                this.hoverForce = this.hoverCurve.Evaluate(hit.distance);
                this.CykinRB.AddForce((Vector3.up * this.hoverForce) * 0.005f);
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (this.Transforming)
        {
            return;
        }
        string ON = other.name;
        Transform OT = other.transform;
        if (ON.Contains("TC"))
        {
            if (OT != this.CykinTC)
            {
                this.CykinTrig.radius = 0.1f;
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

    public virtual void Ticker()
    {
        if (this.Transforming)
        {
            return;
        }
        if (this.target)
        {
            if (this.TypeCydaz)
            {
                if (this.StrikeNum < 1)
                {
                    this.StrikeNum = (int) (this.CykinGrowth * 1.5f);
                }
            }
            if (this.TypeCytarg)
            {
                if (this.StrikeNum < 1)
                {
                    this.StrikeNum = (int) (this.CykinGrowth * 2);
                }
            }
            if (this.TypeCytchau)
            {
                if (this.StrikeNum < 1)
                {
                    this.StrikeNum = (int) (this.CykinGrowth * 3);
                }
                if (Vector3.Distance(this.thisTransform.position, this.target.position) < (2 + (this.CykinGrowth * 0.4f)))
                {
                    this.StartCoroutine(this.Escape());
                }
            }
            this.StrikeNum = this.StrikeNum - 1;
            if (this.StrikeNum < 1)
            {
                if (Vector3.Distance(this.thisTransform.position, this.target.position) < (1.5f + (this.CykinGrowth * 0.4f)))
                {
                    if (this.target.name.Contains("TC"))
                    {
                        GameObject _SpawnedObject1 = UnityEngine.Object.Instantiate(this.OffensePrefab, this.thisTransform.position, this.thisTransform.rotation);
                        _SpawnedObject1.GetComponent<Rigidbody>().velocity = this.CykinRB.velocity;
                        ((MissileScript) _SpawnedObject1.transform.GetComponent(typeof(MissileScript))).target = this.target;
                        this.StartCoroutine(this.TCResetter());
                    }
                }
            }
        }
        if (this.FX1.startColor.a < 0.1f)
        {

            {
                float _1820 = this.FX1.startColor.a + 0.002f;
                Color _1821 = this.FX1.startColor;
                _1821.a = _1820;
                this.FX1.startColor = _1821;
            }
        }
        if (this.FX2.startSize < 1)
        {
            this.FX2.startSize = this.FX2.startSize + 0.02f;
        }
        this.CykinGrowth = this.DamageScript.Health;
        if (this.CykinGrowth < 3)
        {
            this.CykinTC.name = "tTC0";
        }
        else
        {
            this.CykinTC.name = "sTC0";
            if (this.CykinGrowth > 4)
            {
                this.Transforming = true;
                GameObject Spawnionaise = ((GameObject) Resources.Load("NPCs/TurgkinDut", typeof(GameObject))) as GameObject;
                GameObject _SpawnedObject3 = UnityEngine.Object.Instantiate(Spawnionaise, this.thisTransform.position, this.thisTransform.rotation);
                _SpawnedObject3.transform.GetChild(0).GetComponent<Rigidbody>().velocity = this.CykinRB.velocity * 1;
                ((DutTurgkinAI) _SpawnedObject3.transform.GetChild(0).transform.GetChild(0).transform.GetComponent(typeof(DutTurgkinAI))).IsNewlyCreated = true;
                if (this.TypeCydaz)
                {
                    ((DutTurgkinAI) _SpawnedObject3.transform.GetChild(0).transform.GetChild(0).transform.GetComponent(typeof(DutTurgkinAI))).TypeCydaz = true;
                }
                if (this.TypeCytarg)
                {
                    ((DutTurgkinAI) _SpawnedObject3.transform.GetChild(0).transform.GetChild(0).transform.GetComponent(typeof(DutTurgkinAI))).TypeCytarg = true;
                }
                if (this.TypeCytchau)
                {
                    ((DutTurgkinAI) _SpawnedObject3.transform.GetChild(0).transform.GetChild(0).transform.GetComponent(typeof(DutTurgkinAI))).TypeCytchau = true;
                }
                StuffSpawner.TheNPC009N = StuffSpawner.TheNPC009N - 1;
                this.CykinPTF.parent = _SpawnedObject3.transform.GetChild(0).transform;
                UnityEngine.Object.Destroy(this.CykinRB);
                UnityEngine.Object.Destroy(this.CykinWS);
                UnityEngine.Object.Destroy(this.CykinTrig);
                UnityEngine.Object.Destroy(this.DamageScript);
                UnityEngine.Object.Destroy(this.CykinTC.gameObject);
            }
        }
    }

    public virtual IEnumerator TCResetter()
    {
        this.CykinTC.name = "TC0a";
        yield return new WaitForSeconds(6);
        if (this.CykinTC)
        {
            this.CykinTC.name = "TC0";
        }
    }

    public virtual IEnumerator Escape()
    {
        this.Escaping = true;
        yield return new WaitForSeconds(4);
        this.Escaping = false;
    }

    public virtual void Despawn()
    {
        StuffSpawner.TheNPC009N = StuffSpawner.TheNPC009N - 1;
        UnityEngine.Object.Destroy(this.CykinPTF.gameObject);
    }

    public virtual void Kill()
    {
        StuffSpawner.TheNPC009N = StuffSpawner.TheNPC009N - 1;
        this.DamageScript.DestroySequence();
    }

    public DutCykinAI()
    {
        this.FX2R = 0.9f;
        this.FX2G = 0.9f;
        this.FX2B = 0.9f;
        this.aimForce = 0.1f;
        this.hoverForce = 0.0001f;
        this.hoverCurve = new AnimationCurve();
        this.CykinGrowth = 1;
        this.StrikeNum = 1;
    }

}