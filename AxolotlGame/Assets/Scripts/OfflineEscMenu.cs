using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OfflineEscMenu : MonoBehaviour
{
    public static bool EscMenuOpened;
    public GameObject MenuUI;

    void Start()
    {
        EscMenuOpened = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (EscMenuOpened)
            {
                Resume();
            }
            else
            {
                MenuOpened();
            }
        }
    }

    public void ResumeButtonClick()
    {
        MenuUI.SetActive(false);
        EscMenuOpened = false;
    }

    public void Resume()
    {
        MenuUI.SetActive(false);
        EscMenuOpened = false;
    }

    public void MenuOpened()
    {
        MenuUI.SetActive(true);
        EscMenuOpened = true;
    }

    public void onExitClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
