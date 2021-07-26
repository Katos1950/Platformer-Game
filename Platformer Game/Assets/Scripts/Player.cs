using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float jumpSpeed = 100;

    Rigidbody2D rigidBody;
    Animator animator;
    bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
            animator.SetBool("Run", true);
            transform.localScale = new Vector2(1,1);
            transform.Translate(transform.right * speed * Time.deltaTime);
        }

        if (SimpleInput.GetAxis("Horizontal") < 0f)
        {
            animator.SetBool("Run", true);
            transform.localScale = new Vector2(-1,1);//inverting player
            transform.Translate(transform.right * -speed * Time.deltaTime);
        }

        if(SimpleInput.GetAxis("Vertical") > 0f && isGrounded)
        {
            animator.SetBool("Jump", true);
            rigidBody.velocity = Vector2.up * jumpSpeed * Time.fixedDeltaTime;
        }

        if(SimpleInput.GetAxis("Horizontal") == 0f && SimpleInput.GetAxis("Vertical") == 0f)
        {
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
