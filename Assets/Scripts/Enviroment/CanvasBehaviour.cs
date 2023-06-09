using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBehaviour : MonoBehaviour
{
    [SerializeField]
    private int _disposeTime;
    [SerializeField]
    private GameObject station;
    private int _packageCount;
    void Start()
    {
        GameEvents.OnPackageEnter += Count;
   
    }

    void Update()
    {
        if(_packageCount >= 5)
        {
            GameEvents.OnPackageEnter -= Count;
            station.GetComponent<Task>().EndTask();
            Destroy(gameObject, _disposeTime);
        }
    }

    private void Count(bool isInside)
    {
        if (isInside)
        {
            _packageCount++;
        }
        else if (!isInside)
        {
            _packageCount--;
        }

    }
}
