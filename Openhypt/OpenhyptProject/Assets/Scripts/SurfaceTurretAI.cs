using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SurfaceTurretAI : MonoBehaviour
{
    public Transform upperParent;
    public Transform absoluteParent;
    public Transform localParent;
    public Rigidbody mainVesselRB;
    public RemoveOverTime Remover;
    public NPCGun Gun;
    public GameObject GunGO;
    public GameObject MainGO;
    public Rigidbody GunRB;
    public Rigidbody MainRB;
    public MeshCollider GunCol;
    public MeshCollider MainCol;
    public Transform TCTF;
    public bool LineOfFire;
    public float ShootFrequency;
    public float UniqueShootTime;
    public Transform target;
    public Transform targetDestination;
    public Transform targetFinalDestination;
    public Transform TargetTrace;
    public Transform TargetLead;
    public AnimationCurve LeadCurve;
    public int TargetCode;
    public float LeadAmount;
    public bool isStationed;
    public bool isSurvivor;
    public bool damaged;
    public bool braking;
    public bool Obstacle;
    public bool RObstacle;
    public bool LObstacle;
    public GameObject MissilePrefab;
    public Transform thisTransform;
    public Transform viewPoint;
    public Transform gunPivot;
    public Transform midSurfacePoint;
    public Transform frontSurfacePoint;
    public Transform rightSurfacePoint;
    public Transform leftSurfacePoint;
    public float RelClamp;
    public float RelClampE;
    public float RelClamp2;
    public float RelClamp2E;
    public float HitDistSplit;
    public float Dist;
    public float Accnum;
    public LayerMask targetLayers;
    public virtual void Start()
    {
        this.InvokeRepeating("Ticker", 1, 0.15f);
        this.InvokeRepeating("Shoot", this.UniqueShootTime, this.ShootFrequency);
        this.UniqueShootTime = Random.Range(1, 2);
        GameObject gO1 = new GameObject("TT");
        GameObject gO2 = new GameObject("TL" + this.TargetCode);
        this.TargetTrace = gO1.transform;
        this.TargetLead = gO2.transform;
        this.TargetTrace.position = this.transform.position;
        this.TargetTrace.rotation = this.transform.rotation;
        this.TargetLead.position = this.transform.position;
        this.TargetLead.rotation = this.transform.rotation;
        this.TargetTrace.parent = this.upperParent;
        this.TargetLead.parent = this.upperParent;
        gO2.layer = 29;
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        RaycastHit VPhit = default(RaycastHit);
        if (this.damaged)
        {
            return;
        }
        if (this.target)
        {
            this.Dist = Vector3.Distance(this.thisTransform.position, this.target.position);
        }
        if (this.TCTF)
        {
            this.TCTF.rotation = this.thisTransform.rotation;
            this.TCTF.position = this.thisTransform.position;
        }
        if (!this.targetDestination)
        {
            this.StartCoroutine(this.Damage());
            this.damaged = true;
            return;
        }
        Vector3 relativePoint = this.thisTransform.InverseTransformPoint(this.targetDestination.position);
        Vector3 relativePointE = this.gunPivot.InverseTransformPoint(this.targetDestination.position);
        Vector3 relativePointM = new Vector3(), relativePointF = new Vector3(), relativePointR = new Vector3(), relativePointL = new Vector3();
        if (this.midSurfacePoint)
        {
            relativePointM = this.thisTransform.InverseTransformPoint(this.midSurfacePoint.position);
        }
        if (this.frontSurfacePoint)
        {
            relativePointF = this.thisTransform.InverseTransformPoint(this.frontSurfacePoint.position);
        }
        if (this.rightSurfacePoint)
        {
            relativePointR = this.thisTransform.InverseTransformPoint(this.rightSurfacePoint.position);
        }
        if (this.leftSurfacePoint)
        {
            relativePointL = this.thisTransform.InverseTransformPoint(this.leftSurfacePoint.position);
        }
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.up * 1), -this.thisTransform.up * 8, Color.red);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.up * 1), -this.thisTransform.up, out hit, 8, (int) this.targetLayers))
        {
            this.midSurfacePoint.position = hit.point;
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.up * 1)) + (this.thisTransform.forward * 2), -this.thisTransform.up * 8, Color.red);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.up * 1)) + (this.thisTransform.forward * 2), -this.thisTransform.up, out hit, 8, (int) this.targetLayers))
        {
            this.frontSurfacePoint.position = hit.point;
            this.braking = false;
        }
        else
        {
            this.braking = true;
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.up * 1)) + (this.thisTransform.right * 1), -this.thisTransform.up * 8, Color.red);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.up * 1)) + (this.thisTransform.right * 1), -this.thisTransform.up, out hit, 8, (int) this.targetLayers))
        {
            this.rightSurfacePoint.position = hit.point;
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.up * 1)) + (-this.thisTransform.right * 1), -this.thisTransform.up * 8, Color.red);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.up * 1)) + (-this.thisTransform.right * 1), -this.thisTransform.up, out hit, 8, (int) this.targetLayers))
        {
            this.leftSurfacePoint.position = hit.point;
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.up * 1)) + (-this.thisTransform.forward * 2), -this.thisTransform.up * 8, Color.red);
        if (!Physics.Raycast((this.thisTransform.position + (this.thisTransform.up * 1)) + (-this.thisTransform.forward * 2), -this.thisTransform.up, out hit, 8, (int) this.targetLayers))
        {
            this.braking = false;
        }
        if (!this.isStationed)
        {
            if (this.targetDestination)
            {
                this.Dist = Vector3.Distance(this.thisTransform.position, this.targetDestination.position);
            }
            if (this.targetDestination)
            {
                
                float LAndR = relativePoint.x;
                float UAndD = relativePointE.y;
                this.RelClampE = Mathf.Clamp(UAndD / this.Dist, -2, 2);
                this.RelClamp = Mathf.Clamp(LAndR / this.Dist, -2, 2);
                this.LineOfFire = false;

                {
                    float _3594 = this.gunPivot.localEulerAngles.x - this.RelClampE;
                    Vector3 _3595 = this.gunPivot.localEulerAngles;
                    _3595.x = _3594;
                    this.gunPivot.localEulerAngles = _3595;
                }
                if (!this.Obstacle)
                {

                    {
                        float _3596 = this.thisTransform.localEulerAngles.y + this.RelClamp;
                        Vector3 _3597 = this.thisTransform.localEulerAngles;
                        _3597.y = _3596;
                        this.thisTransform.localEulerAngles = _3597;
                    }
                }
                if (this.targetFinalDestination)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.targetDestination.position) < 5)
                    {
                        this.targetDestination = this.targetFinalDestination;
                        this.targetFinalDestination = null;
                    }
                }
                else
                {
                    if (Vector3.Distance(this.thisTransform.position, this.targetDestination.position) < 2)
                    {
                        this.isStationed = true;
                    }
                }
            }
            if (-this.gunPivot.localEulerAngles.x < 180)
            {
                if (-this.gunPivot.localEulerAngles.x > 60)
                {

                    {
                        int _3598 = -60;
                        Vector3 _3599 = this.gunPivot.localEulerAngles;
                        _3599.x = _3598;
                        this.gunPivot.localEulerAngles = _3599;
                    }
                }
            }
            if (this.gunPivot.localEulerAngles.x > 180)
            {
                if (this.gunPivot.localEulerAngles.x < 300)
                {

                    {
                        int _3600 = 300;
                        Vector3 _3601 = this.gunPivot.localEulerAngles;
                        _3601.x = _3600;
                        this.gunPivot.localEulerAngles = _3601;
                    }
                }
            }
            else
            {
                if (this.gunPivot.localEulerAngles.x > 7)
                {

                    {
                        int _3602 = 7;
                        Vector3 _3603 = this.gunPivot.localEulerAngles;
                        _3603.x = _3602;
                        this.gunPivot.localEulerAngles = _3603;
                    }
                }
            }
            //viewPoint.LookAt(targetDestination);
            //Debug.DrawRay (viewPoint.position, viewPoint.forward * 8000, Color.yellow);
            //if (Physics.Raycast (viewPoint.position, viewPoint.forward, VPhit, 8000, targetLayers)){
            //Debug.Log(VPhit.transform.name);
            //braking = true;
            //}
            this.thisTransform.position = this.thisTransform.position + (this.thisTransform.forward * this.Accnum);
            if (!this.braking)
            {
                if (this.Accnum < 0.1f)
                {
                    this.Accnum = this.Accnum + 0.002f;
                }
                else
                {
                    this.Accnum = 0.1f;
                }

                {
                    float _3604 = this.thisTransform.localEulerAngles.x - (relativePointF.y * 4);
                    Vector3 _3605 = this.thisTransform.localEulerAngles;
                    _3605.x = _3604;
                    this.thisTransform.localEulerAngles = _3605;
                }

                {
                    float _3606 = this.thisTransform.localEulerAngles.z + (relativePointR.y * 4);
                    Vector3 _3607 = this.thisTransform.localEulerAngles;
                    _3607.z = _3606;
                    this.thisTransform.localEulerAngles = _3607;
                }

                {
                    float _3608 = this.thisTransform.localEulerAngles.z - (relativePointL.y * 4);
                    Vector3 _3609 = this.thisTransform.localEulerAngles;
                    _3609.z = _3608;
                    this.thisTransform.localEulerAngles = _3609;
                }
            }
            else
            {
                if (-this.Accnum < 0.002f)
                {
                    this.Accnum = this.Accnum - 0.005f;
                }
                else
                {
                    this.Accnum = 0.002f;
                }
            }
            this.thisTransform.position = this.thisTransform.position + ((this.thisTransform.up * relativePointM.y) * 0.5f);
        }
        else
        {
            Vector3 relativePointTD = new Vector3();
            if (this.targetDestination)
            {
                relativePointTD = this.thisTransform.InverseTransformPoint(this.targetDestination.position);
            }
            if (this.target)
            {
                Vector3 relativePoint2 = this.thisTransform.InverseTransformPoint(this.TargetLead.position);
                Vector3 relativePoint2E = this.gunPivot.InverseTransformPoint(this.TargetLead.position);
                float LAndR = relativePoint2.x;
                float UAndD = relativePoint2E.y;
                this.RelClamp2E = Mathf.Clamp(UAndD / this.Dist, -2, 2);
                this.RelClamp2 = Mathf.Clamp(LAndR / this.Dist, -2, 2);
            }

            {
                float _3610 = this.gunPivot.localEulerAngles.x - (this.RelClamp2E * 4);
                Vector3 _3611 = this.gunPivot.localEulerAngles;
                _3611.x = _3610;
                this.gunPivot.localEulerAngles = _3611;
            }

            {
                float _3612 = this.thisTransform.localEulerAngles.y + (this.RelClamp2 * 4);
                Vector3 _3613 = this.thisTransform.localEulerAngles;
                _3613.y = _3612;
                this.thisTransform.localEulerAngles = _3613;
            }
            if (-this.gunPivot.localEulerAngles.x < 180)
            {
                if (-this.gunPivot.localEulerAngles.x > 60)
                {

                    {
                        int _3614 = -60;
                        Vector3 _3615 = this.gunPivot.localEulerAngles;
                        _3615.x = _3614;
                        this.gunPivot.localEulerAngles = _3615;
                    }
                }
            }
            if (this.gunPivot.localEulerAngles.x > 180)
            {
                if (this.gunPivot.localEulerAngles.x < 300)
                {

                    {
                        int _3616 = 300;
                        Vector3 _3617 = this.gunPivot.localEulerAngles;
                        _3617.x = _3616;
                        this.gunPivot.localEulerAngles = _3617;
                    }
                }
            }
            else
            {
                if (this.gunPivot.localEulerAngles.x > 7)
                {

                    {
                        int _3618 = 7;
                        Vector3 _3619 = this.gunPivot.localEulerAngles;
                        _3619.x = _3618;
                        this.gunPivot.localEulerAngles = _3619;
                    }
                }
            }

            {
                float _3620 = this.thisTransform.localEulerAngles.x - (relativePointF.y * 4);
                Vector3 _3621 = this.thisTransform.localEulerAngles;
                _3621.x = _3620;
                this.thisTransform.localEulerAngles = _3621;
            }

            {
                float _3622 = this.thisTransform.localEulerAngles.z + (relativePointR.y * 4);
                Vector3 _3623 = this.thisTransform.localEulerAngles;
                _3623.z = _3622;
                this.thisTransform.localEulerAngles = _3623;
            }

            {
                float _3624 = this.thisTransform.localEulerAngles.z - (relativePointL.y * 4);
                Vector3 _3625 = this.thisTransform.localEulerAngles;
                _3625.z = _3624;
                this.thisTransform.localEulerAngles = _3625;
            }
            this.thisTransform.position = this.thisTransform.position + ((this.thisTransform.up * relativePointM.y) * 0.5f);
            this.thisTransform.position = this.thisTransform.position + ((this.thisTransform.right * relativePointTD.x) * 0.01f);
            this.thisTransform.position = this.thisTransform.position + ((this.thisTransform.forward * relativePointTD.z) * 0.01f);
        }
        this.Obstacle = false;
        this.RObstacle = false;
        this.LObstacle = false;
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 1)) + (this.thisTransform.right * 1)) + (this.thisTransform.forward * 2), -this.thisTransform.up * 8, Color.green);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 1)) + (this.thisTransform.right * 1)) + (this.thisTransform.forward * 2), -this.thisTransform.up, out hit, 8, (int) this.targetLayers))
        {
            this.Obstacle = true;
            this.RObstacle = true;
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 1)) + (-this.thisTransform.right * 1)) + (this.thisTransform.forward * 2), -this.thisTransform.up * 8, Color.green);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 1)) + (-this.thisTransform.right * 1)) + (this.thisTransform.forward * 2), -this.thisTransform.up, out hit, 8, (int) this.targetLayers))
        {
            this.Obstacle = true;
            this.LObstacle = true;
        }
        if (this.RObstacle && this.LObstacle)
        {

            {
                float _3626 = this.thisTransform.localEulerAngles.y + 1;
                Vector3 _3627 = this.thisTransform.localEulerAngles;
                _3627.y = _3626;
                this.thisTransform.localEulerAngles = _3627;
            }
        }
        else
        {
            if (this.RObstacle)
            {

                {
                    float _3628 = this.thisTransform.localEulerAngles.y - 1;
                    Vector3 _3629 = this.thisTransform.localEulerAngles;
                    _3629.y = _3628;
                    this.thisTransform.localEulerAngles = _3629;
                }
            }
            if (this.LObstacle)
            {

                {
                    float _3630 = this.thisTransform.localEulerAngles.y + 1;
                    Vector3 _3631 = this.thisTransform.localEulerAngles;
                    _3631.y = _3630;
                    this.thisTransform.localEulerAngles = _3631;
                }
            }
        }
    }

    public virtual void Shoot()
    {
        if (this.target)
        {
            if (this.isStationed)
            {
                if ((((this.RelClamp2E < 0.1f) && (this.RelClamp2 < 0.1f)) && (-this.RelClamp2E < 0.1f)) && (-this.RelClamp2 < 0.1f))
                {
                    if (Vector3.Distance(this.thisTransform.position, this.target.position) < 1300)
                    {
                        this.LineOfFire = true;
                    }
                    else
                    {
                        this.LineOfFire = false;
                    }
                }
                else
                {
                    this.LineOfFire = false;
                }
            }
            else
            {
                this.LineOfFire = false;
            }
            if (this.LineOfFire)
            {
                if (this.target.name.Contains("TC"))
                {
                    this.Gun.Fire();
                }
            }
        }
    }

    public virtual void Ticker()
    {
        if (this.localParent)
        {
            this.thisTransform.parent = this.absoluteParent;
            UnityEngine.Object.Destroy(this.localParent.gameObject);
        }
        else
        {
            this.thisTransform.parent = this.absoluteParent;
        }
        GameObject gO = new GameObject("TurretParent");
        this.localParent = gO.transform;
        this.localParent.position = this.thisTransform.position;
        this.localParent.rotation = this.thisTransform.rotation;
        this.localParent.parent = this.absoluteParent;
        this.thisTransform.parent = this.localParent;
        if (!this.isSurvivor)
        {
            if (this.absoluteParent.name.Contains("rok"))
            {
                this.isSurvivor = true;
                GameObject TCTFgo = new GameObject("mTC" + this.TargetCode);
                this.TCTF = TCTFgo.transform;
                SphereCollider SCol = this.TCTF.gameObject.AddComponent<SphereCollider>();
                SCol.radius = 4;
                this.TCTF.gameObject.layer = 29;
                this.TCTF.gameObject.tag = "TC";
            }
        }
        this.StartCoroutine(this.Lead());
    }

    public virtual IEnumerator Lead()
    {
        if (this.target && this.TargetTrace)
        {
            this.TargetTrace.position = this.target.position;
        }
        yield return new WaitForSeconds(0.1f);
        if (this.target && this.TargetTrace)
        {
            float Dist1 = Vector3.Distance(this.TargetTrace.position, this.target.position);
            float Dist2 = this.LeadCurve.Evaluate(this.Dist) * Dist1;
            this.TargetTrace.LookAt(this.target);
            this.TargetLead.position = this.TargetTrace.position;
            this.TargetLead.rotation = this.TargetTrace.rotation;
            this.TargetLead.position = this.TargetLead.position + ((this.TargetLead.forward * Dist2) * this.LeadAmount);
        }
    }

    public virtual IEnumerator Damage()
    {
        if (!this)
        {
            yield break;
        }
        if (this.damaged)
        {
            yield break;
        }
        this.MainCol.enabled = false;
        this.GunCol.enabled = false;
        this.damaged = true;
        yield return new WaitForSeconds(0.1f);
        this.Remover.Active = true;
        UnityEngine.Object.Destroy(this.GunRB);
        UnityEngine.Object.Destroy(this.MainRB);
        if (this.TargetTrace)
        {
            UnityEngine.Object.Destroy(this.TargetTrace.gameObject);
        }
        if (this.TargetLead)
        {
            UnityEngine.Object.Destroy(this.TargetLead.gameObject);
        }
        this.GunGO.layer = 0;
        this.MainGO.layer = 0;
        if (!this.GetComponent<Rigidbody>())
        {
            Rigidbody theRB = this.gameObject.AddComponent<Rigidbody>();
            theRB.drag = 0.1f;
            theRB.angularDrag = 0.1f;
            theRB.velocity = this.mainVesselRB.velocity;
        }
        if (this.TCTF)
        {
            UnityEngine.Object.Destroy(this.TCTF.gameObject);
        }
        if (this.thisTransform)
        {
            if (this.thisTransform.parent)
            {
                GameObject TheParent = this.thisTransform.parent.gameObject;
                UnityEngine.Object.Destroy(TheParent);
            }
        }
        this.thisTransform.parent = null;
        this.MainCol.enabled = true;
        this.GunCol.enabled = true;
        UnityEngine.Object.Destroy(this);
    }

    public SurfaceTurretAI()
    {
        this.ShootFrequency = 0.1f;
        this.UniqueShootTime = 0.1f;
        this.LeadCurve = new AnimationCurve();
        this.LeadAmount = 0.017f;
    }

}