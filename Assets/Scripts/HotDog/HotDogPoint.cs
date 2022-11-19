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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hotDogGame.
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
