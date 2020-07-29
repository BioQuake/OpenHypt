using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SoundRepeaterPrefab : MonoBehaviour
{
    public GameObject Sound;
    public float Starttime;
    public float Reptime;
    public virtual void PlayStuff()
    {
        UnityEngine.Object.Instantiate(this.Sound, this.transform.position, Quaternion.Euler(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z));
    }

    public virtual void Start()
    {
        this.InvokeRepeating("PlayStuff", this.Starttime, this.Reptime);
    }

    public SoundRepeaterPrefab()
    {
        this.Starttime = 1f;
        this.Reptime = 2f;
    }

}