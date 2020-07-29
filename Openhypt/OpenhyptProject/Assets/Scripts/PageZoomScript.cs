using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PageZoomScript : MonoBehaviour
{
    public Transform PageTF;
    public Transform Zoom1;
    public Transform ZoomReset;
    public bool IsActivated;
    public bool zoomed;
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
        if (this.IsActivated)
        {
            if (this.PageTF)
            {
                if (this.zoomed)
                {

                    {
                        float _2550 = Mathf.Lerp(this.PageTF.position.x, this.Zoom1.position.x, Time.deltaTime * 12);
                        Vector3 _2551 = this.PageTF.position;
                        _2551.x = _2550;
                        this.PageTF.position = _2551;
                    }

                    {
                        float _2552 = Mathf.Lerp(this.PageTF.position.y, this.Zoom1.position.y, Time.deltaTime * 12);
                        Vector3 _2553 = this.PageTF.position;
                        _2553.y = _2552;
                        this.PageTF.position = _2553;
                    }

                    {
                        float _2554 = Mathf.Lerp(this.PageTF.position.z, this.Zoom1.position.z, Time.deltaTime * 12);
                        Vector3 _2555 = this.PageTF.position;
                        _2555.z = _2554;
                        this.PageTF.position = _2555;
                    }

                    {
                        float _2556 = Mathf.Lerp(this.PageTF.localScale.x, this.Zoom1.localScale.x, Time.deltaTime * 12);
                        Vector3 _2557 = this.PageTF.localScale;
                        _2557.x = _2556;
                        this.PageTF.localScale = _2557;
                    }

                    {
                        float _2558 = Mathf.Lerp(this.PageTF.localScale.y, this.Zoom1.localScale.y, Time.deltaTime * 12);
                        Vector3 _2559 = this.PageTF.localScale;
                        _2559.y = _2558;
                        this.PageTF.localScale = _2559;
                    }

                    {
                        float _2560 = Mathf.Lerp(this.PageTF.localScale.z, this.Zoom1.localScale.z, Time.deltaTime * 12);
                        Vector3 _2561 = this.PageTF.localScale;
                        _2561.z = _2560;
                        this.PageTF.localScale = _2561;
                    }
                }
                else
                {

                    {
                        float _2562 = Mathf.Lerp(this.PageTF.position.x, this.ZoomReset.position.x, Time.deltaTime * 12);
                        Vector3 _2563 = this.PageTF.position;
                        _2563.x = _2562;
                        this.PageTF.position = _2563;
                    }

                    {
                        float _2564 = Mathf.Lerp(this.PageTF.position.y, this.ZoomReset.position.y, Time.deltaTime * 12);
                        Vector3 _2565 = this.PageTF.position;
                        _2565.y = _2564;
                        this.PageTF.position = _2565;
                    }

                    {
                        float _2566 = Mathf.Lerp(this.PageTF.position.z, this.ZoomReset.position.z, Time.deltaTime * 12);
                        Vector3 _2567 = this.PageTF.position;
                        _2567.z = _2566;
                        this.PageTF.position = _2567;
                    }

                    {
                        float _2568 = Mathf.Lerp(this.PageTF.localScale.x, this.ZoomReset.localScale.x, Time.deltaTime * 12);
                        Vector3 _2569 = this.PageTF.localScale;
                        _2569.x = _2568;
                        this.PageTF.localScale = _2569;
                    }

                    {
                        float _2570 = Mathf.Lerp(this.PageTF.localScale.y, this.ZoomReset.localScale.y, Time.deltaTime * 12);
                        Vector3 _2571 = this.PageTF.localScale;
                        _2571.y = _2570;
                        this.PageTF.localScale = _2571;
                    }

                    {
                        float _2572 = Mathf.Lerp(this.PageTF.localScale.z, this.ZoomReset.localScale.z, Time.deltaTime * 12);
                        Vector3 _2573 = this.PageTF.localScale;
                        _2573.z = _2572;
                        this.PageTF.localScale = _2573;
                    }
                }
            }
        }
    }

    public virtual void Reset()
    {
        this.zoomed = false;
        this.IsActivated = false;
        if (this.PageTF)
        {

            {
                float _2574 = this.ZoomReset.position.x;
                Vector3 _2575 = this.PageTF.position;
                _2575.x = _2574;
                this.PageTF.position = _2575;
            }

            {
                float _2576 = this.ZoomReset.position.y;
                Vector3 _2577 = this.PageTF.position;
                _2577.y = _2576;
                this.PageTF.position = _2577;
            }

            {
                float _2578 = this.ZoomReset.position.z;
                Vector3 _2579 = this.PageTF.position;
                _2579.z = _2578;
                this.PageTF.position = _2579;
            }

            {
                float _2580 = this.ZoomReset.localScale.x;
                Vector3 _2581 = this.PageTF.localScale;
                _2581.x = _2580;
                this.PageTF.localScale = _2581;
            }

            {
                float _2582 = this.ZoomReset.localScale.y;
                Vector3 _2583 = this.PageTF.localScale;
                _2583.y = _2582;
                this.PageTF.localScale = _2583;
            }

            {
                float _2584 = this.ZoomReset.localScale.z;
                Vector3 _2585 = this.PageTF.localScale;
                _2585.z = _2584;
                this.PageTF.localScale = _2585;
            }
        }
    }

    public virtual void OnMouseDown()
    {
        if (!this.zoomed)
        {
            this.zoomed = true;
        }
        else
        {
            this.zoomed = false;
        }
    }

}