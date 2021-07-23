using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DialogueGenerator : MonoBehaviour
{
    [SerializeField]
    Camera camera;
    [SerializeField]
    GameObject textBox;

    [SerializeField]
    private Sprite[] sprites;
    string alphabetOrder = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789*/\\-+\":;,.=?!()_&^%$#@~`<>";
    char[] letterOrder;
    private Dictionary<char, LetterSprite> alphabet = new Dictionary<char, LetterSprite>();

    // Start is called before the first frame update
    void Start()
    {
        letterOrder = alphabetOrder.ToCharArray();
        textBox = Instantiate(textBox);
        textBox.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, -8);
        
        textBox.transform.parent = camera.transform;


        if (letterOrder.Length == sprites.Length)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                alphabet.Add(letterOrder[i], new LetterSprite(sprites[i], i));
            }
        }

        GameObject text = GenerateText("Co to za przystojniak :) z roku na rok wyglada coraz \n lepiej makumba lmaooooooooooooooooo!");
    }



    GameObject GenerateText(string text)
    {
        int x = -123;
        int y = -60;
        int temp = x;
        char[] charactersToGenerate = text.ToCharArray();
        GameObject container = new GameObject("TextContainer");
        container.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, -9);
        container.transform.parent = camera.transform;

        for (int i = 0; i < charactersToGenerate.Length; i++)
        {
            if (charactersToGenerate[i] == ' ')
            {
                x += 3;
                continue;
            }

            if (charactersToGenerate[i] == '\n')
            {
                y -= 10;
                x = temp;
                continue;
            }


            LetterSprite letter = alphabet[charactersToGenerate[i]];

            GameObject obj = new GameObject(charactersToGenerate[i].ToString());
            obj.transform.position = new Vector3(x - letter.letterStart, y, -9);
            obj.AddComponent<SpriteRenderer>();
            obj.GetComponent<SpriteRenderer>().sprite = letter.sprite;
            obj.GetComponent<SpriteRenderer>().enabled = false;

            obj.transform.parent = container.transform;

            x += letter.letterWidth + 1;
        }

        StartCoroutine(SpawnLetters(container.GetComponentsInChildren<SpriteRenderer>()));

        return container;
    }

    IEnumerator SpawnLetters(SpriteRenderer[] letters)
    {
        for (int i = 0; i < letters.Length; i++)
        {
            if (letters[i] == null)
                break;

            letters[i].enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }
}

class LetterSprite
{
    public Sprite sprite;
    public int letterWidth;
    public int letterStart;

    public LetterSprite(Sprite sprite, int position)
    {
        this.sprite = sprite;
        GetLetterData(position);
    }

    void GetLetterData(int position)
    {
        Texture2D texture = sprite.texture;

        //get current letter position
        int startX = 0;
        int startY = sprite.texture.height - 1;

        for (int i = 0; i < position; i++)
        {
            startX += 10;

            if (startX >= texture.width)
            {
                startX = 0;
                startY -= 10;
            }
        }

        //scan the letter to find rightmost and leftmost non-transparent pixels
        int letterStartX = 0;
        int letterEndX = 0;

        for (int i = 0; i < 10; i++)
        {
            bool found = false;

            for (int j = 0; j < 10; j++)
            {
                if (texture.GetPixel(startX + i, startY - j).a == 1)
                {
                    letterStartX = startX + i;
                    letterStart = i + 1;
                    found = true;
                    break;
                }
            }

            if (found)
                break;
        }

        for (int i = 9; i >= 0; i--)
        {
            bool found = false;

            for (int j = 9; j >= 0; j--)
            {
                if (texture.GetPixel(startX + i, startY - j).a == 1)
                {
                    letterEndX = startX + i;
                    found = true;
                    break;
                }
            }

            if (found)
                break;
        }

        //calculate the width of the letter
        letterWidth = letterEndX - letterStartX + 1;
    }
}