using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSoundBox : MonoBehaviour
{
    public AudioClip[] boxSound;
    private AudioSource boxAudio;

    // Start is called before the first frame update
    void Start()
    {
        boxAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    void Update()

    {


    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int boxIndex = Random.Range(0, boxSound.Length);
            boxAudio.PlayOneShot(boxSound[boxIndex], (boxAudio.volume));
        }
    }
}
