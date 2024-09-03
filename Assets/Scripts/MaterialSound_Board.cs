using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSound_Board : ObstacleParentScript
{
    public AudioSource boardAudioSource;

    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlayBoardSound();

        }
    }
}
