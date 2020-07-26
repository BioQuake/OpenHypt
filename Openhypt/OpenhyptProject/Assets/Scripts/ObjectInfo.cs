using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ObjectInfo : MonoBehaviour
{
    public string ObjectNameTXT;
    public string ObjectTypeTXT;
    public string ObjectInfoTXT;
    public string ObjectStringCode;
    public string ObjectStringName;
    public string Page;
    public bool RandomPage;
    public int NumberOfPages;
    public virtual void Start()
    {
        if (this.RandomPage)
        {
            int randomValue = Random.Range(0, this.NumberOfPages);
            this.Page = this.Page + randomValue;
        }
    }

    public ObjectInfo()
    {
        this.NumberOfPages = 2;
    }

}