using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [HideInInspector] public bool gameStatus;

    public GameObject player;
    PlayerAttributes pA;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = true;
        pA = player.GetComponent<PlayerAttributes>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStatus)
        {
            if (Input.GetKey(KeyCode.R))
            {
                Time.timeScale = 1;
                Debug.Log(Time.timeScale);
                pA.lifeHits = 2;
                gameStatus = true;
            }
            if (Input.GetKey(KeyCode.N))
            {
                Time.timeScale = 1;
                Debug.Log(Time.timeScale);
            }
        }
    }

    public void GameOverEvent()
    {
        gameStatus = false;
        Time.timeScale = 0;
        Debug.Log(Time.timeScale);
    }

    public void sceneManager()
    {
       
    }
}
