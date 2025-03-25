using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; } // game manager singleton
    public static ShipControls Input { get; private set; }
    public float scrollSpeed { get; private set; } // speed of our ship going right (everything else scrolling past it)

    public Canvas UI; // prefab for the player ship

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        Input = new ShipControls();
        TestStart();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame(GameObject MainMenu)
    {   
        MainMenu.SetActive(false);
        Input.Enable();

        scrollSpeed = 10;

    }

    public void TestStart()
    {
        Input.Enable();
        scrollSpeed = 10;
    }
}
