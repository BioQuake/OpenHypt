using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class StartTutorialScript : MonoBehaviour
{
    public string ShowUpAnimationName;
    public string HideAnimationName;
    public string ShowTutWindowAnimationName;
    public GameObject TutorialWindow;
    public TutorialScript TutorialScript;
    private bool entered;
    private bool Once;
    public static bool DoNotShow;
    public virtual IEnumerator Start()
    {
        StartTutorialScript.DoNotShow = WorldInformation.TutorialOff;
        if (StartTutorialScript.DoNotShow)
        {
            yield break;
        }
        yield return new WaitForSeconds(5);
        this.GetComponent<Animation>().Play(this.ShowUpAnimationName + "");
        yield return new WaitForSeconds(20);
        if (this.Once)
        {
            yield break;
        }
        this.GetComponent<Animation>().Play(this.HideAnimationName + "");
    }

    public virtual void StartNow()
    {
        this.StopAllCoroutines();
        this.StartCoroutine(this.Starting());
    }

    public virtual IEnumerator Starting()
    {
        this.Once = false;
        this.TutorialScript.Once = false;
        this.TutorialScript.Page = 1;
        this.GetComponent<Animation>().Play(this.ShowUpAnimationName + "");
        yield return new WaitForSeconds(5);
        if (this.Once)
        {
            yield break;
        }
        this.GetComponent<Animation>().Play(this.HideAnimationName + "");
    }

    public virtual void Update()
    {
        if ((Input.GetMouseButtonDown(0) && (this.entered == true)) && (this.Once == false))
        {
            this.entered = false;
            this.stuff();
        }
    }

    public virtual void stuff()
    {
        this.Once = true;
        this.TutorialWindow.GetComponent<Animation>().Play(this.ShowTutWindowAnimationName + "");
        this.GetComponent<Animation>().Play(this.HideAnimationName + "");
    }

    public virtual void OnMouseEnter()
    {
        this.entered = true;
    }

    public virtual void OnMouseExit()
    {
        this.entered = false;
    }

    public StartTutorialScript()
    {
        this.ShowUpAnimationName = "Name";
        this.HideAnimationName = "Name";
        this.ShowTutWindowAnimationName = "Name";
    }

}