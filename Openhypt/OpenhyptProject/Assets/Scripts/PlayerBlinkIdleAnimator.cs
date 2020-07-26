using UnityEngine;
using System.Collections;

public enum hState
{
    Idle = 0,
    Idle2 = 1,
    Idle3 = 2
}

[System.Serializable]
public partial class PlayerBlinkIdleAnimator : MonoBehaviour
{
    public hState aState;
    private float lastTime;
    public virtual void FixedUpdate()
    {
        if ((Time.time - this.lastTime) < 0.5f)
        {
            return;
        }
        else
        {
            this.lastTime = Time.time;
        }
        int randomValue = Random.Range(0, 10);
        switch (randomValue)
        {
            case 1:
                this.aState = hState.Idle2;
                this.GetComponent<Animation>().Play();
                break;
            case 2:
                this.aState = hState.Idle3;
                break;
            default:
                //When randomValue is not 1 or 2
                this.aState = hState.Idle;
                break;
        }
    }

    public virtual void PlayAnimation(string ani)
    {
        if (!this.GetComponent<Animation>().IsPlaying(ani))
        {
            this.GetComponent<Animation>().Play(ani);
        }
    }

    public PlayerBlinkIdleAnimator()
    {
        this.aState = hState.Idle;
    }

}