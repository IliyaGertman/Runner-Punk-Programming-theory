using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrestSound : MonoBehaviour
{
    
  private AudioSource arrestAudio;
    public PlayerController playerController;
    public AudioClip arrestClip;
    // Start is called before the first frame update
    void Start()
    {
        arrestAudio = GetComponent<AudioSource>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
     

    
    }

    public void PlayArrest()

    {
        StartCoroutine(DelayArrest());
    }

    IEnumerator DelayArrest()

    {
        if (!arrestAudio.isPlaying)
        {
            yield return new WaitForSeconds(0.5f);
            arrestAudio.PlayOneShot(arrestClip, arrestAudio.volume);
        }    

       
    }


    
   
}
