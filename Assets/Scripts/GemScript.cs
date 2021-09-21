using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    private GameObject gameHandler, player;

    public GameObject effect;

    private Vector3 playerDirection;

    private Rigidbody rb;

    private bool canGoMagnet = false;

    private void Awake()
    {
        player = GameObject.Find("Player");
        gameHandler = GameObject.Find("GameHandler");

        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (canGoMagnet)
        {
            GoToMagnet();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Lets check for collisions, we can take the point by colliding it with our number cubes
        if((other.gameObject.name == "Player") || (other.gameObject.name == "Two Object(Clone)") || (other.gameObject.name == "Four Object(Clone)") ||
            (other.gameObject.name == "Eight Object(Clone)") || (other.gameObject.name == "Sixteen Object(Clone)") || (other.gameObject.name == "Thirtytwo Object(Clone)") ||
            (other.gameObject.name == "Sixtyfour Object(Clone)") || (other.gameObject.name == "Onetwentyeight Object(Clone)"))
        {
            Destroy(this.gameObject);

            Instantiate(effect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

            //We have to play audio at player because, when the object (gem) is destroyed, audio source also destroyed
            //no audio source = no sound
            player.GetComponent<PlayerMovement>().coinAdd.Play();

            Debug.Log("player collided");

            gameHandler.GetComponent<GameScript>().AddPoint();
        }

        if(other.gameObject.name == "Magnet")
        {
            Debug.Log("MAGNETTTTTTTT");
            canGoMagnet = true;
        }
    }

    void GoToMagnet()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * (player.GetComponent<PlayerMovement>().speed + 4));
    }
}
