using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkipArrow : MonoBehaviour
{
    [SerializeField]
    Image arrowImage;
    [SerializeField]
    Sprite HoverSprite;
    [SerializeField]
    Sprite DefaultSprite;

    public void OnPointerEnter()
    {
        arrowImage.sprite = HoverSprite;
    }

    public void OnPointerExit()
    {
        arrowImage.sprite = DefaultSprite;
    }
}
