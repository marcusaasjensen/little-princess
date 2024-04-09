using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class LapManager : MonoBehaviour
{
    public RaceUIManager raceUIManager;
    public List<RaceCheckpoint> checkpoints;
    public int totalLaps = 3;
    public HorseIdentity winner;
    public UnityEvent onRaceWin;
    public UnityEvent onRaceLost;
        
    private void Start()
    {
        ListenCheckpoints(true);
        raceUIManager.UpdateLapText($"Lap 0 / {totalLaps}");
    }

    private void ListenCheckpoints(bool subscribe)
    {
        foreach (var checkpoint in checkpoints)
        {
            if (subscribe)
            {
                checkpoint.onCheckpointEnter.AddListener(CheckpointActivated);
            }
            else
            {
                checkpoint.onCheckpointEnter.RemoveListener(CheckpointActivated);
            }
        }
    }

    private void CheckpointActivated(HorseIdentity horse, RaceCheckpoint checkpoint)
    {
        // Do we know this checkpoint ?
        if (!checkpoints.Contains(checkpoint)) return;
        
        var checkpointNumber = checkpoints.IndexOf(checkpoint);
        // first time ever the car reach the first checkpoint
        var startingFirstLap = checkpointNumber == 0 && horse.LastPlayerCheckpoint == -1;
        // finish line checkpoint is triggered & last checkpoint was reached
        var lapIsFinished = checkpointNumber == 0 && horse.LastPlayerCheckpoint >= checkpoints.Count - 1;
        if (startingFirstLap || lapIsFinished)
        {
            horse.LastPlayerCheckpoint = 0;

            if (horse.CurrentPlayerLap <= totalLaps)
            {
                horse.CurrentPlayerLap++;
            }

            // if this was the final lap
            if (horse.CurrentPlayerLap > totalLaps)
            {
                if (winner) return;
                Debug.Log($"{horse.PlayerName} won!");
                winner = horse;
                if (horse.PlayerName == "Player")
                {
                    RaceAudioManager.Instance.PlayCheckpoint();
                    onRaceWin.Invoke();
                }
                else
                {
                    raceUIManager.ShowWonText(horse.PlayerName);
                    onRaceLost.Invoke();
                    // raceUIManager.ShowRestartText();
                    // EnableSceneInput(false);
                }
            }
            else
            {
                Debug.Log(horse.PlayerName+ "'s Lap " + horse.CurrentPlayerLap);
                if (horse.PlayerName == "Player")
                {
                    RaceAudioManager.Instance.PlayCheckpoint();
                    raceUIManager.UpdateLapText($"Lap {horse.CurrentPlayerLap} / {totalLaps}");
                }
                LapParticleManager.Instance.PlayLapParticle(horse.CarColor);
            }
        }
        // next checkpoint reached
        else if (checkpointNumber == horse.LastPlayerCheckpoint + 1) horse.LastPlayerCheckpoint += 1;
    }
    
    public void EnableSceneInput(bool nextScene)
    {
        StartCoroutine(EnableSceneInputCoroutine(nextScene));
    }
    
    private IEnumerator EnableSceneInputCoroutine(bool nextScene)
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        if (nextScene)
        {
            SceneManager.Instance.LoadNextScene();
        }
        else
        {
            SceneManager.Instance.RestartScene();
        }
    }
}