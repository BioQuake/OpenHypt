using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class KillOverTime : MonoBehaviour
{
    public int Seconds;
    public bool UseRelier;
    public bool IsRemoving;
    public virtual void Start()
    {
        if (!this.UseRelier)
        {
            this.StartCoroutine(this.Destroy());
        }
    }

    public virtual void Update()
    {
        if (this.UseRelier && this.IsRemoving)
        {
            this.IsRemoving = false;
            this.StartCoroutine(this.Destroy());
        }
    }

    public virtual IEnumerator Destroy()
    {
        yield return new WaitForSeconds(this.Seconds);
        UnityEngine.Object.Destroy(this.gameObject);
    }

    public KillOverTime()
    {
        this.Seconds = 8;
    }

}