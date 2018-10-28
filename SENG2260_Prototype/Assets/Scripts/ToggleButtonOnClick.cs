using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ToggleButtonOnClick : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private Color tint;
    [SerializeField]
    private bool usesSprite;
    private Sprite originalSprite;
    private Color originalColour;
    private bool IsOn { get; set; }

    private void Start()
    {
        image = gameObject.GetComponent<Image>();
        originalSprite = image.sprite;
        originalColour = image.color;
    }

    // Start is called before the first frame update
    public void OnClick()
    {
        IsOn = !IsOn;
    }

    public void FixedUpdate()
    {
        if (usesSprite)
        {
            image.sprite = (IsOn) ? sprite : originalSprite;
        }
        else
        {
            image.color = (IsOn) ? originalColour : tint;
        }
    }
}
