using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleBump : MonoBehaviour
{

    private AudioSource charecterAudio;
    public AudioClip[] maleTaunts;
    public AudioClip[] maleGrunts;
    public AudioClip[] clothFoleyTail;
    public AudioClip[] clothFoleyTransient;


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
            int bumpIndex = Random.Range(0, maleGrunts.Length);
            charecterAudio.PlayOneShot(maleGrunts[bumpIndex], (charecterAudio.volume));
            int tailIndex = Random.Range(0, clothFoleyTail.Length);
            charecterAudio.PlayOneShot(clothFoleyTail[tailIndex], (charecterAudio.volume));
            int transientIndex = Random.Range(0, clothFoleyTransient.Length);
            charecterAudio.PlayOneShot(clothFoleyTransient[transientIndex], (charecterAudio.volume));

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int tauntIndex = Random.Range(0, maleTaunts.Length);
            charecterAudio.PlayOneShot(maleTaunts[tauntIndex], (charecterAudio.volume));
        }
    }
}






