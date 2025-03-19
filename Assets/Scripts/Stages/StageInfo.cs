using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stage", menuName = "ScriptableObjects/StageInfo")]
public class StageInfo : ScriptableObject
{
    public List<SpawnSettings> spawns = new List<SpawnSettings>();
    public AnimationCurve entityAmountCurve = new AnimationCurve();
    public int stageLength = 60; // time a stage lasts (without special encounter/boss pauses)

    // GOTO add background and detail settings
}
