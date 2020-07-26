using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SprintGateScript : MonoBehaviour
{
    public bool IsFinish;
    public SprintGateScript OtherGateScript;
    public bool IsRunning;
    public float timer;
    public TextMesh StartTmF;
    public TextMesh StartTmB;
    public TextMesh EndTmF;
    public TextMesh EndTmB;
    public virtual void FixedUpdate()
    {
        if (!this.IsFinish)
        {
            if (this.IsRunning)
            {
                this.timer = this.timer + Time.deltaTime;
            }
            this.StartTmF.text = this.timer.ToString("F2");
            this.StartTmB.text = this.timer.ToString("F2");
            this.EndTmF.text = this.timer.ToString("F2");
            this.EndTmB.text = this.timer.ToString("F2");
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name.Contains("TC"))
        {
            if (!this.IsFinish && !this.IsRunning)
            {
                this.IsRunning = true;
            }
            if (this.IsFinish && this.OtherGateScript.IsRunning)
            {
                this.OtherGateScript.IsRunning = false;
            }
        }
    }

}