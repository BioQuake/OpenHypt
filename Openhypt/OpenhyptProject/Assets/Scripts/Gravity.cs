using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using Boo.Lang;

[System.Serializable]
public partial class Gravity : MonoBehaviour
{
    public float range;
    public float power;
    public float Tickspeed;
    public virtual void Tick()
    {
        Collider[] collideArray = Physics.OverlapSphere(this.transform.position, this.range);
        //object[] rbs = new object[0]; //Get all objects inside the sphere within range's units.
        List<Rigidbody> rbs = new List<Rigidbody>();
        int counter = 0;
        while (counter < collideArray.Length)
        {
            if (collideArray[counter].attachedRigidbody && (collideArray[counter].attachedRigidbody != this.GetComponent<Rigidbody>()))
            {
                bool breaking = false;
                int r = 0;
                while (r < rbs.Count)
                {
                    if (collideArray[counter].attachedRigidbody == rbs[r])
                    {
                        breaking = true;
                        break;
                    }
                    r++;
                }
                if (breaking)
                {
                    goto Label_for_7;
                }
                rbs.Add(collideArray[counter].attachedRigidbody);
                Vector3 offset = this.transform.position - collideArray[counter].transform.position;
                if (Vector3.Distance(collideArray[counter].transform.position, this.transform.position) > 1f)
                {
                    collideArray[counter].attachedRigidbody.AddForce((offset / offset.sqrMagnitude) * this.power, ForceMode.Acceleration);
                }
            }
            Label_for_7:
            counter++;
        }
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 1, this.Tickspeed);
    }

    public Gravity()
    {
        this.range = 30f;
        this.power = 10f;
        this.Tickspeed = 0.2f;
    }

}