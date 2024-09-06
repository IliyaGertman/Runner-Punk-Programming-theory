using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public GameObject bottleCollectible;
    public static SpawnManager instance;
    public float startDelay;
    public float repeatRateA;
    public float repeatRateB;
    public float repeatRateCollectibleA;
    public float repeatRatecCollectibleB;
    private Coroutine spawnObstacleCoroutine;
    private Coroutine spawnCollectibleCoroutine;


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
        StartSpawning();
    }
    void StartSpawning()
    {
        // Only start the coroutine if it isn't already running
        if (spawnObstacleCoroutine == null && spawnCollectibleCoroutine==null)
        {
            spawnObstacleCoroutine = StartCoroutine(SpawnObstacleCoroutine());
            spawnCollectibleCoroutine = StartCoroutine(SpawnCollectibleCoroutine());
        }

    }

    void StopSpawning()
    {
        // Stop the spawning coroutine
        if (spawnObstacleCoroutine != null && spawnCollectibleCoroutine!=null)
        {
            StopCoroutine(spawnObstacleCoroutine);
            StopCoroutine(spawnCollectibleCoroutine);
            spawnObstacleCoroutine = null;
            spawnCollectibleCoroutine = null;
        }
    }


    IEnumerator SpawnObstacleCoroutine()
    {
        while (!playerControllerScript.gameOver && !playerControllerScript.gamePaused)
        {
            // Spawn the obstacle
            SpawnObstacle();

            // Wait for a random time between repeatRateA and repeatRateB before spawning the next one
            yield return new WaitForSeconds(Random.Range(repeatRateA, repeatRateB));
        }

    }


    IEnumerator SpawnCollectibleCoroutine()
    {
        while (!playerControllerScript.gameOver && !playerControllerScript.gamePaused)
        {
            // Spawn the obstacle
            SpawnCollectible();

            // Wait for a random time between repeatRateA and repeatRateB before spawning the next one
            yield return new WaitForSeconds(Random.Range(repeatRateA, repeatRateB));
        }
    }
    void Update()
        {

        }

        void SpawnObstacle()
        {
            if (!playerControllerScript.gameOver && !playerControllerScript.gamePaused)

            {
            int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
                Vector3 spawnPos = new Vector3(-5.20f, 0.0f, Random.Range(-2.0f, 4.5f));
                Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation);
    
               // Invoke("SpawnObstacle", Random.Range(repeatRateA, repeatRateB));
            }
        }
    void SpawnCollectible()



    {

        if (!playerControllerScript.gameOver && !playerControllerScript.gamePaused)
      
        
        {
            Vector3 spawnPos = new Vector3(-5.20f, 2.0f, Random.Range(-2.0f, 4.5f));
            Instantiate(bottleCollectible, spawnPos, bottleCollectible.transform.rotation);
           // Invoke("SpawnCollectible", Random.Range(repeatRateCollectibleA, repeatRatecCollectibleB));

        }    

       
    }




        public void GameState()

        {

            if (playerControllerScript.gameWon == true)

            {
            //CancelInvoke();

            StopSpawning();

        }
            if (playerControllerScript.gameOver == true)

            {
                //CancelInvoke();

            }
        }

    public void OnPauseGame()
    {
        StopSpawning();
    }

    public void OnResumeGame()
    {
        StartSpawning();
    }











}







