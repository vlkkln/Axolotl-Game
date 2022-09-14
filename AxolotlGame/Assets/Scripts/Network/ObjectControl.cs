using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class ObjectControl : NetworkBehaviour
{
    public GameObject PlayerModel;

    void Start()
    {
        PlayerModel.SetActive(false);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (PlayerModel.activeSelf == false)
            {
                PlayerModel.SetActive(true);
            }
        }
    }

}
