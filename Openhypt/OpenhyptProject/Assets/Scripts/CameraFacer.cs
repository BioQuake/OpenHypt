using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CameraFacer : MonoBehaviour
{
    public Transform target;
    public LayerMask targetLayers;
    public GameObject LightTex;
    public bool UseLineOfSight;
    public virtual void Start()
    {
        if (PlayerInformation.instance)
        {
            this.target = PlayerInformation.instance.PhysCam;
        }
    }

    public virtual void LateUpdate()
    {
        if (this.UseLineOfSight)
        {
            if (!Physics.Linecast(this.transform.position, this.target.position, (int) this.targetLayers))
            {
                this.LightTex.gameObject.SetActive(true);
            }
            else
            {
                this.LightTex.gameObject.SetActive(false);
            }
        }
        this.transform.LookAt(this.target);
        if (this.target == null)
        {
            this.target = PlayerInformation.instance.PhysCam;
        }
    }

}