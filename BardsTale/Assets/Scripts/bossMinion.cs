using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMinion : MonoBehaviour {

    //stats
    public int maxHealth = 1;
    public int health = 1;
    public int damage = 1;
    private float baseSpeed = 2f;
    private float speed = 2.5f;
    private float attackTimer = 1.5f;

    private int dir = 2;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!static_information.isPaused)
        {

            if (attackTimer > 0)
                attackTimer -= Time.deltaTime;


            if (attackTimer <= 0)
                ; //Deal damage if touching bard
            AttemptMove(movementAI());
        }
    }
    public float[] movementAI()
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
    public void AttemptMove(float[] movement)
    {

        Vector2 new_position = new Vector2(transform.position.x + movement[0], transform.position.y + movement[1]);

        transform.position = new_position;
    }

    public void hit(int damage)
    {
        health -= damage;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        print("Destroying Egg and spawning skele");
        //col.gameObject.GetComponent<bossProjectile>.
        Destroy(col.gameObject);
    }
}
