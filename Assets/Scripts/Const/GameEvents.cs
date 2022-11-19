using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class GameEvents
{
    public static event Action<int> OnAmmoPickup;
    public static event Action<bool> OnPlayerEnter;

    public static void AmmoPickup(int magazineAmmount)
    {
        OnAmmoPickup?.Invoke(magazineAmmount);
    }

    public static void PlayerEnter(bool isInside)
    {
        Debug.Log("Event");
        OnPlayerEnter?.Invoke(isInside);
    }
}
