using UnityEngine;

public class Letter
{
    public Sprite sprite;
    public int letterWidth;
    public int letterStart;

    public Letter(Sprite sprite, int position)
    {
        this.sprite = sprite;
        SetLetterData(position);
    }

    void SetLetterData(int position)
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