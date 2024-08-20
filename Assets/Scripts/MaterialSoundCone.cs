using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSoundCone : MonoBehaviour
{
    
    public AudioClip[] coneSound;
    private AudioSource coneAudio;
    // Start is called before the first frame update
    void Start()
    {
        coneAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int coneIndex = Random.Range(0, coneSound.Length);
            coneAudio.PlayOneShot(coneSound[coneIndex], (coneAudio.volume));
        }

        }
    }


