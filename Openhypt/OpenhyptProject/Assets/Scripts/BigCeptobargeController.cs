using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BigCeptobargeController : MonoBehaviour
{
    public GameObject Ceptobarge;
    public GameObject Container;
    public GameObject ContainerModel;
    public GameObject ContainerEmptyModel;
    public bool DidItNow;
    public bool Working;
    public bool Arrive;
    public bool Position;
    public bool Drop;
    public bool GoingToLeave;
    public bool Leaving;
    public virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(120);
        this.Ceptobarge.gameObject.SetActive(true);
        this.Working = true;
        this.Ceptobarge.GetComponent<Rigidbody>().velocity = (this.Ceptobarge.transform.up * -8000) * 0.45f;
    }

    public virtual void DoItNow()
    {
        this.StopAllCoroutines();
        this.Ceptobarge.gameObject.SetActive(true);
        this.Working = true;
        this.Ceptobarge.GetComponent<Rigidbody>().velocity = (this.Ceptobarge.transform.up * -8000) * 0.45f;
    }

    public virtual void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.LeftShift) && Input.GetKey("l")) && !this.DidItNow)
        {
            this.DoItNow();
            this.DidItNow = true;
        }
        if (this.Working)
        {
            if (this.Arrive && !this.Position)
            {
                if (this.Ceptobarge.GetComponent<Rigidbody>().velocity.magnitude > 100)
                {
                    this.Ceptobarge.GetComponent<Rigidbody>().AddForce(this.Ceptobarge.transform.up * 5000000);
                }
                this.Ceptobarge.GetComponent<Rigidbody>().drag = 3;
                if (this.Ceptobarge.GetComponent<Rigidbody>().velocity.magnitude < 100)
                {
                    this.Position = true;
                }
            }
            if (this.Position && !this.Drop)
            {
                if (Vector3.Distance(this.Ceptobarge.transform.position, this.transform.position) > 20)
                {
                    if (this.Ceptobarge.GetComponent<Rigidbody>().velocity.magnitude < 50)
                    {
                        this.Ceptobarge.GetComponent<Rigidbody>().drag = 1;
                    }
                }
                if (Vector3.Distance(this.Ceptobarge.transform.position, this.transform.position) < 20)
                {
                    if (this.Ceptobarge.GetComponent<Rigidbody>().velocity.magnitude < 50)
                    {
                        this.Ceptobarge.GetComponent<Rigidbody>().drag = 4;
                    }
                }
                this.Ceptobarge.GetComponent<Rigidbody>().AddForce(this.Ceptobarge.transform.up * -50000);
            }
            if ((Vector3.Distance(this.Ceptobarge.transform.position, this.transform.position) < 1000) && !this.Arrive)
            {
                this.Arrive = true;
            }
            if ((Vector3.Distance(this.Ceptobarge.transform.position, this.transform.position) < 1) && !this.Drop)
            {
                this.Drop = true;
                this.StartCoroutine(this.DropContainer());
            }
            if (this.ContainerEmptyModel.active && !this.GoingToLeave)
            {
                this.Ceptobarge.GetComponent<Rigidbody>().drag = 0.1f;
                this.GoingToLeave = true;
                this.StartCoroutine(this.Done());
            }
            if (this.Leaving)
            {
                if (this.Ceptobarge.GetComponent<Rigidbody>().velocity.magnitude < 1000)
                {
                    this.Ceptobarge.GetComponent<Rigidbody>().AddForce(this.Ceptobarge.transform.up * -100000);
                }
                if (Vector3.Distance(this.Ceptobarge.transform.position, this.transform.position) > 30000)
                {
                    UnityEngine.Object.Destroy(this.gameObject);
                }
            }
        }
    }

    public virtual IEnumerator DropContainer()
    {
        yield return new WaitForSeconds(2);
        this.Container.gameObject.SetActive(true);
        this.ContainerModel.gameObject.SetActive(false);
    }

    public virtual IEnumerator Done()
    {
        yield return new WaitForSeconds(1);
        this.Ceptobarge.GetComponent<AudioSource>().Play();
        this.Leaving = true;
    }

}