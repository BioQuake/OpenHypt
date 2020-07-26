using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class HoverPointScript : MonoBehaviour
{
    public float Multiplier;
    public virtual void FixedUpdate()
    {
        if (WorldInformation.playerCar.Contains(this.transform.parent.name))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (this.transform.position.y < 550)
                {

                    {
                        float _2072 = this.transform.position.y + (1 * this.Multiplier);
                        Vector3 _2073 = this.transform.position;
                        _2073.y = _2072;
                        this.transform.position = _2073;
                    }
                }
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {

                {
                    float _2074 = this.transform.position.y - (1 * this.Multiplier);
                    Vector3 _2075 = this.transform.position;
                    _2075.y = _2074;
                    this.transform.position = _2075;
                }
            }
        }
    }

    public HoverPointScript()
    {
        this.Multiplier = 1;
    }

}