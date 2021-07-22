using System.Collections.Generic;
using UnityEngine;

public class DialogueGenerator : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    string alphabetOrder = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789*/\\-+\";:,.=?!()_&^%$#@~`<>";
    [SerializeField]
    char[] letterOrder;
    private Dictionary<char, LetterSprite> alphabet = new Dictionary<char, LetterSprite>();

    // Start is called before the first frame update
    void Start()
    {
        letterOrder = alphabetOrder.ToCharArray();

        if (letterOrder.Length == sprites.Length)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                alphabet.Add(letterOrder[i], new LetterSprite(sprites[i], i));
            }
        }

        GenerateDialogue(0, 0, "Adam Schwemk nie zagra w lola \n siema naura");
    }


    // Update is called once per frame
    void Update()
    {

    }


    void GenerateDialogue(int x, int y, string text)
    {
        int temp = x;
        char[] charactersToGenerate = text.ToCharArray();

        foreach(char character in charactersToGenerate)
        {
            if (character == ' ')
            {
                x += 3;
                continue;
            }

            if (character == '\n')
            {
                y -= 10;
                x = temp;
                continue;
            }

            LetterSprite letter = alphabet[character];
    
            GameObject obj = new GameObject();
            obj.transform.position = new Vector3(x-letter.letterStart,y,-100);
            obj.AddComponent<SpriteRenderer>();
            obj.GetComponent<SpriteRenderer>().sprite = letter.sprite;

            x += letter.letterWidth + 1;
           
            Instantiate(obj);
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

        letterWidth = letterEndX - letterStartX + 1;
    }
}