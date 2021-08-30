using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : ScriptableObject
{
    [Header("Base Stats")]
    public PlayerBase player;
    public string Name;
    public int Level;
    public int Kills;
    public float Health;
    public int damage;
    public int speed;
    public int jumpHeight;
}
