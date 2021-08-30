using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevels : MonoBehaviour
{
    [SerializeField] PlayerBuffs stats;
    [SerializeField] GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.Kills >= stats.killLvLCap)
        {
            
            stats.AddLevel();
        }
    }

    public void HealthUp()
    {
        stats.AddHealth();
    }

    public void DamageUp()
    {
        stats.AddDamage();
    }

    public void SpeedUp()
    {
        stats.AddSpeed();
    }
}
