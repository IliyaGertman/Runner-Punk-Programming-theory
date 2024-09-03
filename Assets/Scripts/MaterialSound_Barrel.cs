using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSound_Barrel : MonoBehaviour
{
    public AudioSource barrelAudioSource;

    // Start is called before the first frame update
    void Start()
    {

        if (barrelAudioSource == null)
        {
           barrelAudioSource = GetComponent<AudioSource>();
        }
    }
    

    // Update is called once per frame

    void Update()

    {


    }

    public void PlayBarrelSound() // create condition where the player bumps into the barrel and call method from PlayerController. 

    {

        if (barrelAudioSource != null)
        {
            int barrelIndex = Random.Range(0, AudioManager.instance.barrelClip.Length);
            barrelAudioSource.PlayOneShot(AudioManager.instance.barrelClip[barrelIndex], (barrelAudioSource.volume));
        }



    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayBarrelSound(); 
        }
           
    }
}
