using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PauseScript : MonoBehaviour
{
    public bool Paused;
    public virtual void Update()
    {
        if (Input.GetKeyDown("p"))
        {

            {
                int _2602 = 3;
                Vector3 _2603 = this.transform.localScale;
                _2603.x = _2602;
                this.transform.localScale = _2603;
            }

            {
                int _2604 = 3;
                Vector3 _2605 = this.transform.localScale;
                _2605.z = _2604;
                this.transform.localScale = _2605;
            }
            this.GetComponent<AudioSource>().Play();
        }
        if (Input.GetKeyDown("u") && !this.Paused)
        {
            Time.timeScale = 0;
            Debug.Break();
            this.Paused = true;
        }
        else
        {
            if (Input.GetKeyDown("u") && this.Paused)
            {
                Time.timeScale = 1;
                this.Paused = false;
            }
        }
    }

}