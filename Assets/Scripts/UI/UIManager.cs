using System.Collections;
using System.Collections.Generic;
using Eshikivo.DesignPatterns;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public DialogueUIController dialogueUIController;
    public ScreenTransition screenTransition;

    public Image teddyBearImage;
    public Image CountImage;

    public Sprite[] numSprites;
    
    public void ShowTeddyBear()
    {
        teddyBearImage.gameObject.SetActive(true);
    }

    public void ChangeCount(int index)
    {
        if (CountImage == null) return;
        if (index >= numSprites.Length) return;
        CountImage.sprite = numSprites[index];
    }

}
