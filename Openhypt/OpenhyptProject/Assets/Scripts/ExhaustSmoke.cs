using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ExhaustSmoke : MonoBehaviour
{
    public float EmissionRate;
    public float EmissionAcceleration;
    public GameObject Vessel;
    public bool Running;
    public bool Broken;
    public virtual void Update()
    {
        if (this.Broken)
        {
            this.GetComponent<ParticleSystem>().emissionRate = this.GetComponent<ParticleSystem>().emissionRate - this.EmissionAcceleration;
            return;
        }
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            if (CameraScript.InInterface == false)
            {
                if (Input.GetKeyDown("w") || Input.GetKeyDown("s"))
                {
                    this.Running = true;
                }
                if (Input.GetKeyUp("w") || Input.GetKeyUp("s"))
                {
                    this.Running = false;
                }
            }
        }
        if (this.Running)
        {
            if (this.GetComponent<ParticleSystem>().emissionRate < this.EmissionRate)
            {
                this.GetComponent<ParticleSystem>().emissionRate = this.GetComponent<ParticleSystem>().emissionRate + this.EmissionAcceleration;
            }
        }
        else
        {
            if (this.GetComponent<ParticleSystem>().emissionRate > 0)
            {
                this.GetComponent<ParticleSystem>().emissionRate = this.GetComponent<ParticleSystem>().emissionRate - this.EmissionAcceleration;
            }
        }
    }

    public ExhaustSmoke()
    {
        this.EmissionRate = 100;
        this.EmissionAcceleration = 5;
    }

}