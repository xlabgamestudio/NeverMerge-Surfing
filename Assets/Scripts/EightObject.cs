using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightObject : MonoBehaviour
{
    private GameObject player, gameScript;

    private Rigidbody rb;

    //We want to grow up object scale smoothly

    float speed = 80.0f;

    Vector3 newScale = new Vector3(1, 1, 1);

    private bool unparented = false;

    void Awake()
    {
        gameScript = GameObject.Find("GameHandler");

        player = GameObject.Find("Player");

        rb = gameObject.GetComponent<Rigidbody>();

        //When object spawns, becomes the child of the player object
        this.transform.parent = player.transform;
    }

    private void Update()
    {
        Grow();

        rb.maxDepenetrationVelocity = 1.5f;
    }

    void Grow()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, newScale, speed);
        //Debug.Log("working");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((!unparented) && (collision.gameObject.name == "Obstacle1"))
        {
            unparented = true;

            gameObject.transform.parent = null;

            player.GetComponent<PlayerMovement>().SubstractToY();

            player.transform.position = player.transform.position + new Vector3(0, 0.1f, 0);

            Destroy(this.gameObject, 1f);
        }

        else if ((!unparented) && (collision.gameObject.name == "Water"))
        {
            //We need this bool to be sure that this method works once
            unparented = true;

            gameObject.transform.parent = null;

            player.GetComponent<PlayerMovement>().SubstractToY();

            player.transform.position = player.transform.position + new Vector3(0, 0.6f, 0);

            Destroy(this.gameObject, 1f);
        }

        else if ((!unparented) && (collision.gameObject.name == "Leave Cube"))
        {
            //We need this bool to be sure that this method works once
            unparented = true;

            gameObject.transform.parent = null;

            player.GetComponent<PlayerMovement>().SubstractToY();

            player.transform.position = player.transform.position + new Vector3(0, 0.6f, 0);

            Destroy(this.gameObject, 1f);
        }

        else if ((!unparented) && (collision.gameObject.name == "High End"))
        {
            Destroy(this.gameObject, 1f);

            player.GetComponent<PlayerMovement>().StopPlayer(200);
        }

        else if (collision.gameObject.name == "Ground")
        {
            player.GetComponent<PlayerMovement>().SetTrail(3);
        }

        else if (collision.gameObject.name == "Collectable Magnet")
        {
            player.GetComponent<PlayerMovement>().MagnetEnabled();

            Destroy(collision.gameObject);
        }
    }
}
