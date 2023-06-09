﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 100.0f;
    public GameObject splatEffect;
    public float damage = 20.0f;
    GameObject LevelManager;
    private ZombieHealth zHealth;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager = GameObject.FindGameObjectWithTag("LevelManager");

        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        Invoke("DestroySelf", 5.0f); // Bullets that fly for 5 seconds without collision will 'die'
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //LevelManager.GetComponent<LevelManager>().score++; REMOVE COMMENT IF YOU WANT TO USE A SCORE
            Instantiate(splatEffect, collision.transform.position, Quaternion.identity);

            zHealth = collision.gameObject.GetComponent<ZombieHealth>();
            zHealth.damageZombie(damage);

            //Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "EnemyStrong")
        {
            zHealth = collision.gameObject.GetComponent<ZombieHealth>();
            zHealth.damageZombie(damage);
        }

        if (collision.gameObject.tag != "Player")
        {
            DestroySelf();
        }


    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
