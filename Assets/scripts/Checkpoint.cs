using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{   
    public GameObject objecttext;
    public GameObject objectToSave;
    private Vector3 lastCheckpointPosition;
    private int lastCheckpointHealth;
    private float timeBeforeNextSave = 60f;
    private float timer = 0f;
    private bool canSave = true;

    public void Start()
    {
        Time.timeScale = 1;
    }

    public void Update()
    {
        if (!canSave)
        {
            timer += Time.deltaTime;
            float timeRemaining = timeBeforeNextSave - timer;
            Debug.Log("Tiempo restante para guardar: " + timeRemaining.ToString("F1"));
            objecttext.gameObject.SetActive(true);

            if (timer >= timeBeforeNextSave)
            {
                canSave = true;
                timer = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            SaveProgressIfCollidedAndKeyPressed();
        }
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
    public void SaveProgressIfCollidedAndKeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.F) && hasCollided && canSave)
        {
            SavePlayerProgress(lastCollisionPosition, lastCollisionHealth);
            canSave = false;
        }
    }

    private bool hasCollided = false;

    private Vector3 lastCollisionPosition;
    private int lastCollisionHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objectToSave)
        {
            Player player = other.gameObject.GetComponent<Player>(); 

            if (player != null)
            {
                Vector3 playerPosition = player.transform.position;
                int playerHealth = player.currentHealth;

                lastCollisionPosition = playerPosition;
                lastCollisionHealth = playerHealth;
                hasCollided = true;

                player.SetLastCheckpoint(this);
            }
        }
    }
}
