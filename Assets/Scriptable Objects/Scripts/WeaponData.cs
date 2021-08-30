using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/New Weapon")]
public class WeaponData : ScriptableObject
{
    public int ammoCap;
    public float reloadspeed;
    public int wepDamage;
}

