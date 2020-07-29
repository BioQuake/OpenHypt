using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ArchoswirlController : MonoBehaviour
{
    public float DirForce;
    public float HoverForce;
    public float StabForce;
    public float DownForce;
    public float MaxHoverForce;
    public float HoverDistance;
    public float Force;
    public float Torque;
    public Transform Spinner;
    public AnimationCurve curve;
    public LayerMask targetLayers;
    public virtual void Start()
    {
        this.GetComponent<Rigidbody>().centerOfMass = new Vector3(0, 0, 0);
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        if (Vector3.Distance(this.transform.position, PlayerInformation.instance.PiriPresence.position) < 500)
        {
            Debug.DrawRay(this.Spinner.transform.position + (this.Spinner.transform.forward * 2), this.Spinner.transform.forward * 100f, Color.red);
            if (Physics.Raycast(this.Spinner.transform.position + (this.Spinner.transform.forward * 2), this.Spinner.transform.forward, 100, (int) this.targetLayers))
            {
                this.GetComponent<Rigidbody>().AddForce(this.Spinner.transform.forward * this.DirForce);
            }
            else
            {
                this.Spinner.Rotate(0, 10, 0 * Time.deltaTime);
            }
            if (Physics.Raycast(this.transform.position, Vector3.down, out hit, this.HoverDistance, (int) this.targetLayers))
            {
                this.HoverForce = this.curve.Evaluate(hit.distance);
                if (this.HoverForce > this.MaxHoverForce)
                {
                    this.HoverForce = this.MaxHoverForce;
                }
                this.GetComponent<Rigidbody>().AddForce(Vector3.up * this.HoverForce);
            }
            this.GetComponent<Rigidbody>().AddForce(Vector3.down * this.DownForce);
            this.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * this.StabForce, this.transform.up * 1);
            this.GetComponent<Rigidbody>().AddForceAtPosition(-Vector3.up * this.StabForce, -this.transform.up * 1);
            this.GetComponent<Rigidbody>().AddTorque(this.transform.up * Random.Range(-this.Torque, this.Torque));
            this.GetComponent<Rigidbody>().AddTorque(this.transform.right * Random.Range(-this.Torque, this.Torque));
            this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * Random.Range(-this.Torque, this.Torque));
            this.GetComponent<Rigidbody>().AddForce(this.transform.up * Random.Range(-this.Force, this.Force));
            this.GetComponent<Rigidbody>().AddForce(this.transform.right * Random.Range(-this.Force, this.Force));
            this.GetComponent<Rigidbody>().AddForce(this.transform.forward * Random.Range(-this.Force, this.Force));
        }
    }

    public ArchoswirlController()
    {
        this.DirForce = 0.005f;
        this.HoverForce = 1;
        this.StabForce = 1;
        this.DownForce = 1;
        this.MaxHoverForce = 90000;
        this.HoverDistance = 20;
        this.Force = 1;
        this.Torque = 1;
        this.curve = new AnimationCurve();
    }

}