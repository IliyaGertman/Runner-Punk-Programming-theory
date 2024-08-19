using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerEasy : MonoBehaviour
{
    public GameObject[] obstaclePrefab;

    private float startDelay = 3;
    private float repeatRate;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        Invoke("SpawnObstacle", startDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
            Vector3 spawnPos = new Vector3(-5.20f, 0.0f, Random.Range(-2.0f, 4.5f));
            Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation);
            Invoke("SpawnObstacle", Random.Range(0.5f, 1.0f));
        }



    }
}
