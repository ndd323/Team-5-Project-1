using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static ShipControls Input { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Input = new ShipControls();
        Input.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
