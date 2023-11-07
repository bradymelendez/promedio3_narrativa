using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirYActivar : MonoBehaviour
{
    public GameObject objetoAActivar;
    public GameObject objeto;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            objetoAActivar.SetActive(true);
            Destroy(objeto);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trigger con el jugador detectado");

            objetoAActivar.SetActive(true);
            
        }
    }
}
