using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class NpcRespawner : MonoBehaviour
{
    public GameObject Type;
    public GameObject Type2;
    public bool DifferentTypes;
    public bool RareType;
    public Transform PlayerPresence;
    public float SpawnTick;
    public int DropDist;
    public bool IsActive;
    public bool ForceSpawn;
    public bool SpawnAtStart;
    public bool UsePlayerProxy;
    public bool UseSpecialProxy;
    public int SPMinDist;
    public int SPMaxDist;
    public bool RotateRandomly;
    public bool RotateSlightly;
    public bool ButtonSpawned;
    public bool SpawnOnce;
    public bool LocalSpawn;
    public bool UseSpawnChance;
    public float OneIn;
    public GameObject TheThingie;
    public virtual void Update()
    {
        if (Input.GetKeyDown("y") && this.ButtonSpawned)
        {
            this.KeySpawn();
        }
        if (this.ForceSpawn)
        {
            this.ForceSpawn = false;
            this.SpawnIt();
        }
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Spawnie", this.SpawnTick, this.SpawnTick);
        this.PlayerPresence = PlayerInformation.instance.PiriPresence;
        if (!this.UseSpawnChance)
        {
            this.IsActive = true;
        }
        else
        {
            this.IsActive = false;
        }
        if (this.SpawnAtStart)
        {
            this.Spawnie();
            UnityEngine.Object.Destroy(this);
        }
    }

    public virtual void Spawnie()
    {
        int Interval = (int) Random.Range(0, this.OneIn);
        if (this.UseSpawnChance)
        {
            switch (Interval)
            {
                case 1:
                    this.IsActive = true;
                    break;
            }
        }
        if (this.IsActive)
        {
            if ((!this.ButtonSpawned && !this.SpawnOnce) && !this.LocalSpawn)
            {
                this.Spawn1();
            }
            if ((!this.ButtonSpawned && this.SpawnOnce) && !this.LocalSpawn)
            {
                this.Spawn2();
            }
            if ((!this.ButtonSpawned && !this.SpawnOnce) && this.LocalSpawn)
            {
                this.Spawn3();
            }
        }
    }

    public virtual void Spawn1()
    {
        RaycastHit hit = default(RaycastHit);
        if (Physics.Raycast(this.transform.position, -this.transform.up, out hit, 20000))
        {
            if (this.UsePlayerProxy || this.UseSpecialProxy)
            {
                Vector3 PresPos = this.PlayerPresence.position;
            
            Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            if ((this.UsePlayerProxy && (this.TheThingie == null)) && (Vector3.Distance(hit.point, PresPos) > 2000))
            {
                if (this.RotateRandomly)
                {
                    if (!this.DifferentTypes)
                    {
                        this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), randomRotation);
                    }
                    else
                    {
                        if (!this.RareType)
                        {
                            int randomValue1 = Random.Range(1, 3);
                            switch (randomValue1)
                            {
                                case 1:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), randomRotation);
                                    break;
                                case 2:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type2, hit.point + (this.transform.up * this.DropDist), randomRotation);
                                    break;
                            }
                        }
                        else
                        {
                            int randomValue2 = Random.Range(1, 5);
                            switch (randomValue2)
                            {
                                case 1:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), randomRotation);
                                    break;
                                case 2:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), randomRotation);
                                    break;
                                case 3:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), randomRotation);
                                    break;
                                case 4:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type2, hit.point + (this.transform.up * this.DropDist), randomRotation);
                                    break;
                            }
                        }
                    }
                }
                if (!this.RotateRandomly)
                {
                    if (!this.DifferentTypes)
                    {
                        this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                    }
                    else
                    {
                        if (!this.RareType)
                        {
                            int randomValue3 = Random.Range(1, 3);
                            switch (randomValue3)
                            {
                                case 1:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                                    break;
                                case 2:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type2, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                                    break;
                            }
                        }
                        else
                        {
                            int randomValue4 = Random.Range(1, 5);
                            switch (randomValue4)
                            {
                                case 1:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                                    break;
                                case 2:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                                    break;
                                case 3:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                                    break;
                                case 4:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type2, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                                    break;
                            }
                        }
                    }
                }
                if (this.RotateSlightly)
                {
                    this.TheThingie.transform.Rotate(Vector3.up * Random.Range(-30, 30));
                }
            }
            if (((this.UseSpecialProxy && !this.TheThingie) && (Vector3.Distance(hit.point, PresPos) > this.SPMinDist)) && (Vector3.Distance(hit.point, PresPos) < this.SPMaxDist))
            {
                if (this.RotateRandomly)
                {
                    if (!this.DifferentTypes)
                    {
                        this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), randomRotation);
                    }
                    else
                    {
                        if (!this.RareType)
                        {
                            int randomValue5 = Random.Range(1, 3);
                            switch (randomValue5)
                            {
                                case 1:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), randomRotation);
                                    break;
                                case 2:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type2, hit.point + (this.transform.up * this.DropDist), randomRotation);
                                    break;
                            }
                        }
                        else
                        {
                            int randomValue6 = Random.Range(1, 5);
                            switch (randomValue6)
                            {
                                case 1:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), randomRotation);
                                    break;
                                case 2:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), randomRotation);
                                    break;
                                case 3:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), randomRotation);
                                    break;
                                case 4:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type2, hit.point + (this.transform.up * this.DropDist), randomRotation);
                                    break;
                            }
                        }
                    }
                }
                if (!this.RotateRandomly)
                {
                    if (!this.DifferentTypes)
                    {
                        this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                    }
                    else
                    {
                        if (!this.RareType)
                        {
                            int randomValue7 = Random.Range(1, 3);
                            switch (randomValue7)
                            {
                                case 1:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                                    break;
                                case 2:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type2, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                                    break;
                            }
                        }
                        else
                        {
                            int randomValue8 = Random.Range(1, 5);
                            switch (randomValue8)
                            {
                                case 1:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                                    break;
                                case 2:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                                    break;
                                case 3:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                                    break;
                                case 4:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type2, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                                    break;
                            }
                        }
                    }
                }
                if (this.RotateSlightly)
                {
                    this.TheThingie.transform.Rotate(Vector3.up * Random.Range(-30, 30));
                }
            }
                if ((!this.UsePlayerProxy && !this.UseSpecialProxy) && (this.TheThingie == null))
                {
                    if (this.RotateRandomly)
                    {
                        if (!this.DifferentTypes)
                        {
                            this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), randomRotation);
                        }
                        else
                        {
                            int randomValue9 = Random.Range(1, 3);
                            switch (randomValue9)
                            {
                                case 1:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                                    break;
                                case 2:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type2, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                                    break;
                            }
                        }
                    }
                    if (!this.RotateRandomly)
                    {
                        if (!this.DifferentTypes)
                        {
                            this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                        }
                        else
                        {
                            int randomValue0 = Random.Range(1, 3);
                            switch (randomValue0)
                            {
                                case 1:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                                    break;
                                case 2:
                                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type2, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }

    public virtual void Spawn2()
    {
        RaycastHit hit = default(RaycastHit);
        if (Physics.Raycast(this.transform.position, -this.transform.up, out hit, 20000))
        {
            if (this.UsePlayerProxy)
            {
                Vector3 PresPos = this.PlayerPresence.position;

                Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                if ((this.UsePlayerProxy && (this.TheThingie == null)) && (Vector3.Distance(hit.point, PresPos) > 2000))
                {
                    if (this.RotateRandomly)
                    {
                        this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), randomRotation);
                    }
                    if (!this.RotateRandomly)
                    {
                        this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                    }
                    this.IsActive = false;
                }
                if (!this.UsePlayerProxy && (this.TheThingie == null))
                {
                    if (this.RotateRandomly)
                    {
                        this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), randomRotation);
                    }
                    if (!this.RotateRandomly)
                    {
                        this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                    }
                    this.IsActive = false;
                }
            }
        }
    }

    public virtual void Spawn3()
    {
        if (this.UsePlayerProxy || this.UseSpecialProxy)
        {
            Vector3 PresPos = this.PlayerPresence.position;

            Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            if ((this.UsePlayerProxy && (this.TheThingie == null)) && (Vector3.Distance(this.transform.position, PresPos) > 2000))
            {
                if (this.RotateRandomly)
                {
                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, this.transform.position, randomRotation);
                }
                if (!this.RotateRandomly)
                {
                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, this.transform.position, this.transform.rotation);
                }
            }
            if (((this.UseSpecialProxy && !this.TheThingie) && (Vector3.Distance(this.transform.position, PresPos) > this.SPMinDist)) && (Vector3.Distance(this.transform.position, PresPos) < this.SPMaxDist))
            {
                if (this.RotateRandomly)
                {
                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, this.transform.position, randomRotation);
                }
                if (!this.RotateRandomly)
                {
                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, this.transform.position, this.transform.rotation);
                }
            }
            if ((!this.UsePlayerProxy && !this.UseSpecialProxy) && (this.TheThingie == null))
            {
                if (this.RotateRandomly)
                {
                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, this.transform.position, randomRotation);
                }
                if (!this.RotateRandomly)
                {
                    this.TheThingie = UnityEngine.Object.Instantiate(this.Type, this.transform.position, this.transform.rotation);
                }
            }
        }
    }

    public virtual void SpawnIt()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.UsePlayerProxy)
        {
            Vector3 PresPos = this.PlayerPresence.position;

            if (Physics.Raycast(this.transform.position, -this.transform.up, out hit, 20000))
            {
                Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                if ((this.UsePlayerProxy && (this.TheThingie == null)) && (Vector3.Distance(hit.point, PresPos) > 2000))
                {
                    if (this.RotateRandomly)
                    {
                        this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), randomRotation);
                    }
                    if (!this.RotateRandomly)
                    {
                        this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
                    }
                }
            }
        }
    }

    public virtual void KeySpawn()
    {
        RaycastHit hit = default(RaycastHit);
        if (Physics.Raycast(this.transform.position, -this.transform.up, out hit, 20000))
        {
            Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            if (this.RotateRandomly)
            {
                this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), randomRotation);
            }
            if (!this.RotateRandomly)
            {
                this.TheThingie = UnityEngine.Object.Instantiate(this.Type, hit.point + (this.transform.up * this.DropDist), this.transform.rotation);
            }
        }
    }

    public NpcRespawner()
    {
        this.SpawnTick = 0.1f;
        this.DropDist = 5;
        this.UsePlayerProxy = true;
        this.SPMinDist = 1000;
        this.SPMaxDist = 2000;
        this.OneIn = 2;
    }

}