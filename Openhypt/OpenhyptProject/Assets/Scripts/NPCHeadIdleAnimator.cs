using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class NPCHeadIdleAnimator : MonoBehaviour
{
    public Transform target;
    public SphereCollider Trigger;
    public Transform LookTarget;
    public Transform EyeLookTarget;
    public Transform EyeResetTarget;
    public Transform ResetTarget;
    public bool Looking;
    public bool IsLooking;
    public static bool CanTurnHead;
    public bool DoOnce;
    private Quaternion NewRotation;
    public string IgnoreSelf;
    public Transform RandAim1;
    public Transform RandAim2;
    public Transform RandAim3;
    public Transform EyeRandAim1;
    public Transform EyeRandAim2;
    public Transform EyeRandAim3;
    public float LookForce;
    public float EyeLookForce;
    public GameObject REye;
    public GameObject LEye;
    public virtual void FixedUpdate()
    {
        if ((this.LookTarget && this.Looking) && !this.IsLooking)
        {
            this.GetComponent<Rigidbody>().AddForceAtPosition((this.LookTarget.transform.position - this.transform.position).normalized * this.LookForce, -this.transform.forward * 1);
            this.GetComponent<Rigidbody>().AddForceAtPosition((this.LookTarget.transform.position - this.transform.position).normalized * -this.LookForce, this.transform.forward * 1);
        }
        if (WorldInformation.IsOotkinSick)
        {
            this.REye.GetComponent<Rigidbody>().AddTorque(this.transform.up * 1E-05f);
            this.REye.GetComponent<Rigidbody>().AddTorque(this.transform.right * -1E-05f);
            this.LEye.GetComponent<Rigidbody>().AddTorque(this.transform.up * -1E-05f);
            this.LEye.GetComponent<Rigidbody>().AddTorque(this.transform.right * -1E-05f);
        }
        if ((this.EyeLookTarget && this.Looking) && !WorldInformation.IsOotkinSick)
        {
            this.REye.GetComponent<Rigidbody>().AddForceAtPosition((this.EyeLookTarget.transform.position - this.REye.transform.position).normalized * this.EyeLookForce, -this.REye.transform.forward * 0.4f);
            this.REye.GetComponent<Rigidbody>().AddForceAtPosition((this.EyeLookTarget.transform.position - this.REye.transform.position).normalized * -this.EyeLookForce, this.REye.transform.forward * 0.4f);
            this.LEye.GetComponent<Rigidbody>().AddForceAtPosition((this.EyeLookTarget.transform.position - this.LEye.transform.position).normalized * this.EyeLookForce, -this.LEye.transform.forward * 0.4f);
            this.LEye.GetComponent<Rigidbody>().AddForceAtPosition((this.EyeLookTarget.transform.position - this.LEye.transform.position).normalized * -this.EyeLookForce, this.LEye.transform.forward * 0.4f);
        }
        if (NPCHeadIdleAnimator.CanTurnHead || !CameraScript.InInterface)
        {
            if (this.IsLooking)
            {
                this.GetComponent<Rigidbody>().AddForceAtPosition((this.target.transform.position - this.transform.position).normalized * this.LookForce, -this.transform.forward * 1);
                this.GetComponent<Rigidbody>().AddForceAtPosition((this.target.transform.position - this.transform.position).normalized * -this.LookForce, this.transform.forward * 1);
            }
        }
    }

    public virtual void Notice()
    {
        if (PlayerInformation.instance.Pirizuka.gameObject.activeSelf == true)
        {
            this.StartCoroutine(this.Notice2());
        }
    }

    public virtual IEnumerator Notice2()
    {
        this.Looking = false;
        this.Trigger.center = new Vector3(0, 0, -70);
        this.Trigger.radius = 70;
        int Interval = Random.Range(0, 2);
        switch (Interval)
        {
            case 1:
                this.Trigger.center = new Vector3(0, 0, 0);
                this.Trigger.radius = 0.1f;
                this.LookTarget = this.ResetTarget;
                break;
        }
        if (this.LookTarget == this.ResetTarget)
        {
            int Interval2 = Random.Range(0, 10);
            switch (Interval2)
            {
                case 1:
                    this.LookTarget = this.RandAim1;
                    break;
                case 2:
                    this.LookTarget = this.RandAim2;
                    break;
                case 3:
                    this.LookTarget = this.RandAim3;
                    break;
            }
        }
        yield return new WaitForSeconds(0.1f);
        this.Looking = true;
    }

    public virtual void EyeNotice()
    {
        if (this.LookTarget == this.ResetTarget)
        {
            int Interval = Random.Range(0, 16);
            switch (Interval)
            {
                case 1:
                    this.EyeLookTarget = this.EyeResetTarget;
                    break;
                case 2:
                    this.EyeLookTarget = this.EyeRandAim1;
                    break;
                case 3:
                    this.EyeLookTarget = this.EyeRandAim2;
                    break;
                case 4:
                    this.EyeLookTarget = this.EyeRandAim3;
                    break;
            }
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform == this.LookTarget)
        {
            this.Trigger.center = new Vector3(0, 0, 0);
            this.Trigger.radius = 0.1f;
            this.LookTarget = this.ResetTarget;
            this.EyeLookTarget = this.EyeResetTarget;
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Collider>().name.Contains(this.IgnoreSelf))
        {
            return;
        }
        if (other.GetComponent<Collider>().name.Contains("TC"))
        {
            this.LookTarget = other.gameObject.transform;
            this.EyeLookTarget = other.gameObject.transform;
        }
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Notice", 3, 3);
        this.InvokeRepeating("EyeNotice", 3, 0.5f);
    }

    public NPCHeadIdleAnimator()
    {
        this.LookForce = 0.1f;
        this.EyeLookForce = 0.1f;
    }

}