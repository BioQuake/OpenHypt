using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MineralCollector : MonoBehaviour
{
    public MineralContainer ContainerTarget;
    public GameObject MiningBeam;
    public float hitDistance;
    public virtual void Start()
    {
        if (this.ContainerTarget == null)
        {
            Debug.LogError("Assign the Container in the hierarchy for the MineralCollector on the GameObject called " + this.name, this);
        }
    }

    private float lastTime;
    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        int i = 0;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, this.hitDistance))
        {
            if (this.MiningBeam.activeInHierarchy)
            {
                if (hit.collider.gameObject.name.ToLower().Contains("mineral"))
                {
                    if ((Time.time - this.lastTime) > 1f)
                    {
                        MineralInformation MineralInfo = (MineralInformation) hit.collider.gameObject.GetComponent(typeof(MineralInformation));
                        if (MineralInfo != null)
                        {
                            int empty = 0;
                            i = 0;
                            while (i < MineralInfo.Minerals.Count)
                            {
                                if (MineralInfo.Minerals[i].mineralAmount > 0)
                                {
                                    int incrementAmount = MineralInfo.Minerals[i].mineralReceivePerSec;
                                    MineralInfo.Minerals[i].mineralAmount = Mathf.Clamp(MineralInfo.Minerals[i].mineralAmount - incrementAmount, 0, 1000000);
                                    this.ContainerTarget.InsertMineralToContainer(MineralInfo.Minerals[i].mineralType, incrementAmount);
                                }
                                else
                                {
                                    empty++;
                                }
                                i++;
                            }
                            this.lastTime = Time.time;
                            if (empty >= MineralInfo.Minerals.Count)
                            {
                                UnityEngine.Object.Instantiate(MineralInfo.CrumblePrefab, hit.collider.gameObject.transform.position, hit.collider.gameObject.transform.rotation);
                                UnityEngine.Object.Destroy(hit.collider.gameObject);
                            }
                        }
                    }
                }
                else
                {
                    if ((Time.time - this.lastTime) > 1f)
                    {
                        this.ContainerTarget.InsertMineralToContainer((eMineralType) 0, 10);
                        this.lastTime = Time.time;
                    }
                }
            }
        }
    }

    public MineralCollector()
    {
        this.hitDistance = 9999;
    }

}