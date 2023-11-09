using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestruirYActivar : MonoBehaviour
{
    public GameObject objetoAActivar;
    public GameObject objetoADestruir;
    public TextMeshProUGUI messageText;

    public LayerMask playerLayer; 

    private bool dentroDelTrigger = false;

    private void Start()
    {
        messageText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (dentroDelTrigger && Input.GetKeyDown(KeyCode.E))
        {
            objetoAActivar.SetActive(true);
            if (objetoADestruir != null)
            {
                Destroy(objetoADestruir);
                messageText.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerLayer == (playerLayer | (1 << other.gameObject.layer)))
        {
            Debug.Log("Trigger con el jugador detectado");
            dentroDelTrigger = true;
            messageText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerLayer == (playerLayer | (1 << other.gameObject.layer)))
        {
            dentroDelTrigger = false;
            messageText.gameObject.SetActive(false);
        }
    }
}
