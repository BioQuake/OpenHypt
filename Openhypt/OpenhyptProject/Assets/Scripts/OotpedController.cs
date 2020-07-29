using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class OotpedController : MonoBehaviour
{
    public Transform Target;
    public GameObject Model;
    public GameObject Blur;
    public bool CanFade;
    public bool IsFading;
    public bool IsFadingOut;
    public float AimForce;
    public float Force;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Skitter", 0.1f, 0.06f);
        this.InvokeRepeating("Reset", 0.1f, 0.17f);
        this.Target = PlayerInformation.instance.Pirizuka;
        yield return new WaitForSeconds(0.1f);
        ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 0.2f;
        yield return new WaitForSeconds(0.1f);
        ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 0.3f;
        yield return new WaitForSeconds(0.1f);
        ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 0.4f;
        yield return new WaitForSeconds(0.1f);
        ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 0.5f;
        yield return new WaitForSeconds(1.6f);
        this.CanFade = true;
        yield return new WaitForSeconds(18);
        this.IsFadingOut = true;
        yield return new WaitForSeconds(2);
        UnityEngine.Object.Destroy(this.transform.parent.gameObject);
    }

    public virtual void FixedUpdate()
    {
        Color newColor = this.Model.GetComponent<Renderer>().material.GetColor("_TintColor");
        this.GetComponent<Rigidbody>().AddForceAtPosition((this.Target.transform.position - this.transform.position).normalized * this.AimForce, this.transform.up * 1);
        this.GetComponent<Rigidbody>().AddForceAtPosition((this.Target.transform.position - this.transform.position).normalized * -this.AimForce, -this.transform.up * 1);
        this.GetComponent<Rigidbody>().AddForce(this.transform.up * this.Force);
        if ((this.Blur.GetComponent<ParticleSystem>().emissionRate < 10) && !this.IsFading)
        {
            this.Blur.GetComponent<ParticleSystem>().emissionRate = this.Blur.GetComponent<ParticleSystem>().emissionRate + 0.05f;
        }
        if ((newColor.a < 0.2f) && !this.IsFading)
        {
            newColor.a = newColor.a + 0.02f;
        }
        if (((Vector3.Distance(this.transform.position, this.Target.position) < 5) && !this.IsFadingOut) && this.CanFade)
        {
            this.IsFading = true;
            this.Blur.GetComponent<ParticleSystem>().emissionRate = 0;
            newColor.a = newColor.a - 0.02f;
        }
        if (this.IsFadingOut)
        {
            this.IsFading = true;
            this.Blur.GetComponent<ParticleSystem>().emissionRate = 0;
            newColor.a = newColor.a - 0.02f;
        }
        this.Model.GetComponent<Renderer>().material.SetColor("_TintColor", newColor);
    }

    public virtual void Skitter()
    {
        this.Model.transform.Rotate(Random.Range(-20, 20), Random.Range(-30, 30), Random.Range(-170, -190));
    }

    public virtual void Reset()
    {
        this.Model.transform.rotation = this.gameObject.transform.rotation;
    }

    public OotpedController()
    {
        this.AimForce = 0.1f;
        this.Force = 0.1f;
    }

}