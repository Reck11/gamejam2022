using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDogGame : MonoBehaviour
{
    public float winDistance = 0.5f;
    [SerializeField]
    private GameObject sausage;
    [SerializeField]
    private GameObject bun;
    [SerializeField]
    private GameObject station;
    void Update()
    {
        if (Vector2.Distance(sausage.transform.position, bun.transform.position) < winDistance) {
            Win();
        }
    }
    void Win() {
        station.GetComponent<Task>().EndTask();
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
