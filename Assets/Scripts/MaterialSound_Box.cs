using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSound_Box : ObstacleParentScript
{

    public AudioSource boxAudioSource;

    private void Start()
    {
        if (boxAudioSource == null)
        {
            boxAudioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayBoxSound()

    {
        int boxIndex = Random.Range(0, AudioManager.instance.boxClip.Length);
        boxAudioSource.PlayOneShot(AudioManager.instance.boxClip[boxIndex], boxAudioSource.volume);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayBoxSound();
        }
    }
}
