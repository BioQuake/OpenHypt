using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class HitMarker : MonoBehaviour
{
    public Transform host;
    public ConfigurableJoint CJ;
    public LayerMask targetLayers;
    public virtual void Start()
    {
        RaycastHit hit = default(RaycastHit);
        this.InvokeRepeating("Tick", 1, 0.73f);
        this.transform.parent = null;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 5, (int) this.targetLayers))
        {
            if (hit.collider.GetComponent<Rigidbody>())
            {
                this.CJ = this.gameObject.AddComponent<ConfigurableJoint>();
                this.CJ.connectedBody = hit.rigidbody;

                {
                    JointDriveMode _2042 = JointDriveMode.Position;
                    JointDrive _2043 = this.CJ.xDrive;
                    _2043.mode = _2042;
                    this.CJ.xDrive = _2043;
                }

                {
                    JointDriveMode _2044 = JointDriveMode.Position;
                    JointDrive _2045 = this.CJ.yDrive;
                    _2045.mode = _2044;
                    this.CJ.yDrive = _2045;
                }

                {
                    JointDriveMode _2046 = JointDriveMode.Position;
                    JointDrive _2047 = this.CJ.zDrive;
                    _2047.mode = _2046;
                    this.CJ.zDrive = _2047;
                }

                {
                    JointDriveMode _2048 = JointDriveMode.Position;
                    JointDrive _2049 = this.CJ.angularXDrive;
                    _2049.mode = _2048;
                    this.CJ.angularXDrive = _2049;
                }

                {
                    JointDriveMode _2050 = JointDriveMode.Position;
                    JointDrive _2051 = this.CJ.angularYZDrive;
                    _2051.mode = _2050;
                    this.CJ.angularYZDrive = _2051;
                }

                {
                    int _2052 = 1000;
                    JointDrive _2053 = this.CJ.xDrive;
                    _2053.positionSpring = _2052;
                    this.CJ.xDrive = _2053;
                }

                {
                    int _2054 = 1000;
                    JointDrive _2055 = this.CJ.yDrive;
                    _2055.positionSpring = _2054;
                    this.CJ.yDrive = _2055;
                }

                {
                    int _2056 = 1000;
                    JointDrive _2057 = this.CJ.zDrive;
                    _2057.positionSpring = _2056;
                    this.CJ.zDrive = _2057;
                }

                {
                    int _2058 = 1000;
                    JointDrive _2059 = this.CJ.angularXDrive;
                    _2059.positionSpring = _2058;
                    this.CJ.angularXDrive = _2059;
                }

                {
                    int _2060 = 1000;
                    JointDrive _2061 = this.CJ.angularYZDrive;
                    _2061.positionSpring = _2060;
                    this.CJ.angularYZDrive = _2061;
                }

                {
                    int _2062 = 1;
                    JointDrive _2063 = this.CJ.xDrive;
                    _2063.positionDamper = _2062;
                    this.CJ.xDrive = _2063;
                }

                {
                    int _2064 = 1;
                    JointDrive _2065 = this.CJ.yDrive;
                    _2065.positionDamper = _2064;
                    this.CJ.yDrive = _2065;
                }

                {
                    int _2066 = 1;
                    JointDrive _2067 = this.CJ.zDrive;
                    _2067.positionDamper = _2066;
                    this.CJ.zDrive = _2067;
                }

                {
                    int _2068 = 1;
                    JointDrive _2069 = this.CJ.angularXDrive;
                    _2069.positionDamper = _2068;
                    this.CJ.angularXDrive = _2069;
                }

                {
                    int _2070 = 1;
                    JointDrive _2071 = this.CJ.angularYZDrive;
                    _2071.positionDamper = _2070;
                    this.CJ.angularYZDrive = _2071;
                }
                this.CJ.targetPosition = new Vector3(0, 0, -hit.distance);
                this.transform.name = hit.transform.name;
                this.host = hit.transform;
                if (this.host.name.Contains("C3"))
                {
                    UnityEngine.Object.Destroy(this.gameObject);
                }
                else
                {
                    TerrahyptianNetwork.instance.NukeMarker = this.transform;
                }
            }
        }
    }

    public virtual void Tick()
    {
        if (this.host)
        {
            if (Vector3.Distance(this.transform.position, this.host.position) > 1024)
            {
                UnityEngine.Object.Destroy(this.gameObject);
            }
            if (this.host.name.Contains("C3"))
            {
                UnityEngine.Object.Destroy(this.gameObject);
            }
        }
        else
        {
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }

}