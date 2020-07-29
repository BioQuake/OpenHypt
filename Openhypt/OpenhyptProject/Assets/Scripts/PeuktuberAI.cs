using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PeuktuberAI : MonoBehaviour
{
    public float Multiplier;
    public AudioClip[] toots;
    public bool BandF;
    public bool Forth;
    public float MoveLengthrandomizer;
    public float MoveMinDelay;
    public float MoveMaxDelay;
    public float TootLengthrandomizer;
    public float TootMinDelay;
    public float TootMaxDelay;
    public virtual void Start()
    {
        StuffSpawner.TheNPC002N = StuffSpawner.TheNPC002N + 1;
        //lastTime = Time.time + 2;
    }

    public virtual void Move()
    {
        this.GetComponent<Rigidbody>().AddForce(this.transform.up * this.Multiplier, ForceMode.Impulse);
    }

    public virtual void Toot()
    {
        this.GetComponent<AudioSource>().clip = this.toots[Random.Range(0, this.toots.Length)];
        this.GetComponent<AudioSource>().Play();
    }

    public float moveLastTime;
    public float tootLastTime;
    public virtual void Update()
    {
        if ((Time.time - this.moveLastTime) > this.MoveLengthrandomizer)
        {
            this.MoveLengthrandomizer = this.MoveMinDelay + (Random.value * (this.MoveMaxDelay - this.MoveMinDelay));
            this.Move();
            this.moveLastTime = Time.time;
        }
        if ((Time.time - this.tootLastTime) > this.TootLengthrandomizer)
        {
            this.TootLengthrandomizer = this.TootMinDelay + (Random.value * (this.TootMaxDelay - this.TootMinDelay));
            this.Toot();
            this.tootLastTime = Time.time;
        }
    }

    public virtual void Damage()
    {
        StuffSpawner.TheNPC002N = StuffSpawner.TheNPC002N - 1;
    }

    public PeuktuberAI()
    {
        this.MoveLengthrandomizer = 6f;
        this.MoveMinDelay = 6f;
        this.MoveMaxDelay = 12f;
        this.TootLengthrandomizer = 6f;
        this.TootMinDelay = 6f;
        this.TootMaxDelay = 12f;
    }

}