using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public Rigidbody2D playerRb;
    public float jumpSpeed = 8f;
    private bool isGrounded;
    private float direction = 0f;
    private float speed = 8f;
    public bool isFacingRight;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        playerRb = GetComponent<Rigidbody2D>();
        gameObject.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");


        if (direction > 0f)
        {
            playerRb.velocity = new Vector2(direction * speed, playerRb.velocity.y);

        }
        else if (direction < 0f)
        {
            playerRb.velocity = new Vector2(direction * speed, playerRb.velocity.y);

        }
        else
        {
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpSpeed);
        }
        Flip();

        if (isFacingRight)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (!isFacingRight)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("Ground", true);
        }

        if (other.gameObject.CompareTag("LvlSpawner"))
        {
            SceneManager.LoadScene("Lvl2");
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("Ground", false);
        }
    }
        private void Flip()
        {
        
        if (Input.GetAxisRaw("Horizontal") > 0.5)
        {
            isFacingRight = true;
            animator.SetBool("Stop", false);
        }
        else
        {
            animator.SetBool("Stop", true);
        }
        if (Input.GetAxisRaw("Horizontal") < -0.5)
        {
            isFacingRight = false;
            animator.SetBool("Stop", false);
        }
        
    }
}
