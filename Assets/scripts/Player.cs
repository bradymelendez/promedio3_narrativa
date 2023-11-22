using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public HealthDisplay healthDisplay;
    public Canvas gameOverCanvas;
    public Button returnToCheckpointButton;

    private int healthBeforeCheckpoint;
    private Vector3 positionBeforeCheckpoint;
    private Checkpoint lastCheckpoint;
    private bool isEscapeBlocked = false;


    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthDisplay();

        if (returnToCheckpointButton != null)
        {
            returnToCheckpointButton.onClick.AddListener(ReturnToCheckpoint);
            returnToCheckpointButton.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (isEscapeBlocked && Input.GetKeyDown(KeyCode.Escape))
        {
            Input.ResetInputAxes();
            return;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthDisplay();

        if (currentHealth <= 0)
        {
            HandlePlayerDeath();
        }
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthDisplay();
    }

    public void SetLastCheckpoint(Checkpoint checkpoint)
    {
        lastCheckpoint = checkpoint;
    }

    private void HandlePlayerDeath()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.gameObject.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (returnToCheckpointButton != null)
            {
                returnToCheckpointButton.gameObject.SetActive(true);
            }
        }

        if (lastCheckpoint != null)
        {
            TeleportToCheckpoint(lastCheckpoint);
        }
        isEscapeBlocked = true;
    }

    public void TeleportToCheckpoint(Checkpoint checkpoint)
    {
        Vector3 checkpointPosition = checkpoint.GetLastCheckpointPosition();
        transform.position = checkpointPosition;
        currentHealth = maxHealth;
        UpdateHealthDisplay();
    }

    public void RestorePlayerProgress(Vector3 checkpointPosition, int checkpointHealth)
    {
        transform.position = checkpointPosition;
        currentHealth = checkpointHealth;
        UpdateHealthDisplay();
    }

    public void RevertToPreviousState()
    {
        currentHealth = healthBeforeCheckpoint;
        transform.position = positionBeforeCheckpoint;
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        if (healthDisplay != null)
        {
            healthDisplay.UpdateHearts(currentHealth, maxHealth);
        }
    }

    private void ReturnToCheckpoint()
    {
        if (lastCheckpoint != null)
        {
            TeleportToCheckpoint(lastCheckpoint);
            gameOverCanvas.gameObject.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            returnToCheckpointButton.gameObject.SetActive(false);

            isEscapeBlocked = false;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
