using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{


    public GameManager GameManager;
    private Rigidbody playerRb;
    private Animator playerAnimator;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    
    public ChaseBar chaseBar;
    public float minChase = 0.0f;
    public float currentChase;

    public AudioSource playerAudioSource;



    public float jumpForce = 10;
    public float moveForce = 0.5f;
    public float turnForce = 5;
    public float bumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    public float bumpCount = 0;

    public float maxBump;
    public bool bumped;
    public bool difficultyLevel;
    public bool gameWon;
    public bool gamePaused;

    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
      
        Physics.gravity *= gravityModifier;

        currentChase = minChase;
        chaseBar.SetMinChase(minChase);
    
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
      
    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver && !gamePaused)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            AudioManager.instance.PlayJumpSound();
                

        }

        else if (Input.GetKey(KeyCode.S) && isOnGround && !gameOver && !gamePaused)
        {
            transform.Translate(Vector3.right * moveForce * Time.deltaTime);


        }
        else if (Input.GetKey(KeyCode.W) && isOnGround && !gameOver)
        {
            transform.Translate(Vector3.left * moveForce * Time.deltaTime);
        }

        else if (!gamePaused==true && Input.GetKeyDown(KeyCode.Escape))

        {

            gamePaused = true;

            GameManager.PauseGame();
        }

        else if (!gamePaused == false && Input.GetKeyDown(KeyCode.Escape))

        {

            gamePaused = false;
            GameManager.ResumeGame();

        }        

        else if (gameWon==true && isOnGround && !gameOver)
        {
            transform.Translate(Vector3.forward * moveForce * Time.deltaTime);
        } 
        

        if (transform.position.z > 4.30f)
        {

            transform.position = new Vector3(transform.position.x, transform.position.y, 4.30f);

        }
        if (transform.position.z < -2.70f)
        {

            transform.position = new Vector3(transform.position.x, transform.position.y, -2.70f);
        }
        }

    

   
  public void ChaseFarther(float chase)
    {
        currentChase -= chase;
        chaseBar.SetChase(currentChase);
    }

    public void ChaseCloser(float chase)
    {
        currentChase += chase;
        chaseBar.SetChase(currentChase);
    }




        private void OnCollisionExit(Collision collision)
        {

         StartCoroutine(BumpWait(collision));


          IEnumerator BumpWait(Collision collision)
          {

            if (collision.gameObject.CompareTag("Obstacle"))

            {

                yield return null;

            }
              yield return new WaitForSeconds(0.15f);


             playerAnimator.SetBool("Bump", false);
             bumped=false;
          }
        }
 } 
 

 















