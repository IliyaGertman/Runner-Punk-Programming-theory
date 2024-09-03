using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSound_Board : ObstacleParentScript
{
    public AudioSource boardAudioSource;

    // Start is called before the first frame update

    private void Start()
    {
        if (boardAudioSource == null)
        {
            boardAudioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayBoardSound()

    {

        int boardIndex = Random.Range(0, AudioManager.instance.boardClip.Length);
        boardAudioSource.PlayOneShot(AudioManager.instance.boardClip[boardIndex], (boardAudioSource.volume));

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        
            PlayBoardSound();

        }
    }
}
