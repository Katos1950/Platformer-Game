using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Slider : MonoBehaviour
{
    [SerializeField] Vector2 movementVector = new Vector2(10f, 10f);
    [SerializeField] float period = 2f;
    float movementFactor;

    private GameObject target = null;
    private Vector3 offset;

    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;//grows continuously from 0
        const float TAU = Mathf.PI * 2f; // around 6.28
        float rawSinWave = Mathf.Sin(cycles * TAU);//goes from -1 to 1

        movementFactor = rawSinWave + 0.5f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startPos + offset;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            
            collision.gameObject.transform.parent = gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.transform.parent = null;
        }
    }
    /*void OnTriggerStay2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            target = col.gameObject;
            offset = target.transform.position - transform.position;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        target = null;
    }
    void LateUpdate()
    {
        if (target != null)
        {
            target.transform.position = transform.position + offset;
        }

    }*/
}

