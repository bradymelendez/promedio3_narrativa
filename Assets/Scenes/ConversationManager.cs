using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string characterName;
    public Sprite characterImage;
    [TextArea(3, 10)]
    public string dialogueText;
}

public class ConversationManager: MonoBehaviour
{
    public DialogueLine[] dialogueLines;
    public PlayerTrigger playerTrigger;

    private bool isPlayerInRange;
    private int currentLineIndex;
    private bool isDialogueActive;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isDialogueActive)
            {
                playerTrigger.interactionText.gameObject.SetActive(false);
                StartConversation();
            }
            else
            {
                DisplayNextLine();
            }
        }
    }

    private void StartConversation()
    {
        isDialogueActive = true;
        currentLineIndex = 0;
        UIManager.Instance.ShowDialogue(dialogueLines[currentLineIndex].characterName, dialogueLines[currentLineIndex].characterImage, dialogueLines[currentLineIndex].dialogueText);
    }

    private void DisplayNextLine()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogueLines.Length)
        {
            UIManager.Instance.ShowDialogue(dialogueLines[currentLineIndex].characterName, dialogueLines[currentLineIndex].characterImage, dialogueLines[currentLineIndex].dialogueText);
        }
        else
        {
            EndConversation();
        }
    }

    private void EndConversation()
    {
        isDialogueActive = false;
        UIManager.Instance.HideDialogue();
        playerTrigger.ShowInteractionText();
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
                EndConversation();
            }
        }
    }
}
