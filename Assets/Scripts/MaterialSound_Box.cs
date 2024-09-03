using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSound_Box : ObstacleParentScript
{

    public AudioSource boxAudioSource;


    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlayBoxSound();
        }
    }
}
