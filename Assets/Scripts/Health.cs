using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int healthMax;
    public int HealthMax {
        get { return healthMax; }
        private set { healthMax = value; }
    }

    [SerializeField]
    private float healthActual;
    public float HealthActual
    {
        get { return healthActual; }
        private set { healthActual = value; }
    }

    void Awake()
    {
        healthActual = healthMax;
    }

    void Start()
    {
    }

    void Update()
    {
        // Debug.Log("actual hp: " + health);
        // Debug.Log("max hp: " + healthMax);
    }

    public void ReceiveDamage(int amount)
    {
        healthActual = Mathf.Clamp(healthActual - amount, 0, healthMax);
        if (healthActual <= 0)
        {
            //die
        }
    }

    public void ReceiveHealth(int amount)
    {
        healthActual = Mathf.Clamp(healthActual + amount, 0, healthMax);
    }
}
