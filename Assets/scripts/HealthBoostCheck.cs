using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoostCheck : MonoBehaviour
{
    public int live;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.IncreaseHealth(live);
            }
        }
    }
}
