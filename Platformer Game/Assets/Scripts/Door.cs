using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum DoorType
{
    Teleport,
    New_Level
}

public class Door : MonoBehaviour
{
    private Player thePlayer;

    public SpriteRenderer theSR; //used for the closed door 
    public Sprite doorOpenSprite; // after using the key

    public bool doorOpen, waitingToOpen;

    //if type is teleport only then Set teleportTo variable
    [SerializeField] DoorType doorType;
    [SerializeField] Transform teleportTo;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waitingToOpen)
        {
            if(Vector3.Distance(thePlayer.followingKey.transform.position,transform.position) <0.1f)
            {
                waitingToOpen = false;
                doorOpen = true;
                theSR.sprite = doorOpenSprite;
                thePlayer.followingKey.gameObject.SetActive(false);
                thePlayer.followingKey = null;
            }
        }


        if (doorOpen)
        {
            if(doorType == DoorType.New_Level)
            {
                SceneManager.LoadScene(0);
                Debug.Log("next level");
            }
            if(doorType == DoorType.Teleport)
            {
                thePlayer.transform.position = teleportTo.position;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // make the collision between the door and key by player
    {
        if(collision.tag == "Player")
        {
            if(thePlayer.followingKey != null)
            {
                thePlayer.followingKey.followTarget = transform;
                waitingToOpen = true;
            }
        }
    }
}
