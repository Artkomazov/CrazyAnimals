using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MenuBotton;
    public GameObject MenuWindow;

    public MonoBehaviour[] ComponentsToDisable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MenuWindow.active == true)
            {
                CloseMenuWindow();
            }
            else
            {
                OpenMenuWindow();
            }
            
        }
    }

    public void OpenMenuWindow()
    {
        MenuBotton.SetActive(false);
        MenuWindow.SetActive(true);
        for (int i = 0; i < ComponentsToDisable.Length; i++)
        {
            ComponentsToDisable[i].enabled = false;
        }
        Time.timeScale = 0f;
    }

    public void CloseMenuWindow()
    {
        MenuBotton.SetActive(true);
        MenuWindow.SetActive(false);
        for (int i = 0; i < ComponentsToDisable.Length; i++)
        {
            ComponentsToDisable[i].enabled = true;
        }
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }
}
