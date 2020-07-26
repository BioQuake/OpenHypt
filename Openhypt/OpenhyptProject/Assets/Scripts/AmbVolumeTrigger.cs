using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AmbVolumeTrigger : MonoBehaviour
{
    public float TAmb1Vol;
    public float TAmb2Vol;
    public AmbVolumeController Amb1Script;
    public AmbVolumeController Amb2Script;
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("TC1"))
        {
            this.Amb1Script.Amb1Vol = this.TAmb1Vol;
            this.Amb2Script.Amb2Vol = this.TAmb2Vol;
        }
    }

    public AmbVolumeTrigger()
    {
        this.TAmb1Vol = 1;
    }

}