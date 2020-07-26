using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class StickyNPCSensorScript : MonoBehaviour
{
    public GameObject MainNPC;
    public bool Tick;
    public virtual void Update()
    {
        this.StartCoroutine(this.Notice());
    }

    public virtual IEnumerator Notice()
    {
        if (this.Tick)
        {
            yield break;
        }
        this.Tick = true;
        yield return new WaitForSeconds(0.5f);
        ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 50;
        yield return new WaitForSeconds(0.5f);
        ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 0.01f;
        this.Tick = false;
    }

    public virtual IEnumerator OnTriggerEnter(Collider other)
    {
        if ((((other.tag == "EnemyToAberrant") || (other.tag == "EnemyToHelirotor")) || (other.tag == "EnemyToAkbar")) || (other.tag == "ThingOfInterest"))
        {
            Vector3 lastPos = other.transform.position;
            yield return new WaitForSeconds(0.2f);
            if (Vector3.Distance(other.transform.position, lastPos) > 0.2f)
            {
                this.MainNPC.GetComponent<StickyNPC>().Ally = other.gameObject.transform;
            }
        }
    }

}