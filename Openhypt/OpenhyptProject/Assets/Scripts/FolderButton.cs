using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class FolderButton : MonoBehaviour
{
    public GameObject FolderScreen;
    public FolderInfoDisplayer displayer;
    public bool PageUp;
    public virtual void Start()
    {
        this.displayer = FolderInfoDisplayer.instance;
    }

    public virtual void OnMouseDown()
    {
        if (!this.PageUp)
        {
            this.FolderScreen.transform.Translate(Vector3.right * -8);
            this.PageUp = true;
            this.displayer.PutUp();
            this.StartCoroutine(this.PutUpPage());
        }
        else
        {
            this.FolderScreen.transform.Translate(Vector3.right * 8);
            this.PageUp = false;
            this.displayer.PutDown();
        }
    }

    public virtual IEnumerator PutUpPage()
    {
        yield return new WaitForSeconds(0.1f);
        if (FolderInfoDisplayer.instance.pages.Count > 0)
        {
            this.displayer.Pagionaise();
        }
    }

}