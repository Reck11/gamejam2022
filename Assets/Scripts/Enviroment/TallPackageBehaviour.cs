using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallPackageBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.DropBoxTall))
        {
            GameEvents.PackageEnter(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.DropBoxTall))
        {
            GameEvents.PackageEnter(false);
        }
    }
}
