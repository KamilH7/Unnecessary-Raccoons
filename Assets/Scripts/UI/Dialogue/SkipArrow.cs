using UnityEngine;
using UnityEngine.UI;

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
