using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0f, currentX = 0f;

    private Rigidbody rb;

    private GameObject cam, gameScript;

    public GameObject magnet;

    public bool canGo = true;

    public float availableY;

    public string lastTakenObject;

    public AudioSource cubeAdd, cubeSubstract, coinAdd;

    public Material[] trialColors;

    public TrailRenderer line;

    private void Awake()
    {
        //Get the rigidbody
        rb = gameObject.GetComponent<Rigidbody>();

        //Get the camera
        cam = GameObject.Find("Main Camera");;

        //Find the main game script handler
        gameScript = GameObject.Find("GameHandler");

        line.material = trialColors[0];

        availableY = 1f;

        //Debug.Log("child count : " + gameObject.transform.childCount);
    }

    private void Update()
    {
        Go();
    }

    //*********************************MOVEMENT************************************
    private void Go()
    {
        //Make player go 
        transform.position = transform.position + new Vector3(0, 0, speed * Time.deltaTime);

        //This line makes player dont jump
        rb.maxDepenetrationVelocity = 1.5f;
    }

    public void AddToY()
    {
        availableY += 1f;

        //Set camera position 
        cam.GetComponent<CameraScript>().DecreaseY();

        //Move line effect little bit down
        line.transform.position = line.transform.position - new Vector3(0, 1f, 0);

        //Play the effect
        cubeAdd.Play();

        Debug.Log("Y added : " + availableY);
    }

    public void SubstractToY()
    {
        availableY -= 1f;

        //Set camera position
        cam.GetComponent<CameraScript>().AddY();

        line.transform.position = line.transform.position + new Vector3(0, 1f, 0);

        rb.velocity = Vector3.zero;

        cubeSubstract.Play();

        Debug.Log("Y substracted : " + availableY);
    }

    //********************************CONTROLS*************************************
    public void ChangeX(float x)
    {
        if (canGo)
        {
            //this lerp func. makes object do not teleport, without it if you suddenly change the pointer
            //player teleports the position
            currentX = Mathf.Lerp(currentX, x, 0.1f);

            transform.position = new Vector3(currentX, transform.position.y, transform.position.z);
        }
    }

    //********************************TRAIL**************************************

    public void SetTrail(int a)
    {
        //Debug.Log("child count : " + gameObject.transform.childCount);
        
        if (gameObject.transform.childCount <= 4)
        {
            a = 0;
            line.material = trialColors[a];
        }

        else
        {
            line.material = trialColors[a];
        }
    }

    //********************************COLLISION**************************************

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            SetTrail(0);
        }

        else if((collision.gameObject.name == "Obstacle1") || (collision.gameObject.name == "Water"))
        {
            speed = 0f;
            canGo = false;

            gameScript.GetComponent<GameScript>().LostGame();
        }

        else if (collision.gameObject.name == "End Two")
        {
            //Debug.Log("collided 2");
            StopPlayer(2);
        }

        else if (collision.gameObject.name == "End Four")
        {
            //Debug.Log("collided 4");
            StopPlayer(4);
        }

        else if (collision.gameObject.name == "End Eight")
        {
            //Debug.Log("collided 8");
            StopPlayer(8);
        }

        else if (collision.gameObject.name == "End Sixteen")
        {
            //Debug.Log("collided 16");
            StopPlayer(16);
        }

        else if (collision.gameObject.name == "End Thirtytwo")
        {
            //Debug.Log("collided 32");
            StopPlayer(32);
        }

        else if (collision.gameObject.name == "End Sixtyfour")
        {
            //Debug.Log("collided 64");
            StopPlayer(64);
        }

        else if (collision.gameObject.name == "End Onetwentyeight")
        {
            //Debug.Log("collided 128");
            StopPlayer(128);
        }

        else if (collision.gameObject.name == "High End")
        {
            //Debug.Log("collided High end");
            StopPlayer(200);
        }
    }

    //*******************************METHODS************************************
    public void StopPlayer(int a)
    {
        gameScript.GetComponent<GameScript>().WinGame(a);

        //We have to stop the player at the end and calculate the score
        speed = 0f;
        canGo = false;

        gameObject.GetComponent<Rigidbody>().freezeRotation = true;
    }

    public void MagnetEnabled()
    {
        magnet.SetActive(true);
    }
}
