using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class KabrianLaw : MonoBehaviour
{
    public static int Amount1;
    public static int Amount2;
    public static bool KabrianPolicePresent;
    public virtual void Start()
    {
        this.InvokeRepeating("Counter", 0.33f, 1);
        KabrianLaw.KabrianPolicePresent = false;
    }

    public virtual void Counter()
    {
        if (KabrianLaw.KabrianPolicePresent)
        {
            if (WorldInformation.vehicleSpeed > 1200)
            {
                AgrianNetwork.Spawn = 16;
            }
        }
        if (KabrianLaw.Amount1 > 1)
        {
            KabrianLaw.Amount1 = KabrianLaw.Amount1 - 128;
        }
        if (KabrianLaw.Amount1 < 0)
        {
            KabrianLaw.Amount1 = 0;
        }
        if (KabrianLaw.Amount1 > 400)
        {
            AgrianNetwork.Spawn = 4;
            KabrianLaw.Amount1 = 400;
        }
        if (KabrianLaw.Amount2 > 1)
        {
            KabrianLaw.Amount2 = KabrianLaw.Amount2 - 520;
        }
        if (KabrianLaw.Amount2 < 0)
        {
            KabrianLaw.Amount2 = 0;
        }
        if (KabrianLaw.Amount2 > 10000)
        {
            AgrianNetwork.Spawn = 4;
            KabrianLaw.Amount2 = 10000;
        }
    }

}