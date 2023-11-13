using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teletransporte : MonoBehaviour
{
    public Transform destino;
    public void MoverJugadorAlDestino()
    {
        if (destino != null)
        {
            Transform Player = GameObject.FindGameObjectWithTag("Player").transform;

            Player.position = destino.position;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Debug.LogError("No se ha asignado un destino en el Inspector.");
        }
    }
}
