using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MineralDispenser : MonoBehaviour
{
    public GameObject Miner;
    public GameObject compressedMineralPrefab;
    public Transform spawnLocation;
    public MineralContainer mineralContainer;
    public string AniName;
    public GameObject AniObject;
    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5) && this.HasEnoughToDispense())
        {
            this.DispenseBlock();
        }
    }

    public virtual void DispenseBlock()
    {
        int i = 0;
        GameObject spawnedObj = UnityEngine.Object.Instantiate(this.compressedMineralPrefab, this.spawnLocation.position, this.spawnLocation.rotation);
        CompressedMinerals CM = (CompressedMinerals) spawnedObj.GetComponent(typeof(CompressedMinerals));
        i = 0;
        while (i < this.mineralContainer.myMinerals.Count)
        {
            CM.MineralData.Add(this.mineralContainer.myMinerals[i]);
            i++;
        }
        this.mineralContainer.myMinerals.Clear();
        MineralContainer.currentMineralCount = 0;
        this.AniObject.GetComponent<Animation>().Play(this.AniName);
    }

    public virtual bool HasEnoughToDispense()
    {
        int sum = 0;
        int i = 0;
        i = 0;
        while (i < this.mineralContainer.myMinerals.Count)
        {
            sum = sum + this.mineralContainer.myMinerals[i].mineralAmount;
            i++;
        }
        return sum >= ((MinerOnOff) this.Miner.GetComponent(typeof(MinerOnOff))).MinerContainerCapacity;
    }

}