using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damageAmount = 1;
    public float rotationSpeed = 5f;  // Velocidad de rotaci�n hacia el jugador
    private Transform target;  // Referencia al jugador

    private void Start()
    {
        // Busca al jugador al inicio
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.TakeDamage(damageAmount);
            }
        }
    }

    private void Update()
    {
        if (target != null)
        {
            // Calcula la direcci�n hacia el jugador
            Vector3 directionToTarget = target.position - transform.position;
            directionToTarget.y = 0f;  // Mantiene la rotaci�n en el plano horizontal

            // Calcula la rotaci�n para mirar hacia el jugador
            Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);

            // Suaviza la rotaci�n para que no sea brusca
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
    }
}

