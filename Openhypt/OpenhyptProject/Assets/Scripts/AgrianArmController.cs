using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AgrianArmController : MonoBehaviour
{
    public GameObject Aimer;
    public GameObject Arm;
    public bool Aiming;
    public GameObject AimerTip;
    public Transform AimerTarget;
    public float AimForce;
    public float AimVel;
    private Quaternion NewRotation;
    public virtual void Start()
    {
    }

    public virtual void FixedUpdate()
    {
        if (this.Aiming)
        {
            this.NewRotation = Quaternion.LookRotation(this.AimerTarget.position - this.Aimer.transform.position);
            this.Aimer.transform.rotation = Quaternion.RotateTowards(this.Aimer.transform.rotation, this.NewRotation, Time.deltaTime * this.AimVel);
            this.Arm.GetComponent<Rigidbody>().AddForceAtPosition((this.AimerTip.transform.position - this.Arm.transform.position).normalized * -this.AimForce, -this.Arm.transform.forward * 100);
            this.Arm.GetComponent<Rigidbody>().AddForceAtPosition((this.AimerTip.transform.position - this.Arm.transform.position).normalized * this.AimForce, this.Arm.transform.forward * 100);
        }
    }

    public AgrianArmController()
    {
        this.AimForce = 10f;
        this.AimVel = 50;
    }

}