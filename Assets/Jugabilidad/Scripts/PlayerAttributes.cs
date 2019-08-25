using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{

    [HideInInspector]public int lifeHits;
    [HideInInspector]public bool invulnerableStat;

    public GameController gC;
    
    // Start is called before the first frame update
    void Start()
    {
        lifeHits = 3;
        invulnerableStat = false;
    }

    // Update is called once per frame
    void Update()
    { 
        //Debug del game over
        if (lifeHits > 0)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                lifeHits--;
                Debug.Log(lifeHits);
            }
        }
        else
        {
            if(gC.gameStatus == true)
                gC.GameOverEvent();
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (invulnerableStat == false)
        {
            if (col.tag.Equals("Obstacle") && lifeHits > 0)
            {
                lifeHits--;
                StartCoroutine("GetInvulnerable");
            }
            else if (col.tag.Equals("Obstacle") && lifeHits <= 0)
                Debug.Log("Gameover"); //Crear metodos para el gameover
        }
              
    }

    IEnumerator GetInVulnerable()
    {
        invulnerableStat = true;
        yield return new WaitForSeconds(3f);
        invulnerableStat = false;
    }
}
