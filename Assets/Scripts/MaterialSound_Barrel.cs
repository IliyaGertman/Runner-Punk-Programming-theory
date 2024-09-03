using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSound_Barrel : MonoBehaviour
{
    public AudioSource barrelAudioSource;

    // Start is called before the first frame update
    void Start()
    { }
    

    // Update is called once per frame

    void Update()

    {


    }
    void OnCollisionEnter(Collision collision)
    {
        AudioManager.instance.PlayBarrelSound();
    }
}
