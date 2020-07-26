using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AkbarmanController : MonoBehaviour
{
    public Transform Target;
    public Animation Ani;
    public GameObject DeathEffect;
    public bool IsOut;
    public bool AkbarLight;
    public bool AkbarHeavy;
    public bool Grounded;
    public bool Land;
    public LayerMask targetLayers;
    private bool once;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("PlayAni", 0.1f, Random.Range(0.8f, 1));
        yield return new WaitForSeconds(1);
        this.IsOut = true;
        yield return new WaitForSeconds(15);
        this.OldAge();
    }

    public virtual void Update()
    {
        Vector3 fwd = this.transform.TransformDirection(Vector3.down);
        if (Physics.Raycast(this.transform.position, fwd, 2.3f, (int) this.targetLayers))
        {
            this.Grounded = true;
            this.GetComponent<Rigidbody>().drag = 1;
        }
        else
        {
            this.Grounded = false;
            this.GetComponent<Rigidbody>().drag = 0.05f;
            this.Land = false;
            this.Ani.CrossFade("AkbarAirborneAni");
        }
        if ((this.Land == false) && (this.Grounded == true))
        {
            if (this.AkbarLight)
            {
                this.Ani.CrossFade("AkbarFlailAni1");
            }
            if (this.AkbarHeavy)
            {
                this.Ani.CrossFade("Akbar2FlailAni1");
            }
            this.Land = true;
        }
    }

    public virtual void FixedUpdate()
    {
        if (((this.GetComponent<Rigidbody>().velocity.magnitude > 60) && !this.once) && this.IsOut)
        {
            this.once = true;
            this.OldAge();
        }
        if (this.Grounded)
        {
            if (this.Target == null)
            {
                this.GetComponent<Rigidbody>().AddForce(this.transform.forward * 1.4f);
            }
            else
            {
                this.GetComponent<Rigidbody>().AddForce(this.transform.forward * 0.7f);
                this.GetComponent<Rigidbody>().AddForce((this.Target.position - this.transform.position).normalized * 0.7f);
            }
        }
    }

    public virtual void PlayAni()
    {
        if (this.Grounded == false)
        {
            return;
        }
        if (this.AkbarLight)
        {
            int randomValue = Random.Range(1, 4);
            switch (randomValue)
            {
                case 1:
                    this.Ani.CrossFade("AkbarFlailAni1");
                    break;
                case 2:
                    this.Ani.CrossFade("AkbarFlailAni2");
                    break;
                case 3:
                    this.Ani.CrossFade("AkbarFlailAni3");
                    break;
            }
        }
        if (this.AkbarHeavy)
        {
            int randomValueH = Random.Range(1, 3);
            switch (randomValueH)
            {
                case 1:
                    this.Ani.CrossFade("Akbar2FlailAni1");
                    break;
                case 2:
                    this.Ani.CrossFade("Akbar2FlailAni2");
                    break;
            }
        }
    }

    public virtual void OldAge()
    {
        UnityEngine.Object.Instantiate(this.DeathEffect, this.transform.position, this.transform.rotation);
        UnityEngine.Object.Destroy(this.gameObject);
    }

}