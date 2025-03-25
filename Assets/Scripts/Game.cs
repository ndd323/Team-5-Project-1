using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; } // game manager singleton
    public static ShipControls Input { get; private set; }
    public float scrollSpeed { get; private set; } // speed of our ship going right (everything else scrolling past it)

    public GameObject playerPrefab;

    public GameObject deathScreen;

    public GameObject HUD;

    public float highScore = 0f;
    public TMPro.TextMeshProUGUI highScoreText;
    public TMPro.TextMeshProUGUI mainMenuText;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        Input = new ShipControls();
        //TestStart();

    }

    public void UpdateScore(float score)
    {
        if (score > highScore) highScore = score;
        highScoreText.text = highScore.ToString();
        mainMenuText.text = highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame(GameObject MainMenu)
    {   
        //start the player at the start position
        MainMenu.SetActive(false);
        Input.Enable();
        scrollSpeed = 10;
        HUD.SetActive(true);

    }

    public void TestStart()
    {
        Input.Enable();
        scrollSpeed = 10;
    }
    
    public void endGame()
    {
        Input.Disable();
        HUD.SetActive(false);
        deathScreen.SetActive(true);
        UpdateScore(playerPrefab.GetComponentInChildren<ShipController>().player_score);
    }

    public void restartGame()
    {
        deathScreen.SetActive(false);        
        // run the player start function again
        Input.Enable();
        HUD.SetActive(true);
        playerPrefab.GetComponentInChildren<ShipController>().restartGame();


    }

    public void gotomainMenu()
    {
        deathScreen.SetActive(false);
        HUD.SetActive(false);
        Input.Disable();
    }
}
