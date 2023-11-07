using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject objectToSave;
    private Vector3 lastCheckpointPosition;
    private int lastCheckpointHealth;

    public void Start()
    {
        Time.timeScale = 1;
    }
    public void SavePlayerProgress(Vector3 playerPosition, int playerHealth)
    {
        lastCheckpointPosition = playerPosition;
        lastCheckpointHealth = playerHealth;

        PlayerPrefs.SetInt("HasCheckpoint", 1);
        PlayerPrefs.SetFloat("CheckpointPositionX", lastCheckpointPosition.x);
        PlayerPrefs.SetFloat("CheckpointPositionY", lastCheckpointPosition.y);
        PlayerPrefs.SetFloat("CheckpointPositionZ", lastCheckpointPosition.z);
        PlayerPrefs.SetInt("CheckpointHealth", lastCheckpointHealth);

        Debug.Log("Progreso del jugador guardado en el checkpoint.");
    }

    public Vector3 GetLastCheckpointPosition()
    {
        return lastCheckpointPosition;
    }

    public int GetLastCheckpointHealth()
    {
        return lastCheckpointHealth;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objectToSave)
        {
            Player player = objectToSave.GetComponent<Player>();

            if (player != null)
            {
                Vector3 playerPosition = player.transform.position;
                int playerHealth = player.currentHealth;

                SavePlayerProgress(playerPosition, playerHealth);
                player.SetLastCheckpoint(this); 
            }
        }
    }

}
