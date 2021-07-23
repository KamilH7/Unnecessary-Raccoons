using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipArrow : MonoBehaviour
{
    public bool MouseHovering = false;
    public Sprite HoverSprite;
    public Sprite DefaultSprite;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = DefaultSprite;
    }

    private void OnMouseEnter()
    {
        MouseHovering = true;
        GetComponent<SpriteRenderer>().sprite = HoverSprite;
    }

    private void OnMouseExit()
    {
        MouseHovering = false;
        GetComponent<SpriteRenderer>().sprite = DefaultSprite;
    }
}
