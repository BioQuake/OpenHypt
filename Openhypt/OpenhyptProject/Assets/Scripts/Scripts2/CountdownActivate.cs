using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CountdownActivate : MonoBehaviour
{
    public float CountdownTime;
    public GameObject Gameobject;
    public virtual void Start()
    {
        this.StartCoroutine(this.Countdown());
    }

    public virtual IEnumerator Countdown()
    {
        yield return new WaitForSeconds(this.CountdownTime);
        this.Gameobject.gameObject.SetActive(true);
    }

    public CountdownActivate()
    {
        this.CountdownTime = 1;
    }

}