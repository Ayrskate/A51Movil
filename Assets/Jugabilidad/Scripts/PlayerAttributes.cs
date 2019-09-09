using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{

    public int lifeHits;

    public bool invulnerableStat;
    public int invulnerableTimer;

    public GameController gC;
    
    // Start is called before the first frame update
    void Start()
    {
        lifeHits = 3;
        invulnerableStat = false;
        invulnerableTimer = 0;
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
        //Colisión con los obstaculos
        if (invulnerableStat == false)
        {
            if (col.gameObject.tag.Equals("Obstacle") && lifeHits > 0)
            {
                lifeHits--;
                invulnerableStat = true;
                invulnerableTimer = 3;
                StartCoroutine("GetInvulnerable");
            }
            else if (col.gameObject.tag.Equals("Obstacle") && lifeHits <= 0)
            {
                if (gC.gameStatus == true)
                    gC.GameOverEvent();
                Debug.Log("Gameover"); //Crear metodos para el gameover
            }
                
        }
              
    }

    IEnumerator GetInvulnerable()
    {
        for(int i = 0; i < invulnerableTimer; i++)
        {
            yield return new WaitForSeconds(1f);
        }

        invulnerableTimer = 0;
        invulnerableStat = false;
        Debug.Log("Terminó invencibilidad");
    }
}
