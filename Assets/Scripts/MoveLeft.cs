using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private PlayerController playerControllerScript;
    public static float speed;
    public float leftBound = 20;


   
            

    // Start is called before the first frame update
    void Start()
    {
      
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false && playerControllerScript.bumped == false && playerControllerScript.gamePaused==false)

        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (playerControllerScript.gameWon==true)

        {

            speed = 0;
        }    

        if (transform.position.x > leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject, 5);
        }

        if (transform.position.x > leftBound && gameObject.CompareTag("Collectible"))
        {
            Destroy(gameObject, 5);
        }





    }
}
