using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ElevatorController : MonoBehaviour
{
    public GameObject AnimationObject;
    public string AnimationName;
    public bool GoOnStart;
    public bool ReachedEnd;
    public bool CanPlay;
    public virtual void Start()
    {
        if (this.GoOnStart)
        {
            this.Activate();
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (other.name.Contains("TC1"))
        {
            if (!other.name.Contains("TC1d"))
            {
                if (Input.GetKeyDown("e"))
                {
                    this.Activate();
                    this.AnimationObject.GetComponent<AudioSource>().Play();
                }
            }
        }
    }

    public virtual void Activate()
    {
        if ((this.ReachedEnd == false) && (this.CanPlay == true))
        {
            this.CanPlay = false;
            this.StartCoroutine(this.Counter2());
            this.AnimationObject.GetComponent<Animation>()[this.AnimationName + ""].speed = 1;
            this.AnimationObject.GetComponent<Animation>().Play(this.AnimationName + "");
        }
        if ((this.ReachedEnd == true) && (this.CanPlay == true))
        {
            this.CanPlay = false;
            this.StartCoroutine(this.Counter1());
            this.AnimationObject.GetComponent<Animation>()[this.AnimationName + ""].speed = -1;
            this.AnimationObject.GetComponent<Animation>()[this.AnimationName + ""].time = this.AnimationObject.GetComponent<Animation>()[this.AnimationName + ""].length;
            this.AnimationObject.GetComponent<Animation>().Play(this.AnimationName + "");
        }
    }

    public virtual IEnumerator Counter1()
    {
        yield return new WaitForSeconds(40);
        this.ReachedEnd = false;
        this.CanPlay = true;
    }

    public virtual IEnumerator Counter2()
    {
        yield return new WaitForSeconds(40);
        this.ReachedEnd = true;
        this.CanPlay = true;
    }

    public ElevatorController()
    {
        this.AnimationName = "Name";
        this.CanPlay = true;
    }

}