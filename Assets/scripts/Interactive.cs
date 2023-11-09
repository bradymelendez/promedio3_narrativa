using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactive: MonoBehaviour
{

    public TextMeshProUGUI messageText;
    public LayerMask playerLayer; 

    void Start()
    {
        messageText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerLayer == (playerLayer | (1 << other.gameObject.layer)))
        {
            messageText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerLayer == (playerLayer | (1 << other.gameObject.layer)))
        {
            messageText.gameObject.SetActive(false);
        }
    }
}
