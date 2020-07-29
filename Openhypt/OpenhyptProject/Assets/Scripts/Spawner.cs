using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Spawner : MonoBehaviour
{
    public bool UseCountDown;
    public bool RemoveWhenDone;
    public GameObject WhatToRemove;
    public float CountDown;
    public GameObject WhatToSpawn;
    public Transform WhereToSpawn;
    public virtual IEnumerator Start()
    {
        if (this.UseCountDown)
        {
            if (this.CountDown > 0)
            {
                yield return new WaitForSeconds(this.CountDown);
                UnityEngine.Object.Instantiate(this.WhatToSpawn, this.transform.position, this.transform.rotation);
                if (this.RemoveWhenDone)
                {
                    UnityEngine.Object.Destroy(this.WhatToRemove);
                }
            }
            else
            {
                if (!this.WhereToSpawn)
                {
                    UnityEngine.Object.Instantiate(this.WhatToSpawn, this.transform.position, this.transform.rotation);
                }
                else
                {
                    UnityEngine.Object.Instantiate(this.WhatToSpawn, this.WhereToSpawn.position, this.WhereToSpawn.rotation);
                }
                if (this.RemoveWhenDone)
                {
                    UnityEngine.Object.Destroy(this.WhatToRemove);
                }
            }
        }
    }

    public virtual void Spawn()
    {
        UnityEngine.Object.Instantiate(this.WhatToSpawn, this.transform.position, this.transform.rotation);
    }

    public Spawner()
    {
        this.CountDown = 1.3f;
    }

}