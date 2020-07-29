using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SimpleFollow2 : MonoBehaviour
{
    public Transform target;
    private float speedCap;
    public float smoothTime;
    public float xOffset;
    public float yOffset;
    public float zOffset;
    private Vector3 velocity;
    public virtual void Update()
    {
        if (this.target != null)
        {

            {
                float _2956 = Mathf.Lerp(this.transform.position.x, this.target.position.x + this.xOffset, Time.deltaTime * this.smoothTime);
                Vector3 _2957 = this.transform.position;
                _2957.x = _2956;
                this.transform.position = _2957;
            }

            {
                float _2958 = Mathf.Lerp(this.transform.position.y, this.target.position.y + this.yOffset, Time.deltaTime * this.smoothTime);
                Vector3 _2959 = this.transform.position;
                _2959.y = _2958;
                this.transform.position = _2959;
            }

            {
                float _2960 = Mathf.Lerp(this.transform.position.z, this.target.position.z + this.zOffset, Time.deltaTime * this.smoothTime);
                Vector3 _2961 = this.transform.position;
                _2961.z = _2960;
                this.transform.position = _2961;
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rocks")
        {
            if (other.GetComponent<Rigidbody>().velocity.magnitude < this.speedCap)
            {
                this.target = other.gameObject.transform;
            }
        }
    }

    public SimpleFollow2()
    {
        this.speedCap = 20;
        this.smoothTime = 0.3f;
        this.xOffset = 1f;
        this.yOffset = 1f;
        this.zOffset = 1f;
    }

}