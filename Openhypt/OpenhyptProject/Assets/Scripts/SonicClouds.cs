using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SonicClouds : MonoBehaviour
{
    public GameObject Vessel;
    public GameObject Damager;
    public bool partOfWarper;
    public Warper warperScript;
    public int SpeedThreshold;
    public virtual void Start()
    {
        if (!this.partOfWarper)
        {
            Color newColor = this.GetComponent<Renderer>().material.GetColor("_TintColor");
            newColor.a = 0;
            this.GetComponent<Renderer>().material.SetColor("_TintColor", newColor);
        }
    }

    public virtual void FixedUpdate()
    {
        Color newColor = this.GetComponent<Renderer>().material.GetColor("_TintColor");
        if (!this.partOfWarper)
        {
            if (this.Vessel.GetComponent<Rigidbody>().velocity.magnitude > this.SpeedThreshold)
            {
                if (this.Damager)
                {
                    this.Damager.gameObject.SetActive(true);
                }
                if (newColor.a < 0.03f)
                {
                    newColor.a = newColor.a + 0.01f;
                }
            }
            else
            {
                if (this.Damager)
                {
                    this.Damager.gameObject.SetActive(false);
                }
                if (newColor.a > 0f)
                {
                    newColor.a = newColor.a - 0.01f;
                }
            }
        }
        else
        {
            if (this.warperScript.warpStartFXed)
            {
                if (this.Damager)
                {
                    this.Damager.gameObject.SetActive(true);
                }
                if (newColor.a < 0.03f)
                {
                    newColor.a = newColor.a + 0.01f;
                }
            }
            else
            {
                if (this.Damager)
                {
                    this.Damager.gameObject.SetActive(false);
                }
                if (newColor.a > 0f)
                {
                    newColor.a = newColor.a - 0.01f;
                }
            }
        }
        this.GetComponent<Renderer>().material.SetColor("_TintColor", newColor);
    }

    public SonicClouds()
    {
        this.SpeedThreshold = 300;
    }

}