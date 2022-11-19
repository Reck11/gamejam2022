using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private bool _isInside;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.OnPlayerEnter += Pickup;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.E) && _isInside)
        {
            GameEvents.OnPlayerEnter -= Pickup;
            GameEvents.AmmoPickup(1);
            Destroy(gameObject);
        }

    }

    private void Pickup(bool isInside)
    {
        Debug.Log("Player is inside");
        _isInside = isInside;

    }
}
