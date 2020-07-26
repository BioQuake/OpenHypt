using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class WeaponExplosion : MonoBehaviour
{
    public float damage;
    public float range;
    public float power;
    public float penDamage;
    public float penRange;
    public int damageCode;
    public bool PlayerHit;
    public bool PassKL;
    public bool Constant;
    public int Frequency;
    private int FrequencyStat;
    public bool Penetrative;
    public bool UseDamageCurve;
    public AnimationCurve DamageCurve;
    public AnimationCurve ForceCurve;
    public AnimationCurve PushCurve;
    public float ForceAmount;
    public float PushAmount;
    public bool UseForceCurve;
    public GameObject Ejecta1;
    public int Ejecta1Amount;
    public int Ejecta1XForce;
    public int Ejecta1YForce;
    public int Ejecta1ZForce;
    public GameObject Ejecta2;
    public int Ejecta2Amount;
    public int Ejecta2XForce;
    public int Ejecta2YForce;
    public int Ejecta2ZForce;
    public GameObject Ejecta3;
    public int Ejecta3Amount;
    public int Ejecta3XForce;
    public int Ejecta3YForce;
    public int Ejecta3ZForce;
    public Transform EjectaPos;
    public bool GetAttention;
    public LayerMask targetLayers;
    public Quaternion staticRot0;
    public RaycastHit hit0;
    public Transform TheCol0;
    public Quaternion staticRot1;
    public RaycastHit hit1;
    public Transform TheCol1;
    public Quaternion staticRot2;
    public RaycastHit hit2;
    public Transform TheCol2;
    public float pD;
    private bool proceed;
    public virtual void Start()
    {
        if (this.Constant)
        {
            this.FrequencyStat = this.Frequency;
            return;
        }
        if (this.Penetrative)
        {
            Collider[] hitCollidersP = Physics.OverlapSphere(this.transform.position + (this.transform.forward * this.penRange), this.penRange);
            int i2 = 0;
            while (i2 < hitCollidersP.Length)
            {
                if (hitCollidersP[i2].gameObject.GetComponent<VehicleDamage>() != null)
                {
                    hitCollidersP[i2].gameObject.GetComponent<VehicleDamage>().DamageIn(this.penDamage, this.damageCode, 0, this.PlayerHit);
                }
                if (hitCollidersP[i2].gameObject.GetComponent<SubDamage>() != null)
                {
                    hitCollidersP[i2].gameObject.GetComponent<SubDamage>().DamageIn(this.penDamage, this.damageCode, this.PlayerHit);
                }
                if (hitCollidersP[i2].gameObject.GetComponent<ReactiveObject>() != null)
                {
                    hitCollidersP[i2].gameObject.GetComponent<ReactiveObject>().DamageIn(this.penDamage, this.damageCode);
                }
                i2++;
            }
        }
        if (this.GetAttention)
        {
            SlavuicNetwork.Attention = true;
        }
        if (this.PlayerHit)
        {
            if (WorldInformation.PiriExposed > 1)
            {
                this.damageCode = 1;
            }
            if (!this.PassKL)
            {
                KabrianLaw.Amount2 = (int) (KabrianLaw.Amount2 + this.damage);
            }
        }
        Collider[] cols = Physics.OverlapSphere(this.transform.position, this.range);
        int c = 0;
        while (c < cols.Length)
        {
            this.proceed = true;
            if (this.UseDamageCurve)
            {
                if (cols[c].gameObject.GetComponent<VehicleDamage>() != null)
                {
                    this.staticRot0 = this.transform.rotation;
                    this.TheCol0 = cols[c].transform;
                    this.transform.LookAt(this.TheCol0);
                    this.transform.Translate(Vector3.back * 2);
                    if (Physics.Raycast(this.transform.position, this.transform.forward, out this.hit0, 8000, (int) this.targetLayers))
                    {
                        if (this.hit0.transform == this.TheCol0)
                        {
                            //Debug.Log("IT DID " + TheCol0);
                            this.pD = this.hit0.distance;
                        }
                        else
                        {
                            //Debug.Log(hit0.transform);
                            //Debug.Log(TheCol0);
                            this.pD = Vector3.Distance(this.TheCol0.position, this.transform.position);
                        }
                    }
                    else
                    {
                        //Debug.Log("DidOOPS");
                        //Time.timeScale = 0;
                        //Debug.Break();
                        this.pD = 8000;
                    }
                    this.transform.Translate(Vector3.forward * 2);
                    this.transform.rotation = this.staticRot0;
                    Vector3 relativePoint1 = this.TheCol0.InverseTransformPoint(this.transform.position);
                    if (relativePoint1.y < 0)
                    {
                        cols[c].gameObject.GetComponent<VehicleDamage>().DamageIn(this.damage * this.DamageCurve.Evaluate(this.pD), this.damageCode, 1, this.PlayerHit);
                    }
                    else
                    {
                        cols[c].gameObject.GetComponent<VehicleDamage>().DamageIn(this.damage * this.DamageCurve.Evaluate(this.pD), this.damageCode, 2, this.PlayerHit);
                    }
                }
                if (cols[c].gameObject.GetComponent<SubDamage>() != null)
                {
                    this.staticRot1 = this.transform.rotation;
                    this.TheCol1 = cols[c].transform;
                    this.transform.LookAt(this.TheCol1);
                    this.transform.Translate(Vector3.back * 2);
                    if (Physics.Raycast(this.transform.position, this.transform.forward, out this.hit1, 8000, (int) this.targetLayers))
                    {
                        if (this.hit1.transform == this.TheCol1)
                        {
                            this.pD = this.hit1.distance;
                        }
                        else
                        {
                            this.pD = Vector3.Distance(this.TheCol1.position, this.transform.position);
                        }
                    }
                    else
                    {
                        this.pD = 8000;
                    }
                    this.transform.Translate(Vector3.forward * 2);
                    this.transform.rotation = this.staticRot1;
                    cols[c].gameObject.GetComponent<SubDamage>().DamageIn(this.damage * this.DamageCurve.Evaluate(this.pD), this.damageCode, this.PlayerHit);
                }
                if (cols[c].gameObject.GetComponent<ReactiveObject>() != null)
                {
                    this.staticRot2 = this.transform.rotation;
                    this.TheCol2 = cols[c].transform;
                    this.transform.LookAt(this.TheCol2);
                    this.transform.Translate(Vector3.back * 2);
                    //Debug.DrawRay (transform.position, transform.forward * 8000, Color.red);
                    if (Physics.Raycast(this.transform.position, this.transform.forward, out this.hit2, 8000, (int) this.targetLayers))
                    {
                        if (this.hit2.transform == this.TheCol2)
                        {
                            this.pD = this.hit2.distance;
                        }
                        else
                        {
                            this.pD = Vector3.Distance(this.TheCol2.position, this.transform.position);
                        }
                    }
                    else
                    {
                        this.pD = 8000;
                    }
                    this.transform.Translate(Vector3.forward * 2);
                    this.transform.rotation = this.staticRot2;
                    cols[c].gameObject.GetComponent<ReactiveObject>().DamageIn(this.damage * this.DamageCurve.Evaluate(this.pD), this.damageCode);
                }
            }
            else
            {
                if (cols[c].gameObject.GetComponent<VehicleDamage>() != null)
                {
                    Vector3 relativePoint2 = cols[c].transform.InverseTransformPoint(this.transform.position);
                    if (relativePoint2.y < 0)
                    {
                        cols[c].gameObject.GetComponent<VehicleDamage>().DamageIn(this.damage, this.damageCode, 1, this.PlayerHit);
                    }
                    else
                    {
                        cols[c].gameObject.GetComponent<VehicleDamage>().DamageIn(this.damage, this.damageCode, 2, this.PlayerHit);
                    }
                }
                if (cols[c].gameObject.GetComponent<SubDamage>() != null)
                {
                    cols[c].gameObject.GetComponent<SubDamage>().DamageIn(this.damage, this.damageCode, this.PlayerHit);
                }
                if (cols[c].gameObject.GetComponent<ReactiveObject>() != null)
                {
                    cols[c].gameObject.GetComponent<ReactiveObject>().DamageIn(this.damage, this.damageCode);
                }
            }
            if (this.power != 0)
            {
                string zTag = cols[c].gameObject.tag;
                if (((zTag.Contains("Player") || zTag.Contains("Ghosts")) || zTag.Contains("Explosions")) || zTag.Contains("Structure"))
                {
                    this.proceed = false;
                }
                if (this.proceed)
                {
                    if (cols[c].attachedRigidbody && (cols[c].attachedRigidbody != this.GetComponent<Rigidbody>()))
                    {
                        Vector3 offset = this.transform.position - cols[c].transform.position;
                        if (!this.UseForceCurve)
                        {
                            float mag = offset.magnitude;
                            if (Vector3.Distance(cols[c].transform.position, this.transform.position) > 1)
                            {
                                cols[c].attachedRigidbody.AddForce(((offset / mag) / mag) * this.power);
                            }
                            if (Vector3.Distance(cols[c].transform.position, this.transform.position) < 1)
                            {
                                cols[c].attachedRigidbody.AddForce((offset * this.power) * 0.5f);
                            }
                        }
                        else
                        {
                            this.ForceAmount = this.ForceCurve.Evaluate(Vector3.Distance(cols[c].transform.position, this.transform.position));
                            this.PushAmount = this.PushCurve.Evaluate(Vector3.Distance(cols[c].transform.position, this.transform.position));
                            cols[c].attachedRigidbody.AddForce(offset * -this.ForceAmount);
                            cols[c].attachedRigidbody.AddForce(offset * -this.PushAmount, ForceMode.Acceleration);
                        }
                    }
                }
            }
            c++;
        }
        if (!this.name.Contains("TFC2"))
        {
            if (WorldInformation.instance.AreaKabrian == true)
            {
                AgrianNetwork.instance.PriorityWaypoint.transform.position = this.transform.position;
                AgrianNetwork.instance.AlertTime = 120;
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.Ejecta1Amount > 0)
        {
            GameObject E1 = UnityEngine.Object.Instantiate(this.Ejecta1, this.EjectaPos.position, this.EjectaPos.rotation);
            Rigidbody E1RB = E1.GetComponent<Rigidbody>();
            Transform E1TF = E1.transform;
            E1RB.AddForce(E1TF.right * Random.Range(-this.Ejecta1XForce, this.Ejecta1XForce));
            E1RB.AddForce(E1TF.up * Random.Range(-this.Ejecta1YForce, this.Ejecta1YForce));
            E1RB.AddForce(E1TF.forward * Random.Range(this.Ejecta1ZForce * 0.3f, this.Ejecta1ZForce));
            E1RB.AddTorque(E1TF.up * Random.Range(-30, 30));
            E1RB.AddTorque(E1TF.right * Random.Range(-30, 30));
            E1RB.AddTorque(E1TF.forward * Random.Range(-30, 30));
            this.Ejecta1Amount = this.Ejecta1Amount - 1;
        }
        if (this.Ejecta2Amount > 0)
        {
            GameObject E2 = UnityEngine.Object.Instantiate(this.Ejecta2, this.EjectaPos.position, this.EjectaPos.rotation);
            Rigidbody E2RB = E2.GetComponent<Rigidbody>();
            Transform E2TF = E2.transform;
            E2RB.AddForce(E2TF.right * Random.Range(-this.Ejecta2XForce, this.Ejecta2XForce));
            E2RB.AddForce(E2TF.up * Random.Range(-this.Ejecta2YForce, this.Ejecta2YForce));
            E2RB.AddForce(E2TF.forward * Random.Range(this.Ejecta2ZForce * 0.3f, this.Ejecta2ZForce));
            E2RB.AddTorque(E2TF.up * Random.Range(-30, 30));
            E2RB.AddTorque(E2TF.right * Random.Range(-30, 30));
            E2RB.AddTorque(E2TF.forward * Random.Range(-30, 30));
            this.Ejecta2Amount = this.Ejecta2Amount - 1;
        }
        if (this.Ejecta3Amount > 0)
        {
            GameObject E3 = UnityEngine.Object.Instantiate(this.Ejecta3, this.EjectaPos.position, this.EjectaPos.rotation);
            Rigidbody E3RB = E3.GetComponent<Rigidbody>();
            Transform E3TF = E3.transform;
            E3RB.AddForce(E3TF.right * Random.Range(-this.Ejecta3XForce, this.Ejecta3XForce));
            E3RB.AddForce(E3TF.up * Random.Range(-this.Ejecta3YForce, this.Ejecta3YForce));
            E3RB.AddForce(E3TF.forward * Random.Range(this.Ejecta3ZForce * 0.3f, this.Ejecta3ZForce));
            E3RB.AddTorque(E3TF.up * Random.Range(-30, 30));
            E3RB.AddTorque(E3TF.right * Random.Range(-30, 30));
            E3RB.AddTorque(E3TF.forward * Random.Range(-30, 30));
            this.Ejecta3Amount = this.Ejecta3Amount - 1;
        }
        if (this.Constant)
        {
            if (this.Frequency > 0)
            {
                this.Frequency = this.Frequency - 1;
            }
            else
            {
                this.Frequency = this.FrequencyStat;
                this.Rep();
            }
        }
    }

    public virtual void Rep()
    {
        Collider[] colsR = Physics.OverlapSphere(this.transform.position, this.range);
        int c = 0;
        while (c < colsR.Length)
        {
            if (colsR[c].gameObject.GetComponent<VehicleDamage>() != null)
            {
                Vector3 relativePointR = colsR[c].transform.InverseTransformPoint(this.transform.position);
                if (relativePointR.y < 0)
                {
                    colsR[c].gameObject.GetComponent<VehicleDamage>().DamageIn(this.damage, this.damageCode, 1, this.PlayerHit);
                }
                else
                {
                    colsR[c].gameObject.GetComponent<VehicleDamage>().DamageIn(this.damage, this.damageCode, 2, this.PlayerHit);
                }
            }
            if (colsR[c].gameObject.GetComponent<SubDamage>() != null)
            {
                colsR[c].gameObject.GetComponent<SubDamage>().DamageIn(this.damage, this.damageCode, this.PlayerHit);
            }
            if (colsR[c].gameObject.GetComponent<ReactiveObject>() != null)
            {
                colsR[c].gameObject.GetComponent<ReactiveObject>().DamageIn(this.damage, this.damageCode);
            }
            c++;
        }
    }

    public WeaponExplosion()
    {
        this.power = 100f;
        this.Frequency = 20;
        this.FrequencyStat = 20;
        this.DamageCurve = new AnimationCurve();
        this.ForceCurve = new AnimationCurve();
        this.PushCurve = new AnimationCurve();
    }

}