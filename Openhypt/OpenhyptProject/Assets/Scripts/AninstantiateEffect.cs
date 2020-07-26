using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AninstantiateEffect : MonoBehaviour
{
    public GameObject Prefab1;
    public Transform InstantiateLocation;
    public virtual void InstantiateIt()
    {
        UnityEngine.Object.Instantiate(this.Prefab1, this.InstantiateLocation.position, this.InstantiateLocation.rotation);
    }

}