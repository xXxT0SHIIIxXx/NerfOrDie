using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyBase enemyData;
    [SerializeField] PlayerBuffs playerData;
    [SerializeField] Weapon wepData;
    [SerializeField] GameObject player;
    [SerializeField] GameObject selfobj;
    [SerializeField] Transform playerT;
                     Vector3 playerpos;
    [SerializeField] Rigidbody self;

    float deathtimer;
    float deathLimit=5;
    float stuntimer;
    float stunLimit;
    float waittimer;
    float waitLimit = 5;
    public int health;
    int speed;
    int attackDamage;
    bool grounded;
    bool dead;
    bool attack;
    bool wait;
    public int plyLvl;
    // Start is called before the first frame update
    void Start()
    {
        waitLimit = 5;
        selfobj = this.gameObject;
        Debug.Log("Started");
        grounded = false;
        health = enemyData.health;
        speed = enemyData.speed;
        attackDamage = enemyData.attackDamage;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        plyLvl = playerData.Level;
        if(dead == true)
        {
            this.gameObject.GetComponent<Collider>().enabled = false;
        }
        if (wait == true)
        {
            Wait();
        }
        if(attack == true)
        {
            Attack();
        }
        Leveling();
        if(grounded == false)
        {
            Physics.IgnoreLayerCollision(6, 6);
        }
       
        //Set player Transform
        playerT = player.transform;
        //Set player vector3 position
        playerpos = playerT.position;
        

        //If Start and grounded then activate
        if (player.GetComponent<PlayerMove>().start == true && grounded == true)
        {
            EnemyFunctionality();
        }
    }

    private void FixedUpdate()
    {
        //if grounded then move
        if (grounded == true && dead == false && wait == false )
        {
            EnemyMove();
        }
    }
    void EnemyMove()
    {
        //move RigidBody to player position
        float towardsOtherx = player.transform.position.x - transform.position.x;
        float towardsOtherz = player.transform.position.z - transform.position.z;
       Vector3 towardsOther = new Vector3 (towardsOtherx, 0,towardsOtherz).normalized;




        self.MovePosition(transform.position + (towardsOther * speed * Time.deltaTime));

    }

   void EnemyFunctionality()
    {
        //if Health is less than or equal to 0, start death timer
        if (health <= 0)
        {
            dead = true;
           deathtimer = deathtimer + 0.1f;

            //Once timer ends, kill self and add kill to player
            if (deathtimer >= deathLimit) 
            { 
                Destroy(selfobj);
                playerData.Kills = playerData.Kills + 1;
            }
        }
    }

   void Attack()
    {
        playerData.Health = playerData.Health - attackDamage;
        attack = false;
        wait = true;
    }
    
    void Wait()
    {
        waittimer = waittimer + 0.1f;
        if(waittimer >= waitLimit)
        {
            waittimer = 0;
            wait = false;
        }
    }
    private void OnCollisionEnter(Collision obj)
    {
        //if Collided with Bullet, Take Damage
        if (obj.gameObject.tag == "bullet")
        {
            health = health - playerData.damage + wepData.wepDamage;
        }
        //If Collided with Ground then set values
        if(obj.gameObject.tag == "Ground")
        {
            grounded = true;
            this.GetComponent<Rigidbody>().drag = 100;
        }

        if(obj.gameObject.tag == "Player")
        {
            attack = true;
        }
    }

    void Leveling()
    {
        //Level with the player
        if (playerData.Level > 1)
        {
            Debug.Log("ABle to level");
            if (playerData.enemylevel == true)
            {
                Debug.Log("leveled");
                 attackDamage = attackDamage * plyLvl;
                 health = health * plyLvl;
                playerData.enemylevel = false;
            }
        }
    }
}
