using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public static SpawnManager instance;
    public float startDelay;
    public float repeatRateA;
    public float repeatRateB;


    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
      
    }
    void Start()
    { 
       if (DifficultyManager.instance != null)
    {
        DifficultyManager.instance.DifficultyParameterSetter();
        Debug.Log("Difficulty after scene load: " + DifficultyManager.instance.gameDifficulty);
    }
      else
    {
    Debug.LogError("DifficultyManager instance is not available.");
    }

playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

     Invoke("SpawnObstacle", startDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false && playerControllerScript.gamePaused == false)

        {  int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
            Vector3 spawnPos = new Vector3(-5.20f, 0.0f, Random.Range(-2.0f, 4.5f));
            Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation);
            Invoke("SpawnObstacle", Random.Range(repeatRateA, repeatRateB));
        }
    }


    public void GameState()

    { 

        if (playerControllerScript.gameWon == true)

        {
            CancelInvoke();

        }
        if (playerControllerScript.gameOver == true)

        {
            CancelInvoke();

        }
    }
 
    
       



        

       
    
}







