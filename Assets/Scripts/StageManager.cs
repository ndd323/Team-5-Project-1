using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public List<StageInfo> stages = new List<StageInfo>();
    public Stage currentStage;

    public int StageIndex { get; private set; }

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
