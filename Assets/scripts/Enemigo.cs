using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidadMovimiento = 3.0f;
    public float distanciaMinima = 1.0f;
    public float distanciaPerseguir = 5.0f;
    public float tiempoEsperaDespuesDeImpacto = 3.0f;
    public int vidaInicial = 3;  // Ajusta seg�n sea necesario

    private Transform jugador;
    private bool esperandoDespuesDeImpacto;
    private Vector3 direccion;
    private int vidaActual;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        esperandoDespuesDeImpacto = false;
        vidaActual = vidaInicial;
    }

    void Update()
    {
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);

        if (!esperandoDespuesDeImpacto && distanciaAlJugador <= distanciaPerseguir)
        {
            SeguirJugador();
        }
    }

    void SeguirJugador()
    {
        // Calcular la direcci�n hacia el jugador
        direccion = jugador.position - transform.position;
        direccion.Normalize();

        // Rotar para mirar al jugador
        transform.LookAt(jugador);

        // Mover hacia el jugador si la distancia es mayor que la distancia m�nima
        if (Vector3.Distance(transform.position, jugador.position) > distanciaMinima)
        {
            transform.Translate(direccion * velocidadMovimiento * Time.deltaTime, Space.World);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Dibujar un gizmo esf�rico para visualizar el radio de persecuci�n
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaPerseguir);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�El jugador ha sido impactado!");

            // Reducir la vida del enemigo
            vidaActual--;

            if (vidaActual <= 0)
            {
                // Si la vida llega a cero, el enemigo muere
                Destroy(gameObject);
            }
            else
            {
                // Si la vida no es cero, detener al enemigo y esperar despu�s del impacto
                esperandoDespuesDeImpacto = true;
                velocidadMovimiento = 0f;

                // Iniciar la espera de tiempo
                Invoke("ReiniciarSeguimiento", tiempoEsperaDespuesDeImpacto);
            }
        }
    }

    void ReiniciarSeguimiento()
    {
        // Reiniciar el seguimiento despu�s del tiempo de espera
        esperandoDespuesDeImpacto = false;
        velocidadMovimiento = 3.0f;
    }
}

