using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class NPCWheelController : MonoBehaviour
{
    public GameObject WheelObjectIntact;
    public GameObject WheelObjectBroken;
    public Transform target;
    public bool Broken;
    public virtual void Start()
    {
        this.InvokeRepeating("Counter", 0, 0.8f);
        this.target = PlayerInformation.instance.Pirizuka;
    }

    public virtual void OnJointBreak(float breakForce)
    {
        this.Broken = true;
        this.transform.parent = null;
        this.WheelObjectBroken.gameObject.SetActive(true);
        UnityEngine.Object.Destroy(this.WheelObjectIntact);
    }

    public virtual void Counter()
    {
        if ((Vector3.Distance(this.transform.position, this.target.position) > 2000) && this.Broken)
        {
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }

}