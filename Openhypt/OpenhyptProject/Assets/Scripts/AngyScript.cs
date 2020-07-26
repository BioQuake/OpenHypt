using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AngyScript : MonoBehaviour
{
    public TextMesh textObject;
    public string myText;
    public static string myTextStat;
    public Transform target;
    public Transform thisTransform;
    public bool isSubPart;
    public virtual IEnumerator Start()
    {
        if (!this.isSubPart)
        {
            if (WorldInformation.angyS == null)
            {
                WorldInformation.angyS = this;
                this.textObject.text = this.myText;
                this.target = PlayerInformation.instance.PhysCam;

                {
                    float _644 = this.thisTransform.position.y + 2;
                    Vector3 _645 = this.thisTransform.position;
                    _645.y = _644;
                    this.thisTransform.position = _645;
                }
                yield return new WaitForSeconds(8);
                UnityEngine.Object.Destroy(this.gameObject);
            }
            else
            {
                UnityEngine.Object.Destroy(this.gameObject);
            }
        }
        else
        {
            this.textObject.text = this.myText;
            this.target = PlayerInformation.instance.PhysCam;
        }
    }

    public virtual void DisplayName()
    {
        this.textObject.text = this.myText;
    }

    public virtual void LateUpdate()
    {
        float camDist = Vector3.Distance(this.thisTransform.position, this.target.position);
        this.thisTransform.LookAt(this.target);
        this.thisTransform.localScale = new Vector3(camDist * 0.005f, camDist * 0.005f, camDist * 0.005f);
    }

}