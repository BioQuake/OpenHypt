using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PlayerStronglight : MonoBehaviour
{
    public static bool Activated;
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
        if ((this.GetComponent<Light>().intensity < 1) && PlayerStronglight.Activated)
        {
            this.GetComponent<Light>().intensity = this.GetComponent<Light>().intensity + 0.01f;
        }
        if ((this.GetComponent<Light>().intensity > 0) && !PlayerStronglight.Activated)
        {
            this.GetComponent<Light>().intensity = this.GetComponent<Light>().intensity - 0.01f;
        }
    }

}