using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleBump : ObstacleParentScript
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

    public void PlayMaleSoundBump()

    {

        int bumpIndex = Random.Range(0, AudioManager.instance.maleGruntClip.Length);
        characterAudioSource.PlayOneShot(AudioManager.instance.maleGruntClip[bumpIndex], (characterAudioSource.volume));
        int tailIndex = Random.Range(0, AudioManager.instance.clothFoleyTailClip.Length);
        characterAudioSource.PlayOneShot(AudioManager.instance.clothFoleyTailClip[tailIndex], (characterAudioSource.volume));
        int transientIndex = Random.Range(0, AudioManager.instance.clothFoleyTransientClip.Length);
        characterAudioSource.PlayOneShot(AudioManager.instance.clothFoleyTransientClip[transientIndex], (characterAudioSource.volume));

    }


    public void PlayMaleTaunt()
    {

        int tauntIndex = Random.Range(0, AudioManager.instance.maleTauntClip.Length);
        characterAudioSource.PlayOneShot(AudioManager.instance.maleTauntClip[tauntIndex], (characterAudioSource.volume));

    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayMaleSoundBump();

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           PlayMaleTaunt();
        }
    }
}







