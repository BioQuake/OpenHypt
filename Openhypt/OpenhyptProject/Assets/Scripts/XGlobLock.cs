using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class XGlobLock : MonoBehaviour
{
    public virtual void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {

            {
                int _3802 = 0;
                Quaternion _3803 = this.transform.localRotation;
                _3803.x = _3802;
                this.transform.localRotation = _3803;
            }

            {
                int _3804 = 0;
                Quaternion _3805 = this.transform.localRotation;
                _3805.y = _3804;
                this.transform.localRotation = _3805;
            }

            {
                int _3806 = 0;
                Quaternion _3807 = this.transform.localRotation;
                _3807.z = _3806;
                this.transform.localRotation = _3807;
            }
        }
        if (!Input.GetMouseButton(1))
        {

            {
                int _3808 = 0;
                Quaternion _3809 = this.transform.rotation;
                _3809.x = _3808;
                this.transform.rotation = _3809;
            }

            {
                int _3810 = 0;
                Quaternion _3811 = this.transform.localRotation;
                _3811.y = _3810;
                this.transform.localRotation = _3811;
            }

            {
                int _3812 = 0;
                Quaternion _3813 = this.transform.localRotation;
                _3813.z = _3812;
                this.transform.localRotation = _3813;
            }
        }
    }

}