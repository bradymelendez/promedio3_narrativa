using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Image[] hearts;
    public void UpdateHearts(int currentHealth, int maxHealth)
    {
        int heartCount = hearts.Length;
        int filledHearts = Mathf.CeilToInt((float)currentHealth / maxHealth * heartCount);

        for (int i = 0; i < heartCount; i++)
        {
            if (i < filledHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
