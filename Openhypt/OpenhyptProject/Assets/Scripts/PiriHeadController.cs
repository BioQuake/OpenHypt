using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PiriHeadController : MonoBehaviour
{
    public Rigidbody HeadRB;
    public Transform HeadTF;
    public Transform target;
    public Transform LookTarget;
    public Transform EyeLookTarget;
    public Transform EyeResetTarget;
    public Transform ResetTarget;
    public Transform REyeDerp;
    public Transform LEyeDerp;
    public bool Perform;
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
    public Transform REyeTF;
    public Transform LEyeTF;
    public int LookPoints;
    public int LookTime;
    public int RBrowMood;
    public int LBrowMood;
    public int RMouthMood;
    public int LMouthMood;
    public int JawMood;
    public int Mood;
    public Transform RightBrow;
    public Transform LeftBrow;
    public Transform RightMouth;
    public Transform LeftMouth;
    public Rigidbody PiriRB;
    public virtual void Start()
    {
        this.InvokeRepeating("Notice", 3, 3);
        this.InvokeRepeating("EyeNotice", 3, 0.3f);
        PiriHeadController.CanTurnHead = true;
        this.target = GameObject.Find("PiriAimFront").transform;
    }

    public virtual void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            this.IsLooking = true;
        }
        if (WorldInformation.FPMode)
        {
            if (!this.DoOnce)
            {
                this.IsLooking = true;
                this.DoOnce = true;
            }
        }
        if (!WorldInformation.FPMode)
        {
            if (this.DoOnce)
            {
                this.IsLooking = false;
                this.DoOnce = false;
            }
        }
        if (PiriHeadController.CanTurnHead || !CameraScript.InInterface)
        {
            if (Input.GetMouseButtonUp(1))
            {
                this.IsLooking = false;
                this.DoOnce = false;
            }
        }
    }

    private Quaternion RNewRotation;
    private Quaternion LNewRotation;
    public virtual void FixedUpdate()
    {
        if ((this.LookTarget && this.Looking) && !this.IsLooking)
        {
            this.HeadRB.AddForceAtPosition((this.LookTarget.transform.position - this.HeadTF.position).normalized * this.LookForce, -this.HeadTF.forward * 1);
            this.HeadRB.AddForceAtPosition((this.LookTarget.transform.position - this.HeadTF.position).normalized * -this.LookForce, this.HeadTF.forward * 1);
        }
        if (WorldInformation.IsOotkinSick)
        {
            this.RNewRotation = Quaternion.LookRotation(this.REyeDerp.position - this.REyeTF.position);
            this.LNewRotation = Quaternion.LookRotation(this.LEyeDerp.position - this.LEyeTF.position);
            this.REyeTF.rotation = Quaternion.RotateTowards(this.REyeTF.rotation, this.RNewRotation, 5);
            this.LEyeTF.rotation = Quaternion.RotateTowards(this.LEyeTF.rotation, this.LNewRotation, 5);
        }
        if ((this.EyeLookTarget && this.Looking) && !WorldInformation.IsOotkinSick)
        {
            this.RNewRotation = Quaternion.LookRotation(this.EyeLookTarget.position - this.REyeTF.position);
            this.LNewRotation = Quaternion.LookRotation(this.EyeLookTarget.position - this.LEyeTF.position);
            this.REyeTF.rotation = Quaternion.RotateTowards(this.REyeTF.rotation, this.RNewRotation, 5);
            this.LEyeTF.rotation = Quaternion.RotateTowards(this.LEyeTF.rotation, this.LNewRotation, 5);
            if (this.LEyeTF.localEulerAngles.x > 200)
            {
                if (this.LEyeTF.localEulerAngles.x < 340)
                {

                    {
                        int _2700 = 340;
                        Vector3 _2701 = this.LEyeTF.localEulerAngles;
                        _2701.x = _2700;
                        this.LEyeTF.localEulerAngles = _2701;
                    }
                }
            }
            if (this.LEyeTF.localEulerAngles.x < 90)
            {
                if (this.LEyeTF.localEulerAngles.x > 40)
                {

                    {
                        int _2702 = 40;
                        Vector3 _2703 = this.LEyeTF.localEulerAngles;
                        _2703.x = _2702;
                        this.LEyeTF.localEulerAngles = _2703;
                    }
                }
            }
            if (this.LEyeTF.localEulerAngles.y < 135)
            {

                {
                    int _2704 = 135;
                    Vector3 _2705 = this.LEyeTF.localEulerAngles;
                    _2705.y = _2704;
                    this.LEyeTF.localEulerAngles = _2705;
                }
            }
            if (this.LEyeTF.localEulerAngles.y > 225)
            {

                {
                    int _2706 = 225;
                    Vector3 _2707 = this.LEyeTF.localEulerAngles;
                    _2707.y = _2706;
                    this.LEyeTF.localEulerAngles = _2707;
                }
            }
            if (this.REyeTF.localEulerAngles.x > 200)
            {
                if (this.REyeTF.localEulerAngles.x < 340)
                {

                    {
                        int _2708 = 340;
                        Vector3 _2709 = this.REyeTF.localEulerAngles;
                        _2709.x = _2708;
                        this.REyeTF.localEulerAngles = _2709;
                    }
                }
            }
            if (this.REyeTF.localEulerAngles.x < 90)
            {
                if (this.REyeTF.localEulerAngles.x > 40)
                {

                    {
                        int _2710 = 40;
                        Vector3 _2711 = this.REyeTF.localEulerAngles;
                        _2711.x = _2710;
                        this.REyeTF.localEulerAngles = _2711;
                    }
                }
            }
            if (this.REyeTF.localEulerAngles.y < 135)
            {

                {
                    int _2712 = 135;
                    Vector3 _2713 = this.REyeTF.localEulerAngles;
                    _2713.y = _2712;
                    this.REyeTF.localEulerAngles = _2713;
                }
            }
            if (this.REyeTF.localEulerAngles.y > 225)
            {

                {
                    int _2714 = 225;
                    Vector3 _2715 = this.REyeTF.localEulerAngles;
                    _2715.y = _2714;
                    this.REyeTF.localEulerAngles = _2715;
                }
            }
        }
        if (PiriHeadController.CanTurnHead || !CameraScript.InInterface)
        {
            if (this.IsLooking)
            {
                this.HeadRB.AddForceAtPosition((this.target.transform.position - this.HeadTF.position).normalized * this.LookForce, -this.HeadTF.forward * 1);
                this.HeadRB.AddForceAtPosition((this.target.transform.position - this.HeadTF.position).normalized * -this.LookForce, this.HeadTF.forward * 1);
            }
        }

        {
            float _2716 = -0.08f + (-this.RBrowMood * 0.0001f);
            Vector3 _2717 = this.RightBrow.localPosition;
            _2717.x = _2716;
            this.RightBrow.localPosition = _2717;
        }

        {
            float _2718 = -0.08f + (-this.LBrowMood * 0.0001f);
            Vector3 _2719 = this.LeftBrow.localPosition;
            _2719.x = _2718;
            this.LeftBrow.localPosition = _2719;
        }

        /*{
            int _2720 = this.RMouthMood;
            Vector3 _2721 = this.RightMouth.localEulerAngles;
            _2721.x = _2720;
            this.RightMouth.localEulerAngles = _2721;
        }

        {
            float _2722 = 270 + (this.RMouthMood * 0.5f);
            Vector3 _2723 = this.RightMouth.localEulerAngles;
            _2723.y = _2722;
            this.RightMouth.localEulerAngles = _2723;
        }

        {
            int _2724 = -this.LMouthMood;
            Vector3 _2725 = this.LeftMouth.localEulerAngles;
            _2725.x = _2724;
            this.LeftMouth.localEulerAngles = _2725;
        }

        {
            float _2726 = 270 + (this.LMouthMood * 0.5f);
            Vector3 _2727 = this.LeftMouth.localEulerAngles;
            _2727.y = _2726;
            this.LeftMouth.localEulerAngles = _2727;
        }*/
        if (this.PiriRB.velocity.magnitude > 8)
        {
            if (this.JawMood < 14)
            {
                this.JawMood = this.JawMood + 2;
            }
        }
        else
        {
            if (this.JawMood > 0)
            {
                this.JawMood = this.JawMood - 2;
            }
        }
        if (this.Mood == 0)
        {
            if (this.LBrowMood < 150)
            {
                if ((this.REyeTF.localEulerAngles.y < 170) && (this.REyeTF.localEulerAngles.y > 0))
                {
                    this.LBrowMood = this.LBrowMood + 8;
                }
            }
            if (this.RBrowMood < 150)
            {
                if ((this.LEyeTF.localEulerAngles.y > 190) && (this.LEyeTF.localEulerAngles.y < 360))
                {
                    this.RBrowMood = this.RBrowMood + 8;
                }
            }
            if (this.EyeLookTarget != this.EyeRandAim2)
            {
                if (this.RMouthMood > -14)
                {
                    this.RMouthMood = this.RMouthMood - 1;
                }
            }
            if (this.EyeLookTarget != this.EyeRandAim1)
            {
                if (this.LMouthMood > -14)
                {
                    this.LMouthMood = this.LMouthMood - 1;
                }
            }
        }
        if (this.Mood == 2)
        {
            if (this.RMouthMood < 40)
            {
                if ((this.REyeTF.localEulerAngles.y < 170) && (this.REyeTF.localEulerAngles.y > 0))
                {
                    this.RMouthMood = this.RMouthMood + 1;
                }
            }
            if (this.LBrowMood > -100)
            {
                this.LBrowMood = this.LBrowMood - 8;
            }
            if (this.LMouthMood < 40)
            {
                if ((this.LEyeTF.localEulerAngles.y > 190) && (this.LEyeTF.localEulerAngles.y < 360))
                {
                    this.LMouthMood = this.LMouthMood + 1;
                }
            }
            if (this.RBrowMood > -100)
            {
                this.RBrowMood = this.RBrowMood - 8;
            }
        }
        else
        {
            if (this.RBrowMood > 0)
            {
                this.RBrowMood = this.RBrowMood - 2;
            }
            if (this.LBrowMood > 0)
            {
                this.LBrowMood = this.LBrowMood - 2;
            }
            if (this.RBrowMood < 0)
            {
                this.RBrowMood = this.RBrowMood + 2;
            }
            if (this.LBrowMood < 0)
            {
                this.LBrowMood = this.LBrowMood + 2;
            }
        }
        if (this.Mood == 1)
        {
            if (this.RMouthMood > 0)
            {
                this.RMouthMood = this.RMouthMood - 2;
            }
            if (this.RMouthMood < 0)
            {
                this.RMouthMood = this.RMouthMood + 2;
            }
            if (this.LMouthMood > 0)
            {
                this.LMouthMood = this.LMouthMood - 2;
            }
            if (this.LMouthMood < 0)
            {
                this.LMouthMood = this.LMouthMood + 2;
            }
        }
        if (this.RMouthMood > 40)
        {
            this.RMouthMood = 40;
        }
        if (this.LMouthMood > 40)
        {
            this.LMouthMood = 40;
        }
        if (this.RMouthMood < -14)
        {
            this.RMouthMood = -14;
        }
        if (this.LMouthMood < -14)
        {
            this.LMouthMood = -14;
        }
    }

    public virtual void Notice()
    {
        if ((PlayerInformation.instance.Pirizuka.gameObject.activeSelf == true) && !WorldInformation.FPMode)
        {
            this.StartCoroutine(this.Notice2());
        }
    }

    public virtual IEnumerator Notice2()
    {
        this.Looking = false;
        int Interval = Random.Range(0, 2);
        switch (Interval)
        {
            case 1:
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
        if (this.LookPoints > 0)
        {
            this.LookPoints = this.LookPoints - 1;
        }
        if (this.LookTarget)
        {
            if (this.LookTarget.name.Contains("TC"))
            {
                if (this.LookPoints < 1)
                {
                    this.LookTarget = this.ResetTarget;
                    this.EyeLookTarget = this.EyeResetTarget;
                }
            }
        }
        if (this.EyeLookTarget)
        {
            Vector3 relativePoint = this.transform.InverseTransformPoint(this.EyeLookTarget.position);
            if (relativePoint.z > 0)
            {
                this.LookTarget = this.ResetTarget;
                this.EyeLookTarget = this.EyeResetTarget;
            }
        }
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
        int Interval3 = Random.Range(0, 32);
        switch (Interval3)
        {
            case 1:
                this.Mood = 0;
                break;
            case 2:
                this.Mood = 1;
                break;
            case 3:
                this.Mood = 1;
                break;
            case 4:
                this.Mood = 2;
                break;
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Collider>().name.Contains(this.IgnoreSelf))
        {
            return;
        }
        this.LookTime = this.LookTime + Random.Range(0, 4);
        if (this.RBrowMood > 200)
        {
            this.RBrowMood = 200;
        }
        if (this.RBrowMood < -200)
        {
            this.RBrowMood = -200;
        }
        if (this.LBrowMood > 200)
        {
            this.LBrowMood = 200;
        }
        if (this.LBrowMood < -200)
        {
            this.LBrowMood = -200;
        }
        if (other.GetComponent<Collider>().name.Contains("TC"))
        {
            if (this.LookTime > 720)
            {
                this.LookTarget = other.transform;
                this.EyeLookTarget = other.transform;
                this.LookTime = 0;
                this.Mood = 1;
            }
            if (this.EyeLookTarget == other.transform)
            {
                if (this.LookPoints < 2)
                {
                    this.LookPoints = this.LookPoints + 1;
                }
            }
            if (this.LBrowMood < 150)
            {
                if ((this.REyeTF.localEulerAngles.y < 170) && (this.REyeTF.localEulerAngles.y > 0))
                {
                    this.LBrowMood = this.LBrowMood + 8;
                }
            }
            if (this.RBrowMood < 150)
            {
                if ((this.LEyeTF.localEulerAngles.y > 190) && (this.LEyeTF.localEulerAngles.y < 360))
                {
                    this.RBrowMood = this.RBrowMood + 8;
                }
            }
        }
        if (other.GetComponent<Collider>().name.Contains("TFC"))
        {
            this.RBrowMood = this.RBrowMood - 8;
            this.LBrowMood = this.LBrowMood - 8;
        }
    }

    public PiriHeadController()
    {
        this.LookForce = 0.1f;
        this.EyeLookForce = 0.1f;
        this.RBrowMood = 100;
        this.LBrowMood = 100;
        this.RMouthMood = 10;
        this.LMouthMood = 10;
        this.JawMood = 10;
        this.Mood = 1;
    }

}