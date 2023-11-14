using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ActivarTextoConCollider : MonoBehaviour
{
    public TextMeshProUGUI textoAActivar;
    public GameObject panelAActivar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            textoAActivar.gameObject.SetActive(true);
            panelAActivar.SetActive(true);

            Destroy(gameObject);
        }
    }
}
