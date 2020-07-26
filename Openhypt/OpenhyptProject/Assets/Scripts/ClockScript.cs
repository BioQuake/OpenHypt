using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ClockScript : MonoBehaviour
{
    public Transform handFront;
    public Transform handBack;
    public AudioSource noise;
    public AudioSource bellNoise;
    public AudioClip minuteBell;
    public AudioClip halfhourBell;
    public AudioClip hourBell;
    public AudioClip halfraonBell;
    public int clockTime;
    public float prod;
    public float prod2;
    public bool Ticked;
    public bool Belled;
    public virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        this.GetComponent<AudioSource>().Play();
    }

    public virtual void FixedUpdate()
    {
        //65536 times 0.01098633
        if (WorldInformation.terrahyptTime > this.clockTime)
        {
            this.clockTime = WorldInformation.terrahyptTime;
            if (this.noise.time > 0.1f)
            {
                this.GetComponent<AudioSource>().Play();
            }
        }
        this.prod = WorldInformation.terrahyptTime;
        this.prod2 = this.prod * 0.005493165f;

        {
            float _1136 = -this.prod2;
            Vector3 _1137 = this.handFront.localEulerAngles;
            _1137.y = _1136;
            this.handFront.localEulerAngles = _1137;
        }

        {
            float _1138 = this.prod2;
            Vector3 _1139 = this.handBack.localEulerAngles;
            _1139.y = _1138;
            this.handBack.localEulerAngles = _1139;
        }
        if (WorldInformation.halfraonBell && !this.Belled)
        {
            this.Belled = true;
            this.bellNoise.PlayOneShot(this.halfraonBell);
            this.StartCoroutine(this.BellReset());
            return;
        }
        if (WorldInformation.halfhourBell && !this.Belled)
        {
            this.Belled = true;
            this.bellNoise.PlayOneShot(this.halfhourBell);
            this.StartCoroutine(this.BellReset());
            return;
        }
        if (WorldInformation.hourBell && !this.Belled)
        {
            this.Belled = true;
            this.bellNoise.PlayOneShot(this.hourBell);
            this.StartCoroutine(this.BellReset());
            return;
        }
        if (WorldInformation.minuteBell && !this.Belled)
        {
            this.Belled = true;
            this.bellNoise.PlayOneShot(this.minuteBell);
            this.StartCoroutine(this.BellReset());
            return;
        }
    }

    public virtual IEnumerator BellReset()
    {
        yield return new WaitForSeconds(8);
        this.Belled = false;
    }

}