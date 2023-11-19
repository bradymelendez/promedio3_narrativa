using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform jugador; // Asigna el objeto del jugador al que el enemigo seguir�
    public float rangoDeSeguimiento = 10f; // Rango dentro del cual el enemigo comenzar� a seguir al jugador
    public float velocidad = 5f; // Velocidad de movimiento del enemigo

    void Update()
    {
        // Calcula la distancia entre el enemigo y el jugador
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);

        // Verifica si el jugador est� dentro del rango de seguimiento
        if (distanciaAlJugador <= rangoDeSeguimiento)
        {
            // Calcula la direcci�n hacia la cual el enemigo debe moverse para seguir al jugador
            Vector3 direccionAlJugador = (jugador.position - transform.position).normalized;

            // Mueve al enemigo en la direcci�n calculada a una velocidad constante
            transform.Translate(direccionAlJugador * velocidad * Time.deltaTime);
        }
    }
}
