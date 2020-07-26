using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class OotkinSensor : MonoBehaviour
{
    public GameObject Ootkin;
    public GameObject Limb1;
    public GameObject Limb2;
    public GameObject Limb3;
    public AudioClip audioC1;
    public AudioClip audioC2;
    public AudioClip audioC3;
    public Transform EndemicTarget;
    public Transform Target;
    public Transform Antagonist;
    public float WanderStrength;
    public float Power;
    public float OotkinTransparency;
    public float OotkinFadeSpeed;
    public float OotkinFadeoutSpeed;
    public float OotkinFadeinSpeed;
    public RemoveOverTime Remover;
    public int Lifetime;
    public bool Wander;
    public bool WanderAllAxis;
    public bool SomeoneClose;
    public bool Fadeout;
    public bool CanPlayNoise;
    public virtual void Start()
    {
        this.InvokeRepeating("Ticker", 1, 1);
        this.Lifetime = this.Lifetime - Random.Range(0, this.Lifetime - 20);

        {
            int _2518 = 0;
            Color _2519 = this.Ootkin.GetComponent<Renderer>().material.color;
            _2519.a = _2518;
            this.Ootkin.GetComponent<Renderer>().material.color = _2519;
        }
        if (this.Limb1 != null)
        {

            {
                int _2520 = 0;
                Color _2521 = this.Limb1.GetComponent<Renderer>().material.color;
                _2521.a = _2520;
                this.Limb1.GetComponent<Renderer>().material.color = _2521;
            }
        }
        if (this.Limb2 != null)
        {

            {
                int _2522 = 0;
                Color _2523 = this.Limb2.GetComponent<Renderer>().material.color;
                _2523.a = _2522;
                this.Limb2.GetComponent<Renderer>().material.color = _2523;
            }
        }
        if (this.Limb3 != null)
        {

            {
                int _2524 = 0;
                Color _2525 = this.Limb3.GetComponent<Renderer>().material.color;
                _2525.a = _2524;
                this.Limb3.GetComponent<Renderer>().material.color = _2525;
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (!this.Fadeout)
        {
            if (this.SomeoneClose && (this.Ootkin.GetComponent<Renderer>().material.color.a > 0))
            {

                {
                    float _2526 = this.Ootkin.GetComponent<Renderer>().material.color.a - this.OotkinFadeoutSpeed;
                    Color _2527 = this.Ootkin.GetComponent<Renderer>().material.color;
                    _2527.a = _2526;
                    this.Ootkin.GetComponent<Renderer>().material.color = _2527;
                }
                if (this.Limb1 != null)
                {

                    {
                        float _2528 = this.Limb1.GetComponent<Renderer>().material.color.a - this.OotkinFadeoutSpeed;
                        Color _2529 = this.Limb1.GetComponent<Renderer>().material.color;
                        _2529.a = _2528;
                        this.Limb1.GetComponent<Renderer>().material.color = _2529;
                    }
                }
                if (this.Limb2 != null)
                {

                    {
                        float _2530 = this.Limb2.GetComponent<Renderer>().material.color.a - this.OotkinFadeoutSpeed;
                        Color _2531 = this.Limb2.GetComponent<Renderer>().material.color;
                        _2531.a = _2530;
                        this.Limb2.GetComponent<Renderer>().material.color = _2531;
                    }
                }
                if (this.Limb3 != null)
                {

                    {
                        float _2532 = this.Limb3.GetComponent<Renderer>().material.color.a - this.OotkinFadeoutSpeed;
                        Color _2533 = this.Limb3.GetComponent<Renderer>().material.color;
                        _2533.a = _2532;
                        this.Limb3.GetComponent<Renderer>().material.color = _2533;
                    }
                }
            }
            if (!this.SomeoneClose && (this.Ootkin.GetComponent<Renderer>().material.color.a < this.OotkinTransparency))
            {

                {
                    float _2534 = this.Ootkin.GetComponent<Renderer>().material.color.a + this.OotkinFadeinSpeed;
                    Color _2535 = this.Ootkin.GetComponent<Renderer>().material.color;
                    _2535.a = _2534;
                    this.Ootkin.GetComponent<Renderer>().material.color = _2535;
                }
                if (this.Limb1 != null)
                {

                    {
                        float _2536 = this.Limb1.GetComponent<Renderer>().material.color.a + this.OotkinFadeinSpeed;
                        Color _2537 = this.Limb1.GetComponent<Renderer>().material.color;
                        _2537.a = _2536;
                        this.Limb1.GetComponent<Renderer>().material.color = _2537;
                    }
                }
                if (this.Limb2 != null)
                {

                    {
                        float _2538 = this.Limb2.GetComponent<Renderer>().material.color.a + this.OotkinFadeinSpeed;
                        Color _2539 = this.Limb2.GetComponent<Renderer>().material.color;
                        _2539.a = _2538;
                        this.Limb2.GetComponent<Renderer>().material.color = _2539;
                    }
                }
                if (this.Limb3 != null)
                {

                    {
                        float _2540 = this.Limb3.GetComponent<Renderer>().material.color.a + this.OotkinFadeinSpeed;
                        Color _2541 = this.Limb3.GetComponent<Renderer>().material.color;
                        _2541.a = _2540;
                        this.Limb3.GetComponent<Renderer>().material.color = _2541;
                    }
                }
            }
        }
        else
        {
            if (this.Ootkin.GetComponent<Renderer>().material.color.a > 0)
            {

                {
                    float _2542 = this.Ootkin.GetComponent<Renderer>().material.color.a - this.OotkinFadeoutSpeed;
                    Color _2543 = this.Ootkin.GetComponent<Renderer>().material.color;
                    _2543.a = _2542;
                    this.Ootkin.GetComponent<Renderer>().material.color = _2543;
                }
                if (this.Limb1 != null)
                {

                    {
                        float _2544 = this.Limb1.GetComponent<Renderer>().material.color.a - this.OotkinFadeoutSpeed;
                        Color _2545 = this.Limb1.GetComponent<Renderer>().material.color;
                        _2545.a = _2544;
                        this.Limb1.GetComponent<Renderer>().material.color = _2545;
                    }
                }
                if (this.Limb2 != null)
                {

                    {
                        float _2546 = this.Limb2.GetComponent<Renderer>().material.color.a - this.OotkinFadeoutSpeed;
                        Color _2547 = this.Limb2.GetComponent<Renderer>().material.color;
                        _2547.a = _2546;
                        this.Limb2.GetComponent<Renderer>().material.color = _2547;
                    }
                }
                if (this.Limb3 != null)
                {

                    {
                        float _2548 = this.Limb3.GetComponent<Renderer>().material.color.a - this.OotkinFadeoutSpeed;
                        Color _2549 = this.Limb3.GetComponent<Renderer>().material.color;
                        _2549.a = _2548;
                        this.Limb3.GetComponent<Renderer>().material.color = _2549;
                    }
                }
            }
        }
        if (this.Lifetime > 2)
        {
            if (this.Target)
            {
                if (Vector3.Distance(this.transform.position, this.Target.position) < 1)
                {
                    OotkinDistortScript.TouchingOotkin = true;
                }
            }
            if (this.Target)
            {
                if (Vector3.Distance(this.transform.position, this.Target.position) < 2)
                {
                    OotkinDistortScript.ContactingOotkin = true;
                }
            }
            if (this.Target)
            {
                if (Vector3.Distance(this.transform.position, this.Target.position) > 5)
                {
                    OotkinDistortScript.ContactingOotkin = false;
                }
            }
        }
        if (this.Wander && !this.WanderAllAxis)
        {
            this.Ootkin.GetComponent<Rigidbody>().AddTorque(this.transform.forward * Random.Range(-this.WanderStrength, this.WanderStrength));
        }
        if (this.Wander && this.WanderAllAxis)
        {
            this.Ootkin.GetComponent<Rigidbody>().AddTorque(this.transform.right * Random.Range(-this.WanderStrength, this.WanderStrength));
            this.Ootkin.GetComponent<Rigidbody>().AddTorque(this.transform.up * Random.Range(-this.WanderStrength, this.WanderStrength));
            this.Ootkin.GetComponent<Rigidbody>().AddTorque(this.transform.forward * Random.Range(-this.WanderStrength, this.WanderStrength));
        }
        if ((this.EndemicTarget != null) && (Vector3.Distance(this.transform.position, this.EndemicTarget.position) > 200))
        {
            this.Ootkin.GetComponent<Rigidbody>().AddForce((this.EndemicTarget.transform.position - this.transform.position).normalized * this.Power);
        }
        if (this.Target != null)
        {
            if (Vector3.Distance(this.transform.position, this.Target.position) < 20)
            {
                this.Ootkin.GetComponent<Rigidbody>().AddForce((this.Target.transform.position - this.transform.position).normalized * this.Power);
            }
            else
            {
                this.Ootkin.GetComponent<Rigidbody>().AddForce(this.transform.up * -this.Power);
            }
        }
        else
        {
            this.Ootkin.GetComponent<Rigidbody>().AddForce(this.transform.up * -this.Power);
        }
        if ((this.Antagonist != null) && (Vector3.Distance(this.transform.position, this.Antagonist.position) < 20))
        {
            this.Ootkin.GetComponent<Rigidbody>().AddForce((this.Antagonist.transform.position - this.transform.position).normalized * -0.004f);
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.name == "PiriHeatSource")
        {
            this.SomeoneClose = true;
            this.Target = other.gameObject.transform;
            this.Sound();
            this.StartCoroutine(this.Cooldown());
            this.Lifetime = Random.Range(40, 80);
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (other.name == "OoDet")
        {
            this.Antagonist = other.gameObject.transform;
        }
        if (this.Lifetime > 2)
        {
            if (other.name == "Oof")
            {
                this.Lifetime = 2;
            }
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.name == "PiriHeatSource")
        {
            this.SomeoneClose = false;
            this.Target = null;
        }
    }

    public virtual IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2);
        this.CanPlayNoise = true;
    }

    public virtual void Ticker()
    {
        this.Lifetime = this.Lifetime - 1;
        if (this.Lifetime < 3)
        {
            this.Fadeout = true;
            this.OotkinFadeoutSpeed = 0.01f;
            OotkinDistortScript.TouchingOotkin = false;
            OotkinDistortScript.ContactingOotkin = false;
        }
        if (this.Lifetime < 1)
        {
            this.StartCoroutine(this.Remover.Removal());
        }
    }

    public virtual void Sound()
    {
        if (!this.CanPlayNoise)
        {
            return;
        }
        this.CanPlayNoise = false;
        int randomValue = Random.Range(1, 4);
        switch (randomValue)
        {
            case 1:
                this.GetComponent<AudioSource>().PlayOneShot(this.audioC1);
                break;
            case 2:
                this.GetComponent<AudioSource>().PlayOneShot(this.audioC2);
                break;
            case 3:
                this.GetComponent<AudioSource>().PlayOneShot(this.audioC3);
                break;
        }
    }

    public OotkinSensor()
    {
        this.Power = 0.01f;
        this.OotkinTransparency = 0.8f;
        this.OotkinFadeSpeed = 0.02f;
        this.OotkinFadeoutSpeed = 0.02f;
        this.OotkinFadeinSpeed = 0.02f;
        this.Lifetime = 60;
        this.CanPlayNoise = true;
    }

}