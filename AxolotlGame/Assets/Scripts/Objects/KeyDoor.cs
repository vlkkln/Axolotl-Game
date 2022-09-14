using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;
    private bool isOpen = false;
    private float positionY;


    public Key.KeyType GetKeyType() {
        return keyType;
    }
    public void Update()
    {
        if (isOpen == true)
        {
            if (gameObject.transform.position.y <= positionY + 3.6f) {
                gameObject.transform.position += Vector3.up * 2f * Time.deltaTime;
            }            
        }

    }

    public void OpenDoor() {
        isOpen = true;
        positionY = gameObject.transform.position.y;
    }
}
