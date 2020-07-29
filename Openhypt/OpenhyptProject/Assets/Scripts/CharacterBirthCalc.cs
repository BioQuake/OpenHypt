using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CharacterBirthCalc : MonoBehaviour
{
    public int currentAge;
    public int finalAge;
    public virtual void Start()
    {
        this.currentAge = this.currentAge - 1756;
        this.finalAge = this.currentAge;
        Debug.Log(this.finalAge);
    }

}