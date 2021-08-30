using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponFunction : MonoBehaviour
{
    [SerializeField] Weapon wepStats;
    [SerializeField] PlayerMove player;
    [SerializeField] PlayerBuffs ply;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject shootspot;
    [SerializeField] Text reloadRemind;
    [SerializeField] Rigidbody bullet_rb;
    [SerializeField] AudioSource sounds;
    [SerializeField] int shootspeed;
    public float reloadspeed;
    public float reloadLimit;
    bool reloading;


    // Start is called before the first frame update
    void Start()
    {
        

    }
    // Update is called once per frame
    void Update()
    {
        if (player.start == true && ply.levelUp == false && player.dead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
        reloadLimit = wepStats.reloadspeed;

        if(reloading == false)
        {
            reloadspeed = 0;
        }
        if (Input.GetKeyDown(KeyCode.R) && wepStats.currentAmmo <= 0)
        {
            reloading = true;
        }
        if(reloading == true)
        {
            reloadspeed = reloadspeed + 0.1f;
            if (reloadspeed >= reloadLimit)
            {
                wepStats.currentAmmo = wepStats.ammoCap;
                reloading = false;
            }
        }
        if(wepStats.currentAmmo == wepStats.ammoCap)
        {
            reloadRemind.enabled = false;
        }    
    }

    void Shoot()
    {
        if(wepStats.currentAmmo == 0)
        {
                reloadRemind.enabled = true; 
        }
        if (wepStats.currentAmmo > 0)
        {
            sounds.Play();
            GameObject shoot = Instantiate(bullet);
            bullet_rb = shoot.GetComponent<Rigidbody>();
            shoot.transform.position = shootspot.transform.position;
            shoot.transform.rotation = shootspot.transform.rotation;
            bullet_rb.AddForce(shootspot.transform.up * shootspeed, ForceMode.Impulse);
            wepStats.currentAmmo = wepStats.currentAmmo - 1;
        }
        
    }
}
