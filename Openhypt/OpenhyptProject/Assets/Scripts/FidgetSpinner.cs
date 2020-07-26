using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class FidgetSpinner : MonoBehaviour
{
    public Transform Disk;
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            this.GetComponent<Rigidbody>().AddTorque(this.transform.up * 0.001f);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            this.GetComponent<Rigidbody>().AddTorque(this.transform.up * -0.001f);
        }
    }

    public virtual void LateUpdate()
    {
        this.transform.position = this.Disk.position;
    }

}