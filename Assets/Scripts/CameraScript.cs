using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //Target for follow
    public GameObject followingObject;

    private GameObject player;

    //public GameObject player;

    //Offset, follow close or far
    public Vector3 offset;

    private float y = 8f, z = -12.3f;

    private int selectedCamera = 1;

    private float currentFieldView = 60f;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        switch (selectedCamera) 
        {
            case 1:

                if (player.GetComponent<PlayerMovement>().canGo == true)
                {
                    offset = new Vector3(5f, y, z);

                    //Make camera follow the target
                    transform.position = followingObject.transform.position + offset;

                    //We need rotation
                    transform.rotation = Quaternion.Euler(20, -14, 0);

                    //GetOffsetValue();
                }

                else
                {
                    //Make the camera look at our player and rotate around when game ended
                    GameEndedCameraMovement();
                }
                break;

            case 2:

                if (player.GetComponent<PlayerMovement>().canGo == true)
                {
                    offset = new Vector3(8f, 12, -15);

                    //Make camera follow the target
                    transform.position = followingObject.transform.position + offset;

                    //We need rotation
                    transform.rotation = Quaternion.Euler(30, -24, 0);

                    //GetOffsetValue();
                }

                else
                {
                    //Make the camera look at our player and rotate around when game ended
                    GameEndedCameraMovement();
                }
                break;

            case 3:

                if (player.GetComponent<PlayerMovement>().canGo == true)
                {
                    offset = new Vector3(3f, 10, -16);

                    //Make camera follow the target
                    transform.position = followingObject.transform.position + offset;

                    //We need rotation
                    transform.rotation = Quaternion.Euler(30, -5, 0);

                    //GetOffsetValue();
                }

                else
                {
                    //Make the camera look at our player and rotate around when game ended
                    GameEndedCameraMovement();
                }
                break;

        }
        
    }

    public void DecreaseY()
    {
        currentFieldView += 1f;

        gameObject.GetComponent<Camera>().fieldOfView = currentFieldView;
    }

    public void AddY()
    {
        currentFieldView -= 1f;

        gameObject.GetComponent<Camera>().fieldOfView = currentFieldView;
    }

    private void GameEndedCameraMovement()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        transform.LookAt(player.transform);

        transform.RotateAround(player.transform.position, Vector3.up, Time.deltaTime * 6f);
    }

    public void SetCamera(int a)
    {
        selectedCamera = a;
    }
}
