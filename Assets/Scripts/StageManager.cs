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

    void StartStage(int index)
    {
        StageIndex = index;
        currentStage = new Stage(stages[index]);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartStage(0);
    }

    // Update is called once per frame
    void Update()
    {
        currentStage.Update();

        if (Time.time >= currentStage.EndTime)
        {
            int nextStage = (stages.Count <= StageIndex + 1) ? 0 : StageIndex + 1;
            //Equivalent to nextStage = StageIndex + 1; if (stages.Count <= StageIndex + 1) nextStage = 0;
            StartStage(nextStage);
        }
    }
}
