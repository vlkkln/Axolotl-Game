using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private CustomNetworkManager manager;
    private CustomNetworkManager Manager
    {
        get
        {
            if (manager != null)
            {
                return manager;
            }
            return manager = CustomNetworkManager.singleton as CustomNetworkManager;
        }
    }

    private void Start()
    {

    }

    public void singlePlayerButton() 
    {
        SceneManager.LoadScene("SinglePlayer");
    }
    public void multiPlayerButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void optionsButtons()
    {


    }
    public void onExitClick() 
    {
        Application.Quit();
    }
    public void onMainMenuReturn() 
    {
        SceneManager.LoadScene("Menu");
    }
}
