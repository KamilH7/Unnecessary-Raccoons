using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    ShopScreen shop;
    [SerializeField]
    DialogueManager dialogueManager;
    [SerializeField]
    GameObject ExclamationMark;

    bool firstInteraction = true;
    bool playerInside = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInside)
        {
            if (firstInteraction)
            {
                ExclamationMark.SetActive(false);
                dialogueManager.CreateDialogue("Hello wanna buy something ", "ShopKeeper", false);
                dialogueManager.CreateDialogue("Yes Gun please!", "ShopKeeper", true);
                firstInteraction = false;
            }
            else
            {
                shop.OpenShop();
            }

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            playerInside = false;
        }
    }
}
