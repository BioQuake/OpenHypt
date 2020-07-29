using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ScreenFadeScript : MonoBehaviour
{
    public static bool FadeOut;
    public static bool FadeIn;
    public static bool BlackOut;
    public static float ProgVol;
    public virtual IEnumerator Start()
    {
        ScreenFadeScript.ProgVol = WorldInformation.AudioVolume;
        AudioListener.volume = ScreenFadeScript.ProgVol;
        ScreenFadeScript.FadeOut = false;
        ScreenFadeScript.FadeIn = true;
        yield return new WaitForSeconds(2);
        ScreenFadeScript.FadeIn = false;
    }

    public virtual void FixedUpdate()
    {
        if (ScreenFadeScript.BlackOut)
        {

            {
                int _2942 = 1;
                Color _2943 = this.GetComponent<Renderer>().material.color;
                _2943.a = _2942;
                this.GetComponent<Renderer>().material.color = _2943;
            }
        }
        else
        {
            if (!ScreenFadeScript.FadeOut)
            {
                if (this.GetComponent<Renderer>().material.color.a > 0)
                {

                    {
                        float _2944 = this.GetComponent<Renderer>().material.color.a - 0.02f;
                        Color _2945 = this.GetComponent<Renderer>().material.color;
                        _2945.a = _2944;
                        this.GetComponent<Renderer>().material.color = _2945;
                    }
                }
            }
        }
        if (ScreenFadeScript.FadeIn)
        {
            if (this.GetComponent<Renderer>().material.color.a > 0)
            {

                {
                    float _2946 = this.GetComponent<Renderer>().material.color.a - 0.02f;
                    Color _2947 = this.GetComponent<Renderer>().material.color;
                    _2947.a = _2946;
                    this.GetComponent<Renderer>().material.color = _2947;
                }
            }
            if (AudioListener.volume < ScreenFadeScript.ProgVol)
            {
                AudioListener.volume = AudioListener.volume + 0.01f;
            }
            else
            {
                AudioListener.volume = AudioListener.volume - 0.01f;
            }
        }
        if (ScreenFadeScript.FadeOut)
        {
            AudioListener.volume = AudioListener.volume - 0.008f;
            if (this.GetComponent<Renderer>().material.color.a < 1)
            {

                {
                    float _2948 = this.GetComponent<Renderer>().material.color.a + 0.01f;
                    Color _2949 = this.GetComponent<Renderer>().material.color;
                    _2949.a = _2948;
                    this.GetComponent<Renderer>().material.color = _2949;
                }
            }
        }
    }

    static ScreenFadeScript()
    {
        ScreenFadeScript.FadeIn = true;
        ScreenFadeScript.ProgVol = 1;
    }

}