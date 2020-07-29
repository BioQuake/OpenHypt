using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TimedExplosion : MonoBehaviour
{
    public GameObject explosion; // drag your explosion prefab here
    public virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        GameObject expl = UnityEngine.Object.Instantiate(this.explosion, this.transform.position, this.transform.rotation);
        UnityEngine.Object.Destroy(this.gameObject);
    }

}