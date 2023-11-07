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

    private void SavePlayerProgress(Vector3 playerPosition, int playerHealth)
    {
        string filePath = Application.persistentDataPath + "/playerProgress.txt";

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Position: {playerPosition.x}, {playerPosition.y}, {playerPosition.z}");
                writer.WriteLine($"Health: {playerHealth}");
            }

            Debug.Log("Progreso del jugador guardado en el checkpoint.");
        }
        catch (Exception e)
        {
            Debug.LogError("Error al guardar el progreso: " + e.Message);
        }

        lastCheckpointPosition = playerPosition; 
        lastCheckpointHealth = playerHealth;
    }

    public Vector3 GetLastCheckpointPosition()
    {
        return lastCheckpointPosition;
    }

    public int GetLastCheckpointHealth()
    {
        return lastCheckpointHealth;
    }

    private void OnTriggerEnter(Collider other)
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
