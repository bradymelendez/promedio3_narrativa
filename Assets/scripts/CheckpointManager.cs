using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager: MonoBehaviour
{
    public static Vector3 checkpointPosition;
    public static int checkpointHealth;

    void Start()
    {
        if (PlayerPrefs.HasKey("HasCheckpoint") && PlayerPrefs.GetInt("HasCheckpoint") == 1)
        {
            checkpointPosition = new Vector3(
                PlayerPrefs.GetFloat("CheckpointPositionX"),
                PlayerPrefs.GetFloat("CheckpointPositionY"),
                PlayerPrefs.GetFloat("CheckpointPositionZ")
            );
            checkpointHealth = PlayerPrefs.GetInt("CheckpointHealth");

            InitializePlayer();
        }
    }

    void InitializePlayer()
    {
        Player player = GetPlayerReference();

        if (player != null)
        {
            player.transform.position = checkpointPosition;
            player.currentHealth = checkpointHealth;
        }
    }

    Player GetPlayerReference()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            return playerObject.GetComponent<Player>();
        }
        else
        {
            Debug.LogError("Player object not found in the scene or not tagged as 'Player'.");
            return null;
        }
    }
}
