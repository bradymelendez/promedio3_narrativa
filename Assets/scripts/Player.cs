using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth; 
    public HealthDisplay healthDisplay;


    private int healthBeforeCheckpoint;
    private Vector3 positionBeforeCheckpoint;

    private Checkpoint lastCheckpoint;
    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthDisplay();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthDisplay();

        if (currentHealth <= 0)
        {
            if (lastCheckpoint != null)
            {
                TeleportToCheckpoint(lastCheckpoint);
            }
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

    void TeleportToCheckpoint(Checkpoint checkpoint)
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
    void UpdateHealthDisplay()
    {
        if (healthDisplay != null)
        {
            healthDisplay.UpdateHearts(currentHealth, maxHealth);
        }
    }
}
