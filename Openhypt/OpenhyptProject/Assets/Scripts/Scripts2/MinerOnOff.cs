using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MinerOnOff : MonoBehaviour
{
    public MineralDispenser dispenser;
    public MineralContainer Container;
    public GameObject Vehicle;
    public GameObject Miner;
    public GameObject MinerRotor;
    public GameObject audioOn;
    public GameObject audioOff;
    public static bool switched;
    public bool CanRun;
    public int MinerContainerCapacity;
    public float maxVolume;
    private float incrementValue;
    private float decrementValue;
    private string state;
    public virtual void Update()
    {
        if (WorldInformation.playerCar.Contains(this.Vehicle.name))
        {
            this.FullCargo();
        }
        if ((WorldInformation.playerCar.Contains(this.Vehicle.name) && Input.GetKeyDown("4")) && (this.CanRun == true))
        {
            this.Running();
        }
        if (this.Miner.activeSelf == true)
        {
            this.state = "increment";
        }
        if (this.Miner.activeSelf == false)
        {
            this.state = "decrement";
        }
        if (this.state == "increment")
        {
            this.increment();
        }
        else
        {
            if (this.state == "decrement")
            {
                this.decrement();
            }
        }
        if ((MinerOnOff.switched == false) && (this.Miner.activeSelf == true))
        {
            GameObject Locsound = UnityEngine.Object.Instantiate(this.audioOff, this.transform.position, Quaternion.Euler(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z));
            Locsound.transform.parent = this.transform;
            ((ObjectSpin) this.MinerRotor.GetComponent(typeof(ObjectSpin))).enabled = false;
            this.Miner.gameObject.SetActive(false);
            this.decrement();
            MinerOnOff.switched = true;
        }
        if ((MinerOnOff.switched == false) && (this.Miner.activeSelf == false))
        {
            ((ObjectSpin) this.MinerRotor.GetComponent(typeof(ObjectSpin))).enabled = false;
            this.Miner.gameObject.SetActive(false);
            this.decrement();
            MinerOnOff.switched = true;
        }
    }

    public virtual void Running()
    {
        if (this.Miner.activeSelf)
        {
            GameObject Locsound = UnityEngine.Object.Instantiate(this.audioOff, this.transform.position, Quaternion.Euler(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z));
            Locsound.transform.parent = this.transform;
            ((ObjectSpin) this.MinerRotor.GetComponent(typeof(ObjectSpin))).enabled = false;
            this.Miner.gameObject.SetActive(false);
        }
        else
        {
            GameObject ILocsound = UnityEngine.Object.Instantiate(this.audioOn, this.transform.position, Quaternion.Euler(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z));
            ILocsound.transform.parent = this.transform;
            ((ObjectSpin) this.MinerRotor.GetComponent(typeof(ObjectSpin))).enabled = true;
            this.Miner.gameObject.SetActive(true);
        }
    }

    public virtual void FullCargo()
    {
        if (this.dispenser.HasEnoughToDispense())
        {
            IndicatorScript.CargoIsFull = true;
            this.CanRun = false;
            MinerOnOff.switched = false;
        }
        else
        {
            this.CanRun = true;
            IndicatorScript.CargoIsFull = false;
        }
    }

    public virtual void decrement()
    {
        if (this.GetComponent<AudioSource>().volume > 0)
        {
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - this.decrementValue;
        }
        else
        {
            this.GetComponent<AudioSource>().Stop();
            this.state = "";
        }
    }

    public virtual void increment()
    {
        if (!this.GetComponent<AudioSource>().isPlaying)
        {
            this.GetComponent<AudioSource>().Play();
        }
        if (this.GetComponent<AudioSource>().volume < this.maxVolume)
        {
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume + this.incrementValue;
        }
        else
        {
            this.state = "";
        }
    }

    public MinerOnOff()
    {
        this.CanRun = true;
        this.MinerContainerCapacity = 800;
        this.maxVolume = 0.5f;
        this.incrementValue = 0.05f;
        this.decrementValue = 0.1f;
    }

    static MinerOnOff()
    {
        MinerOnOff.switched = true;
    }

}