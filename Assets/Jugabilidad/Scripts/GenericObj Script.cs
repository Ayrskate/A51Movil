using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjScript : MonoBehaviour
{
    public float globalSpeed;
    public int speedModTimer;

    private float speedMult;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        speedMult = 10;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, globalSpeed);
    }

    public IEnumerator SpeedModifier()
    {
        float aux = globalSpeed;
        globalSpeed *= speedMult;
        Debug.Log("La velocidad modificada es: " + globalSpeed);

        for (int i = 0; i < speedModTimer; i++)
        {
            yield return new WaitForSeconds(1f);
        }

        speedModTimer = 0;
        globalSpeed = aux;
    }
}
