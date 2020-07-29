using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Doppelganger2 : MonoBehaviour
{
    public Transform target;
    public float smoothTime;
    public virtual void FixedUpdate()//transform.rotation.z = Mathf.Lerp( transform.rotation.z, target.rotation.z, Time.deltaTime * smoothTime);
    {
        if (this.target != null)
        {

            {
                float _1750 = Mathf.Lerp(this.transform.position.x, this.target.position.x, Time.deltaTime * this.smoothTime);
                Vector3 _1751 = this.transform.position;
                _1751.x = _1750;
                this.transform.position = _1751;
            }

            {
                float _1752 = Mathf.Lerp(this.transform.position.y, this.target.position.y, Time.deltaTime * this.smoothTime);
                Vector3 _1753 = this.transform.position;
                _1753.y = _1752;
                this.transform.position = _1753;
            }

            {
                float _1754 = Mathf.Lerp(this.transform.position.z, this.target.position.z, Time.deltaTime * this.smoothTime);
                Vector3 _1755 = this.transform.position;
                _1755.z = _1754;
                this.transform.position = _1755;
            }

            {
                float _1756 = //transform.rotation.x = Mathf.Lerp( transform.rotation.x, target.rotation.x, Time.deltaTime * smoothTime);
                Mathf.Lerp(this.transform.rotation.y, this.target.rotation.y, Time.deltaTime * this.smoothTime);
                Quaternion _1757 = this.transform.rotation;
                _1757.y = _1756;
                this.transform.rotation = _1757;
            }
        }
    }

    public Doppelganger2()
    {
        this.smoothTime = 0.3f;
    }

}