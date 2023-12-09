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
    private float timer = 60f;
    private bool canSave = true;

    private bool hasCollided = false;
    private Vector3 lastCollisionPosition;
    private int lastCollisionHealth;

    private void Start()
    {
        Time.timeScale = 1;
        objecttext.SetActive(false);
    }

    private void Update()
    {
        if (!canSave)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                canSave = true;
                timer = timeBeforeNextSave;
                objecttext.SetActive(false);
            }
            else
            {
                float timeRemaining = timer;
                Debug.Log("Tiempo restante para guardar: " + timeRemaining.ToString("F1"));
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            SaveProgressIfCollidedAndKeyPressed();
        }
    }

    private void SavePlayerProgress(Vector3 playerPosition, int playerHealth)
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

    private void SaveProgressIfCollidedAndKeyPressed()
    {
        if (hasCollided && canSave)
        {
            SavePlayerProgress(lastCollisionPosition, lastCollisionHealth);
            canSave = false;
            objecttext.SetActive(true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null && other.gameObject == objectToSave)
        {
            Vector3 playerPosition = player.transform.position;
            int playerHealth = player.currentHealth;

            lastCollisionPosition = playerPosition;
            lastCollisionHealth = playerHealth;
            hasCollided = true;

            player.SetLastCheckpoint(this);

            Debug.Log("Colisión con el checkpoint. Posición: " + playerPosition + ", Salud: " + playerHealth);
        }
    }
}
