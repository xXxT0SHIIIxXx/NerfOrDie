using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/New Weapon")]
public class Weapon : WeaponData
{
    [Header("Buffs")]
    public int currentAmmo;
    public float reloadSpeedDeduct;
    public int wepDamageModifier;

    private void OnEnable()
    {
        currentAmmo = ammoCap;
    }

    public void AddAmmos()
    {
        ammoCap = ammoCap + 10;
    }

    public void AddReloadSpeed()
    {
        reloadspeed = reloadspeed - reloadSpeedDeduct;
    }

    public void AddWepDamage()
    {
        if (wepDamage == 0)
        {
            wepDamage = 1;
            wepDamage = wepDamage * wepDamageModifier;
        }
        else
        {
            wepDamage = wepDamage * wepDamageModifier;
        }
    }


}
