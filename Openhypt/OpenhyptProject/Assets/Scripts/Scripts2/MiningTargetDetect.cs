using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MiningTargetDetect : MonoBehaviour
{
    public GameObject Aimer;
    public GameObject AimerPoint;
    public GameObject AimerResetPoint;
    public GameObject MiningTarget;
    public GameObject IdleTarget;
    public AudioClip BeepLockon;
    public AudioClip BeepNolock;
    public AudioClip BeepReset;
    public AudioClip BeepLost;
    public virtual void Start()
    {
        MinerOnOff.switched = false;
        this.MiningTarget = this.IdleTarget;
        this.AimerPoint = GameObject.Find("AimPointTarget").gameObject;
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if ((WorldInformation.playerCar.Contains(this.transform.parent.name) && (other.tag == "Mineral")) && Input.GetKeyDown("3"))
        {
            this.GetComponent<AudioSource>().Stop();
            this.GetComponent<AudioSource>().PlayOneShot(this.BeepLockon);
            this.MiningTarget = other.gameObject;
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Mineral") && (this.MiningTarget == !this.IdleTarget))
        {
            this.GetComponent<AudioSource>().PlayOneShot(this.BeepLost);
            MinerOnOff.switched = false;
            this.MiningTarget = this.IdleTarget;
        }
    }

    public virtual void Update()
    {
        if (WorldInformation.playerCar.Contains(this.transform.parent.name) && Input.GetKeyDown("2"))
        {
            this.Aimer.GetComponent<TurretAim>().AimForward = this.AimerResetPoint;
            this.GetComponent<AudioSource>().PlayOneShot(this.BeepReset);
            MinerOnOff.switched = false;
            this.MiningTarget = this.IdleTarget;
        }
        if ((WorldInformation.playerCar.Contains(this.transform.parent.name) && Input.GetKeyDown("3")) && (this.MiningTarget == this.IdleTarget))
        {
            this.Aimer.GetComponent<TurretAim>().AimForward = this.AimerPoint;
            this.GetComponent<AudioSource>().PlayOneShot(this.BeepNolock);
        }
    }

}