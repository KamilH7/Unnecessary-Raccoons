using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGenerator : MonoBehaviour
{
    public float pixelSize = 32000 / 270;

    [SerializeField]
    int letterSpacing = 1;
    [SerializeField]
    int spaceSize = 3;
    [SerializeField]
    int newLineDistance = 2;

    [SerializeField]
    GameObject letterPrefab;
    [SerializeField]
    GameObject containerPrefab;
    Dictionary<char, Letter> alphabet = new Dictionary<char, Letter>();

    [Header("Font Setttings")]
    [SerializeField]
    Sprite[] fontSprites;
    [SerializeField]
    string fontOrder;

    void Start()
    {
        GenerateAlphabet();
    }

    public GameObject GenerateText(string text, GameObject parent)
    {
        char[] charactersToGenerate = text.ToCharArray();
        GameObject container = Instantiate(containerPrefab, parent.transform);

        float posX = 0;
        float posY = 0;
        float temp = posX;

        for (int i = 0; i < charactersToGenerate.Length; i++)
        {

            if (charactersToGenerate[i] == ' ')
            {
                posX += spaceSize * pixelSize;
                continue;
            }

            if (charactersToGenerate[i] == '\n')
            {
                posY -= newLineDistance * pixelSize;
                posX = temp;
                continue;
            }

            Letter letterInfo = null;

            try
            {
                letterInfo = alphabet[charactersToGenerate[i]];
            }
            catch
            {
                Debug.LogError(charactersToGenerate[i] + " is not present in the dictionary!");
                continue;
            }

            GameObject letter = Instantiate(letterPrefab, container.transform);
            letter.transform.localPosition = Vector3.zero;

            letter.GetComponent<Image>().sprite = letterInfo.sprite;
            letter.GetComponent<Image>().enabled = false;

            letter.transform.localPosition = new Vector3(posX - (letterInfo.letterStart), posY, 0);

            posX += (letterInfo.letterWidth + letterSpacing) * pixelSize;
        }

        return container;
    }

    public void GenerateAlphabet()
    {
        //generate alphabet dictionarty
        char[] letterOrder = fontOrder.ToCharArray();

        if (letterOrder.Length == fontSprites.Length)
        {
            for (int i = 0; i < fontSprites.Length; i++)
            {
                alphabet.Add(letterOrder[i], new Letter(fontSprites[i], i));
            }
        }
        else
        {
            Debug.LogError("Alphabet order is not the same size as the amount of sprites");
        }
    }

    public GameObject GenerateTextEditor(string text, GameObject parent)
    {
        GenerateAlphabet();
        GameObject container = GenerateText(text, parent);
        Image[] letters = container.GetComponentsInChildren<Image>();

        for (int i = 0; i < letters.Length; i++)
        {
            letters[i].enabled = true;
        }

        alphabet.Clear();

        return container;
    }
}

