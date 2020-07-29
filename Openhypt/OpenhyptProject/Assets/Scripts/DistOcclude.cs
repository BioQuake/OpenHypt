using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DistOcclude : MonoBehaviour
{
    public Transform target;
    public GameObject Obj1;
    public GameObject Obj2;
    public GameObject Obj3;
    public GameObject Obj4;
    public GameObject Obj5;
    public GameObject Obj6;
    public GameObject Obj7;
    public GameObject Obj8;
    public GameObject Obj9;
    public GameObject Obj10;
    public GameObject Obj11;
    public GameObject Obj12;
    public GameObject Obj13;
    public GameObject Obj14;
    public GameObject Obj15;
    public GameObject LPObj1;
    public int Dist;
    public virtual void Start()
    {
        this.InvokeRepeating("Counter", 0, 0.4f);
        this.target = PlayerInformation.instance.Pirizuka;
    }

    public virtual void Counter()
    {
        if (Vector3.Distance(this.transform.position, this.target.position) < this.Dist)
        {
            if (this.LPObj1)
            {
                if (this.LPObj1.activeSelf == true)
                {
                    this.LPObj1.gameObject.SetActive(false);
                }
            }
            if (this.Obj1)
            {
                if (this.Obj1.activeSelf == false)
                {
                    this.Obj1.gameObject.SetActive(true);
                }
            }
            if (this.Obj2)
            {
                if (this.Obj2.activeSelf == false)
                {
                    this.Obj2.gameObject.SetActive(true);
                }
            }
            if (this.Obj3)
            {
                if (this.Obj3.activeSelf == false)
                {
                    this.Obj3.gameObject.SetActive(true);
                }
            }
            if (this.Obj4)
            {
                if (this.Obj4.activeSelf == false)
                {
                    this.Obj4.gameObject.SetActive(true);
                }
            }
            if (this.Obj5)
            {
                if (this.Obj5.activeSelf == false)
                {
                    this.Obj5.gameObject.SetActive(true);
                }
            }
            if (this.Obj6)
            {
                if (this.Obj6.activeSelf == false)
                {
                    this.Obj6.gameObject.SetActive(true);
                }
            }
            if (this.Obj7)
            {
                if (this.Obj7.activeSelf == false)
                {
                    this.Obj7.gameObject.SetActive(true);
                }
            }
            if (this.Obj8)
            {
                if (this.Obj8.activeSelf == false)
                {
                    this.Obj8.gameObject.SetActive(true);
                }
            }
            if (this.Obj9)
            {
                if (this.Obj9.activeSelf == false)
                {
                    this.Obj9.gameObject.SetActive(true);
                }
            }
            if (this.Obj10)
            {
                if (this.Obj10.activeSelf == false)
                {
                    this.Obj10.gameObject.SetActive(true);
                }
            }
            if (this.Obj11)
            {
                if (this.Obj11.activeSelf == false)
                {
                    this.Obj11.gameObject.SetActive(true);
                }
            }
            if (this.Obj12)
            {
                if (this.Obj12.activeSelf == false)
                {
                    this.Obj12.gameObject.SetActive(true);
                }
            }
            if (this.Obj13)
            {
                if (this.Obj13.activeSelf == false)
                {
                    this.Obj13.gameObject.SetActive(true);
                }
            }
            if (this.Obj14)
            {
                if (this.Obj14.activeSelf == false)
                {
                    this.Obj14.gameObject.SetActive(true);
                }
            }
            if (this.Obj15)
            {
                if (this.Obj15.activeSelf == false)
                {
                    this.Obj15.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            if (this.LPObj1)
            {
                if (this.LPObj1.activeSelf == false)
                {
                    this.LPObj1.gameObject.SetActive(true);
                }
            }
            if (this.Obj1)
            {
                if (this.Obj1.activeSelf == true)
                {
                    this.Obj1.gameObject.SetActive(false);
                }
            }
            if (this.Obj2)
            {
                if (this.Obj2.activeSelf == true)
                {
                    this.Obj2.gameObject.SetActive(false);
                }
            }
            if (this.Obj3)
            {
                if (this.Obj3.activeSelf == true)
                {
                    this.Obj3.gameObject.SetActive(false);
                }
            }
            if (this.Obj4)
            {
                if (this.Obj4.activeSelf == true)
                {
                    this.Obj4.gameObject.SetActive(false);
                }
            }
            if (this.Obj5)
            {
                if (this.Obj5.activeSelf == true)
                {
                    this.Obj5.gameObject.SetActive(false);
                }
            }
            if (this.Obj6)
            {
                if (this.Obj6.activeSelf == true)
                {
                    this.Obj6.gameObject.SetActive(false);
                }
            }
            if (this.Obj7)
            {
                if (this.Obj7.activeSelf == true)
                {
                    this.Obj7.gameObject.SetActive(false);
                }
            }
            if (this.Obj8)
            {
                if (this.Obj8.activeSelf == true)
                {
                    this.Obj8.gameObject.SetActive(false);
                }
            }
            if (this.Obj9)
            {
                if (this.Obj9.activeSelf == true)
                {
                    this.Obj9.gameObject.SetActive(false);
                }
            }
            if (this.Obj10)
            {
                if (this.Obj10.activeSelf == true)
                {
                    this.Obj10.gameObject.SetActive(false);
                }
            }
            if (this.Obj11)
            {
                if (this.Obj11.activeSelf == true)
                {
                    this.Obj11.gameObject.SetActive(false);
                }
            }
            if (this.Obj12)
            {
                if (this.Obj12.activeSelf == true)
                {
                    this.Obj12.gameObject.SetActive(false);
                }
            }
            if (this.Obj13)
            {
                if (this.Obj13.activeSelf == true)
                {
                    this.Obj13.gameObject.SetActive(false);
                }
            }
            if (this.Obj14)
            {
                if (this.Obj14.activeSelf == true)
                {
                    this.Obj14.gameObject.SetActive(false);
                }
            }
            if (this.Obj15)
            {
                if (this.Obj15.activeSelf == true)
                {
                    this.Obj15.gameObject.SetActive(false);
                }
            }
        }
    }

    public DistOcclude()
    {
        this.Dist = 2000;
    }

}