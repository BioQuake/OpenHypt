using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TalkBubbleScript : MonoBehaviour
{
    public Transform thisTransform;
    public Transform theCam;
    public Transform target;
    public Transform source;
    public static string myText;
    public float textWidth;
    public float floatHeight;
    public float camDist;
    public float cDist;
    public float waitTime;
    public int snyfsiesER;
    public bool done;
    public bool isRemoving;
    public TextMesh textObject;
    public GameObject pop;
    public Transform popPoint;
    public ParticleSystem snyfsies;
    public LayerMask targetLayers;
    public virtual IEnumerator Start()
    {
        RaycastHit hit = default(RaycastHit);
        this.cDist = 1;
        this.transform.Translate(Vector3.up * 64, Space.World);
        this.theCam = PlayerInformation.instance.PhysCam;
        this.thisTransform = this.transform;
        if (this.transform.name.Contains("1"))
        {
            WorldInformation.pSpeech = this.thisTransform;
        }
        if (Physics.Raycast(this.thisTransform.position, Vector3.down, out hit, 64, (int) this.targetLayers))
        {
            this.floatHeight = hit.distance - 64;
        }
        this.textObject.text = TalkBubbleScript.myText;
        this.textWidth = this.textObject.GetComponent<Renderer>().bounds.size.magnitude * 5;
        this.snyfsies.emissionRate = this.textObject.GetComponent<Renderer>().bounds.size.magnitude * 96;

        {
            float _3632 = this.textWidth;
            Vector3 _3633 = this.snyfsies.transform.localScale;
            _3633.x = _3632;
            this.snyfsies.transform.localScale = _3633;
        }
        this.target = PlayerInformation.instance.PhysCam;
        this.waitTime = Mathf.Clamp(this.textWidth * 0.3f, 2, 128);
        WorldInformation.PopUp = true;
        yield return new WaitForSeconds(0.2f);
        if (TalkBubbleScript.myText != null)
        {
            if (TalkBubbleScript.myText.Contains("heat"))
            {
                WorldInformation.cheatsOn = true;
            }
        }
        WorldInformation.PopUp = false;
        this.done = true;
        yield return new WaitForSeconds(this.waitTime);
        this.Removing();
    }

    public virtual void LateUpdate()
    {
        if (!this.source)
        {
            if (!this.isRemoving)
            {
                this.isRemoving = true;
                this.Removing();
                return;
            }
        }

        {
            float _3634 = this.source.position.x;
            Vector3 _3635 = this.thisTransform.position;
            _3635.x = _3634;
            this.thisTransform.position = _3635;
        }

        {
            float _3636 = this.source.position.y - this.floatHeight;
            Vector3 _3637 = this.thisTransform.position;
            _3637.y = _3636;
            this.thisTransform.position = _3637;
        }

        {
            float _3638 = this.source.position.z;
            Vector3 _3639 = this.thisTransform.position;
            _3639.z = _3638;
            this.thisTransform.position = _3639;
        }
        this.thisTransform.LookAt(this.target);
        this.camDist = Vector3.Distance(this.thisTransform.position, this.theCam.position);
        this.cDist = Mathf.Lerp(this.cDist, this.camDist, 0.5f);
        if (this.done && WorldInformation.PopUp)
        {
            this.Removing();
        }
        this.thisTransform.localScale = new Vector3(this.cDist * 0.2f, this.cDist * 0.2f, this.cDist * 0.2f);
        this.snyfsies.startSize = this.cDist * 0.2f;
    }

    public virtual void Removing()
    {
        GameObject Load = ((GameObject) Resources.Load("Prefabs/TalkBubblePop", typeof(GameObject))) as GameObject;
        GameObject TGO = UnityEngine.Object.Instantiate(Load, this.popPoint.position, this.thisTransform.rotation);
        ((ParticleSystem) TGO.GetComponent(typeof(ParticleSystem))).maxParticles = (int) (this.textWidth * 4);
        TGO.transform.localScale = new Vector3(this.camDist * 0.2f, this.camDist * 0.2f, this.camDist * 0.2f);

        {
            float _3640 = TGO.transform.localScale.x + ((this.textWidth * this.camDist) * 0.2f);
            Vector3 _3641 = TGO.transform.localScale;
            _3641.x = _3640;
            TGO.transform.localScale = _3641;
        }
        ((ParticleSystem) TGO.GetComponent(typeof(ParticleSystem))).startSize = this.camDist * 0.2f;
        if (this.transform.name.Contains("1"))
        {
            NotiScript.PiriNotis = false;
        }
        UnityEngine.Object.Destroy(this.gameObject);
    }

}