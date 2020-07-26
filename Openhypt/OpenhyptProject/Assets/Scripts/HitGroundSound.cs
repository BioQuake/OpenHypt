using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class HitGroundSound : MonoBehaviour
{
    public AudioClip audioC1;
    public LayerMask targetLayers;
    public float ContactRange;
    public bool isgrounded;
    public float AirTime;
    public virtual void FixedUpdate()
    {
        int randomValue = Random.Range(1, 4);
        if (Physics.Raycast(this.transform.position + new Vector3(0, 0, 0), this.transform.up, this.ContactRange, (int) this.targetLayers))
        {
            this.isgrounded = true;
        }
        else
        {
            this.isgrounded = false;
        }
        if (this.isgrounded == true)
        {
            if (this.AirTime >= 4)
            {
                this.GetComponent<AudioSource>().PlayOneShot(this.audioC1);
            }
            this.isgrounded = true;
            this.AirTime = 0;
        }
    }

    public virtual void Update()
    {
        if (this.isgrounded == false)
        {
            this.AirTime = this.AirTime + 0.1f;
        }
    }

    public HitGroundSound()
    {
        this.ContactRange = 1;
    }

}