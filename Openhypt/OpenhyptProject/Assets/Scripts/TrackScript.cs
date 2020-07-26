using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TrackScript : MonoBehaviour
{
    public Transform trackWheel1TF;
    public Rigidbody trackWheel1RB;
    public Transform trackWheel2TF;
    public Rigidbody trackWheel2RB;
    public Transform subWheel1TF;
    public Transform subWheel2TF;
    public float sWheelSpinTweak;
    public Transform[] tracks;
    public Transform trackBase;
    public int trackNumber;
    public float trackSpacing;
    public float trackOffset;
    public float tweak;
    public float TSpeed;
    public float speedMod;
    public float TLocation;
    public AnimationCurve trackPosCurve;
    public AnimationCurve trackAngCurve;
    public AnimationCurve trackRadCurve;
    public virtual void Start()
    {
        this.trackOffset = 100f / this.trackNumber;
        this.tracks = new Transform[this.trackNumber];
        this.tracks[0] = this.trackBase;
        int i = 1;
        while (i < this.trackNumber)
        {
            this.tracks[i] = UnityEngine.Object.Instantiate(this.trackBase);
            this.tracks[i].parent = this.transform;
            this.tracks[i].transform.position = this.transform.position;
            i++;
        }
    }

    public virtual void FixedUpdate()
    {
        Vector3 TAv1 = this.trackWheel1TF.InverseTransformDirection(this.trackWheel1RB.angularVelocity);
        Vector3 TAv2 = this.trackWheel2TF.InverseTransformDirection(this.trackWheel2RB.angularVelocity);
        float TAvD = TAv1.x + TAv2.x;
        this.TSpeed = TAvD * this.speedMod;
        int i = 0;
        while (i < this.tracks.Length)
        {
            this.UpdateTrackPos(i);
            i++;
        }
        this.subWheel1TF.Rotate(this.TSpeed * this.sWheelSpinTweak, 0, 0);
        this.subWheel2TF.Rotate(this.TSpeed * this.sWheelSpinTweak, 0, 0);
    }

    public virtual void UpdateTrackPos(int trackID)
    {
        this.TLocation = this.TLocation + this.TSpeed;
        float sTweak = this.TSpeed * this.tweak;
        float trackOffset2 = this.trackOffset + sTweak;
        float ThisOffset = trackOffset2 * trackID;

        {
            int _3666 = 0;
            Vector3 _3667 = this.tracks[trackID].localEulerAngles;
            _3667.y = _3666;
            this.tracks[trackID].localEulerAngles = _3667;
        }

        {
            int _3668 = 0;
            Vector3 _3669 = this.tracks[trackID].localEulerAngles;
            _3669.z = _3668;
            this.tracks[trackID].localEulerAngles = _3669;
        }

        {
            float _3670 = this.trackPosCurve.Evaluate(this.TLocation + ThisOffset);
            Vector3 _3671 = this.tracks[trackID].localPosition;
            _3671.z = _3670;
            this.tracks[trackID].localPosition = _3671;
        }

        {
            float _3672 = this.trackAngCurve.Evaluate(this.TLocation + ThisOffset);
            Vector3 _3673 = this.tracks[trackID].localEulerAngles;
            _3673.x = _3672;
            this.tracks[trackID].localEulerAngles = _3673;
        }
        if (this.TLocation > 100)
        {
            this.TLocation = this.TLocation - 100;
        }
        if (this.TLocation < 0)
        {
            this.TLocation = this.TLocation + 100;
        }
    }

    public TrackScript()
    {
        this.tweak = 0.1f;
        this.trackPosCurve = new AnimationCurve();
        this.trackAngCurve = new AnimationCurve();
        this.trackRadCurve = new AnimationCurve();
    }

}