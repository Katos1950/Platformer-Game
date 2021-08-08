using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical; //for vertical input
    private float speed = 8f; //climbing speed
    private bool isNextToLadder; //standing next to ladder
    private bool isClimbing; // for indication of climbing 

    [SerializeField] private Rigidbody2D rb; //reference player rigidbody2D


    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (isNextToLadder && Mathf.Abs(vertical) > 0f) // is next to the ladder is true and absulute value of vertical is greater then 0
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing) //disable gravity
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 4f;
        }
    }

    //for chicking the player standing next to a ladder
    //{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isNextToLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //
    {
        if (collision.CompareTag("Ladder"))
        {
            isNextToLadder = false;
            isClimbing = false;
        }
    }

   //}
}
