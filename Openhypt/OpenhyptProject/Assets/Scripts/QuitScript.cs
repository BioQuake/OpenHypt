using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class QuitScript : MonoBehaviour
{
    public GameObject Confirmer;
    public bool CanQuit;
    public int QuitTimer;
    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.Confirmer.gameObject.SetActive(true);
            this.QuitTimer = 4;
            this.CanQuit = true;
        }
    }

    public virtual void Timer()
    {
        if (this.CanQuit)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                this.QuitTimer = this.QuitTimer + 1;
            }
            else
            {
                this.QuitTimer = this.QuitTimer - 1;
            }
            if (this.QuitTimer > 0)
            {
                if (this.QuitTimer > 6)
                {
                    this.QuitTimer = 4;
                    WorldInformation.instance.QuitZerahypt();
                }
            }
            else
            {
                this.Confirmer.gameObject.SetActive(false);
                this.CanQuit = false;
            }
        }
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Timer", 1, 1);
    }

}