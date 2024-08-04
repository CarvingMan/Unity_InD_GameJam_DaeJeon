using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorObject : InteractiveObject
{
    [SerializeField] private StageController stageController;

    [SerializeField] private GameObject m_TextDoor = null;
    private void Start()
    {
        if (m_TextDoor != null)
        {
            m_TextDoor.SetActive(false);
        }
        else
        {
            Debug.LogError("m_objTextDoor�� �������� ����");
        }

        stageController.OnStageClear += OnStageClear;
        }

    public override void OnMouseHoverEnter()
    {
        base.OnMouseHoverEnter();
        m_TextDoor.SetActive(true);
    }
    
    public override void OnMouseHoverExit()
    {
        base.OnMouseHoverExit();
        m_TextDoor.SetActive(false);
    }

    protected override void DoInteract()
    {
        if (IsInteractable == false) return;
        
        StartCoroutine(MoveToNextStageCo());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Interact();
    }

    private IEnumerator MoveToNextStageCo()
    {
        var tween = UIManager.Instance.screenTransition.FadeOut(2);
        yield return new WaitWhile(() => tween.IsPlaying());

        SceneManager.LoadScene("Stage2Scene");
    }

    private void OnStageClear()
    {
        isInteractable = true;
    }
}
