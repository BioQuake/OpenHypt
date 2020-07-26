using UnityEngine;
using System.Collections;

public enum npcState
{
    Idle = 0,
    WalkForward = 1,
    WalkBackward = 2,
    Sprinting = 3
}

[System.Serializable]
public partial class NPCMotionAnimator : MonoBehaviour
{
    public GameObject NPC;
    public float forwardSpeed;
    public float sprintSpeed;
    public float WalkingThreshold;
    public string Idle;
    public string forward;
    public string sprint;
    public string falling;
    public string backward;
    public GameObject targetRigidbody;
    public npcState state;
    private Vector3 relative;
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
        this.relative = this.transform.InverseTransformDirection(this.targetRigidbody.GetComponent<Rigidbody>().velocity);
        if ((this.relative.z > this.relative.x) && (this.relative.z > 0.4f))
        {
            if (this.relative.z < this.WalkingThreshold)
            {
                if (this.state != npcState.WalkForward)
                {
                    this.GetComponent<Animation>().CrossFade(this.forward);
                    this.state = npcState.WalkForward;
                }
                if (this.GetComponent<Animation>().IsPlaying(this.forward))
                {
                    this.GetComponent<Animation>()[this.forward].speed = this.relative.z * this.forwardSpeed;
                }
            }
            else
            {
                if (this.state != npcState.Sprinting)
                {
                    this.GetComponent<Animation>().CrossFade(this.sprint);
                    this.state = npcState.Sprinting;
                }
                if (this.GetComponent<Animation>().IsPlaying(this.sprint))
                {
                    this.GetComponent<Animation>()[this.sprint].speed = this.relative.z * this.sprintSpeed;
                }
            }
        }
        this.reset();
    }

    public virtual void reset()
    {
        if ((((this.relative.x >= -0.4f) && (this.relative.x < 0.4f)) && (this.relative.z >= -0.4f)) && (this.relative.z < 0.4f))
        {
            if (!this.GetComponent<Animation>().IsPlaying(this.Idle))
            {
                this.GetComponent<Animation>().CrossFade(this.Idle, 0.5f);
                this.state = npcState.Idle;
            }
        }
    }

    public NPCMotionAnimator()
    {
        this.forwardSpeed = 1f;
        this.sprintSpeed = 1f;
        this.WalkingThreshold = 2.5f;
    }

}