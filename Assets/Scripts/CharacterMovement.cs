using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour


{
    private PlayerController playerControllerScript;
    public float speed;
    public float leftBound = 40;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false && playerControllerScript.gamePaused==false)

        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (playerControllerScript.gameWon == true)

        {
            speed = 4.0f;
        }

        if (playerControllerScript.gameOver == true)

        {
            speed = 4.0f;
        }


        if (playerControllerScript.bumped == true)

        {
            speed = 4.0f;
        }
        if (playerControllerScript.bumped == false)

        {
            speed = 30.0f;
        }

        if (transform.position.x > leftBound && gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject, 3);
            }


        if (playerControllerScript.gamePaused == true)

        {
            Destroy(gameObject);
        }
    }

}
 

