using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsCleaner : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            CleanPlayerPrefs();
        }
    }

    void CleanPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs limpiadas.");
    }
}
