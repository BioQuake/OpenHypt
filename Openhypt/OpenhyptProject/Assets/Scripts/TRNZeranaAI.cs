using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TRNZeranaAI : MonoBehaviour
{
    public Transform thisVTransform;
    public LayerMask targetLayers;
    public bool TurnRight;
    public bool TurnLeft;
    public float TurnRF;
    public float TurnLF;
    public float TurnRaySideness;
    public virtual void Start()
    {
        this.TurnRaySideness = 300;
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        this.TurnLeft = false;
        this.TurnRight = false;
        Debug.DrawRay((this.thisVTransform.position + (this.thisVTransform.right * this.TurnRaySideness)) + (-this.thisVTransform.forward * 900), -this.thisVTransform.up * 20000, Color.green);
        if (Physics.Raycast((this.thisVTransform.position + (this.thisVTransform.right * this.TurnRaySideness)) + (-this.thisVTransform.forward * 900), -this.thisVTransform.up, out hit, 20000, (int) this.targetLayers))
        {
            this.TurnLeft = true;
        }
        Debug.DrawRay((this.thisVTransform.position + (-this.thisVTransform.right * this.TurnRaySideness)) + (-this.thisVTransform.forward * 900), -this.thisVTransform.up * 20000, Color.green);
        if (Physics.Raycast((this.thisVTransform.position + (-this.thisVTransform.right * this.TurnRaySideness)) + (-this.thisVTransform.forward * 900), -this.thisVTransform.up, out hit, 20000, (int) this.targetLayers))
        {
            this.TurnRight = true;
        }
    }

    public virtual void FixedUpdate()
    {
        if (!this.TurnRight && !this.TurnLeft)
        {
            if (this.TurnRaySideness < 600)
            {
                this.TurnRaySideness = this.TurnRaySideness + 2;
            }
            else
            {
                this.TurnRaySideness = 300;
            }
        }
        if (this.TurnRight)
        {
            if (this.TurnRF < 0.05f)
            {
                this.TurnRF = this.TurnRF + 5E-05f;
            }
        }
        else
        {
            if (this.TurnRF > 0)
            {
                this.TurnRF = this.TurnRF - 5E-05f;
            }
            else
            {
                this.TurnRF = 0;
            }
        }
        if (this.TurnLeft)
        {
            if (this.TurnLF < 0.05f)
            {
                this.TurnLF = this.TurnLF + 5E-05f;
            }
        }
        else
        {
            if (this.TurnLF > 0)
            {
                this.TurnLF = this.TurnLF - 5E-05f;
            }
            else
            {
                this.TurnLF = 0;
            }
        }

        {
            float _3676 = this.thisVTransform.localEulerAngles.z - this.TurnLF;
            Vector3 _3677 = this.thisVTransform.localEulerAngles;
            _3677.z = _3676;
            this.thisVTransform.localEulerAngles = _3677;
        }

        {
            float _3678 = this.thisVTransform.localEulerAngles.z + this.TurnRF;
            Vector3 _3679 = this.thisVTransform.localEulerAngles;
            _3679.z = _3678;
            this.thisVTransform.localEulerAngles = _3679;
        }
        this.thisVTransform.position = this.thisVTransform.position - (this.thisVTransform.up * 2);
    }

}