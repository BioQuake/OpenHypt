using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Blinker : MonoBehaviour
{
    public GameObject WhatToBlink;
    public GameObject WhatToBlink2;
    public GameObject WhatToBlink3;
    public Blinker SubBlinker;
    public bool IsActive;
    public bool DeActivated;
    public float OnTime;
    public float OffTime;
    public float PauseTime;
    public bool sequencedBlinks;
    public bool Inverted;
    public bool Tick;
    public virtual void FixedUpdate()
    {
        if (this.DeActivated)
        {
            if (!this.SubBlinker)
            {
                this.WhatToBlink.SetActive(false);
            }
            if (this.SubBlinker)
            {
                this.SubBlinker.DeActivated = true;
            }
        }
        if (!this.DeActivated)
        {
            if (this.SubBlinker)
            {
                this.SubBlinker.DeActivated = false;
            }
        }
        if (this.IsActive && !this.DeActivated)
        {
            this.StartCoroutine(this.Blink());
        }
    }

    public virtual IEnumerator Blink()
    {
        if (this.Tick)
        {
            yield break;
        }
        this.Tick = true;
        yield return new WaitForSeconds(this.OffTime);
        if (!this.Inverted)
        {
            if (!this.SubBlinker)
            {
                this.WhatToBlink.SetActive(true);
            }
            if (this.SubBlinker)
            {
                this.SubBlinker.IsActive = true;
            }
        }
        else
        {
            if (!this.SubBlinker)
            {
                this.WhatToBlink.SetActive(false);
            }
            if (this.SubBlinker)
            {
                this.SubBlinker.IsActive = false;
            }
        }
        yield return new WaitForSeconds(this.OnTime);
        if (!this.Inverted)
        {
            if (!this.SubBlinker)
            {
                this.WhatToBlink.SetActive(false);
            }
            if (this.SubBlinker)
            {
                this.SubBlinker.IsActive = false;
            }
        }
        else
        {
            if (!this.SubBlinker)
            {
                this.WhatToBlink.SetActive(true);
            }
            if (this.SubBlinker)
            {
                this.SubBlinker.IsActive = true;
            }
        }
        this.Tick = false;
        if (this.sequencedBlinks)
        {
            this.Tick = true;
            yield return new WaitForSeconds(this.OffTime);
            if (!this.Inverted)
            {
                this.WhatToBlink2.SetActive(true);
            }
            else
            {
                this.WhatToBlink2.SetActive(false);
            }
            yield return new WaitForSeconds(this.OnTime);
            if (!this.Inverted)
            {
                this.WhatToBlink2.SetActive(false);
            }
            else
            {
                this.WhatToBlink2.SetActive(true);
            }
            yield return new WaitForSeconds(this.OffTime);
            if (!this.Inverted)
            {
                this.WhatToBlink3.SetActive(true);
            }
            else
            {
                this.WhatToBlink3.SetActive(false);
            }
            yield return new WaitForSeconds(this.OnTime);
            if (!this.Inverted)
            {
                this.WhatToBlink3.SetActive(false);
            }
            else
            {
                this.WhatToBlink3.SetActive(true);
            }
            yield return new WaitForSeconds(this.PauseTime);
            this.Tick = false;
        }
    }

    public Blinker()
    {
        this.IsActive = true;
        this.OnTime = 2;
        this.OffTime = 2;
        this.PauseTime = 1;
    }

}