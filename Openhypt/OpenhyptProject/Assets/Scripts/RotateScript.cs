using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RotateScript : MonoBehaviour
{
    public bool RotateDown;
    public bool MoveDown;
    public LayerMask targetLayers;
    public virtual void Start()
    {
        RaycastHit hit = default(RaycastHit);
        if (!this.RotateDown)
        {
            this.transform.Rotate(0, 0, Random.Range(0, 360));
        }
        else
        {
            this.transform.rotation = Quaternion.LookRotation(Vector3.down);
        }
        if (this.MoveDown)
        {
            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 20000, (int) this.targetLayers))
            {
                this.transform.position = this.transform.position + (this.transform.forward * hit.distance);
            }
        }
    }

}