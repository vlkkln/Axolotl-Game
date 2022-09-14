using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongDoor : MonoBehaviour
{
    float positionY;
    bool isOpen;
    bool click;

    private void Awake()
    {
        positionY = gameObject.transform.position.y;
    }

    private void Update()
    {
        if (isOpen == true)
        {
            if (gameObject.transform.position.y <= positionY + 3.6f)
            {
                gameObject.transform.position += Vector3.up * 2f * Time.deltaTime;
            }
        } else if (gameObject.transform.position.y >= positionY)
        {
            gameObject.transform.position += Vector3.down * 2f * Time.deltaTime;
        }
    }

    public void tasi()
    {
        if (!click)
        {
            click = true;
            isOpen = true;
        }
        else if (click) {
            click = false;
            isOpen = false;
        }

    }
}
