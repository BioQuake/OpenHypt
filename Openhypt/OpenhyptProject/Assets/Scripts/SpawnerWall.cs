using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SpawnerWall : MonoBehaviour
{
    public GameObject prefab;
    public Transform LastSpawnPoint;
    public Transform SpawnPoint;
    public int MSTimeRep;
    public int PrivTimeRep;
    public int PushVelocity;
    public int WallLength;
    public int WallWidth;
    public bool UseSpacing;
    public int Spacing;
    public virtual void Start()
    {
        this.PrivTimeRep = this.MSTimeRep;
        GameObject gO = new GameObject("LastSpawn");
        gO.transform.position = this.transform.position;
        gO.transform.rotation = this.transform.rotation;
        this.LastSpawnPoint = gO.transform;
        GameObject gO2 = new GameObject("CurrentSpawn");
        gO2.transform.position = this.transform.position;
        gO2.transform.rotation = this.transform.rotation;
        this.SpawnPoint = gO2.transform;
        this.Spawn();
    }

    public virtual void Update()
    {
        this.MSTimeRep = this.MSTimeRep - 1;
        if (this.MSTimeRep < 1)
        {
            this.MSTimeRep = this.PrivTimeRep;
            this.Spawn();
        }
    }

    public virtual void Spawn()
    {
        if (this.UseSpacing)
        {
            this.SpawnPoint.position = (this.transform.position + (this.transform.right * Random.Range(-this.WallLength, this.WallLength))) + (this.transform.forward * Random.Range(-this.WallWidth, this.WallWidth));
            if (Vector3.Distance(this.SpawnPoint.position, this.LastSpawnPoint.position) < this.Spacing)
            {
                this.MSTimeRep = 6;
                this.SpawnPoint.position = (this.transform.position + (this.transform.right * Random.Range(-this.WallLength, this.WallLength))) + (this.transform.forward * Random.Range(-this.WallWidth, this.WallWidth));
            }
            else
            {
                GameObject Thing1 = UnityEngine.Object.Instantiate(this.prefab, this.SpawnPoint.position, this.transform.rotation);
                Thing1.GetComponent<Rigidbody>().velocity = (this.transform.forward * this.PushVelocity) * 0.45f;
                this.LastSpawnPoint.position = Thing1.transform.position;
            }
        }
        else
        {
            GameObject Thing2 = UnityEngine.Object.Instantiate(this.prefab, this.transform.position + (this.transform.right * Random.Range(-this.WallLength, this.WallLength)), this.transform.rotation);
            Thing2.GetComponent<Rigidbody>().velocity = (this.transform.forward * this.PushVelocity) * 0.45f;
        }
    }

    public SpawnerWall()
    {
        this.MSTimeRep = 600;
        this.PrivTimeRep = 600;
        this.WallLength = 2000;
        this.WallWidth = 2000;
        this.Spacing = 1000;
    }

}