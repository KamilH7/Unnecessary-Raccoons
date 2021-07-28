using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Health playerHealth;
    [SerializeField]
    private Image healthSlider;
    void Start()
    {
        //Debug.Log(playerHealth.health);
        healthSlider.fillAmount = playerHealth.HealthActual / playerHealth.HealthMax;
    }

    void Update()
    {
        healthSlider.fillAmount = playerHealth.HealthActual / playerHealth.HealthMax;
    }
}
