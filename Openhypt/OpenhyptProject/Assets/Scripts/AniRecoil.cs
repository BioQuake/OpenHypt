using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AniRecoil : MonoBehaviour
{
    public float Force;
    public bool DoingRecoil;
    public virtual void Update()
    {
        if (this.DoingRecoil == true)
        {
            this.GetComponent<Rigidbody>().AddForce(this.transform.up * this.Force);
            this.DoingRecoil = false;
        }
    }

    public AniRecoil()
    {
        this.Force = 100;
    }

}