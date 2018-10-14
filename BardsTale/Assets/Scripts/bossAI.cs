using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossAI : MonoBehaviour {

    //stats
    public int maxHealth = 100;
    public int health = 100;
    public int damage = 10;
    private float speed = 1f;
    private float attackTimer = 1.5f;
    private float abilityCooldown = 10f;

    public Slider healthBar;
    private bool skipMove;

    private int phase = 1;

    private int dir = 2;


    // Use this for initialization
    void Start () {
        skipMove = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!static_information.isPaused)
        {
            healthBar.value = health;

            if (attackTimer > 0)
                attackTimer -= Time.deltaTime;
            if (abilityCooldown > 0)
                attackTimer -= Time.deltaTime;


            if (attackTimer <= 0)
                ; //Deal damage if touching bard

            if (phase == 1)
            {
                if (abilityCooldown <= 0)
                    ; //Do special attack
                speed = speed + (maxHealth - health)/50;
                AttemptMove(BossAI());
            }
            





            



        }
    }
    public float [] BossAI()
    {
        float yDir;
        float xDir;
        if (dir == 5)
            dir = 1;

        if (dir == 1 || dir == 2)
            yDir = 1f * speed;
        else
            yDir = -1f * speed;
        if (dir == 1 || dir == 4)
            xDir = 1f * speed;
        else
            xDir = -1f * speed;


        float[] movement = { xDir, yDir };

        return movement;
    }
    public void AttemptMove (float [] movement)
    {
        //print(Camera.main.pixelWidth + "  " + transform.position.x);

        Vector2 new_position = new Vector2(transform.position.x+movement[0], transform.position.y+movement[1]);

        if (new_position[0] < 20)
        {
            if (dir == 2)
                dir = 1;
            else
                dir = 4;
            return;
        }
        if (new_position[0] > Camera.main.pixelWidth-20)
        {
            if (dir == 1)
                dir = 2;
            else
                dir = 3;
            return;
        }
        if (new_position[1] < 50)
        {
            if (dir == 4)
                dir = 1;
            else
                dir = 2;
            return;
        }
        if (new_position[1] > Camera.main.pixelHeight-50)
        {
            if (dir == 1)
                dir = 4;
            else
                dir = 3;
            return;
        }

        
        transform.position = new_position;
    }

    public void hit(int damage)
    {
        health -= damage;
    }

}
