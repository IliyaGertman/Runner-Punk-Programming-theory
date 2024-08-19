using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject instructions;
    private GameObject menu;
    
 
   public void PlayEasy()
    {

        SceneManager.LoadScene("Easy Mode");
    }

    public void PlayNormal ()
    {

        SceneManager.LoadScene("Normal Mode");
    }

    public void PlayHardcore()
    {

        SceneManager.LoadScene("Hardcore Mode");
    }

    public void QuitGame()
    {
        Application.Quit();

    }

    void Start()
    {
     
        menu = GameObject.Find("Menu Screen");
        instructions = GameObject.Find("Instructions Menu");
        instructions.SetActive(false);
      
    
    }
    public void InstructionScreen()
    {
      
        instructions.SetActive(true);
        menu.SetActive(false);
    }

    public void BackToMenuScreen()
    {
        instructions.SetActive(false);
        menu.SetActive(true);
    }


}
