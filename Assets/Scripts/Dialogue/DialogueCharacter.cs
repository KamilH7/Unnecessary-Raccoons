using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueCharacter 
{
    public string name;
    public Sprite[] idleSprites;
    public Sprite[] talkingSprites;

    public DialogueCharacter(string name, Sprite[] idleSprites, Sprite[] talkingSprites)
    {
        this.name = name;
        this.idleSprites = idleSprites;
        this.talkingSprites = talkingSprites;
    }

}
