using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSoundBoard : MonoBehaviour
{
  public AudioClip[] boardSound;
  private AudioSource boardAudio;

    // Start is called before the first frame update
    void Start()
    {
       boardAudio = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame

    void Update()

    {

       
    }
    void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.CompareTag("Player"))
            {
                int boardIndex = Random.Range(0, boardSound.Length);
             boardAudio.PlayOneShot(boardSound[boardIndex], (boardAudio.volume));
            }
        }
}






