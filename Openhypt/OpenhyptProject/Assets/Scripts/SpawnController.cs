using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SpawnController : MonoBehaviour
{
    public GameObject Npc;
    public bool Deactivated;
    public int Numberism;
    public virtual void Start()
    {
        if (this.Deactivated)
        {
            return;
        }
        int randomValue = Random.Range(1, 5);
        switch (randomValue)
        {
            case 1:
                this.Numberism = 1;
                this.StartCoroutine(this.Spawn10m());
                break;
            case 2:
                this.Numberism = 2;
                this.StartCoroutine(this.Spawn7m());
                break;
            case 3:
                this.Numberism = 3;
                this.StartCoroutine(this.Spawn5m());
                break;
            case 4:
                this.Numberism = 4;
                this.StartCoroutine(this.Spawn3m());
                break;
            case 5:
                this.Numberism = 5;
                this.Spawn();
                break;
        }
    }

    public virtual IEnumerator Spawn10m()
    {
        yield return new WaitForSeconds(600);
        this.Npc.gameObject.SetActive(true);
    }

    public virtual IEnumerator Spawn7m()
    {
        yield return new WaitForSeconds(240);
        this.Npc.gameObject.SetActive(true);
    }

    public virtual IEnumerator Spawn5m()
    {
        yield return new WaitForSeconds(300);
        this.Npc.gameObject.SetActive(true);
    }

    public virtual IEnumerator Spawn3m()
    {
        yield return new WaitForSeconds(180);
        this.Npc.gameObject.SetActive(true);
    }

    public virtual void Spawn()
    {
        this.Npc.gameObject.SetActive(true);
    }

}