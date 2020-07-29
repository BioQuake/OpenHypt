using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CallCeptoBarge : MonoBehaviour
{
    public AudioClip CallOk;
    public AudioClip CallBad;
    public GameObject CeptoBarge;
    public GameObject Waypoint;
    public bool CalledRecently;
    public static bool CallingCeptobarge;
    public virtual void Start()
    {
        this.CeptoBarge = GameObject.Find("CeptoBarge");
    }

    public virtual void Update()
    {
        Debug.DrawRay(this.transform.position + (this.transform.up * -10), this.transform.up * 13, Color.green);
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            return;
        }
        if (CallCeptoBarge.CallingCeptobarge)
        {
            if (Physics.Raycast(this.transform.position + (this.transform.up * -10), this.transform.up, 13))
            {
                this.GetComponent<AudioSource>().clip = this.CallBad;
                this.GetComponent<AudioSource>().Play();
            }
            else
            {
                if (this.CalledRecently == false)
                {
                    this.StopAllCoroutines();
                    this.Call();
                }
            }
            CallCeptoBarge.CallingCeptobarge = false;
        }
    }

    public virtual void Call()
    {
        this.Waypoint.transform.position = this.transform.position;
        this.GetComponent<AudioSource>().clip = this.CallOk;
        this.GetComponent<AudioSource>().Play();
        if (this.CeptoBarge)
        {
            this.CeptoBarge.GetComponent<CeptoBargeController>().DoStuff();
        }
    }

}