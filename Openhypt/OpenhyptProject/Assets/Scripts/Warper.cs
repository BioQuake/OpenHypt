using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Warper : MonoBehaviour
{
    public Transform warpTF;
    public GameObject warpCol;
    public GameObject endProduct;
    public int FleetNum;
    public bool isWarping;
    public float warpStartSpeed;
    public AnimationCurve warpStartCurve;
    public float warpStartNum;
    public GameObject warpStartFX;
    public float warpStartFXNum;
    public bool warpStartFXed;
    public float warpEndSpeed;
    public AnimationCurve warpEndCurve;
    public float warpEndNum;
    public GameObject warpEndFX;
    public float warpEndFXNum;
    public bool warpEndFXed;
    public float warpSpeed;
    public int warpDist;
    public virtual void Start()
    {
        this.isWarping = true;
        this.warpDist = this.warpDist - 256;
    }

    public virtual void FixedUpdate()
    {
        if (!this.isWarping)
        {
            return;
        }
        if (this.warpTF.localPosition.z < this.warpDist)
        {
            if (this.warpStartNum < 1)
            {
                this.warpStartNum = this.warpStartNum + this.warpStartSpeed;
                this.warpSpeed = this.warpStartCurve.Evaluate(this.warpStartNum);
                if (!this.warpStartFXed)
                {
                    if (this.warpStartNum > this.warpStartFXNum)
                    {
                        this.warpStartFXed = true;
                        UnityEngine.Object.Instantiate(this.warpStartFX, this.warpTF.position, this.transform.rotation);
                    }
                }
            }
        }
        else
        {
            if (this.warpEndNum < 1)
            {
                this.warpEndNum = this.warpEndNum + this.warpEndSpeed;
                this.warpSpeed = this.warpEndCurve.Evaluate(this.warpEndNum);
                if (!this.warpEndFXed)
                {
                    if (this.warpEndNum > this.warpEndFXNum)
                    {
                        this.warpStartFXed = false;
                        this.warpEndFXed = true;
                        UnityEngine.Object.Instantiate(this.warpEndFX, this.warpTF.position, this.transform.rotation);
                    }
                }
            }
            else
            {
                this.isWarping = false;
                this.StartCoroutine(this.WarpEnd());
            }
        }

        {
            float _3732 = this.warpTF.localPosition.z + this.warpSpeed;
            Vector3 _3733 = this.warpTF.localPosition;
            _3733.z = _3732;
            this.warpTF.localPosition = _3733;
        }
    }

    public virtual IEnumerator WarpEnd()
    {
        UnityEngine.Object.Destroy(this.warpCol);
        yield return new WaitForSeconds(0.1f);
        GameObject prodInst = UnityEngine.Object.Instantiate(this.endProduct, this.warpTF.position, this.warpTF.rotation);
        switch (this.FleetNum)
        {
            case 1:
                ((AgrianTowerAI) prodInst.transform.GetChild(0).GetComponent(typeof(AgrianTowerAI))).isFleetVessel1 = true;
                break;
            case 2:
                ((AgrianTowerAI) prodInst.transform.GetChild(0).GetComponent(typeof(AgrianTowerAI))).isFleetVessel2 = true;
                break;
            case 3:
                ((AgrianTowerAI) prodInst.transform.GetChild(0).GetComponent(typeof(AgrianTowerAI))).isFleetVessel3 = true;
                break;
        }
        UnityEngine.Object.Destroy(this.gameObject);
    }

    public Warper()
    {
        this.warpStartCurve = new AnimationCurve();
        this.warpEndCurve = new AnimationCurve();
    }

}