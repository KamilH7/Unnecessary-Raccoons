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
        healthSlider.fillAmount = playerHealth.health / playerHealth.HealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.fillAmount = playerHealth.health / playerHealth.HealthMax;
    }
}
