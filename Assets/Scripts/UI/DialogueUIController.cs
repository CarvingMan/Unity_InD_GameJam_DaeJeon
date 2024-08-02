using System.Collections;
using System.Collections.Generic;
using Febucci.UI;
using UnityEngine;

public class DialogueUIController : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private TextAnimator_TMP textAnimator;

    private string[] _textsToShow;
    private int _dialogueIndex = 0;
    
    public void ShowDialogue(string[] texts)
    {
        _textsToShow = texts;
        
        SetCurrentText();
        content.SetActive(true);
        _dialogueIndex = 0;
    }

    public void CloseDialogue()
    {
        content.SetActive(false);
    }

    public void OnDialogueClick()
    {
        if (textAnimator.allLettersShown)
        {
            _dialogueIndex++;

            if (_dialogueIndex >= _textsToShow.Length)
            {
                CloseDialogue();
                return;
            }

            SetCurrentText();
        }
        else
        {
            SkipText();
        }
    }

    private void SkipText()
    {
        if (textAnimator.allLettersShown) return;
        
        textAnimator.SetVisibilityEntireText(true);
    }

    private void SetCurrentText()
    {
        string text = _textsToShow[_dialogueIndex];
        textAnimator.SetText(text);
    }
}
