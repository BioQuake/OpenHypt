using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AnimationPlayButton : MonoBehaviour
{
    public GameObject AniObject;
    public GameObject ButtonObject;
    public GameObject OtherButtonObject1;
    public GameObject OtherButtonObject2;
    public GameObject OtherButtonObject3;
    public GameObject OtherButtonObject4;
    public string AniName;
    private bool entered;
    public bool SettingsButton;
    public bool MouseSensitivityButton;
    public int Sensitivity;
    public bool AudioVolumeButton;
    public float Volume;
    public bool MusicButton;
    public bool TutorialButton;
    public StartTutorialScript TutorialScript;
    public bool DamageCounterButton;
    public bool IsDisable;
    public virtual void Start()
    {
        if (this.SettingsButton)
        {
            if (this.AudioVolumeButton)
            {
                if (WorldInformation.AudioVolume == this.Volume)
                {
                    this.ButtonObject.gameObject.SetActive(true);
                    if (this.OtherButtonObject1.activeSelf == true)
                    {
                        this.OtherButtonObject1.gameObject.SetActive(false);
                    }
                    if (this.OtherButtonObject2.activeSelf == true)
                    {
                        this.OtherButtonObject2.gameObject.SetActive(false);
                    }
                    if (this.OtherButtonObject3.activeSelf == true)
                    {
                        this.OtherButtonObject3.gameObject.SetActive(false);
                    }
                    if (this.OtherButtonObject4.activeSelf == true)
                    {
                        this.OtherButtonObject4.gameObject.SetActive(false);
                    }
                }
            }
            if (this.MusicButton)
            {
                if (WorldInformation.MusicOff && this.IsDisable)
                {
                    this.ButtonObject.gameObject.SetActive(true);
                    if (this.OtherButtonObject1.activeSelf == true)
                    {
                        this.OtherButtonObject1.gameObject.SetActive(false);
                    }
                }
            }
            if (this.MouseSensitivityButton)
            {
                if (WorldInformation.Sensitivity == this.Sensitivity)
                {
                    this.ButtonObject.gameObject.SetActive(true);
                    if (this.OtherButtonObject1.activeSelf == true)
                    {
                        this.OtherButtonObject1.gameObject.SetActive(false);
                    }
                    if (this.OtherButtonObject2.activeSelf == true)
                    {
                        this.OtherButtonObject2.gameObject.SetActive(false);
                    }
                }
            }
            if (this.DamageCounterButton)
            {
                if (WorldInformation.DamageCounterOff && this.IsDisable)
                {
                    this.ButtonObject.gameObject.SetActive(true);
                    if (this.OtherButtonObject1.activeSelf == true)
                    {
                        this.OtherButtonObject1.gameObject.SetActive(false);
                    }
                }
            }
            if (this.TutorialButton)
            {
                if (WorldInformation.TutorialOff && this.IsDisable)
                {
                    this.ButtonObject.gameObject.SetActive(true);
                    if (this.OtherButtonObject1.activeSelf == true)
                    {
                        this.OtherButtonObject1.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    public virtual void Update()
    {
        if (this.entered && Input.GetMouseButtonDown(0))
        {
            if (!this.SettingsButton)
            {
                this.AniObject.GetComponent<Animation>().Play(this.AniName);
            }
            if (this.SettingsButton)
            {
                if (this.ButtonObject.activeSelf == false)
                {
                    this.ButtonObject.gameObject.SetActive(true);
                    if (this.MouseSensitivityButton)
                    {
                        CameraScript.xSpeed = this.Sensitivity;
                        CameraScript.ySpeed = this.Sensitivity;
                        PlayerPrefs.SetInt("Sensitivity", this.Sensitivity);
                        PlayerPrefs.Save();
                    }
                    if (this.AudioVolumeButton)
                    {
                        ScreenFadeScript.ProgVol = this.Volume;
                        AudioListener.volume = this.Volume;
                        PlayerPrefs.SetFloat("Volume", this.Volume);
                        PlayerPrefs.Save();
                    }
                    if (this.MusicButton)
                    {
                        if (this.IsDisable)
                        {
                            if (!WorldInformation.MusicOff)
                            {
                                WorldInformation.MusicOff = true;
                                PlayerPrefs.SetInt("Music", 0);
                                PlayerPrefs.Save();
                            }
                        }
                        else
                        {
                            if (WorldInformation.MusicOff)
                            {
                                WorldInformation.MusicOff = false;
                                PlayerPrefs.SetInt("Music", 1);
                                PlayerPrefs.Save();
                            }
                        }
                    }
                    if (this.DamageCounterButton)
                    {
                        if (this.IsDisable)
                        {
                            if (!WorldInformation.DamageCounterOff)
                            {
                                WorldInformation.DamageCounterOff = true;

                                {
                                    float _646 = DamageCounter.instance.thisTransform.localPosition.x - 2;
                                    Vector3 _647 = DamageCounter.instance.thisTransform.localPosition;
                                    _647.x = _646;
                                    DamageCounter.instance.thisTransform.localPosition = _647;
                                }
                                PlayerPrefs.SetInt("Damage", 0);
                                PlayerPrefs.Save();
                            }
                        }
                        else
                        {
                            if (WorldInformation.DamageCounterOff)
                            {
                                WorldInformation.DamageCounterOff = false;

                                {
                                    float _648 = DamageCounter.instance.thisTransform.localPosition.x + 2;
                                    Vector3 _649 = DamageCounter.instance.thisTransform.localPosition;
                                    _649.x = _648;
                                    DamageCounter.instance.thisTransform.localPosition = _649;
                                }
                                PlayerPrefs.SetInt("Damage", 1);
                                PlayerPrefs.Save();
                            }
                        }
                    }
                    if (this.TutorialButton)
                    {
                        if (this.IsDisable)
                        {
                            WorldInformation.TutorialOff = true;
                            PlayerPrefs.SetInt("Tutorial", 0);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            WorldInformation.TutorialOff = false;
                            this.TutorialScript.StartNow();
                            PlayerPrefs.SetInt("Tutorial", 1);
                            PlayerPrefs.Save();
                        }
                    }
                    if (this.OtherButtonObject1.activeSelf == true)
                    {
                        this.OtherButtonObject1.gameObject.SetActive(false);
                    }
                    if (this.OtherButtonObject2)
                    {
                        if (this.OtherButtonObject2.activeSelf == true)
                        {
                            this.OtherButtonObject2.gameObject.SetActive(false);
                        }
                    }
                    if (this.OtherButtonObject3)
                    {
                        if (this.OtherButtonObject3.activeSelf == true)
                        {
                            this.OtherButtonObject3.gameObject.SetActive(false);
                        }
                    }
                    if (this.OtherButtonObject4)
                    {
                        if (this.OtherButtonObject4.activeSelf == true)
                        {
                            this.OtherButtonObject4.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }

    public virtual void OnMouseEnter()
    {
        this.entered = true;
    }

    public virtual void OnMouseExit()
    {
        this.entered = false;
    }

    public AnimationPlayButton()
    {
        this.Sensitivity = 50;
        this.Volume = 1;
    }

}