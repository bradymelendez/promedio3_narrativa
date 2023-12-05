using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teletransporte : MonoBehaviour
{
    public Transform destino;
    public GameObject pantalla ;
    public void Start()
    {
        pantalla.SetActive(false);
    }
    public void MoverJugadorAlDestino()
    {
        if (destino != null)
        {
            Transform Player = GameObject.FindGameObjectWithTag("Player").transform;

            Player.position = destino.position;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pantalla.SetActive(true);
        }
        else
        {
            Debug.LogError("No se ha asignado un destino en el Inspector.");      
        }
    }
}
