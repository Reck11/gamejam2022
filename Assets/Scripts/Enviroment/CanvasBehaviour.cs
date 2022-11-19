using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBehaviour : MonoBehaviour
{
    private int _packageCount;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.OnPackageEnter += Count;
   
    }

    // Update is called once per frame
    void Update()
    {
        if(_packageCount >= 7)
        {
            GameEvents.OnPackageEnter -= Count; 
            Destroy(gameObject);
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
