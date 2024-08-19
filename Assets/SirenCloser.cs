using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SirenCloser : MonoBehaviour
    


{
    public AudioMixer SirenLowPass; 
    private AudioSource sirenSound;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {


        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        sirenSound = gameObject.GetComponent<AudioSource>();
        sirenSound.volume = 0.1f;
        SetLowPass(0.0f);

    }

    public void SetLowPass(float lowpasslvl)
    {
        SirenLowPass.SetFloat("SirenLowpass", lowpasslvl); 
    }
}

    // Update is called once per frame


