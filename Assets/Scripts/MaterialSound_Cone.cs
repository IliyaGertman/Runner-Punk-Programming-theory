using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSound_Cone : ObstacleParentScript
{

    public AudioSource coneAudioSource;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlayConeSound();
        }

        }
    }


