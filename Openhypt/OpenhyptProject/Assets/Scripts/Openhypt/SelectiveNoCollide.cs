using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectiveNoCollide : MonoBehaviour
{

    public Collider[] ignoreColliders;
    public Collider[] localColliders;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<ignoreColliders.Length;i++)
        {
            for(int j=0;j<localColliders.Length;j++)
            {
                Physics.IgnoreCollision(localColliders[j], ignoreColliders[i], true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
