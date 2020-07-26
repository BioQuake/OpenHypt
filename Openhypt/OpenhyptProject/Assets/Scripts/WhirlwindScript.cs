using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using Boo.Lang;

[System.Serializable]
public partial class WhirlwindScript : MonoBehaviour
{
    public bool FadeOut;
    public int Duration;
    public float range;
    public float power;
    public float fullPower;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Tick", 1, 0.1f);
        this.FadeOut = false;
        yield return new WaitForSeconds(this.Duration);
        this.FadeOut = true;
        yield return new WaitForSeconds(20);
        UnityEngine.Object.Destroy(this.gameObject);
    }

    public virtual void Update()
    {
    }

    public virtual void FixedUpdate()
    {
        Vector3 newRot = (this.transform.forward * 0.6f).normalized;
        newRot = ((this.transform.forward * 0.6f) + (this.transform.right * 0.4f)).normalized;
        Debug.DrawRay(this.transform.position + (this.transform.up * 10), newRot * 200f, Color.black);
        if (Physics.Raycast(this.transform.position + (this.transform.up * 10), newRot, 200))
        {
            this.GetComponent<Rigidbody>().AddTorque(this.transform.up * -5);
        }
        newRot = ((this.transform.forward * 0.6f) + (this.transform.right * -0.4f)).normalized;
        Debug.DrawRay(this.transform.position + (this.transform.up * 10), newRot * 200f, Color.black);
        if (Physics.Raycast(this.transform.position + (this.transform.up * 10), newRot, 200))
        {
            this.GetComponent<Rigidbody>().AddTorque(this.transform.up * 5);
        }
        this.GetComponent<Rigidbody>().AddTorque(this.transform.up * Random.Range(-4, 4));
        this.GetComponent<Rigidbody>().AddForce(this.transform.forward * 4);
        this.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * 2, this.transform.up * 2);
        this.GetComponent<Rigidbody>().AddForceAtPosition(-Vector3.up * 2, -this.transform.up * 2);
        if (!this.FadeOut)
        {
            if (this.GetComponent<AudioSource>().volume < 1)
            {
                this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume + 0.002f;
            }
            if (this.power < this.fullPower)
            {
                this.power = this.power + 0.05f;
            }
        }
        if (this.FadeOut)
        {
            if (this.GetComponent<AudioSource>().volume > 0)
            {
                this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - 0.001f;
            }
            if (this.power > 0)
            {
                this.power = this.power - 0.05f;
            }
        }
    }

    public virtual void Tick()
    {
        Collider[] collideArray = Physics.OverlapSphere(this.transform.position, this.range);
        //object[] rigidbodyArray = new object[0];
        List<Rigidbody> rigidbodyArray = new List<Rigidbody>();
        int counter = 0;
        while (counter < collideArray.Length)
        {
            string zTag = collideArray[counter].gameObject.tag;
            if (collideArray[counter].attachedRigidbody && (collideArray[counter].attachedRigidbody != this.GetComponent<Rigidbody>()))
            {
                if ((!zTag.Contains("Player") && !zTag.Contains("Ghosts")) && !zTag.Contains("Explosions"))
                {
                    bool breaking = false;
                    int rounter = 0;
                    while (rounter < rigidbodyArray.Count)
                    {
                        if (collideArray[counter].attachedRigidbody == rigidbodyArray[rounter])
                        {
                            breaking = true;
                            break;
                        }
                        rounter++;
                    }
                    if (breaking)
                    {
                        goto Label_for_50;
                    }
                    rigidbodyArray.Add(collideArray[counter].attachedRigidbody);
                    Vector3 offset = this.transform.position - collideArray[counter].transform.position;
                    if (Vector3.Distance(collideArray[counter].transform.position, this.transform.position) > 1f)
                    {
                        collideArray[counter].attachedRigidbody.AddForce((offset / offset.sqrMagnitude) * this.power);
                    }
                }
            }
            Label_for_50:
            counter++;
        }
    }

    public WhirlwindScript()
    {
        this.Duration = 105;
        this.range = 20;
        this.fullPower = 40;
    }

}