using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AgrianCarrierAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform ResetPoint;
    public Transform Magnet1;
    public Transform EmptyContainer;
    public Transform FullContainer;
    public GameObject Vessel;
    public GameObject Presence;
    public GameObject Gyro;
    public AudioSource StartupAudio;
    public AudioSource SpeedingAudio;
    public AudioSource PassbyAudio;
    public bool HasEmpty;
    public bool HasFull;
    public bool SlowingDown;
    public bool Obstacle;
    public bool Brake;
    public bool StartFast;
    public bool TargetTooClose;
    public bool TurnRight;
    public bool TurnLeft;
    public int Still;
    public float PointY;
    public float PointZ;
    public LayerMask targetLayers;
    private Quaternion NewRotation;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Reader", 1, 0.5f);
        this.PointY = this.ResetPoint.transform.position.y;
        this.PointZ = this.ResetPoint.transform.position.z;
        this.Brake = true;
        yield return new WaitForSeconds(5);
        this.Brake = false;
        ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 2000;
        yield return new WaitForSeconds(5);
        this.Still = 0;
        if (this.StartFast)
        {
            this.StartFast = false;
        }
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.target != null)
        {

            {
                float _538 = this.PointY;
                Vector3 _539 = this.ResetPoint.transform.position;
                _539.y = _538;
                this.ResetPoint.transform.position = _539;
            }

            {
                float _540 = this.PointZ;
                Vector3 _541 = this.ResetPoint.transform.position;
                _541.z = _540;
                this.ResetPoint.transform.position = _541;
            }
        }
        if (this.target == null)
        {
            this.target = this.ResetPoint;
        }
        Vector3 newRot = (this.transform.forward * 0.6f).normalized;
        Debug.DrawRay(this.transform.position + (this.transform.forward * 100), newRot * 1000f, Color.green);
        if (Physics.Raycast(this.transform.position + (this.transform.forward * 100), newRot, out hit, 1000) && (this.Vessel.GetComponent<Rigidbody>().velocity.magnitude > 50))
        {
            this.SlowingDown = true;
        }
        else
        {
            this.SlowingDown = false;
        }
        newRot = ((this.transform.forward * 0.6f) + (this.transform.right * 0.4f)).normalized;
        Debug.DrawRay(this.transform.position + (this.transform.forward * 100), newRot * 500f, Color.black);
        if (Physics.Raycast(this.transform.position + (this.transform.forward * 100), newRot, 500))
        {
            this.TurnLeft = true;
        }
        else
        {
            this.TurnLeft = false;
        }
        newRot = ((this.transform.forward * 0.6f) + (this.transform.right * -0.4f)).normalized;
        Debug.DrawRay(this.transform.position + (this.transform.forward * 100), newRot * 500f, Color.black);
        if (Physics.Raycast(this.transform.position + (this.transform.forward * 100), newRot, 500))
        {
            this.TurnRight = true;
        }
        else
        {
            this.TurnRight = false;
        }
        Debug.DrawRay(this.transform.position + (this.transform.forward * 100), this.transform.forward * 80f, Color.white);
        if (Physics.Raycast(this.transform.position + (this.transform.forward * 100), this.transform.forward, 80))
        {
            this.Obstacle = true;
        }
        else
        {
            this.Obstacle = false;
        }
    }

    public virtual void FixedUpdate()
    {
        Vector3 localV = this.transform.InverseTransformDirection(this.GetComponent<Rigidbody>().velocity);
        if (this.Brake)
        {
            if (this.PassbyAudio.volume > 0)
            {
                this.PassbyAudio.volume = this.PassbyAudio.volume - 0.005f;
            }
        }
        if (this.Vessel.GetComponent<Rigidbody>().velocity.magnitude < 100)
        {
            if (this.SpeedingAudio.volume > 0)
            {
                this.SpeedingAudio.volume = this.SpeedingAudio.volume - 0.01f;
            }
        }
        if (this.Vessel.GetComponent<Rigidbody>().velocity.magnitude > 100)
        {
            if (this.SpeedingAudio.volume < 1)
            {
                this.SpeedingAudio.volume = this.SpeedingAudio.volume + 0.001f;
            }
        }
        if (this.target)
        {
            this.NewRotation = Quaternion.LookRotation(this.target.position - this.transform.position);
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, this.NewRotation, Time.deltaTime * 20);
        }
        if (this.SlowingDown && !this.Brake)
        {
            if (localV.z > 50)
            {
                this.Vessel.GetComponent<Rigidbody>().AddForce(-this.Vessel.transform.up * -700000);
            }
        }
        if (this.Obstacle && !this.Brake)
        {
            if (localV.z > 0)
            {
                this.Vessel.GetComponent<Rigidbody>().AddForce(-this.Vessel.transform.up * -700000);
            }
        }
        if (this.Brake)
        {
            if (localV.z > 50)
            {
                this.Vessel.GetComponent<Rigidbody>().drag = 2.5f;
                this.Vessel.GetComponent<Rigidbody>().AddForce(-this.Vessel.transform.up * -1800000);
            }
        }
        if ((((!this.Obstacle && !this.SlowingDown) && !this.TurnLeft) && !this.TurnRight) && !this.Brake)
        {
            if (this.Vessel.GetComponent<Rigidbody>().angularVelocity.magnitude < 0.05f)
            {
                this.Vessel.GetComponent<Rigidbody>().AddForce(-this.Vessel.transform.up * 700000);
            }
            this.Vessel.GetComponent<Rigidbody>().drag = 0.08f;
            if (this.StartFast)
            {
                this.Vessel.GetComponent<Rigidbody>().AddForce(-this.Vessel.transform.up * 2300000);
            }
        }
        if (this.TurnLeft)
        {
            this.Vessel.GetComponent<Rigidbody>().AddTorque(this.transform.forward * -350000);
        }
        if (this.TurnRight)
        {
            this.Vessel.GetComponent<Rigidbody>().AddTorque(this.transform.forward * 350000);
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
    }

    public virtual void Reader()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.Vessel.GetComponent<Rigidbody>().velocity.magnitude < 1)
        {
            this.Still = this.Still + 1;
            if (this.Still == 40)
            {
                this.StartupAudio.Play();
                this.Still = 0;
                this.Brake = false;
                this.Vessel.GetComponent<Rigidbody>().drag = 0.08f;
            }
        }
        this.GetComponent<Rigidbody>().freezeRotation = true;
        Debug.DrawRay(this.transform.position, this.transform.forward * 30f, Color.red);
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 30, (int) this.targetLayers))
        {
        }
    }

}