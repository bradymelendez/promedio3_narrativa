using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogo: MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public LayerMask playerLayer;
    public GameObject dialogueIcon;
    public GameObject dialoguePanelText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueTextBox;
    public TextMeshProUGUI textDialogue;
    public bool dialogueExist;
    public bool dialogueStart;
    int index;

    void Start()
    {
        dialogueIcon.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
        messageText.gameObject.SetActive(false);

    }

    void Update()
    {
        if (dialogueExist && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogueStart)
            {
                StartDialogue();
                ToggleCursor(true);
                messageText.gameObject.SetActive(false);

            }
            else if (textDialogue.text == dialogueTextBox[index])
            {
                NextDialogue();
            }
            else
            {
                StopAllCoroutines();
                textDialogue.text = dialogueTextBox[index];
            }
        }
    }
    private void ToggleCursor(bool state)
    {
        if (state)
        {
            Cursor.lockState = CursorLockMode.None; 
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false;
        }
    }
    private IEnumerator CountLineText()
    {
        textDialogue.text = string.Empty;
        foreach (char character in dialogueTextBox[index])
        {
            textDialogue.text += character;
            yield return new WaitForSeconds(0.05f);
        }
    }
    void StartDialogue()
    {
        dialogueStart = true;
        dialoguePanelText.SetActive(true);
        dialogueIcon.SetActive(false);
        index = 0;
        StartCoroutine(CountLineText());
    }
    private void NextDialogue()
    {
        index++;
        if (index < dialogueTextBox.Length)
        {
            StartCoroutine(CountLineText());
        }
        else
        {
            dialogueStart = false;
            dialoguePanelText.SetActive(false);
            dialogueIcon.SetActive(true);
            ToggleCursor(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            dialogueExist = true;
            dialogueIcon.SetActive(true);
            messageText.gameObject.SetActive(true);

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            dialogueExist = false;
            dialogueIcon.SetActive(false);
            dialoguePanelText.SetActive(false);
            messageText.gameObject.SetActive(false);

        }
    }
}
