using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogueUI : MonoBehaviour
{
    public Dialogue[] dialogues;
    
    private void OnGUI()
    {
        if (GUILayout.Button("Test Dialogue"))
        {
            UIManager.Instance.dialogueUIController.ShowDialogue(dialogues);
        }
    }
}
