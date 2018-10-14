﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossAI : MonoBehaviour {

    //stats
    public int maxHealth = 100;
    public int health = 100;
    public int damage = 10;
    private float baseSpeed = 1f;
    private float speed = 1f;
    private float attackTimer = 1.5f;

    private float baseAbilityCooldown = 10f;
    private float abilityCooldown = 10f;

    public Slider healthBar;

    private int phase = 1;

    private int dir = 2;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (!static_information.isPaused)
        {
            if (health == 0)
                Destroy(GameObject.Find("Boss"));
            //Do death animation

            healthBar.value = health;

            abilityCooldown = baseAbilityCooldown - (maxHealth - health) / 20f;


            if (attackTimer > 0)
                attackTimer -= Time.deltaTime;
            if (abilityCooldown > 0)
                attackTimer -= Time.deltaTime;


            if (attackTimer <= 0)
                ; //Deal damage if touching bard

            if (health == maxHealth / 2)
                phase = 2;

            //if (phase == 1)
            //{
                if (abilityCooldown <= 0)
                    spawnMinion(phase);

                //speed = baseSpeed + (maxHealth - health)/45f;
                AttemptMove(BossAI());
            //}
            /* if (phase == 2)
            {
                if (abilityCooldown <= 0)
                    spawnMinion(phase);

                //speed = baseSpeed + (maxHealth - health) / 45f;
                AttemptMove(BossAI());
            }  */        
        }
    }
    public float [] BossAI()
    {
        float yDir;
        float xDir;

        float px = GameObject.Find("Guy").transform.position.x;
        float py = GameObject.Find("Guy").transform.position.y;
        float bx = transform.position.x;
        float by = transform.position.y;


        xDir = (bx > px) ? xDir = -1 * speed : xDir = 1 * speed;
        yDir = (by > py) ? yDir = -1 * speed : yDir = 1 * speed;


        float[] movement = { xDir, yDir };

        return movement;
    }
    public void AttemptMove (float [] movement)
    {
        
        Vector2 new_position = new Vector2(transform.position.x+movement[0], transform.position.y+movement[1]);

        transform.position = new_position;
    }

    public void hit(int damage)
    {
        health -= damage;
    }

    public void spawnMinion(int n)
    {
        for (int i = 0; i < n; i++)
        {

        }
    }

}
