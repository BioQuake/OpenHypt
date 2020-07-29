using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DoppelgangerPos : MonoBehaviour
{
    public Transform Target;
    public bool FollowCam;
    public virtual void Start()
    {
        if (this.FollowCam)
        {
            this.Target = PlayerInformation.instance.PhysCam;
        }
    }

    public virtual void LateUpdate()
    {
        if (this.Target == null)
        {
            return;
        }
        this.transform.position = this.Target.transform.position;
    }

}