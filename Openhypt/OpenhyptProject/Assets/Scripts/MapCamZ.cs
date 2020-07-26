using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MapCamZ : MonoBehaviour
{
    public static int ZoomDist;
    public virtual void Start()
    {
        MapCamZ.ZoomDist = -32;
        Screen.lockCursor = false;
        Cursor.visible = true;
    }

    public virtual void FixedUpdate()
    {

        {
            float _2330 = Mathf.Lerp(this.transform.localPosition.z, MapCamZ.ZoomDist, 0.05f * 4);
            Vector3 _2331 = this.transform.localPosition;
            _2331.z = _2330;
            this.transform.localPosition = _2331;
        }
    }

}