using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MissileTargetEngage : MonoBehaviour
{
    public float EngageDelay;
    public Vector3 targetPoint;
    private Quaternion NewRotation;
    public virtual void LateUpdate()
    {
        this.NewRotation = Quaternion.LookRotation(this.targetPoint - this.transform.position);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, this.NewRotation, Time.deltaTime * 400);
    }

    public virtual IEnumerator Start()
    {
        ConfigurableJoint bJoint = (ConfigurableJoint) this.gameObject.GetComponent(typeof(ConfigurableJoint));
        this.GetComponent<Rigidbody>().freezeRotation = true;
        yield return new WaitForSeconds(this.EngageDelay);

        {
            JointDriveMode _2400 = JointDriveMode.Position;
            JointDrive _2401 = bJoint.angularXDrive;
            _2401.mode = _2400;
            bJoint.angularXDrive = _2401;
        }

        {
            JointDriveMode _2402 = JointDriveMode.Position;
            JointDrive _2403 = bJoint.angularYZDrive;
            _2403.mode = _2402;
            bJoint.angularYZDrive = _2403;
        }
    }

    public MissileTargetEngage()
    {
        this.EngageDelay = 1;
    }

}