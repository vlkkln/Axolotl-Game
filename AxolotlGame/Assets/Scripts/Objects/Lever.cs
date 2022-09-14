using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    public UnityEvent customEvent;
    bool DetectObj;
    bool isOpen;

    private void Update()
    {
        Debug.Log(isOpen);
            if (InteractIn() && DetectObj)
            {
            doorOpen();
            }        
    }

    bool InteractIn()
    {
            return Input.GetKeyDown(KeyCode.E);        
    }

    private void doorOpen() {
        isOpen = true;
        customEvent.Invoke();
        gameObject.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterMovement levert = collision.GetComponent<CharacterMovement>();
        if (levert) {
            DetectObj = true;
        }
                 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        DetectObj = false;
    }

    

}
