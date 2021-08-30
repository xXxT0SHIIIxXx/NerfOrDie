using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    bool hit;
    float deathTimer;
    float deathLimit = 10;

    float aliveTimer;
    float aliveLimit = 20;
    [SerializeField] GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreLayerCollision(7, 8);
        Lifetime();
        if (hit == true)
        {
            Death();
        }
    }

    void Lifetime()
    {
       aliveTimer = aliveTimer + .1f;
        if (aliveTimer >= aliveLimit)
        {
            Destroy(self);
        }
    }
    void Death()
    {
        deathTimer = deathTimer + .1f;
        if(deathTimer >= deathLimit)
        {
            Destroy(self);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hit = true;
        }
        if (collision.gameObject.tag == "Ground")
        {
            hit = true;
        }
           
    }

}
