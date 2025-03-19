using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages stages, updating them and proceeding to the next when one finishes
/// </summary>

public class StageManager : MonoBehaviour
{
    public List<StageInfo> stages = new List<StageInfo>(); // List of stages to cycle through (in order)
    public Stage currentStage; // The current active stage

    public int StageIndex { get; private set; } // Index of the active stage

    // Start is called before the first frame update
    void Start()
    {
        currentStage = new Stage(stages[0]);
    }

    // Update is called once per frame
    void Update()
    {
        currentStage.Update();
    }
}
