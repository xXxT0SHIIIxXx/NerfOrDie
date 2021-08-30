using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Enemy", menuName = "New Enemy Data")]

public class EnemyBase : ScriptableObject
{
    public int health;
    public int speed;
    public int attackDamage;
    public float offsetFromGround;
}
