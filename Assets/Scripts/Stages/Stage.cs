using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : ScriptableObject
{
    public List<ScriptableObject> spawns = new List<ScriptableObject>();
    public AnimationCurve entityAmountCurve = new AnimationCurve();
    public int stageLength = 60; // time a stage lasts (without special encounter/boss pauses)
}
