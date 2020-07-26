using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class FollowHorizon : MonoBehaviour
{
    public bool LevelMode;
    public static int LevelRot;
    public Transform cameraToFollow;
    public virtual void Start()
    {
        this.InvokeRepeating("Reset", 0.17f, 0.5f);
    }

    public virtual void FixedUpdate()
    {
        if (!this.LevelMode)
        {
            Vector3 horizon1 = this.cameraToFollow.position + (this.cameraToFollow.forward * 20000000);
            Vector3 lookPos1 = horizon1 - this.transform.position;
            if (!Input.GetMouseButton(1))
            {
                lookPos1.y = this.transform.position.y;
            }
            this.transform.rotation = Quaternion.LookRotation(lookPos1);
            this.transform.position = this.cameraToFollow.position;
        }
        else
        {
            Vector3 horizon2 = this.cameraToFollow.position + (this.cameraToFollow.right * -20000000);
            Vector3 lookPos2 = horizon2 - this.transform.position;
            this.transform.rotation = Quaternion.LookRotation(horizon2);
            this.transform.position = this.cameraToFollow.position;
        }
    }

    public virtual void Reset()
    {
        if (FollowHorizon.LevelRot == 180)
        {
            AgrianNetwork.Spawn = 16;
            //Debug.Log("ItDid");
            FollowHorizon.LevelRot = 0;
        }
    }

}