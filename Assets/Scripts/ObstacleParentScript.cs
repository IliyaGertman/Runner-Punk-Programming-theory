using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleParentScript : MonoBehaviour
{
    public PlayerController pcScript;
    private Rigidbody obstacleRigidbody;
    private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        //siren = siren.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //since we're colliding with other objects, this script probably neds to be put on the player, alongside PlayerController. 
    public void OnCollisionEnter(Collision collision)
    {
      

        obstacleRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        if (collision.gameObject.CompareTag("Ground"))

        {
            pcScript.isOnGround = true;
            pcScript.dirtParticle.Play();
        }

        else if (collision.gameObject.CompareTag("Obstacle"))


        {

          AudioManager.instance.sirenAudioSource.volume += 0.2f;
          AudioManager.instance.SirenCloser(10000 / pcScript.maxBump);

            pcScript.bumpCount += 1;
            pcScript.ChaseCloser(100 / pcScript.maxBump);
            obstacleRigidbody.AddForce(Vector3.left * pcScript.bumpForce, ForceMode.Impulse);

            pcScript.explosionParticle.Play();

            AudioManager.instance.PlayCollectibleSound();

            playerAnimator.SetBool("Bump", true);
            pcScript.bumped = true;

        }

    
        else if (collision.gameObject.CompareTag("Collectible"))
       
        {
            Debug.Log("Bottle Pickup");
            AudioManager.instance.sirenAudioSource.volume -= 0.2f;
            AudioManager.instance.SirenFarther(10000 / pcScript.maxBump);
            pcScript.bumpCount -= 1;
            pcScript.ChaseFarther(100 / pcScript.maxBump);

             Destroy(collision.gameObject);





        }
        
         if (pcScript.bumpCount >= pcScript.maxBump)
         {
          Debug.Log("You're busted!");
          pcScript.gameOver = true;

         GameManager.instance.GameOver();
         playerAnimator.SetBool("Death_b", true);
         playerAnimator.SetInteger("DeathType_int", 2);
         pcScript.dirtParticle.Stop();

         AudioManager.instance.sirenAudioSource.volume = 0.0f;
         AudioManager.instance.PlayArrest();
         pcScript.bumpCount = 1;



         }



    }
}



