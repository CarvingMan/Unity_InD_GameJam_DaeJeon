using System;
using System.Collections;
using System.Collections.Generic;
using Febucci.UI;
using TMPro;
using UnityEngine;

[Serializable]
public class Dialogue
{
    public string name;
    public string dialogue;
}

public class DialogueUIController : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private TextAnimator_TMP textAnimator;
    [SerializeField] private TextMeshProUGUI nameText;

    private Dialogue[] _textsToShow;
    private int _dialogueIndex = 0;
    
    public void ShowDialogue(Dialogue[] texts)
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
        var dialogue = _textsToShow[_dialogueIndex];
        if (string.IsNullOrEmpty(dialogue.name))
        {
            nameText.gameObject.SetActive(false);
        }
        else
        {
            nameText.text = dialogue.name;
            nameText.gameObject.SetActive(true);
        }

        textAnimator.SetText(dialogue.dialogue);
    }
}
