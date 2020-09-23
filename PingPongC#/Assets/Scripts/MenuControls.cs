using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public GameObject SettingsMain;
    public void OnClickPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickSettings()
    {
        SettingsMain.SetActive(true);
    }

    public void OnClickBack()
    {
        SettingsMain.SetActive(false);
    }

    public void OnClickBackMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
