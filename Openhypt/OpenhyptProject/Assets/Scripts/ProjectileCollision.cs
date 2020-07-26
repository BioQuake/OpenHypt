using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ProjectileCollision : MonoBehaviour
{
    public GameObject FX;
    public GameObject GroundHit;
    public GameObject MetalHit;
    public GameObject StructureHit;
    public GameObject LiquidHit;
    public GameObject BodyHit;
    public GameObject BodyHitPeuk;
    public LayerMask targetLayers;
    public int Damage;
    public int DamageCode;
    public bool PlayerShot;
    public bool kineticCollision;
    public bool instantaneous;
    public float startPoint;
    public float range;
    public int Lifetime;
    public float ProjectileMass;
    public Vector3 Point;
    public bool Solid;
    public bool C1;
    public bool C2;
    public bool Away;
    public static int StatDamage;
    public virtual IEnumerator Start()
    {
        if (!this.instantaneous)
        {
            this.transform.parent = null;
            this.ProjectileMass = this.GetComponent<Rigidbody>().mass * 20000;
        }
        if (this.DamageCode != 2)
        {
            if (WorldInformation.instance.AreaKabrian == true)
            {
                if (AgrianNetwork.instance.AlertTime < 60)
                {
                    AgrianNetwork.instance.PriorityWaypoint.position = this.transform.position;
                    AgrianNetwork.instance.AlertTime = 60;
                }
            }
        }
        else
        {
            if (this.PlayerShot)
            {
                AgrianNetwork.instance.Curiosity = AgrianNetwork.instance.Curiosity + 20;
                if (AgrianNetwork.instance.Curiosity > 200)
                {
                    AgrianNetwork.instance.PriorityWaypoint.position = this.transform.position;
                    if ((AgrianNetwork.TC1CriminalLevel > 500) && (AgrianNetwork.instance.Curiosity > 500))
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.position = this.transform.position;
                        WorldInformation.PiriExposed = 120;
                    }
                }
            }
        }
        if (this.PlayerShot)
        {
            KabrianLaw.Amount1 = KabrianLaw.Amount1 + (this.Damage - 32);
            if (this.DamageCode == 1)
            {
                WorldInformation.PiriExposed = 60;
            }
            else
            {
                if (WorldInformation.PiriExposed > 1)
                {
                    this.DamageCode = 1;
                    this.transform.name = "TFC1";
                }
                if (this.DamageCode == 7)
                {
                    TCChanger.DidShootNum = 60;
                }
            }
        }
        yield return new WaitForSeconds(0.02f);
        if (this.FX && !this.C2)
        {
            this.FX.SetActive(true);
        }
        yield return new WaitForSeconds(this.Lifetime);
        UnityEngine.Object.Destroy(this.gameObject);
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        float num = 0.0f;
        float VelClamp = Mathf.Clamp(this.GetComponent<Rigidbody>().velocity.magnitude, 2, 1024);
        if (!this.instantaneous)
        {
            if (this.GetComponent<Rigidbody>().velocity != Vector3.zero)
            {
                if ((!this.C1 && this.Away) && !this.kineticCollision)
                {
                    this.transform.rotation = Quaternion.LookRotation(this.GetComponent<Rigidbody>().velocity);
                }
            }
        }
        if (!this.kineticCollision)
        {
            num = 0.05f;
        }
        else
        {
            num = 1;
        }
        if (this.instantaneous)
        {
            if (!this.C1)
            {
                if (Physics.Raycast(this.transform.position + (this.transform.forward * this.startPoint), this.transform.forward, out hit, this.range, (int) this.targetLayers))
                {
                    this.Point = hit.point;
                    this.C1 = true;
                    Quaternion NormalAngleI = Quaternion.LookRotation(hit.normal);
                    GameObject TheHitI = UnityEngine.Object.Instantiate(this.GroundHit, this.Point, NormalAngleI);
                    TheHitI.transform.parent = hit.collider.transform;
                }
                else
                {
                    this.C1 = true;
                }
            }
        }
        else
        {
            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, VelClamp * num, (int) this.targetLayers) && !this.C1)
            {
                Vector3 relativePoint = hit.transform.InverseTransformPoint(this.transform.position);
                float FAndB = relativePoint.y;
                this.Point = hit.point;
                this.C1 = true;
                if (((VehicleDamage) hit.collider.gameObject.GetComponent(typeof(VehicleDamage))) != null)
                {
                    ((VehicleDamage) hit.collider.gameObject.GetComponent(typeof(VehicleDamage))).DamageIn(this.Damage, this.DamageCode, FAndB, this.PlayerShot);
                }
                if (((SubDamage) hit.collider.gameObject.GetComponent(typeof(SubDamage))) != null)
                {
                    this.StartCoroutine(((SubDamage) hit.collider.gameObject.GetComponent(typeof(SubDamage))).DamageIn(this.Damage, this.DamageCode, this.PlayerShot));
                }
                if (((ReactiveObject) hit.collider.gameObject.GetComponent(typeof(ReactiveObject))) != null)
                {
                    ((ReactiveObject) hit.collider.gameObject.GetComponent(typeof(ReactiveObject))).DamageIn(this.Damage, this.DamageCode);
                }
                if (hit.rigidbody)
                {
                    hit.rigidbody.AddForceAtPosition(this.transform.forward * this.ProjectileMass, hit.point);
                }
                else
                {
                    if (hit.transform.parent)
                    {
                        if (hit.transform.parent.gameObject.GetComponent<Rigidbody>())
                        {
                            hit.transform.parent.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(this.transform.forward * this.ProjectileMass, hit.point);
                        }
                    }
                }
                Quaternion NormalAngle = Quaternion.LookRotation(hit.normal);
                if (!this.Solid)
                {
                    if (!this.C2)
                    {
                        if (hit.collider.tag == "BodyPeuk")
                        {
                            GameObject TheHit0 = UnityEngine.Object.Instantiate(this.BodyHitPeuk, this.Point, NormalAngle);
                            TheHit0.transform.parent = hit.collider.transform;
                            this.StartCoroutine(this.Next());
                        }
                    }
                    if (!this.C2)
                    {
                        if (hit.collider.tag == "Body")
                        {
                            GameObject TheHit1 = UnityEngine.Object.Instantiate(this.BodyHitPeuk, this.Point, NormalAngle);
                            TheHit1.transform.parent = hit.collider.transform;
                            this.StartCoroutine(this.Next());
                        }
                    }
                    if (!this.C2)
                    {
                        if (hit.collider.tag == "TransparentCol")
                        {
                            this.C2 = true;
                            UnityEngine.Object.Instantiate(this.LiquidHit, this.Point, this.LiquidHit.transform.rotation);
                            this.StartCoroutine(this.Next());
                        }
                    }
                    if (!this.C2)
                    {
                        this.C2 = true;
                        UnityEngine.Object.Instantiate(this.GroundHit, this.Point, NormalAngle);
                        this.StartCoroutine(this.Next());
                    }
                }
                else
                {
                    if (!this.C2)
                    {
                        if (hit.collider.tag == "TransparentCol")
                        {
                            this.C2 = true;
                            UnityEngine.Object.Instantiate(this.LiquidHit, this.Point, this.LiquidHit.transform.rotation);
                            this.StartCoroutine(this.Next());
                        }
                    }
                    if (!this.C2)
                    {
                        if (((hit.collider.tag == "Metal") || (hit.collider.tag == "MetalStructure")) || (hit.collider.tag == "Vehicle"))
                        {
                            this.C2 = true;
                            UnityEngine.Object.Instantiate(this.MetalHit, this.Point, this.transform.rotation);
                            this.StartCoroutine(this.Next());
                        }
                    }
                    if (!this.C2)
                    {
                        if (hit.collider.tag == "SoftTerrain")
                        {
                            this.C2 = true;
                            UnityEngine.Object.Instantiate(this.GroundHit, this.Point, NormalAngle);
                            this.StartCoroutine(this.Next());
                        }
                    }
                    if (!this.C2)
                    {
                        if ((hit.collider.tag == "Terrain") || (hit.collider.tag == "Structure"))
                        {
                            this.C2 = true;
                            UnityEngine.Object.Instantiate(this.StructureHit, this.Point, this.StructureHit.transform.rotation);
                            this.StartCoroutine(this.Next());
                        }
                    }
                    if (!this.C2)
                    {
                        if (hit.collider.tag == "BodyPeuk")
                        {
                            this.C2 = true;
                            GameObject TheHit2 = UnityEngine.Object.Instantiate(this.BodyHitPeuk, this.Point, NormalAngle);
                            TheHit2.transform.parent = hit.collider.transform;
                            this.StartCoroutine(this.Next());
                        }
                    }
                    if (!this.C2)
                    {
                        if (hit.collider.tag == "Body")
                        {
                            this.C2 = true;
                            GameObject TheHit3 = UnityEngine.Object.Instantiate(this.BodyHitPeuk, this.Point, NormalAngle);
                            TheHit3.transform.parent = hit.collider.transform;
                            this.StartCoroutine(this.Next());
                        }
                    }
                }
            }
        }
        this.Away = true;
    }

    public virtual IEnumerator Next()
    {
        if (this.FX)
        {
            this.FX.SetActive(false);
        }
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        yield return new WaitForSeconds(0.3f);
        UnityEngine.Object.Destroy(this.gameObject);
    }

    public ProjectileCollision()
    {
        this.Lifetime = 4;
    }

}