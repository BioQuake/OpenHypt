using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MineralSpawner : MonoBehaviour
{
    public static System.Collections.Generic.List<GameObject> AllMineralsInGame;
    public static int MaxMineralsInScene;
    public GameObject OnePerc;
    public GameObject FivePerc;
    public GameObject TenPerc;
    public GameObject TwentyfivePerc;
    public GameObject FiftyPerc;
    public GameObject SixtyPerc;
    public GameObject SeventyPerc;
    public GameObject EightyPerc;
    public GameObject NinetyPerc;
    public GameObject HundredPerc;
    public float minSpawnRate;
    public float maxSpawnRate;
    private float currentSpawnRate;
    private float lastTime;
    public virtual void FixedUpdate()
    {
        if ((MineralSpawner.AllMineralsInGame.Count < MineralSpawner.MaxMineralsInScene) && ((Time.time - this.lastTime) > this.currentSpawnRate))
        {
            this.UpdateSpawnRate();
            this.SelectObject();
            this.lastTime = Time.time;
        }
    }

    public virtual void SelectObject()
    {
        GameObject targetObj = null;
        if ((Random.Range(0, 100) < 1) && (this.OnePerc != null))
        {
            targetObj = this.OnePerc;
        }
        else
        {
            if ((Random.Range(0, 100) < 5) && (this.FivePerc != null))
            {
                targetObj = this.FivePerc;
            }
            else
            {
                if ((Random.Range(0, 100) < 10) && (this.TenPerc != null))
                {
                    targetObj = this.TenPerc;
                }
                else
                {
                    if ((Random.Range(0, 100) < 25) && (this.TwentyfivePerc != null))
                    {
                        targetObj = this.TwentyfivePerc;
                    }
                    else
                    {
                        if ((Random.Range(0, 100) < 50) && (this.FiftyPerc != null))
                        {
                            targetObj = this.FiftyPerc;
                        }
                        else
                        {
                            if ((Random.Range(0, 100) < 60) && (this.SixtyPerc != null))
                            {
                                targetObj = this.SixtyPerc;
                            }
                            else
                            {
                                if ((Random.Range(0, 100) < 70) && (this.SeventyPerc != null))
                                {
                                    targetObj = this.SeventyPerc;
                                }
                                else
                                {
                                    if ((Random.Range(0, 100) < 80) && (this.EightyPerc != null))
                                    {
                                        targetObj = this.EightyPerc;
                                    }
                                    else
                                    {
                                        if ((Random.Range(0, 100) < 90) && (this.NinetyPerc != null))
                                        {
                                            targetObj = this.NinetyPerc;
                                        }
                                        else
                                        {
                                            targetObj = this.HundredPerc;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (targetObj != null)
        {
            this.SpawnObject(targetObj);
        }
    }

    public virtual void SpawnObject(GameObject obj)
    {
        GameObject inst = UnityEngine.Object.Instantiate(obj, this.transform.position, this.transform.rotation);
        inst.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(420, 0, 0) * (inst.GetComponent<Rigidbody>().mass * 10));
        inst.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
    }

    public virtual void UpdateSpawnRate()
    {
        this.currentSpawnRate = Random.Range(this.minSpawnRate, this.maxSpawnRate);
    }

    static MineralSpawner()
    {
        MineralSpawner.AllMineralsInGame = new List<GameObject>();
        MineralSpawner.MaxMineralsInScene = 8;
    }

}