using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleBump : ObstacleParentScript
{


    public AudioSource charecterAudioSource;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlayMaleSoundBump();

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlayMaleTaunt();
        }
    }
}







