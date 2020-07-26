using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SimpleFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime;
    public float xOffset;
    public float yOffset;
    public float zOffset;
    private Vector3 velocity;
    public virtual void FixedUpdate()
    {
        if (this.target != null)
        {

            {
                float _2950 = Mathf.Lerp(this.transform.position.x, this.target.position.x + this.xOffset, Time.deltaTime * this.smoothTime);
                Vector3 _2951 = this.transform.position;
                _2951.x = _2950;
                this.transform.position = _2951;
            }

            {
                float _2952 = Mathf.Lerp(this.transform.position.y, this.target.position.y + this.yOffset, Time.deltaTime * this.smoothTime);
                Vector3 _2953 = this.transform.position;
                _2953.y = _2952;
                this.transform.position = _2953;
            }

            {
                float _2954 = Mathf.Lerp(this.transform.position.z, this.target.position.z + this.zOffset, Time.deltaTime * this.smoothTime);
                Vector3 _2955 = this.transform.position;
                _2955.z = _2954;
                this.transform.position = _2955;
            }
        }
    }

    public SimpleFollow()
    {
        this.smoothTime = 0.3f;
        this.xOffset = 1f;
        this.yOffset = 1f;
        this.zOffset = 1f;
    }

}