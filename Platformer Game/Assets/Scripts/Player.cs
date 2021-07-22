using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float jumpSpeed = 100;

    Rigidbody2D rigidBody;
    bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if(SimpleInput.GetAxis("Horizontal") > 0f)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        if (SimpleInput.GetAxis("Horizontal") < 0f)
        {
            transform.Translate(transform.right * -speed * Time.deltaTime);
        }
        if(SimpleInput.GetAxis("Vertical") > 0f && isGrounded)
        {
            rigidBody.velocity = Vector2.up * jumpSpeed * Time.fixedDeltaTime;
            //rigidBody.AddForce(Vector2.up * jumpSpeed * Time.deltaTime,ForceMode2D.Force);
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
