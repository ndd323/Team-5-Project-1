using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains info related to a spawn prefab for stages
/// </summary>

[CreateAssetMenu(fileName = "New Spawn", menuName = "ScriptableObjects/SpawnSettings")]
public class SpawnSettings : ScriptableObject
{
    public GameObject spawnPrefab; // The prefab we're going to spawn
    public AnimationCurve spawnCurve; // Where on the right side (bottom to top) should we possibly spawn?
    public AnimationCurve spawnChance; // Spawn chance (y-axis) based on the stage progress (x-axis)
    public bool pauseProgress; // Will this spawn pause stage progress (alongside additional spawn checks) until triggered to unpause?
    public bool stopOtherSpawns; // Does this spawn prevent other spawns alongside it?
}
