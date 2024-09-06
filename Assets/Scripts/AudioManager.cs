using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public PlayerController pcScript;

    //player related-audio object declarations
    public AudioSource playerAudioSource;

    public AudioClip[] jumpClip;
    public AudioClip[] deathClip;
    public AudioClip[] winClip;
    public AudioClip[] bumpClip;
    public AudioClip collectibleClip;


    //obstacle-related-audio object declarations - there's a chance you'd want to have the audio source on the object itself, and call it from here (for distance and panning)
   // 

    public AudioClip[] barrelClip;
    public AudioClip[] boardClip;
    public AudioClip[] coneClip;
    public AudioClip[] boxClip;

    //people (character-related audio object declaration)

  
    public AudioClip[] maleTauntClip;
    public AudioClip[] maleGruntClip;
    public AudioClip[] femaleGruntClip;
    public AudioClip[] clothFoleyTransientClip;
    public AudioClip[] clothFoleyTailClip;


    //Other SFX declarations

    public AudioSource arrestAudioSource;
    public AudioMixer sirenLowPass; // accessed through UnityEngine.Audio

    public float currentHz;
    public AudioClip arrestClip;
    public AudioSource sirenAudioSource;
    public AudioSource musicPlayer;
    private float initialMusicVolume;


    private void Awake() //made a static instance of this script since it's the global audio-handler. Reference it as such in PlayerController.
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance!=this)
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();


        {
            AssignPlayerAudioSource();
            SceneManager.sceneLoaded += OnSceneLoaded; // Add listener for scene loaded
        }

        arrestAudioSource = GetComponent<AudioSource>();
        sirenAudioSource = GameObject.Find("SirenSound").GetComponent<AudioSource>();

   
        sirenAudioSource.volume = 0.0f;
        currentHz = 0.0f;

        SetLowPass(currentHz);  // Set initial filter frequency

        musicPlayer = GameObject.Find("Music Player").GetComponent<AudioSource>();
        initialMusicVolume = musicPlayer.volume;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignPlayerAudioSource(); // Reassign the audio source when a scene is loaded

        sirenAudioSource.volume = 0.0f;
        currentHz = 0.0f;

        SetLowPass(currentHz);
        musicPlayer.volume = initialMusicVolume;
        StopAllCoroutines();


    }

    private void AssignPlayerAudioSource()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            playerAudioSource = player.GetComponent<AudioSource>();
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

        StartCoroutine(DelayDeathSound()); // first dealy, then play
    }

    IEnumerator DelayDeathSound()

    {

      
            yield return new WaitForSeconds(1.0f);

            // original had a 1 sec delay -  Invoke("PlayPlayDeathSound", 1.0f);

            int deathIndex = Random.Range(0, deathClip.Length);
            playerAudioSource.PlayOneShot(deathClip[deathIndex], (playerAudioSource.volume));
        
    }
    public void PlayWinSound()

    {
     

            int winIndex = Random.Range(0, winClip.Length);
            playerAudioSource.PlayOneShot(winClip[winIndex], (playerAudioSource.volume));
      

    }
    

   

    // Obstacle sound methods are called from the GameObjects themselves, clips are stored here. Centralized approach is not useful when spawning and destroying is happening frequently - AudioManager will call on AudioSources attached to the destroyed (outdated) objects. 



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
        sirenLowPass.SetFloat("sirenLowpass", lowpasslvl);
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

    public void MusicFadeOut(float fadeDuration)

    {

        StartCoroutine(FadeOutCoroutine(fadeDuration));

    }



    private IEnumerator FadeOutCoroutine(float fadeDuration)
    {
        // Store the original volume of the audio source
        float startVolume = musicPlayer.volume;

        // Gradually decrease the volume over time
        while (musicPlayer.volume > 0)
        {
            musicPlayer.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        // Ensure the audio source stops playing completely when volume reaches zero
       musicPlayer.Stop();
      musicPlayer.volume = initialMusicVolume; ; // Reset volume to the original level for future use
    }

  
}    

    

