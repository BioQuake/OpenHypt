using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SimpleAnimationPlay : MonoBehaviour
{
    public string Ani1;
    public string Ani2;
    public bool PlayAni1;
    public bool PlayAni2;
    public GameObject AniObject1;
    public GameObject AniObject2;
    public GameObject AniObject3;
    public virtual void Update()
    {
        if (this.PlayAni1)
        {
            this.AniAni1();
        }
        if (this.PlayAni2)
        {
            this.AniAni2();
        }
    }

    public virtual void AniAni1()
    {
        this.AniObject1.GetComponent<Animation>().Play(this.Ani1);
        this.AniObject2.GetComponent<Animation>().Play(this.Ani1);
        this.AniObject3.GetComponent<Animation>().Play(this.Ani1);
        this.PlayAni1 = false;
    }

    public virtual void AniAni2()
    {
        this.AniObject1.GetComponent<Animation>().Play(this.Ani2);
        this.AniObject2.GetComponent<Animation>().Play(this.Ani2);
        this.AniObject3.GetComponent<Animation>().Play(this.Ani2);
        this.PlayAni2 = false;
    }

}