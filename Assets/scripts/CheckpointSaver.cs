using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSaver: MonoBehaviour
{
    public void SaveCheckpoint(Vector3 checkpointPosition, int health)
    {
        PlayerPrefs.SetInt("HasCheckpoint", 1);
        PlayerPrefs.SetFloat("CheckpointPositionX", checkpointPosition.x);
        PlayerPrefs.SetFloat("CheckpointPositionY", checkpointPosition.y);
        PlayerPrefs.SetFloat("CheckpointPositionZ", checkpointPosition.z);
        PlayerPrefs.SetInt("CheckpointHealth", health);
    }
}
