using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DutTurgkinAI : MonoBehaviour
{
    public Transform target;
    public string RememberedName;
    public Transform HIdleTarget;
    public Transform TurgkinAIAnchor;
    public Rigidbody TurgkinRB;
    public Transform TurgkinTF;
    public Transform TurgkinTC;
    public SphereCollider TurgkinTrig;
    public Transform thisTransform;
    public Transform TurgkinPTF;
    public VehicleDamage DamageScript;
    public ParticleSystem FX1;
    public ParticleSystem FX2;
    public Transform RHand;
    public Transform RHandAim1;
    public Transform RHandIdle1;
    public Transform RHandIdle2;
    public Transform RHandSwipe1;
    public bool RHandReadySwipe1;
    public int RHandSwiping1;
    public bool RHandReadyJab1;
    public int RHandJabbing1;
    public int RX;
    public int RY;
    public int RZ;
    public AnimationCurve RHandSwipe1PosCurve;
    public AnimationCurve RHandSwipe1RotCurve;
    public AnimationCurve RHandJabPosCurve;
    public AnimationCurve RHandJabRotCurve;
    public AnimationCurve FX2Curve;
    public float FX1R;
    public float FX1G;
    public float FX1B;
    public float LifeForce;
    public float Vel;
    public float Dist;
    public int PissedAtTC0;
    public int PissedAtTC1;
    public int PissedAtTC2;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public GameObject JabFXPrefab;
    public bool JabFXOnce;
    public GameObject JabMeleePrefab;
    public bool JabMeleeOnce;
    public GameObject SwingFXPrefab;
    public bool SwingFXOnce;
    public GameObject SwingMeleePrefab;
    public bool SwingMeleeOnce;
    public PersonGunScript Weapon;
    public Texture2D GradTexUp;
    public Texture2D GradTexDown;
    public Color newColor;
    public MeshRenderer TurgHandModelR;
    public MeshRenderer TurgModelR;
    public MeshRenderer TurgModelFragR;
    public AnimationCurve TurgModelFragRCurve;
    public MeshRenderer TurgRangedModelR;
    public MeshRenderer TurgRangedModelFragR;
    public AnimationCurve TurgRangedModelFragRCurve;
    public int TurgRangedMorphLevel;
    public MeshRenderer TurgMeleeModelR;
    public MeshRenderer TurgMeleeModelFragR;
    public AnimationCurve TurgMeleeModelFragRCurve;
    public int TurgMeleeMorphLevel;
    public bool UsingMelee;
    public bool UsingRanged;
    public bool IsNewlyCreated;
    public bool TypeCydaz;
    public bool TypeCytarg;
    public bool TypeCytchau;
    public bool Escaping;
    public bool KeepDistance;
    public int Interest;
    public int PissedOffLevel;
    public int RelaxedLevel;
    public int StressLevel;
    public float aimForce;
    public float dirForce;
    public AnimationCurve dirForceCurve;
    public AnimationCurve dirForceCurveKD;
    public float hoverForce;
    public AnimationCurve hoverCurve;
    public bool Turning;
    public bool Obstacle;
    public int Stuckage;
    public bool Stuck;
    public LayerMask targetLayers;
    public LayerMask targetLayersM;
    private Quaternion NewRotation;
    public virtual void Start()
    {
        this.InvokeRepeating("Ticker", Random.Range(0.1f, 0.9f), 1);
        this.TurgkinTF.parent.transform.parent = null;
        this.SwingMeleeOnce = false;
        this.RelaxedLevel = 8;
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
                        float _1856 = 0.5f;
                        Color _1857 = this.FX1.startColor;
                        _1857.r = _1856;
                        this.FX1.startColor = _1857;
                    }

                    {
                        float _1858 = 0.65f;
                        Color _1859 = this.FX1.startColor;
                        _1859.g = _1858;
                        this.FX1.startColor = _1859;
                    }

                    {
                        float _1860 = 0.2f;
                        Color _1861 = this.FX1.startColor;
                        _1861.b = _1860;
                        this.FX1.startColor = _1861;
                    }
                    this.TurgRangedModelR.material.color = new Color(0.5f, 0.65f, 0.2f);
                    this.TurgMeleeModelR.material.color = new Color(0.5f, 0.65f, 0.2f);
                    this.TypeCydaz = true;
                    break;
                case 1:

                    {
                        float _1862 = 0.2f;
                        Color _1863 = this.FX1.startColor;
                        _1863.r = _1862;
                        this.FX1.startColor = _1863;
                    }

                    {
                        float _1864 = 0.6f;
                        Color _1865 = this.FX1.startColor;
                        _1865.g = _1864;
                        this.FX1.startColor = _1865;
                    }

                    {
                        float _1866 = 0.2f;
                        Color _1867 = this.FX1.startColor;
                        _1867.b = _1866;
                        this.FX1.startColor = _1867;
                    }
                    this.TurgRangedModelR.material.color = new Color(0.2f, 0.6f, 0.2f);
                    this.TurgMeleeModelR.material.color = new Color(0.2f, 0.6f, 0.2f);
                    this.TypeCytarg = true;
                    break;
                case 2:

                    {
                        float _1868 = 0.2f;
                        Color _1869 = this.FX1.startColor;
                        _1869.r = _1868;
                        this.FX1.startColor = _1869;
                    }

                    {
                        float _1870 = 0.65f;
                        Color _1871 = this.FX1.startColor;
                        _1871.g = _1870;
                        this.FX1.startColor = _1871;
                    }

                    {
                        float _1872 = 0.4f;
                        Color _1873 = this.FX1.startColor;
                        _1873.b = _1872;
                        this.FX1.startColor = _1873;
                    }
                    this.TurgRangedModelR.material.color = new Color(0.2f, 0.65f, 0.4f);
                    this.TurgMeleeModelR.material.color = new Color(0.2f, 0.65f, 0.4f);
                    this.TypeCytchau = true;
                    break;
            }
        }
        else
        {
            if (this.TypeCydaz)
            {

                {
                    float _1874 = 0.5f;
                    Color _1875 = this.FX1.startColor;
                    _1875.r = _1874;
                    this.FX1.startColor = _1875;
                }

                {
                    float _1876 = 0.65f;
                    Color _1877 = this.FX1.startColor;
                    _1877.g = _1876;
                    this.FX1.startColor = _1877;
                }

                {
                    float _1878 = 0.2f;
                    Color _1879 = this.FX1.startColor;
                    _1879.b = _1878;
                    this.FX1.startColor = _1879;
                }
                this.TurgRangedModelR.material.color = new Color(0.5f, 0.65f, 0.2f);
                this.TurgMeleeModelR.material.color = new Color(0.5f, 0.65f, 0.2f);
            }
            if (this.TypeCytarg)
            {

                {
                    float _1880 = 0.2f;
                    Color _1881 = this.FX1.startColor;
                    _1881.r = _1880;
                    this.FX1.startColor = _1881;
                }

                {
                    float _1882 = 0.6f;
                    Color _1883 = this.FX1.startColor;
                    _1883.g = _1882;
                    this.FX1.startColor = _1883;
                }

                {
                    float _1884 = 0.2f;
                    Color _1885 = this.FX1.startColor;
                    _1885.b = _1884;
                    this.FX1.startColor = _1885;
                }
                this.TurgRangedModelR.material.color = new Color(0.2f, 0.6f, 0.2f);
                this.TurgMeleeModelR.material.color = new Color(0.2f, 0.6f, 0.2f);
            }
            if (this.TypeCytchau)
            {

                {
                    float _1886 = 0.2f;
                    Color _1887 = this.FX1.startColor;
                    _1887.r = _1886;
                    this.FX1.startColor = _1887;
                }

                {
                    float _1888 = 0.65f;
                    Color _1889 = this.FX1.startColor;
                    _1889.g = _1888;
                    this.FX1.startColor = _1889;
                }

                {
                    float _1890 = 0.4f;
                    Color _1891 = this.FX1.startColor;
                    _1891.b = _1890;
                    this.FX1.startColor = _1891;
                }
                this.TurgRangedModelR.material.color = new Color(0.2f, 0.65f, 0.4f);
                this.TurgMeleeModelR.material.color = new Color(0.2f, 0.65f, 0.4f);
            }
        }
        this.TurgModelFragR.material.SetTextureOffset("_SliceGuide", new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f)));
        StuffSpawner.TheNPC0091N = StuffSpawner.TheNPC0091N + 1;
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        this.thisTransform.position = this.TurgkinAIAnchor.position;
        this.thisTransform.rotation = this.TurgkinAIAnchor.rotation;
        if (this.target)
        {
            this.Dist = Vector3.Distance(this.thisTransform.position, this.target.position);
        }
        Vector3 localV = this.thisTransform.InverseTransformDirection(this.TurgkinRB.velocity);
        this.Vel = this.TurgkinRB.velocity.magnitude;
        float VelC = Mathf.Clamp(this.Vel, 0.5f, 5);
        float VelC2 = Mathf.Clamp(localV.z, 1, 16);
        float VelC2Div = VelC2 / 4;
        this.LifeForce = this.DamageScript.Health;
        if (this.LifeForce < 1)
        {
            if (this.FX1.startColor.a < (this.LifeForce * 0.3f))
            {

                {
                    float _1892 = this.FX1.startColor.a + 0.002f;
                    Color _1893 = this.FX1.startColor;
                    _1893.a = _1892;
                    this.FX1.startColor = _1893;
                }
            }
            else
            {

                {
                    float _1894 = this.FX1.startColor.a - 0.002f;
                    Color _1895 = this.FX1.startColor;
                    _1895.a = _1894;
                    this.FX1.startColor = _1895;
                }
            }
        }
        else
        {
            if (this.FX1.startColor.a < 0.3f)
            {

                {
                    float _1896 = this.FX1.startColor.a + 0.002f;
                    Color _1897 = this.FX1.startColor;
                    _1897.a = _1896;
                    this.FX1.startColor = _1897;
                }
            }
        }
        this.FX2.emissionRate = this.FX2Curve.Evaluate(this.LifeForce);
        this.TurgModelFragR.material.SetFloat("_SliceAmount", this.TurgModelFragRCurve.Evaluate(this.LifeForce));
        this.TurgRangedModelFragR.material.SetFloat("_SliceAmount", this.TurgRangedModelFragRCurve.Evaluate(this.TurgRangedMorphLevel));
        this.TurgMeleeModelFragR.material.SetFloat("_SliceAmount", this.TurgMeleeModelFragRCurve.Evaluate(this.TurgMeleeMorphLevel));
        if (this.LifeForce > 8)
        {
            this.TurgModelR.enabled = true;
        }
        else
        {
            this.TurgModelR.enabled = false;
        }
        if (this.TurgkinTrig.radius < 32)
        {
            this.TurgkinTrig.radius = this.TurgkinTrig.radius + Random.Range(0.05f, 0.5f);
        }
        Debug.DrawRay(this.thisTransform.position + (this.TurgkinTF.up * -1), -this.TurgkinTF.up * VelC2, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (this.TurgkinTF.up * -1), -this.TurgkinTF.up, out hit, VelC2, (int) this.targetLayers))
        {
            this.Obstacle = true;
        }
        Debug.DrawRay(this.thisTransform.position + (this.TurgkinTF.up * -0.5f), -this.TurgkinTF.up * VelC2, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (this.TurgkinTF.up * -0.5f), -this.TurgkinTF.up, out hit, VelC2, (int) this.targetLayers))
        {
            if (!this.Stuck)
            {
                this.TurgkinRB.AddForce(this.transform.forward * -0.1f);
            }
            else
            {
                this.TurgkinRB.AddTorque(this.TurgkinTF.forward * 0.01f);
                this.Turning = true;
            }
        }
        else
        {
            if (this.Stuck)
            {
                this.TurgkinRB.AddTorque(this.TurgkinTF.forward * 0.01f);
                this.Turning = true;
            }
        }
        float LeftDist = 64;
        float RightDist = 64;
        float UpDist = 64;
        float DownDist = 64;
        Vector3 newRot = (((this.TurgkinTF.up * -VelC2) * 0.5f) + (this.TurgkinTF.right * -0.5f)).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.TurgkinTF.up * -0.3f), newRot * VelC2, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (this.TurgkinTF.up * -0.3f), newRot, out hit, VelC2, (int) this.targetLayers))
        {
            LeftDist = (int) hit.distance;
            this.Turning = true;
        }
        newRot = (((this.TurgkinTF.up * -VelC2) * 0.5f) + (this.TurgkinTF.right * 0.5f)).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.TurgkinTF.up * -0.3f), newRot * VelC2, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (this.TurgkinTF.up * -0.3f), newRot, out hit, VelC2, (int) this.targetLayers))
        {
            RightDist = (int) hit.distance;
            this.Turning = true;
        }
        newRot = (((this.TurgkinTF.up * -VelC2) * 0.5f) + (this.TurgkinTF.forward * 0.5f)).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.TurgkinTF.up * -0.3f), newRot * VelC2, Color.blue);
        if (Physics.Raycast(this.thisTransform.position + (this.TurgkinTF.up * -0.3f), newRot, out hit2, VelC2, (int) this.targetLayers))
        {
            UpDist = (int) hit2.distance;
            this.Turning = true;
        }
        newRot = (((this.TurgkinTF.up * -VelC2) * 0.5f) + (this.TurgkinTF.forward * -0.5f)).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.TurgkinTF.up * -0.3f), newRot * VelC2, Color.red);
        if (Physics.Raycast(this.thisTransform.position + (this.TurgkinTF.up * -0.3f), newRot, out hit2, VelC2, (int) this.targetLayers))
        {
            DownDist = (int) hit2.distance;
            this.Turning = true;
        }
        if (RightDist > LeftDist)
        {
            this.TurgkinRB.AddTorque(this.TurgkinTF.forward * 0.01f);
        }
        if (RightDist < LeftDist)
        {
            this.TurgkinRB.AddTorque(this.TurgkinTF.forward * -0.01f);
        }
        if (DownDist > UpDist)
        {
            this.TurgkinRB.AddTorque(this.TurgkinTF.right * 0.01f);
        }
        if (DownDist < UpDist)
        {
            this.TurgkinRB.AddTorque(this.TurgkinTF.right * -0.01f);
        }
        if (this.target)
        {
            if (this.PissedOffLevel > 4)
            {
                if (!this.RHandReadySwipe1 && !this.RHandReadyJab1)
                {
                    this.NewRotation = Quaternion.LookRotation(this.target.position - this.RHand.position);
                    this.RHand.rotation = Quaternion.RotateTowards(this.RHand.rotation, this.NewRotation, 4);

                    {
                        float _1898 = Mathf.Lerp(this.RHand.position.x, this.RHandAim1.position.x, 0.05f);
                        Vector3 _1899 = this.RHand.position;
                        _1899.x = _1898;
                        this.RHand.position = _1899;
                    }

                    {
                        float _1900 = Mathf.Lerp(this.RHand.position.y, this.RHandAim1.position.y, 0.05f);
                        Vector3 _1901 = this.RHand.position;
                        _1901.y = _1900;
                        this.RHand.position = _1901;
                    }

                    {
                        float _1902 = Mathf.Lerp(this.RHand.position.z, this.RHandAim1.position.z, 0.05f);
                        Vector3 _1903 = this.RHand.position;
                        _1903.z = _1902;
                        this.RHand.position = _1903;
                    }
                }
                if (this.RHandSwiping1 == 0)
                {
                    if (this.RHandReadySwipe1)
                    {

                        {
                            float _1904 = Mathf.Lerp(this.RHand.position.x, this.RHandSwipe1.position.x, 0.1f);
                            Vector3 _1905 = this.RHand.position;
                            _1905.x = _1904;
                            this.RHand.position = _1905;
                        }

                        {
                            float _1906 = Mathf.Lerp(this.RHand.position.y, this.RHandSwipe1.position.y, 0.1f);
                            Vector3 _1907 = this.RHand.position;
                            _1907.y = _1906;
                            this.RHand.position = _1907;
                        }

                        {
                            float _1908 = Mathf.Lerp(this.RHand.position.z, this.RHandSwipe1.position.z, 0.1f);
                            Vector3 _1909 = this.RHand.position;
                            _1909.z = _1908;
                            this.RHand.position = _1909;
                        }
                        this.RHand.localRotation = Quaternion.Slerp(this.RHand.localRotation, this.RHandSwipe1.localRotation, 0.1f);
                        this.RHandSwipe1.LookAt(this.target);
                        this.RHandSwipe1.Rotate(this.RX, this.RY, this.RZ);
                        if (Vector3.Distance(this.RHandSwipe1.position, this.RHand.position) < 0.1f)
                        {
                            this.RHand.Rotate(0, Random.Range(-20, 20), 0);
                            this.RHandReadySwipe1 = false;
                            this.RHandSwiping1 = 1;
                        }
                    }
                }
                else
                {
                    this.RHandSwiping1 = this.RHandSwiping1 + 1;
                    this.RHand.position = this.RHand.position + (this.RHand.forward * this.RHandSwipe1PosCurve.Evaluate(this.RHandSwiping1));
                    this.RHand.position = this.RHand.position - ((this.RHand.up * this.RHandSwipe1PosCurve.Evaluate(this.RHandSwiping1)) * 0.5f);
                    this.RHand.Rotate(this.RHandSwipe1RotCurve.Evaluate(this.RHandSwiping1), 0, 0);
                    this.TurgkinRB.AddForce((this.transform.forward * this.RHandSwipe1RotCurve.Evaluate(this.RHandSwiping1)) * 0.01f);
                    this.TurgkinRB.AddTorque((this.TurgkinTF.forward * this.RHandSwipe1PosCurve.Evaluate(this.RHandSwiping1)) * -0.05f);
                    if (!this.SwingFXOnce)
                    {
                        UnityEngine.Object.Instantiate(this.SwingFXPrefab, this.RHand.position, Quaternion.identity);
                        this.SwingFXOnce = true;
                    }
                    if (this.RHandSwiping1 > 1)
                    {
                        if (this.RHandSwiping1 < 9)
                        {
                            if (!this.SwingMeleeOnce)
                            {
                                Debug.DrawRay(this.RHand.position, this.RHand.up * 1.1f, Color.green);
                                Debug.DrawRay(this.RHand.position + (this.RHand.forward * -0.3f), this.RHand.up * 1.1f, Color.green);
                                Debug.DrawRay(this.RHand.position + (this.RHand.forward * 0.3f), this.RHand.up * 1.1f, Color.green);
                                if ((Physics.Raycast(this.RHand.position, this.RHand.up, out hit, 1.1f) || Physics.Raycast(this.RHand.position + (this.RHand.forward * -0.3f), this.RHand.up, out hit, 1.1f)) || Physics.Raycast(this.RHand.position + (this.RHand.forward * 0.3f), this.RHand.up, out hit, 1.1f, (int) this.targetLayers))
                                {
                                    UnityEngine.Object.Instantiate(this.SwingMeleePrefab, hit.point, Quaternion.identity);
                                    this.SwingMeleeOnce = true;
                                }
                            }
                        }
                        if (this.RHandSwiping1 > 16)
                        {
                            this.RHandSwiping1 = 0;
                            this.SwingMeleeOnce = false;
                            this.SwingFXOnce = false;
                        }
                    }
                }
                if (this.RHandJabbing1 == 0)
                {
                    if (this.RHandReadyJab1)
                    {

                        {
                            float _1910 = Mathf.Lerp(this.RHand.position.x, this.RHandSwipe1.position.x, 0.1f);
                            Vector3 _1911 = this.RHand.position;
                            _1911.x = _1910;
                            this.RHand.position = _1911;
                        }

                        {
                            float _1912 = Mathf.Lerp(this.RHand.position.y, this.RHandSwipe1.position.y, 0.1f);
                            Vector3 _1913 = this.RHand.position;
                            _1913.y = _1912;
                            this.RHand.position = _1913;
                        }

                        {
                            float _1914 = Mathf.Lerp(this.RHand.position.z, this.RHandSwipe1.position.z, 0.1f);
                            Vector3 _1915 = this.RHand.position;
                            _1915.z = _1914;
                            this.RHand.position = _1915;
                        }
                        this.RHand.localRotation = Quaternion.Slerp(this.RHand.localRotation, this.RHandSwipe1.localRotation, 0.1f);
                        this.RHandSwipe1.LookAt(this.target);
                        if (Vector3.Distance(this.RHandSwipe1.position, this.RHand.position) < 0.05f)
                        {
                            this.RHandReadyJab1 = false;
                            this.RHandJabbing1 = 1;
                        }
                    }
                }
                else
                {
                    this.RHandJabbing1 = this.RHandJabbing1 + 1;
                    this.RHand.position = this.RHand.position + (this.RHand.forward * this.RHandJabPosCurve.Evaluate(this.RHandJabbing1));
                    this.RHand.Rotate(0, -this.RHandJabRotCurve.Evaluate(this.RHandJabbing1) / 2, 0);
                    this.TurgkinRB.AddForce((this.transform.forward * this.RHandSwipe1RotCurve.Evaluate(this.RHandJabbing1)) * 0.01f);
                    this.TurgkinRB.AddTorque((this.TurgkinTF.forward * this.RHandJabPosCurve.Evaluate(this.RHandJabbing1)) * -0.05f);
                    if (!this.JabFXOnce)
                    {
                        UnityEngine.Object.Instantiate(this.JabFXPrefab, this.RHand.position, Quaternion.identity);
                        this.JabFXOnce = true;
                    }
                    if (this.RHandJabbing1 > 1)
                    {
                        if (this.RHandJabbing1 < 9)
                        {
                            if (!this.JabMeleeOnce)
                            {
                                Debug.DrawRay(this.RHand.position, this.RHand.forward * 0.5f, Color.green);
                                if (Physics.Raycast(this.RHand.position, this.RHand.forward, out hit, 0.5f, (int) this.targetLayers))
                                {
                                    UnityEngine.Object.Instantiate(this.JabMeleePrefab, hit.point, Quaternion.identity);
                                    this.JabMeleeOnce = true;
                                }
                            }
                        }
                        if (this.RHandJabbing1 > 12)
                        {
                            this.RHandJabbing1 = 0;
                            this.JabMeleeOnce = false;
                            this.JabFXOnce = false;
                        }
                    }
                }
            }
            else
            {
                if (this.RelaxedLevel < 8)
                {

                    {
                        float _1916 = Mathf.Lerp(this.RHand.position.x, this.RHandIdle2.position.x, 0.05f);
                        Vector3 _1917 = this.RHand.position;
                        _1917.x = _1916;
                        this.RHand.position = _1917;
                    }

                    {
                        float _1918 = Mathf.Lerp(this.RHand.position.y, this.RHandIdle2.position.y, 0.05f);
                        Vector3 _1919 = this.RHand.position;
                        _1919.y = _1918;
                        this.RHand.position = _1919;
                    }

                    {
                        float _1920 = Mathf.Lerp(this.RHand.position.z, this.RHandIdle2.position.z, 0.05f);
                        Vector3 _1921 = this.RHand.position;
                        _1921.z = _1920;
                        this.RHand.position = _1921;
                    }

                    {
                        float _1922 = Mathf.Lerp(this.RHand.localRotation.x, this.RHandIdle2.localRotation.x, 0.1f);
                        Quaternion _1923 = this.RHand.localRotation;
                        _1923.x = _1922;
                        this.RHand.localRotation = _1923;
                    }

                    {
                        float _1924 = Mathf.Lerp(this.RHand.localRotation.y, this.RHandIdle2.localRotation.y, 0.1f);
                        Quaternion _1925 = this.RHand.localRotation;
                        _1925.y = _1924;
                        this.RHand.localRotation = _1925;
                    }

                    {
                        float _1926 = Mathf.Lerp(this.RHand.localRotation.z, this.RHandIdle2.localRotation.z, 0.1f);
                        Quaternion _1927 = this.RHand.localRotation;
                        _1927.z = _1926;
                        this.RHand.localRotation = _1927;
                    }
                }
                else
                {

                    {
                        float _1928 = Mathf.Lerp(this.RHand.position.x, this.RHandIdle1.position.x, 0.05f);
                        Vector3 _1929 = this.RHand.position;
                        _1929.x = _1928;
                        this.RHand.position = _1929;
                    }

                    {
                        float _1930 = Mathf.Lerp(this.RHand.position.y, this.RHandIdle1.position.y, 0.05f);
                        Vector3 _1931 = this.RHand.position;
                        _1931.y = _1930;
                        this.RHand.position = _1931;
                    }

                    {
                        float _1932 = Mathf.Lerp(this.RHand.position.z, this.RHandIdle1.position.z, 0.05f);
                        Vector3 _1933 = this.RHand.position;
                        _1933.z = _1932;
                        this.RHand.position = _1933;
                    }

                    {
                        float _1934 = Mathf.Lerp(this.RHand.localRotation.x, this.RHandIdle1.localRotation.x, 0.1f);
                        Quaternion _1935 = this.RHand.localRotation;
                        _1935.x = _1934;
                        this.RHand.localRotation = _1935;
                    }

                    {
                        float _1936 = Mathf.Lerp(this.RHand.localRotation.y, this.RHandIdle1.localRotation.y, 0.1f);
                        Quaternion _1937 = this.RHand.localRotation;
                        _1937.y = _1936;
                        this.RHand.localRotation = _1937;
                    }

                    {
                        float _1938 = Mathf.Lerp(this.RHand.localRotation.z, this.RHandIdle1.localRotation.z, 0.1f);
                        Quaternion _1939 = this.RHand.localRotation;
                        _1939.z = _1938;
                        this.RHand.localRotation = _1939;
                    }
                }
            }
            if (this.KeepDistance)
            {
                this.TurgkinRB.AddForce(this.transform.forward * this.dirForceCurveKD.Evaluate(this.Dist / VelC2Div));
            }
            else
            {
                this.TurgkinRB.AddForce(this.transform.forward * this.dirForceCurve.Evaluate(this.Dist / VelC2Div));
            }
            this.TurgkinRB.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * this.aimForce, this.thisTransform.forward * 3);
            this.TurgkinRB.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * -this.aimForce, -this.thisTransform.forward * 3);
        }
        else
        {
            if (this.RelaxedLevel < 8)
            {

                {
                    float _1940 = Mathf.Lerp(this.RHand.position.x, this.RHandIdle2.position.x, 0.05f);
                    Vector3 _1941 = this.RHand.position;
                    _1941.x = _1940;
                    this.RHand.position = _1941;
                }

                {
                    float _1942 = Mathf.Lerp(this.RHand.position.y, this.RHandIdle2.position.y, 0.05f);
                    Vector3 _1943 = this.RHand.position;
                    _1943.y = _1942;
                    this.RHand.position = _1943;
                }

                {
                    float _1944 = Mathf.Lerp(this.RHand.position.z, this.RHandIdle2.position.z, 0.05f);
                    Vector3 _1945 = this.RHand.position;
                    _1945.z = _1944;
                    this.RHand.position = _1945;
                }

                {
                    float _1946 = Mathf.Lerp(this.RHand.localRotation.x, this.RHandIdle2.localRotation.x, 0.1f);
                    Quaternion _1947 = this.RHand.localRotation;
                    _1947.x = _1946;
                    this.RHand.localRotation = _1947;
                }

                {
                    float _1948 = Mathf.Lerp(this.RHand.localRotation.y, this.RHandIdle2.localRotation.y, 0.1f);
                    Quaternion _1949 = this.RHand.localRotation;
                    _1949.y = _1948;
                    this.RHand.localRotation = _1949;
                }

                {
                    float _1950 = Mathf.Lerp(this.RHand.localRotation.z, this.RHandIdle2.localRotation.z, 0.1f);
                    Quaternion _1951 = this.RHand.localRotation;
                    _1951.z = _1950;
                    this.RHand.localRotation = _1951;
                }
            }
            else
            {

                {
                    float _1952 = Mathf.Lerp(this.RHand.position.x, this.RHandIdle1.position.x, 0.05f);
                    Vector3 _1953 = this.RHand.position;
                    _1953.x = _1952;
                    this.RHand.position = _1953;
                }

                {
                    float _1954 = Mathf.Lerp(this.RHand.position.y, this.RHandIdle1.position.y, 0.05f);
                    Vector3 _1955 = this.RHand.position;
                    _1955.y = _1954;
                    this.RHand.position = _1955;
                }

                {
                    float _1956 = Mathf.Lerp(this.RHand.position.z, this.RHandIdle1.position.z, 0.05f);
                    Vector3 _1957 = this.RHand.position;
                    _1957.z = _1956;
                    this.RHand.position = _1957;
                }

                {
                    float _1958 = Mathf.Lerp(this.RHand.localRotation.x, this.RHandIdle1.localRotation.x, 0.1f);
                    Quaternion _1959 = this.RHand.localRotation;
                    _1959.x = _1958;
                    this.RHand.localRotation = _1959;
                }

                {
                    float _1960 = Mathf.Lerp(this.RHand.localRotation.y, this.RHandIdle1.localRotation.y, 0.1f);
                    Quaternion _1961 = this.RHand.localRotation;
                    _1961.y = _1960;
                    this.RHand.localRotation = _1961;
                }

                {
                    float _1962 = Mathf.Lerp(this.RHand.localRotation.z, this.RHandIdle1.localRotation.z, 0.1f);
                    Quaternion _1963 = this.RHand.localRotation;
                    _1963.z = _1962;
                    this.RHand.localRotation = _1963;
                }
            }
            this.TurgkinRB.AddForce(this.transform.forward * Random.Range(0.015f, 0.03f));
        }
        if (!this.Turning)
        {
            this.TurgkinRB.AddForceAtPosition(Vector3.up * this.aimForce, this.TurgkinTF.forward * 1.5f);
            this.TurgkinRB.AddForceAtPosition(-Vector3.up * this.aimForce, -this.TurgkinTF.forward * 1.5f);
        }
        if (Physics.Raycast(this.thisTransform.position, Vector3.down, out hit, 2000, (int) this.targetLayers))
        {
            this.hoverForce = this.hoverCurve.Evaluate(hit.distance);
            this.TurgkinRB.AddForce((Vector3.up * this.hoverForce) * 0.005f);
        }
        if (this.RelaxedLevel < 8)
        {
            if (this.UsingMelee)
            {
                if (this.TurgRangedMorphLevel < 1)
                {
                    if (this.TurgMeleeMorphLevel < 48)
                    {
                        this.TurgMeleeMorphLevel = this.TurgMeleeMorphLevel + 1;
                    }
                    if (this.TurgMeleeMorphLevel > 24)
                    {
                        this.TurgMeleeModelR.enabled = true;
                        this.TurgMeleeModelFragR.material.SetTexture("_SliceGuide", this.GradTexUp);
                    }
                    else
                    {
                        this.TurgMeleeModelR.enabled = false;
                        this.TurgMeleeModelFragR.material.SetTexture("_SliceGuide", this.GradTexDown);
                    }
                }
            }
            else
            {
                if (this.TurgMeleeMorphLevel > 0)
                {
                    this.TurgMeleeMorphLevel = this.TurgMeleeMorphLevel - 1;
                }
                if (this.TurgMeleeMorphLevel > 24)
                {
                    this.TurgMeleeModelR.enabled = true;
                    this.TurgMeleeModelFragR.material.SetTexture("_SliceGuide", this.GradTexUp);
                }
                else
                {
                    this.TurgMeleeModelR.enabled = false;
                    this.TurgMeleeModelFragR.material.SetTexture("_SliceGuide", this.GradTexDown);
                }
            }
            if (this.UsingRanged)
            {
                if (this.TurgMeleeMorphLevel < 1)
                {
                    if (this.TurgRangedMorphLevel < 48)
                    {
                        this.TurgRangedMorphLevel = this.TurgRangedMorphLevel + 1;
                    }
                    if (this.TurgRangedMorphLevel > 24)
                    {
                        this.TurgRangedModelR.enabled = true;
                        this.TurgRangedModelFragR.material.SetTexture("_SliceGuide", this.GradTexUp);
                    }
                    else
                    {
                        this.TurgRangedModelR.enabled = false;
                        this.TurgRangedModelFragR.material.SetTexture("_SliceGuide", this.GradTexDown);
                    }
                }
            }
            else
            {
                if (this.TurgRangedMorphLevel > 0)
                {
                    this.TurgRangedMorphLevel = this.TurgRangedMorphLevel - 1;
                }
                if (this.TurgRangedMorphLevel > 24)
                {
                    this.TurgRangedModelR.enabled = true;
                    this.TurgRangedModelFragR.material.SetTexture("_SliceGuide", this.GradTexUp);
                }
                else
                {
                    this.TurgRangedModelR.enabled = false;
                    this.TurgRangedModelFragR.material.SetTexture("_SliceGuide", this.GradTexDown);
                }
            }
        }
        else
        {
            if (this.TurgMeleeMorphLevel > 0)
            {
                this.TurgMeleeMorphLevel = this.TurgMeleeMorphLevel - 1;
            }
            if (this.TurgRangedMorphLevel > 0)
            {
                this.TurgRangedMorphLevel = this.TurgRangedMorphLevel - 1;
            }
            if (this.TurgRangedMorphLevel > 24)
            {
                this.TurgRangedModelR.enabled = true;
                this.TurgRangedModelFragR.material.SetTexture("_SliceGuide", this.GradTexUp);
            }
            else
            {
                this.TurgRangedModelR.enabled = false;
                this.TurgRangedModelFragR.material.SetTexture("_SliceGuide", this.GradTexDown);
            }
            if (this.TurgMeleeMorphLevel > 24)
            {
                this.TurgMeleeModelR.enabled = true;
                this.TurgMeleeModelFragR.material.SetTexture("_SliceGuide", this.GradTexUp);
            }
            else
            {
                this.TurgMeleeModelR.enabled = false;
                this.TurgMeleeModelFragR.material.SetTexture("_SliceGuide", this.GradTexDown);
            }
        }
        if (Vector3.Distance(this.thisTransform.position, this.RHand.position) < 0.25f)
        {
            this.TurgHandModelR.enabled = false;
        }
        else
        {
            this.TurgHandModelR.enabled = true;
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (Physics.Linecast(this.thisTransform.position, OT.position, (int) this.targetLayersM))
        {
            return;
        }
        if (ON.Contains("TFC"))
        {
            if (this.PissedOffLevel < 12)
            {
                this.PissedOffLevel = this.PissedOffLevel + 6;
            }
            this.RelaxedLevel = 0;
        }
        if (ON.Contains("TFC0"))
        {
            this.PissedAtTC0 = this.PissedAtTC0 + 6;
        }
        if (ON.Contains("TFC1"))
        {
            this.PissedAtTC1 = this.PissedAtTC1 + 6;
        }
        if (ON.Contains("TFC2"))
        {
            this.PissedAtTC2 = this.PissedAtTC2 + 6;
        }
        if (ON.Contains("TFC3"))
        {
            this.PissedAtTC3 = this.PissedAtTC3 + 6;
        }
        if (ON.Contains("TFC4"))
        {
            this.PissedAtTC4 = this.PissedAtTC4 + 6;
        }
        if (ON.Contains("TFC5"))
        {
            this.PissedAtTC5 = this.PissedAtTC5 + 6;
        }
        if (ON.Contains("TFC6"))
        {
            this.PissedAtTC6 = this.PissedAtTC6 + 6;
        }
        if (ON.Contains("TFC7"))
        {
            this.PissedAtTC7 = this.PissedAtTC7 + 6;
        }
        if (ON.Contains("TFC8"))
        {
            this.PissedAtTC8 = this.PissedAtTC8 + 6;
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (this.TurgkinTrig.radius < 6)
        {
            return;
        }
        string ON = other.name;
        Transform OT = other.transform;
        if (Physics.Linecast(this.thisTransform.position, OT.position, (int) this.targetLayersM))
        {
            return;
        }
        if (ON.Contains("TC"))
        {
            if (OT != this.TurgkinTC)
            {
                if (ON.Contains("C0"))
                {
                    if (this.PissedAtTC0 > 0)
                    {
                        this.target = OT;
                        this.TurgkinTrig.radius = 0.1f;
                        this.PissedOffLevel = 10;
                        this.RelaxedLevel = 0;
                        if (this.TurgRangedMorphLevel > 32)
                        {
                            this.Weapon.Firing = this.UsingRanged;
                        }
                    }
                }
                if (ON.Contains("C1"))
                {
                    if (this.PissedAtTC1 > 0)
                    {
                        this.target = OT;
                        this.TurgkinTrig.radius = 0.1f;
                        this.PissedOffLevel = 10;
                        this.RelaxedLevel = 0;
                        if (this.TurgRangedMorphLevel > 32)
                        {
                            this.Weapon.Firing = this.UsingRanged;
                        }
                    }
                }
                if (ON.Contains("C2"))
                {
                    if (this.PissedAtTC2 > 0)
                    {
                        this.target = OT;
                        this.TurgkinTrig.radius = 0.1f;
                        this.PissedOffLevel = 10;
                        this.RelaxedLevel = 0;
                        if (this.TurgRangedMorphLevel > 32)
                        {
                            this.Weapon.Firing = this.UsingRanged;
                        }
                    }
                }
                if (ON.Contains("C3"))
                {
                    if (this.PissedAtTC3 > 0)
                    {
                        this.target = OT;
                        this.TurgkinTrig.radius = 0.1f;
                        this.PissedOffLevel = 10;
                        this.RelaxedLevel = 0;
                        if (this.TurgRangedMorphLevel > 32)
                        {
                            this.Weapon.Firing = this.UsingRanged;
                        }
                    }
                }
                if (ON.Contains("C4"))
                {
                    if (this.PissedAtTC4 > 0)
                    {
                        this.target = OT;
                        this.TurgkinTrig.radius = 0.1f;
                        this.PissedOffLevel = 10;
                        this.RelaxedLevel = 0;
                        if (this.TurgRangedMorphLevel > 32)
                        {
                            this.Weapon.Firing = this.UsingRanged;
                        }
                    }
                }
                if (ON.Contains("C5"))
                {
                    if (this.PissedAtTC5 > 0)
                    {
                        this.target = OT;
                        this.TurgkinTrig.radius = 0.1f;
                        this.PissedOffLevel = 10;
                        this.RelaxedLevel = 0;
                        if (this.TurgRangedMorphLevel > 32)
                        {
                            this.Weapon.Firing = this.UsingRanged;
                        }
                    }
                }
                if (ON.Contains("C6"))
                {
                    if (this.PissedAtTC6 > 0)
                    {
                        this.target = OT;
                        this.TurgkinTrig.radius = 0.1f;
                        this.PissedOffLevel = 10;
                        this.RelaxedLevel = 0;
                        if (this.TurgRangedMorphLevel > 32)
                        {
                            this.Weapon.Firing = this.UsingRanged;
                        }
                    }
                }
                if (ON.Contains("C7"))
                {
                    if (this.PissedAtTC7 > 0)
                    {
                        this.target = OT;
                        this.TurgkinTrig.radius = 0.1f;
                        this.PissedOffLevel = 10;
                        this.RelaxedLevel = 0;
                        if (this.TurgRangedMorphLevel > 32)
                        {
                            this.Weapon.Firing = this.UsingRanged;
                        }
                    }
                }
                if (ON.Contains("C8"))
                {
                    if (this.PissedAtTC8 > 0)
                    {
                        this.target = OT;
                        this.TurgkinTrig.radius = 0.1f;
                        this.PissedOffLevel = 10;
                        this.RelaxedLevel = 0;
                        if (this.TurgRangedMorphLevel > 32)
                        {
                            this.Weapon.Firing = this.UsingRanged;
                        }
                    }
                }
                if (this.target)
                {
                    if (this.PissedOffLevel < 20)
                    {
                        if (this.target.name.Contains("rok"))
                        {
                            this.Weapon.Firing = false;
                        }
                        if (this.PissedAtTC0 < 1)
                        {
                            if (this.target.name.Contains("C0"))
                            {
                                this.Weapon.Firing = false;
                            }
                        }
                        if (this.PissedAtTC1 < 1)
                        {
                            if (this.target.name.Contains("C1"))
                            {
                                this.Weapon.Firing = false;
                            }
                        }
                        if (this.PissedAtTC2 < 1)
                        {
                            if (this.target.name.Contains("C2"))
                            {
                                this.Weapon.Firing = false;
                            }
                        }
                        if (this.PissedAtTC3 < 1)
                        {
                            if (this.target.name.Contains("C3"))
                            {
                                this.Weapon.Firing = false;
                            }
                        }
                        if (this.PissedAtTC4 < 1)
                        {
                            if (this.target.name.Contains("C4"))
                            {
                                this.Weapon.Firing = false;
                            }
                        }
                        if (this.PissedAtTC5 < 1)
                        {
                            if (this.target.name.Contains("C5"))
                            {
                                this.Weapon.Firing = false;
                            }
                        }
                        if (this.PissedAtTC6 < 1)
                        {
                            if (this.target.name.Contains("C6"))
                            {
                                this.Weapon.Firing = false;
                            }
                        }
                        if (this.PissedAtTC7 < 1)
                        {
                            if (this.target.name.Contains("C7"))
                            {
                                this.Weapon.Firing = false;
                            }
                        }
                        if (this.PissedAtTC8 < 1)
                        {
                            if (this.target.name.Contains("C8"))
                            {
                                this.Weapon.Firing = false;
                            }
                        }
                        if (this.PissedAtTC9 < 1)
                        {
                            if (this.target.name.Contains("C9"))
                            {
                                this.Weapon.Firing = false;
                            }
                        }
                    }
                }
                if (this.TurgMeleeMorphLevel > 32)
                {
                    if ((this.Dist < 2) || this.Obstacle)
                    {
                        this.RHandReadySwipe1 = true;
                    }
                }
                else
                {
                    if ((this.Dist < 2) || this.Obstacle)
                    {
                        this.RHandReadyJab1 = true;
                    }
                }
                if (ON != this.RememberedName)
                {
                    if (this.PissedOffLevel < 8)
                    {
                        this.StressLevel = this.StressLevel + 2;
                        this.Interest = 8;
                        this.target = OT;
                        this.TurgkinTrig.radius = 0.1f;
                        if (this.StressLevel > 24)
                        {
                            this.PissedOffLevel = this.PissedOffLevel + 2;
                            this.RelaxedLevel = 0;
                            if (this.PissedOffLevel > 8)
                            {
                                this.target = OT;
                                this.PissedOffLevel = 4;
                                this.StressLevel = 0;
                                this.Weapon.Firing = this.UsingRanged;
                            }
                        }
                    }
                }
                else
                {
                    if (this.Dist < 32)
                    {
                        this.StressLevel = this.StressLevel + 1;
                        this.TurgkinTrig.radius = 0.1f;
                        if (this.StressLevel > 32)
                        {
                            this.PissedOffLevel = this.PissedOffLevel + 2;
                            this.RelaxedLevel = 0;
                            if (this.PissedOffLevel > 8)
                            {
                                this.target = OT;
                                if (this.TypeCytchau)
                                {
                                    this.PissedOffLevel = 20;
                                }
                                else
                                {
                                    this.PissedOffLevel = 30;
                                }
                                this.StressLevel = 0;
                                this.Weapon.Firing = this.UsingRanged;
                            }
                        }
                    }
                }
            }
        }
        else
        {
            if (this.PissedOffLevel < 20)
            {
                this.Weapon.Firing = false;
            }
        }
    }

    public virtual void Ticker()
    {
        if (this.LifeForce > 8)
        {
            if (this.Dist < 2.5f)
            {
                this.UsingMelee = true;
                this.UsingRanged = false;
                this.Weapon.Firing = false;
            }
            else
            {
                if (!this.Obstacle)
                {
                    this.UsingRanged = true;
                    this.UsingMelee = false;
                }
                else
                {
                    this.UsingMelee = true;
                    this.UsingRanged = false;
                    this.Weapon.Firing = false;
                }
            }
        }
        else
        {
            this.UsingRanged = false;
            this.UsingMelee = false;
        }
        if (this.PissedOffLevel < 1)
        {
            if (this.RelaxedLevel < 8)
            {
                this.RelaxedLevel = this.RelaxedLevel + 1;
            }
        }
        else
        {
            this.RelaxedLevel = 0;
        }
        if (this.LifeForce > 8)
        {
            this.DamageScript.NoArmor = false;
            this.DamageScript.LightArmor = true;
        }
        else
        {
            this.DamageScript.NoArmor = true;
            this.DamageScript.LightArmor = false;
        }
        if (this.Weapon.Firing)
        {
            this.TurgkinTC.name = "sTC0a";
        }
        else
        {
            this.TurgkinTC.name = "sTC0";
        }
        if (!this.target)
        {
            this.Weapon.Firing = false;
        }
        else
        {
            this.RememberedName = this.target.name;
        }
        if (this.StressLevel > 0)
        {
            this.StressLevel = this.StressLevel - 1;
        }
        if (this.PissedOffLevel > 0)
        {
            this.PissedOffLevel = this.PissedOffLevel - 1;
        }
        if (this.PissedAtTC0 > 0)
        {
            this.PissedAtTC0 = this.PissedAtTC0 - 1;
        }
        if (this.PissedAtTC1 > 0)
        {
            this.PissedAtTC1 = this.PissedAtTC1 - 1;
        }
        if (this.PissedAtTC2 > 0)
        {
            this.PissedAtTC2 = this.PissedAtTC2 - 1;
        }
        if (this.PissedAtTC3 > 0)
        {
            this.PissedAtTC3 = this.PissedAtTC3 - 1;
        }
        if (this.PissedAtTC4 > 0)
        {
            this.PissedAtTC4 = this.PissedAtTC4 - 1;
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
        if (this.PissedAtTC8 > 0)
        {
            this.PissedAtTC8 = this.PissedAtTC8 - 1;
        }
        if (this.PissedAtTC9 > 0)
        {
            this.PissedAtTC9 = this.PissedAtTC9 - 1;
        }
        if (this.Stuckage > 3)
        {
            this.Stuck = true;
            this.Stuckage = 0;
        }
        else
        {
            Vector3 lastPos = this.thisTransform.position;
            this.StartCoroutine(this.Stuckneurysms(lastPos));
            this.Stuck = false;
        }
        if (this.Interest < 1)
        {
            if (this.PissedOffLevel < 1)
            {
                if (!this.TypeCydaz)
                {
                    this.StressLevel = this.StressLevel - 1;
                }
                this.target = null;
            }
        }
        else
        {
            this.Interest = this.Interest - 1;
        }
        int randomValueKD = 1;
        if (this.TypeCytarg)
        {
            randomValueKD = Random.Range(0, 8);
        }
        else
        {
            randomValueKD = Random.Range(0, 3);
        }
        switch (randomValueKD)
        {
            case 0:
                this.KeepDistance = false;
                break;
            case 1:
                this.KeepDistance = false;
                break;
            case 2:
                this.KeepDistance = true;
                break;
            case 3:
                this.KeepDistance = true;
                break;
            case 4:
                this.KeepDistance = true;
                break;
            case 5:
                this.KeepDistance = true;
                break;
            case 6:
                this.KeepDistance = true;
                break;
            case 7:
                this.KeepDistance = true;
                break;
        }
        this.Turning = false;
        this.Obstacle = false;
    }

    public virtual IEnumerator Stuckneurysms(Vector3 lastPos)
    {
        yield return new WaitForSeconds(0.8f);
        if (Vector3.Distance(this.thisTransform.position, lastPos) < 1)
        {
            if (!this.target)
            {
                this.Stuckage = this.Stuckage + 1;
            }
        }
    }

    public virtual IEnumerator Escape()
    {
        this.PissedOffLevel = 0;
        this.Escaping = true;
        yield return new WaitForSeconds(2);
        this.Escaping = false;
    }

    public virtual void Despawn()
    {
        StuffSpawner.TheNPC0091N = StuffSpawner.TheNPC0091N - 1;
        UnityEngine.Object.Destroy(this.TurgkinPTF.gameObject);
    }

    public virtual void Kill()
    {
        GameObject Spawnionaise = ((GameObject) Resources.Load("NPCs/CykinDut", typeof(GameObject))) as GameObject;
        GameObject _SpawnedObject3 = UnityEngine.Object.Instantiate(Spawnionaise, this.thisTransform.position, this.thisTransform.rotation);
        _SpawnedObject3.transform.GetChild(0).GetComponent<Rigidbody>().velocity = this.TurgkinRB.velocity * 1;
        ((DutCykinAI) _SpawnedObject3.transform.GetChild(0).transform.GetChild(0).transform.GetComponent(typeof(DutCykinAI))).IsNewlyCreated = true;
        if (this.TypeCydaz)
        {
            ((DutCykinAI) _SpawnedObject3.transform.GetChild(0).transform.GetChild(0).transform.GetComponent(typeof(DutCykinAI))).TypeCydaz = true;
        }
        if (this.TypeCytarg)
        {
            ((DutCykinAI) _SpawnedObject3.transform.GetChild(0).transform.GetChild(0).transform.GetComponent(typeof(DutCykinAI))).TypeCytarg = true;
        }
        if (this.TypeCytchau)
        {
            ((DutCykinAI) _SpawnedObject3.transform.GetChild(0).transform.GetChild(0).transform.GetComponent(typeof(DutCykinAI))).TypeCytchau = true;
        }
        StuffSpawner.TheNPC0091N = StuffSpawner.TheNPC0091N - 1;
        this.DamageScript.DestroySequence();
    }

    public DutTurgkinAI()
    {
        this.RHandSwipe1PosCurve = new AnimationCurve();
        this.RHandSwipe1RotCurve = new AnimationCurve();
        this.RHandJabPosCurve = new AnimationCurve();
        this.RHandJabRotCurve = new AnimationCurve();
        this.FX2Curve = new AnimationCurve();
        this.FX1R = 0.9f;
        this.FX1G = 0.9f;
        this.FX1B = 0.9f;
        this.TurgModelFragRCurve = new AnimationCurve();
        this.TurgRangedModelFragRCurve = new AnimationCurve();
        this.TurgMeleeModelFragRCurve = new AnimationCurve();
        this.aimForce = 0.1f;
        this.dirForce = 0.01f;
        this.dirForceCurve = new AnimationCurve();
        this.dirForceCurveKD = new AnimationCurve();
        this.hoverForce = 0.0001f;
        this.hoverCurve = new AnimationCurve();
    }

}