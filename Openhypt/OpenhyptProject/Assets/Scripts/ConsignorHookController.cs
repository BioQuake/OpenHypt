using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ConsignorHookController : MonoBehaviour
{
    public GameObject Translator;
    public GameObject Hook;
    public GameObject Lock;
    public bool Locked;
    public bool TranslatorMovingOut;
    public bool TranslatorMovingIn;
    public bool HookMovingOut;
    public bool HookMovingIn;
    public bool HookOut;
    public bool TranslatorOut;
    public float TranslatorEnd;
    public float HookEnd;
    public virtual void Update()
    {
        if (WorldInformation.playerCar == this.transform.name)
        {
            if ((this.TranslatorOut && !this.TranslatorMovingIn) && !this.TranslatorMovingOut)
            {
                if (Input.GetKeyDown("3"))
                {
                    if (this.HookOut)
                    {

                        {
                            float _1140 = this.Hook.GetComponent<HingeJoint>().spring.targetPosition + 0.2f;
                            JointSpring _1141 = this.Hook.GetComponent<HingeJoint>().spring;
                            _1141.targetPosition = _1140;
                            this.Hook.GetComponent<HingeJoint>().spring = _1141;
                        }
                        this.HookMovingOut = false;
                        this.HookMovingIn = true;
                    }
                }
                if (Input.GetKeyDown("4"))
                {
                    if (!this.HookOut)
                    {

                        {
                            float _1142 = this.Hook.GetComponent<HingeJoint>().spring.targetPosition - 0.2f;
                            JointSpring _1143 = this.Hook.GetComponent<HingeJoint>().spring;
                            _1143.targetPosition = _1142;
                            this.Hook.GetComponent<HingeJoint>().spring = _1143;
                        }
                        this.HookMovingOut = true;
                        this.HookMovingIn = false;
                    }
                }
            }
            if ((!this.HookOut && !this.HookMovingOut) && !this.HookMovingIn)
            {
                if (Input.GetKeyDown("1"))
                {
                    if (this.TranslatorOut)
                    {
                        ((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition = ((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition + new Vector3(0, 0.02f, 0);
                        this.TranslatorMovingOut = false;
                        this.TranslatorMovingIn = true;
                        this.Locked = true;
                        if (this.Lock != null)
                        {
                            this.Lock.transform.localPosition = new Vector3(0, 0, 0.715f);
                        }
                    }
                }
                if (Input.GetKeyDown("2"))
                {
                    if (!this.TranslatorOut)
                    {
                        ((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition = ((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition - new Vector3(0, 0.02f, 0);
                        this.TranslatorMovingOut = true;
                        this.TranslatorMovingIn = false;
                    }
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.Locked)
        {
            this.Hook.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        {
            float _1144 = -0.27f;
            Vector3 _1145 = this.Translator.transform.localPosition;
            _1145.z = _1144;
            this.Translator.transform.localPosition = _1145;
        }

        {
            int _1146 = 0;
            Vector3 _1147 = this.Translator.transform.localPosition;
            _1147.x = _1146;
            this.Translator.transform.localPosition = _1147;
        }
        this.Translator.transform.localRotation = Quaternion.Euler(0, 0, 0);
        this.Hook.transform.localPosition = new Vector3(0, 0, 0);
        if (this.TranslatorMovingIn || this.TranslatorMovingOut)
        {
            if (((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition.y < this.TranslatorEnd)
            {
                this.TranslatorOut = true;
                this.TranslatorMovingOut = false;
                this.Locked = false;
                if (this.Lock != null)
                {
                    this.Lock.transform.localPosition = new Vector3(0, 0, 0);
                }
            }
            if (((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition.y > 0)
            {
                this.TranslatorOut = false;
                this.TranslatorMovingIn = false;
            }
        }
        if (this.HookMovingIn || this.HookMovingOut)
        {
            if (this.Hook.GetComponent<HingeJoint>().spring.targetPosition < this.HookEnd)
            {
                this.HookOut = true;
                this.HookMovingOut = false;
            }
            if (this.Hook.GetComponent<HingeJoint>().spring.targetPosition > 0)
            {
                this.HookOut = false;
                this.HookMovingIn = false;
            }
        }
        if (this.TranslatorMovingOut)
        {
            if (((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition.y > this.TranslatorEnd)
            {
                ((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition = ((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition - new Vector3(0, 0.02f, 0);
            }
        }
        if (this.TranslatorMovingIn)
        {
            if (((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition.y < 0)
            {
                ((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition = ((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition + new Vector3(0, 0.02f, 0);
            }
        }
        if (this.HookMovingOut)
        {
            if (this.Hook.GetComponent<HingeJoint>().spring.targetPosition > this.HookEnd)
            {

                {
                    float _1148 = this.Hook.GetComponent<HingeJoint>().spring.targetPosition - 0.2f;
                    JointSpring _1149 = this.Hook.GetComponent<HingeJoint>().spring;
                    _1149.targetPosition = _1148;
                    this.Hook.GetComponent<HingeJoint>().spring = _1149;
                }
            }
        }
        if (this.HookMovingIn)
        {
            if (this.Hook.GetComponent<HingeJoint>().spring.targetPosition < 0)
            {

                {
                    float _1150 = this.Hook.GetComponent<HingeJoint>().spring.targetPosition + 0.2f;
                    JointSpring _1151 = this.Hook.GetComponent<HingeJoint>().spring;
                    _1151.targetPosition = _1150;
                    this.Hook.GetComponent<HingeJoint>().spring = _1151;
                }
            }
        }
    }

    public ConsignorHookController()
    {
        this.TranslatorEnd = 5;
        this.HookEnd = 120;
    }

}