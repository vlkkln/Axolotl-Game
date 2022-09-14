using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscMenu : NetworkBehaviour
{
    public static bool EscMenuOpened;
    public GameObject MenuUI;   

    void Start()
    {   
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            MenuUI = GameObject.Find("EscMenu").transform.GetChild(0).gameObject;            
            if (hasAuthority) { 
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
        }        
    }

    public void ResumeButtonClick() {
        MenuUI = GameObject.Find("EscMenu").transform.GetChild(0).gameObject;
        MenuUI.SetActive(false);
        EscMenuOpened = false;
    }

    void Resume() {
        MenuUI.SetActive(false);
        EscMenuOpened = false;
    }

    void MenuOpened() {
        MenuUI.SetActive(true);
        EscMenuOpened = true;
    }

    public void onExitClick() {
        EscMenuOpened = false;
        LobbyController.Instance.OnExitButton(); 
        SceneManager.LoadScene("Menu");   
    }
}
