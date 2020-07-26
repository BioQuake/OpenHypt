using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class NotiScript : MonoBehaviour
{
    public string SnyfAni;
    public GameObject SnyfAniObject;
    public GameObject SnyfSpawn;
    public GameObject PiriNotice;
    public GameObject Head;
    public bool Tick;
    public int Snyfs;
    public AudioClip SnfIn;
    public AudioClip SnfOut;
    public AudioClip Snys;
    public LayerMask targetLayers;
    public static Transform Notipoint;
    public static Transform thisTransform;
    public static bool PiriNotis;
    public virtual void Start()
    {
        this.InvokeRepeating("Untick", 2, 2);
        NotiScript.thisTransform = this.transform;
        NotiScript.Notipoint = PlayerInformation.instance.PiriNose;
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (CameraScript.InInterface)
        {
            return;
        }
        if (Input.GetKey("e"))
        {
            this.Head.GetComponent<Rigidbody>().AddTorque(NotiScript.thisTransform.right * -0.01f);
        }
        if (Input.GetKeyDown("e"))
        {
            this.GetComponent<AudioSource>().maxDistance = 100;
            this.GetComponent<AudioSource>().volume = 0.2f;
            if (Physics.Raycast(NotiScript.thisTransform.position + (NotiScript.thisTransform.forward * 0.1f), NotiScript.thisTransform.forward, out hit, 3, (int) this.targetLayers))
            {
                if (((HingeScript) hit.collider.gameObject.GetComponent(typeof(HingeScript))) != null)
                {
                    ((HingeScript) hit.collider.gameObject.GetComponent(typeof(HingeScript))).Move();
                }
                if (((HatchScript) hit.collider.gameObject.GetComponent(typeof(HatchScript))) != null)
                {
                    ((HatchScript) hit.collider.gameObject.GetComponent(typeof(HatchScript))).Move();
                }
            }
            this.SnyfAniObject.GetComponent<Animation>().Play(this.SnyfAni);
            this.GetComponent<AudioSource>().clip = this.SnfOut;
            this.GetComponent<AudioSource>().Play();
            this.StartCoroutine(this.Snyf());
            this.Snyfs = this.Snyfs + 1;
            if (this.Snyfs > 6)
            {
                UnityEngine.Object.Instantiate(this.SnyfSpawn, NotiScript.thisTransform.position, NotiScript.thisTransform.rotation);
                this.Snyfs = 0;
            }
        }
        if (Input.GetKeyDown("r"))
        {
            if (Physics.Raycast(NotiScript.thisTransform.position + (NotiScript.thisTransform.forward * 0.1f), NotiScript.thisTransform.forward, out hit, 3, (int) this.targetLayers))
            {
                if (((BackpackScript) hit.collider.gameObject.GetComponent(typeof(BackpackScript))) != null)
                {
                    ((BackpackScript) hit.collider.gameObject.GetComponent(typeof(BackpackScript))).GetWorn();
                }
            }
        }
        if (Input.GetKeyUp("e"))
        {
            if (!FurtherActionScript.FurtherActionE1)
            {
                this.GetComponent<AudioSource>().clip = this.SnfIn;
                this.GetComponent<AudioSource>().Play();
            }
            else
            {
                this.GetComponent<AudioSource>().maxDistance = 500;
                this.GetComponent<AudioSource>().volume = 1;
                this.GetComponent<AudioSource>().clip = this.Snys;
                this.GetComponent<AudioSource>().Play();
                NotiScript.PiriNotis = true;
                TalkScript.isTyping = true;
                UnityEngine.Object.Instantiate(this.PiriNotice, NotiScript.thisTransform.position, NotiScript.thisTransform.rotation);
            }
        }
    }

    public virtual void FixedUpdate()
    {
        NotiScript.thisTransform.position = NotiScript.Notipoint.position;
        NotiScript.thisTransform.rotation = NotiScript.Notipoint.rotation;
    }

    public virtual IEnumerator Snyf()
    {
        if (this.Tick)
        {
            yield break;
        }
        this.Tick = true;
        yield return new WaitForSeconds(2);
        this.Snyfs = 0;
        this.Tick = false;
    }

    public virtual void Untick()
    {
        this.Tick = false;
    }

}