using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health { get; private set; }

    [SerializeField]
    private int healthMax;
    public int HealthMax {
        get { return healthMax; }
        private set { healthMax = value; }
    }
    

    void Awake()
    {
        health = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            receiveDamage(2);
        }
       // Debug.Log("actual hp: " + health);
       // Debug.Log("max hp: " + healthMax);
    }

    void receiveDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Mathf.Clamp(health, 0, healthMax);
            //die
        }
    }

    void receiveHealth(int amount)
    {
        health += amount;
        Mathf.Clamp(health, 0, healthMax);
    }
}
