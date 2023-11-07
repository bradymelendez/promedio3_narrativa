using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class CheckpointLoader : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public float messageDuration = 5f;

    public void LoadCheckpointOrShowMessage()
    {
        if (PlayerPrefs.HasKey("HasCheckpoint") && PlayerPrefs.GetInt("HasCheckpoint") == 1)
        {
            StartCoroutine(LoadGame());
        }
        else
        {
            StartCoroutine(ShowMessageForTime("No has guardado partida!", messageDuration));
        }
    }

    IEnumerator ShowMessageForTime(string message, float duration)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        messageText.gameObject.SetActive(false);
    }

    IEnumerator LoadGame()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("game", LoadSceneMode.Single);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
