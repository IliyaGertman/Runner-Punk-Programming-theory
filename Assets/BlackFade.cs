
using UnityEngine;

public class BlackFade : MonoBehaviour
{
    public Animator animator;
    public PlayerController playerController;
    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (playerController.gameOver == true)

        {

            FadeToLevel();
        }                
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");

    }    
}
