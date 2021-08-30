using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] PlayerBuffs stats;
    [SerializeField] Weapon Wepstats;
    [SerializeField] WeaponFunction Wep;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject cam;
    public bool start;
    public int speed;
    bool isGrounded;
    public float sprintspeed;
    Vector2 rotation = Vector2.zero;
    public float turnspeed = 3;
    public bool dead;
    void Start()
    {
        
        ResetBaseStats();
        start = false;
         speed = stats.speed;
    }

    private void Update()
    {
        sprintspeed = stats.speed * 1.12f;
        if (start == true && dead == false)
        {
            Look();
        }

        if(stats.Health <= 0)
        {
            dead = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (start == true && isGrounded == true)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.AddForce(transform.forward * sprintspeed);
            }
            if(dead == false)
            {
                PlayerMovement();
            }
            
        }       
    }
    void PlayerMovement()
    {
        if (Input.GetAxisRaw("Vertical") >0)
        {

            rb.AddForce(transform.forward * stats.speed);
        }
            
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            rb.AddForce(-transform.forward * stats.speed);
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.AddForce(transform.right * stats.speed);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.AddForce(-transform.right * stats.speed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.drag = 0;
            isGrounded = false;
            rb.AddForce(transform.up * stats.jumpHeight);
        }
        else if( isGrounded == true)
        {
            rb.drag = 10;
        }
    }

    public void StartGame()
    {
        start = true;
    }

    public void ResetBaseStats()
    {
        this.transform.position = new Vector3(0, 2, 0);
        stats.Name = null;
        stats.Health = 100;
        stats.jumpHeight = 300;
        stats.speed = 50;
        stats.damage = 10;
        stats.Kills = 0;
        stats.levelUp = false;
        stats.Level = 0;
        start = false;
        stats.CurrentMaxHealth = 100;
        stats.killLvLCap = 10;
        stats.enemycount = 10;

        Wepstats.ammoCap = 10;
        Wepstats.currentAmmo = Wepstats.ammoCap;
        Wepstats.wepDamage = 0;
        Wepstats.reloadspeed = 10;
        Wep.reloadspeed = 0;
        Time.timeScale = 1;
        dead = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }


    void Look()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector2 (0,rotation.y) * turnspeed;
        cam.transform.eulerAngles = new Vector2 (rotation.x,rotation.y) * turnspeed;
    }
}
