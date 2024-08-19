using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSoundBarrel : MonoBehaviour
{
    public AudioClip[] barrelSound;
    private AudioSource barrelAudio;

    // Start is called before the first frame update
    void Start()
    {
        barrelAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    void Update()

    {


    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int barrelIndex = Random.Range(0, barrelSound.Length);
            barrelAudio.PlayOneShot(barrelSound[barrelIndex], (barrelAudio.volume));
        }
    }
}
