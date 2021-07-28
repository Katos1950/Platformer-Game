using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Waypoint Variables
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] float speed = 1f;
    int currentPatrolPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Waypoint System
        if (patrolPoints.Length == 0) return;

        Vector2 direction = patrolPoints[currentPatrolPoint].position - transform.position;
        
        //Face enemy towards the destiation
        if(direction.x > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }
        //Face enemy towards the destiation END


        if (direction.magnitude <= 1f)
        {
            currentPatrolPoint++;
            if(currentPatrolPoint >= patrolPoints.Length)
            {
                currentPatrolPoint = 0;
            }
        }
        transform.Translate(new Vector2(direction.normalized.x * speed * Time.deltaTime,0f));
        //Waypoint System End
    }
}
