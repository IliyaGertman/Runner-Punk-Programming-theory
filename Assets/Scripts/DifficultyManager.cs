using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{
    //    I need to: Create if statements for the game manager which control our difficulty parameters - Speed, Spawnrate and Countdown
    public static DifficultyManager instance;
    public int gameDifficulty;
   
  


    public int timeLeft;

    private void Awake()
    
    {

        if (instance== null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //when I press each button, it runs a method which sets it's own difficulty
    public void SetEasy()

    {
        
      gameDifficulty = 1;
        Debug.Log("Difficulty is" + gameDifficulty);
      SceneManager.LoadScene(1);
     
    }

    public void SetNormal()

    {
        gameDifficulty = 2;
        SceneManager.LoadScene(1);

    }

   public void SetHardcore()

    {
        
        gameDifficulty = 3;
        SceneManager.LoadScene(1);

    }


    public void DifficultyParameterSetter()

    {


    if (gameDifficulty==1)
        {

            //speed = 1;
            MoveLeft.speed = 20f;
            //spawnRate = 1;
            SpawnManager.instance.repeatRateA = 1f;
            SpawnManager.instance.repeatRateB = 3f;

            //timeLeft = 30;

          
        }   
    
    if (gameDifficulty == 2)

        {

            //speed = 2;
            MoveLeft.speed = 30;
            //spawnRate = 2;
            SpawnManager.instance.repeatRateA = 1f;
            SpawnManager.instance.repeatRateB = 2f;
            //timeLeft = 60;



        }

        if (gameDifficulty == 3)

        {

            //speed = 3;
            MoveLeft.speed = 40;
            //spawnRate = 3;
            SpawnManager.instance.repeatRateA = 0.5f;
            SpawnManager.instance.repeatRateB = 1.0f;
            //timeLeft = 90;




        }

        //make sure the difficulty manager travels from the menu scene to the game scene (
    }









}
