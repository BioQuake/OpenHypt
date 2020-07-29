using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class HatchScript : MonoBehaviour
{
    public HingeJoint ConfJ;
    public bool reversedOpening;
    public bool Open;
    public bool Opening;
    public bool Closing;
    public virtual void FixedUpdate()
    {
        if (!this.reversedOpening)
        {
            if (this.Closing || this.Opening)
            {
                if (this.ConfJ.spring.targetPosition > 133)
                {
                    this.Open = true;
                    this.Opening = false;
                }
                if (this.ConfJ.spring.targetPosition < 2)
                {
                    this.Open = false;
                    this.Closing = false;
                }
            }
            if (this.Opening)
            {
                if (this.ConfJ.spring.targetPosition < 135)
                {

                    {
                        float _1982 = this.ConfJ.spring.targetPosition + 2;
                        JointSpring _1983 = this.ConfJ.spring;
                        _1983.targetPosition = _1982;
                        this.ConfJ.spring = _1983;
                    }
                }
            }
            if (this.Closing)
            {
                if (this.ConfJ.spring.targetPosition > 0)
                {

                    {
                        float _1984 = this.ConfJ.spring.targetPosition - 2;
                        JointSpring _1985 = this.ConfJ.spring;
                        _1985.targetPosition = _1984;
                        this.ConfJ.spring = _1985;
                    }
                }
            }
        }
        else
        {
            if (this.Closing || this.Opening)
            {
                if (this.ConfJ.spring.targetPosition < -90)
                {
                    this.Open = true;
                    this.Opening = false;
                }
                if (this.ConfJ.spring.targetPosition > 0)
                {
                    this.Open = false;
                    this.Closing = false;
                }
            }
            if (this.Opening)
            {
                if (this.ConfJ.spring.targetPosition > -91)
                {

                    {
                        float _1986 = this.ConfJ.spring.targetPosition - 2;
                        JointSpring _1987 = this.ConfJ.spring;
                        _1987.targetPosition = _1986;
                        this.ConfJ.spring = _1987;
                    }
                }
            }
            if (this.Closing)
            {
                if (this.ConfJ.spring.targetPosition < 1)
                {

                    {
                        float _1988 = this.ConfJ.spring.targetPosition + 2;
                        JointSpring _1989 = this.ConfJ.spring;
                        _1989.targetPosition = _1988;
                        this.ConfJ.spring = _1989;
                    }
                }
            }
        }
    }

    public virtual void Move()
    {
        if (!this.reversedOpening)
        {
            if (!this.Open)
            {

                {
                    float _1990 = this.ConfJ.spring.targetPosition + 2;
                    JointSpring _1991 = this.ConfJ.spring;
                    _1991.targetPosition = _1990;
                    this.ConfJ.spring = _1991;
                }
                this.Opening = true;
                this.Closing = false;
            }
            if (this.Open)
            {

                {
                    float _1992 = this.ConfJ.spring.targetPosition - 2;
                    JointSpring _1993 = this.ConfJ.spring;
                    _1993.targetPosition = _1992;
                    this.ConfJ.spring = _1993;
                }
                this.Opening = false;
                this.Closing = true;
            }
        }
        else
        {
            if (!this.Open)
            {

                {
                    float _1994 = this.ConfJ.spring.targetPosition + 2;
                    JointSpring _1995 = this.ConfJ.spring;
                    _1995.targetPosition = _1994;
                    this.ConfJ.spring = _1995;
                }
                this.Opening = true;
                this.Closing = false;
            }
            if (this.Open)
            {

                {
                    float _1996 = this.ConfJ.spring.targetPosition - 2;
                    JointSpring _1997 = this.ConfJ.spring;
                    _1997.targetPosition = _1996;
                    this.ConfJ.spring = _1997;
                }
                this.Opening = false;
                this.Closing = true;
            }
        }
    }

}