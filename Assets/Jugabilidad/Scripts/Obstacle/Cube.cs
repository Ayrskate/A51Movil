using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody rb;
    public float time;
     
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * speed);
    }
}
