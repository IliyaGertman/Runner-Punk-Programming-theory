using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public PlayerController pcScript;
    public Button restartButton;
    public Button quitToMenuButton;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI pauseText;

    // Start is called before the first frame update
    void Start()
    {
        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        quitToMenuButton.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        pauseText.gameObject.SetActive(false);


    }

    // Update is called once per frame

    void Update()
    {

    }

    public void GameOver()
    {
        if (pcScript.gameWon!=true)

        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            quitToMenuButton.gameObject.SetActive(true);
        }
      
    }

    public void GameWon()
    {

        if(pcScript.gameOver!=true)
       
        {

            winText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            quitToMenuButton.gameObject.SetActive(true);

        }
       
    }

    public void RestartGame()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void QuitToMenu()

    {
        pcScript.gameOver = true;
        pcScript.gamePaused = false;
        SceneManager.LoadScene("Main Menu");
        
    }

    public void PauseGame()

    {
        if (pcScript.gameOver == false)
        {
            pauseText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            quitToMenuButton.gameObject.SetActive(true);


        }


    }

    public void ResumeGame()

    {
        if (pcScript.gameOver==false)

        {
            pauseText.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(true);
            quitToMenuButton.gameObject.SetActive(true);


        }
    }
    }