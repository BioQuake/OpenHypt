using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class HideHud : MonoBehaviour
{
    public Animation HUDAni;
    public bool Hidden;
    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (!CameraScript.InInterface)
                {
                    this.Hide();
                }
            }
        }
    }

    public virtual void Hide()
    {
        if (this.Hidden)
        {
            this.HUDAni.CrossFade("ZerahyptInterfaceShow");
            this.Hidden = false;
        }
        else
        {
            this.HUDAni.CrossFade("ZerahyptInterfaceHide");
            this.Hidden = true;
        }
    }

}