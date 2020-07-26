using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Thrusterscript3 : MonoBehaviour
{
    public float ForwardSpeed;
    public float ReverseSpeed;
    public bool RunningF;
    public bool RunningR;
    public virtual void Update()
    {
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            if (CameraScript.InInterface == false)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    this.RunningF = true;
                }
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    this.RunningF = false;
                }
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    this.RunningR = true;
                }
                if (Input.GetKeyUp(KeyCode.Mouse1))
                {
                    this.RunningR = false;
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.RunningF)
        {
            this.GetComponent<Rigidbody>().AddForce(this.transform.up * this.ForwardSpeed);
        }
        if (this.RunningR)
        {
            this.GetComponent<Rigidbody>().AddForce(this.transform.up * this.ReverseSpeed);
        }
    }

    public Thrusterscript3()
    {
        this.ForwardSpeed = 100;
        this.ReverseSpeed = -100;
    }

}