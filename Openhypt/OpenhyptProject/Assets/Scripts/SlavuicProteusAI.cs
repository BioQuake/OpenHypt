using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SlavuicProteusAI : MonoBehaviour
{
    public Transform target;
    public Transform Comrade;
    public Transform Suspect;
    public Transform ResetView;
    public Transform Home;
    public MeshCollider trig;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public AudioSource WorkAudio;
    public AudioSource BeamAudio;
    public AudioSource BeamStopAudio;
    public bool CruiserAttachment;
    public bool Complementary;
    public bool IsDroneLauncher;
    public bool IsRayGun;
    public bool IsRadar;
    public SlavuicCruiserAI PartnerCruiserAI;
    public SlavuicProteusAI PartnerDroneLauncherAI;
    public SlavuicProteusAI PartnerRayGunAI1;
    public SlavuicProteusAI PartnerRayGunAI2;
    public int trigRadius;
    public int trigPosZ;
    public GameObject ZapPrefab;
    public GameObject TheZap;
    public Transform Muzzle;
    public GameObject Drone1Prefab;
    public Transform Drone1Spawn;
    public GameObject Drone1Model;
    public SlavuicMachineAI Drone1AI;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public float AimForceMod;
    public float TurnForce;
    public float RPModX;
    public float RPModZ;
    public float RPxClamp;
    public float RPzClamp;
    public float HoriNum;
    public float VertNum;
    public float FuckingRead;
    public int Obscurity;
    public bool Priority;
    public int PriorityBreak;
    public bool Obstacle;
    public bool HasDrone;
    public bool IsZapping;
    public LayerMask targetLayers;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Updater", 1, 0.3f);
        if (this.Drone1Model)
        {
            if (this.Drone1Model.activeSelf == true)
            {
                this.HasDrone = true;
            }
        }
        this.target = this.ResetView;
        if (!this.CruiserAttachment)
        {
            if (SlavuicNetwork.instance.SlavBaseHomePoint != null)
            {
                if (Vector3.Distance(this.thisTransform.position, SlavuicNetwork.instance.SlavBaseHomePoint.position) < 1000)
                {
                    this.Home = SlavuicNetwork.instance.SlavBaseHomePoint;
                }
            }
        }
        int randomValue = Random.Range(0, 1);
        yield return new WaitForSeconds(randomValue);
        if (!this.CruiserAttachment)
        {
            if (this.IsRadar)
            {
                if (SlavuicNetwork.instance.BaseRadar1 == null)
                {
                    SlavuicNetwork.instance.BaseRadar1 = this;
                }
                else
                {
                    if (SlavuicNetwork.instance.BaseRadar2 == null)
                    {
                        SlavuicNetwork.instance.BaseRadar2 = this;
                    }
                }
            }
        }
        if (this.IsDroneLauncher)
        {
            this.AimForceMod = 0.01f;
            if (SlavuicNetwork.instance.BaseDroneLauncher == null)
            {
                SlavuicNetwork.instance.BaseDroneLauncher = this;
            }
        }
        if (this.IsRayGun)
        {
            this.AimForceMod = 0.02f;
            if (!this.CruiserAttachment)
            {
                if (SlavuicNetwork.instance.BaseRayGun1 == null)
                {
                    SlavuicNetwork.instance.BaseRayGun1 = this;
                }
                else
                {
                    if (SlavuicNetwork.instance.BaseRayGun2 == null)
                    {
                        SlavuicNetwork.instance.BaseRayGun2 = this;
                    }
                }
            }
        }
        yield return new WaitForSeconds(2);
        if (this.IsRadar)
        {
            if (SlavuicNetwork.instance.BaseDroneLauncher != null)
            {
                this.PartnerDroneLauncherAI = SlavuicNetwork.instance.BaseDroneLauncher;
            }
            if (SlavuicNetwork.instance.BaseRayGun1 != null)
            {
                this.PartnerRayGunAI1 = SlavuicNetwork.instance.BaseRayGun1;
            }
            if (SlavuicNetwork.instance.BaseRayGun2 != null)
            {
                this.PartnerRayGunAI2 = SlavuicNetwork.instance.BaseRayGun2;
            }
        }
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.IsDroneLauncher)
        {
            this.Obstacle = false;
            Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 5)) + (this.thisTransform.right * 2), this.thisTransform.forward * 128, Color.black);
            if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 5)) + (this.thisTransform.right * 2), this.thisTransform.forward, 128))
            {
                this.Obstacle = true;
            }
            Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 5)) + (-this.thisTransform.right * 2), this.thisTransform.forward * 128, Color.black);
            if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 5)) + (-this.thisTransform.right * 2), this.thisTransform.forward, 128))
            {
                this.Obstacle = true;
            }
        }
        if (this.IsRayGun)
        {
            this.Obstacle = false;
            Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 8)) + (this.thisTransform.right * 1), this.thisTransform.forward * 1000, Color.yellow);
            Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 8)) + (-this.thisTransform.right * 1), this.thisTransform.forward * 1000, Color.yellow);
            Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 8)) + (-this.thisTransform.up * 1), this.thisTransform.forward * 1000, Color.yellow);
            if ((Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 8)) + (this.thisTransform.right * 1), this.thisTransform.forward, out hit, 1000, (int) this.targetLayers) || Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 8)) + (-this.thisTransform.right * 1), this.thisTransform.forward, out hit, 1000, (int) this.targetLayers)) || Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 8)) + (-this.thisTransform.up * 1), this.thisTransform.forward, out hit, 1000, (int) this.targetLayers))
            {
                if ((hit.collider.tag.Contains("tru") || hit.collider.name.Contains("slav")) || hit.collider.name.Contains("T5"))
                {
                    this.Obstacle = true;
                }
            }
            if (this.Obstacle)
            {
                if (this.IsZapping)
                {
                    UnityEngine.Object.Destroy(this.TheZap);
                    this.IsZapping = false;
                    this.BeamStopAudio.Play();
                }
            }
        }
    }

    private Vector3 RP;
    public virtual void FixedUpdate()
    {
        if (!this.IsRadar)
        {
            if (this.target)
            {
                Vector3 RelativeTarget = this.thisVTransform.InverseTransformPoint(this.target.position);
                this.RP = RelativeTarget;
            }
            if (this.IsDroneLauncher)
            {
                this.RPModX = this.RP.x * this.AimForceMod;
                this.RPxClamp = Mathf.Clamp(this.RPModX, -this.TurnForce, this.TurnForce);
                this.vRigidbody.AddTorque(this.thisVTransform.forward * this.RPxClamp);
                this.HoriNum = Mathf.Abs(this.RPxClamp);
            }
            if (this.IsRayGun)
            {
                this.RPModX = this.RP.x * this.AimForceMod;
                this.RPxClamp = Mathf.Clamp(this.RPModX, -this.TurnForce, this.TurnForce);
                this.RPModZ = -this.RP.z * this.AimForceMod;
                this.RPzClamp = Mathf.Clamp(this.RPModZ, -this.TurnForce, this.TurnForce);
                this.vRigidbody.AddTorque(this.thisVTransform.forward * this.RPxClamp);
                this.vRigidbody.AddTorque(this.thisVTransform.right * this.RPzClamp);
                this.HoriNum = Mathf.Abs(this.RPxClamp);
                this.VertNum = Mathf.Abs(this.RPzClamp);
                if (!this.IsZapping)
                {
                    if (this.BeamAudio.GetComponent<AudioSource>().volume > 0)
                    {
                        this.BeamAudio.volume = this.BeamAudio.volume - 0.05f;
                    }
                    else
                    {
                        this.BeamAudio.Stop();
                    }
                }
            }
            this.FuckingRead = this.HoriNum + this.VertNum;
        }
        else
        {
            if (!this.Complementary)
            {
                this.vRigidbody.AddTorque(this.thisVTransform.forward * -this.TurnForce);
            }
            if (!this.CruiserAttachment)
            {
                if (this.thisVTransform.localEulerAngles.z < 90)
                {
                    this.trig.enabled = true;
                }
                if ((this.thisVTransform.localEulerAngles.z > 90) && (this.thisVTransform.localEulerAngles.z < 270))
                {
                    this.trig.enabled = false;
                }
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (this.IsRadar)
        {
            if (ON.Contains("TFC"))
            {
                if (other.GetComponent<Rigidbody>())
                {
                    this.ThreatAssessment(other.GetComponent<Rigidbody>(), OT);
                }
                else
                {
                    if (ON.Contains("TFC0a"))
                    {
                        this.PissedAtTC0a = this.PissedAtTC0a + 1;
                    }
                    if (ON.Contains("TFC1"))
                    {
                        this.PissedAtTC1 = this.PissedAtTC1 + 1;
                    }
                    if (ON.Contains("TFC4"))
                    {
                        this.PissedAtTC4 = this.PissedAtTC4 + 1;
                    }
                    if (ON.Contains("TFC7"))
                    {
                        this.PissedAtTC7 = this.PissedAtTC7 + 1;
                    }
                    if (ON.Contains("TFC8"))
                    {
                        this.PissedAtTC8 = this.PissedAtTC8 + 1;
                    }
                    if (ON.Contains("TFC9"))
                    {
                        this.PissedAtTC9 = this.PissedAtTC9 + 1;
                    }
                }
            }
            if (this.PissedAtTC0a == 1)
            {
                if (ON.Contains("TC0a"))
                {
                    this.Suspect = OT;
                }
            }
            if (this.PissedAtTC1 == 1)
            {
                if (ON.Contains("TC1"))
                {
                    this.Suspect = OT;
                }
            }
            if (this.PissedAtTC3 == 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC3"))
                    {
                        this.Suspect = OT;
                    }
                }
            }
            if (this.PissedAtTC4 == 1)
            {
                if (ON.Contains("TC4"))
                {
                    this.Suspect = OT;
                }
            }
            if (!ON.Contains("cT"))
            {
                if (ON.Contains("TC6"))
                {
                    this.Suspect = OT;
                }
            }
            if (this.PissedAtTC7 == 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC7"))
                    {
                        this.Suspect = OT;
                    }
                }
            }
            if (this.PissedAtTC8 == 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC8"))
                    {
                        this.Suspect = OT;
                    }
                }
            }
            if (this.PissedAtTC9 == 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC9"))
                    {
                        this.Suspect = OT;
                    }
                }
            }
            if (this.CruiserAttachment)
            {
                if (!ON.Contains("TC5"))
                {
                    this.PartnerCruiserAI.TargetIn(OT);
                    this.PartnerCruiserAI.bottomTarget = OT;
                    if (ON.Contains("bMT"))
                    {
                        this.PartnerCruiserAI.upperTarget = OT;
                        this.Priority = false;
                        this.PriorityBreak = 6;
                    }
                    else
                    {
                        if (this.PriorityBreak < 1)
                        {
                            this.PartnerCruiserAI.upperTarget = OT;
                        }
                    }
                }
            }
        }
    }

    public virtual void ThreatAssessment(Rigidbody threatRB, Transform threatTF)
    {
        Vector3 RTT = threatTF.InverseTransformPoint(this.thisVTransform.position);
        float RTPx = Mathf.Abs(RTT.x);
        float RTPy = Mathf.Abs(RTT.y);
        float RTP = RTPx + RTPy;
        GameObject Load = ((GameObject) Resources.Load("Prefabs/ThreatCursor", typeof(GameObject))) as GameObject;
        GameObject TGO = UnityEngine.Object.Instantiate(Load, threatTF.position + (threatTF.forward * threatRB.velocity.z), threatTF.rotation);
        if (threatRB.name.Contains("TFC0a"))
        {
            this.PissedAtTC0a = 1;
        }
        if (threatRB.name.Contains("TFC1"))
        {
            this.PissedAtTC1 = 1;
        }
        if (threatRB.name.Contains("TFC4"))
        {
            this.PissedAtTC4 = 1;
        }
        if (threatRB.name.Contains("TFC7"))
        {
            this.PissedAtTC7 = 1;
        }
        if (threatRB.name.Contains("TFC8"))
        {
            this.PissedAtTC8 = 1;
        }
        if (threatRB.name.Contains("TFC9"))
        {
            this.PissedAtTC9 = 1;
        }
        if (Vector3.Distance(this.thisTransform.position, TGO.transform.position) < 200)
        {
            if (threatRB.name.Contains("TFC0a"))
            {
                if (this.PissedAtTC0a == 1)
                {
                    this.PissedAtTC0a = 2;
                }
            }
            if (threatRB.name.Contains("TFC1"))
            {
                if (this.PissedAtTC1 == 1)
                {
                    this.PissedAtTC1 = 2;
                }
            }
            if (threatRB.name.Contains("TFC4"))
            {
                if (this.PissedAtTC4 == 1)
                {
                    this.PissedAtTC4 = 2;
                }
            }
            if (threatRB.name.Contains("TFC7"))
            {
                if (this.PissedAtTC7 == 1)
                {
                    this.PissedAtTC7 = 2;
                }
            }
            if (threatRB.name.Contains("TFC8"))
            {
                if (this.PissedAtTC8 == 1)
                {
                    this.PissedAtTC8 = 2;
                }
            }
            if (threatRB.name.Contains("TFC9"))
            {
                if (this.PissedAtTC9 == 1)
                {
                    this.PissedAtTC9 = 2;
                }
            }
            UnityEngine.Object.Destroy(TGO);
        }
        else
        {
            if (RTP < 150)
            {
                if (this.Suspect)
                {
                    if (Vector3.Distance(this.Suspect.position, TGO.transform.position) > 1000)
                    {
                        if (threatRB.name.Contains("TFC0a"))
                        {
                            if (this.PissedAtTC0a == 1)
                            {
                                this.PissedAtTC0a = 2;
                            }
                        }
                        if (threatRB.name.Contains("TFC1"))
                        {
                            if (this.PissedAtTC1 == 1)
                            {
                                this.PissedAtTC1 = 2;
                            }
                        }
                        if (threatRB.name.Contains("TFC4"))
                        {
                            if (this.PissedAtTC4 == 1)
                            {
                                this.PissedAtTC4 = 2;
                            }
                        }
                        if (threatRB.name.Contains("TFC7"))
                        {
                            if (this.PissedAtTC7 == 1)
                            {
                                this.PissedAtTC7 = 2;
                            }
                        }
                        if (threatRB.name.Contains("TFC8"))
                        {
                            if (this.PissedAtTC8 == 1)
                            {
                                this.PissedAtTC8 = 2;
                            }
                        }
                        if (threatRB.name.Contains("TFC9"))
                        {
                            if (this.PissedAtTC9 == 1)
                            {
                                this.PissedAtTC9 = 2;
                            }
                        }
                    }
                    else
                    {
                        if (RTT.z > 0)
                        {
                            if (threatRB.name.Contains("TFC0a"))
                            {
                                if (this.PissedAtTC0a == 1)
                                {
                                    this.PissedAtTC0a = 2;
                                }
                            }
                            if (threatRB.name.Contains("TFC1"))
                            {
                                if (this.PissedAtTC1 == 1)
                                {
                                    this.PissedAtTC1 = 2;
                                }
                            }
                            if (threatRB.name.Contains("TFC4"))
                            {
                                if (this.PissedAtTC4 == 1)
                                {
                                    this.PissedAtTC4 = 2;
                                }
                            }
                            if (threatRB.name.Contains("TFC7"))
                            {
                                if (this.PissedAtTC7 == 1)
                                {
                                    this.PissedAtTC7 = 2;
                                }
                            }
                            if (threatRB.name.Contains("TFC8"))
                            {
                                if (this.PissedAtTC8 == 1)
                                {
                                    this.PissedAtTC8 = 2;
                                }
                            }
                            if (threatRB.name.Contains("TFC9"))
                            {
                                if (this.PissedAtTC9 == 1)
                                {
                                    this.PissedAtTC9 = 2;
                                }
                            }
                        }
                    }
                }
            }
            UnityEngine.Object.Destroy(TGO);
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (this.IsRadar)
        {
            if (!this.Priority)
            {
                if (this.PissedAtTC0a > 1)
                {
                    if (ON.Contains("TC0a"))
                    {
                        this.target = OT;
                        if (this.CruiserAttachment)
                        {
                            if (Vector3.Distance(this.thisTransform.position, OT.position) < 256)
                            {
                                this.PartnerCruiserAI.OnHull = true;
                            }
                        }
                    }
                }
                if (this.PissedAtTC1 > 1)
                {
                    if (ON.Contains("TC1"))
                    {
                        this.target = OT;
                        if (this.CruiserAttachment)
                        {
                            if (Vector3.Distance(this.thisTransform.position, OT.position) < 256)
                            {
                                this.PartnerCruiserAI.OnHull = true;
                            }
                        }
                    }
                }
                if (this.PissedAtTC3 > 1)
                {
                    if (!ON.Contains("cT"))
                    {
                        if (ON.Contains("TC3"))
                        {
                            this.target = OT;
                            if (this.CruiserAttachment)
                            {
                                if (Vector3.Distance(this.thisTransform.position, OT.position) < 256)
                                {
                                    this.PartnerCruiserAI.OnHull = true;
                                }
                            }
                        }
                    }
                }
                if (this.PissedAtTC4 > 1)
                {
                    if (ON.Contains("TC4"))
                    {
                        this.target = OT;
                        if (this.CruiserAttachment)
                        {
                            if (Vector3.Distance(this.thisTransform.position, OT.position) < 256)
                            {
                                this.PartnerCruiserAI.OnHull = true;
                            }
                        }
                    }
                }
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC6"))
                    {
                        this.target = OT;
                        if (this.CruiserAttachment)
                        {
                            if (Vector3.Distance(this.thisTransform.position, OT.position) < 256)
                            {
                                this.PartnerCruiserAI.OnHull = true;
                            }
                        }
                    }
                }
                if (this.PissedAtTC7 > 1)
                {
                    if (!ON.Contains("cT"))
                    {
                        if (ON.Contains("TC7"))
                        {
                            this.target = OT;
                            if (this.CruiserAttachment)
                            {
                                if (Vector3.Distance(this.thisTransform.position, OT.position) < 256)
                                {
                                    this.PartnerCruiserAI.OnHull = true;
                                }
                            }
                        }
                    }
                }
                if (this.PissedAtTC8 > 1)
                {
                    if (!ON.Contains("cT"))
                    {
                        if (ON.Contains("TC8"))
                        {
                            this.target = OT;
                            if (this.CruiserAttachment)
                            {
                                if (Vector3.Distance(this.thisTransform.position, OT.position) < 256)
                                {
                                    this.PartnerCruiserAI.OnHull = true;
                                }
                            }
                        }
                    }
                }
                if (this.PissedAtTC9 > 1)
                {
                    if (!ON.Contains("cT"))
                    {
                        if (ON.Contains("TC9"))
                        {
                            this.target = OT;
                            if (this.CruiserAttachment)
                            {
                                if (Vector3.Distance(this.thisTransform.position, OT.position) < 256)
                                {
                                    this.PartnerCruiserAI.OnHull = true;
                                }
                            }
                        }
                    }
                }
                if (this.CruiserAttachment)
                {
                    if (ON.Contains("xbTC5"))
                    {
                        this.Comrade = OT;
                    }
                }
                if (this.PriorityBreak < 1)
                {
                    if (ON.Contains("bMT"))
                    {
                        this.target = OT;
                        this.Priority = true;
                    }
                }
            }
        }
    }

    public virtual void Updater()
    {
        if (SlavuicNetwork.TC1DeathRow > 8)
        {
            this.PissedAtTC1 = 2;
        }
        if (SlavuicNetwork.TC3DeathRow > 8)
        {
            this.PissedAtTC3 = 2;
        }
        if (SlavuicNetwork.TC4DeathRow > 8)
        {
            this.PissedAtTC4 = 2;
        }
        if (SlavuicNetwork.TC6DeathRow > 8)
        {
            PissedAtTC6 = 2;
        }
        if (SlavuicNetwork.TC7DeathRow > 8)
        {
            this.PissedAtTC7 = 2;
        }
        if (SlavuicNetwork.TC8DeathRow > 8)
        {
            this.PissedAtTC8 = 2;
        }
        if (SlavuicNetwork.TC9DeathRow > 8)
        {
            this.PissedAtTC9 = 2;
        }
        if (this.target)
        {
            if (this.IsRadar)
            {
                if (!this.CruiserAttachment)
                {
                    if (this.PartnerDroneLauncherAI)
                    {
                        if (this.PartnerDroneLauncherAI.target)
                        {
                            this.PartnerDroneLauncherAI.target = this.target;
                        }
                    }
                    if (this.PartnerRayGunAI1)
                    {
                        if (this.PartnerRayGunAI1.target)
                        {
                            if (!this.PartnerRayGunAI1.target.name.Contains("TC"))
                            {
                                this.PartnerRayGunAI1.target = this.target;
                            }
                        }
                        if (this.target.name.Contains("bMT"))
                        {
                            this.PartnerRayGunAI1.target = this.target;
                        }
                    }
                    if (this.PartnerRayGunAI2)
                    {
                        if (this.PartnerRayGunAI2.target)
                        {
                            if (!this.PartnerRayGunAI2.target.name.Contains("TC"))
                            {
                                this.PartnerRayGunAI2.target = this.target;
                            }
                        }
                        if (this.target.name.Contains("bMT"))
                        {
                            this.PartnerRayGunAI2.target = this.target;
                        }
                    }
                }
                else
                {
                    if (this.PriorityBreak > 0)
                    {
                        this.PriorityBreak = this.PriorityBreak - 1;
                    }
                }
            }
            if (this.IsDroneLauncher)
            {
                if (this.HasDrone && !this.Obstacle)
                {
                    if (this.target.name.Contains("TC"))
                    {
                        this.StartCoroutine(this.Launch());
                    }
                }
                if (this.Drone1AI)
                {
                    this.Drone1AI.AssignedTarget = this.target;
                }
            }
            if (this.IsRayGun)
            {
                if ((Vector3.Distance(this.thisTransform.position, this.target.position) > 1000) || (this.Obscurity > 4))
                {
                    this.target = this.ResetView;
                }
                if (!this.Obstacle)
                {
                    if (this.target.name.Contains("TC"))
                    {
                        this.StartCoroutine(this.Zap());
                    }
                    else
                    {
                        if (this.IsZapping)
                        {
                            UnityEngine.Object.Destroy(this.TheZap);
                            this.IsZapping = false;
                            this.BeamStopAudio.Play();
                        }
                    }
                    this.Obscurity = 0;
                }
                else
                {
                    if ((this.FuckingRead < 0.5f) && this.target.name.Contains("TC"))
                    {
                        this.Obscurity = this.Obscurity + 1;
                    }
                    else
                    {
                        this.Obscurity = 0;
                    }
                }
            }
        }
        else
        {
            this.target = this.ResetView;
        }
        if (this.CruiserAttachment)
        {
            if (this.Comrade)
            {
                this.PartnerCruiserAI.Comrade = this.Comrade;
            }
        }
    }

    public virtual IEnumerator Zap()
    {
        yield return new WaitForSeconds(0.1f);
        if (this.target)
        {
            if ((!this.Obstacle && (this.FuckingRead < 0.02f)) && this.target.name.Contains("TC"))
            {
                if (!this.IsZapping)
                {
                    this.IsZapping = true;
                    this.TheZap = UnityEngine.Object.Instantiate(this.ZapPrefab, this.Muzzle.position, this.Muzzle.rotation);
                    this.TheZap.transform.parent = this.thisTransform.parent;
                    this.BeamAudio.GetComponent<AudioSource>().volume = 1;
                    this.BeamAudio.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                if (this.IsZapping)
                {
                    UnityEngine.Object.Destroy(this.TheZap);
                    this.IsZapping = false;
                    this.BeamStopAudio.Play();
                }
            }
        }
        else
        {
            if (this.IsZapping)
            {
                UnityEngine.Object.Destroy(this.TheZap);
                this.IsZapping = false;
                this.BeamStopAudio.Play();
            }
        }
    }

    public virtual IEnumerator Launch()
    {
        yield return new WaitForSeconds(0.1f);
        if (this.target)
        {
            if (this.IsDroneLauncher)
            {
                if ((this.HasDrone && !this.Obstacle) && (this.FuckingRead < 0.01f))
                {
                    if (this.target.name.Contains("TC"))
                    {
                        this.HasDrone = false;
                        this.Drone1Model.gameObject.SetActive(false);
                        this.WorkAudio.Play();
                        GameObject Spawn1 = UnityEngine.Object.Instantiate(this.Drone1Prefab, this.Drone1Spawn.position, this.Drone1Spawn.rotation);
                        Spawn1.transform.GetChild(0).GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                        Spawn1.transform.GetChild(0).GetComponent<Rigidbody>().AddForce(this.Drone1Spawn.transform.right * 200);
                        this.Drone1AI = (SlavuicMachineAI) Spawn1.transform.GetChild(0).GetComponent(typeof(SlavuicMachineAI));
                        this.Drone1AI.target = this.target;
                        this.Drone1AI.Home = this.Home;
                    }
                }
            }
        }
    }

    public SlavuicProteusAI()
    {
        this.trigRadius = 2;
        this.AimForceMod = 0.01f;
        this.TurnForce = 1;
    }

}