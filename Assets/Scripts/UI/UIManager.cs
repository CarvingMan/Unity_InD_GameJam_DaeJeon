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
    
    public void ShowTeddyBear()
    {
        teddyBearImage.gameObject.SetActive(true);
    }
    
}
