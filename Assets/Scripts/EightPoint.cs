using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightPoint : MonoBehaviour
{
    private GameObject player;

    public GameObject EightObject;

    private float availableY;

    private bool dontCollide;

    private float totalTime = 1f;

    private void Awake()
    {
        //Find the player
        player = GameObject.Find("Player");

    }

    private void Update()
    {
        //Find the available Y position to spawn another "four object"
        availableY = player.GetComponent<PlayerMovement>().availableY;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && !dontCollide)
        {
            dontCollide = true;

            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1f,
                player.transform.position.z);

            Instantiate(EightObject, new Vector3(player.transform.position.x, player.transform.position.y - availableY,
                player.transform.position.z), Quaternion.identity);

            player.GetComponent<PlayerMovement>().AddToY();

            Debug.Log("8 collided with Player");

            Destroy(this.gameObject);
        }

        else if (other.gameObject.name == "Two Object(Clone)" && !dontCollide)
        {
            dontCollide = true;

            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1f,
                player.transform.position.z);

            Instantiate(EightObject, new Vector3(player.transform.position.x, player.transform.position.y - availableY,
                player.transform.position.z), Quaternion.identity);

            player.GetComponent<PlayerMovement>().AddToY();

            //Debug.Log("collided with Two Object");

            Destroy(this.gameObject);

            Timer();
        }

        else if (other.gameObject.name == "Four Object(Clone)" && !dontCollide)
        {
            dontCollide = true;

            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1f,
                player.transform.position.z);

            Instantiate(EightObject, new Vector3(player.transform.position.x, player.transform.position.y - availableY,
                player.transform.position.z), Quaternion.identity);

            player.GetComponent<PlayerMovement>().AddToY();

            //Debug.Log("collided with Four Object");

            Destroy(this.gameObject);

            Timer();
        }

        else if (other.gameObject.name == "Eight Object(Clone)")
        {
            //If we dont do this, still collides and spawns a "two object"
            dontCollide = true;

            //Debug.Log("collided with Four Object");

            //Substract the availableY 
            player.GetComponent<PlayerMovement>().SubstractToY();

            //Destroy point and "four object"
            Destroy(other.gameObject);
            other.gameObject.transform.parent = null;
            Destroy(this.gameObject);

            //Set timer, that way we can set dontCollide false again after x seconds
            Timer();
        }

        else if (other.gameObject.name == "Sixteen Object(Clone)" && !dontCollide)
        {
            dontCollide = true;

            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1f,
                player.transform.position.z);

            Instantiate(EightObject, new Vector3(player.transform.position.x, player.transform.position.y - availableY,
                player.transform.position.z), Quaternion.identity);

            player.GetComponent<PlayerMovement>().AddToY();

            //Debug.Log("collided with Four Object");

            Destroy(this.gameObject);

            Timer();
        }

        else if (other.gameObject.name == "Thirtytwo Object(Clone)" && !dontCollide)
        {
            dontCollide = true;

            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1f,
                player.transform.position.z);

            Instantiate(EightObject, new Vector3(player.transform.position.x, player.transform.position.y - availableY,
                player.transform.position.z), Quaternion.identity);

            player.GetComponent<PlayerMovement>().AddToY();

            //Debug.Log("collided with Four Object");

            Destroy(this.gameObject);

            Timer();
        }

        else if (other.gameObject.name == "Sixtyfour Object(Clone)" && !dontCollide)
        {
            dontCollide = true;

            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1f,
                player.transform.position.z);

            Instantiate(EightObject, new Vector3(player.transform.position.x, player.transform.position.y - availableY,
                player.transform.position.z), Quaternion.identity);

            player.GetComponent<PlayerMovement>().AddToY();

            //Debug.Log("collided with Four Object");

            Destroy(this.gameObject);

            Timer();
        }

        else if (other.gameObject.name == "Onetwentyeight Object(Clone)" && !dontCollide)
        {
            dontCollide = true;

            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1f,
                player.transform.position.z);

            Instantiate(EightObject, new Vector3(player.transform.position.x, player.transform.position.y - availableY,
                player.transform.position.z), Quaternion.identity);

            player.GetComponent<PlayerMovement>().AddToY();

            //Debug.Log("collided with Four Object");

            Destroy(this.gameObject);

            Timer();
        }
    }

    void Timer()
    {
        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
        }

        else
        {
            dontCollide = false;
        }
    }
}
