using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue 
{
    public GameObject textContainer;
    public DialogueCharacter npc;
    public bool playerDialogue;

    public Dialogue(GameObject textContainer, DialogueCharacter npc, bool playerDialogue)
    {
        this.textContainer = textContainer;
        this.npc = npc;
        this.playerDialogue = playerDialogue;
    }
}


