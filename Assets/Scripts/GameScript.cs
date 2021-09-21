using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    //UI game objects
    public GameObject UI, tapToPlay, player, winScreen, loseScreen;

    //UI elements
    public TextMeshProUGUI gemText, comboText, finalGemText;

    private float point = 0, speed;

    //All the obstacles in the game
    public GameObject[] obstacles;

    //For camera
    public GameObject mainCamera;

    //For speed settings
    public Text speedText;

    private void Awake()
    {
        speed = 10f;

        speedText.text = "10";

        mainCamera = GameObject.Find("Main Camera");
    }

    public void StartGame()
    {
        player.GetComponent<PlayerMovement>().speed = speed;
        gemText.text = point.ToString();
    }

    public void AddPoint()
    {
        point += 2;
        gemText.text = point.ToString();
        Debug.Log("added " + point);
    }

    public void WinGame(int a)
    {
        winScreen.SetActive(true);
        UI.SetActive(false);

        comboText.text = "x" + a.ToString();

        finalGemText.text = (point * a).ToString();

        Debug.Log("point is multipyled by " + a + " and new score is " + a * point);
    }

    public void LostGame()
    {
        loseScreen.SetActive(true);
        UI.SetActive(false);
    }

    public void RestartGame()
    {
        //Restart the game here
        SceneManager.LoadScene(0);
    }

    //////////////////////////////////////////////DEBUG MENU FUNCTIONS///////////////////////////////////////////

    //Obstacle settings
    public void SetFewObject()
    {
        //No need an auto system for this
        obstacles[0].SetActive(false);
        obstacles[1].SetActive(true);
        obstacles[2].SetActive(false);
        obstacles[3].SetActive(false);
        obstacles[4].SetActive(false);
        obstacles[5].SetActive(true);
        obstacles[6].SetActive(false);
        obstacles[7].SetActive(false);
        obstacles[8].SetActive(false);
        obstacles[9].SetActive(true);
        obstacles[10].SetActive(false);
        obstacles[11].SetActive(true);
        obstacles[12].SetActive(false);
        obstacles[13].SetActive(false);
        obstacles[14].SetActive(true);
        obstacles[15].SetActive(false);
        obstacles[16].SetActive(false);
        obstacles[17].SetActive(false);
        obstacles[18].SetActive(true);
        obstacles[19].SetActive(false);
        obstacles[20].SetActive(false);
    }

    public void SetNormalObject()
    {
        obstacles[0].SetActive(true);
        obstacles[1].SetActive(true);
        obstacles[2].SetActive(false);
        obstacles[3].SetActive(false);
        obstacles[4].SetActive(true);
        obstacles[5].SetActive(true);
        obstacles[6].SetActive(true);
        obstacles[7].SetActive(false);
        obstacles[8].SetActive(false);
        obstacles[9].SetActive(true);
        obstacles[10].SetActive(true);
        obstacles[11].SetActive(true);
        obstacles[12].SetActive(true);
        obstacles[13].SetActive(true);
        obstacles[14].SetActive(true);
        obstacles[15].SetActive(true);
        obstacles[16].SetActive(false);
        obstacles[17].SetActive(true);
        obstacles[18].SetActive(true);
        obstacles[19].SetActive(true);
        obstacles[20].SetActive(false);
    }

    public void SetMuchObject()
    {
        obstacles[0].SetActive(true);
        obstacles[1].SetActive(true);
        obstacles[2].SetActive(true);
        obstacles[3].SetActive(true);
        obstacles[4].SetActive(true);
        obstacles[5].SetActive(true);
        obstacles[6].SetActive(true);
        obstacles[7].SetActive(true);
        obstacles[8].SetActive(true);
        obstacles[9].SetActive(true);
        obstacles[10].SetActive(true);
        obstacles[11].SetActive(true);
        obstacles[12].SetActive(true);
        obstacles[13].SetActive(true);
        obstacles[14].SetActive(true);
        obstacles[15].SetActive(true);
        obstacles[16].SetActive(true);
        obstacles[17].SetActive(true);
        obstacles[18].SetActive(true);
        obstacles[19].SetActive(true);
        obstacles[20].SetActive(true);
    }


    //Speed settings
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;

        speedText.text = speed.ToString();

        Debug.Log("Speed changed: " + speed);
    }

    //Camera settings
    public void SetCameraPosOne()
    {
        mainCamera.GetComponent<CameraScript>().SetCamera(1);
    }

    public void SetCameraPosTwo()
    {
        mainCamera.GetComponent<CameraScript>().SetCamera(2);
    }

    public void SetCameraPosThree()
    {
        mainCamera.GetComponent<CameraScript>().SetCamera(3);
    }
}
