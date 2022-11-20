using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class GameEvents
{
    public static event Action<int> OnAmmoPickup;
    public static event Action<bool> OnPlayerEnter;
    public static event Action<bool> OnPackageEnter;
    public static event Action<bool> OnPlayerVisibility;

    public static void AmmoPickup(int magazineAmmount)
    {
        OnAmmoPickup?.Invoke(magazineAmmount);
    }

    public static void PlayerEnter(bool isInside)
    {
        OnPlayerEnter?.Invoke(isInside);
    }

    public static void PackageEnter(bool isInside)
    {
        OnPackageEnter?.Invoke(isInside);
    }
    
    public static void PlayerVisibility(bool isVisible) {
        OnPlayerVisibility?.Invoke(isVisible);
    }
}
