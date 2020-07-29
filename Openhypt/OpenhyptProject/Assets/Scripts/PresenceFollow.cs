using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PresenceFollow : MonoBehaviour
{
    public Transform Piri;
    public GameObject PiriGO;
    public Rigidbody PiriRB;
    public Transform thisTransform;
    public Rigidbody thisRigidbody;
    public int dirFAmount;
    public int RotAmount;
    public int UpRotAmount;
    public int DownRotAmount;
    public static bool insideNPC;
    public LayerMask targetLayers;
    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 0.33f, 0.33f);
        this.thisTransform.position = this.Piri.position;
    }

    public virtual void FixedUpdate()
    {
        if (!this.PiriGO.active)
        {
            if (!PresenceFollow.insideNPC)
            {
                this.thisTransform.position = WorldInformation.vehicleController.transform.position;
            }
            else
            {
                this.thisTransform.position = WorldInformation.npcVehicleTF.position;
            }
        }
        else
        {
            if (WorldInformation.FPMode)
            {
                //thisRigidbody.velocity = PiriRB.velocity;
                //thisTransform.position = Piri.position;
                if (this.dirFAmount < 1000)
                {
                    this.dirFAmount = this.dirFAmount + 10;
                }
                if (WorldInformation.UsingVessel)
                {
                    this.thisRigidbody.AddForce((this.Piri.position - this.thisTransform.position) * 50);
                }
                else
                {
                    this.thisRigidbody.AddForce((this.Piri.position - this.thisTransform.position) * this.dirFAmount);
                }
            }
            else
            {
                if (this.dirFAmount > 50)
                {
                    this.dirFAmount = this.dirFAmount - 10;
                }
                else
                {
                    this.dirFAmount = 50;
                }
                this.thisRigidbody.AddForce((this.Piri.position - this.thisTransform.position) * this.dirFAmount);
            }
        }
    }

    public virtual void Tick()
    {
        Vector3 newRot = ((this.thisTransform.up * 2) + (this.thisTransform.right * 2)).normalized;
        Vector3 newRot2 = ((this.thisTransform.up * -2) + (this.thisTransform.right * -2)).normalized;
        if (!Physics.Raycast(this.thisTransform.position + this.thisTransform.up, newRot, 128, (int) this.targetLayers) && !Physics.Raycast(this.thisTransform.position + this.thisTransform.up, newRot2, 128, (int) this.targetLayers))
        {
            Debug.DrawRay(this.thisTransform.position + this.thisTransform.up, newRot * 128, Color.white);
            Debug.DrawRay(this.thisTransform.position + this.thisTransform.up, newRot2 * 128, Color.white);

            {
                float _2906 = this.thisTransform.localEulerAngles.y + 30;
                Vector3 _2907 = this.thisTransform.localEulerAngles;
                _2907.y = _2906;
                this.thisTransform.localEulerAngles = _2907;
            }
            this.RotAmount = this.RotAmount + 1;
        }
        else
        {
            this.RotAmount = 0;
            WorldInformation.PiriFree = false;
            if (!Physics.Raycast(this.thisTransform.position + this.thisTransform.up, newRot, 128, (int) this.targetLayers))
            {
                Debug.DrawRay(this.thisTransform.position + this.thisTransform.up, newRot * 128, Color.white);

                {
                    float _2908 = this.thisTransform.localEulerAngles.y + 30;
                    Vector3 _2909 = this.thisTransform.localEulerAngles;
                    _2909.y = _2908;
                    this.thisTransform.localEulerAngles = _2909;
                }
                this.UpRotAmount = this.UpRotAmount + 1;
            }
            else
            {
                this.UpRotAmount = 0;
                WorldInformation.PiriTopFree = false;
            }
            if (!Physics.Raycast(this.thisTransform.position + this.thisTransform.up, newRot2, 128, (int) this.targetLayers))
            {
                Debug.DrawRay(this.thisTransform.position + this.thisTransform.up, newRot2 * 128, Color.white);

                {
                    float _2910 = this.thisTransform.localEulerAngles.y + 30;
                    Vector3 _2911 = this.thisTransform.localEulerAngles;
                    _2911.y = _2910;
                    this.thisTransform.localEulerAngles = _2911;
                }
                this.DownRotAmount = this.DownRotAmount + 1;
            }
            else
            {
                this.DownRotAmount = 0;
                WorldInformation.PiriBottomFree = false;
            }
        }
        if (this.RotAmount > 11)
        {

            {
                int _2912 = 0;
                Vector3 _2913 = this.thisTransform.localEulerAngles;
                _2913.y = _2912;
                this.thisTransform.localEulerAngles = _2913;
            }
            this.RotAmount = 0;
            WorldInformation.PiriFree = true;
        }
        if (this.UpRotAmount > 11)
        {

            {
                int _2914 = 0;
                Vector3 _2915 = this.thisTransform.localEulerAngles;
                _2915.y = _2914;
                this.thisTransform.localEulerAngles = _2915;
            }
            this.UpRotAmount = 0;
            WorldInformation.PiriTopFree = true;
        }
        if (this.DownRotAmount > 11)
        {

            {
                int _2916 = 0;
                Vector3 _2917 = this.thisTransform.localEulerAngles;
                _2917.y = _2916;
                this.thisTransform.localEulerAngles = _2917;
            }
            this.DownRotAmount = 0;
            WorldInformation.PiriBottomFree = true;
        }
    }

}