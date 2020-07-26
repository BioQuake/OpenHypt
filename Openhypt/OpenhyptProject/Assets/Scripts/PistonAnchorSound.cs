using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PistonAnchorSound : MonoBehaviour
{
    public GameObject Sound;
    public virtual void Update()
    {
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            this.PlayIt();
        }
    }

    public virtual void PlayIt()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject TheThing = UnityEngine.Object.Instantiate(this.Sound, this.transform.position, Quaternion.Euler(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z));
            TheThing.transform.parent = this.gameObject.transform;
        }
    }

}