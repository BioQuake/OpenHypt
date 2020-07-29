using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DoorAnimator : MonoBehaviour
{
    public Transform Door;
    public Transform MainBody;
    public bool LeftDoor;
    public bool DoorOpen;
    public bool Entered;
    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && this.Entered)
        {
            if (this.DoorOpen)
            {
                this.DoorOpen = false;
            }
            else
            {
                this.DoorOpen = true;
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.LeftDoor)
        {
            if (!this.DoorOpen)
            {
                if (this.Door.transform.localPosition.y > -0.001f)
                {
                    if (this.Door.transform.localPosition.x < 0)
                    {

                        {
                            float _1728 = this.Door.transform.localPosition.x + 0.005f;
                            Vector3 _1729 = this.Door.transform.localPosition;
                            _1729.x = _1728;
                            this.Door.transform.localPosition = _1729;
                        }
                    }
                }
                if (this.Door.transform.localPosition.y < -0.001f)
                {

                    {
                        float _1730 = this.Door.transform.localPosition.y + 0.01f;
                        Vector3 _1731 = this.Door.transform.localPosition;
                        _1731.y = _1730;
                        this.Door.transform.localPosition = _1731;
                    }
                }
            }
            else
            {
                if (this.Door.transform.localPosition.x > -0.3f)
                {

                    {
                        float _1732 = this.Door.transform.localPosition.x - 0.005f;
                        Vector3 _1733 = this.Door.transform.localPosition;
                        _1733.x = _1732;
                        this.Door.transform.localPosition = _1733;
                    }
                }
                if (this.Door.transform.localPosition.x < -0.3f)
                {
                    if (this.Door.transform.localPosition.y > -1.8f)
                    {

                        {
                            float _1734 = this.Door.transform.localPosition.y - 0.01f;
                            Vector3 _1735 = this.Door.transform.localPosition;
                            _1735.y = _1734;
                            this.Door.transform.localPosition = _1735;
                        }
                    }
                }
            }
        }
        else
        {
            if (!this.DoorOpen)
            {
                if (this.Door.transform.localPosition.y > -0.001f)
                {
                    if (this.Door.transform.localPosition.x > 0)
                    {

                        {
                            float _1736 = this.Door.transform.localPosition.x - 0.005f;
                            Vector3 _1737 = this.Door.transform.localPosition;
                            _1737.x = _1736;
                            this.Door.transform.localPosition = _1737;
                        }
                    }
                }
                if (this.Door.transform.localPosition.y < -0.001f)
                {

                    {
                        float _1738 = this.Door.transform.localPosition.y + 0.01f;
                        Vector3 _1739 = this.Door.transform.localPosition;
                        _1739.y = _1738;
                        this.Door.transform.localPosition = _1739;
                    }
                }
            }
            else
            {
                if (this.Door.transform.localPosition.x < 0.3f)
                {

                    {
                        float _1740 = this.Door.transform.localPosition.x + 0.005f;
                        Vector3 _1741 = this.Door.transform.localPosition;
                        _1741.x = _1740;
                        this.Door.transform.localPosition = _1741;
                    }
                }
                if (this.Door.transform.localPosition.x > 0.3f)
                {
                    if (this.Door.transform.localPosition.y > -1.8f)
                    {

                        {
                            float _1742 = this.Door.transform.localPosition.y - 0.01f;
                            Vector3 _1743 = this.Door.transform.localPosition;
                            _1743.y = _1742;
                            this.Door.transform.localPosition = _1743;
                        }
                    }
                }
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("csTC1") || other.name.Contains("sTC1"))
        {
            if (!other.name.Contains("TC1d"))
            {
                this.Entered = true;
            }
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("csTC1") || other.name.Contains("sTC1"))
        {
            if (!other.name.Contains("TC1d"))
            {
                this.Entered = false;
            }
        }
    }

}