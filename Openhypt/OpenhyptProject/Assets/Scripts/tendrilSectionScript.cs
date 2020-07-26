using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class tendrilSectionScript : MonoBehaviour
{
    public Transform Root;
    public tendrilSectionScript RootScript;
    public Transform thisTransform;
    public Transform target;
    public Transform tip;
    public GameObject Impact;
    public Transform mainBody;
    public bool isEnd;
    public bool maybeEnd;
    public bool Retracting;
    public float Zprod;
    public PeukopedeAI PeukAI;
    public LayerMask targetLayers;
    public virtual IEnumerator Start()
    {
        RaycastHit hit = default(RaycastHit);
        this.maybeEnd = true;
        if (this.Root)
        {
            if ((tendrilSectionScript) this.Root.GetComponent(typeof(tendrilSectionScript)))
            {
                this.RootScript = (tendrilSectionScript) this.Root.GetComponent(typeof(tendrilSectionScript));
                this.RootScript.maybeEnd = false;
            }
            this.thisTransform.localPosition = this.Root.localPosition;
        }
        if (this.isEnd)
        {
            if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.forward * 0.25f), this.thisTransform.forward, out hit, 0.5f, (int) this.targetLayers))
            {
                UnityEngine.Object.Instantiate(this.Impact, hit.point, this.thisTransform.rotation);
            }
        }
        yield return new WaitForSeconds(0.5f);
        if (this.maybeEnd)
        {
            this.isEnd = true;
        }
    }

    public virtual void Update()
    {
        if (!this.Retracting)
        {
            this.target = this.PeukAI.Target;
            if (this.target && this.Root)
            {
                Vector3 relativePoint = this.Root.InverseTransformPoint(this.tip.position);
                float FAndB = relativePoint.z;
                if (FAndB > 0.26f)
                {
                    Quaternion NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
                    this.thisTransform.rotation = Quaternion.Slerp(this.thisTransform.rotation, NewRotation, Time.deltaTime * 3);
                }
                else
                {
                    this.thisTransform.rotation = Quaternion.Slerp(this.thisTransform.rotation, this.Root.rotation, Time.deltaTime * 3);
                }
            }
            if (this.isEnd)
            {
                if (!this.mainBody)
                {
                    this.Retracting = true;
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.Root)
        {
            this.thisTransform.localPosition = this.Root.localPosition;
            if (!this.Retracting)
            {
                this.thisTransform.Translate(0, 0, 0.12f, this.Root);
            }
            else
            {
                this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.Root.rotation, Time.deltaTime * 512);
                this.Zprod = this.Zprod - 0.03f;
                this.thisTransform.Translate(0, 0, this.Zprod, this.Root);
                if (this.Zprod < 0)
                {
                    if (this.RootScript)
                    {
                        this.RootScript.Retracting = true;
                    }
                    UnityEngine.Object.Destroy(this.gameObject);
                }
            }
        }
    }

    public tendrilSectionScript()
    {
        this.Zprod = 0.12f;
    }

}