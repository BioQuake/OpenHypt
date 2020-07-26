using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SoundTrigger : MonoBehaviour
{
    public GameObject Sound;
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("SoundTriggerActivator"))
        {
            GameObject TheThing = UnityEngine.Object.Instantiate(this.Sound, this.transform.position, Quaternion.Euler(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z));
            TheThing.transform.parent = this.gameObject.transform;
        }
    }

}