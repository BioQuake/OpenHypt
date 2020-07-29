using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BackpackScript : MonoBehaviour
{
    public Transform thisTF;
    public Transform conTF;
    public Transform lidTF;
    public bool lidOpening;
    public bool lidClosing;
    public int lNum;
    public AnimationCurve lCurve;
    public Rigidbody thisRB;
    public MeshCollider thisCol;
    public bool holdingR;
    public bool holdingE;
    public int eTimer;
    public virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        WorldInformation.backpackIsPresent = true;
        this.StartCoroutine(this.replaceName());
    }

    public virtual IEnumerator replaceName()
    {
        string newName = null;
        yield return new WaitForSeconds(0.2f);
        newName = this.thisTF.name.Replace("(Clone)", "");
        this.thisTF.name = newName;
    }

    public virtual void Update()
    {
        if (this.holdingR)
        {
            this.eTimer = this.eTimer + 1;
            if (this.eTimer > 40)
            {
                this.GetUnworn();
                this.holdingR = false;
                this.eTimer = 0;
            }
        }
        if (this.holdingE)
        {
            this.eTimer = this.eTimer + 1;
            if (this.eTimer > 40)
            {
                if (this.conTF.localPosition.z < 2)
                {

                    {
                        int _868 = 4;
                        Vector3 _869 = this.conTF.localPosition;
                        _869.z = _868;
                        this.conTF.localPosition = _869;
                    }
                    this.lidClosing = true;
                    //lTimer = 0;
                }
                else
                {

                    {
                        int _870 = 0;
                        Vector3 _871 = this.conTF.localPosition;
                        _871.z = _870;
                        this.conTF.localPosition = _871;
                    }
                    this.lidOpening = true;
                    //lTimer = 0;
                }
                this.holdingE = false;
                this.eTimer = 0;
            }
        }
        if (Input.GetKeyDown("r"))
        {
            this.holdingR = true;
        }
        if (Input.GetKeyUp("r"))
        {
            this.holdingR = false;
            this.eTimer = 0;
        }
        if (Input.GetKeyDown("e"))
        {
            if (WorldInformation.isWearingBackpack)
            {
                this.holdingE = true;
            }
        }
        if (Input.GetKeyUp("e"))
        {
            this.holdingE = false;
            this.eTimer = 0;
        }

        {
            float _872 = this.lCurve.Evaluate(this.lNum);
            Vector3 _873 = this.lidTF.localEulerAngles;
            _873.x = _872;
            this.lidTF.localEulerAngles = _873;
        }

        {
            int _874 = 0;
            Vector3 _875 = this.lidTF.localEulerAngles;
            _875.y = _874;
            this.lidTF.localEulerAngles = _875;
        }

        {
            int _876 = 0;
            Vector3 _877 = this.lidTF.localEulerAngles;
            _877.z = _876;
            this.lidTF.localEulerAngles = _877;
        }
        if (this.lidOpening)
        {
            if (this.lNum < 16)
            {
                this.lNum = this.lNum + 1;
            }
            else
            {
                this.lNum = 16;
                this.lidOpening = false;
            }
        }
        if (this.lidClosing)
        {
            if (this.lNum > 0)
            {
                this.lNum = this.lNum - 1;
            }
            else
            {
                this.lNum = 0;
                this.lidClosing = false;
            }
        }
    }

    public virtual void GetWorn()
    {
        this.thisTF.name.Replace("(Clone)", "");
        //Debug.Log(thisTF.name + "Did Get Worn");
        this.thisRB.isKinematic = true;
        this.thisCol.enabled = false;
        this.thisTF.position = PlayerInformation.instance.BackpackPoint.position;
        this.thisTF.rotation = PlayerInformation.instance.BackpackPoint.rotation;
        this.thisTF.parent = PlayerInformation.instance.BackpackPoint;
        FurtherActionScript.instance.Backpack = true;
        FurtherActionScript.instance.ShowText();
        WorldInformation.isWearingBackpack = true;
        WorldInformation.whatBackpack = this.thisTF.name;
    }

    public virtual void GetUnworn()
    {
        this.thisRB.isKinematic = false;
        this.thisCol.enabled = true;
        this.thisTF.parent = null;
        WorldInformation.isWearingBackpack = false;
        WorldInformation.whatBackpack = "null";
    }

    public BackpackScript()
    {
        this.lCurve = new AnimationCurve();
    }

}