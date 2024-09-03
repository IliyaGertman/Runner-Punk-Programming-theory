using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleBump : ObstacleParentScript
{

    public AudioSource characterAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (characterAudioSource == null)
        {
            characterAudioSource = GetComponent<AudioSource>();
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayFemaleSound() 

    {

        int bumpIndex = Random.Range(0, AudioManager.instance.femaleGruntClip.Length);
        characterAudioSource.PlayOneShot(AudioManager.instance.femaleGruntClip[bumpIndex], (characterAudioSource.volume));
        int tailIndex = Random.Range(0, AudioManager.instance.clothFoleyTailClip.Length);
        characterAudioSource.PlayOneShot(AudioManager.instance.clothFoleyTailClip[tailIndex], (characterAudioSource.volume));
        int transientIndex = Random.Range(0, AudioManager.instance.clothFoleyTransientClip.Length);
        characterAudioSource.PlayOneShot(AudioManager.instance.clothFoleyTransientClip[transientIndex], (characterAudioSource.volume));

    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        PlayFemaleSound();
        }
    }
}