using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Upnudge : MonoBehaviour
{
    public float Multiplier;
    public int Num;
    public bool isTouching;
    public bool nudge;
    public virtual void FixedUpdate()
    {
        if (this.Num > 0)
        {
            this.Num = this.Num - 1;
        }
        if (this.nudge)
        {
            if (this.Num < 1)
            {
                float Product = Random.Range(this.Multiplier, this.Multiplier * 1.5f);
                this.GetComponent<Rigidbody>().AddForce(Vector3.up * Product, ForceMode.Impulse);
                this.nudge = false;
                this.isTouching = false;
                this.Num = 30;
            }
        }
    }

    public virtual void OnCollisionStay()
    {
        if (this.Num < 1)
        {
            this.isTouching = true;
        }
    }

}