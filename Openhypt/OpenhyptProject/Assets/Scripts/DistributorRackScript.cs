using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DistributorRackScript : MonoBehaviour
{
    public int SpawnCountdown;
    public float SpawnSequenceTime;
    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Spawner3;
    public GameObject Spawner4;
    public GameObject Spawner5;
    public GameObject Spawner6;
    public GameObject Spawner7;
    public GameObject Spawner8;
    public GameObject Spawner9;
    public GameObject Spawner10;
    public GameObject Spawner11;
    public GameObject Spawner12;
    public GameObject SpawnGO;
    public MeshCollider Col;
    public virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(this.SpawnCountdown);
        this.Col.material = null;
        UnityEngine.Object.Instantiate(this.SpawnGO, this.Spawner1.transform.position, this.Spawner1.transform.rotation);
        this.Spawner1.SetActive(false);
        yield return new WaitForSeconds(this.SpawnSequenceTime);
        UnityEngine.Object.Instantiate(this.SpawnGO, this.Spawner2.transform.position, this.Spawner2.transform.rotation);
        this.Spawner2.SetActive(false);
        yield return new WaitForSeconds(this.SpawnSequenceTime);
        UnityEngine.Object.Instantiate(this.SpawnGO, this.Spawner3.transform.position, this.Spawner3.transform.rotation);
        this.Spawner3.SetActive(false);
        yield return new WaitForSeconds(this.SpawnSequenceTime);
        UnityEngine.Object.Instantiate(this.SpawnGO, this.Spawner4.transform.position, this.Spawner4.transform.rotation);
        this.Spawner4.SetActive(false);
        yield return new WaitForSeconds(this.SpawnSequenceTime);
        UnityEngine.Object.Instantiate(this.SpawnGO, this.Spawner5.transform.position, this.Spawner5.transform.rotation);
        this.Spawner5.SetActive(false);
        yield return new WaitForSeconds(this.SpawnSequenceTime);
        UnityEngine.Object.Instantiate(this.SpawnGO, this.Spawner6.transform.position, this.Spawner6.transform.rotation);
        this.Spawner6.SetActive(false);
        yield return new WaitForSeconds(this.SpawnSequenceTime);
        UnityEngine.Object.Instantiate(this.SpawnGO, this.Spawner7.transform.position, this.Spawner7.transform.rotation);
        this.Spawner7.SetActive(false);
        yield return new WaitForSeconds(this.SpawnSequenceTime);
        UnityEngine.Object.Instantiate(this.SpawnGO, this.Spawner8.transform.position, this.Spawner8.transform.rotation);
        this.Spawner8.SetActive(false);
        yield return new WaitForSeconds(this.SpawnSequenceTime);
        UnityEngine.Object.Instantiate(this.SpawnGO, this.Spawner9.transform.position, this.Spawner9.transform.rotation);
        this.Spawner9.SetActive(false);
        yield return new WaitForSeconds(this.SpawnSequenceTime);
        UnityEngine.Object.Instantiate(this.SpawnGO, this.Spawner10.transform.position, this.Spawner10.transform.rotation);
        this.Spawner10.SetActive(false);
        yield return new WaitForSeconds(this.SpawnSequenceTime);
        UnityEngine.Object.Instantiate(this.SpawnGO, this.Spawner11.transform.position, this.Spawner11.transform.rotation);
        this.Spawner11.SetActive(false);
        yield return new WaitForSeconds(this.SpawnSequenceTime);
        UnityEngine.Object.Instantiate(this.SpawnGO, this.Spawner12.transform.position, this.Spawner12.transform.rotation);
        this.Spawner12.SetActive(false);
    }

    public virtual void FixedUpdate()
    {
    }

    public DistributorRackScript()
    {
        this.SpawnCountdown = 2;
        this.SpawnSequenceTime = 0.2f;
    }

}