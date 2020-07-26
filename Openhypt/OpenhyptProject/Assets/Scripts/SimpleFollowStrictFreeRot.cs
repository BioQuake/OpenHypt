using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SimpleFollowStrictFreeRot : MonoBehaviour
{
    public Transform target;
    public int AimRate;
    private Transform thisTransform;
    public virtual void Start()
    {
        this.thisTransform = this.transform;
    }

    public virtual void FixedUpdate()
    {

        {
            float _2962 = Mathf.MoveTowards(this.thisTransform.position.x, this.target.position.x, this.AimRate);
            Vector3 _2963 = this.thisTransform.position;
            _2963.x = _2962;
            this.thisTransform.position = _2963;
        }

        {
            float _2964 = Mathf.MoveTowards(this.thisTransform.position.y, this.target.position.y, this.AimRate);
            Vector3 _2965 = this.thisTransform.position;
            _2965.y = _2964;
            this.thisTransform.position = _2965;
        }

        {
            float _2966 = Mathf.MoveTowards(this.thisTransform.position.z, this.target.position.z, this.AimRate);
            Vector3 _2967 = this.thisTransform.position;
            _2967.z = _2966;
            this.thisTransform.position = _2967;
        }
    }

    public SimpleFollowStrictFreeRot()
    {
        this.AimRate = 1;
    }

}