using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SnyfSensor : MonoBehaviour
{
    public GameObject Snyf;
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
        yield return new WaitForSeconds(0.9f);
        this.Snyf.GetComponent<SnyfController>().Target = null;
        ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 10;
        yield return new WaitForSeconds(0.1f);
        ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 0.01f;
        this.Tick = false;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SnyferolSource")
        {
            this.Snyf.GetComponent<SnyfController>().Target = other.gameObject.transform;
        }
    }

}