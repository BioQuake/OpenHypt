using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AgrianDigesterAI : MonoBehaviour
{
    public Transform LevelPoint;
    public Transform PermeatePoint;
    public Transform SpinPoint;
    public Transform Permeator;
    public GameObject Container1;
    public GameObject Container2;
    public AgrianArmController Arm;
    public StrongGyroStabilizer Gyro;
    public bool Pausing;
    public bool IsBeingRefitted;
    public bool Continue;
    public int ContinueIn;
    public float MoveForce;
    public int Permeating;
    public float WaypointDist;
    public Transform Waypoint;
    public LayerMask targetLayers;
    public virtual void Start()
    {
        this.InvokeRepeating("Reader", 1, 0.5f);
    }

    public virtual void FixedUpdate()
    {
        if (!this.Pausing)
        {

            {
                int _598 = -2000;
                Vector3 _599 = this.LevelPoint.transform.position;
                _599.y = _598;
                this.LevelPoint.transform.position = _599;
            }

            {
                float _600 = this.transform.position.x;
                Vector3 _601 = this.LevelPoint.transform.position;
                _601.x = _600;
                this.LevelPoint.transform.position = _601;
            }

            {
                float _602 = this.transform.position.z;
                Vector3 _603 = this.LevelPoint.transform.position;
                _603.z = _602;
                this.LevelPoint.transform.position = _603;
            }
            if (this.Permeating < 40)
            {
                if (this.Gyro.offset > 5)
                {
                    this.Gyro.offset = this.Gyro.offset - 5;
                }
                if (this.Waypoint != null)
                {
                    if (Vector3.Distance(this.transform.position, this.Waypoint.position) > this.WaypointDist)
                    {
                        this.GetComponent<Rigidbody>().AddForce((this.Waypoint.transform.position - this.transform.position).normalized * this.MoveForce);
                    }
                    if (Vector3.Distance(this.transform.position, this.Waypoint.position) < this.WaypointDist)
                    {
                        this.GetComponent<Rigidbody>().AddForce((this.Waypoint.transform.position - this.transform.position) * 0);
                    }
                }
            }
            if (this.Permeating > 40)
            {
                if (this.Gyro.offset < 1000)
                {
                    this.Gyro.offset = this.Gyro.offset + 5;
                }
                this.Permeator.gameObject.GetComponent<Rigidbody>().AddForce(((this.PermeatePoint.transform.position - this.Permeator.position).normalized * this.MoveForce) * 2);
                this.GetComponent<Rigidbody>().AddForce(((this.PermeatePoint.transform.position - this.transform.position).normalized * this.MoveForce) * 8);
                this.GetComponent<Rigidbody>().AddForce(((this.Waypoint.transform.position - this.transform.position).normalized * this.MoveForce) * 8);
            }
            if (this.Permeating < 40)
            {
                if (this.Permeating > 30)
                {
                    this.Permeator.gameObject.GetComponent<Rigidbody>().AddForce(((this.PermeatePoint.transform.position - this.Permeator.position).normalized * -this.MoveForce) * 2);
                }
            }
        }
    }

    public virtual void Reader()
    {
        RaycastHit hit = default(RaycastHit);
        int Interval = Random.Range(0, 30);
        if (this.Pausing)
        {
            if ((this.Container1 == null) || (this.Container2 == null))
            {
                this.IsBeingRefitted = true;
            }
            if (((this.Container1 != null) && (this.Container2 != null)) && this.IsBeingRefitted)
            {
                this.ContinueIn = 31;
                this.Continue = true;
            }
            if (this.Continue)
            {
                this.IsBeingRefitted = false;
                this.ContinueIn = this.ContinueIn - 1;
                if (this.ContinueIn == 0)
                {
                    this.Pausing = false;
                    this.Continue = false;
                    this.Arm.Aiming = true;
                    this.Permeating = 60;
                }
            }
        }
        if ((this.Permeating == 40) && !this.Pausing)
        {
            this.Arm.AimerTarget = this.SpinPoint;
            if (this.Container1)
            {
                if (this.Container1.gameObject.GetComponent<AgrianContainerController>().AmountOfStuff > 0)
                {
                    this.Container1.gameObject.GetComponent<AgrianContainerController>().AmountOfStuff = ((int) this.Container1.gameObject.GetComponent<AgrianContainerController>().AmountOfStuff) + 40;
                }
            }
            if (this.Container2)
            {
                if (this.Container2.gameObject.GetComponent<AgrianContainerController>().AmountOfStuff > 0)
                {
                    this.Container2.gameObject.GetComponent<AgrianContainerController>().AmountOfStuff = ((int) this.Container2.gameObject.GetComponent<AgrianContainerController>().AmountOfStuff) + 40;
                }
            }
            if (this.Container1)
            {
                if (this.Container1.gameObject.GetComponent<AgrianContainerController>().AmountOfStuff > 200)
                {
                    if (this.Container2)
                    {
                        this.Container2.gameObject.GetComponent<AgrianContainerController>().AmountOfStuff = ((int) this.Container2.gameObject.GetComponent<AgrianContainerController>().AmountOfStuff) + 40;
                    }
                    this.Pausing = true;
                    this.Arm.Aiming = false;
                }
            }
            if (this.Container2)
            {
                if (this.Container2.gameObject.GetComponent<AgrianContainerController>().AmountOfStuff > 200)
                {
                    if (this.Container1)
                    {
                        this.Container1.gameObject.GetComponent<AgrianContainerController>().AmountOfStuff = ((int) this.Container1.gameObject.GetComponent<AgrianContainerController>().AmountOfStuff) + 40;
                    }
                    this.Pausing = true;
                    this.Arm.Aiming = false;
                }
            }
        }
        if (!this.Pausing)
        {
            switch (Interval)
            {
                case 1:
                    if (this.Permeating == 1)
                    {
                        this.Permeating = 0;
                    }
                    break;
            }
            if (this.Permeating > 1)
            {
                this.Permeating = this.Permeating - 1;
            }
            Debug.DrawRay(this.Permeator.position + (this.Permeator.forward * 50), this.Permeator.forward * 1000f, Color.red);
            if (Physics.Raycast(this.Permeator.position + (this.Permeator.forward * 50), this.Permeator.forward, out hit, 1000, (int) this.targetLayers))
            {
                if (hit.collider.name.Contains("PermeatePoint") && (this.Permeating == 0))
                {
                    this.PermeatePoint.position = hit.point;
                    this.Arm.AimerTarget = this.PermeatePoint;
                    this.Permeating = 120;
                }
            }
        }
    }

    public AgrianDigesterAI()
    {
        this.MoveForce = 10f;
        this.WaypointDist = 2;
    }

}