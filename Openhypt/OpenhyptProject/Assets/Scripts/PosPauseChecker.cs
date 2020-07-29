using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PosPauseChecker : MonoBehaviour
{
    public virtual void FixedUpdate()
    {
        if ((((((this.transform.localPosition.x > 4) || (this.transform.localPosition.y > 4)) || (this.transform.localPosition.z > 4)) || (-this.transform.localPosition.x > 4)) || (-this.transform.localPosition.y > 4)) || (-this.transform.localPosition.z > 4))
        {
            Time.timeScale = 0;
        }
    }

}