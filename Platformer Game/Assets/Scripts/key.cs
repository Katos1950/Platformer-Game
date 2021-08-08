using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    private bool isFollowing;// to know it is following the player or not

    public float followSpeed;//how fast it is following the player

    public Transform followTarget; //Object that the key should follow
    // Start is called before the first frame update
    void Start()
    {
       // isFollowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position,followTarget.position,followSpeed*Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!isFollowing)
            {
                Player thePlayer = FindObjectOfType<Player>();

                followTarget = thePlayer.keyFollowPoint;

                isFollowing = true;
            thePlayer.followingKey = this;
            }
        }
    }
}
