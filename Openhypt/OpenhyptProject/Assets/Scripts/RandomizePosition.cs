using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RandomizePosition : MonoBehaviour
{
    public float Radius;
    public float TimeTick;
    public bool UseZ;
    public virtual void Tick()
    {
        Vector3 newPosition = Random.insideUnitSphere * this.Radius;

        {
            float _2918 = newPosition.x;
            Vector3 _2919 = this.transform.localPosition;
            _2919.x = _2918;
            this.transform.localPosition = _2919;
        }

        {
            float _2920 = newPosition.y;
            Vector3 _2921 = this.transform.localPosition;
            _2921.y = _2920;
            this.transform.localPosition = _2921;
        }
        if (this.UseZ)
        {

            {
                float _2922 = newPosition.z;
                Vector3 _2923 = this.transform.localPosition;
                _2923.z = _2922;
                this.transform.localPosition = _2923;
            }
        }
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 3, this.TimeTick);
    }

    public RandomizePosition()
    {
        this.Radius = 5;
        this.TimeTick = 2;
    }

}