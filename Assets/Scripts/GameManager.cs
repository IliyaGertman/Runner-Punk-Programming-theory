using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI gameOverText;
    public PlayerController pcScript;
    public Button restartButton;
    public Button quitToMenuButton;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI pauseText;
    public AudioSource musicPlayer;
    public AudioSource cityAmb_1;
    public AudioSource cityAmb_2;
    public AudioSource siren;
    public Animator playerAnimator;
    public SpawnManager spawnManager;


    // Start is called before the first frame update

    private void Awake() //made a static instance of this script since it's the global game state manager. Reference it as such in PlayerController.
    {



        instance = this;

    }

        void Start()
    {

      
        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();
        musicPlayer = GameObject.Find("Music Player").GetComponent<AudioSource>();
        cityAmb_1 = GameObject.Find("City Ambience Layer 1").GetComponent<AudioSource>();
        cityAmb_2 = GameObject.Find("City Ambience Layer 2").GetComponent<AudioSource>();
        siren = GameObject.Find("SirenSound").GetComponent<AudioSource>();
     playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        DeactivateInGameUI();

    }

    // Update is called once per frame

    void Update()
    {

    }

    public void GameOver()
    {
        if (pcScript.gameWon!=true)

        {
            ActivateGameOverMenu();
        }
      
    }

    public void GameWon()
    {

        if(pcScript.gameOver!=true)
       
        {
            ActivateGameWonMenu();
        }
       
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      
        AudioManager.instance.musicPlayer.time = 0f;
        AudioManager.instance.musicPlayer.volume = 1f;
   
        AudioManager.instance.musicPlayer.Play();


    }

    public void QuitToMenu()

    {
        pcScript.gameOver = true;
        pcScript.gamePaused = false;
        SceneManager.LoadScene("Main Menu");
        
    }

    public void PauseGame()

    {
        if (pcScript.gameOver == false && pcScript.gameWon==false)
        {
            pcScript.gamePaused = true;
            musicPlayer.Pause();
            cityAmb_1.Pause();
            cityAmb_2.Pause();
            siren.Pause();
            playerAnimator.SetBool("gamePaused", true);
            pcScript.dirtParticle.Stop();
            pcScript.explosionParticle.Play();
            spawnManager.OnPauseGame();

            ActivatePauseMenu();

        }


    }

    public void ResumeGame()

    {
        if (pcScript.gameOver==false)

        {
            pcScript.gamePaused = false;
            musicPlayer.UnPause();
            cityAmb_1.UnPause();
            cityAmb_2.UnPause();
            siren.UnPause();
            playerAnimator.SetBool("gamePaused", false);
            pcScript.dirtParticle.Play();
            pauseText.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(true);
            quitToMenuButton.gameObject.SetActive(true); 
            pcScript.dirtParticle.Play();
            pcScript.explosionParticle.Stop();
            spawnManager.OnResumeGame();


        }
    }

    public void ActivateGameOverMenu()

    {

        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        quitToMenuButton.gameObject.SetActive(true);

    }

    public void ActivateGameWonMenu()

    {
        winText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        quitToMenuButton.gameObject.SetActive(true);
    }

    public void ActivatePauseMenu()

    {

        pauseText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        quitToMenuButton.gameObject.SetActive(true);

    }

    public void DeactivateInGameUI()

    {

        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        quitToMenuButton.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        pauseText.gameObject.SetActive(false);

    }

}