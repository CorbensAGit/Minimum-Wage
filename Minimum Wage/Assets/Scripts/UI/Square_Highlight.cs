using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Square_Highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        sprite.color = new Color (239, 239, 239, 0); 
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        sprite.color = new Color (239, 239, 239, 255);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        sprite.color = new Color (239, 239, 239, 0); 
    }
    
}
