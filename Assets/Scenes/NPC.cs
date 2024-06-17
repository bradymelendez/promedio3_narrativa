using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName;
    public Sprite npcImage;
    [TextArea(3, 10)]
    public string[] dialogueLines;

    private bool isPlayerInRange;
    private int currentLineIndex;
    private bool isDialogueActive;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isDialogueActive)
            {
                StartDialogue();
            }
            else
            {
                DisplayNextLine();
            }
        }
    }

    private void StartDialogue()
    {
        isDialogueActive = true;
        currentLineIndex = 0;
        UIManager.Instance.ShowDialogue(npcName, npcImage, dialogueLines[currentLineIndex]);
    }

    private void DisplayNextLine()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogueLines.Length)
        {
            UIManager.Instance.UpdateDialogue(dialogueLines[currentLineIndex]);
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        UIManager.Instance.HideDialogue();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (isDialogueActive)
            {
                EndDialogue();
            }
        }
    }
}