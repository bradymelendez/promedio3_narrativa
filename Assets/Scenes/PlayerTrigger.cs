using UnityEngine;
using TMPro;

public class PlayerTrigger : MonoBehaviour
{
    public TMP_Text interactionText;
    private bool isPlayerInRange;

    void Start()
    {
        interactionText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactionText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactionText.gameObject.SetActive(false);
        }
    }

    public void ShowInteractionText()
    {
        if (isPlayerInRange)
        {
            interactionText.gameObject.SetActive(true);
        }
    }
}
