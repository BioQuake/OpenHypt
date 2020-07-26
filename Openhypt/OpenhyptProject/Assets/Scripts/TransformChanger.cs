using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TransformChanger : MonoBehaviour
{
    public float offsetMultiplier;
    public float maxOffset;
    private GameObject originObject;
    public virtual void Start()
    {
        this.originObject = new GameObject();
        this.originObject.name = "FocusPointOrigin";
        this.originObject.transform.position = this.transform.position;
        this.originObject.transform.rotation = this.transform.rotation;
        this.originObject.transform.parent = this.transform.parent;
    }

    public virtual void Update()
    {
        Vector3 offset = ((-this.transform.up * this.transform.parent.GetComponent<Rigidbody>().velocity.magnitude) / 10) * this.offsetMultiplier;
        offset = this.Max(offset, this.maxOffset);
        Vector3 newPos = this.originObject.transform.position + offset;
        this.transform.position = newPos;
    }

    public virtual Vector3 Max(Vector3 _value, float _maxValue)
    {
        if (_value.x > _maxValue)
        {
            _value.x = _maxValue;
        }
        else
        {
            if (_value.x < -_maxValue)
            {
                _value.x = -_maxValue;
            }
        }
        if (_value.y > _maxValue)
        {
            _value.y = _maxValue;
        }
        else
        {
            if (_value.y < -_maxValue)
            {
                _value.y = -_maxValue;
            }
        }
        if (_value.z > _maxValue)
        {
            _value.z = _maxValue;
        }
        else
        {
            if (_value.z < -_maxValue)
            {
                _value.z = -_maxValue;
            }
        }
        return _value;
    }

    public TransformChanger()
    {
        this.maxOffset = 30f;
    }

}