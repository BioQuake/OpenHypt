using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RayEndPoint : MonoBehaviour
{
    public Transform Point;
    public Transform target;
    public Transform MainVessel;
    public bool CanLockOn;
    public bool Locked;
    public LayerMask targetLayers;
    public LayerMask targetLayers2;
    public virtual void Start()
    {
        this.Point = GameObject.Find("AimPointTarget").gameObject.transform;
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        if (WorldInformation.playerCar == this.MainVessel.name)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (this.Locked)
                {
                    this.Locked = false;
                    this.target = null;
                    CallButton.CallingLock0 = true;
                }
            }
            if (Input.GetMouseButton(1))
            {
                if (this.CanLockOn)
                {
                    if (!this.Locked)
                    {
                        if (Physics.Raycast(this.transform.position, -this.transform.up, out hit2, Mathf.Infinity, (int) this.targetLayers2))
                        {
                            if (hit2.collider.name.Contains("TC"))
                            {
                                if (!hit2.collider.name.Contains("TC1"))
                                {
                                    if (!hit2.collider.name.Contains("_P"))
                                    {
                                        this.Locked = true;
                                        this.target = hit2.transform;
                                        CallButton.LockedName = hit2.collider.name;
                                        CallButton.CallingLock1 = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (Physics.Raycast(this.transform.position, -this.transform.up, out hit, Mathf.Infinity, (int) this.targetLayers))
                {
                    this.Point.position = hit.point;
                }
                else
                {
                    this.Point.position = this.transform.position + (-this.transform.up * 1000);
                }
            }
        }
    }

}