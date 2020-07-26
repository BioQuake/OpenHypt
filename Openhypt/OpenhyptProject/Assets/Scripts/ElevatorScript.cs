using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ElevatorScript : MonoBehaviour
{
    public bool IsGate;
    public bool SingleSound;
    public bool LeftOpener;
    public bool IsNear;
    public bool Ascend;
    public bool Moved;
    public bool Moving;
    public Rigidbody VesselRB;
    public FixedJoint LockJoint;
    public ConfigurableJoint ElevatorJoint;
    public GameObject Elevator;
    public bool YAxis;
    public bool XAxis;
    public HingeJoint GateJoint;
    public GameObject Gate;
    public AudioSource ContAudio;
    public AudioSource StartAudio;
    public AudioSource StopAudio;
    public float ElevatorVolume;
    public float Num;
    public float Speed;
    public float AscendedNum;
    public GameObject OtherGO;
    public virtual void Start()
    {
        this.Moved = true;
    }

    public virtual void Update()
    {
        if (this.IsNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!this.OtherGO.name.Contains("sTC1p") || WorldInformation.UsingVessel)
                {
                    this.IsNear = false;
                    return;
                }
                if (this.SingleSound)
                {
                    if (this.Moved)
                    {
                        if (!this.Ascend)
                        {
                            this.Ascend = true;
                            this.Moving = true;
                            this.Moved = false;
                            this.StartAudio.Play();
                            if (this.LockJoint)
                            {
                                UnityEngine.Object.Destroy(this.LockJoint);
                            }
                            this.StopCoroutine("LockRB");
                        }
                        else
                        {
                            this.Ascend = false;
                            this.Moving = true;
                            this.Moved = false;
                            this.StartAudio.Play();
                            if (this.LockJoint)
                            {
                                UnityEngine.Object.Destroy(this.LockJoint);
                            }
                            this.StopCoroutine("LockRB");
                        }
                    }
                }
                else
                {
                    if (!this.Ascend)
                    {
                        this.Ascend = true;
                        this.Moving = true;
                        this.Moved = false;
                        this.StartAudio.Play();
                        if (this.LockJoint)
                        {
                            UnityEngine.Object.Destroy(this.LockJoint);
                        }
                        this.StopCoroutine("LockRB");
                    }
                    else
                    {
                        this.Ascend = false;
                        this.Moving = true;
                        this.Moved = false;
                        this.StartAudio.Play();
                        if (this.LockJoint)
                        {
                            UnityEngine.Object.Destroy(this.LockJoint);
                        }
                        this.StopCoroutine("LockRB");
                    }
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.Ascend)
        {
            if (!this.LeftOpener)
            {
                if (this.Num > this.AscendedNum)
                {
                    this.Num = this.Num - this.Speed;
                    this.Moving = true;
                }
                else
                {
                    this.Moving = false;
                }
            }
            else
            {
                if (-this.Num > this.AscendedNum)
                {
                    this.Num = this.Num - this.Speed;
                    this.Moving = true;
                }
                else
                {
                    this.Moving = false;
                }
            }
        }
        if (!this.Ascend)
        {
            if (!this.LeftOpener)
            {
                if (this.Num < 0)
                {
                    this.Num = this.Num + this.Speed;
                    this.Moving = true;
                }
                else
                {
                    this.Moving = false;
                }
            }
            else
            {
                if (-this.Num < 0)
                {
                    this.Num = this.Num + this.Speed;
                    this.Moving = true;
                }
                else
                {
                    this.Moving = false;
                }
            }
        }
        if (!this.Moving && !this.Moved)
        {
            if (!this.SingleSound)
            {
                this.StopAudio.Play();
            }
            this.Moved = true;
            this.StartCoroutine("LockRB");
        }
        if (!this.IsGate)
        {
            if (this.XAxis)
            {
                this.ElevatorJoint.targetPosition = new Vector3(this.Num, 0, 0);
            }
            else
            {
                if (this.YAxis)
                {
                    this.ElevatorJoint.targetPosition = new Vector3(0, this.Num, 0);
                }
                else
                {
                    this.ElevatorJoint.targetPosition = new Vector3(0, 0, this.Num);
                }
            }
        }
        else
        {

            {
                float _1976 = this.Num;
                JointSpring _1977 = this.GateJoint.spring;
                _1977.targetPosition = _1976;
                this.GateJoint.spring = _1977;
            }
        }
        if (!this.SingleSound)
        {
            if (this.Moving && (this.ContAudio.volume < this.ElevatorVolume))
            {
                this.ContAudio.volume = this.ContAudio.volume + 0.02f;
            }
            if (!this.Moving && (this.ContAudio.volume > 0))
            {
                this.ContAudio.volume = this.ContAudio.volume - 0.02f;
            }
        }
    }

    public virtual IEnumerator LockRB()
    {
        if (this.Moving)
        {
            yield break;
        }
        yield return new WaitForSeconds(0.5f);
        if (this.Moving)
        {
            yield break;
        }
        if (this.Elevator)
        {
            this.LockJoint = this.Elevator.AddComponent<FixedJoint>();
            if (this.VesselRB)
            {
                this.LockJoint.connectedBody = this.VesselRB;
            }
        }
        if (this.Gate)
        {
            this.LockJoint = this.Gate.AddComponent<FixedJoint>();
            if (this.VesselRB)
            {
                this.LockJoint.connectedBody = this.VesselRB;
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("sTC1p") || other.name.Contains("csTC1p"))
        {
            this.IsNear = true;
            this.OtherGO = other.gameObject;
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("sTC1p") || other.name.Contains("csTC1p"))
        {
            this.IsNear = false;
        }
    }

    public ElevatorScript()
    {
        this.ElevatorVolume = 1;
        this.Speed = 0.1f;
        this.AscendedNum = 6;
    }

}