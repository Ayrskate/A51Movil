using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject obstacle1;
    public float spawntime = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Inst", 1, 1); 
    }

    void Inst()
    {
        Instantiate(obstacle1, transform.position, transform.rotation);
    }
    
}
