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
    private Color originalColour;

    private void Awake()
    {
        originalColour = image.color;
    }

    // Start is called before the first frame update
    public void OnClick()
    {
        if (usesSprite)
        {
            image.overrideSprite = (image.overrideSprite == null)
               ? sprite : null;
        }
        else
        {
            image.color = (image.color == tint) 
                ? originalColour : tint;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
