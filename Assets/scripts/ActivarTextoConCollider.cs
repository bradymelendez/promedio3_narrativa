using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ActivarTextoConCollider : MonoBehaviour
{
    public TextMeshProUGUI textoAActivar;
    public GameObject panelAActivar;
    public float tiempoEntreLetras = 0.1f;

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
        textoAActivar.text = "";

        foreach (char letra in texto)
        {
            textoAActivar.text += letra;
            yield return new WaitForSeconds(tiempoEntreLetras);
        }
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
