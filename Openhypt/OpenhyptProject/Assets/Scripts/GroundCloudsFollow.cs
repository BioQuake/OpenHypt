using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class GroundCloudsFollow : MonoBehaviour
{
    public Transform target;
    public virtual void Start()
    {
        this.target = PlayerInformation.instance.PhysCam;
    }

    public virtual void FixedUpdate()
    {
        if (this.target == null)
        {
            return;
        }

        {
            float _1978 = this.target.position.x;
            Vector3 _1979 = this.transform.position;
            _1979.x = _1978;
            this.transform.position = _1979;
        }

        {
            float _1980 = this.target.position.z;
            Vector3 _1981 = this.transform.position;
            _1981.z = _1980;
            this.transform.position = _1981;
        }
    }

}