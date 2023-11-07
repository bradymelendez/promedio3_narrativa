using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueMelee : MonoBehaviour
{
    public GameObject objetoAActivarDesactivar;
    private bool puedeInteractuar = true;
    public float tiempoactivo = 1f;
    public float tiempoinactivo = 0.5f;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && puedeInteractuar)
        {
            StartCoroutine(ActivarDesactivar());
        }
    }

    System.Collections.IEnumerator ActivarDesactivar()
    {
        puedeInteractuar = false;
        objetoAActivarDesactivar.SetActive(true);

        yield return new WaitForSeconds(tiempoactivo);

        objetoAActivarDesactivar.SetActive(false);

        yield return new WaitForSeconds(tiempoinactivo);

        puedeInteractuar = true;
    }
}
