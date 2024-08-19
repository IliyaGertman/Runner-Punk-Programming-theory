using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject SirenSound;


    public float minChase = 0.0f;
    public float currentChase;
    public ChaseBar chaseBar;
    public SirenCloser siren;
    private AudioSource sirenVol;
    public float currentHz;
    public GameManager GameManager;
    public ArrestSound arrest;

  



    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip[] jumpSound;
    public AudioClip[] bumpSound;
    public AudioClip[] deathSound;


    public float jumpForce = 10;
    public float moveForce = 0.5f;
    public float turnForce = 5;
    public float bumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    public float bumpCount = 0;
    private Rigidbody enemyRigidbody;
    public float maxBump;
    public bool bumped;
    public bool difficultyLevel;
    public bool gameWon;
    public bool gamePaused;




    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;

        currentChase = minChase;
        chaseBar.SetMinChase(minChase);
        siren = GameObject.Find("SirenSound").GetComponent<SirenCloser>();
       
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        arrest = GameObject.Find("Arrest Sound").GetComponent<ArrestSound>();
    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver && !gamePaused)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            int jumpIndex = Random.Range(0, jumpSound.Length);
            playerAudio.PlayOneShot(jumpSound[jumpIndex], (playerAudio.volume));

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

    void PlayDeathSound()
    {
        int deathIndex = Random.Range(0, deathSound.Length);
        playerAudio.PlayOneShot(deathSound[deathIndex], (playerAudio.volume));



    }
    public void OnCollisionEnter(Collision collision)
    {


        enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        if (collision.gameObject.CompareTag("Ground"))

        {
            isOnGround = true;
            dirtParticle.Play();
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            sirenVol = siren.GetComponent<AudioSource>();
            sirenVol.volume += 0.2f;
            SirenCloser(10000 / maxBump);

            bumpCount += 1;
            ChaseCloser(100 / maxBump);
            enemyRigidbody.AddForce(Vector3.left * bumpForce, ForceMode.Impulse);

            explosionParticle.Play();

            int bumpIndex = Random.Range(0, bumpSound.Length);
            playerAudio.PlayOneShot(bumpSound[bumpIndex], (playerAudio.volume));

            playerAnim.SetBool("Bump", true);
            bumped = true;


        }



        if (bumpCount >= maxBump)
        {
            Debug.Log("You're busted!");
            gameOver = true;
        
            GameManager.GameOver();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 2);
            dirtParticle.Stop();
            Invoke("PlayDeathSound", 1.0f);
            sirenVol.volume = 0.0f;
            arrest.PlayArrest();
            bumpCount = 1;



        }

    }

    void ChaseCloser(float chase)
    {
        currentChase += chase;
        chaseBar.SetChase(currentChase);
    }

    void SirenCloser(float lowpasslvl)

    {
        currentHz += lowpasslvl;
        siren.SetLowPass(currentHz);
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


            playerAnim.SetBool("Bump", false);
          bumped=false;
        }
    }

 
 

}













