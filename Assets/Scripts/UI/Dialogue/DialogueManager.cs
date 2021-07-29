using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    List<Dialogue> dialogueQueue = new List<Dialogue>();

    [SerializeField]
    TextGenerator textGenerator;

    [Header("Canvas References")]
    [SerializeField]
    GameObject DialogueContainer;
    [SerializeField]
    GameObject textContainer;
    [SerializeField]
    Image textBoxImg;
    [SerializeField]
    Image skipArrowImg;
    [SerializeField]
    UICharacter npc;
    [SerializeField]
    UICharacter player;

    [Header("Dialogue Setttings")]
    [SerializeField]
    DialogueCharacter[] dialogueCharacters;
    [SerializeField]
    float letterSpawnSpeed = 0.1f;

    public void CreateDialogue(string text, string npc, bool playerDialogue)
    {
        dialogueQueue.Add(new Dialogue(textGenerator.GenerateText(text, textContainer), FindCharacter(npc), playerDialogue));
        DisplayNextText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CreateDialogue("Hello wanna buy something ", "ShopKeeper", false);
            CreateDialogue("Yes Gun please!", "ShopKeeper", true);
        }
    }

    void Start()
    {
        DisableDialogueUI();
        StartCoroutine(AnimateArrow(skipArrowImg.transform));
        
    }


    public void SkipArrowClicked()
    {
        Dialogue dialogueToRemove = dialogueQueue[0];
        dialogueQueue.Remove(dialogueToRemove);
        Destroy(dialogueToRemove.textContainer);
        DisplayNextText();
    }

    public void DisplayNextText()
    {
        if (dialogueQueue.Count > 0)
        {
            EnableDialogueUI();

            npc.ChangeCharacter(dialogueQueue[0].npc);
            player.ChangeCharacter(FindCharacter("Player"));

            if (dialogueQueue[0].playerDialogue == true)
            {
                player.SwitchState("Talking");
                npc.SwitchState("Idle");
            }
            else
            {
                player.SwitchState("Idle");
                npc.SwitchState("Talking");
            }

            StartCoroutine(SpawnLetters(dialogueQueue[0].textContainer.GetComponentsInChildren<Image>()));
        }
        else
        {
            DisableDialogueUI();
        }
    }

    public void DisableDialogueUI()
    {
        dialogueQueue.Clear();
        DialogueContainer.SetActive(false);
    }

    void EnableDialogueUI()
    {
        DialogueContainer.SetActive(true);
    }

    DialogueCharacter FindCharacter(string name)
    {
        foreach (DialogueCharacter character in dialogueCharacters)
        {
            if (character.name == name)
                return character;
        }
        Debug.Log("No character named "+name);
        return null;
    }

    IEnumerator SpawnLetters(Image[] letters)
    {
        bool interruped = false;

        for (int i = 0; i < letters.Length; i++)
        {
            if (letters[i] == null)
            {
                interruped = true;
                break;
            }

            letters[i].enabled = true;
            yield return new WaitForSeconds(letterSpawnSpeed);
        }

        if (!interruped)
        {
            npc.SwitchState("Idle");
            player.SwitchState("Idle");
        }
    }
    
    IEnumerator AnimateArrow(Transform arrow)
    {
        bool running = true;
        float startingPos = arrow.localPosition.x;
        float moveBy = 1;

        while (running)
        {
            if (Mathf.Abs(startingPos - arrow.localPosition.x) > 3 * textGenerator.pixelSize)
            {
                moveBy *= -1;
            }

            arrow.localPosition = new Vector3(arrow.localPosition.x + moveBy * textGenerator.pixelSize, arrow.localPosition.y, arrow.localPosition.z);
            yield return new WaitForSeconds(0.05f);
        }
    }
    
}