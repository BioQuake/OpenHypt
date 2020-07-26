using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RotateRandomlyXYZ : MonoBehaviour
{
    public bool UseUpdate;
    public bool OnlyY;
    public virtual void Start()
    {
        if (!this.OnlyY)
        {
            this.transform.Rotate(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        }
        else
        {
            this.transform.Rotate(0, Random.Range(0, 360), 0);
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.UseUpdate)
        {
            this.transform.Rotate(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        }
    }

}