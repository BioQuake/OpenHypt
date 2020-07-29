using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ObjectInfoScript : MonoBehaviour
{
    public bool Showing;
    public bool MovingOut;
    public bool MovingIn;
    public float metrics1;
    public float metrics2;
    public TextMesh metrics1TXT;
    public TextMesh metrics2TXT;
    public TextMesh weights1TXT;
    public TextMesh healths1TXT;
    public Transform mP1TF;
    public Transform SPTF;
    public Transform MPTF;
    public Transform EPTF;
    public Vector3 metricP1;
    public Vector3 metricP2;
    public AudioSource CallSource;
    public string docStringMem;
    public AudioClip WindowUp;
    public AudioClip ShowWindow;
    public LayerMask targetLayers;
    public virtual void Start()
    {
        this.mP1TF = PlayerInformation.instance.PiriAim;
        this.metrics1 = 0.001f;
        this.metrics2 = 0.001f;
    }

    public virtual void Update()
    {
        if (this.Showing)
        {
            if (Input.GetMouseButton(1))
            {
                this.CalcPoint();
                if (Input.GetKeyDown("q"))
                {
                    this.SetPoint();
                    this.StartCoroutine(this.PlayBoop());
                }
            }
            if (Input.GetMouseButtonUp(1))
            {
                this.MovingIn = true;
                this.UnsetPoint();
            }
        }
        else
        {
            if (Input.GetMouseButton(1))
            {
                this.CalcPoint();
                if (Input.GetKeyDown("q"))
                {
                    this.SetPoint();
                    this.CallSource.clip = this.ShowWindow;
                    this.CallSource.Play();
                    this.MovingOut = true;
                }
                if (Input.GetMouseButtonUp(1))
                {
                    this.MovingIn = true;
                    this.MovingOut = false;
                    this.UnsetPoint();
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.MovingOut)
        {
            this.transform.Translate(Vector3.right * -0.2f);
            if (this.transform.localPosition.x < 1)
            {
                this.MovingOut = false;
                this.Showing = true;

                {
                    int _2504 = 0;
                    Vector3 _2505 = this.transform.localPosition;
                    _2505.x = _2504;
                    this.transform.localPosition = _2505;
                }
            }
        }
        if (this.MovingIn)
        {
            this.transform.Translate(Vector3.right * 0.2f);
            if (this.transform.localPosition.x > 20)
            {
                this.MovingIn = false;
                this.Showing = false;

                {
                    int _2506 = 20;
                    Vector3 _2507 = this.transform.localPosition;
                    _2507.x = _2506;
                    this.transform.localPosition = _2507;
                }
            }
        }
    }

    public virtual void SetPoint()
    {
        RaycastHit shit = default(RaycastHit);
        string docString1 = null;
        string docString2 = null;
        string docString3 = null;
        string docStringFinal = null;
        docString1 = "n/a";
        docString2 = "n/a";
        docString3 = "n/a";
        if (Physics.Raycast(this.mP1TF.position, this.mP1TF.forward, out shit, 32768, (int) this.targetLayers))
        {
            GameObject hit_obj = shit.collider.gameObject;
            string vehicle_name = "";
            if (ObjectNameDisplayer.instance != null)
            {
                if (((ObjectInfo) hit_obj.GetComponent(typeof(ObjectInfo))) != null)
                {
                    docString1 = ((ObjectInfo) hit_obj.GetComponent(typeof(ObjectInfo))).ObjectNameTXT;
                    ObjectNameDisplayer.instance.UpdateName(docString1);
                    vehicle_name = ((ObjectInfo) hit_obj.GetComponent(typeof(ObjectInfo))).ObjectStringName;
                }
            }
            if (ObjectTypeDisplayer.instance != null)
            {
                if (((ObjectInfo) hit_obj.GetComponent(typeof(ObjectInfo))) != null)
                {
                    //ObjectTypeDisplayer.instance.UpdateType(hit_obj.GetComponent(ObjectInfo).ObjectTypeTXT);
                    docString2 = ((ObjectInfo) hit_obj.GetComponent(typeof(ObjectInfo))).ObjectTypeTXT;
                    ObjectTypeDisplayer.instance.UpdateType(docString2);
                }
            }
            if (ObjectInfoDisplayer.instance != null)
            {
                if (((ObjectInfo) hit_obj.GetComponent(typeof(ObjectInfo))) != null)
                {
                    //ObjectInfoDisplayer.instance.UpdateInfo(hit_obj.GetComponent(ObjectInfo).ObjectInfoTXT);
                    docString3 = ((ObjectInfo) hit_obj.GetComponent(typeof(ObjectInfo))).ObjectInfoTXT;
                    ObjectInfoDisplayer.instance.UpdateInfo(docString3);
                }
            }
            if (ObjectInfoDisplayer.instance != null)
            {
                if (((ObjectInfo) hit_obj.GetComponent(typeof(ObjectInfo))) != null)
                {
                    string stringcode = ((ObjectInfo) hit_obj.GetComponent(typeof(ObjectInfo))).ObjectStringCode;
                    VesselList vlist = VesselList.instance;
                    if (vlist.IsVehicleInspect(stringcode))
                    {
                        vlist.StringIn(new VehicleLinker(stringcode, vehicle_name));
                    }
                }
            }
            if (ObjectInfoDisplayer.instance != null)
            {
                if (((ObjectInfo) hit_obj.GetComponent(typeof(ObjectInfo))) != null)
                {
                    string PageGO = ((ObjectInfo) hit_obj.GetComponent(typeof(ObjectInfo))).Page;
                    if (PageGO.Length > 0)
                    {
                        FolderInfoDisplayer.ListContains(PageGO);
                    }
                }
            }
            if (docString1.Contains("n/a"))
            {
            }
            else
            {
                docStringFinal = (((((("Name :  " + docString1) + "\n") + "Type :  ") + docString2) + "\n") + "Info :  ") + docString3;
                if (this.docStringMem != docStringFinal)
                {
                    this.docStringMem = docStringFinal;
                    this.StartCoroutine(this.WriteDocumentation(docStringFinal));
                }
            }
            if (hit_obj.GetComponent<Rigidbody>() != null)
            {
                //var MassConv = Mathf.Ceil(hit_obj.rigidbody.mass * 1000);
                //weights1TXT.text = MassConv.ToString() + " Kg";
                if (((VehicleDamage) hit_obj.GetComponent(typeof(VehicleDamage))) != null)
                {
                    this.healths1TXT.text = ((VehicleDamage) hit_obj.GetComponent(typeof(VehicleDamage))).Health.ToString("F1");
                    if (((VehicleDamage) hit_obj.GetComponent(typeof(VehicleDamage))).Health < 0)
                    {
                        this.healths1TXT.text = "Non-serviceable";
                    }
                }
                else
                {
                    this.healths1TXT.text = "Not Available";
                }
                this.CalculateWeight(hit_obj.gameObject);
            }
            else
            {
                this.weights1TXT.text = "Not Available";
                this.healths1TXT.text = "Not Available";
                if (hit_obj.transform.parent.GetComponent<Rigidbody>())
                {
                    this.CalculateWeight(hit_obj.transform.parent.gameObject);
                    if (((VehicleDamage) hit_obj.transform.parent.gameObject.GetComponent(typeof(VehicleDamage))) != null)
                    {
                        this.healths1TXT.text = ((VehicleDamage) hit_obj.transform.parent.gameObject.GetComponent(typeof(VehicleDamage))).Health.ToString("F1");
                        if (((VehicleDamage) hit_obj.transform.parent.gameObject.GetComponent(typeof(VehicleDamage))).Health < 0)
                        {
                            this.healths1TXT.text = "Non-serviceable";
                        }
                    }
                }
            }
            //Debug.Log(hit_obj.transform.parent.gameObject.name);
            this.metricP1 = shit.point;
            this.SPTF.position = shit.point;
            this.MPTF.position = shit.point;
            this.MPTF.LookAt(this.EPTF);

            {
                float _2508 = 0.001f;
                Vector3 _2509 = this.MPTF.localScale;
                _2509.z = _2508;
                this.MPTF.localScale = _2509;
            }
            this.SPTF.GetComponent<Renderer>().enabled = true;
            this.MPTF.GetComponent<Renderer>().enabled = true;
            this.EPTF.GetComponent<Renderer>().enabled = true;
        }
    }

    public virtual IEnumerator WriteDocumentation(string dSF)
    {
        string tempParser = null;
        tempParser = (WorldInformation.DocumentationsStat + "\n_______________________________\n \n") + dSF;
        yield return new WaitForSeconds(0.1f);
        WorldInformation.DocumentationsStat = tempParser;
        WorldInformation.instance.objectsScanned = true;
    }

    public virtual void CalculateWeight(GameObject obj)
    {
        // Find the highest rigidbody above (sort of)
        GameObject top = null;
        top = obj;
        if (top.transform.parent)
        {
            if (top.transform.parent.gameObject.GetComponent<Rigidbody>())
            {
                top = top.transform.parent.gameObject;
            }
        }
        if (top.transform.parent)
        {
            if (top.transform.parent.gameObject.GetComponent<Rigidbody>())
            {
                top = top.transform.parent.gameObject;
            }
        }
        if (top.transform.parent)
        {
            if (top.transform.parent.gameObject.GetComponent<Rigidbody>())
            {
                top = top.transform.parent.gameObject;
            }
        }
        //sum the masses of all the children of the top object we found
        float totalWeight = 0;
        Component[] allRigidbodies = top.GetComponentsInChildren(typeof(Rigidbody));
        foreach (Rigidbody rb in allRigidbodies)
        {
            totalWeight = totalWeight + rb.mass;
        }
        float MassConv = totalWeight * 1000;
        if (MassConv >= 1)
        {
            this.weights1TXT.text = MassConv.ToString("F0") + " Kg";
        }
        else
        {
            this.weights1TXT.text = "Less than 1 Kg";
        }
    }

    public virtual void CalcPoint()
    {
        RaycastHit chit = default(RaycastHit);
        this.metrics1 = Vector3.Distance(this.metricP1, this.metricP2);
        this.metrics2 = this.metrics1 * 0.666f;
        this.metrics1TXT.text = this.metrics1.ToString("F0") + " Zets";
        this.metrics2TXT.text = this.metrics2.ToString("F2") + " Metres";
        if (Physics.Raycast(this.mP1TF.position, this.mP1TF.forward, out chit, 32768, (int) this.targetLayers))
        {
            this.metricP2 = chit.point;
            this.EPTF.position = chit.point;
            this.MPTF.LookAt(this.EPTF);

            {
                float _2510 = this.metrics2;
                Vector3 _2511 = this.MPTF.localScale;
                _2511.z = _2510;
                this.MPTF.localScale = _2511;
            }
        }
    }

    public virtual void UnsetPoint()
    {
        this.SPTF.GetComponent<Renderer>().enabled = false;
        this.MPTF.GetComponent<Renderer>().enabled = false;
        this.EPTF.GetComponent<Renderer>().enabled = false;
        ObjectNameDisplayer.instance.UpdateName("Not Available");
        ObjectTypeDisplayer.instance.UpdateType("Not Available");
        ObjectInfoDisplayer.instance.UpdateInfo("Not Available");
    }

    public virtual IEnumerator PlayBoop()
    {
        this.CallSource.volume = 0.25f;
        yield return new WaitForSeconds(0.002f);
        this.CallSource.volume = 0.2f;
        yield return new WaitForSeconds(0.002f);
        this.CallSource.volume = 0.15f;
        yield return new WaitForSeconds(0.002f);
        this.CallSource.volume = 0.1f;
        yield return new WaitForSeconds(0.002f);
        this.CallSource.volume = 0.05f;
        yield return new WaitForSeconds(0.002f);
        this.CallSource.volume = 0;
        this.CallSource.clip = this.WindowUp;
        this.CallSource.Play();
        this.CallSource.volume = 0.3f;
    }

}