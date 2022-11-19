using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameEvents.PlayerEnter(true);
            Debug.Log("Player entered");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameEvents.PlayerEnter(false);
        }
    }
}
