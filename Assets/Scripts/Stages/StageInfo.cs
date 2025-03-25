using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains the info related to a particular stage
/// </summary>

[CreateAssetMenu(fileName = "New Stage", menuName = "ScriptableObjects/StageInfo")]
public class StageInfo : ScriptableObject
{
    public List<SpawnSettings> spawns = new List<SpawnSettings>(); // All the spawn settings for this stage
    public AnimationCurve entityAmountCurve = new AnimationCurve(); // Curve that decides how many entities can exist (y-axis) according to the progress level (x-axis) of the stage
    public int stageLength = 60; // Time a stage lasts (without special encounter/boss pauses)
    public float stageSpawnTimeMod = 1f; // Multiplier for the stage spawn check time
    public Color stageColor;

    // GOTO add background and detail settings
}
