using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TestScriptCrap : MonoBehaviour
{
    public Transform target;
    public GameObject WhatToSpawn;
    public float Dist;
    public Vector3 RelativeTarget;
    public float EndMultiplier;
    public float DistMultiplier;
    public float RPX;
    public float RPY;
    public float FuckingRead1;
    public float FuckingRead2;
    public virtual void Update()//}
    {
        if ((this.FuckingRead2 > 0.48f) && (this.FuckingRead2 < 0.52f))
        {
            GameObject TheThing1 = UnityEngine.Object.Instantiate(this.WhatToSpawn, this.target.position, this.target.rotation);
            TheThing1.transform.parent = this.transform;
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.target)
        {
            this.RelativeTarget = this.transform.InverseTransformPoint(this.target.position);
            this.Dist = this.RelativeTarget.z;
            float DistMod = this.Dist * this.DistMultiplier;
            float RPModX = this.RelativeTarget.x / DistMod;
            float RPModY = (this.RelativeTarget.y / this.Dist) / DistMod;
            this.RPX = RPModX;
            this.RPY = RPModY * this.EndMultiplier;
            this.FuckingRead1 = Mathf.Abs(this.RPX);
            this.FuckingRead2 = Mathf.Abs(this.RPY);
        }
    }

    public TestScriptCrap()
    {
        this.EndMultiplier = 0.5f;
        this.DistMultiplier = 0.5f;
    }

}