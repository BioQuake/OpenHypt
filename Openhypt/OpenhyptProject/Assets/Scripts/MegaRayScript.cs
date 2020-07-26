using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MegaRayScript : MonoBehaviour
{
    public bool AgrianTurretRay;
    public bool AgrianSuperRay;
    public bool RegularRay;
    public bool PulseRay;
    public bool PlayerShot;
    public bool Unchild;
    public Transform RayStart;
    public float startPoint;
    public int RayReach;
    public int RayLevel;
    public float TimeDelay;
    public AudioSource FinalSFX;
    public GameObject collision;
    public GameObject finalCollision;
    public GameObject RayLight;
    public GameObject RayEffect;
    public GameObject ChargeEffect;
    public bool RayOn;
    public bool ReadyMode;
    public bool FireMode;
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    private bool P1Go;
    private bool P2Go;
    private bool P3Go;
    public virtual IEnumerator Start()
    {
        RaycastHit hit1 = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        RaycastHit hit3 = default(RaycastHit);
        RaycastHit hit = default(RaycastHit);
        this.InvokeRepeating("HitTick", 0, 0.05f);
        if (!this.RegularRay)
        {
            if (!this.AgrianSuperRay)
            {
                if (!this.AgrianTurretRay)
                {
                    if (this.ReadyMode)
                    {
                        yield return new WaitForSeconds(3.2f);
                        this.ChargeEffect.gameObject.SetActive(true);
                    }
                    if (this.FireMode)
                    {
                        this.RayLight.SetActive(true);
                        this.RayEffect.SetActive(true);
                        yield return new WaitForSeconds(0.1f);
                        this.RayOn = true;
                        yield return new WaitForSeconds(4.1f);
                        this.RayOn = false;
                        this.RayLight.SetActive(false);
                        this.RayEffect.SetActive(false);
                    }
                }
                else
                {
                    yield return new WaitForSeconds(0.15f);
                    this.RayEffect.SetActive(true);
                    this.RayLight.SetActive(true);
                    this.RayOn = true;
                    yield return new WaitForSeconds(0.7f);
                    this.RayOn = false;
                    this.RayLight.SetActive(false);
                    this.RayEffect.SetActive(false);
                }
            }
            else
            {
                yield return new WaitForSeconds(this.TimeDelay);
                this.RayLight.gameObject.SetActive(true);
                if (this.Unchild)
                {
                    this.transform.parent = null;
                }
                if (Physics.Raycast(this.transform.position, this.transform.forward, out hit1, 20000, (int) this.targetLayers))
                {
                    UnityEngine.Object.Instantiate(this.collision, hit1.point, Quaternion.identity);
                    if (hit1.rigidbody)
                    {
                        if (hit1.rigidbody.mass > 6)
                        {
                            Vector3 Point1 = hit1.point;
                            Quaternion NormalAngle1 = Quaternion.LookRotation(hit1.normal);
                            yield return new WaitForSeconds(hit1.distance * 0.00015f);
                            UnityEngine.Object.Instantiate(this.finalCollision, Point1, NormalAngle1);
                        }
                        else
                        {
                            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit2, 20000, (int) this.MtargetLayers))
                            {
                                Vector3 Point2 = hit2.point;
                                Quaternion NormalAngle2 = Quaternion.LookRotation(hit2.normal);
                                yield return new WaitForSeconds(hit2.distance * 0.00015f);
                                UnityEngine.Object.Instantiate(this.finalCollision, Point2, NormalAngle2);
                            }
                        }
                    }
                    else
                    {
                        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit3, 20000, (int) this.MtargetLayers))
                        {
                            Vector3 Point3 = hit3.point;
                            Quaternion NormalAngle3 = Quaternion.LookRotation(hit3.normal);
                            yield return new WaitForSeconds(hit3.distance * 0.00015f);
                            UnityEngine.Object.Instantiate(this.finalCollision, Point3, NormalAngle3);
                        }
                    }
                }
            }
        }
        else
        {
            if (!this.PulseRay)
            {
                this.RayOn = true;
            }
            else
            {
                yield return new WaitForSeconds(this.TimeDelay);
                if (this.PlayerShot)
                {
                    AgrianNetwork.instance.Curiosity = AgrianNetwork.instance.Curiosity + this.RayLevel;
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
                if (this.RayEffect)
                {
                    this.RayEffect.SetActive(true);
                }
                if (this.FinalSFX)
                {
                    this.FinalSFX.Play();
                }
                if (Physics.Raycast(this.transform.position + (this.transform.forward * this.startPoint), this.transform.forward, out hit, this.RayReach, (int) this.targetLayers))
                {
                    UnityEngine.Object.Instantiate(this.collision, hit.point, Quaternion.identity);
                }
            }
        }
    }

    public virtual void HitTick()
    {
        RaycastHit hit = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        if (this.RayOn)
        {
            if (this.AgrianTurretRay)
            {
                this.transform.Rotate(0.002f, 0, 0);
            }
            if (!this.RegularRay)
            {
                if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, this.RayReach, (int) this.targetLayers))
                {
                    UnityEngine.Object.Instantiate(this.collision, hit.point, Quaternion.identity);
                }
            }
            else
            {
                if (Physics.SphereCast(this.RayStart.position, 1, this.transform.forward, out hit2, this.RayReach, (int) this.targetLayers))
                {
                    UnityEngine.Object.Instantiate(this.collision, hit2.point, Quaternion.identity);
                }
            }
        }
    }

    public MegaRayScript()
    {
        this.startPoint = 0.1f;
        this.RayReach = 20000;
        this.RayLevel = 20;
        this.TimeDelay = 0.25f;
    }

}