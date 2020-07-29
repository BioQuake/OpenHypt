using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class WingScriptDelayed : MonoBehaviour
{
    public Vector3 AxisDrag;
    public float EngageDelay;
    public bool Activated;
    public virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(this.EngageDelay);
        this.Activated = true;
    }

    public virtual void FixedUpdate()
    {
        if (this.Activated == true)
        {
            Vector3 localV = this.transform.InverseTransformDirection(this.GetComponent<Rigidbody>().velocity);
            float x = ((localV.x * this.AxisDrag.x) * -1) * Time.deltaTime;
            float y = ((localV.y * this.AxisDrag.y) * -1) * Time.deltaTime;
            float z = ((localV.z * this.AxisDrag.z) * -1) * Time.deltaTime;
            this.GetComponent<Rigidbody>().AddRelativeForce(x, y, z);
        }
    }

    public WingScriptDelayed()
    {
        this.EngageDelay = 0.3f;
    }

}