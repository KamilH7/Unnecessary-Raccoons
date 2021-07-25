using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UICharacter : MonoBehaviour
{
    Image characterImg;
    public float timePerFrame = 0.2f;

    [System.NonSerialized]
    public string currentName;
    [System.NonSerialized]
    public Sprite[] idleAnimation;
    [System.NonSerialized]
    public Sprite[] talkingAnimation;
    [System.NonSerialized]
    public Sprite[] currentAnimation;

    bool animating = true;
    int currentAnimationSprite = 0;

    private void OnEnable()
    {
        characterImg = GetComponent<Image>();

        idleAnimation = new Sprite[] { characterImg.sprite };
        talkingAnimation = new Sprite[] { characterImg.sprite };
        currentAnimation = idleAnimation;

        StartCoroutine(AnimateCharacter());
    }

    IEnumerator AnimateCharacter()
    {
        while (animating)
        {       
            if (currentAnimationSprite >= currentAnimation.Length)
            {
                currentAnimationSprite = 0;
            }

            characterImg.sprite = currentAnimation[currentAnimationSprite];
            currentAnimationSprite++;

            yield return new WaitForSeconds(timePerFrame);
            
        }
    }

    public void ChangeCharacter(DialogueCharacter character)
    {
        this.name = character.name;
        this.idleAnimation = character.idleSprites;
        this.talkingAnimation = character.talkingSprites;

        SwitchState("Idle");
    }

    public void SwitchState(string state)
    {
        if (state == "Idle")
        {
            currentAnimation = idleAnimation;
        }
        else if (state == "Talking")
        {
            currentAnimation = talkingAnimation;
        }
        else
        {
            Debug.LogError("No animation named " + state);
        }

        this.characterImg.sprite = idleAnimation[0];

        currentAnimationSprite = 0;
    }
}
