using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PiriBunnyAI : MonoBehaviour
{
    public Transform AIAnchor;
    public Transform topAnchor;
    public Rigidbody topRB;
    public bool isBeingHeld;
    public Transform target;
    public Transform vTransform;
    public Transform thisTransform;
    public Rigidbody thisRigidbody;
    public Transform neckTransform;
    public Rigidbody neckRigidbody;
    public SphereCollider trig;
    public Transform thisTrigTF;
    public AudioSource SFX;
    public AudioClip BepSFX1;
    public AudioClip BepSFX2;
    public AudioClip BepSFX3;
    public AudioClip BepSFX4;
    public AudioClip BaapSFX1;
    public AudioClip BaapSFX2;
    public AudioClip BaapSFX3;
    public AudioClip BaapSFX4;
    public HingeJoint skullHJoint;
    public HingeJoint jawHJoint;
    public HingeJoint RArmHJoint;
    public HingeJoint LArmHJoint;
    public HingeJoint RLegHJoint;
    public HingeJoint LLegHJoint;
    public CapsuleCollider RLegCol;
    public CapsuleCollider LLegCol;
    public PhysicMaterial physMat1;
    public PhysicMaterial physMat2;
    public bool Moving;
    public bool Running;
    public bool Interacting;
    public int mouthMood;
    public float moveClock;
    public float moveSpeed;
    public float stabForce;
    public float lookForce;
    public AnimationCurve FLCurve;
    public AnimationCurve RLCurve;
    public Vector3 Normrot;
    public LayerMask targetLayers;
    public float notiClock;
    public virtual void Start()
    {
        if (this.isBeingHeld)
        {
            this.topAnchor = this.vTransform.parent.transform;
            this.topRB = PlayerInformation.instance.PirizukaRB;
            this.vTransform.parent = null;
        }
        this.thisTransform.parent = null;
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        if (!this.AIAnchor)
        {
            UnityEngine.Object.Destroy(this.thisTransform.gameObject);
            return;
        }
        if (this.isBeingHeld)
        {
            this.vTransform.rotation = this.topAnchor.rotation;
            this.vTransform.position = this.topAnchor.position;
            this.thisRigidbody.angularVelocity = this.topRB.angularVelocity;
            this.thisRigidbody.velocity = this.topRB.velocity;
            if (WorldInformation.UsingClosedVessel)
            {
                this.vTransform.parent = PlayerInformation.instance.Pirizuka;
                this.Interacting = false;
            }
            else
            {
                this.vTransform.parent = null;
            }
        }
        this.thisTransform.rotation = this.AIAnchor.rotation;
        this.thisTransform.position = this.AIAnchor.position;
        if (Physics.Raycast(this.thisTransform.position, Vector3.down, out hit, 1, (int) this.targetLayers))
        {
            this.Normrot = hit.normal;
            this.thisRigidbody.AddForceAtPosition(this.Normrot * this.stabForce, this.thisTransform.up * 1);
            this.thisRigidbody.AddForceAtPosition(-this.Normrot * this.stabForce, -this.thisTransform.up * 1);
        }
        else
        {
            this.thisRigidbody.AddForceAtPosition(this.Normrot * this.stabForce, this.thisTransform.up * 1);
            this.thisRigidbody.AddForceAtPosition(-this.Normrot * this.stabForce, -this.thisTransform.up * 1);
        }
        if (this.target)
        {
            this.neckRigidbody.AddForceAtPosition((this.target.position - this.neckTransform.position).normalized * this.lookForce, this.neckTransform.up * 1);
            this.neckRigidbody.AddForceAtPosition((this.target.position - this.neckTransform.position).normalized * -this.lookForce, -this.neckTransform.up * 1);
        }
        if (this.notiClock > 60)
        {
            this.Ticker();
            this.notiClock = 0;
        }
        else
        {
            this.notiClock = this.notiClock + Random.Range(0.01f, 5.33f);
        }
        if (this.moveClock > 59)
        {
            this.moveClock = 0;
        }
        if (this.moveClock < 15)
        {
            this.RLegCol.material = this.physMat1;
            this.LLegCol.material = this.physMat1;
        }
        else
        {
            this.RLegCol.material = this.physMat2;
            this.LLegCol.material = this.physMat2;
        }
        if (this.Moving)
        {
            this.moveClock = this.moveClock + (this.moveSpeed * Random.Range(0.7f, 1.3f));

            {
                float _2622 = this.FLCurve.Evaluate(this.moveClock);
                JointSpring _2623 = this.RArmHJoint.spring;
                _2623.targetPosition = _2622;
                this.RArmHJoint.spring = _2623;
            }

            {
                float _2624 = this.FLCurve.Evaluate(this.moveClock);
                JointSpring _2625 = this.LArmHJoint.spring;
                _2625.targetPosition = _2624;
                this.LArmHJoint.spring = _2625;
            }

            {
                float _2626 = this.RLCurve.Evaluate(this.moveClock);
                JointSpring _2627 = this.RLegHJoint.spring;
                _2627.targetPosition = _2626;
                this.RLegHJoint.spring = _2627;
            }

            {
                float _2628 = this.RLCurve.Evaluate(this.moveClock);
                JointSpring _2629 = this.LLegHJoint.spring;
                _2629.targetPosition = _2628;
                this.LLegHJoint.spring = _2629;
            }
        }
        else
        {
            this.moveClock = 0;

            {
                int _2630 = 0;
                JointSpring _2631 = this.RArmHJoint.spring;
                _2631.targetPosition = _2630;
                this.RArmHJoint.spring = _2631;
            }

            {
                int _2632 = 0;
                JointSpring _2633 = this.LArmHJoint.spring;
                _2633.targetPosition = _2632;
                this.LArmHJoint.spring = _2633;
            }

            {
                int _2634 = 0;
                JointSpring _2635 = this.RLegHJoint.spring;
                _2635.targetPosition = _2634;
                this.RLegHJoint.spring = _2635;
            }

            {
                int _2636 = 0;
                JointSpring _2637 = this.LLegHJoint.spring;
                _2637.targetPosition = _2636;
                this.LLegHJoint.spring = _2637;
            }
        }
        switch (this.mouthMood)
        {
            case 0:

                {
                    int _2638 = 0;
                    JointSpring _2639 = this.skullHJoint.spring;
                    _2639.targetPosition = _2638;
                    this.skullHJoint.spring = _2639;
                }

                {
                    int _2640 = 0;
                    JointSpring _2641 = this.jawHJoint.spring;
                    _2641.targetPosition = _2640;
                    this.jawHJoint.spring = _2641;
                }
                break;
            case 1:

                {
                    int _2642 = 0;
                    JointSpring _2643 = this.skullHJoint.spring;
                    _2643.targetPosition = _2642;
                    this.skullHJoint.spring = _2643;
                }

                {
                    int _2644 = -30;
                    JointSpring _2645 = this.jawHJoint.spring;
                    _2645.targetPosition = _2644;
                    this.jawHJoint.spring = _2645;
                }
                break;
            case 2:

                {
                    int _2646 = 40;
                    JointSpring _2647 = this.skullHJoint.spring;
                    _2647.targetPosition = _2646;
                    this.skullHJoint.spring = _2647;
                }

                {
                    int _2648 = -35;
                    JointSpring _2649 = this.jawHJoint.spring;
                    _2649.targetPosition = _2648;
                    this.jawHJoint.spring = _2649;
                }
                break;
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (Physics.Linecast(this.thisTransform.position, OT.position, (int) this.targetLayers) || !this.Interacting)
        {
            return;
        }
        if (OT != this.thisTrigTF)
        {
            if (ON.Contains("TC"))
            {
                this.target = OT;
                this.trig.enabled = false;
                this.trig.radius = 0.1f;
                int randomValue = Random.Range(1, 16);
                switch (randomValue)
                {
                    case 1:
                        this.StartCoroutine(this.Bep());
                        break;
                    case 2:
                        this.StartCoroutine(this.Bep());
                        break;
                    case 3:
                        this.StartCoroutine(this.Bep());
                        break;
                    case 4:
                        this.StartCoroutine(this.Bep());
                        break;
                    case 5:
                        this.StartCoroutine(this.Baap());
                        break;
                }
            }
        }
    }

    public virtual void Ticker()
    {
        int randomValue1 = Random.Range(1, 4);
        int randomValue2 = Random.Range(1, 16);
        switch (randomValue1)
        {
            case 1:
                this.Moving = true;
                break;
            case 2:
                this.Moving = false;
                break;
        }
        switch (randomValue2)
        {
            case 1:
                if (this.Interacting)
                {
                    this.Interacting = false;
                    this.target = null;
                }
                else
                {
                    this.Interacting = true;
                }
                break;
            case 3:
                this.target = null;
                break;
        }
        this.trig.enabled = true;
        this.trig.radius = 16;
    }

    public virtual IEnumerator Bep()
    {
        this.Interacting = false;
        if (this.mouthMood > 0)
        {
            yield break;
        }
        int randomValueBep = Random.Range(1, 5);
        yield return new WaitForSeconds(0.3f);
        this.mouthMood = 1;
        switch (randomValueBep)
        {
            case 1:
                this.SFX.PlayOneShot(this.BepSFX1);
                break;
            case 2:
                this.SFX.PlayOneShot(this.BepSFX2);
                break;
            case 3:
                this.SFX.PlayOneShot(this.BepSFX3);
                break;
            case 4:
                this.SFX.PlayOneShot(this.BepSFX4);
                break;
        }
        yield return new WaitForSeconds(0.15f);
        this.mouthMood = 0;
    }

    public virtual IEnumerator Baap()
    {
        this.Interacting = false;
        if (this.mouthMood > 0)
        {
            yield break;
        }
        int randomValueBaap = Random.Range(1, 5);
        yield return new WaitForSeconds(0.2f);
        this.mouthMood = 2;
        switch (randomValueBaap)
        {
            case 1:
                this.SFX.PlayOneShot(this.BaapSFX1);
                break;
            case 2:
                this.SFX.PlayOneShot(this.BaapSFX2);
                break;
            case 3:
                this.SFX.PlayOneShot(this.BaapSFX3);
                break;
            case 4:
                this.SFX.PlayOneShot(this.BaapSFX4);
                break;
        }
        yield return new WaitForSeconds(0.5f);
        this.mouthMood = 0;
    }

    public PiriBunnyAI()
    {
        this.FLCurve = new AnimationCurve();
        this.RLCurve = new AnimationCurve();
    }

}