using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Doppelganger1 : MonoBehaviour
{
    public Transform target;
    public bool Locked;
    public float smoothTime;
    public virtual void LateUpdate()
    {
        if ((this.target != null) && !this.Locked)
        {

            {
                float _1744 = Mathf.Lerp(this.transform.position.x, this.target.position.x, Time.deltaTime * this.smoothTime);
                Vector3 _1745 = this.transform.position;
                _1745.x = _1744;
                this.transform.position = _1745;
            }

            {
                float _1746 = Mathf.Lerp(this.transform.position.y, this.target.position.y, Time.deltaTime * this.smoothTime);
                Vector3 _1747 = this.transform.position;
                _1747.y = _1746;
                this.transform.position = _1747;
            }

            {
                float _1748 = Mathf.Lerp(this.transform.position.z, this.target.position.z, Time.deltaTime * this.smoothTime);
                Vector3 _1749 = this.transform.position;
                _1749.z = _1748;
                this.transform.position = _1749;
            }
        }
        if ((this.target != null) && this.Locked)
        {
            this.transform.position = this.target.transform.position;
        }
    }

    public Doppelganger1()
    {
        this.smoothTime = 0.3f;
    }

}