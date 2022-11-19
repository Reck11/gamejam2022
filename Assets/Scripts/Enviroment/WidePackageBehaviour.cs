using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidePackageBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.DropBoxWide))
        {
            GameEvents.PackageEnter(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.DropBoxWide))
        {
            GameEvents.PackageEnter(false);
        }
    }
}
