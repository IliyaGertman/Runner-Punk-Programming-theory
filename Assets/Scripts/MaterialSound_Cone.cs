using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSound_Cone : ObstacleParentScript
{

    public AudioSource coneAudioSource;


    private void Start()
    {
        if (coneAudioSource == null)
        {
            coneAudioSource = GetComponent<AudioSource>();
        }
    }
    public void PlayConeSound()

    {
        int coneIndex = Random.Range(0, AudioManager.instance.coneClip.Length);
        coneAudioSource.PlayOneShot(AudioManager.instance.coneClip[coneIndex], (coneAudioSource.volume));


        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayConeSound();
            }


        }

    }

}


