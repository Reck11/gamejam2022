using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObjects : MonoBehaviour
{

    public bool isInRange;
    public KeyCode key;
    public UnityEvent interactAction;

    private void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(key))
            {
                interactAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("In range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Not in range");
        }
    }

    

}
