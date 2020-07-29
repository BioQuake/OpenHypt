using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TurretWarningLight : MonoBehaviour
{
    public bool LightingUp;
    public GameObject WarningLight;
    public virtual void Update()
    {
        if ((AgrianNetwork.instance.RedAlertTime > 1) && !this.LightingUp)
        {
            this.LightingUp = true;
            this.StartCoroutine(this.LightOn());
        }
    }

    public virtual IEnumerator LightOn()
    {
        yield return new WaitForSeconds(2);
        this.WarningLight.gameObject.SetActive(true);
        yield return new WaitForSeconds(30);
        this.WarningLight.gameObject.SetActive(false);
        this.LightingUp = false;
    }

}