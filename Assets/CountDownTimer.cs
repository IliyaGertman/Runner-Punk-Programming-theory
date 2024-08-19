using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondsLeft;
    public bool takingAway = false;
    public PlayerController playerController;
    public GameManager gameManager;
    void Start()
    {
      

        if (secondsLeft == 60)
        {
            textDisplay.GetComponent<Text>().text = "01:00";
        }
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void Update()
    {
        if (takingAway == false && secondsLeft > 0 && playerController.gamePaused==false)
        {

            StartCoroutine(TimerTake());
        }
    }
    IEnumerator TimerTake()
    {
        

       takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
       
        takingAway = false;
         
        if (playerController.gameOver == true)

        {
            takingAway = true;
        }

        if (secondsLeft < 10)
        {

            textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
        }    
      
        if (secondsLeft < 60 && secondsLeft > 10)
        {
            textDisplay.GetComponent<Text>().text = "00:" +secondsLeft;
        }

        if (secondsLeft == 0 && playerController.bumpCount <= playerController.maxBump)
        {
            textDisplay.GetComponent<Text>().text = "00:00"; 
            gameManager.GameWon();
            playerController.gameWon = true;
        }

       
    } 
    


    }

    















