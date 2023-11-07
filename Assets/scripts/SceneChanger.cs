using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("saliste");
    }
    public void ClearPlayerPrefsAndLoadScene(string scenename)
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All PlayerPrefs cleared");
        SceneManager.LoadScene(scenename);
    }
}
