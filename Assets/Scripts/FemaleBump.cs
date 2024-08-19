using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleBump : MonoBehaviour
{
    public AudioClip[] femaleGrunts;
    public AudioClip[] clothFoleyTail;
    public AudioClip[] clothFoleyTransient;

    private AudioSource charecterAudio;
    // Start is called before the first frame update
    void Start()
    {
        charecterAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int bumpIndex = Random.Range(0, femaleGrunts.Length);
            charecterAudio.PlayOneShot(femaleGrunts[bumpIndex], (charecterAudio.volume));
            int tailIndex = Random.Range(0, clothFoleyTail.Length);
            charecterAudio.PlayOneShot(clothFoleyTail[tailIndex], (charecterAudio.volume));
            int transientIndex = Random.Range(0, clothFoleyTransient.Length);
            charecterAudio.PlayOneShot(clothFoleyTransient[transientIndex], (charecterAudio.volume));
        }
    }
}