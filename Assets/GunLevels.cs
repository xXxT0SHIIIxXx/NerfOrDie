using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLevels : MonoBehaviour
{
    [SerializeField] Weapon wepData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AmmoUpgrade()
    {
        wepData.AddAmmos();
    }

    public void ReloadUpgrade()
    {
        wepData.AddReloadSpeed();
    }

    public void DamageUpgrade()
    {
        wepData.AddWepDamage();
    }
}
