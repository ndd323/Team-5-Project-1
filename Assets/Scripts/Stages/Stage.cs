using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that handles the active stage effects, such as spawning enemies, powerups, and environment details
/// </summary>

public class Stage
{
    private float spawnTryTime;
    private float spawnDoTime;
    private Queue<SpawnSettings> spawnQueue = new Queue<SpawnSettings>();

    public StageInfo Info { get; private set; }
    public float StartTime { get; private set; }
    public float PauseTime { get; private set; }
    public float EndTime { get; private set; }
    public bool IsPaused { get; private set; }
    public float SpawnTryDelay { get; private set; } = 3f; // how frequently we check spawn chances and queue
    public float SpawnDoDelay { get; private set; } = .5f; // delay between spawning things in queue

    public Stage(StageInfo info)
    {
        Info = info;
        StartTime = Time.time;
        EndTime = Time.time + info.stageLength;
    }

    public float GetProgress()
    {
        var progressTime = Time.time;
        if (IsPaused) progressTime = PauseTime;

        // The following is an equivalent one line expression to the lines above in C#, I like using these :D
        // var progressTime = IsPaused ? PauseTime : Time.time

        return (progressTime - StartTime) / (EndTime - StartTime) ;
    }

    public void Pause()
    {
        PauseTime = Time.time;
        IsPaused = true;
    }

    public void UnPause()
    {
        EndTime = EndTime + (Time.time - PauseTime);
        IsPaused = false;
    }

    // Checks each spawn info to see if they pass a chance check, if so queue their spawn
    private void TrySpawn()
    {
        foreach (var spawn in Info.spawns)
        {
            Debug.Log(spawn.spawnChance.Evaluate(GetProgress()) + " " + GetProgress());

            if (spawn.spawnChance.Evaluate(GetProgress()) >= Random.value) // check spawn chance
            {
                if (spawn.stopOtherSpawns) // if this spawn stops others, we're gonna clear the queue, enqueue this spawn, and then break
                {
                    spawnQueue.Clear();
                    spawnQueue.Enqueue(spawn);
                    break;
                }

                spawnQueue.Enqueue(spawn); // otherwise just queue the spawn
            }
        }
    }

    // Handles spawning the next spawn from the spawn queue
    private void DoSpawn()
    {
        var spawn = spawnQueue.Dequeue();

        if (spawn.pauseProgress) Pause();

        var spawned = Object.Instantiate(spawn.spawnPrefab);

        // GOTO change to use configurable spawn position in spawn info
        spawned.transform.position = new Vector3(12f, Random.Range(-4.5f, 4.5f), 0); // place us just off the screen
    }

    public void Update()
    {
        if (Time.time >= spawnTryTime && !IsPaused)
        {
            TrySpawn();
            spawnTryTime = Time.time + SpawnTryDelay;
        }

        if (Time.time >= spawnDoTime && spawnQueue.Count > 0)
        {
            DoSpawn();
            spawnDoTime = Time.time + SpawnDoDelay;
        }
    }
}
