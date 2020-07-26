using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class OotController : MonoBehaviour
{
    public Transform Target;
    public GameObject Model;
    public ParticleSystem Blur;
    public Color newColor;
    public bool isBlurryOot;
    public bool CanFade;
    public bool IsFading;
    public bool IsFadingOut;
    public virtual IEnumerator Start()
    {
        if (this.isBlurryOot)
        {
            this.newColor = this.Model.GetComponent<Renderer>().material.GetColor("_TintColor");
        }
        else
        {
            this.newColor = this.Model.GetComponent<Renderer>().material.GetColor("_Color");
        }
        this.Target = PlayerInformation.instance.Pirizuka;
        yield return new WaitForSeconds(1);
        this.CanFade = true;
        yield return new WaitForSeconds(Random.Range(2, 8));
        this.IsFadingOut = true;
        yield return new WaitForSeconds(3.5f);
        UnityEngine.Object.Destroy(this.transform.parent.gameObject);
    }

    public virtual void FixedUpdate()
    {
        if (this.isBlurryOot)
        {
            this.GetComponent<Rigidbody>().AddForce(this.transform.forward * Random.Range(0.0001f, 0.0003f));
        }
        else
        {
            this.GetComponent<Rigidbody>().AddForce(this.transform.forward * 0.0001f);
        }
        this.GetComponent<Rigidbody>().AddTorque(this.transform.up * Random.Range(-0.0001f, 0.0001f));
        this.GetComponent<Rigidbody>().AddTorque(this.transform.right * Random.Range(-0.0001f, 0.0001f));
        this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * Random.Range(-0.0001f, 0.0001f));
        if ((this.Blur.startColor.a < 0.5f) && !this.IsFading)
        {

            {
                float _2512 = this.Blur.startColor.a + 0.005f;
                Color _2513 = this.Blur.startColor;
                _2513.a = _2512;
                this.Blur.startColor = _2513;
            }
        }
        if ((this.newColor.a < 0.5f) && !this.IsFading)
        {
            this.newColor.a = this.newColor.a + 0.01f;
        }
        if (((Vector3.Distance(this.transform.position, this.Target.position) < 3) && !this.IsFadingOut) && this.CanFade)
        {
            this.IsFading = true;

            {
                float _2514 = this.Blur.startColor.a - 0.005f;
                Color _2515 = this.Blur.startColor;
                _2515.a = _2514;
                this.Blur.startColor = _2515;
            }
            this.newColor.a = this.newColor.a - 0.005f;
        }
        if (this.IsFadingOut)
        {
            this.IsFading = true;

            {
                float _2516 = this.Blur.startColor.a - 0.005f;
                Color _2517 = this.Blur.startColor;
                _2517.a = _2516;
                this.Blur.startColor = _2517;
            }
            this.newColor.a = this.newColor.a - 0.005f;
        }
        if (this.isBlurryOot)
        {
            this.Model.GetComponent<Renderer>().material.SetColor("_TintColor", this.newColor);
        }
        else
        {
            this.Model.GetComponent<Renderer>().material.SetColor("_Color", this.newColor);
        }
    }

}