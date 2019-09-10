using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandaNinja : GenericObjScript
{
    PlayerAttributes pa;
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
            pa = col.gameObject.GetComponent<PlayerAttributes>();

        if (pa.invulnerableStat == false)
        {
            pa.invulnerableStat = true;
            pa.invulnerableTimer = 3;
            speedModTimer = 3;
            pa.StartCoroutine("GetInvulnerable");
            StartCoroutine("SpeedModifier");
            Destroy(gameObject);
            Debug.Log(pa.invulnerableTimer);
        }
        else
        {
            pa.invulnerableTimer += 1;
            speedModTimer += 1;
            Destroy(gameObject);
            Debug.Log(pa.invulnerableTimer);
        }

    }
}
