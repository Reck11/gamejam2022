using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public void Pickup() {
        GameEvents.AmmoPickup(1);
        Destroy(gameObject);
    }
}
