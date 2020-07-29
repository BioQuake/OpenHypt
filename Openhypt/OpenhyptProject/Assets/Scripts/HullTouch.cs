using UnityEngine;
using System.Collections;
using System;
using System.Reflection;

[System.Serializable]
public partial class HullTouch : MonoBehaviour
{
    public GameObject AI;
    public string AIName;
    public bool DoesSheRotate;
    public virtual void OnCollisionStay(Collision collision)
    {
        if (this.AI)
        {
            if (!this.DoesSheRotate)
            {
                if (((((collision.gameObject.tag == "Vehicle") || (collision.gameObject.tag == "Body")) || (collision.gameObject.tag == "Metal")) || (collision.gameObject.tag == "Structure")) || (collision.gameObject.tag == "MetalStructure"))
                {
                    //this.AI.GetComponent(this.AIName).OnHull = true;
                    ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "OnHull", true);
                }
            }
            else
            {
                if (((collision.gameObject.tag == "Vehicle") || (collision.gameObject.tag == "Body")) || (collision.gameObject.tag == "Metal"))
                {
                    //this.AI.GetComponent(this.AIName).OnHull = true;
                    ReflectionUtils.SetField(AI.GetComponent(AIName), AIName, "OnHull", true);
                }
            }
        }
    }

    public HullTouch()
    {
        this.AIName = "AgrianExecutorCruiserAI";
    }

}