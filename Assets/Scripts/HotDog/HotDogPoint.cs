using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDogPoint : MonoBehaviour
{

    private HotDogGame hotDogGame;

    private void Awake()
    {
        hotDogGame = GetComponentInParent<HotDogGame>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        hotDogGame.HotDogPointTrigger(this);
    }
}
