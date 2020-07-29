using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PeukopedeAI : MonoBehaviour
{
    public Transform Target;
    public Rigidbody PeukRB;
    public Transform PeukTF;
    public Transform thisTC;
    public SphereCollider thisTrig;
    public bool BigPeuk;
    public Transform prongBase;
    public Transform startProng;
    public Transform prong;
    public int prongNum;
    public AnimationCurve prongCurve;
    public bool Pronged;
    public int ProngedTime;
    public tendrilSectionScript ProngEndScript;
    public int RetractTime;
    public AudioClip ProngOut;
    public AudioClip ProngIn;
    public AudioSource ProngAudio;
    public bool ProngSoundBool;
    public PeukopedeLegSensor LegRightSensor;
    public PeukopedeLegSensor LegLeftSensor;
    public Rigidbody LegRightRB;
    public Rigidbody LegLeftRB;
    public ConfigurableJoint LegRightCJ;
    public ConfigurableJoint LegLeftCJ;
    public float StandingStrength;
    public float Power;
    public float LegLiftPower;
    public float LegStandPower;
    public bool Standing;
    public float StrideTime;
    public float RestTime;
    public bool LegRightMove;
    public bool LegLeftMove;
    public bool Grab;
    public bool Tick;
    public bool PTick;
    public LayerMask MtargetLayers;
    public virtual void Start()
    {
        this.InvokeRepeating("Ticker", 1, 0.2f);
        if (this.BigPeuk)
        {
            //StuffSpawner.TheNPC006N = ((int) StuffSpawner.TheNPC006N) + 1;
        }
        else
        {
            StuffSpawner.TheNPC005N = StuffSpawner.TheNPC005N + 1;
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.Target)
        {
            Vector3 relativePoint = this.PeukTF.InverseTransformPoint(this.Target.position);
            float FAndB = relativePoint.x;
            if (this.LegRightMove && this.Standing)
            {
                this.LegRightRB.AddForce((this.Target.position - this.PeukTF.position).normalized * this.Power);
            }
            if (this.LegLeftMove && this.Standing)
            {
                this.LegLeftRB.AddForce((this.Target.position - this.PeukTF.position).normalized * this.Power);
            }
            if (this.Pronged)
            {
                if (this.ProngedTime > 0)
                {
                    this.ProngedTime = this.ProngedTime - 1;
                }
                else
                {
                    if (this.RetractTime < 1)
                    {
                        this.ProngEndScript.Retracting = true;
                        this.RetractTime = 240;
                        this.Grab = false;
                        if (this.ProngSoundBool)
                        {
                            this.ProngSoundBool = false;
                            this.ProngSoundIn();
                        }
                    }
                    else
                    {
                        this.RetractTime = this.RetractTime - 1;
                        if (this.RetractTime < 8)
                        {
                            this.Pronged = false;
                            this.RetractTime = 0;
                            this.prongNum = 0;
                            this.prong = this.startProng;
                        }
                    }
                }
            }
            if (this.Grab)
            {
                if (!this.Pronged)
                {
                    this.Pronging();
                    if (FAndB < 0)
                    {
                        this.LegRightSensor.LiftPower = (int) -this.LegStandPower;
                        this.LegLeftSensor.LiftPower = (int) -this.LegStandPower;
                    }
                }
                else
                {
                    if (FAndB > 0)
                    {
                        this.Grab = false;
                    }
                }
            }
            else
            {
                this.StartCoroutine(this.Walking());
            }
        }
        if (this.Standing == true)
        {
            this.PeukRB.AddForceAtPosition(Vector3.up * this.StandingStrength, this.PeukTF.up * 1);
            this.PeukRB.AddForceAtPosition(-Vector3.up * this.StandingStrength, -this.PeukTF.up * 1);
            this.PeukRB.useGravity = false;
            this.PeukRB.drag = 3;
        }
        else
        {
            this.PeukRB.useGravity = true;
            this.PeukRB.drag = 0;
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        GameObject OG = other.gameObject;
        if (Physics.Linecast(this.PeukTF.position, OT.position, (int) this.MtargetLayers))
        {
            return;
        }
        if (ON.Contains("TC"))
        {
            if (OG.GetComponent<TCInfo>())
            {
                if (OG.GetComponent<TCInfo>().IAmName == "Peukopede")
                {
                    return;
                }
            }
            this.thisTrig.radius = 0.01f;
            this.Target = OT;
        }
    }

    public virtual void Ticker()
    {
        if (this.thisTrig.radius < 24)
        {
            this.thisTrig.radius = this.thisTrig.radius + 1;
        }
        else
        {
            this.thisTrig.radius = 24;
        }
        if (this.Target)
        {
            if (Vector3.Distance(this.prongBase.position, this.Target.position) < 4)
            {
                if (!Physics.Linecast(this.prongBase.position, this.Target.position, (int) this.MtargetLayers))
                {
                    this.Grab = true;
                }
                if (this.thisTC.name == "TC0")
                {
                    this.StartCoroutine(this.TCResetter());
                }
            }
        }
    }

    public virtual IEnumerator TCResetter()
    {
        this.thisTC.name = "TC0a";
        yield return new WaitForSeconds(15);
        this.thisTC.name = "TC0";
    }

    public virtual IEnumerator Walking()
    {
        if (this.Tick)
        {
            yield break;
        }
        this.Tick = true;
        if (this.Standing == true)
        {
            this.LegRightMove = true;
            this.LegLeftMove = false;
            this.LegRightSensor.LiftPower = (int) this.LegLiftPower;
            this.LegLeftSensor.LiftPower = (int) -this.LegStandPower;
            yield return new WaitForSeconds(this.RestTime);
            this.LegLeftMove = false;
            this.LegRightMove = false;
            this.LegRightSensor.LiftPower = 0;
            this.LegLeftSensor.LiftPower = 0;
            yield return new WaitForSeconds(this.StrideTime);
            this.LegLeftMove = true;
            this.LegRightMove = false;
            this.LegRightSensor.LiftPower = (int) -this.LegStandPower;
            this.LegLeftSensor.LiftPower = (int) this.LegLiftPower;
            yield return new WaitForSeconds(this.RestTime);
            this.LegLeftMove = false;
            this.LegRightMove = false;
            this.LegRightSensor.LiftPower = 0;
            this.LegLeftSensor.LiftPower = 0;
            yield return new WaitForSeconds(this.StrideTime);
        }
        this.Tick = false;
    }

    public virtual IEnumerator LegMover()
    {
        this.LegRightMove = true;
        this.LegLeftMove = false;
        yield return new WaitForSeconds(0.5f);
        this.LegLeftMove = true;
        this.LegRightMove = false;
    }

    public virtual void Pronging()
    {
        if (this.PTick)
        {
            return;
        }
        this.PTick = true;
        if (!this.ProngSoundBool)
        {
            this.ProngSoundBool = true;
            this.ProngSoundOut();
        }
        float axisSize = this.prongCurve.Evaluate(this.prongNum);
        GameObject Load = ((GameObject) Resources.Load("Prefabs/prongSection", typeof(GameObject))) as GameObject;
        GameObject TGO = UnityEngine.Object.Instantiate(Load, this.prong.position + (this.prong.forward * 0.12f), this.prong.rotation);
        TGO.transform.parent = this.prongBase;
        this.ProngEndScript = (tendrilSectionScript) TGO.GetComponent(typeof(tendrilSectionScript));
        this.ProngEndScript.Root = this.prong;
        this.ProngEndScript.PeukAI = this;
        this.ProngEndScript.mainBody = this.PeukTF;
        this.prong = TGO.transform;

        {
            float _2606 = axisSize;
            Vector3 _2607 = this.prong.localScale;
            _2607.x = _2606;
            this.prong.localScale = _2607;
        }

        {
            float _2608 = axisSize;
            Vector3 _2609 = this.prong.localScale;
            _2609.y = _2608;
            this.prong.localScale = _2609;
        }
        if (this.Target)
        {
            Quaternion NewRotation = Quaternion.LookRotation(this.Target.position - this.prong.position);
            this.prong.rotation = Quaternion.RotateTowards(this.prong.rotation, NewRotation, Time.deltaTime * 1500);
        }
        this.prongNum = this.prongNum + 1;
        if (this.prongNum > 31)
        {
            this.ProngEndScript.isEnd = true;
            this.ProngedTime = 120;
            this.Pronged = true;
            this.Grab = false;
        }
        this.PTick = false;
    }

    public virtual void ProngSoundOut()
    {
        this.ProngAudio.clip = this.ProngOut;
        this.ProngAudio.Play();
    }

    public virtual void ProngSoundIn()
    {
        this.ProngAudio.clip = this.ProngIn;
        this.ProngAudio.Play();
    }

    public virtual void Damage()
    {
        if (this.BigPeuk)
        {
            //StuffSpawner.TheNPC006N = ((int) StuffSpawner.TheNPC006N) - 1;
        }
        else
        {
            StuffSpawner.TheNPC005N = StuffSpawner.TheNPC005N - 1;
        }
    }

    public PeukopedeAI()
    {
        this.prongCurve = new AnimationCurve();
        this.StandingStrength = 10f;
        this.Power = 0.01f;
        this.LegLiftPower = 1;
        this.LegStandPower = 1;
        this.StrideTime = 0.5f;
        this.RestTime = 0.5f;
    }

}