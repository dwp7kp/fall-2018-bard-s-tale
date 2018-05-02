﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public bool doingSlider = false;
    public Slider healthSlider;

    public int maxHealth;

    public int currHealth;
    public bool dead;

    // Use this for initialization
    void Start()
    {
        if (doingSlider)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = maxHealth;
        }
        currHealth = maxHealth;
        dead = false;
    }

    public void takeDamage(int dmg)
    {
        if (!dead)
        {
            if (dmg != -1)
            {
                currHealth -= dmg;
                if (doingSlider)
                    healthSlider.value = currHealth;
                if (currHealth < 0)
                {
                    dead = true;
                }
            }
            else
            {
                currHealth = maxHealth;
            }
        }
    }

    public int[] getHealthStats()
    {
        return new int[] { currHealth, maxHealth };
    }
}
