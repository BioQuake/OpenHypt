using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class EntranceTransition : MonoBehaviour
{
    public bool IsNear;
    public bool isCameraSetter;
    public Transform StartPoint;
    public Transform EndPoint;
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
        if (this.IsNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.IsNear = false;
                PlayerInformation.instance.Pirizuka.position = this.EndPoint.position;
                PlayerInformation.instance.Pirizuka.Translate(Vector3.up * 1.4f);
                if (this.isCameraSetter)
                {
                    if (!WorldInformation.IsNopass)
                    {
                        CameraScript.cameraSetOnce = true;
                    }
                }
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("TC1p") && (WorldInformation.playerCar == "null"))
        {
            this.IsNear = true;
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("TC1p") && (WorldInformation.playerCar == "null"))
        {
            this.IsNear = false;
        }
    }

}