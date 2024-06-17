using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public Image npcImage;
    public TMP_Text npcNameText;
    public float typingSpeed = 0.05f; 

    private Coroutine typingCoroutine;

    public void Start()
    {
        dialoguePanel.SetActive(false);
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowDialogue(string npcName, Sprite image, string firstLine)
    {
        dialoguePanel.SetActive(true);
        npcNameText.text = npcName;
        npcImage.sprite = image;
        StartTyping(firstLine);
    }

    public void UpdateDialogue(string newLine)
    {
        StartTyping(newLine);
    }

    public void HideDialogue()
    {
        dialoguePanel.SetActive(false);
    }

    private void StartTyping(string line)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypeLine(line));
    }

    private IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}