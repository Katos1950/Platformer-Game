using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float jumpSpeed = 100;
    [SerializeField] AudioClip runClip;
    [SerializeField] AudioClip jumpClip;
    Rigidbody2D rigidBody;
    Animator animator;
    public AudioSource audioSource;

    bool isGrounded = false;

    public Transform keyFollowPoint;
    public key followingKey;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement and animation
        if(isGrounded)
        {
            animator.SetBool("Jump", false);
        }

        if (SimpleInput.GetAxis("Horizontal") > 0f)
        {
            if (!audioSource.isPlaying && animator.GetBool("Run") && isGrounded)
            {
                audioSource.clip = runClip;
                audioSource.Play();
            }
            animator.SetBool("Run", true);
            transform.localScale = new Vector2(1,1);
            transform.Translate(transform.right * speed * Time.deltaTime);
        }

        if (SimpleInput.GetAxis("Horizontal") < 0f)
        {
            if (!audioSource.isPlaying && animator.GetBool("Run") && isGrounded)
            {
                audioSource.clip = runClip;
                audioSource.Play();
            }
           animator.SetBool("Run", true);
            transform.localScale = new Vector2(-1,1);//inverting player
            transform.Translate(transform.right * -speed * Time.deltaTime);
        }

        if(SimpleInput.GetAxis("Vertical") > 0f && isGrounded)
        {
            animator.SetBool("Jump", true);
            audioSource.clip = jumpClip;
            audioSource.Play();
            rigidBody.velocity = Vector2.up * jumpSpeed * Time.fixedDeltaTime;
        }

        if(SimpleInput.GetAxis("Horizontal") == 0f && SimpleInput.GetAxis("Vertical") == 0f)
        {
            audioSource.clip = null;
            animator.SetBool("Run", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
