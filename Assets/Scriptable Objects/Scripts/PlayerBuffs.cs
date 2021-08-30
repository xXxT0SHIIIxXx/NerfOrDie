using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Player Stats", menuName = "Characters/Player/Stats")]
public class PlayerBuffs : PlayerBase
{
    [Header("Buffs")]
    public int currentLevel;
    public int currentKills;
    public float healthBuff;
    public float CurrentMaxHealth;
    public int damageBuff;
    public int speedBuff;
    public int jumpBuff;
    public int killLvLCap;
    public bool levelUp;
    public int enemycount;
    public bool enemylevel;
    public PlayerBuffs starts;

    public void AddLevel()
    {
        if (levelUp == false)
        {
            enemylevel = true;
            Level = Level + 1;
            levelUp = true;
        }
    }

    public void LevelCap()
    {
        killLvLCap = enemycount + killLvLCap+5;
    }

    public void AddKills()
    {
        player.Kills = player.Kills + currentKills;
    }

    public void AddHealth()
    {
        CurrentMaxHealth = CurrentMaxHealth + healthBuff;
        

    }

    public void AddDamage()
    {
        player.damage = player.damage + damageBuff;
    }

    public void AddSpeed()
    {
        player.speed = player.speed + speedBuff;
    }

    public void AddJump()
    {
        player.jumpHeight = player.jumpHeight + jumpBuff;
    }

    public void HealthStart()
    {
        Health = Health +100;
    }
}


