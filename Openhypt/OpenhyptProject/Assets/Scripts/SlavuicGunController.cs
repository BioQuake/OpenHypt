using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SlavuicGunController : MonoBehaviour
{
    public Transform TurretTarget;
    public Transform ResetView;
    public Transform Muzzle1;
    public Transform Muzzle2;
    public Transform Muzzle3;
    public Transform Muzzle4;
    public Transform Muzzle5;
    public Transform Muzzle6;
    public Transform Muzzle7;
    public Transform Muzzle8;
    public Transform Muzzle9;
    public Transform Muzzle10;
    public Transform Muzzle11;
    public Transform Muzzle12;
    public Transform LauncherTF;
    public Transform TargetTrace;
    public Transform TargetLead;
    public int Lead1Time;
    public int Lead2Time;
    public Transform Overview;
    public GameObject VentEffect;
    public Transform Vent1;
    public Transform Vent2;
    public Transform Vent3;
    public Transform Vent4;
    public Transform Pivot;
    public ConfigurableJoint ConJoint;
    public float GunWidth;
    public AnimationCurve PitchCurve;
    public float PitchAmount;
    public float PitchMod;
    public float PitchForce;
    public float LeadMod;
    public float LeadMod2;
    public float LeadDiv;
    public float Dist1;
    public float Dist2;
    public bool LeadLeader;
    public int AimForce;
    public int Cooldown;
    public int Counter;
    public int Xrot;
    public int Calm;
    public Vector3 VelDir;
    public Vector3 RelativeTarget;
    public float RPX;
    public float RPY;
    public float FuckingRead1;
    public float FuckingRead2;
    public bool Firing;
    public GameObject Fire1;
    public SlavuicVesselAI SlavuicAI;
    public SlavuicCruiserAI SlavuicCAI;
    public bool CruiserAttachment;
    public GameObject Vessel;
    public LayerMask targetLayers;
    public LayerMask OtargetLayers;
    public bool Launcher;
    public bool BigLauncher;
    public bool ExtraThiccLauncher;
    public bool ExtraTubes;
    public bool Obscured;
    public bool Stable;
    public bool Idle;
    public bool BusyFiring;
    public virtual void Start()
    {
        this.InvokeRepeating("Resetter", 1.1f, 0.25f);
        this.InvokeRepeating("Count", 0.7f, 1);
        if (!this.ExtraThiccLauncher)
        {
            if (!this.BigLauncher)
            {
                if (this.CruiserAttachment)
                {
                    this.LeadMod2 = 0.013f;
                }
                else
                {
                    this.LeadMod2 = 0.005f;
                }
                this.LeadMod = 0.08f;
            }
            else
            {
                this.LeadMod2 = 0.004f;
                this.LeadMod = 0.03f;
            }
        }
        else
        {
            this.LeadMod2 = 0.004f;
            this.LeadMod = 0.03f;
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.TurretTarget)
        {
            if (this.TargetLead)
            {
                this.RelativeTarget = this.LauncherTF.InverseTransformPoint(this.TargetLead.position);
            }
            float Dist = this.RelativeTarget.z;
            this.PitchForce = this.PitchAmount;
            this.PitchAmount = this.PitchCurve.Evaluate(Dist) * this.PitchMod;
            if (this.CruiserAttachment)
            {
                float DistMod1 = Dist * 0.1f;
                float DistMod2 = Dist * 0.1f;
                float RPModX = (this.RelativeTarget.x / Dist) / DistMod1;
                float RPModY = (this.RelativeTarget.y / Dist) / DistMod2;
                this.RPX = RPModX * 500;
                this.RPY = RPModY * 500;
                this.FuckingRead1 = Mathf.Abs(this.RPX);
                this.FuckingRead2 = Mathf.Abs(this.RPY);
            }
            if (this.Lead1Time < 1)
            {
                this.Lead1Time = 8;
                this.Lead2Time = 4;
                if ((this.CruiserAttachment && this.LeadLeader) || !this.CruiserAttachment)
                {
                    this.Lead1();
                }
            }
            else
            {
                this.Lead1Time = this.Lead1Time - 1;
            }
            if (this.Lead2Time < 1)
            {
                this.Lead2Time = 8;
                this.Lead2Time = 4;
                if ((this.CruiserAttachment && this.LeadLeader) || !this.CruiserAttachment)
                {
                    this.Lead2();
                }
            }
            else
            {
                this.Lead2Time = this.Lead2Time - 1;
            }
        }
        if (this.GetComponent<Rigidbody>().angularVelocity.magnitude < 1)
        {
            this.GetComponent<Rigidbody>().AddTorque(this.transform.right * -this.PitchForce);
            if (!this.ExtraThiccLauncher)
            {
                this.AimForce = 20;
            }
            else
            {
                this.AimForce = 40;
            }
        }
        else
        {
            this.AimForce = 0;
        }
        if (!this.Idle)
        {
            this.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.transform.position - this.transform.position).normalized * this.AimForce, this.transform.forward * 2);
            this.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.transform.position - this.transform.position).normalized * -this.AimForce, -this.transform.forward * 2);
        }
        else
        {
            if (this.TurretTarget)
            {
                this.GetComponent<Rigidbody>().AddForceAtPosition((this.TurretTarget.transform.position - this.transform.position).normalized * this.AimForce, this.transform.forward * 2);
                this.GetComponent<Rigidbody>().AddForceAtPosition((this.TurretTarget.transform.position - this.transform.position).normalized * -this.AimForce, -this.transform.forward * 2);
            }
        }
        if (this.Firing && !this.Obscured)
        {
            this.Firing = false;
            if (this.Launcher)
            {
                this.StartCoroutine(this.Launch());
            }
            else
            {
                this.Fire();
            }
        }
    }

    public virtual IEnumerator Launch()
    {
        if (this.Stable)
        {
            if (this.Counter == 0)
            {
                this.Counter = this.Cooldown;
                this.BusyFiring = true;
                if (!this.ExtraThiccLauncher)
                {
                    if (!this.BigLauncher)
                    {
                        if (!this.ExtraTubes)
                        {
                            GameObject _SpawnedObject01 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle1.position, this.Muzzle1.rotation);
                            _SpawnedObject01.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                            yield return new WaitForSeconds(0.5f);
                            GameObject _SpawnedObject02 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle2.position, this.Muzzle2.rotation);
                            _SpawnedObject02.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                            yield return new WaitForSeconds(0.5f);
                            GameObject _SpawnedObject03 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle3.position, this.Muzzle3.rotation);
                            _SpawnedObject03.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                            yield return new WaitForSeconds(0.5f);
                            if (this.Muzzle4)
                            {
                                GameObject _SpawnedObject04 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle4.position, this.Muzzle4.rotation);
                                _SpawnedObject04.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                                yield return new WaitForSeconds(0.5f);
                            }
                            if (this.Muzzle5)
                            {
                                GameObject _SpawnedObject05 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle5.position, this.Muzzle5.rotation);
                                _SpawnedObject05.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                                yield return new WaitForSeconds(0.5f);
                            }
                            if (this.Muzzle6)
                            {
                                GameObject _SpawnedObject06 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle6.position, this.Muzzle6.rotation);
                                _SpawnedObject06.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                                yield return new WaitForSeconds(0.5f);
                            }
                            this.BusyFiring = false;
                        }
                        else
                        {
                            GameObject _SpawnedObject1 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle1.position, this.Muzzle1.rotation);
                            _SpawnedObject1.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                            yield return new WaitForSeconds(0.25f);
                            GameObject _SpawnedObject2 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle2.position, this.Muzzle2.rotation);
                            _SpawnedObject2.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                            yield return new WaitForSeconds(0.25f);
                            GameObject _SpawnedObject3 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle3.position, this.Muzzle3.rotation);
                            _SpawnedObject3.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                            yield return new WaitForSeconds(0.25f);
                            GameObject _SpawnedObject4 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle4.position, this.Muzzle4.rotation);
                            _SpawnedObject4.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                            yield return new WaitForSeconds(0.25f);
                            GameObject _SpawnedObject5 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle5.position, this.Muzzle5.rotation);
                            _SpawnedObject5.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                            yield return new WaitForSeconds(0.25f);
                            GameObject _SpawnedObject6 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle6.position, this.Muzzle6.rotation);
                            _SpawnedObject6.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                            yield return new WaitForSeconds(0.25f);
                            GameObject _SpawnedObject7 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle7.position, this.Muzzle7.rotation);
                            _SpawnedObject7.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                            yield return new WaitForSeconds(0.25f);
                            GameObject _SpawnedObject8 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle8.position, this.Muzzle8.rotation);
                            _SpawnedObject8.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                            yield return new WaitForSeconds(0.25f);
                            GameObject _SpawnedObject9 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle9.position, this.Muzzle9.rotation);
                            _SpawnedObject9.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                            yield return new WaitForSeconds(0.25f);
                            GameObject _SpawnedObject10 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle10.position, this.Muzzle10.rotation);
                            _SpawnedObject10.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                            yield return new WaitForSeconds(0.25f);
                            GameObject _SpawnedObject11 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle11.position, this.Muzzle11.rotation);
                            _SpawnedObject11.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                            yield return new WaitForSeconds(0.25f);
                            GameObject _SpawnedObject12 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle12.position, this.Muzzle12.rotation);
                            _SpawnedObject12.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                            yield return new WaitForSeconds(1);
                            this.BusyFiring = false;
                        }
                    }
                    else
                    {
                        GameObject TheThing = UnityEngine.Object.Instantiate(this.VentEffect, this.Vent1.position, this.Vent1.rotation);
                        TheThing.transform.parent = this.Vent1.transform;
                        yield return new WaitForSeconds(0.5f);
                        GameObject _SpawnedObject00 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle1.position, this.Muzzle1.rotation);
                        _SpawnedObject00.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                        yield return new WaitForSeconds(1);
                        this.BusyFiring = false;
                    }
                }
                else
                {
                    GameObject TheThing000 = UnityEngine.Object.Instantiate(this.VentEffect, this.Vent1.position, this.Vent1.rotation);
                    TheThing000.transform.parent = this.Vent1.transform;
                    yield return new WaitForSeconds(0.5f);
                    GameObject _SpawnedObject000 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle1.position, this.Muzzle1.rotation);
                    _SpawnedObject000.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                    GameObject TheThing001 = UnityEngine.Object.Instantiate(this.VentEffect, this.Vent2.position, this.Vent2.rotation);
                    TheThing001.transform.parent = this.Vent2.transform;
                    yield return new WaitForSeconds(0.5f);
                    GameObject _SpawnedObject001 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle2.position, this.Muzzle2.rotation);
                    _SpawnedObject001.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                    GameObject TheThing002 = UnityEngine.Object.Instantiate(this.VentEffect, this.Vent3.position, this.Vent3.rotation);
                    TheThing002.transform.parent = this.Vent3.transform;
                    yield return new WaitForSeconds(0.5f);
                    GameObject _SpawnedObject002 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle3.position, this.Muzzle3.rotation);
                    _SpawnedObject002.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                    GameObject TheThing003 = UnityEngine.Object.Instantiate(this.VentEffect, this.Vent4.position, this.Vent4.rotation);
                    TheThing003.transform.parent = this.Vent4.transform;
                    yield return new WaitForSeconds(0.5f);
                    GameObject _SpawnedObject003 = UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle4.position, this.Muzzle4.rotation);
                    _SpawnedObject003.GetComponent<Rigidbody>().velocity = this.Vessel.GetComponent<Rigidbody>().velocity * 1;
                    yield return new WaitForSeconds(1);
                    this.BusyFiring = false;
                }
            }
        }
    }

    public virtual void Fire()
    {
        if (this.Stable && !this.Obscured)
        {
            if (this.Counter == 0)
            {
                this.Counter = this.Cooldown;
                UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle1.position, this.Muzzle1.rotation);
            }
        }
    }

    public virtual void Lead1()
    {
        if (this.TurretTarget)
        {
            this.TargetTrace.position = this.TurretTarget.position;
        }
    }

    public virtual void Lead2()
    {
        if (this.TurretTarget)
        {
            if (this.LeadLeader)
            {
                this.Dist1 = Vector3.Distance(this.Overview.position, this.TurretTarget.position);
                this.Dist2 = Vector3.Distance(this.TargetTrace.position, this.TurretTarget.position);
            }
            else
            {
                this.Dist1 = Vector3.Distance(this.transform.position, this.TurretTarget.position);
                this.Dist2 = Vector3.Distance(this.TargetTrace.position, this.TurretTarget.position);
            }
            this.TargetTrace.LookAt(this.TurretTarget);
            this.TargetLead.position = this.TargetTrace.position;
            this.TargetLead.rotation = this.TargetTrace.rotation;
            this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * this.Dist1) * this.Dist2) * this.LeadMod);
            if (this.VelDir != Vector3.zero)
            {
                this.TargetLead.rotation = Quaternion.LookRotation(this.VelDir);
            }
            this.TargetLead.position = this.TargetLead.position - (((this.TargetLead.forward * this.LeadDiv) * this.Dist1) * this.LeadMod2);
        }
    }

    public virtual void Resetter()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.TurretTarget != null)
        {
            float ODist = Vector3.Distance(this.transform.position, this.TurretTarget.position);
            if (this.TurretTarget.name.Contains("TC"))
            {
                if (this.Calm > 0)
                {
                    this.Calm = this.Calm - 1;
                }
            }
            if (!this.TurretTarget.name.Contains("TC"))
            {
                this.Calm = 20;
            }
            this.Stable = false;
            if (!this.CruiserAttachment)
            {
                if (Vector3.Distance(this.transform.position, this.TurretTarget.position) < 500)
                {
                    if (this.GetComponent<Rigidbody>().angularVelocity.magnitude < 0.25f)
                    {
                        this.Stable = true;
                    }
                }
                else
                {
                    if ((this.GetComponent<Rigidbody>().angularVelocity.magnitude < 0.05f) && (this.GetComponent<Rigidbody>().velocity.magnitude < 0.2f))
                    {
                        this.Stable = true;
                    }
                }
            }
            else
            {
                if (this.TurretTarget.name.Contains("TC"))
                {
                    if (((this.GetComponent<Rigidbody>().angularVelocity.magnitude < 0.1f) && (this.FuckingRead1 < 0.5f)) && (this.FuckingRead2 < 0.7f))
                    {
                        this.Stable = true;
                    }
                }
            }
            if ((this.Calm > 0) || (this.transform.localEulerAngles.x > 180))
            {

                {
                    int _2992 = this.Xrot;
                    Vector3 _2993 = this.transform.localEulerAngles;
                    _2993.x = _2992;
                    this.transform.localEulerAngles = _2993;
                }
            }
            if (!this.CruiserAttachment)
            {
                if (!this.Launcher)
                {
                    if (Physics.Raycast(this.transform.position + (this.transform.forward * 2), this.transform.forward, out hit, 50, (int) this.targetLayers))
                    {
                        this.Obscured = true;
                    }
                    else
                    {
                        this.Obscured = false;
                    }
                }
                else
                {
                    if (Physics.Raycast(this.transform.position + (this.transform.forward * 2), this.transform.forward, out hit, 16, (int) this.targetLayers))
                    {
                        this.Obscured = true;
                    }
                    else
                    {
                        this.Obscured = false;
                    }
                }
                if ((this.Pivot.localEulerAngles.z < 40) || (this.Pivot.localEulerAngles.z > 320))
                {
                    this.Obscured = true;
                }
            }
            else
            {
                this.Obscured = true;
                Debug.DrawRay(this.LauncherTF.position + (this.transform.right * this.GunWidth), this.transform.forward * ODist, Color.yellow);
                Debug.DrawRay(this.LauncherTF.position + (-this.transform.right * this.GunWidth), this.transform.forward * ODist, Color.yellow);
                if (Physics.Raycast(this.LauncherTF.position + (this.transform.right * this.GunWidth), this.transform.forward, out hit, ODist, (int) this.OtargetLayers) || Physics.Raycast(this.LauncherTF.position + (-this.transform.right * this.GunWidth), this.transform.forward, out hit, ODist, (int) this.OtargetLayers))
                {
                    if (hit.collider.name.Contains("T5"))
                    {
                        this.Obscured = true;
                    }
                    else
                    {
                        this.Obscured = false;
                    }
                }
                else
                {
                    this.Obscured = false;
                }
                if ((this.Pivot.localEulerAngles.z < 240) && (this.Pivot.localEulerAngles.z > 120))
                {
                    this.Obscured = true;
                }
            }
        }
        if (this.SlavuicAI)
        {
            if (this.SlavuicAI.Attacking)
            {
                this.TurretTarget = this.SlavuicAI.target;
            }
            else
            {
                if (!this.BusyFiring)
                {
                    this.TurretTarget = this.ResetView;
                }
            }
        }
        if (this.SlavuicCAI)
        {
            if (this.SlavuicCAI.Attacking)
            {
                this.TurretTarget = this.SlavuicCAI.target;
            }
            else
            {
                if (!this.BusyFiring)
                {
                    this.TurretTarget = this.ResetView;
                }
            }
        }
        if (this.TurretTarget == this.ResetView)
        {
            this.Idle = true;
        }
        else
        {
            this.Idle = false;
        }
    }

    public virtual void Count()
    {
        if (this.Counter > 0)
        {
            this.Counter = this.Counter - 1;
        }
    }

    public SlavuicGunController()
    {
        this.GunWidth = 1.5f;
        this.PitchCurve = new AnimationCurve();
        this.PitchMod = 1f;
        this.LeadMod = 0.2f;
        this.LeadMod2 = 1.2f;
        this.LeadDiv = 1;
        this.Xrot = 90;
        this.Calm = 10;
    }

}