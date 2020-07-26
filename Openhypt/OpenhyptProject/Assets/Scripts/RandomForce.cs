using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RandomForce : MonoBehaviour
{
    public Transform thisTransform;
    public Rigidbody rBody;
    public float forceX;
    public float forceY;
    public float forceZ;
    public virtual void Start()
    {
        this.rBody = this.GetComponent<Rigidbody>();
        this.thisTransform = this.transform;
    }

    public virtual void FixedUpdate()
    {
        if (this.forceX < 0.5f)
        {
            this.forceX = this.forceX + Random.Range(-0.02f, 0.02f);
            if (-this.forceX > 0.5f)
            {
                this.forceX = 0;
            }
        }
        else
        {
            this.forceX = 0;
        }
        if (this.forceY < 0.4f)
        {
            this.forceY = this.forceY + Random.Range(-0.02f, 0.02f);
            if (-this.forceY > 0.1f)
            {
                this.forceY = 0;
            }
        }
        else
        {
            this.forceY = 0;
        }
        if (this.forceZ < 0.5f)
        {
            this.forceZ = this.forceZ + Random.Range(-0.02f, 0.02f);
            if (-this.forceZ > 0.5f)
            {
                this.forceZ = 0;
            }
        }
        else
        {
            this.forceZ = 0;
        }
        this.rBody.AddForce(new Vector3(this.forceX, this.forceY, this.forceZ), ForceMode.VelocityChange);
    }

}