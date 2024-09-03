using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public PlayerController pcScript;

    //player related-audio object declarations

    private AudioSource playerAudioSource;

    public AudioClip[] jumpClip;
    public AudioClip[] deathClip;
    public AudioClip[] bumpClip;
    public AudioClip collectibleClip;






    //obstacle-related-audio object declarations - there's a chance you'd want to have the audio source on the object itself, and call it from here (for distance and panning)
    private AudioSource barrelAudioSource; // 
    private AudioSource boardAudioSource;
    private AudioSource coneAudioSource;
    private AudioSource boxAudioSource;

    public AudioClip[] barrelClip;
    public AudioClip[] boardClip;
    public AudioClip[] coneClip;
    public AudioClip[] boxClip;

    //people (character-related audio object declaration)

    private AudioSource charecterAudioSource; // there's a chance you'd want to have the audio source on the character itself, and call it from here (for distance and panning)


    public AudioClip[] maleTauntClip;
    public AudioClip[] maleGruntClip;
    public AudioClip[] femaleGruntClip;
    public AudioClip[] clothFoleyTransientClip;
    public AudioClip[] clothFoleyTailClip;




    //Other SFX declarations
 public AudioSource sirenAudioSource;
    public AudioMixer SirenLowPass; // accessed through UnityEngine.Audio
    private AudioSource arrestAudioSource;
    public float currentHz;
    public AudioClip arrestClip;
    public AudioClip sirenClip;



    private void Awake() //made a static instance of this script since it's the global audio-handler. Reference it as such in PlayerController.
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();

        playerAudioSource = GameObject.Find("Player").GetComponent<AudioSource>();

 

     

        arrestAudioSource = GetComponent<AudioSource>();
        sirenAudioSource = GetComponent<AudioSource>();
       
        
        //sirenAudioSource.volume = 0.1f;
        SetLowPass(0.0f);


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AssignAudioSources(GameObject obstacle)
    {
        switch (obstacle.name)
        {
            case "Obstacle_Box(Clone)":
                boxAudioSource = obstacle.GetComponent<AudioSource>();
                break;
            case "Obstacle_Barrel(Clone)":
                barrelAudioSource = obstacle.GetComponent<AudioSource>();
                break;
            case "Obstacle_Board(Clone)":
                boardAudioSource = obstacle.GetComponent<AudioSource>();
                break;
            case "Obstacle_Cone(Clone)":
                coneAudioSource = obstacle.GetComponent<AudioSource>();
                break;
            case "Businessman 1(Clone)":
                charecterAudioSource = obstacle.GetComponent<AudioSource>();
                break;
            case "Businessman 2 (clone)":
                charecterAudioSource = obstacle.GetComponent<AudioSource>();
                break;
            case "Waitress 1 (clone)":
                charecterAudioSource = obstacle.GetComponent<AudioSource>();
                break;
            case "Waitress 2 (clone)":
                charecterAudioSource = obstacle.GetComponent<AudioSource>();
                break;
            case "Worker 1 (clone)":
                charecterAudioSource = obstacle.GetComponent<AudioSource>();
                break;
            case "Worker 2 (clone)":
                charecterAudioSource = obstacle.GetComponent<AudioSource>();
                break;




                // Add cases for other obstacles as needed
        }
    }




    //-------------------------------------------PLAYER SOUNDS----------------------------------------------------------


    public void PlayBumpSound()

    {

        int bumpIndex = Random.Range(0, bumpClip.Length);
        playerAudioSource.PlayOneShot(bumpClip[bumpIndex], (playerAudioSource.volume));
    }

    public void PlayJumpSound()

    {
        int jumpIndex = Random.Range(0, jumpClip.Length);
        playerAudioSource.PlayOneShot(jumpClip[jumpIndex], (playerAudioSource.volume));

    }
 
    public void PlayPlayerDeathSound()
    {

        DelayDeathSound(); // first dealy, then play
    }

    IEnumerator DelayDeathSound()

    {

        if (pcScript.bumpCount >= pcScript.maxBump)
        {
            yield return new WaitForSeconds(1.0f);

            // original had a 1 sec delay -  Invoke("PlayPlayDeathSound", 1.0f);

            int deathIndex = Random.Range(0, deathClip.Length);
            playerAudioSource.PlayOneShot(deathClip[deathIndex], (playerAudioSource.volume));
        }
    }

    //---------------------------------------------OBSTACLE MATERIALS-------------------------------------------

    public void PlayBarrelSound() // create condition where the player bumps into the barrel and call method from PlayerController. 

    {

        if (barrelAudioSource != null)
        {
            int barrelIndex = Random.Range(0, barrelClip.Length);
            barrelAudioSource.PlayOneShot(barrelClip[barrelIndex], (barrelAudioSource.volume));
        }

 

    }

    public void PlayBoardSound()  

    {

        int boardIndex = Random.Range(0, boardClip.Length);
        boardAudioSource.PlayOneShot(boardClip[boardIndex], (boardAudioSource.volume));

    }

    public void PlayBoxSound() 

    {
        int boxIndex = Random.Range(0, boxClip.Length);
        boxAudioSource.PlayOneShot(boxClip[boxIndex], boxAudioSource.volume);
    }

    public void PlayConeSound() 

    {
        int coneIndex = Random.Range(0, coneClip.Length);
        coneAudioSource.PlayOneShot(coneClip[coneIndex], (coneAudioSource.volume));


    }

    //-------------------------------------------HUMAN OBSTALCES-----------------------------------------------

    public void PlayFemaleSound() // create condition where the player bumps into a Female and call method from PlayerController. 

    {

        int bumpIndex = Random.Range(0, femaleGruntClip.Length);
        charecterAudioSource.PlayOneShot(femaleGruntClip[bumpIndex], (charecterAudioSource.volume));
        int tailIndex = Random.Range(0, clothFoleyTailClip.Length);
        charecterAudioSource.PlayOneShot(clothFoleyTailClip[tailIndex], (charecterAudioSource.volume));
        int transientIndex = Random.Range(0, clothFoleyTransientClip.Length);
        charecterAudioSource.PlayOneShot(clothFoleyTransientClip[transientIndex], (charecterAudioSource.volume));

    }

    public void PlayMaleSoundBump()

    {

        int bumpIndex = Random.Range(0, maleGruntClip.Length);
        charecterAudioSource.PlayOneShot(maleGruntClip[bumpIndex], (charecterAudioSource.volume));
        int tailIndex = Random.Range(0, clothFoleyTailClip.Length);
        charecterAudioSource.PlayOneShot(clothFoleyTailClip[tailIndex], (charecterAudioSource.volume));
        int transientIndex = Random.Range(0, clothFoleyTransientClip.Length);
        charecterAudioSource.PlayOneShot(clothFoleyTransientClip[transientIndex], (charecterAudioSource.volume));

    }

    public void PlayMaleTaunt()
    {

        int tauntIndex = Random.Range(0, maleTauntClip.Length);
        charecterAudioSource.PlayOneShot(maleTauntClip[tauntIndex], (charecterAudioSource.volume));

    }



    // --------------------------------------------OTHER SOUNDS (EXCEPT SIREN AND CITY AMB!)--------------------------------------------------------

    public void PlayArrest()

    {
        StartCoroutine(DelayArrest());
    }

    IEnumerator DelayArrest()

    {
        if (!arrestAudioSource.isPlaying)
        {
            yield return new WaitForSeconds(0.5f);
            arrestAudioSource.PlayOneShot(arrestClip, arrestAudioSource.volume);
        }

        // siren behaviour is player-dependent, which is why it will be called from the playerController Script (according to bump values)
    }

    public void SetLowPass(float lowpasslvl)
    {
        SirenLowPass.SetFloat("SirenLowpass", lowpasslvl);
    }

    public void SirenFarther(float lowpasslvl)

    {
        currentHz -= lowpasslvl;
        SetLowPass(currentHz);
    }


    public void SirenCloser(float lowpasslvl)

    {
        currentHz += lowpasslvl;
        SetLowPass(currentHz);
    }

    public void PlayCollectibleSound()

    { 
    
    playerAudioSource.PlayOneShot(collectibleClip,playerAudioSource.volume);
    }


}    

    

