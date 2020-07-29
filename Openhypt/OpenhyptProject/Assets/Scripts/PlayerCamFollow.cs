using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PlayerCamFollow : MonoBehaviour
{
    public static bool HoldCam;
    public Transform PlayerCamera;
    public Transform LookTarget;
    public Transform Piri;
    public AudioListener mainListener;
    public AudioListener conListener;
    public AudioSource conScreenAudio;
    public GameObject ConIcon;
    public GameObject ConScreen;
    public bool conFar;
    public bool once;
    public float StabForce;
    public float Force;
    public float camDist;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Tick", 2, 0.25f);
        this.Force = 0.002f;
        this.Piri = PlayerInformation.instance.PiriPresence;
        if (PlayerCamFollow.HoldCam)
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
            yield return new WaitForSeconds(0.05f);
            this.transform.position = (PlayerInformation.instance.Pirizuka.position + (PlayerInformation.instance.Pirizuka.up * 3)) + (PlayerInformation.instance.Pirizuka.forward * 1.5f);
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
        else
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
            yield return new WaitForSeconds(0.05f);
            this.transform.position = PlayerInformation.instance.Pirizuka.position + (PlayerInformation.instance.Pirizuka.up * 1000);
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    public virtual void Update()
    {
        if (this.conFar && !this.once)
        {
            this.once = true;
            this.GetComponent<AudioSource>().Stop();
            this.GetComponent<AudioSource>().loop = false;
            this.StartCoroutine(this.ConnectionBroken());
        }
        this.camDist = Vector3.Distance(this.transform.position, this.Piri.position);
    }

    public virtual void FixedUpdate()
    {
        if (!WorldInformation.FPMode)
        {
            this.GetComponent<Rigidbody>().AddForce((this.PlayerCamera.transform.position - this.transform.position) * this.Force);
        }
        Quaternion rotation = Quaternion.LookRotation(this.LookTarget.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * this.StabForce);
        if (this.Force < 0.002f)
        {
            this.Force = this.Force + 5E-05f;
        }
    }

    public virtual void Tick()
    {
        if (!WorldInformation.UsingSnyf)
        {
            if (this.camDist > 512)
            {
                this.conFar = true;
            }
            else
            {
                if (this.camDist > 256)
                {
                    this.ConIcon.SetActive(true);
                    if (!this.conFar)
                    {
                        if (!this.GetComponent<AudioSource>().isPlaying)
                        {
                            this.GetComponent<AudioSource>().Play();
                        }
                    }
                    this.GetComponent<AudioSource>().loop = true;
                }
                else
                {
                    this.ConIcon.SetActive(false);
                    this.GetComponent<AudioSource>().loop = false;
                    if (this.camDist < 128)
                    {
                        this.conFar = false;
                        this.once = false;
                    }
                }
            }
        }
    }

    public virtual IEnumerator ConnectionBroken()
    {
        this.mainListener.enabled = false;
        this.conListener.enabled = true;
        this.ConScreen.SetActive(true);
        this.conScreenAudio.Play();
        yield return new WaitForSeconds(31);
        if (this.conFar)
        {
            WorldInformation.FPMode = false;
            PlayerCamFollow.HoldCam = false;
            Application.LoadLevel("PiriZerzek");
        }
        else
        {
            this.mainListener.enabled = true;
            this.conListener.enabled = false;
            this.ConScreen.SetActive(false);
        }
    }

    public virtual void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name.Contains("Wa"))
        {
            this.Force = 0.0005f;
        }
    }

    public PlayerCamFollow()
    {
        this.StabForce = 6f;
        this.Force = 0.002f;
        this.camDist = 1;
    }

}