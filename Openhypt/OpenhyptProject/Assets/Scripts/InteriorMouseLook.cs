using UnityEngine;
using System.Collections;

public enum RotationAxes
{
    MouseXAndY = 0,
    MouseX = 1,
    MouseY = 2
}

[System.Serializable]
public partial class InteriorMouseLook : MonoBehaviour
{
    public RotationAxes axes;
    public float sensitivityX;
    public float sensitivityY;
    public float minimumX;
    public float maximumX;
    public float minimumY;
    public float maximumY;
    public GameObject Reticle;
    private float rotationY;
    public virtual void Update()
    {
        if (!CameraScript.InInterface)
        {
            if (this.axes == RotationAxes.MouseXAndY)
            {
                float rotationX = this.transform.localEulerAngles.y + (Input.GetAxis("Mouse X") * this.sensitivityX);
                this.rotationY = this.rotationY + (Input.GetAxis("Mouse Y") * this.sensitivityY);
                this.rotationY = Mathf.Clamp(this.rotationY, this.minimumY, this.maximumY);
                this.transform.localEulerAngles = new Vector3(-this.rotationY, rotationX, 0);
            }
            else
            {
                if (this.axes == RotationAxes.MouseX)
                {
                    this.transform.Rotate(0, Input.GetAxis("Mouse X") * this.sensitivityX, 0);
                }
                else
                {
                    this.rotationY = this.rotationY + (Input.GetAxis("Mouse Y") * this.sensitivityY);
                    this.rotationY = Mathf.Clamp(this.rotationY, this.minimumY, this.maximumY);
                    this.transform.localEulerAngles = new Vector3(-this.rotationY, this.transform.localEulerAngles.y, 0);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            this.Reticle.gameObject.SetActive(true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            this.Reticle.gameObject.SetActive(false);
        }
    }

    public InteriorMouseLook()
    {
        this.axes = RotationAxes.MouseXAndY;
        this.minimumX = -360f;
        this.maximumX = 360f;
        this.minimumY = -60f;
        this.maximumY = 60f;
    }

}