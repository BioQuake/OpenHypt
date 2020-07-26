using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TransformChangerCamOther : MonoBehaviour
{
    public float maxOffset;
    private GameObject OtherOriginObject;
    public GameObject BasedOn;
    public virtual void Start()
    {
        this.OtherOriginObject = new GameObject();
        this.OtherOriginObject.name = "OtherFocusPointOrigin";
        this.OtherOriginObject.transform.position = this.transform.position;
        this.OtherOriginObject.transform.rotation = this.transform.rotation;
        this.OtherOriginObject.transform.parent = this.transform.parent;
    }

    public virtual void FixedUpdate()
    {
        Vector3 offset = this.BasedOn.GetComponent<Rigidbody>().velocity * 0.0238f;
        if (((offset.x > this.maxOffset) || (offset.y > this.maxOffset)) || (offset.z > this.maxOffset))
        {
            offset = this.Max(offset, this.maxOffset);
        }
        Vector3 OtherNewPos = this.OtherOriginObject.transform.position + offset;
        this.transform.position = OtherNewPos;
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

    public TransformChangerCamOther()
    {
        this.maxOffset = 100;
    }

}