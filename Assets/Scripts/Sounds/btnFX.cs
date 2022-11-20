using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnFX : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hover;
    public AudioClip click;

    public void HoverSound()
    {
        audioSource.PlayOneShot(hover);
    }

    public void ClickSound()
    {
        audioSource.PlayOneShot(click);
    }
}
