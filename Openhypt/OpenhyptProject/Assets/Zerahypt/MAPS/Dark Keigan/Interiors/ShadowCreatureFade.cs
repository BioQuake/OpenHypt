using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ShadowCreatureFade : MonoBehaviour
{
    public string Name;
    public GameObject targetAlpha;
    public float fadedistance;
    public float fadespeed;
    private float lastDistance;
    public virtual void Update()
    {
        if (Vector3.Distance(this.transform.position, this.targetAlpha.transform.position) <= this.fadedistance)
        {

            {
                int _3820 = 0;
                Color _3821 = this.targetAlpha.GetComponent<Renderer>().material.color;
                _3821.a = _3820;
                this.targetAlpha.GetComponent<Renderer>().material.color = _3821;
            }
        }
        else
        {
            if (Vector3.Distance(this.transform.position, this.targetAlpha.transform.position) > this.fadedistance)
            {

                {
                    float _3822 = (Vector3.Distance(this.transform.position, this.targetAlpha.transform.position) - this.fadedistance) * this.fadespeed;
                    Color _3823 = this.targetAlpha.GetComponent<Renderer>().material.color;
                    _3823.a = _3822;
                    this.targetAlpha.GetComponent<Renderer>().material.color = _3823;
                }
            }
        }
        this.lastDistance = Vector3.Distance(this.transform.position, this.targetAlpha.transform.position);
    }

    public virtual void Start()
    {
        if (this.targetAlpha == null)
        {
            this.targetAlpha = GameObject.Find(this.Name);
        }
    }

    public ShadowCreatureFade()
    {
        this.fadedistance = 30;
        this.fadespeed = 0.05f;
    }

}