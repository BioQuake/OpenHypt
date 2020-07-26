using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ThrusterscriptWS : MonoBehaviour
{
    public float ForwardSpeed;
    public float ForwardBoostedSpeed;
    public float ReverseSpeed;
    public SpeedLimiter TandemSLScript;
    public int BoostCooldown;
    public GameObject BoostIndicator;
    public bool CanBoost;
    public bool Boosting;
    public virtual void Update()
    {
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            if (Input.GetKey("w"))
            {
                if (Input.GetKeyUp(KeyCode.B))
                {
                    this.BoostIndicator.gameObject.SetActive(false);
                    this.CanBoost = false;
                    this.BoostCooldown = 0;
                }
            }
            if (Input.GetKey(KeyCode.B))
            {
                if (Input.GetKeyUp("w"))
                {
                    this.BoostIndicator.gameObject.SetActive(false);
                    this.CanBoost = false;
                    this.BoostCooldown = 0;
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            if (Input.GetKey("w"))
            {
                this.GetComponent<Rigidbody>().AddForce(this.transform.forward * this.ForwardSpeed);
            }
            if (Input.GetKey(KeyCode.B))
            {
                if (Input.GetKey("w") && this.CanBoost)
                {
                    this.GetComponent<Rigidbody>().AddForce(this.transform.forward * this.ForwardBoostedSpeed);
                    this.Boosting = true;
                }
            }
            if (Input.GetKey("s"))
            {
                this.GetComponent<Rigidbody>().AddForce(-this.transform.forward * this.ReverseSpeed);
            }
        }
    }

    public virtual void CountDowner()
    {
        if (!this.CanBoost && (this.BoostCooldown < 8))
        {
            this.BoostCooldown = this.BoostCooldown + 1;
        }
        if (this.Boosting && (this.BoostCooldown > 0))
        {
            this.BoostCooldown = this.BoostCooldown - 2;
            this.Boosting = false;
        }
        if (this.BoostCooldown < 1)
        {
            this.BoostIndicator.gameObject.SetActive(false);
            this.CanBoost = false;
            this.TandemSLScript.CanBoost = false;
        }
        if ((this.BoostCooldown > 7) && !this.CanBoost)
        {
            this.BoostIndicator.gameObject.SetActive(true);
            this.BoostIndicator.GetComponent<AudioSource>().Play();
            this.CanBoost = true;
            this.TandemSLScript.CanBoost = true;
        }
    }

    public virtual void Start()
    {
        this.InvokeRepeating("CountDowner", 1, 1);
    }

    public ThrusterscriptWS()
    {
        this.ForwardSpeed = 100;
        this.ForwardBoostedSpeed = 100;
        this.ReverseSpeed = 100;
    }

}