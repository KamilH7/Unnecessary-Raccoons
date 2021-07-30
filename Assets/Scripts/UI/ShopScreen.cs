using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScreen : MonoBehaviour
{

    [SerializeField]
    GameObject ShopUI;


    public void OpenShop()
    {
        Time.timeScale = 0f;
        ShopUI.SetActive(true);
    }

    public void CloseShop()
    {
        Time.timeScale = 1f;
        ShopUI.SetActive(false);
    }

    public void BackpackUpgrade()
    {
        Debug.Log("Upgrading Backpack");
    }

    public void WeaponUpgrade()
    {
        Debug.Log("Upgrading Weapon");
    }

    public void Heal()
    {
        Debug.Log("Healing");
    }
}

