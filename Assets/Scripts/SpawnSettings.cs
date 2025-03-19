using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spawn", menuName = "ScriptableObjects/SpawnSettings")]
public class SpawnSettings : ScriptableObject
{
    public GameObject spawnPrefab;
    public AnimationCurve spawnCurve; // where on the right side (bottom to top) should we possibly spawn?
    public AnimationCurve spawnChance; // spawn chance based on the stage progress
    public bool pauseProgress;
    public bool stopOtherSpawns;
}
