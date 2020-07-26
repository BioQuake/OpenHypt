using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class HeightCollisionSensor : MonoBehaviour
{
    private int x0;
    private int y0;
    private int z0;
    public GameObject LowSpeed1;
    public GameObject LowSpeed2;
    public GameObject LowSpeed3;
    public GameObject HighSpeed1;
    public GameObject HighSpeed2;
    public GameObject HighSpeed3;
    public float randomseed;
    private int cooldown2;
    public bool isgrounded;
    public float AirTime;
    public virtual void Update()
    {
        this.x0 = (int) this.transform.position.x;
        this.y0 = (int) this.transform.position.y;
        this.z0 = (int) this.transform.position.z;
        if (this.isgrounded == false)
        {
            this.AirTime = this.AirTime + 0.1f;
        }
    }

     //private var cooldown2 : int = 20;
     //private var height : int;
     //private var oldheight : int;
     //private var isgrounded : boolean;
    public virtual void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.tag.Contains("Te"))
        {
            this.randomseed = Random.value;
            if ((this.AirTime >= 4) && (this.AirTime < 30))
            {
                if (this.randomseed < 0.3f)
                {
                    UnityEngine.Object.Instantiate(this.LowSpeed1, new Vector3(this.x0, this.y0, this.z0), this.transform.rotation);
                }
                else
                {
                    if ((this.randomseed >= 0.3f) && (this.randomseed < 0.6f))
                    {
                        UnityEngine.Object.Instantiate(this.LowSpeed2, new Vector3(this.x0, this.y0, this.z0), this.transform.rotation);
                    }
                    else
                    {
                        if (this.randomseed >= 0.6f)
                        {
                            UnityEngine.Object.Instantiate(this.LowSpeed3, new Vector3(this.x0, this.y0, this.z0), this.transform.rotation);
                        }
                    }
                }
            }
            else
            {
                if (this.AirTime >= 30)
                {
                    if (this.randomseed < 0.3f)
                    {
                        UnityEngine.Object.Instantiate(this.HighSpeed1, new Vector3(this.x0, this.y0, this.z0), this.transform.rotation);
                    }
                    else
                    {
                        if ((this.randomseed >= 0.3f) && (this.randomseed < 0.6f))
                        {
                            UnityEngine.Object.Instantiate(this.HighSpeed2, new Vector3(this.x0, this.y0, this.z0), this.transform.rotation);
                        }
                        else
                        {
                            if (this.randomseed >= 0.6f)
                            {
                                UnityEngine.Object.Instantiate(this.HighSpeed3, new Vector3(this.x0, this.y0, this.z0), this.transform.rotation);
                            }
                        }
                    }
                }
            }
            this.isgrounded = true;
            this.AirTime = 0;
        }
    }

    public virtual void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.tag.Contains("Te"))
        {
            this.isgrounded = false;
        }
    }

    public HeightCollisionSensor()
    {
        this.cooldown2 = 40;
    }

}