using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TransformChangerCam : MonoBehaviour
{
    public Vector3 offset;
    public float maxOffset;
    private GameObject originObject;
    public GameObject BasedOn;
    public Transform OtherTarget;
    public bool LookingAtOther;
    public Transform OriginalTarget;
    public bool CanSwitchTarget;
    public GameObject Line;
    public GameObject NameGO;
    public TextMesh NameTag;
    public CapsuleCollider Trig;
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
        if (!this.CanSwitchTarget)
        {
            if (!this.BasedOn)
            {
                this.offset = this.transform.parent.GetComponent<Rigidbody>().velocity * 0.24f;
            }
            else
            {
                this.offset = this.BasedOn.GetComponent<Rigidbody>().velocity * 0.23f;
            }
        }
        if (this.CanSwitchTarget)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if ((WorldInformation.playerCar == this.transform.parent.name) && (this.OtherTarget != null))
                {
                    this.Trig.center = new Vector3(0, 0, 0);
                    this.Trig.radius = 1;
                    this.Trig.height = 1;
                    this.LookingAtOther = true;
                    this.transform.position = this.OtherTarget.position;
                    this.transform.rotation = this.OtherTarget.rotation;
                    CameraScript.instance.CheckCars(this.OtherTarget, 10);
                    this.NameGO.SetActive(false);
                    this.Line.SetActive(false);
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                this.LookingAtOther = false;
                this.transform.position = this.originObject.transform.position;
                this.transform.rotation = this.originObject.transform.rotation;
                if (WorldInformation.playerCar == this.transform.parent.name)
                {
                    this.Trig.center = new Vector3(0, -1000, 0);
                    this.Trig.radius = 16;
                    this.Trig.height = 2000;
                    CameraScript.instance.CheckCars(this.gameObject.transform, 10);
                    this.Line.SetActive(true);
                }
            }
            if (Input.GetMouseButtonUp(1))
            {
                if (WorldInformation.playerCar == this.transform.parent.name)
                {
                    this.Trig.center = new Vector3(0, 0, 0);
                    this.Trig.radius = 1;
                    this.Trig.height = 1;
                    this.Line.SetActive(false);
                    this.NameGO.SetActive(false);
                }
            }
            if (this.LookingAtOther)
            {
                if (this.OtherTarget != null)
                {
                    this.transform.position = this.OtherTarget.position;
                }
            }
        }
        if (((this.offset.x > this.maxOffset) || (this.offset.y > this.maxOffset)) || (this.offset.z > this.maxOffset))
        {
            this.offset = this.Max(this.offset, this.maxOffset);
        }
        Vector3 newPos = this.originObject.transform.position + this.offset;
        this.transform.position = newPos;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name.Contains("TC") && !other.GetComponent<Collider>().name.Contains("TC1"))
        {
            this.OtherTarget = other.gameObject.transform;
            this.NameTag.text = other.name;
            this.NameGO.SetActive(true);
        }
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

    public TransformChangerCam()
    {
        this.maxOffset = 100;
    }

}