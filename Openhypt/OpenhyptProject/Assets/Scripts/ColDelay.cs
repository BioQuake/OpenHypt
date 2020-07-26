using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ColDelay : MonoBehaviour
{
    public float Delay;
    public virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(this.Delay);
        this.gameObject.layer = 0;
    }

    public ColDelay()
    {
        this.Delay = 0.3f;
    }

}