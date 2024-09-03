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

    

