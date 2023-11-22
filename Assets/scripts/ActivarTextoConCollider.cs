using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ActivarTextoConCollider : MonoBehaviour
{
    public TextMeshProUGUI textoAActivar;
    public GameObject panelAActivar;
    public float tiempoEntreLetras = 0.1f;
    public float tiempoAntesDeDestruir = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelAActivar.SetActive(true);
            StartCoroutine(MostrarTextoPorLetras(textoAActivar.text));
        }
    }

    private IEnumerator MostrarTextoPorLetras(string texto)
    {
        TextMeshProUGUI textoLocal = Instantiate(textoAActivar);
        textoLocal.text = "";

        int i = 0;
        while (i < texto.Length)
        {
            textoLocal.text += texto[i++];
            yield return new WaitForSeconds(tiempoEntreLetras);
        }

        yield return new WaitForSeconds(tiempoAntesDeDestruir);
        Destroy(textoLocal.gameObject); // Destruir la copia local
        Destroy(gameObject); // Destruir el objeto original
    }
}
