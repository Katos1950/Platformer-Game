using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Death");
        }
    }
}
